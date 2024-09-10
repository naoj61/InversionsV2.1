using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Windows.Forms;
using Comuns;

namespace Inversions
{
    public abstract partial class Producte
    {
        
        /// <summary>
        /// Suma les perdues dels 4 anys anteriors
        /// </summary>
        /// <param name="anyRenda"></param>
        /// <returns></returns>
        internal static decimal PerduesDarrersQuatreAnys(int? anyRenda = null)
        {
            if (!anyRenda.HasValue || anyRenda.Value == 0)
                return 0;

            var any = anyRenda.Value - 4;
            decimal pigT = 0;

            for (int i = 0; i < 4; i++)
            {
                var pAny = Pig2(TipusProducte.Tots, any++, false, false);
                if (pAny + pigT >= 0)
                    pigT = 0;
                else
                    pigT += pAny;
            }

            return pigT;
        }

        /// <summary>
        /// Crea una llista de productes en funció dels paràmetres: "tipusProducte", "tipusFons"
        /// </summary>
        /// <param name="tipusProducte"></param>
        /// <param name="tipusFons"></param>
        /// <returns></returns>
        private static IEnumerable<Producte> SeleccionaProds(TipusProducte tipusProducte, TipusFons? tipusFons)
        {
            List<Producte> prods = null;

            switch (tipusProducte)
            {
                case TipusProducte.Accions:
                    prods = new List<Producte>(ProdAccions.Tuples);
                    break;
                case TipusProducte.Fons:
                    if (tipusFons.HasValue)
                    {
                        switch (tipusFons.Value)
                        {
                            case TipusFons.RF:
                                prods = new List<Producte>(ProdFons.Tuples.Where(w => w.Tipus == TipusFons.RF));
                                break;
                            case TipusFons.RV:
                                prods = new List<Producte>(ProdFons.Tuples.Where(w => w.Tipus == TipusFons.RV));
                                break;
                            default:
                                prods = new List<Producte>(ProdFons.Tuples);
                                break;
                        }
                    }
                    else
                        prods = new List<Producte>(ProdFons.Tuples);
                    break;
                default:
                    prods = Producte.Tuples.ToList();
                    break;
            }

            return prods;
        }


        #region ***** PiG *****

        /// <summary>
        /// PiG de tots els productes en un any. Vendes reals dins el periode.
        /// Preu compra --> Preu origen.
        /// Preu venda  --> Preu venda.
        /// </summary>
        /// <param name="tipusProducte"></param>
        /// <param name="any"></param>
        /// <param name="inclouCartera"></param>
        /// <param name="inclouDividends">En la tributació a la renda els dividends tributen a part de les PiG de les accions. </param>
        /// <returns></returns>
        public static decimal Pig2(TipusProducte tipusProducte, int any, bool inclouCartera, bool inclouDividends)
        {
            return Pig2(tipusProducte, null, new DateTime(any, 1, 1), new DateTime(any + 1, 1, 1).AddMilliseconds(-1), inclouCartera, inclouDividends);
        }


        /// <summary>
        /// PiG de tots els productes en un any. Vendes reals dins el periode.
        /// Preu compra --> Preu origen.
        /// Preu venda  --> Preu venda.
        /// </summary>
        /// <param name="tipusProducte"></param>
        /// <param name="tipusFons">Si null, tots els fons.</param>
        /// <param name="dataInici"></param>
        /// <param name="dataFinal"></param>
        /// <param name="inclouCartera"></param>
        /// <param name="inclouDividends">En la tributació a la renda els dividends tributen a part de les PiG de les accions. </param>
        /// <returns></returns>
        internal static decimal Pig2(TipusProducte tipusProducte, TipusFons? tipusFons,
            DateTime dataInici, DateTime dataFinal, bool inclouCartera, bool inclouDividends)
        {
            IEnumerable<Producte> prods = SeleccionaProds(tipusProducte, tipusFons);

            return prods.Sum(prod => prod.pig2TotalOrig(dataInici, dataFinal, inclouCartera, inclouDividends));
        }
        

        /// <summary>
        /// Calcula el PiG de les accions en cartera a final d'any de tots els productes.
        /// </summary>
        /// <param name="tipusProducte"></param>
        /// <param name="tipusFons">Si null, tots els fons.</param>
        /// <param name="any">És l'any de càlcul.</param>
        /// <param name="pigOrigen">Calcula el PiG respecte el valor de compra original.</param>
        /// <param name="ambDespeses">Afegeig les despeses.</param>
        /// <returns></returns>
        internal static decimal Pig2Cartera(TipusProducte tipusProducte, TipusFons? tipusFons, int any, bool pigOrigen, bool ambDespeses)
        {
            return SeleccionaProds(tipusProducte, tipusFons).Sum(prod => prod.pigActual4(pigOrigen, ambDespeses));
        }

