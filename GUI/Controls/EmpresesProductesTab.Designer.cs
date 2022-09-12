using System;

namespace Inversions.GUI
{
    partial class EmpresesProductesTab
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
            this.pnCampsProductes = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbTipusProducte = new System.Windows.Forms.GroupBox();
            this.cbTipusProducte = new Controls.ComboBox2();
            this.grMercatProducte = new System.Windows.Forms.GroupBox();
            this.cbMercatProducte = new Controls.ComboBox2();
            this.grMonedaProducte = new System.Windows.Forms.GroupBox();
            this.cbMonedaProducte = new Controls.ComboBox2();
            this.grOrdreGridProducte = new System.Windows.Forms.GroupBox();
            this.ntbOrdreGridProducte = new Controls.NumericTextBox2();
            this.grNomProducte = new System.Windows.Forms.GroupBox();
            this.tbNomProducte = new System.Windows.Forms.TextBox();
            this.grIsinProducte = new System.Windows.Forms.GroupBox();
            this.tbIsinProducte = new System.Windows.Forms.TextBox();
            this.grDescripcioProducte = new System.Windows.Forms.GroupBox();
            this.tbDescripcioProducte = new System.Windows.Forms.TextBox();
            this.pnDesaCanvisProductes = new System.Windows.Forms.Panel();
            this.btCancelaProducte = new System.Windows.Forms.Button();
            this.btEsborraProducte = new System.Windows.Forms.Button();
            this.btEditaProducte = new System.Windows.Forms.Button();
            this.btNouProducte = new System.Windows.Forms.Button();
            this.btDesaProducte = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._OrdreGrid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grEmpresa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpreses)).BeginInit();
            this.pnDesaCanvisEmpreses.SuspendLayout();
            this.grProductes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductes)).BeginInit();
            this.pnCampsProductes.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbTipusProducte.SuspendLayout();
            this.grMercatProducte.SuspendLayout();
            this.grMonedaProducte.SuspendLayout();
            this.grOrdreGridProducte.SuspendLayout();
            this.grNomProducte.SuspendLayout();
            this.grIsinProducte.SuspendLayout();
            this.grDescripcioProducte.SuspendLayout();
            this.pnDesaCanvisProductes.SuspendLayout();
            this.SuspendLayout();
            // 
            // grEmpresa
            // 
            this.grEmpresa.Controls.Add(this.dgvEmpreses);
            this.grEmpresa.Controls.Add(this.pnDesaCanvisEmpreses);
            this.grEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grEmpresa.Location = new System.Drawing.Point(0, 0);
            this.grEmpresa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grEmpresa.Name = "grEmpresa";
            this.grEmpresa.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grEmpresa.Size = new System.Drawing.Size(775, 401);
            this.grEmpresa.TabIndex = 1;
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
            this.grProductes.Location = new System.Drawing.Point(823, 0);
            this.grProductes.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grProductes.Name = "grProductes";
            this.grProductes.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grProductes.Size = new System.Drawing.Size(721, 770);
            this.grProductes.TabIndex = 2;
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
            this.colIsin,
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
            // pnCampsProductes
            // 
            this.pnCampsProductes.Controls.Add(this.panel1);
            this.pnCampsProductes.Controls.Add(this.grOrdreGridProducte);
            this.pnCampsProductes.Controls.Add(this.grNomProducte);
            this.pnCampsProductes.Controls.Add(this.grIsinProducte);
            this.pnCampsProductes.Controls.Add(this.grDescripcioProducte);
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
            // panel1
            // 
            this.panel1.Controls.Add(this.gbTipusProducte);
            this.panel1.Controls.Add(this.grMercatProducte);
            this.panel1.Controls.Add(this.grMonedaProducte);
            this.panel1.Location = new System.Drawing.Point(9, 140);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(363, 79);
            this.panel1.TabIndex = 6;
            // 
            // gbTipusProducte
            // 
            this.gbTipusProducte.Controls.Add(this.cbTipusProducte);
            this.gbTipusProducte.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbTipusProducte.Location = new System.Drawing.Point(257, 5);
            this.gbTipusProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbTipusProducte.Name = "gbTipusProducte";
            this.gbTipusProducte.Padding = new System.Windows.Forms.Padding(6);
            this.gbTipusProducte.Size = new System.Drawing.Size(99, 69);
            this.gbTipusProducte.TabIndex = 4;
            this.gbTipusProducte.TabStop = false;
            this.gbTipusProducte.Text = "Tipus";
            // 
            // cbTipusProducte
            // 
            this.cbTipusProducte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTipusProducte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipusProducte.FormattingEnabled = true;
            this.cbTipusProducte.Location = new System.Drawing.Point(6, 24);
            this.cbTipusProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTipusProducte.Name = "cbTipusProducte";
            this.cbTipusProducte.Size = new System.Drawing.Size(87, 28);
            this.cbTipusProducte.TabIndex = 0;
            this.cbTipusProducte.SelectedIndexChanged += new System.EventHandler(this.cbTipusProducte_SelectedIndexChanged);
            // 
            // grMercatProducte
            // 
            this.grMercatProducte.Controls.Add(this.cbMercatProducte);
            this.grMercatProducte.Dock = System.Windows.Forms.DockStyle.Left;
            this.grMercatProducte.Location = new System.Drawing.Point(131, 5);
            this.grMercatProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grMercatProducte.Name = "grMercatProducte";
            this.grMercatProducte.Padding = new System.Windows.Forms.Padding(6);
            this.grMercatProducte.Size = new System.Drawing.Size(126, 69);
            this.grMercatProducte.TabIndex = 4;
            this.grMercatProducte.TabStop = false;
            this.grMercatProducte.Text = "Mercat";
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
            this.cbMercatProducte.SelectedIndexChanged += new System.EventHandler(this.cbTipusProducte_SelectedIndexChanged);
            // 
            // grMonedaProducte
            // 
            this.grMonedaProducte.Controls.Add(this.cbMonedaProducte);
            this.grMonedaProducte.Dock = System.Windows.Forms.DockStyle.Left;
            this.grMonedaProducte.Location = new System.Drawing.Point(5, 5);
            this.grMonedaProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grMonedaProducte.Name = "grMonedaProducte";
            this.grMonedaProducte.Padding = new System.Windows.Forms.Padding(6);
            this.grMonedaProducte.Size = new System.Drawing.Size(126, 69);
            this.grMonedaProducte.TabIndex = 3;
            this.grMonedaProducte.TabStop = false;
            this.grMonedaProducte.Text = "Moneda";
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
            this.cbMonedaProducte.SelectedIndexChanged += new System.EventHandler(this.cbTipusProducte_SelectedIndexChanged);
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
            this.ntbOrdreGridProducte.TextChanged += new System.EventHandler(this.ntbOrdreGridProducte_TextChanged);
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
            this.tbNomProducte.TextChanged += new System.EventHandler(this.tbNomProducte_TextChanged);
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
            this.tbIsinProducte.TextChanged += new System.EventHandler(this.tbNomProducte_TextChanged);
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
            this.tbDescripcioProducte.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescripcioProducte.Size = new System.Drawing.Size(684, 161);
            this.tbDescripcioProducte.TabIndex = 0;
            this.tbDescripcioProducte.TextChanged += new System.EventHandler(this.tbNomProducte_TextChanged);
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
            // colIsin
            // 
            this.colIsin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colIsin.DataPropertyName = "_Isin";
            this.colIsin.HeaderText = "ISIN";
            this.colIsin.Name = "colIsin";
            this.colIsin.Width = 81;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "_NomProducte";
            this.dataGridViewTextBoxColumn2.HeaderText = "Nom";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // EmpresesProductesTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grProductes);
            this.Controls.Add(this.grEmpresa);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(1464, 819);
            this.Name = "EmpresesProductesTab";
            this.Size = new System.Drawing.Size(1642, 819);
            this.Load += new System.EventHandler(this.EmpresesProductesTab_Load);
            this.grEmpresa.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpreses)).EndInit();
            this.pnDesaCanvisEmpreses.ResumeLayout(false);
            this.grProductes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductes)).EndInit();
            this.pnCampsProductes.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbTipusProducte.ResumeLayout(false);
            this.grMercatProducte.ResumeLayout(false);
            this.grMonedaProducte.ResumeLayout(false);
            this.grOrdreGridProducte.ResumeLayout(false);
            this.grOrdreGridProducte.PerformLayout();
            this.grNomProducte.ResumeLayout(false);
            this.grNomProducte.PerformLayout();
            this.grIsinProducte.ResumeLayout(false);
            this.grIsinProducte.PerformLayout();
            this.grDescripcioProducte.ResumeLayout(false);
            this.grDescripcioProducte.PerformLayout();
            this.pnDesaCanvisProductes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grEmpresa;
        private System.Windows.Forms.DataGridView dgvEmpreses;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn _Nom;
        private System.Windows.Forms.DataGridViewTextBoxColumn _TipusEmpresa;
        private System.Windows.Forms.Panel pnDesaCanvisEmpreses;
        private System.Windows.Forms.Button btCancelaCanvisEmpreses;
        private System.Windows.Forms.Button btDesaCanvisEmpreses;
        private System.Windows.Forms.GroupBox grProductes;
        private System.Windows.Forms.DataGridView dgvProductes;
        private System.Windows.Forms.Panel pnCampsProductes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbTipusProducte;
        private Controls.ComboBox2 cbTipusProducte;
        private System.Windows.Forms.GroupBox grMercatProducte;
        private Controls.ComboBox2 cbMercatProducte;
        private System.Windows.Forms.GroupBox grMonedaProducte;
        private Controls.ComboBox2 cbMonedaProducte;
        private System.Windows.Forms.GroupBox grOrdreGridProducte;
        private Controls.NumericTextBox2 ntbOrdreGridProducte;
        private System.Windows.Forms.GroupBox grNomProducte;
        private System.Windows.Forms.TextBox tbNomProducte;
        private System.Windows.Forms.GroupBox grIsinProducte;
        private System.Windows.Forms.TextBox tbIsinProducte;
        private System.Windows.Forms.GroupBox grDescripcioProducte;
        private System.Windows.Forms.TextBox tbDescripcioProducte;
        private System.Windows.Forms.Panel pnDesaCanvisProductes;
        private System.Windows.Forms.Button btCancelaProducte;
        private System.Windows.Forms.Button btEsborraProducte;
        private System.Windows.Forms.Button btEditaProducte;
        private System.Windows.Forms.Button btNouProducte;
        private System.Windows.Forms.Button btDesaProducte;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn _OrdreGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIsin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

    }
}
