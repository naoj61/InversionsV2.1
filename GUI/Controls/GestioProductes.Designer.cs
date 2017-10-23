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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbMoneda = new System.Windows.Forms.GroupBox();
            this.lbMoneda = new System.Windows.Forms.Label();
            this.gbUsuari = new System.Windows.Forms.GroupBox();
            this.lbUsuari = new System.Windows.Forms.Label();
            this.gbIsinMercat = new System.Windows.Forms.GroupBox();
            this.tbMercat = new System.Windows.Forms.TextBox();
            this.tbIsin = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPiGReal = new Controls.NumericTextBox2();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tbDividends = new Controls.NumericTextBox2();
            this.gbDescripcio = new System.Windows.Forms.GroupBox();
            this.tbDescripcio = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbPiGActual = new Controls.NumericTextBox2();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.tbValorActual = new Controls.NumericTextBox2();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.tbParticipacions = new Controls.NumericTextBox2();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lbProductesTab2 = new System.Windows.Forms.ListBox();
            this.gbFiltres = new System.Windows.Forms.GroupBox();
            this.btFiltra = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ckNomesAmbParticipacions = new System.Windows.Forms.CheckBox();
            this.ckAmbMoviments = new System.Windows.Forms.CheckBox();
            this.pnFiltreAny = new System.Windows.Forms.Panel();
            this.gbFiltreAny = new System.Windows.Forms.GroupBox();
            this.cbFiltreAny = new System.Windows.Forms.ComboBox();
            this.ckFiltreVendesAny = new System.Windows.Forms.CheckBox();
            this.ckFiltreCompresAny = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbTipusProducteFiltreTab2 = new System.Windows.Forms.ComboBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lbEmpresa = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.gbMoneda.SuspendLayout();
            this.gbUsuari.SuspendLayout();
            this.gbIsinMercat.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbDescripcio.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.gbFiltres.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnFiltreAny.SuspendLayout();
            this.gbFiltreAny.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbMoneda);
            this.panel1.Controls.Add(this.gbUsuari);
            this.panel1.Controls.Add(this.gbIsinMercat);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.gbDescripcio);
            this.panel1.Controls.Add(this.groupBox4);
            this.panel1.Controls.Add(this.groupBox15);
            this.panel1.Controls.Add(this.groupBox13);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(539, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(336, 625);
            this.panel1.TabIndex = 11;
            // 
            // gbMoneda
            // 
            this.gbMoneda.Controls.Add(this.lbMoneda);
            this.gbMoneda.Location = new System.Drawing.Point(8, 173);
            this.gbMoneda.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.gbMoneda.Name = "gbMoneda";
            this.gbMoneda.Padding = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.gbMoneda.Size = new System.Drawing.Size(74, 38);
            this.gbMoneda.TabIndex = 8;
            this.gbMoneda.TabStop = false;
            this.gbMoneda.Text = "Moneda";
            // 
            // lbMoneda
            // 
            this.lbMoneda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoneda.Location = new System.Drawing.Point(9, 18);
            this.lbMoneda.Name = "lbMoneda";
            this.lbMoneda.Size = new System.Drawing.Size(56, 17);
            this.lbMoneda.TabIndex = 0;
            // 
            // gbUsuari
            // 
            this.gbUsuari.Controls.Add(this.lbUsuari);
            this.gbUsuari.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbUsuari.Location = new System.Drawing.Point(0, 46);
            this.gbUsuari.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.gbUsuari.Name = "gbUsuari";
            this.gbUsuari.Padding = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.gbUsuari.Size = new System.Drawing.Size(336, 46);
            this.gbUsuari.TabIndex = 7;
            this.gbUsuari.TabStop = false;
            this.gbUsuari.Text = "Usuari";
            // 
            // lbUsuari
            // 
            this.lbUsuari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUsuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuari.Location = new System.Drawing.Point(9, 18);
            this.lbUsuari.Name = "lbUsuari";
            this.lbUsuari.Size = new System.Drawing.Size(318, 25);
            this.lbUsuari.TabIndex = 0;
            this.lbUsuari.Text = "Usuari";
            // 
            // gbIsinMercat
            // 
            this.gbIsinMercat.Controls.Add(this.tbMercat);
            this.gbIsinMercat.Controls.Add(this.tbIsin);
            this.gbIsinMercat.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbIsinMercat.Location = new System.Drawing.Point(0, 0);
            this.gbIsinMercat.Margin = new System.Windows.Forms.Padding(3, 3, 9, 3);
            this.gbIsinMercat.Name = "gbIsinMercat";
            this.gbIsinMercat.Padding = new System.Windows.Forms.Padding(9, 3, 9, 3);
            this.gbIsinMercat.Size = new System.Drawing.Size(336, 46);
            this.gbIsinMercat.TabIndex = 0;
            this.gbIsinMercat.TabStop = false;
            this.gbIsinMercat.Text = "ISIN";
            // 
            // tbMercat
            // 
            this.tbMercat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMercat.Location = new System.Drawing.Point(147, 18);
            this.tbMercat.Name = "tbMercat";
            this.tbMercat.ReadOnly = true;
            this.tbMercat.Size = new System.Drawing.Size(106, 22);
            this.tbMercat.TabIndex = 1;
            this.tbMercat.Text = "Mercat";
            this.tbMercat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbIsin
            // 
            this.tbIsin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIsin.Location = new System.Drawing.Point(14, 18);
            this.tbIsin.Name = "tbIsin";
            this.tbIsin.ReadOnly = true;
            this.tbIsin.Size = new System.Drawing.Size(106, 22);
            this.tbIsin.TabIndex = 0;
            this.tbIsin.Text = "ISIN";
            this.tbIsin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbPiGReal);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(171, 224);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox2.Size = new System.Drawing.Size(156, 50);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PiG Acumulat";
            this.toolTip1.SetToolTip(this.groupBox2, "(Vendes o vendesT) + participacions en cartera");
            // 
            // tbPiGReal
            // 
            this.tbPiGReal._Format = "#,#0.00 €";
            this.tbPiGReal._PermetDecimals = true;
            this.tbPiGReal._PermetEspais = false;
            this.tbPiGReal._PermetNegatius = true;
            this.tbPiGReal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPiGReal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPiGReal.Location = new System.Drawing.Point(5, 18);
            this.tbPiGReal.Name = "tbPiGReal";
            this.tbPiGReal.ReadOnly = true;
            this.tbPiGReal.Size = new System.Drawing.Size(146, 22);
            this.tbPiGReal.TabIndex = 0;
            this.tbPiGReal.Text = "0,00 €";
            this.tbPiGReal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbPiGReal, "PiG de les vendes reals. No inclou dividends");
            this.tbPiGReal.Valor = 0D;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.tbDividends);
            this.groupBox3.Location = new System.Drawing.Point(171, 167);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox3.Size = new System.Drawing.Size(156, 50);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dividends";
            this.toolTip1.SetToolTip(this.groupBox3, "Dividends historics");
            // 
            // tbDividends
            // 
            this.tbDividends._Format = "#,#0.00 €";
            this.tbDividends._PermetDecimals = true;
            this.tbDividends._PermetEspais = false;
            this.tbDividends._PermetNegatius = true;
            this.tbDividends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDividends.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDividends.Location = new System.Drawing.Point(5, 18);
            this.tbDividends.Name = "tbDividends";
            this.tbDividends.ReadOnly = true;
            this.tbDividends.Size = new System.Drawing.Size(146, 22);
            this.tbDividends.TabIndex = 0;
            this.tbDividends.Text = "0,00 €";
            this.tbDividends.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbDividends, "Dividends historics");
            this.tbDividends.Valor = 0D;
            // 
            // gbDescripcio
            // 
            this.gbDescripcio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDescripcio.Controls.Add(this.tbDescripcio);
            this.gbDescripcio.Location = new System.Drawing.Point(6, 280);
            this.gbDescripcio.Name = "gbDescripcio";
            this.gbDescripcio.Size = new System.Drawing.Size(319, 337);
            this.gbDescripcio.TabIndex = 6;
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
            this.tbDescripcio.Size = new System.Drawing.Size(313, 316);
            this.tbDescripcio.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.tbPiGActual);
            this.groupBox4.Location = new System.Drawing.Point(7, 224);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox4.Size = new System.Drawing.Size(156, 50);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PiG Actual";
            this.toolTip1.SetToolTip(this.groupBox4, "PiG de les participacions actualment en cartera");
            // 
            // tbPiGActual
            // 
            this.tbPiGActual._Format = "#,#0.00 €";
            this.tbPiGActual._PermetDecimals = true;
            this.tbPiGActual._PermetEspais = false;
            this.tbPiGActual._PermetNegatius = true;
            this.tbPiGActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPiGActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPiGActual.Location = new System.Drawing.Point(5, 18);
            this.tbPiGActual.Name = "tbPiGActual";
            this.tbPiGActual.ReadOnly = true;
            this.tbPiGActual.Size = new System.Drawing.Size(146, 22);
            this.tbPiGActual.TabIndex = 0;
            this.tbPiGActual.Text = "0,00 €";
            this.tbPiGActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbPiGActual, "PiG de la cartera actual.");
            this.tbPiGActual.Valor = 0D;
            // 
            // groupBox15
            // 
            this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox15.Controls.Add(this.tbValorActual);
            this.groupBox15.Location = new System.Drawing.Point(7, 111);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox15.Size = new System.Drawing.Size(156, 50);
            this.groupBox15.TabIndex = 1;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Valor Actual";
            this.toolTip1.SetToolTip(this.groupBox15, "Valor de les participacions en cartera segons l\'últim valor");
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
            this.toolTip1.SetToolTip(this.tbValorActual, "Valor de les participacions en cartera segons l\'últim valor");
            this.tbValorActual.Valor = 0D;
            // 
            // groupBox13
            // 
            this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox13.Controls.Add(this.tbParticipacions);
            this.groupBox13.Location = new System.Drawing.Point(171, 111);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox13.Size = new System.Drawing.Size(156, 50);
            this.groupBox13.TabIndex = 2;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Participacions";
            this.toolTip1.SetToolTip(this.groupBox13, "Número de participacions en cartera");
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
            this.toolTip1.SetToolTip(this.tbParticipacions, "Número de participacions en cartera");
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
            this.panel2.Size = new System.Drawing.Size(539, 625);
            this.panel2.TabIndex = 12;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lbProductesTab2);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 178);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox6.Size = new System.Drawing.Size(539, 447);
            this.groupBox6.TabIndex = 2;
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
            this.lbProductesTab2.Size = new System.Drawing.Size(529, 422);
            this.lbProductesTab2.TabIndex = 0;
            this.lbProductesTab2.SelectedIndexChanged += new System.EventHandler(this.lbProductesTab2_SelectedIndexChanged);
            // 
            // gbFiltres
            // 
            this.gbFiltres.Controls.Add(this.panel4);
            this.gbFiltres.Controls.Add(this.btFiltra);
            this.gbFiltres.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFiltres.Location = new System.Drawing.Point(0, 64);
            this.gbFiltres.Name = "gbFiltres";
            this.gbFiltres.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.gbFiltres.Size = new System.Drawing.Size(539, 114);
            this.gbFiltres.TabIndex = 1;
            this.gbFiltres.TabStop = false;
            this.gbFiltres.Text = "Filtres";
            // 
            // btFiltra
            // 
            this.btFiltra.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btFiltra.Location = new System.Drawing.Point(3, 80);
            this.btFiltra.Name = "btFiltra";
            this.btFiltra.Size = new System.Drawing.Size(533, 31);
            this.btFiltra.TabIndex = 4;
            this.btFiltra.Text = "Filtra";
            this.btFiltra.UseVisualStyleBackColor = true;
            this.btFiltra.Click += new System.EventHandler(this.btFiltra_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pnFiltreAny);
            this.panel4.Controls.Add(this.ckAmbMoviments);
            this.panel4.Controls.Add(this.ckNomesAmbParticipacions);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 15);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(533, 65);
            this.panel4.TabIndex = 1;
            // 
            // ckNomesAmbParticipacions
            // 
            this.ckNomesAmbParticipacions.AutoSize = true;
            this.ckNomesAmbParticipacions.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckNomesAmbParticipacions.Checked = true;
            this.ckNomesAmbParticipacions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckNomesAmbParticipacions.Dock = System.Windows.Forms.DockStyle.Left;
            this.ckNomesAmbParticipacions.Location = new System.Drawing.Point(3, 3);
            this.ckNomesAmbParticipacions.Margin = new System.Windows.Forms.Padding(0);
            this.ckNomesAmbParticipacions.Name = "ckNomesAmbParticipacions";
            this.ckNomesAmbParticipacions.Size = new System.Drawing.Size(100, 59);
            this.ckNomesAmbParticipacions.TabIndex = 0;
            this.ckNomesAmbParticipacions.Text = "Amb\r\nParticipacions";
            this.ckNomesAmbParticipacions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckNomesAmbParticipacions.UseVisualStyleBackColor = true;
            // 
            // ckAmbMoviments
            // 
            this.ckAmbMoviments.AutoSize = true;
            this.ckAmbMoviments.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckAmbMoviments.Checked = true;
            this.ckAmbMoviments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAmbMoviments.Dock = System.Windows.Forms.DockStyle.Left;
            this.ckAmbMoviments.Location = new System.Drawing.Point(103, 3);
            this.ckAmbMoviments.Margin = new System.Windows.Forms.Padding(0);
            this.ckAmbMoviments.Name = "ckAmbMoviments";
            this.ckAmbMoviments.Size = new System.Drawing.Size(79, 59);
            this.ckAmbMoviments.TabIndex = 7;
            this.ckAmbMoviments.Text = "Amb\r\nMoviments";
            this.ckAmbMoviments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.ckAmbMoviments, "Filtre productes que no han tingut moviments pel usuari.");
            this.ckAmbMoviments.UseVisualStyleBackColor = true;
            // 
            // pnFiltreAny
            // 
            this.pnFiltreAny.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnFiltreAny.Controls.Add(this.gbFiltreAny);
            this.pnFiltreAny.Controls.Add(this.ckFiltreVendesAny);
            this.pnFiltreAny.Controls.Add(this.ckFiltreCompresAny);
            this.pnFiltreAny.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnFiltreAny.Location = new System.Drawing.Point(182, 3);
            this.pnFiltreAny.Name = "pnFiltreAny";
            this.pnFiltreAny.Padding = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.pnFiltreAny.Size = new System.Drawing.Size(203, 59);
            this.pnFiltreAny.TabIndex = 6;
            // 
            // gbFiltreAny
            // 
            this.gbFiltreAny.Controls.Add(this.cbFiltreAny);
            this.gbFiltreAny.Location = new System.Drawing.Point(128, 11);
            this.gbFiltreAny.Margin = new System.Windows.Forms.Padding(0, 9, 3, 0);
            this.gbFiltreAny.Name = "gbFiltreAny";
            this.gbFiltreAny.Size = new System.Drawing.Size(69, 43);
            this.gbFiltreAny.TabIndex = 5;
            this.gbFiltreAny.TabStop = false;
            this.gbFiltreAny.Text = "Any";
            // 
            // cbFiltreAny
            // 
            this.cbFiltreAny.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbFiltreAny.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFiltreAny.Enabled = false;
            this.cbFiltreAny.FormattingEnabled = true;
            this.cbFiltreAny.Location = new System.Drawing.Point(3, 18);
            this.cbFiltreAny.Name = "cbFiltreAny";
            this.cbFiltreAny.Size = new System.Drawing.Size(63, 24);
            this.cbFiltreAny.TabIndex = 3;
            // 
            // ckFiltreVendesAny
            // 
            this.ckFiltreVendesAny.AutoSize = true;
            this.ckFiltreVendesAny.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckFiltreVendesAny.Location = new System.Drawing.Point(68, 13);
            this.ckFiltreVendesAny.Margin = new System.Windows.Forms.Padding(0);
            this.ckFiltreVendesAny.Name = "ckFiltreVendesAny";
            this.ckFiltreVendesAny.Size = new System.Drawing.Size(60, 38);
            this.ckFiltreVendesAny.TabIndex = 2;
            this.ckFiltreVendesAny.Text = "Vendes";
            this.ckFiltreVendesAny.UseVisualStyleBackColor = true;
            this.ckFiltreVendesAny.CheckedChanged += new System.EventHandler(this.ckFiltreAny_CheckedChanged);
            // 
            // ckFiltreCompresAny
            // 
            this.ckFiltreCompresAny.AutoSize = true;
            this.ckFiltreCompresAny.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckFiltreCompresAny.Location = new System.Drawing.Point(0, 13);
            this.ckFiltreCompresAny.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.ckFiltreCompresAny.Name = "ckFiltreCompresAny";
            this.ckFiltreCompresAny.Size = new System.Drawing.Size(68, 38);
            this.ckFiltreCompresAny.TabIndex = 4;
            this.ckFiltreCompresAny.Text = "Compres";
            this.ckFiltreCompresAny.UseVisualStyleBackColor = true;
            this.ckFiltreCompresAny.CheckedChanged += new System.EventHandler(this.ckFiltreAny_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox5);
            this.panel3.Controls.Add(this.groupBox11);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(539, 64);
            this.panel3.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbTipusProducteFiltreTab2);
            this.groupBox5.Location = new System.Drawing.Point(9, 3);
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
            // groupBox11
            // 
            this.groupBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox11.Controls.Add(this.lbEmpresa);
            this.groupBox11.Location = new System.Drawing.Point(172, 7);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(365, 50);
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
            this.lbEmpresa.Size = new System.Drawing.Size(359, 29);
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
            this.Size = new System.Drawing.Size(875, 625);
            this.Load += new System.EventHandler(this.GestioProductes_Load);
            this.panel1.ResumeLayout(false);
            this.gbMoneda.ResumeLayout(false);
            this.gbUsuari.ResumeLayout(false);
            this.gbIsinMercat.ResumeLayout(false);
            this.gbIsinMercat.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbDescripcio.ResumeLayout(false);
            this.gbDescripcio.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.gbFiltres.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnFiltreAny.ResumeLayout(false);
            this.pnFiltreAny.PerformLayout();
            this.gbFiltreAny.ResumeLayout(false);
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
        private NumericTextBox2 tbPiGReal;
        private GroupBox groupBox4;
        private NumericTextBox2 tbPiGActual;
        private GroupBox groupBox3;
        private NumericTextBox2 tbDividends;
        private GroupBox groupBox15;
        private NumericTextBox2 tbValorActual;
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
        private GroupBox gbIsinMercat;
        private TextBox tbMercat;
        private TextBox tbIsin;
        private ToolTip toolTip1;
        private GroupBox gbUsuari;
        private Label lbUsuari;
        private GroupBox gbMoneda;
        private Label lbMoneda;
        private Panel panel4;
        private CheckBox ckFiltreVendesAny;
        private ComboBox cbFiltreAny;
        private Button btFiltra;
        private CheckBox ckFiltreCompresAny;
        private GroupBox gbFiltreAny;
        private Panel pnFiltreAny;
        private CheckBox ckAmbMoviments;
    }
}
