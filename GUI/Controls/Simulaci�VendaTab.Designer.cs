using System;

namespace Inversions.GUI
{
    partial class SimulacióVendaTab
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCompresOriginals = new System.Windows.Forms.DataGridView();
            this.IdOrig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCompraOrig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartsUtil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PigOrigen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PigDeLaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValorAct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.ntbDeduccioIrpf = new Controls.NumericTextBox2();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ntbNumParticipacions = new Controls.NumericTextBox2();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ntbPreuParticipacio = new Controls.NumericTextBox2();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.ntbTributaRenda = new Controls.NumericTextBox2();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ntbPigTributa = new Controls.NumericTextBox2();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ntbPerduesAnteriors = new Controls.NumericTextBox2();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ntbImportBrut = new Controls.NumericTextBox2();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.ntbAnyRenda = new Controls.NumericTextBox2();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ntbPig = new Controls.NumericTextBox2();
            this.btSimulacio = new System.Windows.Forms.Button();
            this.btRecalcula = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.productes = new Inversions.GUI.GestioProductes();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompresOriginals)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvCompresOriginals);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 493);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1459, 329);
            this.panel1.TabIndex = 1;
            // 
            // dgvCompresOriginals
            // 
            this.dgvCompresOriginals.AllowUserToAddRows = false;
            this.dgvCompresOriginals.AllowUserToDeleteRows = false;
            this.dgvCompresOriginals.AllowUserToOrderColumns = true;
            this.dgvCompresOriginals.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompresOriginals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCompresOriginals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompresOriginals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdOrig,
            this.Column1,
            this.DataCompraOrig,
            this.DataCompra,
            this.Parts,
            this.PartsUtil,
            this.PigOrigen,
            this.PigDeLaCompra,
            this.ValorAct});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompresOriginals.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvCompresOriginals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompresOriginals.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCompresOriginals.Location = new System.Drawing.Point(812, 0);
            this.dgvCompresOriginals.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCompresOriginals.Name = "dgvCompresOriginals";
            this.dgvCompresOriginals.ReadOnly = true;
            this.dgvCompresOriginals.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvCompresOriginals.RowTemplate.Height = 24;
            this.dgvCompresOriginals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompresOriginals.Size = new System.Drawing.Size(647, 329);
            this.dgvCompresOriginals.TabIndex = 22;
            // 
            // IdOrig
            // 
            this.IdOrig.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.IdOrig.DataPropertyName = "_IdOrig";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.IdOrig.DefaultCellStyle = dataGridViewCellStyle2;
            this.IdOrig.HeaderText = "Id Orig";
            this.IdOrig.Name = "IdOrig";
            this.IdOrig.ReadOnly = true;
            this.IdOrig.Width = 86;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "_FonsOrig";
            this.Column1.HeaderText = "Fons Orig";
            this.Column1.MinimumWidth = 150;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 150;
            // 
            // DataCompraOrig
            // 
            this.DataCompraOrig.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.DataCompraOrig.DataPropertyName = "_DataOrig";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.DataCompraOrig.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataCompraOrig.HeaderText = "Data Orig Compra";
            this.DataCompraOrig.MinimumWidth = 75;
            this.DataCompraOrig.Name = "DataCompraOrig";
            this.DataCompraOrig.ReadOnly = true;
            this.DataCompraOrig.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataCompraOrig.Width = 75;
            // 
            // DataCompra
            // 
            this.DataCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.DataCompra.DataPropertyName = "_DataCompra";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.DataCompra.DefaultCellStyle = dataGridViewCellStyle4;
            this.DataCompra.HeaderText = "Data Compra";
            this.DataCompra.MinimumWidth = 75;
            this.DataCompra.Name = "DataCompra";
            this.DataCompra.ReadOnly = true;
            this.DataCompra.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.DataCompra.Width = 75;
            // 
            // Parts
            // 
            this.Parts.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Parts.DataPropertyName = "_Participacions";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N3";
            dataGridViewCellStyle5.NullValue = null;
            this.Parts.DefaultCellStyle = dataGridViewCellStyle5;
            this.Parts.HeaderText = "Parts";
            this.Parts.Name = "Parts";
            this.Parts.ReadOnly = true;
            this.Parts.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Parts.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Parts.Width = 52;
            // 
            // PartsUtil
            // 
            this.PartsUtil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PartsUtil.DataPropertyName = "_ParticipacionsUtilitzades";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N3";
            this.PartsUtil.DefaultCellStyle = dataGridViewCellStyle6;
            this.PartsUtil.HeaderText = "Parts Util";
            this.PartsUtil.Name = "PartsUtil";
            this.PartsUtil.ReadOnly = true;
            this.PartsUtil.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PartsUtil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PartsUtil.Width = 71;
            // 
            // PigOrigen
            // 
            this.PigOrigen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.PigOrigen.DataPropertyName = "_PigDeLaCompraOrigen";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            this.PigOrigen.DefaultCellStyle = dataGridViewCellStyle7;
            this.PigOrigen.HeaderText = "Pig Origen";
            this.PigOrigen.Name = "PigOrigen";
            this.PigOrigen.ReadOnly = true;
            this.PigOrigen.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PigOrigen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PigOrigen.Width = 5;
            // 
            // PigDeLaCompra
            // 
            this.PigDeLaCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.PigDeLaCompra.DataPropertyName = "_PigDeLaCompra";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.PigDeLaCompra.DefaultCellStyle = dataGridViewCellStyle8;
            this.PigDeLaCompra.HeaderText = "PiG";
            this.PigDeLaCompra.Name = "PigDeLaCompra";
            this.PigDeLaCompra.ReadOnly = true;
            this.PigDeLaCompra.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PigDeLaCompra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PigDeLaCompra.Width = 5;
            // 
            // ValorAct
            // 
            this.ValorAct.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ValorAct.DataPropertyName = "_ValorActual";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "C2";
            this.ValorAct.DefaultCellStyle = dataGridViewCellStyle9;
            this.ValorAct.HeaderText = "Valor Act.";
            this.ValorAct.Name = "ValorAct";
            this.ValorAct.ReadOnly = true;
            this.ValorAct.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ValorAct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ValorAct.Width = 76;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox8);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox9);
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Controls.Add(this.groupBox6);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.btSimulacio);
            this.panel2.Controls.Add(this.btRecalcula);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(812, 329);
            this.panel2.TabIndex = 23;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.ntbDeduccioIrpf);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(635, 99);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(154, 57);
            this.groupBox8.TabIndex = 6;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Deducció IRPF";
            this.toolTip1.SetToolTip(this.groupBox8, "Total a tributar");
            // 
            // ntbDeduccioIrpf
            // 
            this.ntbDeduccioIrpf._CapturaEscape = true;
            this.ntbDeduccioIrpf._Format = "#,##0.00";
            this.ntbDeduccioIrpf._NegatiusEnVermell = false;
            this.ntbDeduccioIrpf._PermetDecimals = true;
            this.ntbDeduccioIrpf._PermetEspais = false;
            this.ntbDeduccioIrpf._PermetNegatius = true;
            this.ntbDeduccioIrpf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbDeduccioIrpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbDeduccioIrpf.Location = new System.Drawing.Point(3, 19);
            this.ntbDeduccioIrpf.Name = "ntbDeduccioIrpf";
            this.ntbDeduccioIrpf.Size = new System.Drawing.Size(148, 26);
            this.ntbDeduccioIrpf.TabIndex = 4;
            this.ntbDeduccioIrpf.Text = "5.500,00";
            this.ntbDeduccioIrpf.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.ntbDeduccioIrpf, "Import que no tributa al IRPF");
            this.ntbDeduccioIrpf.Valor = 5500D;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(447, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(262, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Any Renda=0 -> Perdues Ant=0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ntbNumParticipacions);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(123, 55);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Num, Partic.";
            // 
            // ntbNumParticipacions
            // 
            this.ntbNumParticipacions._CapturaEscape = true;
            this.ntbNumParticipacions._Format = "#,##0.0000";
            this.ntbNumParticipacions._NegatiusEnVermell = false;
            this.ntbNumParticipacions._PermetDecimals = true;
            this.ntbNumParticipacions._PermetEspais = false;
            this.ntbNumParticipacions._PermetNegatius = true;
            this.ntbNumParticipacions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbNumParticipacions.Enabled = false;
            this.ntbNumParticipacions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbNumParticipacions.Location = new System.Drawing.Point(3, 19);
            this.ntbNumParticipacions.Name = "ntbNumParticipacions";
            this.ntbNumParticipacions.Size = new System.Drawing.Size(117, 26);
            this.ntbNumParticipacions.TabIndex = 3;
            this.ntbNumParticipacions.Text = "0,0000";
            this.ntbNumParticipacions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbNumParticipacions.Valor = 0D;
            this.ntbNumParticipacions.Enter += new System.EventHandler(this.ntbNumParticipacions_Enter);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ntbPreuParticipacio);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(161, 33);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(123, 55);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preu Partic.";
            // 
            // ntbPreuParticipacio
            // 
            this.ntbPreuParticipacio._CapturaEscape = true;
            this.ntbPreuParticipacio._Format = "#,##0.000";
            this.ntbPreuParticipacio._NegatiusEnVermell = false;
            this.ntbPreuParticipacio._PermetDecimals = true;
            this.ntbPreuParticipacio._PermetEspais = false;
            this.ntbPreuParticipacio._PermetNegatius = true;
            this.ntbPreuParticipacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPreuParticipacio.Enabled = false;
            this.ntbPreuParticipacio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPreuParticipacio.Location = new System.Drawing.Point(3, 19);
            this.ntbPreuParticipacio.Name = "ntbPreuParticipacio";
            this.ntbPreuParticipacio.Size = new System.Drawing.Size(117, 26);
            this.ntbPreuParticipacio.TabIndex = 3;
            this.ntbPreuParticipacio.Text = "0,000";
            this.ntbPreuParticipacio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPreuParticipacio.Valor = 0D;
            this.ntbPreuParticipacio.Enter += new System.EventHandler(this.ntbPreuParticipacio_Enter);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.ntbTributaRenda);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(635, 162);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(154, 57);
            this.groupBox9.TabIndex = 4;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Tributa Renda";
            this.toolTip1.SetToolTip(this.groupBox9, "PiG - Perdues Ant. - Deducció IRPF");
            // 
            // ntbTributaRenda
            // 
            this.ntbTributaRenda._CapturaEscape = true;
            this.ntbTributaRenda._Format = "#,##0.00";
            this.ntbTributaRenda._NegatiusEnVermell = false;
            this.ntbTributaRenda._PermetDecimals = true;
            this.ntbTributaRenda._PermetEspais = false;
            this.ntbTributaRenda._PermetNegatius = true;
            this.ntbTributaRenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbTributaRenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbTributaRenda.Location = new System.Drawing.Point(3, 19);
            this.ntbTributaRenda.Name = "ntbTributaRenda";
            this.ntbTributaRenda.ReadOnly = true;
            this.ntbTributaRenda.Size = new System.Drawing.Size(148, 26);
            this.ntbTributaRenda.TabIndex = 4;
            this.ntbTributaRenda.Text = "0,00";
            this.ntbTributaRenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbTributaRenda.Valor = 0D;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ntbPigTributa);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(441, 99);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(154, 57);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "P i G Tributa";
            this.toolTip1.SetToolTip(this.groupBox5, "Total a tributar");
            // 
            // ntbPigTributa
            // 
            this.ntbPigTributa._CapturaEscape = true;
            this.ntbPigTributa._Format = "#,##0.00";
            this.ntbPigTributa._NegatiusEnVermell = false;
            this.ntbPigTributa._PermetDecimals = true;
            this.ntbPigTributa._PermetEspais = false;
            this.ntbPigTributa._PermetNegatius = true;
            this.ntbPigTributa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPigTributa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPigTributa.Location = new System.Drawing.Point(3, 19);
            this.ntbPigTributa.Name = "ntbPigTributa";
            this.ntbPigTributa.ReadOnly = true;
            this.ntbPigTributa.Size = new System.Drawing.Size(148, 26);
            this.ntbPigTributa.TabIndex = 4;
            this.ntbPigTributa.Text = "0,00";
            this.ntbPigTributa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPigTributa.Valor = 0D;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ntbPerduesAnteriors);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(566, 33);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(114, 55);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Perdues Ant";
            this.toolTip1.SetToolTip(this.groupBox4, "Perdues dels últims quatre anys desgravables.");
            // 
            // ntbPerduesAnteriors
            // 
            this.ntbPerduesAnteriors._CapturaEscape = true;
            this.ntbPerduesAnteriors._Format = "#,##0.00";
            this.ntbPerduesAnteriors._NegatiusEnVermell = false;
            this.ntbPerduesAnteriors._PermetDecimals = true;
            this.ntbPerduesAnteriors._PermetEspais = false;
            this.ntbPerduesAnteriors._PermetNegatius = true;
            this.ntbPerduesAnteriors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPerduesAnteriors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPerduesAnteriors.Location = new System.Drawing.Point(3, 19);
            this.ntbPerduesAnteriors.Name = "ntbPerduesAnteriors";
            this.ntbPerduesAnteriors.ReadOnly = true;
            this.ntbPerduesAnteriors.Size = new System.Drawing.Size(108, 26);
            this.ntbPerduesAnteriors.TabIndex = 3;
            this.ntbPerduesAnteriors.Text = "0,00";
            this.ntbPerduesAnteriors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPerduesAnteriors.Valor = 0D;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ntbImportBrut);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(228, 99);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(154, 57);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Import Brut";
            // 
            // ntbImportBrut
            // 
            this.ntbImportBrut._CapturaEscape = true;
            this.ntbImportBrut._Format = "#,##0.00";
            this.ntbImportBrut._NegatiusEnVermell = false;
            this.ntbImportBrut._PermetDecimals = true;
            this.ntbImportBrut._PermetEspais = false;
            this.ntbImportBrut._PermetNegatius = true;
            this.ntbImportBrut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbImportBrut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbImportBrut.Location = new System.Drawing.Point(3, 19);
            this.ntbImportBrut.Name = "ntbImportBrut";
            this.ntbImportBrut.ReadOnly = true;
            this.ntbImportBrut.Size = new System.Drawing.Size(148, 26);
            this.ntbImportBrut.TabIndex = 4;
            this.ntbImportBrut.Tag = "";
            this.ntbImportBrut.Text = "0,00";
            this.ntbImportBrut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbImportBrut.Valor = 0D;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.ntbAnyRenda);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(441, 33);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(121, 55);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Any Renda";
            // 
            // ntbAnyRenda
            // 
            this.ntbAnyRenda._CapturaEscape = true;
            this.ntbAnyRenda._Format = "0";
            this.ntbAnyRenda._NegatiusEnVermell = false;
            this.ntbAnyRenda._PermetDecimals = false;
            this.ntbAnyRenda._PermetEspais = false;
            this.ntbAnyRenda._PermetNegatius = false;
            this.ntbAnyRenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbAnyRenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbAnyRenda.Location = new System.Drawing.Point(3, 19);
            this.ntbAnyRenda.Name = "ntbAnyRenda";
            this.ntbAnyRenda.Size = new System.Drawing.Size(115, 26);
            this.ntbAnyRenda.TabIndex = 3;
            this.ntbAnyRenda.Text = "0";
            this.ntbAnyRenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbAnyRenda.Valor = 0D;
            this.ntbAnyRenda.Enter += new System.EventHandler(this.ntbAnyRenda_Enter);
            this.ntbAnyRenda.Validating += new System.ComponentModel.CancelEventHandler(this.ntbAnyRenda_Validating);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ntbPig);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(35, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(154, 57);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "P i G";
            this.toolTip1.SetToolTip(this.groupBox2, "PiG de les participacions de la simulació");
            // 
            // ntbPig
            // 
            this.ntbPig._CapturaEscape = true;
            this.ntbPig._Format = "#,##0.00";
            this.ntbPig._NegatiusEnVermell = false;
            this.ntbPig._PermetDecimals = true;
            this.ntbPig._PermetEspais = false;
            this.ntbPig._PermetNegatius = true;
            this.ntbPig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPig.Location = new System.Drawing.Point(3, 19);
            this.ntbPig.Name = "ntbPig";
            this.ntbPig.ReadOnly = true;
            this.ntbPig.Size = new System.Drawing.Size(148, 26);
            this.ntbPig.TabIndex = 4;
            this.ntbPig.Tag = "";
            this.ntbPig.Text = "0,00";
            this.ntbPig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPig.Valor = 0D;
            // 
            // btSimulacio
            // 
            this.btSimulacio.Enabled = false;
            this.btSimulacio.Location = new System.Drawing.Point(287, 45);
            this.btSimulacio.Name = "btSimulacio";
            this.btSimulacio.Size = new System.Drawing.Size(95, 39);
            this.btSimulacio.TabIndex = 3;
            this.btSimulacio.Text = "Simulació";
            this.btSimulacio.UseVisualStyleBackColor = true;
            this.btSimulacio.Click += new System.EventHandler(this.btSimulacio_Click);
            // 
            // btRecalcula
            // 
            this.btRecalcula.Location = new System.Drawing.Point(687, 45);
            this.btRecalcula.Name = "btRecalcula";
            this.btRecalcula.Size = new System.Drawing.Size(102, 39);
            this.btRecalcula.TabIndex = 3;
            this.btRecalcula.Text = "Recalcula";
            this.btRecalcula.UseVisualStyleBackColor = true;
            this.btRecalcula.Click += new System.EventHandler(this.btRecalcula_Click);
            // 
            // productes
            // 
            this.productes._AmbMoviments = true;
            this.productes._FiltreAnyVisible = false;
            this.productes._MostraLlistaAmbChecks = false;
            this.productes._NomesAmbParticipacions = true;
            this.productes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.productes.Dock = System.Windows.Forms.DockStyle.Top;
            this.productes.Location = new System.Drawing.Point(0, 0);
            this.productes.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.productes.MinimumSize = new System.Drawing.Size(824, 493);
            this.productes.Name = "productes";
            this.productes.Size = new System.Drawing.Size(1459, 493);
            this.productes.TabIndex = 0;
            this.productes.ProducteSeleccionat += new System.EventHandler(this.productes_ProducteSeleccionat);
            // 
            // SimulacióVendaTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.productes);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SimulacióVendaTab";
            this.Size = new System.Drawing.Size(1459, 822);
            this.Load += new System.EventHandler(this.SimulacióVendaTab_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompresOriginals)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GestioProductes productes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btSimulacio;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.NumericTextBox2 ntbNumParticipacions;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controls.NumericTextBox2 ntbPig;
        private System.Windows.Forms.GroupBox groupBox3;
        private Controls.NumericTextBox2 ntbPreuParticipacio;
        private System.Windows.Forms.GroupBox groupBox4;
        private Controls.NumericTextBox2 ntbPerduesAnteriors;
        private System.Windows.Forms.GroupBox groupBox5;
        private Controls.NumericTextBox2 ntbPigTributa;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox6;
        private Controls.NumericTextBox2 ntbAnyRenda;
        private System.Windows.Forms.Button btRecalcula;
        private System.Windows.Forms.GroupBox groupBox7;
        private Controls.NumericTextBox2 ntbImportBrut;
        private System.Windows.Forms.DataGridView dgvCompresOriginals;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrig;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCompraOrig;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parts;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartsUtil;
        private System.Windows.Forms.DataGridViewTextBoxColumn PigOrigen;
        private System.Windows.Forms.DataGridViewTextBoxColumn PigDeLaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorAct;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox8;
        private Controls.NumericTextBox2 ntbDeduccioIrpf;
        private System.Windows.Forms.GroupBox groupBox9;
        private Controls.NumericTextBox2 ntbTributaRenda;
    }
}
