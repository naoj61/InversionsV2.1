using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comuns;
using Controls;
using DevExpress.Utils.OAuth.Provider;
using Microsoft.Win32;

namespace Inversions.GUI.Forms
{
    public sealed partial class IRPF : Form
    {
        #region *** Structs per DataGridView ***
        
        private struct StrDgvProductes
        {
            public StrDgvProductes(int any, Producte prod)
                : this()
            {
                _Prod = prod;
                _Divident = prod.dividends(any);
            }

            // ReSharper disable MemberCanBePrivate.Local
            // ReSharper disable UnusedAutoPropertyAccessor.Local
            public Producte _Prod { get; private set; }
            public decimal _Divident { get; private set; }
            // ReSharper restore MemberCanBePrivate.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local
        }

        private struct StrDgvVendes
        {
            public StrDgvVendes(Moviment venda)
                : this()
            {
                if (!venda._EsVenda)
                    throw new Exception("No és una venda");

                vVenda = venda;
            }

            private readonly Moviment vVenda;

            // ReSharper disable MemberCanBePrivate.Local
            // ReSharper disable UnusedAutoPropertyAccessor.Local
            // ReSharper disable UnusedMember.Local

            public Moviment _Venda
            {
                get { return vVenda; }
            }

            public int _Id
            {
                get { return _Venda.Id; }
            }

            public DateTime _Data
            {
                get { return _Venda.Data; }
            }

            public Producte _Prod
            {
                get { return _Venda.Prod; }
            }

            public decimal _Parts
            {
                get { return _Venda.Participacions; }
            }

            public decimal _PreuUnitari
            {
                get { return _Venda.PreuParticipacio; }
            }

            public decimal _Despeses
            {
                get { return _Venda.Despeses.GetValueOrDefault(); }
            }

            public decimal _ImportBrut
            {
                get { return _Venda._ImportBrut; }
            }

            public decimal _ImportNet
            {
                get { return _Venda._ImportNet; }
            }

            public decimal _PiG
            {
                get { return _Venda.pigVenda4(true, true, true); }
            }

            // ReSharper restore UnusedMember.Local
            // ReSharper restore MemberCanBePrivate.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local
        }

        private struct StrDgvCompresVenda
        {
            public StrDgvCompresVenda(Moviment venda, CompraExt compra)
                : this()
            {
                if (!venda._EsVenda)
                    throw new Exception("No és una venda");


                vVenda = venda;
                vCompra = compra;

                vParticipacionsUtilitzades = compra._PartsUtilitzades;
            }

            private readonly Moviment vVenda;
            private readonly CompraExt vCompra;
            private decimal vParticipacionsUtilitzades;

            private decimal _DespesesCompraUtil
            {
                get { return vCompra._DespesesPartsUtilitzades / vCompra._Participacions * vParticipacionsUtilitzades; }
            }

            private decimal _DespesesVendaUtil
            {
                get { return vVenda.Despeses.GetValueOrDefault() / vVenda.Participacions * vParticipacionsUtilitzades; }
            }


            public void afegeigParticipacionsUtilitzades(decimal participacionsUtilitzades)
            {
                vParticipacionsUtilitzades += participacionsUtilitzades;
            }

            // ReSharper disable MemberCanBePrivate.Local
            // ReSharper disable UnusedAutoPropertyAccessor.Local
            // ReSharper disable UnusedMember.Local

            public decimal _ParticipacionsUtilitzades
            {
                get { return vParticipacionsUtilitzades; }
            }

            public decimal _DespesesUtil
            {
                get { return _DespesesCompraUtil + _DespesesVendaUtil; }
            }

            public decimal _DespesesCompra
            {
                get { return vCompra._Despeses; }
            }

            public decimal _DespesesVenda
            {
                get { return vVenda.Despeses.GetValueOrDefault(); }
            }

            public Moviment _Venda
            {
                get { return vVenda; }
            }

            public CompraExt _CompraExt
            {
                get { return vCompra; }
            }

