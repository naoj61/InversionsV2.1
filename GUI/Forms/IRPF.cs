using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Comuns;
using Controls;
using Microsoft.Win32;

namespace Inversions.GUI.Forms
{
    public sealed partial class IRPF : Form
    {
        private List<StProductes> vProdsAmbVendesAny;
        private List<Moviment> vVendesAny;
        private Dictionary<Inversions.Moviment, List<CompraExt>> vCompresVendesAny;
        private int vAny;

        public IRPF(int any)
        {
            InitializeComponent();

            dgvProductes.AutoGenerateColumns = false;
            dgvVendes.AutoGenerateColumns = false;
            dgvCompresVenda.AutoGenerateColumns = false;
            dgvIngressosForaAplicacio.AutoGenerateColumns = false;

            dgvProductes.AutoSize = true;

            for (int i = 2013; i <= DateTime.Today.Year; i++)
            {
                cbAny.Items.Add(i);
            }

            cbAny.SelectedItem = any;
        }

        private struct StProductes
        {
            public StProductes(int any, Producte prod) : this()
            {
                _Prod = prod;
                _Divident = prod.calculaDividents(any);
            }

            // ReSharper disable MemberCanBePrivate.Local
            // ReSharper disable UnusedAutoPropertyAccessor.Local
            public Producte _Prod { get; private set; }
            public decimal _Divident { get; private set; }
            // ReSharper restore MemberCanBePrivate.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local
        }


        private struct StVendesAny
        {
            public StVendesAny(Moviment venda) : this()
            {
                if (!venda._EsVenda)
                    throw new Exception("No és una venda");

                vVenda = venda;
            }

            private readonly Moviment vVenda;

            // ReSharper disable MemberCanBePrivate.Local
            // ReSharper disable UnusedAutoPropertyAccessor.Local

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
                get { return _Venda.pigVenda(true); }
            }


            // ReSharper restore MemberCanBePrivate.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local
        }


        private struct StCompresVenda
        {
            public StCompresVenda(Moviment venda, CompraExt compra)
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

            public DateTime _Data
            {
                get { return _CompraExt._Data; }
            }

            public decimal _Participacions
            {
                get { return _CompraExt._Participacions; }
            }

            public decimal _PreuUnitari
            {
                get { return _CompraExt._PreuParticipacio; }
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

            // ReSharper restore MemberCanBePrivate.Local
            // ReSharper restore UnusedAutoPropertyAccessor.Local


            #region Overrides

            public override int GetHashCode()
            {
                return (vCompra != null ? vCompra.GetHashCode() : 0);
            }

            public static bool operator ==(StCompresVenda a, StCompresVenda b)
            {
                return a.vCompra == b.vCompra;
            }

            public static bool operator !=(StCompresVenda a, StCompresVenda b)
            {
                return !(a == b);
            }

            public override bool Equals(object obj)
            {
                if (!(obj is StCompresVenda))
                    return false;

                return this == (StCompresVenda) obj;
            }

            #endregion
        }


        private void IRPF_Shown(object sender, EventArgs e)
        {
            ckAgrupaCompres.Checked = true;

            dgvProductes.ClearSelection();

            dgvProductes.SelectionChanged += dgvProductes_SelectionChanged;

            seleccionaFilesDataGrid();
        }

        private void ompleGridCompresDeLaVenda()
        {
            // Crea llista de les vendes seleccionades de "dgvVendes".
            var vendessSelec = (from DataGridViewRow row in dgvVendes.SelectedRows select (Moviment) row.Cells[0].Value).ToList();

            List<StCompresVenda> compresVenda = new List<StCompresVenda>();
            foreach (Moviment venda in vendessSelec)
            {
                compresVenda.AddRange(venda.compresDeLaVenda().Select(compraExt => new StCompresVenda(venda, compraExt)));
            }

            if (ckAgrupaCompres.Checked)
            {
                ColDespesesCompra.Visible = false;
                ColDespesesVenda.Visible = false;

                List<StCompresVenda> compresVendaAgrup = new List<StCompresVenda>();
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
                ColDespesesCompra.Visible = true;
                ColDespesesVenda.Visible = true;

                dgvCompresVenda.DataSource = compresVenda.OrderBy(o => o._Venda.Data).ThenBy(o => o._CompraExt._Data).ToList();
            }
        }

        private void calculaTotalATributar()
        {
            ntbTotalTributar.Valor = ntbPiG.Valor + ntbIngressosForaApp.Valor + ntbDividents.Valor
                                     - ntbPerduesAnysAnteriors.Valor - ntbMinimContribuent.Valor;

            var activaBotons = vImportMinimContribuent != ntbMinimContribuent.Valor || vIngressosForaApp != ntbIngressosForaApp.Valor;

            btCancela.Enabled = activaBotons;
            btDesa.Enabled = activaBotons;
        }

