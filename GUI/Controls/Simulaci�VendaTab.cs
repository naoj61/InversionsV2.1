using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using Comuns;
using Inversions.GUI.Forms;
using Microsoft.Win32;

namespace Inversions.GUI
{

    struct FilaCompresOriginals
    {
        private static double? PreuPartActual;

        private readonly DesglosCompraExt vDesglosCompra;


        public FilaCompresOriginals(DesglosCompraExt desglosCompra)
            : this()
        {
            vDesglosCompra = desglosCompra;
        }


        internal static double? _PreuPartActual
        {
            set { PreuPartActual = value; }
        }

        private double preuPartActual()
        {
            return PreuPartActual.GetValueOrDefault(vDesglosCompra._Compra.Prod._PreuParticipacioActual);
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
        public double _Participacions
        {
            get { return vDesglosCompra._Participacions; }
        }

        [Description("S'utilitza en un DataGrid")]
        public double _ParticipacionsUtilitzades
        {
            get { return vDesglosCompra._PartsUtilitzades; }
        }

        [Description("S'utilitza en un DataGrid")]
        public double _PigDeLaCompraOrigen
        {
            get
            {
                var costOrig = vDesglosCompra._CompraOrig.PreuParticipacio * vDesglosCompra._PartsUtilitzadesOrig;
                var valorAct = preuPartActual() * vDesglosCompra._PartsUtilitzades;

                return valorAct - costOrig;
            }
        }

        [Description("S'utilitza en un DataGrid")]
        public double _PigDeLaCompra
        {
            get
            {
                var cost = vDesglosCompra._Compra.PreuParticipacio * vDesglosCompra._PartsUtilitzades;
                var valorAct = preuPartActual() * vDesglosCompra._PartsUtilitzades;

                return valorAct - cost;
            }
        }

        [Description("S'utilitza en un DataGrid")]
        public double _ValorActual
        {
            get
            {
                var valorAct = preuPartActual() * vDesglosCompra._PartsUtilitzades;

                return valorAct;
            }
        }



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

            return _IdOrig == ((FilaCompresOriginals)obj)._IdOrig;
        }

        public override int GetHashCode()
        {
            return _IdOrig;
        }

        #endregion *** Mètodes sobreescrits ***
    }

    public partial class SimulacióVendaTab : TabX
    {
        private const string NomVarReg = "AnyRenda";
        private Producte vProducteSeleccionat = null;

        public SimulacióVendaTab()
        {
            InitializeComponent();
        }

        internal override void canviUsuari(Usuari usuari)
        {
            dgvCompresOriginals.DataSource = null;
            
            ntbNumParticipacions.Valor = 0;
            ntbPreuParticipacio.Valor = 0;
            ntbPerduesAnteriors.Valor = 0;
            ntbPigTributa.Valor = 0;
            ntbTributaRenda.Valor = 0;
            ntbPig.Valor = 0;
            ntbImportBrut.Valor = 0;

            refresca(true);
        }

        internal override void refresca(bool? refrescaActivat)
        {
            base.refresca(refrescaActivat);

            if (_ActivaRefresca)
            {
                _ActivaRefresca = false;

                productes.refrescaDadesControl();
            }
        }


        private void ompleDgvCompres(double? preuPartActual)
        {
            if (vProducteSeleccionat == null)
                return;

            var desgloçPartsEnCartera = vProducteSeleccionat.desglosCompresDeParticipacionsEnData(DateTime.Now, ntbNumParticipacions.Valor);

            FilaCompresOriginals._PreuPartActual = preuPartActual;

            List<FilaCompresOriginals> compresProdSelecionat =
                desgloçPartsEnCartera.Select(desglosCompra => new FilaCompresOriginals(desglosCompra)).ToList();

            SuspendLayout();
            dgvCompresOriginals.SuspendLayout();
            dgvCompresOriginals.DataSource = compresProdSelecionat.OrderBy(o => o._DataOrig).ToList();
            dgvCompresOriginals.ClearSelection();
            dgvCompresOriginals.ResumeLayout();
            ResumeLayout();
        }

