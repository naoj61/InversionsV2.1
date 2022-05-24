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
        public static double Pig2(TipusProducte tipusProducte, int any, bool inclouCartera, bool inclouDividends)
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
        internal static double Pig2(TipusProducte tipusProducte, TipusFons? tipusFons,
            DateTime dataInici, DateTime dataFinal, bool inclouCartera, bool inclouDividends)
        {
            IEnumerable<Producte> prods = SeleccionaProds(tipusProducte, tipusFons);

            return prods.Sum(prod => prod.pig2Total(dataInici, dataFinal, inclouCartera, inclouDividends));
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
        internal static double Pig2Cartera(TipusProducte tipusProducte, TipusFons? tipusFons, uint any, bool pigOrigen, bool ambDespeses)
        {
            var prods = SeleccionaProds(tipusProducte, tipusFons);
            return prods.Sum(prod => prod.pig2Cartera(any, pigOrigen, ambDespeses));
        }


        internal static double PigTributa(TipusProducte tipusProducte, TipusFons? tipusFons, uint any, bool inclouDividends)
        {
            IEnumerable<Producte> prods = SeleccionaProds(tipusProducte, tipusFons).ToList();

            double pig = Program.Sessio.MovimentsUsuari
                .Where(w => w.Data.Year == any && prods.Contains(w.Prod) && w._EsVendaReal)
                .Sum(s => s.pigVenda(true));

            double div = inclouDividends ? Program.Sessio.MovimentsUsuari
                .Where(w => w.Data.Year == any && prods.Contains(w.Prod) && w._EsDividents)
                .Sum(s => s._ImportBrut) : 0;

            return pig + div;
        }

        /// <summary>
        /// Suma les perdues dels 4 anys anteriors
        /// </summary>
        /// <param name="dataRenda"></param>
        /// <returns></returns>
        internal static double PerduesDarrersQuatreAnys(int? dataRenda = null)
        {
            var any = dataRenda.GetValueOrDefault(DateTime.Today.Year) - 4;
            double pigT = 0;

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
                    prods = new List<Producte>(Program.Sessio.ProdAccions);
                    break;
                case TipusProducte.Fons:
                    if (tipusFons.HasValue)
                    {
                        switch (tipusFons.Value)
                        {
                            case TipusFons.RF:
                                prods = new List<Producte>(Program.Sessio.ProdFons.Where(w => w.Tipus == TipusFons.RF));
                                break;
                            case TipusFons.RV:
                                prods = new List<Producte>(Program.Sessio.ProdFons.Where(w => w.Tipus == TipusFons.RV));
                                break;
                            default:
                                prods = new List<Producte>(Program.Sessio.ProdFons);
                                break;
                        }
                    }
                    else
                        prods = new List<Producte>(Program.Sessio.ProdFons);
                    break;
                default:
                    prods = Program.Sessio.Productes.ToList();
                    break;
            }

            return prods;
        }


        /// <summary>
        /// Calcula perdues i guanys de les vendes reals més els dividents entre les dates, inclou participacions en cartera si -> inclouCartera=true.
        /// </summary>
        internal double pig2Total()
        {
            return pig2Total(DateTime.MinValue, DateTime.MaxValue, true, true);
        }


        /// <summary>
        /// Calcula perdues i guanys de les vendes reals més els dividents entre les dates, inclou participacions en cartera si -> inclouCartera=true.
        /// </summary>
        /// <param name="dataHoraInici"></param>
        /// <param name="dataHoraFinal"></param>
        /// <param name="inclouCartera">Indica si s'ha d'incloure els dividents.</param>
        /// <param name="inclouDividends">En la tributació a la renda els dividends tributen a part de les PiG de les accions. </param>
        /// <returns></returns>
        public double pig2Total(DateTime? dataHoraInici, DateTime? dataHoraFinal, bool inclouCartera, bool inclouDividends)
        {
            var dataIni = dataHoraInici.GetValueOrDefault(DateTime.MinValue);
            var dataFi = dataHoraFinal.GetValueOrDefault(DateTime.MaxValue);

            var pigVendesReals = pig2Vendes(dataIni, dataFi, true);
            var pigEnCartera = inclouCartera ? pig2EnCartera(dataFi, null) : 0;
            var divid = inclouDividends ? dividends(dataIni, dataFi) : 0;
            var pigTotal = pigVendesReals + pigEnCartera + divid;

            return pigTotal;
        }
        

        /// <summary>
        /// Calcula perdues i guanys de les vendes reals més els dividents entre les dates, inclou participacions en cartera si -> inclouCartera=true.
        /// </summary>
        /// <param name="anyVendes"></param>
        /// <param name="inclouCartera">Indica si s'ha d'incloure els dividents.</param>
        /// <param name="inclouDividends">En la tributació a la renda els dividends tributen a part de les PiG de les accions. </param>
        /// <returns></returns>
        internal double pig3Total(uint anyVendes, bool inclouCartera, bool inclouDividends)
        {
            var vendesRealsAny = MovimentsProducteUsuari.Where(w => w._EsVendaReal && w.Data.Year == anyVendes).ToList();

            List<Moviment> compres = new List<Moviment>();
            foreach (Moviment vendaReal in vendesRealsAny)
            {
                // Creo llista de compres de les vendes del periode evitant duplicats.
                foreach (CompraExt compraExt in vendaReal.compresDeLaVenda())
                {
                    if (!compres.Contains(compraExt._Compra))
                        compres.Add(compraExt._Compra);
                }
            }

            double sum = 0;
            foreach (var compra in compres)
            {
                sum += compra.pigCompra(inclouCartera, true, anyVendes, true, inclouDividends);
            }

            return sum;
        }


        /// <summary>
        /// PiG del producte sense tenir en compte el peru original en cas de traspàs.
        /// </summary>
        /// <param name="dataHoraFinal"></param>
        /// <returns></returns>
        internal double pig2Producte(DateTime? dataHoraFinal = null)
        {
            return pig2Producte(dataHoraFinal.GetValueOrDefault(DateTime.MaxValue));
        }


        /// <summary>
        /// PiG del producte sense tenir en compte el preu original en cas de traspàs.
        /// </summary>
        /// <param name="dataHoraFinal"></param>
        /// <returns></returns>
        private double pig2Producte(DateTime dataHoraFinal)
        {
            var movimentsData = MovimentsProducteUsuari.Where(w => w.Data <= dataHoraFinal).ToList();

            var valorEnCart = valorEnCartera(dataHoraFinal);
            var importNetCompres = movimentsData.Where(w => w._EsCompra).Sum(s => s.Participacions * s.PreuParticipacio);
            var importNetVendes = movimentsData.Where(w => w._EsVenda).Sum(s => s.Participacions * s.PreuParticipacio);
            var dividends = movimentsData.Where(w => w._EsDividents).Sum(s => s.PreuParticipacio);
            var despeses = movimentsData.Sum(s => s.Despeses.GetValueOrDefault());

            return importNetVendes + valorEnCart + dividends - importNetCompres - despeses;
        }


        /// <summary>
        /// Calcula el PiG de les accions en cartera a final d'any.
        /// </summary>
        /// <param name="any">És l'any de càlcul.</param>
        /// <param name="pigOrigen">Calcula el PiG respecte el valor de compra original.</param>
        /// <param name="ambDespeses">Afegeig les despeses.</param>
        /// <returns></returns>
        private double pig2Cartera(uint any, bool pigOrigen, bool ambDespeses)
        {
            var compres = MovimentsProducteUsuari.Where(w => w._EsCompra && w.Data.Year <= any).ToList();
            return compres.Sum(compra => compra.pigEnCartera(pigOrigen, ambDespeses));
        }


        /// <summary>
        /// Participacions en cartera d'un producte en una data.
        /// </summary>
        /// <param name="dataHora">Si null, data d'avui.</param>
        /// <returns></returns>
        private double partsEnCartera(DateTime? dataHora)
        {
            var dataH = dataHora.GetValueOrDefault(DateTime.Now);
            var partsComprades = MovimentsProducteUsuari.Where(w => w._EsCompra && w.Data <= dataH).Sum(s => s.Participacions);
            var partsVenudes = MovimentsProducteUsuari.Where(w => w._EsVenda && w.Data <= dataH).Sum(s => s.Participacions);

            return partsComprades - partsVenudes;
        }


        /// <summary>
        /// Calcula perdues i guanys del les participacions en cartera a una data. Inclou despeses. No inclou vendes reals ni dividends.
        /// </summary>
        /// <param name="dataHoraFinal">Si null, data d'avui.</param>
        /// <param name="numParts"></param>
        /// <param name="preuParticipacio">Si null, preu de la participació en la data "dataFinal"</param>
        /// <returns></returns>
        internal double pig2EnCartera(DateTime? dataHoraFinal = null, double? numParts = null, double? preuParticipacio = null)
        {
            return pig2EnCartera(dataHoraFinal.GetValueOrDefault(DateTime.MaxValue), numParts, preuParticipacio);
        }


        /// <summary>
        /// Calcula perdues i guanys de les participacions en cartera a una data. Inclou despeses. No inclou vendes reals ni dividends.
        /// </summary>
        /// <param name="dataHoraFinal"></param>
        /// <param name="numParts"></param>
        /// <param name="preuParticipacio">Si null, preu de la participació en la data "dataFinal"</param>
        /// <returns></returns>
        private double pig2EnCartera(DateTime dataHoraFinal, double? numParts, double? preuParticipacio)
        {
            var parts = numParts.GetValueOrDefault(numParticipacionsEnData(dataHoraFinal));

            var preuOrig = costOriginalEnCartera4(dataHoraFinal, parts);
            var preuData = preuParticipacio.GetValueOrDefault(valorParticipacio(dataHoraFinal)) * parts;

            return Math.Round(preuData - preuOrig, 5);
        }


        /// <summary>
        /// Torna la variació de valor en cartera entre dates. Només productes amb cartera a 'dataHoraFinal'.
        /// </summary>
        /// <param name="any"></param>
        /// <param name="percentatge">Si true, torna percentatge.</param>
        /// <returns></returns>
        internal double pigVariacioCartera(int any, bool percentatge)
        {
            DateTime dataHoraInicial = new DateTime(any, 1, 1);
            DateTime dataHoraFinal = Utilitats.DataHoraFinalAny(any);

            return pigVariacioCartera(dataHoraInicial, dataHoraFinal, percentatge);
        }

        /// <summary>
        /// Torna la variació de valor en cartera entre dates. Només productes amb cartera a 'dataHoraFinal'.
        /// </summary>
        /// <param name="dataHoraInicial"></param>
        /// <param name="dataHoraFinal"></param>
        /// <param name="percentatge">Si true, torna percentatge.</param>
        /// <returns></returns>
        internal double pigVariacioCartera(DateTime dataHoraInicial, DateTime dataHoraFinal, bool percentatge)
        {
            var preuPartInici = valorParticipacio(dataHoraInicial);
            var preuPartFinal = valorParticipacio(dataHoraFinal);
            var partsFinal = numParticipacionsEnData(dataHoraFinal);

            if (Utilitats.EsZero(partsFinal))
                return 0;

            if (Utilitats.EsZero(preuPartInici))
                preuPartInici = ValoracionsProducte.First().PreuParticipacio;

            return percentatge 
                ? preuPartFinal / preuPartInici - 1 
                : partsFinal * (preuPartFinal - preuPartInici);
        }



        /// <summary>
        /// PiG de vendes. No inclou dividends.
        /// </summary>
        /// <param name="dataHoraInici"></param>
        /// <param name="dataHoraFinal"></param>
        /// <param name="nomesVendesReals">Si true, només de les vendes reals.</param>
        /// <returns></returns>
        private double pig2Vendes(DateTime dataHoraInici, DateTime dataHoraFinal, bool nomesVendesReals)
        {
            //var vendesReals = MovimentsProducteUsuari.Where(w => w._EsVendaReal && w.Data >= dataIni && w.Data <= dataFi).ToList();

            var vendes = MovimentsProducteUsuari.Where(w => w.Data >= dataHoraInici && w.Data <= dataHoraFinal && w._EsVenda).ToList();
            if (nomesVendesReals)
                vendes = vendes.Where(w => !w._EsTraspas).ToList();

            return vendes.Sum(venda => venda.pigVenda(true));
        }

        #endregion ***** PiG *****

        /// <summary>
        /// Calcula el cost original de les participacions en cartera. Inclou despeses. 
        /// </summary>
        /// <param name="dataHoraFinal">Si null calcula les participacions avui, sinò les que hi havia a la data.</param>
        /// <param name="numPartsMax">Limita el cost a num de participacions</param>
        /// <returns></returns>
        public double costOriginalEnCartera4(DateTime? dataHoraFinal = null, double? numPartsMax = null)
        {
            var dataH = dataHoraFinal.GetValueOrDefault(DateTime.Now);
            var numParts = numPartsMax.GetValueOrDefault(numParticipacionsEnData(dataH));

            return desglosCompresDeParticipacionsEnData(dataH, numParts).Sum(s => s._PartsUtilitzadesOrig * s._PreuParticipacioOrig);
        }


        /// <summary>
        /// Torna les participacions en una data hora determinada. No te en compte els moviments del mateix dia fets en hora posterior.
        /// </summary>
        /// <param name="dataHora">Si null, data hora actual.</param>
        /// <returns></returns>
        internal double numParticipacionsEnData(DateTime? dataHora = null)
        {
            var data = dataHora.GetValueOrDefault(DateTime.Now);

            var particComprades = MovimentsProducteUsuari.Where(w => w.Data <= data && w.TipusMoviment == TipusMoviment.Compra).Sum(s => s.Participacions);
            var particVenudes = MovimentsProducteUsuari.Where(w => w.Data <= data && w.TipusMoviment == TipusMoviment.Venda).Sum(s => s.Participacions);

            return Math.Round(particComprades - particVenudes, 5);
        }


        #region **** Mètodes cridats des de Test *****
        
        public static double Pig2CarteraTest(TipusProducte tipusProducte, TipusFons? tipusFons, uint any, bool pigOrigen, bool ambDespeses)
        {
            return Pig2Cartera(tipusProducte, tipusFons, any, pigOrigen, ambDespeses);
        }


        public double pig2EnCarteraTest(DateTime? dataHoraFinal = null, double? numParts = null, double? preuParticipacio = null)
        {
            return pig2EnCartera(dataHoraFinal, numParts, preuParticipacio);
        }

        public double numParticipacionsEnDataTest(DateTime? data = null)
        {
            return numParticipacionsEnData(data);
        }

        public double costOriginalEnCartera2Test(double? numPartsMax = null)
        {
            return costOriginalEnCartera4(null, numPartsMax);
        }


        public double pig3TotalTest(uint any, bool inclouCartera, bool inclouDividends)
        {
            return pig3Total(any, inclouCartera, inclouDividends);
        }

        public double pig2TotalTest(DateTime? dataHoraInici = null, DateTime? dataHoraFinal = null, bool inclouCartera = true, bool inclouDividends = false)
        {
            return pig2Total(dataHoraInici, dataHoraFinal, inclouCartera, inclouDividends);
        }

        public double pig2ProducteTest(DateTime? dataHoraFinal = null)
        {
            return pig2Producte(dataHoraFinal);
        }

        #endregion
    }
}