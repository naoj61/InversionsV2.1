using System;
using System.Collections.Generic;
using System.Linq;

namespace Inversions
{
    public partial class Moviment
    {
        #region *** Mètodes bàsics ***

        /// <summary>
        /// Torna el PiG de la compra, real o no.
        /// </summary>
        /// <param name="inclouDespeses"></param>
        /// <param name="pigOrig"></param>
        /// <param name="ambCartera"></param>
        /// <returns></returns>
        internal decimal pigCompra4(bool inclouDespeses, bool pigOrig, bool ambCartera)
        {
            if (!_EsCompra)
                throw new Exception("El moviment no és una compra");

            decimal partsEnCartera;
            List<DesglosCompraExt> desglosCompraExt;
            var vendes = Prod.vendesDeCompra4(this, pigOrig, out partsEnCartera, out desglosCompraExt).ToList();
            desglosCompraExt = desglosCompraExt.Where(w => w._Compra == this).ToList();

            decimal importActualPartsEnCartera = 0;
            if (ambCartera)
            {
                importActualPartsEnCartera = partsEnCartera * Prod._PreuParticipacioActual;
            }

            var importPartsVenudes = vendes.Sum(s => s._PartsUtilitzades * s._PreuParticipacio);

            decimal importCompra;
            if (pigOrig)
            {
                importCompra = desglosCompraExt.Sum(s => s._PartsUtilitzadesOrig * s._PreuParticipacioOrig);
                if (ambCartera)
                {
                    importCompra += desglosCompraExt.Where(desgC => desgC._Compra == this)
                        .Sum(desgC => desgC._PartsDisponiblesOrig * desgC._PreuParticipacioOrig);
                }
            }
            else if (ambCartera)
                importCompra = _ImportBrut;
            else
                importCompra = (Participacions - partsEnCartera) * PreuParticipacio;

            var pig = importActualPartsEnCartera + importPartsVenudes - importCompra;

            var despeses = inclouDespeses
                ? vendes.Sum(s => s._DespesesPartsUtilitzades) + Despeses.GetValueOrDefault()
                : 0;

            return pig - despeses;
        }

        /// <summary>
        /// PiG de la venda
        /// </summary>
        /// <param name="pigOrig"></param>
        /// <param name="inclouDespeses"></param>
        /// <param name="utilitzarPiGVendaReal">Indica si s'ha de agafar el valor del PiG del camp: 'PiGVendaReal'.</param>
        /// <returns></returns>
        internal decimal pigVenda4(bool pigOrig, bool inclouDespeses, bool utilitzarPiGVendaReal)
        {
            decimal despesesCompres;
            var pig = Prod.pigVenda4(this, pigOrig, utilitzarPiGVendaReal, out despesesCompres);

            if (inclouDespeses)
                pig -= (despesesCompres + Despeses.GetValueOrDefault());

            return pig;
        }


        /// <summary>
        /// Torna l'import dels dividents cobrats que corresponen a la compra.
        /// </summary>
        /// <param name="dataCalculDividend">Si una venda busca el divident, Tant la compra com el divident han de saer d'abans que la venda</param>
        /// <returns></returns>
        internal decimal dividendsCompra4(DateTime dataCalculDividend)
        {
            /* 
             * Si una venda te una compra que li corresponen dividends però la venda és anterior al dividend, no li corrrespon dividend,
             * però en una venda posterior podria ser que encara que no utilitzi totes les participacions de la compra si que li correspondrien
             * tots els dividends que a l'artra venda no li corresponien.
             * Aixó és un merder i no em vull compñicar la vida per tant poca cosa.
             */

            throw new NotImplementedException("No utilitzar aquesta funció, molt complicat");

            if (!_EsCompra)
                throw new Exception("El moviment no és una compra");

            // Busco els dividents amb data superior a la compra.
            var divs = MovimentsUsuari.Where(mov => mov.ProdId == ProdId && mov.Data >= Data && mov.Data < dataCalculDividend && mov._EsDividents).ToList();

            if (divs.Count == 0)
                return 0;

            // A partir de les participacions en cartera a la data de cada divident, miro quines compres li corresponen.
            decimal divCompra = 0;
            foreach (var dividend in divs)
            {
                var partsEnDataDivident = Prod.partsEnCartera(dividend.Data);
                var compraExt = Prod.basicDesglosCompresDeParticipacionsEnData4(dividend.Data, partsEnDataDivident, false).SingleOrDefault(s => s._Compra == this);
                if (compraExt != null)
                {
                    // Si alguna compra coincideix amb la del paràmetre, reparteixo els dividents entre les participacions que li corresponguin
                    var div = dividend.PreuParticipacio / partsEnDataDivident * compraExt._PartsUtilitzades;
                    divCompra += div;
                }
            }

            return divCompra;
        }

        #endregion *** Mètodes bàsics ***


        #region *** Test ***

        public decimal pigVenda4Test(bool pigOrig, bool inclouDespeses, bool utilitzarPiGVendaReal = true)
        {
            return pigVenda4(pigOrig, inclouDespeses, utilitzarPiGVendaReal);
        }

        public decimal pigCompra4Test(bool inclouDespeses, bool pigOrig, bool ambCartera)
        {
            return pigCompra4(inclouDespeses, pigOrig, ambCartera);
        }
        
        #endregion *** Test ***
    }
}