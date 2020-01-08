/**
* @author   Troller Fabian
* @date     2019-04-08
* @brief    Form teacher for manage users
* @file     PanelVPS.cs
* @version  1.0.0.0
*/

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace ClientProxmox
{
    public partial class PanelVPS : Form, IView
    {
        #region Constants
        private const int DEFAULT_NEGATIVE_INDEX = -1;
        private const int DEFAULT_POSITIVE_INDEX = 1;
        private const string DEFAULT_STRING_CORE = "Coeurs";
        private const string DEFAULT_STRING_GIGABYTE = "GB";
        // String for controls
        public const string DEFAULT_LABEL_NAME = "Nom : ";
        public const string DEFAULT_LABEL_IP = "Adresse IP : ";
        public const string DEFAULT_LABEL_OS = "OS : ";
        public const string DEFAULT_LABEL_CPU = "CPU : ";
        public const string DEFAULT_LABEL_RAM = "RAM : ";
        public const string DEFAULT_LABEL_DISK = "Disque : ";
        public const string DEFAULT_LABEL_UPTIME = "Temps d'activités : ";
        public const string DEFAULT_LABEL_ONLINE = "En ligne : ";
        public const string DEFAULT_LABEL_TEACHER = "Enseignant : ";
        public const string DEFAULT_LABEL_STUDENT = "Étudiant : ";
        public const string DEFAULT_LABEL_BTNSTOP = "Arrêter";
        public const string DEFAULT_LABEL_BTNSTART = "Démarrer";
        public const string DEFAULT_BUTTON_START_ALL = "Démarrer tous";
        public const string DEFAULT_BUTTON_STOP_ALL = "Arrêter tous";


        #endregion

        #region Variables
        private bool _startStop = false;

        private readonly List<ViewBags> pcs = new List<ViewBags>();
        #endregion

        #region Properties
        /// <summary>
        /// The node name of index
        /// </summary>
        public string NODE
        {
            get
            {
                return this.cmbNode.Items[this.cmbNode.SelectedIndex].ToString();
            }
        }

        /// <summary>
        /// If the VPS is start
        /// </summary>
        private bool StartStop { get => _startStop; set => _startStop = value; }

        /// <summary>
        /// Index of the VPS list view
        /// </summary>
        private int IndexList { get => this.lstVPS.SelectedIndex; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default ctor
        /// </summary>
        public PanelVPS()
        {
            InitializeComponent();
            DoubleBuffered = true;
            this.btnEdit.Click += EditPC;
            this.FormClosing += AppQuit;
            this.Load += UpdateNodes;
            this.Load += Subscribe;
            this.lstVPS.SelectedIndexChanged += UpdateDetails;
            this.lstVPS.SelectedIndexChanged += SwitchBtn;
            this.lstVPS.SelectedIndexChanged += UpdateImage;
            this.btnConsole.Click += VNC;
            this.btnDelete.Click += DeleteVmid;
            this.btnStop.Click += ClickSwitch;
            this.btnCreate.Click += CreateForm;
            this.btnReboot.Click += RebootVmid;
            this.cmbNode.SelectedIndexChanged += UpdateDetails;
            this.chbStartAll.Click += StartAllVPS;
            this.pibProfile.Load(SharedObject.EDUGE.UrlPic);
            this.aideToolStripMenuItem.Click += HelpViewer.HelpView;
        }
        #endregion

        #region Methods Private

        /// <summary>
        /// Show help pdf file
        /// </summary>
        /// <param name="sender">The parent sender</param>
        /// <param name="e">Event args</param>
        private void HelpView(object sender, EventArgs e)
        {
            File.WriteAllBytes(SharedObject.DEFAULT_HELP_FILE_NAME, Properties.Resources.ManuelUtilisateur);
            Process.Start(SharedObject.DEFAULT_HELP_FILE_NAME);
        }

        /// <summary>
        /// Satrt all VPS or stop all VPS
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void StartAllVPS(object sender, EventArgs e)
        {
            try
            {
                if (this.chbStartAll.Checked)
                {
                    foreach (ViewBags element in this.pcs)
                    {
                        if (element.Status == VPS.STATUS.STOP)
                        {
                            SharedObject.Modal.Startup(element);
                        }
                    }
                    this.chbStartAll.Text = $"{DEFAULT_BUTTON_STOP_ALL}";
                }
                else
                {
                    foreach (ViewBags element in this.pcs)
                    {
                        if (element.Status == VPS.STATUS.RUNNING)
                        {
                            SharedObject.Modal.Shutdown(element);
                        }
                    }
                    this.chbStartAll.Text = $"{DEFAULT_BUTTON_START_ALL}";
                }
            }
            catch (WebException we)
            {
                SharedObject.PrintWebError(we);

            }catch(Exception ex)
            {
                SharedObject.PrintUnknowErrorException(ex);
            }
            
        }

        /// <summary>
        /// Open VNC browser
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void VNC(object sender, EventArgs e)
        {
            SharedObject.Modal.NoVNC(this.pcs[this.IndexList]);
        }

        /// <summary>
        /// Start new form for create VPS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateForm(object sender, EventArgs e)
        {
            if (!SharedObject.EDUGE.Student || this.lstVPS.Items.Count < Convert.ToInt32(Properties.Resources.StudentMaxVPS))
            {
                CreateVM frm = new CreateVM(this, this.pcs,this.NODE);
                this.Hide();
                frm.Show();
            }
            else
            {
                MessageBox.Show("Trop de machine ont déjà été créée");
            }
            
        }

        /// <summary>
        /// Update image of VPS and draw
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void UpdateImage(object sender, EventArgs e)
        {
            if (this.IndexList != DEFAULT_NEGATIVE_INDEX)
            {
                if (this.pcs.Count != 0)
                {
                    this.pibVM.Image = SharedObject.Modal.DrawViewBags(this.pcs[this.IndexList]);
                }
                else
                {
                    this.pibVM.Image = new Bitmap(this.pibVM.Width, this.pibVM.Height);
                }
            }
        }


        /// <summary>
        /// Update data of VPS
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void UpdateDetails(object sender, EventArgs e)
        {
            SharedObject.Modal.Node = this.NODE;
            DetailsPC();
        }

        /// <summary>
        /// Alternate the texte of the button
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void SwitchBtn(object sender, EventArgs e)
        {
            if (this.IndexList != DEFAULT_NEGATIVE_INDEX)
            {
                if (this.pcs[this.IndexList].Status == VPS.STATUS.RUNNING)
                {
                    this.btnStop.Text = DEFAULT_LABEL_BTNSTOP;
                    this.btnReboot.Enabled = true;
                    this.StartStop = false;
                }
                else if (this.pcs[this.IndexList].Status == VPS.STATUS.STOP)
                {
                    this.btnStop.Text = DEFAULT_LABEL_BTNSTART;
                    this.btnReboot.Enabled = false;
                    this.StartStop = true;
                }
            }

        }


        /// <summary>
        /// For alternate button action
        /// </summary>
        /// <param name="sender">parent sender</param>
        /// <param name="e">Event</param>
        private void ClickSwitch(object sender, EventArgs e)
        {
            if (this.StartStop)
            {
                StartVmid(sender, e);
            }
            else
            {
                ShutdownVmid(sender, e);
            }
        }


        /// <summary>
        /// When the node is edit update all data
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void UpdateNodes(object sender, EventArgs e)
        {
            if (SharedObject.EDUGE.Student)
            {
                this.lblTeachers.Text = $"{DEFAULT_LABEL_STUDENT} {SharedObject.EDUGE.FullName}";
                this.cmbNode.Visible = false;
                this.lblNode.Visible = false;
                this.cmbNode.Items.Clear();
                this.cmbNode.Items.Add(Properties.Resources.StudentDefaultNode);
                this.cmbNode.SelectedIndex = 0;
            }
            else
            {
                this.lblTeachers.Text = $"{DEFAULT_LABEL_TEACHER} {SharedObject.EDUGE.FullName}";
                this.cmbNode.Items.Clear();
                SharedObject.Client.NodeName.ForEach((node) => { this.cmbNode.Items.Add(node); });
                this.cmbNode.SelectedIndex = 0;
            }

        }


        /// <summary>
        /// Close applications correctly
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void AppQuit(object sender, EventArgs e)
        {
            UnSubscribe();
            Application.Exit();
        }

        /// <summary>
        /// Manage VPS
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void EditPC(object sender, EventArgs e)
        {
            this.Hide();
            int index = (this.IndexList == DEFAULT_NEGATIVE_INDEX) ? 0 : this.IndexList;
            ViewBags pc = this.pcs[index];
            ManageVPS frm = new ManageVPS(this, pc);
            frm.Show();
        }


        /// <summary>
        /// Get all data from Model
        /// </summary>
        private void UpdateInfo()
        {

            this.pcs.RemoveAll(new Predicate<ViewBags>((target) => true));
            SharedObject.Modal.ListPC.ForEach((pc) =>
            {
                this.pcs.Add(pc);
            });
            if (this.pcs.Count == 0 || this.IndexList == DEFAULT_NEGATIVE_INDEX)
            {
                this.btnDelete.Enabled = false;
                this.btnStop.Enabled = false;
                this.btnReboot.Enabled = false;
                this.btnEdit.Enabled = false;
                this.btnConsole.Enabled = false;
                this.chbStartAll.Enabled = false;
            }
            else
            {
                this.btnDelete.Enabled = true;
                this.btnStop.Enabled = true;
                this.btnReboot.Enabled = true;
                this.btnEdit.Enabled = true;
                this.btnConsole.Enabled = true;
                this.chbStartAll.Enabled = true;
            }
            RefreshListBox();
        }


        /// <summary>
        /// Refresh all details of VPS
        /// </summary>
        private void DetailsPC()
        {
            //int index = (this.IndexList == -1) ? 0 : this.IndexList;
            if (this.pcs.Count != 0 && this.IndexList > DEFAULT_NEGATIVE_INDEX)
            {
                ViewBags pc = this.pcs[this.IndexList];

                this.lblOS.Text = $"{DEFAULT_LABEL_OS}{pc.Os}";
                this.lblUsername.Text = $"{DEFAULT_LABEL_NAME}{pc.Name}";
                this.lblCpu.Text = $"{DEFAULT_LABEL_CPU}{pc.Cpus} {DEFAULT_STRING_CORE}";
                this.lblRam.Text = $"{DEFAULT_LABEL_RAM}{pc.Ram:#,0.##} {DEFAULT_STRING_GIGABYTE}";
                this.lblDisk.Text = $"{DEFAULT_LABEL_DISK}{pc.Disk:#,0.##} {DEFAULT_STRING_GIGABYTE}";
                TimeSpan tmp = TimeSpan.FromSeconds(pc.Uptime);
                this.lblUpTime.Text = $"{DEFAULT_LABEL_UPTIME}{$"{(int)tmp.TotalDays}J:{(int)tmp.Hours}h:{(int)tmp.Minutes}m:{(int)tmp.Seconds}s"}";
                this.lblOnline.Text = $"{DEFAULT_LABEL_ONLINE}{pc.Status}";
            }
            else
            {
                this.lblOS.Text = DEFAULT_LABEL_OS;
                this.lblUsername.Text = DEFAULT_LABEL_NAME;
                this.lblCpu.Text = DEFAULT_LABEL_CPU;
                this.lblRam.Text = DEFAULT_LABEL_RAM;
                this.lblDisk.Text = DEFAULT_LABEL_DISK;
                this.lblUpTime.Text = DEFAULT_LABEL_UPTIME;
                this.lblOnline.Text = DEFAULT_LABEL_ONLINE;
            }
        }


        /// <summary>
        /// Refresh the list of VPS
        /// </summary>
        private void RefreshListBox()
        {
            int index = this.IndexList;
            this.lstVPS.Items.Clear();
            this.pcs.Sort();
            this.pcs.ForEach((pc) => { this.lstVPS.Items.Add(pc.Name); });
            try
            {

                if (this.lstVPS.Items.Count == 0)
                    index = -1;
                this.lstVPS.SelectedIndex = (index >= this.lstVPS.Items.Count) ?
                    (index > this.lstVPS.Items.Count) ? this.lstVPS.Items.Count  : index - DEFAULT_POSITIVE_INDEX : index;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            DetailsPC();
        }

        /// <summary>
        /// Shutdown the VPS
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void ShutdownVmid(object sender, EventArgs e)
        {
            try
            {
                SharedObject.Modal.Shutdown(this.pcs[this.IndexList]);
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


        /// <summary>
        /// Start the VPS
        /// </summary>
        /// <param name="sender">Parent</param>
        /// <param name="e">Event</param>
        private void StartVmid(object sender, EventArgs e)
        {
            try
            {
                SharedObject.Modal.Startup(this.pcs[this.IndexList]);
            }
            catch (WebException we)
            {
                SharedObject.PrintWebError(we);
            }
            catch(Exception ex)
            {
                SharedObject.PrintUnknowErrorException(ex);
            }
        }


        /// <summary>
        /// Reboot the VPS
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void RebootVmid(object sender, EventArgs e)
        {
            try
            {
                SharedObject.Modal.Reboot(this.pcs[this.IndexList]);
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


        /// <summary>
        /// Delete the VPS
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void DeleteVmid(object sender, EventArgs e)
        {
            try
            {
                SharedObject.Modal.Delete(this.pcs[this.IndexList]);
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


        /// <summary>
        /// Subscribe to model
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void Subscribe(object sender, EventArgs e)
        {
            SharedObject.Modal.Node = this.NODE;
            SharedObject.Modal.AddObserver(this);
        }

        /// <summary>
        /// Unsubscribe of model list
        /// </summary>
        private void UnSubscribe()
        {
            SharedObject.Modal.RemoveObserver(this);
        }


        /// <summary>
        /// When the model notify view
        /// </summary>
        public void NotifiyObserver()
        {
            this.UpdateInfo();
        }
        #endregion
    }
}
