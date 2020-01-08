/**
* @author   C. Maréchal, D. Aigroz, F. Troller
* @date     2019-05-06
* @brief    Class for connect to Google account
* @file     Eduge.cs
* @version  1.0.0.0
*/

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientProxmox
{
    public class Eduge
    {
        #region Constants
        // Infos get from exemple app
        readonly string clientID = Properties.Resources.ClientID;
        readonly string clientSecret = Properties.Resources.ClientSecret;
        const string authorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
        #endregion

        #region Variables
        private string _name = string.Empty;
        private string _urlPic = null;
        private string _fullName = string.Empty;
        private bool student = true;
        #endregion

        #region Properties
        /// <summary>
        /// Return the name of account
        /// </summary>
        public string Name { get => _name; set => _name = value; }

        /// <summary>
        /// return the full name of account
        /// </summary>
        public string FullName { get => _fullName; set => _fullName = value; }


        /// <summary>
        /// Return the URL of picture
        /// </summary>
        public string UrlPic { get => _urlPic; set => _urlPic = value; }


        /// <summary>
        /// Return if this account is for student or not
        /// </summary>
        public bool Student { get => student; set => student = value; }
        #endregion

        #region Constructors
        /// <summary>
        /// Use for connect to google account
        /// </summary>
        public Eduge()
        {

        }
        #endregion

        #region Methods Private
        /// <summary>
        /// Send request of user
        /// </summary>
        /// <param name="code">The validate code</param>
        /// <param name="code_verifier">The code verifier</param>
        /// <param name="redirectURI">The url to redirect</param>
        private void ExecuteRequest(string code, string code_verifier, string redirectURI)
        {
            // builds the  request
            string tokenRequestURI = "https://www.googleapis.com/oauth2/v4/token";
            string tokenRequestBody = string.Format("code={0}&redirect_uri={1}&client_id={2}&code_verifier={3}&client_secret={4}&scope=&grant_type=authorization_code",
                code,
                Uri.EscapeDataString(redirectURI),
                clientID,
                code_verifier,
                clientSecret
                );

            // sends the request
            HttpWebRequest tokenRequest = (HttpWebRequest)WebRequest.Create(tokenRequestURI);
            tokenRequest.Method = "POST";
            tokenRequest.ContentType = "application/x-www-form-urlencoded";
            tokenRequest.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";
            byte[] _byteVersion = Encoding.ASCII.GetBytes(tokenRequestBody);
            tokenRequest.ContentLength = _byteVersion.Length;
            Stream stream = tokenRequest.GetRequestStream();
            stream.WriteAsync(_byteVersion, 0, _byteVersion.Length);
            Thread.Sleep(400);
            stream.Close();

            try
            {
                // gets the response
                WebResponse tokenResponse = tokenRequest.GetResponse();
                using (StreamReader reader = new StreamReader(tokenResponse.GetResponseStream()))
                {
                    // reads response body
                    string responseText = reader.ReadToEnd();

                    // converts to dictionary
                    Dictionary<string, string> tokenEndpointDecoded = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseText);

                    string access_token = tokenEndpointDecoded["access_token"];
                    UserinfoCall(access_token);
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    if (ex.Response is HttpWebResponse response)
                    {
                        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                        {
                            // reads response body
                            string responseText = reader.ReadToEnd();
                        }
                    }
                }
            }
        }


        /// <summary>
        /// Get user info from google authentificate
        /// </summary>
        /// <param name="access_token">access token of the user</param>
        private void UserinfoCall(string access_token)
        {

            // builds the  request
            string userinfoRequestURI = "https://www.googleapis.com/oauth2/v3/userinfo";

            // sends the request
            HttpWebRequest userinfoRequest = (HttpWebRequest)WebRequest.Create(userinfoRequestURI);
            userinfoRequest.Method = "GET";
            userinfoRequest.Headers.Add(string.Format("Authorization: Bearer {0}", access_token));
            userinfoRequest.ContentType = "application/x-www-form-urlencoded";
            userinfoRequest.Accept = "Accept=text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

            // gets the response
            using (WebResponse userinfoResponse = userinfoRequest.GetResponse())
            {
                JObject JSON = JObject.Parse(new StreamReader(userinfoResponse.GetResponseStream()).ReadToEnd());
                this.UrlPic = JSON["picture"].ToString();
                this.Name = JSON["given_name"].ToString();
                this.FullName = JSON["family_name"].ToString();
                this.Student = (JSON["family_name"].ToString().StartsWith("EDU-")? false:true); 
            }

        }
        #endregion

        #region Methods Public
        /// <summary>
        /// Connect to google account
        /// </summary>
        public void Connect()
        {
            // Generates state and PKCE values.
            string state = RandomDataBase64url(32);
            string code_verifier = RandomDataBase64url(32);
            string code_challenge = Base64urlencodeNoPadding(Sha256(code_verifier));
            const string code_challenge_method = "S256";

            // Creates a redirect URI using an available port on the loopback address.
            var listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            var port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            string redirectURI = string.Format("http://{0}:{1}/", IPAddress.Loopback, port);
            //output("redirect URI: " + redirectURI);

            // Creates an HttpListener to listen for requests on that redirect URI.
            var http = new HttpListener();
            http.Prefixes.Add(redirectURI);
            //output("Listening..");
            http.Start();

            // Creates the OAuth 2.0 authorization request.
            string authorizationRequest = string.Format("{0}?response_type=code&scope=openid%20profile&redirect_uri={1}&client_id={2}&state={3}&code_challenge={4}&code_challenge_method={5}",
                authorizationEndpoint,
                System.Uri.EscapeDataString(redirectURI),
                clientID,
                state,
                code_challenge,
                code_challenge_method);

            // Opens request in the browser.
            System.Diagnostics.Process.Start(authorizationRequest);

            // Waits for the OAuth authorization response.
            var context = http.GetContext();



            // Sends an HTTP response to the browser.
            var response = context.Response;
            string responseString = string.Format("<html><head><meta http-equiv='refresh' content='10;url=https://google.com'></head><body>Please return to the app.</body></html>");
            var buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            var responseOutput = response.OutputStream;
            Task responseTask = responseOutput.WriteAsync(buffer, 0, buffer.Length).ContinueWith((task) =>
            {
                responseOutput.Close();
                http.Stop();
                Console.WriteLine("HTTP server stopped.");
            });

            // Checks for errors.
            if (context.Request.QueryString.Get("error") != null)
            {
                return;
            }
            if (context.Request.QueryString.Get("code") == null
                || context.Request.QueryString.Get("state") == null)
            {
                return;
            }

            // extracts the code
            var code = context.Request.QueryString.Get("code");
            var incoming_state = context.Request.QueryString.Get("state");

            // Compares the receieved state to the expected value, to ensure that
            // this app made the request which resulted in authorization.
            if (incoming_state != state)
            {
                return;
            }

            // Starts the code exchange at the Token Endpoint.
            ExecuteRequest(code, code_verifier, redirectURI);

        }




        /// <summary>
        /// Returns URI-safe data with a given input length.
        /// </summary>
        /// <param name="length">Input length (nb. output will be longer)</param>
        /// <returns>return string of base64 url</returns>
        public static string RandomDataBase64url(uint length)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] bytes = new byte[length];
            rng.GetBytes(bytes);
            return Base64urlencodeNoPadding(bytes);
        }

        /// <summary>
        /// Returns the SHA256 hash of the input string.
        /// </summary>
        /// <param name="inputString">The string to hash</param>
        /// <returns>return byte array of hash</returns>
        public static byte[] Sha256(string inputString)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(inputString);
            SHA256Managed sha256 = new SHA256Managed();
            return sha256.ComputeHash(bytes);
        }

        /// <summary>
        /// Base64url no-padding encodes the given input buffer.
        /// </summary>
        /// <param name="buffer">The byte to cache</param>
        /// <returns>return string of value encoded</returns>
        public static string Base64urlencodeNoPadding(byte[] buffer)
        {
            string base64 = Convert.ToBase64String(buffer);

            // Converts base64 to base64url.
            base64 = base64.Replace("+", "-");
            base64 = base64.Replace("/", "_");
            // Strips padding.
            base64 = base64.Replace("=", "");

            return base64;
        }
        #endregion

    }
}
