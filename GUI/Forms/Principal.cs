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
        const string NomVarReg = "UltimaPestanyaSeleccionada";
        static internal bool SestaCanviantLusuari = false;

        readonly EmpresesProductesTab vEmpresesProductesTab = new EmpresesProductesTab();
        readonly MovimentsTab vMovimentsTab = new MovimentsTab();
        readonly ValoracionsTab vValoracionsTab = new ValoracionsTab();
        readonly PerduesGuanysTab vPerduesGuanysTab = new PerduesGuanysTab();
        readonly GrafiquesTab vGrafiquesTab = new GrafiquesTab();
        readonly SimulacióVendaTab vSimulacióVendaTab = new SimulacióVendaTab();
        readonly UsuarisTab vUsuarisTab = new UsuarisTab();
        readonly EdicioTaulesTab vEdicioTaulesTab = new EdicioTaulesTab();

        public Principal()
        {
            InitializeComponent();
            
            titolFinestra();
        }

        private TabX tornaTabX(TabPage tabPage = null)
        {
            if (tabPage == null)
                tabPage = tabControl1.SelectedTab;

            return tabPage.Controls.OfType<TabX>().FirstOrDefault();
        }


        #region *** Mètodes ***
        
        private void titolFinestra()
        {
            Text = String.Format("Inversions. Ver: {0}. Usuari: {1}", Application.ProductVersion, Usuari.Seleccionat.Nom);
        }

        private void canviUsuari(Usuari usuari = null)
        {
            var cursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                var tabPageX = tornaTabX();
                if (tabPageX != null && tabPageX._EnModeEdicio)
                {
                    MessageBox.Show("Està en mode edició");
                    return;
                }

                SestaCanviantLusuari = true;

                if (usuari == null)
                {
                    usuari = vUsuarisTab.tornaUsuariSeguent();
                }

                Program.CanviUsuari(usuari);


                vUsuarisTab._SelectedIndexChanged -= usuarisTab_SelectedIndexChanged;
                foreach (TabPage tabPage in tabControl1.TabPages)
                {
                    var tabX = tornaTabX(tabPage);
                    if (tabX != null)
                        tabX.canviUsuari(usuari);
                }
                vUsuarisTab._SelectedIndexChanged += usuarisTab_SelectedIndexChanged;

                titolFinestra();

                SestaCanviantLusuari = false;
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

                vUsuarisTab.carregaInicial();

                var tabSelect = tornaTabX();
                if (tabSelect != null) 
                    tabSelect.carregaInicial();

//#if DEBUG
                //tabControl1.SelectTab(tabPerduesGuanys.Name);
//#endif
            }
        }

        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.U)
            {
                canviUsuari();
            }
            else if (e.KeyCode == Keys.F5 || (e.Control && e.KeyCode == Keys.R))
            {
                var tabX = tornaTabX();
                if (tabX != null)
                    tabX.refresca(true);
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
            Program.DesaVariableEnRegistreWindows(NomVarReg, e.TabPage.Name, true);

            var tabX = tornaTabX(e.TabPage);

            if (tabX != null)
            {
            if (tabX._PendentCarregaInicial)
                tabX.carregaInicial();
                tabX.refresca(null);
            }
        }

        void usuarisTab_SelectedIndexChanged(object sender, EventArgs e)
        {
            canviUsuari((Usuari)sender);
        }

        #endregion *** Events ***
    }
}
