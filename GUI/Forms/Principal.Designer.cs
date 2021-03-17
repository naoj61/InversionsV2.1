namespace Inversions.GUI
{
    partial class Principal
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUsuari = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbUsuaris = new System.Windows.Forms.ComboBox();
            this.tabEmpreses = new System.Windows.Forms.TabPage();
            this.grEmpresa = new System.Windows.Forms.GroupBox();
            this.dgvEmpreses = new System.Windows.Forms.DataGridView();
            this._Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._TipusEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnDesaCanvisEmpreses = new System.Windows.Forms.Panel();
            this.btCancelaCanvisEmpreses = new System.Windows.Forms.Button();
            this.btDesaCanvisEmpreses = new System.Windows.Forms.Button();
            this.grProductes = new System.Windows.Forms.GroupBox();
            this.dgvProductes = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._OrdreGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnCampsProductes = new System.Windows.Forms.Panel();
            this.grOrdreGridProducte = new System.Windows.Forms.GroupBox();
            this.grNomProducte = new System.Windows.Forms.GroupBox();
            this.tbNomProducte = new System.Windows.Forms.TextBox();
            this.grIsinProducte = new System.Windows.Forms.GroupBox();
            this.tbIsinProducte = new System.Windows.Forms.TextBox();
            this.grDescripcioProducte = new System.Windows.Forms.GroupBox();
            this.tbDescripcioProducte = new System.Windows.Forms.TextBox();
            this.grMercatProducte = new System.Windows.Forms.GroupBox();
            this.grMonedaProducte = new System.Windows.Forms.GroupBox();
            this.pnDesaCanvisProductes = new System.Windows.Forms.Panel();
            this.btCancelaProducte = new System.Windows.Forms.Button();
            this.btEsborraProducte = new System.Windows.Forms.Button();
            this.btEditaProducte = new System.Windows.Forms.Button();
            this.btNouProducte = new System.Windows.Forms.Button();
            this.btDesaProducte = new System.Windows.Forms.Button();
            this.tabMoviments = new System.Windows.Forms.TabPage();
            this.tabValoracions = new System.Windows.Forms.TabPage();
            this.tabPerduesGuanys = new System.Windows.Forms.TabPage();
            this.tabGrafiques = new System.Windows.Forms.TabPage();
            this.tabSimulacióVenda = new System.Windows.Forms.TabPage();
            this.ntbOrdreGridProducte = new Controls.NumericTextBox2();
            this.cbMercatProducte = new Controls.ComboBox2();
            this.cbMonedaProducte = new Controls.ComboBox2();
            this.movimentsTab1 = new Inversions.GUI.MovimentsTab();
            this.valoracionsTab1 = new Inversions.GUI.ValoracionsTab();
            this.perduesGuanysTab1 = new Inversions.GUI.PerduesGuanysTab();
            this.grafiquesTab1 = new Inversions.GUI.GrafiquesTab();
            this.simulacióVendaTab1 = new Inversions.GUI.SimulacióVendaTab();
            this.tabControl1.SuspendLayout();
            this.tabUsuari.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabEmpreses.SuspendLayout();
            this.grEmpresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpreses)).BeginInit();
            this.pnDesaCanvisEmpreses.SuspendLayout();
            this.grProductes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductes)).BeginInit();
            this.pnCampsProductes.SuspendLayout();
            this.grOrdreGridProducte.SuspendLayout();
            this.grNomProducte.SuspendLayout();
            this.grIsinProducte.SuspendLayout();
            this.grDescripcioProducte.SuspendLayout();
            this.grMercatProducte.SuspendLayout();
            this.grMonedaProducte.SuspendLayout();
            this.pnDesaCanvisProductes.SuspendLayout();
            this.tabMoviments.SuspendLayout();
            this.tabValoracions.SuspendLayout();
            this.tabPerduesGuanys.SuspendLayout();
            this.tabGrafiques.SuspendLayout();
            this.tabSimulacióVenda.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabUsuari);
            this.tabControl1.Controls.Add(this.tabEmpreses);
            this.tabControl1.Controls.Add(this.tabMoviments);
            this.tabControl1.Controls.Add(this.tabValoracions);
            this.tabControl1.Controls.Add(this.tabPerduesGuanys);
            this.tabControl1.Controls.Add(this.tabGrafiques);
            this.tabControl1.Controls.Add(this.tabSimulacióVenda);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1530, 919);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            this.tabControl1.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Deselecting);
            // 
            // tabUsuari
            // 
            this.tabUsuari.Controls.Add(this.groupBox6);
            this.tabUsuari.Location = new System.Drawing.Point(4, 29);
            this.tabUsuari.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabUsuari.Name = "tabUsuari";
            this.tabUsuari.Size = new System.Drawing.Size(1522, 886);
            this.tabUsuari.TabIndex = 4;
            this.tabUsuari.Text = "Usuari";
            this.tabUsuari.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbUsuaris);
            this.groupBox6.Location = new System.Drawing.Point(28, 51);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox6.Size = new System.Drawing.Size(259, 61);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Usuari";
            // 
            // cbUsuaris
            // 
            this.cbUsuaris.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbUsuaris.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuaris.FormattingEnabled = true;
            this.cbUsuaris.Location = new System.Drawing.Point(6, 23);
            this.cbUsuaris.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbUsuaris.Name = "cbUsuaris";
            this.cbUsuaris.Size = new System.Drawing.Size(247, 28);
            this.cbUsuaris.TabIndex = 0;
            // 
            // tabEmpreses
            // 
            this.tabEmpreses.Controls.Add(this.grEmpresa);
            this.tabEmpreses.Controls.Add(this.grProductes);
            this.tabEmpreses.Location = new System.Drawing.Point(4, 29);
            this.tabEmpreses.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabEmpreses.Name = "tabEmpreses";
            this.tabEmpreses.Size = new System.Drawing.Size(1522, 886);
            this.tabEmpreses.TabIndex = 5;
            this.tabEmpreses.Text = "Empreses/Productes";
            this.tabEmpreses.UseVisualStyleBackColor = true;
            // 
            // grEmpresa
            // 
            this.grEmpresa.Controls.Add(this.dgvEmpreses);
            this.grEmpresa.Controls.Add(this.pnDesaCanvisEmpreses);
            this.grEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grEmpresa.Location = new System.Drawing.Point(9, 21);
            this.grEmpresa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grEmpresa.Name = "grEmpresa";
            this.grEmpresa.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grEmpresa.Size = new System.Drawing.Size(775, 401);
            this.grEmpresa.TabIndex = 0;
            this.grEmpresa.TabStop = false;
            this.grEmpresa.Text = "Empreses";
            // 
            // dgvEmpreses
            // 
            this.dgvEmpreses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpreses.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._Id,
            this._Nom,
            this._TipusEmpresa});
            this.dgvEmpreses.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmpreses.Location = new System.Drawing.Point(3, 22);
            this.dgvEmpreses.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvEmpreses.Name = "dgvEmpreses";
            this.dgvEmpreses.RowTemplate.Height = 24;
            this.dgvEmpreses.Size = new System.Drawing.Size(769, 319);
            this.dgvEmpreses.TabIndex = 0;
            this.dgvEmpreses.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dgvEmpreses_CellValidating);
            this.dgvEmpreses.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpreses_RowEnter);
            this.dgvEmpreses.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvEmpreses_RowValidating);
            this.dgvEmpreses.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.dgvEmpreses_UserDeletedRow);
            // 
            // _Id
            // 
            this._Id.DataPropertyName = "Id";
            this._Id.HeaderText = "Id";
            this._Id.Name = "_Id";
            this._Id.ReadOnly = true;
            this._Id.Width = 50;
            // 
            // _Nom
            // 
            this._Nom.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this._Nom.DataPropertyName = "Nom";
            this._Nom.HeaderText = "Nom";
            this._Nom.Name = "_Nom";
            // 
            // _TipusEmpresa
            // 
            this._TipusEmpresa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this._TipusEmpresa.DataPropertyName = "TipusEmpresa";
            this._TipusEmpresa.HeaderText = "Tipus";
            this._TipusEmpresa.Name = "_TipusEmpresa";
            this._TipusEmpresa.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._TipusEmpresa.Width = 88;
            // 
            // pnDesaCanvisEmpreses
            // 
            this.pnDesaCanvisEmpreses.Controls.Add(this.btCancelaCanvisEmpreses);
            this.pnDesaCanvisEmpreses.Controls.Add(this.btDesaCanvisEmpreses);
            this.pnDesaCanvisEmpreses.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnDesaCanvisEmpreses.Enabled = false;
            this.pnDesaCanvisEmpreses.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnDesaCanvisEmpreses.Location = new System.Drawing.Point(3, 341);
            this.pnDesaCanvisEmpreses.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnDesaCanvisEmpreses.Name = "pnDesaCanvisEmpreses";
            this.pnDesaCanvisEmpreses.Padding = new System.Windows.Forms.Padding(6);
            this.pnDesaCanvisEmpreses.Size = new System.Drawing.Size(769, 56);
            this.pnDesaCanvisEmpreses.TabIndex = 1;
            this.pnDesaCanvisEmpreses.Text = "Canvis pendents de desar";
            // 
            // btCancelaCanvisEmpreses
            // 
            this.btCancelaCanvisEmpreses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelaCanvisEmpreses.Location = new System.Drawing.Point(657, 11);
            this.btCancelaCanvisEmpreses.Margin = new System.Windows.Forms.Padding(0);
            this.btCancelaCanvisEmpreses.Name = "btCancelaCanvisEmpreses";
            this.btCancelaCanvisEmpreses.Size = new System.Drawing.Size(106, 38);
            this.btCancelaCanvisEmpreses.TabIndex = 1;
            this.btCancelaCanvisEmpreses.Text = "Cancel·la";
            this.btCancelaCanvisEmpreses.UseVisualStyleBackColor = true;
            this.btCancelaCanvisEmpreses.Click += new System.EventHandler(this.btCancelaCanvisEmpreses_Click);
            // 
            // btDesaCanvisEmpreses
            // 
            this.btDesaCanvisEmpreses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDesaCanvisEmpreses.Location = new System.Drawing.Point(541, 11);
            this.btDesaCanvisEmpreses.Margin = new System.Windows.Forms.Padding(0);
            this.btDesaCanvisEmpreses.Name = "btDesaCanvisEmpreses";
            this.btDesaCanvisEmpreses.Size = new System.Drawing.Size(106, 38);
            this.btDesaCanvisEmpreses.TabIndex = 0;
            this.btDesaCanvisEmpreses.Text = "Desa";
            this.btDesaCanvisEmpreses.UseVisualStyleBackColor = true;
            this.btDesaCanvisEmpreses.Click += new System.EventHandler(this.btDesaCanvisEmpreses_Click);
            // 
            // grProductes
            // 
            this.grProductes.Controls.Add(this.dgvProductes);
            this.grProductes.Controls.Add(this.pnCampsProductes);
            this.grProductes.Controls.Add(this.pnDesaCanvisProductes);
            this.grProductes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grProductes.Location = new System.Drawing.Point(791, 21);
            this.grProductes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grProductes.Name = "grProductes";
            this.grProductes.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grProductes.Size = new System.Drawing.Size(721, 770);
            this.grProductes.TabIndex = 1;
            this.grProductes.TabStop = false;
            this.grProductes.Text = "Productes";
            // 
            // dgvProductes
            // 
            this.dgvProductes.AllowUserToAddRows = false;
            this.dgvProductes.AllowUserToDeleteRows = false;
            this.dgvProductes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this._OrdreGrid,
            this.dataGridViewTextBoxColumn2});
            this.dgvProductes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProductes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvProductes.Location = new System.Drawing.Point(3, 22);
            this.dgvProductes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvProductes.Name = "dgvProductes";
            this.dgvProductes.RowTemplate.Height = 24;
            this.dgvProductes.Size = new System.Drawing.Size(715, 260);
            this.dgvProductes.TabIndex = 0;
            this.dgvProductes.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductes_RowEnter);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 61;
            // 
            // _OrdreGrid
            // 
            this._OrdreGrid.DataPropertyName = "OrdreGrid";
            this._OrdreGrid.HeaderText = "Ordre Grid";
            this._OrdreGrid.Name = "_OrdreGrid";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "_NomProducte";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nom";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // pnCampsProductes
            // 
            this.pnCampsProductes.Controls.Add(this.grOrdreGridProducte);
            this.pnCampsProductes.Controls.Add(this.grNomProducte);
            this.pnCampsProductes.Controls.Add(this.grIsinProducte);
            this.pnCampsProductes.Controls.Add(this.grDescripcioProducte);
            this.pnCampsProductes.Controls.Add(this.grMercatProducte);
            this.pnCampsProductes.Controls.Add(this.grMonedaProducte);
            this.pnCampsProductes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnCampsProductes.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnCampsProductes.Location = new System.Drawing.Point(3, 282);
            this.pnCampsProductes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnCampsProductes.Name = "pnCampsProductes";
            this.pnCampsProductes.Padding = new System.Windows.Forms.Padding(6);
            this.pnCampsProductes.Size = new System.Drawing.Size(715, 428);
            this.pnCampsProductes.TabIndex = 1;
            this.pnCampsProductes.Text = "Canvis pendents de desar";
            // 
            // grOrdreGridProducte
            // 
            this.grOrdreGridProducte.Controls.Add(this.ntbOrdreGridProducte);
            this.grOrdreGridProducte.Location = new System.Drawing.Point(433, 10);
            this.grOrdreGridProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grOrdreGridProducte.Name = "grOrdreGridProducte";
            this.grOrdreGridProducte.Padding = new System.Windows.Forms.Padding(6);
            this.grOrdreGridProducte.Size = new System.Drawing.Size(116, 69);
            this.grOrdreGridProducte.TabIndex = 1;
            this.grOrdreGridProducte.TabStop = false;
            this.grOrdreGridProducte.Text = "Ordre Grid";
            // 
            // grNomProducte
            // 
            this.grNomProducte.Controls.Add(this.tbNomProducte);
            this.grNomProducte.Location = new System.Drawing.Point(9, 8);
            this.grNomProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grNomProducte.Name = "grNomProducte";
            this.grNomProducte.Padding = new System.Windows.Forms.Padding(6);
            this.grNomProducte.Size = new System.Drawing.Size(417, 69);
            this.grNomProducte.TabIndex = 0;
            this.grNomProducte.TabStop = false;
            this.grNomProducte.Text = "Nom";
            // 
            // tbNomProducte
            // 
            this.tbNomProducte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNomProducte.Location = new System.Drawing.Point(6, 24);
            this.tbNomProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbNomProducte.Name = "tbNomProducte";
            this.tbNomProducte.Size = new System.Drawing.Size(405, 25);
            this.tbNomProducte.TabIndex = 0;
            this.tbNomProducte.TextChanged += new System.EventHandler(this.tbProducte_TextChanged);
            // 
            // grIsinProducte
            // 
            this.grIsinProducte.Controls.Add(this.tbIsinProducte);
            this.grIsinProducte.Location = new System.Drawing.Point(9, 84);
            this.grIsinProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grIsinProducte.Name = "grIsinProducte";
            this.grIsinProducte.Padding = new System.Windows.Forms.Padding(6);
            this.grIsinProducte.Size = new System.Drawing.Size(417, 69);
            this.grIsinProducte.TabIndex = 2;
            this.grIsinProducte.TabStop = false;
            this.grIsinProducte.Text = "ISIN";
            // 
            // tbIsinProducte
            // 
            this.tbIsinProducte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbIsinProducte.Location = new System.Drawing.Point(6, 24);
            this.tbIsinProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbIsinProducte.Name = "tbIsinProducte";
            this.tbIsinProducte.Size = new System.Drawing.Size(405, 25);
            this.tbIsinProducte.TabIndex = 0;
            this.tbIsinProducte.TextChanged += new System.EventHandler(this.tbProducte_TextChanged);
            // 
            // grDescripcioProducte
            // 
            this.grDescripcioProducte.Controls.Add(this.tbDescripcioProducte);
            this.grDescripcioProducte.Location = new System.Drawing.Point(9, 226);
            this.grDescripcioProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grDescripcioProducte.Name = "grDescripcioProducte";
            this.grDescripcioProducte.Padding = new System.Windows.Forms.Padding(6);
            this.grDescripcioProducte.Size = new System.Drawing.Size(696, 191);
            this.grDescripcioProducte.TabIndex = 5;
            this.grDescripcioProducte.TabStop = false;
            this.grDescripcioProducte.Text = "Descripció";
            // 
            // tbDescripcioProducte
            // 
            this.tbDescripcioProducte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescripcioProducte.Location = new System.Drawing.Point(6, 24);
            this.tbDescripcioProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDescripcioProducte.Multiline = true;
            this.tbDescripcioProducte.Name = "tbDescripcioProducte";
            this.tbDescripcioProducte.Size = new System.Drawing.Size(684, 161);
            this.tbDescripcioProducte.TabIndex = 0;
            this.tbDescripcioProducte.TextChanged += new System.EventHandler(this.tbProducte_TextChanged);
            // 
            // grMercatProducte
            // 
            this.grMercatProducte.Controls.Add(this.cbMercatProducte);
            this.grMercatProducte.Location = new System.Drawing.Point(158, 160);
            this.grMercatProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grMercatProducte.Name = "grMercatProducte";
            this.grMercatProducte.Padding = new System.Windows.Forms.Padding(6);
            this.grMercatProducte.Size = new System.Drawing.Size(126, 59);
            this.grMercatProducte.TabIndex = 4;
            this.grMercatProducte.TabStop = false;
            this.grMercatProducte.Text = "Mercat";
            // 
            // grMonedaProducte
            // 
            this.grMonedaProducte.Controls.Add(this.cbMonedaProducte);
            this.grMonedaProducte.Location = new System.Drawing.Point(9, 160);
            this.grMonedaProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grMonedaProducte.Name = "grMonedaProducte";
            this.grMonedaProducte.Padding = new System.Windows.Forms.Padding(6);
            this.grMonedaProducte.Size = new System.Drawing.Size(126, 59);
            this.grMonedaProducte.TabIndex = 3;
            this.grMonedaProducte.TabStop = false;
            this.grMonedaProducte.Text = "Moneda";
            // 
            // pnDesaCanvisProductes
            // 
            this.pnDesaCanvisProductes.Controls.Add(this.btCancelaProducte);
            this.pnDesaCanvisProductes.Controls.Add(this.btEsborraProducte);
            this.pnDesaCanvisProductes.Controls.Add(this.btEditaProducte);
            this.pnDesaCanvisProductes.Controls.Add(this.btNouProducte);
            this.pnDesaCanvisProductes.Controls.Add(this.btDesaProducte);
            this.pnDesaCanvisProductes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnDesaCanvisProductes.Location = new System.Drawing.Point(3, 710);
            this.pnDesaCanvisProductes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnDesaCanvisProductes.Name = "pnDesaCanvisProductes";
            this.pnDesaCanvisProductes.Size = new System.Drawing.Size(715, 56);
            this.pnDesaCanvisProductes.TabIndex = 2;
            // 
            // btCancelaProducte
            // 
            this.btCancelaProducte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancelaProducte.Location = new System.Drawing.Point(598, 11);
            this.btCancelaProducte.Margin = new System.Windows.Forms.Padding(0);
            this.btCancelaProducte.Name = "btCancelaProducte";
            this.btCancelaProducte.Size = new System.Drawing.Size(106, 38);
            this.btCancelaProducte.TabIndex = 3;
            this.btCancelaProducte.Text = "Cancel·la";
            this.btCancelaProducte.UseVisualStyleBackColor = true;
            this.btCancelaProducte.Click += new System.EventHandler(this.btCancelaProducte_Click);
            // 
            // btEsborraProducte
            // 
            this.btEsborraProducte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEsborraProducte.Location = new System.Drawing.Point(128, 11);
            this.btEsborraProducte.Margin = new System.Windows.Forms.Padding(0);
            this.btEsborraProducte.Name = "btEsborraProducte";
            this.btEsborraProducte.Size = new System.Drawing.Size(106, 38);
            this.btEsborraProducte.TabIndex = 0;
            this.btEsborraProducte.Text = "Esborra";
            this.btEsborraProducte.UseVisualStyleBackColor = true;
            this.btEsborraProducte.Click += new System.EventHandler(this.btEsborraProducte_Click);
            // 
            // btEditaProducte
            // 
            this.btEditaProducte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btEditaProducte.Location = new System.Drawing.Point(246, 11);
            this.btEditaProducte.Margin = new System.Windows.Forms.Padding(0);
            this.btEditaProducte.Name = "btEditaProducte";
            this.btEditaProducte.Size = new System.Drawing.Size(106, 38);
            this.btEditaProducte.TabIndex = 1;
            this.btEditaProducte.Text = "Edita";
            this.btEditaProducte.UseVisualStyleBackColor = true;
            this.btEditaProducte.Click += new System.EventHandler(this.btEditaProducte_Click);
            // 
            // btNouProducte
            // 
            this.btNouProducte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btNouProducte.Location = new System.Drawing.Point(10, 11);
            this.btNouProducte.Margin = new System.Windows.Forms.Padding(0);
            this.btNouProducte.Name = "btNouProducte";
            this.btNouProducte.Size = new System.Drawing.Size(106, 38);
            this.btNouProducte.TabIndex = 1;
            this.btNouProducte.Text = "Nou";
            this.btNouProducte.UseVisualStyleBackColor = true;
            this.btNouProducte.Click += new System.EventHandler(this.btNouProducte_Click);
            // 
            // btDesaProducte
            // 
            this.btDesaProducte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btDesaProducte.Location = new System.Drawing.Point(480, 11);
            this.btDesaProducte.Margin = new System.Windows.Forms.Padding(0);
            this.btDesaProducte.Name = "btDesaProducte";
            this.btDesaProducte.Size = new System.Drawing.Size(106, 38);
            this.btDesaProducte.TabIndex = 2;
            this.btDesaProducte.Text = "Desa";
            this.btDesaProducte.UseVisualStyleBackColor = true;
            this.btDesaProducte.Click += new System.EventHandler(this.btDesaProducte_Click);
            // 
            // tabMoviments
            // 
            this.tabMoviments.Controls.Add(this.movimentsTab1);
            this.tabMoviments.Location = new System.Drawing.Point(4, 29);
            this.tabMoviments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMoviments.Name = "tabMoviments";
            this.tabMoviments.Padding = new System.Windows.Forms.Padding(6);
            this.tabMoviments.Size = new System.Drawing.Size(1522, 886);
            this.tabMoviments.TabIndex = 1;
            this.tabMoviments.Text = "Moviments";
            this.tabMoviments.UseVisualStyleBackColor = true;
            // 
            // tabValoracions
            // 
            this.tabValoracions.Controls.Add(this.valoracionsTab1);
            this.tabValoracions.Location = new System.Drawing.Point(4, 29);
            this.tabValoracions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabValoracions.Name = "tabValoracions";
            this.tabValoracions.Size = new System.Drawing.Size(1522, 886);
            this.tabValoracions.TabIndex = 2;
            this.tabValoracions.Text = "Valoracions";
            this.tabValoracions.UseVisualStyleBackColor = true;
            // 
            // tabPerduesGuanys
            // 
            this.tabPerduesGuanys.Controls.Add(this.perduesGuanysTab1);
            this.tabPerduesGuanys.Location = new System.Drawing.Point(4, 29);
            this.tabPerduesGuanys.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPerduesGuanys.Name = "tabPerduesGuanys";
            this.tabPerduesGuanys.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPerduesGuanys.Size = new System.Drawing.Size(1522, 886);
            this.tabPerduesGuanys.TabIndex = 3;
            this.tabPerduesGuanys.Text = "Perdues i Guanys";
            this.tabPerduesGuanys.UseVisualStyleBackColor = true;
            // 
            // tabGrafiques
            // 
            this.tabGrafiques.Controls.Add(this.grafiquesTab1);
            this.tabGrafiques.Location = new System.Drawing.Point(4, 29);
            this.tabGrafiques.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabGrafiques.Name = "tabGrafiques";
            this.tabGrafiques.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabGrafiques.Size = new System.Drawing.Size(1522, 886);
            this.tabGrafiques.TabIndex = 6;
            this.tabGrafiques.Text = "Gràfiques";
            this.tabGrafiques.UseVisualStyleBackColor = true;
            // 
            // tabSimulacióVenda
            // 
            this.tabSimulacióVenda.Controls.Add(this.simulacióVendaTab1);
            this.tabSimulacióVenda.Location = new System.Drawing.Point(4, 29);
            this.tabSimulacióVenda.Name = "tabSimulacióVenda";
            this.tabSimulacióVenda.Padding = new System.Windows.Forms.Padding(3);
            this.tabSimulacióVenda.Size = new System.Drawing.Size(1522, 886);
            this.tabSimulacióVenda.TabIndex = 7;
            this.tabSimulacióVenda.Text = "Simulació Venda";
            this.tabSimulacióVenda.UseVisualStyleBackColor = true;
            // 
            // ntbOrdreGridProducte
            // 
            this.ntbOrdreGridProducte._CapturaEscape = true;
            this.ntbOrdreGridProducte._Format = "0";
            this.ntbOrdreGridProducte._PermetDecimals = true;
            this.ntbOrdreGridProducte._PermetEspais = false;
            this.ntbOrdreGridProducte._PermetNegatius = true;
            this.ntbOrdreGridProducte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbOrdreGridProducte.Location = new System.Drawing.Point(6, 24);
            this.ntbOrdreGridProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ntbOrdreGridProducte.Name = "ntbOrdreGridProducte";
            this.ntbOrdreGridProducte.Size = new System.Drawing.Size(104, 25);
            this.ntbOrdreGridProducte.TabIndex = 0;
            this.ntbOrdreGridProducte.Text = "999";
            this.ntbOrdreGridProducte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbOrdreGridProducte.Valor = 999D;
            this.ntbOrdreGridProducte.TextChanged += new System.EventHandler(this.tbProducte_TextChanged);
            // 
            // cbMercatProducte
            // 
            this.cbMercatProducte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMercatProducte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMercatProducte.FormattingEnabled = true;
            this.cbMercatProducte.Location = new System.Drawing.Point(6, 24);
            this.cbMercatProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbMercatProducte.Name = "cbMercatProducte";
            this.cbMercatProducte.Size = new System.Drawing.Size(114, 28);
            this.cbMercatProducte.TabIndex = 0;
            this.cbMercatProducte.SelectedIndexChanged += new System.EventHandler(this.cbProducte_SelectedIndexChanged);
            // 
            // cbMonedaProducte
            // 
            this.cbMonedaProducte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMonedaProducte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMonedaProducte.FormattingEnabled = true;
            this.cbMonedaProducte.Location = new System.Drawing.Point(6, 24);
            this.cbMonedaProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbMonedaProducte.Name = "cbMonedaProducte";
            this.cbMonedaProducte.Size = new System.Drawing.Size(114, 28);
            this.cbMonedaProducte.TabIndex = 0;
            this.cbMonedaProducte.SelectedIndexChanged += new System.EventHandler(this.cbProducte_SelectedIndexChanged);
            // 
            // movimentsTab1
            // 
            this.movimentsTab1.activaRefresca = false;
            this.movimentsTab1.CausesValidation = false;
            this.movimentsTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movimentsTab1.Location = new System.Drawing.Point(6, 6);
            this.movimentsTab1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.movimentsTab1.Name = "movimentsTab1";
            this.movimentsTab1.Size = new System.Drawing.Size(1510, 874);
            this.movimentsTab1.TabIndex = 0;
            // 
            // valoracionsTab1
            // 
            this.valoracionsTab1.activaRefresca = false;
            this.valoracionsTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valoracionsTab1.Location = new System.Drawing.Point(0, 0);
            this.valoracionsTab1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.valoracionsTab1.MinimumSize = new System.Drawing.Size(1464, 819);
            this.valoracionsTab1.Name = "valoracionsTab1";
            this.valoracionsTab1.Size = new System.Drawing.Size(1522, 886);
            this.valoracionsTab1.TabIndex = 0;
            // 
            // perduesGuanysTab1
            // 
            this.perduesGuanysTab1.activaRefresca = false;
            this.perduesGuanysTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.perduesGuanysTab1.Location = new System.Drawing.Point(3, 4);
            this.perduesGuanysTab1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.perduesGuanysTab1.Name = "perduesGuanysTab1";
            this.perduesGuanysTab1.Size = new System.Drawing.Size(1516, 878);
            this.perduesGuanysTab1.TabIndex = 0;
            // 
            // grafiquesTab1
            // 
            this.grafiquesTab1.activaRefresca = false;
            this.grafiquesTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grafiquesTab1.Location = new System.Drawing.Point(3, 4);
            this.grafiquesTab1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grafiquesTab1.MinimumSize = new System.Drawing.Size(1464, 819);
            this.grafiquesTab1.Name = "grafiquesTab1";
            this.grafiquesTab1.Size = new System.Drawing.Size(1516, 878);
            this.grafiquesTab1.TabIndex = 0;
            // 
            // simulacióVendaTab1
            // 
            this.simulacióVendaTab1.activaRefresca = false;
            this.simulacióVendaTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simulacióVendaTab1.Location = new System.Drawing.Point(3, 3);
            this.simulacióVendaTab1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simulacióVendaTab1.Name = "simulacióVendaTab1";
            this.simulacióVendaTab1.Size = new System.Drawing.Size(1516, 880);
            this.simulacióVendaTab1.TabIndex = 0;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1530, 919);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1522, 761);
            this.Name = "Principal";
            this.Text = "Inversions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Principal_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Principal_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabUsuari.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tabEmpreses.ResumeLayout(false);
            this.grEmpresa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpreses)).EndInit();
            this.pnDesaCanvisEmpreses.ResumeLayout(false);
            this.grProductes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductes)).EndInit();
            this.pnCampsProductes.ResumeLayout(false);
            this.grOrdreGridProducte.ResumeLayout(false);
            this.grOrdreGridProducte.PerformLayout();
            this.grNomProducte.ResumeLayout(false);
            this.grNomProducte.PerformLayout();
            this.grIsinProducte.ResumeLayout(false);
            this.grIsinProducte.PerformLayout();
            this.grDescripcioProducte.ResumeLayout(false);
            this.grDescripcioProducte.PerformLayout();
            this.grMercatProducte.ResumeLayout(false);
            this.grMonedaProducte.ResumeLayout(false);
            this.pnDesaCanvisProductes.ResumeLayout(false);
            this.tabMoviments.ResumeLayout(false);
            this.tabValoracions.ResumeLayout(false);
            this.tabPerduesGuanys.ResumeLayout(false);
            this.tabGrafiques.ResumeLayout(false);
            this.tabSimulacióVenda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMoviments;
        private System.Windows.Forms.DataGridViewComboBoxColumn productesDataGridViewTextBoxColumn;
        private MovimentsTab movimentsTab1;
        private System.Windows.Forms.TabPage tabValoracions;
        private ValoracionsTab valoracionsTab1;
        private System.Windows.Forms.TabPage tabPerduesGuanys;
        private PerduesGuanysTab perduesGuanysTab1;
        private System.Windows.Forms.TabPage tabUsuari;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbUsuaris;
        private System.Windows.Forms.TabPage tabEmpreses;
        private System.Windows.Forms.GroupBox grEmpresa;
        private System.Windows.Forms.DataGridView dgvEmpreses;
        private System.Windows.Forms.Button btDesaCanvisEmpreses;
        private System.Windows.Forms.Panel pnDesaCanvisEmpreses;
        private System.Windows.Forms.Button btCancelaCanvisEmpreses;
        private System.Windows.Forms.GroupBox grProductes;
        private System.Windows.Forms.DataGridView dgvProductes;
        private System.Windows.Forms.Panel pnCampsProductes;
        private System.Windows.Forms.Button btCancelaProducte;
        private System.Windows.Forms.Button btDesaProducte;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TipusEmpresa;
        private System.Windows.Forms.GroupBox grMercatProducte;
        private Controls.ComboBox2 cbMercatProducte;
        private System.Windows.Forms.GroupBox grMonedaProducte;
        private Controls.ComboBox2 cbMonedaProducte;
        private System.Windows.Forms.Panel pnDesaCanvisProductes;
        private System.Windows.Forms.GroupBox grOrdreGridProducte;
        private Controls.NumericTextBox2 ntbOrdreGridProducte;
        private System.Windows.Forms.GroupBox grNomProducte;
        private System.Windows.Forms.TextBox tbNomProducte;
        private System.Windows.Forms.GroupBox grIsinProducte;
        private System.Windows.Forms.TextBox tbIsinProducte;
        private System.Windows.Forms.GroupBox grDescripcioProducte;
        private System.Windows.Forms.TextBox tbDescripcioProducte;
        private System.Windows.Forms.Button btEsborraProducte;
        private System.Windows.Forms.Button btNouProducte;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _OrdreGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.Button btEditaProducte;
        private System.Windows.Forms.TabPage tabGrafiques;
        private GrafiquesTab grafiquesTab1;
        private System.Windows.Forms.TabPage tabSimulacióVenda;
        private SimulacióVendaTab simulacióVendaTab1;
    }
}