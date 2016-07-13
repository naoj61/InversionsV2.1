using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Inversions
{
    public abstract partial class Producte : IComparable<Producte>
    {
        #region Variables

        public abstract TipusProducte _TipusProducte { get; }
        public abstract string _NomProducte { get; }
        public abstract string _TipusNomProducte { get; }

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
                    _PiG = compra.Import;
                    _PreuVenda = compra.Import;
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

            public double _PiGActual
            {
                get { return _Compra.Prod.pigValorat(Producte.DateTimeFinalDia.Today); }
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

        /// <summary>
        /// Estructura per assegurar-me que la data té l'hora del inici del dia.
        /// </summary>
        public struct DateTimeIniciDia
        {
            public DateTimeIniciDia(DateTime data)
            {
                vData = data.Date; // Deso la data amb hora 00:00:00
            }

            public DateTimeIniciDia(int any, int mes, int dia)
                : this(new DateTime(any, mes, dia))
            {
            }

            private readonly DateTime vData;

            public static DateTimeIniciDia Today
            {
                get { return new DateTimeIniciDia(DateTime.Today); }
            }

            public DateTime _Data
            {
                get { return vData; }
            }

            public  DateTimeFinalDia finalDia
            {
                get { return new DateTimeFinalDia(vData); }
            }

            public override string ToString()
            {
                return _Data.ToString();
            }
        }


        /// <summary>
        /// Estructura per assegurar-me que la data té l'hora del final del dia.
        /// </summary>
        public struct DateTimeFinalDia
        {
            public DateTimeFinalDia(DateTime data)
            {
                vData = data.Date.AddDays(1).AddTicks(-1); // Deso la data amb hora 23:59:59
            }

            public DateTimeFinalDia(int any, int mes, int dia)
                : this(new DateTime(any, mes, dia))
            {
            }


            private readonly DateTime vData;

            public DateTime _Data
            {
                get { return vData; }
            }

            public static DateTimeFinalDia Today
            {
                get { return new DateTimeFinalDia(DateTime.Today); }
            }
            
            public DateTimeFinalDia AddYears(int valor)
            {
                return new DateTimeFinalDia(vData.AddYears(valor));
            }

            public override string ToString()
            {
                return _Data.ToString();
            }
        }

        public enum TipusProducte : int
        {
            Tots = 0,
            Accions = 1,
            Fons = 2
        }


        public string _NomEmpresa
        {
            get { return Empresa == null ? null : Empresa.Nom; }
        }
        
        #endregion

        #region Atributs

        /// <summary>
        /// Torna les participacions actuals.
        /// </summary>
        public double _Participacions
        {
            get { return numParticipacionsEnData(DateTimeFinalDia.Today); }
        }


        /// <summary>
        /// És el valor de les participacions avui.
        /// </summary>
        public double _ValorActual
        {
            get { return valorEnCartera(Producte.DateTimeFinalDia.Today); }
        }
        
        #endregion


        #region *** Mètodes validats ***

        internal Moviment compraVenda(InversionsBDContext connexio, TipusMoviment tipusMoviment, DateTime data, double numParticipacions, double preuParticipacio, double? despeses, 
            string descripcio)
        {

            // Poso la hora actual. No tinc clar si hauria d'agafar l'ordre del Id en lloc de la data.
            DateTime dataHora = data.Date + DateTime.Now.TimeOfDay;

            var ultimaData = MovimentsProducte.Max(m => m.Data);

            // Valido que DateTime no sigui inferior a un moviment prèvi del mateix producte.
            if (ultimaData >= dataHora)
                throw new ApplicationException("La data no pot ser inferior a la data del últim moviment del producte. Data últim moviment: " +  ultimaData);

            if(connexio == null)
                throw new ArgumentNullException("connexio");

            if (numParticipacions <= 0)
                throw new ArgumentException("El valor ha de ser major de zero", "numParticipacions");

            if (preuParticipacio <= 0)
                throw new ArgumentException("El valor ha de ser major de zero", "preuParticipacio");

            Moviment moviment = new Moviment();
            moviment.TipusMoviment = tipusMoviment;
            moviment.ProdId = this.Id;
            moviment.Participacions = numParticipacions;
            moviment.PreuParticipacio = preuParticipacio;
            moviment.Despeses = despeses;
            moviment.Data = dataHora;
            moviment.Descripcio = String.IsNullOrEmpty(descripcio) ? null : descripcio;
            moviment.ProducteTraspasId = null;
            moviment.IdRefVenda = null;
            if (tipusMoviment == TipusMoviment.Compra)
                moviment.ValorCompraOriginal = numParticipacions * preuParticipacio - despeses.GetValueOrDefault();
            moviment.ProducteTraspasId = null;

            connexio.Moviments.Add(moviment);
            connexio.SaveChanges();

            return moviment;
        }

        internal void traspas(InversionsBDContext connexio, DateTime data, double numParticipacions, double preuParticipacio, string descripcio, 
            DateTime dataDesti, Producte prodDesti, double numParticipacionsDesti)
        {
            if(prodDesti == null)
                throw new ArgumentNullException("prodDesti");

            if (numParticipacionsDesti <= 0)
                throw new ArgumentException("El valor ha de ser major de zero", "numParticipacionsDesti");


            // Faig la venda del producte origen.
            var movVenda = this.compraVenda(connexio, TipusMoviment.Venda, data, numParticipacions, preuParticipacio, null, descripcio);

            // Faig la compra del producte destí.
            var movCompra = prodDesti.compraVenda(connexio, TipusMoviment.Compra, dataDesti, numParticipacionsDesti, 
                movVenda.Participacions * movVenda.PreuParticipacio / numParticipacionsDesti, null, descripcio);


            movVenda.ProducteTraspasId = prodDesti.Id; // Informo el prod desti en la venda.
            movCompra.ProducteTraspasId = this.Id;
            movCompra.IdRefVenda = movVenda.Id;
            movCompra.ValorCompraOriginal = valorCompraReal(numParticipacions);

            connexio.SaveChanges();
        }


        public static double PigValorat()
        {
            double pig = 0;

            foreach (var prod in Program.Sessio.Productes)
            {
                pig += prod.pigValorat(DateTimeFinalDia.Today);
            }

            return pig;
        }


        public static double PigValorat(int any)
        {
            double pig = 0;

            foreach (var prod in Program.Sessio.Productes)
            {
                pig += prod.pigValorat(new DateTimeIniciDia(any, 1, 1), new DateTimeFinalDia(any, 12, 31));
            }

            return pig;
        }

        public static double PigReal()
        {
            double pig = 0;

            foreach (var prod in Program.Sessio.Productes)
            {
                pig += prod.pigReal(DateTimeFinalDia.Today);
            }

            return pig;
        }

        public static double PigReal(int any)
        {
            double pig = 0;

            DateTimeFinalDia dataFi = new DateTimeFinalDia(any, 12, 31);

            foreach (var prod in Program.Sessio.Productes)
            {
                pig += prod.pigReal(dataFi.AddYears(-1), dataFi);
            }

            return pig;
        }


        public double pigValorat(int any)
        {
            double pig = 0;

            pig += pigValorat(new DateTimeIniciDia(any, 1, 1), new DateTimeFinalDia(any, 12, 31));

            return pig;
        }


        public double pigValorat(DateTimeIniciDia dataIni, DateTimeFinalDia dataFi)
        {
            return pigValorat(dataFi) - pigValorat(dataIni.finalDia);
        }


        /// <summary>
        /// PiG en una data, segons el valor de la valoració més recent anterior a la data.
        /// Inclou dividends.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double pigValorat(DateTimeFinalDia data)
        {
            var importCompres = MovimentsProducte.Where(w => w._EsCompra && w.Data < data._Data).Sum(s => (s.Participacions * s.PreuParticipacio) + s.Despeses.GetValueOrDefault());
            var importVendes = MovimentsProducte.Where(w => w._EsVenda && w.Data < data._Data).Sum(s => (s.Participacions * s.PreuParticipacio) - s.Despeses.GetValueOrDefault());
            var dividends = this.dividends(data);
            var valoracioActual = valorEnCartera(data);

            return importVendes + dividends + valoracioActual - importCompres;
        }


        /// <summary>
        /// Torna el valor de les participacions en cartera en una data determinada.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal double valorEnCartera(DateTimeFinalDia data)
        {
            double numPartEnCartera = numParticipacionsEnData(data);

            if (Program.EsZero(numPartEnCartera))
                return dividends(data);

            var compres = new Stack<Moviment>(MovimentsProducte.Where(w => w._EsCompra).OrderBy(o => o.Data));

            double preuUnitariEnData = valorParticipacio(data);
            double valorCarteraEnData = 0;
            while (true)
            {
                var compra = compres.Pop();

                if (Program.Compara(numPartEnCartera, compra.Participacions) > 0)
                {
                    valorCarteraEnData += compra.Participacions * preuUnitariEnData;
                    numPartEnCartera -= compra.Participacions;
                }
                else
                {
                    valorCarteraEnData += numPartEnCartera * preuUnitariEnData;
                    break;
                }
            }

            return valorCarteraEnData;
        }


        /// <summary>
        /// PiG entre dates, a partir de la venda més recent anterior a la dataFi.
        /// No inclou dividends.
        /// </summary>
        /// <param name="dataInici"></param>
        /// <param name="dataFi"></param>
        /// <returns></returns>
        public double pigReal(DateTimeFinalDia dataInici, DateTimeFinalDia dataFi)
        {
            var ini = pigReal(dataInici);
            var fi = pigReal(dataFi);
            return fi - ini;
        }

        /// <summary>
        /// PiG en una data, a partir de la venda més recent anterior a la data.
        /// No inclou dividends.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double pigReal(DateTimeFinalDia data)
        {
            // Troba la data de l'última venda real.
            var vendesReals = MovimentsProducte.Where(w => w._EsVendaReal && w.Data < data._Data).ToList();
            if (!vendesReals.Any())
                return 0;
            DateTime dataUltimaVenda = vendesReals.Max(m => m.Data);

            // Totes les vendes, inclou traspassos, a partir de la data de la última venda real.
            var vendes = MovimentsProducte.Where(w => w._EsVenda && w.Data <= dataUltimaVenda).OrderBy(o => o.Data).ToList();

            // Totes les compres, inclou traspassos, a partir de la data de la última venda real.
            var compres = new Queue<Moviment>(MovimentsProducte.Where(w => w._EsCompra && w.Data < dataUltimaVenda).OrderBy(o => o.Data));

            Moviment compra = null;
            double importCompres = 0;
            double numPartsCompresRestants = 0;
            foreach (var venda in vendes)
            {
                double numPartsVendesRestants = venda.Participacions;

                while (true)
                {
                    if (Program.EsZero(numPartsCompresRestants))
                    {
                        compra = compres.Dequeue();
                        numPartsCompresRestants = compra.Participacions;
                    }

                    if (Program.Compara(numPartsVendesRestants, numPartsCompresRestants) > 0)
                    {
                        importCompres += compra._ValorCompraOriginalPreuUnitari.GetValueOrDefault() * numPartsCompresRestants;
                        numPartsVendesRestants = Math.Round(numPartsVendesRestants - numPartsCompresRestants, 5);
                        //numPartsVendesRestants -= numPartsCompresRestants;
                        numPartsCompresRestants = 0;
                    }
                    else
                    {
                        importCompres += compra._ValorCompraOriginalPreuUnitari.GetValueOrDefault() * numPartsVendesRestants;
                        numPartsCompresRestants = Math.Round(numPartsCompresRestants - numPartsVendesRestants, 5);
                        //numPartsCompresRestants -= numPartsVendesRestants;
                        break;
                    }
                }
            }

            var importVendes = vendes.Where(w=>!w._EsTraspas).Sum(s => s.Participacions * s.PreuParticipacio - s.Despeses.GetValueOrDefault());

            return importVendes - importCompres;
        }

        internal double dividends(DateTimeFinalDia data)
        {
            return MovimentsProducte.Where(w => w._EsDividents && w.Data < data._Data).Sum(s => s.PreuParticipacio);
        }

        /// <summary>
        /// Calcula el valor real de compra de "participacionsAValorar".
        /// Valor real de compra de les participacions en cartera.
        /// Pels fons és el preu de compra original que és diferent al preu de compra en cas de traspàs.
        /// Per les accions és el preu de compra.
        /// </summary>
        /// <param name="participacionsAValorar">Si participacionsAValorar > participacions en cartera, torna error.</param>
        /// <returns></returns>
        private double valorCompraReal(double participacionsAValorar)
        {
            if (participacionsAValorar > numParticipacionsEnData(DateTimeFinalDia.Today))
                throw new ArgumentException("'participacionsAValorar' no pot ser un valor més gran que les participacions en cartera", "participacionsAValorar");

            double importCompra = 0;

            var vendes = new Queue<Moviment>(MovimentsProducte.Where(w => w._EsVenda).OrderBy(o => o.Data));
            var compres = new Queue<Moviment>(MovimentsProducte.Where(w => w._EsCompra).OrderBy(o => o.Data));

            if (vendes.Any() || compres.Any())
            {
                Moviment compra = null;
                double partsVendaRestants = 0;
                double partsCompraRestants = 0;

                do
                {
                    if (Program.SonIguals(partsCompraRestants, partsVendaRestants))
                    {
                        // SonIguals ha de ser el primer "if" perquè si hi ha algun decimal perdut entraria "per menor" que o "major que".

                        partsVendaRestants = 0;
                        partsCompraRestants = 0;
                        if (compres.Any())
                        {
                            compra = compres.Dequeue();
                            partsCompraRestants = compra.Participacions;
                        }
                        else
                        {
                            compra = null;
                            break;
                        }
                    }
                    else if (partsCompraRestants < partsVendaRestants)
                    {
                        partsVendaRestants -= partsCompraRestants;
                        if (compres.Any())
                        {
                            compra = compres.Dequeue();
                            partsCompraRestants = compra.Participacions;
                        }
                        else
                        {
                            partsCompraRestants = 0;
                            break;
                        }
                    }
                    else if (partsCompraRestants > partsVendaRestants)
                    {
                        partsCompraRestants -= partsVendaRestants;
                        if (vendes.Any())
                        {
                            Moviment venda = vendes.Dequeue();
                            partsVendaRestants = venda.Participacions;
                        }
                        else
                        {
                            partsVendaRestants = 0;
                            break;
                        }
                    }
                } while (true);


                while (compra != null && participacionsAValorar > 0)
                {
                    Debug.Assert(compra.ValorCompraOriginal.HasValue, "Ha de tenir valor");

                    double parts = participacionsAValorar > partsCompraRestants ? partsCompraRestants : participacionsAValorar;

                    importCompra += (compra.ValorCompraOriginal.GetValueOrDefault() / compra.Participacions * parts);

                    participacionsAValorar -= parts;

                    if (compres.Any())
                    {
                        compra = compres.Dequeue();
                        partsCompraRestants = compra.Participacions;
                    }
                    else
                        break;
                }
            }

            return Math.Round(importCompra, 5);
        }


        /// <summary>
        /// Torna les participacions en una data determinada.
        /// </summary>
        /// <param name="data">Si null data d'avui</param>
        /// <returns></returns>
        public double numParticipacionsEnData(DateTimeFinalDia data)
        {
            List<Moviment> movs = MovimentsProducte.Where(w => w.Data <= data._Data).ToList();

            double result = 0;
            if (movs.Any())
            {
                var compra = movs.Where(w => w.TipusMoviment == TipusMoviment.Compra).Sum(s => s.Participacions);
                var venda = movs.Where(w => w.TipusMoviment == TipusMoviment.Venda).Sum(s => s.Participacions);

                result = Math.Round(compra - venda, 6);
            }

            return result;
        }


        /// <summary>
        /// Torna el valor de la participació en una data determinada o la inmediatament inferior.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private double valorParticipacio(DateTimeFinalDia data)
        {
            var movs = Valoracions.
                Where(w => w.Data <= data._Data).Select(s => new { Data = s.Data, PreuParticipacio = s.PreuParticipacio }).
                Union(MovimentsProducte.
                    Where(w => w.Data <= data._Data && w.Participacions > 0).Select(s => new { Data = s.Data, PreuParticipacio = s._PreuParticipacio })).
                OrderBy(o => o.Data);

            var mov = movs.Any() ? movs.OrderBy(o => o.Data).Last() : null;

            return mov == null ? 0 : mov.PreuParticipacio;
        }


        #endregion *** Mètodes validats ***


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


            foreach (var divident in MovimentsProducte.Where(w => w.TipusMoviment == TipusMoviment.Dividends).OrderBy(o => o.Data))
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
