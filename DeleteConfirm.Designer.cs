namespace ClientProxmox
{
    partial class DeleteConfirm
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
            this.lblConfirm = new System.Windows.Forms.Label();
            this.lblInstruct = new System.Windows.Forms.Label();
            this.tbxPc = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.toolTipHelp = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblConfirm
            // 
            this.lblConfirm.AutoSize = true;
            this.lblConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfirm.Location = new System.Drawing.Point(12, 19);
            this.lblConfirm.Name = "lblConfirm";
            this.lblConfirm.Size = new System.Drawing.Size(350, 20);
            this.lblConfirm.TabIndex = 0;
            this.lblConfirm.Text = "Voulez vous vraiment supprimer la machine : ";
            // 
            // lblInstruct
            // 
            this.lblInstruct.AutoSize = true;
            this.lblInstruct.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstruct.Location = new System.Drawing.Point(12, 53);
            this.lblInstruct.Name = "lblInstruct";
            this.lblInstruct.Size = new System.Drawing.Size(435, 20);
            this.lblInstruct.TabIndex = 1;
            this.lblInstruct.Text = "Si oui mettez le nom de la machine dans la boite de texte";
            // 
            // tbxPc
            // 
            this.tbxPc.Location = new System.Drawing.Point(122, 90);
            this.tbxPc.Name = "tbxPc";
            this.tbxPc.Size = new System.Drawing.Size(325, 22);
            this.tbxPc.TabIndex = 0;
            this.toolTipHelp.SetToolTip(this.tbxPc, "Taper le nom de la machine à supprimer");
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Location = new System.Drawing.Point(241, 142);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 28);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "Supprimer";
            this.toolTipHelp.SetToolTip(this.btnDelete, "Supprime la machine");
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // DeleteConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 182);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.tbxPc);
            this.Controls.Add(this.lblInstruct);
            this.Controls.Add(this.lblConfirm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteConfirm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DeleteConfirm";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConfirm;
        private System.Windows.Forms.Label lblInstruct;
        private System.Windows.Forms.TextBox tbxPc;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ToolTip toolTipHelp;
    }
}