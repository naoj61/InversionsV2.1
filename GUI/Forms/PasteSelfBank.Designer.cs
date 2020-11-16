namespace Inversions.GUI
{
    partial class PasteSelfBank
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ckTancaAlDesar = new System.Windows.Forms.CheckBox();
            this.btDesa = new System.Windows.Forms.Button();
            this.ckCapturaAutomaticament = new System.Windows.Forms.CheckBox();
            this.btCapturaValors = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colNomFons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(826, 726);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.ckTancaAlDesar);
            this.panel1.Controls.Add(this.btDesa);
            this.panel1.Controls.Add(this.ckCapturaAutomaticament);
            this.panel1.Controls.Add(this.btCapturaValors);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.panel1.Location = new System.Drawing.Point(0, 726);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(1261, 75);
            this.panel1.TabIndex = 1;
            // 
            // ckTancaAlDesar
            // 
            this.ckTancaAlDesar.AutoSize = true;
            this.ckTancaAlDesar.Checked = true;
            this.ckTancaAlDesar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckTancaAlDesar.Location = new System.Drawing.Point(1107, 26);
            this.ckTancaAlDesar.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.ckTancaAlDesar.Name = "ckTancaAlDesar";
            this.ckTancaAlDesar.Size = new System.Drawing.Size(139, 24);
            this.ckTancaAlDesar.TabIndex = 2;
            this.ckTancaAlDesar.Text = "Tanca al desar";
            this.ckTancaAlDesar.UseVisualStyleBackColor = true;
            // 
            // btDesa
            // 
            this.btDesa.Enabled = false;
            this.btDesa.Location = new System.Drawing.Point(992, 10);
            this.btDesa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDesa.Name = "btDesa";
            this.btDesa.Size = new System.Drawing.Size(109, 55);
            this.btDesa.TabIndex = 0;
            this.btDesa.Text = "Desa";
            this.btDesa.UseVisualStyleBackColor = true;
            this.btDesa.Click += new System.EventHandler(this.btDesa_Click);
            // 
            // ckCapturaAutomaticament
            // 
            this.ckCapturaAutomaticament.AutoSize = true;
            this.ckCapturaAutomaticament.Checked = true;
            this.ckCapturaAutomaticament.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckCapturaAutomaticament.Location = new System.Drawing.Point(810, 26);
            this.ckCapturaAutomaticament.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.ckCapturaAutomaticament.Name = "ckCapturaAutomaticament";
            this.ckCapturaAutomaticament.Size = new System.Drawing.Size(176, 24);
            this.ckCapturaAutomaticament.TabIndex = 2;
            this.ckCapturaAutomaticament.Text = "Captura al fer Paste";
            this.ckCapturaAutomaticament.UseVisualStyleBackColor = true;
            this.ckCapturaAutomaticament.CheckedChanged += new System.EventHandler(this.ckCapturaAutomaticament_CheckedChanged);
            // 
            // btCapturaValors
            // 
            this.btCapturaValors.Location = new System.Drawing.Point(695, 10);
            this.btCapturaValors.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btCapturaValors.Name = "btCapturaValors";
            this.btCapturaValors.Size = new System.Drawing.Size(109, 55);
            this.btCapturaValors.TabIndex = 0;
            this.btCapturaValors.Text = "Captura Valors";
            this.btCapturaValors.UseVisualStyleBackColor = true;
            this.btCapturaValors.Click += new System.EventHandler(this.btCapturaValors_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(541, 10);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 22, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(129, 26);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNomFons,
            this.colValor});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.Location = new System.Drawing.Point(826, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(435, 726);
            this.dataGridView1.TabIndex = 3;
            // 
            // colNomFons
            // 
            this.colNomFons.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNomFons.HeaderText = "Nom Fons";
            this.colNomFons.Name = "colNomFons";
            this.colNomFons.ReadOnly = true;
            // 
            // colValor
            // 
            this.colValor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "C4";
            dataGridViewCellStyle2.NullValue = "0";
            this.colValor.DefaultCellStyle = dataGridViewCellStyle2;
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Width = 82;
            // 
            // PasteSelfBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 801);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PasteSelfBank";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PasteSelfBank";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel panel1;
        private System.Windows.Forms.Button btCapturaValors;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btDesa;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomFons;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.CheckBox ckTancaAlDesar;
        private System.Windows.Forms.CheckBox ckCapturaAutomaticament;
    }
}