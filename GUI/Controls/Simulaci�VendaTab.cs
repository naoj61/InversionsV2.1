using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Comuns;
using Controls;
using Inversions.GUI.Forms;
using Microsoft.Win32;

namespace Inversions.GUI
{
    internal struct FilaCompresOriginals
    {
        private readonly DesglosCompraExt vDesglosCompra;
        private static decimal PreuParticipacioSimulacio;

        public FilaCompresOriginals(DesglosCompraExt desglosCompra, decimal? preuPart)
            : this()
        {
            vDesglosCompra = desglosCompra;
            PreuParticipacioSimulacio = preuPart.GetValueOrDefault(vDesglosCompra._Compra.Prod._PreuParticipacioActual);
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

        public static bool operator ==(FilaCompresOriginals a, FilaCompresOriginals b)
        {
            return a._IdOrig == b._IdOrig;
        }

        public static bool operator !=(FilaCompresOriginals a, FilaCompresOriginals b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is FilaCompresOriginals))
                return false;

            return _IdOrig == ((FilaCompresOriginals) obj)._IdOrig;
        }

        public override int GetHashCode()
        {
            return _IdOrig;
        }

        #endregion *** Mètodes sobreescrits ***
    }


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

            ctrProductes.refrescaDadesControl(true);
        }

        internal override void canviUsuari()
        {
            dgvCompresOriginals.DataSource = null;

            ntbNumParticipacions.Valor = 0;
            ntbPreuParticipacio.Valor = 0;
            ntbTributaRenda.Valor = 0;
            ntbPigSimulacio.Valor = 0;
            ntbPigOrigSimulacio.Valor = 0;
            ntbImportBrut.Valor = 0;

            refresca();

            base.canviUsuari();
        }

        internal override void refresca()
        {
            base.refresca();

            ctrProductes.refrescaDadesControl(_PendentCanviUsuari);

            calculaTotalATributar();
        }

        #endregion *** Overrides ***


        private int _AnySeleccionat
        {
            get { return Convert.ToInt32(cbAny.SelectedItem); }
        }

        private decimal carregaValorTramExent()
        {
            decimal tramExentAnual;
            vClauReg = Utilitats.CreaClauRegistre() + "\\" + Usuari.Seleccionat.Nom + "\\" + _AnySeleccionat;
            var dd1 = Utilitats.LlegeixVariableRegistre(Registry.CurrentUser, vClauReg, RegImportMinimContribuent);
            Decimal.TryParse(dd1, out tramExentAnual);

            return tramExentAnual;
        }
        
        private void ompleDgvCompres(decimal? preuPart)
        {
            if (vProducteSeleccionat == null)
                return;

            var desgloçPartsEnCartera = vProducteSeleccionat.desglosCompresDeParticipacionsEnData(DateTime.Now, ntbNumParticipacions.Valor).ToList();

            List<FilaCompresOriginals> compresProdSelecionat =
                desgloçPartsEnCartera.Select(desglosCompra => new FilaCompresOriginals(desglosCompra, preuPart)).ToList();

            SuspendLayout();

            ntbImportBrut.Valor = compresProdSelecionat.Sum(s => s._ValorActual);
            ntbPigSimulacio.Valor = compresProdSelecionat.Sum(s => s._PigDeLaCompra);
            ntbPigOrigSimulacio.Valor = compresProdSelecionat.Sum(s => s._PigDeLaCompraOrigen);

            dgvCompresOriginals.SuspendLayout();
            dgvCompresOriginals.CellFormatting += dgv_CellFormatting;
            dgvCompresOriginals.DataSource = compresProdSelecionat.OrderBy(o => o._DataOrig).ToList();
            dgvCompresOriginals.ClearSelection();
            dgvCompresOriginals.CellFormatting -= dgv_CellFormatting;
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
            var any = _AnySeleccionat;

            var sessio = Program.Sessio;
            var pigAny = Moviment.MovimentsUsuari.Where(w => w._EsVendaReal && w.Data.Year == any).ToList().Sum(s => s.pigVenda(true));

            var ingressosExterns = sessio.IngressosExterns.Where(w => w.Any == any).ToList().Sum(s => s.Import);

            var dividents = sessio.Moviments.Where(w => w.Data.Year == any && w.TipusMoviment == TipusMoviment.Dividends).ToList().Sum(s => s.PreuParticipacio);

            var perduesAnysAnteriors = Math.Abs(Producte.PerduesDarrersQuatreAnys(any));

            var restaTramNoTributa = (ntbTramExentAnual.Valor + perduesAnysAnteriors) - (pigAny + ingressosExterns + dividents);

            var tributaRenda = ntbPigOrigSimulacio.Valor + ntbPiGAltresProductes.Valor - restaTramNoTributa;

            ntbPiGActual.Valor = pigAny;
            ntbPerduesAnysAnteriors.Valor = perduesAnysAnteriors;
            ntbIngressosExterns.Valor = ingressosExterns;
            ntbDividents.Valor = dividents;

            // Si "tributaRenda" és negatiu significa que encara és pot seguir venent sense tributar. Passo el valor a positiu.
            // Si "tributaRenda" és positiu significa que ja s'ha sobrepasat el límit que no tributa. Poso "ntbRestaTramNoTributa" a 0.
            ntbRestaTramNoTributa.Valor = tributaRenda < 0 ? Math.Abs(tributaRenda) : 0;
            ntbTributaRenda.Valor = tributaRenda < 0 ? 0 : tributaRenda;
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
            if (ntbNumParticipacions.Valor > vProducteSeleccionat._Participacions)
            {
                MessageBox.Show("Num. participacions massa gran");
                return;
            }

            ompleDgvCompres(ntbPreuParticipacio.Valor);
        }

        private void productes_ProducteSeleccionat(object sender, EventArgs e)
        {
            vProducteSeleccionat = sender as Producte;

            if (vProducteSeleccionat == null)
            {
                ntbNumParticipacions.Enabled = false;
                ntbPreuParticipacio.Enabled = false;

                ntbNumParticipacions.Valor = 0;
                ntbPreuParticipacio.Valor = 0;
                ntbTributaRenda.Valor = 0;
            }
            else
            {
                ntbNumParticipacions.Enabled = vProducteSeleccionat._Participacions > 0;
                ntbPreuParticipacio.Enabled = vProducteSeleccionat._Participacions > 0;

                ntbNumParticipacions.Valor = vProducteSeleccionat._Participacions;
                ntbPreuParticipacio.Valor = vProducteSeleccionat.ValoracionsProducte.Last().PreuParticipacio;
            }

            ompleDgvCompres(null);

            ntbNumParticipacions.Focus();
        }

        private void cbAny_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAny.SelectedItem != null)
            {
                gbPigRealAny.Text = "PiG Any: " + cbAny.Text;

                if (_AnySeleccionat != DateTime.Today.Year)
                {
                    ctrProductes.seleccionaProducte(null);
                    dgvCompresOriginals.DataSource = null;
                    btRecalcula.Enabled = false;
                    ctrProductes.Enabled = false;
                    ntbTramExentAnual.ReadOnly = true;
                    ntbPiGAltresProductes.ReadOnly = true;
                }
                else
                {
                    btRecalcula.Enabled = true;
                    ctrProductes.Enabled = true;
                    ntbTramExentAnual.ReadOnly = false;
                    ntbPiGAltresProductes.ReadOnly = false;
                }

                ntbImportBrut.Valor = 0;
                ntbPigSimulacio.Valor = 0;
                ntbPigOrigSimulacio.Valor = 0;
                ntbPiGAltresProductes.Valor = 0;

                ntbTramExentAnual.Valor = carregaValorTramExent();

                calculaTotalATributar();
            }
        }

        private void ntbTramExentAnual_Validating(object sender, CancelEventArgs e)
        {
            if (ntbTramExentAnual.Modified)
            {
                if (MessageBox.Show("S'ha modificat el valor del 'Tram Exent Anual'. Vols desar el nou valor al registre de Windows?"
                    , "Avís", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Utilitats.GravaVariableRegistre(Registry.CurrentUser, vClauReg, RegImportMinimContribuent, ntbTramExentAnual._DecimalValue);
                    calculaTotalATributar();

                    ntbTramExentAnual.Modified = false;
                }
                else
                {
                    ntbTramExentAnual.Valor = carregaValorTramExent();
                    e.Cancel = true;
                }
            }
        }

        private void ntb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char) Keys.Enter)
            {
                var ntb = (NumericTextBox2) sender;

                if (ntb.Modified)
                {
                    ompleDgvCompres(ntbPreuParticipacio.Valor);
                    ntb.Modified = false;
                }
            }
        }

        private void ntb_Leave(object sender, EventArgs e)
        {
            var ntb = (NumericTextBox2) sender;

            if (ntb.Modified)
            {
                ompleDgvCompres(ntbPreuParticipacio.Valor);
                ntb.Modified = false;
            }
        }
        
        #endregion *** Events ***
    }
}