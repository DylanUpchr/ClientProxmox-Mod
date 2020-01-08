/**
 * @author   Troller Fabian
 * @date     2019-04-08
 * @brief    Class for connect to server Pormox and make request
 * @file     ProxmoxClient.cs
 * @version  1.0.0.0
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

using Newtonsoft.Json.Linq;

namespace ClientProxmox
{
    public class ProxmoxClient
    {

        #region Constants
        const char DEFAULT_SEPARATOR_TOKEN = ':';
        const char DEFAULT_SEPARATOR_COOKIE = '=';
        const string DEFAULT_PASSWORD = "";
        const int DEFAULT_VALUE_ARRAY_HEADER = 1;
        const int DEFAULT_VALUE_ARRAY_SIZE_TOKEN_COOKIE = 2;
        const int DEFAULT_CSRFTOKEN_NAME = 0;
        const int DEFAULT_CSRFTOKEN_VALUE = 1;
        const int DEFAULT_VALUE_STORAGE = 0;
        const int DEFAULT_ARRAY_COOKIE = 0;
        const int DEFAULT_ARRAY_CSRFTOKEN = 1;
        #endregion

        #region Variables
        private string _url = string.Empty;

        private string _username = string.Empty;
        private string _password = string.Empty;
        private string _realm = string.Empty;

        private string _cookie = string.Empty;
        private string _csrftoken = string.Empty;
        private List<string> _storage = new List<string>();

        private List<string> _nodesName = new List<string>();
        private List<string> _os = new List<string>();

        private TimeSpan csrfExpire;
        #endregion

        #region Properties
        /// <summary>
        /// Return the URL for Proxmox server
        /// </summary>
        public string Url { get => _url; private set => _url = value; }


        /// <summary>
        /// Return Username use for authentificate
        /// </summary>
        public string Username { get => _username; private set => _username = value; }

        /// <summary>
        /// Return Password use for authentificate
        /// </summary>
        public string Password { get => _password; private set => _password = value; }

        /// <summary>
        /// Return the realm for Proxmox server
        /// </summary>
        public string Realm { get => _realm; private set => _realm = value; }


        /// <summary>
        /// Return value of cookie for Proxmox authentificate
        /// </summary>
        public string Cookie
        {
            get { return _cookie; }
            private set { _cookie = value; }
        }


        /// <summary>
        /// The value of cookier without name
        /// </summary>
        public string CookieValue
        {
            get { return Cookie.Substring(SharedObject.Client.Cookie.IndexOf(DEFAULT_SEPARATOR_COOKIE) + DEFAULT_VALUE_ARRAY_HEADER); }
        }

        /// <summary>
        /// Name of cookie for Proxmox server
        /// </summary>
        public string CookieName
        {
            get { return Cookie.Substring(0,SharedObject.Client.Cookie.IndexOf(DEFAULT_SEPARATOR_COOKIE)); }
        }

        /// <summary>
        /// Return the CSRF token of session Proxmox
        /// </summary>
        public string Csrftoken
        {
            get
            {
                if (csrfExpire >= csrfExpire.Add(TimeSpan.FromMinutes(118)))
                {
                    Csrftoken = GetCookieCSRFValue(this.Username, this.Password, this.Realm)[1];
                }
                return _csrftoken;
            }
            private set
            {
                csrfExpire = TimeSpan.Parse(DateTime.Now.ToShortTimeString().ToString());
                _csrftoken = value;
            }
        }

        /// <summary>
        /// Return node of account
        /// </summary>
        public List<string> NodeName { get => _nodesName; private set => _nodesName = value; }


        /// <summary>
        /// Return list string of OS availaible
        /// </summary>
        public List<string> OS { get => _os; private set => _os = value; }


        /// <summary>
        /// Return storage of image
        /// </summary>
        public List<string> Storage { get => _storage; set => _storage = value; }

        #endregion

        #region Constructor
        /// <summary>
        /// Connect and get all authtificate from Proxmox server
        /// </summary>
        /// <param name="url"></param>
        public ProxmoxClient(string url, string node)
        {
            this.Url = url;
            this.NodeName = new List<string>() { node };
        }

        /// <summary>
        /// Constructor of target url
        /// </summary>
        /// <param name="url">string of web site url</param>
        public ProxmoxClient(string url, string username, string password, string realm)
        {
            this.Url = url;
            this.Username = username;
            this.Password = password;
            this.Realm = realm;
            this.Cookie = GetCookieCSRFValue(this.Username, this.Password, this.Realm)[DEFAULT_ARRAY_COOKIE];
            this.Csrftoken = GetCookieCSRFValue(this.Username, this.Password, this.Realm)[DEFAULT_ARRAY_CSRFTOKEN];
            this.NodeName = GetNodes();
            this.NodeName.ForEach((element) => { this.OS.AddRange(GetOSList(element)); });
            this.NodeName.ForEach((element) => { this.Storage.AddRange(GetStorageName(element)); });
        }
        #endregion

        #region Methods Public
        /// <summary>
        /// Make GET request to url
        /// </summary>
        /// <returns>Return WebResponse</returns>
        public WebResponse SimpleGet()
        {
            HttpWebRequest request = CreateRequestWeb(new Uri(this.Url), WebRequestMethods.Http.Get);
            return request.GetResponse();
        }

        /// <summary>
        /// GET request with value of cookie
        /// </summary>
        /// <param name="cookieValue">The cookie value to use in request</param>
        /// <returns>Return WebResponse</returns>
        public WebResponse Get(string node, string type, string action)
        {
            Uri uri = new Uri($"{this.Url}/api2/json/nodes/{node}/{type}/{action}");
            var request = CreateRequestWeb(uri, WebRequestMethods.Http.Get);

            try
            {
                // Add cookie to headers request
                request.Headers.Set(HttpRequestHeader.Cookie, this.Cookie);
                return request.GetResponse();
            }
            catch (WebException)
            {
                UpdateCSRFCookie();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return null;
        }

        /// <summary>
        /// Create VM on server Proxmox
        /// </summary>
        /// <param name="node">The node of server</param>
        /// <param name="type">The type of VM LXC / QEMU</param>
        /// <param name="os">The os for start the VM</param>
        /// <param name="vmid">The vmid number</param>
        /// <param name="name">The name of VM</param>
        /// <param name="cpuCores">The number of cpu allow to VM</param>
        /// <param name="memorySize">The number of memory allow</param>
        /// <param name="sizeDisk">The size of disk</param>
        /// <param name="password">The password only for LXC</param>
        /// <returns>The WebResponse of request</returns>
        public WebResponse CreateNewVPS(string node, string type, string os, string vmid,
            string name, uint cpuCores, double memorySize, double sizeDisk, string password = DEFAULT_PASSWORD, bool privileged = false)
        {
            Uri uri = new Uri($"{this.Url}/api2/json/nodes/{node}/{type}");
            WebRequest request = CreateRequestWeb(uri, WebRequestMethods.Http.Post);

            if (this.Cookie != string.Empty && this.Csrftoken != string.Empty)
            {
                // Add cookie to headers request
                request.Headers.Set(HttpRequestHeader.Cookie, this.Cookie);
                string tmp = this.Csrftoken;
                string[] csrf = { tmp.Substring(0, tmp.IndexOf(DEFAULT_SEPARATOR_TOKEN)), tmp.Substring(tmp.IndexOf(DEFAULT_SEPARATOR_TOKEN) + DEFAULT_VALUE_ARRAY_HEADER) };
                request.Headers.Set(csrf[DEFAULT_CSRFTOKEN_NAME], csrf[DEFAULT_CSRFTOKEN_VALUE]);
            }


            string dataToSend = string.Empty;
            if (type == VPS.TYPE.LXC)
            {
                string priviledgeValue = ((privileged == true) ? 1 : 0).ToString();
                // Create request
                dataToSend = $"hostname={name}&password={password}&net0=name%3Deth0%2Cbridge%3D" +
                                 $"vmbr0%2Cfirewall%3D1%2Cip%3Ddhcp&ostemplate=local:{os}&unprivileged={priviledgeValue}" +
                                 $"&rootfs={Storage[DEFAULT_VALUE_STORAGE]}:{sizeDisk}&vmid={vmid}&cores={cpuCores}&memory={memorySize}";
            }
            else if (type == VPS.TYPE.QEMU)
            {
                dataToSend = $"name={name}&net0=model%3De1000%2Cbridge%3Dvmbr0%2Cfirewall%3D1&" +
                                 $"ide1=file%3Dlocal:{os}%2Cmedia%3Dcdrom&" +
                    $"sata1=file%3D{Storage[DEFAULT_VALUE_STORAGE]}:{sizeDisk}&vmid={vmid}&cores={cpuCores}&memory={memorySize}";
            }


            // Encode data
            byte[] data = Encoding.Default.GetBytes(dataToSend.ToCharArray());


            // Send request and wait response
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            return request.GetResponse();
        }



        /// <summary>
        /// Make PUT request for modify value of VPS
        /// </summary>
        /// <param name="node">The node of VPS</param>
        /// <param name="type">The type of VPS</param>
        /// <param name="vmid">The vmid of VPS</param>
        /// <param name="name">The name of VPS</param>
        /// <param name="cpuCores">The number of cores for CPU</param>
        /// <param name="memorySize">The number of RAM</param>
        /// <param name="sizeDisk">The size disk of VPS</param>
        /// <returns>Return result of request</returns>
        public WebResponse ModifyVPSPut(string node, string type, string vmid,
            string name, uint cpuCores, double memorySize)
        {
            Uri uri = new Uri($"{this.Url}/api2/json/nodes/{node}/{type}/{vmid}/config");
            string data = string.Empty;
            HttpWebRequest request = CreateRequestWeb(uri, WebRequestMethods.Http.Put);

            if (this.Cookie != string.Empty || this.Csrftoken != string.Empty)
            {
                // Add cookie to headers request
                request.Headers.Set(HttpRequestHeader.Cookie, SharedObject.Client.Cookie);
                string tmp = SharedObject.Client.Csrftoken;
                string[] csrf = { tmp.Substring(0, tmp.IndexOf(DEFAULT_SEPARATOR_TOKEN)), tmp.Substring(tmp.IndexOf(DEFAULT_SEPARATOR_TOKEN) + DEFAULT_VALUE_ARRAY_HEADER) };
                request.Headers.Set(csrf[DEFAULT_CSRFTOKEN_NAME], csrf[DEFAULT_CSRFTOKEN_VALUE]);
            }

            // Add data to the PUT request
            if (type == VPS.TYPE.LXC)
            {
                data = $"cores={cpuCores}&memory={memorySize}&hostname={name}";
            }
            else if (type == VPS.TYPE.QEMU)
            {
                data = $"name={name}&cores={cpuCores}&memory={memorySize}";
            }

            // Encode data
            byte[] dataEncoded = Encoding.ASCII.GetBytes(data);

            // Send data for PUT request
            using (Stream str = request.GetRequestStream())
            {
                str.Write(dataEncoded, 0, dataEncoded.Length);
            }

            return request.GetResponse();
        }


        /// <summary>
        /// Make PUT request for set the size disk of VPS
        /// </summary>
        /// <param name="node">The node of VPS</param>
        /// <param name="type">The type of VPS</param>
        /// <param name="vmid">The vmid of VPS</param>
        /// <param name="sizeDisk">The size of disk</param>
        /// <returns></returns>
        public WebResponse ResizeDisk(string node, string type, string vmid, string sizeDisk)
        {
            Uri uri = new Uri($"{this.Url}/api2/json/nodes/{node}/{type}/{vmid}/resize");
            HttpWebRequest request = CreateRequestWeb(uri, WebRequestMethods.Http.Put);

            if (this.Cookie != string.Empty && this.Csrftoken != string.Empty)
            {
                // Add cookie to headers request
                request.Headers.Set(HttpRequestHeader.Cookie, SharedObject.Client.Cookie);
                string tmp = SharedObject.Client.Csrftoken;
                string[] csrf = { tmp.Substring(0, tmp.IndexOf(DEFAULT_SEPARATOR_TOKEN)),
                    tmp.Substring(tmp.IndexOf(DEFAULT_SEPARATOR_TOKEN) + DEFAULT_CSRFTOKEN_VALUE) };
                request.Headers.Set(csrf[DEFAULT_CSRFTOKEN_NAME], csrf[DEFAULT_CSRFTOKEN_VALUE]);
            }

            string data = string.Empty;

            if (type == VPS.TYPE.LXC)
            {
                data = $"disk=rootfs&size={sizeDisk}G";
            }
            else if (type == VPS.TYPE.QEMU)
            {
                data = $"disk=sata1&size={sizeDisk}G";
            }

            // Encode data
            byte[] dataEncoded = Encoding.ASCII.GetBytes(data);

            // Send data for PUT request
            using (Stream str = request.GetRequestStream())
            {
                str.Write(dataEncoded, 0, dataEncoded.Length);
            }

            return request.GetResponse();
        }


        /// <summary>
        /// Get free vmid for next VM
        /// </summary>
        /// <returns>return int of vmid</returns>
        public int GetFreeVmid()
        {
            int result = 0;
            Uri uri = new Uri($"{this.Url}/api2/json/cluster/nextid");
            HttpWebRequest request = CreateRequestWeb(uri, WebRequestMethods.Http.Get);

            // Add cookie to headers request
            request.Headers.Set(HttpRequestHeader.Cookie, this.Cookie);
            using (WebResponse response = request.GetResponse())
            {
                JToken stringtmp = HttpToolBox.WebResponseToJObject(response)[SharedObject.DEFAULT_DATA_JSON];
                result = Convert.ToInt32(stringtmp.ToString());
            }

            return result;
        }

        /// <summary>
        /// Delete VM from vmid 
        /// </summary>
        /// <param name="cookieValue">The value of cookie</param>
        /// <param name="csrfValue">The value of CSRFtoken</param>
        /// <param name="vmid">The vmid stirng to delete</param>
        /// <returns>return webresponse of request</returns>
        public WebResponse DeleteVmid(string node, string type, string vmid)
        {
            Uri uri = new Uri($"{this.Url}/api2/json/nodes/{node}/{type}/{vmid}");
            var request = CreateRequestWeb(uri, "DELETE");

            if (this.Cookie != "" || this.Csrftoken != "")
            {
                // Add cookie & CSRF token to headers request
                request.Headers.Set(HttpRequestHeader.Cookie, this.Cookie);
                string tmp = this.Csrftoken;
                string[] csrf = { tmp.Substring(0, tmp.IndexOf(DEFAULT_SEPARATOR_TOKEN)),
                    tmp.Substring(tmp.IndexOf(DEFAULT_SEPARATOR_TOKEN) + DEFAULT_VALUE_ARRAY_HEADER) };
                request.Headers.Set(csrf[DEFAULT_CSRFTOKEN_NAME], csrf[DEFAULT_CSRFTOKEN_VALUE]);
            }

            return request.GetResponse();
        }

        /// <summary>
        /// Execute POST request to server with cookie + CSRF token
        /// </summary>
        /// <param name="cookieValue">The cookie value</param>
        /// <param name="csrfValue">The CSRF token value</param>
        /// <param name="paramType">The type of machine is target</param>
        /// <param name="paramVmid">The vmid to target</param>
        /// <param name="paramAction">The action to execute</param>
        /// <returns>return WebResponse of request</returns>
        public WebResponse PostFromCookieCSRF(string node, string paramType, string paramVmid, string paramAction)
        {

            Uri uri = new Uri($"{this.Url}/api2/json/nodes/{node}/{paramType}/{paramVmid}/status/{paramAction}");
            HttpWebRequest request = CreateRequestWeb(uri, WebRequestMethods.Http.Post);



            if (this.Cookie != string.Empty && this.Csrftoken != string.Empty)
            {
                // Add cookie + CSRF token to headers request
                request.Headers.Set(HttpRequestHeader.Cookie, this.Cookie);

                // Add CSRF token to header request
                string tmp = this.Csrftoken;
                string[] csrf = { tmp.Substring(0, tmp.IndexOf(DEFAULT_SEPARATOR_TOKEN)),
                    tmp.Substring(tmp.IndexOf(DEFAULT_SEPARATOR_TOKEN) + DEFAULT_VALUE_ARRAY_HEADER) };
                request.Headers.Set(csrf[DEFAULT_CSRFTOKEN_NAME], csrf[DEFAULT_CSRFTOKEN_VALUE]);
            }

            request.ContentLength = 0;
            // Get response and return
            return request.GetResponse();
        }

        /// <summary>
        /// Get all OS avalaible
        /// </summary>
        /// <returns>List<string> of OS</returns>
        public List<string> GetOSList(string node)
        {
            List<string> result = new List<string>();
            Uri uri = new Uri($"{this.Url}/api2/json/nodes/{node}/storage/local/content");
            HttpWebRequest request = CreateRequestWeb(uri, WebRequestMethods.Http.Get);

            // Add cookie to headers request
            request.Headers.Set(HttpRequestHeader.Cookie, this.Cookie);

            using (WebResponse response = request.GetResponse())
            {
                HttpToolBox.WebResponseToJObject(response)[SharedObject.DEFAULT_DATA_JSON].ToList().ForEach((element) =>
                {
                    result.Add(element[SharedObject.DEFAULT_DATA_JSON_VOLUMEID].ToString());
                });
            }

            return result;
        }

        /// <summary>
        /// Update the cookie and CSRF token for Promox server
        /// </summary>
        public void UpdateCSRFCookie()
        {
            this.Cookie = GetCookieCSRFValue(this.Username, this.Password, this.Realm)[DEFAULT_ARRAY_COOKIE];
            this.Csrftoken = GetCookieCSRFValue(this.Username, this.Password, this.Realm)[DEFAULT_ARRAY_CSRFTOKEN];
        }
        #endregion

        #region Methods Private
        /// <summary>
        /// Get COOKIE + CSRFtoken at ctor
        /// </summary>
        /// <param name="username">The username of user</param>
        /// <param name="password">The password of user</param>
        /// <returns>return string array</returns>
        protected string[] GetCookieCSRFValue(string username, string password, string realm)
        {
            string[] result = new string[DEFAULT_VALUE_ARRAY_SIZE_TOKEN_COOKIE];
            byte[] data = Encoding.Default.GetBytes($"username={username}@{realm}&password={password}");
            string jsonResult = string.Empty;
            Uri uri = new Uri($"{this.Url}/api2/json/access/ticket");

            // Create request
            HttpWebRequest request = CreateRequestWeb(uri, WebRequestMethods.Http.Post);

            // Send post request to server
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            jsonResult = new StreamReader(response.GetResponseStream()).ReadToEnd();
            JObject res = JObject.Parse(jsonResult);
            result[DEFAULT_ARRAY_COOKIE] = res[SharedObject.DEFAULT_DATA_JSON][SharedObject.DEFAULT_JSON_TICKET].ToString().Insert(0, "PVEAuthCookie=");
            result[DEFAULT_ARRAY_CSRFTOKEN] = res[SharedObject.DEFAULT_DATA_JSON][SharedObject.DEFAULT_JSON_CSRFTOKEN].ToString().Insert(0, "CSRFPreventionToken:");
            return result;
        }




        /// <summary>
        /// Get the storage on the Proxmox server
        /// </summary>
        /// <returns>string name of storage name</returns>
        private List<string> GetStorageName(string node)
        {
            List<string> result = new List<string>();
            Uri uri = new Uri($"{this.Url}/api2/json/nodes/{node}/storage/");
            HttpWebRequest request = CreateRequestWeb(uri, WebRequestMethods.Http.Get);

            // Add cookie to headers request
            request.Headers.Set(HttpRequestHeader.Cookie, this.Cookie);

            using (WebResponse response = request.GetResponse())
            {
                HttpToolBox.WebResponseToJObject(response)[SharedObject.DEFAULT_DATA_JSON].ToList().ForEach((element) =>
                {
                    if (element[SharedObject.DEFAULT_DATA_JSON_TYPE].ToString() != SharedObject.DEFAULT_STRING_FOLDER)
                    {
                        result.Add(element[SharedObject.DEFAULT_STRING_STORAGE].ToString());
                    }
                });
            }

            return result;
        }

        /// <summary>
        /// Get node of user
        /// </summary>
        /// <returns>return string name of node</returns>
        private List<string> GetNodes()
        {
            List<string> result = new List<string>();
            //Uri uri = new Uri($"{this.Url}/api2/json/cluster/config/nodes");
            Uri uri = new Uri($"{this.Url}/api2/json/nodes");
            HttpWebRequest request = CreateRequestWeb(uri, WebRequestMethods.Http.Get);

            // Add cookie to headers request
            request.Headers.Set(HttpRequestHeader.Cookie, this.Cookie);


            using (WebResponse response = request.GetResponse())
            {
                HttpToolBox.WebResponseToJObject(response)[SharedObject.DEFAULT_DATA_JSON].ToList().ForEach((element) =>
                {
                    string node = element["node"].ToString();
                    //if (TestConnectionToNode(node))
                    result.Add(node);
                });
            }

            return result;
        }

        /// <summary>
        /// Test connection to node 
        /// </summary>
        /// <param name="node">The node to test</param>
        /// <returns>return if the node is active</returns>
        private bool TestConnectionToNode(string node)
        {
            bool result = false;
            Uri uri = new Uri($"{this.Url}/api2/json/nodes/{node}/status");
            HttpWebRequest request = CreateRequestWeb(uri, WebRequestMethods.Http.Get);

            // Add cookie to headers request
            request.Headers.Set(HttpRequestHeader.Cookie, this.Cookie);


            try
            {
                request.GetResponse();
                result = true;
            }
            catch (WebException we)
            {
                if (we.Status == WebExceptionStatus.ProtocolError)
                    result = false;
                if (we.Status == WebExceptionStatus.Timeout)
                    result = false;
            }

            return result;
        }


        /// <summary>
        /// Create my request for all Web request to server
        /// </summary>
        /// <param name="url">The url to send</param>
        /// <param name="httpMethod">The methods to use</param>
        /// <returns>Return the request created</returns>
        private HttpWebRequest CreateRequestWeb(Uri url, string httpMethod)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = Convert.ToInt32(Properties.Resources.TimeoutDefaultTime);
            request.Method = httpMethod;
            request.UserAgent = SharedObject.DEFAULT_USER_AGENT_REQUEST;
            request.Accept = SharedObject.DEFAULT_ACCEPT_REQUEST;
            request.AllowAutoRedirect = false;
            request.ServerCertificateValidationCallback = 
                new System.Net.Security.RemoteCertificateValidationCallback((a, b, c, d) => { return true; });

            return request;
        }
        #endregion
    }
}
