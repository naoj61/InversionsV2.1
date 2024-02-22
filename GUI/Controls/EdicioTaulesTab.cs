using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Comuns;



namespace Inversions.GUI
{
    public partial class EdicioTaulesTab : TabX
    {
        private const string NomControlPanellTaula = "Panell1";
        private const string NomControlDataGridViewTaula = "DgvTaula";
        private const string NomControlEtiquetaNomTaula = "EtiquetaNomTaula";

        private static readonly string StringConexio = Program.Sessio.Database.Connection.ConnectionString;
        private readonly Dictionary<string, Panel> vControlsTaula = new Dictionary<string, Panel>();

        private Panel vPanellActiu;
        private Panel vPanellAnteriorActiu;

        public EdicioTaulesTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Busca en els controls parent amb el nom.
        /// </summary>
        /// <param name="control"></param>
        /// <param name="nom"></param>
        /// <returns></returns>
        private static Control TrobaControlParent(Control control, string nom)
        {
            if (control == null)
                return null;

            if (control.Name == nom)
                return control;

            return TrobaControlParent(control.Parent, nom);
        }

        /// <summary>
        /// Busca en els controls fill amb el nom.
        /// </summary>
        /// <param name="parentControl"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private static Control TrobaControlFill(Control parentControl, string name)
        {
            // Recorre tots els controls dins del parentControl
            foreach (Control control in parentControl.Controls)
            {
                // Comprova si el nom del control coincideix amb el que estem buscant
                if (control.Name == name)
                {
                    return control; // Retorna el control si s'ha trobat
                }

                // Si el control actual té controls interns, crida recursivament aquest mètode
                if (control.HasChildren)
                {
                    Control childControl = TrobaControlFill(control, name);
                    if (childControl != null)
                    {
                        return childControl; // Retorna el control si s'ha trobat dins dels controls interns
                    }
                }
            }
            return null; // Retorna null si no s'ha trobat cap control amb el nom especificat
        }

        private Panel InicialitzaControlsTaula()
        {
            this.SuspendLayout();

            #region *** Control Panell Taula ***

            Panel pnTaula = new Panel();
            pnTaula.Name = NomControlPanellTaula;
            pnTaula.Dock = DockStyle.Left;
            pnTaula.Padding = new Padding(9);
            pnTaula.HorizontalScroll.Enabled = true;
            pnTaula.VerticalScroll.Enabled = true;
            pnTaules.Controls.Add(pnTaula);

            #region *** EtiquetaNomTaula ***

            Panel pnEtiqueta = new Panel();
            pnEtiqueta.Dock = DockStyle.Top;
            pnEtiqueta.Size = new Size(200, 28);
            pnTaula.Controls.Add(pnEtiqueta);

            Label etiquetaNomTaula = new Label();
            etiquetaNomTaula.Name = NomControlEtiquetaNomTaula;
            etiquetaNomTaula.Dock = DockStyle.Fill;
            etiquetaNomTaula.BackColor = Color.DarkGray;
            etiquetaNomTaula.AutoSize = false;
            etiquetaNomTaula.TextAlign = ContentAlignment.MiddleCenter;
            etiquetaNomTaula.Font = new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Bold);
            pnEtiqueta.Controls.Add(etiquetaNomTaula);

            Button btTancaPanell = new Button();
            btTancaPanell.Dock = DockStyle.Right;
            btTancaPanell.Text = "X";
            btTancaPanell.Font = new Font("Arial", 8);
            btTancaPanell.BackColor = Color.White;
            btTancaPanell.FlatStyle = FlatStyle.Flat;
            btTancaPanell.Size = new Size(22, 22);
            pnEtiqueta.Controls.Add(btTancaPanell);

            #endregion *** EtiquetaNomTaula ***

            #region *** DataGridView ***

            DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
            column.DataPropertyName = "RowVersion";
            column.HeaderText = "RowVersion";
            column.Name = "RowVersion";
            column.Visible = false;

            DataGridView dataGridView = new DataGridView();
            dataGridView.Name = NomControlDataGridViewTaula;
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {column});
            dataGridView.RowTemplate.Height = 28;
            dataGridView.Dock = DockStyle.Fill;
            pnTaula.Controls.Add(dataGridView);

            #endregion *** DataGridView ***

            Splitter splitter2 = new Splitter();
            splitter2.Name = "splitter2";
            splitter2.Dock = DockStyle.Left;
            pnTaules.Controls.Add(splitter2);

            #endregion *** Control Panell Taula ***

            Panell panell = new Panell(pnTaula, etiquetaNomTaula, dataGridView);


            #region *** Ordena controls ***

            pnTaula.BringToFront();
            pnEtiqueta.BringToFront();
            btTancaPanell.BringToFront();
            etiquetaNomTaula.BringToFront();
            splitter2.BringToFront();

            #endregion *** Ordena controls ***

            #region *** Activa events ***

            pnTaula.Enter += pnTaula_Enter;
            pnTaula.Leave += pnTaula_Leave;
            btTancaPanell.Click += btTancaPanell_Click;
            dataGridView.DataError += dataGridView_DataError;


            #endregion *** Activa events ***

            pnTaula.Focus();
            this.ResumeLayout();

