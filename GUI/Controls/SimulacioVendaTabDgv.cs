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

            private static BindingList<SimulacioVendaTabDgv> LlistaCompresOriginals;
            private static BindingSource BsDgvCompresOriginals;
            private static decimal PreuParticipacioSimulacio;

            private readonly DesglosCompraExt vDesglosCompra;


            #region *** Mètodes statics ***

            /// <summary>
            /// Desa la referencia a: SimulacioVendaTab.
            /// </summary>
            /// <param name="refSimulacioVendaTab"></param>
            internal static void Inicialitza(SimulacioVendaTab refSimulacioVendaTab)
            {
                RefSimulacioVendaTab = refSimulacioVendaTab;
            }

            /// <summary>
            /// Carrega el DgvCompresOriginals amb el producte.
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
                    LlistaCompresOriginals.Add(new SimulacioVendaTabDgv(desglosCompra));
                }

                BsDgvCompresOriginals = new BindingSource();
                BsDgvCompresOriginals.DataSource = _LCompresOriginals;
                _DgvCompresOriginals.DataSource = null;

                OmpleDataGrid(0, 0);

                //foreach (DataGridViewColumn col in _DgvCompresOriginals.Columns)
                //{
                //    if (col.AutoSizeMode == DataGridViewAutoSizeColumnMode.AllCellsExceptHeader)
                //        _DgvCompresOriginals
                //            .AutoResizeColumn(col.Index, DataGridViewAutoSizeColumnMode.AllCellsExceptHeader);
                //}
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

                    if (desglosCompra._PartsUtilitzades > partsResten)
                    {
                        desglosCompra._PartsUtilitzades = partsResten;
                        LlistaCompresOriginals.Add(new SimulacioVendaTabDgv(desglosCompra));
                        partsResten = 0;
                    }
                    else
                    {
                        LlistaCompresOriginals.Add(new SimulacioVendaTabDgv(desglosCompra));
                        partsResten -= desglosCompra._PartsUtilitzades;
                    }
                }
            }

            #endregion *** Mètodes statics ***


            /// <summary>
            /// Inicialitza una nova instància de la classe SimulacioVendaTabDgv amb el desglossament de la compra i l'etiqueta especificats
            /// configuració de color.
            /// </summary>
            /// <param name="desglosCompra">Les dades del desglossament de la compra que s'utilitzaran per a la inicialització. No pot ser nul.</param>
            /// <param name="etiquetaColor">L'etiqueta els colors de fons i primer pla de la qual s'utilitzen per establir l'esquema de colors inicial. No pot ser nul.</param>
            private SimulacioVendaTabDgv(DesglosCompraExt desglosCompra)
            {
                vDesglosCompra = desglosCompra;
            }


            public event PropertyChangedEventHandler PropertyChanged;
            protected void OnPropertyChanged(string propietat)
            {
                var handler = PropertyChanged;
                if (handler != null)
                    handler(this, new PropertyChangedEventArgs(propietat));
            }

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

            internal static void OmpleDataGrid(decimal parts, decimal saltaParts)
            {
                _DgvCompresOriginals.SuspendLayout();

                if (_DgvCompresOriginals.DataSource == null)
                    _DgvCompresOriginals.DataSource = BsDgvCompresOriginals;

                // Primer posa a zero les partsUtilitzades.
                foreach (SimulacioVendaTabDgv fila in BsDgvCompresOriginals)
                {
                    fila.vDesglosCompra._PartsUtilitzades = 0;
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

                    if (nParts <= partsDisp)
                    {
                        fila.vDesglosCompra._PartsUtilitzades += nParts; // Més parts utilitzades, menys disponibles.
                        nParts = 0;
                    }
                    else 
                    {
                        fila.vDesglosCompra._PartsUtilitzades += partsDisp; // Més parts utilitzades, menys disponibles.
                        nParts -= partsDisp;
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
                }

                //_DgvCompresOriginals.Refresh();
                _DgvCompresOriginals.ClearSelection();
                _DgvCompresOriginals.ResumeLayout();
            }


            private static DataGridView _DgvCompresOriginals
            {
                get { return RefSimulacioVendaTab.dgvCompresOriginals; }
            }

            internal static BindingList<SimulacioVendaTabDgv> _LCompresOriginals
            {
                get { return LlistaCompresOriginals; }
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
}