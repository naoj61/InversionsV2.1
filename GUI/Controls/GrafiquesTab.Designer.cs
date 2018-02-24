using System;

namespace Inversions.GUI
{
    partial class GrafiquesTab
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btgActualitzaGrafiques = new System.Windows.Forms.Button();
            this.gestioProductesTabValoracions = new Inversions.GUI.GestioProductes();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gestioProductesTabValoracions);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Size = new System.Drawing.Size(495, 819);
            this.panel1.TabIndex = 9;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(495, 0);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(1147, 819);
            this.chart1.TabIndex = 11;
            this.chart1.Text = "chart1";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btgActualitzaGrafiques);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(489, 88);
            this.panel2.TabIndex = 13;
            // 
            // btgActualitzaGrafiques
            // 
            this.btgActualitzaGrafiques.Enabled = false;
            this.btgActualitzaGrafiques.Location = new System.Drawing.Point(24, 18);
            this.btgActualitzaGrafiques.Name = "btgActualitzaGrafiques";
            this.btgActualitzaGrafiques.Size = new System.Drawing.Size(449, 50);
            this.btgActualitzaGrafiques.TabIndex = 10;
            this.btgActualitzaGrafiques.Text = "Actualitza Gràfiques";
            this.btgActualitzaGrafiques.UseVisualStyleBackColor = true;
            this.btgActualitzaGrafiques.Click += new System.EventHandler(this.btgActualitzaGrafiques_Click);
            // 
            // gestioProductesTabValoracions
            // 
            this.gestioProductesTabValoracions._AmbMoviments = true;
            this.gestioProductesTabValoracions._FiltreAnyVisible = false;
            this.gestioProductesTabValoracions._MostraLlistaAmbChecks = true;
            this.gestioProductesTabValoracions._NomesAmbParticipacions = true;
            this.gestioProductesTabValoracions.Dock = System.Windows.Forms.DockStyle.Top;
            this.gestioProductesTabValoracions.Location = new System.Drawing.Point(3, 92);
            this.gestioProductesTabValoracions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gestioProductesTabValoracions.Name = "gestioProductesTabValoracions";
            this.gestioProductesTabValoracions.Size = new System.Drawing.Size(489, 494);
            this.gestioProductesTabValoracions.TabIndex = 9;
            this.gestioProductesTabValoracions.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.gestioProductesTabValoracions_ItemCheck);
            // 
            // GrafiquesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1464, 819);
            this.Name = "GrafiquesTab";
            this.Size = new System.Drawing.Size(1642, 819);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GestioProductes gestioProductesTabValoracions;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btgActualitzaGrafiques;
    }
}
