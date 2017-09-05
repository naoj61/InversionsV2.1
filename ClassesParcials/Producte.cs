using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Windows.Forms;

namespace Inversions
{
    public abstract partial class Producte : IComparable<Producte>
    {
        #region Variables

        public abstract TipusProducte _TipusProducte { get; }
        public abstract string _NomProducte { get; }
        public abstract string _TipusNomProducte { get; }

        public IEnumerable<Moviment> MovimentsProducteUsuari
        {
            get { return MovimentsProducte.Where(w => w.IdUsuari == Usuari.Seleccionat.Id); }
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

            public double _PiGActual
            {
                get { return _Compra.Prod.pigValorat(DateTimeFinalDia.Today); }
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
            get { return valorEnCartera(DateTimeFinalDia.Today); }
        }
        
        #endregion


        #region *** Mètodes validats ***

        /* SELECT Participacions, PreuParticipacio, CanviAplicat, Despeses, ValorCompraOriginal,
            (Participacions * PreuParticipacio + ISNULL(Despeses,0)), ValorCompraOriginal - (Participacions * PreuParticipacio + Despeses) FROM [Moviments] 
            WHERE Despeses is not null and TipusMoviment = 0
           UPDATE [Moviments] set ValorCompraOriginal = (Participacions * PreuParticipacio + Despeses) WHERE Despeses is not null and TipusMoviment = 0 AND ValorCompraOriginal <> (Participacions * PreuParticipacio + Despeses)
         */

        internal Moviment compraVenda(InversionsBDContext connexio, TipusMoviment tipusMoviment, DateTime data, double numParticipacions, double preuParticipacio, double canviAplicat, 
            double? despeses, string descripcio, bool afegeigPreuAValoracions = true)
        {
            // Poso la hora actual. No tinc clar si hauria d'agafar l'ordre del Id en lloc de la data.
            DateTime dataHora = data.Date + DateTime.Now.TimeOfDay;

            if (MovimentsProducteUsuari.Any())
            {
                var ultimaData = MovimentsProducteUsuari.Max(m => m.Data);

                // Valido que DateTime no sigui inferior a un moviment prèvi del mateix producte.
                if (ultimaData >= dataHora)
                {
                    if (MessageBox.Show("La data és inferior a la data del últim moviment del producte.\nVols continuar?", "Avís", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        throw new ApplicationException("Operació cancelada");
                    //throw new ApplicationException("La data no pot ser inferior a la data del últim moviment del producte. Data últim moviment: " + ultimaData);
                }
            }

            if(connexio == null)
                throw new ArgumentNullException("connexio");

            if (tipusMoviment != TipusMoviment.Dividends && numParticipacions <= 0)
                throw new ArgumentException("El valor ha de ser major de zero", "numParticipacions");

            //if (preuParticipacio <= 0)
            //    throw new ArgumentException("El valor ha de ser major de zero", "preuParticipacio");

            Moviment moviment = new Moviment();
            moviment.IdUsuari = Usuari.Seleccionat.Id;
            moviment.TipusMoviment = tipusMoviment;
            moviment.ProdId = this.Id;
            moviment.Participacions = numParticipacions;
            moviment.PreuParticipacio = preuParticipacio;
            moviment.CanviAplicat = canviAplicat;
            moviment.Despeses = despeses;
            moviment.Data = dataHora;
            moviment.Descripcio = String.IsNullOrEmpty(descripcio) ? null : descripcio;
            moviment.ProducteTraspasId = null;
            moviment.IdRefVenda = null;
            if (tipusMoviment == TipusMoviment.Compra)
                moviment.ValorCompraOriginal = numParticipacions * preuParticipacio + despeses.GetValueOrDefault();
            moviment.ProducteTraspasId = null;

            connexio.Moviments.Add(moviment);
            connexio.SaveChanges();

            if (afegeigPreuAValoracions)
            {
                // Crea una valoració amb el preu del moviment
                Valoracio val = Valoracions.SingleOrDefault(a => a.ProdId == this.Id && a.Data == dataHora.Date);
                if (val == null)
                {
                    try
                    {
                        Valoracio.Nova(connexio, this, dataHora, preuParticipacio);
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number != 2627) // Si Duplicate Key en Valoracions no fa cas
                            throw;
                    }
                }
                else
                    val.modifica(connexio, dataHora, preuParticipacio); 
            }

            return moviment;
        }

        internal void traspas(InversionsBDContext connexio, DateTime data, double numParticipacions, double preuParticipacio, double canviAplicat, string descripcio, 
            DateTime dataDesti, Producte prodDesti, double numParticipacionsDesti)
        {
            if(prodDesti == null)
                throw new ArgumentNullException("prodDesti");

            if (numParticipacionsDesti <= 0)
                throw new ArgumentException("El valor ha de ser major de zero", "numParticipacionsDesti");


            // Faig la venda del producte origen.
            var movVenda = this.compraVenda(connexio, TipusMoviment.Venda, data, numParticipacions, preuParticipacio, canviAplicat, null, descripcio);

            // Faig la compra del producte destí.
            var movCompra = prodDesti.compraVenda(connexio, TipusMoviment.Compra, dataDesti, numParticipacionsDesti, 
                movVenda.Participacions * movVenda.PreuParticipacio / numParticipacionsDesti, canviAplicat, null, descripcio);


            movVenda.ProducteTraspasId = prodDesti.Id; // Informo el prod desti en la venda.
            movCompra.ProducteTraspasId = this.Id;
            movCompra.IdRefVenda = movVenda.Id;
            movCompra.ValorCompraOriginal = valorCompraReal(numParticipacions);

            connexio.SaveChanges();
        }


        internal void splitContraSplit(InversionsBDContext connexio, TipusMoviment tipusMoviment, DateTime data, int factorConversor, double preuParticipacioAbans, double canviAplicat)
        {
            var preuParticipacioDespres = Math.Round(preuParticipacioAbans * factorConversor, 3);

            int numPartActual = (int) _Participacions;

            // *** Les participacions en les accions han de ser números entres. ***
            int numPartticipacionsDespresSplit;
            int numPartticipacionsRemanent;
            if (tipusMoviment == TipusMoviment.Split)
            {
                numPartticipacionsDespresSplit = (numPartActual * factorConversor);
                numPartticipacionsRemanent = 0;
            }
            else if (tipusMoviment == TipusMoviment.ContraSplit)
            {
                numPartticipacionsDespresSplit = numPartActual / factorConversor;
                numPartticipacionsRemanent = numPartActual %  factorConversor;
            }
            else
            {
                throw new ArgumentException("Moviment: " + tipusMoviment + "incorrecte. ha de ser 'Split' o 'ContraSplit'");
            }

            var numPartticipacionsAbansSplit = numPartActual - numPartticipacionsRemanent;

            double numPartNoVenudesPrimeraCompra;
            var movsCompra = compresAmbParticipacionsNoVenudes(out numPartNoVenudesPrimeraCompra).ToList();

            //// Venc accions remanents.
            double partPerVendre = numPartticipacionsRemanent;
            //foreach (var compra in movsCompra)
            //{
            //    if (partPerVendre > 0)
            //    {
            //        if (partPerVendre <= compra.Participacions)
            //        {
            //            var despeses = compra.Despeses.HasValue ? (double?) (compra.Despeses.Value / compra.Participacions * partPerVendre) : null;

            //            compraVenda(connexio, TipusMoviment.Venda, data, partPerVendre, preuParticipacioAbans, canviAplicat, -despeses, tipusMoviment.ToString(), false);

            //            break;
            //        }
            //        else
            //        {
            //            compraVenda(connexio, TipusMoviment.Venda, data, compra.Participacions, preuParticipacioAbans, canviAplicat, -compra.Despeses, tipusMoviment.ToString(), false);
            //            partPerVendre -= compra.Participacions;
            //        }
            //    }
            //    else
            //    {
            //        break;
            //    }
            //}

            //return;

            // Venc accions antiges per convertirles.
            double desAcum = 0;
            foreach (var compra in movsCompra)
            {
                var particCompra = compra.Participacions;

                if (partPerVendre > 0)
                {
                    if (partPerVendre <= particCompra)
                    {
                        var despeses = compra.Despeses.HasValue ? (double?)(compra.Despeses.Value / compra.Participacions * partPerVendre) : null;
                        desAcum += despeses.GetValueOrDefault();

                        compraVenda(connexio, TipusMoviment.Venda, data, partPerVendre, preuParticipacioAbans, canviAplicat, -despeses, tipusMoviment.ToString(), false);

                        particCompra -= partPerVendre;
                        partPerVendre = 0;
                    }
                    else
                    {
                        var despeses = compra.Despeses.HasValue ? (double?)(compra.Despeses.Value / compra.Participacions * particCompra) : null;
                        desAcum += despeses.GetValueOrDefault();

                        compraVenda(connexio, TipusMoviment.Venda, data, particCompra, preuParticipacioAbans, canviAplicat, -despeses, tipusMoviment.ToString(), false);
                        particCompra -= 0;
                        partPerVendre -= particCompra;
                    }
                }

                if (particCompra > 0)
                {
                    var despeses = compra.Despeses.HasValue ? (double?)(compra.Despeses.Value / compra.Participacions * particCompra) : null;
                    desAcum += despeses.GetValueOrDefault();
                    
                    compraVenda(connexio, TipusMoviment.Venda, data, particCompra, compra.PreuParticipacio, compra.CanviAplicat, -despeses, tipusMoviment.ToString(), false);
                }
            }

            // Compro noves accions.
            compraVenda(connexio, TipusMoviment.Compra, data, numPartticipacionsDespresSplit, preuParticipacioDespres, canviAplicat, desAcum == 0 ? (double?) null : desAcum, tipusMoviment.ToString(), true);
        }

        /// <summary>
        /// Torna una llista amb els moviments de compra que tenen perticipacions/accions NO venudes.
        /// </summary>
        /// <returns></returns>
        private IEnumerable<Moviment> compresAmbParticipacionsNoVenudes(out double numPartNoVenudes)
        {
            Moviment primeraCompraAmbSaldo = null;
            var compres = MovimentsProducteUsuari.Where(w => w.TipusMoviment == TipusMoviment.Compra).OrderBy(o => o.Data).ThenBy(o=>o.Id).ToList();
            var vendes = new Queue<Moviment>(MovimentsProducteUsuari.Where(w => w.TipusMoviment == TipusMoviment.Venda).OrderBy(o => o.Data).ThenBy(o=>o.Id));
            numPartNoVenudes = 0;

            foreach (var compra in compres)
            {
                numPartNoVenudes += compra.Participacions;

                while (vendes.Count > 0 && numPartNoVenudes > 0)
                {
                    Moviment ultimaVendaLlegida = vendes.Dequeue();
                    numPartNoVenudes -= ultimaVendaLlegida.Participacions;
                }

                if (numPartNoVenudes > 0)
                {
                    primeraCompraAmbSaldo = compra;
                    break;
                }
            }

            List<Moviment> compresAmbParticipacio = new List<Moviment>();

            if (primeraCompraAmbSaldo == null)
                return compresAmbParticipacio;

            //Moviment xx = primeraCompraAmbSaldo.Clone(); // Clono per modificar el numero de participacions no venudes, nomes per aquesta funció.
            //xx.Participacions = numPartNoVenudes;
            //compresAmbParticipacio.Add(xx);
            //compresAmbParticipacio.AddRange(MovimentsProducteUsuari.Where(w => w.Data >= primeraCompraAmbSaldo.Data && w.TipusMoviment == TipusMoviment.Compra).ToList());
            //return compresAmbParticipacio.OrderBy(o => o.Data).ThenBy(o=>o.Id);
            
            return MovimentsProducteUsuari.Where(w => w.Data >= primeraCompraAmbSaldo.Data && w.TipusMoviment == TipusMoviment.Compra).OrderBy(o => o.Data).ThenBy(o => o.Id);
        }


        public static double PigValorat(TipusProducte tipusProducte)
        {
            double pig = 0;

            foreach (var prod in ProductesPerTipus(tipusProducte))
            {
                pig += prod.pigValorat(DateTimeFinalDia.Today);
            }

            return pig;
        }


        public static double PigValorat(int any, TipusProducte tipusProducte)
        {
            double pig = 0;
            var data = new DateTimeFinalDia(any, 12, 31);

            foreach (var prod in ProductesPerTipus(tipusProducte))
            {
                pig += prod.pigValorat(data.AddYears(-1), data);
            }

            return pig;
        }


        private static IEnumerable<Producte> ProductesPerTipus(TipusProducte tipusProducte)
        {
            var prods = Program.Sessio.Productes.ToList();
            if (tipusProducte != TipusProducte.Tots)
                prods = prods.Where(w => w._TipusProducte == tipusProducte).ToList();

            return prods;
        }


        public static double PigReal(TipusProducte tipusProducte)
        {
            double pig = 0;

            foreach (var prod in ProductesPerTipus(tipusProducte))
            {
                pig += prod.pigReal(DateTimeFinalDia.Today);
            }

            return pig;
        }

        public static double PigReal(int any, TipusProducte tipusProducte)
        {
            double pig = 0;
            DateTimeFinalDia dataFi = new DateTimeFinalDia(any, 12, 31);

            foreach (var prod in ProductesPerTipus(tipusProducte))
            {
                pig += prod.pigReal(dataFi.AddYears(-1), dataFi);
            }

            return pig;
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
            var vendesReals = MovimentsProducteUsuari.Where(w => w._EsVendaReal && w.Data < data._Data).ToList();
            if (!vendesReals.Any())
                return 0;
            DateTime dataUltimaVenda = vendesReals.Max(m => m.Data);

            // Totes les vendes, inclou traspassos, a partir de la data de la última venda real.
            var vendes = MovimentsProducteUsuari.Where(w => w._EsVenda && w.Data <= dataUltimaVenda).OrderBy(o => o.Data).ToList();

            // Totes les compres, inclou traspassos, a partir de la data de la última venda real.
            var compres = new Queue<Moviment>(MovimentsProducteUsuari.Where(w => w._EsCompra && w.Data < dataUltimaVenda).OrderBy(o => o.Data));

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

            var importVendes = vendes.Where(w => !w._EsTraspas).Sum(s => s.Participacions * s.PreuParticipacio - s.Despeses.GetValueOrDefault());

            return importVendes - importCompres;
        }


        public double pigValorat(int any)
        {
            double pig = 0;

            DateTimeFinalDia data = new DateTimeFinalDia(any, 12, 31);
            pig += pigValorat(data.AddYears(-1), data);

            return pig;
        }


        public double pigValorat(DateTimeFinalDia dataIni, DateTimeFinalDia dataFi)
        {
            return pigValorat(dataFi) - pigValorat(dataIni);
        }


        /// <summary>
        /// PiG en una data, segons el valor de la valoració més recent anterior a la data.
        /// Inclou dividends.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double pigValorat(DateTimeFinalDia data)
        {
            var importCompres = MovimentsProducteUsuari.Where(w => w._EsCompra && w.Data < data._Data).Sum(s => (s.Participacions * s.PreuParticipacio) + s.Despeses.GetValueOrDefault());
            var importVendes = MovimentsProducteUsuari.Where(w => w._EsVenda && w.Data < data._Data).Sum(s => (s.Participacions * s.PreuParticipacio) - s.Despeses.GetValueOrDefault());
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
                return 0; // No calcular dividents si no hi ha res en cartera.
                // return dividends(data);

            var compres = new Stack<Moviment>(MovimentsProducteUsuari.Where(w => w._EsCompra).OrderBy(o => o.Data));

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

        internal double dividends(DateTimeFinalDia data)
        {
            return MovimentsProducteUsuari.Where(w => w._EsDividents && w.Data < data._Data).Sum(s => s.PreuParticipacio);
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

            var vendes = new Queue<Moviment>(MovimentsProducteUsuari.Where(w => w._EsVenda).OrderBy(o => o.Data));
            var compres = new Queue<Moviment>(MovimentsProducteUsuari.Where(w => w._EsCompra).OrderBy(o => o.Data));

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
        /// Torna les participacions en una data determinada. Te en compte tots els moviments del dia.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double numParticipacionsEnData(DateTimeFinalDia data)
        {
            return numParticipacionsEnData(data._Data);
        }
        
        
        /// <summary>
        /// Torna les participacions en una data hora determinada. No te en compte els moviments del mateix dia fets en hora posterior.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public double numParticipacionsEnData(DateTime data)
        {
            List<Moviment> movs = MovimentsProducteUsuari.Where(w => w.Data <= data).ToList();

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
                Union(MovimentsProducteUsuari.
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
