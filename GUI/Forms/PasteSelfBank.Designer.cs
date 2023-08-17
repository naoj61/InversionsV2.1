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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tbPaste = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.ckTancaAlDesar = new System.Windows.Forms.CheckBox();
            this.btDesa = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtpDataUnica = new System.Windows.Forms.DateTimePicker();
            this.ckDataUnica = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbColumnaPreuParticio = new System.Windows.Forms.ComboBox();
            this.ckSobreescriuValoracions = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btCapturaValorPaste = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colEstatOriginalCheckBox = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNomFons = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSeleccionat = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colData = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorActual = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colValorNou = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPercentatge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDif = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbPaste
            // 
            this.tbPaste.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbPaste.Location = new System.Drawing.Point(0, 0);
            this.tbPaste.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbPaste.Multiline = true;
            this.tbPaste.Name = "tbPaste";
            this.tbPaste.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbPaste.Size = new System.Drawing.Size(433, 722);
            this.tbPaste.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.ckTancaAlDesar);
            this.flowLayoutPanel1.Controls.Add(this.btDesa);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.ckSobreescriuValoracions);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.btCapturaValorPaste);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 722);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(6);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1343, 79);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // ckTancaAlDesar
            // 
            this.ckTancaAlDesar.AutoSize = true;
            this.ckTancaAlDesar.Checked = true;
            this.ckTancaAlDesar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckTancaAlDesar.Location = new System.Drawing.Point(1189, 26);
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
            this.btDesa.Location = new System.Drawing.Point(1074, 10);
            this.btDesa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btDesa.Name = "btDesa";
            this.btDesa.Size = new System.Drawing.Size(109, 55);
            this.btDesa.TabIndex = 0;
            this.btDesa.Text = "Desa";
            this.btDesa.UseVisualStyleBackColor = true;
            this.btDesa.Click += new System.EventHandler(this.btDesa_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtpDataUnica);
            this.panel1.Controls.Add(this.ckDataUnica);
            this.panel1.Location = new System.Drawing.Point(934, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 61);
            this.panel1.TabIndex = 4;
            // 
            // dtpDataUnica
            // 
            this.dtpDataUnica.Enabled = false;
            this.dtpDataUnica.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataUnica.Location = new System.Drawing.Point(0, 35);
            this.dtpDataUnica.Margin = new System.Windows.Forms.Padding(3, 4, 22, 4);
            this.dtpDataUnica.Name = "dtpDataUnica";
            this.dtpDataUnica.Size = new System.Drawing.Size(129, 26);
            this.dtpDataUnica.TabIndex = 1;
            this.dtpDataUnica.ValueChanged += new System.EventHandler(this.dtpDataUnica_ValueChanged);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbColumnaPreuParticio);
            this.groupBox1.Location = new System.Drawing.Point(728, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 60);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "(Deshabilitat)Columa Preu en Web";
            this.groupBox1.Visible = false;
            // 
            // cbColumnaPreuParticio
            // 
            this.cbColumnaPreuParticio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColumnaPreuParticio.Items.AddRange(new object[] {
            "Auto",
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
            // ckSobreescriuValoracions
            // 
            this.ckSobreescriuValoracions.Location = new System.Drawing.Point(593, 9);
            this.ckSobreescriuValoracions.Name = "ckSobreescriuValoracions";
            this.ckSobreescriuValoracions.Size = new System.Drawing.Size(129, 61);
            this.ckSobreescriuValoracions.TabIndex = 2;
            this.ckSobreescriuValoracions.Text = "Sobreescriu Valoracions";
            this.ckSobreescriuValoracions.UseVisualStyleBackColor = true;
            this.ckSobreescriuValoracions.CheckedChanged += new System.EventHandler(this.ckDataUnica_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox3);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Location = new System.Drawing.Point(364, 9);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(223, 58);
            this.panel2.TabIndex = 5;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Blue;
            this.textBox3.Location = new System.Drawing.Point(0, 28);
            this.textBox3.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(223, 28);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = "Ja existeis una valoració";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.DarkOrange;
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(223, 28);
            this.textBox2.TabIndex = 0;
            this.textBox2.Text = "Diferència superior al 10%";
            // 
            // btCapturaValorPaste
            // 
            this.btCapturaValorPaste.Location = new System.Drawing.Point(249, 10);
            this.btCapturaValorPaste.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btCapturaValorPaste.Name = "btCapturaValorPaste";
            this.btCapturaValorPaste.Size = new System.Drawing.Size(109, 55);
            this.btCapturaValorPaste.TabIndex = 0;
            this.btCapturaValorPaste.Text = "Captura Paste";
            this.btCapturaValorPaste.UseVisualStyleBackColor = true;
            this.btCapturaValorPaste.Click += new System.EventHandler(this.btCapturaValorPaste_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colEstatOriginalCheckBox,
            this.colNomFons,
            this.colSeleccionat,
            this.colData,
            this.colValorActual,
            this.colValorNou,
            this.colPercentatge,
            this.colDif});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(433, 0);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(910, 722);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            // 
            // colEstatOriginalCheckBox
            // 
            this.colEstatOriginalCheckBox.HeaderText = "EstatCheckBox";
            this.colEstatOriginalCheckBox.Name = "colEstatOriginalCheckBox";
            this.colEstatOriginalCheckBox.Visible = false;
            // 
            // colNomFons
            // 
            this.colNomFons.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colNomFons.HeaderText = "Nom Fons";
            this.colNomFons.Name = "colNomFons";
            this.colNomFons.ReadOnly = true;
            this.colNomFons.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colNomFons.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // colSeleccionat
            // 
            this.colSeleccionat.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.colSeleccionat.HeaderText = "Selec";
            this.colSeleccionat.Name = "colSeleccionat";
            this.colSeleccionat.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colSeleccionat.Width = 55;
            // 
            // colData
            // 
            this.colData.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            this.colData.DefaultCellStyle = dataGridViewCellStyle1;
            this.colData.HeaderText = "Data";
            this.colData.Name = "colData";
            this.colData.ReadOnly = true;
            this.colData.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colData.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colData.Width = 50;
            // 
            // colValorActual
            // 
            this.colValorActual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "#,#0.00###### €";
            dataGridViewCellStyle2.NullValue = null;
            this.colValorActual.DefaultCellStyle = dataGridViewCellStyle2;
            this.colValorActual.HeaderText = "Valor Act";
            this.colValorActual.Name = "colValorActual";
            this.colValorActual.ReadOnly = true;
            this.colValorActual.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colValorActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colValorActual.Width = 80;
            // 
            // colValorNou
            // 
            this.colValorNou.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "#,#0.00###### €";
            dataGridViewCellStyle3.NullValue = "0";
            this.colValorNou.DefaultCellStyle = dataGridViewCellStyle3;
            this.colValorNou.HeaderText = "Valor Nou";
            this.colValorNou.Name = "colValorNou";
            this.colValorNou.ReadOnly = true;
            this.colValorNou.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colValorNou.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colValorNou.Width = 85;
            // 
            // colPercentatge
            // 
            this.colPercentatge.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "#0.000 %";
            dataGridViewCellStyle4.NullValue = null;
            this.colPercentatge.DefaultCellStyle = dataGridViewCellStyle4;
            this.colPercentatge.HeaderText = "%";
            this.colPercentatge.Name = "colPercentatge";
            this.colPercentatge.ReadOnly = true;
            this.colPercentatge.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colPercentatge.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colPercentatge.Width = 29;
            // 
            // colDif
            // 
            this.colDif.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "#,#0.00 €";
            dataGridViewCellStyle5.NullValue = null;
            this.colDif.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDif.HeaderText = "Dif";
            this.colDif.Name = "colDif";
            this.colDif.ReadOnly = true;
            this.colDif.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.colDif.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.colDif.Width = 35;
            // 
            // PasteSelfBank
            // 
            this.AcceptButton = this.btCapturaValorPaste;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1343, 801);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tbPaste);
            this.Controls.Add(this.flowLayoutPanel1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PasteSelfBank";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "PasteSelfBank";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbPaste;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btDesa;
        private System.Windows.Forms.DateTimePicker dtpDataUnica;
        private System.Windows.Forms.CheckBox ckTancaAlDesar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox ckDataUnica;
        private System.Windows.Forms.CheckBox ckSobreescriuValoracions;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbColumnaPreuParticio;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstatOriginalCheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNomFons;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSeleccionat;
        private System.Windows.Forms.DataGridViewTextBoxColumn colData;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorActual;
        private System.Windows.Forms.DataGridViewTextBoxColumn colValorNou;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPercentatge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDif;
        private System.Windows.Forms.Button btCapturaValorPaste;
    }
}