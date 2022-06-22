using System;
using System.Windows.Forms;

namespace Inversions.GUI
{
    partial class UsuarisTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbUsuaris = new System.Windows.Forms.ComboBox();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbUsuaris);
            this.groupBox6.Location = new System.Drawing.Point(38, 25);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox6.Size = new System.Drawing.Size(259, 61);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Usuari";
            // 
            // cbUsuaris
            // 
            this.cbUsuaris.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbUsuaris.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuaris.FormattingEnabled = true;
            this.cbUsuaris.Location = new System.Drawing.Point(6, 23);
            this.cbUsuaris.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbUsuaris.Name = "cbUsuaris";
            this.cbUsuaris.Size = new System.Drawing.Size(247, 28);
            this.cbUsuaris.TabIndex = 0;
            // 
            // UsuarisTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox6);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1464, 819);
            this.Name = "UsuarisTab";
            this.Size = new System.Drawing.Size(1642, 819);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox groupBox6;
        private ComboBox cbUsuaris;

    }
}