            public int _IdVenda
            {
                get { return _Venda.Id; }
            }

            public int _Id
            {
                get { return _CompraExt._Id; }
            }

            public DateTime _DataCompra
            {
                get { return _CompraExt._Data; }
            }

            public DateTime _DataVenda
            {
                get { return vVenda.Data; }
            }

            public decimal _Participacions
            {
                get { return _CompraExt._Participacions; }
            }

            public decimal _PreuUnitariCompra
            {
                get { return _CompraExt._PreuParticipacio; }
            }

            public decimal _PreuUnitariVenda
            {
                get { return vVenda.PreuParticipacio; }
            }

            public decimal _ImportCompraBrutUtil
            {
                get { return _ParticipacionsUtilitzades * vCompra._PreuParticipacio; }
            }

            public decimal _ImportVendaBrutUtil
            {
                get { return _ParticipacionsUtilitzades * vVenda.PreuParticipacio; }
            }

            public decimal _ImportCompraNetUtil
            {
                get { return _ImportCompraBrutUtil + _DespesesCompraUtil; }
            }

            public decimal _ImportVendaNetUtil
            {
                get { return _ImportVendaBrutUtil - _DespesesVendaUtil; }
            }

            public decimal _PiG
            {
                get { return _ImportVendaNetUtil - _ImportCompraNetUtil; }
            }

            // ReSharper restore UnusedMember.Local
            // ReSharper restore MemberCanBePrivate.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local


            #region Overrides

            public override int GetHashCode()
            {
                return (vCompra != null ? vCompra.GetHashCode() : 0);
            }

            public static bool operator ==(StrDgvCompresVenda a, StrDgvCompresVenda b)
            {
                return a.vCompra == b.vCompra;
            }

            public static bool operator !=(StrDgvCompresVenda a, StrDgvCompresVenda b)
            {
                return !(a == b);
            }

            public override bool Equals(object obj)
            {
                if (!(obj is StrDgvCompresVenda))
                    return false;

                return this == (StrDgvCompresVenda)obj;
            }

            #endregion
        }

        #endregion
        
        private List<StrDgvProductes> vProdsAmbVendesDividentsAny;
        private List<Moviment> vVendesAny;
        private Dictionary<Inversions.Moviment, List<CompraExt>> vCompresVendesAny;
        private int vAny;

        public IRPF(int any)
        {
            InitializeComponent();
            
            dgvIngressosForaAplicacio.RowsRemoved -= dgvIngressosForaAplicacio_RowsRemoved;

            dgvProductes.AutoGenerateColumns = false;
            dgvVendes.AutoGenerateColumns = false;
            dgvCompresVenda.AutoGenerateColumns = false;
            dgvIngressosForaAplicacio.AutoGenerateColumns = false;

            dgvProductes.AutoSize = true;

            cbAny.SelectedIndexChanged -= cbAny_SelectedIndexChanged;
            for (int i = 2013; i <= DateTime.Today.Year; i++)
            {
                cbAny.Items.Add(i);
            }
            cbAny.SelectedIndexChanged += cbAny_SelectedIndexChanged;

            cbAny.SelectedItem = any;
        }

        public bool _ShaModificat
        {
            get { return vShaModificat; }
        }

        private void IRPF_Shown(object sender, EventArgs e)
        {

        }

        private void IRPF_Load(object sender, EventArgs e)
        {
            //ckAgrupaCompres.Checked = true;

            dgvProductes.ClearSelection();

            dgvProductes.SelectionChanged += dgvProductes_SelectionChanged;
            dgvIngressosForaAplicacio.RowsRemoved += dgvIngressosForaAplicacio_RowsRemoved;

            seleccionaFilesDataGrid();
        }

