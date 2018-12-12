using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using Comuns;

namespace Inversions
{
    public abstract partial class Producte : IComparable<Producte>
    {
        #region Variables

        public abstract TipusProducte _TipusProducte { get; }
        public abstract string _NomProducte { get; set;}
        public abstract string _TipusNomProducte { get; }
        public abstract Mercat _Mercat { get; set; }
        public abstract string _NomMercat { get; }
        public abstract string _Isin { get; }
        public abstract string _Descripcio { get; }

        public IEnumerable<Moviment> MovimentsProducteUsuari
        {
            get { return this.Moviments.Where(w => w.UsuariId == Usuari.Seleccionat.Id); }
        }

        public struct PiGPerCompra
        {
            public PiGPerCompra(Moviment compra, Moviment venda, double participacions, bool hisenda)
                : this()
            {
                _Hisenda = hisenda;
                _Compra = compra;
                _Venda = venda;
                _DataCompra = compra.Data;

                if (compra.TipusMoviment == TipusMoviment.Dividends)
                {
                    _PiG = compra.ImportNet;
                    _PreuVenda = compra.ImportNet;
                }
                else
                {
                    _DataVenda = venda == null ? (DateTime?)null : venda.Data;
                    _Participacions = participacions;
                    _PreuUnitariCompra = compra._PreuParticipacio;
                    _PreuUnitariVenda = venda == null ? 0 : venda._PreuParticipacio;
                    _PreuCompra = participacions * compra._PreuParticipacio;
                    _PreuVenda = venda == null ? 0 : participacions * venda._PreuParticipacio;
                    //_Despeses = (compra.Despeses.GetValueOrDefault(0) / compra.Participacions * participacions) + (venda == null ? 0 : (venda.Despeses.GetValueOrDefault(0) / venda.Participacions * participacions));
                    _DespesesC = (compra.Despeses.GetValueOrDefault(0) / compra.Participacions * participacions);
                    _DespesesV = (venda == null ? 0 : (venda.Despeses.GetValueOrDefault(0) / venda.Participacions * participacions));
                    _PiG = venda == null ? 0 : ((participacions * venda._PreuParticipacio) - (participacions * compra._PreuParticipacio) - (_DespesesC + _DespesesV));
                }
                ImpAcc += _PiG;
                _PiGAcumulat = ImpAcc;
            }

            private static double ImpAcc = 0;

            public string _Moviment
            {
                get { return _Compra.TipusMoviment.ToString(); }
            }

            public DateTime _DataCompra { get; private set; }
            public DateTime? _DataVenda { get; private set; }
            public double _Participacions { get; private set; }
            public Moviment _Compra { get; private set; }
            public Moviment _Venda { get; private set; }
            public double _PreuUnitariCompra { get; private set; }
            public double _PreuUnitariVenda { get; private set; }
            public double _PreuCompra { get; private set; }
            public double _PreuVenda { get; private set; }
            public double _DespesesC { get; private set; }
            public double _DespesesV { get; private set; }
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
                get { return _DataVenda.HasValue && _DataCompra.AddYears(1) <= _DataVenda.Value; }
            }

            //public double _PiGActual
            //{
            //    get { return _Compra.Prod.pigValorat(DateTimeFinalDia.Today); }
            //}

            public string _Termini
            {
                get { return !_Hisenda ? null : _LlargPlaç ? "Llarg" : "Curt"; }
            }

            public static void InicialitzaAcumulat()
            {
                ImpAcc = 0;
            }
        }

        public enum TipusProducte
        {
            Tots = 0,
            Accions = 1,
            Fons = 2
        }

        #endregion


        #region Atributs

        public string _NomEmpresa
        {
            get { return Empresa == null ? null : Empresa.Nom; }
        }


        /// <summary>
        /// Torna les participacions actuals.
        /// </summary>
        public double _Participacions
        {
            get { return numParticipacionsEnData(DateTime.Today); }
        }


        /// <summary>
        /// És el valor de les participacions avui.
        /// </summary>
        public double _ValorActualEnCartera
        {
            get { return valorEnCartera(DateTime.MaxValue); }
        }
        
        #endregion


        internal double dividends(DateTime dataFi)
        {
            return MovimentsProducteUsuari.Where(w => w._EsDividents && w.Data < Utilitats.DataFinalDia(dataFi)).Sum(s => s.PreuParticipacio);
        }


