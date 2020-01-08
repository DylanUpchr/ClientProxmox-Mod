/**
* @author   Troller Fabian
* @date     2019-06-31
* @brief    Class for VNC
* @file     VNC.cs
* @version  1.0.0.0 
*/

using System;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Handler;
using CefSharp.WinForms;

namespace ClientProxmox
{
    public partial class VNC : Form
    {

        #region Variables
        private string _url = string.Empty;
        private ViewBags _vb;
        private ChromiumWebBrowser chromeView;
        #endregion

        #region Properties
        public ViewBags VB
        {
            get { return _vb; }
            set { _vb = value; }
        }


        public string Url { get => _url; set => _url = value; }
        public ChromiumWebBrowser ChromeView { get => chromeView; set => chromeView = value; }
        #endregion

        #region Contructor
        /// <summary>
        /// Open windows with NoVNC inside
        /// </summary>
        /// <param name="url">The url to target</param>
        /// <param name="vb">The ViewBags of VPS to connect</param>
        public VNC(string url, ViewBags vb)
        {
            this.Url = url;
            DoubleBuffered = true;
            InitializeComponent();
            this.VB = vb;
            InitializeChromium();
            this.FormClosing += AppQuit;
        }
        #endregion

        #region Methods Private
        /// <summary>
        /// When app is closing free memory of browser
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void AppQuit(object sender, EventArgs e)
        {
            this.ChromeView.Dispose();
        }

        /// <summary>
        /// Initilize the chromium browser and load to URL
        /// </summary>
        private void InitializeChromium()
        {
            string type = (VB.Type == VPS.TYPE.QEMU) ? "kvm" : "lxc";
            string data = $"{this.Url}/?console={type}&novnc=1&vmid={VB.Vmid}&vmname={VB.Name}&node={VB.Node}&resize=off&cmd=";
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Cookies);

            // Settings of browser
            CefSettings setting = new CefSettings
            {
                UserAgent = SharedObject.DEFAULT_USER_AGENT_REQUEST,
                EnableNetSecurityExpiration = false,
                IgnoreCertificateErrors = true,
                CachePath = path,
            };

            if (!Cef.IsInitialized)
            {
                Cef.Initialize(setting);
            }

            // Add new browser + create requestHandler
            this.ChromeView = new ChromiumWebBrowser(data);
            this.ChromeView.RequestHandler = new CustomRequestForVNC(this.Url);
            this.ChromeView.Dock = DockStyle.Fill;
            this.Controls.Add(this.ChromeView);

            this.ChromeView.Load(data);

        }
        #endregion
    }

    /// <summary>
    /// Class for request of browser
    /// </summary>
    class CustomRequestForVNC : DefaultRequestHandler
    {
        #region Variables
        private string _url = string.Empty;
        #endregion

        #region Properties
        public string Url { get => _url; set => _url = value; }
        public CustomRequestForVNC(string url)
        {
            this.Url = url;
        }
        #endregion

        #region Methods Public
        /// <summary>
        /// This methods set the cookie before the browser load the HTML page
        /// </summary>
        /// <param name="browserControl">The browser control</param>
        /// <param name="browser">The chromium browser</param>
        /// <param name="frame">The frame displayed</param>
        /// <param name="request">The request</param>
        /// <param name="userGesture">The user gesture</param>
        /// <param name="isRedirect">If the browser can redirect</param>
        /// <returns></returns>
        public override bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
        {
            string name = SharedObject.Client.CookieName;
            string value = SharedObject.Client.CookieValue;
            string tmp = Uri.EscapeDataString(value);

            // Set cookie in browser
            ICookieManager CookieManage = Cef.GetGlobalCookieManager();
            CookieManage.SetCookie(this.Url, new CefSharp.Cookie() { Name = name, Value = tmp, }, null);

            return false;
        }
        #endregion
    }

}
