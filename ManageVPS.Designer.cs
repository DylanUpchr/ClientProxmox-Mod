namespace ClientProxmox
{
    partial class ManageVPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageVPS));
            this.btnModificate = new System.Windows.Forms.Button();
            this.lblDisk = new System.Windows.Forms.Label();
            this.numDisk = new System.Windows.Forms.NumericUpDown();
            this.lblRam = new System.Windows.Forms.Label();
            this.trbRam = new System.Windows.Forms.TrackBar();
            this.lblCpu = new System.Windows.Forms.Label();
            this.trbCpu = new System.Windows.Forms.TrackBar();
            this.lblUsername = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblOS = new System.Windows.Forms.Label();
            this.lblOsValue = new System.Windows.Forms.Label();
            this.lblGBRam = new System.Windows.Forms.Label();
            this.lblGBDisk = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tbxName = new System.Windows.Forms.TextBox();
            this.lblCpuNumber = new System.Windows.Forms.Label();
            this.lblAdminCpu = new System.Windows.Forms.Label();
            this.lblAdminRam = new System.Windows.Forms.Label();
            this.lblAdminDisk = new System.Windows.Forms.Label();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.numDisk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbRam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbCpu)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnModificate
            // 
            this.btnModificate.Location = new System.Drawing.Point(132, 484);
            this.btnModificate.Name = "btnModificate";
            this.btnModificate.Size = new System.Drawing.Size(96, 39);
            this.btnModificate.TabIndex = 5;
            this.btnModificate.Text = "Modifier";
            this.toolTipHelp.SetToolTip(this.btnModificate, "Modifie la machine");
            this.btnModificate.UseVisualStyleBackColor = true;
            // 
            // lblDisk
            // 
            this.lblDisk.AutoSize = true;
            this.lblDisk.Location = new System.Drawing.Point(26, 381);
            this.lblDisk.Name = "lblDisk";
            this.lblDisk.Size = new System.Drawing.Size(64, 17);
            this.lblDisk.TabIndex = 32;
            this.lblDisk.Text = "Disque : ";
            // 
            // numDisk
            // 
            this.numDisk.Location = new System.Drawing.Point(96, 379);
            this.numDisk.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numDisk.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numDisk.Name = "numDisk";
            this.numDisk.Size = new System.Drawing.Size(169, 22);
            this.numDisk.TabIndex = 4;
            this.toolTipHelp.SetToolTip(this.numDisk, "Taille du disque dur forcémement plus grande");
            this.numDisk.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblRam
            // 
            this.lblRam.AutoSize = true;
            this.lblRam.Location = new System.Drawing.Point(24, 305);
            this.lblRam.Name = "lblRam";
            this.lblRam.Size = new System.Drawing.Size(50, 17);
            this.lblRam.TabIndex = 28;
            this.lblRam.Text = "RAM : ";
            // 
            // trbRam
            // 
            this.trbRam.Location = new System.Drawing.Point(76, 295);
            this.trbRam.Maximum = 50;
            this.trbRam.Minimum = 1;
            this.trbRam.Name = "trbRam";
            this.trbRam.Size = new System.Drawing.Size(189, 56);
            this.trbRam.TabIndex = 3;
            this.trbRam.Value = 1;
            // 
            // lblCpu
            // 
            this.lblCpu.AutoSize = true;
            this.lblCpu.Location = new System.Drawing.Point(24, 228);
            this.lblCpu.Name = "lblCpu";
            this.lblCpu.Size = new System.Drawing.Size(48, 17);
            this.lblCpu.TabIndex = 26;
            this.lblCpu.Text = "CPU : ";
            // 
            // trbCpu
            // 
            this.trbCpu.Location = new System.Drawing.Point(76, 218);
            this.trbCpu.Maximum = 16;
            this.trbCpu.Minimum = 1;
            this.trbCpu.Name = "trbCpu";
            this.trbCpu.Size = new System.Drawing.Size(189, 56);
            this.trbCpu.TabIndex = 2;
            this.trbCpu.Value = 1;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(70, 76);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(91, 17);
            this.lblUsername.TabIndex = 19;
            this.lblUsername.Text = "Enseignant : ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(357, 28);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // lblOS
            // 
            this.lblOS.AutoSize = true;
            this.lblOS.Location = new System.Drawing.Point(25, 132);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(40, 17);
            this.lblOS.TabIndex = 22;
            this.lblOS.Text = "OS : ";
            // 
            // lblOsValue
            // 
            this.lblOsValue.AutoSize = true;
            this.lblOsValue.Location = new System.Drawing.Point(71, 132);
            this.lblOsValue.Name = "lblOsValue";
            this.lblOsValue.Size = new System.Drawing.Size(51, 17);
            this.lblOsValue.TabIndex = 34;
            this.lblOsValue.Text = "debian";
            // 
            // lblGBRam
            // 
            this.lblGBRam.AutoSize = true;
            this.lblGBRam.Location = new System.Drawing.Point(271, 305);
            this.lblGBRam.Name = "lblGBRam";
            this.lblGBRam.Size = new System.Drawing.Size(28, 17);
            this.lblGBRam.TabIndex = 35;
            this.lblGBRam.Text = "GB";
            // 
            // lblGBDisk
            // 
            this.lblGBDisk.AutoSize = true;
            this.lblGBDisk.Location = new System.Drawing.Point(271, 381);
            this.lblGBDisk.Name = "lblGBDisk";
            this.lblGBDisk.Size = new System.Drawing.Size(28, 17);
            this.lblGBDisk.TabIndex = 36;
            this.lblGBDisk.Text = "GB";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(25, 174);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(49, 17);
            this.lblName.TabIndex = 37;
            this.lblName.Text = "Nom : ";
            // 
            // tbxName
            // 
            this.tbxName.Location = new System.Drawing.Point(80, 172);
            this.tbxName.Name = "tbxName";
            this.tbxName.Size = new System.Drawing.Size(167, 22);
            this.tbxName.TabIndex = 1;
            this.toolTipHelp.SetToolTip(this.tbxName, "Nom de la machine");
            // 
            // lblCpuNumber
            // 
            this.lblCpuNumber.AutoSize = true;
            this.lblCpuNumber.Location = new System.Drawing.Point(271, 228);
            this.lblCpuNumber.Name = "lblCpuNumber";
            this.lblCpuNumber.Size = new System.Drawing.Size(53, 17);
            this.lblCpuNumber.TabIndex = 39;
            this.lblCpuNumber.Text = "Coeurs";
            // 
            // lblAdminCpu
            // 
            this.lblAdminCpu.AutoSize = true;
            this.lblAdminCpu.Location = new System.Drawing.Point(190, 257);
            this.lblAdminCpu.Name = "lblAdminCpu";
            this.lblAdminCpu.Size = new System.Drawing.Size(134, 17);
            this.lblAdminCpu.TabIndex = 40;
            this.lblAdminCpu.Text = "(Override by admin)";
            this.lblAdminCpu.Visible = false;
            // 
            // lblAdminRam
            // 
            this.lblAdminRam.AutoSize = true;
            this.lblAdminRam.Location = new System.Drawing.Point(190, 334);
            this.lblAdminRam.Name = "lblAdminRam";
            this.lblAdminRam.Size = new System.Drawing.Size(134, 17);
            this.lblAdminRam.TabIndex = 41;
            this.lblAdminRam.Text = "(Override by admin)";
            this.lblAdminRam.Visible = false;
            // 
            // lblAdminDisk
            // 
            this.lblAdminDisk.AutoSize = true;
            this.lblAdminDisk.Location = new System.Drawing.Point(190, 404);
            this.lblAdminDisk.Name = "lblAdminDisk";
            this.lblAdminDisk.Size = new System.Drawing.Size(134, 17);
            this.lblAdminDisk.TabIndex = 42;
            this.lblAdminDisk.Text = "(Override by admin)";
            this.lblAdminDisk.Visible = false;
            // 
            // ManageVPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(357, 535);
            this.Controls.Add(this.lblAdminDisk);
            this.Controls.Add(this.lblAdminRam);
            this.Controls.Add(this.lblAdminCpu);
            this.Controls.Add(this.lblCpuNumber);
            this.Controls.Add(this.tbxName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblGBDisk);
            this.Controls.Add(this.lblGBRam);
            this.Controls.Add(this.lblOsValue);
            this.Controls.Add(this.btnModificate);
            this.Controls.Add(this.lblDisk);
            this.Controls.Add(this.numDisk);
            this.Controls.Add(this.lblRam);
            this.Controls.Add(this.trbRam);
            this.Controls.Add(this.lblCpu);
            this.Controls.Add(this.trbCpu);
            this.Controls.Add(this.lblOS);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManageVPS";
            this.Text = "Modification VPS";
            ((System.ComponentModel.ISupportInitialize)(this.numDisk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbRam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbCpu)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnModificate;
        private System.Windows.Forms.Label lblDisk;
        private System.Windows.Forms.NumericUpDown numDisk;
        private System.Windows.Forms.Label lblRam;
        private System.Windows.Forms.TrackBar trbRam;
        private System.Windows.Forms.Label lblCpu;
        private System.Windows.Forms.TrackBar trbCpu;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.Label lblOS;
        private System.Windows.Forms.Label lblOsValue;
        private System.Windows.Forms.Label lblGBRam;
        private System.Windows.Forms.Label lblGBDisk;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbxName;
        private System.Windows.Forms.Label lblCpuNumber;
        private System.Windows.Forms.Label lblAdminCpu;
        private System.Windows.Forms.Label lblAdminRam;
        private System.Windows.Forms.Label lblAdminDisk;
        private System.Windows.Forms.ToolTip toolTipHelp;
    }
}