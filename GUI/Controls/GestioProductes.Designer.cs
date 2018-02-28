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
            this.pnDadesProducte = new System.Windows.Forms.Panel();
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ntbPreuPartActual = new Controls.NumericTextBox2();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.tbParticipacions = new Controls.NumericTextBox2();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.gbFiltres = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ckAmbMoviments = new System.Windows.Forms.CheckBox();
            this.ckNomesAmbParticipacions = new System.Windows.Forms.CheckBox();
            this.pnFiltreAny = new System.Windows.Forms.Panel();
            this.gbFiltreAny = new System.Windows.Forms.GroupBox();
            this.cbFiltreAny = new System.Windows.Forms.ComboBox();
            this.ckFiltreVendesAny = new System.Windows.Forms.CheckBox();
            this.ckFiltreCompresAny = new System.Windows.Forms.CheckBox();
            this.pnSelDeselChecksProds = new System.Windows.Forms.Panel();
            this.btDeseleccionaTot = new System.Windows.Forms.Button();
            this.btSeleccionaTot = new System.Windows.Forms.Button();
            this.btFiltra = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbTipusProducteFiltreTab2 = new System.Windows.Forms.ComboBox();
            this.gbEmpresa = new System.Windows.Forms.GroupBox();
            this.lbEmpresa = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnDadesProducte.SuspendLayout();
            this.gbMoneda.SuspendLayout();
            this.gbUsuari.SuspendLayout();
            this.gbIsinMercat.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbDescripcio.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbFiltres.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnFiltreAny.SuspendLayout();
            this.gbFiltreAny.SuspendLayout();
            this.pnSelDeselChecksProds.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbEmpresa.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnDadesProducte
            // 
            this.pnDadesProducte.Controls.Add(this.gbMoneda);
            this.pnDadesProducte.Controls.Add(this.gbUsuari);
            this.pnDadesProducte.Controls.Add(this.gbIsinMercat);
            this.pnDadesProducte.Controls.Add(this.groupBox2);
            this.pnDadesProducte.Controls.Add(this.groupBox3);
            this.pnDadesProducte.Controls.Add(this.gbDescripcio);
            this.pnDadesProducte.Controls.Add(this.groupBox4);
            this.pnDadesProducte.Controls.Add(this.groupBox15);
            this.pnDadesProducte.Controls.Add(this.groupBox1);
            this.pnDadesProducte.Controls.Add(this.groupBox13);
            this.pnDadesProducte.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnDadesProducte.Location = new System.Drawing.Point(702, 0);
            this.pnDadesProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnDadesProducte.Name = "pnDadesProducte";
            this.pnDadesProducte.Size = new System.Drawing.Size(378, 781);
            this.pnDadesProducte.TabIndex = 11;
            // 
            // gbMoneda
            // 
            this.gbMoneda.Controls.Add(this.lbMoneda);
            this.gbMoneda.Location = new System.Drawing.Point(279, 65);
            this.gbMoneda.Margin = new System.Windows.Forms.Padding(3, 4, 10, 4);
            this.gbMoneda.Name = "gbMoneda";
            this.gbMoneda.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.gbMoneda.Size = new System.Drawing.Size(83, 58);
            this.gbMoneda.TabIndex = 8;
            this.gbMoneda.TabStop = false;
            this.gbMoneda.Text = "Moneda";
            // 
            // lbMoneda
            // 
            this.lbMoneda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMoneda.Location = new System.Drawing.Point(10, 23);
            this.lbMoneda.Name = "lbMoneda";
            this.lbMoneda.Size = new System.Drawing.Size(63, 31);
            this.lbMoneda.TabIndex = 0;
            // 
            // gbUsuari
            // 
            this.gbUsuari.Controls.Add(this.lbUsuari);
            this.gbUsuari.Location = new System.Drawing.Point(8, 65);
            this.gbUsuari.Margin = new System.Windows.Forms.Padding(3, 4, 10, 4);
            this.gbUsuari.Name = "gbUsuari";
            this.gbUsuari.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.gbUsuari.Size = new System.Drawing.Size(260, 58);
            this.gbUsuari.TabIndex = 7;
            this.gbUsuari.TabStop = false;
            this.gbUsuari.Text = "Usuari";
            // 
            // lbUsuari
            // 
            this.lbUsuari.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbUsuari.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsuari.Location = new System.Drawing.Point(10, 23);
            this.lbUsuari.Name = "lbUsuari";
            this.lbUsuari.Size = new System.Drawing.Size(240, 31);
            this.lbUsuari.TabIndex = 0;
            this.lbUsuari.Text = "Usuari";
            // 
            // gbIsinMercat
            // 
            this.gbIsinMercat.Controls.Add(this.tbMercat);
            this.gbIsinMercat.Controls.Add(this.tbIsin);
            this.gbIsinMercat.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbIsinMercat.Location = new System.Drawing.Point(0, 0);
            this.gbIsinMercat.Margin = new System.Windows.Forms.Padding(3, 4, 10, 4);
            this.gbIsinMercat.Name = "gbIsinMercat";
            this.gbIsinMercat.Padding = new System.Windows.Forms.Padding(10, 4, 10, 4);
            this.gbIsinMercat.Size = new System.Drawing.Size(378, 58);
            this.gbIsinMercat.TabIndex = 0;
            this.gbIsinMercat.TabStop = false;
            this.gbIsinMercat.Text = "ISIN";
            // 
            // tbMercat
            // 
            this.tbMercat.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMercat.Location = new System.Drawing.Point(165, 22);
            this.tbMercat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbMercat.Name = "tbMercat";
            this.tbMercat.ReadOnly = true;
            this.tbMercat.Size = new System.Drawing.Size(119, 25);
            this.tbMercat.TabIndex = 1;
            this.tbMercat.Text = "Mercat";
            this.tbMercat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbIsin
            // 
            this.tbIsin.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbIsin.Location = new System.Drawing.Point(16, 22);
            this.tbIsin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbIsin.Name = "tbIsin";
            this.tbIsin.ReadOnly = true;
            this.tbIsin.Size = new System.Drawing.Size(119, 25);
            this.tbIsin.TabIndex = 0;
            this.tbIsin.Text = "ISIN";
            this.tbIsin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbPiGReal);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(192, 278);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox2.Size = new System.Drawing.Size(176, 62);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "PiG Acumulat";
            this.toolTip1.SetToolTip(this.groupBox2, "(Vendes o vendesT) + participacions en cartera");
            // 
            // tbPiGReal
            // 
            this.tbPiGReal._CapturaEscape = true;
            this.tbPiGReal._Format = "#,#0.00 €";
            this.tbPiGReal._PermetDecimals = true;
            this.tbPiGReal._PermetEspais = false;
            this.tbPiGReal._PermetNegatius = true;
            this.tbPiGReal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPiGReal.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPiGReal.Location = new System.Drawing.Point(6, 22);
            this.tbPiGReal.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPiGReal.Name = "tbPiGReal";
            this.tbPiGReal.ReadOnly = true;
            this.tbPiGReal.Size = new System.Drawing.Size(164, 25);
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
            this.groupBox3.Location = new System.Drawing.Point(192, 205);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox3.Size = new System.Drawing.Size(176, 62);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Dividends";
            this.toolTip1.SetToolTip(this.groupBox3, "Dividends historics");
            // 
            // tbDividends
            // 
            this.tbDividends._CapturaEscape = true;
            this.tbDividends._Format = "#,#0.00 €";
            this.tbDividends._PermetDecimals = true;
            this.tbDividends._PermetEspais = false;
            this.tbDividends._PermetNegatius = true;
            this.tbDividends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDividends.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDividends.Location = new System.Drawing.Point(6, 23);
            this.tbDividends.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDividends.Name = "tbDividends";
            this.tbDividends.ReadOnly = true;
            this.tbDividends.Size = new System.Drawing.Size(164, 25);
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
            this.gbDescripcio.Location = new System.Drawing.Point(7, 350);
            this.gbDescripcio.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDescripcio.Name = "gbDescripcio";
            this.gbDescripcio.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDescripcio.Size = new System.Drawing.Size(359, 421);
            this.gbDescripcio.TabIndex = 6;
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
            this.tbDescripcio.ReadOnly = true;
            this.tbDescripcio.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescripcio.Size = new System.Drawing.Size(353, 394);
            this.tbDescripcio.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.tbPiGActual);
            this.groupBox4.Location = new System.Drawing.Point(8, 278);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox4.Size = new System.Drawing.Size(176, 62);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "PiG Actual";
            this.toolTip1.SetToolTip(this.groupBox4, "PiG de les participacions actualment en cartera");
            // 
            // tbPiGActual
            // 
            this.tbPiGActual._CapturaEscape = true;
            this.tbPiGActual._Format = "#,#0.00 €";
            this.tbPiGActual._PermetDecimals = true;
            this.tbPiGActual._PermetEspais = false;
            this.tbPiGActual._PermetNegatius = true;
            this.tbPiGActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPiGActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPiGActual.Location = new System.Drawing.Point(6, 23);
            this.tbPiGActual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPiGActual.Name = "tbPiGActual";
            this.tbPiGActual.ReadOnly = true;
            this.tbPiGActual.Size = new System.Drawing.Size(164, 25);
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
            this.groupBox15.Location = new System.Drawing.Point(8, 205);
            this.groupBox15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox15.Size = new System.Drawing.Size(176, 62);
            this.groupBox15.TabIndex = 1;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Valor Actual";
            this.toolTip1.SetToolTip(this.groupBox15, "Valor de les participacions en cartera segons l\'últim valor");
            // 
            // tbValorActual
            // 
            this.tbValorActual._CapturaEscape = true;
            this.tbValorActual._Format = "#,#0.00 €";
            this.tbValorActual._PermetDecimals = true;
            this.tbValorActual._PermetEspais = false;
            this.tbValorActual._PermetNegatius = true;
            this.tbValorActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbValorActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbValorActual.Location = new System.Drawing.Point(6, 23);
            this.tbValorActual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbValorActual.Name = "tbValorActual";
            this.tbValorActual.ReadOnly = true;
            this.tbValorActual.Size = new System.Drawing.Size(164, 25);
            this.tbValorActual.TabIndex = 0;
            this.tbValorActual.Text = "0,00 €";
            this.tbValorActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbValorActual, "Valor de les participacions en cartera segons l\'últim valor");
            this.tbValorActual.Valor = 0D;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ntbPreuPartActual);
            this.groupBox1.Location = new System.Drawing.Point(192, 132);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox1.Size = new System.Drawing.Size(176, 62);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preu Part. Actual";
            // 
            // ntbPreuPartActual
            // 
            this.ntbPreuPartActual._CapturaEscape = true;
            this.ntbPreuPartActual._Format = "#,#0.00";
            this.ntbPreuPartActual._PermetDecimals = true;
            this.ntbPreuPartActual._PermetEspais = false;
            this.ntbPreuPartActual._PermetNegatius = true;
            this.ntbPreuPartActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPreuPartActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPreuPartActual.Location = new System.Drawing.Point(6, 23);
            this.ntbPreuPartActual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ntbPreuPartActual.Name = "ntbPreuPartActual";
            this.ntbPreuPartActual.ReadOnly = true;
            this.ntbPreuPartActual.Size = new System.Drawing.Size(164, 25);
            this.ntbPreuPartActual.TabIndex = 0;
            this.ntbPreuPartActual.Text = "0,00";
            this.ntbPreuPartActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPreuPartActual.Valor = 0D;
            // 
            // groupBox13
            // 
            this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox13.Controls.Add(this.tbParticipacions);
            this.groupBox13.Location = new System.Drawing.Point(8, 132);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox13.Size = new System.Drawing.Size(176, 62);
            this.groupBox13.TabIndex = 2;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Participacions";
            this.toolTip1.SetToolTip(this.groupBox13, "Número de participacions en cartera");
            // 
            // tbParticipacions
            // 
            this.tbParticipacions._CapturaEscape = true;
            this.tbParticipacions._Format = "#,#0.00";
            this.tbParticipacions._PermetDecimals = true;
            this.tbParticipacions._PermetEspais = false;
            this.tbParticipacions._PermetNegatius = true;
            this.tbParticipacions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbParticipacions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbParticipacions.Location = new System.Drawing.Point(6, 23);
            this.tbParticipacions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbParticipacions.Name = "tbParticipacions";
            this.tbParticipacions.ReadOnly = true;
            this.tbParticipacions.Size = new System.Drawing.Size(164, 25);
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
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(702, 781);
            this.panel2.TabIndex = 12;
            // 
            // groupBox6
            // 
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 222);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox6.Size = new System.Drawing.Size(702, 559);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Productes";
            // 
            // gbFiltres
            // 
            this.gbFiltres.Controls.Add(this.panel4);
            this.gbFiltres.Controls.Add(this.btFiltra);
            this.gbFiltres.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFiltres.Location = new System.Drawing.Point(0, 80);
            this.gbFiltres.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbFiltres.Name = "gbFiltres";
            this.gbFiltres.Padding = new System.Windows.Forms.Padding(3, 0, 3, 4);
            this.gbFiltres.Size = new System.Drawing.Size(702, 142);
            this.gbFiltres.TabIndex = 1;
            this.gbFiltres.TabStop = false;
            this.gbFiltres.Text = "Filtres";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.ckAmbMoviments);
            this.panel4.Controls.Add(this.ckNomesAmbParticipacions);
            this.panel4.Controls.Add(this.pnFiltreAny);
            this.panel4.Controls.Add(this.pnSelDeselChecksProds);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 19);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3);
            this.panel4.Size = new System.Drawing.Size(696, 80);
            this.panel4.TabIndex = 1;
            // 
            // ckAmbMoviments
            // 
            this.ckAmbMoviments.AutoSize = true;
            this.ckAmbMoviments.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckAmbMoviments.Checked = true;
            this.ckAmbMoviments.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckAmbMoviments.Location = new System.Drawing.Point(3, 3);
            this.ckAmbMoviments.Margin = new System.Windows.Forms.Padding(0);
            this.ckAmbMoviments.Name = "ckAmbMoviments";
            this.ckAmbMoviments.Size = new System.Drawing.Size(89, 65);
            this.ckAmbMoviments.TabIndex = 7;
            this.ckAmbMoviments.Text = "Amb\r\nMoviments";
            this.ckAmbMoviments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.ckAmbMoviments, "Filtre productes que no han tingut moviments pel usuari.");
            this.ckAmbMoviments.UseVisualStyleBackColor = true;
            // 
            // ckNomesAmbParticipacions
            // 
            this.ckNomesAmbParticipacions.AutoSize = true;
            this.ckNomesAmbParticipacions.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckNomesAmbParticipacions.Checked = true;
            this.ckNomesAmbParticipacions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckNomesAmbParticipacions.Location = new System.Drawing.Point(92, 3);
            this.ckNomesAmbParticipacions.Margin = new System.Windows.Forms.Padding(0);
            this.ckNomesAmbParticipacions.Name = "ckNomesAmbParticipacions";
            this.ckNomesAmbParticipacions.Size = new System.Drawing.Size(111, 65);
            this.ckNomesAmbParticipacions.TabIndex = 0;
            this.ckNomesAmbParticipacions.Text = "Amb\r\nParticipacions";
            this.ckNomesAmbParticipacions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ckNomesAmbParticipacions.UseVisualStyleBackColor = true;
            // 
            // pnFiltreAny
            // 
            this.pnFiltreAny.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnFiltreAny.Controls.Add(this.gbFiltreAny);
            this.pnFiltreAny.Controls.Add(this.ckFiltreVendesAny);
            this.pnFiltreAny.Controls.Add(this.ckFiltreCompresAny);
            this.pnFiltreAny.Location = new System.Drawing.Point(203, 3);
            this.pnFiltreAny.Margin = new System.Windows.Forms.Padding(0);
            this.pnFiltreAny.Name = "pnFiltreAny";
            this.pnFiltreAny.Size = new System.Drawing.Size(228, 72);
            this.pnFiltreAny.TabIndex = 6;
            // 
            // gbFiltreAny
            // 
            this.gbFiltreAny.Controls.Add(this.cbFiltreAny);
            this.gbFiltreAny.Location = new System.Drawing.Point(144, 14);
            this.gbFiltreAny.Margin = new System.Windows.Forms.Padding(0, 11, 3, 0);
            this.gbFiltreAny.Name = "gbFiltreAny";
            this.gbFiltreAny.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbFiltreAny.Size = new System.Drawing.Size(78, 54);
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
            this.cbFiltreAny.Location = new System.Drawing.Point(3, 23);
            this.cbFiltreAny.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbFiltreAny.Name = "cbFiltreAny";
            this.cbFiltreAny.Size = new System.Drawing.Size(72, 28);
            this.cbFiltreAny.TabIndex = 3;
            // 
            // ckFiltreVendesAny
            // 
            this.ckFiltreVendesAny.AutoSize = true;
            this.ckFiltreVendesAny.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckFiltreVendesAny.Location = new System.Drawing.Point(76, 16);
            this.ckFiltreVendesAny.Margin = new System.Windows.Forms.Padding(0);
            this.ckFiltreVendesAny.Name = "ckFiltreVendesAny";
            this.ckFiltreVendesAny.Size = new System.Drawing.Size(68, 45);
            this.ckFiltreVendesAny.TabIndex = 2;
            this.ckFiltreVendesAny.Text = "Vendes";
            this.ckFiltreVendesAny.UseVisualStyleBackColor = true;
            this.ckFiltreVendesAny.CheckedChanged += new System.EventHandler(this.ckFiltreAny_CheckedChanged);
            // 
            // ckFiltreCompresAny
            // 
            this.ckFiltreCompresAny.AutoSize = true;
            this.ckFiltreCompresAny.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckFiltreCompresAny.Location = new System.Drawing.Point(0, 15);
            this.ckFiltreCompresAny.Margin = new System.Windows.Forms.Padding(0);
            this.ckFiltreCompresAny.Name = "ckFiltreCompresAny";
            this.ckFiltreCompresAny.Size = new System.Drawing.Size(77, 45);
            this.ckFiltreCompresAny.TabIndex = 4;
            this.ckFiltreCompresAny.Text = "Compres";
            this.ckFiltreCompresAny.UseVisualStyleBackColor = true;
            this.ckFiltreCompresAny.CheckedChanged += new System.EventHandler(this.ckFiltreAny_CheckedChanged);
            // 
            // pnSelDeselChecksProds
            // 
            this.pnSelDeselChecksProds.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pnSelDeselChecksProds.AutoSize = true;
            this.pnSelDeselChecksProds.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnSelDeselChecksProds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnSelDeselChecksProds.Controls.Add(this.btDeseleccionaTot);
            this.pnSelDeselChecksProds.Controls.Add(this.btSeleccionaTot);
            this.pnSelDeselChecksProds.Location = new System.Drawing.Point(449, 3);
            this.pnSelDeselChecksProds.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnSelDeselChecksProds.Name = "pnSelDeselChecksProds";
            this.pnSelDeselChecksProds.Padding = new System.Windows.Forms.Padding(3);
            this.pnSelDeselChecksProds.Size = new System.Drawing.Size(171, 73);
            this.pnSelDeselChecksProds.TabIndex = 8;
            this.pnSelDeselChecksProds.Visible = false;
            // 
            // btDeseleccionaTot
            // 
            this.btDeseleccionaTot.Location = new System.Drawing.Point(88, 5);
            this.btDeseleccionaTot.Name = "btDeseleccionaTot";
            this.btDeseleccionaTot.Size = new System.Drawing.Size(75, 60);
            this.btDeseleccionaTot.TabIndex = 0;
            this.btDeseleccionaTot.Text = "Deselec\r\nTot";
            this.btDeseleccionaTot.UseVisualStyleBackColor = true;
            this.btDeseleccionaTot.Click += new System.EventHandler(this.btDeseleccionaTot_Click);
            // 
            // btSeleccionaTot
            // 
            this.btSeleccionaTot.Location = new System.Drawing.Point(5, 5);
            this.btSeleccionaTot.Name = "btSeleccionaTot";
            this.btSeleccionaTot.Size = new System.Drawing.Size(75, 60);
            this.btSeleccionaTot.TabIndex = 0;
            this.btSeleccionaTot.Text = "Selec\r\nTot";
            this.btSeleccionaTot.UseVisualStyleBackColor = true;
            this.btSeleccionaTot.Click += new System.EventHandler(this.btSeleccionaTot_Click);
            // 
            // btFiltra
            // 
            this.btFiltra.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btFiltra.Location = new System.Drawing.Point(3, 99);
            this.btFiltra.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btFiltra.Name = "btFiltra";
            this.btFiltra.Size = new System.Drawing.Size(696, 39);
            this.btFiltra.TabIndex = 4;
            this.btFiltra.Text = "Filtra";
            this.btFiltra.UseVisualStyleBackColor = true;
            this.btFiltra.Click += new System.EventHandler(this.btFiltra_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.groupBox5);
            this.panel3.Controls.Add(this.gbEmpresa);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(702, 80);
            this.panel3.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbTipusProducteFiltreTab2);
            this.groupBox5.Location = new System.Drawing.Point(10, 4);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox5.Size = new System.Drawing.Size(159, 66);
            this.groupBox5.TabIndex = 0;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Tipus Producte";
            // 
            // cbTipusProducteFiltreTab2
            // 
            this.cbTipusProducteFiltreTab2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTipusProducteFiltreTab2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipusProducteFiltreTab2.FormattingEnabled = true;
            this.cbTipusProducteFiltreTab2.Location = new System.Drawing.Point(6, 25);
            this.cbTipusProducteFiltreTab2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTipusProducteFiltreTab2.Name = "cbTipusProducteFiltreTab2";
            this.cbTipusProducteFiltreTab2.Size = new System.Drawing.Size(147, 28);
            this.cbTipusProducteFiltreTab2.TabIndex = 0;
            this.cbTipusProducteFiltreTab2.SelectedIndexChanged += new System.EventHandler(this.cbTipusProducteFiltreTab2_SelectedIndexChanged);
            // 
            // gbEmpresa
            // 
            this.gbEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbEmpresa.Controls.Add(this.lbEmpresa);
            this.gbEmpresa.Location = new System.Drawing.Point(194, 9);
            this.gbEmpresa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbEmpresa.Name = "gbEmpresa";
            this.gbEmpresa.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbEmpresa.Size = new System.Drawing.Size(507, 62);
            this.gbEmpresa.TabIndex = 1;
            this.gbEmpresa.TabStop = false;
            this.gbEmpresa.Text = "Empresa";
            // 
            // lbEmpresa
            // 
            this.lbEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmpresa.Location = new System.Drawing.Point(3, 23);
            this.lbEmpresa.Name = "lbEmpresa";
            this.lbEmpresa.Size = new System.Drawing.Size(501, 35);
            this.lbEmpresa.TabIndex = 0;
            this.lbEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // GestioProductes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnDadesProducte);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GestioProductes";
            this.Size = new System.Drawing.Size(1080, 781);
            this.Load += new System.EventHandler(this.GestioProductes_Load);
            this.pnDadesProducte.ResumeLayout(false);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.gbFiltres.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnFiltreAny.ResumeLayout(false);
            this.pnFiltreAny.PerformLayout();
            this.gbFiltreAny.ResumeLayout(false);
            this.pnSelDeselChecksProds.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.gbEmpresa.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnDadesProducte;
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
        private GroupBox gbFiltres;
        private CheckBox ckNomesAmbParticipacions;
        private Panel panel3;
        private GroupBox groupBox5;
        private ComboBox cbTipusProducteFiltreTab2;
        private GroupBox gbEmpresa;
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
        private GroupBox groupBox1;
        private NumericTextBox2 ntbPreuPartActual;
        private Panel pnSelDeselChecksProds;
        private Button btDeseleccionaTot;
        private Button btSeleccionaTot;
    }
}
