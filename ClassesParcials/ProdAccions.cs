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
            Program.Sessio.refrescaTaula(typeof(ProdAccions));
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
        /// <returns></returns>
        public static decimal Valor(DateTime data)
        {
            return Tuples.ToList().Sum(producte => producte.valorEnCartera(data));
        }
    }
}
