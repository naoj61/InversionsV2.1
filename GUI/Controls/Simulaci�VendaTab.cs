using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Comuns;
using Controls;
using DevExpress.XtraEditors.ButtonPanel;
using Inversions.GUI.Forms;
using Microsoft.Win32;

namespace Inversions.GUI
{
    internal struct StrDgvCompresOriginals
    {
        private readonly DesglosCompraExt vDesglosCompra;
        private static decimal PreuParticipacioSimulacio;

        public StrDgvCompresOriginals(DesglosCompraExt desglosCompra, decimal preuPart)
            : this()
        {
            vDesglosCompra = desglosCompra;
            PreuParticipacioSimulacio = preuPart;
        }


        #region *** Propietats per mostrar en dataGridView ***

        [Description("S'utilitza en un DataGrid")]
        public int _Id
        {
            get { return vDesglosCompra._Compra.Id; }
        }

        [Description("S'utilitza en un DataGrid")]
        public int _IdOrig
        {
            get { return vDesglosCompra._CompraOrig.Id; }
        }

        [Description("S'utilitza en un DataGrid")]
        public string _FonsOrig
        {
            get { return vDesglosCompra._CompraOrig.Prod._NomProducte; }
        }

        [Description("S'utilitza en un DataGrid")]
        public DateTime _DataOrig
        {
            get { return vDesglosCompra._CompraOrig.Data; }
        }

        [Description("S'utilitza en un DataGrid")]
        public DateTime _DataCompra
        {
            get { return vDesglosCompra._Compra.Data; }
        }

        [Description("S'utilitza en un DataGrid")]
        public decimal _Participacions
        {
            get { return vDesglosCompra._Participacions; }
        }

        [Description("S'utilitza en un DataGrid")]
        public decimal _ParticipacionsUtilitzades
        {
            get { return vDesglosCompra._PartsUtilitzades; }
        }

        [Description("S'utilitza en un DataGrid")]
        public decimal _PigDeLaCompraOrigen
        {
            get
            {
                var costOrig = vDesglosCompra._CompraOrig.PreuParticipacio * vDesglosCompra._PartsUtilitzadesOrig;
                var valorSim = PreuParticipacioSimulacio * vDesglosCompra._PartsUtilitzades;

                return valorSim - costOrig;
            }
        }

        [Description("S'utilitza en un DataGrid")]
        public decimal _PigDeLaCompra
        {
            get
            {
                var cost = vDesglosCompra._Compra.PreuParticipacio * vDesglosCompra._PartsUtilitzades;
                var valorSim = PreuParticipacioSimulacio * vDesglosCompra._PartsUtilitzades;

                return valorSim - cost;
            }
        }

        [Description("S'utilitza en un DataGrid")]
        public decimal _ValorActual
        {
            get { return PreuParticipacioSimulacio * vDesglosCompra._PartsUtilitzades; }
        }

        #endregion *** Propietats per mostrar en dataGridView ***


        #region *** Mètodes sobreescrits ***

        public static bool operator ==(StrDgvCompresOriginals a, StrDgvCompresOriginals b)
        {
            return a._IdOrig == b._IdOrig;
        }

        public static bool operator !=(StrDgvCompresOriginals a, StrDgvCompresOriginals b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is StrDgvCompresOriginals))
                return false;