            return pnTaula;
        }

        bool estaTaulaModificada(Panel panell)
        {
            var ff = TrobaControlFill(panell, NomControlEtiquetaNomTaula);

            return ff.Text.StartsWith("* ");
        }

        private void marcaTaulaModificada()
        {
            var ff = TrobaControlFill(vPanellActiu, NomControlEtiquetaNomTaula);

            if (!ff.Text.StartsWith("* "))
            {
                ff.Text = "* " + ff.Text;
                modeEdicio();
            }
        }

        private void carregaTaula(Panel panell, string taula = null)
        {
            var dgvActiu = (DataGridView)TrobaControlFill(panell, NomControlDataGridViewTaula);

            if (dgvActiu == null)
                return;

            if (taula == null)
                taula = (string) dgvActiu.Tag;
            else
                dgvActiu.Tag = taula;

            using (SqlConnection connection = new SqlConnection(StringConexio))
            {
                // Consulta SQL para seleccionar todos los registros de la tabla
                string query = "SELECT * FROM " + taula;

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();

                adapter.Fill(table);

                // Asignar la tabla como origen de datos del DataGridView
                dgvActiu.DataSource = table;

                vPanellActiu.Width = Utilitats.AjustaAmpladaDataGridView(dgvActiu) + 20;
            }

            var etiquetaNomTaula = TrobaControlFill(panell, NomControlEtiquetaNomTaula);
            if (etiquetaNomTaula != null)
                etiquetaNomTaula.Text = taula;

            modeConsulta();
        }

        private void desaTaula()
        {
            var dgvActiu = (DataGridView) TrobaControlFill(vPanellActiu, NomControlDataGridViewTaula);

            if (dgvActiu == null)
                return;

            string taula = (string) dgvActiu.Tag;

            // Guardar cambios en la base de datos al hacer clic en el botón "Guardar"
            using (SqlConnection connection = new SqlConnection(StringConexio))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Crear comandos SQL para actualizar los cambios en la base de datos
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.SelectCommand = new SqlCommand("SELECT * FROM " + taula, connection);
                connection.Open();

                // Actualizar los cambios en la base de datos
                var files = (DataTable) dgvActiu.DataSource;

                try
                {
                    adapter.Update(files);

                    var ff = TrobaControlFill(vPanellActiu, NomControlEtiquetaNomTaula);

                    if (ff.Text.StartsWith("* "))
                        ff.Text = taula;

                    modeConsulta();

                    MessageBox.Show("Modificacions taula: " + taula + ". Ok.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                connection.Close();
            }
        }

        protected override void modeConsulta()
        {
            bool hiHaModificacions = vControlsTaula.Values
                .Select(panell => TrobaControlFill(panell, NomControlEtiquetaNomTaula))
                .Any(etiqueta => etiqueta != null && etiqueta.Text.StartsWith("*"));
            
            if (!hiHaModificacions)
                base.modeConsulta();
        }

        #region *** Events ***

        private void datagridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView datagridView = (DataGridView)sender;

            if (datagridView.IsCurrentRowDirty)
            {
                marcaTaulaModificada();
            }
        }

        private void datagridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            marcaTaulaModificada();
        }

        private void edicioTaulesTab_Load(object sender, EventArgs e)
        {
            // Obté una llista de les taules disponibles a la base de dades
            var tables = Program.Sessio.Database
                .SqlQuery<string>("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'").ToList();

            // Omple un desplegable amb les taules
            comboBoxTaules.DataSource = tables;
            comboBoxTaules.SelectedItem = null;

            comboBoxTaules.SelectedIndexChanged -= comboBoxTables_SelectedIndexChanged;
            comboBoxTaules.SelectedIndexChanged += comboBoxTables_SelectedIndexChanged;
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            var nomTaula = comboBoxTaules.SelectedItem.ToString();
            Panel panell;

            if (vControlsTaula.ContainsKey(nomTaula))
            {
                panell = vControlsTaula[nomTaula];
                panell.Focus();
            }
            else
            {
                panell = InicialitzaControlsTaula();
                vControlsTaula.Add(nomTaula, panell);
                carregaTaula(panell, nomTaula);
                DataGridView dgv = (DataGridView)TrobaControlFill(panell, NomControlDataGridViewTaula);
                dgv.CellValidated += datagridView_CellValidated;
                dgv.RowsRemoved += datagridView_RowsRemoved;
            }
           
            btDesa.Enabled = true;
            btCancela.Enabled = true;
        }

        private void btDesa_Click(object sender, EventArgs e)
        {
            desaTaula();
        }

        private void btCancela_Click(object sender, EventArgs e)
        {
            carregaTaula(vPanellActiu);
        }

        private void btTancaPanell_Click(object sender, EventArgs e)
        {
            Panel panell1 = (Panel) TrobaControlParent((Control) sender, NomControlPanellTaula);

            if (panell1 != null)
            {
                if (estaTaulaModificada(panell1))
                    MessageBox.Show("No es pot tancar la finestra, la taula s'està modificant");
                else
                {
                    pnTaules.Controls.Remove(panell1);
                    vControlsTaula.Remove(vControlsTaula.Single(s => s.Value == panell1).Key);
                }
            }
        }

        private void pnTaula_Leave(object sender, EventArgs e)
        {
            vPanellAnteriorActiu = (Panel) sender;
        }

        private void pnTaula_Enter(object sender, EventArgs e)
        {
            Panel panel = (Panel) sender;

            if (panel != null)
            {
                vPanellActiu = panel;

                panel.BackColor = Color.Red;

                // No poso el panell que ha perdut el focus en blau fins que entro en un altre panell.
                if (vPanellAnteriorActiu != null)
                    vPanellAnteriorActiu.BackColor = Color.PowderBlue;
            }
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataGridView grid = (DataGridView) sender;

            if (grid.Columns[e.ColumnIndex].Name == "RowVersion")
            {
                e.ThrowException = false;
                e.Cancel = true;
            }
        }

        #endregion *** Events ***
    }
}
