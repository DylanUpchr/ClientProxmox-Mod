/*
 * @author   Troller Fabian
 * @date     2019-05-08
 * @brief    Form for check delete of VM / CT
 * @file     DeleteConfirm.cs
 * @version  1.0.0.0
 */

using System;
using System.Windows.Forms;

namespace ClientProxmox
{
    public partial class DeleteConfirm : Form
    {
        #region Variables
        private string _pcName = string.Empty;
        #endregion

        #region Properties
        /// <summary>
        /// The name of pc to delete
        /// </summary>
        public string PcName { get => _pcName; set => _pcName = value; }
        #endregion

        #region Contructor
        /// <summary>
        /// Interface for delete VPS
        /// </summary>
        /// <param name="pcName"></param>
        public DeleteConfirm(string pcName)
        {
            InitializeComponent();
            this.PcName = pcName;
            this.Load += UpdateText;
            this.btnDelete.Click += VerifieName;
        }
        #endregion

        #region Methods Private

        /// <summary>
        /// Update the interface text
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void UpdateText(object sender,EventArgs e)
        {
            this.lblConfirm.Text = $"{this.lblConfirm.Text}\"{this.PcName}\"";
        }

        /// <summary>
        /// Check if name is same as text box
        /// </summary>
        /// <param name="sender">Parent sender</param>
        /// <param name="e">Event</param>
        private void VerifieName(object sender,EventArgs e)
        {
            if (tbxPc.Text == this.PcName)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Mauvais nom de machine");
                this.tbxPc.Clear();
                this.tbxPc.Focus();
            }
        }
        #endregion
    }
}
