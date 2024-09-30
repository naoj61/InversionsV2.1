using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Threading;
using Comuns;

namespace Inversions
{
    public partial class Moviment
    {
        #region *** Atributs ***
        
        public decimal _ImportBrut
        {
            get
            {
                decimal result;
                if (Utilitats.EsZero(Participacions))
                {
                    result = PreuParticipacio;
                }
                else
                {
                    result = PreuParticipacio * Participacions;
                }
                return result;
            }
        }

        public decimal _ImportNet
        {
            get
            {
                decimal result;
                if (Utilitats.EsZero(Participacions))
                {
                    result = PreuParticipacio;
                }
                else
                {
                    if (_EsCompra)
                        result = PreuParticipacio * Participacions + Despeses.GetValueOrDefault();
                    else if (_EsVenda)
                        result = PreuParticipacio * Participacions - Despeses.GetValueOrDefault();
                    else
                        result = PreuParticipacio * Participacions;
                }
                return result;
            }
        }
        

        public bool _EsTraspas
        {
            get { return RefTraspas != null; }
        }

        /// <summary>
        /// Pot ser compra o traspas compra.
        /// </summary>
        public bool _EsCompra
        {
            get { return TipusMoviment == TipusMoviment.Compra; }
        }

        /// <summary>
        /// Compra. No traspàs.
        /// </summary>
        public bool _EsCompraReal
        {
            get { return _EsCompra && !_EsTraspas; }
        }

        /// <summary>
        /// Pot ser venda o traspàs venda.
        /// </summary>
        public bool _EsVenda
        {
            get { return TipusMoviment == TipusMoviment.Venda; }
        }

        /// <summary>
        /// Venda. no traspàs
        /// </summary>
        public bool _EsVendaReal
        {
            get { return _EsVenda && !_EsTraspas; }
        }

        public bool _EsDividents
        {
            get { return TipusMoviment == TipusMoviment.Dividends; }
        }



        /// <summary>
        /// És la referéncia del la venda traspàs sobre la compra.
        /// En la BD és una relació de 0..1-->*, però hauria de ser de 0..1-->1.
        /// Per aixó només torno el primer element, que hauria de ser l'unic, si existeix.
        /// </summary>
        public Moviment _MovimentRefCompra
        {
            get { return RefTraspas1.FirstOrDefault(); }
        }


        /// <summary>
        /// És la referéncia del la venda traspàs sobre la compra.
        /// En la BD és una relació de 0..1-->*, però hauria de ser de 0..1-->1.
        /// Per aixó només torno el primer element, que hauria de ser l'unic, si existeix.
        /// </summary>
        public bool _EsOrigen
        {
            get { return DesglosCompres.Count == 1 && DesglosCompres.Any(w=>w.MovCompraId == w.MovCompraOrigId); }
        }

        #endregion *** Atributs ***


        #region *** Mètodes ***

        public static DbSet<Moviment> Tuples
        {
            get { return Program.Sessio.Moviments; }
        }

        public static void RefrescaTaula()
        {
            Program.Sessio.refrescaTaula(typeof(Moviment));

            // Fa que es recarreguin el "ICollection" de la taula.
            var xx = Tuples.ToList();
        }

        public static IEnumerable<Moviment> MovimentsUsuari
        {
            get { return Tuples.Where(w => w.UsuariId == Usuari.Seleccionat.Id); }
        }


        private IEnumerable<VendaExt> vendesDeLaCompra(bool pigOrig = false)
        {
            decimal partsEnCartera;
            List<DesglosCompraExt> desglosCompraExt;

            return Prod.vendesDeCompra4(this, pigOrig, out partsEnCartera, out desglosCompraExt).ToList();
        }


        /// <summary>
        /// Torna la llista de les compres afectades per aquesta venda.
        /// </summary>
        /// <returns></returns>
        internal IEnumerable<CompraExt> compresDeLaVenda()
        {
            if (!_EsVenda)
                throw new ArgumentException(String.Format("El moviment ha de ser una venda. Id={0}", Id));

            return Prod.compresDePartipacionsEnData4(Data, Participacions);
        }



