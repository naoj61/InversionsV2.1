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
        /// <returns></returns>
        public static double Pig2(TipusProducte tipusProducte, bool inclouCartera)
        {
            return Pig2(tipusProducte, DateTime.MinValue, DateTime.MaxValue, inclouCartera);
        }


        /// <summary>
        /// PiG de tots els productes en un any. Vendes reals dins el periode.
        /// Preu compra --> Preu origen.
        /// Preu venda  --> Preu venda.
        /// </summary>
        /// <param name="tipusProducte"></param>
        /// <param name="any"></param>
        /// <param name="inclouCartera"></param>
        /// <returns></returns>
        public static double Pig2(TipusProducte tipusProducte, int any, bool inclouCartera)
        {
            return Pig2(tipusProducte, new DateTime(any, 1, 1), new DateTime(any + 1, 1, 1).AddMilliseconds(-1), inclouCartera);
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
        /// <returns></returns>
        internal static double Pig2(TipusProducte tipusProducte,
            DateTime dataInici, DateTime dataFinal, bool inclouCartera)
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
            return prods.Sum(prod => prod.pig2Total(dataInici, dataFinal, inclouCartera));
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
            return costOriginalEnCartera3(DateTime.MaxValue, numPartsMax);
        }


        public IEnumerable<Moviment> compresAnteriors3Test(DateTime dataHora, double numParticions)
        {
            return compresAnteriors3(dataHora, numParticions);
        }

        /// <summary>
        /// Torna la llista de les compres a les que afecten aquesta venda.
        /// </summary>
        /// <param name="dataHora">Es buscaran compres i vendes anteriors a aquesta data.</param>
        /// <param name="numParticions">Son les particions venudes a les que buscaré les seves compres.</param>
        /// <returns></returns>
        internal IEnumerable<Moviment> compresAnteriors3(DateTime dataHora, double numParticions)
        {
            // Totes les compres anteriors a la venda.
            var compresAnt = MovimentsProducteUsuari.Where(w => w._EsCompra && w.Data < dataHora).OrderBy(o => o.Data).ToList();

            // Totes les vendes anteriors a la venda.
            var vendesAnt = new Queue<Moviment>(MovimentsProducteUsuari.Where(w => w._EsVenda && w.Data < dataHora).OrderBy(o => o.Data));

            // *** Reinicia _ParticipacionsDisponibles ***
            Moviment.ResetParticipacionsDisponibles(compresAnt);


            List<Moviment> compres = new List<Moviment>();
            double participacionsRestantsCompra = 0;
            var partRestantsVenda = numParticions;
            foreach (var compraAnt in compresAnt)
            {
                if (partRestantsVenda <= 0)
                    // Ja no queden participacions de la venda per repartir.
                    break;

                if (compres.Any())
                {
                    // Ja he trobat la primera compra, a partir d'aquí afegeixo totes les compres fins a repartir totes les participacions.
                    partRestantsVenda = compraAnt.trobaParticipacionsDisponiblesDesgloçCompra(0, partRestantsVenda);
                    compres.Add(compraAnt);

                    continue;
                }

                participacionsRestantsCompra += compraAnt._ParticipacionsDisponibles;

                while (vendesAnt.Count > 0 && Utilitats.ComparaNumeros(participacionsRestantsCompra, 0) > 0)
                {
                    // Resta de la compra les vendes anteriors.
                    var venda = vendesAnt.Dequeue();
                    participacionsRestantsCompra -= venda.Participacions;
                }

                if (Utilitats.ComparaNumeros(participacionsRestantsCompra, 0) > 0)
                {
                    // Si encara queden participacions en la compra, significa que és la primera que pertany a la venda.

                    var partsUtilit = compraAnt.Participacions - participacionsRestantsCompra;

                    if (partsUtilit < 0 && Utilitats.EsZero(partsUtilit, 3))
                        // Si és negatiu per decimes, poso 0.
                        partsUtilit = 0;

                    partRestantsVenda = compraAnt.trobaParticipacionsDisponiblesDesgloçCompra(partsUtilit, partRestantsVenda);
                    compres.Add(compraAnt);
                }
            }

            return compres;
        }


        /// <summary>
        /// Calcula perdues i guanys de les vendes reals més els dividents entre les dates, inclou participacions en cartera si -> inclouCartera=true.
        /// </summary>
        /// <param name="any"></param>
        /// <param name="inclouCartera">Indica si s'ha d'incloure els dividents.</param>
        /// <returns></returns>
        internal double pig2Total(int any, bool inclouCartera)
        {
            var dataIni = new DateTime(any,1,1);
            var dataFi = dataIni.AddYears(1).AddMilliseconds(-1);

            return pig2Total(dataIni, dataFi, inclouCartera);
        }

        /// <summary>
        /// Calcula perdues i guanys de les vendes reals més els dividents entre les dates, inclou participacions en cartera si -> inclouCartera=true.
        /// </summary>
        /// <param name="dataHoraInici"></param>
        /// <param name="dataHoraFinal"></param>
        /// <param name="inclouCartera">Indica si s'ha d'incloure els dividents.</param>
        /// <returns></returns>
        internal double pig2Total(DateTime? dataHoraInici = null, DateTime? dataHoraFinal = null, bool inclouCartera = true)
        {
            var dataIni = dataHoraInici.GetValueOrDefault(DateTime.MinValue);
            var dataFi = dataHoraFinal.GetValueOrDefault(DateTime.MaxValue);

            var pigVendesReals = pig2Vendes(dataIni, dataFi, true);
            var pigEnCartera = inclouCartera ? pig2EnCartera(dataFi, null) : 0;
            var divid = dividends(dataIni, dataFi);
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

            var preuOrig = costOriginalEnCartera3(dataHoraFinal, parts);
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
        private double costOriginalEnCartera3(DateTime dataHoraFinal, double? numPartsMax = null)
        {
            var partsEnCartera = numParticipacionsEnData(dataHoraFinal);

            if (numPartsMax.HasValue && numPartsMax.Value > partsEnCartera)
                throw new ArgumentException("'numPartsMax' és més gran que les participacions en cartera.", "numPartsMax");

            Moviment.ResetParticipacionsDisponibles(this);

            var compresAnt = compresAnteriors3(dataHoraFinal, partsEnCartera).ToList();

            var partsPerCalcul = compresAnt.Sum(s => s._ParticipacionsDisponibles);

            if (Utilitats.EsZero(partsPerCalcul))
                return 0;

            if (numPartsMax.HasValue)
                if (Utilitats.ComparaNumeros(numPartsMax.Value, partsPerCalcul) > 0)
                    throw new ArgumentException("'numPartsMax' és més gran que les participacions disponibles", "numPartsMax");
                else
                    partsPerCalcul = numPartsMax.Value;


            double preuOrig2 = 0;
            foreach (var movimentCompra in compresAnt)
            {
                var parts = movimentCompra._ParticipacionsDisponibles < partsPerCalcul ? movimentCompra._ParticipacionsDisponibles : partsPerCalcul;

                preuOrig2 += movimentCompra.calculaPreuOrig2(parts);
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
   

        public double pig2TotalTest(int any, bool inclouCartera = true)
        {
            return pig2Total(any, inclouCartera);
        }

        public double pig2TotalTest(DateTime? dataHoraInici = null, DateTime? dataHoraFinal = null, bool inclouCartera = true)
        {
            return pig2Total(dataHoraInici, dataHoraFinal, inclouCartera);
        }

        public double pig2ProducteTest(DateTime? dataHoraFinal = null)
        {
            return pig2Producte(dataHoraFinal);
        }

        #endregion
    }
}