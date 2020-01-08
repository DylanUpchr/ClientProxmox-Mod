namespace ClientProxmox
{
    partial class PanelVPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelVPS));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblTeachers = new System.Windows.Forms.Label();
            this.lstVPS = new System.Windows.Forms.ListBox();
            this.chbStartAll = new System.Windows.Forms.CheckBox();
            this.grpInfo = new System.Windows.Forms.GroupBox();
            this.btnConsole = new System.Windows.Forms.Button();
            this.pibVM = new System.Windows.Forms.PictureBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnReboot = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.lblOnline = new System.Windows.Forms.Label();
            this.lblUpTime = new System.Windows.Forms.Label();
            this.lblDisk = new System.Windows.Forms.Label();
            this.lblRam = new System.Windows.Forms.Label();
            this.lblCpu = new System.Windows.Forms.Label();
            this.lblOS = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.cmbNode = new System.Windows.Forms.ComboBox();
            this.lblNode = new System.Windows.Forms.Label();
            this.btnCreate = new System.Windows.Forms.Button();
            this.grpVPS = new System.Windows.Forms.GroupBox();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.pibProfile = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.grpInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pibVM)).BeginInit();
            this.grpVPS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pibProfile)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aideToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(942, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.aideToolStripMenuItem.Text = "Aide";
            // 
            // lblTeachers
            // 
            this.lblTeachers.AutoSize = true;
            this.lblTeachers.Location = new System.Drawing.Point(100, 47);
            this.lblTeachers.Name = "lblTeachers";
            this.lblTeachers.Size = new System.Drawing.Size(91, 17);
            this.lblTeachers.TabIndex = 2;
            this.lblTeachers.Text = "Enseignant : ";
            // 
            // lstVPS
            // 
            this.lstVPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstVPS.FormattingEnabled = true;
            this.lstVPS.ItemHeight = 22;
            this.lstVPS.Location = new System.Drawing.Point(29, 69);
            this.lstVPS.Name = "lstVPS";
            this.lstVPS.Size = new System.Drawing.Size(212, 378);
            this.lstVPS.TabIndex = 3;
            this.toolTipHelp.SetToolTip(this.lstVPS, "Affiche les machines");
            // 
            // chbStartAll
            // 
            this.chbStartAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.chbStartAll.AutoSize = true;
            this.chbStartAll.Location = new System.Drawing.Point(74, 452);
            this.chbStartAll.Name = "chbStartAll";
            this.chbStartAll.Size = new System.Drawing.Size(109, 27);
            this.chbStartAll.TabIndex = 4;
            this.chbStartAll.Text = "Démarrer tous";
            this.toolTipHelp.SetToolTip(this.chbStartAll, "Pernet de démarrer / arrêter toutes les machine");
            this.chbStartAll.UseVisualStyleBackColor = true;
            // 
            // grpInfo
            // 
            this.grpInfo.Controls.Add(this.btnConsole);
            this.grpInfo.Controls.Add(this.pibVM);
            this.grpInfo.Controls.Add(this.btnDelete);
            this.grpInfo.Controls.Add(this.btnReboot);
            this.grpInfo.Controls.Add(this.btnStop);
            this.grpInfo.Controls.Add(this.lblOnline);
            this.grpInfo.Controls.Add(this.lblUpTime);
            this.grpInfo.Controls.Add(this.lblDisk);
            this.grpInfo.Controls.Add(this.lblRam);
            this.grpInfo.Controls.Add(this.lblCpu);
            this.grpInfo.Controls.Add(this.lblOS);
            this.grpInfo.Controls.Add(this.lblUsername);
            this.grpInfo.Location = new System.Drawing.Point(350, 136);
            this.grpInfo.Name = "grpInfo";
            this.grpInfo.Size = new System.Drawing.Size(505, 449);
            this.grpInfo.TabIndex = 5;
            this.grpInfo.TabStop = false;
            this.grpInfo.Text = "Informations";
            // 
            // btnConsole
            // 
            this.btnConsole.Location = new System.Drawing.Point(334, 322);
            this.btnConsole.Name = "btnConsole";
            this.btnConsole.Size = new System.Drawing.Size(122, 32);
            this.btnConsole.TabIndex = 9;
            this.btnConsole.Text = "Console";
            this.toolTipHelp.SetToolTip(this.btnConsole, "Ouvre une interface avec une console");
            this.btnConsole.UseVisualStyleBackColor = true;
            // 
            // pibVM
            // 
            this.pibVM.Location = new System.Drawing.Point(425, 16);
            this.pibVM.Name = "pibVM";
            this.pibVM.Size = new System.Drawing.Size(75, 75);
            this.pibVM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pibVM.TabIndex = 9;
            this.pibVM.TabStop = false;
            this.toolTipHelp.SetToolTip(this.pibVM, "Affiche le type de machine selectionnée");
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.ForeColor = System.Drawing.Color.Black;
            this.btnDelete.Location = new System.Drawing.Point(334, 376);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(122, 35);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Supprimer";
            this.toolTipHelp.SetToolTip(this.btnDelete, "Supprime la machine selectionnée");
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnReboot
            // 
            this.btnReboot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnReboot.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnReboot.Location = new System.Drawing.Point(194, 376);
            this.btnReboot.Name = "btnReboot";
            this.btnReboot.Size = new System.Drawing.Size(122, 35);
            this.btnReboot.TabIndex = 7;
            this.btnReboot.Text = "Redémarrer";
            this.toolTipHelp.SetToolTip(this.btnReboot, "Redémarre la machine selectionnée");
            this.btnReboot.UseVisualStyleBackColor = false;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Location = new System.Drawing.Point(57, 376);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(119, 35);
            this.btnStop.TabIndex = 6;
            this.btnStop.Text = "Arrêter";
            this.toolTipHelp.SetToolTip(this.btnStop, "Arrête la machine selectionnée");
            this.btnStop.UseVisualStyleBackColor = false;
            // 
            // lblOnline
            // 
            this.lblOnline.AutoSize = true;
            this.lblOnline.Location = new System.Drawing.Point(27, 214);
            this.lblOnline.Name = "lblOnline";
            this.lblOnline.Size = new System.Drawing.Size(71, 17);
            this.lblOnline.TabIndex = 7;
            this.lblOnline.Text = "En ligne : ";
            // 
            // lblUpTime
            // 
            this.lblUpTime.AutoSize = true;
            this.lblUpTime.Location = new System.Drawing.Point(27, 185);
            this.lblUpTime.Name = "lblUpTime";
            this.lblUpTime.Size = new System.Drawing.Size(129, 17);
            this.lblUpTime.TabIndex = 6;
            this.lblUpTime.Text = "Temps d\'activités : ";
            // 
            // lblDisk
            // 
            this.lblDisk.AutoSize = true;
            this.lblDisk.Location = new System.Drawing.Point(27, 157);
            this.lblDisk.Name = "lblDisk";
            this.lblDisk.Size = new System.Drawing.Size(64, 17);
            this.lblDisk.TabIndex = 5;
            this.lblDisk.Text = "Disque : ";
            // 
            // lblRam
            // 
            this.lblRam.AutoSize = true;
            this.lblRam.Location = new System.Drawing.Point(27, 128);
            this.lblRam.Name = "lblRam";
            this.lblRam.Size = new System.Drawing.Size(50, 17);
            this.lblRam.TabIndex = 4;
            this.lblRam.Text = "RAM : ";
            // 
            // lblCpu
            // 
            this.lblCpu.AutoSize = true;
            this.lblCpu.Location = new System.Drawing.Point(27, 101);
            this.lblCpu.Name = "lblCpu";
            this.lblCpu.Size = new System.Drawing.Size(48, 17);
            this.lblCpu.TabIndex = 3;
            this.lblCpu.Text = "CPU : ";
            // 
            // lblOS
            // 
            this.lblOS.AutoSize = true;
            this.lblOS.Location = new System.Drawing.Point(27, 72);
            this.lblOS.Name = "lblOS";
            this.lblOS.Size = new System.Drawing.Size(40, 17);
            this.lblOS.TabIndex = 2;
            this.lblOS.Text = "OS : ";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(27, 44);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(62, 17);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Eleves : ";
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Location = new System.Drawing.Point(166, 36);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 27);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Modifier";
            this.toolTipHelp.SetToolTip(this.btnEdit, "Modifie la machine selectionnée");
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // cmbNode
            // 
            this.cmbNode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNode.FormattingEnabled = true;
            this.cmbNode.Location = new System.Drawing.Point(425, 47);
            this.cmbNode.Name = "cmbNode";
            this.cmbNode.Size = new System.Drawing.Size(157, 24);
            this.cmbNode.TabIndex = 5;
            this.toolTipHelp.SetToolTip(this.cmbNode, "Permet de changer de noeuds");
            // 
            // lblNode
            // 
            this.lblNode.AutoSize = true;
            this.lblNode.Location = new System.Drawing.Point(347, 51);
            this.lblNode.Name = "lblNode";
            this.lblNode.Size = new System.Drawing.Size(62, 17);
            this.lblNode.TabIndex = 8;
            this.lblNode.Text = "Noeud : ";
            // 
            // btnCreate
            // 
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Location = new System.Drawing.Point(29, 36);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 27);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Créer";
            this.toolTipHelp.SetToolTip(this.btnCreate, "Créer une nouvelle machine");
            this.btnCreate.UseVisualStyleBackColor = true;
            // 
            // grpVPS
            // 
            this.grpVPS.Controls.Add(this.btnCreate);
            this.grpVPS.Controls.Add(this.lstVPS);
            this.grpVPS.Controls.Add(this.chbStartAll);
            this.grpVPS.Controls.Add(this.btnEdit);
            this.grpVPS.Location = new System.Drawing.Point(51, 100);
            this.grpVPS.Name = "grpVPS";
            this.grpVPS.Size = new System.Drawing.Size(269, 485);
            this.grpVPS.TabIndex = 9;
            this.grpVPS.TabStop = false;
            this.grpVPS.Text = "Gestion de VPS";
            // 
            // pibProfile
            // 
            this.pibProfile.Location = new System.Drawing.Point(873, 31);
            this.pibProfile.Name = "pibProfile";
            this.pibProfile.Size = new System.Drawing.Size(65, 60);
            this.pibProfile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pibProfile.TabIndex = 10;
            this.pibProfile.TabStop = false;
            // 
            // PanelVPS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 623);
            this.Controls.Add(this.pibProfile);
            this.Controls.Add(this.lblNode);
            this.Controls.Add(this.cmbNode);
            this.Controls.Add(this.grpInfo);
            this.Controls.Add(this.lblTeachers);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.grpVPS);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PanelVPS";
            this.Text = "Gestion de machine";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpInfo.ResumeLayout(false);
            this.grpInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pibVM)).EndInit();
            this.grpVPS.ResumeLayout(false);
            this.grpVPS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pibProfile)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aideToolStripMenuItem;
        private System.Windows.Forms.Label lblTeachers;
        private System.Windows.Forms.ListBox lstVPS;
        private System.Windows.Forms.CheckBox chbStartAll;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblOnline;
        private System.Windows.Forms.Label lblUpTime;
        private System.Windows.Forms.Label lblDisk;
        private System.Windows.Forms.Label lblRam;
        private System.Windows.Forms.Label lblCpu;
        private System.Windows.Forms.Label lblOS;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnReboot;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ComboBox cmbNode;
        private System.Windows.Forms.Label lblNode;
        private System.Windows.Forms.PictureBox pibVM;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnConsole;
        private System.Windows.Forms.GroupBox grpVPS;
        private System.Windows.Forms.ToolTip toolTipHelp;
        private System.Windows.Forms.PictureBox pibProfile;
    }
}