using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms.VisualStyles;
using Comuns;

namespace Inversions
{
    public partial class ProdFons
    {
        public override IEnumerable<MovimentCompra> compresRealsPerParticipacionsEnCartera(DateTime data)
        {
            var dataFinalDia = Utilitats.DataHoraFinalDia(data);
            var numPartEnData = numParticipacionsEnCartera(dataFinalDia);
            List<MovimentCompra> movs = new List<MovimentCompra>();

            if (Utilitats.EsZero(numPartEnData))
                return movs;

            var asd = compresPerParticipacionsEnCartera(data).OrderByDescending(o => o._Moviment.Data);
            foreach (var moviment in asd)
            {
                if (moviment._Moviment._EsTraspas)
                {
                    var movVenda = Program.Sessio.Moviments.Single(s => s.Id == moviment._Moviment.IdRefVenda);
                    var dataAnteriorVenda = movVenda.Data.AddDays(-1);
                    IEnumerable<MovimentCompra> xx = movVenda.Prod.compresRealsPerParticipacionsEnCartera(dataAnteriorVenda);

                    foreach (var moviment1 in xx.Where(mov => !movs.Contains(mov)))
                    {
                        movs.Add(moviment1);
                    }
                }
                else
                {
                    var mov = moviment._Moviment.Clone();

                    if (numPartEnData <= mov.Participacions)
                        mov.Participacions = numPartEnData;

                    movs.Add(new MovimentCompra(mov, mov.Participacions));

                    numPartEnData -= mov.Participacions;

                    if (numPartEnData <= 0)
                        break;
                }
            }

            return movs;
        }


        public override TipusProducte _TipusProducte
        {
            get { return TipusProducte.Fons; }
        }

        public override string _NomProducte
        {
            get { return Nom; }
        }

        public override string _TipusNomProducte
        {
            get { return "Fons - " + Nom + " - " + _NomEmpresa; }
        }


        /// <summary>
        /// PiG de tots els fons en una data determinada.
        /// </summary>
        /// <param name="dataFi"></param>
        /// <returns></returns>
        public static double PiG(DateTimeFinalDia dataFi)
        {
            return Enumerable.Sum(Program.Sessio.Productes.Where(w => w is ProdFons), producte => producte.pigValorat(dataFi));
        }


        /// <summary>
        /// Valor dels fons en cartera en una data determinada.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static double Valor(DateTimeFinalDia data)
        {
            double saldo = 0;

            foreach (Producte producte in Program.Sessio.Productes.Where(w => w is ProdFons))
            {
                saldo += producte.valorEnCartera(data);
            }

            return saldo;
        }
    }
}