        private const string RegImportMinimContribuent = "ImportMinimContribuent";
        private const string RegIngressosForaApp = "IngressosForaApp";
        private decimal vImportMinimContribuent, vIngressosForaApp;
        private string vClauReg;

        private List<IngresExtern> vDespesesExt;

        private void cbAny_SelectedIndexChanged(object sender, EventArgs e)
        {
            vAny = (int) cbAny.SelectedItem;

            vDespesesExt = Program.Sessio.IngressosExterns.Where(w => w.Any == vAny).ToList();
            dgvIngressosForaAplicacio.DataSource = vDespesesExt;

            vVendesAny = Moviment.MovimentsUsuari.Where(w => w._EsVendaReal && w.Data.Year == vAny).OrderBy(o => o.Prod).ThenBy(t => t.Data).ToList();
            vProdsAmbVendesAny = vVendesAny.Select(s => s.Prod).Distinct().Select(i => new StProductes(vAny, i)).ToList();
            vCompresVendesAny = vVendesAny.ToDictionary(x => x, x => x.compresDeLaVenda().ToList());

            dgvProductes.DataSource = vProdsAmbVendesAny;

            ntbPerduesAnysAnteriors.Valor = -Producte.PerduesDarrersQuatreAnys(vAny);

            seleccionaFilesDataGrid();

            vClauReg = Utilitats.CreaClauRegistre() + "\\" + Usuari.Seleccionat.Nom + "\\" + cbAny.Text;

            var dd1 = Utilitats.LlegeixVariableRegistre(Registry.CurrentUser, vClauReg, RegImportMinimContribuent);
            Decimal.TryParse(dd1, out vImportMinimContribuent);
            ntbMinimContribuent.Valor = vImportMinimContribuent;

            var dd2 = Utilitats.LlegeixVariableRegistre(Registry.CurrentUser, vClauReg, RegIngressosForaApp);
            Decimal.TryParse(dd2, out vIngressosForaApp);
            ntbIngressosForaApp.Valor = vIngressosForaApp;

            calculaTotalATributar();
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

                List<StVendesAny> vendesAny = new List<StVendesAny>();
                foreach (Moviment venda in vVendesAny)
                {
                    if (prodsSelec.Contains(venda.Prod))
                        vendesAny.Add(new StVendesAny(venda));
                }

                dgvVendes.DataSource = vendesAny;

                ntbDividents.Valor = dgvProductes.SelectedRows.Cast<DataGridViewRow>().Sum(row => ((StProductes) row.DataBoundItem)._Divident);
            }
        }

