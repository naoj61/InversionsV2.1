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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ckTancaAlDesar = new System.Windows.Forms.CheckBox();
            this.btDesa = new System.Windows.Forms.Button();
            this.ckCapturaAutomaticament = new System.Windows.Forms.CheckBox();
            this.btCapturaValors = new System.Windows.Forms.Button();
            this.dtpDataUnica = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbColumnaPreuParticio = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colNomFons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ckDataUnica = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(826, 722);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.ckTancaAlDesar);
            this.flowLayoutPanel1.Controls.Add(this.btDesa);
            this.flowLayoutPanel1.Controls.Add(this.ckCapturaAutomaticament);
            this.flowLayoutPanel1.Controls.Add(this.btCapturaValors);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.textBox2);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 722);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1261, 79);
            this.flowLayoutPanel1.TabIndex = 1;
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
            // dtpDataUnica
            // 
            this.dtpDataUnica.Enabled = false;
            this.dtpDataUnica.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataUnica.Location = new System.Drawing.Point(3, 30);
            this.dtpDataUnica.Margin = new System.Windows.Forms.Padding(3, 4, 22, 4);
            this.dtpDataUnica.Name = "dtpDataUnica";
            this.dtpDataUnica.Size = new System.Drawing.Size(129, 26);
            this.dtpDataUnica.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbColumnaPreuParticio);
            this.groupBox1.Location = new System.Drawing.Point(349, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 60);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Columa Preu en Web";
            // 
            // cbColumnaPreuParticio
            // 
            this.cbColumnaPreuParticio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColumnaPreuParticio.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbColumnaPreuParticio.Location = new System.Drawing.Point(31, 28);
            this.cbColumnaPreuParticio.Name = "cbColumnaPreuParticio";
            this.cbColumnaPreuParticio.Size = new System.Drawing.Size(121, 28);
            this.cbColumnaPreuParticio.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colNomFons,
            this.colData,
            this.colValor});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.dataGridView1.Location = new System.Drawing.Point(826, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(435, 722);
            this.dataGridView1.TabIndex = 3;
            // 
            // colNomFons
            // 
            this.colNomFons.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNomFons.HeaderText = "Nom Fons";
            this.colNomFons.Name = "colNomFons";
            this.colNomFons.ReadOnly = true;
            // 
            // colData
            // 
            this.colData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Format = "d";
            dataGridViewCellStyle5.NullValue = null;
            this.colData.DefaultCellStyle = dataGridViewCellStyle5;
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Width = 80;
            // 
            // colValor
            // 
            this.colValor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "C4";
            dataGridViewCellStyle6.NullValue = "0";
            this.colValor.DefaultCellStyle = dataGridViewCellStyle6;
            this.colValor.HeaderText = "Valor";
            this.colValor.Name = "colValor";
            this.colValor.ReadOnly = true;
            this.colValor.Width = 82;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpDataUnica);
            this.panel1.Controls.Add(this.ckDataUnica);
            this.panel1.Location = new System.Drawing.Point(555, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 61);
            this.panel1.TabIndex = 4;
            // 
            // ckDataUnica
            // 
            this.ckDataUnica.AutoSize = true;
            this.ckDataUnica.Location = new System.Drawing.Point(7, 3);
            this.ckDataUnica.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.ckDataUnica.Name = "ckDataUnica";
            this.ckDataUnica.Size = new System.Drawing.Size(112, 24);
            this.ckDataUnica.TabIndex = 2;
            this.ckDataUnica.Text = "Data única";
            this.ckDataUnica.UseVisualStyleBackColor = true;
            this.ckDataUnica.CheckedChanged += new System.EventHandler(this.ckDataUnica_CheckedChanged);
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(53, 9);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(290, 60);
            this.textBox2.TabIndex = 5;
            this.textBox2.Text = "Les valoracions que ja existeixen no se sobreescriuen.";
            // 
            // PasteSelfBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1261, 801);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PasteSelfBank";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PasteSelfBank";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btCapturaValors;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btDesa;
        private System.Windows.Forms.DateTimePicker dtpDataUnica;
        private System.Windows.Forms.CheckBox ckTancaAlDesar;
        private System.Windows.Forms.CheckBox ckCapturaAutomaticament;
        private System.Windows.Forms.ComboBox cbColumnaPreuParticio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomFons;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValor;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckDataUnica;
        private System.Windows.Forms.TextBox textBox2;
    }
}