        internal static decimal PigTributa(TipusProducte tipusProducte, TipusFons? tipusFons, int any, bool inclouDividends)
        {
            IEnumerable<Producte> prods = SeleccionaProds(tipusProducte, tipusFons).ToList();

            var pig = Moviment.MovimentsUsuari
                .Where(mov => mov.Data.Year == any && mov._EsVendaReal && prods.Contains(mov.Prod))
                .Sum(venda => venda.pigVenda4(true, true));
            
            decimal div = inclouDividends ? Moviment.MovimentsUsuari
                .Where(mov => mov.Data.Year == any && mov._EsDividents && prods.Contains(mov.Prod))
                .Sum(divid => divid._ImportBrut) 
                : 0;

            return pig + div;
        }
        

        /// <summary>
        /// Calcula perdues i guanys de les vendes reals més els dividents entre les dates, inclou participacions en cartera si -> inclouCartera=true.
        /// </summary>
        /// <param name="dataHoraInici"></param>
        /// <param name="dataHoraFinal"></param>
        /// <param name="inclouCartera">Indica si s'ha d'incloure els dividents.</param>
        /// <param name="inclouDividends">En la tributació a la renda els dividends tributen a part de les PiG de les accions. </param>
        /// <returns></returns>
        public decimal pig2TotalOrig(DateTime? dataHoraInici, DateTime? dataHoraFinal, bool inclouCartera, bool inclouDividends)
        {
            var dataIni = dataHoraInici.GetValueOrDefault(DateTime.MinValue);
            var dataFi = dataHoraFinal.GetValueOrDefault(DateTime.MaxValue);

            var pigVendesReals = pig2Vendes(dataIni, dataFi, true);
            var pigEnCartera = inclouCartera ? pig2EnCarteraOrig(dataFi) : 0;
            var divid = inclouDividends ? dividends(dataIni, dataFi) : 0;
            var pigTotal = pigVendesReals + pigEnCartera + divid;

            return pigTotal;
        }
        

        /// <summary>
        /// PiG del producte sense tenir en compte el peru original en cas de traspàs.
        /// </summary>
        /// <param name="dataHoraFinal"></param>
        /// <returns></returns>
        internal decimal pig2Producte(DateTime? dataHoraFinal = null)
        {
            return pig2Producte(dataHoraFinal.GetValueOrDefault(DateTime.MaxValue));
        }


        /// <summary>
        /// PiG del producte sense tenir en compte el preu original en cas de traspàs.
        /// </summary>
        /// <param name="dataHoraFinal"></param>
        /// <returns></returns>
        private decimal pig2Producte(DateTime dataHoraFinal)
        {
            var movimentsData = MovimentsProducteUsuari.Where(w => w.Data <= dataHoraFinal).ToList();

            var valorEnCart = valorEnCartera(dataHoraFinal);
            var importNetCompres = movimentsData.Where(w => w._EsCompra).Sum(s => s.Participacions * s.PreuParticipacio);
            var importNetVendes = movimentsData.Where(w => w._EsVenda).Sum(s => s.Participacions * s.PreuParticipacio);
            var dividends = movimentsData.Where(w => w._EsDividents).Sum(s => s.PreuParticipacio);
            var despeses = movimentsData.Sum(s => s.Despeses.GetValueOrDefault());

            return importNetVendes + valorEnCart + dividends - importNetCompres - despeses;
        }

        /*
        /// <summary>
        /// Calcula perdues i guanys del les participacions en cartera a una data. Inclou despeses. No inclou vendes reals ni dividends.
        /// </summary>
        /// <param name="dataHoraFinal">Si null, data d'avui.</param>
        /// <param name="numParts"></param>
        /// <param name="preuParticipacio">Si null, preu de la participació en la data "dataFinal"</param>
        /// <returns></returns>
        internal decimal pig2EnCartera(DateTime? dataHoraFinal = null, decimal? numParts = null, decimal? preuParticipacio = null)
        {
            dataHoraFinal = dataHoraFinal.GetValueOrDefault(DateTime.MaxValue);
            numParts = numParts.GetValueOrDefault(numParticipacionsEnData(dataHoraFinal));
            preuParticipacio = preuParticipacio.GetValueOrDefault(valorParticipacio(dataHoraFinal.Value)) * numParts.Value;

            return pig2EnCartera(dataHoraFinal.GetValueOrDefault(DateTime.MaxValue), numParts, preuParticipacio);
        }
        */

