using System;
using System.CodeDom;
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
    internal static class Program
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
                // *** Crea la clau per gravar el registre de Windows. ***
                Claureg = Utilitats.CreaClauRegistre();

                int? idUsuari = null;

                bool createdNew = true;
                using (Mutex mutex = new Mutex(true, "Inversions", out createdNew))
                {
                    if (createdNew)
                    {
                        FitxerLog = Utilitats.LlegeixFitxerLog();
              
                        var argUsu = args.FirstOrDefault(arg => arg.StartsWith(ArgUsuari, StringComparison.CurrentCultureIgnoreCase));
                        if (argUsu != null)
                        {
                            var idUsuString = argUsu.Remove(0, ArgUsuari.Length);
                            if(!Utilitats.EsNumeric(idUsuString))
                                throw new ArgumentException(String.Format("El paràmetre no és numèric"), ArgUsuari);

                            idUsuari = Convert.ToInt32(idUsuString);
                        }

                        if (idUsuari == null)
                            throw new ArgumentException("Falta el paràmetre", ArgUsuari);

                        // *** Deso l'id del usuari en el registre.
                        DesaIdUsuariEnRegistreWindows(idUsuari.Value);

                        string bd = null;
                        var argBd = args.FirstOrDefault(arg => arg.StartsWith(ArgBd, StringComparison.CurrentCultureIgnoreCase));
                        if (argBd != null) 
                            bd = argBd.Remove(0, ArgBd.Length);

                        if (bd == null)
                            throw new ArgumentException("Falta el paràmetre", argBd);

                        // Informa la variable |DataDirectory|, s'utilitza en App.config.
                        AppDomain.CurrentDomain.SetData("DataDirectory", bd);

                        // Ha d'anar despres de "AppDomain.CurrentDomain"
                        Usuari.Seleccionat = Sessio.Usuaris.Find(idUsuari.Value);

                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);
                        Application.Run(new Principal());
                    }
                    else
                    {
                        // *** El procés ja s'està executant.

                        var argUsu = args.FirstOrDefault(arg => arg.StartsWith(ArgUsuari, StringComparison.CurrentCultureIgnoreCase));
                        if (argUsu != null)
                        {
                            idUsuari = Convert.ToInt32(argUsu.Remove(0, ArgUsuari.Length));

                            // *** Deso l'id del usuari en el registre per que es canviï al activar la finestra Principal.
                            Utilitats.GravaVariableRegistre(Registry.CurrentUser, Claureg, NomVarReg, idUsuari);
                        }

                        Process current = Process.GetCurrentProcess();
                        foreach (Process process in Process.GetProcessesByName(current.ProcessName))
                        {
                            if (process.Id != current.Id)
                            {
                                SetForegroundWindow(process.MainWindowHandle);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Utilitats.EscriuLog(ex, FitxerLog, Versio);
            }
        }

        public static void DesaIdUsuariEnRegistreWindows(int idUsuari)
        {
            Utilitats.GravaVariableRegistre(Registry.CurrentUser, Claureg, NomVarReg, idUsuari);
        }
    }
}