        /// <summary>
        /// Calcula el divident que s'ha cobrat per la compra.
        /// Pot ser que hi hagi més d'un divident o que algun divident no correspongui completament a les accions de la compra.
        /// </summary>
        /// <returns></returns>
        private decimal dividentsDeLaCompra()
        {
            if (!_EsCompra)
                throw new Exception(String.Format("L'Id:{0}. Ha de ser una compra", Id));
            
            decimal divident = 0;
            var dataIni = Data;
            var dataFi = vendesDeLaCompra().Any() ? vendesDeLaCompra().Last()._Data : DateTime.Now;
            var dividents = Moviment.MovimentsUsuari.Where(w => w._EsDividents && w.Data >= dataIni && w.Data <= dataFi).ToList();
            foreach (var div in dividents)
            {
                var partsVenudes = vendesDeLaCompra().Where(w => w._Data < div.Data).Sum(s => s._PartsUtilitzades);
                var partsEnDataDivident = Prod.partsEnCartera(div.Data);
                divident += div._ImportBrut / partsEnDataDivident * (Participacions - partsVenudes);
            }

            return divident;
        }


        /// <summary>
        /// Al crear una nova compra, s'ha de crear el desgloç de les compres originals que li corresponen.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="vendaTraspas"></param>
        public void desgloçarCompra(InversionsBDContext connexio, Moviment vendaTraspas)
        {
            if (TipusMoviment != TipusMoviment.Compra)
                throw new ArgumentException(String.Format("El moviment ha de ser una compra. Id={0}", Id));

            if (_EsTraspas)
            {
                // ** És un traspàs.

                var desgloçCompresVenda = vendaTraspas.Prod.desglosCompresDeParticipacionsEnData4(vendaTraspas.Data, vendaTraspas.Participacions, true).ToList();

                var agrupatPerIdOrig = desgloçCompresVenda.OrderBy(o => o._DataOrig).GroupBy(g => g._CompraOrig)
                    .Select(s => new
                    {
                        movOrig = s.Key,
                        sumPartsUtil = s.Sum(x => x._PartsUtilitzades),
                        sumPartsUtilOrig = s.Sum(x => x._PartsUtilitzadesOrig)
                    });

                foreach (var grup in agrupatPerIdOrig)
                {
                    if (Utilitats.EsZero(grup.sumPartsUtil))
                        continue;

                    DesglosCompra desglosCompra = connexio.DesglosCompres.Create();

                    // ** Per obtenir parts desgloç Traspas C
                    desglosCompra.Participacions =grup.sumPartsUtil / vendaTraspas.Participacions * Participacions;

                    // ** Per obtenir parts orig desgloç Traspas C
                    desglosCompra.ParticipacionsOrig = (grup.sumPartsUtilOrig);

                    DesglosCompres.Add(desglosCompra);
                    grup.movOrig.DesglosCompresOrig.Add(desglosCompra);

                    connexio.SaveChanges();
                }
            }
            else
            {
                // ** El desgloç és una fila lligada al propi moviment.
                DesglosCompra desglosCompra = connexio.DesglosCompres.Create();

                desglosCompra.Participacions = this.Participacions;
                desglosCompra.ParticipacionsOrig = this.Participacions;

                DesglosCompres.Add(desglosCompra);
                DesglosCompresOrig.Add(desglosCompra);

                connexio.SaveChanges();
            }
        }

        #endregion *** Mètodes ***
        

        #region **** Mètodes cridats des de Test *****

        public decimal pigCompraTest(bool ambCartera, bool pigOrigen, uint? any, bool ambDespeses = true)
        {
            return pigCompra4(ambDespeses, pigOrigen, ambCartera);
        }

        public IEnumerable<VendaExt> vendesDeLaCompraTest()
        {
            return vendesDeLaCompra();
        }
        
        public decimal dividentsDeLaCompraTest()
        {
            return dividentsDeLaCompra();
        }
        
        #endregion


        #region Overrides

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(Moviment a, Moviment b)
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

        public static bool operator !=(Moviment a, Moviment b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Moviment))
                return false;

            return this == (Moviment) obj;
        }

        public override string ToString()
        {
            return Id.ToString(CultureInfo.InvariantCulture);
        }

        #endregion

    }
}