        /// <summary>
        /// Calcula perdues i guanys de les participacions en cartera a una data. No inclou despeses ni vendes reals ni dividends.
        /// </summary>
        /// <param name="dataHoraFinal"></param>
        /// <param name="numParts"></param>
        /// <param name="preuParticipacio">Si null, preu de la participació en la data "dataFinal"</param>
        /// <returns></returns>
        internal decimal pig2EnCarteraOrig(DateTime? dataHoraFinal = null, decimal? numParts = null, decimal? preuParticipacio = null)
        {
            dataHoraFinal = dataHoraFinal.GetValueOrDefault(DateTime.MaxValue);
            numParts = numParts.GetValueOrDefault(numParticipacionsEnData(dataHoraFinal));
            preuParticipacio = preuParticipacio.GetValueOrDefault(valorParticipacio(dataHoraFinal.Value));

            var preuOrig = costOriginalEnCartera3(dataHoraFinal, numParts.Value);
            var preuData = preuParticipacio.GetValueOrDefault(valorParticipacio(dataHoraFinal.Value)) * numParts.Value;

            return Math.Round(preuData - preuOrig, 5);
        }


        /// <summary>
        /// Calcula el PiG de les accions en cartera en una data.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="pigOrigen"></param>
        /// <param name="ambDespeses"></param>
        /// <returns></returns>
        internal decimal pig2Cartera(DateTime data, bool pigOrigen, bool ambDespeses)
        {
            var compres = MovimentsProducteUsuari.Where(w => w._EsCompra && w.Data <= Utilitats.DataHoraFinalDia(data)).ToList();
            return compres.Sum(compra => compra.pigEnCartera(pigOrigen, ambDespeses));
        }


        /// <summary>
        /// Torna la variació de valor en cartera entre dates. Només productes amb cartera a 'dataHoraFinal'.
        /// </summary>
        /// <param name="any"></param>
        /// <returns></returns>
        internal decimal pigVariacioCartera(int any)
        {
            DateTime dataHoraInicial = new DateTime(any, 1, 1);
            DateTime dataHoraFinal = Utilitats.DataHoraFinalAny(any);

            return pigVariacioCartera(dataHoraInicial, dataHoraFinal);
        }

        /// <summary>
        /// Torna la variació de valor en cartera entre dates. Només productes amb cartera a 'dataHoraFinal'.
        /// </summary>
        /// <param name="dataHoraInicial"></param>
        /// <param name="dataHoraFinal"></param>
        /// <returns></returns>
        internal decimal pigVariacioCartera(DateTime dataHoraInicial, DateTime dataHoraFinal)
        {
            var preuPartInici = valorParticipacio(dataHoraInicial);
            var preuPartFinal = valorParticipacio(dataHoraFinal);
            var partsFinal = numParticipacionsEnData(dataHoraFinal);

            /*
             * Si s'ha comprat: Calcular el PiG des de la compra fins ara o fins la venda si s'han venut rl mateix any i restar a les parts actuals les parts comprades que restes.
             * Si s'ha venut: Calcular el PiG de les parts venudes respecte al preu de principi d'any o del preu de compra si s'han comprat el mateix any.
            */

            var compres = MovimentsProducteUsuari.Where(w => w.Data >= dataHoraInicial && w.Data <= dataHoraFinal && w._EsCompra).ToList();
            var vendes = MovimentsProducteUsuari.Where(w => w.Data >= dataHoraInicial && w.Data <= dataHoraFinal && w._EsVenda).ToList();

            if (Utilitats.EsZero(partsFinal) && !vendes.Any())
                return 0;

            partsFinal -= compres.Sum(s=>s.Participacions); // Elimino les parts comprades perque calcularé el seu PiG a part.

            decimal pigCompres = 0;
            if (compres.Any())
            {
                if (Utilitats.EsZero(preuPartInici))
                    preuPartInici = compres.Single(w => w.Data == compres.Min(m => m.Data)).PreuParticipacio;

                pigCompres += compres.Sum(compra => (preuPartFinal - compra.PreuParticipacio) * compra.Participacions);
            }

            decimal pigVendes = 0;
            if (vendes.Any())
            {
                pigVendes += vendes.Sum(venda => (venda.PreuParticipacio - preuPartInici) * venda.Participacions);
            }

            if (Utilitats.EsZero(preuPartInici))
                preuPartInici = ValoracionsProducte.First().PreuParticipacio;

            var pigPartsDataFinal = partsFinal * (preuPartFinal - preuPartInici);

            return pigCompres + pigVendes + pigPartsDataFinal;
        }



