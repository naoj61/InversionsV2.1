namespace Inversions.GUI.Forms
{
    partial class Tributacions
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cAny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCompresNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cVendesNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cTotalNet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cImportCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cImportVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDespesesCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDespesesVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTotal = new Controls.NumericTextBox2();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAny = new Controls.NumericTextBox2();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cAny,
            this.cProd,
            this.cCompresNet,
            this.cVendesNet,
            this.cTotalNet,
            this.cImportCompra,
            this.cImportVenda,
            this.cDespesesCompra,
            this.cDespesesVenda});
            this.dataGridView1.Location = new System.Drawing.Point(12, 55);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1065, 211);
            this.dataGridView1.TabIndex = 0;
            // 
            // cAny
            // 
            this.cAny.DataPropertyName = "_Any";
            this.cAny.HeaderText = "Any";
            this.cAny.Name = "cAny";
            this.cAny.Visible = false;
            // 
            // cProd
            // 
            this.cProd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cProd.DataPropertyName = "_Prod";
            this.cProd.HeaderText = "Producte";
            this.cProd.Name = "cProd";
            this.cProd.Width = 109;
            // 
            // cCompresNet
            // 
            this.cCompresNet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cCompresNet.DataPropertyName = "_CompresNet";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "C2";
            this.cCompresNet.DefaultCellStyle = dataGridViewCellStyle1;
            this.cCompresNet.HeaderText = "Compres Net";
            this.cCompresNet.Name = "cCompresNet";
            this.cCompresNet.Width = 138;
            // 
            // cVendesNet
            // 
            this.cVendesNet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cVendesNet.DataPropertyName = "_VendesNet";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C2";
            this.cVendesNet.DefaultCellStyle = dataGridViewCellStyle2;
            this.cVendesNet.HeaderText = "Vendes Net";
            this.cVendesNet.Name = "cVendesNet";
            this.cVendesNet.Width = 129;
            // 
            // cTotalNet
            // 
            this.cTotalNet.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cTotalNet.DataPropertyName = "_TotalNet";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.cTotalNet.DefaultCellStyle = dataGridViewCellStyle3;
            this.cTotalNet.HeaderText = "Total net";
            this.cTotalNet.Name = "cTotalNet";
            this.cTotalNet.Width = 107;
            // 
            // cImportCompra
            // 
            this.cImportCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cImportCompra.DataPropertyName = "_ImportCompra";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.cImportCompra.DefaultCellStyle = dataGridViewCellStyle4;
            this.cImportCompra.HeaderText = "Compres";
            this.cImportCompra.Name = "cImportCompra";
            this.cImportCompra.Width = 109;
            // 
            // cImportVenda
            // 
            this.cImportVenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cImportVenda.DataPropertyName = "_ImportVenda";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.cImportVenda.DefaultCellStyle = dataGridViewCellStyle5;
            this.cImportVenda.HeaderText = "Vendes";
            this.cImportVenda.Name = "cImportVenda";
            // 
            // cDespesesCompra
            // 
            this.cDespesesCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDespesesCompra.DataPropertyName = "_DespesesCompra";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.cDespesesCompra.DefaultCellStyle = dataGridViewCellStyle6;
            this.cDespesesCompra.HeaderText = "Despeses C";
            this.cDespesesCompra.Name = "cDespesesCompra";
            this.cDespesesCompra.Width = 132;
            // 
            // cDespesesVenda
            // 
            this.cDespesesVenda.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.cDespesesVenda.DataPropertyName = "_DespesesVenda";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.cDespesesVenda.DefaultCellStyle = dataGridViewCellStyle7;
            this.cDespesesVenda.HeaderText = "Despeses V";
            this.cDespesesVenda.Name = "cDespesesVenda";
            this.cDespesesVenda.Width = 132;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 494);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Total PiG";
            // 
            // tbTotal
            // 
            this.tbTotal._CapturaEscape = true;
            this.tbTotal._Format = "#,##0.00 €";
            this.tbTotal._PermetDecimals = true;
            this.tbTotal._PermetEspais = false;
            this.tbTotal._PermetNegatius = true;
            this.tbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTotal.Location = new System.Drawing.Point(107, 491);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(103, 26);
            this.tbTotal.TabIndex = 2;
            this.tbTotal.Text = "0,00 €";
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTotal.Valor = 0D;
            // 
            // dataGridView2
            // 
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn6});
            this.dataGridView2.Location = new System.Drawing.Point(12, 273);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(1065, 211);
            this.dataGridView2.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "_Any";
            this.dataGridViewTextBoxColumn1.HeaderText = "Any";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "_Prod";
            this.dataGridViewTextBoxColumn2.HeaderText = "Producte";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 109;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "_Dividents";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "C2";
            dataGridViewCellStyle8.NullValue = null;
            this.dataGridViewTextBoxColumn6.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewTextBoxColumn6.HeaderText = "Dividents";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Any";
            // 
            // tbAny
            // 
            this.tbAny._CapturaEscape = true;
            this.tbAny._Format = "0";
            this.tbAny._PermetDecimals = true;
            this.tbAny._PermetEspais = false;
            this.tbAny._PermetNegatius = true;
            this.tbAny.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAny.Location = new System.Drawing.Point(59, 20);
            this.tbAny.Name = "tbAny";
            this.tbAny.ReadOnly = true;
            this.tbAny.Size = new System.Drawing.Size(54, 26);
            this.tbAny.TabIndex = 2;
            this.tbAny.Text = "2018";
            this.tbAny.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbAny.Valor = 2018D;
            // 
            // Tributacions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 525);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.tbAny);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Tributacions";
            this.ShowInTaskbar = false;
            this.Text = "Tributacions";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private Controls.NumericTextBox2 tbTotal;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label2;
        private Controls.NumericTextBox2 tbAny;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAny;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCompresNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn cVendesNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn cTotalNet;
        private System.Windows.Forms.DataGridViewTextBoxColumn cImportCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn cImportVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDespesesCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDespesesVenda;
    }
}