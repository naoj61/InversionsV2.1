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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvMovimentsProd = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTipusMoviment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProducte = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.gbPigVendaReal = new System.Windows.Forms.GroupBox();
            this.ntbPigVendaReal = new Controls.NumericTextBox2();
            this.gbDescripcio = new System.Windows.Forms.GroupBox();
            this.tbDescripcio = new System.Windows.Forms.TextBox();
            this.gbEdicio = new System.Windows.Forms.GroupBox();
            this.gbTraspas = new System.Windows.Forms.GroupBox();
            this.gbDataDesti = new System.Windows.Forms.GroupBox();
            this.cDataDesti = new System.Windows.Forms.DateTimePicker();
            this.gbNumParticipacionsDesti = new System.Windows.Forms.GroupBox();
            this.tbNumParticipacionsDesti = new Controls.NumericTextBox2();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ntbPreuParticipacioFonsCompra = new Controls.NumericTextBox2();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ntbDespeses = new Controls.NumericTextBox2();
            this.gbProducteTraspas = new System.Windows.Forms.GroupBox();
            this.cProducteTraspas = new System.Windows.Forms.ComboBox();
            this.pnMovBotons = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTipusMoviment = new System.Windows.Forms.ComboBox();
            this.pnMovTop = new System.Windows.Forms.Panel();
            this.gestioProductesTabMoviments = new Inversions.GUI.GestioProductes();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentsProd)).BeginInit();
            this.gbPreuPartic.SuspendLayout();
            this.gbFactorConversor.SuspendLayout();
            this.pnCompraVenda.SuspendLayout();
            this.gbDataMoviment.SuspendLayout();
            this.gbParticipacions.SuspendLayout();
            this.gbCanviAplicat.SuspendLayout();
            this.gbDespeses.SuspendLayout();
            this.gbImportTotal.SuspendLayout();
            this.gbPigVendaReal.SuspendLayout();
            this.gbDescripcio.SuspendLayout();
            this.gbEdicio.SuspendLayout();
            this.gbTraspas.SuspendLayout();
            this.gbDataDesti.SuspendLayout();
            this.gbNumParticipacionsDesti.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbProducteTraspas.SuspendLayout();
            this.pnMovBotons.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.pnMovTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMovimentsProd
            // 
            this.dgvMovimentsProd.AllowUserToAddRows = false;
            this.dgvMovimentsProd.AllowUserToDeleteRows = false;
            this.dgvMovimentsProd.AllowUserToOrderColumns = true;
            this.dgvMovimentsProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimentsProd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colTipusMoviment,
            this.colProducte,
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
            this.dgvMovimentsProd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMovimentsProd.Location = new System.Drawing.Point(0, 566);
            this.dgvMovimentsProd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvMovimentsProd.Name = "dgvMovimentsProd";
            this.dgvMovimentsProd.ReadOnly = true;
            this.dgvMovimentsProd.RowTemplate.Height = 24;
            this.dgvMovimentsProd.Size = new System.Drawing.Size(1783, 183);
            this.dgvMovimentsProd.TabIndex = 0;
            this.toolTip1.SetToolTip(this.dgvMovimentsProd, "nhjfghj");
            this.dgvMovimentsProd.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.cDataGridView1_CellMouseDoubleClick);
            // 
            // colId
            // 
            this.colId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colId.DataPropertyName = "_Id";
            this.colId.HeaderText = "Id";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            this.colId.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colId.Width = 59;
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
            this.colTipusMoviment.Width = 113;
            // 
            // colProducte
            // 
            this.colProducte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colProducte.DataPropertyName = "_Prod";
            this.colProducte.HeaderText = "Producte";
            this.colProducte.Name = "colProducte";
            this.colProducte.ReadOnly = true;
            this.colProducte.Visible = false;
            // 
            // colData
            // 
            this.colData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colData.DataPropertyName = "_Data";
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle15.Format = "d";
            dataGridViewCellStyle15.NullValue = null;
            this.colData.DefaultCellStyle = dataGridViewCellStyle15;
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 80;
            // 
            // colParticipacions
            // 
            this.colParticipacions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colParticipacions.DataPropertyName = "_Participacions";
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle16.Format = "N4";
            dataGridViewCellStyle16.NullValue = null;
            this.colParticipacions.DefaultCellStyle = dataGridViewCellStyle16;
            this.colParticipacions.HeaderText = "Participacions";
            this.colParticipacions.Name = "colParticipacions";
            this.colParticipacions.ReadOnly = true;
            this.colParticipacions.Width = 143;
            // 
            // colPreuUnitari
            // 
            this.colPreuUnitari.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colPreuUnitari.DataPropertyName = "_PreuParticipacio";
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle17.Format = "c4";
            dataGridViewCellStyle17.NullValue = null;
            this.colPreuUnitari.DefaultCellStyle = dataGridViewCellStyle17;
            this.colPreuUnitari.HeaderText = "Preu Unitari";
            this.colPreuUnitari.Name = "colPreuUnitari";
            this.colPreuUnitari.ReadOnly = true;
            this.colPreuUnitari.Width = 118;
            // 
            // ImportBrut
            // 
            this.ImportBrut.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ImportBrut.DataPropertyName = "_ImportBrut";
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle18.Format = "C2";
            this.ImportBrut.DefaultCellStyle = dataGridViewCellStyle18;
            this.ImportBrut.HeaderText = "Import Brut";
            this.ImportBrut.Name = "ImportBrut";
            this.ImportBrut.ReadOnly = true;
            this.ImportBrut.Width = 116;
            // 
            // colImport
            // 
            this.colImport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colImport.DataPropertyName = "_ImportNet";
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle19.Format = "C2";
            dataGridViewCellStyle19.NullValue = null;
            this.colImport.DefaultCellStyle = dataGridViewCellStyle19;
            this.colImport.HeaderText = "Import Net";
            this.colImport.Name = "colImport";
            this.colImport.ReadOnly = true;
            this.colImport.Width = 111;
            // 
            // colCanviAplicat
            // 
            this.colCanviAplicat.DataPropertyName = "_CanviAplicat";
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "C2";
            this.colCanviAplicat.DefaultCellStyle = dataGridViewCellStyle20;
            this.colCanviAplicat.HeaderText = "Canvi Aplicat";
            this.colCanviAplicat.Name = "colCanviAplicat";
            this.colCanviAplicat.ReadOnly = true;
            // 
            // colDespeses
            // 
            this.colDespeses.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDespeses.DataPropertyName = "_Despeses";
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle21.Format = "c2";
            this.colDespeses.DefaultCellStyle = dataGridViewCellStyle21;
            this.colDespeses.HeaderText = "Despeses";
            this.colDespeses.Name = "colDespeses";
            this.colDespeses.ReadOnly = true;
            this.colDespeses.Width = 117;
            // 
            // colTraspasOrigen
            // 
            this.colTraspasOrigen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colTraspasOrigen.DataPropertyName = "_ProducteTraspasOrigen";
            this.colTraspasOrigen.HeaderText = "Traspassat de:";
            this.colTraspasOrigen.MinimumWidth = 130;
            this.colTraspasOrigen.Name = "colTraspasOrigen";
            this.colTraspasOrigen.ReadOnly = true;
            this.colTraspasOrigen.Width = 138;
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
            this.colDescripcio.DataPropertyName = "_Descripcio";
            this.colDescripcio.HeaderText = "Descripció";
            this.colDescripcio.Name = "colDescripcio";
            this.colDescripcio.ReadOnly = true;
            // 
            // gbPreuPartic
            // 
            this.gbPreuPartic.Controls.Add(this.ntbPreuParticipacio);
            this.gbPreuPartic.Location = new System.Drawing.Point(3, 74);
            this.gbPreuPartic.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPreuPartic.Name = "gbPreuPartic";
            this.gbPreuPartic.Padding = new System.Windows.Forms.Padding(6);
            this.gbPreuPartic.Size = new System.Drawing.Size(136, 62);
            this.gbPreuPartic.TabIndex = 4;
            this.gbPreuPartic.TabStop = false;
            this.gbPreuPartic.Text = "Preu Partic.";
            this.toolTip1.SetToolTip(this.gbPreuPartic, "Import brut sense despeses");
            // 
            // ntbPreuParticipacio
            // 
            this.ntbPreuParticipacio._CapturaEscape = true;
            this.ntbPreuParticipacio._Format = "#,##0.####### €";
            this.ntbPreuParticipacio._NegatiusEnVermell = false;
            this.ntbPreuParticipacio._PermetDecimals = true;
            this.ntbPreuParticipacio._PermetNegatius = false;
            this.ntbPreuParticipacio._PermetTextNull = false;
            this.ntbPreuParticipacio.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPreuParticipacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPreuParticipacio.ForeColor = System.Drawing.Color.Black;
            this.ntbPreuParticipacio.Location = new System.Drawing.Point(6, 25);
            this.ntbPreuParticipacio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ntbPreuParticipacio.Name = "ntbPreuParticipacio";
            this.ntbPreuParticipacio.Size = new System.Drawing.Size(124, 26);
            this.ntbPreuParticipacio.TabIndex = 0;
            this.ntbPreuParticipacio.Text = "0 €";
            this.ntbPreuParticipacio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPreuParticipacio.Valor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntbPreuParticipacio.Leave += new System.EventHandler(this.tbPreuParticipacio_Leave);
            // 
            // gbFactorConversor
            // 
            this.gbFactorConversor.Controls.Add(this.ntbFactorConversor);
            this.gbFactorConversor.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFactorConversor.Location = new System.Drawing.Point(441, 4);
            this.gbFactorConversor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbFactorConversor.Name = "gbFactorConversor";
            this.gbFactorConversor.Padding = new System.Windows.Forms.Padding(6);
            this.gbFactorConversor.Size = new System.Drawing.Size(142, 62);
            this.gbFactorConversor.TabIndex = 3;
            this.gbFactorConversor.TabStop = false;
            this.gbFactorConversor.Text = "Factor Conversor";
            this.toolTip1.SetToolTip(this.gbFactorConversor, "És el numero pel que les accions se dividiran(Contrasplit) o multiplicaran(Split)" +
        "");
            // 
            // ntbFactorConversor
            // 
            this.ntbFactorConversor._CapturaEscape = true;
            this.ntbFactorConversor._Format = "#,##0";
            this.ntbFactorConversor._NegatiusEnVermell = false;
            this.ntbFactorConversor._PermetDecimals = false;
            this.ntbFactorConversor._PermetNegatius = false;
            this.ntbFactorConversor._PermetTextNull = false;
            this.ntbFactorConversor.BackColor = System.Drawing.SystemColors.Window;
            this.ntbFactorConversor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbFactorConversor.ForeColor = System.Drawing.Color.Black;
            this.ntbFactorConversor.Location = new System.Drawing.Point(6, 23);
            this.ntbFactorConversor.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ntbFactorConversor.Name = "ntbFactorConversor";
            this.ntbFactorConversor.Size = new System.Drawing.Size(130, 24);
            this.ntbFactorConversor.TabIndex = 0;
            this.ntbFactorConversor.Text = "0";
            this.ntbFactorConversor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbFactorConversor.Valor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntbFactorConversor.Leave += new System.EventHandler(this.tbNumParticipacions_Leave);
            // 
            // btDesaMoviment
            // 
            this.btDesaMoviment.Enabled = false;
            this.btDesaMoviment.Location = new System.Drawing.Point(450, 10);
            this.btDesaMoviment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDesaMoviment.Name = "btDesaMoviment";
            this.btDesaMoviment.Size = new System.Drawing.Size(89, 62);
            this.btDesaMoviment.TabIndex = 2;
            this.btDesaMoviment.Text = "Desa";
            this.btDesaMoviment.UseVisualStyleBackColor = true;
            this.btDesaMoviment.Click += new System.EventHandler(this.btDesaMoviment_Click);
            // 
            // btFes
            // 
            this.btFes.Enabled = false;
            this.btFes.Location = new System.Drawing.Point(169, 10);
            this.btFes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btFes.Name = "btFes";
            this.btFes.Size = new System.Drawing.Size(89, 62);
            this.btFes.TabIndex = 1;
            this.btFes.Text = "Fes";
            this.btFes.UseVisualStyleBackColor = true;
            this.btFes.Click += new System.EventHandler(this.btFes_Click);
            // 
            // btCancelaMoviment
            // 
            this.btCancelaMoviment.Enabled = false;
            this.btCancelaMoviment.Location = new System.Drawing.Point(548, 10);
            this.btCancelaMoviment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btCancelaMoviment.Name = "btCancelaMoviment";
            this.btCancelaMoviment.Size = new System.Drawing.Size(89, 62);
            this.btCancelaMoviment.TabIndex = 3;
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
            this.pnCompraVenda.Controls.Add(this.gbPigVendaReal);
            this.pnCompraVenda.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnCompraVenda.Location = new System.Drawing.Point(3, 23);
            this.pnCompraVenda.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnCompraVenda.Name = "pnCompraVenda";
            this.pnCompraVenda.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.pnCompraVenda.Size = new System.Drawing.Size(638, 146);
            this.pnCompraVenda.TabIndex = 0;
            // 
            // gbDataMoviment
            // 
            this.gbDataMoviment.Controls.Add(this.cData1);
            this.gbDataMoviment.Location = new System.Drawing.Point(3, 4);
            this.gbDataMoviment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDataMoviment.Name = "gbDataMoviment";
            this.gbDataMoviment.Padding = new System.Windows.Forms.Padding(6);
            this.gbDataMoviment.Size = new System.Drawing.Size(142, 62);
            this.gbDataMoviment.TabIndex = 0;
            this.gbDataMoviment.TabStop = false;
            this.gbDataMoviment.Text = "Data";
            // 
            // cData1
            // 
            this.cData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cData1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cData1.Location = new System.Drawing.Point(6, 25);
            this.cData1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cData1.Name = "cData1";
            this.cData1.Size = new System.Drawing.Size(130, 26);
            this.cData1.TabIndex = 0;
            // 
            // ckActivaDataDesti
            // 
            this.ckActivaDataDesti.AutoSize = true;
            this.ckActivaDataDesti.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckActivaDataDesti.Location = new System.Drawing.Point(151, 4);
            this.ckActivaDataDesti.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckActivaDataDesti.Name = "ckActivaDataDesti";
            this.ckActivaDataDesti.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.ckActivaDataDesti.Size = new System.Drawing.Size(142, 46);
            this.ckActivaDataDesti.TabIndex = 1;
            this.ckActivaDataDesti.Text = "Mostra Data Destí";
            this.ckActivaDataDesti.UseVisualStyleBackColor = true;
            this.ckActivaDataDesti.CheckedChanged += new System.EventHandler(this.ckActivaDataDesti_CheckedChanged);
            // 
            // gbParticipacions
            // 
            this.gbParticipacions.Controls.Add(this.tbNumParticipacions);
            this.gbParticipacions.Location = new System.Drawing.Point(299, 4);
            this.gbParticipacions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbParticipacions.Name = "gbParticipacions";
            this.gbParticipacions.Padding = new System.Windows.Forms.Padding(6);
            this.gbParticipacions.Size = new System.Drawing.Size(136, 62);
            this.gbParticipacions.TabIndex = 2;
            this.gbParticipacions.TabStop = false;
            this.gbParticipacions.Text = "Num Parts";
            // 
            // tbNumParticipacions
            // 
            this.tbNumParticipacions._CapturaEscape = true;
            this.tbNumParticipacions._Format = "#,##0.############";
            this.tbNumParticipacions._NegatiusEnVermell = false;
            this.tbNumParticipacions._PermetDecimals = true;
            this.tbNumParticipacions._PermetNegatius = false;
            this.tbNumParticipacions._PermetTextNull = false;
            this.tbNumParticipacions.BackColor = System.Drawing.SystemColors.Window;
            this.tbNumParticipacions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNumParticipacions.ForeColor = System.Drawing.Color.Black;
            this.tbNumParticipacions.Location = new System.Drawing.Point(6, 25);
            this.tbNumParticipacions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbNumParticipacions.Name = "tbNumParticipacions";
            this.tbNumParticipacions.Size = new System.Drawing.Size(124, 26);
            this.tbNumParticipacions.TabIndex = 0;
            this.tbNumParticipacions.Text = "0";
            this.tbNumParticipacions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbNumParticipacions.Valor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbNumParticipacions.Leave += new System.EventHandler(this.tbNumParticipacions_Leave);
            // 
            // gbCanviAplicat
            // 
            this.gbCanviAplicat.Controls.Add(this.tbCanviAplicat);
            this.gbCanviAplicat.Location = new System.Drawing.Point(145, 74);
            this.gbCanviAplicat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbCanviAplicat.Name = "gbCanviAplicat";
            this.gbCanviAplicat.Padding = new System.Windows.Forms.Padding(6);
            this.gbCanviAplicat.Size = new System.Drawing.Size(108, 62);
            this.gbCanviAplicat.TabIndex = 5;
            this.gbCanviAplicat.TabStop = false;
            this.gbCanviAplicat.Text = "Canvi €/x";
            // 
            // tbCanviAplicat
            // 
            this.tbCanviAplicat._CapturaEscape = true;
            this.tbCanviAplicat._Format = "#,##0.######## €";
            this.tbCanviAplicat._NegatiusEnVermell = false;
            this.tbCanviAplicat._PermetDecimals = true;
            this.tbCanviAplicat._PermetNegatius = false;
            this.tbCanviAplicat._PermetTextNull = false;
            this.tbCanviAplicat.BackColor = System.Drawing.SystemColors.Window;
            this.tbCanviAplicat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCanviAplicat.ForeColor = System.Drawing.Color.Black;
            this.tbCanviAplicat.Location = new System.Drawing.Point(6, 25);
            this.tbCanviAplicat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCanviAplicat.Name = "tbCanviAplicat";
            this.tbCanviAplicat.Size = new System.Drawing.Size(96, 26);
            this.tbCanviAplicat.TabIndex = 0;
            this.tbCanviAplicat.Text = "1 €";
            this.tbCanviAplicat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbCanviAplicat.Valor = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tbCanviAplicat.Leave += new System.EventHandler(this.tbPreuParticipacio_Leave);
            // 
            // gbDespeses
            // 
            this.gbDespeses.Controls.Add(this.tbDespeses);
            this.gbDespeses.Location = new System.Drawing.Point(259, 74);
            this.gbDespeses.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDespeses.Name = "gbDespeses";
            this.gbDespeses.Padding = new System.Windows.Forms.Padding(6);
            this.gbDespeses.Size = new System.Drawing.Size(108, 62);
            this.gbDespeses.TabIndex = 6;
            this.gbDespeses.TabStop = false;
            this.gbDespeses.Text = "Despeses";
            // 
            // tbDespeses
            // 
            this.tbDespeses._CapturaEscape = true;
            this.tbDespeses._Format = "#,##0.### €";
            this.tbDespeses._NegatiusEnVermell = false;
            this.tbDespeses._PermetDecimals = true;
            this.tbDespeses._PermetNegatius = false;
            this.tbDespeses._PermetTextNull = false;
            this.tbDespeses.BackColor = System.Drawing.SystemColors.Window;
            this.tbDespeses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDespeses.ForeColor = System.Drawing.Color.Black;
            this.tbDespeses.Location = new System.Drawing.Point(6, 25);
            this.tbDespeses.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDespeses.Name = "tbDespeses";
            this.tbDespeses.Size = new System.Drawing.Size(96, 26);
            this.tbDespeses.TabIndex = 0;
            this.tbDespeses.Text = "0 €";
            this.tbDespeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDespeses.Valor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbDespeses.Leave += new System.EventHandler(this.tbDespeses_Leave);
            // 
            // gbImportTotal
            // 
            this.gbImportTotal.Controls.Add(this.tbImportTotal);
            this.gbImportTotal.Location = new System.Drawing.Point(373, 74);
            this.gbImportTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbImportTotal.Name = "gbImportTotal";
            this.gbImportTotal.Padding = new System.Windows.Forms.Padding(6);
            this.gbImportTotal.Size = new System.Drawing.Size(108, 62);
            this.gbImportTotal.TabIndex = 7;
            this.gbImportTotal.TabStop = false;
            this.gbImportTotal.Text = "Imp. Total";
            // 
            // tbImportTotal
            // 
            this.tbImportTotal._CapturaEscape = true;
            this.tbImportTotal._Format = "#,##0.### €";
            this.tbImportTotal._NegatiusEnVermell = false;
            this.tbImportTotal._PermetDecimals = true;
            this.tbImportTotal._PermetNegatius = false;
            this.tbImportTotal._PermetTextNull = false;
            this.tbImportTotal.BackColor = System.Drawing.SystemColors.Window;
            this.tbImportTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbImportTotal.ForeColor = System.Drawing.Color.Black;
            this.tbImportTotal.Location = new System.Drawing.Point(6, 25);
            this.tbImportTotal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbImportTotal.Name = "tbImportTotal";
            this.tbImportTotal.ReadOnly = true;
            this.tbImportTotal.Size = new System.Drawing.Size(96, 26);
            this.tbImportTotal.TabIndex = 0;
            this.tbImportTotal.Text = "0 €";
            this.tbImportTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbImportTotal.Valor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // gbPigVendaReal
            // 
            this.gbPigVendaReal.Controls.Add(this.ntbPigVendaReal);
            this.gbPigVendaReal.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbPigVendaReal.Location = new System.Drawing.Point(487, 74);
            this.gbPigVendaReal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPigVendaReal.Name = "gbPigVendaReal";
            this.gbPigVendaReal.Padding = new System.Windows.Forms.Padding(6);
            this.gbPigVendaReal.Size = new System.Drawing.Size(108, 62);
            this.gbPigVendaReal.TabIndex = 8;
            this.gbPigVendaReal.TabStop = false;
            this.gbPigVendaReal.Text = "PiG Real";
            // 
            // ntbPigVendaReal
            // 
            this.ntbPigVendaReal._CapturaEscape = true;
            this.ntbPigVendaReal._Format = "#,##0.0 €";
            this.ntbPigVendaReal._NegatiusEnVermell = false;
            this.ntbPigVendaReal._PermetDecimals = true;
            this.ntbPigVendaReal._PermetNegatius = false;
            this.ntbPigVendaReal._PermetTextNull = true;
            this.ntbPigVendaReal.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPigVendaReal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPigVendaReal.ForeColor = System.Drawing.Color.Black;
            this.ntbPigVendaReal.Location = new System.Drawing.Point(6, 25);
            this.ntbPigVendaReal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ntbPigVendaReal.Name = "ntbPigVendaReal";
            this.ntbPigVendaReal.Size = new System.Drawing.Size(96, 26);
            this.ntbPigVendaReal.TabIndex = 0;
            this.ntbPigVendaReal.Text = "0,0 €";
            this.ntbPigVendaReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPigVendaReal.Valor = new decimal(new int[] {
            0,
            0,
            0,
            65536});
            // 
            // gbDescripcio
            // 
            this.gbDescripcio.Controls.Add(this.tbDescripcio);
            this.gbDescripcio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDescripcio.Location = new System.Drawing.Point(3, 169);
            this.gbDescripcio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDescripcio.Name = "gbDescripcio";
            this.gbDescripcio.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDescripcio.Size = new System.Drawing.Size(638, 154);
            this.gbDescripcio.TabIndex = 1;
            this.gbDescripcio.TabStop = false;
            this.gbDescripcio.Text = "Descripció";
            // 
            // tbDescripcio
            // 
            this.tbDescripcio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescripcio.Location = new System.Drawing.Point(3, 23);
            this.tbDescripcio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDescripcio.Multiline = true;
            this.tbDescripcio.Name = "tbDescripcio";
            this.tbDescripcio.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbDescripcio.Size = new System.Drawing.Size(632, 127);
            this.tbDescripcio.TabIndex = 0;
            // 
            // gbEdicio
            // 
            this.gbEdicio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbEdicio.Controls.Add(this.gbDescripcio);
            this.gbEdicio.Controls.Add(this.pnCompraVenda);
            this.gbEdicio.Controls.Add(this.gbTraspas);
            this.gbEdicio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEdicio.Location = new System.Drawing.Point(0, 82);
            this.gbEdicio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbEdicio.Name = "gbEdicio";
            this.gbEdicio.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbEdicio.Size = new System.Drawing.Size(644, 484);
            this.gbEdicio.TabIndex = 1;
            this.gbEdicio.TabStop = false;
            this.gbEdicio.Visible = false;
            // 
            // gbTraspas
            // 
            this.gbTraspas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbTraspas.Controls.Add(this.gbDataDesti);
            this.gbTraspas.Controls.Add(this.gbNumParticipacionsDesti);
            this.gbTraspas.Controls.Add(this.groupBox3);
            this.gbTraspas.Controls.Add(this.groupBox2);
            this.gbTraspas.Controls.Add(this.gbProducteTraspas);
            this.gbTraspas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbTraspas.Location = new System.Drawing.Point(3, 323);
            this.gbTraspas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbTraspas.Name = "gbTraspas";
            this.gbTraspas.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbTraspas.Size = new System.Drawing.Size(638, 157);
            this.gbTraspas.TabIndex = 2;
            this.gbTraspas.TabStop = false;
            this.gbTraspas.Text = "Traspàs";
            this.gbTraspas.Visible = false;
            // 
            // gbDataDesti
            // 
            this.gbDataDesti.Controls.Add(this.cDataDesti);
            this.gbDataDesti.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbDataDesti.Location = new System.Drawing.Point(126, 94);
            this.gbDataDesti.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDataDesti.Name = "gbDataDesti";
            this.gbDataDesti.Padding = new System.Windows.Forms.Padding(6);
            this.gbDataDesti.Size = new System.Drawing.Size(125, 59);
            this.gbDataDesti.TabIndex = 1;
            this.gbDataDesti.TabStop = false;
            this.gbDataDesti.Text = "Data";
            // 
            // cDataDesti
            // 
            this.cDataDesti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cDataDesti.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cDataDesti.Location = new System.Drawing.Point(6, 25);
            this.cDataDesti.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cDataDesti.Name = "cDataDesti";
            this.cDataDesti.Size = new System.Drawing.Size(113, 26);
            this.cDataDesti.TabIndex = 0;
            // 
            // gbNumParticipacionsDesti
            // 
            this.gbNumParticipacionsDesti.Controls.Add(this.tbNumParticipacionsDesti);
            this.gbNumParticipacionsDesti.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbNumParticipacionsDesti.Location = new System.Drawing.Point(251, 94);
            this.gbNumParticipacionsDesti.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbNumParticipacionsDesti.Name = "gbNumParticipacionsDesti";
            this.gbNumParticipacionsDesti.Padding = new System.Windows.Forms.Padding(6);
            this.gbNumParticipacionsDesti.Size = new System.Drawing.Size(128, 59);
            this.gbNumParticipacionsDesti.TabIndex = 2;
            this.gbNumParticipacionsDesti.TabStop = false;
            this.gbNumParticipacionsDesti.Text = "Num Parts";
            // 
            // tbNumParticipacionsDesti
            // 
            this.tbNumParticipacionsDesti._CapturaEscape = true;
            this.tbNumParticipacionsDesti._Format = "#,##0.####";
            this.tbNumParticipacionsDesti._NegatiusEnVermell = false;
            this.tbNumParticipacionsDesti._PermetDecimals = true;
            this.tbNumParticipacionsDesti._PermetNegatius = false;
            this.tbNumParticipacionsDesti._PermetTextNull = false;
            this.tbNumParticipacionsDesti.BackColor = System.Drawing.SystemColors.Window;
            this.tbNumParticipacionsDesti.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNumParticipacionsDesti.ForeColor = System.Drawing.Color.Black;
            this.tbNumParticipacionsDesti.Location = new System.Drawing.Point(6, 25);
            this.tbNumParticipacionsDesti.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbNumParticipacionsDesti.Name = "tbNumParticipacionsDesti";
            this.tbNumParticipacionsDesti.Size = new System.Drawing.Size(116, 26);
            this.tbNumParticipacionsDesti.TabIndex = 0;
            this.tbNumParticipacionsDesti.Text = "0";
            this.tbNumParticipacionsDesti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbNumParticipacionsDesti.Valor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.tbNumParticipacionsDesti.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNumParticipacionsDesti_KeyPress);
            this.tbNumParticipacionsDesti.Leave += new System.EventHandler(this.tbNumParticipacionsDesti_Leave);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ntbPreuParticipacioFonsCompra);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(379, 94);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox3.Size = new System.Drawing.Size(128, 59);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preu Partic";
            // 
            // ntbPreuParticipacioFonsCompra
            // 
            this.ntbPreuParticipacioFonsCompra._CapturaEscape = true;
            this.ntbPreuParticipacioFonsCompra._Format = "#,##0.####### €";
            this.ntbPreuParticipacioFonsCompra._NegatiusEnVermell = false;
            this.ntbPreuParticipacioFonsCompra._PermetDecimals = true;
            this.ntbPreuParticipacioFonsCompra._PermetNegatius = false;
            this.ntbPreuParticipacioFonsCompra._PermetTextNull = false;
            this.ntbPreuParticipacioFonsCompra.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPreuParticipacioFonsCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPreuParticipacioFonsCompra.ForeColor = System.Drawing.Color.Black;
            this.ntbPreuParticipacioFonsCompra.Location = new System.Drawing.Point(6, 25);
            this.ntbPreuParticipacioFonsCompra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ntbPreuParticipacioFonsCompra.Name = "ntbPreuParticipacioFonsCompra";
            this.ntbPreuParticipacioFonsCompra.Size = new System.Drawing.Size(116, 26);
            this.ntbPreuParticipacioFonsCompra.TabIndex = 0;
            this.ntbPreuParticipacioFonsCompra.Text = "0 €";
            this.ntbPreuParticipacioFonsCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPreuParticipacioFonsCompra.Valor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntbPreuParticipacioFonsCompra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ntbPreuParticipacioFonsCompra_KeyPress);
            this.ntbPreuParticipacioFonsCompra.Leave += new System.EventHandler(this.ntbPreuParticipacioFonsCompra_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ntbDespeses);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(507, 94);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox2.Size = new System.Drawing.Size(128, 59);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Despeses";
            // 
            // ntbDespeses
            // 
            this.ntbDespeses._CapturaEscape = true;
            this.ntbDespeses._Format = "#,##0.00 €";
            this.ntbDespeses._NegatiusEnVermell = false;
            this.ntbDespeses._PermetDecimals = true;
            this.ntbDespeses._PermetNegatius = false;
            this.ntbDespeses._PermetTextNull = false;
            this.ntbDespeses.BackColor = System.Drawing.SystemColors.Window;
            this.ntbDespeses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbDespeses.ForeColor = System.Drawing.Color.Black;
            this.ntbDespeses.Location = new System.Drawing.Point(6, 25);
            this.ntbDespeses.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ntbDespeses.Name = "ntbDespeses";
            this.ntbDespeses.ReadOnly = true;
            this.ntbDespeses.Size = new System.Drawing.Size(116, 26);
            this.ntbDespeses.TabIndex = 0;
            this.ntbDespeses.Text = "0,00 €";
            this.ntbDespeses.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbDespeses.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // gbProducteTraspas
            // 
            this.gbProducteTraspas.Controls.Add(this.cProducteTraspas);
            this.gbProducteTraspas.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbProducteTraspas.Location = new System.Drawing.Point(3, 23);
            this.gbProducteTraspas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbProducteTraspas.Name = "gbProducteTraspas";
            this.gbProducteTraspas.Padding = new System.Windows.Forms.Padding(6);
            this.gbProducteTraspas.Size = new System.Drawing.Size(632, 71);
            this.gbProducteTraspas.TabIndex = 0;
            this.gbProducteTraspas.TabStop = false;
            this.gbProducteTraspas.Text = "Producte Destí";
            // 
            // cProducteTraspas
            // 
            this.cProducteTraspas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cProducteTraspas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cProducteTraspas.FormattingEnabled = true;
            this.cProducteTraspas.Location = new System.Drawing.Point(6, 25);
            this.cProducteTraspas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cProducteTraspas.Name = "cProducteTraspas";
            this.cProducteTraspas.Size = new System.Drawing.Size(620, 28);
            this.cProducteTraspas.TabIndex = 0;
            this.cProducteTraspas.SelectedIndexChanged += new System.EventHandler(this.cProducteTraspas_SelectedIndexChanged);
            // 
            // pnMovBotons
            // 
            this.pnMovBotons.Controls.Add(this.gbEdicio);
            this.pnMovBotons.Controls.Add(this.panel3);
            this.pnMovBotons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnMovBotons.Location = new System.Drawing.Point(1139, 0);
            this.pnMovBotons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnMovBotons.MinimumSize = new System.Drawing.Size(644, 512);
            this.pnMovBotons.Name = "pnMovBotons";
            this.pnMovBotons.Size = new System.Drawing.Size(644, 566);
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
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(644, 82);
            this.panel3.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTipusMoviment);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 3, 6, 9);
            this.groupBox1.Size = new System.Drawing.Size(151, 62);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipus Moviment";
            // 
            // cbTipusMoviment
            // 
            this.cbTipusMoviment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTipusMoviment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipusMoviment.Enabled = false;
            this.cbTipusMoviment.FormattingEnabled = true;
            this.cbTipusMoviment.Location = new System.Drawing.Point(6, 22);
            this.cbTipusMoviment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTipusMoviment.Name = "cbTipusMoviment";
            this.cbTipusMoviment.Size = new System.Drawing.Size(139, 28);
            this.cbTipusMoviment.TabIndex = 0;
            this.cbTipusMoviment.SelectedIndexChanged += new System.EventHandler(this.cbTipusMoviment_SelectedIndexChanged);
            // 
            // pnMovTop
            // 
            this.pnMovTop.Controls.Add(this.gestioProductesTabMoviments);
            this.pnMovTop.Controls.Add(this.pnMovBotons);
            this.pnMovTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnMovTop.Location = new System.Drawing.Point(0, 0);
            this.pnMovTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnMovTop.Name = "pnMovTop";
            this.pnMovTop.Size = new System.Drawing.Size(1783, 566);
            this.pnMovTop.TabIndex = 10;
            // 
            // gestioProductesTabMoviments
            // 
            this.gestioProductesTabMoviments._AmbMoviments = true;
            this.gestioProductesTabMoviments._FiltreAnyVisible = true;
            this.gestioProductesTabMoviments._MostraLlistaAmbChecks = false;
            this.gestioProductesTabMoviments._NomesAmbParticipacions = true;
            this.gestioProductesTabMoviments.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gestioProductesTabMoviments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gestioProductesTabMoviments.Location = new System.Drawing.Point(0, 0);
            this.gestioProductesTabMoviments.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gestioProductesTabMoviments.MinimumSize = new System.Drawing.Size(824, 493);
            this.gestioProductesTabMoviments.Name = "gestioProductesTabMoviments";
            this.gestioProductesTabMoviments.Size = new System.Drawing.Size(1139, 566);
            this.gestioProductesTabMoviments.TabIndex = 0;
            this.gestioProductesTabMoviments.EventProducteSeleccionat += new System.EventHandler(this.gestioProductes1_ProducteSeleccionat);
            // 
            // MovimentsTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvMovimentsProd);
            this.Controls.Add(this.pnMovTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MovimentsTab";
            this.Size = new System.Drawing.Size(1783, 749);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimentsProd)).EndInit();
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
            this.gbPigVendaReal.ResumeLayout(false);
            this.gbPigVendaReal.PerformLayout();
            this.gbDescripcio.ResumeLayout(false);
            this.gbDescripcio.PerformLayout();
            this.gbEdicio.ResumeLayout(false);
            this.gbEdicio.PerformLayout();
            this.gbTraspas.ResumeLayout(false);
            this.gbDataDesti.ResumeLayout(false);
            this.gbNumParticipacionsDesti.ResumeLayout(false);
            this.gbNumParticipacionsDesti.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbProducteTraspas.ResumeLayout(false);
            this.pnMovBotons.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.pnMovTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMovimentsProd;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controls.NumericTextBox2 ntbPreuParticipacioFonsCompra;
        private Controls.NumericTextBox2 ntbDespeses;
        private System.Windows.Forms.GroupBox gbPigVendaReal;
        private Controls.NumericTextBox2 ntbPigVendaReal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTipusMoviment;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProducte;
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
    }
}
