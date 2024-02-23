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
            this.tabSimulacióVenda = new System.Windows.Forms.TabPage();
            this.tabGrafiques = new System.Windows.Forms.TabPage();
            this.tabPerduesGuanys = new System.Windows.Forms.TabPage();
            this.tabValoracions = new System.Windows.Forms.TabPage();
            this.tabMoviments = new System.Windows.Forms.TabPage();
            this.tabEmpresesProductes = new System.Windows.Forms.TabPage();
            this.tabUsuari = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabEdicioTaules = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSimulacióVenda
            // 
            this.tabSimulacióVenda.Location = new System.Drawing.Point(4, 29);
            this.tabSimulacióVenda.Name = "tabSimulacióVenda";
            this.tabSimulacióVenda.Padding = new System.Windows.Forms.Padding(3);
            this.tabSimulacióVenda.Size = new System.Drawing.Size(1522, 886);
            this.tabSimulacióVenda.TabIndex = 7;
            this.tabSimulacióVenda.Text = "Simulació Venda";
            this.tabSimulacióVenda.UseVisualStyleBackColor = true;
            // 
            // tabGrafiques
            // 
            this.tabGrafiques.Location = new System.Drawing.Point(4, 29);
            this.tabGrafiques.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabGrafiques.Name = "tabGrafiques";
            this.tabGrafiques.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabGrafiques.Size = new System.Drawing.Size(1522, 886);
            this.tabGrafiques.TabIndex = 6;
            this.tabGrafiques.Text = "Gràfiques";
            this.tabGrafiques.UseVisualStyleBackColor = true;
            // 
            // tabPerduesGuanys
            // 
            this.tabPerduesGuanys.Location = new System.Drawing.Point(4, 29);
            this.tabPerduesGuanys.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPerduesGuanys.Name = "tabPerduesGuanys";
            this.tabPerduesGuanys.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPerduesGuanys.Size = new System.Drawing.Size(1522, 886);
            this.tabPerduesGuanys.TabIndex = 3;
            this.tabPerduesGuanys.Text = "Perdues i Guanys";
            this.tabPerduesGuanys.UseVisualStyleBackColor = true;
            // 
            // tabValoracions
            // 
            this.tabValoracions.Location = new System.Drawing.Point(4, 29);
            this.tabValoracions.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabValoracions.Name = "tabValoracions";
            this.tabValoracions.Size = new System.Drawing.Size(1522, 886);
            this.tabValoracions.TabIndex = 2;
            this.tabValoracions.Text = "Valoracions";
            this.tabValoracions.UseVisualStyleBackColor = true;
            // 
            // tabMoviments
            // 
            this.tabMoviments.Location = new System.Drawing.Point(4, 29);
            this.tabMoviments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabMoviments.Name = "tabMoviments";
            this.tabMoviments.Padding = new System.Windows.Forms.Padding(6);
            this.tabMoviments.Size = new System.Drawing.Size(1522, 886);
            this.tabMoviments.TabIndex = 1;
            this.tabMoviments.Text = "Moviments";
            this.tabMoviments.UseVisualStyleBackColor = true;
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
            // tabUsuari
            // 
            this.tabUsuari.Location = new System.Drawing.Point(4, 29);
            this.tabUsuari.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabUsuari.Name = "tabUsuari";
            this.tabUsuari.Size = new System.Drawing.Size(1522, 886);
            this.tabUsuari.TabIndex = 4;
            this.tabUsuari.Text = "Usuari";
            this.tabUsuari.UseVisualStyleBackColor = true;
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
            this.tabControl1.Controls.Add(this.tabEdicioTaules);
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
            // tabEdicioTaules
            // 
            this.tabEdicioTaules.Location = new System.Drawing.Point(4, 29);
            this.tabEdicioTaules.Name = "tabEdicioTaules";
            this.tabEdicioTaules.Padding = new System.Windows.Forms.Padding(3);
            this.tabEdicioTaules.Size = new System.Drawing.Size(1522, 886);
            this.tabEdicioTaules.TabIndex = 9;
            this.tabEdicioTaules.Text = "Edició Taules BD";
            this.tabEdicioTaules.UseVisualStyleBackColor = true;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewComboBoxColumn productesDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tabSimulacióVenda;
        private System.Windows.Forms.TabPage tabGrafiques;
        private System.Windows.Forms.TabPage tabPerduesGuanys;
        private System.Windows.Forms.TabPage tabValoracions;
        private System.Windows.Forms.TabPage tabMoviments;
        private System.Windows.Forms.TabPage tabEmpresesProductes;
        private System.Windows.Forms.TabPage tabUsuari;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabEdicioTaules;
    }
}