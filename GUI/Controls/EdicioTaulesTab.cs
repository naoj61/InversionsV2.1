using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Comuns;
using Microsoft.SqlServer.Server;


namespace Inversions.GUI
{
    public partial class EdicioTaulesTab : TabX
    {
        private struct Panell
        {
            private static readonly Dictionary<string, Panell> Panells = new Dictionary<string, Panell>();
            private const string NomControlPanellTaula = "Panell1";
            private const string NomControlDataGridViewTaula = "DgvTaula";
            private const string NomControlEtiquetaNomTaula = "EtiquetaNomTaula";

            private static string NomPanellActiu;

            private readonly Panel vPanell;
            private readonly Label vEtiqueta;
            private readonly DataGridView vDataGridView;
            private readonly string vNomTaula;
            private bool vEstaModificat;

            internal Panell(Panel panell, Label etiqueta, DataGridView dataGridView, string nomTaula)
                : this()
            {
                vPanell = panell;
                vEtiqueta = etiqueta;
                vDataGridView = dataGridView;
                vNomTaula = nomTaula;
                vEstaModificat = false;

                vPanell.Name = NomControlPanellTaula;
                vEtiqueta.Name = NomControlEtiquetaNomTaula;
                vDataGridView.Name = NomControlDataGridViewTaula;

                Panells.Add(nomTaula, this);
            }

            internal static Panell? PanellActiu
            {
                get { return Panells.ContainsKey(NomPanellActiu) ? Panells[NomPanellActiu] : (Panell?) null; }
            }

            /// <summary>
            /// Per desar el panell actiu, Només deso el nom de la taula.
            /// </summary>
            /// <param name="panell"></param>
            internal static void NouPanellActiu(Panell? panell)
            {
                if (panell.HasValue)
                    NouPanellActiu(panell.Value.vNomTaula);
                else
                    NouPanellActiu((string) null);
            }

            /// <summary>
            /// Per desar el panell actiu, Només deso el nom de la taula.
            /// </summary>
            /// <param name="nouPanellActiu"></param>
            internal static void NouPanellActiu(string nouPanellActiu)
            {
                if (NomPanellActiu != null && Panells.ContainsKey(NomPanellActiu))
                    Panells[NomPanellActiu].vPanell.BackColor = Color.PowderBlue;

                NomPanellActiu = nouPanellActiu;
                if (NomPanellActiu != null && Panells.ContainsKey(NomPanellActiu))
                    Panells[NomPanellActiu].vPanell.BackColor = Color.Red;
            }

            internal static void Esborra(Panell panell)
            {
                Panells.Remove(panell._NomTaula);
            }

            internal static Panell? TrobaElPanell(string nomTaula)
            {
                return Panells.ContainsKey(nomTaula) ? (Panell?) Panells[nomTaula] : null;
            }

            internal static bool HiHaModificacionsPendents()
            {
                return Panells.Any(a => a.Value._EstaModificat);
            }

            internal Panel _Panell
            {
                get { return vPanell; }
            }

            internal DataGridView _DataGridView
            {
                get { return vDataGridView; }
            }

            internal string _NomTaula
            {
                get { return vNomTaula; }
            }

            internal bool _EstaModificat
            {
                get { return vEstaModificat; }
            }

            /// <summary>
            /// Com que un struc no pot ser null, així comprovo si s'ha inicialitzat.
            /// </summary>
            internal bool _PanellCarregatOk
            {
                get { return !Equals(default(Panell)); }
            }

            /// <summary>
            /// Indica si s'ha modificat el DataGridView.
            /// </summary>
            /// <param name="nouEstat"></param>
            internal void modificaEstat(bool nouEstat)
            {
                if (nouEstat && !vEstaModificat)
                    vEtiqueta.Text = "* " + vEtiqueta.Text;
                else if (!nouEstat && vEstaModificat)
                    vEtiqueta.Text = vEtiqueta.Text.Substring(2);

                vEstaModificat = nouEstat;

                // Aixo és perque el panell de en Panells és una còpia, no una referència i per tant el valor no s'actualitza directament.
                Panells[_NomTaula] = this;
            }

