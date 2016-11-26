namespace Inversions.GUI
{
    partial class MovimentsTab
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cDataGridView1 = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipusMoviment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParticipacions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPreuUnitari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDespeses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTraspasOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTraspasDesti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btDesaMoviment = new System.Windows.Forms.Button();
            this.btCompra = new System.Windows.Forms.Button();
            this.btVenda = new System.Windows.Forms.Button();
            this.btDividends = new System.Windows.Forms.Button();
            this.btCancelaMoviment = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.cTipusMovimentTab2 = new System.Windows.Forms.ComboBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cData1 = new System.Windows.Forms.DateTimePicker();
            this.gbParticipacions = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.gbDespeses = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbDescripcio = new System.Windows.Forms.GroupBox();
            this.tbDescripcio = new System.Windows.Forms.TextBox();
            this.gbEdicio = new System.Windows.Forms.GroupBox();
            this.gbNumParticipacionsDesti = new System.Windows.Forms.GroupBox();
            this.gbDataDesti = new System.Windows.Forms.GroupBox();
            this.cDataDesti = new System.Windows.Forms.DateTimePicker();
            this.gbProducteTraspas = new System.Windows.Forms.GroupBox();
            this.cProducteTraspas = new System.Windows.Forms.ComboBox();
            this.gbTraspas = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbNumParticipacionsDesti = new Controls.NumericTextBox2();
            this.tbImportTotal = new Controls.NumericTextBox2();
            this.tbDespeses = new Controls.NumericTextBox2();
            this.tbPreuParticipacio = new Controls.NumericTextBox2();
            this.tbNumParticipacions = new Controls.NumericTextBox2();
            this.gestioProductesTabMoviments = new Inversions.GUI.GestioProductes();
            ((System.ComponentModel.ISupportInitialize)(this.cDataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.gbParticipacions.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.gbDespeses.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbDescripcio.SuspendLayout();
            this.gbEdicio.SuspendLayout();
            this.gbNumParticipacionsDesti.SuspendLayout();
            this.gbDataDesti.SuspendLayout();
            this.gbProducteTraspas.SuspendLayout();
            this.gbTraspas.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // cDataGridView1
            // 
            this.cDataGridView1.AllowUserToAddRows = false;
            this.cDataGridView1.AllowUserToDeleteRows = false;
            this.cDataGridView1.AllowUserToOrderColumns = true;
            this.cDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colProducte,
            this.colTipusMoviment,
            this.colData,
            this.colParticipacions,
            this.colPreuUnitari,
            this.colImport,
            this.colDespeses,
            this.colTraspasOrigen,
            this.colTraspasDesti,
            this.colDescripcio});
            this.cDataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.cDataGridView1.Location = new System.Drawing.Point(0, 410);
            this.cDataGridView1.Name = "cDataGridView1";
            this.cDataGridView1.ReadOnly = true;
            this.cDataGridView1.RowTemplate.Height = 24;
            this.cDataGridView1.Size = new System.Drawing.Size(1585, 189);
            this.cDataGridView1.TabIndex = 0;
            this.toolTip1.SetToolTip(this.cDataGridView1, "nhjfghj");
            this.cDataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.cDataGridView1_CellMouseDoubleClick);
            // 
            // colId
            // 
            this.colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colId.DataPropertyName = "Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colId.Width = 48;
            // 
            // colProducte
            // 
            this.colProducte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProducte.DataPropertyName = "Prod";
            this.colProducte.HeaderText = "Producte";
            this.colProducte.Name = "colProducte";
            this.colProducte.ReadOnly = true;
            this.colProducte.Width = 94;
            // 
            // colTipusMoviment
            // 
            this.colTipusMoviment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTipusMoviment.DataPropertyName = "_TipusMoviment";
            this.colTipusMoviment.HeaderText = "Tipus moviment";
            this.colTipusMoviment.Name = "colTipusMoviment";
            this.colTipusMoviment.ReadOnly = true;
            this.colTipusMoviment.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colTipusMoviment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colTipusMoviment.Width = 102;
            // 
            // colData
            // 
            this.colData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colData.DataPropertyName = "Data";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.colData.DefaultCellStyle = dataGridViewCellStyle1;
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 67;
            // 
            // colParticipacions
            // 
            this.colParticipacions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colParticipacions.DataPropertyName = "Participacions";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N4";
            dataGridViewCellStyle2.NullValue = null;
            this.colParticipacions.DefaultCellStyle = dataGridViewCellStyle2;
            this.colParticipacions.HeaderText = "Participacions";
            this.colParticipacions.Name = "colParticipacions";
            this.colParticipacions.ReadOnly = true;
            this.colParticipacions.Width = 125;
            // 
            // colPreuUnitari
            // 
            this.colPreuUnitari.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPreuUnitari.DataPropertyName = "_PreuParticipacio";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "c3";
            this.colPreuUnitari.DefaultCellStyle = dataGridViewCellStyle3;
            this.colPreuUnitari.HeaderText = "Preu Unitari";
            this.colPreuUnitari.Name = "colPreuUnitari";
            this.colPreuUnitari.ReadOnly = true;
            this.colPreuUnitari.Width = 103;
            // 
            // colImport
            // 
            this.colImport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colImport.DataPropertyName = "Import";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.colImport.DefaultCellStyle = dataGridViewCellStyle4;
            this.colImport.HeaderText = "Import";
            this.colImport.Name = "colImport";
            this.colImport.ReadOnly = true;
            this.colImport.Width = 76;
            // 
            // colDespeses
            // 
            this.colDespeses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDespeses.DataPropertyName = "Despeses";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "c2";
            this.colDespeses.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDespeses.HeaderText = "Despeses";
            this.colDespeses.Name = "colDespeses";
            this.colDespeses.ReadOnly = true;
            // 
            // colTraspasOrigen
            // 
            this.colTraspasOrigen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTraspasOrigen.DataPropertyName = "_ProducteTraspasOrigen";
            this.colTraspasOrigen.HeaderText = "Traspassat de:";
            this.colTraspasOrigen.MinimumWidth = 130;
            this.colTraspasOrigen.Name = "colTraspasOrigen";
            this.colTraspasOrigen.ReadOnly = true;
            this.colTraspasOrigen.Width = 130;
            // 
            // colTraspasDesti
            // 
            this.colTraspasDesti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTraspasDesti.DataPropertyName = "_ProducteTraspasDesti";
            this.colTraspasDesti.HeaderText = "Traspassat a:";
            this.colTraspasDesti.MinimumWidth = 130;
            this.colTraspasDesti.Name = "colTraspasDesti";
            this.colTraspasDesti.ReadOnly = true;
            this.colTraspasDesti.Width = 130;
            // 
            // colDescripcio
            // 
            this.colDescripcio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDescripcio.DataPropertyName = "Descripcio";
            this.colDescripcio.HeaderText = "Descripció";
            this.colDescripcio.Name = "colDescripcio";
            this.colDescripcio.ReadOnly = true;
            this.colDescripcio.Width = 103;
            // 
            // btDesaMoviment
            // 
            this.btDesaMoviment.Enabled = false;
            this.btDesaMoviment.Location = new System.Drawing.Point(352, 13);
            this.btDesaMoviment.Name = "btDesaMoviment";
            this.btDesaMoviment.Size = new System.Drawing.Size(101, 50);
            this.btDesaMoviment.TabIndex = 5;
            this.btDesaMoviment.Text = "Desa";
            this.btDesaMoviment.UseVisualStyleBackColor = true;
            this.btDesaMoviment.Click += new System.EventHandler(this.btDesaMoviment_Click);
            // 
            // btCompra
            // 
            this.btCompra.Enabled = false;
            this.btCompra.Location = new System.Drawing.Point(16, 13);
            this.btCompra.Name = "btCompra";
            this.btCompra.Size = new System.Drawing.Size(101, 50);
            this.btCompra.TabIndex = 2;
            this.btCompra.Text = "Compra";
            this.btCompra.UseVisualStyleBackColor = true;
            this.btCompra.Click += new System.EventHandler(this.btCompra_Click);
            // 
            // btVenda
            // 
            this.btVenda.Enabled = false;
            this.btVenda.Location = new System.Drawing.Point(128, 13);
            this.btVenda.Name = "btVenda";
            this.btVenda.Size = new System.Drawing.Size(101, 50);
            this.btVenda.TabIndex = 3;
            this.btVenda.Text = "Venda";
            this.btVenda.UseVisualStyleBackColor = true;
            this.btVenda.Click += new System.EventHandler(this.btVenda_Click);
            // 
            // btDividends
            // 
            this.btDividends.Enabled = false;
            this.btDividends.Location = new System.Drawing.Point(240, 13);
            this.btDividends.Name = "btDividends";
            this.btDividends.Size = new System.Drawing.Size(101, 50);
            this.btDividends.TabIndex = 4;
            this.btDividends.Text = "Dividends";
            this.btDividends.UseVisualStyleBackColor = true;
            this.btDividends.Click += new System.EventHandler(this.btDividends_Click);
            // 
            // btCancelaMoviment
            // 
            this.btCancelaMoviment.Enabled = false;
            this.btCancelaMoviment.Location = new System.Drawing.Point(464, 13);
            this.btCancelaMoviment.Name = "btCancelaMoviment";
            this.btCancelaMoviment.Size = new System.Drawing.Size(101, 50);
            this.btCancelaMoviment.TabIndex = 6;
            this.btCancelaMoviment.Text = "Cancela";
            this.btCancelaMoviment.UseVisualStyleBackColor = true;
            this.btCancelaMoviment.Click += new System.EventHandler(this.btCancelaMoviment_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 18);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.panel1.Size = new System.Drawing.Size(545, 105);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gbDespeses);
            this.panel2.Controls.Add(this.groupBox10);
            this.panel2.Controls.Add(this.gbParticipacions);
            this.panel2.Controls.Add(this.groupBox8);
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(545, 50);
            this.panel2.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.cTipusMovimentTab2);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox7.Location = new System.Drawing.Point(0, 0);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox7.Size = new System.Drawing.Size(132, 50);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tipus Moviment";
            // 
            // cTipusMovimentTab2
            // 
            this.cTipusMovimentTab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cTipusMovimentTab2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cTipusMovimentTab2.Enabled = false;
            this.cTipusMovimentTab2.FormattingEnabled = true;
            this.cTipusMovimentTab2.Location = new System.Drawing.Point(5, 20);
            this.cTipusMovimentTab2.Name = "cTipusMovimentTab2";
            this.cTipusMovimentTab2.Size = new System.Drawing.Size(122, 24);
            this.cTipusMovimentTab2.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cData1);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox8.Location = new System.Drawing.Point(132, 0);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox8.Size = new System.Drawing.Size(105, 50);
            this.groupBox8.TabIndex = 1;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Data";
            // 
            // cData1
            // 
            this.cData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cData1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cData1.Location = new System.Drawing.Point(5, 20);
            this.cData1.Name = "cData1";
            this.cData1.Size = new System.Drawing.Size(95, 22);
            this.cData1.TabIndex = 0;
            // 
            // gbParticipacions
            // 
            this.gbParticipacions.Controls.Add(this.tbNumParticipacions);
            this.gbParticipacions.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbParticipacions.Location = new System.Drawing.Point(237, 0);
            this.gbParticipacions.Name = "gbParticipacions";
            this.gbParticipacions.Padding = new System.Windows.Forms.Padding(5);
            this.gbParticipacions.Size = new System.Drawing.Size(111, 50);
            this.gbParticipacions.TabIndex = 2;
            this.gbParticipacions.TabStop = false;
            this.gbParticipacions.Text = "Participacions";
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.tbPreuParticipacio);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox10.Location = new System.Drawing.Point(348, 0);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox10.Size = new System.Drawing.Size(98, 50);
            this.groupBox10.TabIndex = 3;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Preu Partic.";
            this.toolTip1.SetToolTip(this.groupBox10, "Import brut sense despeses");
            // 
            // gbDespeses
            // 
            this.gbDespeses.Controls.Add(this.tbDespeses);
            this.gbDespeses.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbDespeses.Location = new System.Drawing.Point(446, 0);
            this.gbDespeses.Name = "gbDespeses";
            this.gbDespeses.Padding = new System.Windows.Forms.Padding(5);
            this.gbDespeses.Size = new System.Drawing.Size(96, 50);
            this.gbDespeses.TabIndex = 4;
            this.gbDespeses.TabStop = false;
            this.gbDespeses.Text = "Despeses";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbImportTotal);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(96, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Imp. Total";
            // 
            // gbDescripcio
            // 
            this.gbDescripcio.Controls.Add(this.tbDescripcio);
            this.gbDescripcio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDescripcio.Location = new System.Drawing.Point(3, 123);
            this.gbDescripcio.Name = "gbDescripcio";
            this.gbDescripcio.Size = new System.Drawing.Size(545, 96);
            this.gbDescripcio.TabIndex = 0;
            this.gbDescripcio.TabStop = false;
            this.gbDescripcio.Text = "Descripció";
            // 
            // tbDescripcio
            // 
            this.tbDescripcio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescripcio.Location = new System.Drawing.Point(3, 18);
            this.tbDescripcio.Multiline = true;
            this.tbDescripcio.Name = "tbDescripcio";
            this.tbDescripcio.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbDescripcio.Size = new System.Drawing.Size(539, 75);
            this.tbDescripcio.TabIndex = 0;
            // 
            // gbEdicio
            // 
            this.gbEdicio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbEdicio.Controls.Add(this.gbDescripcio);
            this.gbEdicio.Controls.Add(this.panel1);
            this.gbEdicio.Location = new System.Drawing.Point(16, 84);
            this.gbEdicio.Name = "gbEdicio";
            this.gbEdicio.Size = new System.Drawing.Size(551, 222);
            this.gbEdicio.TabIndex = 7;
            this.gbEdicio.TabStop = false;
            this.gbEdicio.Visible = false;
            // 
            // gbNumParticipacionsDesti
            // 
            this.gbNumParticipacionsDesti.Controls.Add(this.tbNumParticipacionsDesti);
            this.gbNumParticipacionsDesti.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbNumParticipacionsDesti.Location = new System.Drawing.Point(434, 18);
            this.gbNumParticipacionsDesti.Name = "gbNumParticipacionsDesti";
            this.gbNumParticipacionsDesti.Padding = new System.Windows.Forms.Padding(5);
            this.gbNumParticipacionsDesti.Size = new System.Drawing.Size(114, 57);
            this.gbNumParticipacionsDesti.TabIndex = 2;
            this.gbNumParticipacionsDesti.TabStop = false;
            this.gbNumParticipacionsDesti.Text = "Participacions";
            // 
            // gbDataDesti
            // 
            this.gbDataDesti.Controls.Add(this.cDataDesti);
            this.gbDataDesti.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbDataDesti.Location = new System.Drawing.Point(323, 18);
            this.gbDataDesti.Name = "gbDataDesti";
            this.gbDataDesti.Padding = new System.Windows.Forms.Padding(5);
            this.gbDataDesti.Size = new System.Drawing.Size(111, 57);
            this.gbDataDesti.TabIndex = 1;
            this.gbDataDesti.TabStop = false;
            this.gbDataDesti.Text = "Data";
            // 
            // cDataDesti
            // 
            this.cDataDesti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cDataDesti.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cDataDesti.Location = new System.Drawing.Point(5, 20);
            this.cDataDesti.Name = "cDataDesti";
            this.cDataDesti.Size = new System.Drawing.Size(101, 22);
            this.cDataDesti.TabIndex = 0;
            // 
            // gbProducteTraspas
            // 
            this.gbProducteTraspas.Controls.Add(this.cProducteTraspas);
            this.gbProducteTraspas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbProducteTraspas.Location = new System.Drawing.Point(3, 18);
            this.gbProducteTraspas.Name = "gbProducteTraspas";
            this.gbProducteTraspas.Padding = new System.Windows.Forms.Padding(5);
            this.gbProducteTraspas.Size = new System.Drawing.Size(320, 57);
            this.gbProducteTraspas.TabIndex = 0;
            this.gbProducteTraspas.TabStop = false;
            this.gbProducteTraspas.Text = "Producte Destí";
            // 
            // cProducteTraspas
            // 
            this.cProducteTraspas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cProducteTraspas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cProducteTraspas.FormattingEnabled = true;
            this.cProducteTraspas.Location = new System.Drawing.Point(5, 20);
            this.cProducteTraspas.Name = "cProducteTraspas";
            this.cProducteTraspas.Size = new System.Drawing.Size(310, 24);
            this.cProducteTraspas.TabIndex = 0;
            this.cProducteTraspas.SelectedIndexChanged += new System.EventHandler(this.cProducteTraspas_SelectedIndexChanged);
            // 
            // gbTraspas
            // 
            this.gbTraspas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbTraspas.Controls.Add(this.gbProducteTraspas);
            this.gbTraspas.Controls.Add(this.gbDataDesti);
            this.gbTraspas.Controls.Add(this.gbNumParticipacionsDesti);
            this.gbTraspas.Location = new System.Drawing.Point(16, 312);
            this.gbTraspas.Name = "gbTraspas";
            this.gbTraspas.Size = new System.Drawing.Size(551, 78);
            this.gbTraspas.TabIndex = 8;
            this.gbTraspas.TabStop = false;
            this.gbTraspas.Text = "Traspàs";
            this.gbTraspas.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btCompra);
            this.panel3.Controls.Add(this.gbTraspas);
            this.panel3.Controls.Add(this.btDesaMoviment);
            this.panel3.Controls.Add(this.gbEdicio);
            this.panel3.Controls.Add(this.btVenda);
            this.panel3.Controls.Add(this.btCancelaMoviment);
            this.panel3.Controls.Add(this.btDividends);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(1013, 0);
            this.panel3.MinimumSize = new System.Drawing.Size(572, 410);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(572, 410);
            this.panel3.TabIndex = 9;
            // 
            // tbNumParticipacionsDesti
            // 
            this.tbNumParticipacionsDesti._Format = "#,##0.####";
            this.tbNumParticipacionsDesti._PermetDecimals = true;
            this.tbNumParticipacionsDesti._PermetEspais = false;
            this.tbNumParticipacionsDesti._PermetNegatius = false;
            this.tbNumParticipacionsDesti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNumParticipacionsDesti.Location = new System.Drawing.Point(5, 20);
            this.tbNumParticipacionsDesti.Name = "tbNumParticipacionsDesti";
            this.tbNumParticipacionsDesti.Size = new System.Drawing.Size(104, 22);
            this.tbNumParticipacionsDesti.TabIndex = 0;
            this.tbNumParticipacionsDesti.Text = "0";
            this.tbNumParticipacionsDesti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbNumParticipacionsDesti.Valor = 0D;
            // 
            // tbImportTotal
            // 
            this.tbImportTotal._Format = "#,##0.### €";
            this.tbImportTotal._PermetDecimals = true;
            this.tbImportTotal._PermetEspais = false;
            this.tbImportTotal._PermetNegatius = false;
            this.tbImportTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbImportTotal.Location = new System.Drawing.Point(5, 20);
            this.tbImportTotal.Name = "tbImportTotal";
            this.tbImportTotal.ReadOnly = true;
            this.tbImportTotal.Size = new System.Drawing.Size(86, 22);
            this.tbImportTotal.TabIndex = 0;
            this.tbImportTotal.Text = "0 €";
            this.tbImportTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbImportTotal.Valor = 0D;
            // 
            // tbDespeses
            // 
            this.tbDespeses._Format = "#,##0.### €";
            this.tbDespeses._PermetDecimals = true;
            this.tbDespeses._PermetEspais = false;
            this.tbDespeses._PermetNegatius = false;
            this.tbDespeses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDespeses.Location = new System.Drawing.Point(5, 20);
            this.tbDespeses.Name = "tbDespeses";
            this.tbDespeses.Size = new System.Drawing.Size(86, 22);
            this.tbDespeses.TabIndex = 0;
            this.tbDespeses.Text = "0 €";
            this.tbDespeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDespeses.Valor = 0D;
            this.tbDespeses.Leave += new System.EventHandler(this.tbDespeses_Leave);
            // 
            // tbPreuParticipacio
            // 
            this.tbPreuParticipacio._Format = "#,##0.### €";
            this.tbPreuParticipacio._PermetDecimals = true;
            this.tbPreuParticipacio._PermetEspais = false;
            this.tbPreuParticipacio._PermetNegatius = false;
            this.tbPreuParticipacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPreuParticipacio.Location = new System.Drawing.Point(5, 20);
            this.tbPreuParticipacio.Name = "tbPreuParticipacio";
            this.tbPreuParticipacio.Size = new System.Drawing.Size(88, 22);
            this.tbPreuParticipacio.TabIndex = 0;
            this.tbPreuParticipacio.Text = "0 €";
            this.tbPreuParticipacio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPreuParticipacio.Valor = 0D;
            this.tbPreuParticipacio.Leave += new System.EventHandler(this.tbPreuParticipacio_Leave);
            // 
            // tbNumParticipacions
            // 
            this.tbNumParticipacions._Format = "#,##0.####";
            this.tbNumParticipacions._PermetDecimals = true;
            this.tbNumParticipacions._PermetEspais = false;
            this.tbNumParticipacions._PermetNegatius = false;
            this.tbNumParticipacions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNumParticipacions.Location = new System.Drawing.Point(5, 20);
            this.tbNumParticipacions.Name = "tbNumParticipacions";
            this.tbNumParticipacions.Size = new System.Drawing.Size(101, 22);
            this.tbNumParticipacions.TabIndex = 0;
            this.tbNumParticipacions.Text = "0";
            this.tbNumParticipacions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbNumParticipacions.Valor = 0D;
            this.tbNumParticipacions.Leave += new System.EventHandler(this.tbNumParticipacions_Leave);
            // 
            // gestioProductesTabMoviments
            // 
            this.gestioProductesTabMoviments._NomesAmbParticipacions = true;
            this.gestioProductesTabMoviments._ProducteSeleccionat = null;
            this.gestioProductesTabMoviments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gestioProductesTabMoviments.Dock = System.Windows.Forms.DockStyle.Left;
            this.gestioProductesTabMoviments.Location = new System.Drawing.Point(0, 0);
            this.gestioProductesTabMoviments.MinimumSize = new System.Drawing.Size(733, 395);
            this.gestioProductesTabMoviments.Name = "gestioProductesTabMoviments";
            this.gestioProductesTabMoviments.Size = new System.Drawing.Size(1013, 410);
            this.gestioProductesTabMoviments.TabIndex = 0;
            this.gestioProductesTabMoviments.ProducteSeleccionat += new System.EventHandler(this.gestioProductes1_ProducteSeleccionat);
            // 
            // MovimentsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.gestioProductesTabMoviments);
            this.Controls.Add(this.cDataGridView1);
            this.Name = "MovimentsTab";
            this.Size = new System.Drawing.Size(1585, 599);
            ((System.ComponentModel.ISupportInitialize)(this.cDataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.gbParticipacions.ResumeLayout(false);
            this.gbParticipacions.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.gbDespeses.ResumeLayout(false);
            this.gbDespeses.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbDescripcio.ResumeLayout(false);
            this.gbDescripcio.PerformLayout();
            this.gbEdicio.ResumeLayout(false);
            this.gbNumParticipacionsDesti.ResumeLayout(false);
            this.gbNumParticipacionsDesti.PerformLayout();
            this.gbDataDesti.ResumeLayout(false);
            this.gbProducteTraspas.ResumeLayout(false);
            this.gbTraspas.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView cDataGridView1;
        private GestioProductes gestioProductesTabMoviments;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTraspasOrigenX;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipusMoviment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParticipacions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPreuUnitari;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDespeses;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTraspasOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTraspasDesti;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcio;
        private System.Windows.Forms.Button btDesaMoviment;
        private System.Windows.Forms.Button btCompra;
        private System.Windows.Forms.Button btVenda;
        private System.Windows.Forms.Button btDividends;
        private System.Windows.Forms.Button btCancelaMoviment;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.NumericTextBox2 tbImportTotal;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox gbDespeses;
        private Controls.NumericTextBox2 tbDespeses;
        private System.Windows.Forms.GroupBox groupBox10;
        private Controls.NumericTextBox2 tbPreuParticipacio;
        private System.Windows.Forms.GroupBox gbParticipacions;
        private Controls.NumericTextBox2 tbNumParticipacions;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.DateTimePicker cData1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.ComboBox cTipusMovimentTab2;
        private System.Windows.Forms.GroupBox gbDescripcio;
        private System.Windows.Forms.TextBox tbDescripcio;
        private System.Windows.Forms.GroupBox gbEdicio;
        private System.Windows.Forms.GroupBox gbNumParticipacionsDesti;
        private Controls.NumericTextBox2 tbNumParticipacionsDesti;
        private System.Windows.Forms.GroupBox gbDataDesti;
        private System.Windows.Forms.DateTimePicker cDataDesti;
        private System.Windows.Forms.GroupBox gbProducteTraspas;
        private System.Windows.Forms.ComboBox cProducteTraspas;
        private System.Windows.Forms.GroupBox gbTraspas;
        private System.Windows.Forms.Panel panel3;
    }
}
