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
    partial class SimulacioVendaTab
    {
        internal class SimulacioVendaTabDgv : INotifyPropertyChanged
        {
            static SimulacioVendaTab RefSimulacioVendaTab;
            private static Producte Producte;

            private static BindingList<SimulacioVendaTabDgv> LlistaCompresOriginals = new BindingList<SimulacioVendaTabDgv>();
            private static BindingSource BsDgvCompresOriginals;
            private static decimal PreuParticipacioSimulacio;

            private readonly DesglosCompraExt vDesglosCompra;
            private Label vEtiquetaColorColor;


            #region *** Constructors ***

            /// <summary>
            /// Inicialitza les etiquetes de colors per a les parts utilitzades.
            /// </summary>
            /// <param name="totLliure"></param>
            /// <param name="parcialLliure"></param>
            /// <param name="totPle"></param>
            internal static void Inicialitza(SimulacioVendaTab ss)
            {
                RefSimulacioVendaTab = ss;
            }

            /// <summary>
            /// Carrega el producte.
            /// </summary>
            /// <param name="prod"></param>
            internal static void CarregaProducte(Producte prod)
            {
                Producte = prod;

                PreuParticipacioSimulacio = prod.ValoracionsProducte.Last().PreuParticipacio;

                LlistaCompresOriginals = new BindingList<SimulacioVendaTabDgv>();


                var desgloçPartsEnCartera = Producte.desglosCompresDeParticipacionsEnData4(DateTime.Now, Producte._Participacions)
                    .OrderBy(o => o._DataOrig);

                foreach (DesglosCompraExt desglosCompra in desgloçPartsEnCartera)
                {
                    desglosCompra._PartsUtilitzades = 0;
                    LlistaCompresOriginals.Add(new SimulacioVendaTabDgv(desglosCompra, RefSimulacioVendaTab.lbTotLliure));
                }

                BsDgvCompresOriginals = new BindingSource();
                BsDgvCompresOriginals.DataSource = _LCompresOriginals;
                _DgvCompresOriginals.DataSource = BsDgvCompresOriginals;

                foreach (DataGridViewColumn col in _DgvCompresOriginals.Columns) 
                {
                    if (col.AutoSizeMode == DataGridViewAutoSizeColumnMode.AllCellsExceptHeader)
                        _DgvCompresOriginals
                            .AutoResizeColumn(col.Index, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                }
            }



            /// <summary>
            /// Actualitza els valors de simulació per a les participacions, ajustant la venda simulada en funció del preu especificat i 
            /// del nombre de participacions que s'han d'ometre o processar.
            /// </summary>
            /// <param name="preuPart">El preu per participació que s'utilitzarà a la simulació.</param>
            /// <param name="saltResten">El nombre de participacions que s'han d'ometre abans d'iniciar la simulació. Ha de ser zero o superior.</param>
            /// <param name="partsResten">El nombre total de participacions que s'han de processar a la simulació. Ha de ser zero o superior.</param>
            /// <exception cref="Exception">Es genera si el producte o els controls d'etiqueta obligatoris no s'han inicialitzat.</exception>
            internal static void ModificaValors(decimal preuPart, decimal saltResten, decimal partsResten)
            {
                if (Producte == null)
                    throw new Exception("El producte no està inicialitzat a SimulacioVendaTabDgv.");

                if (RefSimulacioVendaTab.lbTotLliure == null || RefSimulacioVendaTab.lbParcialLliure == null || RefSimulacioVendaTab.lbTotPle == null)
                    throw new Exception("Les etiquetes de colors no estan inicialitzades a SimulacioVendaTabDgv.");

                // Aquí omplo lCompresOriginals a partir de producte.

                var desgloçPartsEnCartera = Producte.desglosCompresDeParticipacionsEnData4(DateTime.Now, Producte._Participacions)
                        .OrderBy(o => o._DataOrig);

                LlistaCompresOriginals = new BindingList<SimulacioVendaTabDgv>();

                PreuParticipacioSimulacio = preuPart;

                foreach (DesglosCompraExt desglosCompra in desgloçPartsEnCartera)
                {
                    /* *** Salta les participacions més antigues. 
                         * És per no haver de fer un traspàs simulat per veure el PiG de les més noves */
                    if (saltResten > 0)
                    {
                        if (desglosCompra._PartsUtilitzades <= saltResten)
                        {
                            saltResten -= desglosCompra._PartsUtilitzades;
                            desglosCompra._PartsUtilitzades = 0;
                        }
                        else
                        {
                            desglosCompra._PartsUtilitzades -= saltResten;
                            saltResten = 0;
                        }
                    }

                    // Deso el color de la cel·la: Parts Utils.
                    Label labelColor = partsResten == 0 ? RefSimulacioVendaTab.lbTotLliure
                            : partsResten < desglosCompra._PartsUtilitzades ? RefSimulacioVendaTab.lbParcialLliure 
                            : RefSimulacioVendaTab.lbTotPle;

                    if (desglosCompra._PartsUtilitzades > partsResten)
                    {
                        desglosCompra._PartsUtilitzades = partsResten;
                        LlistaCompresOriginals.Add(new SimulacioVendaTabDgv(desglosCompra, labelColor));
                        partsResten = 0;
                    }
                    else
                    {
                        LlistaCompresOriginals.Add(new SimulacioVendaTabDgv(desglosCompra, labelColor));
                        partsResten -= desglosCompra._PartsUtilitzades;
                    }
                }
            }

            /// <summary>
            /// Inicialitza una nova instància de la classe SimulacioVendaTabDgv amb el desglossament de la compra i l'etiqueta especificats
            /// configuració de color.
            /// </summary>
            /// <param name="desglosCompra">Les dades del desglossament de la compra que s'utilitzaran per a la inicialització. No pot ser nul.</param>
            /// <param name="etiquetaColor">L'etiqueta els colors de fons i primer pla de la qual s'utilitzen per establir l'esquema de colors inicial. No pot ser nul.</param>
            private SimulacioVendaTabDgv(DesglosCompraExt desglosCompra, Label etiquetaColor)
            {
                vDesglosCompra = desglosCompra;
                vEtiquetaColorColor = etiquetaColor;
            }

            #endregion *** Constructors ***


            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propietat)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propietat));
            }

            // Todo: Revisar aquest càlcul perquè no funciona be..
            internal static decimal CalculaParticipacionsPerLimitExent(decimal restaNoTributa)
            {
                _DgvCompresOriginals.SuspendLayout();

                foreach (SimulacioVendaTabDgv fila in BsDgvCompresOriginals)
                {
                    fila.vDesglosCompra._PartsUtilitzades = 0;
                }

                decimal numParts = 0;

                foreach (SimulacioVendaTabDgv fila in BsDgvCompresOriginals)
                {
                    var pigOrigTotal = fila._PigOrigenDisponible;

                    if (restaNoTributa > pigOrigTotal)
                    {
                        restaNoTributa -= pigOrigTotal;
                        numParts += fila._PartsDisp;
                    }
                    else
                    {
                        numParts += fila._Participacions / pigOrigTotal * restaNoTributa;
                        break;
                    }
                }
                // 28-Euro Fund A-2 Acc -> Num Parts = 24,46665


                var nParts = numParts;

                foreach (SimulacioVendaTabDgv fila in BsDgvCompresOriginals)
                {
                    if (fila.vDesglosCompra._PartsDisponibles >= nParts)
                    {
                        fila.vDesglosCompra._PartsUtilitzades += nParts; // Més parts utilitzades, menys disponibles.
                        fila.vEtiquetaColorColor = RefSimulacioVendaTab.lbParcialLliure;
                        nParts = 0;
                    }
                    else
                    {
                        var pDisp = fila.vDesglosCompra._PartsDisponibles;
                        fila.vDesglosCompra._PartsUtilitzades += pDisp; // Més parts utilitzades, menys disponibles.
                        fila.vEtiquetaColorColor = RefSimulacioVendaTab.lbTotPle;
                        nParts -= pDisp;
                    }

                    // Indica que ha de redibuixar la fila
                    var indexFila = BsDgvCompresOriginals.IndexOf(fila);

                    _DgvCompresOriginals
                        .AutoResizeColumn(RefSimulacioVendaTab.PartsUtil.Index, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                    _DgvCompresOriginals
                        .AutoResizeColumn(RefSimulacioVendaTab.PigOrigenUtil.Index, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                    _DgvCompresOriginals
                        .AutoResizeColumn(RefSimulacioVendaTab.ValorAct.Index, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);

                    _DgvCompresOriginals.InvalidateRow(indexFila);

                    //fila.OnPropertyChanged("_ParticipacionsUtilitzades");

                    if (nParts == 0)
                        break;
                }

                //_DgvCompresOriginals.Refresh();
                _DgvCompresOriginals.ClearSelection();
                _DgvCompresOriginals.ResumeLayout();

                return Math.Round(numParts, 3);
            }
            

            private static DataGridView _DgvCompresOriginals
            {
                get { return RefSimulacioVendaTab.dgvCompresOriginals; }
            }

            internal static BindingList<SimulacioVendaTabDgv> _LCompresOriginals
            {
                get { return LlistaCompresOriginals; }
            }

            internal Color _BackColorPartsUtil
            {
                get { return vEtiquetaColorColor.BackColor; }
            }

            internal Color _ForeColorPartsUtil
            {
                get { return vEtiquetaColorColor.ForeColor; }
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

            public decimal _PigDeLaCompraOrigen
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
                unchecked { 
                    int hash = 17; 
                    hash = hash * 23 + _Id.GetHashCode(); 
                    hash = hash * 23 + _IdOrig.GetHashCode(); 
                    return hash; 
                }
            }

            #endregion *** Mètodes sobreescrits ***
        }
    }
}