        /// <summary>
        /// PiG de vendes. No inclou dividends.
        /// </summary>
        /// <param name="dataHoraInici"></param>
        /// <param name="dataHoraFinal"></param>
        /// <param name="nomesVendesReals">Si true, només de les vendes reals.</param>
        /// <returns></returns>
        private decimal pig2Vendes(DateTime dataHoraInici, DateTime dataHoraFinal, bool nomesVendesReals)
        {
            //var vendesReals = MovimentsProducteUsuari.Where(w => w._EsVendaReal && w.Data >= dataIni && w.Data <= dataFi).ToList();

            var vendes = MovimentsProducteUsuari.Where(w => w.Data >= dataHoraInici && w.Data <= dataHoraFinal && w._EsVenda).ToList();
            if (nomesVendesReals)
                vendes = vendes.Where(w => !w._EsTraspas).ToList();

            return vendes.Sum(venda => venda.pigVenda(true));
        }

        #endregion ***** PiG *****


        /// <summary>
        /// Trona les despeses de les participacions en cartera en una data,
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal decimal despeses(DateTime? data = null)
        {
            data = data.GetValueOrDefault(Utilitats.DataHoraFinalDia(DateTime.Today));
            return compresDePartipacionsEnData4(Utilitats.DataHoraFinalDia(data.Value), numParticipacionsEnData(data))
                .Sum(compra => compra._DespesesPartsUtilitzades);
        }


        /// <summary>
        /// Participacions en cartera d'un producte en una data.
        /// </summary>
        /// <param name="dataHora">Si null, data d'avui.</param>
        /// <returns></returns>
        internal decimal partsEnCartera(DateTime? dataHora = null)
        {
            var dataH = dataHora.GetValueOrDefault(DateTime.Now);
            var partsComprades = MovimentsProducteUsuari.Where(w => w._EsCompra && w.Data <= dataH).Sum(s => s.Participacions);
            var partsVenudes = MovimentsProducteUsuari.Where(w => w._EsVenda && w.Data <= dataH).Sum(s => s.Participacions);

            return partsComprades - partsVenudes;
        }


        /// <summary>
        /// Calcula el cost original de les participacions en cartera. Inclou despeses. 
        /// </summary>
        /// <param name="dataHoraFinal">Si null calcula les participacions avui, sinò les que hi havia a la data.</param>
        /// <param name="numPartsMax">Limita el cost a num de participacions</param>
        /// <returns></returns>
        public decimal costOriginalEnCartera3(DateTime? dataHoraFinal = null, decimal? numPartsMax = null)
        {
            var dataH = dataHoraFinal.GetValueOrDefault(DateTime.Now);
            var numParts = numPartsMax.GetValueOrDefault(numParticipacionsEnData(dataH));

            return desglosCompresDeParticipacionsEnData4(dataH, numParts).Sum(s => s._PartsUtilitzadesOrig * s._PreuParticipacioOrig);
        }


        /// <summary>
        /// Torna les participacions en una data hora determinada. No te en compte els moviments del mateix dia fets en hora posterior.
        /// </summary>
        /// <param name="dataHora">Si null, data hora actual.</param>
        /// <returns></returns>
        internal decimal numParticipacionsEnData(DateTime? dataHora = null)
        {
            var data = dataHora.GetValueOrDefault(DateTime.Now);

            var particComprades = MovimentsProducteUsuari.Where(w => w.Data <= data && w.TipusMoviment == TipusMoviment.Compra).Sum(s => s.Participacions);
            var particVenudes = MovimentsProducteUsuari.Where(w => w.Data <= data && w.TipusMoviment == TipusMoviment.Venda).Sum(s => s.Participacions);

            return Math.Round(particComprades - particVenudes, 5);
        }


        #region **** Mètodes cridats des de Test *****
        
        public static decimal Pig2CarteraTest(TipusProducte tipusProducte, TipusFons? tipusFons, int any, bool pigOrigen, bool ambDespeses)
        {
            return Pig2Cartera(tipusProducte, tipusFons, any, pigOrigen, ambDespeses);
        }


        public decimal pig2EnCarteraTest(DateTime? dataHoraFinal = null, decimal? numParts = null, decimal? preuParticipacio = null)
        {
            return pig2EnCarteraOrig(dataHoraFinal, numParts, preuParticipacio);
        }

        public decimal numParticipacionsEnDataTest(DateTime? data = null)
        {
            return numParticipacionsEnData(data);
        }

        public decimal costOriginalEnCartera3Test(decimal? numPartsMax = null)
        {
            return costOriginalEnCartera3(null, numPartsMax);
        }


        public decimal pig2TotalTest(DateTime? dataHoraInici = null, DateTime? dataHoraFinal = null, bool inclouCartera = true, bool inclouDividends = false)
        {
            return pig2TotalOrig(dataHoraInici, dataHoraFinal, inclouCartera, inclouDividends);
        }

        public decimal pig2ProducteTest(DateTime? dataHoraFinal = null)
        {
            return pig2Producte(dataHoraFinal);
        }

        #endregion
    }
}