        private void calculaPerdues()
        {
            Program.DesaVariableEnRegistreWindows(NomVarReg, ntbAnyRenda._IntValue.ToString(CultureInfo.InvariantCulture), true);

            ntbPerduesAnteriors.Valor = Producte.PerduesDarrersQuatreAnys(ntbAnyRenda._IntValue);
        }

        private void ompleValors()
        {
            var costParts = vProducteSeleccionat.costOriginalEnCartera4(numPartsMax: ntbNumParticipacions.Valor);
            var valorParts = vProducteSeleccionat.valorEnCartera(numPartsMax: ntbNumParticipacions.Valor, preuParticipacio: ntbPreuParticipacio.Valor);

            ntbPig.Valor = valorParts - costParts;

            if (-ntbPerduesAnteriors.Valor > ntbPig.Valor)
                ntbPigTributa.Valor = 0;
            else
                ntbPigTributa.Valor = ntbPig.Valor + ntbPerduesAnteriors.Valor;

            ntbTributaRenda.Valor = ntbDeduccioIrpf.Valor > ntbPigTributa.Valor ? 0 : ntbPigTributa.Valor - ntbDeduccioIrpf.Valor;

            ntbImportBrut.Valor = valorParts;
        }


        #region *** Events ***

        private void ntbNumParticipacions_Enter(object sender, EventArgs e)
        {
            acceptButton(btSimulacio);
        }

        private void ntbPreuParticipacio_Enter(object sender, EventArgs e)
        {
            acceptButton(btSimulacio);
        }

        private void ntbAnyRenda_Enter(object sender, EventArgs e)
        {
            acceptButton(btRecalcula);
        }

        private void ntbAnyRenda_Validating(object sender, CancelEventArgs e)
        {
            if (ntbAnyRenda.Valor > 0 && ntbAnyRenda.Valor < 2000)
            {
                MessageBox.Show(this, "L'any no pot ser inferior al 2000", "Atenció", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void btSimulacio_Click(object sender, EventArgs e)
        {
            if (ntbNumParticipacions.Valor > vProducteSeleccionat._Participacions)
            {
                MessageBox.Show("Num. participacions massa gran");
                return;
            }

            ompleValors();
            ompleDgvCompres(ntbPreuParticipacio.Valor);
        }

        private void btRecalcula_Click(object sender, EventArgs e)
        {
            calculaPerdues();

            if (btSimulacio.Enabled)
                ompleValors();
        }

        private void productes_ProducteSeleccionat(object sender, EventArgs e)
        {
            vProducteSeleccionat = sender as Producte;

            if (vProducteSeleccionat == null)
            {
                btSimulacio.Enabled = false;

                ntbNumParticipacions.Enabled = false;
                ntbPreuParticipacio.Enabled = false;

                ntbNumParticipacions.Valor = 0;
                ntbPreuParticipacio.Valor = 0;
                ntbPerduesAnteriors.Valor = 0;
                ntbPigTributa.Valor = 0;
                ntbTributaRenda.Valor = 0;
            }
            else
            {
                btSimulacio.Enabled = true;

                ntbNumParticipacions.Enabled = vProducteSeleccionat._Participacions > 0;
                ntbPreuParticipacio.Enabled = vProducteSeleccionat._Participacions > 0;

                ntbNumParticipacions.Valor = vProducteSeleccionat._Participacions;
                ntbPreuParticipacio.Valor = vProducteSeleccionat.ValoracionsProducte.Last().PreuParticipacio;

                ompleValors();
            }
            ompleDgvCompres(null);
        }

        private void SimulacióVendaTab_Load(object sender, EventArgs e)
        {
            var anyRenda = Program.LlegeigVariableEnRegistreWindows(NomVarReg, true);
            ntbAnyRenda.Valor = Utilitats.EsNumeric(anyRenda) ? Convert.ToInt32(anyRenda) : DateTime.Today.Year;

            calculaPerdues();
        }

        #endregion *** Events ***
    }
}