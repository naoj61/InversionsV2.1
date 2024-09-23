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
        /// Calcula el dividend que correspon a una compra. Només per accions. Pels fons torna 0.
        /// </summary>
        /// <returns></returns>
        internal decimal dividendCompra4()
        {
            if (!_EsCompra)
                throw new Exception("El moviment no és una compra");

            if (Prod is ProdFons)
                return 0;

            var dividends = Prod.MovimentsProducteUsuari.Where(mov => mov._EsDividents && mov.Data > Data).OrderBy(o=>o.Data).ToList();

            decimal div = 0;
            foreach (var dividend in dividends)
            {
                var partsEnCarteraDiv = Prod.partsEnCartera(dividend.Data);
                
                // Compres a les que afecta el dividend.
                var compresDiv = Prod.compresDePartipacionsEnData4(dividend.Data, partsEnCarteraDiv, false);
                
                // Miro si aquesta compra està afectada.
                var compraDiv = compresDiv.SingleOrDefault(w => w._Id == Id);
                
                if (compraDiv != null)
                {
                    // Si aquesta compra està afectada, acumulo el dividend.
                    div += dividend._PreuParticipacio / partsEnCarteraDiv * compraDiv._PartsUtilitzades;
                }
            }

            return div;
        }


        #endregion *** Mètodes bàsics ***


        #region *** Test ***

        public decimal dividendsCompra4Test()
        {
            return dividendCompra4();
        }

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