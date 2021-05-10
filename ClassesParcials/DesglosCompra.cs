using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using Comuns;

namespace Inversions
{
    public partial class DesglosCompra
    {

        #region *** Atributs ***

        public double _PreuParticipacioOrig
        {
            get { return MovCompraOrig.PreuParticipacio; }
        }

        public double _PreuParticipacio
        {
            get { return MovCompra.PreuParticipacio; }
        }

        public DateTime _DataOrig
        {
            get { return MovCompraOrig.Data; }
        }


        public double _ParticipacionsDisponiblesOrig
        {
            get { return ParticipacionsOrig / Participacions * _ParticipacionsDisponibles; }
        }

        // todo He de diferenciar entre participacions Ocupades(per altres moviments), Utilitzades(en aquest moviment) i Disponibles(la resta).

        /// <summary>
        /// L'utilitzo per saber les participacions disponibles que poden no ser les mateixes que les del moviment.
        /// </summary>
        public double _ParticipacionsDisponibles
        {
            get { return vParticipacionsDisponibles.GetValueOrDefault(Participacions); }
            set
            {
                if (Utilitats.ComparaNumeros(value, Participacions, 4) > 0)
                    throw new Exception("El valor no pot ser superior a 'Participacions'");
                vParticipacionsDisponibles = value;
            }
        }
        private double? vParticipacionsDisponibles;

        #endregion *** Atributs ***

        #region *** Mètodes ***

       /// <summary>
        /// Reseteja ParticipacionsDisponibles dels moviments del paràmetre.
       /// </summary>
       /// <param name="desglosCompres"></param>
        public static void ResetParticipacionsDisponibles(IEnumerable<DesglosCompra> desglosCompres)
        {
            foreach (var desglosCompra in desglosCompres)
            {
                desglosCompra.resetParticipacionsDisponibles();
            }
        }

        /// <summary>
        /// Reseteja ParticipacionsDisponibles.
        /// </summary>
        internal void resetParticipacionsDisponibles()
        {
            vParticipacionsDisponibles = null;
        }

        /// <summary>
        /// Converteix el número de participacions del moviment al numero de particions originals.
        /// </summary>
        /// <param name="partsDelMoviment"></param>
        /// <returns></returns>
        internal double calculaPartsMovAPartsOrig(double partsDelMoviment)
        {
            if (Utilitats.ComparaNumeros(partsDelMoviment, Participacions) > 0)
                throw new ArgumentException("El valor de partsDelMoviment és més gran que el total de particions.");
            
            return partsDelMoviment / Participacions * ParticipacionsOrig;
        }


        /// <summary>
        /// Torna les participacions que encara hi ha en cartera de una compra real. No serveix per traspassos.
        /// La compra ha de pertanyer a un fons d'inversió.
        /// </summary>
        /// <param name="compra"></param>
        /// <returns></returns>
        public static double PartsEnCarteraCompra(Moviment compra)
        {
            if (!compra._EsCompraReal)
                throw new Exception(String.Format("L'Id:{0}, no és una compra real", compra.Id));

            if (!(compra.Prod is ProdFons))
                throw new Exception(String.Format("L'Id:{0}, no pertany a un fons d'inversió", compra.Id));

            // Si és una compra real, només hi pot haver un element a DesglosCompres.
            var desgloç = compra.DesglosCompres.Single();
          
            return desgloç.partsEnCarteraCompra(compra.Participacions);
        }

        /// <summary>
        /// Torna les participacions que encara hi ha en cartera de una compra real. No serveix per traspassos.
        /// La compra ha de pertanyer a un fons d'inversió.
        /// </summary>
        /// <param name="parts">Participacions que queden per vendre.</param>
        /// <returns></returns>
        private double partsEnCarteraCompra(double parts)
        {
            var compraOrig = MovCompraOrig;
            var compra = MovCompra;
            double participEnCartera;
            var vendes = compra.vendesDeLaCompra(out participEnCartera);
           
            foreach (var venda in vendes)
            {
                if (venda._EsTraspas)
                {
                    // venda.Id==100 dona error.
                    var cOrig = venda._MovimentRefCompra.DesglosCompres.SingleOrDefault(w => w.MovCompraOrig == compraOrig);
                    if (cOrig != null) 
                        parts = cOrig.partsEnCarteraCompra(parts);
                }
                else
                {
                    var pa = ParticipacionsOrig / compra.Participacions * venda._ParticipacionsDisponibles;
                    parts -= pa;
                }
            }

            return parts;
        }

        #endregion *** Mètodes ***

        #region Overrides

        public override int GetHashCode()
        {
            return Id;
        }

        public static bool operator ==(DesglosCompra a, DesglosCompra b)
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

        public static bool operator !=(DesglosCompra a, DesglosCompra b)
        {
            return !(a == b);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is DesglosCompra))
                return false;

            return this == (DesglosCompra)obj;
        }

        public override string ToString()
        {
            return String.Format("Id={0}. MovId={1}. MovOrigId={2}", Id, MovCompraId, MovCompraOrigId);
        }

        #endregion
    }
}
