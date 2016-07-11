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
                get { return _Compra.Prod.pigPerDates(DateTimeFinalDia.Today); }
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
        /// Torna l'import total brut que han costat les participacions que hi ha comprades avui.
        /// No 'sinclouen despeses.
        /// </summary>
        public double _InversioActual
        {
            get { return invertitEnData(DateTimeFinalDia.Today); }
        }


        /// <summary>
        /// És el valor de les participacions avui.
        /// </summary>
        public double _ValorActual
        {
            get { return valorEnData(DateTimeFinalDia.Today); }
        }
        
        #endregion


        #region *** Mètodes validats ***

        /// <summary>
        /// PiG en una data, segons el valor de la valoració més recent anterior a la data. *******************
        /// Inclou Dividends.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double pigValorat(DateTimeFinalDia data)
        {
            double numPartEnCartera = numParticipacionsEnData(data);

            if (Program.EsZero(numPartEnCartera))
                return pigReal(data, true);

            var compres = new Stack<Moviment>(MovimentsProducte.Where(w => w._EsCompra).OrderBy(o => o.Data));

            double preuUnitariEnData = valorParticipacio(data);
            double valorCarteraEnData = 0;
            while(numPartEnCartera > 0)
            {
                var compra = compres.Pop();

                if(numPartEnCartera > compra.Participacions)
                {
                    valorCarteraEnData += compra.Participacions * preuUnitariEnData - compra.ValorCompraOriginal.GetValueOrDefault();
                    numPartEnCartera -= compra.Participacions;
                }
                else
                {
                    valorCarteraEnData += numPartEnCartera * preuUnitariEnData -  compra.ValorCompraOriginal.GetValueOrDefault() / compra.Participacions * numPartEnCartera;
                    numPartEnCartera = 0;
                }
            }

            return pigReal(data, true) + valorCarteraEnData;
        }


        /// <summary>
        /// PiG entre dates, a partir de la venda més recent anterior a la dataFi.
        /// </summary>
        /// <param name="dataInici"></param>
        /// <param name="dataFi"></param>
        /// <param name="ambDividends"></param>
        /// <returns></returns>
        public double pigReal(DateTimeFinalDia dataInici, DateTimeFinalDia dataFi, bool ambDividends)
        {
            var ini = pigReal(dataInici, ambDividends);
            var fi = pigReal(dataFi, ambDividends);
            return fi - ini;
        }

        /// <summary>
        /// PiG en una data, a partir de la venda més recent anterior a la data.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="ambDividends"></param>
        /// <returns></returns>
        public double pigReal(DateTimeFinalDia data, bool ambDividends)
        {
            var vendes = MovimentsProducte.Where(w => w._EsVenda && w.Data < data._Data).OrderBy(o=>o.Data).ToList();
            
            if (!vendes.Any())
                return 0;


            var dataUltimaVenda = vendes.Last().Data;

            var compres = new Queue<Moviment>(MovimentsProducte.Where(w => w._EsCompra && w.Data < dataUltimaVenda).OrderBy(o=>o.Data));

            bool llegirCompra = true;
            Moviment compra = null;
            double importCompres = 0;
            foreach (var venda in vendes)
            {
                double numPartsVendesRestants = venda.Participacions;

                while (true)
                {
                    if (llegirCompra)
                    {
                        compra = compres.Dequeue();
                        llegirCompra = false;
                    }

                    if(numPartsVendesRestants > compra.Participacions)
                    {
                        numPartsVendesRestants -= compra.Participacions;
                        llegirCompra = true;
                        importCompres += compra.ValorCompraOriginal.GetValueOrDefault();
                    }
                    else
                    {
                        llegirCompra = Program.EsZero(compra.Participacions - numPartsVendesRestants);
                        importCompres += compra.ValorCompraOriginal.GetValueOrDefault() / compra.Participacions * numPartsVendesRestants;
                        break;
                    }
                }
            }

            var importVendes = vendes.Sum(s => s.Participacions * s.PreuParticipacio - s.Despeses.GetValueOrDefault());

            return importVendes - importCompres + MovimentsProducte.Where(w => w._EsDividents && w.Data < dataUltimaVenda).Sum(s => s.PreuParticipacio);
        }


        /// <summary>
        /// Calcula el valor real de compra de "participacionsAValorar".
        /// Valor real de compra de les participacions en cartera.
        /// Pels fons és el preu de compra original que és diferent al preu de compra en cas de traspàs.
        /// Per les accions és el preu de compra.
        /// </summary>
        /// <param name="participacionsAValorar">Si participacionsAValorar > participacions en cartera, torna error.</param>
        /// <returns></returns>
        public double valorCompraReal(double participacionsAValorar)
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
        public double valorParticipacio(DateTimeFinalDia data)
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
        /// Torna l'import total brut que han costat les participacions que tenia comprades en una data determinada.
        /// No 'sinclouen despeses.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double invertitEnData(DateTimeFinalDia data)
        {
            var parts = numParticipacionsEnData(data);
            double inversio = 0;
            foreach (Moviment moviment in MovimentsProducte.Where(w => w.TipusMoviment == TipusMoviment.Compra).OrderByDescending(o => o.Data))
            {
                var partMov = parts > moviment.Participacions ? moviment.Participacions : parts;
                inversio += (moviment.PreuParticipacio * partMov);

                if (parts == partMov)
                    break;

                parts -= partMov;
            }

            return inversio;
        }


        /// <summary>
        /// És el valor de les participacions comprades, en una data determinada.
        /// </summary>
        /// <param name="dataFi"></param>
        /// <returns></returns>
        public double valorEnData(DateTimeFinalDia dataFi)
        {
            return numParticipacionsEnData(dataFi) * valorParticipacio(dataFi);
        }


        #region ***** Nou PiG *****

        /// <summary>
        /// És el PiG del valor tant si s'ha venut com no.
        /// Torna PiG de l'any sencer. 
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        public double pigPerDates(int any)
        {
            return pigPerDates(new DateTimeIniciDia(any, 1, 1), new DateTimeFinalDia(any, 12, 31));
        }

        /// <summary>
        /// És la variació del valor tant si s'ha venut com no desde l'inici fins DataFi.
        /// Torna PiG generat entre dues dates.
        /// </summary>
        /// <param name="dataFi"></param>
        /// <returns></returns>
        public double pigPerDates(DateTimeFinalDia dataFi)
        {
            return pigPerDates(new DateTimeIniciDia(2000, 11, 11), dataFi);
        }

        /// <summary>
        /// És la variació del valor tant si s'ha venut com no entre dates.
        /// Torna PiG generat entre dues dates.
        /// </summary>
        /// <param name="dataInici"></param>
        /// <param name="dataFi"></param>
        /// <returns></returns>
        public double pigPerDates(DateTimeIniciDia dataInici, DateTimeFinalDia dataFi)
        {
            List<Moviment> movs = new List<Moviment>();

            var partI = numParticipacionsEnData(new DateTimeFinalDia(dataInici._Data));
            var valorPartI = valorParticipacio(new DateTimeFinalDia(dataInici._Data));

            // Simulo un moviment de compra de les participacions existents.
            movs.Add(new Moviment {Data = dataInici._Data, PreuParticipacio = valorPartI, Participacions = partI, TipusMoviment = TipusMoviment.Compra});

            foreach (var moviment in MovimentsProducte.Where(w => w.Data >= dataInici._Data && w.Data <= dataFi._Data))
            {
                movs.Add(moviment);
            }

            var partF = numParticipacionsEnData(dataFi);
            var valorPartF = valorParticipacio(dataFi);

            // Simulo un moviment de venda per deixar les participacions a cero.
            movs.Add(new Moviment {Data = dataFi._Data, PreuParticipacio = valorPartF, Participacions = partF, TipusMoviment = TipusMoviment.Venda});

            double pig = 0;
            foreach (var moviment in movs)
            {
                var v = moviment._EsCompra ? -moviment.Import : (moviment.Import - moviment.Despeses.GetValueOrDefault());
                pig += v;
            }

            return pig;
        }

        #endregion ***** Nou PiG *****


        /// <summary>
        /// Calcula les PiG d'un producte de les participacions actualment en cartera.
        /// </summary>
        /// <param name="nomesVenudes">No tracta els fons traspassats.</param>
        /// <returns></returns>
        public double pigActual(bool nomesVenudes = false)
        {
            double piG = 0;

            if (_Participacions > 0)
            {
                var participacions = _Participacions;
                double importCompres = 0;
                foreach (var compra in MovimentsProducte.Where(w => w._EsCompra).OrderByDescending(o => o.Data))
                {
                    if (nomesVenudes && compra._EsTraspas)
                        continue;

                    if (participacions > compra.Participacions)
                    {
                        importCompres += compra.Import + compra.Despeses.GetValueOrDefault();
                        participacions -= compra.Participacions;
                    }
                    else
                    {
                        importCompres += (participacions * compra._PreuParticipacio);
                        importCompres += (compra.Despeses.GetValueOrDefault() / compra.Participacions * participacions);
                        participacions = 0;
                    }

                    if (participacions <= 0)
                        break;
                }
                piG = Math.Round(_ValorActual - importCompres, 6);
            }

            return piG;
        }


        /// <summary>
        /// P i G del producte, inclou traspassos i dividents.
        /// </summary>
        /// <returns></returns>
        public double pigReal()
        {
            double pigCurt, pigLlarg, dividents;
            pigReal(false, null, out pigCurt, out pigLlarg, out dividents);

            return pigCurt + pigLlarg + dividents;
        }

        /// <summary>
        /// Calcula les PiG real d'un producte, no utilitza les participacions que estan en cartera.
        /// </summary>
        /// <param name="tributaIrpf">Indica si pel càlcul s'utilitzaran els traspassos de fons o no.</param>
        /// <param name="any">Any de la venda. Si null tots els anys.</param>
        /// <param name="pigCurt"></param>
        /// <param name="pigLlarg"></param>
        /// <param name="dividents"></param>
        public void pigReal(bool tributaIrpf, int? any, out double pigCurt, out double pigLlarg, out double dividents)
        {
            pigCurt = 0;
            pigLlarg = 0;
            dividents = 0;

            var vendes = MovimentsProducte.Where(w => w._EsVenda && (!tributaIrpf || !w._EsTraspas)).ToList();

            var dataUltimaVenda = vendes.Where(w => any == null || w.Data.Year == any).Select(s => s.Data).LastOrDefault();
            if (dataUltimaVenda == DateTime.MinValue)
                return; //No hi ha cap venda.

            vendes = vendes.Where(w => w.Data <= dataUltimaVenda).OrderBy(o => o.Data).ToList();
            if (!vendes.Any())
                return;


            var vendesX = vendes.Where(w => w.Data <= dataUltimaVenda).OrderBy(o => o.Data).GetEnumerator();
            var compresX = MovimentsProducte.Where(w => w._EsCompra && w.Data <= dataUltimaVenda).OrderBy(o => o.Data).GetEnumerator();

            bool vendaLlegida = vendesX.MoveNext();
            var venda = vendesX.Current;
            double participacionsVenudesRestants = venda.Participacions;

            compresX.MoveNext();
            var compra = compresX.Current;
            double participacionsCompradesRestants = compra.Participacions;

            //if(any.HasValue)
            //{
            //    //Salto els moviments que corresponen als anys anteriors.

            //    while(vendaLlegida && venda.Data.Year < any.Value)
            //    {
            //        while (participacionsVenudesRestants > 0)
            //        {
            //            if (participacionsVenudesRestants > participacionsCompradesRestants)
            //            {
            //                participacionsVenudesRestants -= compra.Participacions;
            //            }
            //            else
            //            {
            //                participacionsCompradesRestants = venda.Participacions;
            //                break;
            //            }

            //            compresX.MoveNext();
            //            participacionsCompradesRestants = compra.Participacions;
            //        }
            //        vendaLlegida = vendesX.MoveNext();
            //        participacionsVenudesRestants = venda.Participacions;
            //    }
            //}


            while (vendaLlegida)
            {
                bool esLlarPlaç = compra.Data <= venda.Data.AddYears(-1);
                double numParticipacionsCalcul;

                if (participacionsVenudesRestants > participacionsCompradesRestants)
                {
                    // Si les particip venudes que queden, son més que les d'aquesta compra, utilitzo totes les particip de la mateixa.
                    numParticipacionsCalcul = participacionsCompradesRestants;
                }
                else
                {
                    // Si les particip venudes que queden, son menys que les d'aquesta compra, utilitzo la resta de particip de la venda.
                    numParticipacionsCalcul = participacionsVenudesRestants;
                }


                if (!any.HasValue || any.Value == venda.Data.Year)
                {

                    double importCompra = numParticipacionsCalcul * compra._PreuParticipacio;
                    double importVenda = numParticipacionsCalcul * venda._PreuParticipacio;
                    double despesesCompra = compra.Despeses.GetValueOrDefault() / compra.Participacions * numParticipacionsCalcul;
                    double despesesVenda = venda.Despeses.GetValueOrDefault() / venda.Participacions * numParticipacionsCalcul;
                    double piG = importVenda - importCompra - despesesVenda - despesesCompra;

                    if (esLlarPlaç)
                        pigLlarg += piG;
                    else
                        pigCurt += piG;
                }
                participacionsVenudesRestants -= numParticipacionsCalcul; // Resto les particip d'aquesta compra del total de particip venudes.
                participacionsCompradesRestants -= numParticipacionsCalcul; // Resto les particip d'aquesta compra del total de particip venudes.

                if (Math.Abs(participacionsVenudesRestants) < .0001)
                {
                    vendaLlegida = vendesX.MoveNext();
                    venda = vendesX.Current;
                    participacionsVenudesRestants = venda.Participacions;
                }

                if (Math.Abs(participacionsCompradesRestants) < .0001)
                {
                    compresX.MoveNext();
                    compra = compresX.Current;
                    participacionsCompradesRestants = compra.Participacions;
                }
            }

            if (any.HasValue)
                dividents = MovimentsProducte.Where(w => w._EsDividents && w.Data.Year == venda.Data.Year).Sum(s => s.Import);
            else
                dividents = MovimentsProducte.Where(w => w._EsDividents).Sum(s => s.Import);
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
