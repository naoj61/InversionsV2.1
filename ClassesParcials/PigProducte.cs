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
    #region Structs

    public class CompraExt
    {
        public CompraExt(Moviment compra)
        {
            if (!compra._EsCompra)
                throw new Exception("El paràmetre 'compra' no és una compra");

            vCompra = compra;
        }

        public CompraExt(DesglosCompraExt desglosCompraExt) : this(desglosCompraExt._Compra)
        {
            vDesglosCompra.Add(desglosCompraExt);
        }

        private readonly Moviment vCompra;
        private readonly List<DesglosCompraExt> vDesglosCompra = new List<DesglosCompraExt>();

        public Moviment _Compra
        {
            get { return vCompra; }
        }


        //, compraExt.

        public double _PartsUtilitzades
        {
            get { return vDesglosCompra.Sum(s => s._PartsUtilitzades); }
        }

        public double _PartsOcupades
        {
            get { return vDesglosCompra.Sum(s => s._PartsOcupades); }
        }

        internal void addDesglos(DesglosCompraExt desglosCompra)
        {
            if (vDesglosCompra.Contains(desglosCompra))
            {
                var desg = vDesglosCompra.Single(w => w == desglosCompra);
                desg._PartsOcupades += desglosCompra._PartsOcupades;
                desg._PartsUtilitzades += desglosCompra._PartsUtilitzades;
            }
            else
                vDesglosCompra.Add(desglosCompra);
        }


        #region Equals

        public override bool Equals(object obj)
        {
            return Equals((CompraExt)obj);
        }

        public bool Equals(CompraExt other)
        {
            return _Compra == other._Compra;
        }

        public override int GetHashCode()
        {
            return _Compra.GetHashCode();
        }

        public static bool operator ==(CompraExt left, CompraExt right)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            // If one is null,return false.
            if ((object)left == null || (object)right == null)
            {
                return false;
            }

            return left._Compra == right._Compra;
        }

        public static bool operator !=(CompraExt left, CompraExt right)
        {
            return !(left == right);
        }

        #endregion Equals

        public override string ToString()
        {
            return _Compra.ToString();
        }
    }

    public class DesglosCompraExt
    {
        public DesglosCompraExt(DesglosCompra desgloçCompra)
        {
            vDesglosCompra = desgloçCompra;
        }

        private readonly DesglosCompra vDesglosCompra;

        public double _PartsUtilitzades { get; set; }
        public double _PartsOcupades { get; set; }

        public Moviment _Compra
        {
            get { return vDesglosCompra.MovCompra; }
        }

        public double _PartsDisponibles
        {
            get { return vDesglosCompra.Participacions - _PartsUtilitzades - _PartsOcupades; }
        }

        /// <summary>
        /// Son les participacions originals utilitzades en aquest moviment.
        /// </summary>
        public double _PartsUtilitzadesOrig
        {
            get { return vDesglosCompra.ParticipacionsOrig / vDesglosCompra.Participacions * _PartsUtilitzades; }
        }


        public DateTime _Data
        {
            get { return _Compra.Data; }
        }

        public DateTime _DataOrig
        {
            get { return vDesglosCompra._DataOrig; }
        }

        public static IEnumerable<DesglosCompraExt> OmpleLlista(IEnumerable<Moviment> compres)
        {
            List<DesglosCompraExt> list = new List<DesglosCompraExt>();
            foreach (Moviment compra in compres)
            {
                if (!compra._EsCompra)
                    throw new ArgumentException(String.Format(" Id:{0}. No és una compra.", compra.Id));

                list.AddRange(compra.DesglosCompres.Select(compre => new DesglosCompraExt(compre)));
            }
            return list;
        }

        #region Equals

        public override bool Equals(object obj)
        {
            return Equals((DesglosCompraExt)obj);
        }

        public bool Equals(DesglosCompraExt other)
        {
            return this.vDesglosCompra == other.vDesglosCompra;
        }

        public override int GetHashCode()
        {
            return vDesglosCompra.GetHashCode();
        }

        public static bool operator ==(DesglosCompraExt left, DesglosCompraExt right)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            // If one is null,return false.
            if ((object)left == null || (object)right == null)
            {
                return false;
            }

            return left.vDesglosCompra == right.vDesglosCompra;
        }

        public static bool operator !=(DesglosCompraExt left, DesglosCompraExt right)
        {
            return !(left == right);
        }

        #endregion Equals

        public override string ToString()
        {
            return vDesglosCompra.ToString();
        }
    }

    #endregion Structs


    public abstract partial class Producte
    {

        /// <summary>
        /// Torna la llista de les compres de les partipacions del producte en una data..
        /// la venda pot ser que encara no existeixi en la taula moviments o que siguin les participacions en cartera.
        /// </summary>
        /// <param name="dataHora">Es buscaran compres anteriors a aquesta data.</param>
        /// <param name="numPartipacions">Son les partipacions de les que buscaré les seves compres.
        /// Si null utilitza les participacions en cartera a la data.</param>
        /// <returns></returns>
        public IEnumerable<CompraExt> compresDePartipacionsEnData(DateTime? dataHora = null, double? numPartipacions = null)
        {
            var dComp = desglosCompresDePartipacionsEnData(dataHora, numPartipacions);

            //return dComp.GroupBy(g => g._Compra).Select(exts => new CompraExt(exts.Key)).ToList();

            List<CompraExt> compres = new List<CompraExt>();

            foreach (var desglosCompraExt in dComp)
            {
                // Creo la llista de compres de les participacions numPartipacions.
                if (compres.Any(w => w._Compra == desglosCompraExt._Compra))
                    compres.Single(w => w._Compra == desglosCompraExt._Compra).addDesglos(desglosCompraExt);
                else
                    compres.Add(new CompraExt(desglosCompraExt));                    
            }

            return compres;
        }


        /// <summary>
        /// Torna la llista de les desgloç compres de les partipacions del producte en una data.
        /// la venda pot ser que encara no existeixi en la taula moviments o que siguin les participacions en cartera.
        /// </summary>
        /// <param name="dataHora">Es buscaran compres anteriors a aquesta data.</param>
        /// <param name="numPartipacions">Son les partipacions de les que buscaré les seves compres.
        /// Si null utilitza les participacions en cartera a la data.</param>
        /// <returns></returns>
        public IEnumerable<DesglosCompraExt> desglosCompresDePartipacionsEnData(DateTime? dataHora = null, double? numPartipacions = null)
        {
            var dataH = dataHora.GetValueOrDefault(DateTime.Now);
            var numParts = numPartipacions.GetValueOrDefault(numParticipacionsEnData(dataH));

            if (Utilitats.EsZero(numParts))
                return new List<DesglosCompraExt>();


            var vendesAnt = MovimentsProducteUsuari.Where(w => w._EsVenda && w.Data < dataH).OrderBy(o => o.Data).ToList();
            var desglosCompresAnt = DesglosCompraExt.OmpleLlista(MovimentsProducteUsuari
                .Where(w => w._EsCompra && w.Data < dataH)).ToList();

            // Marco les participacions ocupades per vendes anteriors.
            double partsVenudesResten;
            foreach (var venda in vendesAnt)
            {
                var dataVenda = venda.Data;
                partsVenudesResten = venda.Participacions;

                foreach (var desgCompra in desglosCompresAnt.Where(w => w._Data < dataVenda && w._PartsDisponibles > 0).OrderBy(o=>o._DataOrig))
                {
                    if (Utilitats.ComparaNumeros(partsVenudesResten, desgCompra._PartsDisponibles) > 0)
                    {
                        partsVenudesResten -= desgCompra._PartsDisponibles;
                        desgCompra._PartsOcupades += desgCompra._PartsDisponibles;
                    }
                    else
                    {
                        desgCompra._PartsOcupades += partsVenudesResten;
                        break;
                    }
                }
            }

            // Marco les participacions utilitzades en aquesta venda.
            partsVenudesResten = numParts;
            foreach (var desgCompra in desglosCompresAnt.Where(w => w._PartsDisponibles > 0).OrderBy(o => o._DataOrig))
            {
                if (Utilitats.ComparaNumeros(partsVenudesResten, desgCompra._PartsDisponibles) > 0)
                {
                    partsVenudesResten -= desgCompra._PartsDisponibles;
                    desgCompra._PartsUtilitzades += desgCompra._PartsDisponibles;
                }
                else
                {
                    desgCompra._PartsUtilitzades += partsVenudesResten;
                    break;
                }
            }

            return desglosCompresAnt.Where(w => w._PartsUtilitzades > 0);
        }
    }
}