using System;

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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbData = new System.Windows.Forms.GroupBox();
            this.cData = new System.Windows.Forms.DateTimePicker();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.tbImport = new Controls.NumericTextBox2();
            this.btCancela = new System.Windows.Forms.Button();
            this.btNouValor = new System.Windows.Forms.Button();
            this.btDesa = new System.Windows.Forms.Button();
            this.cDataGridView1 = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVariacioPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colVariacioEuros = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnEdicio = new System.Windows.Forms.Panel();
            this.btModifica = new System.Windows.Forms.Button();
            this.dgvValoracionsPerData = new System.Windows.Forms.DataGridView();
            this.btActualitzaLlista = new System.Windows.Forms.Button();
            this.gbFiltreTipusProducte = new System.Windows.Forms.GroupBox();
            this.dtpDataIniciLlista = new System.Windows.Forms.DateTimePicker();
            this.cbTipusProducteFiltre = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btEsborra = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btCopiaValorsDelPaste = new System.Windows.Forms.Button();
            this.gestioProductesTabValoracions = new Inversions.GUI.GestioProductes();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbData.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cDataGridView1)).BeginInit();
            this.pnEdicio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValoracionsPerData)).BeginInit();
            this.gbFiltreTipusProducte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
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
            this.tbImport._Format = "#,##0.0### €";
            this.tbImport._PermetDecimals = true;
            this.tbImport._PermetEspais = false;
            this.tbImport._PermetNegatius = false;
            this.tbImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbImport.Enabled = false;
            this.tbImport.Location = new System.Drawing.Point(6, 25);
            this.tbImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbImport.Name = "tbImport";
            this.tbImport.Size = new System.Drawing.Size(125, 26);
            this.tbImport.TabIndex = 0;
            this.tbImport.Text = "0,0 €";
            this.tbImport.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbImport.Valor = 0D;
            // 
            // btCancela
            // 
            this.btCancela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancela.Enabled = false;
            this.btCancela.ForeColor = System.Drawing.Color.Red;
            this.btCancela.Location = new System.Drawing.Point(501, 61);
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
            this.btNouValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNouValor.Enabled = false;
            this.btNouValor.Location = new System.Drawing.Point(242, 9);
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
            this.btDesa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDesa.Enabled = false;
            this.btDesa.ForeColor = System.Drawing.Color.Green;
            this.btDesa.Location = new System.Drawing.Point(359, 61);
            this.btDesa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDesa.Name = "btDesa";
            this.btDesa.Size = new System.Drawing.Size(124, 45);
            this.btDesa.TabIndex = 5;
            this.btDesa.Text = "Desa";
            this.btDesa.UseVisualStyleBackColor = true;
            this.btDesa.Click += new System.EventHandler(this.btDesa_Click);
            // 
            // cDataGridView1
            // 
            this.cDataGridView1.AllowUserToAddRows = false;
            this.cDataGridView1.AllowUserToDeleteRows = false;
            this.cDataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.cDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colProducte,
            this.colData,
            this.NumPart,
            this.colImport,
            this.colValor,
            this.colVariacioPercent,
            this.colVariacioEuros});
            this.cDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cDataGridView1.Location = new System.Drawing.Point(3, 498);
            this.cDataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cDataGridView1.MinimumSize = new System.Drawing.Size(0, 138);
            this.cDataGridView1.Name = "cDataGridView1";
            this.cDataGridView1.ReadOnly = true;
            this.cDataGridView1.RowTemplate.Height = 24;
            this.cDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.cDataGridView1.Size = new System.Drawing.Size(974, 155);
            this.cDataGridView1.TabIndex = 5;
            this.cDataGridView1.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.cDataGridView1_RowEnter);
            // 
            // colId
            // 
            this.colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colId.DataPropertyName = "Id";
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
            this.colProducte.DataPropertyName = "Prod";
            this.colProducte.HeaderText = "Producte";
            this.colProducte.Name = "colProducte";
            this.colProducte.ReadOnly = true;
            this.colProducte.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colProducte.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colProducte.Visible = false;
            this.colProducte.Width = 79;
            // 
            // colData
            // 
            this.colData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colData.DataPropertyName = "Data";
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
            this.colImport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colImport.DataPropertyName = "PreuParticipacio";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C4";
            dataGridViewCellStyle4.NullValue = null;
            this.colImport.DefaultCellStyle = dataGridViewCellStyle4;
            this.colImport.HeaderText = "Import Part/Acc";
            this.colImport.Name = "colImport";
            this.colImport.ReadOnly = true;
            this.colImport.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colImport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colImport.Width = 125;
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
            this.colValor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colValor.Width = 121;
            // 
            // colVariacioPercent
            // 
            this.colVariacioPercent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colVariacioPercent.DataPropertyName = "_VariacioPercentatge";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "#0.00%";
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
            this.colVariacioEuros.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colVariacioEuros.DataPropertyName = "_VariacioEuros";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "#,#0.00€";
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
            this.pnEdicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnEdicio.Controls.Add(this.groupBox10);
            this.pnEdicio.Controls.Add(this.gbData);
            this.pnEdicio.Location = new System.Drawing.Point(361, 119);
            this.pnEdicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnEdicio.Name = "pnEdicio";
            this.pnEdicio.Padding = new System.Windows.Forms.Padding(3, 6, 3, 4);
            this.pnEdicio.Size = new System.Drawing.Size(290, 76);
            this.pnEdicio.TabIndex = 7;
            this.pnEdicio.Visible = false;
            // 
            // btModifica
            // 
            this.btModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btModifica.Enabled = false;
            this.btModifica.Location = new System.Drawing.Point(359, 9);
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
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Column1});
            this.dgvValoracionsPerData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvValoracionsPerData.Location = new System.Drawing.Point(980, 208);
            this.dgvValoracionsPerData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvValoracionsPerData.Name = "dgvValoracionsPerData";
            this.dgvValoracionsPerData.ReadOnly = true;
            this.dgvValoracionsPerData.RowTemplate.Height = 24;
            this.dgvValoracionsPerData.Size = new System.Drawing.Size(662, 346);
            this.dgvValoracionsPerData.TabIndex = 6;
            // 
            // btActualitzaLlista
            // 
            this.btActualitzaLlista.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btActualitzaLlista.Location = new System.Drawing.Point(6, 68);
            this.btActualitzaLlista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btActualitzaLlista.Name = "btActualitzaLlista";
            this.btActualitzaLlista.Size = new System.Drawing.Size(221, 45);
            this.btActualitzaLlista.TabIndex = 1;
            this.btActualitzaLlista.Text = "Actualitza";
            this.btActualitzaLlista.UseVisualStyleBackColor = true;
            this.btActualitzaLlista.Click += new System.EventHandler(this.btActualitzaLlista_Click);
            // 
            // gbFiltreTipusProducte
            // 
            this.gbFiltreTipusProducte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiltreTipusProducte.Controls.Add(this.dtpDataIniciLlista);
            this.gbFiltreTipusProducte.Controls.Add(this.cbTipusProducteFiltre);
            this.gbFiltreTipusProducte.Controls.Add(this.btActualitzaLlista);
            this.gbFiltreTipusProducte.Location = new System.Drawing.Point(122, 76);
            this.gbFiltreTipusProducte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFiltreTipusProducte.Name = "gbFiltreTipusProducte";
            this.gbFiltreTipusProducte.Padding = new System.Windows.Forms.Padding(6);
            this.gbFiltreTipusProducte.Size = new System.Drawing.Size(233, 119);
            this.gbFiltreTipusProducte.TabIndex = 4;
            this.gbFiltreTipusProducte.TabStop = false;
            this.gbFiltreTipusProducte.Text = "Tipus Prod.      Data Inici Llista";
            // 
            // dtpDataIniciLlista
            // 
            this.dtpDataIniciLlista.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpDataIniciLlista.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataIniciLlista.Location = new System.Drawing.Point(112, 25);
            this.dtpDataIniciLlista.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpDataIniciLlista.Name = "dtpDataIniciLlista";
            this.dtpDataIniciLlista.Size = new System.Drawing.Size(115, 26);
            this.dtpDataIniciLlista.TabIndex = 2;
            // 
            // cbTipusProducteFiltre
            // 
            this.cbTipusProducteFiltre.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbTipusProducteFiltre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipusProducteFiltre.FormattingEnabled = true;
            this.cbTipusProducteFiltre.Location = new System.Drawing.Point(6, 25);
            this.cbTipusProducteFiltre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTipusProducteFiltre.Name = "cbTipusProducteFiltre";
            this.cbTipusProducteFiltre.Size = new System.Drawing.Size(98, 28);
            this.cbTipusProducteFiltre.TabIndex = 0;
            this.cbTipusProducteFiltre.SelectedIndexChanged += new System.EventHandler(this.cbTipusProducteFiltre_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(3, 653);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.IsVisibleInLegend = false;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueMember = "Data";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValueMembers = "PreuParticipacio";
            series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(974, 162);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            // 
            // btEsborra
            // 
            this.btEsborra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEsborra.Enabled = false;
            this.btEsborra.Location = new System.Drawing.Point(501, 9);
            this.btEsborra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btEsborra.Name = "btEsborra";
            this.btEsborra.Size = new System.Drawing.Size(150, 45);
            this.btEsborra.TabIndex = 3;
            this.btEsborra.Text = "Esborra";
            this.btEsborra.UseVisualStyleBackColor = true;
            this.btEsborra.Click += new System.EventHandler(this.btEsborra_Click);
            // 
            // chart2
            // 
            chartArea2.AxisX.IsLabelAutoFit = false;
            chartArea2.AxisX.LabelStyle.Angle = 30;
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(980, 554);
            this.chart2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart2.Name = "chart2";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart2.Series.Add(series2);
            this.chart2.Size = new System.Drawing.Size(662, 265);
            this.chart2.TabIndex = 8;
            this.chart2.Text = "chart1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cDataGridView1);
            this.panel1.Controls.Add(this.gestioProductesTabValoracions);
            this.panel1.Controls.Add(this.chart1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Size = new System.Drawing.Size(980, 819);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btCopiaValorsDelPaste);
            this.panel2.Controls.Add(this.btModifica);
            this.panel2.Controls.Add(this.btDesa);
            this.panel2.Controls.Add(this.btNouValor);
            this.panel2.Controls.Add(this.gbFiltreTipusProducte);
            this.panel2.Controls.Add(this.btEsborra);
            this.panel2.Controls.Add(this.btCancela);
            this.panel2.Controls.Add(this.pnEdicio);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(980, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(662, 208);
            this.panel2.TabIndex = 0;
            // 
            // btCopiaValorsDelPaste
            // 
            this.btCopiaValorsDelPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCopiaValorsDelPaste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btCopiaValorsDelPaste.Location = new System.Drawing.Point(122, 5);
            this.btCopiaValorsDelPaste.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btCopiaValorsDelPaste.Name = "btCopiaValorsDelPaste";
            this.btCopiaValorsDelPaste.Size = new System.Drawing.Size(114, 54);
            this.btCopiaValorsDelPaste.TabIndex = 0;
            this.btCopiaValorsDelPaste.Text = "Còpia des d\'un Paste";
            this.btCopiaValorsDelPaste.UseVisualStyleBackColor = false;
            this.btCopiaValorsDelPaste.Click += new System.EventHandler(this.btCopiaValorsDelPaste_Click);
            // 
            // gestioProductesTabValoracions
            // 
            this.gestioProductesTabValoracions._AmbMoviments = true;
            this.gestioProductesTabValoracions._FiltreAnyVisible = false;
            this.gestioProductesTabValoracions._MostraLlistaAmbChecks = false;
            this.gestioProductesTabValoracions._NomesAmbParticipacions = true;
            this.gestioProductesTabValoracions.Dock = System.Windows.Forms.DockStyle.Top;
            this.gestioProductesTabValoracions.Location = new System.Drawing.Point(3, 4);
            this.gestioProductesTabValoracions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gestioProductesTabValoracions.MinimumSize = new System.Drawing.Size(825, 494);
            this.gestioProductesTabValoracions.Name = "gestioProductesTabValoracions";
            this.gestioProductesTabValoracions.Size = new System.Drawing.Size(974, 494);
            this.gestioProductesTabValoracions.TabIndex = 9;
            this.gestioProductesTabValoracions.ProducteSeleccionat += new System.EventHandler(this.gestioProductesTabValoracions_ProducteSeleccionat);
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "_Data";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "d";
            dataGridViewCellStyle9.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn3.HeaderText = "Data";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.Width = 80;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "_Import";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "C3";
            dataGridViewCellStyle10.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn4.HeaderText = "PiG";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.Width = 71;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "_VariacioPercentatge";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle11.Format = "#0.00%";
            dataGridViewCellStyle11.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn5.HeaderText = "Variació %";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.Width = 120;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "_VariacioEuros";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle12.Format = "#,#0.00€";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridViewTextBoxColumn6.HeaderText = "Variació €";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.Width = 115;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle13.Format = "#,#0.00€";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle13;
            this.Column1.HeaderText = "Valor total";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.Width = 117;
            // 
            // ValoracionsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvValoracionsPerData);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1464, 819);
            this.Name = "ValoracionsTab";
            this.Size = new System.Drawing.Size(1642, 819);
            this.gbData.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cDataGridView1)).EndInit();
            this.pnEdicio.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvValoracionsPerData)).EndInit();
            this.gbFiltreTipusProducte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
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
        private System.Windows.Forms.DataGridView cDataGridView1;
        private System.Windows.Forms.Panel pnEdicio;
        private System.Windows.Forms.Button btModifica;
        private System.Windows.Forms.DataGridView dgvValoracionsPerData;
        private System.Windows.Forms.Button btActualitzaLlista;
        private System.Windows.Forms.GroupBox gbFiltreTipusProducte;
        private System.Windows.Forms.ComboBox cbTipusProducteFiltre;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button btEsborra;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private GestioProductes gestioProductesTabValoracions;
        private System.Windows.Forms.Button btCopiaValorsDelPaste;
        private System.Windows.Forms.DateTimePicker dtpDataIniciLlista;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariacioPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colVariacioEuros;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}