        private void dgvVendes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvVendes.SelectedRows.Count == 0)
                dgvVendes.DataSource = null;
            else
            {
                ompleGridCompresDeLaVenda();

                ntbPiG.Valor = dgvVendes.SelectedRows.Cast<DataGridViewRow>().Sum(row => ((StVendesAny) row.DataBoundItem)._PiG);

                calculaTotalATributar();
            }
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

        private void btCancela_Click(object sender, EventArgs e)
        {
            ntbMinimContribuent.Valor = vImportMinimContribuent;
            ntbIngressosForaApp.Valor = vIngressosForaApp;

            calculaTotalATributar();

            btCancela.Enabled = false;
            btDesa.Enabled = false;
        }

        private void btDesa_Click(object sender, EventArgs e)
        {
            Utilitats.GravaVariableRegistre(Registry.CurrentUser, vClauReg, RegImportMinimContribuent, ntbMinimContribuent.Valor);
            Utilitats.GravaVariableRegistre(Registry.CurrentUser, vClauReg, RegIngressosForaApp, ntbIngressosForaApp.Valor);

            vImportMinimContribuent = ntbMinimContribuent.Valor;
            vIngressosForaApp = ntbIngressosForaApp.Valor;

            btCancela.Enabled = false;
            btDesa.Enabled = false;
        }

        private void ntbMinimContribuent_Validated(object sender, EventArgs e)
        {
            if (vImportMinimContribuent != ntbMinimContribuent.Valor)
                calculaTotalATributar();
        }


        private void ntbIngressosForaApp_Validated(object sender, EventArgs e)
        {
            if (vIngressosForaApp != ntbIngressosForaApp.Valor)
                calculaTotalATributar();
        }


        #region *** Gestiona Ingressos fora de l'aplicació ***

        private void btDesaIngresExtern_Click(object sender, EventArgs e)
        {
            // Desa totes les modificacions.
            throw new NotImplementedException();

            
            btDesaIngresExtern.Enabled = false;
            btCancelaIngresExtern.Enabled = false;

            tbImportIngresExtern.Enabled = false;
            ntbImportIngresExtern.Enabled = true;

            dgvIngressosForaAplicacio.Enabled = true;
        }

        private void btCancelaIngresExtern_Click(object sender, EventArgs e)
        {
            // Elimina totes les modificacions i deixa l'estat inicial.
            //throw new NotImplementedException();


            btDesaIngresExtern.Enabled = false;
            btCancelaIngresExtern.Enabled = false;

            tbImportIngresExtern.Enabled = false;
            ntbImportIngresExtern.Enabled = true;

            dgvIngressosForaAplicacio.Enabled = true;
        }


        #region *** Controla events de "dgvIngressosForaAplicacio" ***

        private void dgvIngressosForaAplicacio_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            // Obté el control d'edició actual
            TextBox textBox = e.Control as TextBox;

            if (textBox != null)
            {
                // Només apliquem la validació a les cel·les de columnes del tipus"NumericTextBoxColumn"
                if (dgvIngressosForaAplicacio.Columns[dgvIngressosForaAplicacio.CurrentCell.ColumnIndex] is NumericTextBoxColumn)
                {
                    // Afegim un esdeveniment de validació de text quan es produeix l'entrada
                    textBox.KeyPress -= numericTextBox_KeyPress;
                    textBox.KeyPress += numericTextBox_KeyPress;
                }
                else
                {
                    textBox.KeyPress -= numericTextBox_KeyPress;
                } 
            }

            // Deshabilito els botons Desar i Cancel·lar temporalment
            btDesaIngresExtern.Enabled = false;
            btCancelaIngresExtern.Enabled = false;
        }

        /// <summary>
        /// Només permetem dígits, coma i tecla de retrocés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Només permetem dígits, coma i tecla de retrocés
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
            {
                e.Handled = true; // S'ignora el caràcter
            }

            if (e.KeyChar == '.')
                e.KeyChar = ','; // Converteix el punt en coma

            // Només permetem una coma decimal
            if (e.KeyChar == ',')
            {
                TextBox textBox = sender as TextBox;
                if (textBox != null && textBox.Text.Contains(","))
                {
                    e.Handled = true; // S'ignora la coma si ja existeix una
                }
            }
        }

        private void dgvIngressosForaAplicacio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Elimina la fila si és nova i es pulsa la tecla "Esc"
            if (e.KeyChar == (char)27 && dgvIngressosForaAplicacio.IsCurrentRowDirty)
            {
                dgvIngressosForaAplicacio.Rows.Remove(dgvIngressosForaAplicacio.CurrentRow);


                if(comprovaSiHiHaModificacions())
                {
                    // Habilito els botons Desar i Cancel·lar
                    btDesaIngresExtern.Enabled = true;
                    btCancelaIngresExtern.Enabled = true;
                }
            }
        }

        private bool comprovaSiHiHaModificacions()
        {
            throw new NotImplementedException();
        }

        private void dgvIngressosForaAplicacio_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;

            if (dataGridView != null && dataGridView.IsCurrentRowDirty)
            {
                var rao = dataGridView.Rows[e.RowIndex].Cells["ColumnaRao"].Value;
                var import = dataGridView.Rows[e.RowIndex].Cells["ColumnaImport"].Value;

                if (rao != null || import != null)
                {
                    if (rao == null)
                    {
                        e.Cancel = true;
                        MessageBox.Show("La Raó és obligatòria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView.Rows[e.RowIndex].Cells[1].Selected = true;
                    }
                    else if (import == null)
                    {
                        e.Cancel = true;
                        MessageBox.Show("L'import és obligatòri.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dataGridView.Rows[e.RowIndex].Cells[2].Selected = true;
                    }
                    else
                    {
                        // Habilito els botons Desar i Cancel·lar
                        btDesaIngresExtern.Enabled = true;
                        btCancelaIngresExtern.Enabled = true;
                    }
                }
            }
        }

        private void dgvIngressosForaAplicacio_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Aquí pots gestionar l'error de dades com vulguis
            MessageBox.Show("Error de dades: " + e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // Si vols controlar l'error i evitar que es propagui, pots fer-ho assignant la propietat Handled a true
            e.ThrowException = false; // Opcional: indiques que ja has gestionat l'error
            e.Cancel = true; // Opcional: indiques que cancel·les l'operació que va provocar l'error
        }
        
        #endregion *** Controla events de "dgvIngressosForaAplicacio" ***

        private void btNovaDespesaExterna_Click(object sender, EventArgs e)
        {
            IngresExtern de = new IngresExtern();
            de.Any = (short) vAny;
            vDespesesExt.Add(de);

            dgvIngressosForaAplicacio.DataSource = null;
            dgvIngressosForaAplicacio.DataSource = vDespesesExt;
        }




        #endregion *** Gestiona Ingressos fora de l'aplicació ***

        private void btEsborraDespesaExterna_Click(object sender, EventArgs e)
        {

        }

        private void dgvIngressosForaAplicacio_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyData & Keys.KeyCode) == Keys.Delete)
            {
                DataGridView dataGridView = sender as DataGridView;

                foreach (DataGridViewRow row in dataGridView.SelectedRows)
                {
                    IngresExtern desp = (IngresExtern)row.DataBoundItem;

                    vDespesesExt.Remove(desp);
                } 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 ff = new Form1();
            ff.Show();
        }
    }
}