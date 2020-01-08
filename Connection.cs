/**
* @author   Troller Fabian
* @date     2019-04-08
* @brief    Login user form
* @file     Connection.cs
* @version  1.0.0.0
*/

using System;
using System.Windows.Forms;
using System.Net;

namespace ClientProxmox
{
    public partial class Connection : Form
    {
        readonly string urlServer = Properties.Resources.Server;



        /// <summary>
        /// Ctor for connection form
        /// </summary>
        public Connection()
        {
            InitializeComponent();
            this.KeyDown += KeyControl;
            this.btnConnect.Click += NewForm;
            

        }

        /// <summary>
        /// Event foreach keypressed
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="key">Event of key pressed</param>
        private void KeyControl(object sender, KeyEventArgs key)
        {
            if (key.KeyCode == Keys.Enter)
            {
                this.btnConnect.PerformClick();
            }
        }

        /// <summary>
        /// Show new form for list VM
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void NewForm(object sender, EventArgs e)
        {

            SharedObject.EDUGE = new Eduge();
            SharedObject.EDUGE.Connect();
            

            try
            {
                SharedObject.Client = 
                    new ProxmoxClient(Properties.Resources.Server, Properties.Resources.UserName, Properties.Resources.PassWord,Properties.Resources.Realm);
                SharedObject.Modal = new Model();
                this.Hide();
                Form frm;
                if (SharedObject.EDUGE.Student)
                {
                    frm = new PanelVPS();
                }
                else
                {
                    frm = new PanelVPS();
                }
                frm.Show();

            }
            catch (WebException we)
            {
                SharedObject.PrintWebError(we);
            }
            catch (Exception ex)
            {
                SharedObject.PrintUnknowErrorException(ex);
            }
        }
    }
}
