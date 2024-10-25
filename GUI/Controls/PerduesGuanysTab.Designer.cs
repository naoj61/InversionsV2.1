using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Controls;

namespace Inversions.GUI
{
    partial class PerduesGuanysTab
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle36 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle34 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle35 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnPigRight = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.dgvPiGEnCartera = new System.Windows.Forms.DataGridView();
            this.colPigEnCarteraProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPigEnCarteraPig = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lbTotalPigEnCartera = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbPiGEnCartera = new System.Windows.Forms.Label();
            this.cbAnysPiGEnCartera = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ntbPigRealMesCartera = new Controls.NumericTextBox2();
            this.label3 = new System.Windows.Forms.Label();
            this.ntbPigActualPartsEnCartera = new Controls.NumericTextBox2();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvPiGAnualsTributen = new System.Windows.Forms.DataGridView();
            this.colAny = new Controls.NumericTextBoxColumn2();
            this.colPigTributa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTotalPigTributen = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbTipusProducteFiltreTab2 = new System.Windows.Forms.ComboBox();
            this.pnPigFill = new System.Windows.Forms.Panel();
            this.dgvCompresProducte = new Controls.DataGridView3();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PigDeLaCompra = new Controls.NumericTextBoxColumn2();
            this.PigOrigen = new Controls.NumericTextBoxColumn2();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ckAmbCartera = new System.Windows.Forms.CheckBox();
            this.ckAmbDividends = new System.Windows.Forms.CheckBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvPiGProductePerAny = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ntbPigCompra = new Controls.NumericTextBox2();
            this.gbPigCompraOrig = new System.Windows.Forms.GroupBox();
            this.ntbPigCompraOrig = new Controls.NumericTextBox2();
            this.label4 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel7 = new System.Windows.Forms.Panel();
            this.gbSimulacioPig = new System.Windows.Forms.GroupBox();
            this.btSimulacioPiG = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ntbDiferencia = new Controls.NumericTextBox2();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ntbPiG = new Controls.NumericTextBox2();
            this.gbPreuPartic = new System.Windows.Forms.GroupBox();
            this.ntbPreuParticipacio = new Controls.NumericTextBox2();
            this.gbFiltreDates = new System.Windows.Forms.GroupBox();
            this.ckPiGEntreDatesNomesProdSel = new System.Windows.Forms.CheckBox();
            this.tbPigEntreDates = new Controls.NumericTextBox2();
            this.dtpFiltreDataInici = new Controls.DateTimePickerNullable();
            this.btFiltreDates = new System.Windows.Forms.Button();
            this.dtpFiltreDataFi = new Controls.DateTimePickerNullable();
            this.gestioProductesTabValoracions = new Inversions.GUI.GestioProductes();
            this.pnPigRight.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiGEnCartera)).BeginInit();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiGAnualsTributen)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.pnPigFill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompresProducte)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiGProductePerAny)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.gbPigCompraOrig.SuspendLayout();
            this.panel7.SuspendLayout();
            this.gbSimulacioPig.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbPreuPartic.SuspendLayout();
            this.gbFiltreDates.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnPigRight
            // 
            this.pnPigRight.Controls.Add(this.panel8);
            this.pnPigRight.Controls.Add(this.panel2);
            this.pnPigRight.Controls.Add(this.panel3);
            this.pnPigRight.Controls.Add(this.groupBox5);
            this.pnPigRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnPigRight.Location = new System.Drawing.Point(1029, 0);
            this.pnPigRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnPigRight.Name = "pnPigRight";
            this.pnPigRight.Padding = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.pnPigRight.Size = new System.Drawing.Size(430, 822);
            this.pnPigRight.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.dgvPiGEnCartera);
            this.panel8.Controls.Add(this.panel9);
            this.panel8.Controls.Add(this.panel6);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(5, 464);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(420, 358);
            this.panel8.TabIndex = 22;
            // 
            // dgvPiGEnCartera
            // 
            this.dgvPiGEnCartera.AllowUserToAddRows = false;
            this.dgvPiGEnCartera.AllowUserToDeleteRows = false;
            this.dgvPiGEnCartera.AllowUserToOrderColumns = true;
            this.dgvPiGEnCartera.AllowUserToResizeRows = false;
            this.dgvPiGEnCartera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPiGEnCartera.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
            this.dgvPiGEnCartera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPiGEnCartera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPigEnCarteraProd,
            this.colPigEnCarteraPig});
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPiGEnCartera.DefaultCellStyle = dataGridViewCellStyle21;
            this.dgvPiGEnCartera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPiGEnCartera.Location = new System.Drawing.Point(0, 44);
            this.dgvPiGEnCartera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPiGEnCartera.Name = "dgvPiGEnCartera";
            this.dgvPiGEnCartera.ReadOnly = true;
            this.dgvPiGEnCartera.RowHeadersVisible = false;
            this.dgvPiGEnCartera.RowTemplate.Height = 24;
            this.dgvPiGEnCartera.Size = new System.Drawing.Size(420, 276);
            this.dgvPiGEnCartera.TabIndex = 1;
            this.toolTip1.SetToolTip(this.dgvPiGEnCartera, "Només vendes reals.");
            this.dgvPiGEnCartera.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvPiGEnCartera_CellMouseClick);
            this.dgvPiGEnCartera.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgvPiGEnCartera_SortCompare);
            // 
            // colPigEnCarteraProd
            // 
            this.colPigEnCarteraProd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPigEnCarteraProd.HeaderText = "Producte";
            this.colPigEnCarteraProd.Name = "colPigEnCarteraProd";
            this.colPigEnCarteraProd.ReadOnly = true;
            // 
            // colPigEnCarteraPig
            // 
            this.colPigEnCarteraPig.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle20.Format = "C2";
            dataGridViewCellStyle20.NullValue = null;
            this.colPigEnCarteraPig.DefaultCellStyle = dataGridViewCellStyle20;
            this.colPigEnCarteraPig.HeaderText = "P i G";
            this.colPigEnCarteraPig.Name = "colPigEnCarteraPig";
            this.colPigEnCarteraPig.ReadOnly = true;
            this.colPigEnCarteraPig.Width = 79;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.label6);
            this.panel9.Controls.Add(this.lbTotalPigEnCartera);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel9.Location = new System.Drawing.Point(0, 320);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(420, 38);
            this.panel9.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(366, 38);
            this.label6.TabIndex = 0;
            this.label6.Text = "Total";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTotalPigEnCartera
            // 
            this.lbTotalPigEnCartera.AutoSize = true;
            this.lbTotalPigEnCartera.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbTotalPigEnCartera.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPigEnCartera.Location = new System.Drawing.Point(366, 0);
            this.lbTotalPigEnCartera.Name = "lbTotalPigEnCartera";
            this.lbTotalPigEnCartera.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.lbTotalPigEnCartera.Size = new System.Drawing.Size(54, 29);
            this.lbTotalPigEnCartera.TabIndex = 1;
            this.lbTotalPigEnCartera.Text = "0,00€";
            this.lbTotalPigEnCartera.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.lbPiGEnCartera);
            this.panel6.Controls.Add(this.cbAnysPiGEnCartera);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Padding = new System.Windows.Forms.Padding(0, 6, 0, 5);
            this.panel6.Size = new System.Drawing.Size(420, 44);
            this.panel6.TabIndex = 0;
            this.panel6.Text = "P i G en cartera en l\'any";
            this.toolTip1.SetToolTip(this.panel6, "Només vendes reals, amb despeses, sense dividends.");
            // 
            // lbPiGEnCartera
            // 
            this.lbPiGEnCartera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPiGEnCartera.Location = new System.Drawing.Point(0, 6);
            this.lbPiGEnCartera.Name = "lbPiGEnCartera";
            this.lbPiGEnCartera.Size = new System.Drawing.Size(321, 29);
            this.lbPiGEnCartera.TabIndex = 0;
            this.lbPiGEnCartera.Text = "Variació P i G en cartera any:";
            this.lbPiGEnCartera.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbAnysPiGEnCartera
            // 
            this.cbAnysPiGEnCartera.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbAnysPiGEnCartera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAnysPiGEnCartera.FormattingEnabled = true;
            this.cbAnysPiGEnCartera.Location = new System.Drawing.Point(321, 6);
            this.cbAnysPiGEnCartera.Name = "cbAnysPiGEnCartera";
            this.cbAnysPiGEnCartera.Size = new System.Drawing.Size(95, 28);
            this.cbAnysPiGEnCartera.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.ntbPigRealMesCartera);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.ntbPigActualPartsEnCartera);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(5, 322);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(9);
            this.panel2.Size = new System.Drawing.Size(420, 142);
            this.panel2.TabIndex = 2;
            // 
            // ntbPigRealMesCartera
            // 
            this.ntbPigRealMesCartera._CapturaEscape = true;
            this.ntbPigRealMesCartera._Format = "#,#0.00 €";
            this.ntbPigRealMesCartera._NegatiusEnVermell = false;
            this.ntbPigRealMesCartera._PermetDecimals = true;
            this.ntbPigRealMesCartera._PermetNegatius = true;
            this.ntbPigRealMesCartera._PermetTextNull = false;
            this.ntbPigRealMesCartera.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPigRealMesCartera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ntbPigRealMesCartera.Dock = System.Windows.Forms.DockStyle.Top;
            this.ntbPigRealMesCartera.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPigRealMesCartera.ForeColor = System.Drawing.Color.Black;
            this.ntbPigRealMesCartera.Location = new System.Drawing.Point(9, 101);
            this.ntbPigRealMesCartera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ntbPigRealMesCartera.Name = "ntbPigRealMesCartera";
            this.ntbPigRealMesCartera.ReadOnly = true;
            this.ntbPigRealMesCartera.Size = new System.Drawing.Size(400, 30);
            this.ntbPigRealMesCartera.TabIndex = 3;
            this.ntbPigRealMesCartera.Text = "0,00 €";
            this.ntbPigRealMesCartera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.ntbPigRealMesCartera, "PiG actual de les participacions en cartera");
            this.ntbPigRealMesCartera.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(400, 31);
            this.label3.TabIndex = 2;
            this.label3.Text = "PiG Real + Cartera";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ntbPigActualPartsEnCartera
            // 
            this.ntbPigActualPartsEnCartera._CapturaEscape = true;
            this.ntbPigActualPartsEnCartera._Format = "#,#0.00 €";
            this.ntbPigActualPartsEnCartera._NegatiusEnVermell = false;
            this.ntbPigActualPartsEnCartera._PermetDecimals = true;
            this.ntbPigActualPartsEnCartera._PermetNegatius = true;
            this.ntbPigActualPartsEnCartera._PermetTextNull = false;
            this.ntbPigActualPartsEnCartera.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPigActualPartsEnCartera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ntbPigActualPartsEnCartera.Dock = System.Windows.Forms.DockStyle.Top;
            this.ntbPigActualPartsEnCartera.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPigActualPartsEnCartera.ForeColor = System.Drawing.Color.Black;
            this.ntbPigActualPartsEnCartera.Location = new System.Drawing.Point(9, 40);
            this.ntbPigActualPartsEnCartera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ntbPigActualPartsEnCartera.Name = "ntbPigActualPartsEnCartera";
            this.ntbPigActualPartsEnCartera.ReadOnly = true;
            this.ntbPigActualPartsEnCartera.Size = new System.Drawing.Size(400, 30);
            this.ntbPigActualPartsEnCartera.TabIndex = 1;
            this.ntbPigActualPartsEnCartera.Text = "0,00 €";
            this.ntbPigActualPartsEnCartera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.ntbPigActualPartsEnCartera, "PiG actual de les participacions en cartera");
            this.ntbPigActualPartsEnCartera.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(400, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "PiG actual de les participacions en cartera";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvPiGAnualsTributen);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(5, 66);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(420, 256);
            this.panel3.TabIndex = 21;
            // 
            // dgvPiGAnualsTributen
            // 
            this.dgvPiGAnualsTributen.AllowUserToAddRows = false;
            this.dgvPiGAnualsTributen.AllowUserToDeleteRows = false;
            this.dgvPiGAnualsTributen.AllowUserToOrderColumns = true;
            this.dgvPiGAnualsTributen.AllowUserToResizeRows = false;
            this.dgvPiGAnualsTributen.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPiGAnualsTributen.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle22;
            this.dgvPiGAnualsTributen.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPiGAnualsTributen.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colAny,
            this.colPigTributa});
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPiGAnualsTributen.DefaultCellStyle = dataGridViewCellStyle25;
            this.dgvPiGAnualsTributen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPiGAnualsTributen.Location = new System.Drawing.Point(0, 31);
            this.dgvPiGAnualsTributen.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPiGAnualsTributen.Name = "dgvPiGAnualsTributen";
            this.dgvPiGAnualsTributen.ReadOnly = true;
            this.dgvPiGAnualsTributen.RowHeadersVisible = false;
            this.dgvPiGAnualsTributen.RowTemplate.Height = 24;
            this.dgvPiGAnualsTributen.Size = new System.Drawing.Size(420, 187);
            this.dgvPiGAnualsTributen.TabIndex = 1;
            this.toolTip1.SetToolTip(this.dgvPiGAnualsTributen, "Només vendes reals.");
            this.dgvPiGAnualsTributen.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPiGAnualsTributen_CellDoubleClick);
            // 
            // colAny
            // 
            this.colAny._NegatiusEnVermell = true;
            this.colAny.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle23.Format = "0000";
            dataGridViewCellStyle23.NullValue = null;
            this.colAny.DefaultCellStyle = dataGridViewCellStyle23;
            this.colAny.HeaderText = "Any";
            this.colAny.Name = "colAny";
            this.colAny.ReadOnly = true;
            this.colAny.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colAny.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colAny.Width = 42;
            // 
            // colPigTributa
            // 
            this.colPigTributa.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle24.Format = "c2";
            this.colPigTributa.DefaultCellStyle = dataGridViewCellStyle24;
            this.colPigTributa.HeaderText = "P i G Total";
            this.colPigTributa.Name = "colPigTributa";
            this.colPigTributa.ReadOnly = true;
            this.colPigTributa.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.lbTotalPigTributen);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 218);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(420, 38);
            this.panel5.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(366, 38);
            this.label5.TabIndex = 0;
            this.label5.Text = "Total";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbTotalPigTributen
            // 
            this.lbTotalPigTributen.AutoSize = true;
            this.lbTotalPigTributen.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbTotalPigTributen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTotalPigTributen.Location = new System.Drawing.Point(366, 0);
            this.lbTotalPigTributen.Name = "lbTotalPigTributen";
            this.lbTotalPigTributen.Padding = new System.Windows.Forms.Padding(0, 9, 0, 0);
            this.lbTotalPigTributen.Size = new System.Drawing.Size(54, 29);
            this.lbTotalPigTributen.TabIndex = 1;
            this.lbTotalPigTributen.Text = "0,00€";
            this.lbTotalPigTributen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(420, 31);
            this.label2.TabIndex = 0;
            this.label2.Text = "P i G que tributen";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.label2, "Només vendes reals, amb despeses, sense dividends.");
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbTipusProducteFiltreTab2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(5, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox5.Size = new System.Drawing.Size(420, 66);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tipus Producte";
            // 
            // cbTipusProducteFiltreTab2
            // 
            this.cbTipusProducteFiltreTab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTipusProducteFiltreTab2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipusProducteFiltreTab2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTipusProducteFiltreTab2.FormattingEnabled = true;
            this.cbTipusProducteFiltreTab2.Location = new System.Drawing.Point(6, 24);
            this.cbTipusProducteFiltreTab2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTipusProducteFiltreTab2.Name = "cbTipusProducteFiltreTab2";
            this.cbTipusProducteFiltreTab2.Size = new System.Drawing.Size(408, 34);
            this.cbTipusProducteFiltreTab2.TabIndex = 0;
            // 
            // pnPigFill
            // 
            this.pnPigFill.Controls.Add(this.dgvCompresProducte);
            this.pnPigFill.Controls.Add(this.flowLayoutPanel1);
            this.pnPigFill.Controls.Add(this.panel4);
            this.pnPigFill.Controls.Add(this.panel1);
            this.pnPigFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPigFill.Location = new System.Drawing.Point(0, 493);
            this.pnPigFill.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnPigFill.Name = "pnPigFill";
            this.pnPigFill.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnPigFill.Size = new System.Drawing.Size(1029, 229);
            this.pnPigFill.TabIndex = 19;
            // 
            // dgvCompresProducte
            // 
            this.dgvCompresProducte.AllowUserToAddRows = false;
            this.dgvCompresProducte.AllowUserToDeleteRows = false;
            this.dgvCompresProducte.AllowUserToOrderColumns = true;
            this.dgvCompresProducte.AllowUserToResizeRows = false;
            this.dgvCompresProducte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCompresProducte.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dgvCompresProducte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompresProducte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn12,
            this.PigDeLaCompra,
            this.PigOrigen});
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCompresProducte.DefaultCellStyle = dataGridViewCellStyle32;
            this.dgvCompresProducte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompresProducte.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCompresProducte.Location = new System.Drawing.Point(0, 34);
            this.dgvCompresProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvCompresProducte.Name = "dgvCompresProducte";
            this.dgvCompresProducte.ReadOnly = true;
            this.dgvCompresProducte.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvCompresProducte.RowTemplate.Height = 24;
            this.dgvCompresProducte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompresProducte.Size = new System.Drawing.Size(724, 190);
            this.dgvCompresProducte.TabIndex = 2;
            this.dgvCompresProducte.VirtualMode = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "_Id";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle27.Format = "N0";
            dataGridViewCellStyle27.NullValue = null;
            this.Id.DefaultCellStyle = dataGridViewCellStyle27;
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Width = 5;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "_Data";
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle28.Format = "d";
            dataGridViewCellStyle28.NullValue = null;
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle28;
            this.dataGridViewTextBoxColumn3.HeaderText = "Data Compra";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 99;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.dataGridViewTextBoxColumn12.DataPropertyName = "_PreuParticipacio";
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle29.Format = "C3";
            this.dataGridViewTextBoxColumn12.DefaultCellStyle = dataGridViewCellStyle29;
            this.dataGridViewTextBoxColumn12.HeaderText = "Preu Unit. Compra";
            this.dataGridViewTextBoxColumn12.MinimumWidth = 95;
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn12.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn12.Width = 95;
            // 
            // PigDeLaCompra
            // 
            this.PigDeLaCompra._NegatiusEnVermell = true;
            this.PigDeLaCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.PigDeLaCompra.DataPropertyName = "_PigDeLaCompra";
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle30.Format = "C2";
            this.PigDeLaCompra.DefaultCellStyle = dataGridViewCellStyle30;
            this.PigDeLaCompra.HeaderText = "PiG";
            this.PigDeLaCompra.MinimumWidth = 97;
            this.PigDeLaCompra.Name = "PigDeLaCompra";
            this.PigDeLaCompra.ReadOnly = true;
            this.PigDeLaCompra.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PigDeLaCompra.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PigDeLaCompra.Width = 97;
            // 
            // PigOrigen
            // 
            this.PigOrigen._NegatiusEnVermell = true;
            this.PigOrigen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.PigOrigen.DataPropertyName = "_PigDeLaCompraOrigen";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle31.Format = "C2";
            this.PigOrigen.DefaultCellStyle = dataGridViewCellStyle31;
            this.PigOrigen.HeaderText = "PigOrigen";
            this.PigOrigen.MinimumWidth = 97;
            this.PigOrigen.Name = "PigOrigen";
            this.PigOrigen.ReadOnly = true;
            this.PigOrigen.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.PigOrigen.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.PigOrigen.Width = 97;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.ckAmbCartera);
            this.flowLayoutPanel1.Controls.Add(this.ckAmbDividends);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(724, 34);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // ckAmbCartera
            // 
            this.ckAmbCartera.AutoSize = true;
            this.ckAmbCartera.Checked = true;
            this.ckAmbCartera.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAmbCartera.Location = new System.Drawing.Point(3, 3);
            this.ckAmbCartera.Name = "ckAmbCartera";
            this.ckAmbCartera.Padding = new System.Windows.Forms.Padding(2);
            this.ckAmbCartera.Size = new System.Drawing.Size(129, 28);
            this.ckAmbCartera.TabIndex = 0;
            this.ckAmbCartera.Text = "Amb Cartera";
            this.ckAmbCartera.UseVisualStyleBackColor = true;
            this.ckAmbCartera.CheckedChanged += new System.EventHandler(this.ckAmbCartera_CheckedChanged);
            // 
            // ckAmbDividends
            // 
            this.ckAmbDividends.AutoSize = true;
            this.ckAmbDividends.Checked = true;
            this.ckAmbDividends.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAmbDividends.Location = new System.Drawing.Point(138, 3);
            this.ckAmbDividends.Name = "ckAmbDividends";
            this.ckAmbDividends.Padding = new System.Windows.Forms.Padding(2);
            this.ckAmbDividends.Size = new System.Drawing.Size(145, 28);
            this.ckAmbDividends.TabIndex = 1;
            this.ckAmbDividends.Text = "Amb Dividends";
            this.ckAmbDividends.UseVisualStyleBackColor = true;
            this.ckAmbDividends.CheckedChanged += new System.EventHandler(this.ckAmbDividends_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(724, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(21, 224);
            this.panel4.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvPiGProductePerAny);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.gbPigCompraOrig);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(745, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(284, 224);
            this.panel1.TabIndex = 20;
            // 
            // dgvPiGProductePerAny
            // 
            this.dgvPiGProductePerAny.AllowUserToAddRows = false;
            this.dgvPiGProductePerAny.AllowUserToDeleteRows = false;
            this.dgvPiGProductePerAny.AllowUserToOrderColumns = true;
            this.dgvPiGProductePerAny.AllowUserToResizeRows = false;
            this.dgvPiGProductePerAny.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPiGProductePerAny.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle33;
            this.dgvPiGProductePerAny.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPiGProductePerAny.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9});
            dataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle36.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle36.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle36.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle36.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle36.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPiGProductePerAny.DefaultCellStyle = dataGridViewCellStyle36;
            this.dgvPiGProductePerAny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPiGProductePerAny.Location = new System.Drawing.Point(5, 29);
            this.dgvPiGProductePerAny.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPiGProductePerAny.Name = "dgvPiGProductePerAny";
            this.dgvPiGProductePerAny.ReadOnly = true;
            this.dgvPiGProductePerAny.RowHeadersVisible = false;
            this.dgvPiGProductePerAny.RowTemplate.Height = 24;
            this.dgvPiGProductePerAny.Size = new System.Drawing.Size(279, 85);
            this.dgvPiGProductePerAny.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle34.Format = "0000";
            dataGridViewCellStyle34.NullValue = null;
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle34;
            this.dataGridViewTextBoxColumn8.HeaderText = "Any";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 40;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn8.Width = 42;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle35.Format = "c2";
            this.dataGridViewTextBoxColumn9.DefaultCellStyle = dataGridViewCellStyle35;
            this.dataGridViewTextBoxColumn9.HeaderText = "P i G Total Origen";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 20;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ntbPigCompra);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(5, 114);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 9, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.groupBox3.Size = new System.Drawing.Size(279, 55);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "PiG Total";
            this.toolTip1.SetToolTip(this.groupBox3, "PiG cartera + vendes reals + vendesT + dividents - despeses, sense tenir en compt" +
        "e el preu original en cas de traspàs.");
            // 
            // ntbPigCompra
            // 
            this.ntbPigCompra._CapturaEscape = true;
            this.ntbPigCompra._Format = "#,##0.00 €";
            this.ntbPigCompra._NegatiusEnVermell = true;
            this.ntbPigCompra._PermetDecimals = true;
            this.ntbPigCompra._PermetNegatius = true;
            this.ntbPigCompra._PermetTextNull = false;
            this.ntbPigCompra.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPigCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPigCompra.Location = new System.Drawing.Point(3, 22);
            this.ntbPigCompra.Name = "ntbPigCompra";
            this.ntbPigCompra.ReadOnly = true;
            this.ntbPigCompra.Size = new System.Drawing.Size(273, 25);
            this.ntbPigCompra.TabIndex = 0;
            this.ntbPigCompra.Text = "0,00 €";
            this.ntbPigCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPigCompra.Valor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // gbPigCompraOrig
            // 
            this.gbPigCompraOrig.Controls.Add(this.ntbPigCompraOrig);
            this.gbPigCompraOrig.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbPigCompraOrig.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPigCompraOrig.Location = new System.Drawing.Point(5, 169);
            this.gbPigCompraOrig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPigCompraOrig.Name = "gbPigCompraOrig";
            this.gbPigCompraOrig.Padding = new System.Windows.Forms.Padding(3, 4, 3, 0);
            this.gbPigCompraOrig.Size = new System.Drawing.Size(279, 55);
            this.gbPigCompraOrig.TabIndex = 3;
            this.gbPigCompraOrig.TabStop = false;
            this.gbPigCompraOrig.Text = "PiG Total Orig";
            // 
            // ntbPigCompraOrig
            // 
            this.ntbPigCompraOrig._CapturaEscape = true;
            this.ntbPigCompraOrig._Format = "#,##0.00 €";
            this.ntbPigCompraOrig._NegatiusEnVermell = true;
            this.ntbPigCompraOrig._PermetDecimals = true;
            this.ntbPigCompraOrig._PermetNegatius = true;
            this.ntbPigCompraOrig._PermetTextNull = false;
            this.ntbPigCompraOrig.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPigCompraOrig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPigCompraOrig.Location = new System.Drawing.Point(3, 22);
            this.ntbPigCompraOrig.Name = "ntbPigCompraOrig";
            this.ntbPigCompraOrig.ReadOnly = true;
            this.ntbPigCompraOrig.Size = new System.Drawing.Size(273, 25);
            this.ntbPigCompraOrig.TabIndex = 0;
            this.ntbPigCompraOrig.Text = "0,00 €";
            this.ntbPigCompraOrig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPigCompraOrig.Valor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(279, 29);
            this.label4.TabIndex = 0;
            this.label4.Text = "PiG Producte";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.gbSimulacioPig);
            this.panel7.Controls.Add(this.gbFiltreDates);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel7.Location = new System.Drawing.Point(0, 722);
            this.panel7.Name = "panel7";
            this.panel7.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.panel7.Size = new System.Drawing.Size(1029, 100);
            this.panel7.TabIndex = 20;
            // 
            // gbSimulacioPig
            // 
            this.gbSimulacioPig.Controls.Add(this.btSimulacioPiG);
            this.gbSimulacioPig.Controls.Add(this.groupBox2);
            this.gbSimulacioPig.Controls.Add(this.groupBox1);
            this.gbSimulacioPig.Controls.Add(this.gbPreuPartic);
            this.gbSimulacioPig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSimulacioPig.Enabled = false;
            this.gbSimulacioPig.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbSimulacioPig.Location = new System.Drawing.Point(435, 3);
            this.gbSimulacioPig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbSimulacioPig.Name = "gbSimulacioPig";
            this.gbSimulacioPig.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbSimulacioPig.Size = new System.Drawing.Size(594, 94);
            this.gbSimulacioPig.TabIndex = 1;
            this.gbSimulacioPig.TabStop = false;
            this.gbSimulacioPig.Text = "Simulació PiG Orig";
            // 
            // btSimulacioPiG
            // 
            this.btSimulacioPiG.Location = new System.Drawing.Point(420, 29);
            this.btSimulacioPiG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btSimulacioPiG.Name = "btSimulacioPiG";
            this.btSimulacioPiG.Size = new System.Drawing.Size(93, 56);
            this.btSimulacioPiG.TabIndex = 3;
            this.btSimulacioPiG.Text = "Calcula";
            this.btSimulacioPiG.UseVisualStyleBackColor = true;
            this.btSimulacioPiG.Click += new System.EventHandler(this.btSimulacioPiG_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ntbDiferencia);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(271, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 6, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(131, 56);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dif.PiG Act.";
            // 
            // ntbDiferencia
            // 
            this.ntbDiferencia._CapturaEscape = true;
            this.ntbDiferencia._Format = "#,##0.00 €";
            this.ntbDiferencia._NegatiusEnVermell = false;
            this.ntbDiferencia._PermetDecimals = true;
            this.ntbDiferencia._PermetNegatius = true;
            this.ntbDiferencia._PermetTextNull = false;
            this.ntbDiferencia.BackColor = System.Drawing.SystemColors.Window;
            this.ntbDiferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbDiferencia.ForeColor = System.Drawing.Color.Black;
            this.ntbDiferencia.Location = new System.Drawing.Point(3, 20);
            this.ntbDiferencia.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ntbDiferencia.Name = "ntbDiferencia";
            this.ntbDiferencia.ReadOnly = true;
            this.ntbDiferencia.Size = new System.Drawing.Size(125, 25);
            this.ntbDiferencia.TabIndex = 0;
            this.ntbDiferencia.Text = "0,00 €";
            this.ntbDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbDiferencia.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ntbPiG);
            this.groupBox1.Location = new System.Drawing.Point(122, 29);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 8);
            this.groupBox1.Size = new System.Drawing.Size(131, 56);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PiG";
            // 
            // ntbPiG
            // 
            this.ntbPiG._CapturaEscape = true;
            this.ntbPiG._Format = "#,##0.00 €";
            this.ntbPiG._NegatiusEnVermell = true;
            this.ntbPiG._PermetDecimals = true;
            this.ntbPiG._PermetNegatius = true;
            this.ntbPiG._PermetTextNull = false;
            this.ntbPiG.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPiG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPiG.Location = new System.Drawing.Point(4, 22);
            this.ntbPiG.Name = "ntbPiG";
            this.ntbPiG.ReadOnly = true;
            this.ntbPiG.Size = new System.Drawing.Size(123, 25);
            this.ntbPiG.TabIndex = 0;
            this.ntbPiG.Text = "0,00 €";
            this.ntbPiG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPiG.Valor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // gbPreuPartic
            // 
            this.gbPreuPartic.Controls.Add(this.ntbPreuParticipacio);
            this.gbPreuPartic.Location = new System.Drawing.Point(8, 29);
            this.gbPreuPartic.Margin = new System.Windows.Forms.Padding(0);
            this.gbPreuPartic.Name = "gbPreuPartic";
            this.gbPreuPartic.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPreuPartic.Size = new System.Drawing.Size(96, 56);
            this.gbPreuPartic.TabIndex = 0;
            this.gbPreuPartic.TabStop = false;
            this.gbPreuPartic.Text = "Preu";
            // 
            // ntbPreuParticipacio
            // 
            this.ntbPreuParticipacio._CapturaEscape = true;
            this.ntbPreuParticipacio._Format = "#,##0.###### €";
            this.ntbPreuParticipacio._NegatiusEnVermell = false;
            this.ntbPreuParticipacio._PermetDecimals = true;
            this.ntbPreuParticipacio._PermetNegatius = false;
            this.ntbPreuParticipacio._PermetTextNull = false;
            this.ntbPreuParticipacio.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPreuParticipacio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPreuParticipacio.ForeColor = System.Drawing.Color.Black;
            this.ntbPreuParticipacio.Location = new System.Drawing.Point(3, 22);
            this.ntbPreuParticipacio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ntbPreuParticipacio.Name = "ntbPreuParticipacio";
            this.ntbPreuParticipacio.Size = new System.Drawing.Size(90, 25);
            this.ntbPreuParticipacio.TabIndex = 0;
            this.ntbPreuParticipacio.Text = "0 €";
            this.ntbPreuParticipacio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPreuParticipacio.Valor = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ntbPreuParticipacio.Enter += new System.EventHandler(this.ntbPreuParticipacio_Enter);
            this.ntbPreuParticipacio.Leave += new System.EventHandler(this.ntb_Leave);
            // 
            // gbFiltreDates
            // 
            this.gbFiltreDates.Controls.Add(this.ckPiGEntreDatesNomesProdSel);
            this.gbFiltreDates.Controls.Add(this.tbPigEntreDates);
            this.gbFiltreDates.Controls.Add(this.dtpFiltreDataInici);
            this.gbFiltreDates.Controls.Add(this.btFiltreDates);
            this.gbFiltreDates.Controls.Add(this.dtpFiltreDataFi);
            this.gbFiltreDates.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbFiltreDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFiltreDates.Location = new System.Drawing.Point(0, 3);
            this.gbFiltreDates.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbFiltreDates.Name = "gbFiltreDates";
            this.gbFiltreDates.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbFiltreDates.Size = new System.Drawing.Size(435, 94);
            this.gbFiltreDates.TabIndex = 0;
            this.gbFiltreDates.TabStop = false;
            this.gbFiltreDates.Text = "PiG entre dates";
            // 
            // ckPiGEntreDatesNomesProdSel
            // 
            this.ckPiGEntreDatesNomesProdSel.AutoSize = true;
            this.ckPiGEntreDatesNomesProdSel.Enabled = false;
            this.ckPiGEntreDatesNomesProdSel.Location = new System.Drawing.Point(15, 61);
            this.ckPiGEntreDatesNomesProdSel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckPiGEntreDatesNomesProdSel.Name = "ckPiGEntreDatesNomesProdSel";
            this.ckPiGEntreDatesNomesProdSel.Size = new System.Drawing.Size(173, 24);
            this.ckPiGEntreDatesNomesProdSel.TabIndex = 2;
            this.ckPiGEntreDatesNomesProdSel.Text = "Només Prod. Sel.";
            this.ckPiGEntreDatesNomesProdSel.UseVisualStyleBackColor = true;
            // 
            // tbPigEntreDates
            // 
            this.tbPigEntreDates._CapturaEscape = true;
            this.tbPigEntreDates._Format = "#,#0.00 €";
            this.tbPigEntreDates._NegatiusEnVermell = false;
            this.tbPigEntreDates._PermetDecimals = true;
            this.tbPigEntreDates._PermetNegatius = true;
            this.tbPigEntreDates._PermetTextNull = false;
            this.tbPigEntreDates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPigEntreDates.BackColor = System.Drawing.SystemColors.Window;
            this.tbPigEntreDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPigEntreDates.ForeColor = System.Drawing.Color.Black;
            this.tbPigEntreDates.Location = new System.Drawing.Point(307, 60);
            this.tbPigEntreDates.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPigEntreDates.Name = "tbPigEntreDates";
            this.tbPigEntreDates.ReadOnly = true;
            this.tbPigEntreDates.Size = new System.Drawing.Size(119, 25);
            this.tbPigEntreDates.TabIndex = 3;
            this.tbPigEntreDates.Text = "0,00 €";
            this.tbPigEntreDates.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPigEntreDates.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // dtpFiltreDataInici
            // 
            this.dtpFiltreDataInici.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFiltreDataInici.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltreDataInici.Location = new System.Drawing.Point(15, 25);
            this.dtpFiltreDataInici.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFiltreDataInici.Name = "dtpFiltreDataInici";
            this.dtpFiltreDataInici.Size = new System.Drawing.Size(140, 25);
            this.dtpFiltreDataInici.TabIndex = 0;
            this.dtpFiltreDataInici.Value = null;
            this.dtpFiltreDataInici.Enter += new System.EventHandler(this.dtpFiltreDataInici_Enter);
            this.dtpFiltreDataInici.Leave += new System.EventHandler(this.ntb_Leave);
            // 
            // btFiltreDates
            // 
            this.btFiltreDates.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFiltreDates.Location = new System.Drawing.Point(307, 16);
            this.btFiltreDates.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btFiltreDates.Name = "btFiltreDates";
            this.btFiltreDates.Size = new System.Drawing.Size(119, 38);
            this.btFiltreDates.TabIndex = 4;
            this.btFiltreDates.Text = "Calcula";
            this.btFiltreDates.UseVisualStyleBackColor = true;
            this.btFiltreDates.Click += new System.EventHandler(this.btFiltreDates_Click);
            // 
            // dtpFiltreDataFi
            // 
            this.dtpFiltreDataFi.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFiltreDataFi.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFiltreDataFi.Location = new System.Drawing.Point(161, 25);
            this.dtpFiltreDataFi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtpFiltreDataFi.Name = "dtpFiltreDataFi";
            this.dtpFiltreDataFi.Size = new System.Drawing.Size(140, 25);
            this.dtpFiltreDataFi.TabIndex = 1;
            this.dtpFiltreDataFi.Value = null;
            this.dtpFiltreDataFi.Enter += new System.EventHandler(this.dtpFiltreDataFi_Enter);
            this.dtpFiltreDataFi.Leave += new System.EventHandler(this.ntb_Leave);
            // 
            // gestioProductesTabValoracions
            // 
            this.gestioProductesTabValoracions._AmbMoviments = true;
            this.gestioProductesTabValoracions._FiltreAnyVisible = true;
            this.gestioProductesTabValoracions._MostraLlistaAmbChecks = false;
            this.gestioProductesTabValoracions._NomesAmbParticipacions = true;
            this.gestioProductesTabValoracions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gestioProductesTabValoracions.Dock = System.Windows.Forms.DockStyle.Top;
            this.gestioProductesTabValoracions.Location = new System.Drawing.Point(0, 0);
            this.gestioProductesTabValoracions.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.gestioProductesTabValoracions.MinimumSize = new System.Drawing.Size(824, 493);
            this.gestioProductesTabValoracions.Name = "gestioProductesTabValoracions";
            this.gestioProductesTabValoracions.Size = new System.Drawing.Size(1029, 493);
            this.gestioProductesTabValoracions.TabIndex = 0;
            this.gestioProductesTabValoracions.EventProducteSeleccionat += new System.EventHandler(this.gestioProductesTabValoracions_ProducteSeleccionat);
            // 
            // PerduesGuanysTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnPigFill);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.gestioProductesTabValoracions);
            this.Controls.Add(this.pnPigRight);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PerduesGuanysTab";
            this.Size = new System.Drawing.Size(1459, 822);
            this.pnPigRight.ResumeLayout(false);
            this.pnPigRight.PerformLayout();
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiGEnCartera)).EndInit();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiGAnualsTributen)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.pnPigFill.ResumeLayout(false);
            this.pnPigFill.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompresProducte)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiGProductePerAny)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbPigCompraOrig.ResumeLayout(false);
            this.gbPigCompraOrig.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.gbSimulacioPig.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbPreuPartic.ResumeLayout(false);
            this.gbPreuPartic.PerformLayout();
            this.gbFiltreDates.ResumeLayout(false);
            this.gbFiltreDates.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GestioProductes gestioProductesTabValoracions;
        private System.Windows.Forms.Panel pnPigRight;
        private System.Windows.Forms.Panel pnPigFill;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbTipusProducteFiltreTab2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvPiGAnualsTributen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvPiGProductePerAny;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private Controls.DataGridView3 dgvCompresProducte;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox ckAmbCartera;
        private System.Windows.Forms.CheckBox ckAmbDividends;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gbPigCompraOrig;
        private System.Windows.Forms.Label label3;
        private Controls.NumericTextBox2 ntbPigRealMesCartera;
        private Controls.NumericTextBox2 ntbPigActualPartsEnCartera;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.DataGridView dgvPiGEnCartera;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label lbPiGEnCartera;
        private System.Windows.Forms.ComboBox cbAnysPiGEnCartera;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.GroupBox gbSimulacioPig;
        private System.Windows.Forms.Button btSimulacioPiG;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controls.NumericTextBox2 ntbDiferencia;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox gbPreuPartic;
        private Controls.NumericTextBox2 ntbPreuParticipacio;
        private System.Windows.Forms.GroupBox gbFiltreDates;
        private System.Windows.Forms.CheckBox ckPiGEntreDatesNomesProdSel;
        private Controls.NumericTextBox2 tbPigEntreDates;
        private Controls.DateTimePickerNullable dtpFiltreDataInici;
        private System.Windows.Forms.Button btFiltreDates;
        private Controls.DateTimePickerNullable dtpFiltreDataFi;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPigEnCarteraProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPigEnCarteraPig;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTotalPigTributen;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbTotalPigEnCartera;
        private DataGridViewTextBoxColumn Id;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private Controls.NumericTextBoxColumn2 PigDeLaCompra;
        private Controls.NumericTextBoxColumn2 PigOrigen;
        private Controls.NumericTextBoxColumn2 colAny;
        private DataGridViewTextBoxColumn colPigTributa;
        private NumericTextBox2 ntbPigCompra;
        private NumericTextBox2 ntbPigCompraOrig;
        private NumericTextBox2 ntbPiG;
    }
}
