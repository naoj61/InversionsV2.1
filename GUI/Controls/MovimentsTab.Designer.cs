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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cDataGridView1 = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducte = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipusMoviment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colParticipacions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPreuUnitari = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ImportBrut = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCanviAplicat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDespeses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTraspasOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTraspasDesti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.gbPreuPartic = new System.Windows.Forms.GroupBox();
            this.ntbPreuParticipacio = new Controls.NumericTextBox2();
            this.gbFactorConversor = new System.Windows.Forms.GroupBox();
            this.ntbFactorConversor = new Controls.NumericTextBox2();
            this.btDesaMoviment = new System.Windows.Forms.Button();
            this.btFes = new System.Windows.Forms.Button();
            this.btCancelaMoviment = new System.Windows.Forms.Button();
            this.pnCompraVenda = new System.Windows.Forms.FlowLayoutPanel();
            this.gbDataMoviment = new System.Windows.Forms.GroupBox();
            this.cData1 = new System.Windows.Forms.DateTimePicker();
            this.ckActivaDataDesti = new System.Windows.Forms.CheckBox();
            this.gbParticipacions = new System.Windows.Forms.GroupBox();
            this.tbNumParticipacions = new Controls.NumericTextBox2();
            this.gbCanviAplicat = new System.Windows.Forms.GroupBox();
            this.tbCanviAplicat = new Controls.NumericTextBox2();
            this.gbDespeses = new System.Windows.Forms.GroupBox();
            this.tbDespeses = new Controls.NumericTextBox2();
            this.gbImportTotal = new System.Windows.Forms.GroupBox();
            this.tbImportTotal = new Controls.NumericTextBox2();
            this.gbDescripcio = new System.Windows.Forms.GroupBox();
            this.tbDescripcio = new System.Windows.Forms.TextBox();
            this.gbEdicio = new System.Windows.Forms.GroupBox();
            this.gbTraspas = new System.Windows.Forms.GroupBox();
            this.gbProducteTraspas = new System.Windows.Forms.GroupBox();
            this.cProducteTraspas = new System.Windows.Forms.ComboBox();
            this.gbDataDesti = new System.Windows.Forms.GroupBox();
            this.cDataDesti = new System.Windows.Forms.DateTimePicker();
            this.gbNumParticipacionsDesti = new System.Windows.Forms.GroupBox();
            this.tbNumParticipacionsDesti = new Controls.NumericTextBox2();
            this.pnMovBotons = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTipusMoviment = new System.Windows.Forms.ComboBox();
            this.pnMovTop = new System.Windows.Forms.Panel();
            this.gestioProductesTabMoviments = new Inversions.GUI.GestioProductes();
            ((System.ComponentModel.ISupportInitialize)(this.cDataGridView1)).BeginInit();
            this.gbPreuPartic.SuspendLayout();
            this.gbFactorConversor.SuspendLayout();
            this.pnCompraVenda.SuspendLayout();
            this.gbDataMoviment.SuspendLayout();
            this.gbParticipacions.SuspendLayout();
            this.gbCanviAplicat.SuspendLayout();
            this.gbDespeses.SuspendLayout();
            this.gbImportTotal.SuspendLayout();
            this.gbDescripcio.SuspendLayout();
            this.gbEdicio.SuspendLayout();
            this.gbTraspas.SuspendLayout();
            this.gbProducteTraspas.SuspendLayout();
            this.gbDataDesti.SuspendLayout();
            this.gbNumParticipacionsDesti.SuspendLayout();
            this.pnMovBotons.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnMovTop.SuspendLayout();
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
            this.ImportBrut,
            this.colImport,
            this.colCanviAplicat,
            this.colDespeses,
            this.colTraspasOrigen,
            this.colTraspasDesti,
            this.colDescripcio});
            this.cDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cDataGridView1.Location = new System.Drawing.Point(0, 453);
            this.cDataGridView1.Name = "cDataGridView1";
            this.cDataGridView1.ReadOnly = true;
            this.cDataGridView1.RowTemplate.Height = 24;
            this.cDataGridView1.Size = new System.Drawing.Size(1585, 146);
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
            // ImportBrut
            // 
            this.ImportBrut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ImportBrut.DataPropertyName = "ImportBrut";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            this.ImportBrut.DefaultCellStyle = dataGridViewCellStyle4;
            this.ImportBrut.HeaderText = "Import Brut";
            this.ImportBrut.Name = "ImportBrut";
            this.ImportBrut.ReadOnly = true;
            this.ImportBrut.Width = 98;
            // 
            // colImport
            // 
            this.colImport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colImport.DataPropertyName = "ImportNet";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.colImport.DefaultCellStyle = dataGridViewCellStyle5;
            this.colImport.HeaderText = "Import Net";
            this.colImport.Name = "colImport";
            this.colImport.ReadOnly = true;
            this.colImport.Width = 94;
            // 
            // colCanviAplicat
            // 
            this.colCanviAplicat.DataPropertyName = "CanviAplicat";
            this.colCanviAplicat.HeaderText = "Canvi Aplicat";
            this.colCanviAplicat.Name = "colCanviAplicat";
            this.colCanviAplicat.ReadOnly = true;
            // 
            // colDespeses
            // 
            this.colDespeses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDespeses.DataPropertyName = "Despeses";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "c2";
            this.colDespeses.DefaultCellStyle = dataGridViewCellStyle6;
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
            this.colDescripcio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colDescripcio.DataPropertyName = "Descripcio";
            this.colDescripcio.HeaderText = "Descripció";
            this.colDescripcio.Name = "colDescripcio";
            this.colDescripcio.ReadOnly = true;
            // 
            // gbPreuPartic
            // 
            this.gbPreuPartic.Controls.Add(this.ntbPreuParticipacio);
            this.gbPreuPartic.Location = new System.Drawing.Point(3, 59);
            this.gbPreuPartic.Name = "gbPreuPartic";
            this.gbPreuPartic.Padding = new System.Windows.Forms.Padding(5);
            this.gbPreuPartic.Size = new System.Drawing.Size(111, 50);
            this.gbPreuPartic.TabIndex = 3;
            this.gbPreuPartic.TabStop = false;
            this.gbPreuPartic.Text = "Preu Partic.";
            this.toolTip1.SetToolTip(this.gbPreuPartic, "Import brut sense despeses");
            // 
            // ntbPreuParticipacio
            // 
            this.ntbPreuParticipacio._Format = "#,##0.###### €";
            this.ntbPreuParticipacio._PermetDecimals = true;
            this.ntbPreuParticipacio._PermetEspais = false;
            this.ntbPreuParticipacio._PermetNegatius = false;
            this.ntbPreuParticipacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPreuParticipacio.Location = new System.Drawing.Point(5, 20);
            this.ntbPreuParticipacio.Name = "ntbPreuParticipacio";
            this.ntbPreuParticipacio.Size = new System.Drawing.Size(101, 22);
            this.ntbPreuParticipacio.TabIndex = 0;
            this.ntbPreuParticipacio.Text = "0 €";
            this.ntbPreuParticipacio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPreuParticipacio.Valor = 0D;
            this.ntbPreuParticipacio.Leave += new System.EventHandler(this.tbPreuParticipacio_Leave);
            // 
            // gbFactorConversor
            // 
            this.gbFactorConversor.Controls.Add(this.ntbFactorConversor);
            this.gbFactorConversor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFactorConversor.Location = new System.Drawing.Point(362, 3);
            this.gbFactorConversor.Name = "gbFactorConversor";
            this.gbFactorConversor.Padding = new System.Windows.Forms.Padding(5);
            this.gbFactorConversor.Size = new System.Drawing.Size(125, 50);
            this.gbFactorConversor.TabIndex = 2;
            this.gbFactorConversor.TabStop = false;
            this.gbFactorConversor.Text = "Factor Conversor";
            this.toolTip1.SetToolTip(this.gbFactorConversor, "És el numero pel que les accions se dividiran(Contrasplit) o multiplicaran(Split)" +
        "");
            // 
            // ntbFactorConversor
            // 
            this.ntbFactorConversor._Format = "#,##0";
            this.ntbFactorConversor._PermetDecimals = false;
            this.ntbFactorConversor._PermetEspais = false;
            this.ntbFactorConversor._PermetNegatius = false;
            this.ntbFactorConversor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbFactorConversor.Location = new System.Drawing.Point(5, 19);
            this.ntbFactorConversor.Name = "ntbFactorConversor";
            this.ntbFactorConversor.Size = new System.Drawing.Size(115, 21);
            this.ntbFactorConversor.TabIndex = 0;
            this.ntbFactorConversor.Text = "0";
            this.ntbFactorConversor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbFactorConversor.Valor = 0D;
            this.ntbFactorConversor.Leave += new System.EventHandler(this.tbNumParticipacions_Leave);
            // 
            // btDesaMoviment
            // 
            this.btDesaMoviment.Enabled = false;
            this.btDesaMoviment.Location = new System.Drawing.Point(400, 8);
            this.btDesaMoviment.Name = "btDesaMoviment";
            this.btDesaMoviment.Size = new System.Drawing.Size(79, 50);
            this.btDesaMoviment.TabIndex = 5;
            this.btDesaMoviment.Text = "Desa";
            this.btDesaMoviment.UseVisualStyleBackColor = true;
            this.btDesaMoviment.Click += new System.EventHandler(this.btDesaMoviment_Click);
            // 
            // btFes
            // 
            this.btFes.Enabled = false;
            this.btFes.Location = new System.Drawing.Point(150, 8);
            this.btFes.Name = "btFes";
            this.btFes.Size = new System.Drawing.Size(79, 50);
            this.btFes.TabIndex = 4;
            this.btFes.Text = "Fes";
            this.btFes.UseVisualStyleBackColor = true;
            this.btFes.Click += new System.EventHandler(this.btFes_Click);
            // 
            // btCancelaMoviment
            // 
            this.btCancelaMoviment.Enabled = false;
            this.btCancelaMoviment.Location = new System.Drawing.Point(487, 8);
            this.btCancelaMoviment.Name = "btCancelaMoviment";
            this.btCancelaMoviment.Size = new System.Drawing.Size(79, 50);
            this.btCancelaMoviment.TabIndex = 6;
            this.btCancelaMoviment.Text = "Cancela";
            this.btCancelaMoviment.UseVisualStyleBackColor = true;
            this.btCancelaMoviment.Click += new System.EventHandler(this.btCancelaMoviment_Click);
            // 
            // pnCompraVenda
            // 
            this.pnCompraVenda.AutoSize = true;
            this.pnCompraVenda.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnCompraVenda.Controls.Add(this.gbDataMoviment);
            this.pnCompraVenda.Controls.Add(this.ckActivaDataDesti);
            this.pnCompraVenda.Controls.Add(this.gbParticipacions);
            this.pnCompraVenda.Controls.Add(this.gbFactorConversor);
            this.pnCompraVenda.Controls.Add(this.gbPreuPartic);
            this.pnCompraVenda.Controls.Add(this.gbCanviAplicat);
            this.pnCompraVenda.Controls.Add(this.gbDespeses);
            this.pnCompraVenda.Controls.Add(this.gbImportTotal);
            this.pnCompraVenda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnCompraVenda.Location = new System.Drawing.Point(3, 18);
            this.pnCompraVenda.Name = "pnCompraVenda";
            this.pnCompraVenda.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnCompraVenda.Size = new System.Drawing.Size(566, 117);
            this.pnCompraVenda.TabIndex = 4;
            // 
            // gbDataMoviment
            // 
            this.gbDataMoviment.Controls.Add(this.cData1);
            this.gbDataMoviment.Location = new System.Drawing.Point(3, 3);
            this.gbDataMoviment.Name = "gbDataMoviment";
            this.gbDataMoviment.Padding = new System.Windows.Forms.Padding(5);
            this.gbDataMoviment.Size = new System.Drawing.Size(105, 50);
            this.gbDataMoviment.TabIndex = 1;
            this.gbDataMoviment.TabStop = false;
            this.gbDataMoviment.Text = "Data";
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
            // ckActivaDataDesti
            // 
            this.ckActivaDataDesti.AutoSize = true;
            this.ckActivaDataDesti.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckActivaDataDesti.Location = new System.Drawing.Point(114, 3);
            this.ckActivaDataDesti.Name = "ckActivaDataDesti";
            this.ckActivaDataDesti.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.ckActivaDataDesti.Size = new System.Drawing.Size(125, 39);
            this.ckActivaDataDesti.TabIndex = 5;
            this.ckActivaDataDesti.Text = "Mostra Data Destí";
            this.ckActivaDataDesti.UseVisualStyleBackColor = true;
            this.ckActivaDataDesti.CheckedChanged += new System.EventHandler(this.ckActivaDataDesti_CheckedChanged);
            // 
            // gbParticipacions
            // 
            this.gbParticipacions.Controls.Add(this.tbNumParticipacions);
            this.gbParticipacions.Location = new System.Drawing.Point(245, 3);
            this.gbParticipacions.Name = "gbParticipacions";
            this.gbParticipacions.Padding = new System.Windows.Forms.Padding(5);
            this.gbParticipacions.Size = new System.Drawing.Size(111, 50);
            this.gbParticipacions.TabIndex = 2;
            this.gbParticipacions.TabStop = false;
            this.gbParticipacions.Text = "Participacions";
            // 
            // tbNumParticipacions
            // 
            this.tbNumParticipacions._Format = "#,##0.######";
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
            // gbCanviAplicat
            // 
            this.gbCanviAplicat.Controls.Add(this.tbCanviAplicat);
            this.gbCanviAplicat.Location = new System.Drawing.Point(120, 59);
            this.gbCanviAplicat.Name = "gbCanviAplicat";
            this.gbCanviAplicat.Padding = new System.Windows.Forms.Padding(5);
            this.gbCanviAplicat.Size = new System.Drawing.Size(111, 50);
            this.gbCanviAplicat.TabIndex = 3;
            this.gbCanviAplicat.TabStop = false;
            this.gbCanviAplicat.Text = "Canvi €/x";
            // 
            // tbCanviAplicat
            // 
            this.tbCanviAplicat._Format = "#,##0.######## €";
            this.tbCanviAplicat._PermetDecimals = true;
            this.tbCanviAplicat._PermetEspais = false;
            this.tbCanviAplicat._PermetNegatius = false;
            this.tbCanviAplicat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCanviAplicat.Location = new System.Drawing.Point(5, 20);
            this.tbCanviAplicat.Name = "tbCanviAplicat";
            this.tbCanviAplicat.Size = new System.Drawing.Size(101, 22);
            this.tbCanviAplicat.TabIndex = 0;
            this.tbCanviAplicat.Text = "1 €";
            this.tbCanviAplicat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCanviAplicat.Valor = 1D;
            this.tbCanviAplicat.Leave += new System.EventHandler(this.tbPreuParticipacio_Leave);
            // 
            // gbDespeses
            // 
            this.gbDespeses.Controls.Add(this.tbDespeses);
            this.gbDespeses.Location = new System.Drawing.Point(237, 59);
            this.gbDespeses.Name = "gbDespeses";
            this.gbDespeses.Padding = new System.Windows.Forms.Padding(5);
            this.gbDespeses.Size = new System.Drawing.Size(111, 50);
            this.gbDespeses.TabIndex = 4;
            this.gbDespeses.TabStop = false;
            this.gbDespeses.Text = "Despeses";
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
            this.tbDespeses.Size = new System.Drawing.Size(101, 22);
            this.tbDespeses.TabIndex = 0;
            this.tbDespeses.Text = "0 €";
            this.tbDespeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDespeses.Valor = 0D;
            this.tbDespeses.Leave += new System.EventHandler(this.tbDespeses_Leave);
            // 
            // gbImportTotal
            // 
            this.gbImportTotal.Controls.Add(this.tbImportTotal);
            this.gbImportTotal.Location = new System.Drawing.Point(354, 59);
            this.gbImportTotal.Name = "gbImportTotal";
            this.gbImportTotal.Padding = new System.Windows.Forms.Padding(5);
            this.gbImportTotal.Size = new System.Drawing.Size(111, 46);
            this.gbImportTotal.TabIndex = 0;
            this.gbImportTotal.TabStop = false;
            this.gbImportTotal.Text = "Imp. Total";
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
            this.tbImportTotal.Size = new System.Drawing.Size(101, 22);
            this.tbImportTotal.TabIndex = 0;
            this.tbImportTotal.Text = "0 €";
            this.tbImportTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbImportTotal.Valor = 0D;
            // 
            // gbDescripcio
            // 
            this.gbDescripcio.Controls.Add(this.tbDescripcio);
            this.gbDescripcio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDescripcio.Location = new System.Drawing.Point(3, 135);
            this.gbDescripcio.Name = "gbDescripcio";
            this.gbDescripcio.Size = new System.Drawing.Size(566, 171);
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
            this.tbDescripcio.Size = new System.Drawing.Size(560, 150);
            this.tbDescripcio.TabIndex = 0;
            // 
            // gbEdicio
            // 
            this.gbEdicio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbEdicio.Controls.Add(this.gbDescripcio);
            this.gbEdicio.Controls.Add(this.pnCompraVenda);
            this.gbEdicio.Controls.Add(this.gbTraspas);
            this.gbEdicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEdicio.Location = new System.Drawing.Point(0, 66);
            this.gbEdicio.Name = "gbEdicio";
            this.gbEdicio.Size = new System.Drawing.Size(572, 387);
            this.gbEdicio.TabIndex = 7;
            this.gbEdicio.TabStop = false;
            this.gbEdicio.Visible = false;
            // 
            // gbTraspas
            // 
            this.gbTraspas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbTraspas.Controls.Add(this.gbProducteTraspas);
            this.gbTraspas.Controls.Add(this.gbDataDesti);
            this.gbTraspas.Controls.Add(this.gbNumParticipacionsDesti);
            this.gbTraspas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbTraspas.Location = new System.Drawing.Point(3, 306);
            this.gbTraspas.Name = "gbTraspas";
            this.gbTraspas.Size = new System.Drawing.Size(566, 78);
            this.gbTraspas.TabIndex = 9;
            this.gbTraspas.TabStop = false;
            this.gbTraspas.Text = "Traspàs";
            this.gbTraspas.Visible = false;
            // 
            // gbProducteTraspas
            // 
            this.gbProducteTraspas.Controls.Add(this.cProducteTraspas);
            this.gbProducteTraspas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbProducteTraspas.Location = new System.Drawing.Point(3, 18);
            this.gbProducteTraspas.Name = "gbProducteTraspas";
            this.gbProducteTraspas.Padding = new System.Windows.Forms.Padding(5);
            this.gbProducteTraspas.Size = new System.Drawing.Size(335, 57);
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
            this.cProducteTraspas.Size = new System.Drawing.Size(325, 24);
            this.cProducteTraspas.TabIndex = 0;
            // 
            // gbDataDesti
            // 
            this.gbDataDesti.Controls.Add(this.cDataDesti);
            this.gbDataDesti.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbDataDesti.Location = new System.Drawing.Point(338, 18);
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
            // gbNumParticipacionsDesti
            // 
            this.gbNumParticipacionsDesti.Controls.Add(this.tbNumParticipacionsDesti);
            this.gbNumParticipacionsDesti.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbNumParticipacionsDesti.Location = new System.Drawing.Point(449, 18);
            this.gbNumParticipacionsDesti.Name = "gbNumParticipacionsDesti";
            this.gbNumParticipacionsDesti.Padding = new System.Windows.Forms.Padding(5);
            this.gbNumParticipacionsDesti.Size = new System.Drawing.Size(114, 57);
            this.gbNumParticipacionsDesti.TabIndex = 2;
            this.gbNumParticipacionsDesti.TabStop = false;
            this.gbNumParticipacionsDesti.Text = "Participacions";
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
            // pnMovBotons
            // 
            this.pnMovBotons.Controls.Add(this.gbEdicio);
            this.pnMovBotons.Controls.Add(this.panel3);
            this.pnMovBotons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnMovBotons.Location = new System.Drawing.Point(1013, 0);
            this.pnMovBotons.MinimumSize = new System.Drawing.Size(572, 410);
            this.pnMovBotons.Name = "pnMovBotons";
            this.pnMovBotons.Size = new System.Drawing.Size(572, 453);
            this.pnMovBotons.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox1);
            this.panel3.Controls.Add(this.btFes);
            this.panel3.Controls.Add(this.btCancelaMoviment);
            this.panel3.Controls.Add(this.btDesaMoviment);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(572, 66);
            this.panel3.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTipusMoviment);
            this.groupBox1.Location = new System.Drawing.Point(11, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(134, 46);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipus Moviment";
            // 
            // cbTipusMoviment
            // 
            this.cbTipusMoviment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTipusMoviment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipusMoviment.Enabled = false;
            this.cbTipusMoviment.FormattingEnabled = true;
            this.cbTipusMoviment.Location = new System.Drawing.Point(5, 20);
            this.cbTipusMoviment.Name = "cbTipusMoviment";
            this.cbTipusMoviment.Size = new System.Drawing.Size(124, 24);
            this.cbTipusMoviment.TabIndex = 0;
            this.cbTipusMoviment.SelectedIndexChanged += new System.EventHandler(this.cbTipusMoviment_SelectedIndexChanged);
            // 
            // pnMovTop
            // 
            this.pnMovTop.Controls.Add(this.gestioProductesTabMoviments);
            this.pnMovTop.Controls.Add(this.pnMovBotons);
            this.pnMovTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnMovTop.Location = new System.Drawing.Point(0, 0);
            this.pnMovTop.Name = "pnMovTop";
            this.pnMovTop.Size = new System.Drawing.Size(1585, 453);
            this.pnMovTop.TabIndex = 10;
            // 
            // gestioProductesTabMoviments
            // 
            this.gestioProductesTabMoviments._AmbMoviments = true;
            this.gestioProductesTabMoviments._FiltreAnyVisible = true;
            this.gestioProductesTabMoviments._NomesAmbParticipacions = false;
            this.gestioProductesTabMoviments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gestioProductesTabMoviments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gestioProductesTabMoviments.Location = new System.Drawing.Point(0, 0);
            this.gestioProductesTabMoviments.MinimumSize = new System.Drawing.Size(733, 395);
            this.gestioProductesTabMoviments.Name = "gestioProductesTabMoviments";
            this.gestioProductesTabMoviments.Size = new System.Drawing.Size(1013, 453);
            this.gestioProductesTabMoviments.TabIndex = 0;
            this.gestioProductesTabMoviments.ProducteSeleccionat += new System.EventHandler(this.gestioProductes1_ProducteSeleccionat);
            // 
            // MovimentsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cDataGridView1);
            this.Controls.Add(this.pnMovTop);
            this.Name = "MovimentsTab";
            this.Size = new System.Drawing.Size(1585, 599);
            ((System.ComponentModel.ISupportInitialize)(this.cDataGridView1)).EndInit();
            this.gbPreuPartic.ResumeLayout(false);
            this.gbPreuPartic.PerformLayout();
            this.gbFactorConversor.ResumeLayout(false);
            this.gbFactorConversor.PerformLayout();
            this.pnCompraVenda.ResumeLayout(false);
            this.pnCompraVenda.PerformLayout();
            this.gbDataMoviment.ResumeLayout(false);
            this.gbParticipacions.ResumeLayout(false);
            this.gbParticipacions.PerformLayout();
            this.gbCanviAplicat.ResumeLayout(false);
            this.gbCanviAplicat.PerformLayout();
            this.gbDespeses.ResumeLayout(false);
            this.gbDespeses.PerformLayout();
            this.gbImportTotal.ResumeLayout(false);
            this.gbImportTotal.PerformLayout();
            this.gbDescripcio.ResumeLayout(false);
            this.gbDescripcio.PerformLayout();
            this.gbEdicio.ResumeLayout(false);
            this.gbEdicio.PerformLayout();
            this.gbTraspas.ResumeLayout(false);
            this.gbProducteTraspas.ResumeLayout(false);
            this.gbDataDesti.ResumeLayout(false);
            this.gbNumParticipacionsDesti.ResumeLayout(false);
            this.gbNumParticipacionsDesti.PerformLayout();
            this.pnMovBotons.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pnMovTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView cDataGridView1;
        private GestioProductes gestioProductesTabMoviments;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTraspasOrigenX;
        private System.Windows.Forms.Button btDesaMoviment;
        private System.Windows.Forms.Button btFes;
        private System.Windows.Forms.Button btCancelaMoviment;
        private System.Windows.Forms.FlowLayoutPanel pnCompraVenda;
        private System.Windows.Forms.GroupBox gbImportTotal;
        private Controls.NumericTextBox2 tbImportTotal;
        private System.Windows.Forms.GroupBox gbDespeses;
        private Controls.NumericTextBox2 tbDespeses;
        private System.Windows.Forms.GroupBox gbPreuPartic;
        private Controls.NumericTextBox2 ntbPreuParticipacio;
        private System.Windows.Forms.GroupBox gbParticipacions;
        private Controls.NumericTextBox2 tbNumParticipacions;
        private System.Windows.Forms.GroupBox gbDataMoviment;
        private System.Windows.Forms.DateTimePicker cData1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox gbDescripcio;
        private System.Windows.Forms.TextBox tbDescripcio;
        private System.Windows.Forms.GroupBox gbEdicio;
        private System.Windows.Forms.Panel pnMovBotons;
        private System.Windows.Forms.Panel pnMovTop;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox gbCanviAplicat;
        private Controls.NumericTextBox2 tbCanviAplicat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducte;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipusMoviment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colParticipacions;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPreuUnitari;
        private System.Windows.Forms.DataGridViewTextBoxColumn ImportBrut;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCanviAplicat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDespeses;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTraspasOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTraspasDesti;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbTipusMoviment;
        private System.Windows.Forms.GroupBox gbFactorConversor;
        private Controls.NumericTextBox2 ntbFactorConversor;
        private System.Windows.Forms.GroupBox gbTraspas;
        private System.Windows.Forms.GroupBox gbProducteTraspas;
        private System.Windows.Forms.ComboBox cProducteTraspas;
        private System.Windows.Forms.GroupBox gbDataDesti;
        private System.Windows.Forms.DateTimePicker cDataDesti;
        private System.Windows.Forms.GroupBox gbNumParticipacionsDesti;
        private Controls.NumericTextBox2 tbNumParticipacionsDesti;
        private System.Windows.Forms.CheckBox ckActivaDataDesti;
    }
}