            #region Overrides

            public override int GetHashCode()
            {
                return _Panell.GetHashCode();
            }

            public static bool operator ==(Panell a, Panell b)
            {
                // Aquest codi no cal en un struc perque mai pot ser null.

                //// If both are null, or both are same instance, return true.
                //if (ReferenceEquals(a, b))
                //{
                //    return true;
                //}

                //// If one is null,return false.
                //if ((object) a == null || (object) b == null)
                //{
                //    return false;
                //}

                return a.vNomTaula == b.vNomTaula;
            }

            public static bool operator !=(Panell a, Panell b)
            {
                return !(a == b);
            }

            public override bool Equals(object obj)
            {
                if (!(obj is Panell))
                    return false;

                return this == (Panell) obj;
            }

            public override string ToString()
            {
                return vEtiqueta.Text;
            }

            #endregion

        }

        private static readonly string StringConexio = Program.Sessio.Database.Connection.ConnectionString;

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


        /// <summary>
        /// Crea el panell per una nova taula.
        /// </summary>
        /// <returns></returns>
        private Panell InicialitzaControlsTaula(string nomPaula)
        {
            this.SuspendLayout();

            #region *** Controls Panell Taula pnTaules ***

            Panel pnTaula = new Panel();
            pnTaula.Dock = DockStyle.Left;
            pnTaula.Padding = new Padding(9);
            pnTaula.HorizontalScroll.Enabled = true;
            pnTaula.Tag = nomPaula;
            pnTaules.Controls.Add(pnTaula);

            Splitter splitter2 = new Splitter();
            splitter2.Name = "splitter2";
            splitter2.Dock = DockStyle.Left;
            pnTaules.Controls.Add(splitter2);

            pnTaula.BringToFront();
            splitter2.BringToFront();

            #endregion *** Control Panell Taula ***


            #region *** Controls pnTaula ***

            #region *** EtiquetaNomTaula pnEtiqueta ***

            Panel pnEtiqueta = new Panel();
            pnEtiqueta.Dock = DockStyle.Top;
            pnEtiqueta.Size = new Size(200, 28);
            pnTaula.Controls.Add(pnEtiqueta);

            Label etiquetaNomTaula = new Label();
            etiquetaNomTaula.Text = nomPaula;
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

            #region *** DataGridView dataGridView ***

            DataGridViewTextBoxColumn column1 = new DataGridViewTextBoxColumn();
            column1.DataPropertyName = "Id";
            column1.HeaderText = "Id";
            column1.Name = "Id";
            column1.Visible = true;
            column1.ReadOnly = true;

            DataGridViewTextBoxColumn column2 = new DataGridViewTextBoxColumn();
            column2.DataPropertyName = "RowVersion";
            column2.HeaderText = "RowVersion";
            column2.Name = "RowVersion";
            column2.Visible = false;

            DataGridView dataGridView = new DataGridView();
            dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {column1});
            dataGridView.Columns.AddRange(new DataGridViewColumn[] {column2});
            dataGridView.RowTemplate.Height = 28;
            dataGridView.Dock = DockStyle.Fill;
            pnTaula.Controls.Add(dataGridView);

            #endregion *** DataGridView ***

            pnEtiqueta.SendToBack();
            dataGridView.BringToFront();

            #endregion *** Controls pnTaula ***


            #region *** Activa events ***

            pnTaula.Enter += pnTaula_Enter;
            btTancaPanell.Click += btTancaPanell_Click;
            dataGridView.DataError += dataGridView_DataError;

            dataGridView.CellValidated += datagridView_CellValidated;
            dataGridView.RowsRemoved += datagridView_RowsRemoved;

            #endregion *** Activa events ***


            pnTaula.Focus();

            this.ResumeLayout();

            return new Panell(pnTaula, etiquetaNomTaula, dataGridView, nomPaula);
        }

