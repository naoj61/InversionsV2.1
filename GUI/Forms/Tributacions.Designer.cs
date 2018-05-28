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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cAny = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cProd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cImportCompraVenda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDespeses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cDividents = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.tbTotal = new Controls.NumericTextBox2();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cAny,
            this.cProd,
            this.cImportCompraVenda,
            this.cDespeses,
            this.cDividents});
            this.dataGridView1.Location = new System.Drawing.Point(146, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(818, 423);
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
            // cImportCompraVenda
            // 
            this.cImportCompraVenda.DataPropertyName = "_ImportCompraVenda";
            dataGridViewCellStyle4.Format = "C2";
            dataGridViewCellStyle4.NullValue = null;
            this.cImportCompraVenda.DefaultCellStyle = dataGridViewCellStyle4;
            this.cImportCompraVenda.HeaderText = "PiG";
            this.cImportCompraVenda.Name = "cImportCompraVenda";
            // 
            // cDespeses
            // 
            this.cDespeses.DataPropertyName = "_Despeses";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.cDespeses.DefaultCellStyle = dataGridViewCellStyle5;
            this.cDespeses.HeaderText = "Despeses";
            this.cDespeses.Name = "cDespeses";
            // 
            // cDividents
            // 
            this.cDividents.DataPropertyName = "_Dividents";
            dataGridViewCellStyle6.Format = "C2";
            dataGridViewCellStyle6.NullValue = null;
            this.cDividents.DefaultCellStyle = dataGridViewCellStyle6;
            this.cDividents.HeaderText = "Dividents";
            this.cDividents.Name = "cDividents";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(142, 472);
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
            this.tbTotal.Location = new System.Drawing.Point(245, 469);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(100, 26);
            this.tbTotal.TabIndex = 2;
            this.tbTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbTotal.Valor = 0D;
            // 
            // Tributacions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 609);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Tributacions";
            this.Text = "Tributacions";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAny;
        private System.Windows.Forms.DataGridViewTextBoxColumn cProd;
        private System.Windows.Forms.DataGridViewTextBoxColumn cImportCompraVenda;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDespeses;
        private System.Windows.Forms.DataGridViewTextBoxColumn cDividents;
        private System.Windows.Forms.Label label1;
        private Controls.NumericTextBox2 tbTotal;
    }
}