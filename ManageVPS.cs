/**
* @author   Troller Fabian
* @date     2019-04-08
* @brief    Form for teacher for manage VM / CT
* @file     ManageVPS.cs
* @version  1.0.0.0
*/

using System;
using System.Net;
using System.Windows.Forms;

namespace ClientProxmox
{
    public partial class ManageVPS : Form
    {

        #region Constants
        const string DEFAULT_LABEL_TEACHER_NAME = "Enseignant : ";
        const string DEFAULT_LABEL_STUDENT_NAME = "Étudiant : ";
        const string DEFAULT_LABEL_GB = "GB";
        const string DEFAULT_LABEL_CPUCORE = "Coeurs";
        const int KIB = 1024;
        #endregion

        #region Variables
        private readonly Form parent;

        private string _type = string.Empty;
        private string _vmid = string.Empty;
        private string _node = string.Empty;
        private string _vpsName = string.Empty;
        private double _cpu = 0;
        private double _ram = 0;
        private double _disk = 0;
        private string _os = string.Empty;
        private string _password = string.Empty;
        private ViewBags _vps = null;
        #endregion

        #region Properties
        private string Type { get => _type; set => _type = value; }
        private string Vmid { get => _vmid; set => _vmid = value; }
        private string Node { get => _node; set => _node = value; }
        private string VpsName { get => _vpsName; set => _vpsName = value; }
        private double Cpu { get => _cpu; set => _cpu = value; }
        private double Ram { get => _ram; set => _ram = value; }
        private double Disk { get => _disk; set => _disk = value; }
        private string Os { get => _os; set => _os = value; }
        private string Password { get => _password; set => _password = value; }
        private ViewBags Vps { get => _vps; set => _vps = value; }
        #endregion

        #region Constructor
        /// <summary>
        /// Ctor interface for manage VM / CT
        /// </summary>
        public ManageVPS(object sender, ViewBags vps)
        {
            InitializeComponent();
            this.parent = (Form)sender;
            Vps = vps;
            this.Node = Vps.Node;
            this.VpsName = Vps.Name;
            this.Type = Vps.Type;
            this.Cpu = Vps.Cpus;
            this.Ram = Vps.Ram;
            this.Disk = Vps.Disk;
            this.Vmid = Vps.Vmid.ToString();
            this.Os = Vps.Os;
            this.tbxName.Text = this.VpsName;
            this.Load += UpdateInfo;
            this.FormClosing += AppQuit;
            this.btnModificate.Click += UpdateVPS;
            this.trbCpu.ValueChanged += UpdateLabel;
            this.trbRam.ValueChanged += UpdateLabel;
            this.aideToolStripMenuItem.Click += HelpViewer.HelpView;
            if (SharedObject.EDUGE.Student)
            {
                this.lblUsername.Text = $"{DEFAULT_LABEL_STUDENT_NAME}{SharedObject.EDUGE.FullName}";
                this.trbCpu.Maximum = Convert.ToInt32(Properties.Resources.StudentMaxCPU);
                this.trbRam.Maximum = Convert.ToInt32(Properties.Resources.StudentMaxRAM);
                this.numDisk.Maximum = (this.Type == "qemu") ? Convert.ToInt32(Properties.Resources.StudentMaxDiskVM) :
                    Convert.ToInt32(Properties.Resources.StudentMaxDiskCT);
                this.lblName.Visible = false;
                this.tbxName.Visible = false;
            }
            else
            {
                this.lblUsername.Text = $"{DEFAULT_LABEL_TEACHER_NAME}{SharedObject.EDUGE.FullName}";
                this.trbCpu.Maximum = Convert.ToInt32(Properties.Resources.TeacherMaxCPU);
                this.trbRam.Maximum = Convert.ToInt32(Properties.Resources.TeacherMaxRAM);
                this.numDisk.Maximum = Convert.ToInt32(Properties.Resources.TeacherMaxDisk);
            }

        }
        #endregion

