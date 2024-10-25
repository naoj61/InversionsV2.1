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
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.tbParticipacions = new Controls.NumericTextBox2();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ntbPreuPartActual = new Controls.NumericTextBox2();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.tbValorActual = new Controls.NumericTextBox2();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.tbCostOrigPartsCartera = new Controls.NumericTextBox2();
            this.gbPigHistoric = new System.Windows.Forms.GroupBox();
            this.tbPigHistoric = new Controls.NumericTextBox2();
            this.gbPigEnCartera = new System.Windows.Forms.GroupBox();
            this.tbEnCartera = new Controls.NumericTextBox2();
            this.gbPigHistoricOrig = new System.Windows.Forms.GroupBox();
            this.tbPigHistoricOrig = new Controls.NumericTextBox2();
            this.gbPigEnCarteraOrig = new System.Windows.Forms.GroupBox();
            this.tbPigEnCarteraOrig = new Controls.NumericTextBox2();
            this.gbDividents = new System.Windows.Forms.GroupBox();
            this.tbDividends = new Controls.NumericTextBox2();
            this.pnDescripcioFons = new System.Windows.Forms.Panel();
            this.btDescripcioFons = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbIsinMercat = new System.Windows.Forms.GroupBox();
            this.tbMercat = new System.Windows.Forms.TextBox();
            this.tbIsin = new System.Windows.Forms.TextBox();
            this.gbMoneda = new System.Windows.Forms.GroupBox();
            this.tbMoneda = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.gbFiltres = new System.Windows.Forms.GroupBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pnSelDeselChecksProds = new System.Windows.Forms.Panel();
            this.btDeseleccionaTot = new System.Windows.Forms.Button();
            this.btSeleccionaTot = new System.Windows.Forms.Button();
            this.pnFiltreAny = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.gbFiltreAny = new System.Windows.Forms.GroupBox();
            this.cbFiltreAny = new System.Windows.Forms.ComboBox();
            this.ckFiltreCompresAny = new System.Windows.Forms.CheckBox();
            this.ckFiltreVendesAny = new System.Windows.Forms.CheckBox();
            this.ckFiltreTraspasAny = new System.Windows.Forms.CheckBox();
            this.ckFiltreDivAny = new System.Windows.Forms.CheckBox();
            this.ckNomesAmbParticipacions = new System.Windows.Forms.CheckBox();
            this.ckAmbMoviments = new System.Windows.Forms.CheckBox();
            this.gbFiltreText = new System.Windows.Forms.Panel();
            this.tbFiltreNom = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btFiltra = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.gbFons = new System.Windows.Forms.Panel();
            this.lbFons = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gbEmpresa = new System.Windows.Forms.Panel();
            this.lbEmpresa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.cbTipusProducteFiltreTab2 = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnDadesProducte.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.gbPigHistoric.SuspendLayout();
            this.gbPigEnCartera.SuspendLayout();
            this.gbPigHistoricOrig.SuspendLayout();
            this.gbPigEnCarteraOrig.SuspendLayout();
            this.gbDividents.SuspendLayout();
            this.pnDescripcioFons.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbIsinMercat.SuspendLayout();
            this.gbMoneda.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbFiltres.SuspendLayout();
            this.panel4.SuspendLayout();
            this.pnSelDeselChecksProds.SuspendLayout();
            this.pnFiltreAny.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.gbFiltreAny.SuspendLayout();
            this.gbFiltreText.SuspendLayout();
            this.panel3.SuspendLayout();
            this.gbFons.SuspendLayout();
            this.gbEmpresa.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnDadesProducte
            // 
            this.pnDadesProducte.Controls.Add(this.flowLayoutPanel2);
            this.pnDadesProducte.Controls.Add(this.panel1);
            this.pnDadesProducte.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnDadesProducte.Location = new System.Drawing.Point(758, 0);
            this.pnDadesProducte.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnDadesProducte.Name = "pnDadesProducte";
            this.pnDadesProducte.Size = new System.Drawing.Size(412, 781);
            this.pnDadesProducte.TabIndex = 1;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.groupBox13);
            this.flowLayoutPanel2.Controls.Add(this.groupBox1);
            this.flowLayoutPanel2.Controls.Add(this.groupBox15);
            this.flowLayoutPanel2.Controls.Add(this.groupBox7);
            this.flowLayoutPanel2.Controls.Add(this.gbPigHistoric);
            this.flowLayoutPanel2.Controls.Add(this.gbPigEnCartera);
            this.flowLayoutPanel2.Controls.Add(this.gbPigHistoricOrig);
            this.flowLayoutPanel2.Controls.Add(this.gbPigEnCarteraOrig);
            this.flowLayoutPanel2.Controls.Add(this.gbDividents);
            this.flowLayoutPanel2.Controls.Add(this.pnDescripcioFons);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 73);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(412, 708);
            this.flowLayoutPanel2.TabIndex = 10;
            // 
            // groupBox13
            // 
            this.groupBox13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox13.Controls.Add(this.tbParticipacions);
            this.groupBox13.Location = new System.Drawing.Point(3, 4);
            this.groupBox13.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox13.Size = new System.Drawing.Size(195, 62);
            this.groupBox13.TabIndex = 2;
            this.groupBox13.TabStop = false;
            this.groupBox13.Text = "Participacions";
            this.toolTip1.SetToolTip(this.groupBox13, "Número de participacions en cartera");
            // 
            // tbParticipacions
            // 
            this.tbParticipacions._CapturaEscape = true;
            this.tbParticipacions._Format = "#,#0.00######";
            this.tbParticipacions._NegatiusEnVermell = false;
            this.tbParticipacions._PermetDecimals = true;
            this.tbParticipacions._PermetNegatius = true;
            this.tbParticipacions._PermetTextNull = false;
            this.tbParticipacions.BackColor = System.Drawing.SystemColors.Window;
            this.tbParticipacions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbParticipacions.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbParticipacions.ForeColor = System.Drawing.Color.Black;
            this.tbParticipacions.Location = new System.Drawing.Point(6, 23);
            this.tbParticipacions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbParticipacions.Name = "tbParticipacions";
            this.tbParticipacions.ReadOnly = true;
            this.tbParticipacions.Size = new System.Drawing.Size(183, 25);
            this.tbParticipacions.TabIndex = 0;
            this.tbParticipacions.Text = "0,00";
            this.tbParticipacions.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbParticipacions, "Número de participacions en cartera");
            this.tbParticipacions.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.ntbPreuPartActual);
            this.flowLayoutPanel2.SetFlowBreak(this.groupBox1, true);
            this.groupBox1.Location = new System.Drawing.Point(204, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox1.Size = new System.Drawing.Size(195, 62);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preu Part. Actual";
            // 
            // ntbPreuPartActual
            // 
            this.ntbPreuPartActual._CapturaEscape = true;
            this.ntbPreuPartActual._Format = "#,#0.00###### €";
            this.ntbPreuPartActual._NegatiusEnVermell = false;
            this.ntbPreuPartActual._PermetDecimals = true;
            this.ntbPreuPartActual._PermetNegatius = true;
            this.ntbPreuPartActual._PermetTextNull = false;
            this.ntbPreuPartActual.BackColor = System.Drawing.SystemColors.Window;
            this.ntbPreuPartActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbPreuPartActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ntbPreuPartActual.ForeColor = System.Drawing.Color.Black;
            this.ntbPreuPartActual.Location = new System.Drawing.Point(6, 23);
            this.ntbPreuPartActual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ntbPreuPartActual.Name = "ntbPreuPartActual";
            this.ntbPreuPartActual.ReadOnly = true;
            this.ntbPreuPartActual.Size = new System.Drawing.Size(183, 25);
            this.ntbPreuPartActual.TabIndex = 0;
            this.ntbPreuPartActual.Text = "0,00 €";
            this.ntbPreuPartActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbPreuPartActual.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox15
            // 
            this.groupBox15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox15.Controls.Add(this.tbValorActual);
            this.groupBox15.Location = new System.Drawing.Point(3, 74);
            this.groupBox15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox15.Size = new System.Drawing.Size(195, 62);
            this.groupBox15.TabIndex = 4;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Valor Actual";
            this.toolTip1.SetToolTip(this.groupBox15, "Valor de les participacions en cartera segons l\'últim valor");
            // 
            // tbValorActual
            // 
            this.tbValorActual._CapturaEscape = true;
            this.tbValorActual._Format = "#,#0.00 €";
            this.tbValorActual._NegatiusEnVermell = false;
            this.tbValorActual._PermetDecimals = true;
            this.tbValorActual._PermetNegatius = true;
            this.tbValorActual._PermetTextNull = false;
            this.tbValorActual.BackColor = System.Drawing.SystemColors.Window;
            this.tbValorActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbValorActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbValorActual.ForeColor = System.Drawing.Color.Black;
            this.tbValorActual.Location = new System.Drawing.Point(6, 23);
            this.tbValorActual.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbValorActual.Name = "tbValorActual";
            this.tbValorActual.ReadOnly = true;
            this.tbValorActual.Size = new System.Drawing.Size(183, 25);
            this.tbValorActual.TabIndex = 0;
            this.tbValorActual.Text = "0,00 €";
            this.tbValorActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbValorActual, "Valor de les participacions en cartera segons l\'últim valor");
            this.tbValorActual.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.tbCostOrigPartsCartera);
            this.flowLayoutPanel2.SetFlowBreak(this.groupBox7, true);
            this.groupBox7.Location = new System.Drawing.Point(204, 74);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox7.Size = new System.Drawing.Size(195, 62);
            this.groupBox7.TabIndex = 5;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Cost Original";
            this.toolTip1.SetToolTip(this.groupBox7, "És el cost de les compres reals de les parts en cartera.");
            // 
            // tbCostOrigPartsCartera
            // 
            this.tbCostOrigPartsCartera._CapturaEscape = true;
            this.tbCostOrigPartsCartera._Format = "#,#0.00 €";
            this.tbCostOrigPartsCartera._NegatiusEnVermell = false;
            this.tbCostOrigPartsCartera._PermetDecimals = true;
            this.tbCostOrigPartsCartera._PermetNegatius = true;
            this.tbCostOrigPartsCartera._PermetTextNull = false;
            this.tbCostOrigPartsCartera.BackColor = System.Drawing.SystemColors.Window;
            this.tbCostOrigPartsCartera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCostOrigPartsCartera.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCostOrigPartsCartera.ForeColor = System.Drawing.Color.Black;
            this.tbCostOrigPartsCartera.Location = new System.Drawing.Point(6, 23);
            this.tbCostOrigPartsCartera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbCostOrigPartsCartera.Name = "tbCostOrigPartsCartera";
            this.tbCostOrigPartsCartera.ReadOnly = true;
            this.tbCostOrigPartsCartera.Size = new System.Drawing.Size(183, 25);
            this.tbCostOrigPartsCartera.TabIndex = 0;
            this.tbCostOrigPartsCartera.Text = "0,00 €";
            this.tbCostOrigPartsCartera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbCostOrigPartsCartera, "Cost original total de les participacions actualment en cartera");
            this.tbCostOrigPartsCartera.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // gbPigHistoric
            // 
            this.gbPigHistoric.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPigHistoric.Controls.Add(this.tbPigHistoric);
            this.gbPigHistoric.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPigHistoric.Location = new System.Drawing.Point(3, 144);
            this.gbPigHistoric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPigHistoric.Name = "gbPigHistoric";
            this.gbPigHistoric.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbPigHistoric.Size = new System.Drawing.Size(195, 62);
            this.gbPigHistoric.TabIndex = 6;
            this.gbPigHistoric.TabStop = false;
            this.gbPigHistoric.Text = "PiG Prod";
            this.toolTip1.SetToolTip(this.gbPigHistoric, "PiG cartera + vendes reals + dividents - despeses, sense tenir en compte el preu " +
        "original en cas de traspàs.");
            // 
            // tbPigHistoric
            // 
            this.tbPigHistoric._CapturaEscape = true;
            this.tbPigHistoric._Format = "#,#0.00 €";
            this.tbPigHistoric._NegatiusEnVermell = true;
            this.tbPigHistoric._PermetDecimals = true;
            this.tbPigHistoric._PermetNegatius = true;
            this.tbPigHistoric._PermetTextNull = false;
            this.tbPigHistoric.BackColor = System.Drawing.SystemColors.Window;
            this.tbPigHistoric.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPigHistoric.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPigHistoric.ForeColor = System.Drawing.Color.Black;
            this.tbPigHistoric.Location = new System.Drawing.Point(6, 22);
            this.tbPigHistoric.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPigHistoric.Name = "tbPigHistoric";
            this.tbPigHistoric.ReadOnly = true;
            this.tbPigHistoric.Size = new System.Drawing.Size(183, 25);
            this.tbPigHistoric.TabIndex = 0;
            this.tbPigHistoric.Text = "0,00 €";
            this.tbPigHistoric.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbPigHistoric, "PiG històric. No inclou dividends");
            this.tbPigHistoric.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // gbPigEnCartera
            // 
            this.gbPigEnCartera.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPigEnCartera.Controls.Add(this.tbEnCartera);
            this.flowLayoutPanel2.SetFlowBreak(this.gbPigEnCartera, true);
            this.gbPigEnCartera.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPigEnCartera.Location = new System.Drawing.Point(204, 144);
            this.gbPigEnCartera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPigEnCartera.Name = "gbPigEnCartera";
            this.gbPigEnCartera.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbPigEnCartera.Size = new System.Drawing.Size(195, 62);
            this.gbPigEnCartera.TabIndex = 7;
            this.gbPigEnCartera.TabStop = false;
            this.gbPigEnCartera.Text = "PiG Prod En Cartera";
            this.toolTip1.SetToolTip(this.gbPigEnCartera, "PiG cartera - despeses.");
            // 
            // tbEnCartera
            // 
            this.tbEnCartera._CapturaEscape = true;
            this.tbEnCartera._Format = "#,#0.00 €";
            this.tbEnCartera._NegatiusEnVermell = true;
            this.tbEnCartera._PermetDecimals = true;
            this.tbEnCartera._PermetNegatius = true;
            this.tbEnCartera._PermetTextNull = false;
            this.tbEnCartera.BackColor = System.Drawing.SystemColors.Window;
            this.tbEnCartera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbEnCartera.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEnCartera.ForeColor = System.Drawing.Color.Black;
            this.tbEnCartera.Location = new System.Drawing.Point(6, 22);
            this.tbEnCartera.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbEnCartera.Name = "tbEnCartera";
            this.tbEnCartera.ReadOnly = true;
            this.tbEnCartera.Size = new System.Drawing.Size(183, 25);
            this.tbEnCartera.TabIndex = 0;
            this.tbEnCartera.Text = "0,00 €";
            this.tbEnCartera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbEnCartera, "Valor actual - Valor compra real (No compra traspàs)");
            this.tbEnCartera.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // gbPigHistoricOrig
            // 
            this.gbPigHistoricOrig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPigHistoricOrig.Controls.Add(this.tbPigHistoricOrig);
            this.gbPigHistoricOrig.Location = new System.Drawing.Point(3, 214);
            this.gbPigHistoricOrig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPigHistoricOrig.Name = "gbPigHistoricOrig";
            this.gbPigHistoricOrig.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbPigHistoricOrig.Size = new System.Drawing.Size(195, 62);
            this.gbPigHistoricOrig.TabIndex = 8;
            this.gbPigHistoricOrig.TabStop = false;
            this.gbPigHistoricOrig.Text = "PiG Origen";
            this.toolTip1.SetToolTip(this.gbPigHistoricOrig, "PiG participacions en cartera + vendes reals des del cost inicial.");
            this.gbPigHistoricOrig.Visible = false;
            // 
            // tbPigHistoricOrig
            // 
            this.tbPigHistoricOrig._CapturaEscape = true;
            this.tbPigHistoricOrig._Format = "#,#0.00 €";
            this.tbPigHistoricOrig._NegatiusEnVermell = true;
            this.tbPigHistoricOrig._PermetDecimals = true;
            this.tbPigHistoricOrig._PermetNegatius = true;
            this.tbPigHistoricOrig._PermetTextNull = false;
            this.tbPigHistoricOrig.BackColor = System.Drawing.SystemColors.Window;
            this.tbPigHistoricOrig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPigHistoricOrig.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPigHistoricOrig.ForeColor = System.Drawing.Color.Black;
            this.tbPigHistoricOrig.Location = new System.Drawing.Point(6, 23);
            this.tbPigHistoricOrig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPigHistoricOrig.Name = "tbPigHistoricOrig";
            this.tbPigHistoricOrig.ReadOnly = true;
            this.tbPigHistoricOrig.Size = new System.Drawing.Size(183, 25);
            this.tbPigHistoricOrig.TabIndex = 0;
            this.tbPigHistoricOrig.Text = "0,00 €";
            this.tbPigHistoricOrig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbPigHistoricOrig, "PiG de la cartera actual.");
            this.tbPigHistoricOrig.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // gbPigEnCarteraOrig
            // 
            this.gbPigEnCarteraOrig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPigEnCarteraOrig.Controls.Add(this.tbPigEnCarteraOrig);
            this.flowLayoutPanel2.SetFlowBreak(this.gbPigEnCarteraOrig, true);
            this.gbPigEnCarteraOrig.Location = new System.Drawing.Point(204, 214);
            this.gbPigEnCarteraOrig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbPigEnCarteraOrig.Name = "gbPigEnCarteraOrig";
            this.gbPigEnCarteraOrig.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbPigEnCarteraOrig.Size = new System.Drawing.Size(195, 62);
            this.gbPigEnCarteraOrig.TabIndex = 8;
            this.gbPigEnCarteraOrig.TabStop = false;
            this.gbPigEnCarteraOrig.Text = "PiG Orig En Cartera";
            this.toolTip1.SetToolTip(this.gbPigEnCarteraOrig, "PiG participacions en cartera des del cost inicial.");
            this.gbPigEnCarteraOrig.Visible = false;
            // 
            // tbPigEnCarteraOrig
            // 
            this.tbPigEnCarteraOrig._CapturaEscape = true;
            this.tbPigEnCarteraOrig._Format = "#,#0.00 €";
            this.tbPigEnCarteraOrig._NegatiusEnVermell = true;
            this.tbPigEnCarteraOrig._PermetDecimals = true;
            this.tbPigEnCarteraOrig._PermetNegatius = true;
            this.tbPigEnCarteraOrig._PermetTextNull = false;
            this.tbPigEnCarteraOrig.BackColor = System.Drawing.SystemColors.Window;
            this.tbPigEnCarteraOrig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbPigEnCarteraOrig.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPigEnCarteraOrig.ForeColor = System.Drawing.Color.Black;
            this.tbPigEnCarteraOrig.Location = new System.Drawing.Point(6, 23);
            this.tbPigEnCarteraOrig.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPigEnCarteraOrig.Name = "tbPigEnCarteraOrig";
            this.tbPigEnCarteraOrig.ReadOnly = true;
            this.tbPigEnCarteraOrig.Size = new System.Drawing.Size(183, 25);
            this.tbPigEnCarteraOrig.TabIndex = 0;
            this.tbPigEnCarteraOrig.Text = "0,00 €";
            this.tbPigEnCarteraOrig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPigEnCarteraOrig.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // gbDividents
            // 
            this.gbDividents.Controls.Add(this.tbDividends);
            this.gbDividents.Location = new System.Drawing.Point(3, 284);
            this.gbDividents.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbDividents.Name = "gbDividents";
            this.gbDividents.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.gbDividents.Size = new System.Drawing.Size(195, 62);
            this.gbDividents.TabIndex = 0;
            this.gbDividents.TabStop = false;
            this.gbDividents.Text = "Dividends";
            this.toolTip1.SetToolTip(this.gbDividents, "Dividends historics");
            this.gbDividents.Visible = false;
            // 
            // tbDividends
            // 
            this.tbDividends._CapturaEscape = true;
            this.tbDividends._Format = "#,#0.00 €";
            this.tbDividends._NegatiusEnVermell = true;
            this.tbDividends._PermetDecimals = true;
            this.tbDividends._PermetNegatius = true;
            this.tbDividends._PermetTextNull = false;
            this.tbDividends.BackColor = System.Drawing.SystemColors.Window;
            this.tbDividends.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDividends.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDividends.ForeColor = System.Drawing.Color.Black;
            this.tbDividends.Location = new System.Drawing.Point(6, 23);
            this.tbDividends.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDividends.Name = "tbDividends";
            this.tbDividends.ReadOnly = true;
            this.tbDividends.Size = new System.Drawing.Size(183, 25);
            this.tbDividends.TabIndex = 0;
            this.tbDividends.Text = "0,00 €";
            this.tbDividends.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.tbDividends, "Dividends historics");
            this.tbDividends.Valor = new decimal(new int[] {
            0,
            0,
            0,
            131072});
            // 
            // pnDescripcioFons
            // 
            this.pnDescripcioFons.Controls.Add(this.btDescripcioFons);
            this.pnDescripcioFons.Location = new System.Drawing.Point(204, 284);
            this.pnDescripcioFons.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnDescripcioFons.Name = "pnDescripcioFons";
            this.pnDescripcioFons.Padding = new System.Windows.Forms.Padding(6, 11, 6, 6);
            this.pnDescripcioFons.Size = new System.Drawing.Size(195, 61);
            this.pnDescripcioFons.TabIndex = 1;
            this.pnDescripcioFons.Visible = false;
            // 
            // btDescripcioFons
            // 
            this.btDescripcioFons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btDescripcioFons.Location = new System.Drawing.Point(6, 11);
            this.btDescripcioFons.Name = "btDescripcioFons";
            this.btDescripcioFons.Size = new System.Drawing.Size(183, 44);
            this.btDescripcioFons.TabIndex = 0;
            this.btDescripcioFons.Text = "Descripció";
            this.btDescripcioFons.UseVisualStyleBackColor = true;
            this.btDescripcioFons.Click += new System.EventHandler(this.btDescripcioFons_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.gbIsinMercat);
            this.panel1.Controls.Add(this.gbMoneda);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 9);
            this.panel1.Size = new System.Drawing.Size(412, 73);
            this.panel1.TabIndex = 11;
            // 
            // gbIsinMercat
            // 
            this.gbIsinMercat.Controls.Add(this.tbMercat);
            this.gbIsinMercat.Controls.Add(this.tbIsin);
            this.gbIsinMercat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbIsinMercat.Location = new System.Drawing.Point(0, 0);
            this.gbIsinMercat.Margin = new System.Windows.Forms.Padding(3, 4, 10, 4);
            this.gbIsinMercat.Name = "gbIsinMercat";
            this.gbIsinMercat.Padding = new System.Windows.Forms.Padding(10, 4, 10, 10);
            this.gbIsinMercat.Size = new System.Drawing.Size(318, 64);
            this.gbIsinMercat.TabIndex = 0;
            this.gbIsinMercat.TabStop = false;
            this.gbIsinMercat.Text = "Mercat";
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
            this.tbIsin.TabStop = false;
            this.tbIsin.Text = "ISIN";
            this.tbIsin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbMoneda
            // 
            this.gbMoneda.Controls.Add(this.tbMoneda);
            this.gbMoneda.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbMoneda.Location = new System.Drawing.Point(318, 0);
            this.gbMoneda.Margin = new System.Windows.Forms.Padding(3, 4, 10, 4);
            this.gbMoneda.Name = "gbMoneda";
            this.gbMoneda.Padding = new System.Windows.Forms.Padding(10, 5, 10, 4);
            this.gbMoneda.Size = new System.Drawing.Size(94, 64);
            this.gbMoneda.TabIndex = 1;
            this.gbMoneda.TabStop = false;
            this.gbMoneda.Text = "Moneda";
            // 
            // tbMoneda
            // 
            this.tbMoneda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbMoneda.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbMoneda.Location = new System.Drawing.Point(10, 24);
            this.tbMoneda.Name = "tbMoneda";
            this.tbMoneda.ReadOnly = true;
            this.tbMoneda.Size = new System.Drawing.Size(74, 25);
            this.tbMoneda.TabIndex = 0;
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
            this.panel2.Size = new System.Drawing.Size(758, 781);
            this.panel2.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 267);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox6.Size = new System.Drawing.Size(758, 514);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Productes";
            // 
            // gbFiltres
            // 
            this.gbFiltres.Controls.Add(this.panel4);
            this.gbFiltres.Controls.Add(this.gbFiltreText);
            this.gbFiltres.Controls.Add(this.btFiltra);
            this.gbFiltres.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFiltres.Location = new System.Drawing.Point(0, 80);
            this.gbFiltres.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbFiltres.Name = "gbFiltres";
            this.gbFiltres.Padding = new System.Windows.Forms.Padding(3, 0, 3, 4);
            this.gbFiltres.Size = new System.Drawing.Size(758, 187);
            this.gbFiltres.TabIndex = 1;
            this.gbFiltres.TabStop = false;
            this.gbFiltres.Text = "Filtres";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.pnSelDeselChecksProds);
            this.panel4.Controls.Add(this.pnFiltreAny);
            this.panel4.Controls.Add(this.ckNomesAmbParticipacions);
            this.panel4.Controls.Add(this.ckAmbMoviments);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 19);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(3, 3, 3, 9);
            this.panel4.Size = new System.Drawing.Size(752, 92);
            this.panel4.TabIndex = 0;
            // 
            // pnSelDeselChecksProds
            // 
            this.pnSelDeselChecksProds.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnSelDeselChecksProds.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnSelDeselChecksProds.Controls.Add(this.btDeseleccionaTot);
            this.pnSelDeselChecksProds.Controls.Add(this.btSeleccionaTot);
            this.pnSelDeselChecksProds.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnSelDeselChecksProds.Location = new System.Drawing.Point(538, 3);
            this.pnSelDeselChecksProds.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.pnSelDeselChecksProds.Name = "pnSelDeselChecksProds";
            this.pnSelDeselChecksProds.Padding = new System.Windows.Forms.Padding(3);
            this.pnSelDeselChecksProds.Size = new System.Drawing.Size(208, 80);
            this.pnSelDeselChecksProds.TabIndex = 2;
            this.pnSelDeselChecksProds.Visible = false;
            // 
            // btDeseleccionaTot
            // 
            this.btDeseleccionaTot.Location = new System.Drawing.Point(107, 10);
            this.btDeseleccionaTot.Name = "btDeseleccionaTot";
            this.btDeseleccionaTot.Size = new System.Drawing.Size(93, 60);
            this.btDeseleccionaTot.TabIndex = 1;
            this.btDeseleccionaTot.Text = "Deselec\r\nTot";
            this.btDeseleccionaTot.UseVisualStyleBackColor = true;
            this.btDeseleccionaTot.Click += new System.EventHandler(this.btDeseleccionaTot_Click);
            // 
            // btSeleccionaTot
            // 
            this.btSeleccionaTot.Location = new System.Drawing.Point(7, 10);
            this.btSeleccionaTot.Name = "btSeleccionaTot";
            this.btSeleccionaTot.Size = new System.Drawing.Size(93, 60);
            this.btSeleccionaTot.TabIndex = 0;
            this.btSeleccionaTot.Text = "Selec\r\nTot";
            this.btSeleccionaTot.UseVisualStyleBackColor = true;
            this.btSeleccionaTot.Click += new System.EventHandler(this.btSeleccionaTot_Click);
            // 
            // pnFiltreAny
            // 
            this.pnFiltreAny.AutoSize = true;
            this.pnFiltreAny.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnFiltreAny.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnFiltreAny.Controls.Add(this.flowLayoutPanel1);
            this.pnFiltreAny.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnFiltreAny.Location = new System.Drawing.Point(203, 3);
            this.pnFiltreAny.Margin = new System.Windows.Forms.Padding(0);
            this.pnFiltreAny.Name = "pnFiltreAny";
            this.pnFiltreAny.Size = new System.Drawing.Size(335, 80);
            this.pnFiltreAny.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowLayoutPanel1.Controls.Add(this.gbFiltreAny);
            this.flowLayoutPanel1.Controls.Add(this.ckFiltreCompresAny);
            this.flowLayoutPanel1.Controls.Add(this.ckFiltreVendesAny);
            this.flowLayoutPanel1.Controls.Add(this.ckFiltreTraspasAny);
            this.flowLayoutPanel1.Controls.Add(this.ckFiltreDivAny);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(333, 78);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // gbFiltreAny
            // 
            this.gbFiltreAny.Controls.Add(this.cbFiltreAny);
            this.gbFiltreAny.Location = new System.Drawing.Point(5, 10);
            this.gbFiltreAny.Margin = new System.Windows.Forms.Padding(5, 10, 0, 0);
            this.gbFiltreAny.Name = "gbFiltreAny";
            this.gbFiltreAny.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbFiltreAny.Size = new System.Drawing.Size(78, 54);
            this.gbFiltreAny.TabIndex = 0;
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
            this.cbFiltreAny.TabIndex = 0;
            // 
            // ckFiltreCompresAny
            // 
            this.ckFiltreCompresAny.AutoSize = true;
            this.ckFiltreCompresAny.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckFiltreCompresAny.Location = new System.Drawing.Point(83, 10);
            this.ckFiltreCompresAny.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ckFiltreCompresAny.Name = "ckFiltreCompresAny";
            this.ckFiltreCompresAny.Size = new System.Drawing.Size(77, 45);
            this.ckFiltreCompresAny.TabIndex = 1;
            this.ckFiltreCompresAny.Text = "Compres";
            this.ckFiltreCompresAny.UseVisualStyleBackColor = true;
            this.ckFiltreCompresAny.CheckedChanged += new System.EventHandler(this.ckFiltreAny_CheckedChanged);
            // 
            // ckFiltreVendesAny
            // 
            this.ckFiltreVendesAny.AutoSize = true;
            this.ckFiltreVendesAny.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckFiltreVendesAny.Location = new System.Drawing.Point(160, 10);
            this.ckFiltreVendesAny.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ckFiltreVendesAny.Name = "ckFiltreVendesAny";
            this.ckFiltreVendesAny.Size = new System.Drawing.Size(68, 45);
            this.ckFiltreVendesAny.TabIndex = 2;
            this.ckFiltreVendesAny.Text = "Vendes";
            this.ckFiltreVendesAny.UseVisualStyleBackColor = true;
            this.ckFiltreVendesAny.CheckedChanged += new System.EventHandler(this.ckFiltreAny_CheckedChanged);
            // 
            // ckFiltreTraspasAny
            // 
            this.ckFiltreTraspasAny.AutoSize = true;
            this.ckFiltreTraspasAny.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckFiltreTraspasAny.Enabled = false;
            this.ckFiltreTraspasAny.Location = new System.Drawing.Point(228, 10);
            this.ckFiltreTraspasAny.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ckFiltreTraspasAny.Name = "ckFiltreTraspasAny";
            this.ckFiltreTraspasAny.Size = new System.Drawing.Size(70, 45);
            this.ckFiltreTraspasAny.TabIndex = 3;
            this.ckFiltreTraspasAny.Text = "Traspàs";
            this.ckFiltreTraspasAny.UseVisualStyleBackColor = true;
            this.ckFiltreTraspasAny.CheckedChanged += new System.EventHandler(this.ckFiltreAny_CheckedChanged);
            // 
            // ckFiltreDivAny
            // 
            this.ckFiltreDivAny.AutoSize = true;
            this.ckFiltreDivAny.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckFiltreDivAny.Location = new System.Drawing.Point(298, 10);
            this.ckFiltreDivAny.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.ckFiltreDivAny.Name = "ckFiltreDivAny";
            this.ckFiltreDivAny.Size = new System.Drawing.Size(35, 45);
            this.ckFiltreDivAny.TabIndex = 4;
            this.ckFiltreDivAny.Text = "Div";
            this.ckFiltreDivAny.UseVisualStyleBackColor = true;
            this.ckFiltreDivAny.CheckedChanged += new System.EventHandler(this.ckFiltreAny_CheckedChanged);
            // 
            // ckNomesAmbParticipacions
            // 
            this.ckNomesAmbParticipacions.AutoSize = true;
            this.ckNomesAmbParticipacions.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ckNomesAmbParticipacions.Checked = true;
            this.ckNomesAmbParticipacions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckNomesAmbParticipacions.Dock = System.Windows.Forms.DockStyle.Left;
            this.ckNomesAmbParticipacions.Location = new System.Drawing.Point(92, 3);
            this.ckNomesAmbParticipacions.Margin = new System.Windows.Forms.Padding(0);
            this.ckNomesAmbParticipacions.Name = "ckNomesAmbParticipacions";
            this.ckNomesAmbParticipacions.Size = new System.Drawing.Size(111, 80);
            this.ckNomesAmbParticipacions.TabIndex = 1;
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
            this.ckAmbMoviments.Location = new System.Drawing.Point(3, 3);
            this.ckAmbMoviments.Margin = new System.Windows.Forms.Padding(0);
            this.ckAmbMoviments.Name = "ckAmbMoviments";
            this.ckAmbMoviments.Size = new System.Drawing.Size(89, 80);
            this.ckAmbMoviments.TabIndex = 0;
            this.ckAmbMoviments.Text = "Amb\r\nMoviments";
            this.ckAmbMoviments.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.ckAmbMoviments, "Filtre productes que no han tingut moviments pel usuari.");
            this.ckAmbMoviments.UseVisualStyleBackColor = true;
            // 
            // gbFiltreText
            // 
            this.gbFiltreText.Controls.Add(this.tbFiltreNom);
            this.gbFiltreText.Controls.Add(this.label2);
            this.gbFiltreText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbFiltreText.Location = new System.Drawing.Point(3, 111);
            this.gbFiltreText.Name = "gbFiltreText";
            this.gbFiltreText.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.gbFiltreText.Size = new System.Drawing.Size(752, 33);
            this.gbFiltreText.TabIndex = 1;
            this.gbFiltreText.Text = "Filtre Text";
            // 
            // tbFiltreNom
            // 
            this.tbFiltreNom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFiltreNom.Location = new System.Drawing.Point(92, 3);
            this.tbFiltreNom.Margin = new System.Windows.Forms.Padding(0);
            this.tbFiltreNom.Name = "tbFiltreNom";
            this.tbFiltreNom.Size = new System.Drawing.Size(655, 26);
            this.tbFiltreNom.TabIndex = 1;
            this.tbFiltreNom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbFiltreNom_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(5, 3);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 4, 9, 0);
            this.label2.Size = new System.Drawing.Size(87, 24);
            this.label2.TabIndex = 0;
            this.label2.Text = "Filtre Text";
            // 
            // btFiltra
            // 
            this.btFiltra.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btFiltra.Location = new System.Drawing.Point(3, 144);
            this.btFiltra.Name = "btFiltra";
            this.btFiltra.Size = new System.Drawing.Size(752, 39);
            this.btFiltra.TabIndex = 2;
            this.btFiltra.Text = "Filtra";
            this.btFiltra.UseVisualStyleBackColor = true;
            this.btFiltra.Click += new System.EventHandler(this.btFiltra_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.gbFons);
            this.panel3.Controls.Add(this.gbEmpresa);
            this.panel3.Controls.Add(this.groupBox5);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.panel3.Size = new System.Drawing.Size(758, 80);
            this.panel3.TabIndex = 0;
            // 
            // gbFons
            // 
            this.gbFons.Controls.Add(this.lbFons);
            this.gbFons.Controls.Add(this.label3);
            this.gbFons.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbFons.Location = new System.Drawing.Point(168, 35);
            this.gbFons.Name = "gbFons";
            this.gbFons.Padding = new System.Windows.Forms.Padding(3);
            this.gbFons.Size = new System.Drawing.Size(590, 35);
            this.gbFons.TabIndex = 2;
            // 
            // lbFons
            // 
            this.lbFons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbFons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFons.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFons.Location = new System.Drawing.Point(78, 3);
            this.lbFons.Name = "lbFons";
            this.lbFons.Size = new System.Drawing.Size(509, 29);
            this.lbFons.TabIndex = 1;
            this.lbFons.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbFons.DoubleClick += new System.EventHandler(this.lbFons_DoubleClick);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label3.Size = new System.Drawing.Size(75, 29);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fons";
            // 
            // gbEmpresa
            // 
            this.gbEmpresa.Controls.Add(this.lbEmpresa);
            this.gbEmpresa.Controls.Add(this.label1);
            this.gbEmpresa.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbEmpresa.Location = new System.Drawing.Point(168, 0);
            this.gbEmpresa.Name = "gbEmpresa";
            this.gbEmpresa.Padding = new System.Windows.Forms.Padding(3);
            this.gbEmpresa.Size = new System.Drawing.Size(590, 35);
            this.gbEmpresa.TabIndex = 1;
            // 
            // lbEmpresa
            // 
            this.lbEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEmpresa.Location = new System.Drawing.Point(78, 3);
            this.lbEmpresa.Name = "lbEmpresa";
            this.lbEmpresa.Size = new System.Drawing.Size(509, 29);
            this.lbEmpresa.TabIndex = 1;
            this.lbEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbEmpresa.DoubleClick += new System.EventHandler(this.lbEmpresa_DoubleClick);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 2, 0, 0);
            this.label1.Size = new System.Drawing.Size(75, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Empresa";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbTipusProducteFiltreTab2);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(9, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(6);
            this.groupBox5.Size = new System.Drawing.Size(159, 80);
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
            // GestioProductes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnDadesProducte);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GestioProductes";
            this.Size = new System.Drawing.Size(1170, 781);
            this.Load += new System.EventHandler(this.GestioProductes_Load);
            this.pnDadesProducte.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox15.ResumeLayout(false);
            this.groupBox15.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.gbPigHistoric.ResumeLayout(false);
            this.gbPigHistoric.PerformLayout();
            this.gbPigEnCartera.ResumeLayout(false);
            this.gbPigEnCartera.PerformLayout();
            this.gbPigHistoricOrig.ResumeLayout(false);
            this.gbPigHistoricOrig.PerformLayout();
            this.gbPigEnCarteraOrig.ResumeLayout(false);
            this.gbPigEnCarteraOrig.PerformLayout();
            this.gbDividents.ResumeLayout(false);
            this.gbDividents.PerformLayout();
            this.pnDescripcioFons.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.gbIsinMercat.ResumeLayout(false);
            this.gbIsinMercat.PerformLayout();
            this.gbMoneda.ResumeLayout(false);
            this.gbMoneda.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.gbFiltres.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.pnSelDeselChecksProds.ResumeLayout(false);
            this.pnFiltreAny.ResumeLayout(false);
            this.pnFiltreAny.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.gbFiltreAny.ResumeLayout(false);
            this.gbFiltreText.ResumeLayout(false);
            this.gbFiltreText.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.gbFons.ResumeLayout(false);
            this.gbEmpresa.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Panel pnDadesProducte;
        private GroupBox gbPigHistoric;
        private NumericTextBox2 tbPigHistoric;
        private GroupBox gbPigHistoricOrig;
        private NumericTextBox2 tbPigHistoricOrig;
        private GroupBox gbDividents;
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
        private Label lbEmpresa;
        private GroupBox gbIsinMercat;
        private TextBox tbMercat;
        private TextBox tbIsin;
        private ToolTip toolTip1;
        private GroupBox gbMoneda;
        private TextBox tbMoneda;
        private Panel panel4;
        private Button btFiltra;
        private Panel pnFiltreAny;
        private CheckBox ckAmbMoviments;
        private GroupBox groupBox1;
        private NumericTextBox2 ntbPreuPartActual;
        private Panel pnSelDeselChecksProds;
        private Button btDeseleccionaTot;
        private Button btSeleccionaTot;
        private Panel gbEmpresa;
        private Label label1;
        private Panel gbFons;
        private Label lbFons;
        private Label label3;
        private GroupBox groupBox7;
        private NumericTextBox2 tbCostOrigPartsCartera;
        private GroupBox gbPigEnCartera;
        private NumericTextBox2 tbEnCartera;
        private FlowLayoutPanel flowLayoutPanel1;
        private GroupBox gbFiltreAny;
        private ComboBox cbFiltreAny;
        private CheckBox ckFiltreCompresAny;
        private CheckBox ckFiltreVendesAny;
        private CheckBox ckFiltreDivAny;
        private CheckBox ckFiltreTraspasAny;
        private TextBox tbFiltreNom;
        private Panel gbFiltreText;
        private Label label2;
        private FlowLayoutPanel flowLayoutPanel2;
        private GroupBox gbPigEnCarteraOrig;
        private NumericTextBox2 tbPigEnCarteraOrig;
        private Panel pnDescripcioFons;
        private Button btDescripcioFons;
        private Panel panel1;
    }
}
