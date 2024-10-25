using System;
using System.Windows.Forms;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbData = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbValorActual = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbNomProducte = new System.Windows.Forms.Label();
            this.gestioProductesTabValoracions = new Inversions.GUI.GestioProductes();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ntbIntervalEixY = new Controls.NumericTextBox2();
            this.panel3 = new System.Windows.Forms.GroupBox();
            this.dtpFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpInici = new Controls.DateTimePickerNullable();
            this.ckIntervalAutomatic = new System.Windows.Forms.CheckBox();
            this.ckDataIniciComu = new System.Windows.Forms.CheckBox();
            this.ckPonderat = new System.Windows.Forms.CheckBox();
            this.btgActualitzaGrafiques = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.lbNomProducte);
            this.panel1.Controls.Add(this.gestioProductesTabValoracions);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Size = new System.Drawing.Size(481, 819);
            this.panel1.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lbData);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.lbValorActual);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 724);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.panel4.Size = new System.Drawing.Size(475, 34);
            this.panel4.TabIndex = 4;
            // 
            // lbData
            // 
            this.lbData.AutoSize = true;
            this.lbData.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbData.Location = new System.Drawing.Point(138, 3);
            this.lbData.Name = "lbData";
            this.lbData.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lbData.Size = new System.Drawing.Size(29, 23);
            this.lbData.TabIndex = 3;
            this.lbData.Text = "    ";
            this.lbData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(85, 3);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label4.Size = new System.Drawing.Size(53, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Data:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbValorActual
            // 
            this.lbValorActual.AutoSize = true;
            this.lbValorActual.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbValorActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbValorActual.Location = new System.Drawing.Point(56, 3);
            this.lbValorActual.Name = "lbValorActual";
            this.lbValorActual.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.lbValorActual.Size = new System.Drawing.Size(29, 23);
            this.lbValorActual.TabIndex = 1;
            this.lbValorActual.Text = "    ";
            this.lbValorActual.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Valor:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbNomProducte
            // 
            this.lbNomProducte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbNomProducte.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbNomProducte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomProducte.Location = new System.Drawing.Point(3, 698);
            this.lbNomProducte.Name = "lbNomProducte";
            this.lbNomProducte.Size = new System.Drawing.Size(475, 26);
            this.lbNomProducte.TabIndex = 2;
            this.lbNomProducte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gestioProductesTabValoracions
            // 
            this.gestioProductesTabValoracions._AmbMoviments = true;
            this.gestioProductesTabValoracions._FiltreAnyVisible = false;
            this.gestioProductesTabValoracions._MostraLlistaAmbChecks = true;
            this.gestioProductesTabValoracions._NomesAmbParticipacions = true;
            this.gestioProductesTabValoracions.Dock = System.Windows.Forms.DockStyle.Top;
            this.gestioProductesTabValoracions.Location = new System.Drawing.Point(3, 204);
            this.gestioProductesTabValoracions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gestioProductesTabValoracions.Name = "gestioProductesTabValoracions";
            this.gestioProductesTabValoracions.Size = new System.Drawing.Size(475, 494);
            this.gestioProductesTabValoracions.TabIndex = 1;
            this.gestioProductesTabValoracions.EventItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.gestioProductesTabValoracions_ItemCheck);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.ckIntervalAutomatic);
            this.panel2.Controls.Add(this.ckDataIniciComu);
            this.panel2.Controls.Add(this.ckPonderat);
            this.panel2.Controls.Add(this.btgActualitzaGrafiques);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(475, 168);
            this.panel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ntbIntervalEixY);
            this.groupBox1.Location = new System.Drawing.Point(311, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.groupBox1.Size = new System.Drawing.Size(108, 58);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Interval Y";
            // 
            // ntbIntervalEixY
            // 
            this.ntbIntervalEixY._CapturaEscape = true;
            this.ntbIntervalEixY._Format = "0.00";
            this.ntbIntervalEixY._NegatiusEnVermell = false;
            this.ntbIntervalEixY._PermetDecimals = true;
            this.ntbIntervalEixY._PermetNegatius = false;
            this.ntbIntervalEixY._PermetTextNull = false;
            this.ntbIntervalEixY.BackColor = System.Drawing.SystemColors.Window;
            this.ntbIntervalEixY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbIntervalEixY.ForeColor = System.Drawing.Color.Black;
            this.ntbIntervalEixY.Location = new System.Drawing.Point(3, 22);
            this.ntbIntervalEixY.Name = "ntbIntervalEixY";
            this.ntbIntervalEixY.Size = new System.Drawing.Size(102, 26);
            this.ntbIntervalEixY.TabIndex = 0;
            this.ntbIntervalEixY.Text = "1,00";
            this.ntbIntervalEixY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbIntervalEixY.Valor = new decimal(new int[] {
            100,
            0,
            0,
            131072});
            this.ntbIntervalEixY.TextChanged += new System.EventHandler(this.ntbIntervalEixY_TextChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtpFinal);
            this.panel3.Controls.Add(this.dtpInici);
            this.panel3.Location = new System.Drawing.Point(8, 97);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(297, 65);
            this.panel3.TabIndex = 1;
            this.panel3.TabStop = false;
            this.panel3.Text = "Dates";
            // 
            // dtpFinal
            // 
            this.dtpFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFinal.Location = new System.Drawing.Point(150, 25);
            this.dtpFinal.Name = "dtpFinal";
            this.dtpFinal.Size = new System.Drawing.Size(135, 26);
            this.dtpFinal.TabIndex = 1;
            this.dtpFinal.Value = new System.DateTime(2018, 2, 26, 19, 57, 11, 47);
            this.dtpFinal.ValueChanged += new System.EventHandler(this.dtpInici_ValueChanged);
            // 
            // dtpInici
            // 
            this.dtpInici.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpInici.Location = new System.Drawing.Point(6, 25);
            this.dtpInici.Name = "dtpInici";
            this.dtpInici.Size = new System.Drawing.Size(135, 26);
            this.dtpInici.TabIndex = 0;
            this.dtpInici.Value = null;
            this.dtpInici.ValueChanged += new System.EventHandler(this.dtpInici_ValueChanged);
            // 
            // ckIntervalAutomatic
            // 
            this.ckIntervalAutomatic.AutoSize = true;
            this.ckIntervalAutomatic.Checked = true;
            this.ckIntervalAutomatic.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckIntervalAutomatic.Location = new System.Drawing.Point(299, 65);
            this.ckIntervalAutomatic.Name = "ckIntervalAutomatic";
            this.ckIntervalAutomatic.Size = new System.Drawing.Size(161, 24);
            this.ckIntervalAutomatic.TabIndex = 3;
            this.ckIntervalAutomatic.Text = "Interval automàtic";
            this.ckIntervalAutomatic.UseVisualStyleBackColor = true;
            this.ckIntervalAutomatic.CheckedChanged += new System.EventHandler(this.ck_CheckedChanged);
            // 
            // ckDataIniciComu
            // 
            this.ckDataIniciComu.AutoSize = true;
            this.ckDataIniciComu.Checked = true;
            this.ckDataIniciComu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckDataIniciComu.Location = new System.Drawing.Point(299, 35);
            this.ckDataIniciComu.Name = "ckDataIniciComu";
            this.ckDataIniciComu.Size = new System.Drawing.Size(148, 24);
            this.ckDataIniciComu.TabIndex = 3;
            this.ckDataIniciComu.Text = "Data Inici Comú";
            this.ckDataIniciComu.UseVisualStyleBackColor = true;
            this.ckDataIniciComu.CheckedChanged += new System.EventHandler(this.ck_CheckedChanged);
            // 
            // ckPonderat
            // 
            this.ckPonderat.AutoSize = true;
            this.ckPonderat.Checked = true;
            this.ckPonderat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckPonderat.Location = new System.Drawing.Point(299, 4);
            this.ckPonderat.Name = "ckPonderat";
            this.ckPonderat.Size = new System.Drawing.Size(157, 24);
            this.ckPonderat.TabIndex = 2;
            this.ckPonderat.Text = "Valors Ponderats";
            this.ckPonderat.UseVisualStyleBackColor = true;
            this.ckPonderat.CheckedChanged += new System.EventHandler(this.ck_CheckedChanged);
            // 
            // btgActualitzaGrafiques
            // 
            this.btgActualitzaGrafiques.Enabled = false;
            this.btgActualitzaGrafiques.Location = new System.Drawing.Point(8, 4);
            this.btgActualitzaGrafiques.Name = "btgActualitzaGrafiques";
            this.btgActualitzaGrafiques.Size = new System.Drawing.Size(285, 50);
            this.btgActualitzaGrafiques.TabIndex = 0;
            this.btgActualitzaGrafiques.Text = "Actualitza Gràfiques";
            this.btgActualitzaGrafiques.UseVisualStyleBackColor = true;
            this.btgActualitzaGrafiques.Click += new System.EventHandler(this.btgActualitzaGrafiques_Click);
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(475, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Doble click canvia la paletta de colors";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.DoubleClick += new System.EventHandler(this.chart1_DoubleClick);
            // 
            // chart1
            // 
            chartArea2.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea2);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Top;
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(481, 0);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.chart1.Size = new System.Drawing.Size(1161, 819);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            this.chart1.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chart1_GetToolTipText);
            this.chart1.DoubleClick += new System.EventHandler(this.chart1_DoubleClick);
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
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private GestioProductes gestioProductesTabValoracions;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btgActualitzaGrafiques;
        private System.Windows.Forms.CheckBox ckPonderat;
        private System.Windows.Forms.GroupBox panel3;
        private System.Windows.Forms.DateTimePicker dtpFinal;
        private Controls.DateTimePickerNullable dtpInici;
        private System.Windows.Forms.CheckBox ckDataIniciComu;
        private GroupBox groupBox1;
        private Controls.NumericTextBox2 ntbIntervalEixY;
        private Label lbNomProducte;
        private Label label2;
        private Panel panel4;
        private Label lbValorActual;
        private Label label1;
        private Label lbData;
        private Label label4;
        private CheckBox ckIntervalAutomatic;
    }
}
