using System;
using Controls;

namespace Inversions.GUI
{
    partial class ValoracionsTab
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.cData = new System.Windows.Forms.DateTimePicker();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tbImport = new Controls.NumericTextBox2();
            this.btCancela = new System.Windows.Forms.Button();
            this.btNouValor = new System.Windows.Forms.Button();
            this.btDesa = new System.Windows.Forms.Button();
            this.dgvValoracions = new Controls.DataGridView3();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVariacioPercent = new Controls.NumericTextBoxColumn2();
            this.colVariacioEuros = new Controls.NumericTextBoxColumn2();
            this.pnEdicio = new System.Windows.Forms.Panel();
            this.btModifica = new System.Windows.Forms.Button();
            this.dgvValoracionsPerData = new Controls.DataGridView3();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new Controls.NumericTextBoxColumn2();
            this.colVariacioPercentatge = new Controls.NumericTextBoxColumn2();
            this.colVariacioEuros2 = new Controls.NumericTextBoxColumn2();
            this.Column1 = new Controls.NumericTextBoxColumn2();
            this.btActualitzaLlista = new System.Windows.Forms.Button();
            this.gbFiltreTipusProducte = new System.Windows.Forms.GroupBox();
            this.checkedComboBoxEdit1 = new DevExpress.XtraEditors.CheckedComboBoxEdit();
            this.dtpDataIniciLlista = new System.Windows.Forms.DateTimePicker();
            this.btEsborra = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnFiltreValoracions = new System.Windows.Forms.Panel();
            this.tlpPercents = new System.Windows.Forms.TableLayoutPanel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.ntbPercent1A = new Controls.NumericTextBox2();
            this.panel8 = new System.Windows.Forms.Panel();
            this.ntbPercentAny = new Controls.NumericTextBox2();
            this.panel7 = new System.Windows.Forms.Panel();
            this.ntbPercent6M12 = new Controls.NumericTextBox2();
            this.ntbPercent6M = new Controls.NumericTextBox2();
            this.panel6 = new System.Windows.Forms.Panel();
            this.ntbPercent3M12 = new Controls.NumericTextBox2();
            this.ntbPercent3M = new Controls.NumericTextBox2();
            this.label6 = new System.Windows.Forms.Label();
            this.lbPercentAny = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ntbPercent1M12 = new Controls.NumericTextBox2();
            this.ntbPercent1M = new Controls.NumericTextBox2();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ckValsAmbParticipacions = new System.Windows.Forms.CheckBox();
            this.dtpDataIniciValoracions = new System.Windows.Forms.DateTimePicker();
            this.gestioProductesTabValoracions = new Inversions.GUI.GestioProductes();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lbTitolValoracionsPerData = new System.Windows.Forms.Label();
            this.btCopiaValorsDelPaste = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.gbData.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValoracions)).BeginInit();
            this.pnEdicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValoracionsPerData)).BeginInit();
            this.gbFiltreTipusProducte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.pnFiltreValoracions.SuspendLayout();
            this.tlpPercents.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.cData);
            this.gbData.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbData.Location = new System.Drawing.Point(3, 6);
            this.gbData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbData.Name = "gbData";
            this.gbData.Padding = new System.Windows.Forms.Padding(6);
            this.gbData.Size = new System.Drawing.Size(147, 66);
            this.gbData.TabIndex = 0;
            this.gbData.TabStop = false;
            this.gbData.Text = "Data";
            // 
            // cData
            // 
            this.cData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cData.Enabled = false;
            this.cData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cData.Location = new System.Drawing.Point(6, 25);
            this.cData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cData.Name = "cData";
            this.cData.Size = new System.Drawing.Size(135, 26);
            this.cData.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tbImport);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(150, 6);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox10.Size = new System.Drawing.Size(137, 66);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Import";
            // 
            // tbImport
            // 
            this.tbImport._CapturaEscape = true;
            this.tbImport._Format = "#,##0.0######### €";
            this.tbImport._NegatiusEnVermell = false;
            this.tbImport._PermetDecimals = true;
            this.tbImport._PermetNegatius = false;
            this.tbImport._PermetTextNull = false;
            this.tbImport.BackColor = System.Drawing.SystemColors.Window;
            this.tbImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbImport.Enabled = false;
            this.tbImport.ForeColor = System.Drawing.Color.Black;
            this.tbImport.Location = new System.Drawing.Point(6, 25);
            this.tbImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbImport.Name = "tbImport";
            this.tbImport.Size = new System.Drawing.Size(125, 26);
            this.tbImport.TabIndex = 0;
            this.tbImport.Text = "0,0 €";
            this.tbImport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbImport.Valor = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            this.tbImport.TextChanged += new System.EventHandler(this.tbImport_TextChanged);
            this.tbImport.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbImport_KeyDown);
            // 
            // btCancela
            // 
            this.btCancela.Enabled = false;
            this.btCancela.ForeColor = System.Drawing.Color.Red;
            this.btCancela.Location = new System.Drawing.Point(418, 61);
            this.btCancela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCancela.Name = "btCancela";
            this.btCancela.Size = new System.Drawing.Size(150, 45);
            this.btCancela.TabIndex = 6;
            this.btCancela.Text = "Cancela";
            this.btCancela.UseVisualStyleBackColor = true;
            this.btCancela.Click += new System.EventHandler(this.btCancela_Click);
            // 
            // btNouValor
            // 
            this.btNouValor.Enabled = false;
            this.btNouValor.Location = new System.Drawing.Point(150, 9);
            this.btNouValor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btNouValor.Name = "btNouValor";
            this.btNouValor.Size = new System.Drawing.Size(110, 45);
            this.btNouValor.TabIndex = 1;
            this.btNouValor.Text = "Nou Valor";
            this.btNouValor.UseVisualStyleBackColor = true;
            this.btNouValor.Click += new System.EventHandler(this.btNouValor_Click);
            // 
            // btDesa
            // 
            this.btDesa.Enabled = false;
            this.btDesa.ForeColor = System.Drawing.Color.Green;
            this.btDesa.Location = new System.Drawing.Point(276, 61);
            this.btDesa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDesa.Name = "btDesa";
            this.btDesa.Size = new System.Drawing.Size(124, 45);
            this.btDesa.TabIndex = 5;
            this.btDesa.Text = "Desa";
            this.btDesa.UseVisualStyleBackColor = true;
            this.btDesa.Click += new System.EventHandler(this.btDesa_Click);
            // 
            // dgvValoracions
            // 
            this.dgvValoracions.AllowUserToAddRows = false;
            this.dgvValoracions.AllowUserToDeleteRows = false;
            this.dgvValoracions.AllowUserToOrderColumns = true;
            this.dgvValoracions.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValoracions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvValoracions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValoracions.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colProducte,
            this.colData,
            this.NumPart,
            this.colImport,
            this.colValor,
            this.colVariacioPercent,
            this.colVariacioEuros});
            this.dgvValoracions.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvValoracions.Location = new System.Drawing.Point(0, 574);
            this.dgvValoracions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvValoracions.Name = "dgvValoracions";
            this.dgvValoracions.ReadOnly = true;
            this.dgvValoracions.RowHeadersVisible = false;
            this.dgvValoracions.RowTemplate.Height = 24;
            this.dgvValoracions.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvValoracions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvValoracions.Size = new System.Drawing.Size(460, 245);
            this.dgvValoracions.TabIndex = 0;
            this.dgvValoracions.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.cDataGridView1_RowEnter);
            // 
            // colId
            // 
            this.colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colId.DataPropertyName = "_Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colId.Width = 29;
            // 
            // colProducte
            // 
            this.colProducte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProducte.DataPropertyName = "_Prod";
            this.colProducte.HeaderText = "Producte";
            this.colProducte.Name = "colProducte";
            this.colProducte.ReadOnly = true;
            this.colProducte.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colProducte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colProducte.Visible = false;
            // 
            // colData
            // 
            this.colData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colData.DataPropertyName = "_Data";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.colData.DefaultCellStyle = dataGridViewCellStyle2;
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colData.Width = 50;
            // 
            // NumPart
            // 
            this.NumPart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NumPart.DataPropertyName = "_NumParticipacions";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N4";
            dataGridViewCellStyle3.NullValue = null;
            this.NumPart.DefaultCellStyle = dataGridViewCellStyle3;
            this.NumPart.HeaderText = "Num. Part.";
            this.NumPart.Name = "NumPart";
            this.NumPart.ReadOnly = true;
            this.NumPart.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NumPart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumPart.Width = 89;
            // 
            // colImport
            // 
            this.colImport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.colImport.DataPropertyName = "_PreuParticipacio";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#,#0.00###### €";
            dataGridViewCellStyle4.NullValue = null;
            this.colImport.DefaultCellStyle = dataGridViewCellStyle4;
            this.colImport.HeaderText = "Import Part/Acc";
            this.colImport.Name = "colImport";
            this.colImport.ReadOnly = true;
            this.colImport.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colImport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colImport.Width = 5;
            // 
            // colValor
            // 
            this.colValor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colValor.DataPropertyName = "_ValoracioTotal";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.colValor.DefaultCellStyle = dataGridViewCellStyle5;
            this.colValor.HeaderText = "Valor Total";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colValor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colValor.Width = 91;
            // 
            // colVariacioPercent
            // 
            this.colVariacioPercent._NegatiusEnVermell = true;
            this.colVariacioPercent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colVariacioPercent.DataPropertyName = "_VariacioPercentatge";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "#0.00# %";
            dataGridViewCellStyle6.NullValue = null;
            this.colVariacioPercent.DefaultCellStyle = dataGridViewCellStyle6;
            this.colVariacioPercent.HeaderText = "Variació %";
            this.colVariacioPercent.Name = "colVariacioPercent";
            this.colVariacioPercent.ReadOnly = true;
            this.colVariacioPercent.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colVariacioPercent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colVariacioPercent.Width = 90;
            // 
            // colVariacioEuros
            // 
            this.colVariacioEuros._NegatiusEnVermell = true;
            this.colVariacioEuros.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colVariacioEuros.DataPropertyName = "_VariacioEuros";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "#,#0.00 €";
            dataGridViewCellStyle7.NullValue = null;
            this.colVariacioEuros.DefaultCellStyle = dataGridViewCellStyle7;
            this.colVariacioEuros.HeaderText = "Variació €";
            this.colVariacioEuros.Name = "colVariacioEuros";
            this.colVariacioEuros.ReadOnly = true;
            this.colVariacioEuros.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colVariacioEuros.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colVariacioEuros.Width = 85;
            // 
            // pnEdicio
            // 
            this.pnEdicio.Controls.Add(this.groupBox10);
            this.pnEdicio.Controls.Add(this.gbData);
            this.pnEdicio.Location = new System.Drawing.Point(278, 119);
            this.pnEdicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnEdicio.Name = "pnEdicio";
            this.pnEdicio.Padding = new System.Windows.Forms.Padding(3, 6, 3, 4);
            this.pnEdicio.Size = new System.Drawing.Size(290, 76);
            this.pnEdicio.TabIndex = 7;
            this.pnEdicio.Visible = false;
            // 
            // btModifica
            // 
            this.btModifica.Enabled = false;
            this.btModifica.Location = new System.Drawing.Point(276, 9);
            this.btModifica.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btModifica.Name = "btModifica";
            this.btModifica.Size = new System.Drawing.Size(124, 45);
            this.btModifica.TabIndex = 2;
            this.btModifica.Text = "Modifica";
            this.btModifica.UseVisualStyleBackColor = true;
            this.btModifica.Click += new System.EventHandler(this.btModifica_Click);
            // 
            // dgvValoracionsPerData
            // 
            this.dgvValoracionsPerData.AllowUserToAddRows = false;
            this.dgvValoracionsPerData.AllowUserToDeleteRows = false;
            this.dgvValoracionsPerData.AllowUserToOrderColumns = true;
            this.dgvValoracionsPerData.AllowUserToResizeRows = false;
            this.dgvValoracionsPerData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValoracionsPerData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvValoracionsPerData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValoracionsPerData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.colVariacioPercentatge,
            this.colVariacioEuros2,
            this.Column1});
            this.dgvValoracionsPerData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvValoracionsPerData.Location = new System.Drawing.Point(0, 237);
            this.dgvValoracionsPerData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvValoracionsPerData.Name = "dgvValoracionsPerData";
            this.dgvValoracionsPerData.ReadOnly = true;
            this.dgvValoracionsPerData.RowHeadersVisible = false;
            this.dgvValoracionsPerData.RowTemplate.Height = 24;
            this.dgvValoracionsPerData.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvValoracionsPerData.Size = new System.Drawing.Size(636, 298);
            this.dgvValoracionsPerData.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "_Data";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "d";
            dataGridViewCellStyle9.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn3.FillWeight = 75F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Data";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4._NegatiusEnVermell = true;
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "_Pig";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "#,##0.00 €";
            dataGridViewCellStyle10.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn4.HeaderText = "PiG en Cartera";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 150;
            // 
            // colVariacioPercentatge
            // 
            this.colVariacioPercentatge._NegatiusEnVermell = true;
            this.colVariacioPercentatge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colVariacioPercentatge.DataPropertyName = "_VariacioPercentatge";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "#0.00 %";
            dataGridViewCellStyle11.NullValue = "-";
            this.colVariacioPercentatge.DefaultCellStyle = dataGridViewCellStyle11;
            this.colVariacioPercentatge.FillWeight = 20F;
            this.colVariacioPercentatge.HeaderText = "Variació %";
            this.colVariacioPercentatge.Name = "colVariacioPercentatge";
            this.colVariacioPercentatge.ReadOnly = true;
            this.colVariacioPercentatge.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colVariacioPercentatge.Width = 111;
            // 
            // colVariacioEuros2
            // 
            this.colVariacioEuros2._NegatiusEnVermell = true;
            this.colVariacioEuros2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colVariacioEuros2.DataPropertyName = "_VariacioImport";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "#,##0.00 €";
            dataGridViewCellStyle12.NullValue = "-";
            this.colVariacioEuros2.DefaultCellStyle = dataGridViewCellStyle12;
            this.colVariacioEuros2.FillWeight = 50F;
            this.colVariacioEuros2.HeaderText = "Variació €";
            this.colVariacioEuros2.Name = "colVariacioEuros2";
            this.colVariacioEuros2.ReadOnly = true;
            this.colVariacioEuros2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colVariacioEuros2.Width = 107;
            // 
            // Column1
            // 
            this.Column1._NegatiusEnVermell = true;
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "_ValorTotal";
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "#,##0.00 €";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column1.HeaderText = "Valor total";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // btActualitzaLlista
            // 
            this.btActualitzaLlista.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btActualitzaLlista.Location = new System.Drawing.Point(6, 68);
            this.btActualitzaLlista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btActualitzaLlista.Name = "btActualitzaLlista";
            this.btActualitzaLlista.Size = new System.Drawing.Size(240, 45);
            this.btActualitzaLlista.TabIndex = 2;
            this.btActualitzaLlista.Text = "Actualitza";
            this.btActualitzaLlista.UseVisualStyleBackColor = true;
            this.btActualitzaLlista.Click += new System.EventHandler(this.btActualitzaLlista_Click);
            // 
            // gbFiltreTipusProducte
            // 
            this.gbFiltreTipusProducte.Controls.Add(this.checkedComboBoxEdit1);
            this.gbFiltreTipusProducte.Controls.Add(this.dtpDataIniciLlista);
            this.gbFiltreTipusProducte.Controls.Add(this.btActualitzaLlista);
            this.gbFiltreTipusProducte.Location = new System.Drawing.Point(20, 76);
            this.gbFiltreTipusProducte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFiltreTipusProducte.Name = "gbFiltreTipusProducte";
            this.gbFiltreTipusProducte.Padding = new System.Windows.Forms.Padding(6);
            this.gbFiltreTipusProducte.Size = new System.Drawing.Size(252, 119);
            this.gbFiltreTipusProducte.TabIndex = 4;
            this.gbFiltreTipusProducte.TabStop = false;
            this.gbFiltreTipusProducte.Text = "Tipus Prod.           Data Inici";
            // 
            // checkedComboBoxEdit1
            // 
            this.checkedComboBoxEdit1.EditValue = "RF, RV, Accions, Criptos";
            this.checkedComboBoxEdit1.Location = new System.Drawing.Point(11, 25);
            this.checkedComboBoxEdit1.Name = "checkedComboBoxEdit1";
            this.checkedComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.checkedComboBoxEdit1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.CheckedListBoxItem[] {
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(Inversions.GUI.ValoracionsTab.TipusProd.RF, "Fons RF", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(Inversions.GUI.ValoracionsTab.TipusProd.RV, "Fons RV", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(Inversions.GUI.ValoracionsTab.TipusProd.Accions, "Accions", System.Windows.Forms.CheckState.Checked),
            new DevExpress.XtraEditors.Controls.CheckedListBoxItem(Inversions.GUI.ValoracionsTab.TipusProd.Criptos, "Criptos", System.Windows.Forms.CheckState.Checked)});
            this.checkedComboBoxEdit1.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.checkedComboBoxEdit1.Properties.SelectAllItemCaption = "Selecciona-ho Tot";
            this.checkedComboBoxEdit1.Properties.ShowButtons = false;
            this.checkedComboBoxEdit1.Size = new System.Drawing.Size(109, 26);
            this.checkedComboBoxEdit1.TabIndex = 0;
            this.checkedComboBoxEdit1.CloseUp += new DevExpress.XtraEditors.Controls.CloseUpEventHandler(this.checkedComboBoxEdit1_CloseUp);
            // 
            // dtpDataIniciLlista
            // 
            this.dtpDataIniciLlista.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpDataIniciLlista.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataIniciLlista.Location = new System.Drawing.Point(131, 25);
            this.dtpDataIniciLlista.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDataIniciLlista.Name = "dtpDataIniciLlista";
            this.dtpDataIniciLlista.Size = new System.Drawing.Size(115, 26);
            this.dtpDataIniciLlista.TabIndex = 1;
            // 
            // btEsborra
            // 
            this.btEsborra.Enabled = false;
            this.btEsborra.Location = new System.Drawing.Point(416, 9);
            this.btEsborra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btEsborra.Name = "btEsborra";
            this.btEsborra.Size = new System.Drawing.Size(150, 45);
            this.btEsborra.TabIndex = 3;
            this.btEsborra.Text = "Esborra";
            this.btEsborra.UseVisualStyleBackColor = true;
            this.btEsborra.Click += new System.EventHandler(this.btEsborra_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Controls.Add(this.dgvValoracions);
            this.panel1.Controls.Add(this.pnFiltreValoracions);
            this.panel1.Controls.Add(this.gestioProductesTabValoracions);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1006, 819);
            this.panel1.TabIndex = 0;
            // 
            // chart1
            // 
            this.chart1.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.FrameThin1;
            chartArea1.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chart1.Location = new System.Drawing.Point(460, 574);
            this.chart1.Margin = new System.Windows.Forms.Padding(0);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Name = "Series1";
            series1.XValueMember = "Data";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "PreuParticipacio";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(546, 245);
            this.chart1.TabIndex = 1;
            this.chart1.Text = "chart1";
            // 
            // pnFiltreValoracions
            // 
            this.pnFiltreValoracions.Controls.Add(this.tlpPercents);
            this.pnFiltreValoracions.Controls.Add(this.panel5);
            this.pnFiltreValoracions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnFiltreValoracions.Location = new System.Drawing.Point(0, 494);
            this.pnFiltreValoracions.Name = "pnFiltreValoracions";
            this.pnFiltreValoracions.Padding = new System.Windows.Forms.Padding(5);
            this.pnFiltreValoracions.Size = new System.Drawing.Size(1006, 80);
            this.pnFiltreValoracions.TabIndex = 1;
            // 
            // tlpPercents
            // 
            this.tlpPercents.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpPercents.ColumnCount = 6;
            this.tlpPercents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPercents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPercents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPercents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPercents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpPercents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPercents.Controls.Add(this.panel9, 4, 1);
            this.tlpPercents.Controls.Add(this.panel8, 3, 1);
            this.tlpPercents.Controls.Add(this.panel7, 2, 1);
            this.tlpPercents.Controls.Add(this.panel6, 1, 1);
            this.tlpPercents.Controls.Add(this.label6, 4, 0);
            this.tlpPercents.Controls.Add(this.lbPercentAny, 3, 0);
            this.tlpPercents.Controls.Add(this.label4, 2, 0);
            this.tlpPercents.Controls.Add(this.label3, 1, 0);
            this.tlpPercents.Controls.Add(this.label2, 0, 0);
            this.tlpPercents.Controls.Add(this.panel4, 0, 1);
            this.tlpPercents.Dock = System.Windows.Forms.DockStyle.Right;
            this.tlpPercents.Location = new System.Drawing.Point(310, 5);
            this.tlpPercents.Name = "tlpPercents";
            this.tlpPercents.RowCount = 2;
            this.tlpPercents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpPercents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPercents.Size = new System.Drawing.Size(691, 70);
            this.tlpPercents.TabIndex = 2;
            // 
            // panel9
            // 
            this.panel9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel9.Controls.Add(this.ntbPercent1A);
            this.panel9.Location = new System.Drawing.Point(570, 28);
            this.panel9.Name = "panel9";
            this.panel9.Padding = new System.Windows.Forms.Padding(3);
            this.panel9.Size = new System.Drawing.Size(84, 39);
            this.panel9.TabIndex = 9;
            // 
            // ntbPercent1A
            // 
            this.ntbPercent1A._CapturaEscape = true;
            this.ntbPercent1A._Format = "0.00%";
            this.ntbPercent1A._NegatiusEnVermell = true;
            this.ntbPercent1A._PermetDecimals = true;
            this.ntbPercent1A._PermetNegatius = true;
            this.ntbPercent1A._PermetTextNull = false;
            this.ntbPercent1A.BackColor = System.Drawing.Color.Khaki;
            this.ntbPercent1A.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPercent1A.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPercent1A.ForeColor = System.Drawing.Color.Black;
            this.ntbPercent1A.Location = new System.Drawing.Point(3, 3);
            this.ntbPercent1A.Name = "ntbPercent1A";
            this.ntbPercent1A.ReadOnly = true;
            this.ntbPercent1A.Size = new System.Drawing.Size(76, 26);
            this.ntbPercent1A.TabIndex = 1;
            this.ntbPercent1A.Text = "0,00%";
            this.ntbPercent1A.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPercent1A.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // panel8
            // 
            this.panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel8.Controls.Add(this.ntbPercentAny);
            this.panel8.Location = new System.Drawing.Point(480, 28);
            this.panel8.Name = "panel8";
            this.panel8.Padding = new System.Windows.Forms.Padding(3);
            this.panel8.Size = new System.Drawing.Size(84, 39);
            this.panel8.TabIndex = 8;
            // 
            // ntbPercentAny
            // 
            this.ntbPercentAny._CapturaEscape = true;
            this.ntbPercentAny._Format = "0.00%";
            this.ntbPercentAny._NegatiusEnVermell = true;
            this.ntbPercentAny._PermetDecimals = true;
            this.ntbPercentAny._PermetNegatius = true;
            this.ntbPercentAny._PermetTextNull = false;
            this.ntbPercentAny.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPercentAny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPercentAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPercentAny.ForeColor = System.Drawing.Color.Black;
            this.ntbPercentAny.Location = new System.Drawing.Point(3, 3);
            this.ntbPercentAny.Name = "ntbPercentAny";
            this.ntbPercentAny.ReadOnly = true;
            this.ntbPercentAny.Size = new System.Drawing.Size(76, 26);
            this.ntbPercentAny.TabIndex = 1;
            this.ntbPercentAny.Text = "0,00%";
            this.ntbPercentAny.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPercentAny.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.ntbPercent6M12);
            this.panel7.Controls.Add(this.ntbPercent6M);
            this.panel7.Location = new System.Drawing.Point(321, 28);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(3);
            this.panel7.Size = new System.Drawing.Size(153, 39);
            this.panel7.TabIndex = 7;
            // 
            // ntbPercent6M12
            // 
            this.ntbPercent6M12._CapturaEscape = true;
            this.ntbPercent6M12._Format = "0.00%";
            this.ntbPercent6M12._NegatiusEnVermell = true;
            this.ntbPercent6M12._PermetDecimals = true;
            this.ntbPercent6M12._PermetNegatius = true;
            this.ntbPercent6M12._PermetTextNull = false;
            this.ntbPercent6M12.BackColor = System.Drawing.Color.Khaki;
            this.ntbPercent6M12.Dock = System.Windows.Forms.DockStyle.Right;
            this.ntbPercent6M12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPercent6M12.ForeColor = System.Drawing.Color.Black;
            this.ntbPercent6M12.Location = new System.Drawing.Point(80, 3);
            this.ntbPercent6M12.Name = "ntbPercent6M12";
            this.ntbPercent6M12.ReadOnly = true;
            this.ntbPercent6M12.Size = new System.Drawing.Size(68, 26);
            this.ntbPercent6M12.TabIndex = 3;
            this.ntbPercent6M12.Text = "0,00%";
            this.ntbPercent6M12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPercent6M12.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // ntbPercent6M
            // 
            this.ntbPercent6M._CapturaEscape = true;
            this.ntbPercent6M._Format = "0.00%";
            this.ntbPercent6M._NegatiusEnVermell = true;
            this.ntbPercent6M._PermetDecimals = true;
            this.ntbPercent6M._PermetNegatius = true;
            this.ntbPercent6M._PermetTextNull = false;
            this.ntbPercent6M.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPercent6M.Dock = System.Windows.Forms.DockStyle.Left;
            this.ntbPercent6M.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPercent6M.ForeColor = System.Drawing.Color.Black;
            this.ntbPercent6M.Location = new System.Drawing.Point(3, 3);
            this.ntbPercent6M.Name = "ntbPercent6M";
            this.ntbPercent6M.ReadOnly = true;
            this.ntbPercent6M.Size = new System.Drawing.Size(68, 26);
            this.ntbPercent6M.TabIndex = 2;
            this.ntbPercent6M.Text = "0,00%";
            this.ntbPercent6M.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPercent6M.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.ntbPercent3M12);
            this.panel6.Controls.Add(this.ntbPercent3M);
            this.panel6.Location = new System.Drawing.Point(162, 28);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(3);
            this.panel6.Size = new System.Drawing.Size(153, 39);
            this.panel6.TabIndex = 6;
            // 
            // ntbPercent3M12
            // 
            this.ntbPercent3M12._CapturaEscape = true;
            this.ntbPercent3M12._Format = "0.00%";
            this.ntbPercent3M12._NegatiusEnVermell = true;
            this.ntbPercent3M12._PermetDecimals = true;
            this.ntbPercent3M12._PermetNegatius = true;
            this.ntbPercent3M12._PermetTextNull = false;
            this.ntbPercent3M12.BackColor = System.Drawing.Color.Khaki;
            this.ntbPercent3M12.Dock = System.Windows.Forms.DockStyle.Right;
            this.ntbPercent3M12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPercent3M12.ForeColor = System.Drawing.Color.Black;
            this.ntbPercent3M12.Location = new System.Drawing.Point(80, 3);
            this.ntbPercent3M12.Margin = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.ntbPercent3M12.Name = "ntbPercent3M12";
            this.ntbPercent3M12.ReadOnly = true;
            this.ntbPercent3M12.Size = new System.Drawing.Size(68, 26);
            this.ntbPercent3M12.TabIndex = 3;
            this.ntbPercent3M12.Text = "0,00%";
            this.ntbPercent3M12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPercent3M12.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // ntbPercent3M
            // 
            this.ntbPercent3M._CapturaEscape = true;
            this.ntbPercent3M._Format = "0.00%";
            this.ntbPercent3M._NegatiusEnVermell = true;
            this.ntbPercent3M._PermetDecimals = true;
            this.ntbPercent3M._PermetNegatius = true;
            this.ntbPercent3M._PermetTextNull = false;
            this.ntbPercent3M.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPercent3M.Dock = System.Windows.Forms.DockStyle.Left;
            this.ntbPercent3M.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPercent3M.ForeColor = System.Drawing.Color.Black;
            this.ntbPercent3M.Location = new System.Drawing.Point(3, 3);
            this.ntbPercent3M.Name = "ntbPercent3M";
            this.ntbPercent3M.ReadOnly = true;
            this.ntbPercent3M.Size = new System.Drawing.Size(68, 26);
            this.ntbPercent3M.TabIndex = 2;
            this.ntbPercent3M.Text = "0,00%";
            this.ntbPercent3M.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPercent3M.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(567, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 25);
            this.label6.TabIndex = 4;
            this.label6.Text = "% 1A";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbPercentAny
            // 
            this.lbPercentAny.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbPercentAny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPercentAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPercentAny.Location = new System.Drawing.Point(477, 0);
            this.lbPercentAny.Margin = new System.Windows.Forms.Padding(0);
            this.lbPercentAny.Name = "lbPercentAny";
            this.lbPercentAny.Size = new System.Drawing.Size(90, 25);
            this.lbPercentAny.TabIndex = 3;
            this.lbPercentAny.Text = "% Any";
            this.lbPercentAny.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(318, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "% 6M";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(159, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 25);
            this.label3.TabIndex = 1;
            this.label3.Text = "% 3M";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "% 1M";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.ntbPercent1M12);
            this.panel4.Controls.Add(this.ntbPercent1M);
            this.panel4.Location = new System.Drawing.Point(3, 28);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(153, 39);
            this.panel4.TabIndex = 5;
            // 
            // ntbPercent1M12
            // 
            this.ntbPercent1M12._CapturaEscape = true;
            this.ntbPercent1M12._Format = "0.00%";
            this.ntbPercent1M12._NegatiusEnVermell = true;
            this.ntbPercent1M12._PermetDecimals = true;
            this.ntbPercent1M12._PermetNegatius = true;
            this.ntbPercent1M12._PermetTextNull = false;
            this.ntbPercent1M12.BackColor = System.Drawing.Color.Khaki;
            this.ntbPercent1M12.Dock = System.Windows.Forms.DockStyle.Right;
            this.ntbPercent1M12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPercent1M12.ForeColor = System.Drawing.Color.Black;
            this.ntbPercent1M12.Location = new System.Drawing.Point(80, 3);
            this.ntbPercent1M12.Margin = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.ntbPercent1M12.Name = "ntbPercent1M12";
            this.ntbPercent1M12.ReadOnly = true;
            this.ntbPercent1M12.Size = new System.Drawing.Size(68, 26);
            this.ntbPercent1M12.TabIndex = 3;
            this.ntbPercent1M12.Text = "0,00%";
            this.ntbPercent1M12.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPercent1M12.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // ntbPercent1M
            // 
            this.ntbPercent1M._CapturaEscape = true;
            this.ntbPercent1M._Format = "0.00%";
            this.ntbPercent1M._NegatiusEnVermell = true;
            this.ntbPercent1M._PermetDecimals = true;
            this.ntbPercent1M._PermetNegatius = true;
            this.ntbPercent1M._PermetTextNull = false;
            this.ntbPercent1M.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPercent1M.Dock = System.Windows.Forms.DockStyle.Left;
            this.ntbPercent1M.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPercent1M.ForeColor = System.Drawing.Color.Black;
            this.ntbPercent1M.Location = new System.Drawing.Point(3, 3);
            this.ntbPercent1M.Name = "ntbPercent1M";
            this.ntbPercent1M.ReadOnly = true;
            this.ntbPercent1M.Size = new System.Drawing.Size(68, 26);
            this.ntbPercent1M.TabIndex = 2;
            this.ntbPercent1M.Text = "0,00%";
            this.ntbPercent1M.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPercent1M.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.ckValsAmbParticipacions);
            this.panel5.Controls.Add(this.dtpDataIniciValoracions);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel5.Location = new System.Drawing.Point(5, 5);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(233, 70);
            this.panel5.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Inici";
            // 
            // ckValsAmbParticipacions
            // 
            this.ckValsAmbParticipacions.AutoSize = true;
            this.ckValsAmbParticipacions.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ckValsAmbParticipacions.Checked = true;
            this.ckValsAmbParticipacions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckValsAmbParticipacions.Location = new System.Drawing.Point(4, 37);
            this.ckValsAmbParticipacions.Margin = new System.Windows.Forms.Padding(0);
            this.ckValsAmbParticipacions.Name = "ckValsAmbParticipacions";
            this.ckValsAmbParticipacions.Size = new System.Drawing.Size(221, 24);
            this.ckValsAmbParticipacions.TabIndex = 2;
            this.ckValsAmbParticipacions.Text = "Només amb participacions";
            this.ckValsAmbParticipacions.UseVisualStyleBackColor = true;
            this.ckValsAmbParticipacions.CheckedChanged += new System.EventHandler(this.ckValsAmbParticipacions_CheckedChanged);
            // 
            // dtpDataIniciValoracions
            // 
            this.dtpDataIniciValoracions.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataIniciValoracions.Location = new System.Drawing.Point(86, 2);
            this.dtpDataIniciValoracions.Margin = new System.Windows.Forms.Padding(0);
            this.dtpDataIniciValoracions.Name = "dtpDataIniciValoracions";
            this.dtpDataIniciValoracions.Size = new System.Drawing.Size(139, 26);
            this.dtpDataIniciValoracions.TabIndex = 1;
            this.dtpDataIniciValoracions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dtpDataIniciValoracions_KeyPress);
            this.dtpDataIniciValoracions.Validating += new System.ComponentModel.CancelEventHandler(this.dtpDataIniciValoracions_Validating);
            // 
            // gestioProductesTabValoracions
            // 
            this.gestioProductesTabValoracions._AmbMoviments = true;
            this.gestioProductesTabValoracions._FiltreAnyVisible = false;
            this.gestioProductesTabValoracions._MostraLlistaAmbChecks = false;
            this.gestioProductesTabValoracions._NomesAmbParticipacions = true;
            this.gestioProductesTabValoracions.Dock = System.Windows.Forms.DockStyle.Top;
            this.gestioProductesTabValoracions.Location = new System.Drawing.Point(0, 0);
            this.gestioProductesTabValoracions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gestioProductesTabValoracions.MinimumSize = new System.Drawing.Size(825, 494);
            this.gestioProductesTabValoracions.Name = "gestioProductesTabValoracions";
            this.gestioProductesTabValoracions.Size = new System.Drawing.Size(1006, 494);
            this.gestioProductesTabValoracions.TabIndex = 0;
            this.gestioProductesTabValoracions.EventProducteSeleccionat += new System.EventHandler(this.gestioProductesTabValoracions_ProducteSeleccionat);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lbTitolValoracionsPerData);
            this.panel2.Controls.Add(this.btCopiaValorsDelPaste);
            this.panel2.Controls.Add(this.btModifica);
            this.panel2.Controls.Add(this.btDesa);
            this.panel2.Controls.Add(this.btNouValor);
            this.panel2.Controls.Add(this.gbFiltreTipusProducte);
            this.panel2.Controls.Add(this.btEsborra);
            this.panel2.Controls.Add(this.btCancela);
            this.panel2.Controls.Add(this.pnEdicio);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(636, 237);
            this.panel2.TabIndex = 0;
            // 
            // lbTitolValoracionsPerData
            // 
            this.lbTitolValoracionsPerData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbTitolValoracionsPerData.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbTitolValoracionsPerData.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitolValoracionsPerData.Location = new System.Drawing.Point(0, 208);
            this.lbTitolValoracionsPerData.Name = "lbTitolValoracionsPerData";
            this.lbTitolValoracionsPerData.Size = new System.Drawing.Size(636, 29);
            this.lbTitolValoracionsPerData.TabIndex = 8;
            this.lbTitolValoracionsPerData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btCopiaValorsDelPaste
            // 
            this.btCopiaValorsDelPaste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btCopiaValorsDelPaste.Location = new System.Drawing.Point(20, 4);
            this.btCopiaValorsDelPaste.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btCopiaValorsDelPaste.Name = "btCopiaValorsDelPaste";
            this.btCopiaValorsDelPaste.Size = new System.Drawing.Size(114, 54);
            this.btCopiaValorsDelPaste.TabIndex = 0;
            this.btCopiaValorsDelPaste.Text = "Còpia des d\'un Paste";
            this.btCopiaValorsDelPaste.UseVisualStyleBackColor = false;
            this.btCopiaValorsDelPaste.Click += new System.EventHandler(this.btCopiaValorsDelPaste_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvValoracionsPerData);
            this.panel3.Controls.Add(this.chart2);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1006, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(636, 819);
            this.panel3.TabIndex = 10;
            // 
            // chart2
            // 
            this.chart2.BorderSkin.SkinStyle = System.Windows.Forms.DataVisualization.Charting.BorderSkinStyle.FrameThin1;
            chartArea2.AxisX.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.AxisY.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.False;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.chart2.Location = new System.Drawing.Point(0, 535);
            this.chart2.Margin = new System.Windows.Forms.Padding(0);
            this.chart2.Name = "chart2";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsVisibleInLegend = false;
            series2.Name = "Series1";
            series2.XValueMember = "Data";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueMembers = "PreuParticipacio";
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(636, 284);
            this.chart2.TabIndex = 4;
            this.chart2.Text = "chart2";
            // 
            // ValoracionsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1464, 819);
            this.Name = "ValoracionsTab";
            this.Size = new System.Drawing.Size(1642, 819);
            this.gbData.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValoracions)).EndInit();
            this.pnEdicio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValoracionsPerData)).EndInit();
            this.gbFiltreTipusProducte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.checkedComboBoxEdit1.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.pnFiltreValoracions.ResumeLayout(false);
            this.tlpPercents.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbData;
        private System.Windows.Forms.DateTimePicker cData;
        private System.Windows.Forms.GroupBox groupBox10;
        private Controls.NumericTextBox2 tbImport;
        private System.Windows.Forms.Button btCancela;
        private System.Windows.Forms.Button btNouValor;
        private System.Windows.Forms.Button btDesa;
        private Controls.DataGridView3 dgvValoracions;
        private System.Windows.Forms.Panel pnEdicio;
        private System.Windows.Forms.Button btModifica;
        private Controls.DataGridView3 dgvValoracionsPerData;
        private System.Windows.Forms.Button btActualitzaLlista;
        private System.Windows.Forms.GroupBox gbFiltreTipusProducte;
        private System.Windows.Forms.Button btEsborra;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private GestioProductes gestioProductesTabValoracions;
        private System.Windows.Forms.Button btCopiaValorsDelPaste;
        private System.Windows.Forms.DateTimePicker dtpDataIniciLlista;
        private DevExpress.XtraEditors.CheckedComboBoxEdit checkedComboBoxEdit1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbTitolValoracionsPerData;
        private System.Windows.Forms.Panel pnFiltreValoracions;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private Controls.NumericTextBoxColumn2 colVariacioPercent;
        private Controls.NumericTextBoxColumn2 colVariacioEuros;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private Controls.NumericTextBoxColumn2 dataGridViewTextBoxColumn4;
        private Controls.NumericTextBoxColumn2 colVariacioPercentatge;
        private Controls.NumericTextBoxColumn2 colVariacioEuros2;
        private Controls.NumericTextBoxColumn2 Column1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox ckValsAmbParticipacions;
        private System.Windows.Forms.DateTimePicker dtpDataIniciValoracions;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.TableLayoutPanel tlpPercents;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbPercentAny;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel9;
        private NumericTextBox2 ntbPercent1A;
        private System.Windows.Forms.Panel panel8;
        private NumericTextBox2 ntbPercentAny;
        private System.Windows.Forms.Panel panel7;
        private NumericTextBox2 ntbPercent6M12;
        private NumericTextBox2 ntbPercent6M;
        private System.Windows.Forms.Panel panel6;
        private NumericTextBox2 ntbPercent3M12;
        private NumericTextBox2 ntbPercent3M;
        private System.Windows.Forms.Panel panel4;
        private NumericTextBox2 ntbPercent1M12;
        private NumericTextBox2 ntbPercent1M;
    }
}
