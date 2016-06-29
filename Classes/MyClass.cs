using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Windows.Forms;

namespace Inversions
{
    public class MyClass : InversionsBDContext
    {
        internal static readonly MyClass Sessio;
        internal static readonly bool DesignMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        static MyClass()
        {
            Sessio = new MyClass();
            Sessio.Configuration.AutoDetectChangesEnabled = false; // Si poso true, dona error quan inserto una fila i l'esborro en la mateixa sessió.
            Sessio.Configuration.LazyLoadingEnabled = true;
        }


        /// <summary>
        /// Torna la data del dia anterior laborable.
        /// No té calendari de festius, només te en compte dissabtes i diumenges.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        internal static DateTime AnteriorDiaLaborable(DateTime data)
        {
            DateTime dataAnt = data;
            do
            {
                dataAnt = dataAnt.AddDays(-1);

            } while (dataAnt.DayOfWeek == DayOfWeek.Saturday || dataAnt.DayOfWeek == DayOfWeek.Sunday);

            return dataAnt;
        }
    }
}