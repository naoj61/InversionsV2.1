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

        EmpresesProductesTab empresesProductesTab = new EmpresesProductesTab();
        MovimentsTab movimentsTab = new MovimentsTab();

        public Principal()
        {
            InitializeComponent();

            Tc = tabControl1;

            //using (var conn = new InversionsBDContext())
            //{
            //    //var conn = Program.Sessio;

            //    using (var dbContextTransaction = conn.Database.BeginTransaction())
            //    {
            //        try
            //        {
            //            //var ges = conn.Gestors.Single(s => s.Id == 1);
            //            var ges = conn.Gestors.Create();
            //            ges.Nom = "jlklkh";
            //            ges.Empresa = conn.Empreses.First();

            //            conn.Gestors.AddOrUpdate(ges);
            //            conn.SaveChanges();

            //            //dbContextTransaction.Rollback();
            //            //dbContextTransaction.Commit();

            //            conn.Gestors.Remove(ges);
            //            conn.SaveChanges();

            //            ////dbContextTransaction.Rollback();
            //            dbContextTransaction.Commit();


            //        }
            //        catch (Exception)
            //        {
            //            dbContextTransaction.Rollback();
            //            throw;
            //        }
            //    }
            //}

            //var cc = Program.Sessio.Gestors.Count();
            //var gess = Program.Sessio.Gestors.Single(s => s.Id == 1);
            //Program.Sessio.ChangeTracker.DetectChanges();
            //var gess2 = Program.Sessio.Gestors.Single(s => s.Id == 1);

            titolFinestra();

            // Selecciona l'ultima pestanya seleccionada al tancar l'últim cop.
            var ultimaPestanyaSeleccionada = Program.LlegeigVariableEnRegistreWindows(NomVarReg, true);
            try
            {
                tabControl1.SelectTab(ultimaPestanyaSeleccionada);
            }
            catch (ArgumentNullException)
            {
                tabControl1.SelectTab(tabValoracions.Name);
            }

#if DEBUG           
            //tabControl1.SelectTab(tabPerduesGuanys.Name);
#endif

   
            modeConsultaProducte();
        }

        public static TabControl _Tc
        {
            get { return Tc; }
        }

        #region *** Mètodes ***

        private void titolFinestra()
        {
            this.Text = String.Format("Inversions. Ver: {0}. Usuari: {1}", Application.ProductVersion, Usuari.Seleccionat.Nom);
        }



        private void modeConsultaProducte()
        {
            vModeConsultaProducte = true;
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
                tabEmpresesProductes.Controls.Add(empresesProductesTab);
                empresesProductesTab.Dock = DockStyle.Fill;
                tabEmpresesProductes.ResumeLayout(false);

                // Afegeig MovimentsTab
                tabMoviments.SuspendLayout();
                tabEmpresesProductes.Controls.Add(empresesProductesTab);
                empresesProductesTab.Dock = DockStyle.Fill;
                tabEmpresesProductes.ResumeLayout(false);

                ResumeLayout();
            }
        }

        
        private void cbUsuaris_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SestaCanviantLusuari = true;

                Program.CanviUsuari((Usuari)cbUsuaris.SelectedItem);
                movimentsTab1.canviUsuari(Usuari.Seleccionat);
                valoracionsTab1.canviUsuari(Usuari.Seleccionat);
                perduesGuanysTab1.canviUsuari(Usuari.Seleccionat);
            }
            finally
            {
                SestaCanviantLusuari = false;
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
                tabControl1.SelectedTab.Controls[0].Refresh();
            }
            //else if (e.KeyCode == Keys.Escape)
            //{
            //    if (ActiveControl.Parent.Parent == pnCampsProductes)
            //        teclaEscapeEdicioProducte();
            //}
        }

        private void canviUsuari(Usuari usuari = null)
        {
            var cursor = this.Cursor;
            try
            {
                this.Cursor = Cursors.WaitCursor;

                if (usuari == null)
                {
                    var numUsuaris = cbUsuaris.Items.Count;
                    if (cbUsuaris.SelectedIndex == numUsuaris - 1)
                    {
                        cbUsuaris.SelectedIndex = 0;
                    }
                    else
                    {
                        cbUsuaris.SelectedIndex++;
                    }
                }
                else
                {
                    cbUsuaris.SelectedItem = usuari;
                }

                if (cbUsuaris.SelectedItem != null)
                {
                    Program.CanviUsuari(((Usuari) cbUsuaris.SelectedItem));
                }

                titolFinestra();
            }
            finally
            {
                this.Cursor = cursor;
            }
        }



        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (pnDesaCanvisEmpreses.Enabled)
            //{
            //    if (MessageBox.Show("Hi han canvis pendents de desar en la taula Empreses. \nVols tancar igualment?", "Atenció",
            //        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            //    {
            //        e.Cancel = true;
            //        return;
            //    }
            //}
        }


        private void tabControl1_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            ITabs tab = e.TabPage.Controls.OfType<ITabs>().FirstOrDefault();

            if (tab != null && tab.enModeEdicio)
                e.Cancel = true;
        }
        
        #endregion *** Events ***

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

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            ITabs tab = e.TabPage.Controls.OfType<ITabs>().FirstOrDefault();

            if (tab == null)
                AcceptButton = null;
            else
            {
                AcceptButton = tab.AcceptButton;
                if (tab.activaRefresca)
                    tab.refresca();
            }

            Program.DesaVariableEnRegistreWindows(NomVarReg, e.TabPage.Name, true);
        }

        /// <summary>
        /// Activa l'indicador per refrescar al entrar en la pestanya.
        /// </summary>
        /// <param name="tabX"></param>
        internal static void ActivaRefresca(ITabs tabX)
        {
            foreach (TabPage tabPage in Tc.TabPages)
            {
                ITabs tab = tabPage.Controls.OfType<ITabs>().FirstOrDefault();

                if (tab != null)
                    tab.activaRefresca = tab != tabX;
            }
        }
    }
}