        /// <summary>
        /// Torna les participacions en una data hora determinada. No te en compte els moviments del mateix dia fets en hora posterior.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal double numParticipacionsEnData(DateTime data)
        {
            data = Utilitats.DataFinalDia(data);
            var particComprades = MovimentsProducteUsuari.Where(w => w.Data <= data && w.TipusMoviment == TipusMoviment.Compra).Sum(s => s.Participacions);
            var particVenudes = MovimentsProducteUsuari.Where(w => w.Data <= data && w.TipusMoviment == TipusMoviment.Venda).Sum(s => s.Participacions);
            return particComprades - particVenudes;
        }


        /// <summary>
        /// Torna el valor de l'accio inmediatament anterior a la data hora actual.
        /// </summary>
        /// <returns></returns>
        internal double valorParticipacio()
        {
            return valorParticipacio(DateTime.Now);
        }


        /// <summary>
        /// Torna el valor de l'accio inmediatament anterior a la data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private double valorParticipacio(DateTime data)
        {
            var valoracions = ValoracionsProducte.Where(w => w.Data <= data).Select(val => new { val.Data, val.PreuParticipacio });

            var moviments = this.Moviments.Where(w => w.Data <= data && (w.TipusMoviment == TipusMoviment.Compra || w.TipusMoviment == TipusMoviment.Venda))
                .Select(mov => new { mov.Data, mov.PreuParticipacio });

            var tot = valoracions.Union(moviments).OrderBy(o => o.Data).ToList();

            if (tot.Any())
            {
                return tot.Last().PreuParticipacio;
            }

            //throw new ApplicationException("No hi ha cap moviment ni cap valoració disponibles.");
            return 0;
        }


        /// <summary>
        /// Torma una llista amb les Compres o "Traspassos compres" anteriors a la data hora, fins que cobreixin el número de participacions.
        /// </summary>
        /// <param name="dataHora">Data hora a partir de la que es buscaran els moviments de compravenda.</param>
        /// <param name="numParticipacions">Numero de participacions que es volen vendre.</param>
        /// <returns></returns>
        internal IEnumerable<MovimentCompra> compresAnteriors(DateTime dataHora, double? numParticipacions = null)
        {
            double participacions = numParticipacions.HasValue ? numParticipacions.Value : numParticipacionsEnData(dataHora);
            List<MovimentCompra> compresAmbParticipacio = new List<MovimentCompra>();

            if (participacions <= 0)
                return compresAmbParticipacio;

            // Troba suma participacions venudes anteriors a aquesta venda.
            var participVenudesAbans = MovimentsProducteUsuari
                .Where(w => w.Data < dataHora && w.TipusMoviment == TipusMoviment.Venda).Sum(s => (double?)s.Participacions) ?? 0;
            var trobadaPrimeraCompra = false;

            // Llegeix compres anteriors a la venda del producte ordenades per data creixent i vaig restant les participacions venudes anteriorment.
            var xx = MovimentsProducteUsuari.Where(w => w.Data < dataHora && w.TipusMoviment == TipusMoviment.Compra).OrderBy(o => o.Data).ToList();
            foreach (var compra in xx)
            {
                if (!trobadaPrimeraCompra)
                {
                    if (participVenudesAbans >= compra.Participacions)
                    {
                        // Son les participacions que ja estan venude per una venda anterior.
                        participVenudesAbans -= compra.Participacions;
                    }
                    else
                    {
                        var part = compra.Participacions - participVenudesAbans;
                        if (part > participacions)
                            part = participacions;
                        compresAmbParticipacio.Add(new MovimentCompra(compra, part));
                        participacions -= part;
                        trobadaPrimeraCompra = true;
                    }
                }
                else
                {
                    //double part = participacions > compra.Participacions ? participacions - compra.Participacions : participacions;
                    double part = participacions > compra.Participacions ? compra.Participacions : participacions;
                    compresAmbParticipacio.Add(new MovimentCompra(compra, part));
                    participacions -= part;
                }

                if (Utilitats.EsZero(participacions))
                    break;
            }

            if (participacions > 0.0000001)
                throw new ApplicationException("No hi ha prou participacions disponibles en cartera en aquesta data: " + dataHora.ToShortDateString() + " " + dataHora.ToShortTimeString());

            return compresAmbParticipacio;
        }


        internal static double Pig(DateTime? dataInici = null, DateTime? dataFinal = null)
        {
            return Pig(TipusProducte.Tots, dataInici.GetValueOrDefault(DateTime.MinValue), dataFinal.GetValueOrDefault(DateTime.MaxValue));
        }

        internal static double Pig(TipusProducte tipusProducte, DateTime dataFinal)
        {
            return Pig(tipusProducte, DateTime.MinValue, dataFinal);
        }

