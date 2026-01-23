using Controls;
using DevExpress.XtraExport;
using Inversions.ClassesEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Inversions.GUI
{
    internal class SimulacioVendaTabDgv : INotifyPropertyChanged
    {
        private static Producte Producte;
        private static BindingSource BsDgvCompresOriginals;
        private static decimal PreuParticipacioSimulacio;
        static DataGridView DgvCompresOriginals;

        private readonly DesglosCompraExt vDesglosCompra;
        private decimal vPartsOcupades; // Parts ocupades sense manipular, al carregar el projecte.


        #region *** Constructors ***
        /// <summary>
        /// Inicialitza una nova instància de la classe SimulacioVendaTabDgv amb el desglossament de la compra i l'etiqueta especificats
        /// configuració de color.
        /// </summary>
        /// <param name="desglosCompra">Les dades del desglossament de la compra que s'utilitzaran per a la inicialització. No pot ser nul.</param>
        private SimulacioVendaTabDgv(DesglosCompraExt desglosCompra)
        {
            vDesglosCompra = desglosCompra;
        }

        #endregion *** Constructors ***


        #region *** Mètodes statics ***

        /// <summary>
        /// Desa la referencia a: SimulacioVendaTab.
        /// </summary>
        /// <param name="refSimulacioVendaTab"></param>
        internal static void Inicialitza(DataGridView dgvCompresOriginals)
        {
            DgvCompresOriginals = dgvCompresOriginals;

            CarregaProducte(null);
        }

        /// <summary>
        /// Carrega el DgvCompresOriginals amb el producte.
        /// </summary>
        /// <param name="prod"></param>
        internal static void CarregaProducte(Producte prod, bool ompleDataGrid = true)
        {
            Producte = prod;

            IOrderedEnumerable<DesglosCompraExt> desgloçPartsEnCartera;
            if (prod == null)
            {
                PreuParticipacioSimulacio = 0;
                desgloçPartsEnCartera = Enumerable.Empty<DesglosCompraExt>().OrderBy(o => o._DataOrig);
            }
            else
            {
                PreuParticipacioSimulacio = prod.ValoracionsProducte.Last().PreuParticipacio;
                desgloçPartsEnCartera = prod.desglosCompresDeParticipacionsEnData4(DateTime.Now, prod._Participacions)
                               .OrderBy(o => o._DataOrig);
            }

            var LlistaCompresOriginals = new BindingList<SimulacioVendaTabDgv>();
            foreach (DesglosCompraExt desglosCompra in desgloçPartsEnCartera)
            {
                var fila = new SimulacioVendaTabDgv(desglosCompra);
                fila.vPartsOcupades = desglosCompra._PartsOcupades;

                LlistaCompresOriginals.Add(fila);
            }

            BsDgvCompresOriginals = new BindingSource();
            BsDgvCompresOriginals.DataSource = LlistaCompresOriginals;
            DgvCompresOriginals.DataSource = BsDgvCompresOriginals;

            if (ompleDataGrid)
                OmpleDataGrid(0, 0);
        }


        /// <summary>
        /// Omple i actualitza dgvCompresOriginals.
        /// </summary>
        /// <remarks>Aquest mètode actualitza la font de dades subjacent de la quadrícula de dades per reflectir l'
        /// assignació de parts de participació, ajusta l'amplada de les columnes i actualitza la pantalla. Està pensat per a
        /// ús dins del flux de treball de simulació i assumeix que la quadrícula de dades i la seva font de dades estan correctament
        /// inicialitzades.</remarks>
        /// <param name="parts">El nombre total de parts de participació que s'assignaran a la quadrícula de dades. Ha de ser zero o superior.</param>
        /// <param name="saltaParts">El nombre de parts de participació que s'ometran abans que comenci l'assignació. Ha de ser zero o superior.</param>
        /// <param name="preuParticipacio">El preu de participació que s'utilitzarà per a la simulació. Si és nul, es conserva el preu de simulació existent.</param>
        internal static void OmpleDataGrid(decimal parts, decimal saltaParts, decimal? preuParticipacio = null)
        {
            if (preuParticipacio.HasValue)
                PreuParticipacioSimulacio = preuParticipacio.Value;

            // Primer posa a zero les partsUtilitzades.
            foreach (SimulacioVendaTabDgv fila in BsDgvCompresOriginals)
            {
                fila.vDesglosCompra._PartsUtilitzades = 0;
                fila.vDesglosCompra._PartsOcupades = fila.vPartsOcupades;
            }

            // Ara assigna els partsPerLimit calculats
            var nParts = parts;
            var saltaPartsLocal = saltaParts;

            foreach (SimulacioVendaTabDgv fila in BsDgvCompresOriginals)
            {
                var partsDisp = fila._PartsDisp;

                // Salta parts si cal
                if (saltaPartsLocal > 0)
                {
                    if (partsDisp <= saltaPartsLocal)
                    {
                        fila.vDesglosCompra._PartsOcupades += partsDisp;
                        saltaPartsLocal -= partsDisp;
                        continue;
                    }
                    else
                    {
                        fila.vDesglosCompra._PartsOcupades += saltaPartsLocal;
                        partsDisp -= saltaPartsLocal;
                        saltaPartsLocal = 0;
                    }
                }

                if (nParts == 0)
                {
                    fila.vDesglosCompra._PartsUtilitzades = 0;
                }
                else if (nParts < partsDisp)
                {
                    fila.vDesglosCompra._PartsUtilitzades += nParts; // Més parts utilitzades, menys disponibles.
                    nParts = 0;
                }
                else
                {
                    fila.vDesglosCompra._PartsUtilitzades += partsDisp; // Més parts utilitzades, menys disponibles.
                    nParts -= partsDisp;
                }
            }


            // Actualitza les dades mostrades i les amplades de les columnes a DgvCompresOriginals sense reinicialitzar-la tota.
            BsDgvCompresOriginals.ResetBindings(false);

            DgvCompresOriginals.ClearSelection();
        }


        /// <summary>
        /// Calcula el nombre de participacions que es poden assignar fins al límit no imposable especificat,
        /// opcionalment ometent un nombre determinat de participacions a l'inici.
        /// </summary>
        /// <param name="restaNoTributa">L'import no imposable restant que s'ha de distribuir entre les participacions. 
        /// Ha de ser superior o igual a zero.
        /// </param>
        /// <param name="saltaParts">El nombre de participacions a ometre abans de començar l'assignació. 
        /// Ha de ser superior o igual a zero.
        /// </param>
        /// <returns>El nombre total de participacions assignades fins al límit no imposable especificat, després d'ometre el
        /// nombre especificat de participacions.
        /// </returns>            
        internal static decimal CalculaPartPerLimitExent(decimal restaNoTributa, decimal saltaParts)
        {
            foreach (SimulacioVendaTabDgv fila in BsDgvCompresOriginals)
            {
                fila.vDesglosCompra._PartsUtilitzades = 0;
            }

            decimal partsPerLimit = 0;
            decimal saltaPartsLocal = saltaParts;

            foreach (SimulacioVendaTabDgv fila in BsDgvCompresOriginals)
            {
                var partsDisp = fila._PartsDisp;

                // Salta parts si cal
                if (saltaPartsLocal > 0)
                {
                    if (partsDisp <= saltaPartsLocal)
                    {
                        saltaPartsLocal -= partsDisp;
                        continue;
                    }
                    else
                    {
                        partsDisp -= saltaPartsLocal;
                        saltaPartsLocal = 0;
                    }
                }

                var pigOrigDisp = fila._PigOrigenDisponible / fila._PartsDisp * partsDisp;

                if (restaNoTributa > pigOrigDisp)
                {
                    restaNoTributa -= pigOrigDisp;
                    partsPerLimit += fila._PartsDisp;
                }
                else
                {
                    partsPerLimit += fila._Participacions / pigOrigDisp * restaNoTributa;
                    break;
                }
            }

            OmpleDataGrid(partsPerLimit, saltaParts);

            return partsPerLimit;
        }

        #endregion *** Mètodes statics ***


        #region *** Event que no utilitzo, suggerència de Copilot per indicar que la cel·la ha canviat ***

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propietat)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propietat));
        }

        // S'invoca amb la següent línia.
        //fila.OnPropertyChanged("_ParticipacionsUtilitzades");

        #endregion *** Event que no utilitzo, suggerència de Copilot ***


        internal static BindingList<SimulacioVendaTabDgv> _LlistaCompresOriginals
        {
            get { return (BindingList<SimulacioVendaTabDgv>)BsDgvCompresOriginals.DataSource; }
        }

        internal decimal _PigDeLaCompraPartsUtil
        {
            get
            {
                return _PigDeLaCompra / vDesglosCompra._Participacions * vDesglosCompra._PartsUtilitzades;
            }
        }


        #region *** Propietats per mostrar en dataGridView ***

        [DisplayName("Id")]
        public int _Id
        {
            get { return vDesglosCompra._Compra.Id; }
        }

        public int _IdOrig
        {
            get { return vDesglosCompra._CompraOrig.Id; }
        }


        public string _FonsOrig
        {
            get { return vDesglosCompra._CompraOrig.Prod._NomProducte; }
        }

        public DateTime _DataOrig
        {
            get { return vDesglosCompra._CompraOrig.Data; }
        }

        public DateTime _DataCompra
        {
            get { return vDesglosCompra._Compra.Data; }
        }

        public decimal _Participacions
        {
            get { return vDesglosCompra._Participacions; }
        }
        public decimal _PartsDisp
        {
            get { return vDesglosCompra._PartsDisponibles; }
        }

        public decimal _ParticipacionsUtilitzades
        {
            get { return vDesglosCompra._PartsUtilitzades; }
        }

        public decimal _PigOrigenDisponible
        {
            get
            {
                decimal costOrig = vDesglosCompra._CompraOrig.PreuParticipacio * vDesglosCompra._PartsDisponiblesOrig;
                decimal valorSim = PreuParticipacioSimulacio * vDesglosCompra._PartsDisponibles;

                return valorSim - costOrig;
            }
        }

        public decimal _PigDeLaCompraOrigenTot
        {
            get
            {
                decimal costOrig = vDesglosCompra._CompraOrig.PreuParticipacio * vDesglosCompra._ParticipacionsOrig;
                decimal valorSim = PreuParticipacioSimulacio * vDesglosCompra._Participacions;

                return valorSim - costOrig;
            }
        }

        public decimal _PigDeLaCompraPartsUtilOrig
        {
            get
            {
                decimal costOrig = vDesglosCompra._CompraOrig.PreuParticipacio * vDesglosCompra._PartsUtilitzadesOrig;
                decimal valorSim = PreuParticipacioSimulacio * vDesglosCompra._PartsUtilitzades;

                return valorSim - costOrig;
            }
        }


        public decimal _PigDeLaCompra
        {
            get
            {
                decimal cost = vDesglosCompra._Compra.PreuParticipacio * vDesglosCompra._Participacions;
                decimal valorSim = PreuParticipacioSimulacio * vDesglosCompra._Participacions;

                return valorSim - cost;
            }
        }

        public decimal _ValorActual
        {
            get { return PreuParticipacioSimulacio * vDesglosCompra._PartsUtilitzades; }
        }

        #endregion *** Propietats per mostrar en dataGridView ***


        #region *** Mètodes sobreescrits ***

        public static bool operator ==(SimulacioVendaTabDgv a, SimulacioVendaTabDgv b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if ((object)a == null || (object)b == null)
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(SimulacioVendaTabDgv a, SimulacioVendaTabDgv b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            if (obj == null || obj.GetType() != GetType())
                return false;

            var other = (SimulacioVendaTabDgv)obj;
            return _Id == other._Id && _IdOrig == other._IdOrig;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + _Id.GetHashCode();
                hash = hash * 23 + _IdOrig.GetHashCode();
                return hash;
            }
        }

        #endregion *** Mètodes sobreescrits ***
    }
}