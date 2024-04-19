using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Comuns;
using Controls;
using Microsoft.Win32;

namespace Inversions.GUI
{
    public partial class Principal : Form
    {
        private const string NomVarReg = "UltimaPestanyaSeleccionada";

        private readonly EmpresesProductesTab vEmpresesProductesTab = new EmpresesProductesTab();
        private readonly MovimentsTab vMovimentsTab = new MovimentsTab();
        private readonly ValoracionsTab vValoracionsTab = new ValoracionsTab();
        private readonly PerduesGuanysTab vPerduesGuanysTab = new PerduesGuanysTab();
        private readonly GrafiquesTab vGrafiquesTab = new GrafiquesTab();
        private readonly SimulacióVendaTab vSimulacióVendaTab = new SimulacióVendaTab();
        private readonly UsuarisTab vUsuarisTab = new UsuarisTab();
        private readonly EdicioTaulesTab vEdicioTaulesTab = new EdicioTaulesTab();

        public Principal()
        {
            InitializeComponent();

            titolFinestra();
        }


        #region *** Mètodes ***

        /// <summary>
        /// Tora el control TabX seleccionat.
        /// </summary>
        /// <param name="tabPage"></param>
        /// <returns></returns>
        private TabX tornaTabX(TabPage tabPage = null)
        {
            if (tabPage == null)
                tabPage = tabControl1.SelectedTab;

            return tabPage.Controls.OfType<TabX>().FirstOrDefault();
        }


        private void titolFinestra()
        {
            Text = String.Format("Inversions. Ver: {0}. Usuari: {1}", Application.ProductVersion, Usuari.Seleccionat.Nom);
        }


        /// <summary>
        /// Torna l'usuari següent al del paràmetre, si aquest és null torna el següent al seleccionat.
        /// </summary>
        /// <param name="usuari"></param>
        /// <returns></returns>
        private Usuari tornaUsuariSeguent(Usuari usuari)
        {
            var usuaris = Program.Sessio.Usuaris.OrderBy(o => o.Id);

            if (usuari == null)
                return usuaris.First();

            return usuaris.FirstOrDefault(f => f.Id > usuari.Id) ?? usuaris.First();
        }


        private void canviUsuari(Usuari usuari = null)
        {
            var cursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var tabPageX = tornaTabX();

                if (tabPageX._EnModeEdicio)
                {
                    MessageBox.Show("Està en mode edició");
                    return;
                }

                if (usuari == null)
                    usuari = tornaUsuariSeguent(Usuari.Seleccionat);

                // Canvia registre Windows i la variable "Usuari.Seleccionat"
                Program.CanviUsuari(usuari);

                TabX.ActivaPendentCanviUsuariEnTabs();

                tabPageX.canviUsuari();

                titolFinestra();
            }
            finally
            {
                this.Cursor = cursor;
            }
        }

        #endregion *** Mètodes ***


        #region *** Events ***

