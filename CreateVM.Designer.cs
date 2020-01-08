namespace ClientProxmox
{
    partial class CreateVM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateVM));
            this.lblUsername = new System.Windows.Forms.Label();
            this.cmbOS = new System.Windows.Forms.ComboBox();
            this.lblOS = new System.Windows.Forms.Label();
            this.lblPcName = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.trbCpu = new System.Windows.Forms.TrackBar();
            this.lblCpu = new System.Windows.Forms.Label();
            this.lblRam = new System.Windows.Forms.Label();
            this.trbRam = new System.Windows.Forms.TrackBar();
            this.tbxPassword = new System.Windows.Forms.TextBox();
            this.lblPasswordPc = new System.Windows.Forms.Label();
            this.numDisk = new System.Windows.Forms.NumericUpDown();
            this.lblDisk = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.rdbVm = new System.Windows.Forms.RadioButton();
            this.grpVmCt = new System.Windows.Forms.GroupBox();
            this.rdbCt = new System.Windows.Forms.RadioButton();
            this.lblCores = new System.Windows.Forms.Label();
            this.lblGBRam = new System.Windows.Forms.Label();
            this.lblConfirm = new System.Windows.Forms.Label();
            this.tbxConfirm = new System.Windows.Forms.TextBox();
            this.lblGBDisk = new System.Windows.Forms.Label();
            this.lblMinPassword = new System.Windows.Forms.Label();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.chkPrivileged = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.trbCpu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbRam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisk)).BeginInit();
            this.grpVmCt.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(73, 50);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(79, 17);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Utilisateur :";
            // 
            // cmbOS
            // 
            this.cmbOS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOS.FormattingEnabled = true;
            this.cmbOS.Location = new System.Drawing.Point(70, 111);
            this.cmbOS.Name = "cmbOS";
            this.cmbOS.Size = new System.Drawing.Size(284, 24);
            this.cmbOS.TabIndex = 1;
            this.toolTipHelp.SetToolTip(this.cmbOS, "OS disponible");
            // 
            // lblOS
            // 
            this.lblOS.AutoSize = true;
            this.lblOS.Location = new System.Drawing.Point(24, 114);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(40, 17);
            this.lblOS.TabIndex = 4;
            this.lblOS.Text = "OS : ";
            // 
            // lblPcName
            // 
            this.lblPcName.AutoSize = true;
            this.lblPcName.Location = new System.Drawing.Point(360, 96);
            this.lblPcName.Name = "lblPcName";
            this.lblPcName.Size = new System.Drawing.Size(106, 17);
            this.lblPcName.TabIndex = 5;
            this.lblPcName.Text = "Nom machine : ";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(465, 93);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(150, 22);
            this.tbxName.TabIndex = 5;
            this.toolTipHelp.SetToolTip(this.tbxName, "Nom de la machine après création");
            // 
            // trbCpu
            // 
            this.trbCpu.Location = new System.Drawing.Point(76, 192);
            this.trbCpu.Maximum = 4;
            this.trbCpu.Minimum = 1;
            this.trbCpu.Name = "trbCpu";
            this.trbCpu.Size = new System.Drawing.Size(189, 56);
            this.trbCpu.TabIndex = 2;
            this.trbCpu.Value = 1;
            // 
            // lblCpu
            // 
            this.lblCpu.AutoSize = true;
            this.lblCpu.Location = new System.Drawing.Point(24, 202);
            this.lblCpu.Name = "lblCpu";
            this.lblCpu.Size = new System.Drawing.Size(48, 17);
            this.lblCpu.TabIndex = 8;
            this.lblCpu.Text = "CPU : ";
            // 
            // lblRam
            // 
            this.lblRam.AutoSize = true;
            this.lblRam.Location = new System.Drawing.Point(24, 275);
            this.lblRam.Name = "lblRam";
            this.lblRam.Size = new System.Drawing.Size(50, 17);
            this.lblRam.TabIndex = 10;
            this.lblRam.Text = "RAM : ";
            // 
            // trbRam
            // 
            this.trbRam.Location = new System.Drawing.Point(76, 265);
            this.trbRam.Maximum = 12;
            this.trbRam.Minimum = 1;
            this.trbRam.Name = "trbRam";
            this.trbRam.Size = new System.Drawing.Size(189, 56);
            this.trbRam.TabIndex = 3;
            this.trbRam.Value = 1;
            // 
            // tbxPassword
            // 
            this.tbxPassword.Location = new System.Drawing.Point(465, 168);
            this.tbxPassword.Name = "tbxPassword";
            this.tbxPassword.PasswordChar = '●';
            this.tbxPassword.Size = new System.Drawing.Size(150, 22);
            this.tbxPassword.TabIndex = 6;
            // 
            // lblPasswordPc
            // 
            this.lblPasswordPc.AutoSize = true;
            this.lblPasswordPc.Location = new System.Drawing.Point(354, 173);
            this.lblPasswordPc.Name = "lblPasswordPc";
            this.lblPasswordPc.Size = new System.Drawing.Size(105, 17);
            this.lblPasswordPc.TabIndex = 12;
            this.lblPasswordPc.Text = "Mot de passe : ";
            // 
            // numDisk
            // 
            this.numDisk.Location = new System.Drawing.Point(145, 353);
            this.numDisk.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.numDisk.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDisk.Name = "numDisk";
            this.numDisk.Size = new System.Drawing.Size(120, 22);
            this.numDisk.TabIndex = 4;
            this.toolTipHelp.SetToolTip(this.numDisk, "Quantité de disque dur");
            this.numDisk.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblDisk
            // 
            this.lblDisk.AutoSize = true;
            this.lblDisk.Location = new System.Drawing.Point(75, 355);
            this.lblDisk.Name = "lblDisk";
            this.lblDisk.Size = new System.Drawing.Size(64, 17);
            this.lblDisk.TabIndex = 14;
            this.lblDisk.Text = "Disque : ";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(309, 453);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(96, 39);
            this.btnCreate.TabIndex = 10;
            this.btnCreate.Text = "Créer";
            this.toolTipHelp.SetToolTip(this.btnCreate, "Créer la machine configuré");
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // rdbVm
            // 
            this.rdbVm.AutoSize = true;
            this.rdbVm.Location = new System.Drawing.Point(35, 29);
            this.rdbVm.Name = "rdbVm";
            this.rdbVm.Size = new System.Drawing.Size(135, 21);
            this.rdbVm.TabIndex = 8;
            this.rdbVm.Text = "Machine virtuelle";
            this.toolTipHelp.SetToolTip(this.rdbVm, "une machine virtuelle permet de démarrer tous les type de système");
            this.rdbVm.UseVisualStyleBackColor = true;
            // 
            // grpVmCt
            // 
            this.grpVmCt.Controls.Add(this.rdbCt);
            this.grpVmCt.Controls.Add(this.rdbVm);
            this.grpVmCt.Location = new System.Drawing.Point(386, 282);
            this.grpVmCt.Name = "grpVmCt";
            this.grpVmCt.Size = new System.Drawing.Size(214, 93);
            this.grpVmCt.TabIndex = 17;
            this.grpVmCt.TabStop = false;
            this.grpVmCt.Text = "VM ou CT";
            // 
            // rdbCt
            // 
            this.rdbCt.AutoSize = true;
            this.rdbCt.Checked = true;
            this.rdbCt.Location = new System.Drawing.Point(35, 56);
            this.rdbCt.Name = "rdbCt";
            this.rdbCt.Size = new System.Drawing.Size(95, 21);
            this.rdbCt.TabIndex = 9;
            this.rdbCt.TabStop = true;
            this.rdbCt.Text = "Conteneur";
            this.toolTipHelp.SetToolTip(this.rdbCt, "un conteneur est uniquement sous linux");
            this.rdbCt.UseVisualStyleBackColor = true;
            // 
            // lblCores
            // 
            this.lblCores.AutoSize = true;
            this.lblCores.Location = new System.Drawing.Point(271, 202);
            this.lblCores.Name = "lblCores";
            this.lblCores.Size = new System.Drawing.Size(53, 17);
            this.lblCores.TabIndex = 18;
            this.lblCores.Text = "Coeurs";
            // 
            // lblGBRam
            // 
            this.lblGBRam.AutoSize = true;
            this.lblGBRam.Location = new System.Drawing.Point(271, 275);
            this.lblGBRam.Name = "lblGBRam";
            this.lblGBRam.Size = new System.Drawing.Size(28, 17);
            this.lblGBRam.TabIndex = 19;
            this.lblGBRam.Text = "GB";
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Location = new System.Drawing.Point(383, 213);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(81, 17);
            this.lblConfirm.TabIndex = 20;
            this.lblConfirm.Text = "Confirmer : ";
            // 
            // tbxConfirm
            // 
            this.tbxConfirm.Location = new System.Drawing.Point(465, 213);
            this.tbxConfirm.Name = "tbxConfirm";
            this.tbxConfirm.PasswordChar = '●';
            this.tbxConfirm.Size = new System.Drawing.Size(150, 22);
            this.tbxConfirm.TabIndex = 7;
            // 
            // lblGBDisk
            // 
            this.lblGBDisk.AutoSize = true;
            this.lblGBDisk.Location = new System.Drawing.Point(271, 355);
            this.lblGBDisk.Name = "lblGBDisk";
            this.lblGBDisk.Size = new System.Drawing.Size(28, 17);
            this.lblGBDisk.TabIndex = 22;
            this.lblGBDisk.Text = "GB";
            // 
            // lblMinPassword
            // 
            this.lblMinPassword.AutoSize = true;
            this.lblMinPassword.Location = new System.Drawing.Point(502, 192);
            this.lblMinPassword.Name = "lblMinPassword";
            this.lblMinPassword.Size = new System.Drawing.Size(123, 17);
            this.lblMinPassword.TabIndex = 23;
            this.lblMinPassword.Text = "(Min 5 caractères)";
            this.lblMinPassword.Visible = false;
            // 
            // chkPrivileged
            // 
            this.chkPrivileged.AutoSize = true;
            this.chkPrivileged.Location = new System.Drawing.Point(412, 381);
            this.chkPrivileged.Name = "chkPrivileged";
            this.chkPrivileged.Size = new System.Drawing.Size(156, 21);
            this.chkPrivileged.TabIndex = 24;
            this.chkPrivileged.Text = "Conteneur privilegié";
            this.toolTipHelp.SetToolTip(this.chkPrivileged, "Permet de créer un conteneurs avec des privilèges");
            this.chkPrivileged.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(715, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // CreateVM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 526);
            this.Controls.Add(this.chkPrivileged);
            this.Controls.Add(this.lblMinPassword);
            this.Controls.Add(this.lblGBDisk);
            this.Controls.Add(this.tbxConfirm);
            this.Controls.Add(this.lblConfirm);
            this.Controls.Add(this.lblGBRam);
            this.Controls.Add(this.lblCores);
            this.Controls.Add(this.grpVmCt);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lblDisk);
            this.Controls.Add(this.numDisk);
            this.Controls.Add(this.lblPasswordPc);
            this.Controls.Add(this.tbxPassword);
            this.Controls.Add(this.lblRam);
            this.Controls.Add(this.trbRam);
            this.Controls.Add(this.lblCpu);
            this.Controls.Add(this.trbCpu);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.lblPcName);
            this.Controls.Add(this.lblOS);
            this.Controls.Add(this.cmbOS);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "CreateVM";
            this.Text = "Configuraton PC";
            ((System.ComponentModel.ISupportInitialize)(this.trbCpu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbRam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDisk)).EndInit();
            this.grpVmCt.ResumeLayout(false);
            this.grpVmCt.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.ComboBox cmbOS;
        private System.Windows.Forms.Label lblOS;
        private System.Windows.Forms.Label lblPcName;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.TrackBar trbCpu;
        private System.Windows.Forms.Label lblCpu;
        private System.Windows.Forms.Label lblRam;
        private System.Windows.Forms.TrackBar trbRam;
        private System.Windows.Forms.TextBox tbxPassword;
        private System.Windows.Forms.Label lblPasswordPc;
        private System.Windows.Forms.NumericUpDown numDisk;
        private System.Windows.Forms.Label lblDisk;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.RadioButton rdbVm;
        private System.Windows.Forms.GroupBox grpVmCt;
        private System.Windows.Forms.RadioButton rdbCt;
        private System.Windows.Forms.Label lblCores;
        private System.Windows.Forms.Label lblGBRam;
        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.TextBox tbxConfirm;
        private System.Windows.Forms.Label lblGBDisk;
        private System.Windows.Forms.Label lblMinPassword;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.CheckBox chkPrivileged;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
    }
}