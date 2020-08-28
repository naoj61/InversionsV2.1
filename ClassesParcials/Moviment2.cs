using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Threading;
using Comuns;

namespace Inversions
{
    public partial class Moviment
    {
        /// <summary>
        /// Calcula el preu origen de les partticipacions 'numParts' del moviment. Inclou despeses. 
        /// Creat el 1/07/2020
        /// </summary>
        /// <param name="numParts">Num participacions a calcular.</param>
        /// <returns></returns>
        internal double calculaPreuOrig2(double? numParts = null)
        {
            if (!_EsCompra)
                throw new Exception("El moviment no és una compra.");

            var partics = numParts.GetValueOrDefault(_ParticipacionsDisponibles);

            if (Utilitats.ComparaNumeros(_ParticipacionsDisponibles, partics) < 0)
                throw new ArgumentException("El valor numparts és major que les participacions disponibles.", "numParts");

            var partsUtilitzades = Participacions - _ParticipacionsDisponibles;
            double preuOrig = 0;

            foreach (var desglosCompra in DesglosCompres)
            {
                if (partsUtilitzades >= desglosCompra.Participacions)
                {
                    partsUtilitzades -= desglosCompra.Participacions;
                    continue;
                }

                var partsPerCalcul = desglosCompra.Participacions - partsUtilitzades;
                partsUtilitzades = 0;

                if (Utilitats.ComparaNumeros(partics, partsPerCalcul) <= 0)
                {
                    partsPerCalcul = partics;
                    partics = 0;
                }
                else
                {
                    partics -= partsPerCalcul;
                }
                var despeses = Despeses.GetValueOrDefault() / Participacions * partsPerCalcul; // És la part proporcional de les despeses.
                preuOrig += desglosCompra.calculaPartsMovAPartsOrig(partsPerCalcul) * desglosCompra._PreuPartOrig + despeses;
            }

            return preuOrig;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal double pig2Venda()
        {
            if(!_EsVenda)
                throw new Exception("El moviment no és una venda.");

            double preuCost = 0;
            var compresAnt = Prod.compresAnteriors2(this).ToList();
            foreach (var compraAnt in compresAnt)
            {
                preuCost += compraAnt._Moviment.calculaPreuOrig2();
            }
            return Participacions * PreuParticipacio - preuCost;
        }


        #region **** Mètodes cridats des de Test *****

        public double calculaPreuOrig2Test(double? numParts = null)
        {
            return calculaPreuOrig2(numParts);
        }

        #endregion
    }
}
