using System;
using System.Windows.Forms;

namespace Inversions.GUI
{
    partial class EdicioTaulesTab
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
            this.pnCombo = new System.Windows.Forms.Panel();
            this.comboBoxTaules = new System.Windows.Forms.ComboBox();
            this.pnButons = new System.Windows.Forms.Panel();
            this.btDesa = new System.Windows.Forms.Button();
            this.btCancela = new System.Windows.Forms.Button();
            this.pnTaules = new System.Windows.Forms.Panel();
            this.pnCombo.SuspendLayout();
            this.pnButons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnCombo
            // 
            this.pnCombo.Controls.Add(this.comboBoxTaules);
            this.pnCombo.Controls.Add(this.pnButons);
            this.pnCombo.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnCombo.Location = new System.Drawing.Point(0, 0);
            this.pnCombo.Name = "pnCombo";
            this.pnCombo.Size = new System.Drawing.Size(339, 819);
            this.pnCombo.TabIndex = 5;
            // 
            // comboBoxTaules
            // 
            this.comboBoxTaules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxTaules.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBoxTaules.FormattingEnabled = true;
            this.comboBoxTaules.Location = new System.Drawing.Point(0, 0);
            this.comboBoxTaules.Name = "comboBoxTaules";
            this.comboBoxTaules.Size = new System.Drawing.Size(339, 768);
            this.comboBoxTaules.TabIndex = 11;
            // 
            // pnButons
            // 
            this.pnButons.Controls.Add(this.btDesa);
            this.pnButons.Controls.Add(this.btCancela);
            this.pnButons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnButons.Location = new System.Drawing.Point(0, 768);
            this.pnButons.Name = "pnButons";
            this.pnButons.Size = new System.Drawing.Size(339, 51);
            this.pnButons.TabIndex = 13;
            // 
            // btDesa
            // 
            this.btDesa.Enabled = false;
            this.btDesa.Location = new System.Drawing.Point(3, 6);
            this.btDesa.Name = "btDesa";
            this.btDesa.Size = new System.Drawing.Size(98, 40);
            this.btDesa.TabIndex = 7;
            this.btDesa.Text = "Desa";
            this.btDesa.UseVisualStyleBackColor = true;
            this.btDesa.Click += new System.EventHandler(this.btDesa_Click);
            // 
            // btCancela
            // 
            this.btCancela.Enabled = false;
            this.btCancela.Location = new System.Drawing.Point(107, 6);
            this.btCancela.Name = "btCancela";
            this.btCancela.Size = new System.Drawing.Size(98, 40);
            this.btCancela.TabIndex = 7;
            this.btCancela.Text = "Cancel·la";
            this.btCancela.UseVisualStyleBackColor = true;
            this.btCancela.Click += new System.EventHandler(this.btCancela_Click);
            // 
            // pnTaules
            // 
            this.pnTaules.AutoScroll = true;
            this.pnTaules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnTaules.Location = new System.Drawing.Point(339, 0);
            this.pnTaules.Name = "pnTaules";
            this.pnTaules.Size = new System.Drawing.Size(1303, 819);
            this.pnTaules.TabIndex = 6;
            // 
            // EdicioTaulesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnTaules);
            this.Controls.Add(this.pnCombo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1464, 819);
            this.Name = "EdicioTaulesTab";
            this.Size = new System.Drawing.Size(1642, 819);
            this.Load += new System.EventHandler(this.edicioTaulesTab_Load);
            this.pnCombo.ResumeLayout(false);
            this.pnButons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnCombo;
        private ComboBox comboBoxTaules;
        private Panel pnButons;
        private Button btDesa;
        private Button btCancela;
        private Panel pnTaules;


    }
}