        private void ompleGridCompresDeLaVenda()
        {
            // Crea llista de les vendes seleccionades de "dgvVendes".
            var vendessSelec = (from DataGridViewRow row in dgvVendes.SelectedRows select (Moviment) row.Cells[0].Value).ToList();

            List<StrDgvCompresVenda> compresVenda = new List<StrDgvCompresVenda>();
            foreach (Moviment venda in vendessSelec)
            {
                compresVenda.AddRange(venda.compresDeLaVenda().Select(compraExt => new StrDgvCompresVenda(venda, compraExt)));
            }

            //dgvCompresVenda.CellFormatting += NumericCell.CellFormatting;

            if (ckAgrupaCompres.Checked)
            {
                //ColDespesesCompra.Visible = false;
                //ColDespesesVenda.Visible = false;

                List<StrDgvCompresVenda> compresVendaAgrup = new List<StrDgvCompresVenda>();
                foreach (var compraVenda in compresVenda)
                {
                    if (compresVendaAgrup.Contains(compraVenda))
                    {
                        // Aixó és perquè "compraVenda" son strucs i la llista retorna una còpia no una referència.
                        var idx = compresVendaAgrup.IndexOf(compraVenda);
                        compraVenda.afegeigParticipacionsUtilitzades(compresVendaAgrup[idx]._ParticipacionsUtilitzades);
                        compresVendaAgrup[idx] = compraVenda;
                    }
                    else
                        compresVendaAgrup.Add(compraVenda);
                }
                dgvCompresVenda.DataSource = compresVendaAgrup.OrderBy(o => o._Venda.Data).ThenBy(o => o._CompraExt._Data).ToList();
            }
            else
            {
                //ColDespesesCompra.Visible = true;
                //ColDespesesVenda.Visible = true;

                dgvCompresVenda.DataSource = compresVenda.OrderBy(o => o._Venda.Data).ThenBy(o => o._CompraExt._Data).ToList();
            }

            //dgvCompresVenda.CellFormatting -= NumericCell.CellFormatting;
        }


        private void calculaTotalATributar()
        {
            ntbTotalTributar.Valor = ntbPiG.Valor + ntbIngressosForaApp.Valor + ntbDividents.Valor
                                     - ntbPerduesAnysAnteriors.Valor - ntbMinimContribuent.Valor;
        }

        private const string RegImportMinimContribuent = "ImportMinimContribuent";
        private decimal vImportMinimContribuent;
        private string vClauReg;


        private void cbAny_SelectedIndexChanged(object sender, EventArgs e)
        {
            vAny = (int) cbAny.SelectedItem;

            carregaTaulaIngressosExterns(vAny);

            vVendesAny = Moviment.MovimentsUsuari.Where(w => w._EsVendaReal && w.Data.Year == vAny).ToList();
            vProdsAmbVendesDividentsAny = vVendesAny.Select(s => s.Prod).Distinct().Select(i => new StrDgvProductes(vAny, i)).ToList();
            
            // Afegeixo dividents.
            List<StrDgvProductes>prodsAmbDividentsAny= new List<StrDgvProductes>();
            foreach (var mov in Moviment.MovimentsUsuari.Where(w=>w._EsDividents && w.Data.Year == vAny))
            {
                var xx = new StrDgvProductes(vAny, mov.Prod);
                if (!prodsAmbDividentsAny.Contains(xx))
                    prodsAmbDividentsAny.Add(xx);
            }
            vProdsAmbVendesDividentsAny.AddRange(prodsAmbDividentsAny);

            vCompresVendesAny = vVendesAny.ToDictionary(x => x, x => x.compresDeLaVenda().ToList());

            dgvProductes.DataSource = vProdsAmbVendesDividentsAny;

            ntbPerduesAnysAnteriors.Valor = -Producte.PerduesDarrersQuatreAnys(vAny);

            seleccionaFilesDataGrid();

            vClauReg = Utilitats.CreaClauRegistre() + "\\" + Usuari.Seleccionat.Nom + "\\" + cbAny.Text;

            var dd1 = Utilitats.LlegeixVariableRegistre(Registry.CurrentUser, vClauReg, RegImportMinimContribuent);
            Decimal.TryParse(dd1, out vImportMinimContribuent);
            ntbMinimContribuent.Valor = vImportMinimContribuent;

            ntbIngressosForaApp.Valor = sumaImportsIngressosExterns();

            calculaTotalATributar();
        }

