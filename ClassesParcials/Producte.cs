using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inversions
{
    public abstract partial class Producte : IComparable<Producte>
    {
        public struct PiG
        {
            public PiG(Moviment compra, Moviment venda, double participacions, bool hisenda)
                : this()
            {
                _Hisenda = hisenda;
                _Compra = compra;
                _Venda = venda;
                _DataCompra = compra.Data;

                if (compra.TipusMoviment == TipusMoviment.Dividends)
                {
                    _PiG = compra.Import;
                    _PreuVenda = compra.Import;
                }
                else
                {
                    _DataVenda = venda == null ? (DateTime?) null : venda.Data;
                    _Participacions = participacions;
                    _PreuUnitariCompra = compra._PreuParticipacio;
                    _PreuUnitariVenda = venda == null ? 0 : venda._PreuParticipacio;
                    _PreuCompra = participacions * compra._PreuParticipacio;
                    _PreuVenda = venda == null ? 0 : participacions * venda._PreuParticipacio;
                    _Despeses = compra.Despeses.GetValueOrDefault(0) + (venda == null ? 0 : venda.Despeses.GetValueOrDefault(0));
                    _PiG = venda == null ? 0 : ((participacions * venda._PreuParticipacio) - (participacions * compra._PreuParticipacio) - _Despeses);

                }
                ImpAcc += _PiG;
                _PiGAcumulat = ImpAcc;
            }


            private static double ImpAcc = 0;
            public string _Moviment { get { return _Compra.TipusMoviment.ToString(); } }
            public DateTime _DataCompra { get; private set; }
            public DateTime? _DataVenda { get; private set; }
            public double _Participacions { get; private set; }
            public Moviment _Compra { get; private set; }
            public Moviment _Venda { get; private set; }
            public double _PreuUnitariCompra { get; private set; }
            public double _PreuUnitariVenda { get; private set; }
            public double _PreuCompra { get; private set; }
            public double _PreuVenda { get; private set; }
            public double _Despeses { get; private set; }
            public double _PiG { get; private set; }
            public bool _Hisenda { get; private set; }
            public double _PiGAcumulat { get; private set; }


            /// <summary>
            /// Si és un traspà torna null.
            /// </summary>
            public DateTime? _DataVendaReal
            {
                get { return _Hisenda && _DataVenda.HasValue ? _DataVenda : null; }
            }

            /// <summary>
            /// Si hi ha data venda la torna sinò, torna la data compra.
            /// </summary>
            public DateTime? _DataMovimentReal
            {
                get { return _DataVenda.HasValue ? _DataVenda : _DataCompra; }
            }


            /// <summary>
            /// Si és una venda torna null
            /// </summary>
            public DateTime? _DataTraspas
            {
                get { return !_Hisenda && _DataVenda.HasValue ? _DataVenda : null; }
            }

            public bool _LlargPlaç
            {
                get
                {
                    return _DataVenda.HasValue && _DataCompra.AddYears(1) <= _DataVenda.Value;
                }
            }

            public string _Termini
            {
                get { return !_Hisenda ? null : _LlargPlaç ? "Llarg" : "Curt"; }
            }

            public static void InicialitzaAcumulat()
            {
                ImpAcc = 0;
            }
        }

        public enum TipusProducte : int
        {
            Tots = 0,
            Accions = 1,
            Fons = 2
        }

        public abstract TipusProducte _TipusProducte { get; }
        public abstract string _NomProducte { get; }
        public abstract string _TipusNomProducte { get; }

        public string _NomEmpresa
        {
            get { return Empresa == null ? null : Empresa.Nom; }
        }


        /// <summary>
        /// Torna les participacions actuals.
        /// </summary>
        public double _Participacions
        {
            get
            {
                if (MovimentsProducte.Count == 0)
                    return 0;

                var compra = MovimentsProducte.Where(w => w.TipusMoviment == TipusMoviment.Compra).Sum(s => s.Participacions);
                var venda = MovimentsProducte.Where(w => w.TipusMoviment == TipusMoviment.Venda).Sum(s => s.Participacions);

                return compra - venda;
            }
        }


        /// <summary>
        /// Torna les participacions en una data determinada.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double participacions(DateTime data)
        {
            var compra = MovimentsProducte.Where(w => w.Data <= data && w.TipusMoviment == TipusMoviment.Compra).Sum(s => s.Participacions);
            var venda = MovimentsProducte.Where(w => w.Data <= data && w.TipusMoviment == TipusMoviment.Venda).Sum(s => s.Participacions);

            return compra - venda;
        }


        public double _ImportTotalCompres
        {
            get
            {
                if (MovimentsProducte.Count == 0)
                    return 0;

                return MovimentsProducte.Where(moviment => moviment.TipusMoviment == TipusMoviment.Compra).Sum(moviment => moviment.Import);
            }
        }

        public double _ImportTotalVendes
        {
            get
            {
                if (MovimentsProducte.Count == 0)
                    return 0;

                return MovimentsProducte.Where(moviment => moviment.TipusMoviment == TipusMoviment.Venda).Sum(moviment => moviment.Import);
            }
        }

        public double _ImportTotalDividends
        {
            get
            {
                if (MovimentsProducte.Count == 0)
                    return 0;

                return MovimentsProducte.Where(moviment => moviment.TipusMoviment == TipusMoviment.Dividends).Sum(moviment => moviment.Import);
            }
        }

        public double _ImportTotalDespeses
        {
            get
            {
                if (MovimentsProducte.Count == 0)
                    return 0;

                return MovimentsProducte.Sum(moviment => moviment.Despeses).GetValueOrDefault(0);
            }
        }

        public double _InversioActual
        {
            get
            {
                double numParticipacionsVenudes = MovimentsProducte.Where(w => w.TipusMoviment == TipusMoviment.Venda).Sum(s => s.Participacions);
                double inversioActual = 0;
                foreach (Moviment moviment in MovimentsProducte.Where(w => w.TipusMoviment == TipusMoviment.Compra).OrderBy(o => o.Data))
                {
                    if (numParticipacionsVenudes >= moviment.Participacions)
                        numParticipacionsVenudes = Math.Round(numParticipacionsVenudes - moviment.Participacions, 6);
                    else
                    {
                        double part = moviment.Participacions - numParticipacionsVenudes;
                        numParticipacionsVenudes = 0;

                        inversioActual += part * moviment._PreuParticipacio;
                    }
                }

                return inversioActual;
            }
        }

        public double _ValorActual
        {
            get { return Valoracions.Count == 0 ? 0 : _Participacions * Valoracions.Last().Import; }
        }

        public double _PiGTotal(bool nomesVenut)
        {
            return _PiG(nomesVenut).Sum(s => s._PiG);
        }

        public List<PiG> _PiG(bool nomesVenut)
        {
            /* Quan hi ha una venda Pot ser que no sigui total i que les accions venudes tinguin diferents preus de compra
             * Pot ser que una compra tingui zero, una o varies vendes.
             * Pot ser que una venda tingui una o varies compres.
            */

            var piG = new List<PiG>();

            var compres = new Queue<Moviment>(MovimentsProducte.Where(w => w.TipusMoviment == TipusMoviment.Compra).OrderBy(o => o.Data));
            var vendes = new Queue<Moviment>(MovimentsProducte.Where(w => w.TipusMoviment == TipusMoviment.Venda).OrderBy(o => o.Data));

            if (!compres.Any())
            {
                if (vendes.Any())
                    throw new ApplicationException("Error. Hi ha vendes, però ni hi ha cap compra.");

                // No hi ha moviments.
                return piG;
            }


            var compra = compres.Dequeue();
            double participacionsCompradesRestants = compra.Participacions;

            Moviment venda = null;
            double participacionsVenudesRestants = 0;
            if (vendes.Any())
            {
                venda = vendes.Dequeue();
                participacionsVenudesRestants = venda.Participacions;
            }

            double importPiG = 0;

            do
            {
                if (participacionsCompradesRestants > 0 && participacionsVenudesRestants > 0)
                {
                    if (compra.Data > venda.Data)
                        throw new ApplicationException("Error. La data de compra no pot ser mes gran que la de venda.");


                    if (participacionsVenudesRestants <= participacionsCompradesRestants)
                    {
                        // Hi ha mes participacions comprades que les que queden per vendre.

                        var part = participacionsVenudesRestants;

                        if (!nomesVenut || !venda._EsTraspas)
                        {
                            importPiG += (part * venda._PreuParticipacio) - (part * compra._PreuParticipacio);
                            piG.Add(new PiG(compra, venda, part, !venda._EsTraspas));
                        }

                        participacionsCompradesRestants = Math.Round(participacionsCompradesRestants - part, 4);
                        participacionsVenudesRestants = 0;
                        importPiG = 0;

                        if (Math.Abs(participacionsCompradesRestants) < 0.0001) // Equival a participacionsCompradesRestants == 0
                        {
                            if (compres.Any())
                            {
                                compra = compres.Dequeue();
                                participacionsCompradesRestants = compra.Participacions;
                            }
                        }

                        if (vendes.Any())
                        {
                            venda = vendes.Dequeue();
                            participacionsVenudesRestants = venda.Participacions;
                        }
                    }
                    else
                    {
                        // Hi ha mes participacions per vendre que les comprades en aquest moviment.

                        var part = participacionsCompradesRestants;

                        if (!nomesVenut || !venda._EsTraspas)
                        {
                            importPiG += (part * venda._PreuParticipacio) - (part * compra._PreuParticipacio);
                            piG.Add(new PiG(compra, venda, part,  !venda._EsTraspas));
                        }

                        if(Math.Abs(part) < 1)
                        { }

                        participacionsCompradesRestants = 0;
                        participacionsVenudesRestants = Math.Round(participacionsVenudesRestants - part, 4);
                        importPiG = 0;

                        if (compres.Any())
                        {
                            compra = compres.Dequeue();
                            participacionsCompradesRestants = compra.Participacions;
                        }
                    }
                }
                else if (participacionsCompradesRestants > 0)
                {
                    if (nomesVenut)
                        break;

                    //piG.Add(new PiG(compra, null, participacionsCompradesRestants,false));
                    importPiG = 0;
                    participacionsCompradesRestants = 0;

                    if (compres.Any())
                    {
                        compra = compres.Dequeue();
                        participacionsCompradesRestants = compra.Participacions;
                    }
                }
                else if (participacionsVenudesRestants > 0)
                {
                    throw new ApplicationException("Error. No hauria d'entrar aquí.");
                }
            } while (compres.Any() || vendes.Any() || participacionsVenudesRestants > 0);

            //if (!nomesVenut && participacionsCompradesRestants > 0)
            //{
            //    // Valoro les participacions que tinc actualment segons l'última valoració introduida.
            //    piG.Add(new PiG(compra, null, participacionsCompradesRestants, false));
            //}


            foreach (var divident in MovimentsProducte.Where(w => w.TipusMoviment == TipusMoviment.Dividends).OrderBy(o => o.Data))
            {
                piG.Add(new PiG(divident, null, 0, true));
            }

            // Faig que acumuli les PiG en l'ordre real de la data del moviment.
            var piG2 = new List<PiG>();
            PiG.InicialitzaAcumulat();
            foreach (var g in piG.OrderBy(o => o._DataMovimentReal))
            {
                piG2.Add(new PiG( g._Compra, g._Venda, g._Participacions, g._Hisenda));
            }

            return piG2;
        }



        #region Overrides

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Producte a, Producte b)
        {
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

            return a.Id == b.Id;
        }

        public static bool operator !=(Producte a, Producte b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Producte))
                return false;

            return this == (Producte) obj;
        }

        public override string ToString()
        {
            return _NomProducte;
        }

        #endregion

        public int CompareTo(Producte other)
        {
            if (Id < other.Id)
                return -1;
            return Id > other.Id ? 1 : 0;
        }
    }
}