        private void Principal_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode && LicenseManager.UsageMode == LicenseUsageMode.Runtime)
            {
                #region *** Crea les pestanyes ***

                SuspendLayout();

                // Afegeix EmpresesProductesTab
                tabUsuari.SuspendLayout();
                tabUsuari.Controls.Add(vUsuarisTab);
                tabUsuari.Dock = DockStyle.Fill;
                tabUsuari.ResumeLayout();
                vUsuarisTab._SelectedIndexChanged += usuarisTab_SelectedIndexChanged;

                // Afegeix EmpresesProductesTab
                tabEmpresesProductes.SuspendLayout();
                tabEmpresesProductes.Controls.Add(vEmpresesProductesTab);
                vEmpresesProductesTab.Dock = DockStyle.Fill;
                tabEmpresesProductes.ResumeLayout();

                // Afegeig MovimentsTab
                tabMoviments.SuspendLayout();
                tabMoviments.Controls.Add(vMovimentsTab);
                vMovimentsTab.Dock = DockStyle.Fill;
                tabMoviments.ResumeLayout();

                // Afegeig ValoracionsTab
                tabValoracions.SuspendLayout();
                tabValoracions.Controls.Add(vValoracionsTab);
                vValoracionsTab.Dock = DockStyle.Fill;
                tabValoracions.ResumeLayout();

                // Afegeig PerduesGuanysTab
                tabPerduesGuanys.SuspendLayout();
                tabPerduesGuanys.Controls.Add(vPerduesGuanysTab);
                vPerduesGuanysTab.Dock = DockStyle.Fill;
                tabPerduesGuanys.ResumeLayout();

                // Afegeig GrafiquesTab
                tabGrafiques.SuspendLayout();
                tabGrafiques.Controls.Add(vGrafiquesTab);
                vGrafiquesTab.Dock = DockStyle.Fill;
                tabGrafiques.ResumeLayout();

                // Afegeig SimulacióVendaTab
                tabSimulacióVenda.SuspendLayout();
                tabSimulacióVenda.Controls.Add(vSimulacióVendaTab);
                vSimulacióVendaTab.Dock = DockStyle.Fill;
                tabSimulacióVenda.ResumeLayout();

                // Afegeig EdicioTaulesTab
                tabEdicioTaules.SuspendLayout();
                tabEdicioTaules.Controls.Add(vEdicioTaulesTab);
                vEdicioTaulesTab.Dock = DockStyle.Fill;
                tabEdicioTaules.ResumeLayout();

                ResumeLayout();

                #endregion *** Crea les pestanyes ***

                if (Usuari.Seleccionat == null)
                    Program.CanviUsuari(Usuari.Tuples.First());

                var ultimaPestanyaSeleccionada = Program.LlegeigVariableEnRegistreWindows(NomVarReg, true);
                try
                {
                    tabControl1.SelectTab(ultimaPestanyaSeleccionada);
                }
                catch (ArgumentNullException)
                {
                    tabControl1.SelectTab(tabValoracions.Name);
                }
            }
        }


        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.U)
            {
                var tabPageX = tornaTabX();
                if (tabPageX != null && tabPageX._EnModeEdicio)
                    MessageBox.Show("Està en mode edició");
                else
                    canviUsuari();
            }
            else if (e.KeyCode == Keys.F5 || (e.Control && e.KeyCode == Keys.R))
            {
                var tabX = tornaTabX();
                if (tabX != null)
                    tabX.refresca();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                var tabX = tornaTabX();
                if (tabX != null)
                    tabX.escape(sender, e);
            }
        }


        private void Principal_Activated(object sender, EventArgs e)
        {
            // *** Canvia d'usuari si s'ha intentat arrancar de nou el procés amb un usuari diferent.
            var usuariId = Convert.ToInt32(Utilitats.LlegeixVariableRegistre(Registry.CurrentUser, Program.Claureg, Program.NomVarReg));
            if (usuariId != Usuari.Seleccionat.Id)
            {
                var usuari = Usuari.Tuples.Find(usuariId);
                if (usuari != null)
                {
                    canviUsuari(usuari);
                }
            }
        }


        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            var tabX = tornaTabX();

            if (tabX != null)
                // Impideix canviar de pastanya si la pestanya seleccionada està en mode edició.
                tabX.validating(sender, e);
        }


        private void tabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            var tabX = tornaTabX(e.TabPage);

            if (tabX != null)
                // Impideix canviar de pastanya si la pestanya seleccionada està en mode edició.
                tabX.validating(sender, e);
        }


        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            var tabXSeleccionada = tornaTabX(e.TabPage);

            if (tabXSeleccionada != null)
            {
                Program.DesaVariableEnRegistreWindows(NomVarReg, e.TabPage.Name, true);

                if (tabXSeleccionada._PendentCarregaInicial)
                    tabXSeleccionada.carregaInicial();

                if (tabXSeleccionada._PendentCanviUsuari)
                    tabXSeleccionada.canviUsuari();

                if (tabXSeleccionada._PendentRefrescar)
                    tabXSeleccionada.refresca();
            }
        }

        private void usuarisTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            canviUsuari((Usuari) sender);
        }

        #endregion *** Events ***

        private void Principal_KeyUp(object sender, KeyEventArgs e)
        {
#if DEBUG
            if (e.KeyCode == Keys.Tab)
            {
                Control aa = GetActiveControlInPanel((Control) ActiveControl);
                Text = aa.Name;
            }
#endif
        }

        /// <summary>
        /// Mètode per saber quin control te el focus real.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        private static Control GetActiveControlInPanel(Control control)
        {
            // Check if the panel itself has focus
            if (control.Focused)
            {
                return control;
            }

            // Recursively search for active control within child controls
            foreach (Control child in control.Controls)
            {
                Control activeChild = GetActiveControlInPanel(child);
                if (activeChild != null)
                {
                    return activeChild;
                }
            }

            return null;
        }
    }
}
 