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
        private static TabControl Tc;
        private bool vModeConsultaProducte = true;

        readonly EmpresesProductesTab vEmpresesProductesTab = new EmpresesProductesTab();
        readonly MovimentsTab vMovimentsTab = new MovimentsTab();
        readonly ValoracionsTab vValoracionsTab = new ValoracionsTab();
        readonly PerduesGuanysTab vPerduesGuanysTab = new PerduesGuanysTab();
        readonly GrafiquesTab vGrafiquesTab = new GrafiquesTab();
        readonly SimulacióVendaTab vSimulacióVendaTab = new SimulacióVendaTab();

        public Principal()
        {
            InitializeComponent();
            
            Tc = tabControl1;
            
            titolFinestra();

            modeConsultaProducte();
        }

        private TabX _PestanyaSeleccionada
        {
            get { return tabControl1.SelectedTab.Controls.OfType<TabX>().FirstOrDefault(); }
        }
        

        #region *** Mètodes ***

        /// <summary>
        /// Activa l'indicador per refrescar al entrar en totes les pestanyes.
        /// </summary>
        /// <param name="tabx"></param>
        internal static void ActivaRefresca(TabX tabx)
        {
            foreach (TabPage tabPage in Tc.TabPages)
            {
                var tab = tabPage.Controls.OfType<TabX>().FirstOrDefault();

                if (tab != null)
                    tab._ActivaRefresca = tab != tabx;
            }
        }


        private void titolFinestra()
        {
            Text = String.Format("Inversions. Ver: {0}. Usuari: {1}", Application.ProductVersion, Usuari.Seleccionat.Nom);
        }


        private void modeConsultaProducte()
        {
            vModeConsultaProducte = true;
        }


        private void canviUsuari(Usuari usuari = null)
        {
            var cursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (_PestanyaSeleccionada._EnModeEdicio)
                {
                    MessageBox.Show("Està en mode edició");
                    return;
                }

                SestaCanviantLusuari = true;

                if (usuari == null)
                {
                    var numUsuaris = cbUsuaris.Items.Count;
                    if (cbUsuaris.SelectedIndex == numUsuaris - 1)
                        cbUsuaris.SelectedIndex = 0;
                    else
                        cbUsuaris.SelectedIndex++;
                    return;
                }
                else if (((Usuari) cbUsuaris.SelectedItem) != usuari)
                {
                    cbUsuaris.SelectedItem = usuari;
                    return;
                }

                Program.CanviUsuari(usuari);

                foreach (Control tabPage in tabControl1.TabPages)
                {
                    var tabX = tabPage.Controls.OfType<TabX>().FirstOrDefault();
                    if (tabX != null)
                        tabX.canviUsuari(usuari);
                }

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
                    Program.CanviUsuari(Program.Sessio.Usuaris.First());

                SuspendLayout();

                cbUsuaris.DisplayMember = "Nom";
                cbUsuaris.DataSource = Program.Sessio.Usuaris.ToList();
                cbUsuaris.SelectedItem = Usuari.Seleccionat;
                cbUsuaris.SelectedIndexChanged += cbUsuaris_SelectedIndexChanged;

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

                ResumeLayout();

                var ultimaPestanyaSeleccionada = Program.LlegeigVariableEnRegistreWindows(NomVarReg, true);
                try
                {
                    tabControl1.SelectTab(ultimaPestanyaSeleccionada);
                }
                catch (ArgumentNullException)
                {
                    tabControl1.SelectTab(tabValoracions.Name);
                }

//#if DEBUG
                //tabControl1.SelectTab(tabPerduesGuanys.Name);
//#endif
            }
        }

        private void Principal_KeyDown(object sender, KeyEventArgs e)
        {
            var tabX = tabControl1.SelectedTab.Controls.OfType<TabX>().FirstOrDefault();

            if (e.Control && e.KeyCode == Keys.U)
            {
                canviUsuari();
            }
            else if (e.KeyCode == Keys.F5 || (e.Control && e.KeyCode == Keys.R))
            {
                if (tabX != null)
                    tabX.refresca(true);
            }
            else if (e.KeyCode == Keys.Escape)
            {
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
                var usuari = Program.Sessio.Usuaris.Find(usuariId);
                if (usuari != null)
                {
                    canviUsuari(usuari);
                }
            }
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
           var tabX = tabControl1.SelectedTab.Controls.OfType<TabX>().FirstOrDefault();

            if (tabX != null)
                // Impideix canviar de pastanya si la pestanya seleccionada està en mode edició.
                tabX.validating(sender, e);
        }

        private void cbUsuaris_SelectedIndexChanged(object sender, EventArgs e)
        {
            canviUsuari((Usuari)cbUsuaris.SelectedItem);
        }

        private void tabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            var tabX = e.TabPage.Controls.OfType<TabX>().FirstOrDefault();

            if (tabX != null)
                // Impideix canviar de pastanya si la pestanya seleccionada està en mode edició.
                tabX.validating(sender, e);
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            Program.DesaVariableEnRegistreWindows(NomVarReg, e.TabPage.Name, true);

            var tabX = e.TabPage.Controls.OfType<TabX>().FirstOrDefault();

            if (tabX != null && tabX._PendentCarregaInicial)
                tabX.carregaInicial();
        }

        #endregion *** Events ***
    }
}
