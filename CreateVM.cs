/**
* @author   Troller Fabian
* @date     2019-04-08
* @brief    Form user create proxmox contener
* @file     CreateVM.cs
* @version  1.0.0.0
*/

using System;
using System.Collections.Generic;
using System.Net;
using System.Windows.Forms;

namespace ClientProxmox
{
    public partial class CreateVM : Form 
    {
        #region Constants
        const int KIB = 1024;
        const int DEFAULT_DISK_VALUE_ADD = 1;
        const int DEFAULT_EMPTY_COMBOBOX_INDEX = -1;
        const string DEFAULT_STRING_CORE = "Coeurs";
        const string DEFAULT_LABELUSER = "Utilisateur : ";
        const string DEFAULT_STRING_GBRAM = "GB";
        #endregion

        #region Variables
        private List<string> _selectOS = new List<string>();
        private int _number = 0;
        private Form parent;
        private string _node = string.Empty;
        #endregion

        #region Properties
        /// <summary>
        /// List string of OS in server Proxmox
        /// </summary>
        public List<string> SelectOS { get => _selectOS; set => _selectOS = value; }

        /// <summary>
        /// Number of next machine
        /// </summary>
        public int Number { get => _number; set => _number = value; }

        /// <summary>
        /// The node of new VPS
        /// </summary>
        public string Node { get => _node; private set => _node = value; }
        #endregion

        #region Constructors
        /// <summary>
        /// Ctor for form
        /// </summary>
        public CreateVM(object sender, List<ViewBags> listBags,string node)
        {
            InitializeComponent();
            this.Node = node;
            this.lblUsername.Text = $"{DEFAULT_LABELUSER}{SharedObject.EDUGE.FullName}";
            this.parent = (Form)sender;
            this.Load += OSList;
            this.cmbOS.Click += OSList;
            this.Load += UpdateLabelValue;
            this.trbCpu.ValueChanged += UpdateLabelValue;
            this.trbRam.ValueChanged += UpdateLabelValue;
            this.FormClosing += AppQuit;
            this.btnCreate.Click += Create;
            this.rdbCt.CheckedChanged += OSList;
            this.Number = listBags.Count;
            this.tbxPassword.TextChanged += LengthPassword;
            this.tbxConfirm.KeyDown += EnterKeyPress;
            this.aideToolStripMenuItem.Click += HelpViewer.HelpView;
            if (SharedObject.EDUGE.Student)
            {
                this.tbxName.Visible = false;
                this.lblPcName.Visible = false;
                this.trbCpu.Maximum = Convert.ToInt32(Properties.Resources.StudentMaxCPU);
                this.trbRam.Maximum = Convert.ToInt32(Properties.Resources.StudentMaxRAM);
                this.numDisk.Maximum = Convert.ToInt32(Properties.Resources.StudentMaxDiskCT);
            }
            else
            {
                this.trbCpu.Maximum = Convert.ToInt32(Properties.Resources.TeacherMaxCPU);
                this.trbRam.Maximum = Convert.ToInt32(Properties.Resources.TeacherMaxRAM);
            }
        }
        #endregion

        #region Methods Private
        /// <summary>
        /// Check key pressed for ENTER key
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void EnterKeyPress(object sender,KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnCreate.PerformClick();
            }
        }


        /// <summary>
        /// Check length of password
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void LengthPassword(object sender, EventArgs e)
        {

            if (this.tbxPassword.Text.Length >= 5)
            {
                this.lblMinPassword.Visible = false;
            }
            else if (this.tbxPassword.Text.Length < 5)
            {
                this.lblMinPassword.Visible = true;
            }
            if (this.rdbVm.Checked)
            {
                this.lblMinPassword.Visible = false;
            }
        }


        /// <summary>
        /// Update info label of TrackBar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateLabelValue(object sender, EventArgs e)
        {
            this.lblCores.Text = $"{this.trbCpu.Value} {DEFAULT_STRING_CORE}";
            this.lblGBRam.Text = $"{this.trbRam.Value} {DEFAULT_STRING_GBRAM}";
        }