        public static double Pig(TipusProducte tipusProducte, int any)
        {
            DateTime dataInici = new DateTime(any, 1, 1);
            DateTime dataFinal = new DateTime(any, 12, 31);

            return Pig(tipusProducte, dataInici, dataFinal);
        }

        public static double Pig(TipusProducte tipusProducte, DateTime? dataInici = null, DateTime? dataFinal = null)
        {
            double pig = 0;

            if (tipusProducte == TipusProducte.Accions || tipusProducte == TipusProducte.Tots)
            {
                pig += Enumerable.Sum(Program.Sessio.ProdAccions, prodAccio => prodAccio.pig(dataInici, dataFinal));
            }

            if (tipusProducte == TipusProducte.Fons || tipusProducte == TipusProducte.Tots)
            {
                pig += Enumerable.Sum(Program.Sessio.ProdFons, prodAccio => prodAccio.pig(dataInici, dataFinal));
            }

            return pig;
        }


        /// <summary>
        /// PiG de tots els moviments del producte.
        /// </summary>
        /// <param name="dataInici"></param>
        /// <param name="dataFi"></param>
        /// <returns></returns>
        internal double pig(DateTime? dataInici = null, DateTime? dataFi = null)
        {
            return pig(dataInici.GetValueOrDefault(DateTime.MinValue), dataFi.GetValueOrDefault(DateTime.MaxValue));
        }


        /// <summary>
        /// Quant ha guanyat en un periode. (Vendes o vendesT dins el periode) + (participacions en cartera al final del periode).
        /// Preu compra --> Si s'ha comprat dins el periode, preu compra o compraT, sinò, valoració al inici del periode del les venudes i en cartera.
        /// Preu venda  --> Si s'ha venut dins el periode, preu venda o vendaT, sinò, valoració al final del periode.
        /// </summary>
        /// <param name="any">Del 1 de gener al 31 de desembre de l'any.</param>
        /// <returns></returns>
        internal double pig(int any)
        {
            return pig(new DateTime(any, 1, 1), new DateTime(any, 12, 31));
        }


        /// <summary>
        /// PiG dels moviments amb data igual o anterior a dataFinal.
        /// </summary>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        internal double pig(DateTime dataFinal)
        {
            return pig(DateTime.MinValue, dataFinal);
        }



