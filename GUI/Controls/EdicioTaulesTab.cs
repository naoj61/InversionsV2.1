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
        private static readonly string StringConexio = Program.Sessio.Database.Connection.ConnectionString;
        private readonly Timer vCheckSortingTimer;
        private bool vIsSorting;

        public EdicioTaulesTab()
        {
            InitializeComponent();

            // Configurar el Timer. És per poder ordenar camps sense que es posi en mode edició.
            vCheckSortingTimer = new Timer();
            vCheckSortingTimer.Interval = 50; // Retard de 50 mil·lisegons (ajusta segons necessitis)
            vCheckSortingTimer.Tick += checkSortingTimer_Tick;
        }

        #region *** Mètodes que no s'utilitzen, però que poden servir en el futur ***

        // ReSharper disable UnusedMember.Local
        /// <summary>
        ///     Busca en els controls parent amb el nom.
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
        ///     Busca en els controls fill amb el nom.
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

        // ReSharper restore UnusedMember.Local

        #endregion *** Mètodes que no s'utilitzen, però que poden servir en el futur ***

        /// <summary>
        ///     Crea el panell per a una nova taula.
        /// </summary>
        /// <returns></returns>
        private Panell InicialitzaControlsTaula(string nomTaula)
        {
            SuspendLayout();

            var panell = new Panell(nomTaula, pnTaules);

            #region *** Activa events ***

            panell.btTancaPanellClick += panell_BtTancaPanellClick;
            panell.dataGridViewEnter += panell_DataGridViewEnter;

            #endregion *** Activa events ***

            ResumeLayout();

            return panell;
        }

        private void carregaTaula(Panell panell)
        {
            Cursor cursor = Cursor;
            Cursor = Cursors.WaitCursor;

            try
            {
                DataGridView dataGridView = panell._DataGridView;

                if (dataGridView == null)
                    return;

                try
                {
                    dataGridView.CellValidated -= datagridView_CellValidated;
                    dataGridView.ColumnHeaderMouseClick -= dataGridView_ColumnHeaderMouseClick;
                    dataGridView.RowsRemoved -= datagridView_RowsRemoved;

                    // Guarda la posicio del dataGridView i la cel·la seleccionada.
                    int filaSelec = dataGridView.CurrentRow == null ? 0 : dataGridView.CurrentCell.RowIndex;
                    int colSelec = dataGridView.CurrentRow == null ? 0 : dataGridView.CurrentCell.ColumnIndex;
                    int primeraFilaMostrada = dataGridView.FirstDisplayedScrollingRowIndex;

                    using (var connection = new SqlConnection(StringConexio))
                    {
                        // Consulta SQL para seleccionar todos los registros de la tabla
                        string query = "SELECT * FROM " + panell._NomTaula;

                        var adapter = new SqlDataAdapter(query, connection);
                        var table = new DataTable();

                        adapter.Fill(table);

                        // Asignar la tabla como origen de datos del DataGridView
                        dataGridView.DataSource = table;

                        panell._Panel.Width = Utilitats.AjustaAmpladaDataGridView(dataGridView) + 20;
                    }

                    try
                    {
                        // Restaura la posicio del dataGridView i la cel·la seleccionada.
                        dataGridView.CurrentCell = dataGridView.Rows[filaSelec].Cells[colSelec];
                        dataGridView.FirstDisplayedScrollingRowIndex = primeraFilaMostrada;
                    }
                    catch (Exception)
                    {
                        // Si dona error no passa res.
                    }

                    modeConsulta();

                    if (Panell._PanellActiu != null)
                        Panell._PanellActiu._Panel.Focus();
                }
                finally
                {
                    dataGridView.CellValidated += datagridView_CellValidated;
                    dataGridView.ColumnHeaderMouseClick += dataGridView_ColumnHeaderMouseClick;
                    dataGridView.RowsRemoved += datagridView_RowsRemoved;
                }
            }
            finally
            {
                Cursor = cursor;
            }
        }

        private void desaTaula(Panell panell)
        {
            Cursor cursor = Cursor;
            Cursor = Cursors.WaitCursor;

            try
            {
                DataGridView dataGridView = panell._DataGridView;

                if (dataGridView == null)
                    return;

                string taula = panell._NomTaula;

                // Guardar cambios en la base de datos al hacer clic en el botón "Guardar"
                using (var connection = new SqlConnection(StringConexio))
                {
                    var adapter = new SqlDataAdapter();

                    // Crear comandos SQL para actualizar los cambios en la base de datos
                    var builder = new SqlCommandBuilder(adapter);
                    adapter.SelectCommand = new SqlCommand("SELECT * FROM " + taula, connection);
                    connection.Open();

                    // Actualizar los cambios en la base de datos
                    var files = (DataTable) dataGridView.DataSource;

                    try
                    {
                        adapter.Update(files);

                        panell._EstaModificat = false;

                        modeConsulta();

                        ActivaRefrescaEnTabs(this);
                        try
                        {
                            Program.Sessio.refrescaTaula(taula);
                        }
                        catch (InvalidExpressionException)
                        {
                            MessageBox.Show(taula + " No s'ha pogut refrescar en Entity Framework");
                        }

                        carregaTaula(panell);

                        MessageBox.Show("Modificacions taula: " + taula + ". Ok.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }

                    connection.Close();
                }

                Panell._PanellActiu._Panel.Focus();
            }
            finally
            {
                Cursor = cursor;
            }
        }

        #region *** Sobreescriu mètodes de TabX ***

        internal override void carregaInicial()
        {
            base.carregaInicial();

            // Obté una llista de les taules disponibles a la base de dades
            List<string> tables = Program.Sessio.Database
                .SqlQuery<string>("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE' ORDER BY TABLE_NAME").ToList();

            // Omple un desplegable amb les taules
            cbBoxTaules.DataSource = tables;
            cbBoxTaules.SelectedItem = null;

            cbBoxTaules.SelectedIndexChanged -= cbTaules_SelectedIndexChanged;
            cbBoxTaules.SelectedIndexChanged += cbTaules_SelectedIndexChanged;
        }

        internal override void refresca()
        {
            base.refresca();

            foreach (object control in pnTaules.Controls)
            {
                var ctrl = control as Panel;
                if (ctrl != null)
                {
                    Panell panell = Panell.TrobaElPanell(ctrl);
                    if (panell != null)
                        carregaTaula(panell);
                }
            }
        }

        protected override void modeEdicio()
        {
            base.modeEdicio();

            Panell._PanellActiu._EstaModificat = true;

            btDesa.Enabled = true;
            btCancela.Enabled = true;
        }

        protected override void modeConsulta()
        {
            if (Panell._PanellActiu != null)
                Panell._PanellActiu._EstaModificat = false;

            if (!Panell.HiHaModificacionsPendents())
                base.modeConsulta();

            btDesa.Enabled = false;
            btCancela.Enabled = false;
        }

        #endregion *** sobreescriu mètodes de TabX ***

        #region *** Events ***

        private void datagridView_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            var datagridView = (DataGridView) sender;

            if (datagridView != null && datagridView.IsCurrentRowDirty)
            {
                modeEdicio();
            }
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Indicar que s'està realitzant una operació d'ordenació
            vIsSorting = true;
        }

        private void datagridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            /* Utilitzo el temporitzador perque RowsRemoved s'executa abans que ColumnHeaderMouseClick 
             * i no puc saber si s'està ordenant o esborrant files. */
            vCheckSortingTimer.Start(); // Començar el temporitzador per retardar la lògica
        }

        /// <summary>
        ///     Utilitzo el timer per què al ordenar un camp s'executa 'RowsRemoved' i no vull que es posi en mode edició.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkSortingTimer_Tick(object sender, EventArgs e)
        {
            // Aturar el temporitzador
            vCheckSortingTimer.Stop();

            // Només executar la lògica si no s'està ordenant
            if (!vIsSorting)

                // Aquí va la teva lògica quan es remouen files
                modeEdicio();

            vIsSorting = false;
        }


        private void cbTaules_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbBoxTaules.SelectedItem != null)
            {
                string nomTaula = cbBoxTaules.SelectedItem.ToString();

                Panell panell = Panell.TrobaElPanell(nomTaula);

                if (panell != null)
                {
                    panell._DataGridView.Focus();
                }
                else
                {
                    panell = InicialitzaControlsTaula(nomTaula);
                    Panell.PanellActiu(panell);
                    carregaTaula(panell);
                }
            }
        }

        private void btDesa_Click(object sender, EventArgs e)
        {
            if (Panell._PanellActiu != null)
                desaTaula(Panell._PanellActiu);
            else
                MessageBox.Show("No hi ha cap taula seleccionada");
        }

        private void btCancela_Click(object sender, EventArgs e)
        {
            if (Panell._PanellActiu != null)
                carregaTaula(Panell._PanellActiu);
            else
                MessageBox.Show("No hi ha cap taula seleccionada");
        }

        private void panell_BtTancaPanellClick(object sender, EventArgs e)
        {
            var panell = (Panell) sender;

            if (panell != null)
            {
                if (panell._EstaModificat)
                    MessageBox.Show("No es pot tancar la finestra, la taula s'està modificant");
                else
                {
                    panell._DataGridView.CellValidated -= datagridView_CellValidated;
                    panell._DataGridView.ColumnHeaderMouseClick -= dataGridView_ColumnHeaderMouseClick;
                    panell._DataGridView.RowsRemoved -= datagridView_RowsRemoved;

                    pnTaules.Controls.Remove(panell._Panel);
                    Panell.Esborra(panell);
                }
            }
        }

        private void panell_DataGridViewEnter(object sender, EventArgs e)
        {
            if (Panell._PanellActiu != null && Panell._PanellActiu._EstaModificat)
                modeEdicio();
            else
                modeConsulta();
        }

        #endregion *** Events ***

        private class Panell
        {
            private static readonly Dictionary<Panel, Panell> Panells = new Dictionary<Panel, Panell>();
            private readonly DataGridView vDataGridView;
            private readonly Label vEtiqueta;
            private readonly string vNomTaula;
            private readonly Panel vPanel;
            private Button vBtTancaPanell;
            private bool vEstaModificat;

            /// <summary>
            /// </summary>
            /// <param name="nomTaula"></param>
            /// <param name="pnTaules">Panell contenidor de tots els panelss taula.</param>
            internal Panell(string nomTaula, Panel pnTaules)
            {
                vNomTaula = nomTaula;
                vPanel = new Panel();
                vEtiqueta = new Label();
                vDataGridView = new DataGridView();
                vEstaModificat = false;

                creaControlsPanell(pnTaules, nomTaula, vPanel, vEtiqueta, vDataGridView);
            }

            internal static Panell _PanellActiu { get; private set; }

            internal Panel _Panel
            {
                get { return vPanel; }
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
                set
                {
                    vEstaModificat = value;

                    if (value)
                    {
                        // Canvío el color del titol.
                        vEtiqueta.BackColor = Color.Green;
                        vEtiqueta.ForeColor = Color.White;

                        vBtTancaPanell.Visible = false;
                    }
                    else
                    {
                        // Restaura el color del titol.
                        vEtiqueta.BackColor = Color.DarkGray;
                        vEtiqueta.ForeColor = Color.Black;

                        vBtTancaPanell.Visible = true;
                    }
                }
            }

            private bool _EsActiu
            {
                get { return this == _PanellActiu; }
            }

            #region Overrides

            public override int GetHashCode()
            {
                return _Panel.GetHashCode();
            }

            public static bool operator ==(Panell a, Panell b)
            {
                // Aquest codi no cal en un struc perque mai pot ser null.

                // If both are null, or both are same instance, return true.
                if (ReferenceEquals(a, b))
                {
                    return true;
                }

                // If one is null,return false.
                if ((object) a == null || (object) b == null)
                {
                    return false;
                }

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

            public event EventHandler btTancaPanellClick;
            public event EventHandler dataGridViewEnter;

            /// <summary>
            ///     Crea els controls taula.
            /// </summary>
            /// <param name="pnTaules">Panell contenidor de tots els panelss taula.</param>
            /// <param name="nomTaula">Nom taula</param>
            /// <param name="pnTaula">Panell taula</param>
            /// <param name="etiquetaNomTaula">Etiqueta</param>
            /// <param name="dataGridView"></param>
            private void creaControlsPanell(Panel pnTaules, string nomTaula, Panel pnTaula, Label etiquetaNomTaula, DataGridView dataGridView)
            {
                pnTaula.SuspendLayout();

                #region *** Controls Panell Taula pnTaules ***

                pnTaula.Name = "pnTaula";
                pnTaula.Dock = DockStyle.Left;
                pnTaula.Padding = new Padding(9);
                pnTaula.HorizontalScroll.Enabled = true;
                pnTaules.Controls.Add(pnTaula);

                var splitter2 = new Splitter();
                splitter2.Name = "splitter2";
                splitter2.Dock = DockStyle.Left;
                splitter2.Width = 9;
                pnTaules.Controls.Add(splitter2);

                pnTaula.BringToFront();
                splitter2.BringToFront();

                #endregion *** Control Panell Taula ***

                #region *** DataGridView dataGridView ***

                var column1 = new DataGridViewTextBoxColumn();
                column1.DataPropertyName = "Id";
                column1.HeaderText = "Id";
                column1.Name = "Id";
                column1.Visible = true;
                column1.ReadOnly = true;

                var column2 = new DataGridViewTextBoxColumn();
                column2.DataPropertyName = "RowVersion";
                column2.HeaderText = "RowVersion";
                column2.Name = "RowVersion";
                column2.Visible = false;

                dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                dataGridView.Columns.AddRange(new DataGridViewColumn[] {column1});
                dataGridView.Columns.AddRange(new DataGridViewColumn[] {column2});
                dataGridView.RowTemplate.Height = 28;
                dataGridView.Dock = DockStyle.Fill;
                pnTaula.Controls.Add(dataGridView);

                #endregion *** DataGridView ***

                #region *** EtiquetaNomTaula pnEtiqueta ***

                var pnEtiqueta = new Panel();
                pnEtiqueta.Dock = DockStyle.Top;
                pnEtiqueta.Size = new Size(200, 28);
                pnTaula.Controls.Add(pnEtiqueta);

                etiquetaNomTaula.Text = nomTaula;
                etiquetaNomTaula.Dock = DockStyle.Fill;
                etiquetaNomTaula.BackColor = Color.DarkGray;
                etiquetaNomTaula.AutoSize = false;
                etiquetaNomTaula.TextAlign = ContentAlignment.MiddleCenter;
                etiquetaNomTaula.Font = new Font(FontFamily.GenericSansSerif, 8F, FontStyle.Bold);
                etiquetaNomTaula.TabStop = true;
                pnEtiqueta.Controls.Add(etiquetaNomTaula);

                #endregion *** EtiquetaNomTaula ***

                vBtTancaPanell = new Button();
                vBtTancaPanell.Dock = DockStyle.Right;
                vBtTancaPanell.Text = "X";
                vBtTancaPanell.Font = new Font("Arial", 8);
                vBtTancaPanell.BackColor = Color.LightGray;
                vBtTancaPanell.ForeColor = Color.Black;
                vBtTancaPanell.FlatStyle = FlatStyle.Flat;
                vBtTancaPanell.Size = new Size(26, 22);
                vBtTancaPanell.TextAlign = ContentAlignment.MiddleCenter;
                etiquetaNomTaula.Controls.Add(vBtTancaPanell);

                pnEtiqueta.SendToBack();
                dataGridView.BringToFront();

                Panells.Add(pnTaula, this);

                pnTaula.Focus();

                vBtTancaPanell.Click += btTancaPanell_Click;
                dataGridView.Enter += dataGridView_Enter;
                dataGridView.DataError += dataGridView_DataError;

                pnTaula.ResumeLayout();
            }

            private void btTancaPanell_Click(object sender, EventArgs e)
            {
                if (btTancaPanellClick != null)
                    btTancaPanellClick(this, e);
            }

            private void dataGridView_Enter(object sender, EventArgs e)
            {
                PanellActiu(this);

                if (dataGridViewEnter != null)
                    dataGridViewEnter(this, e);
            }

            private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
            {
                var grid = (DataGridView) sender;

                if (grid.Columns[e.ColumnIndex].Name == "RowVersion")
                {
                    e.ThrowException = false;
                    e.Cancel = true;
                }
            }

            /// <summary>
            ///     Per desar el panell actiu, Només deso el nom de la taula.
            /// </summary>
            /// <param name="panell"></param>
            internal static void PanellActiu(Panell panell)
            {
                if (_PanellActiu != panell)
                {
                    if (_PanellActiu != null)
                        _PanellActiu.vPanel.BackColor = Color.PowderBlue;

                    if (panell != null)
                        panell.vPanel.BackColor = Color.Blue;

                    _PanellActiu = panell;
                }
            }

            /// <summary>
            ///     Elimina el panell del diccionari de panells creats.
            /// </summary>
            /// <param name="panell"></param>
            internal static void Esborra(Panell panell)
            {
                if (panell._EsActiu)
                    PanellActiu(null);

                Panells.Remove(panell._Panel);
            }

            /// <summary>
            ///     Troba un panell en el diccionari de panells creats.
            /// </summary>
            /// <param name="nomTaula"></param>
            /// <returns></returns>
            internal static Panell TrobaElPanell(string nomTaula)
            {
                return Panells.Values.FirstOrDefault(f => f._NomTaula == nomTaula);
            }

            /// <summary>
            ///     Troba un panell en el diccionari de panells creats.
            /// </summary>
            /// <param name="panel"></param>
            /// <returns></returns>
            internal static Panell TrobaElPanell(Panel panel)
            {
                return Panells.ContainsKey(panel) ? Panells[panel] : null;
            }

            /// <summary>
            ///     Busca a tots els panells creats si n'hi ha algun amb modificacions pendents.
            /// </summary>
            /// <returns></returns>
            internal static bool HiHaModificacionsPendents()
            {
                return Panells.Any(a => a.Value._EstaModificat);
            }
        }
    }
}