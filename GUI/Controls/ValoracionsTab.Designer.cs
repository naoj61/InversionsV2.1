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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
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
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btActualitzaLlista = new System.Windows.Forms.Button();
            this.gbFiltreTipusProducte = new System.Windows.Forms.GroupBox();
            this.cbTipusProducteFiltre = new System.Windows.Forms.ComboBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btEsborra = new System.Windows.Forms.Button();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gestioProductesTabValoracions = new Inversions.GUI.GestioProductes();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btCopiaValorsDelPaste = new System.Windows.Forms.Button();
            this.dtpDataIniciLlista = new System.Windows.Forms.DateTimePicker();
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
            this.gbData.Location = new System.Drawing.Point(3, 5);
            this.gbData.Name = "gbData";
            this.gbData.Padding = new System.Windows.Forms.Padding(5);
            this.gbData.Size = new System.Drawing.Size(131, 53);
            this.gbData.TabIndex = 0;
            this.gbData.TabStop = false;
            this.gbData.Text = "Data";
            // 
            // cData
            // 
            this.cData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cData.Enabled = false;
            this.cData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cData.Location = new System.Drawing.Point(5, 20);
            this.cData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cData.Name = "cData";
            this.cData.Size = new System.Drawing.Size(121, 22);
            this.cData.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tbImport);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox10.Location = new System.Drawing.Point(134, 5);
            this.groupBox10.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox10.Size = new System.Drawing.Size(121, 53);
            this.groupBox10.TabIndex = 1;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Import";
            // 
            // tbImport
            // 
            this.tbImport._Format = "#,##0.0### €";
            this.tbImport._PermetDecimals = true;
            this.tbImport._PermetEspais = false;
            this.tbImport._PermetNegatius = false;
            this.tbImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbImport.Enabled = false;
            this.tbImport.Location = new System.Drawing.Point(5, 20);
            this.tbImport.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbImport.Name = "tbImport";
            this.tbImport.Size = new System.Drawing.Size(111, 22);
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
            this.btCancela.Location = new System.Drawing.Point(446, 49);
            this.btCancela.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btCancela.Name = "btCancela";
            this.btCancela.Size = new System.Drawing.Size(133, 36);
            this.btCancela.TabIndex = 6;
            this.btCancela.Text = "Cancela";
            this.btCancela.UseVisualStyleBackColor = true;
            this.btCancela.Click += new System.EventHandler(this.btCancela_Click);
            // 
            // btNouValor
            // 
            this.btNouValor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNouValor.Enabled = false;
            this.btNouValor.Location = new System.Drawing.Point(216, 7);
            this.btNouValor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btNouValor.Name = "btNouValor";
            this.btNouValor.Size = new System.Drawing.Size(98, 36);
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
            this.btDesa.Location = new System.Drawing.Point(320, 49);
            this.btDesa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btDesa.Name = "btDesa";
            this.btDesa.Size = new System.Drawing.Size(110, 36);
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
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle14;
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
            this.cDataGridView1.Location = new System.Drawing.Point(0, 395);
            this.cDataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cDataGridView1.MinimumSize = new System.Drawing.Size(0, 110);
            this.cDataGridView1.Name = "cDataGridView1";
            this.cDataGridView1.ReadOnly = true;
            this.cDataGridView1.RowTemplate.Height = 24;
            this.cDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.cDataGridView1.Size = new System.Drawing.Size(871, 130);
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
            this.colId.Width = 25;
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
            // 
            // colData
            // 
            this.colData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colData.DataPropertyName = "Data";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Format = "d";
            dataGridViewCellStyle15.NullValue = null;
            this.colData.DefaultCellStyle = dataGridViewCellStyle15;
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colData.Width = 44;
            // 
            // NumPart
            // 
            this.NumPart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.NumPart.DataPropertyName = "_NumParticipacions";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.NumPart.DefaultCellStyle = dataGridViewCellStyle16;
            this.NumPart.HeaderText = "Num. Part.";
            this.NumPart.Name = "NumPart";
            this.NumPart.ReadOnly = true;
            this.NumPart.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.NumPart.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NumPart.Width = 73;
            // 
            // colImport
            // 
            this.colImport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colImport.DataPropertyName = "PreuParticipacio";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "C4";
            dataGridViewCellStyle17.NullValue = null;
            this.colImport.DefaultCellStyle = dataGridViewCellStyle17;
            this.colImport.HeaderText = "Import Part/Acc";
            this.colImport.Name = "colImport";
            this.colImport.ReadOnly = true;
            this.colImport.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colImport.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colImport.Width = 99;
            // 
            // colValor
            // 
            this.colValor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colValor.DataPropertyName = "_ValoracioTotal";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "C2";
            dataGridViewCellStyle18.NullValue = null;
            this.colValor.DefaultCellStyle = dataGridViewCellStyle18;
            this.colValor.HeaderText = "Valor Total";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colValor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.colValor.Width = 98;
            // 
            // colVariacioPercent
            // 
            this.colVariacioPercent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colVariacioPercent.DataPropertyName = "_VariacioPercentatge";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.Format = "#0.00%";
            dataGridViewCellStyle19.NullValue = null;
            this.colVariacioPercent.DefaultCellStyle = dataGridViewCellStyle19;
            this.colVariacioPercent.HeaderText = "Variació %";
            this.colVariacioPercent.Name = "colVariacioPercent";
            this.colVariacioPercent.ReadOnly = true;
            this.colVariacioPercent.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colVariacioPercent.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colVariacioPercent.Width = 73;
            // 
            // colVariacioEuros
            // 
            this.colVariacioEuros.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colVariacioEuros.DataPropertyName = "_VariacioEuros";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "#,#0.00€";
            this.colVariacioEuros.DefaultCellStyle = dataGridViewCellStyle20;
            this.colVariacioEuros.HeaderText = "Variació €";
            this.colVariacioEuros.Name = "colVariacioEuros";
            this.colVariacioEuros.ReadOnly = true;
            this.colVariacioEuros.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colVariacioEuros.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colVariacioEuros.Width = 69;
            // 
            // pnEdicio
            // 
            this.pnEdicio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnEdicio.Controls.Add(this.groupBox10);
            this.pnEdicio.Controls.Add(this.gbData);
            this.pnEdicio.Location = new System.Drawing.Point(322, 95);
            this.pnEdicio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnEdicio.Name = "pnEdicio";
            this.pnEdicio.Padding = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.pnEdicio.Size = new System.Drawing.Size(258, 61);
            this.pnEdicio.TabIndex = 7;
            this.pnEdicio.Visible = false;
            // 
            // btModifica
            // 
            this.btModifica.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btModifica.Enabled = false;
            this.btModifica.Location = new System.Drawing.Point(320, 7);
            this.btModifica.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btModifica.Name = "btModifica";
            this.btModifica.Size = new System.Drawing.Size(110, 36);
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
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValoracionsPerData.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvValoracionsPerData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValoracionsPerData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.Column1});
            this.dgvValoracionsPerData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvValoracionsPerData.Location = new System.Drawing.Point(871, 166);
            this.dgvValoracionsPerData.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvValoracionsPerData.MultiSelect = false;
            this.dgvValoracionsPerData.Name = "dgvValoracionsPerData";
            this.dgvValoracionsPerData.ReadOnly = true;
            this.dgvValoracionsPerData.RowTemplate.Height = 24;
            this.dgvValoracionsPerData.Size = new System.Drawing.Size(589, 277);
            this.dgvValoracionsPerData.TabIndex = 6;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "_Data";
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.Format = "d";
            dataGridViewCellStyle22.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle22;
            this.dataGridViewTextBoxColumn3.HeaderText = "Data";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 44;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "_Import";
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle23.Format = "C3";
            dataGridViewCellStyle23.NullValue = null;
            this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle23;
            this.dataGridViewTextBoxColumn4.HeaderText = "PiG";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn4.Width = 37;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "_VariacioPercentatge";
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle24.Format = "#0.00%";
            dataGridViewCellStyle24.NullValue = null;
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle24;
            this.dataGridViewTextBoxColumn5.HeaderText = "Variació %";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn5.Width = 81;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "_VariacioEuros";
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle25.Format = "#,#0.00€";
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridViewTextBoxColumn6.HeaderText = "Variació €";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn6.Width = 77;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle26.Format = "#,#0.00€";
            this.Column1.DefaultCellStyle = dataGridViewCellStyle26;
            this.Column1.HeaderText = "Valor total";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 78;
            // 
            // btActualitzaLlista
            // 
            this.btActualitzaLlista.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btActualitzaLlista.Location = new System.Drawing.Point(5, 54);
            this.btActualitzaLlista.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btActualitzaLlista.Name = "btActualitzaLlista";
            this.btActualitzaLlista.Size = new System.Drawing.Size(197, 36);
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
            this.gbFiltreTipusProducte.Location = new System.Drawing.Point(109, 61);
            this.gbFiltreTipusProducte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbFiltreTipusProducte.Name = "gbFiltreTipusProducte";
            this.gbFiltreTipusProducte.Padding = new System.Windows.Forms.Padding(5);
            this.gbFiltreTipusProducte.Size = new System.Drawing.Size(207, 95);
            this.gbFiltreTipusProducte.TabIndex = 4;
            this.gbFiltreTipusProducte.TabStop = false;
            this.gbFiltreTipusProducte.Text = "Tipus Prod.      Data Inici Llista";
            // 
            // cbTipusProducteFiltre
            // 
            this.cbTipusProducteFiltre.Dock = System.Windows.Forms.DockStyle.Left;
            this.cbTipusProducteFiltre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipusProducteFiltre.FormattingEnabled = true;
            this.cbTipusProducteFiltre.Location = new System.Drawing.Point(5, 20);
            this.cbTipusProducteFiltre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbTipusProducteFiltre.Name = "cbTipusProducteFiltre";
            this.cbTipusProducteFiltre.Size = new System.Drawing.Size(88, 24);
            this.cbTipusProducteFiltre.TabIndex = 0;
            this.cbTipusProducteFiltre.SelectedIndexChanged += new System.EventHandler(this.cbTipusProducteFiltre_SelectedIndexChanged);
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(0, 525);
            this.chart1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart1.Name = "chart1";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.IsVisibleInLegend = false;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            series3.XValueMember = "Data";
            series3.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series3.YValueMembers = "PreuParticipacio";
            series3.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(871, 130);
            this.chart1.TabIndex = 8;
            this.chart1.Text = "chart1";
            // 
            // btEsborra
            // 
            this.btEsborra.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEsborra.Enabled = false;
            this.btEsborra.Location = new System.Drawing.Point(446, 7);
            this.btEsborra.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btEsborra.Name = "btEsborra";
            this.btEsborra.Size = new System.Drawing.Size(133, 36);
            this.btEsborra.TabIndex = 3;
            this.btEsborra.Text = "Esborra";
            this.btEsborra.UseVisualStyleBackColor = true;
            this.btEsborra.Click += new System.EventHandler(this.btEsborra_Click);
            // 
            // chart2
            // 
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.LabelStyle.Angle = 30;
            chartArea4.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea4);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Bottom;
            legend4.Name = "Legend1";
            this.chart2.Legends.Add(legend4);
            this.chart2.Location = new System.Drawing.Point(871, 443);
            this.chart2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.chart2.Name = "chart2";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series4.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Double;
            this.chart2.Series.Add(series4);
            this.chart2.Size = new System.Drawing.Size(589, 212);
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
            this.panel1.Size = new System.Drawing.Size(871, 655);
            this.panel1.TabIndex = 9;
            // 
            // gestioProductesTabValoracions
            // 
            this.gestioProductesTabValoracions._FiltreAnyVisible = false;
            this.gestioProductesTabValoracions._NomesAmbParticipacions = true;
            this.gestioProductesTabValoracions._ProducteSeleccionat = null;
            this.gestioProductesTabValoracions.Dock = System.Windows.Forms.DockStyle.Top;
            this.gestioProductesTabValoracions.Location = new System.Drawing.Point(0, 0);
            this.gestioProductesTabValoracions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gestioProductesTabValoracions.MinimumSize = new System.Drawing.Size(733, 395);
            this.gestioProductesTabValoracions.Name = "gestioProductesTabValoracions";
            this.gestioProductesTabValoracions.Size = new System.Drawing.Size(871, 395);
            this.gestioProductesTabValoracions.TabIndex = 9;
            this.gestioProductesTabValoracions.ProducteSeleccionat += new System.EventHandler(this.gestioProductesTabValoracions_ProducteSeleccionat);
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
            this.panel2.Location = new System.Drawing.Point(871, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(589, 166);
            this.panel2.TabIndex = 0;
            // 
            // btCopiaValorsDelPaste
            // 
            this.btCopiaValorsDelPaste.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCopiaValorsDelPaste.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btCopiaValorsDelPaste.Location = new System.Drawing.Point(109, 4);
            this.btCopiaValorsDelPaste.Name = "btCopiaValorsDelPaste";
            this.btCopiaValorsDelPaste.Size = new System.Drawing.Size(101, 43);
            this.btCopiaValorsDelPaste.TabIndex = 0;
            this.btCopiaValorsDelPaste.Text = "Còpia des d\'un Paste";
            this.btCopiaValorsDelPaste.UseVisualStyleBackColor = false;
            this.btCopiaValorsDelPaste.Click += new System.EventHandler(this.btCopiaValorsDelPaste_Click);
            // 
            // dtpDataIniciLlista
            // 
            this.dtpDataIniciLlista.Dock = System.Windows.Forms.DockStyle.Right;
            this.dtpDataIniciLlista.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataIniciLlista.Location = new System.Drawing.Point(99, 20);
            this.dtpDataIniciLlista.Name = "dtpDataIniciLlista";
            this.dtpDataIniciLlista.Size = new System.Drawing.Size(103, 22);
            this.dtpDataIniciLlista.TabIndex = 2;
            // 
            // ValoracionsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvValoracionsPerData);
            this.Controls.Add(this.chart2);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1301, 655);
            this.Name = "ValoracionsTab";
            this.Size = new System.Drawing.Size(1460, 655);
            this.Load += new System.EventHandler(this.ValoracionsTab_Load);
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
        private System.Windows.Forms.Button btCopiaValorsDelPaste;
        private System.Windows.Forms.DateTimePicker dtpDataIniciLlista;
    }
}
