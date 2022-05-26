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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabUsuari = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.cbUsuaris = new System.Windows.Forms.ComboBox();
            this.tabEmpresesProductes = new System.Windows.Forms.TabPage();
            this.tabMoviments = new System.Windows.Forms.TabPage();
            this.movimentsTab1 = new Inversions.GUI.MovimentsTab();
            this.tabValoracions = new System.Windows.Forms.TabPage();
            this.valoracionsTab1 = new Inversions.GUI.ValoracionsTab();
            this.tabPerduesGuanys = new System.Windows.Forms.TabPage();
            this.perduesGuanysTab1 = new Inversions.GUI.PerduesGuanysTab();
            this.tabGrafiques = new System.Windows.Forms.TabPage();
            this.grafiquesTab1 = new Inversions.GUI.GrafiquesTab();
            this.tabSimulacióVenda = new System.Windows.Forms.TabPage();
            this.simulacióVendaTab1 = new Inversions.GUI.SimulacióVendaTab();
            this.tabControl1.SuspendLayout();
            this.tabUsuari.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tabMoviments.SuspendLayout();
            this.tabValoracions.SuspendLayout();
            this.tabPerduesGuanys.SuspendLayout();
            this.tabGrafiques.SuspendLayout();
            this.tabSimulacióVenda.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabUsuari);
            this.tabControl1.Controls.Add(this.tabEmpresesProductes);
            this.tabControl1.Controls.Add(this.tabMoviments);
            this.tabControl1.Controls.Add(this.tabValoracions);
            this.tabControl1.Controls.Add(this.tabPerduesGuanys);
            this.tabControl1.Controls.Add(this.tabGrafiques);
            this.tabControl1.Controls.Add(this.tabSimulacióVenda);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1530, 919);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            this.tabControl1.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Deselecting);
            // 
            // tabUsuari
            // 
            this.tabUsuari.Controls.Add(this.groupBox6);
            this.tabUsuari.Location = new System.Drawing.Point(4, 29);
            this.tabUsuari.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabUsuari.Name = "tabUsuari";
            this.tabUsuari.Size = new System.Drawing.Size(1522, 886);
            this.tabUsuari.TabIndex = 4;
            this.tabUsuari.Text = "Usuari";
            this.tabUsuari.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.cbUsuaris);
            this.groupBox6.Location = new System.Drawing.Point(28, 51);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.groupBox6.Size = new System.Drawing.Size(259, 61);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Usuari";
            // 
            // cbUsuaris
            // 
            this.cbUsuaris.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbUsuaris.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsuaris.FormattingEnabled = true;
            this.cbUsuaris.Location = new System.Drawing.Point(6, 23);
            this.cbUsuaris.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbUsuaris.Name = "cbUsuaris";
            this.cbUsuaris.Size = new System.Drawing.Size(247, 28);
            this.cbUsuaris.TabIndex = 0;
            // 
            // tabEmpresesProductes
            // 
            this.tabEmpresesProductes.Location = new System.Drawing.Point(4, 29);
            this.tabEmpresesProductes.Name = "tabEmpresesProductes";
            this.tabEmpresesProductes.Padding = new System.Windows.Forms.Padding(3);
            this.tabEmpresesProductes.Size = new System.Drawing.Size(1522, 886);
            this.tabEmpresesProductes.TabIndex = 8;
            this.tabEmpresesProductes.Text = "Empreses/Productes";
            this.tabEmpresesProductes.UseVisualStyleBackColor = true;
            // 
            // tabMoviments
            // 
            this.tabMoviments.Controls.Add(this.movimentsTab1);
            this.tabMoviments.Location = new System.Drawing.Point(4, 29);
            this.tabMoviments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMoviments.Name = "tabMoviments";
            this.tabMoviments.Padding = new System.Windows.Forms.Padding(6);
            this.tabMoviments.Size = new System.Drawing.Size(1522, 886);
            this.tabMoviments.TabIndex = 1;
            this.tabMoviments.Text = "Moviments";
            this.tabMoviments.UseVisualStyleBackColor = true;
            // 
            // movimentsTab1
            // 
            this.movimentsTab1.activaRefresca = false;
            this.movimentsTab1.CausesValidation = false;
            this.movimentsTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movimentsTab1.Location = new System.Drawing.Point(6, 6);
            this.movimentsTab1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.movimentsTab1.Name = "movimentsTab1";
            this.movimentsTab1.Size = new System.Drawing.Size(1510, 874);
            this.movimentsTab1.TabIndex = 0;
            // 
            // tabValoracions
            // 
            this.tabValoracions.Controls.Add(this.valoracionsTab1);
            this.tabValoracions.Location = new System.Drawing.Point(4, 29);
            this.tabValoracions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabValoracions.Name = "tabValoracions";
            this.tabValoracions.Size = new System.Drawing.Size(1522, 886);
            this.tabValoracions.TabIndex = 2;
            this.tabValoracions.Text = "Valoracions";
            this.tabValoracions.UseVisualStyleBackColor = true;
            // 
            // valoracionsTab1
            // 
            this.valoracionsTab1.activaRefresca = false;
            this.valoracionsTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.valoracionsTab1.Location = new System.Drawing.Point(0, 0);
            this.valoracionsTab1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.valoracionsTab1.MinimumSize = new System.Drawing.Size(1464, 819);
            this.valoracionsTab1.Name = "valoracionsTab1";
            this.valoracionsTab1.Size = new System.Drawing.Size(1522, 886);
            this.valoracionsTab1.TabIndex = 0;
            // 
            // tabPerduesGuanys
            // 
            this.tabPerduesGuanys.Controls.Add(this.perduesGuanysTab1);
            this.tabPerduesGuanys.Location = new System.Drawing.Point(4, 29);
            this.tabPerduesGuanys.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPerduesGuanys.Name = "tabPerduesGuanys";
            this.tabPerduesGuanys.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPerduesGuanys.Size = new System.Drawing.Size(1522, 886);
            this.tabPerduesGuanys.TabIndex = 3;
            this.tabPerduesGuanys.Text = "Perdues i Guanys";
            this.tabPerduesGuanys.UseVisualStyleBackColor = true;
            // 
            // perduesGuanysTab1
            // 
            this.perduesGuanysTab1.activaRefresca = false;
            this.perduesGuanysTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.perduesGuanysTab1.Location = new System.Drawing.Point(3, 4);
            this.perduesGuanysTab1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.perduesGuanysTab1.Name = "perduesGuanysTab1";
            this.perduesGuanysTab1.Size = new System.Drawing.Size(186, 59);
            this.perduesGuanysTab1.TabIndex = 0;
            // 
            // tabGrafiques
            // 
            this.tabGrafiques.Controls.Add(this.grafiquesTab1);
            this.tabGrafiques.Location = new System.Drawing.Point(4, 29);
            this.tabGrafiques.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabGrafiques.Name = "tabGrafiques";
            this.tabGrafiques.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabGrafiques.Size = new System.Drawing.Size(1522, 886);
            this.tabGrafiques.TabIndex = 6;
            this.tabGrafiques.Text = "Gràfiques";
            this.tabGrafiques.UseVisualStyleBackColor = true;
            // 
            // grafiquesTab1
            // 
            this.grafiquesTab1.activaRefresca = false;
            this.grafiquesTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grafiquesTab1.Location = new System.Drawing.Point(3, 4);
            this.grafiquesTab1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grafiquesTab1.MinimumSize = new System.Drawing.Size(1464, 819);
            this.grafiquesTab1.Name = "grafiquesTab1";
            this.grafiquesTab1.Size = new System.Drawing.Size(1516, 878);
            this.grafiquesTab1.TabIndex = 0;
            // 
            // tabSimulacióVenda
            // 
            this.tabSimulacióVenda.Controls.Add(this.simulacióVendaTab1);
            this.tabSimulacióVenda.Location = new System.Drawing.Point(4, 29);
            this.tabSimulacióVenda.Name = "tabSimulacióVenda";
            this.tabSimulacióVenda.Padding = new System.Windows.Forms.Padding(3);
            this.tabSimulacióVenda.Size = new System.Drawing.Size(1522, 886);
            this.tabSimulacióVenda.TabIndex = 7;
            this.tabSimulacióVenda.Text = "Simulació Venda";
            this.tabSimulacióVenda.UseVisualStyleBackColor = true;
            // 
            // simulacióVendaTab1
            // 
            this.simulacióVendaTab1.activaRefresca = false;
            this.simulacióVendaTab1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.simulacióVendaTab1.Location = new System.Drawing.Point(3, 3);
            this.simulacióVendaTab1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simulacióVendaTab1.Name = "simulacióVendaTab1";
            this.simulacióVendaTab1.Size = new System.Drawing.Size(1516, 880);
            this.simulacióVendaTab1.TabIndex = 0;
            // 
            // Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1530, 919);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(1522, 761);
            this.Name = "Principal";
            this.Text = "Inversions";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Principal_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Principal_FormClosing);
            this.Load += new System.EventHandler(this.Principal_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Principal_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabUsuari.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tabMoviments.ResumeLayout(false);
            this.tabValoracions.ResumeLayout(false);
            this.tabPerduesGuanys.ResumeLayout(false);
            this.tabGrafiques.ResumeLayout(false);
            this.tabSimulacióVenda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMoviments;
        private System.Windows.Forms.DataGridViewComboBoxColumn productesDataGridViewTextBoxColumn;
        private MovimentsTab movimentsTab1;
        private System.Windows.Forms.TabPage tabValoracions;
        private ValoracionsTab valoracionsTab1;
        private System.Windows.Forms.TabPage tabPerduesGuanys;
        private PerduesGuanysTab perduesGuanysTab1;
        private System.Windows.Forms.TabPage tabUsuari;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ComboBox cbUsuaris;
        private System.Windows.Forms.TabPage tabGrafiques;
        private GrafiquesTab grafiquesTab1;
        private System.Windows.Forms.TabPage tabSimulacióVenda;
        private SimulacióVendaTab simulacióVendaTab1;
        private System.Windows.Forms.TabPage tabEmpresesProductes;
    }
}