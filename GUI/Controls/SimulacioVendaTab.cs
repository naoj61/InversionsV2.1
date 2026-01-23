using Comuns;
using Controls;
using Inversions.ClassesEntity;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Inversions.GUI
{

    /*
    * *** Van amb l'any --> Si canvia l'any inicialitzar la resta ***
    * ntbTramExentAnual -Exent anual (Modificable)
    * ntbPerduesAnysAnteriors -Perdues anteriors
    * ntbPiGActual -PiG Any
    * ntbIngressosExterns -Ingressos externs
    * ntbDividents -Dividents
    * 
    * 
    * ****** Només s'utilitzen si any actual ******
    * 
    * *** Van amb el producte ***
    * ntbNumParticipacions -Num Parts (Modificable)(Només visible any actual)
    * ntbPreuParticipacio -Preu Parts (Modificable)(Només visible any actual)
    * dgvCompresOriginals -DataGridViaw
    * 
    * *** A 0 si canvia el producte o l'any ***
    * ntbPartsSaltades -Parts Saltades (Modificable)(Només visible any actual)
    * ntbPiGAltresProductes -PiG d'altre (Modificable)(Només visible any actual)
    * 
    * *** Calculats ***
    * ntbImportBrut -Import Brut (Només visible any actual)
    * ntbPigSimulacio -PiG Prod (Només visible any actual)
    * ntbPigOrigSimulacio -PiG Orig (Només visible any actual)
    * ntbRestaTramNoTributa -Exent Restant (Només visible any actual)
    * ntbTributaRenda -Tributa Renda
    * 
    */

    public partial class SimulacioVendaTab : TabX
    {
        private const string RegImportMinimContribuent = "ImportMinimContribuent";
        private string vClauReg;
        private bool vPendentRefrescar;
        private Producte vProducteSeleccionat;

        public SimulacioVendaTab()
        {
            InitializeComponent();

            dgvCompresOriginals.AutoGenerateColumns = false;

            SimulacioVendaTabDgv.Inicialitza(dgvCompresOriginals);
       
            ctrProductes.refrescaDadesControl(null);
        }

        #region *** Overrides ***

        private bool vNoValidaControlsNtb;


        Producte vProducteUsuariAnterior;
        int vAnyRendaUsuariAnterior;
        decimal vPreuPartUsuariAnterior;
        decimal vNumPartsUsuariAnterior;
        decimal vPartsSaltadesUsuariAnterior;
        decimal vPigAltresProductesUsuariAnterior;

        internal override void canviUsuari()
        {
            base.canviUsuari();

            Usuari usuari = Usuari.Seleccionat;

            /* 
             * ** Dades a desar abans de canviar d'usuari:
             * Producte
             * Any Renda
             * Num Parts
             * Preu Part
             * Parts Saltades
             * PiG Altres Productes
            */

            // Recuperar dades de l'usuari actual
            var anyRenda = vAnyRendaUsuariAnterior;
            var prod = vProducteUsuariAnterior;
            var preuPart = vPreuPartUsuariAnterior;
            var numParts = vNumPartsUsuariAnterior;
            var partsSaltades = vPartsSaltadesUsuariAnterior;
            var pigAltresProductes = vPigAltresProductesUsuariAnterior;

            // Desar dades de l'usuari anterior
            vAnyRendaUsuariAnterior = vAnyRenda;
            vProducteUsuariAnterior = vProducteSeleccionat;
            vPreuPartUsuariAnterior = ntbPreuParticipacio.Valor;
            vNumPartsUsuariAnterior = ntbNumParticipacions.Valor;
            vPartsSaltadesUsuariAnterior = ntbPartsSaltades.Valor;
            vPigAltresProductesUsuariAnterior = ntbPigAltresProductes.Valor;

            // Carregar dades de l'usuari actual
            cbAny.SelectedItem = anyRenda == 0 ? DateTime.Today.Year : anyRenda; ;
            vProducteSeleccionat = prod;
            ctrProductes.seleccionaProducte(vProducteSeleccionat);
            ntbPreuParticipacio.Valor = preuPart;
            ntbNumParticipacions.Valor = numParts;
            ntbPartsSaltades.Valor = partsSaltades;
            ntbPigAltresProductes.Valor = pigAltresProductes;

            SimulacioVendaTabDgv.CarregaProducte(vProducteSeleccionat, false);
            SimulacioVendaTabDgv.OmpleDataGrid(ntbNumParticipacions.Valor, ntbPartsSaltades.Valor, ntbPreuParticipacio.Valor);

            actualitzaControlsCanviDany();
            ompleValorsTotals();
        }


        internal override void refresca()
        {
            base.refresca();


            vPendentRefrescar = true;

            // Guardar valors actuals
            var anyRenda = vAnyRenda;
            var prod = vProducteSeleccionat;
            var preuPart = ntbPreuParticipacio.Valor;
            var numParts = ntbNumParticipacions.Valor;
            var partsSaltades = ntbPartsSaltades.Valor;
            var pigAltresProductes = ntbPigAltresProductes.Valor;

            ctrProductes.refrescaDadesControl(vProducteSeleccionat);

            // Recuperar valors actuals
            vAnyRenda = anyRenda;
            vProducteSeleccionat = prod;
            ntbPreuParticipacio.Valor = preuPart;
            ntbNumParticipacions.Valor = numParts;
            ntbPartsSaltades.Valor = partsSaltades;
            ntbPigAltresProductes.Valor = pigAltresProductes;

            SimulacioVendaTabDgv.OmpleDataGrid(ntbNumParticipacions.Valor, ntbPartsSaltades.Valor, ntbPreuParticipacio.Valor);
        }

        internal override void obrePestanya(Producte prod)
        {
            ctrProductes.refrescaDadesControl(prod);
        }

        internal override void escape(object sender, KeyEventArgs e)
        {
            if (!(((SimulacioVendaTab)((Form)sender).ActiveControl).ActiveControl is NumericTextBox2))
                // Si el control actiu és del tipus NumericTextBox2, no es crida a "base.escape" per evitar que s'executi "refresca()".
                base.escape(sender, e);
        }

        #endregion *** Overrides ***

        private bool _EsAnyActual
        {
            get { return Convert.ToInt32(cbAny.SelectedItem) == DateTime.Today.Year; }
        }

        private decimal valorTramExent(int any)
        {
            decimal tramExentAnual;
            vClauReg = Utilitats.CreaClauRegistre() + "\\" + Usuari.Seleccionat.Nom + "\\" + any;
            string dd1 = Utilitats.LlegeixVariableRegistre(Registry.CurrentUser, vClauReg, RegImportMinimContribuent);
            Decimal.TryParse(dd1, out tramExentAnual);

            return tramExentAnual;
        }


        private decimal valorIngressosExterns(int any)
        {
            return Program.Sessio.IngressosExterns.Where(w => w.Usuari.Id == Usuari.Seleccionat.Id && w.Any == any).ToList().Sum(s => s.Import);
        }

        private void carregaNouProducte(Producte prod, decimal? preuPart = null)
        {
            if (vPendentRefrescar)
                vPendentRefrescar = false;
            else
                return;

            SimulacioVendaTabDgv.CarregaProducte(prod);

            return;
        }


        /// <summary>
        ///     Calcula el valor a tributar. Si negatiu és que no s'ha arribat al límit que no tributa.
        /// </summary>
        /// <returns></returns>
        private void calculaTotalATributar()
        {
            decimal tramNoTributa = (ntbTramExentAnual.Valor + ntbPerduesAnysAnteriors.Valor)
                                    - (ntbPiGActual.Valor + ntbIngressosExterns.Valor + ntbDividents.Valor);

            decimal tributaRenda = ntbPigOrigSimulacio.Valor + ntbPigAltresProductes.Valor - tramNoTributa;

            if (tributaRenda > 0)
            {
                ntbRestaTramNoTributa.Valor = 0;
                ntbTributaRenda.Valor = tributaRenda;
            }
            else
            {
                ntbRestaTramNoTributa.Valor = Math.Abs(tributaRenda); // Poso el valor positiu.
                ntbTributaRenda.Valor = 0;
            }
        }


        /// <summary>
        ///     Son els controls que varien al canviar d'any o al refrescar.
        /// </summary>
        private void actualitzaControlsCanviDany()
        {
            ntbTramExentAnual.Valor = valorTramExent(vAnyRenda);
            ntbPerduesAnysAnteriors.Valor = Math.Abs(Producte.PerduesDarrersQuatreAnys(vAnyRenda));
            ntbPiGActual.Valor = Moviment.MovimentsUsuari.Where(w => w._EsVendaReal && w.Data.Year == vAnyRenda).ToList().Sum(s => s.pigVenda4(true, true, true));
            ntbIngressosExterns.Valor = valorIngressosExterns(vAnyRenda);
            ntbDividents.Valor = Moviment.MovimentsUsuari.Where(w => w.Data.Year == vAnyRenda && w.TipusMoviment == TipusMoviment.Dividends)
                .ToList().Sum(s => s.PreuParticipacio);
        }


        /// <summary>
        ///     Son els controls que varien al canviar de producte.
        /// </summary>
        /// <param name="prod"></param>
        private void actualitzaControlsProducte(Producte prod)
        {
            vProducteSeleccionat = prod;

            var ctrlActivat = prod != null && prod._Participacions > 0;

            ntbNumParticipacions.Enabled = ctrlActivat;
            ntbPreuParticipacio.Enabled = ctrlActivat;
            ntbPartsSaltades.Enabled = ctrlActivat;
            btMaxPartsNoTributa.Enabled = ctrlActivat;
            btMaxParts.Enabled = ctrlActivat;

            //ntbNumParticipacions.Valor = prod == null ? 0 : prod._Participacions;
            ntbNumParticipacions.Valor = 0;
            ntbPreuParticipacio.Valor = prod == null ? 0 : prod.ValoracionsProducte.Last().PreuParticipacio;

            ntbPartsSaltades.Valor = 0;
            ntbTributaRenda.Valor = 0;

            carregaNouProducte(prod);
        }

        #region *** Events ***

        private int vAnyRenda;

        private void simulacióVendaTab_Load(object sender, EventArgs e)
        {
            cbAny.SelectedIndexChanged -= cbAny_SelectedIndexChanged;
            for (int i = 2001; i <= DateTime.Today.Year; i++)
            {
                cbAny.Items.Add(i);
            }

            cbAny.SelectedIndexChanged += cbAny_SelectedIndexChanged;
            cbAny.SelectedItem = Convert.ToInt32(DateTime.Today.Year);
        }

        private void btRecalcula_Click(object sender, EventArgs e)
        {
            var cancel = new CancelEventArgs();
            ntb_Validating(sender, cancel);
            if (cancel.Cancel)
                return;
        }

        private void ctrProductes_EventProducteSeleccionat(object sender, EventArgs e)
        {
            var prod = (Producte)sender;

            vPendentRefrescar = prod != vProducteSeleccionat;

            if (vPendentRefrescar)
                actualitzaControlsProducte(prod);

            if (sender != null)
                ntbNumParticipacions.Focus();
        }

        private void cbAny_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAny.SelectedItem != null && vAnyRenda != Convert.ToInt32(cbAny.SelectedItem))
            {
                vAnyRenda = Convert.ToInt32(cbAny.SelectedItem);

                gbPigRealAny.Text = "PiG Any: " + cbAny.Text;

                btRecalcula.Enabled = false;
                ctrProductes.Enabled = _EsAnyActual;

                ntbTramExentAnual.ReadOnly = !_EsAnyActual;
                ntbPigAltresProductes.Enabled = _EsAnyActual;

                // *** Inicialitza valors
                ctrProductes.seleccionaProducte(null);

                // *** Si no és l'any actual fa invisibles els groupBox que contenen els ntb ***
                btRecalcula.Visible = _EsAnyActual;
                ntbNumParticipacions.Parent.Visible = _EsAnyActual;
                ntbPreuParticipacio.Parent.Visible = _EsAnyActual;
                ntbPartsSaltades.Parent.Visible = _EsAnyActual;
                ntbPigAltresProductes.Parent.Visible = _EsAnyActual;
                ntbImportBrut.Parent.Visible = _EsAnyActual;
                ntbPigSimulacio.Parent.Visible = _EsAnyActual;
                ntbPigOrigSimulacio.Parent.Visible = _EsAnyActual;
                ntbRestaTramNoTributa.Parent.Visible = _EsAnyActual;

                actualitzaControlsCanviDany();
                ompleValorsTotals();
            }
        }

        private void ntb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                var cancel = new CancelEventArgs();
                ntb_Validating(sender, cancel);
                if (cancel.Cancel)
                {
                    e.Handled = true;
                    return;
                }
                ((NumericTextBox2)sender).SelectAll();
            }
        }

        private void ntb_Validating(object sender, CancelEventArgs e)
        {
            Form form = FindForm();
            if (form is Principal && ((Principal)form).SestaTancantForm)
            {
                // S'està tancant el formulari → no validar
                e.Cancel = false;
                return;
            }

            if (!vPendentRefrescar)
            {
                return;
            }

            if (vNoValidaControlsNtb)
            {
                // Quan no vull que es facin les validacions. P.ex. si vProducteSeleccionat == null.
                vNoValidaControlsNtb = false;
                return;
            }

            var ntb = (NumericTextBox2)sender;

            if (ntb == ntbNumParticipacions || ntb == ntbPartsSaltades)
            {
                if (ntb.Valor > vProducteSeleccionat._Participacions)
                {
                    MessageBox.Show("El valor és superior a les participacions disponibles. Max: " + vProducteSeleccionat._Participacions.ToString("0.000"),
                        "Avís", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }

                if ((ntbNumParticipacions.Valor + ntbPartsSaltades.Valor) > vProducteSeleccionat._Participacions)
                {
                    string missatge = "La suma de 'Num, Partic.' + 'Parts Saltades' supera les participacions disponibles. " +
                                      String.Format("Vols disminuir les participacions a: {0}?"
                                          , ntb == ntbNumParticipacions ? "Parts saldates" : "Num Parts");

                    if (MessageBox.Show(missatge, "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        if (ntb == ntbNumParticipacions)
                            ntbPartsSaltades.Valor = vProducteSeleccionat._Participacions - ntbNumParticipacions.Valor;
                        else
                            ntbNumParticipacions.Valor = vProducteSeleccionat._Participacions - ntbPartsSaltades.Valor;
                    }
                    else
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            if (ntb == ntbTramExentAnual && ntbTramExentAnual.Valor != valorTramExent(vAnyRenda))
            {
                if (MessageBox.Show("S'ha modificat el valor del 'Tram Exent Anual'. Vols desar el nou valor al registre de Windows?"
                    , "Avís", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Utilitats.GravaVariableRegistre(Registry.CurrentUser, vClauReg, RegImportMinimContribuent, ntbTramExentAnual._DecimalValue);
                }
                else
                {
                    ntbTramExentAnual.Valor = valorTramExent(vAnyRenda);
                    e.Cancel = true;
                    return;
                }
            }

            SimulacioVendaTabDgv.OmpleDataGrid(ntbNumParticipacions.Valor, ntbPartsSaltades.Valor, ntbPreuParticipacio.Valor);
            ompleValorsTotals();
        }

        private void ntb_TextChanged(object sender, EventArgs e)
        {
            vPendentRefrescar = true;
        }

        public void dgvCompresOriginals_SelectionChanged(object sender, EventArgs e)
        {
            ntbNumPartsSelect.Valor = dgvCompresOriginals
                .SelectedRows
                .Cast<DataGridViewRow>()
                .Sum(selectedRow => (decimal)selectedRow.Cells["PartsUtil"].Value);
        }


        private void dgvCompresOriginals_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // 1. Comprovar que estem a la columna que ens interessa
            if (dgvCompresOriginals.Columns[e.ColumnIndex].Name == "PartsUtil")
            {
                var item = (SimulacioVendaTabDgv)dgvCompresOriginals.Rows[e.RowIndex].DataBoundItem;

                // Primer comprovar _PartsDisp abans de _ParticipacionsUtilitzades
                if (item._PartsDisp == 0)
                {
                    e.CellStyle.BackColor = lbTotPle.BackColor;
                    e.CellStyle.ForeColor = lbTotPle.ForeColor;
                }
                else if (item._ParticipacionsUtilitzades == 0)
                {
                    e.CellStyle.BackColor = lbTotLliure.BackColor;
                    e.CellStyle.ForeColor = lbTotLliure.ForeColor;
                }
                else
                {
                    e.CellStyle.BackColor = lbParcialLliure.BackColor;
                    e.CellStyle.ForeColor = lbParcialLliure.ForeColor;
                }
            }
        }

        #endregion *** Events ***

        private void ompleValorsTotals()
        {
            ntbImportBrut.Valor = ntbNumParticipacions.Valor * ntbPreuParticipacio.Valor;
            ntbPigSimulacio.Valor = SimulacioVendaTabDgv._LlistaCompresOriginals.Sum(s => s._PigDeLaCompraPartsUtil);
            ntbPigOrigSimulacio.Valor = SimulacioVendaTabDgv._LlistaCompresOriginals.Sum(s => s._PigDeLaCompraPartsUtilOrig);

            calculaTotalATributar();
        }

        private void btMaxPartsNoTributa_Click(object sender, EventArgs e)
        {
            vPendentRefrescar = true;

            ntbNumParticipacions.Valor = SimulacioVendaTabDgv.CalculaPartPerLimitExent(ntbRestaTramNoTributa.Valor, ntbPartsSaltades.Valor);

            ompleValorsTotals();
        }

        private void btMaxParts_Click(object sender, EventArgs e)
        {
            vPendentRefrescar = true;

            ntbNumParticipacions.Valor = Math.Round(vProducteSeleccionat._Participacions, 3);

            SimulacioVendaTabDgv.OmpleDataGrid(ntbNumParticipacions.Valor, ntbPartsSaltades.Valor, ntbPreuParticipacio.Valor);

            ompleValorsTotals();
        }
    }
}