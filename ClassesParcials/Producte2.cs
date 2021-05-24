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
        /// PiG de tots els productes en un any. Vendes reals dins el periode.
        /// Preu compra --> Preu origen.
        /// Preu venda  --> Preu venda.
        /// </summary>
        /// <param name="tipusProducte"></param>
        /// <param name="inclouCartera"></param>
        /// <param name="inclouDividends">En la tributació a la renda els dividends tributen a part de les PiG de les accions. </param>
        /// <returns></returns>
        public static double Pig2(TipusProducte tipusProducte, bool inclouCartera, bool inclouDividends)
        {
            return Pig2(tipusProducte, DateTime.MinValue, DateTime.MaxValue, inclouCartera, inclouDividends);
        }


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
            return Pig2(tipusProducte, new DateTime(any, 1, 1), new DateTime(any + 1, 1, 1).AddMilliseconds(-1), inclouCartera, inclouDividends);
        }


        /// <summary>
        /// PiG de tots els productes en un any. Vendes reals dins el periode.
        /// Preu compra --> Preu origen.
        /// Preu venda  --> Preu venda.
        /// </summary>
        /// <param name="tipusProducte"></param>
        /// <param name="dataInici"></param>
        /// <param name="dataFinal"></param>
        /// <param name="inclouCartera"></param>
        /// <param name="inclouDividends">En la tributació a la renda els dividends tributen a part de les PiG de les accions. </param>
        /// <returns></returns>
        internal static double Pig2(TipusProducte tipusProducte,
            DateTime dataInici, DateTime dataFinal, bool inclouCartera, bool inclouDividends)
        {
            List<Producte> prods;
            switch (tipusProducte)
            {
                case TipusProducte.Accions:
                    prods = new List<Producte>(Program.Sessio.ProdAccions);
                    break;
                case TipusProducte.Fons:
                    prods = new List<Producte>(Program.Sessio.ProdFons);
                    break;
                default:
                    prods = Program.Sessio.Productes.ToList();
                    break;
            }
            return prods.Sum(prod => prod.pig2Total(dataInici, dataFinal, inclouCartera, inclouDividends));
        }
        

        /// <summary>
        /// Torna les participacions en una data hora determinada. No te en compte els moviments del mateix dia fets en hora posterior.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal double numParticipacionsEnData(DateTime? data = null)
        {
            return numParticipacionsEnData(data.GetValueOrDefault(DateTime.MaxValue));
        }


        /// <summary>
        /// Calcula el cost original de les participacions en cartera.
        /// </summary>
        /// <param name="numPartsMax"></param>
        /// <returns></returns>
        internal double costOriginalEnCartera2(double? numPartsMax = null)
        {
            return costOriginalEnCartera4(DateTime.MaxValue, numPartsMax);
        }

        /// <summary>
        /// Torna la llista de les compres afectades per una venda amb data 'dataHoraVenda' i num parts 'numParticionsVenda'.
        /// </summary>
        /// <param name="dataHora"></param>
        /// <param name="numParticions"></param>
        /// <returns></returns>
        public IEnumerable<Moviment> compresDeLaVenda4Test(DateTime dataHora, double numParticions)
        {
            return compresDeLaVenda4(dataHora, numParticions);
        }

        /// <summary>
        /// Torna la llista de les compres afectades per una venda amb data 'dataHoraVenda' i num parts 'numParticionsVenda'.
        /// </summary>
        /// <param name="dataHoraVenda">Es buscaran compres i vendes anteriors a aquesta data.</param>
        /// <param name="numParticionsVenda">Son les particions venudes a les que buscaré les seves compres.</param>
        /// <returns></returns>
        internal IEnumerable<Moviment> compresDeLaVenda4(DateTime dataHoraVenda, double numParticionsVenda)
        {
            // Totes les compres anteriors a la venda.
            var compresAnt = MovimentsProducteUsuari.Where(w => w._EsCompra && w.Data < dataHoraVenda).OrderBy(o => o.Data).ToList();

            // *** Reinicia _ParticipacionsDisponibles ***
            Moviment.ResetParticipacionsDisponibles(compresAnt);

            var numPartsVenudesAbans = MovimentsProducteUsuari.Where(w => w._EsVenda && w.Data < dataHoraVenda).Sum(s => s.Participacions);
            var partRestantsVendaActual = numParticionsVenda;

            List<Moviment> compres = new List<Moviment>();
            foreach (var compraAnt in compresAnt)
            {
                if (Utilitats.ComparaNumeros(numPartsVenudesAbans, 0) > 0)
                {
                    // Descompta les participacions venudes abans.
                    if (Utilitats.ComparaNumeros(numPartsVenudesAbans, compraAnt.Participacions) >= 0)
                    {
                        // Tota la compra estava venuda abans.
                        numPartsVenudesAbans -= compraAnt.Participacions;
                        continue;
                    }

                    // Descompto les participacions venudes abans.
                    compraAnt._ParticipacionsOcupades = numPartsVenudesAbans;
                    numPartsVenudesAbans = 0;
                }

                if (Utilitats.ComparaNumeros(partRestantsVendaActual, compraAnt._ParticipacionsDisponibles) > 0)
                {
                    var partsDisp = compraAnt._ParticipacionsDisponibles;
                    compraAnt._ParticipacionsUtilitzades = partsDisp;
                    partRestantsVendaActual -= partsDisp;
                }
                else
                {
                    compraAnt._ParticipacionsUtilitzades = partRestantsVendaActual;
                    partRestantsVendaActual = 0;
                }

                compres.Add(compraAnt);

                if (Utilitats.EsZero(partRestantsVendaActual))
                    break;
            }

            return compres;
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
        /// <param name="any"></param>
        /// <param name="inclouCartera">Indica si s'ha d'incloure els dividents.</param>
        /// <param name="inclouDividends"></param>
        /// <returns></returns>
        internal double pig2Total(int any, bool inclouCartera, bool inclouDividends)
        {
            var dataIni = new DateTime(any,1,1);
            var dataFi = dataIni.AddYears(1).AddMilliseconds(-1);

            return pig2Total(dataIni, dataFi, inclouCartera, inclouDividends);
        }

        /// <summary>
        /// Calcula perdues i guanys de les vendes reals més els dividents entre les dates, inclou participacions en cartera si -> inclouCartera=true.
        /// </summary>
        /// <param name="dataHoraInici"></param>
        /// <param name="dataHoraFinal"></param>
        /// <param name="inclouCartera">Indica si s'ha d'incloure els dividents.</param>
        /// <param name="inclouDividends">En la tributació a la renda els dividends tributen a part de les PiG de les accions. </param>
        /// <returns></returns>
        internal double pig2Total(DateTime? dataHoraInici, DateTime? dataHoraFinal, bool inclouCartera, bool inclouDividends)
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
        /// P i G de vendes reals o vendes reals i traspassades.
        /// </summary>
        /// <param name="dataHoraInici"></param>
        /// <param name="dataHoraFinal"></param>
        /// <param name="nomesVendesReals"></param>
        /// <returns></returns>
        internal double pig2Vendes(DateTime? dataHoraInici = null, DateTime? dataHoraFinal = null, bool nomesVendesReals = true)
        {
            return pig2Vendes(dataHoraInici.GetValueOrDefault(DateTime.MinValue), dataHoraFinal.GetValueOrDefault(DateTime.MaxValue), nomesVendesReals);
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


        #region ***** Mètodes que fan coses, com els catalans *****

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
        /// Calcula perdues i guanys del les participacions en cartera a una data. Inclou despeses. No inclou vendes reals ni dividends.
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

            return vendes.Sum(venda => venda.pig2Venda());
        }


        /// <summary>
        /// Calcula el cost original de les participacions en cartera. Inclou despeses. 
        /// </summary>
        /// <param name="dataHoraFinal">Si null calcula les participacions avui, sinò les que hi havia a la data.</param>
        /// <param name="numPartsMax">Limita el cost a num de participacions</param>
        /// <returns></returns>
        private double costOriginalEnCartera4(DateTime dataHoraFinal, double? numPartsMax = null)
        {
            var partsEnCartera = numParticipacionsEnData(dataHoraFinal);

            if (numPartsMax.HasValue && numPartsMax.Value > partsEnCartera)
                throw new ArgumentException("'numPartsMax' és més gran que les participacions en cartera.", "numPartsMax");

            resetParticipacionsDisponibles();

            var compresAnt = compresDeLaVenda4(dataHoraFinal, partsEnCartera).ToList();

            var partsPerCalcul = compresAnt.Sum(s => s._ParticipacionsUtilitzades);

            if (Utilitats.EsZero(partsPerCalcul))
                return 0;

            if (numPartsMax.HasValue)
                if (Utilitats.ComparaNumeros(numPartsMax.Value, partsPerCalcul, 3) > 0)
                    throw new ArgumentException("'numPartsMax' és més gran que les participacions disponibles", "numPartsMax");
                else
                    partsPerCalcul = numPartsMax.Value;


            double preuOrig2 = 0;
            foreach (var compra in compresAnt)
            {
                var parts = compra._ParticipacionsUtilitzades < partsPerCalcul ? compra._ParticipacionsUtilitzades : partsPerCalcul;

                preuOrig2 += compra.calculaPreuOrig2(parts);
                partsPerCalcul -= parts;

                if (Utilitats.EsZero(partsPerCalcul))
                    break;
            }
            return preuOrig2;
        }
        /// <summary>
        /// Torna les participacions en una data hora determinada. No te en compte els moviments del mateix dia fets en hora posterior.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private double numParticipacionsEnData(DateTime data)
        {
            /* *** No modifico data a final del dia perquè no em permet discriminar les participacions que hi havia abans del moviment 
             * si hi ha més d'un moviment en un dia. 
             */
            //data = Utilitats.DataFinalDia(data);

            var particComprades = MovimentsProducteUsuari.Where(w => w.Data <= data && w.TipusMoviment == TipusMoviment.Compra).Sum(s => s.Participacions);
            var particVenudes = MovimentsProducteUsuari.Where(w => w.Data <= data && w.TipusMoviment == TipusMoviment.Venda).Sum(s => s.Participacions);

            return Math.Round(particComprades - particVenudes, 5);
        }
        
        #endregion


        #region **** Mètodes cridats des de Test *****

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
            return costOriginalEnCartera2(numPartsMax);
        }


        public double pig2TotalTest(int any, bool inclouCartera, bool inclouDividends)
        {
            return pig2Total(any, inclouCartera, inclouDividends);
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