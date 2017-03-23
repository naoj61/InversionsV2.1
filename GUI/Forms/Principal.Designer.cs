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
            this.cbTipusProducte = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbProductesTab1 = new System.Windows.Forms.ComboBox();
            this.gbNom = new System.Windows.Forms.GroupBox();
            this.tbNom = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbEmpresa = new System.Windows.Forms.ComboBox();
            this.gbIsin = new System.Windows.Forms.GroupBox();
            this.tbIsin = new System.Windows.Forms.TextBox();
            this.gbDescripcio = new System.Windows.Forms.GroupBox();
            this.tbDescripcio = new System.Windows.Forms.TextBox();
            this.gbMercat = new System.Windows.Forms.GroupBox();
            this.cbMercat = new System.Windows.Forms.ComboBox();
            this.flpDades = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tbId = new System.Windows.Forms.TextBox();
            this.gbMoneda = new System.Windows.Forms.GroupBox();
            this.cbMoneda = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbTipusProducteFiltreTab1 = new System.Windows.Forms.ComboBox();
            this.btNouProducte = new System.Windows.Forms.Button();
            this.btDesa = new System.Windows.Forms.Button();
            this.btCancela = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUsuari = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbUsuaris = new System.Windows.Forms.ComboBox();
            this.tabProductes = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.grAltaEmpresa = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.rbCotitzada = new System.Windows.Forms.RadioButton();
            this.rbGestora = new System.Windows.Forms.RadioButton();
            this.grMercat = new System.Windows.Forms.GroupBox();
            this.cbMercat2 = new System.Windows.Forms.ComboBox();
            this.gbOrdreGrid = new System.Windows.Forms.GroupBox();
            this.ntbOrdreGrid = new Controls.NumericTextBox2();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.tbNomNovaEmpresa = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.cbMoneda2 = new System.Windows.Forms.ComboBox();
            this.btEditaProducte = new System.Windows.Forms.Button();
            this.btNovaEmpresa = new System.Windows.Forms.Button();
            this.tabMoviments = new System.Windows.Forms.TabPage();
            this.movimentsTab1 = new Inversions.GUI.MovimentsTab();
            this.tabValoracions = new System.Windows.Forms.TabPage();
            this.valoracionsTab1 = new Inversions.GUI.ValoracionsTab();
            this.tabPerduesGuanys = new System.Windows.Forms.TabPage();
            this.perduesGuanysTab1 = new Inversions.GUI.PerduesGuanysTab();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbNom.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbIsin.SuspendLayout();
            this.gbDescripcio.SuspendLayout();
            this.gbMercat.SuspendLayout();
            this.flpDades.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.gbMoneda.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabUsuari.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabProductes.SuspendLayout();
            this.grAltaEmpresa.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.grMercat.SuspendLayout();
            this.gbOrdreGrid.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.tabMoviments.SuspendLayout();
            this.tabValoracions.SuspendLayout();
            this.tabPerduesGuanys.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTipusProducte
            // 
            this.cbTipusProducte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTipusProducte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipusProducte.Enabled = false;
            this.cbTipusProducte.FormattingEnabled = true;
            this.cbTipusProducte.Items.AddRange(new object[] {
            "Accions",
            "Fons"});
            this.cbTipusProducte.Location = new System.Drawing.Point(5, 20);
            this.cbTipusProducte.Name = "cbTipusProducte";
            this.cbTipusProducte.Size = new System.Drawing.Size(131, 24);
            this.cbTipusProducte.TabIndex = 0;
            this.cbTipusProducte.SelectedIndexChanged += new System.EventHandler(this.cbTipusProducte_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTipusProducte);
            this.groupBox1.Location = new System.Drawing.Point(382, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(141, 53);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipus Producte";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbProductesTab1);
            this.groupBox2.Location = new System.Drawing.Point(201, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(569, 53);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Productes";
            // 
            // cbProductesTab1
            // 
            this.cbProductesTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbProductesTab1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbProductesTab1.FormattingEnabled = true;
            this.cbProductesTab1.Location = new System.Drawing.Point(5, 20);
            this.cbProductesTab1.Name = "cbProductesTab1";
            this.cbProductesTab1.Size = new System.Drawing.Size(559, 24);
            this.cbProductesTab1.TabIndex = 0;
            // 
            // gbNom
            // 
            this.gbNom.Controls.Add(this.tbNom);
            this.gbNom.Location = new System.Drawing.Point(769, 3);
            this.gbNom.Name = "gbNom";
            this.gbNom.Padding = new System.Windows.Forms.Padding(5);
            this.gbNom.Size = new System.Drawing.Size(371, 55);
            this.gbNom.TabIndex = 3;
            this.gbNom.TabStop = false;
            this.gbNom.Text = "Nom";
            // 
            // tbNom
            // 
            this.tbNom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNom.Location = new System.Drawing.Point(5, 20);
            this.tbNom.Name = "tbNom";
            this.tbNom.Size = new System.Drawing.Size(361, 22);
            this.tbNom.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbEmpresa);
            this.groupBox4.Location = new System.Drawing.Point(45, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox4.Size = new System.Drawing.Size(331, 53);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Empresa";
            // 
            // cbEmpresa
            // 
            this.cbEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmpresa.FormattingEnabled = true;
            this.cbEmpresa.Location = new System.Drawing.Point(5, 20);
            this.cbEmpresa.Name = "cbEmpresa";
            this.cbEmpresa.Size = new System.Drawing.Size(321, 24);
            this.cbEmpresa.TabIndex = 0;
            this.cbEmpresa.SelectedIndexChanged += new System.EventHandler(this.cbEmpresa_SelectedIndexChanged);
            // 
            // gbIsin
            // 
            this.gbIsin.Controls.Add(this.tbIsin);
            this.gbIsin.Location = new System.Drawing.Point(3, 64);
            this.gbIsin.Name = "gbIsin";
            this.gbIsin.Padding = new System.Windows.Forms.Padding(5);
            this.gbIsin.Size = new System.Drawing.Size(371, 55);
            this.gbIsin.TabIndex = 4;
            this.gbIsin.TabStop = false;
            this.gbIsin.Text = "ISIN";
            // 
            // tbIsin
            // 
            this.tbIsin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbIsin.Location = new System.Drawing.Point(5, 20);
            this.tbIsin.Name = "tbIsin";
            this.tbIsin.Size = new System.Drawing.Size(361, 22);
            this.tbIsin.TabIndex = 0;
            // 
            // gbDescripcio
            // 
            this.gbDescripcio.Controls.Add(this.tbDescripcio);
            this.gbDescripcio.Location = new System.Drawing.Point(3, 125);
            this.gbDescripcio.Name = "gbDescripcio";
            this.gbDescripcio.Padding = new System.Windows.Forms.Padding(5);
            this.gbDescripcio.Size = new System.Drawing.Size(1149, 110);
            this.gbDescripcio.TabIndex = 5;
            this.gbDescripcio.TabStop = false;
            this.gbDescripcio.Text = "Descripció";
            // 
            // tbDescripcio
            // 
            this.tbDescripcio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDescripcio.Location = new System.Drawing.Point(5, 20);
            this.tbDescripcio.Multiline = true;
            this.tbDescripcio.Name = "tbDescripcio";
            this.tbDescripcio.Size = new System.Drawing.Size(1139, 85);
            this.tbDescripcio.TabIndex = 0;
            // 
            // gbMercat
            // 
            this.gbMercat.Controls.Add(this.cbMercat);
            this.gbMercat.Location = new System.Drawing.Point(529, 3);
            this.gbMercat.Name = "gbMercat";
            this.gbMercat.Padding = new System.Windows.Forms.Padding(5);
            this.gbMercat.Size = new System.Drawing.Size(234, 53);
            this.gbMercat.TabIndex = 2;
            this.gbMercat.TabStop = false;
            this.gbMercat.Text = "Mercat";
            // 
            // cbMercat
            // 
            this.cbMercat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMercat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMercat.FormattingEnabled = true;
            this.cbMercat.Location = new System.Drawing.Point(5, 20);
            this.cbMercat.Name = "cbMercat";
            this.cbMercat.Size = new System.Drawing.Size(224, 24);
            this.cbMercat.TabIndex = 0;
            // 
            // flpDades
            // 
            this.flpDades.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpDades.Controls.Add(this.groupBox5);
            this.flpDades.Controls.Add(this.groupBox4);
            this.flpDades.Controls.Add(this.groupBox1);
            this.flpDades.Controls.Add(this.gbMercat);
            this.flpDades.Controls.Add(this.gbNom);
            this.flpDades.Controls.Add(this.gbMoneda);
            this.flpDades.Controls.Add(this.gbIsin);
            this.flpDades.Controls.Add(this.gbDescripcio);
            this.flpDades.Location = new System.Drawing.Point(20, 83);
            this.flpDades.Name = "flpDades";
            this.flpDades.Size = new System.Drawing.Size(1274, 243);
            this.flpDades.TabIndex = 6;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tbId);
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox5.Size = new System.Drawing.Size(36, 53);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Id";
            // 
            // tbId
            // 
            this.tbId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbId.Location = new System.Drawing.Point(5, 20);
            this.tbId.Name = "tbId";
            this.tbId.Size = new System.Drawing.Size(26, 22);
            this.tbId.TabIndex = 1;
            // 
            // gbMoneda
            // 
            this.gbMoneda.Controls.Add(this.cbMoneda);
            this.gbMoneda.Location = new System.Drawing.Point(1146, 3);
            this.gbMoneda.Name = "gbMoneda";
            this.gbMoneda.Padding = new System.Windows.Forms.Padding(5);
            this.gbMoneda.Size = new System.Drawing.Size(112, 53);
            this.gbMoneda.TabIndex = 3;
            this.gbMoneda.TabStop = false;
            this.gbMoneda.Text = "Moneda";
            // 
            // cbMoneda
            // 
            this.cbMoneda.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMoneda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMoneda.Enabled = false;
            this.cbMoneda.FormattingEnabled = true;
            this.cbMoneda.Location = new System.Drawing.Point(5, 20);
            this.cbMoneda.Name = "cbMoneda";
            this.cbMoneda.Size = new System.Drawing.Size(102, 24);
            this.cbMoneda.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbTipusProducteFiltreTab1);
            this.groupBox3.Location = new System.Drawing.Point(20, 10);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox3.Size = new System.Drawing.Size(141, 53);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Tipus Producte";
            // 
            // cbTipusProducteFiltreTab1
            // 
            this.cbTipusProducteFiltreTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbTipusProducteFiltreTab1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipusProducteFiltreTab1.FormattingEnabled = true;
            this.cbTipusProducteFiltreTab1.Location = new System.Drawing.Point(5, 20);
            this.cbTipusProducteFiltreTab1.Name = "cbTipusProducteFiltreTab1";
            this.cbTipusProducteFiltreTab1.Size = new System.Drawing.Size(131, 24);
            this.cbTipusProducteFiltreTab1.TabIndex = 0;
            this.cbTipusProducteFiltreTab1.SelectedIndexChanged += new System.EventHandler(this.cbTipusProducteFiltreTab1_SelectedIndexChanged);
            // 
            // btNouProducte
            // 
            this.btNouProducte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNouProducte.Location = new System.Drawing.Point(881, 16);
            this.btNouProducte.Name = "btNouProducte";
            this.btNouProducte.Size = new System.Drawing.Size(101, 50);
            this.btNouProducte.TabIndex = 2;
            this.btNouProducte.Text = "Nou Producte";
            this.btNouProducte.UseVisualStyleBackColor = true;
            this.btNouProducte.Click += new System.EventHandler(this.btNouProducte_Click);
            // 
            // btDesa
            // 
            this.btDesa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDesa.Enabled = false;
            this.btDesa.Location = new System.Drawing.Point(1089, 16);
            this.btDesa.Name = "btDesa";
            this.btDesa.Size = new System.Drawing.Size(101, 50);
            this.btDesa.TabIndex = 4;
            this.btDesa.Text = "Desa";
            this.btDesa.UseVisualStyleBackColor = true;
            this.btDesa.Click += new System.EventHandler(this.btDesa_Click);
            // 
            // btCancela
            // 
            this.btCancela.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btCancela.Enabled = false;
            this.btCancela.Location = new System.Drawing.Point(1193, 16);
            this.btCancela.Name = "btCancela";
            this.btCancela.Size = new System.Drawing.Size(101, 50);
            this.btCancela.TabIndex = 5;
            this.btCancela.Text = "Cancela";
            this.btCancela.UseVisualStyleBackColor = true;
            this.btCancela.Click += new System.EventHandler(this.btCancela_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabUsuari);
            this.tabControl1.Controls.Add(this.tabProductes);
            this.tabControl1.Controls.Add(this.tabMoviments);
            this.tabControl1.Controls.Add(this.tabValoracions);
            this.tabControl1.Controls.Add(this.tabPerduesGuanys);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1360, 735);
            this.tabControl1.TabIndex = 0;
            // 
            // tabUsuari
            // 
            this.tabUsuari.Controls.Add(this.groupBox6);
            this.tabUsuari.Location = new System.Drawing.Point(4, 25);
            this.tabUsuari.Name = "tabUsuari";
            this.tabUsuari.Size = new System.Drawing.Size(1352, 706);
            this.tabUsuari.TabIndex = 4;
            this.tabUsuari.Text = "Usuari";
            this.tabUsuari.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbUsuaris);
            this.groupBox6.Location = new System.Drawing.Point(25, 41);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.groupBox6.Size = new System.Drawing.Size(230, 49);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Usuari";
            // 
            // cbUsuaris
            // 
            this.cbUsuaris.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbUsuaris.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuaris.FormattingEnabled = true;
            this.cbUsuaris.Location = new System.Drawing.Point(5, 18);
            this.cbUsuaris.Name = "cbUsuaris";
            this.cbUsuaris.Size = new System.Drawing.Size(220, 24);
            this.cbUsuaris.TabIndex = 0;
            this.cbUsuaris.SelectedIndexChanged += new System.EventHandler(this.cbUsuaris_SelectedIndexChanged);
            // 
            // tabProductes
            // 
            this.tabProductes.Controls.Add(this.label1);
            this.tabProductes.Controls.Add(this.grAltaEmpresa);
            this.tabProductes.Controls.Add(this.groupBox3);
            this.tabProductes.Controls.Add(this.btCancela);
            this.tabProductes.Controls.Add(this.groupBox2);
            this.tabProductes.Controls.Add(this.btDesa);
            this.tabProductes.Controls.Add(this.flpDades);
            this.tabProductes.Controls.Add(this.btEditaProducte);
            this.tabProductes.Controls.Add(this.btNovaEmpresa);
            this.tabProductes.Controls.Add(this.btNouProducte);
            this.tabProductes.Location = new System.Drawing.Point(4, 25);
            this.tabProductes.Name = "tabProductes";
            this.tabProductes.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductes.Size = new System.Drawing.Size(1352, 706);
            this.tabProductes.TabIndex = 0;
            this.tabProductes.Text = "Productes";
            this.tabProductes.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 465);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(600, 31);
            this.label1.TabIndex = 8;
            this.label1.Text = "Per noves accions o ETFs, clicar: \"Nova Empresa\"";
            // 
            // grAltaEmpresa
            // 
            this.grAltaEmpresa.Controls.Add(this.groupBox7);
            this.grAltaEmpresa.Controls.Add(this.grMercat);
            this.grAltaEmpresa.Controls.Add(this.gbOrdreGrid);
            this.grAltaEmpresa.Controls.Add(this.groupBox9);
            this.grAltaEmpresa.Controls.Add(this.groupBox8);
            this.grAltaEmpresa.Location = new System.Drawing.Point(20, 344);
            this.grAltaEmpresa.Name = "grAltaEmpresa";
            this.grAltaEmpresa.Size = new System.Drawing.Size(1274, 93);
            this.grAltaEmpresa.TabIndex = 7;
            this.grAltaEmpresa.TabStop = false;
            this.grAltaEmpresa.Text = "Alta empresa";
            this.grAltaEmpresa.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.rbCotitzada);
            this.groupBox7.Controls.Add(this.rbGestora);
            this.groupBox7.Location = new System.Drawing.Point(8, 21);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox7.Size = new System.Drawing.Size(229, 53);
            this.groupBox7.TabIndex = 0;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Tipus Empresa";
            // 
            // rbCotitzada
            // 
            this.rbCotitzada.AutoSize = true;
            this.rbCotitzada.Location = new System.Drawing.Point(129, 23);
            this.rbCotitzada.Name = "rbCotitzada";
            this.rbCotitzada.Size = new System.Drawing.Size(88, 21);
            this.rbCotitzada.TabIndex = 1;
            this.rbCotitzada.TabStop = true;
            this.rbCotitzada.Text = "Cotitzada";
            this.rbCotitzada.UseVisualStyleBackColor = true;
            this.rbCotitzada.CheckedChanged += new System.EventHandler(this.rbCotitzada_CheckedChanged);
            // 
            // rbGestora
            // 
            this.rbGestora.AutoSize = true;
            this.rbGestora.Location = new System.Drawing.Point(8, 23);
            this.rbGestora.Name = "rbGestora";
            this.rbGestora.Size = new System.Drawing.Size(115, 21);
            this.rbGestora.TabIndex = 0;
            this.rbGestora.TabStop = true;
            this.rbGestora.Text = "Gestora Fons";
            this.rbGestora.UseVisualStyleBackColor = true;
            this.rbGestora.CheckedChanged += new System.EventHandler(this.rbGestora_CheckedChanged);
            // 
            // grMercat
            // 
            this.grMercat.Controls.Add(this.cbMercat2);
            this.grMercat.Location = new System.Drawing.Point(919, 21);
            this.grMercat.Name = "grMercat";
            this.grMercat.Padding = new System.Windows.Forms.Padding(5);
            this.grMercat.Size = new System.Drawing.Size(234, 53);
            this.grMercat.TabIndex = 3;
            this.grMercat.TabStop = false;
            this.grMercat.Text = "Mercat";
            this.grMercat.Visible = false;
            // 
            // cbMercat2
            // 
            this.cbMercat2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMercat2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMercat2.FormattingEnabled = true;
            this.cbMercat2.Location = new System.Drawing.Point(5, 20);
            this.cbMercat2.Name = "cbMercat2";
            this.cbMercat2.Size = new System.Drawing.Size(224, 24);
            this.cbMercat2.TabIndex = 0;
            // 
            // gbOrdreGrid
            // 
            this.gbOrdreGrid.Controls.Add(this.ntbOrdreGrid);
            this.gbOrdreGrid.Location = new System.Drawing.Point(792, 20);
            this.gbOrdreGrid.Name = "gbOrdreGrid";
            this.gbOrdreGrid.Padding = new System.Windows.Forms.Padding(5);
            this.gbOrdreGrid.Size = new System.Drawing.Size(103, 55);
            this.gbOrdreGrid.TabIndex = 2;
            this.gbOrdreGrid.TabStop = false;
            this.gbOrdreGrid.Text = "Ordre Grid";
            this.gbOrdreGrid.Visible = false;
            // 
            // ntbOrdreGrid
            // 
            this.ntbOrdreGrid._Format = "0";
            this.ntbOrdreGrid._PermetDecimals = true;
            this.ntbOrdreGrid._PermetEspais = false;
            this.ntbOrdreGrid._PermetNegatius = true;
            this.ntbOrdreGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ntbOrdreGrid.Location = new System.Drawing.Point(5, 20);
            this.ntbOrdreGrid.Name = "ntbOrdreGrid";
            this.ntbOrdreGrid.Size = new System.Drawing.Size(93, 22);
            this.ntbOrdreGrid.TabIndex = 0;
            this.ntbOrdreGrid.Text = "999";
            this.ntbOrdreGrid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ntbOrdreGrid.Valor = 999D;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.tbNomNovaEmpresa);
            this.groupBox9.Location = new System.Drawing.Point(261, 20);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox9.Size = new System.Drawing.Size(371, 55);
            this.groupBox9.TabIndex = 1;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "Nom";
            // 
            // tbNomNovaEmpresa
            // 
            this.tbNomNovaEmpresa.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbNomNovaEmpresa.Location = new System.Drawing.Point(5, 20);
            this.tbNomNovaEmpresa.Name = "tbNomNovaEmpresa";
            this.tbNomNovaEmpresa.Size = new System.Drawing.Size(361, 22);
            this.tbNomNovaEmpresa.TabIndex = 0;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.cbMoneda2);
            this.groupBox8.Location = new System.Drawing.Point(651, 22);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox8.Size = new System.Drawing.Size(112, 53);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Moneda";
            // 
            // cbMoneda2
            // 
            this.cbMoneda2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbMoneda2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMoneda2.FormattingEnabled = true;
            this.cbMoneda2.Location = new System.Drawing.Point(5, 20);
            this.cbMoneda2.Name = "cbMoneda2";
            this.cbMoneda2.Size = new System.Drawing.Size(102, 24);
            this.cbMoneda2.TabIndex = 0;
            // 
            // btEditaProducte
            // 
            this.btEditaProducte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEditaProducte.Location = new System.Drawing.Point(985, 16);
            this.btEditaProducte.Name = "btEditaProducte";
            this.btEditaProducte.Size = new System.Drawing.Size(101, 50);
            this.btEditaProducte.TabIndex = 3;
            this.btEditaProducte.Text = "Edita Producte";
            this.btEditaProducte.UseVisualStyleBackColor = true;
            this.btEditaProducte.Click += new System.EventHandler(this.btEditaProducte_Click);
            // 
            // btNovaEmpresa
            // 
            this.btNovaEmpresa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNovaEmpresa.Location = new System.Drawing.Point(776, 16);
            this.btNovaEmpresa.Name = "btNovaEmpresa";
            this.btNovaEmpresa.Size = new System.Drawing.Size(101, 50);
            this.btNovaEmpresa.TabIndex = 2;
            this.btNovaEmpresa.Text = "Nova Empresa";
            this.btNovaEmpresa.UseVisualStyleBackColor = true;
            this.btNovaEmpresa.Click += new System.EventHandler(this.btNovaEmpresa_Click);
            // 
            // tabMoviments
            // 
            this.tabMoviments.Controls.Add(this.movimentsTab1);
            this.tabMoviments.Location = new System.Drawing.Point(4, 25);
            this.tabMoviments.Name = "tabMoviments";
            this.tabMoviments.Padding = new System.Windows.Forms.Padding(5);
            this.tabMoviments.Size = new System.Drawing.Size(1352, 706);
            this.tabMoviments.TabIndex = 1;
            this.tabMoviments.Text = "Moviments";
            this.tabMoviments.UseVisualStyleBackColor = true;
            // 
            // movimentsTab1
            // 
            this.movimentsTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movimentsTab1.Location = new System.Drawing.Point(5, 5);
            this.movimentsTab1.Name = "movimentsTab1";
            this.movimentsTab1.Size = new System.Drawing.Size(1342, 696);
            this.movimentsTab1.TabIndex = 0;
            // 
            // tabValoracions
            // 
            this.tabValoracions.Controls.Add(this.valoracionsTab1);
            this.tabValoracions.Location = new System.Drawing.Point(4, 25);
            this.tabValoracions.Name = "tabValoracions";
            this.tabValoracions.Size = new System.Drawing.Size(1352, 706);
            this.tabValoracions.TabIndex = 2;
            this.tabValoracions.Text = "Valoracions";
            this.tabValoracions.UseVisualStyleBackColor = true;
            // 
            // valoracionsTab1
            // 
            this.valoracionsTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valoracionsTab1.Location = new System.Drawing.Point(0, 0);
            this.valoracionsTab1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.valoracionsTab1.MinimumSize = new System.Drawing.Size(1301, 655);
            this.valoracionsTab1.Name = "valoracionsTab1";
            this.valoracionsTab1.Size = new System.Drawing.Size(1352, 706);
            this.valoracionsTab1.TabIndex = 0;
            // 
            // tabPerduesGuanys
            // 
            this.tabPerduesGuanys.Controls.Add(this.perduesGuanysTab1);
            this.tabPerduesGuanys.Location = new System.Drawing.Point(4, 25);
            this.tabPerduesGuanys.Name = "tabPerduesGuanys";
            this.tabPerduesGuanys.Padding = new System.Windows.Forms.Padding(3);
            this.tabPerduesGuanys.Size = new System.Drawing.Size(1352, 706);
            this.tabPerduesGuanys.TabIndex = 3;
            this.tabPerduesGuanys.Text = "Perdues i Guanys";
            this.tabPerduesGuanys.UseVisualStyleBackColor = true;
            // 
            // perduesGuanysTab1
            // 
            this.perduesGuanysTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.perduesGuanysTab1.Location = new System.Drawing.Point(3, 3);
            this.perduesGuanysTab1.Name = "perduesGuanysTab1";
            this.perduesGuanysTab1.Size = new System.Drawing.Size(1346, 700);
            this.perduesGuanysTab1.TabIndex = 0;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1360, 735);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(1355, 620);
            this.Name = "Principal";
            this.Text = "Productes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Principal_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.gbNom.ResumeLayout(false);
            this.gbNom.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.gbIsin.ResumeLayout(false);
            this.gbIsin.PerformLayout();
            this.gbDescripcio.ResumeLayout(false);
            this.gbDescripcio.PerformLayout();
            this.gbMercat.ResumeLayout(false);
            this.flpDades.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.gbMoneda.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabUsuari.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tabProductes.ResumeLayout(false);
            this.tabProductes.PerformLayout();
            this.grAltaEmpresa.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.grMercat.ResumeLayout(false);
            this.gbOrdreGrid.ResumeLayout(false);
            this.gbOrdreGrid.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.tabMoviments.ResumeLayout(false);
            this.tabValoracions.ResumeLayout(false);
            this.tabPerduesGuanys.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbTipusProducte;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cbProductesTab1;
        private System.Windows.Forms.GroupBox gbNom;
        private System.Windows.Forms.TextBox tbNom;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbEmpresa;
        private System.Windows.Forms.GroupBox gbIsin;
        private System.Windows.Forms.TextBox tbIsin;
        private System.Windows.Forms.GroupBox gbDescripcio;
        private System.Windows.Forms.TextBox tbDescripcio;
        private System.Windows.Forms.GroupBox gbMercat;
        private System.Windows.Forms.ComboBox cbMercat;
        private System.Windows.Forms.FlowLayoutPanel flpDades;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbTipusProducteFiltreTab1;
        private System.Windows.Forms.Button btNouProducte;
        private System.Windows.Forms.Button btDesa;
        private System.Windows.Forms.Button btCancela;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabProductes;
        private System.Windows.Forms.TabPage tabMoviments;
        private System.Windows.Forms.DataGridViewComboBoxColumn productesDataGridViewTextBoxColumn;
        private MovimentsTab movimentsTab1;
        private System.Windows.Forms.TabPage tabValoracions;
        private ValoracionsTab valoracionsTab1;
        private System.Windows.Forms.Button btEditaProducte;
        private System.Windows.Forms.TabPage tabPerduesGuanys;
        private PerduesGuanysTab perduesGuanysTab1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox tbId;
        private System.Windows.Forms.TabPage tabUsuari;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbUsuaris;
        private System.Windows.Forms.Button btNovaEmpresa;
        private System.Windows.Forms.GroupBox grAltaEmpresa;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton rbCotitzada;
        private System.Windows.Forms.RadioButton rbGestora;
        private System.Windows.Forms.GroupBox grMercat;
        private System.Windows.Forms.ComboBox cbMercat2;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox tbNomNovaEmpresa;
        private System.Windows.Forms.GroupBox gbOrdreGrid;
        private Controls.NumericTextBox2 ntbOrdreGrid;
        private System.Windows.Forms.GroupBox gbMoneda;
        private System.Windows.Forms.ComboBox cbMoneda;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.ComboBox cbMoneda2;
        private System.Windows.Forms.Label label1;
    }
}