        /// <summary>
        /// Calcula les PiG d'un producte per cada compra feta i torna una llista.
        /// </summary>
        /// <returns></returns>
        public List<PiGPerCompra> pigPerCompra()
        {
            /* Quan hi ha una venda Pot ser que no sigui total i que les accions venudes tinguin diferents preus de compra
             * Pot ser que una compra tingui zero, una o varies vendes.
             * Pot ser que una venda tingui una o varies compres.
            */

            var piG = new List<PiGPerCompra>();

            var compres = new Queue<Moviment>(MovimentsProducteUsuari.Where(w => w.TipusMoviment == TipusMoviment.Compra).OrderBy(o => o.Data));
            var vendes = new Queue<Moviment>(MovimentsProducteUsuari.Where(w => w.TipusMoviment == TipusMoviment.Venda).OrderBy(o => o.Data));

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

                        piG.Add(new PiGPerCompra(compra, venda, part, !venda._EsTraspas));

                        participacionsCompradesRestants = Math.Round(participacionsCompradesRestants - part, 4);
                        participacionsVenudesRestants = 0;

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

                        piG.Add(new PiGPerCompra(compra, venda, part, !venda._EsTraspas));

                        if (Math.Abs(part) < 1)
                        {
                        }

                        participacionsCompradesRestants = 0;
                        participacionsVenudesRestants = Math.Round(participacionsVenudesRestants - part, 4);

                        if (compres.Any())
                        {
                            compra = compres.Dequeue();
                            participacionsCompradesRestants = compra.Participacions;
                        }
                    }
                }
                else if (participacionsCompradesRestants > 0)
                {
                    //piG.Add(new PiG(compra, null, participacionsCompradesRestants,false));
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


            foreach (var divident in MovimentsProducteUsuari.Where(w => w.TipusMoviment == TipusMoviment.Dividends).OrderBy(o => o.Data))
            {
                piG.Add(new PiGPerCompra(divident, null, 0, true));
            }

            // Faig que acumuli les PiG en l'ordre real de la data del moviment.
            var piG2 = new List<PiGPerCompra>();
            PiGPerCompra.InicialitzaAcumulat();
            foreach (var g in piG.OrderBy(o => o._DataMovimentReal))
            {
                piG2.Add(new PiGPerCompra(g._Compra, g._Venda, g._Participacions, g._Hisenda));
            }

            return piG2;
        }


        /// <summary>
        /// PiG de tots els productes en un any. Vendes reals dins el periode.
        /// Preu compra --> Preu origen.
        /// Preu venda  --> Preu venda.
        /// </summary>
        /// <param name="tipusProducte"></param>
        /// <param name="any"></param>
        /// <returns></returns>
        public static double PigTributa(TipusProducte? tipusProducte = null, int? any = null)
        {
            tipusProducte = tipusProducte.HasValue ? tipusProducte : TipusProducte.Tots;

            double pig = 0;

            if (tipusProducte == TipusProducte.Accions || tipusProducte == TipusProducte.Tots)
            {
                pig += Enumerable.Sum(Program.Sessio.ProdAccions, prodAccio => prodAccio.pigTributa(any));
            }

            if (tipusProducte == TipusProducte.Fons || tipusProducte == TipusProducte.Tots)
            {
                pig += Enumerable.Sum(Program.Sessio.ProdFons, prodFons => prodFons.pigTributa(any));
            }

            return pig;
        }


        /// <summary>
        /// PiG que tributen en un periode. Vendes reals dins el periode.
        /// Preu compra --> Preu origen.
        /// Preu venda  --> Preu venda.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        public double pigTributa(int? any = null)
        {
            return any.HasValue 
                ? pigTributa(new DateTime(any.Value, 1, 1), new DateTime(any.Value, 12, 31)) 
                : pigTributa(DateTime.MinValue, DateTime.MaxValue);
        }


        /// <summary>
        /// PiG que tributen en un periode. Vendes reals dins el periode.
        /// Preu compra --> Preu origen.
        /// Preu venda  --> Preu venda.
        /// </summary>
        /// <param name="dataInici"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        private double pigTributa(DateTime dataInici, DateTime dataFinal)
        {
            var dInici = dataInici.Date; // Poso la d'inici hora a zero.
            var dFinal = Utilitats.DataFinalDia(dataFinal);

            var totalCompra = importCompra(dInici, dFinal);
            var totalVenda = importVenda(dInici, dFinal);

            double totalDividends = 0;
            double totalDespeses = 0;
            if (this is ProdAccions)
            {
                totalDespeses = calculaDespesesCompra(dInici, dFinal) + calculaDespesesVenda(dInici, dFinal);

                totalDividends = calculaDividents(dInici, dFinal);
            }

            return Math.Round((totalVenda - totalCompra ) + totalDividends - totalDespeses, 3);
        }

        /// <summary>
        /// Calcula la diferencia de compra/venda en l'any.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        internal double importCompra(int any)
        {
            return importCompra(new DateTime(any, 1, 1), Utilitats.DataFinalDia(new DateTime(any, 12, 31)));
        }


        /// <summary>
        /// Calcula la diferencia de compra/venda en l'any.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        internal double importVenda(int any)
        {
            return importVenda(new DateTime(any, 1, 1), Utilitats.DataFinalDia(new DateTime(any, 12, 31)));
        }


        /// <summary>
        /// Calcula la diferencia de compra/venda en el periode.
        /// </summary>
        /// <param name="dInici"></param>
        /// <param name="dFinal"></param>
        /// <returns></returns>
        private double importVenda(DateTime dInici, DateTime dFinal)
        {
            return MovimentsProducteUsuari.
                Where(w => w.Data >= dInici && w.Data <= dFinal && w._EsVendaReal).
                Sum(s => s.Participacions * s.PreuParticipacio);
        }


        /// <summary>
        /// Calcula les despeses per compra/venda en l'any.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        internal double calculaDespesesCompra(int any)
        {
            return calculaDespesesCompra(new DateTime(any, 1, 1), Utilitats.DataFinalDia(new DateTime(any, 12, 31)));
        }


        /// <summary>
        /// Calcula les despeses per compra en el periode.
        /// </summary>
        /// <param name="dInici"></param>
        /// <param name="dFinal"></param>
        /// <returns></returns>
        private double calculaDespesesCompra(DateTime dInici, DateTime dFinal)
        {
            // Calcula despeses i dividents.
            double totalDespeses = 0;
            
            foreach (var venda in MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w._EsVendaReal).ToList())
            {              
                // Despeses de la compra.
                totalDespeses += venda.compresAnteriors()
                    .Sum(movCompra => movCompra._Moviment.Despeses.GetValueOrDefault() * movCompra._ParticipacionsDisponibles / movCompra._Moviment.Participacions);
            }

            return totalDespeses;
        }



        /// <summary>
        /// Calcula les despeses per compra/venda en l'any.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        internal double calculaDespesesVenda(int any)
        {
            return calculaDespesesVenda(new DateTime(any, 1, 1), Utilitats.DataFinalDia(new DateTime(any, 12, 31)));
        }


        /// <summary>
        /// Calcula les despeses per venda en el periode.
        /// </summary>
        /// <param name="dInici"></param>
        /// <param name="dFinal"></param>
        /// <returns></returns>
        private double calculaDespesesVenda(DateTime dInici, DateTime dFinal)
        {
            // Calcula despeses i dividents.
            double totalDespeses = 0;

            foreach (var venda in MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w._EsVendaReal).ToList())
            {
                // Despeses de la venda.
                totalDespeses += venda.Despeses.GetValueOrDefault();
            }

            return totalDespeses;
        }

        /// <summary>
        /// Calcula els dividents en l'any.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        internal double calculaDividents(int any)
        {
            return calculaDividents(new DateTime(any, 1, 1), Utilitats.DataFinalDia(new DateTime(any, 12, 31)));
        }

        /// <summary>
        /// Calcula els dividents en el periode.
        /// </summary>
        /// <param name="dInici"></param>
        /// <param name="dFinal"></param>
        /// <returns></returns>
        private double calculaDividents(DateTime dInici, DateTime dFinal)
        {
            return MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w._EsDividents).Sum(s => s.PreuParticipacio);
        }


        /// <summary>
        /// Indica si un producte ha de tributar en un any deterninat.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        internal bool tributaAquestAny(int any)
        {
            return MovimentsProducteUsuari.Any(w => w.Data.Year == any && (w._EsVendaReal || w._EsDividents));
        }


        /// <summary>
        /// PiG de les perticipacions en cartera a la data. Vendes reals dins el periode.
        /// Preu compra --> Preu compra.
        /// Preu venda  --> Valoració actual.
        /// </summary>
        /// <param name="dataFinal">Si null, dataFinal=DateTime.MaxValue.</param>
        /// <param name="preuParticipacio">Si null, preu de la participació en la data "dataFinal"</param>
        /// <returns></returns>
        public double pigEnCartera(DateTime? dataFinal = null, double? preuParticipacio = null)
        {
            var dFinal = Utilitats.DataFinalDia(dataFinal);

            var participacions = numParticipacionsEnData(dFinal);

            if (Utilitats.EsZero(participacions))
                return 0;

            var compresAnt = compresAnteriors(dFinal, participacions);

            double totalCompres = compresAnt.Sum(compra => compra._ParticipacionsDisponibles * compra._Moviment.PreuParticipacio + compra._Moviment.Despeses.GetValueOrDefault());

            double valorPartic = preuParticipacio.HasValue ? _Participacions * preuParticipacio.Value : valorEnCartera(dFinal);

            return valorPartic - totalCompres;
        }


        /// <summary>
        /// Torna el valor de les participacions en cartera en una data determinada.
        /// </summary>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        internal double valorEnCartera(DateTime? dataFinal = null)
        {
            var dFinal = Utilitats.DataFinalDia(dataFinal);

            var participacions = numParticipacionsEnData(dFinal);

            if (Utilitats.EsZero(participacions))
                return 0;

            return participacions * valorParticipacio(dFinal);
        }


        /// <summary>
        /// Torna les valoracions entre les dates, ponderades si s'indica.
        /// </summary>
        /// <param name="ponderar"></param>
        /// <param name="dataInici"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        internal Dictionary<Valoracio, double> valoracionsPonderades(bool ponderar, DateTime dataInici, DateTime dataFinal)
        {
            var valsProd = ValoracionsProducte
                .Where(w => w.Data >= dataInici && w.Data <= dataFinal)
                .OrderBy(o => o.Data)
                .ToList();

            if (valsProd.Any())
            {
                if (!ponderar)
                    // Sense ponderar.
                    return valsProd.ToDictionary(x => x, x => x.PreuParticipacio);
                const double pond = 10;
                double valorPonderacio = pond / valsProd.First().PreuParticipacio;
                return valsProd.ToDictionary(x => x, x => (x.PreuParticipacio * valorPonderacio) - pond);
            }

            return null;
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

        public int CompareTo(Producte other)
        {
            if (Id < other.Id)
                return -1;
            return Id > other.Id ? 1 : 0;
        }

        #endregion
    }
}
