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
            Sessio = new InversionsBDContext();
            Sessio.Configuration.AutoDetectChangesEnabled = true; // Si poso true, dona error quan inserto una fila i l'esborro en la mateixa sessió.
            Sessio.Configuration.LazyLoadingEnabled = true;
        }


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public static Usuari UsuariSeleccionat;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {

            bool createdNew = true;
            using (Mutex mutex = new Mutex(true, "Inversions", out createdNew))
            {
                if (createdNew)
                {
                    FitxerLog = Utilitats.LlegeixFitxerLog();
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
                        Utilitats.EscriuLog(ex, FitxerLog, Versio);
                    }
                }
                else
                {
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
    }
}
