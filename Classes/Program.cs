using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using Inversions.GUI;

namespace Inversions
{
    static class Program
    {
        internal static readonly InversionsBDContext Sessio;
        internal static readonly bool DesignMode = LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        static Program()
        {
            Sessio = new InversionsBDContext();
            Sessio.Configuration.AutoDetectChangesEnabled = false; // Si poso true, dona error quan inserto una fila i l'esborro en la mateixa sessió.
            Sessio.Configuration.LazyLoadingEnabled = true;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                // Valida arguments.
                if (args.Count() != 1)
                {
                    throw new ArgumentException("És obligatori el directori de la BD com únic argument.");
                }
                if (!Directory.Exists(args[0]))
                {
                    throw new ArgumentException("El directori de la BD no existeix.");
                }
                if (!File.Exists(Path.Combine(args[0], "InversionsBD.mdf")))
                {
                    throw new ArgumentException("La BD 'InversionsBD.mdf' no existeix en el directori: " + args[0]);
                }

                // Informa la variable |DataDirectory|, s'utilitza en App.config.
                AppDomain.CurrentDomain.SetData("DataDirectory", args[0]);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Principal());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
