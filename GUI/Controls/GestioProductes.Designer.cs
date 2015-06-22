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
            this.gbMercatProd = new System.Windows.Forms.GroupBox();
            this.lbMercat = new System.Windows.Forms.Label();
            this.gbIsinProd = new System.Windows.Forms.GroupBox();
            this.lbIsin = new System.Windows.Forms.Label();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.tbValorActual = new Controls.NumericTextBox2();
            this.groupBox17 = new System.Windows.Forms.GroupBox();
            this.tbValorVenda = new Controls.NumericTextBox2();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.tbValorCompra = new Controls.NumericTextBox2();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.tbParticipacions = new Controls.NumericTextBox2();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lbEmpresa = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbProductesTab2 = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbTipusProducteFiltreTab2 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbDescripcio = new System.Windows.Forms.GroupBox();
            this.tbDescripcio = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPiG = new Controls.NumericTextBox2();
            this.gbFiltres = new System.Windows.Forms.GroupBox();
            this.ckNomesAmbParticipacions = new System.Windows.Forms.CheckBox();
            this.tbTotalInvertit = new Controls.NumericTextBox2();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbInversioActual = new Controls.NumericTextBox2();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbDiferencia = new Controls.NumericTextBox2();
            this.gbMercatProd.SuspendLayout();
            this.gbIsinProd.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox17.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbDescripcio.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbFiltres.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbMercatProd
            // 
            this.gbMercatProd.Controls.Add(this.lbMercat);
            this.gbMercatProd.Location = new System.Drawing.Point(262, 3);
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
            // gbIsinProd
            // 
            this.gbIsinProd.Controls.Add(this.lbIsin);
            this.gbIsinProd.Location = new System.Drawing.Point(3, 3);
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
            this.lbIsin.Size = new System.Drawing.Size(229, 32);
            this.lbIsin.TabIndex = 0;
            this.lbIsin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox15
            // 
            this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox15.Controls.Add(this.tbValorActual);
            this.groupBox15.Location = new System.Drawing.Point(631, 202);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox15.Size = new System.Drawing.Size(158, 50);
            this.groupBox15.TabIndex = 8;
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
            this.tbValorActual.Size = new System.Drawing.Size(148, 22);
            this.tbValorActual.TabIndex = 0;
            this.tbValorActual.Text = "0,00 €";
            this.tbValorActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValorActual.Valor = 0D;
            // 
            // groupBox17
            // 
            this.groupBox17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox17.Controls.Add(this.tbValorVenda);
            this.groupBox17.Location = new System.Drawing.Point(633, 146);
            this.groupBox17.Name = "groupBox17";
            this.groupBox17.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox17.Size = new System.Drawing.Size(158, 50);
            this.groupBox17.TabIndex = 7;
            this.groupBox17.TabStop = false;
            this.groupBox17.Text = "Import Total Vendes";
            // 
            // tbValorVenda
            // 
            this.tbValorVenda._Format = "#,#0.00 €";
            this.tbValorVenda._PermetDecimals = true;
            this.tbValorVenda._PermetEspais = false;
            this.tbValorVenda._PermetNegatius = true;
            this.tbValorVenda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbValorVenda.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbValorVenda.Location = new System.Drawing.Point(5, 18);
            this.tbValorVenda.Name = "tbValorVenda";
            this.tbValorVenda.ReadOnly = true;
            this.tbValorVenda.Size = new System.Drawing.Size(148, 22);
            this.tbValorVenda.TabIndex = 0;
            this.tbValorVenda.Text = "0,00 €";
            this.tbValorVenda.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValorVenda.Valor = 0D;
            // 
            // groupBox14
            // 
            this.groupBox14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox14.Controls.Add(this.tbValorCompra);
            this.groupBox14.Location = new System.Drawing.Point(469, 146);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox14.Size = new System.Drawing.Size(158, 50);
            this.groupBox14.TabIndex = 6;
            this.groupBox14.TabStop = false;
            this.groupBox14.Text = "Import Total Compres";
            // 
            // tbValorCompra
            // 
            this.tbValorCompra._Format = "#,#0.00 €";
            this.tbValorCompra._PermetDecimals = true;
            this.tbValorCompra._PermetEspais = false;
            this.tbValorCompra._PermetNegatius = true;
            this.tbValorCompra.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbValorCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbValorCompra.Location = new System.Drawing.Point(5, 18);
            this.tbValorCompra.Name = "tbValorCompra";
            this.tbValorCompra.ReadOnly = true;
            this.tbValorCompra.Size = new System.Drawing.Size(148, 22);
            this.tbValorCompra.TabIndex = 0;
            this.tbValorCompra.Text = "0,00 €";
            this.tbValorCompra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbValorCompra.Valor = 0D;
            // 
            // groupBox13
            // 
            this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox13.Controls.Add(this.tbParticipacions);
            this.groupBox13.Location = new System.Drawing.Point(633, 87);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox13.Size = new System.Drawing.Size(158, 50);
            this.groupBox13.TabIndex = 5;
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
            this.tbParticipacions.Size = new System.Drawing.Size(148, 22);
            this.tbParticipacions.TabIndex = 0;
            this.tbParticipacions.Text = "0,00";
            this.tbParticipacions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbParticipacions.Valor = 0D;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.lbEmpresa);
            this.groupBox11.Location = new System.Drawing.Point(175, 18);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(315, 50);
            this.groupBox11.TabIndex = 1;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Empresa";
            // 
            // lbEmpresa
            // 
            this.lbEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmpresa.Location = new System.Drawing.Point(3, 18);
            this.lbEmpresa.Name = "lbEmpresa";
            this.lbEmpresa.Size = new System.Drawing.Size(309, 29);
            this.lbEmpresa.TabIndex = 0;
            this.lbEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.lbProductesTab2);
            this.groupBox6.Location = new System.Drawing.Point(12, 146);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox6.Size = new System.Drawing.Size(451, 468);
            this.groupBox6.TabIndex = 3;
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
            this.lbProductesTab2.Size = new System.Drawing.Size(441, 443);
            this.lbProductesTab2.TabIndex = 0;
            this.lbProductesTab2.SelectedIndexChanged += new System.EventHandler(this.lbProductesTab2_SelectedIndexChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbTipusProducteFiltreTab2);
            this.groupBox5.Location = new System.Drawing.Point(12, 14);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox5.Size = new System.Drawing.Size(141, 53);
            this.groupBox5.TabIndex = 0;
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
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.gbIsinProd);
            this.flowLayoutPanel1.Controls.Add(this.gbMercatProd);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(512, 13);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(413, 64);
            this.flowLayoutPanel1.TabIndex = 4;
            // 
            // gbDescripcio
            // 
            this.gbDescripcio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDescripcio.Controls.Add(this.tbDescripcio);
            this.gbDescripcio.Location = new System.Drawing.Point(469, 314);
            this.gbDescripcio.Name = "gbDescripcio";
            this.gbDescripcio.Size = new System.Drawing.Size(322, 295);
            this.gbDescripcio.TabIndex = 9;
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
            this.tbDescripcio.Size = new System.Drawing.Size(316, 274);
            this.tbDescripcio.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbPiG);
            this.groupBox2.Location = new System.Drawing.Point(630, 258);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox2.Size = new System.Drawing.Size(158, 50);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "P i G";
            // 
            // tbPiG
            // 
            this.tbPiG._Format = "#,#0.00 €";
            this.tbPiG._PermetDecimals = true;
            this.tbPiG._PermetEspais = false;
            this.tbPiG._PermetNegatius = true;
            this.tbPiG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPiG.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPiG.Location = new System.Drawing.Point(5, 18);
            this.tbPiG.Name = "tbPiG";
            this.tbPiG.ReadOnly = true;
            this.tbPiG.Size = new System.Drawing.Size(148, 22);
            this.tbPiG.TabIndex = 0;
            this.tbPiG.Text = "0,00 €";
            this.tbPiG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPiG.Valor = 0D;
            // 
            // gbFiltres
            // 
            this.gbFiltres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFiltres.Controls.Add(this.ckNomesAmbParticipacions);
            this.gbFiltres.Location = new System.Drawing.Point(12, 75);
            this.gbFiltres.Name = "gbFiltres";
            this.gbFiltres.Size = new System.Drawing.Size(446, 64);
            this.gbFiltres.TabIndex = 10;
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
            // tbTotalInvertit
            // 
            this.tbTotalInvertit._Format = "#,#0.00 €";
            this.tbTotalInvertit._PermetDecimals = true;
            this.tbTotalInvertit._PermetEspais = false;
            this.tbTotalInvertit._PermetNegatius = true;
            this.tbTotalInvertit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTotalInvertit.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotalInvertit.Location = new System.Drawing.Point(5, 18);
            this.tbTotalInvertit.Name = "tbTotalInvertit";
            this.tbTotalInvertit.ReadOnly = true;
            this.tbTotalInvertit.Size = new System.Drawing.Size(148, 22);
            this.tbTotalInvertit.TabIndex = 0;
            this.tbTotalInvertit.Text = "0,00 €";
            this.tbTotalInvertit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTotalInvertit.Valor = 0D;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbTotalInvertit);
            this.groupBox1.Location = new System.Drawing.Point(469, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox1.Size = new System.Drawing.Size(158, 50);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Total Invertit";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tbInversioActual);
            this.groupBox3.Location = new System.Drawing.Point(473, 202);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox3.Size = new System.Drawing.Size(158, 50);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Inversió Actual";
            // 
            // tbInversioActual
            // 
            this.tbInversioActual._Format = "#,#0.00 €";
            this.tbInversioActual._PermetDecimals = true;
            this.tbInversioActual._PermetEspais = false;
            this.tbInversioActual._PermetNegatius = true;
            this.tbInversioActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbInversioActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbInversioActual.Location = new System.Drawing.Point(5, 18);
            this.tbInversioActual.Name = "tbInversioActual";
            this.tbInversioActual.ReadOnly = true;
            this.tbInversioActual.Size = new System.Drawing.Size(148, 22);
            this.tbInversioActual.TabIndex = 0;
            this.tbInversioActual.Text = "0,00 €";
            this.tbInversioActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbInversioActual.Valor = 0D;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.tbDiferencia);
            this.groupBox4.Location = new System.Drawing.Point(475, 258);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox4.Size = new System.Drawing.Size(158, 50);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "P i G Inversió Actual";
            // 
            // tbDiferencia
            // 
            this.tbDiferencia._Format = "#,#0.00 €";
            this.tbDiferencia._PermetDecimals = true;
            this.tbDiferencia._PermetEspais = false;
            this.tbDiferencia._PermetNegatius = true;
            this.tbDiferencia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDiferencia.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDiferencia.Location = new System.Drawing.Point(5, 18);
            this.tbDiferencia.Name = "tbDiferencia";
            this.tbDiferencia.ReadOnly = true;
            this.tbDiferencia.Size = new System.Drawing.Size(148, 22);
            this.tbDiferencia.TabIndex = 0;
            this.tbDiferencia.Text = "0,00 €";
            this.tbDiferencia.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbDiferencia.Valor = 0D;
            // 
            // GestioProductes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.gbFiltres);
            this.Controls.Add(this.gbDescripcio);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox15);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox17);
            this.Controls.Add(this.groupBox14);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox13);
            this.Controls.Add(this.groupBox5);
            this.MinimumSize = new System.Drawing.Size(733, 395);
            this.Name = "GestioProductes";
            this.Size = new System.Drawing.Size(801, 625);
            this.gbMercatProd.ResumeLayout(false);
            this.gbIsinProd.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox17.ResumeLayout(false);
            this.groupBox17.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.gbDescripcio.ResumeLayout(false);
            this.gbDescripcio.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbFiltres.ResumeLayout(false);
            this.gbFiltres.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox15;
        private Controls.NumericTextBox2 tbValorActual;
        private System.Windows.Forms.GroupBox groupBox17;
        private Controls.NumericTextBox2 tbValorVenda;
        private System.Windows.Forms.GroupBox groupBox14;
        private Controls.NumericTextBox2 tbValorCompra;
        private System.Windows.Forms.GroupBox groupBox13;
        private Controls.NumericTextBox2 tbParticipacions;
        private System.Windows.Forms.GroupBox gbMercatProd;
        private System.Windows.Forms.Label lbMercat;
        private System.Windows.Forms.GroupBox gbIsinProd;
        private System.Windows.Forms.Label lbIsin;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Label lbEmpresa;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox lbProductesTab2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox cbTipusProducteFiltreTab2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox gbDescripcio;
        private System.Windows.Forms.TextBox tbDescripcio;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controls.NumericTextBox2 tbPiG;
        private System.Windows.Forms.GroupBox gbFiltres;
        private System.Windows.Forms.CheckBox ckNomesAmbParticipacions;
        private Controls.NumericTextBox2 tbTotalInvertit;
        private GroupBox groupBox1;
        private GroupBox groupBox3;
        private Controls.NumericTextBox2 tbInversioActual;
        private GroupBox groupBox4;
        private Controls.NumericTextBox2 tbDiferencia;
    }
}
