using System;
using System.CodeDom;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Comuns;
using Inversions.GUI;

namespace Inversions
{
    internal static class Program
    {
        internal static InversionsBDContext Sessio;
        internal static readonly bool RuntimeMode = LicenseManager.UsageMode == LicenseUsageMode.Runtime;
        //internal static Usuari UsuariSeleccionat;
        internal static FileInfo FitxerLog = null;
        internal static readonly Version Versio = Assembly.GetExecutingAssembly().GetName().Version;


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
        private static void Main(string[] args)
        {
            FitxerLog = Comuns.Utilitats.LlegeixFitxerLog();
            try
            {
                string bd = null;
                int? idUsuari = null;

                foreach (var arg in args)
                {
                    if (arg.StartsWith("Bd:", StringComparison.CurrentCultureIgnoreCase))
                        if (bd == null)
                            bd = arg.Remove(0, 3);
                        else
                            throw new ArgumentException("Hi ha més d'un paràmetre 'Bd'");
                    else if (arg.StartsWith("IdUsuari:", StringComparison.CurrentCultureIgnoreCase))
                        if (idUsuari == null)
                            idUsuari = Convert.ToInt32(arg.Remove(0, 9));
                        else
                            throw new ArgumentException("Hi ha més d'un paràmetre 'idUsuari'");
                    else
                        throw new ArgumentException("Hi ha un paràmetre desconegut '" + arg + "'");
                }

                if (bd == null)
                    throw new ArgumentException("Falta el paràmetre 'Bd:'");

                if (idUsuari == null)
                    throw new ArgumentException("Falta el paràmetre 'idUsuari:'");


                // Valida arguments.
                //if (args.Count() != 1)
                //{
                //    throw new ArgumentException("És obligatori el directori de la BD com únic argument.");
                //}
                //if (!Directory.Exists(args[0]))
                //{
                //    throw new ArgumentException("El directori de la BD no existeix.");
                //}
                //if (!File.Exists(Path.Combine(args[0], "InversionsBD.mdf")))
                //{
                //    throw new ArgumentException("La BD 'InversionsBD.mdf' no existeix en el directori: " + args[0]);
                //}

                // Informa la variable |DataDirectory|, s'utilitza en App.config.
                AppDomain.CurrentDomain.SetData("DataDirectory", bd);

                //Usuari.Seleccionat = Sessio.Usuaris.Single(s => s.Id == idUsuari);
                Usuari.Seleccionat = Sessio.Usuaris.Find(idUsuari);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Principal());
            }
            catch (Exception ex)
            {
                Comuns.Utilitats.EscriuLog(ex, FitxerLog, Versio);
                //MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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


        /// <summary>
        /// Compara dos valor double, però eliminant decimals residuals.
        /// </summary>
        /// <param name="valor1"></param>
        /// <param name="valor2"></param>
        /// <param name="tolerancia"></param>
        /// <returns></returns>
        internal static bool SonIguals(double valor1, double valor2, double tolerancia = 0.000001)
        {
            return Math.Abs(valor1 - valor2) < tolerancia;
        }

        /// <summary>
        /// Elimina decimals residuals i comprova si el valor és zero.
        /// </summary>
        /// <param name="valor"></param>
        /// <returns></returns>
        internal static bool EsZero(double valor)
        {
            return SonIguals(valor, 0);
        }

        /// <summary>
        /// Compara dos números amb decimals amb una precisió màxima.
        /// -1 si valor1 és més petit. 0 si valor1 = valor2. +1 si valor2 és més petit.
        /// </summary>
        /// <param name="valor1"></param>
        /// <param name="valor2"></param>
        /// <param name="numDecimals"></param>
        /// <returns></returns>
        internal static int Compara(double valor1, double valor2, int numDecimals = 5)
        {
            var precisio = Math.Pow(10, numDecimals);
            var v1 = Math.Truncate(valor1 * precisio);
            var v2 = Math.Truncate(valor2 * precisio);

            if (v1 > v2)
                return 1;
            
            if (v1 < v2)
                return -1;

            return 0;
        }

    }
}