        private void carregaTaula(Panell panell)
        {
            var dataGridView = panell._DataGridView;

            if (dataGridView == null)
                return;

            using (SqlConnection connection = new SqlConnection(StringConexio))
            {
                // Consulta SQL para seleccionar todos los registros de la tabla
                string query = "SELECT * FROM " + panell._NomTaula;

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();

                adapter.Fill(table);

                // Asignar la tabla como origen de datos del DataGridView
                dataGridView.DataSource = table;

                panell._Panell.Width = Utilitats.AjustaAmpladaDataGridView(dataGridView) + 20;
            }

            modeConsulta();

            Panell.PanellActiu.Value._Panell.Focus();
        }

        private void desaTaula(Panell panell)
        {
            var dataGridView = panell._DataGridView;

            if (dataGridView == null)
                return;

            string taula = panell._NomTaula;

            // Guardar cambios en la base de datos al hacer clic en el botón "Guardar"
            using (SqlConnection connection = new SqlConnection(StringConexio))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Crear comandos SQL para actualizar los cambios en la base de datos
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.SelectCommand = new SqlCommand("SELECT * FROM " + taula, connection);
                connection.Open();

                // Actualizar los cambios en la base de datos
                var files = (DataTable) dataGridView.DataSource;

                try
                {
                    adapter.Update(files);

                    panell.modificaEstat(false);

                    modeConsulta();

                    MessageBox.Show("Modificacions taula: " + taula + ". Ok.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                connection.Close();
            }

            Panell.PanellActiu.Value._Panell.Focus();
        }

        protected override void modeEdicio()
        {
            base.modeEdicio();

            Panell.PanellActiu.Value.modificaEstat(true);
        }

        protected override void modeConsulta()
        {
            Panell.PanellActiu.Value.modificaEstat(false);

            if (!Panell.HiHaModificacionsPendents())
                base.modeConsulta();
        }

        #region *** Events ***

        private void datagridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView datagridView = (DataGridView) sender;

            if (datagridView != null && datagridView.IsCurrentRowDirty)
            {
                modeEdicio();
            }
        }

        private void datagridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            var datagridView = (DataGridView) sender;

            if (datagridView != null && datagridView.IsCurrentRowDirty)
                modeEdicio();
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

            Panell? panell = Panell.TrobaElPanell(nomTaula);

            if (panell.HasValue)
            {
                panell.Value._Panell.Focus();
            }
            else
            {
                panell = InicialitzaControlsTaula(nomTaula);
                Panell.NouPanellActiu(panell);
                carregaTaula(panell.Value);
                DataGridView dgv = panell.Value._DataGridView;
            }

            btDesa.Enabled = true;
            btCancela.Enabled = true;
        }

        private void btDesa_Click(object sender, EventArgs e)
        {
            if (Panell.PanellActiu.HasValue)
                desaTaula(Panell.PanellActiu.Value);
            else
                MessageBox.Show("No hi ha cap taula seleccionada");
        }

        private void btCancela_Click(object sender, EventArgs e)
        {
            if (Panell.PanellActiu.HasValue)
                carregaTaula(Panell.PanellActiu.Value);
            else
                MessageBox.Show("No hi ha cap taula seleccionada");
        }

        private void btTancaPanell_Click(object sender, EventArgs e)
        {
            if (Panell.PanellActiu.HasValue)
            {
                if (Panell.PanellActiu.Value._EstaModificat)
                    MessageBox.Show("No es pot tancar la finestra, la taula s'està modificant");
                else
                {
                    pnTaules.Controls.Remove(Panell.PanellActiu.Value._Panell);
                    Panell.Esborra(Panell.PanellActiu.Value);
                    Panell.NouPanellActiu((string) null);
                }
            }
        }


        private void pnTaula_Enter(object sender, EventArgs e)
        {
            Panel panel = (Panel) sender;

            if (panel != null)
            {
                Panell.NouPanellActiu((string) panel.Tag);
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
