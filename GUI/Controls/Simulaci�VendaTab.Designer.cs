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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvCompresOriginals = new System.Windows.Forms.DataGridView();
            this.IdOrig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fonsOrig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCompraOrig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartsUtil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PigOrigen = new Controls.NumericTextBoxColumn();
            this.PigDeLaCompra = new Controls.NumericTextBoxColumn();
            this.ValorAct = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.ntbDividents = new Controls.NumericTextBox2();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.ntbIngressosExterns = new Controls.NumericTextBox2();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ntbPerduesAnysAnteriors = new Controls.NumericTextBox2();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.ntbPiGAltresProductes = new Controls.NumericTextBox2();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.ntbTramExentAnual = new Controls.NumericTextBox2();
            this.gbPigRealAny = new System.Windows.Forms.GroupBox();
            this.ntbPiGActual = new Controls.NumericTextBox2();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.ntbRestaTramNoTributa = new Controls.NumericTextBox2();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.ntbPartsSaltades = new Controls.NumericTextBox2();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ntbNumParticipacions = new Controls.NumericTextBox2();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ntbPreuParticipacio = new Controls.NumericTextBox2();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.ntbTributaRenda = new Controls.NumericTextBox2();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ntbImportBrut = new Controls.NumericTextBox2();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbAny = new System.Windows.Forms.ComboBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.ntbPigSimulacio = new Controls.NumericTextBox2();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ntbPigOrigSimulacio = new Controls.NumericTextBox2();
            this.btRecalcula = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ctrProductes = new Inversions.GUI.GestioProductes();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompresOriginals)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.gbPigRealAny.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox12.SuspendLayout();
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
            this.panel1.TabIndex = 0;
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
            this.Id,
            this.fonsOrig,
            this.DataCompraOrig,
            this.DataCompra,
            this.Parts,
            this.PartsUtil,
            this.PigOrigen,
            this.PigDeLaCompra,
            this.ValorAct});
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompresOriginals.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvCompresOriginals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompresOriginals.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCompresOriginals.Location = new System.Drawing.Point(673, 0);
            this.dgvCompresOriginals.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCompresOriginals.Name = "dgvCompresOriginals";
            this.dgvCompresOriginals.ReadOnly = true;
            this.dgvCompresOriginals.RowHeadersVisible = false;
            this.dgvCompresOriginals.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvCompresOriginals.RowTemplate.Height = 24;
            this.dgvCompresOriginals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompresOriginals.Size = new System.Drawing.Size(786, 329);
            this.dgvCompresOriginals.TabIndex = 1;
            // 
            // IdOrig
            // 
            this.IdOrig.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.IdOrig.DataPropertyName = "_IdOrig";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.NullValue = null;
            this.IdOrig.DefaultCellStyle = dataGridViewCellStyle2;
            this.IdOrig.HeaderText = "Id Orig";
            this.IdOrig.MinimumWidth = 40;
            this.IdOrig.Name = "IdOrig";
            this.IdOrig.ReadOnly = true;
            this.IdOrig.Width = 40;
            // 
            // Id
            // 
            this.Id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.Id.DataPropertyName = "_Id";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.NullValue = null;
            this.Id.DefaultCellStyle = dataGridViewCellStyle3;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 5;
            // 
            // fonsOrig
            // 
            this.fonsOrig.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fonsOrig.DataPropertyName = "_FonsOrig";
            this.fonsOrig.HeaderText = "Fons Orig";
            this.fonsOrig.MinimumWidth = 75;
            this.fonsOrig.Name = "fonsOrig";
            this.fonsOrig.ReadOnly = true;
            // 
            // DataCompraOrig
            // 
            this.DataCompraOrig.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.DataCompraOrig.DataPropertyName = "_DataOrig";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.DataCompraOrig.DefaultCellStyle = dataGridViewCellStyle4;
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
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.DataCompra.DefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N3";
            dataGridViewCellStyle6.NullValue = null;
            this.Parts.DefaultCellStyle = dataGridViewCellStyle6;
            this.Parts.HeaderText = "Parts";
            this.Parts.Name = "Parts";
            this.Parts.ReadOnly = true;
            this.Parts.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Parts.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Parts.ToolTipText = "Totes les participacions del moviment. (Poden estar venudes)";
            this.Parts.Width = 52;
            // 
            // PartsUtil
            // 
            this.PartsUtil.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PartsUtil.DataPropertyName = "_ParticipacionsUtilitzades";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Lime;
            dataGridViewCellStyle7.Format = "N5";
            this.PartsUtil.DefaultCellStyle = dataGridViewCellStyle7;
            this.PartsUtil.HeaderText = "Parts Util";
            this.PartsUtil.Name = "PartsUtil";
            this.PartsUtil.ReadOnly = true;
            this.PartsUtil.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PartsUtil.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PartsUtil.ToolTipText = "Participacions utilitzades en la simulació.";
            this.PartsUtil.Width = 71;
            // 
            // PigOrigen
            // 
            this.PigOrigen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.PigOrigen.DataPropertyName = "_PigDeLaCompraOrigen";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            this.PigOrigen.DefaultCellStyle = dataGridViewCellStyle8;
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "C2";
            dataGridViewCellStyle9.NullValue = null;
            this.PigDeLaCompra.DefaultCellStyle = dataGridViewCellStyle9;
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Format = "C2";
            this.ValorAct.DefaultCellStyle = dataGridViewCellStyle10;
            this.ValorAct.HeaderText = "Valor Act.";
            this.ValorAct.Name = "ValorAct";
            this.ValorAct.ReadOnly = true;
            this.ValorAct.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ValorAct.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ValorAct.Width = 76;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox10);
            this.panel2.Controls.Add(this.groupBox5);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Controls.Add(this.groupBox13);
            this.panel2.Controls.Add(this.groupBox11);
            this.panel2.Controls.Add(this.gbPigRealAny);
            this.panel2.Controls.Add(this.groupBox8);
            this.panel2.Controls.Add(this.groupBox14);
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox9);
            this.panel2.Controls.Add(this.groupBox7);
            this.panel2.Controls.Add(this.groupBox6);
            this.panel2.Controls.Add(this.groupBox12);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.btRecalcula);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(673, 329);
            this.panel2.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.ntbDividents);
            this.groupBox10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox10.Location = new System.Drawing.Point(504, 142);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(156, 57);
            this.groupBox10.TabIndex = 13;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Dividents";
            // 
            // ntbDividents
            // 
            this.ntbDividents._CapturaEscape = true;
            this.ntbDividents._Format = "#,##0.00 €";
            this.ntbDividents._NegatiusEnVermell = false;
            this.ntbDividents._PermetDecimals = true;
            this.ntbDividents._PermetNegatius = true;
            this.ntbDividents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbDividents.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbDividents.Location = new System.Drawing.Point(3, 19);
            this.ntbDividents.Name = "ntbDividents";
            this.ntbDividents.ReadOnly = true;
            this.ntbDividents.Size = new System.Drawing.Size(150, 26);
            this.ntbDividents.TabIndex = 0;
            this.ntbDividents.Text = "0,00 €";
            this.ntbDividents.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbDividents.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.ntbIngressosExterns);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(504, 77);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(156, 57);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Ingressos Externs";
            // 
            // ntbIngressosExterns
            // 
            this.ntbIngressosExterns._CapturaEscape = true;
            this.ntbIngressosExterns._Format = "#,##0.00 €";
            this.ntbIngressosExterns._NegatiusEnVermell = false;
            this.ntbIngressosExterns._PermetDecimals = true;
            this.ntbIngressosExterns._PermetNegatius = true;
            this.ntbIngressosExterns.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbIngressosExterns.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbIngressosExterns.Location = new System.Drawing.Point(3, 19);
            this.ntbIngressosExterns.Name = "ntbIngressosExterns";
            this.ntbIngressosExterns.ReadOnly = true;
            this.ntbIngressosExterns.Size = new System.Drawing.Size(150, 26);
            this.ntbIngressosExterns.TabIndex = 0;
            this.ntbIngressosExterns.Text = "0,00 €";
            this.ntbIngressosExterns.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbIngressosExterns.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ntbPerduesAnysAnteriors);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(504, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(156, 57);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Perdues Anteriors";
            // 
            // ntbPerduesAnysAnteriors
            // 
            this.ntbPerduesAnysAnteriors._CapturaEscape = true;
            this.ntbPerduesAnysAnteriors._Format = "#,##0.00 €";
            this.ntbPerduesAnysAnteriors._NegatiusEnVermell = false;
            this.ntbPerduesAnysAnteriors._PermetDecimals = true;
            this.ntbPerduesAnysAnteriors._PermetNegatius = true;
            this.ntbPerduesAnysAnteriors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPerduesAnysAnteriors.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPerduesAnysAnteriors.Location = new System.Drawing.Point(3, 19);
            this.ntbPerduesAnysAnteriors.Name = "ntbPerduesAnysAnteriors";
            this.ntbPerduesAnysAnteriors.ReadOnly = true;
            this.ntbPerduesAnysAnteriors.Size = new System.Drawing.Size(150, 26);
            this.ntbPerduesAnysAnteriors.TabIndex = 0;
            this.ntbPerduesAnysAnteriors.Text = "0,00 €";
            this.ntbPerduesAnysAnteriors.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPerduesAnysAnteriors.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.ntbPiGAltresProductes);
            this.groupBox13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox13.Location = new System.Drawing.Point(331, 142);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(156, 57);
            this.groupBox13.TabIndex = 12;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "PiG D\'altre producte";
            this.toolTip1.SetToolTip(this.groupBox13, "Si vull acumular els PiGs de més d\'un producte, poso aquí limport dels altres.");
            // 
            // ntbPiGAltresProductes
            // 
            this.ntbPiGAltresProductes._CapturaEscape = true;
            this.ntbPiGAltresProductes._Format = "#,##0.00 €";
            this.ntbPiGAltresProductes._NegatiusEnVermell = false;
            this.ntbPiGAltresProductes._PermetDecimals = true;
            this.ntbPiGAltresProductes._PermetNegatius = false;
            this.ntbPiGAltresProductes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPiGAltresProductes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPiGAltresProductes.Location = new System.Drawing.Point(3, 19);
            this.ntbPiGAltresProductes.Name = "ntbPiGAltresProductes";
            this.ntbPiGAltresProductes.Size = new System.Drawing.Size(150, 26);
            this.ntbPiGAltresProductes.TabIndex = 0;
            this.ntbPiGAltresProductes.Text = "0,00 €";
            this.ntbPiGAltresProductes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPiGAltresProductes.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.ntbPiGAltresProductes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ntb_KeyPress);
            this.ntbPiGAltresProductes.Validating += new System.ComponentModel.CancelEventHandler(this.ntb_Validating);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.ntbTramExentAnual);
            this.groupBox11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox11.Location = new System.Drawing.Point(331, 12);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(156, 57);
            this.groupBox11.TabIndex = 8;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Exent Anual";
            this.toolTip1.SetToolTip(this.groupBox11, "És l\'import que no tributa marcat per Hidenda");
            // 
            // ntbTramExentAnual
            // 
            this.ntbTramExentAnual._CapturaEscape = true;
            this.ntbTramExentAnual._Format = "#,##0.00 €";
            this.ntbTramExentAnual._NegatiusEnVermell = false;
            this.ntbTramExentAnual._PermetDecimals = true;
            this.ntbTramExentAnual._PermetNegatius = false;
            this.ntbTramExentAnual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbTramExentAnual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbTramExentAnual.Location = new System.Drawing.Point(3, 19);
            this.ntbTramExentAnual.Name = "ntbTramExentAnual";
            this.ntbTramExentAnual.Size = new System.Drawing.Size(150, 26);
            this.ntbTramExentAnual.TabIndex = 0;
            this.ntbTramExentAnual.Text = "0,00 €";
            this.ntbTramExentAnual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbTramExentAnual.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            this.ntbTramExentAnual.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ntb_KeyPress);
            this.ntbTramExentAnual.Validating += new System.ComponentModel.CancelEventHandler(this.ntb_Validating);
            // 
            // gbPigRealAny
            // 
            this.gbPigRealAny.Controls.Add(this.ntbPiGActual);
            this.gbPigRealAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPigRealAny.Location = new System.Drawing.Point(331, 77);
            this.gbPigRealAny.Name = "gbPigRealAny";
            this.gbPigRealAny.Size = new System.Drawing.Size(156, 57);
            this.gbPigRealAny.TabIndex = 10;
            this.gbPigRealAny.TabStop = false;
            this.gbPigRealAny.Text = "PiG Any: ";
            this.toolTip1.SetToolTip(this.gbPigRealAny, "És el PiG de les vendes realitzades en l\'any");
            // 
            // ntbPiGActual
            // 
            this.ntbPiGActual._CapturaEscape = true;
            this.ntbPiGActual._Format = "#,##0.00 €";
            this.ntbPiGActual._NegatiusEnVermell = false;
            this.ntbPiGActual._PermetDecimals = true;
            this.ntbPiGActual._PermetNegatius = true;
            this.ntbPiGActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPiGActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPiGActual.Location = new System.Drawing.Point(3, 19);
            this.ntbPiGActual.Name = "ntbPiGActual";
            this.ntbPiGActual.ReadOnly = true;
            this.ntbPiGActual.Size = new System.Drawing.Size(150, 26);
            this.ntbPiGActual.TabIndex = 0;
            this.ntbPiGActual.Text = "0,00 €";
            this.ntbPiGActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPiGActual.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.ntbRestaTramNoTributa);
            this.groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox8.Location = new System.Drawing.Point(331, 207);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(156, 57);
            this.groupBox8.TabIndex = 14;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Exent Restant";
            this.toolTip1.SetToolTip(this.groupBox8, "Import restant de la part exent de tributar.");
            // 
            // ntbRestaTramNoTributa
            // 
            this.ntbRestaTramNoTributa._CapturaEscape = true;
            this.ntbRestaTramNoTributa._Format = "#,##0.00 €";
            this.ntbRestaTramNoTributa._NegatiusEnVermell = false;
            this.ntbRestaTramNoTributa._PermetDecimals = true;
            this.ntbRestaTramNoTributa._PermetNegatius = true;
            this.ntbRestaTramNoTributa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbRestaTramNoTributa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbRestaTramNoTributa.Location = new System.Drawing.Point(3, 19);
            this.ntbRestaTramNoTributa.Name = "ntbRestaTramNoTributa";
            this.ntbRestaTramNoTributa.ReadOnly = true;
            this.ntbRestaTramNoTributa.Size = new System.Drawing.Size(150, 26);
            this.ntbRestaTramNoTributa.TabIndex = 0;
            this.ntbRestaTramNoTributa.Text = "0,00 €";
            this.ntbRestaTramNoTributa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.ntbRestaTramNoTributa, "Import que no tributa al IRPF. Inclou perdues anys anteriors i dividents.");
            this.ntbRestaTramNoTributa.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.ntbPartsSaltades);
            this.groupBox14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox14.Location = new System.Drawing.Point(11, 142);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(135, 57);
            this.groupBox14.TabIndex = 4;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Parts Saltades";
            this.toolTip1.SetToolTip(this.groupBox14, "Salta les participacions més antigues, fa com si estiguessin venudes.\r\nÉs per no " +
        "haver de fer un traspàs simulat per veure el PiG de les més noves");
            // 
            // ntbPartsSaltades
            // 
            this.ntbPartsSaltades._CapturaEscape = true;
            this.ntbPartsSaltades._Format = "#,##0.0000";
            this.ntbPartsSaltades._NegatiusEnVermell = false;
            this.ntbPartsSaltades._PermetDecimals = true;
            this.ntbPartsSaltades._PermetNegatius = false;
            this.ntbPartsSaltades.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPartsSaltades.Enabled = false;
            this.ntbPartsSaltades.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPartsSaltades.Location = new System.Drawing.Point(3, 19);
            this.ntbPartsSaltades.Name = "ntbPartsSaltades";
            this.ntbPartsSaltades.Size = new System.Drawing.Size(129, 26);
            this.ntbPartsSaltades.TabIndex = 0;
            this.ntbPartsSaltades.Text = "0,0000";
            this.ntbPartsSaltades.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPartsSaltades.Valor = new decimal(new int[] {
            0,
            0,
            0,
            262144});
            this.ntbPartsSaltades.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ntb_KeyPress);
            this.ntbPartsSaltades.Validating += new System.ComponentModel.CancelEventHandler(this.ntb_Validating);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ntbNumParticipacions);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(11, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(135, 57);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Num, Parts.";
            // 
            // ntbNumParticipacions
            // 
            this.ntbNumParticipacions._CapturaEscape = true;
            this.ntbNumParticipacions._Format = "#,##0.0000";
            this.ntbNumParticipacions._NegatiusEnVermell = false;
            this.ntbNumParticipacions._PermetDecimals = true;
            this.ntbNumParticipacions._PermetNegatius = false;
            this.ntbNumParticipacions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbNumParticipacions.Enabled = false;
            this.ntbNumParticipacions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbNumParticipacions.Location = new System.Drawing.Point(3, 19);
            this.ntbNumParticipacions.Name = "ntbNumParticipacions";
            this.ntbNumParticipacions.Size = new System.Drawing.Size(129, 26);
            this.ntbNumParticipacions.TabIndex = 0;
            this.ntbNumParticipacions.Text = "0,0000";
            this.ntbNumParticipacions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbNumParticipacions.Valor = new decimal(new int[] {
            0,
            0,
            0,
            262144});
            this.ntbNumParticipacions.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ntb_KeyPress);
            this.ntbNumParticipacions.Validating += new System.ComponentModel.CancelEventHandler(this.ntb_Validating);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ntbPreuParticipacio);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(166, 77);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(135, 57);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preu Partic.";
            // 
            // ntbPreuParticipacio
            // 
            this.ntbPreuParticipacio._CapturaEscape = true;
            this.ntbPreuParticipacio._Format = "#,##0.000 €";
            this.ntbPreuParticipacio._NegatiusEnVermell = false;
            this.ntbPreuParticipacio._PermetDecimals = true;
            this.ntbPreuParticipacio._PermetNegatius = false;
            this.ntbPreuParticipacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPreuParticipacio.Enabled = false;
            this.ntbPreuParticipacio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPreuParticipacio.Location = new System.Drawing.Point(3, 19);
            this.ntbPreuParticipacio.Name = "ntbPreuParticipacio";
            this.ntbPreuParticipacio.Size = new System.Drawing.Size(129, 26);
            this.ntbPreuParticipacio.TabIndex = 0;
            this.ntbPreuParticipacio.Text = "0,000 €";
            this.ntbPreuParticipacio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPreuParticipacio.Valor = new decimal(new int[] {
            0,
            0,
            0,
            196608});
            this.ntbPreuParticipacio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ntb_KeyPress);
            this.ntbPreuParticipacio.Validating += new System.ComponentModel.CancelEventHandler(this.ntb_Validating);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.ntbTributaRenda);
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.Location = new System.Drawing.Point(504, 207);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(156, 57);
            this.groupBox9.TabIndex = 15;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Tributa Renda";
            this.toolTip1.SetToolTip(this.groupBox9, "Tram exent + Perdues Ant. - PiG Actual - Dividents - PiG Simulació");
            // 
            // ntbTributaRenda
            // 
            this.ntbTributaRenda._CapturaEscape = true;
            this.ntbTributaRenda._Format = "#,##0.00 €";
            this.ntbTributaRenda._NegatiusEnVermell = false;
            this.ntbTributaRenda._PermetDecimals = true;
            this.ntbTributaRenda._PermetNegatius = true;
            this.ntbTributaRenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbTributaRenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbTributaRenda.Location = new System.Drawing.Point(3, 19);
            this.ntbTributaRenda.Name = "ntbTributaRenda";
            this.ntbTributaRenda.ReadOnly = true;
            this.ntbTributaRenda.Size = new System.Drawing.Size(150, 26);
            this.ntbTributaRenda.TabIndex = 0;
            this.ntbTributaRenda.Text = "0,00 €";
            this.ntbTributaRenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbTributaRenda.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ntbImportBrut);
            this.groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox7.Location = new System.Drawing.Point(166, 142);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(135, 57);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Import Brut";
            this.toolTip1.SetToolTip(this.groupBox7, "Import de la venda");
            // 
            // ntbImportBrut
            // 
            this.ntbImportBrut._CapturaEscape = true;
            this.ntbImportBrut._Format = "#,##0.00 €";
            this.ntbImportBrut._NegatiusEnVermell = false;
            this.ntbImportBrut._PermetDecimals = true;
            this.ntbImportBrut._PermetNegatius = true;
            this.ntbImportBrut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbImportBrut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbImportBrut.Location = new System.Drawing.Point(3, 19);
            this.ntbImportBrut.Name = "ntbImportBrut";
            this.ntbImportBrut.ReadOnly = true;
            this.ntbImportBrut.Size = new System.Drawing.Size(129, 26);
            this.ntbImportBrut.TabIndex = 0;
            this.ntbImportBrut.Tag = "";
            this.ntbImportBrut.Text = "0,00 €";
            this.ntbImportBrut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbImportBrut.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbAny);
            this.groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox6.Location = new System.Drawing.Point(11, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(109, 55);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Any Renda";
            this.toolTip1.SetToolTip(this.groupBox6, "Any Renda");
            // 
            // cbAny
            // 
            this.cbAny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbAny.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAny.FormattingEnabled = true;
            this.cbAny.Location = new System.Drawing.Point(3, 19);
            this.cbAny.Name = "cbAny";
            this.cbAny.Size = new System.Drawing.Size(103, 25);
            this.cbAny.TabIndex = 0;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.ntbPigSimulacio);
            this.groupBox12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox12.Location = new System.Drawing.Point(11, 207);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(135, 57);
            this.groupBox12.TabIndex = 6;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "P i G Prod";
            this.toolTip1.SetToolTip(this.groupBox12, "PiG actual de la simulació");
            // 
            // ntbPigSimulacio
            // 
            this.ntbPigSimulacio._CapturaEscape = true;
            this.ntbPigSimulacio._Format = "#,##0.00 €";
            this.ntbPigSimulacio._NegatiusEnVermell = false;
            this.ntbPigSimulacio._PermetDecimals = true;
            this.ntbPigSimulacio._PermetNegatius = true;
            this.ntbPigSimulacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPigSimulacio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPigSimulacio.Location = new System.Drawing.Point(3, 19);
            this.ntbPigSimulacio.Name = "ntbPigSimulacio";
            this.ntbPigSimulacio.ReadOnly = true;
            this.ntbPigSimulacio.Size = new System.Drawing.Size(129, 26);
            this.ntbPigSimulacio.TabIndex = 0;
            this.ntbPigSimulacio.Tag = "";
            this.ntbPigSimulacio.Text = "0,00 €";
            this.ntbPigSimulacio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPigSimulacio.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ntbPigOrigSimulacio);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(166, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(135, 57);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "P i G Orig";
            this.toolTip1.SetToolTip(this.groupBox2, "PiG origen de la simulació");
            // 
            // ntbPigOrigSimulacio
            // 
            this.ntbPigOrigSimulacio._CapturaEscape = true;
            this.ntbPigOrigSimulacio._Format = "#,##0.00 €";
            this.ntbPigOrigSimulacio._NegatiusEnVermell = false;
            this.ntbPigOrigSimulacio._PermetDecimals = true;
            this.ntbPigOrigSimulacio._PermetNegatius = true;
            this.ntbPigOrigSimulacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPigOrigSimulacio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPigOrigSimulacio.Location = new System.Drawing.Point(3, 19);
            this.ntbPigOrigSimulacio.Name = "ntbPigOrigSimulacio";
            this.ntbPigOrigSimulacio.ReadOnly = true;
            this.ntbPigOrigSimulacio.Size = new System.Drawing.Size(129, 26);
            this.ntbPigOrigSimulacio.TabIndex = 0;
            this.ntbPigOrigSimulacio.Tag = "";
            this.ntbPigOrigSimulacio.Text = "0,00 €";
            this.ntbPigOrigSimulacio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPigOrigSimulacio.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // btRecalcula
            // 
            this.btRecalcula.Location = new System.Drawing.Point(183, 21);
            this.btRecalcula.Name = "btRecalcula";
            this.btRecalcula.Size = new System.Drawing.Size(102, 39);
            this.btRecalcula.TabIndex = 1;
            this.btRecalcula.Text = "Recalcula";
            this.btRecalcula.UseVisualStyleBackColor = true;
            this.btRecalcula.Click += new System.EventHandler(this.btRecalcula_Click);
            // 
            // ctrProductes
            // 
            this.ctrProductes._AmbMoviments = true;
            this.ctrProductes._FiltreAnyVisible = false;
            this.ctrProductes._MostraLlistaAmbChecks = false;
            this.ctrProductes._NomesAmbParticipacions = true;
            this.ctrProductes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ctrProductes.Dock = System.Windows.Forms.DockStyle.Top;
            this.ctrProductes.Location = new System.Drawing.Point(0, 0);
            this.ctrProductes.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ctrProductes.MinimumSize = new System.Drawing.Size(824, 493);
            this.ctrProductes.Name = "ctrProductes";
            this.ctrProductes.Size = new System.Drawing.Size(1459, 493);
            this.ctrProductes.TabIndex = 1;
            this.ctrProductes.EventProducteSeleccionat += new System.EventHandler(this.productes_ProducteSeleccionat);
            // 
            // SimulacióVendaTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ctrProductes);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SimulacióVendaTab";
            this.Size = new System.Drawing.Size(1459, 822);
            this.Load += new System.EventHandler(this.simulacióVendaTab_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompresOriginals)).EndInit();
            this.panel2.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.gbPigRealAny.ResumeLayout(false);
            this.gbPigRealAny.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GestioProductes ctrProductes;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.NumericTextBox2 ntbNumParticipacions;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controls.NumericTextBox2 ntbPigOrigSimulacio;
        private System.Windows.Forms.GroupBox groupBox3;
        private Controls.NumericTextBox2 ntbPreuParticipacio;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btRecalcula;
        private System.Windows.Forms.GroupBox groupBox7;
        private Controls.NumericTextBox2 ntbImportBrut;
        private System.Windows.Forms.DataGridView dgvCompresOriginals;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox8;
        private Controls.NumericTextBox2 ntbRestaTramNoTributa;
        private System.Windows.Forms.GroupBox groupBox9;
        private Controls.NumericTextBox2 ntbTributaRenda;
        private System.Windows.Forms.ComboBox cbAny;
        private System.Windows.Forms.GroupBox groupBox4;
        private Controls.NumericTextBox2 ntbPerduesAnysAnteriors;
        private System.Windows.Forms.GroupBox groupBox5;
        private Controls.NumericTextBox2 ntbIngressosExterns;
        private System.Windows.Forms.GroupBox groupBox10;
        private Controls.NumericTextBox2 ntbDividents;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.GroupBox gbPigRealAny;
        private Controls.NumericTextBox2 ntbPiGActual;
        private System.Windows.Forms.GroupBox groupBox13;
        private Controls.NumericTextBox2 ntbPiGAltresProductes;
        private System.Windows.Forms.GroupBox groupBox12;
        private Controls.NumericTextBox2 ntbPigSimulacio;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdOrig;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fonsOrig;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCompraOrig;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parts;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartsUtil;
        private Controls.NumericTextBoxColumn PigOrigen;
        private Controls.NumericTextBoxColumn PigDeLaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValorAct;
        private System.Windows.Forms.GroupBox groupBox14;
        private Controls.NumericTextBox2 ntbPartsSaltades;
        private Controls.NumericTextBox2 ntbTramExentAnual;
    }
}