        /// <summary>
        /// Check if state of radio button change
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void CheckRadioState(object sender, EventArgs e)
        {
            this.SelectOS.Clear();
            List<string> tmp = SharedObject.Client.GetOSList(this.Node);
            if (rdbCt.Checked)
            {
                // List all os LXC and remove storage string
                tmp.ForEach((os) =>
                {
                    if (os.StartsWith(SharedObject.DEFAULT_TEXT_LOCALSTORAGE_PROXMOX_SERVER))
                    { this.SelectOS.Add(os.TrimStart(SharedObject.DEFAULT_TEXT_LOCAL_PROXMOX_SERVER.ToCharArray())); }
                });
                this.tbxPassword.Enabled = true;
                this.tbxConfirm.Enabled = true;
                this.chkPrivileged.Enabled = true;
            }
            else
            {
                // List all os QEMU and remove storage string
                tmp.ForEach((os) =>
                {
                    if (!os.StartsWith(SharedObject.DEFAULT_TEXT_LOCALSTORAGE_PROXMOX_SERVER))
                    { this.SelectOS.Add(os.TrimStart(SharedObject.DEFAULT_TEXT_LOCAL_PROXMOX_SERVER.ToCharArray())); }
                });
                this.tbxPassword.Enabled = false;
                this.tbxConfirm.Enabled = false;
                this.chkPrivileged.Enabled = false;
                this.numDisk.Maximum = Convert.ToInt32(Properties.Resources.StudentMaxDiskVM);

            }
        }

        /// <summary>
        /// List all OS in comboBox
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void OSList(object sender, EventArgs e)
        {
            CheckRadioState(sender, e);
            this.cmbOS.Items.Clear();
            for (int i = 0; i < this.SelectOS.Count; i++)
            {
                this.cmbOS.Items.Add(this.SelectOS[i]);
            }
            if (this.SelectOS.Count <= 0)
            {
                this.cmbOS.SelectedIndex = DEFAULT_EMPTY_COMBOBOX_INDEX;
                this.cmbOS.Items.Clear();
            }
            else
            {
                this.cmbOS.SelectedIndex = 0;
            }
        }


        /// <summary>
        /// Close app 
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void AppQuit(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }


        /// <summary>
        /// Check if password is same in two textbox
        /// </summary>
        /// <returns>Return bollean of test</returns>
        private bool CheckPassword()
        {
            bool result = false;
            if (this.tbxPassword.Text != this.tbxConfirm.Text)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.");
            }
            else
            {
                result = true;
            }

            return result;
        }

        /// <summary>
        /// Create new VM on server
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void Create(object sender, EventArgs e)
        {
            if (CheckPassword())
            {
                uint cpu = (uint)trbCpu.Value;
                double disk = (double)numDisk.Value;
                double ram = trbRam.Value * KIB;
                string type = (rdbCt.Checked) ? VPS.TYPE.LXC : VPS.TYPE.QEMU;
                string name = (tbxName.Text == string.Empty) ? $"{SharedObject.EDUGE.FullName}-{(this.Number + DEFAULT_DISK_VALUE_ADD).ToString()}" : tbxName.Text;
                string pass = this.tbxPassword.Text;

                try
                {
                    ViewBags vb = new ViewBags();
                    vb.Name = name;
                    vb.Password = pass;
                    vb.Type = type;
                    vb.Os = this.cmbOS.Items[this.cmbOS.SelectedIndex].ToString();
                    vb.Vmid = (uint)SharedObject.Client.GetFreeVmid();
                    vb.Node = SharedObject.Modal.Node;
                    vb.Cpus = cpu;
                    vb.Ram = ram;
                    vb.Disk = disk;

                    if (rdbCt.Checked)
                    {
                        vb.Privileged = chkPrivileged.Checked;
                        SharedObject.Modal.CreateVPS(vb);
                    }
                    else
                    {
                        SharedObject.Modal.CreateVPS(vb);
                    }
                }
                catch (WebException we)
                {
                    SharedObject.PrintWebError(we);
                }
                catch(Exception ex)
                {
                    SharedObject.PrintUnknowErrorException(ex);
                }

                this.Hide();
                this.parent.Show();
            }
        }

        #endregion
    }
}
