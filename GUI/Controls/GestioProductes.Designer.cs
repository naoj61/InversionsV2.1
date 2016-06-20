using System.Windows.Forms;
using Controls;

namespace Inversions.GUI
{
    partial class GestioProductes
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPiGTotal = new Controls.NumericTextBox2();
            this.gbDescripcio = new System.Windows.Forms.GroupBox();
            this.tbDescripcio = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPiGActiusVenuts = new Controls.NumericTextBox2();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbPiGActiusEnCartera = new Controls.NumericTextBox2();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbPreuCompra = new Controls.NumericTextBox2();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.tbValorActual = new Controls.NumericTextBox2();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbIsinProd = new System.Windows.Forms.GroupBox();
            this.lbIsin = new System.Windows.Forms.TextBox();
            this.gbMercatProd = new System.Windows.Forms.GroupBox();
            this.lbMercat = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.tbParticipacions = new Controls.NumericTextBox2();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbProductesTab2 = new System.Windows.Forms.ListBox();
            this.gbFiltres = new System.Windows.Forms.GroupBox();
            this.ckNomesAmbParticipacions = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbTipusProducteFiltreTab2 = new System.Windows.Forms.ComboBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lbEmpresa = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gbDescripcio.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbIsinProd.SuspendLayout();
            this.gbMercatProd.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gbFiltres.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.gbDescripcio);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox15);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.groupBox13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(464, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 625);
            this.panel1.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbPiGTotal);
            this.groupBox1.Location = new System.Drawing.Point(10, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox1.Size = new System.Drawing.Size(156, 50);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PiG Total";
            // 
            // tbPiGTotal
            // 
            this.tbPiGTotal._Format = "#,#0.00 €";
            this.tbPiGTotal._PermetDecimals = true;
            this.tbPiGTotal._PermetEspais = false;
            this.tbPiGTotal._PermetNegatius = true;
            this.tbPiGTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPiGTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPiGTotal.Location = new System.Drawing.Point(5, 18);
            this.tbPiGTotal.Name = "tbPiGTotal";
            this.tbPiGTotal.ReadOnly = true;
            this.tbPiGTotal.Size = new System.Drawing.Size(146, 22);
            this.tbPiGTotal.TabIndex = 0;
            this.tbPiGTotal.Text = "0,00 €";
            this.tbPiGTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPiGTotal.Valor = 0D;
            // 
            // gbDescripcio
            // 
            this.gbDescripcio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDescripcio.Controls.Add(this.tbDescripcio);
            this.gbDescripcio.Location = new System.Drawing.Point(7, 240);
            this.gbDescripcio.Name = "gbDescripcio";
            this.gbDescripcio.Size = new System.Drawing.Size(319, 378);
            this.gbDescripcio.TabIndex = 16;
            this.gbDescripcio.TabStop = false;
            this.gbDescripcio.Text = "Descripció";
            // 
            // tbDescripcio
            // 
            this.tbDescripcio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescripcio.Location = new System.Drawing.Point(3, 18);
            this.tbDescripcio.Multiline = true;
            this.tbDescripcio.Name = "tbDescripcio";
            this.tbDescripcio.ReadOnly = true;
            this.tbDescripcio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescripcio.Size = new System.Drawing.Size(313, 357);
            this.tbDescripcio.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbPiGActiusVenuts);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(10, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox2.Size = new System.Drawing.Size(156, 50);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PiG Actius Venuts";
            // 
            // tbPiGActiusVenuts
            // 
            this.tbPiGActiusVenuts._Format = "#,#0.00 €";
            this.tbPiGActiusVenuts._PermetDecimals = true;
            this.tbPiGActiusVenuts._PermetEspais = false;
            this.tbPiGActiusVenuts._PermetNegatius = true;
            this.tbPiGActiusVenuts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPiGActiusVenuts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPiGActiusVenuts.Location = new System.Drawing.Point(5, 18);
            this.tbPiGActiusVenuts.Name = "tbPiGActiusVenuts";
            this.tbPiGActiusVenuts.ReadOnly = true;
            this.tbPiGActiusVenuts.Size = new System.Drawing.Size(146, 22);
            this.tbPiGActiusVenuts.TabIndex = 0;
            this.tbPiGActiusVenuts.Text = "0,00 €";
            this.tbPiGActiusVenuts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPiGActiusVenuts.Valor = 0D;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.tbPiGActiusEnCartera);
            this.groupBox4.Location = new System.Drawing.Point(10, 127);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox4.Size = new System.Drawing.Size(156, 50);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PiG Actius en cartera";
            // 
            // tbPiGActiusEnCartera
            // 
            this.tbPiGActiusEnCartera._Format = "#,#0.00 €";
            this.tbPiGActiusEnCartera._PermetDecimals = true;
            this.tbPiGActiusEnCartera._PermetEspais = false;
            this.tbPiGActiusEnCartera._PermetNegatius = true;
            this.tbPiGActiusEnCartera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPiGActiusEnCartera.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPiGActiusEnCartera.Location = new System.Drawing.Point(5, 18);
            this.tbPiGActiusEnCartera.Name = "tbPiGActiusEnCartera";
            this.tbPiGActiusEnCartera.ReadOnly = true;
            this.tbPiGActiusEnCartera.Size = new System.Drawing.Size(146, 22);
            this.tbPiGActiusEnCartera.TabIndex = 0;
            this.tbPiGActiusEnCartera.Text = "0,00 €";
            this.tbPiGActiusEnCartera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPiGActiusEnCartera.Valor = 0D;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tbPreuCompra);
            this.groupBox3.Location = new System.Drawing.Point(173, 127);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox3.Size = new System.Drawing.Size(156, 50);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preu Compra";
            // 
            // tbPreuCompra
            // 
            this.tbPreuCompra._Format = "#,#0.00 €";
            this.tbPreuCompra._PermetDecimals = true;
            this.tbPreuCompra._PermetEspais = false;
            this.tbPreuCompra._PermetNegatius = true;
            this.tbPreuCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPreuCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPreuCompra.Location = new System.Drawing.Point(5, 18);
            this.tbPreuCompra.Name = "tbPreuCompra";
            this.tbPreuCompra.ReadOnly = true;
            this.tbPreuCompra.Size = new System.Drawing.Size(146, 22);
            this.tbPreuCompra.TabIndex = 0;
            this.tbPreuCompra.Text = "0,00 €";
            this.tbPreuCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPreuCompra.Valor = 0D;
            // 
            // groupBox15
            // 
            this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox15.Controls.Add(this.tbValorActual);
            this.groupBox15.Location = new System.Drawing.Point(173, 184);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox15.Size = new System.Drawing.Size(156, 50);
            this.groupBox15.TabIndex = 15;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Valor Actual";
            // 
            // tbValorActual
            // 
            this.tbValorActual._Format = "#,#0.00 €";
            this.tbValorActual._PermetDecimals = true;
            this.tbValorActual._PermetEspais = false;
            this.tbValorActual._PermetNegatius = true;
            this.tbValorActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbValorActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbValorActual.Location = new System.Drawing.Point(5, 18);
            this.tbValorActual.Name = "tbValorActual";
            this.tbValorActual.ReadOnly = true;
            this.tbValorActual.Size = new System.Drawing.Size(146, 22);
            this.tbValorActual.TabIndex = 0;
            this.tbValorActual.Text = "0,00 €";
            this.tbValorActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValorActual.Valor = 0D;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.gbIsinProd);
            this.flowLayoutPanel1.Controls.Add(this.gbMercatProd);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(337, 64);
            this.flowLayoutPanel1.TabIndex = 10;
            // 
            // gbIsinProd
            // 
            this.gbIsinProd.Controls.Add(this.lbIsin);
            this.gbIsinProd.Location = new System.Drawing.Point(8, 3);
            this.gbIsinProd.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.gbIsinProd.Name = "gbIsinProd";
            this.gbIsinProd.Padding = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.gbIsinProd.Size = new System.Drawing.Size(241, 53);
            this.gbIsinProd.TabIndex = 0;
            this.gbIsinProd.TabStop = false;
            this.gbIsinProd.Text = "ISIN";
            this.gbIsinProd.Visible = false;
            // 
            // lbIsin
            // 
            this.lbIsin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIsin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbIsin.Location = new System.Drawing.Point(3, 18);
            this.lbIsin.Name = "lbIsin";
            this.lbIsin.ReadOnly = true;
            this.lbIsin.Size = new System.Drawing.Size(229, 22);
            this.lbIsin.TabIndex = 0;
            this.lbIsin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbMercatProd
            // 
            this.gbMercatProd.Controls.Add(this.lbMercat);
            this.gbMercatProd.Location = new System.Drawing.Point(14, 62);
            this.gbMercatProd.Margin = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.gbMercatProd.Name = "gbMercatProd";
            this.gbMercatProd.Padding = new System.Windows.Forms.Padding(9, 3, 3, 3);
            this.gbMercatProd.Size = new System.Drawing.Size(146, 53);
            this.gbMercatProd.TabIndex = 1;
            this.gbMercatProd.TabStop = false;
            this.gbMercatProd.Text = "Mercat";
            this.gbMercatProd.Visible = false;
            // 
            // lbMercat
            // 
            this.lbMercat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMercat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMercat.Location = new System.Drawing.Point(9, 18);
            this.lbMercat.Name = "lbMercat";
            this.lbMercat.Size = new System.Drawing.Size(134, 32);
            this.lbMercat.TabIndex = 0;
            this.lbMercat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox13
            // 
            this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox13.Controls.Add(this.tbParticipacions);
            this.groupBox13.Location = new System.Drawing.Point(173, 70);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox13.Size = new System.Drawing.Size(156, 50);
            this.groupBox13.TabIndex = 11;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Participacions";
            // 
            // tbParticipacions
            // 
            this.tbParticipacions._Format = "#,#0.00";
            this.tbParticipacions._PermetDecimals = true;
            this.tbParticipacions._PermetEspais = false;
            this.tbParticipacions._PermetNegatius = true;
            this.tbParticipacions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbParticipacions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbParticipacions.Location = new System.Drawing.Point(5, 18);
            this.tbParticipacions.Name = "tbParticipacions";
            this.tbParticipacions.ReadOnly = true;
            this.tbParticipacions.Size = new System.Drawing.Size(146, 22);
            this.tbParticipacions.TabIndex = 0;
            this.tbParticipacions.Text = "0,00";
            this.tbParticipacions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbParticipacions.Valor = 0D;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox6);
            this.panel2.Controls.Add(this.gbFiltres);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(464, 625);
            this.panel2.TabIndex = 12;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbProductesTab2);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 128);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox6.Size = new System.Drawing.Size(464, 497);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Productes";
            // 
            // lbProductesTab2
            // 
            this.lbProductesTab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbProductesTab2.FormattingEnabled = true;
            this.lbProductesTab2.ItemHeight = 16;
            this.lbProductesTab2.Location = new System.Drawing.Point(5, 20);
            this.lbProductesTab2.Name = "lbProductesTab2";
            this.lbProductesTab2.Size = new System.Drawing.Size(454, 472);
            this.lbProductesTab2.TabIndex = 0;
            this.lbProductesTab2.SelectedIndexChanged += new System.EventHandler(this.lbProductesTab2_SelectedIndexChanged);
            // 
            // gbFiltres
            // 
            this.gbFiltres.Controls.Add(this.ckNomesAmbParticipacions);
            this.gbFiltres.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFiltres.Location = new System.Drawing.Point(0, 64);
            this.gbFiltres.Name = "gbFiltres";
            this.gbFiltres.Size = new System.Drawing.Size(464, 64);
            this.gbFiltres.TabIndex = 14;
            this.gbFiltres.TabStop = false;
            this.gbFiltres.Text = "Filtres";
            // 
            // ckNomesAmbParticipacions
            // 
            this.ckNomesAmbParticipacions.AutoSize = true;
            this.ckNomesAmbParticipacions.Checked = true;
            this.ckNomesAmbParticipacions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckNomesAmbParticipacions.Location = new System.Drawing.Point(6, 28);
            this.ckNomesAmbParticipacions.Name = "ckNomesAmbParticipacions";
            this.ckNomesAmbParticipacions.Size = new System.Drawing.Size(150, 21);
            this.ckNomesAmbParticipacions.TabIndex = 0;
            this.ckNomesAmbParticipacions.Text = "Amb Participacions";
            this.ckNomesAmbParticipacions.UseVisualStyleBackColor = true;
            this.ckNomesAmbParticipacions.CheckedChanged += new System.EventHandler(this.ckNomesAmbParticipacions_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox5);
            this.panel3.Controls.Add(this.groupBox11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(464, 64);
            this.panel3.TabIndex = 15;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbTipusProducteFiltreTab2);
            this.groupBox5.Location = new System.Drawing.Point(9, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox5.Size = new System.Drawing.Size(141, 53);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tipus Producte";
            // 
            // cbTipusProducteFiltreTab2
            // 
            this.cbTipusProducteFiltreTab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTipusProducteFiltreTab2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipusProducteFiltreTab2.FormattingEnabled = true;
            this.cbTipusProducteFiltreTab2.Location = new System.Drawing.Point(5, 20);
            this.cbTipusProducteFiltreTab2.Name = "cbTipusProducteFiltreTab2";
            this.cbTipusProducteFiltreTab2.Size = new System.Drawing.Size(131, 24);
            this.cbTipusProducteFiltreTab2.TabIndex = 0;
            this.cbTipusProducteFiltreTab2.SelectedIndexChanged += new System.EventHandler(this.cbTipusProducteFiltreTab2_SelectedIndexChanged);
            // 
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox11.Controls.Add(this.lbEmpresa);
            this.groupBox11.Location = new System.Drawing.Point(172, 7);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(290, 50);
            this.groupBox11.TabIndex = 12;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Empresa";
            // 
            // lbEmpresa
            // 
            this.lbEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmpresa.Location = new System.Drawing.Point(3, 18);
            this.lbEmpresa.Name = "lbEmpresa";
            this.lbEmpresa.Size = new System.Drawing.Size(284, 29);
            this.lbEmpresa.TabIndex = 0;
            this.lbEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GestioProductes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(733, 395);
            this.Name = "GestioProductes";
            this.Size = new System.Drawing.Size(801, 625);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gbDescripcio.ResumeLayout(false);
            this.gbDescripcio.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbIsinProd.ResumeLayout(false);
            this.gbIsinProd.PerformLayout();
            this.gbMercatProd.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.gbFiltres.ResumeLayout(false);
            this.gbFiltres.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private GroupBox gbDescripcio;
        private TextBox tbDescripcio;
        private GroupBox groupBox2;
        private NumericTextBox2 tbPiGActiusVenuts;
        private GroupBox groupBox4;
        private NumericTextBox2 tbPiGActiusEnCartera;
        private GroupBox groupBox3;
        private NumericTextBox2 tbPreuCompra;
        private GroupBox groupBox15;
        private NumericTextBox2 tbValorActual;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox gbIsinProd;
        private TextBox lbIsin;
        private GroupBox gbMercatProd;
        private Label lbMercat;
        private GroupBox groupBox13;
        private NumericTextBox2 tbParticipacions;
        private Panel panel2;
        private GroupBox groupBox6;
        private ListBox lbProductesTab2;
        private GroupBox gbFiltres;
        private CheckBox ckNomesAmbParticipacions;
        private Panel panel3;
        private GroupBox groupBox5;
        private ComboBox cbTipusProducteFiltreTab2;
        private GroupBox groupBox11;
        private Label lbEmpresa;
        private GroupBox groupBox1;
        private NumericTextBox2 tbPiGTotal;
    }
}