        private static readonly string StringConexxio = Program.Sessio.Database.Connection.ConnectionString;

        private void carregaTaulaIngressosExterns(int any)
        {
            using (SqlConnection connection = new SqlConnection(StringConexxio))
            {
                // Consulta SQL para seleccionar todos los registros de la tabla
                string query = String.Format("SELECT * FROM IngressosExterns Where [UsuariId] = {0} AND [Any] = {1} Order By Rao"
                    , Usuari.Seleccionat.Id, any);

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();

                adapter.Fill(table);

                // Asignar la tabla como origen de datos del DataGridView
                dgvIngressosForaAplicacio.DataSource = table;
            }
        }

        private decimal sumaImportsIngressosExterns()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dgvIngressosForaAplicacio.Rows)
            {
                if (row.Cells["columnaImport"].Value != null)
                    total += (decimal) row.Cells["columnaImport"].Value;
            }

            return total;
        }

        private void desaTaulaIngressosExterns()
        {
            // Guardar cambios en la base de datos al hacer clic en el botón "Guardar"
            using (SqlConnection connection = new SqlConnection(StringConexxio))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();

                // Crear comandos SQL para actualizar los cambios en la base de datos
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.SelectCommand = new SqlCommand("SELECT * FROM IngressosExterns", connection);
                connection.Open();

                // Actualizar los cambios en la base de datos
                var files = (DataTable) dgvIngressosForaAplicacio.DataSource;

                foreach (DataRow fila in files.Rows)
                {
                    if (fila.RowState == DataRowState.Added)
                    {
                        fila["UsuariId"] = Usuari.Seleccionat.Id;
                        fila["Any"] = vAny;
                    }
                }

                adapter.Update(files);

                connection.Close();

                IngresExtern.RefrescaTaula();
            }

            if(MessageBox.Show("Canvis desats correctament. Tanco la finestra?", "Avís"
                , MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
            {
                btDesa.Enabled = false;
                this.Close();
            }
        }

        private void seleccionaFilesDataGrid()
        {
            dgvProductes.SelectAll();

            dgvVendes.SelectAll();

            dgvCompresVenda.ClearSelection();
        }

        private void dgvProductes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductes.SelectedRows.Count == 0)
            {
                dgvVendes.DataSource = null;
                ntbDividents.Valor = 0;
            }
            else
            {
                // Crea llista dels productes seleccionats de "dgvProductes".
                var prodsSelec = (from DataGridViewRow row in dgvProductes.SelectedRows select (Producte) row.Cells[1].Value).ToList();

                List<StrDgvVendes> vendesAny = new List<StrDgvVendes>();
                foreach (Moviment venda in vVendesAny)
                {
                    if (prodsSelec.Contains(venda.Prod))
                        vendesAny.Add(new StrDgvVendes(venda));
                }

                //dgvVendes.CellFormatting += NumericCell.CellFormatting; 

                dgvVendes.DataSource = vendesAny.OrderBy(o=>o._Prod).ThenBy(o=>o._Data).ToList();

                //dgvVendes.CellFormatting -= NumericCell.CellFormatting; 

                ntbDividents.Valor = dgvProductes.SelectedRows.Cast<DataGridViewRow>().Sum(row => ((StrDgvProductes) row.DataBoundItem)._Divident);
            }
        }

        private void dgvVendes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVendes.SelectedRows.Count == 0)
            {
                dgvVendes.DataSource = null;
                dgvCompresVenda.DataSource = null;
                ntbPiG.Valor = 0;
            }
            else
            {
                ompleGridCompresDeLaVenda();

                ntbPiG.Valor = dgvVendes.SelectedRows.Cast<DataGridViewRow>().Sum(row => ((StrDgvVendes) row.DataBoundItem)._PiG);
            }
            calculaTotalATributar();
        }

        private void ckAgrupaCompres_CheckedChanged(object sender, EventArgs e)
        {
            ompleGridCompresDeLaVenda();
        }

        private void ntbMinimContribuent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                calculaTotalATributar();

                if (String.IsNullOrEmpty(ntbMinimContribuent.Text))
                    ntbMinimContribuent.Text = "0";
            }
        }

        private void ntbMinimContribuent_TextChanged(object sender, EventArgs e)
        {
            modeEdicio();
            calculaTotalATributar();
        }


        private void modeEdicio(bool? modeEdicioOn = null)
        {
            if (!modeEdicioOn.HasValue)
            {
                var filesModif = ((DataTable) dgvIngressosForaAplicacio.DataSource).GetChanges();

                modeEdicioOn = vImportMinimContribuent != ntbMinimContribuent.Valor || filesModif != null;
            }

            if (modeEdicioOn.Value)
            {
                btCancela.Enabled = true;
                btDesa.Enabled = true;
                cbAny.Enabled = false;
            }
            else
            {
                btCancela.Enabled = false;
                btDesa.Enabled = false;
                cbAny.Enabled = true;
            }
        }

        private void btCancela_Click(object sender, EventArgs e)
        {
            carregaTaulaIngressosExterns(vAny);

            ntbIngressosForaApp.Valor = sumaImportsIngressosExterns();
            ntbMinimContribuent.Valor = vImportMinimContribuent;

            calculaTotalATributar();

            modeEdicio(false);
        }

        private bool vShaModificat = false;
        private void btDesa_Click(object sender, EventArgs e)
        {
            Utilitats.GravaVariableRegistre(Registry.CurrentUser, vClauReg, RegImportMinimContribuent, ntbMinimContribuent.Valor);

            desaTaulaIngressosExterns();

            vImportMinimContribuent = ntbMinimContribuent.Valor;

            modeEdicio(false);

            vShaModificat = true;
        }


        private void IRPF_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btDesa.Enabled)
            {
                MessageBox.Show("Pendend de desar canvis", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                e.Cancel = true;
            }
        }


        #region *** Gestiona Ingressos fora de l'aplicació ***

        private void dgvIngressosForaAplicacio_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            if (dataGridView != null && dataGridView.IsCurrentRowDirty)
            {
                var rao = dataGridView.Rows[e.RowIndex].Cells["ColumnaRao"].Value;
                var import = dataGridView.Rows[e.RowIndex].Cells["ColumnaImport"].Value;

                if (rao != null || rao != DBNull.Value || import != null || import != DBNull.Value)
                {
                    if (rao == null || rao == DBNull.Value)
                    {
                        e.Cancel = true;
                        MessageBox.Show("La Raó és obligatòria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["ColumnaRao"];
                    }
                    else if (import == null || import == DBNull.Value)
                    {
                        e.Cancel = true;
                        MessageBox.Show("L'import és obligatòri.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView.CurrentCell = dataGridView.Rows[e.RowIndex].Cells["ColumnaImport"];
                    }
                    else
                    {
                        // Habilito els botons Desar i Cancel·lar
                        modeEdicio(true);

                        ntbIngressosForaApp.Valor = sumaImportsIngressosExterns();

                        calculaTotalATributar();
                    }
                }
            }
        }

        private void dgvIngressosForaAplicacio_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // Habilito els botons Desar i Cancel·lar
            modeEdicio();

            ntbIngressosForaApp.Valor = sumaImportsIngressosExterns();

            calculaTotalATributar();
        }

        private void dgvIngressosForaAplicacio_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Aquí pots gestionar l'error de dades com vulguis
            MessageBox.Show("Error de dades: " + e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Si vols controlar l'error i evitar que es propagui, pots fer-ho assignant la propietat Handled a true
            e.ThrowException = false; // Opcional: indiques que ja has gestionat l'error
            e.Cancel = true; // Opcional: indiques que cancel·les l'operació que va provocar l'error
        }

        #endregion *** Gestiona Ingressos fora de l'aplicació ***
    }
}