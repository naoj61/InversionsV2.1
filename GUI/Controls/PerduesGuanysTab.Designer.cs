using System;

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cDataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbPiGTotConsolidat = new Controls.NumericTextBox2();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbPiGTotActual = new Controls.NumericTextBox2();
            this.dgvPiGAnuals = new System.Windows.Forms.DataGridView();
            this.gestioProductesTabValoracions = new Inversions.GUI.GestioProductes();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataTraspas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImport = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colImportAcumulat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTermini = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.cDataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiGAnuals)).BeginInit();
            this.SuspendLayout();
            // 
            // cDataGridView1
            // 
            this.cDataGridView1.AllowUserToAddRows = false;
            this.cDataGridView1.AllowUserToDeleteRows = false;
            this.cDataGridView1.AllowUserToOrderColumns = true;
            this.cDataGridView1.AllowUserToResizeRows = false;
            this.cDataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.cDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.cDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDataCompra,
            this.colDataVenda,
            this.colDataTraspas,
            this.colImport,
            this.colImportAcumulat,
            this.colTermini,
            this.Column2});
            this.cDataGridView1.Location = new System.Drawing.Point(0, 440);
            this.cDataGridView1.Name = "cDataGridView1";
            this.cDataGridView1.ReadOnly = true;
            this.cDataGridView1.RowTemplate.Height = 24;
            this.cDataGridView1.Size = new System.Drawing.Size(1297, 218);
            this.cDataGridView1.TabIndex = 5;
            this.cDataGridView1.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.tbPiGTotConsolidat);
            this.groupBox1.Location = new System.Drawing.Point(915, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(184, 78);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Total Perdues i Guanys Consolidat";
            // 
            // tbPiGTotConsolidat
            // 
            this.tbPiGTotConsolidat._Format = "#,#0.0 €";
            this.tbPiGTotConsolidat._PermetDecimals = true;
            this.tbPiGTotConsolidat._PermetEspais = false;
            this.tbPiGTotConsolidat._PermetNegatius = true;
            this.tbPiGTotConsolidat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPiGTotConsolidat.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPiGTotConsolidat.Location = new System.Drawing.Point(6, 42);
            this.tbPiGTotConsolidat.Name = "tbPiGTotConsolidat";
            this.tbPiGTotConsolidat.ReadOnly = true;
            this.tbPiGTotConsolidat.Size = new System.Drawing.Size(172, 27);
            this.tbPiGTotConsolidat.TabIndex = 0;
            this.tbPiGTotConsolidat.Text = "0,0 €";
            this.tbPiGTotConsolidat.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPiGTotConsolidat.Valor = 0D;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.tbPiGTotActual);
            this.groupBox2.Location = new System.Drawing.Point(1107, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(184, 78);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Total Perdues i Guanys Actual";
            // 
            // tbPiGTotActual
            // 
            this.tbPiGTotActual._Format = "#,#0.0 €";
            this.tbPiGTotActual._PermetDecimals = true;
            this.tbPiGTotActual._PermetEspais = false;
            this.tbPiGTotActual._PermetNegatius = true;
            this.tbPiGTotActual.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbPiGTotActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPiGTotActual.Location = new System.Drawing.Point(3, 42);
            this.tbPiGTotActual.Name = "tbPiGTotActual";
            this.tbPiGTotActual.ReadOnly = true;
            this.tbPiGTotActual.Size = new System.Drawing.Size(175, 27);
            this.tbPiGTotActual.TabIndex = 0;
            this.tbPiGTotActual.Text = "0,0 €";
            this.tbPiGTotActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbPiGTotActual.Valor = 0D;
            // 
            // dgvPiGAnuals
            // 
            this.dgvPiGAnuals.AllowUserToAddRows = false;
            this.dgvPiGAnuals.AllowUserToDeleteRows = false;
            this.dgvPiGAnuals.AllowUserToOrderColumns = true;
            this.dgvPiGAnuals.AllowUserToResizeRows = false;
            this.dgvPiGAnuals.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPiGAnuals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPiGAnuals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvPiGAnuals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPiGAnuals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn5,
            this.Column1});
            this.dgvPiGAnuals.Location = new System.Drawing.Point(908, 87);
            this.dgvPiGAnuals.Name = "dgvPiGAnuals";
            this.dgvPiGAnuals.ReadOnly = true;
            this.dgvPiGAnuals.RowTemplate.Height = 24;
            this.dgvPiGAnuals.Size = new System.Drawing.Size(389, 351);
            this.dgvPiGAnuals.TabIndex = 7;
            // 
            // gestioProductesTabValoracions
            // 
            this.gestioProductesTabValoracions._NomesAmbParticipacions = true;
            this.gestioProductesTabValoracions._ProducteSeleccionat = null;
            this.gestioProductesTabValoracions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gestioProductesTabValoracions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gestioProductesTabValoracions.Location = new System.Drawing.Point(0, 0);
            this.gestioProductesTabValoracions.MinimumSize = new System.Drawing.Size(733, 395);
            this.gestioProductesTabValoracions.Name = "gestioProductesTabValoracions";
            this.gestioProductesTabValoracions.Size = new System.Drawing.Size(909, 440);
            this.gestioProductesTabValoracions.TabIndex = 0;
            this.gestioProductesTabValoracions.ProducteSeleccionat += new System.EventHandler(this.gestioProductesTabValoracions_ProducteSeleccionat);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Format = "0000";
            dataGridViewCellStyle9.NullValue = null;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewTextBoxColumn1.HeaderText = "Any";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 57;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn6.HeaderText = "Termini";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 80;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle11.Format = "c3";
            this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridViewTextBoxColumn5.HeaderText = "Import";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 72;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.HeaderText = "";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // colDataCompra
            // 
            this.colDataCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDataCompra.DataPropertyName = "_DataCompra";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.colDataCompra.DefaultCellStyle = dataGridViewCellStyle2;
            this.colDataCompra.HeaderText = "Data Compra";
            this.colDataCompra.Name = "colDataCompra";
            this.colDataCompra.ReadOnly = true;
            this.colDataCompra.Width = 116;
            // 
            // colDataVenda
            // 
            this.colDataVenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDataVenda.DataPropertyName = "_DataVendaReal";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "d";
            this.colDataVenda.DefaultCellStyle = dataGridViewCellStyle3;
            this.colDataVenda.HeaderText = "Data Venda";
            this.colDataVenda.Name = "colDataVenda";
            this.colDataVenda.ReadOnly = true;
            this.colDataVenda.Width = 108;
            // 
            // colDataTraspas
            // 
            this.colDataTraspas.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colDataTraspas.DataPropertyName = "_DataTraspas";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "d";
            this.colDataTraspas.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDataTraspas.HeaderText = "Data Traspàs";
            this.colDataTraspas.Name = "colDataTraspas";
            this.colDataTraspas.ReadOnly = true;
            this.colDataTraspas.Width = 119;
            // 
            // colImport
            // 
            this.colImport.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colImport.DataPropertyName = "_Import";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C3";
            dataGridViewCellStyle5.NullValue = null;
            this.colImport.DefaultCellStyle = dataGridViewCellStyle5;
            this.colImport.HeaderText = "P i G";
            this.colImport.Name = "colImport";
            this.colImport.ReadOnly = true;
            this.colImport.Width = 64;
            // 
            // colImportAcumulat
            // 
            this.colImportAcumulat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.colImportAcumulat.DataPropertyName = "_ImportAcumulat";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Format = "c3";
            this.colImportAcumulat.DefaultCellStyle = dataGridViewCellStyle6;
            this.colImportAcumulat.HeaderText = "P i G Acumulades";
            this.colImportAcumulat.Name = "colImportAcumulat";
            this.colImportAcumulat.ReadOnly = true;
            this.colImportAcumulat.Width = 132;
            // 
            // colTermini
            // 
            this.colTermini.DataPropertyName = "_Termini";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colTermini.DefaultCellStyle = dataGridViewCellStyle7;
            this.colTermini.HeaderText = "Termini";
            this.colTermini.Name = "colTermini";
            this.colTermini.ReadOnly = true;
            this.colTermini.Width = 80;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // PerduesGuanysTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvPiGAnuals);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gestioProductesTabValoracions);
            this.Controls.Add(this.cDataGridView1);
            this.Name = "PerduesGuanysTab";
            this.Size = new System.Drawing.Size(1297, 658);
            ((System.ComponentModel.ISupportInitialize)(this.cDataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiGAnuals)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private GestioProductes gestioProductesTabValoracions;
        private System.Windows.Forms.DataGridView cDataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private Controls.NumericTextBox2 tbPiGTotConsolidat;
        private System.Windows.Forms.GroupBox groupBox2;
        private Controls.NumericTextBox2 tbPiGTotActual;
        private System.Windows.Forms.DataGridView dgvPiGAnuals;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDataTraspas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn colImportAcumulat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTermini;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}
