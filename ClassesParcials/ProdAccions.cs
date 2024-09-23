using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Comuns;

namespace Inversions
{
    public partial class ProdAccions
    {
        public static DbSet<ProdAccions> Tuples
        {
            get { return Program.Sessio.ProdAccions; }
        }

        public new static void RefrescaTaula()
        {
            Producte.RefrescaTaula();
        }

        public override TipusProducte _TipusProducte
        {
            get { return TipusProducte.Accions; }
        }

        public override string _NomProducte
        {
            get { return _NomEmpresa; }
            set { }
        }

        public override string _TipusNomProducte
        {
            get { return "Accions - " + _NomEmpresa; }
        }

        public override Mercat _Mercat
        {
            get { return Mercat; }
            set { Mercat = value; }
        }

        public override string _NomMercat
        {
            get { return Mercat == null ? null :Mercat.Nom; }
        }

        public override string _Isin
        {
            get { return null; }
        }

        public override string _Descripcio
        {
            get { return null; }
        }


        /// <summary>
        /// Valor de les accions en cartera en una data determinada.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="esCripto">True=Només criptos. False=Només accions. Null=Accions i criptos.</param>
        /// <returns></returns>
        public static decimal Valor(DateTime data, bool? esCripto)
        {
            IEnumerable<ProdAccions> xx = Tuples;

            if (esCripto.HasValue)
            {
                if (esCripto.Value)
                    // Només criptos
                    xx = xx.Where(w => w.MercatId == 4);
                else
                    // Només accions
                    xx = xx.Where(w => w.MercatId != 4);
            }

            return xx.Sum(producte => producte.valorEnCartera(data));
        }
    }
}
