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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbTipusProducteFiltreTab1 = new System.Windows.Forms.ComboBox();
            this.btNouProducte = new System.Windows.Forms.Button();
            this.btDesa = new System.Windows.Forms.Button();
            this.btCancela = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabProductes = new System.Windows.Forms.TabPage();
            this.btEditaProducte = new System.Windows.Forms.Button();
            this.tabMoviments = new System.Windows.Forms.TabPage();
            this.tabValoracions = new System.Windows.Forms.TabPage();
            this.tabPerduesGuanys = new System.Windows.Forms.TabPage();
            this.tabUsuari = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbUsuaris = new System.Windows.Forms.ComboBox();
            this.movimentsTab1 = new Inversions.GUI.MovimentsTab();
            this.valoracionsTab1 = new Inversions.GUI.ValoracionsTab();
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
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabProductes.SuspendLayout();
            this.tabMoviments.SuspendLayout();
            this.tabValoracions.SuspendLayout();
            this.tabPerduesGuanys.SuspendLayout();
            this.tabUsuari.SuspendLayout();
            this.groupBox6.SuspendLayout();
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
            this.flpDades.Controls.Add(this.gbIsin);
            this.flpDades.Controls.Add(this.gbDescripcio);
            this.flpDades.Location = new System.Drawing.Point(20, 83);
            this.flpDades.Name = "flpDades";
            this.flpDades.Size = new System.Drawing.Size(1175, 243);
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
            this.btNouProducte.Location = new System.Drawing.Point(782, 16);
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
            this.btDesa.Location = new System.Drawing.Point(990, 16);
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
            this.btCancela.Location = new System.Drawing.Point(1094, 16);
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
            // tabProductes
            // 
            this.tabProductes.Controls.Add(this.groupBox3);
            this.tabProductes.Controls.Add(this.btCancela);
            this.tabProductes.Controls.Add(this.groupBox2);
            this.tabProductes.Controls.Add(this.btDesa);
            this.tabProductes.Controls.Add(this.flpDades);
            this.tabProductes.Controls.Add(this.btEditaProducte);
            this.tabProductes.Controls.Add(this.btNouProducte);
            this.tabProductes.Location = new System.Drawing.Point(4, 25);
            this.tabProductes.Name = "tabProductes";
            this.tabProductes.Padding = new System.Windows.Forms.Padding(3);
            this.tabProductes.Size = new System.Drawing.Size(1352, 706);
            this.tabProductes.TabIndex = 0;
            this.tabProductes.Text = "Productes";
            this.tabProductes.UseVisualStyleBackColor = true;
            // 
            // btEditaProducte
            // 
            this.btEditaProducte.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEditaProducte.Location = new System.Drawing.Point(886, 16);
            this.btEditaProducte.Name = "btEditaProducte";
            this.btEditaProducte.Size = new System.Drawing.Size(101, 50);
            this.btEditaProducte.TabIndex = 3;
            this.btEditaProducte.Text = "Edita Producte";
            this.btEditaProducte.UseVisualStyleBackColor = true;
            this.btEditaProducte.Click += new System.EventHandler(this.btEditaProducte_Click);
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
            // movimentsTab1
            // 
            this.movimentsTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movimentsTab1.Location = new System.Drawing.Point(5, 5);
            this.movimentsTab1.Name = "movimentsTab1";
            this.movimentsTab1.Size = new System.Drawing.Size(1342, 696);
            this.movimentsTab1.TabIndex = 0;
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
            this.groupBox3.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabProductes.ResumeLayout(false);
            this.tabMoviments.ResumeLayout(false);
            this.tabValoracions.ResumeLayout(false);
            this.tabPerduesGuanys.ResumeLayout(false);
            this.tabUsuari.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
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
    }
}