using System;

namespace Inversions.GUI
{
    partial class SimulacióVendaTab
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ntbPig = new Controls.NumericTextBox2();
            this.btSimulacio = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ntbPreuParticipacio = new Controls.NumericTextBox2();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ntbNumParticipacions = new Controls.NumericTextBox2();
            this.productes = new Inversions.GUI.GestioProductes();
            this.panel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.btSimulacio);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 493);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1459, 329);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ntbPig);
            this.groupBox2.Location = new System.Drawing.Point(13, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 57);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "P i G";
            // 
            // ntbPig
            // 
            this.ntbPig._CapturaEscape = true;
            this.ntbPig._Format = "#,###.#€";
            this.ntbPig._PermetDecimals = true;
            this.ntbPig._PermetEspais = false;
            this.ntbPig._PermetNegatius = true;
            this.ntbPig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPig.Location = new System.Drawing.Point(3, 22);
            this.ntbPig.Name = "ntbPig";
            this.ntbPig.ReadOnly = true;
            this.ntbPig.Size = new System.Drawing.Size(183, 26);
            this.ntbPig.TabIndex = 4;
            this.ntbPig.Text = "€";
            this.ntbPig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPig.Valor = 0D;
            // 
            // btSimulacio
            // 
            this.btSimulacio.Enabled = false;
            this.btSimulacio.Location = new System.Drawing.Point(262, 35);
            this.btSimulacio.Name = "btSimulacio";
            this.btSimulacio.Size = new System.Drawing.Size(95, 39);
            this.btSimulacio.TabIndex = 3;
            this.btSimulacio.Text = "Simulació";
            this.btSimulacio.UseVisualStyleBackColor = true;
            this.btSimulacio.Click += new System.EventHandler(this.btSimulacio_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ntbPreuParticipacio);
            this.groupBox3.Location = new System.Drawing.Point(145, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(111, 55);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preu Partic.";
            // 
            // ntbPreuParticipacio
            // 
            this.ntbPreuParticipacio._CapturaEscape = true;
            this.ntbPreuParticipacio._Format = "#,##0.######";
            this.ntbPreuParticipacio._PermetDecimals = true;
            this.ntbPreuParticipacio._PermetEspais = false;
            this.ntbPreuParticipacio._PermetNegatius = true;
            this.ntbPreuParticipacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPreuParticipacio.Enabled = false;
            this.ntbPreuParticipacio.Location = new System.Drawing.Point(3, 22);
            this.ntbPreuParticipacio.Name = "ntbPreuParticipacio";
            this.ntbPreuParticipacio.Size = new System.Drawing.Size(105, 26);
            this.ntbPreuParticipacio.TabIndex = 3;
            this.ntbPreuParticipacio.Text = "0";
            this.ntbPreuParticipacio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPreuParticipacio.Valor = 0D;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ntbNumParticipacions);
            this.groupBox1.Location = new System.Drawing.Point(13, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(111, 55);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Num, Partic.";
            // 
            // ntbNumParticipacions
            // 
            this.ntbNumParticipacions._CapturaEscape = true;
            this.ntbNumParticipacions._Format = "#,##0.######";
            this.ntbNumParticipacions._PermetDecimals = true;
            this.ntbNumParticipacions._PermetEspais = false;
            this.ntbNumParticipacions._PermetNegatius = true;
            this.ntbNumParticipacions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbNumParticipacions.Enabled = false;
            this.ntbNumParticipacions.Location = new System.Drawing.Point(3, 22);
            this.ntbNumParticipacions.Name = "ntbNumParticipacions";
            this.ntbNumParticipacions.Size = new System.Drawing.Size(105, 26);
            this.ntbNumParticipacions.TabIndex = 3;
            this.ntbNumParticipacions.Text = "0";
            this.ntbNumParticipacions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbNumParticipacions.Valor = 0D;
            // 
            // productes
            // 
            this.productes._AmbMoviments = true;
            this.productes._FiltreAnyVisible = false;
            this.productes._MostraLlistaAmbChecks = false;
            this.productes._NomesAmbParticipacions = true;
            this.productes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productes.Dock = System.Windows.Forms.DockStyle.Top;
            this.productes.Location = new System.Drawing.Point(0, 0);
            this.productes.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.productes.MinimumSize = new System.Drawing.Size(824, 493);
            this.productes.Name = "productes";
            this.productes.Size = new System.Drawing.Size(1459, 493);
            this.productes.TabIndex = 0;
            this.productes.ProducteSeleccionat += new System.EventHandler(this.productes_ProducteSeleccionat);
            // 
            // SimulacióVendaTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.productes);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SimulacióVendaTab";
            this.Size = new System.Drawing.Size(1459, 822);
            this.panel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GestioProductes productes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btSimulacio;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.NumericTextBox2 ntbNumParticipacions;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controls.NumericTextBox2 ntbPig;
        private System.Windows.Forms.GroupBox groupBox3;
        private Controls.NumericTextBox2 ntbPreuParticipacio;
    }
}