            return _IdOrig == ((StrDgvCompresOriginals) obj)._IdOrig;
        }

        public override int GetHashCode()
        {
            return _IdOrig;
        }

        #endregion *** Mètodes sobreescrits ***
    }

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

    public partial class SimulacióVendaTab : TabX
    {
        private const string RegImportMinimContribuent = "ImportMinimContribuent";
        private Producte vProducteSeleccionat = null;
        private string vClauReg;

        public SimulacióVendaTab()
        {
            InitializeComponent();
        }


        #region *** Overrides ***

        internal override void carregaInicial()
        {
            base.carregaInicial();

            // Càrrega el control GestioProductes sense necessitat de clicar "Filtrar".
            //ctrProductes.refrescaDadesControl(true);
            ctrProductes.refrescaDadesControl(null);
        }


        private bool vNoValidaControlsNtb = false;
        internal override void canviUsuari()
        {
            base.canviUsuari();

            vNoValidaControlsNtb = true; // Evita que es facin les validacions al canviar el focus a 'ctrProductes'
            ctrProductes.Focus();

            //ctrProductes.refrescaDadesControl(true); //Mostra els productes del nou usuari.
            ctrProductes.refrescaDadesControl(null); //Mostra els productes del nou usuari.
           
            actualitzaControlsAny();
        }


        internal override void refresca()
        {
            base.refresca();

            actualitzaControlsAny();
            ompleDgvCompres(vProducteSeleccionat, ntbPreuParticipacio.Valor);
        }

        internal override void obrePestanya(Producte prod)
        {
            ctrProductes.refrescaDadesControl(prod);
        }

        internal override void escape(object sender, KeyEventArgs e)
        {
            if (!(((SimulacióVendaTab)((Form)sender).ActiveControl).ActiveControl is NumericTextBox2))
                // Si el control actiu és del tipus NumericTextBox2, no es crida a "base.escape" per evitar que s'executi "refresca()".
                base.escape(sender, e);
        }

        #endregion *** Overrides ***


        private bool _EsAnyActual { get { return Convert.ToInt32(cbAny.SelectedItem) == DateTime.Today.Year; } }

        private decimal valorTramExent(int any)
        {
            decimal tramExentAnual;
            vClauReg = Utilitats.CreaClauRegistre() + "\\" + Usuari.Seleccionat.Nom + "\\" + any;
            var dd1 = Utilitats.LlegeixVariableRegistre(Registry.CurrentUser, vClauReg, RegImportMinimContribuent);
            Decimal.TryParse(dd1, out tramExentAnual);

            return tramExentAnual;
        }


        private decimal valorIngressosExterns(int any)
        {
            return Program.Sessio.IngressosExterns.Where(w =>w.Usuari.Id == Usuari.Seleccionat.Id && w.Any == any).ToList().Sum(s => s.Import);
        }


        private void  ompleDgvCompres(Producte prod, decimal? preuPart = null)
        {
            if (prod == null)
            {
                dgvCompresOriginals.DataSource = new List<StrDgvCompresOriginals>();
                
                ntbImportBrut.Valor = 0;
                ntbPigSimulacio.Valor = 0;
                ntbPigOrigSimulacio.Valor = 0;
                ntbPiGAltresProductes.Valor = 0;

                calculaTotalATributar();

                return;
            }

            preuPart = preuPart.GetValueOrDefault(prod.ValoracionsProducte.Last().PreuParticipacio);

            var desgloçPartsEnCartera = prod.desglosCompresDeParticipacionsEnData4(DateTime.Now, prod._Participacions)
                .OrderBy(o => o._DataOrig).ToList();

            List<StrDgvCompresOriginals> compresProdSelecionat = new List<StrDgvCompresOriginals>();

            /* *** Salta les participacions més antigues. 
                 * És per no haver de fer un traspàs simulat per veure el PiG de les més noves */
            var saltResten = ntbPartsSaltades.Valor;
            var partsResten = ntbNumParticipacions.Valor;
            foreach (var desglosCompraExt in desgloçPartsEnCartera)
            {
                if (saltResten > 0)
                {
                    if (desglosCompraExt._PartsUtilitzades <= saltResten)
                    {
                        saltResten -= desglosCompraExt._PartsUtilitzades;
                        continue;
                    }

                    if (saltResten > 0)
                    {
                        desglosCompraExt._PartsUtilitzades -= saltResten;
                        saltResten = 0;
                    }
                }

                if (desglosCompraExt._PartsUtilitzades > partsResten)
                {
                    desglosCompraExt._PartsUtilitzades = partsResten;
                    compresProdSelecionat.Add(new StrDgvCompresOriginals(desglosCompraExt, preuPart.Value));
                    break;
                }

                compresProdSelecionat.Add(new StrDgvCompresOriginals(desglosCompraExt, preuPart.Value));

                partsResten -= desglosCompraExt._PartsUtilitzades;
            }

            SuspendLayout();

            ntbImportBrut.Valor = ntbNumParticipacions.Valor * preuPart.Value;
            ntbPigSimulacio.Valor = compresProdSelecionat.Sum(s => s._PigDeLaCompra);
            ntbPigOrigSimulacio.Valor = compresProdSelecionat.Sum(s => s._PigDeLaCompraOrigen);

            dgvCompresOriginals.SuspendLayout();
            dgvCompresOriginals.CellFormatting += NumericCell.CellFormatting; 
            dgvCompresOriginals.DataSource = compresProdSelecionat.OrderBy(o => o._DataOrig).ToList();
            dgvCompresOriginals.ClearSelection();
            dgvCompresOriginals.CellFormatting -= NumericCell.CellFormatting;
            dgvCompresOriginals.ResumeLayout();

            calculaTotalATributar();

            ResumeLayout();
        }

        /// <summary>
        /// Calcula el valor a tributar. Si negatiu és que no s'ha arribat al límit que no tributa.
        /// </summary>
        /// <returns></returns>
        private void calculaTotalATributar()
        {
            var tramNoTributa = (ntbTramExentAnual.Valor + ntbPerduesAnysAnteriors.Valor) 
                - (ntbPiGActual.Valor + ntbIngressosExterns.Valor + ntbDividents.Valor);

            var tributaRenda = ntbPigOrigSimulacio.Valor + ntbPiGAltresProductes.Valor - tramNoTributa;

            // Si "tributaRenda" és negatiu significa que encara és pot seguir venent sense tributar. Passo el valor a positiu.
            // Si "tributaRenda" és positiu significa que ja s'ha sobrepasat el límit que no tributa. Poso "ntbRestaTramNoTributa" a 0.
            if (_EsAnyActual)
                ntbRestaTramNoTributa.Valor = tributaRenda <= 0 ? Math.Abs(tributaRenda) : 0;
            else
                ntbRestaTramNoTributa.Valor = 0;

            ntbTributaRenda.Valor = tributaRenda <= 0 ? 0 : tributaRenda;
        }

        /// <summary>
        /// Son els controls que varien al canviar d'any o al refrescar.
        /// </summary>
        private void actualitzaControlsAny()
        {
            ntbTramExentAnual.Valor = valorTramExent(vAny);
            ntbPerduesAnysAnteriors.Valor = Math.Abs(Producte.PerduesDarrersQuatreAnys(vAny));
            ntbPiGActual.Valor = Moviment.MovimentsUsuari.Where(w => w._EsVendaReal && w.Data.Year == vAny).ToList().Sum(s => s.pigVenda(true));
            ntbIngressosExterns.Valor = valorIngressosExterns(vAny);
            ntbDividents.Valor = Moviment.MovimentsUsuari.Where(w => w.Data.Year == vAny && w.TipusMoviment == TipusMoviment.Dividends)
                .ToList().Sum(s => s.PreuParticipacio);

            calculaTotalATributar();
        }

        /// <summary>
        /// Son els controls que varien al canviar de producte.
        /// </summary>
        /// <param name="prod"></param>
        private void actualitzaControlsProducte(Producte prod)
        {
            vProducteSeleccionat = prod;

            ntbNumParticipacions.Enabled = prod != null && prod._Participacions > 0;
            ntbPreuParticipacio.Enabled = prod != null && prod._Participacions > 0;
            ntbPartsSaltades.Enabled = prod != null && prod._Participacions > 0;

            ntbNumParticipacions.Valor = prod == null ? 0 : prod._Participacions;
            ntbPreuParticipacio.Valor = prod == null ? 0 : prod.ValoracionsProducte.Last().PreuParticipacio;

            ntbPartsSaltades.Valor = 0;
            ntbTributaRenda.Valor = 0;

            ompleDgvCompres(prod);
        }

        #region *** Events ***

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

        private void productes_ProducteSeleccionat(object sender, EventArgs e)
        {
            actualitzaControlsProducte((Producte) sender);

            if (sender != null)
                ntbNumParticipacions.Focus();
        }

        private int vAny;
        private void cbAny_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAny.SelectedItem != null && vAny != Convert.ToInt32(cbAny.SelectedItem))
            {
                vAny = Convert.ToInt32(cbAny.SelectedItem);

                gbPigRealAny.Text = "PiG Any: " + cbAny.Text;

                btRecalcula.Enabled = false;
                ctrProductes.Enabled = _EsAnyActual;

                ntbTramExentAnual.ReadOnly = !_EsAnyActual;
                ntbPiGAltresProductes.Enabled = _EsAnyActual;

                // *** Inicialitza valors
                ctrProductes.seleccionaProducte(null);

                // *** Si no és l'any actual fa invisibles els groupBox que contenen els ntb ***
                btRecalcula.Visible = _EsAnyActual;
                ntbNumParticipacions.Parent.Visible = _EsAnyActual;
                ntbPreuParticipacio.Parent.Visible = _EsAnyActual;
                ntbPartsSaltades.Parent.Visible = _EsAnyActual;
                ntbPiGAltresProductes.Parent.Visible = _EsAnyActual;
                ntbImportBrut.Parent.Visible = _EsAnyActual;
                ntbPigSimulacio.Parent.Visible = _EsAnyActual;
                ntbPigOrigSimulacio.Parent.Visible = _EsAnyActual;
                ntbRestaTramNoTributa.Parent.Visible = _EsAnyActual;

                actualitzaControlsAny();
            }
        }
        

        private void ntb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                var cancel = new CancelEventArgs();
                ntb_Validating(sender, cancel);
                if (cancel.Cancel)
                {
                    e.Handled = true;
                    return;
                }
                ((NumericTextBox2) sender).SelectAll();
            }
        }

        private void ntb_Validating(object sender, CancelEventArgs e)
        {
            if (vNoValidaControlsNtb)
            {
                // Quan no vull que es facin les validacions. P.ex. si vProducteSeleccionat == null.
                vNoValidaControlsNtb = false;
                return;
            }

            var ntb = (NumericTextBox2) sender;

            if (ntb == ntbNumParticipacions || ntb == ntbPartsSaltades)
            {
                if(ntb.Valor > vProducteSeleccionat._Participacions)
                {
                    MessageBox.Show("El valor és superior a les participacions disponibles.", "Avís", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                    return;
                }

                if ((ntbNumParticipacions.Valor + ntbPartsSaltades.Valor) > vProducteSeleccionat._Participacions)
                {
                    var missatge = "La suma de 'Num, Partic.' + 'Parts Saltades' supera les participacions disponibles. " +
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

            if (ntb == ntbTramExentAnual && ntbTramExentAnual.Valor != valorTramExent(vAny))
            {
                if (MessageBox.Show("S'ha modificat el valor del 'Tram Exent Anual'. Vols desar el nou valor al registre de Windows?"
                    , "Avís", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Utilitats.GravaVariableRegistre(Registry.CurrentUser, vClauReg, RegImportMinimContribuent, ntbTramExentAnual._DecimalValue);
                }
                else
                {
                    ntbTramExentAnual.Valor = valorTramExent(vAny);
                    e.Cancel = true;
                    return;
                }
            }

            ompleDgvCompres(vProducteSeleccionat, ntbPreuParticipacio.Valor);
        }

        #endregion *** Events ***
    }
}