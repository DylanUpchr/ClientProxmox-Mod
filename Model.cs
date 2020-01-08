/**
* @author   Troller Fabian
* @date     2019-04-08
* @brief    Model for notify view
* @file     Model.cs
* @version  1.0.0.0
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.Threading;
using Timer = System.Windows.Forms.Timer;

namespace ClientProxmox
{
    public class Model
    {
        #region Variables
        private int DEFAULT_TIMER_INTERVAL = Convert.ToInt32(Properties.Resources.TimeForRefresh);
        private List<IView> _listObserver = new List<IView>();
        private List<ViewBags> _listPC = new List<ViewBags>();
        private Timer _timer = new Timer();
        private string _node = string.Empty;
        #endregion

        #region Properties
        /// <summary>
        /// List of observer to notify
        /// </summary>
        public List<IView> ListObserver { get => _listObserver; set => _listObserver = value; }

        /// <summary>
        /// List of PC get for Form
        /// </summary>
        public List<ViewBags> ListPC { get => _listPC; set => _listPC = value; }

        /// <summary>
        /// Timer to update list
        /// </summary>
        public Timer Timer { get => _timer; set => _timer = value; }


        public string Node { get => _node; set => _node = value; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public Model()
        {
            this.Timer.Start();
            this.Timer.Interval = DEFAULT_TIMER_INTERVAL;
            this.Timer.Tick += OnTick;
        }
        #endregion

        #region Methods Public
        /// <summary>
        /// Create VPS from ViewBags
        /// </summary>
        /// <param name="vb">The ViewBags to create</param>
        public void CreateVPS(ViewBags vb)
        {
            if (vb.Type == VPS.TYPE.LXC)
            {
                new CT(pname: vb.Name, ppass: vb.Password, ptype: vb.Type, pos: vb.Os
                        , pvmid: vb.Vmid.ToString(), pnode: vb.Node, pcpu: vb.Cpus, pram: vb.Ram, pdisk: vb.Disk,privileged: vb.Privileged).Create().Dispose();
            }
            else if (vb.Type == VPS.TYPE.QEMU)
            {
                new VM(pname: vb.Name, ptype: vb.Type, pos: vb.Os
                        , pvmid: vb.Vmid.ToString(), pnode: vb.Node, pcpu: vb.Cpus, pram: vb.Ram, pdisk: vb.Disk).Create().Dispose();
            }
        }


        /// <summary>
        /// Shutdown the VPS
        /// </summary>
        /// <param name="vb">The ViewBags of VPS</param>
        public void Shutdown(ViewBags vb)
        {
            try
            {
                if (vb.Type == VPS.TYPE.LXC)
                    new CT(vb).Shutdown().Dispose();
                else
                    new VM(vb).Shutdown().Dispose();
            }
            catch (WebException we)
            {
                System.Windows.Forms.MessageBox.Show($"Erreur lors de l'execution {we.Message}");
            }
        }


        /// <summary>
        /// Start the VPS
        /// </summary>
        /// <param name="vb">The ViewBags of VPS</param>
        public void Startup(ViewBags vb)
        {
            try
            {
                if (vb.Type == VPS.TYPE.LXC)
                    new CT(vb).Startup().Dispose();
                else
                    new VM(vb).Startup().Dispose();

            }
            catch (WebException we)
            {
                System.Windows.Forms.MessageBox.Show($"Erreur lors de l'execution {we.Message}");
            }
        }

        /// <summary>
        /// Reboot the VPS
        /// </summary>
        /// <param name="vb">The ViewBags of VPS</param>
        public void Reboot(ViewBags vb)
        {
            if (vb.Type == VPS.TYPE.LXC)
                new Thread(new ThreadStart( () => { new CT(vb).Reboot().Dispose(); })).Start();
            else
                new Thread(new ThreadStart(() => { new VM(vb).Reboot().Dispose(); })).Start();
        }

        /// <summary>
        /// Delete the VPS
        /// </summary>
        /// <param name="vb">The ViewBags of VPS</param>
        public void Delete(ViewBags vb)
        {
            if (new DeleteConfirm(vb.Name).ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    SharedObject.Client.DeleteVmid(vb.Node, vb.Type, vb.Vmid.ToString()).Dispose();
                }
                catch (WebException we)
                {
                    System.Windows.Forms.MessageBox.Show($"Erreur lors de l'execution {we.Message}");
                }
            }
        }


        /// <summary>
        /// Modify setup of ViewBags
        /// </summary>
        /// <param name="vb">The ViewBags to modify</param>
        /// <param name="newValue">The new value for VPS</param>
        public void Modifiy(ViewBags vb, ViewBags newValue)
        {
            if (vb.Type == VPS.TYPE.LXC)
                new CT(vb).Modifiy(newValue.Name, newValue.Type, newValue.Os, newValue.Vmid.ToString(), newValue.Node,
                    newValue.Cpus, newValue.Ram, newValue.Disk).Dispose();
            else
                new VM(vb).Modifiy(newValue.Name, newValue.Type, newValue.Os, newValue.Vmid.ToString(), newValue.Node,
                    newValue.Cpus, newValue.Ram, newValue.Disk).Dispose();
        }


        /// <summary>
        /// Resize disk size of ViewBags
        /// </summary>
        /// <param name="vb">The ViewBags to resize</param>
        /// <param name="sizeDisk">The new size of disk</param>
        public void Resize(ViewBags vb, double sizeDisk)
        {
            if (vb.Type == VPS.TYPE.LXC)
                new CT(vb).Resize(sizeDisk.ToString()).Dispose();
            else
                new VM(vb).Resize(sizeDisk.ToString()).Dispose();
        }


        /// <summary>
        /// Draw thie ViewBags image
        /// </summary>
        /// <param name="vb">The ViewBags to draw</param>
        /// <returns>Return image of ViewBags</returns>
        public Bitmap DrawViewBags(ViewBags vb)
        {
            Bitmap img;
            if (vb.Type == VPS.TYPE.LXC)
            {
                img = new Bitmap(new CT(vb).Draw());
            }
            else
            {
                img = new Bitmap(new VM(vb).Draw());
            }

            return img;
        }

        /// <summary>
        /// Add observer to list
        /// </summary>
        /// <param name="observer">The observer object to add</param>
        public void AddObserver(object observer)
        {
            this.ListObserver.Add(observer as IView);
        }



        /// <summary>
        /// Remove an observer to list
        /// </summary>
        /// <param name="observer">The observer object to remove</param>
        public void RemoveObserver(object observer)
        {
            this.ListObserver.Remove(observer as IView);
        }


        /// <summary>
        /// Open NoVNC interface from webview
        /// </summary>
        /// <param name="vb">The ViewBags of the VPS to connect</param>
        public void NoVNC(ViewBags vb)
        {
            VNC frm = new VNC(Properties.Resources.Server, vb);
            frm.Show();
        }
        #endregion

        #region Methods Private
        /// <summary>
        /// On tick event for refresh data from Proxmox server
        /// </summary>
        /// <param name="sender">Sender parent</param>
        /// <param name="e">Event</param>
        private void OnTick(object sender, EventArgs e)
        {
            this.ListPC.Clear();
            RETRY:
            try
            {
                using (WebResponse lxcResponse = SharedObject.Client.Get(
                 SharedObject.Client.NodeName.Where((n) => n == this.Node).ToArray()[0], VPS.TYPE.LXC, string.Empty))
                {
                    JToken[] LxcArray = HttpToolBox.WebResponseToJObject(lxcResponse)[SharedObject.DEFAULT_DATA_JSON].ToArray();
                    for (int j = 0; j < LxcArray.Length; j++)
                    {
                        this.ListPC.Add(VpsToBags(new CT(this.Node, LxcArray[j])));
                    }
                }

                // Response destoy when using ends
                using (WebResponse qemuResponse = SharedObject.Client.Get(
                    SharedObject.Client.NodeName.Where((n) => n == this.Node).ToArray()[0], VPS.TYPE.QEMU, string.Empty))
                {
                    JToken[] QemuArray = HttpToolBox.WebResponseToJObject(qemuResponse)[SharedObject.DEFAULT_DATA_JSON].ToArray();
                    for (int j = 0; j < QemuArray.Length; j++)
                    {
                        this.ListPC.Add(VpsToBags(new VM(this.Node, QemuArray[j])));
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException || ex is WebException)
                {
                    SharedObject.Client.UpdateCSRFCookie();
                    goto RETRY;
                }

                throw ex;                
            }
            

            if (SharedObject.EDUGE.Student)
            {
                this.ListPC.RemoveAll((pc) => !pc.Name.StartsWith(SharedObject.EDUGE.Name));
            }


            // Notify all observer
            this.UpdateObserver();

        }

        /// <summary>
        /// Convert VPS to ViewBags object
        /// </summary>
        /// <param name="vps">The VPS to convert</param>
        /// <returns>Return the ViewBags</returns>
        private ViewBags VpsToBags(VPS vps)
        {
            ViewBags vb = new ViewBags();
            vb.Name = vps.Name;
            vb.Vmid = vps.Vmid;
            vb.Cpus = vps.Cpus;
            vb.Ram = vps.Ram;
            vb.Disk = vps.Disk;
            vb.Os = vps.Os;
            vb.Type = vps.Type;
            vb.Status = vps.Status;
            vb.Uptime = vps.Uptime;
            vb.Img = vps.Img;
            vb.Node = vps.Node;
            return vb;
        }




        /// <summary>
        /// Update all observer
        /// </summary>
        private void UpdateObserver()
        {
            this.ListObserver.ForEach((observer) =>
            {
                observer.NotifiyObserver();
            });
        }
        #endregion
    }
}
