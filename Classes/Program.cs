using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Comuns;
using Inversions.GUI;
using Microsoft.Win32;

namespace Inversions
{
    public static class Program
    {
        internal static InversionsBDContext Sessio;
        internal static readonly bool RuntimeMode = LicenseManager.UsageMode == LicenseUsageMode.Runtime;
        //internal static Usuari UsuariSeleccionat;
        internal static FileInfo FitxerLog = null;
        internal static readonly Version Versio = Assembly.GetExecutingAssembly().GetName().Version;
        public static int PrimerAny = 2000;

        static Program()
        {
            ConnectaSessio();
        }

        public static void ConnectaSessio()
        {
            //Sessio = null;
            Sessio = new InversionsBDContext();
            Sessio.Configuration.AutoDetectChangesEnabled = true; // Si poso true, dona error quan inserto una fila i l'esborro en la mateixa sessió.
            Sessio.Configuration.LazyLoadingEnabled = true;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public static Usuari UsuariSeleccionat;
        internal static string Claureg;
        internal const string NomVarReg = "UsuariId";
        private const string ArgUsuari = "IdUsuari:";
        private const string ArgBd = "Bd:";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                // Com que aquí encara no tinc fitxer log, si hi ha error el mostro per pantalla i acabo l'execució.
                FitxerLog = Utilitats.LlegeixFitxerLog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                return;
            }

            try
            {
                // *** Crea la clau per gravar el registre de Windows. ***
                Claureg = Utilitats.CreaClauRegistre();

                // ***** Llegeix els arguments passats per paràmetres. Tenen preferència sobre els de "app.config".
                int? idUsuari;
                string bd;
                LlegeixParametres(args, out idUsuari, out bd);

                if (!idUsuari.HasValue)
                {
                    // Si no hi ha usuari, l'agafa del registre;
                    var usuRegistreWindows = Utilitats.LlegeixVariableRegistre(Registry.CurrentUser, Claureg, NomVarReg);
                    if (Utilitats.EsNumeric(usuRegistreWindows)) 
                        idUsuari = Int32.Parse(usuRegistreWindows);

                    // Si tampoc hi és al registre, usuari 1 per defecte.
                    if (!idUsuari.HasValue)
                        idUsuari = 1;
                }

                var nomProces = Utilitats.NomProcesActual();

                bool createdNew;
                using (new Mutex(true, nomProces, out createdNew))
                {
                    if (createdNew)
                    {
                        // Informa la variable |DataDirectory|, s'utilitza en App.config.
                        // ***** A partir d'aquí, ja es pot accedir a la Bd *****
                        Utilitats.AssignaDataDirectory(bd, "InversionsBD.mdf");

                        Usuari usuari = Sessio.Usuaris.Find(idUsuari.Value);

                        if(usuari == null)
                            throw new Exception(String.Format("L'usuari: {0} no existeix", idUsuari.Value));

                        CanviUsuari(usuari);


                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Principal());
                    }
                    else
                    {
                        if (idUsuari.HasValue)
                            // *** El procés ja s'està executant.
                            // ***** Modifico l'usuari en el registre, aquí encara no tinc accés s la Bd *****
                            Utilitats.GravaVariableRegistre(Registry.CurrentUser, Claureg, NomVarReg, idUsuari.Value);

                        Utilitats.ActivaInstanciaEnMarxa(Process.GetCurrentProcess());
                    }
                }
            }
            catch (Exception ex)
            {
                Utilitats.EscriuLog(ex, FitxerLog, Versio);
            }
        }


        /// <summary>
        /// Llegeix els parèmetres que arriven de l'execució de l'app
        /// </summary>
        /// <param name="args"></param>
        /// <param name="idUsuari"></param>
        /// <param name="bd"></param>
        private static void LlegeixParametres(IEnumerable<string> args, out int? idUsuari, out string bd)
        {
            idUsuari = null;
            bd = null;

            foreach (var arg in args)
            {
                var argu = arg.Substring(0, arg.IndexOf(':') + 1);

                if (argu.Equals(ArgUsuari, StringComparison.CurrentCultureIgnoreCase))
                {
                    var idUsuString = arg.Remove(0, ArgUsuari.Length);
                    if (!Utilitats.EsNumeric(idUsuString))
                        throw new ArgumentException(String.Format("El paràmetre no és numèric"), ArgUsuari);

                    idUsuari = Convert.ToInt32(idUsuString);
                }
                else if (argu.Equals(ArgBd, StringComparison.CurrentCultureIgnoreCase))
                {
                    bd = arg.Remove(0, ArgBd.Length);
                }
                else
                {
                    throw new ArgumentException(String.Format("Argument: {0} Invalid.", arg));
                }
            }
        }


        private static void DesaIdUsuariEnRegistreWindows(Usuari usuari)
        {
            if (usuari == null)
                throw new ArgumentNullException("usuari", "No es pot canviar a un usuari Null");

            Utilitats.GravaVariableRegistre(Registry.CurrentUser, Claureg, NomVarReg, usuari.Id);
        }

        internal static void CanviUsuari(Usuari usuari)
        {
            DesaIdUsuariEnRegistreWindows(usuari);
            Usuari.Seleccionat = usuari;
        }

        private static string ClauRegistre(bool ambUsuari)
        {
            return Claureg + (ambUsuari ? "\\" + Usuari.Seleccionat.Nom : String.Empty);
        }

        internal static string LlegeigVariableEnRegistreWindows(string nomVarReg, bool llegeigDelUsuari)
        {
            if (nomVarReg == null)
                throw new ArgumentNullException("nomVarReg", "El nom variable no pot ser null");

            return Utilitats.LlegeixVariableRegistre(Registry.CurrentUser, ClauRegistre(llegeigDelUsuari), nomVarReg);
        }


        internal static void DesaVariableEnRegistreWindows(string nomVarReg, string valor, bool escriuAlUsuari)
        {
            if (nomVarReg == null)
                throw new ArgumentNullException("nomVarReg", "El nom variable no pot ser null");

            Utilitats.GravaVariableRegistre(Registry.CurrentUser, ClauRegistre(escriuAlUsuari), nomVarReg, valor);
        }

    }
}