        #region Methods Private
        /// <summary>
        /// Update info of VPS to set
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void UpdateInfo(object sender, EventArgs e)
        {
            this.lblOsValue.Text = this.Os;

            if (SharedObject.EDUGE.Student)
            {

                int temporaryRamValue = 0;
                if (this.Type == VPS.TYPE.LXC)
                {
                    temporaryRamValue = (this.Ram < 1) ? 1 : (int)this.Ram;
                }
                else
                {
                    temporaryRamValue = (this.Ram > VPS.KB) ? (int)this.Ram / VPS.KIB : (int)this.Ram;
                }

                if (temporaryRamValue > this.trbRam.Maximum)
                {
                    this.trbRam.Maximum = (int)this.Ram;
                    this.trbRam.Value = (int)this.Ram;
                    this.trbRam.Enabled = false;
                    this.lblAdminRam.Visible = true;

                }
                else
                {
                    this.trbRam.Value = temporaryRamValue;
                }


                if (this.Cpu > this.trbCpu.Maximum)
                {
                    this.trbCpu.Maximum = (int)this.Cpu;
                    this.trbCpu.Value = (int)this.Cpu;
                    this.trbCpu.Enabled = false;
                    this.lblAdminCpu.Visible = true;
                }
                else
                {
                    this.trbCpu.Value = (int)this.Cpu;
                }

                if (this.Disk > (int)this.numDisk.Maximum)
                {
                    this.numDisk.Maximum = (int)this.Disk;
                    this.numDisk.Value = (int)this.Disk;
                    this.numDisk.Enabled = false;
                    this.lblAdminDisk.Visible = true;
                }
                else
                {
                    this.numDisk.Value = (int)this.Disk;
                    this.numDisk.Minimum = (int)this.Disk;
                }
            }
            else
            {
                this.numDisk.Value = (int)this.Disk;
                this.trbCpu.Value = (int)this.Cpu;
                this.trbRam.Value = (int)this.Ram;
            }

            this.lblCpuNumber.Text = $"{this.trbCpu.Value} {DEFAULT_LABEL_CPUCORE}";
            this.lblGBRam.Text = $"{this.trbRam.Value} {DEFAULT_LABEL_GB}";
        }

        /// <summary>
        /// Update label info of TrackBar
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void UpdateLabel(object sender, EventArgs e)
        {
            this.lblCpuNumber.Text = $"{this.trbCpu.Value} {DEFAULT_LABEL_CPUCORE}";
            this.lblGBRam.Text = $"{this.trbRam.Value} {DEFAULT_LABEL_GB}";
        }


        /// <summary>
        /// Modify VPS with value
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void UpdateVPS(object sender, EventArgs e)
        {
            try
            {
                ViewBags vb = new ViewBags();
                vb.Name = this.tbxName.Text;
                vb.Type = this.Type;
                vb.Os = this.Os;
                vb.Vmid = Convert.ToUInt32(this.Vmid);
                vb.Node = this.Node;
                vb.Cpus = (uint)this.trbCpu.Value;
                vb.Ram = (double)this.trbRam.Value * KIB;
                vb.Disk = (double)this.numDisk.Value;
                SharedObject.Modal.Modifiy(this.Vps, vb);
                if ((int)this.numDisk.Value != (int)this.Vps.Disk)
                {
                    SharedObject.Modal.Resize(this.Vps, (double)this.numDisk.Value);
                }
            }
            catch (WebException we)
            {
                    SharedObject.PrintWebError(we);
            }
            catch (Exception ex)
            {
                SharedObject.PrintUnknowErrorException(ex);
            }
            AppQuit(sender, e);
        }

        /// <summary>
        /// Force close app
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void AppQuit(object sender, EventArgs e)
        {
            this.Hide();
            this.parent.Show();
        }
        #endregion
    }
}
