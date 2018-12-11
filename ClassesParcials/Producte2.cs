using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security;
using System.Windows.Forms;
using Comuns;

namespace Inversions
{
    // *** Nou mètodes per substituir "PreuParticipacioOrig" per la taula "DesgloçCompres".
    public abstract partial class Producte
    {

        #region *** Mètodes per fer Test ***

        public double testImportCompraAntic(DateTime dInici, DateTime dFinal)
        {
            return importCompraAntic(dInici, dFinal);
        }

        public double testImportCompra2(DateTime dInici, DateTime dFinal)
        {
            return importCompra(dInici, dFinal);
        }

        #endregion *** Mètodes per fer Test ***


        #region *** Mètodes que modifiquen la BD ***

        /// <summary>
        /// Validacions en Compres o Vendes.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="participacions"></param>
        /// <param name="mostraFinestraAdvertencia"></param>
        private void validacionsCompraVenda(InversionsBDContext connexio, DateTime dataHora, double participacions, bool mostraFinestraAdvertencia)
        {
            if (connexio == null)
                throw new ArgumentNullException("connexio");

            // Valida que s'hagi creat una transacció abans de començar el procés.
            if (connexio.Database.CurrentTransaction == null)
                throw new ArgumentNullException("No s'ha creat cap transacció. És obligatori per aquest procés.");


            if (MovimentsProducteUsuari.Any())
            {
                var ultimaData = MovimentsProducteUsuari.Max(m => m.Data);

                // Valido que DateTime no sigui inferior a un moviment prèvi del mateix producte.
                if (ultimaData >= dataHora && mostraFinestraAdvertencia)
                {
                    if (MessageBox.Show("La data és inferior a la data del últim moviment del producte.\nVols continuar?", "Avís", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        throw new ApplicationException("Operació cancelada");
                }
            }

            if (participacions <= 0)
                throw new ArgumentException("El valor ha de ser major de zero", "numParticipacions");
        }


        /// <summary>
        /// Traspàs de un fons.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHoraVenda"></param>
        /// <param name="participacionsVenda"></param>
        /// <param name="preuParticipacioVenda"></param>
        /// <param name="descripcio"></param>
        /// <param name="dataHoraCompra"></param>
        /// <param name="prodCompra"></param>
        /// <param name="participacionsCompra"></param>
        public void desaTraspas(InversionsBDContext connexio, DateTime dataHoraVenda, double participacionsVenda, double preuParticipacioVenda, string descripcio,
            DateTime dataHoraCompra, Producte prodCompra, double participacionsCompra)
        {
            dataHoraVenda = Utilitats.ArrodoneixoDataASegons(dataHoraVenda);
            dataHoraCompra = Utilitats.ArrodoneixoDataASegons(dataHoraCompra);

            if (dataHoraVenda == dataHoraCompra)
                dataHoraCompra = dataHoraCompra.AddSeconds(1);


            double preuParticipacioCompra = Math.Round(preuParticipacioVenda * participacionsVenda / participacionsCompra, 4);

            var venda = this.desaVenda(connexio, dataHoraVenda, participacionsVenda, preuParticipacioVenda, 1, null, descripcio, false, true);
            var compra = prodCompra.desaCompra(connexio, dataHoraCompra, participacionsCompra, preuParticipacioCompra, 1, null, descripcio, venda, false, true);
        }


        /// <summary>
        /// Compra. No es crida en els traspassos.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="data"></param>
        /// <param name="hora"></param>
        /// <param name="participacions"></param>
        /// <param name="preuParticipacio"></param>
        /// <param name="canviAplicat"></param>
        /// <param name="despeses"></param>
        /// <param name="descripcio"></param>
        /// <param name="afegeigPreuAValoracions"></param>
        /// <param name="mostraFinestraAdvertencia"></param>
        /// <returns></returns>
        public Moviment desaCompra(InversionsBDContext connexio, DateTime data, TimeSpan hora, double participacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, bool afegeigPreuAValoracions = true, bool mostraFinestraAdvertencia = true)
        {
            DateTime dataHora = Utilitats.FormaData(data, hora);

            return desaCompra(connexio, dataHora, participacions, preuParticipacio, canviAplicat, despeses, descripcio, null, afegeigPreuAValoracions, mostraFinestraAdvertencia);
        }


        /// <summary>
        /// Compra o traspàs compra.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="participacions"></param>
        /// <param name="preuParticipacio"></param>
        /// <param name="canviAplicat"></param>
        /// <param name="despeses"></param>
        /// <param name="descripcio"></param>
        /// <param name="movimentVendaVinculatTraspas">Si != NULL, és un traspàs.</param>
        /// <param name="afegeigPreuAValoracions"></param>
        /// <param name="mostraFinestraAdvertencia"></param>
        /// <returns></returns>
        private Moviment desaCompra(InversionsBDContext connexio, DateTime dataHora, double participacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, Moviment movimentVendaVinculatTraspas, bool afegeigPreuAValoracions, bool mostraFinestraAdvertencia)
        {
            validacionsCompraVenda(connexio, dataHora, participacions, mostraFinestraAdvertencia);

            Moviment moviment = connexio.Moviments.Create();
            moviment.UsuariId = Usuari.Seleccionat.Id; // Utilitzo Id perquè "Usuari.Seleccionat" està en un context diferent.
            moviment.TipusMoviment = TipusMoviment.Compra;
            moviment.Participacions = participacions;
            moviment.PreuParticipacio = preuParticipacio;
            moviment.CanviAplicat = canviAplicat;
            moviment.Despeses = despeses;
            moviment.Data = dataHora;
            moviment.Descripcio = String.IsNullOrEmpty(descripcio) ? null : descripcio;
            if (movimentVendaVinculatTraspas != null)
            {
                //// Asigno valor a "ProducteTraspasId" en la venda.
                //this.MovimentsTraspas.Add(movimentVendaVinculatTraspas);

                //// Asigno valor a "ProducteTraspasId" en la compra.
                //movimentVendaVinculatTraspas.Prod.MovimentsTraspas.Add(moviment);

                // Asigno valor a "MovimentRefVendaId" en la venda.
                moviment.MovimentRefVenda1.Add(movimentVendaVinculatTraspas);

                // Asigno valor a "MovimentRefVendaId" en la compra.
                movimentVendaVinculatTraspas.MovimentRefVenda1.Add(moviment);
            }

            this.Moviments.Add(moviment); // Carrega les referències.
            connexio.Entry(moviment).Reference(c => c.Prod).Load();

            moviment.PreuParticipacioOrigen = moviment.calculaPreuOrigen(); // Després del Add per tenir les referèmcies creades.

            if (afegeigPreuAValoracions)
                this.afegeigPreuAValoracions(connexio, dataHora, preuParticipacio);

            connexio.SaveChanges();

            moviment.desgloçarCompra(connexio);

            return moviment;
        }


        /// <summary>
        /// Venda. No s'utilitza ens traspassos.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="data"></param>
        /// <param name="hora"></param>
        /// <param name="participacions"></param>
        /// <param name="preuParticipacio"></param>
        /// <param name="canviAplicat"></param>
        /// <param name="despeses"></param>
        /// <param name="descripcio"></param>
        /// <param name="afegeigPreuAValoracions"></param>
        /// <param name="mostraFinestraAdvertencia"></param>
        /// <returns></returns>
        internal Moviment desaVenda(InversionsBDContext connexio, DateTime data, TimeSpan hora, double participacions, double preuParticipacio
            , double canviAplicat, double? despeses, string descripcio, bool afegeigPreuAValoracions = true, bool mostraFinestraAdvertencia = true)
        {
            DateTime dataHora = Utilitats.FormaData(data, hora);

            return desaVenda(connexio, dataHora, participacions, preuParticipacio, canviAplicat, despeses, descripcio, afegeigPreuAValoracions
                , mostraFinestraAdvertencia);
        }


        /// <summary>
        /// Venda o traspàs venda.
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="participacions"></param>
        /// <param name="preuParticipacio"></param>
        /// <param name="canviAplicat"></param>
        /// <param name="despeses"></param>
        /// <param name="descripcio"></param>
        /// <param name="afegeigPreuAValoracions"></param>
        /// <param name="mostraFinestraAdvertencia"></param>
        /// <returns></returns>
        private Moviment desaVenda(InversionsBDContext connexio, DateTime dataHora, double participacions, double preuParticipacio, double canviAplicat,
            double? despeses, string descripcio, bool afegeigPreuAValoracions, bool mostraFinestraAdvertencia)
        {
            validacionsCompraVenda(connexio, dataHora, participacions, mostraFinestraAdvertencia);

            Moviment moviment = connexio.Moviments.Create();
            moviment.UsuariId = Usuari.Seleccionat.Id; // Utilitzo Id perquè "Usuari.Seleccionat" està en un context diferent.
            moviment.TipusMoviment = TipusMoviment.Venda;
            moviment.Participacions = participacions;
            moviment.PreuParticipacio = preuParticipacio;
            moviment.CanviAplicat = canviAplicat;
            moviment.Despeses = despeses;
            moviment.Data = dataHora;
            moviment.Descripcio = String.IsNullOrEmpty(descripcio) ? null : descripcio;

            this.Moviments.Add(moviment);
            connexio.Entry(moviment).Reference(c => c.Prod).Load(); // Carrega les referències.

            moviment.PreuParticipacioOrigen = moviment.calculaPreuOrigen(); // Després del Add per tenir les referències creades.

            if (afegeigPreuAValoracions)
                this.afegeigPreuAValoracions(connexio, dataHora, preuParticipacio);

            connexio.SaveChanges();

            return moviment;
        }


        internal Moviment desaDividend(InversionsBDContext connexio, DateTime dataHora, double importTotalDividend, double canviAplicat, double? despeses, string descripcio)
        {
            Moviment moviment = connexio.Moviments.Create();
            moviment.UsuariId = Usuari.Seleccionat.Id;
            moviment.TipusMoviment = TipusMoviment.Dividends;
            moviment.ProdId = this.Id;
            moviment.Participacions = 0;
            moviment.PreuParticipacio = importTotalDividend;
            moviment.CanviAplicat = canviAplicat;
            moviment.Despeses = despeses;
            moviment.Data = dataHora;
            moviment.Descripcio = String.IsNullOrEmpty(descripcio) ? null : descripcio;

            connexio.Moviments.Add(moviment);
            //connexio.SaveChanges();

            return moviment;
        }


        /// <summary>
        /// Split de les accions en cartera del producte
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="factorConversor"></param>
        internal void split(InversionsBDContext connexio, DateTime dataHora, int factorConversor)
        {
            if (!(this is ProdAccions))
                throw new ApplicationException("No és una acció. Només es pot fer l'split si és una acció.");

            var descripcio = String.Format("{0}. Factor conversor: {1}.", "Split", factorConversor);
            var compres = compresAnteriors(dataHora, _Participacions).ToList();

            foreach (var movimentCompra in compres)
            {
                var mov1 = connexio.Moviments.Find(movimentCompra._Moviment.Id);

                DateTime data1 = mov1.Data; // Deso la data per sumar-li segons.

                mov1.TipusMoviment = TipusMoviment.Split; // Modifico el tipus de moviment de la compra.
                mov1.Descripcio += descripcio;

                int particSplit = (int)movimentCompra._ParticipacionsDisponibles;
                int particSenseSplit = (int)mov1.Participacions - particSplit;

                double despesesSenseSplit = 0;

                if (particSenseSplit > 0)
                {
                    // Creo una nova compra amb la part de la compra original que no li afecta el Split
                    data1 = data1.AddSeconds(1);
                    despesesSenseSplit = Math.Round(mov1.Despeses.GetValueOrDefault() / mov1.Participacions * particSenseSplit, 4);

                    desaCompra(connexio, data1, particSenseSplit, mov1.PreuParticipacio, mov1.CanviAplicat, despesesSenseSplit, descripcio, null, false, false);
                }

                // Calculo el nou preu i les participacions del Split i creo una compra amb les participacions afectades.
                data1 = data1.AddSeconds(1);
                int participacions = particSplit * factorConversor;
                double preuParticipacio = Math.Round(mov1.PreuParticipacio / factorConversor, 4);
                double despesesSplit = Math.Round(mov1.Despeses.GetValueOrDefault() - despesesSenseSplit, 4);
                desaCompra(connexio, data1, participacions, preuParticipacio, mov1.CanviAplicat, despesesSplit, descripcio, null, false, false);
            }


            // Modifico les valoracions a partir de la data del Split.
            var dataPrimeraCompra = compres.First()._Moviment.Data;
            modificaValoracions(connexio, TipusMoviment.Split, dataPrimeraCompra.Date, factorConversor);

            //connexio.SaveChanges();
        }


        /// <summary>
        /// ContraSplit de les accions en cartera del producte
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="factorConversor"></param>
        /// <param name="preuOperacio"></param>
        /// <param name="canviAplicat"></param>
        internal void contraSplit(InversionsBDContext connexio, DateTime dataHora, int factorConversor, double preuOperacio, double canviAplicat)
        {
            if (!(this is ProdAccions))
                throw new ApplicationException("No és una acció. Només es pot fer l'split si és una acció.");

            var descripcio = String.Format("{0}. Factor conversor: {1}. Preu operació: {2}.", "ContraSplit", factorConversor, preuOperacio);
            var compresAnt = compresAnteriors(dataHora, _Participacions).ToList();

            foreach (var movimentCompra in compresAnt)
            {
                var mov1 = connexio.Moviments.Find(movimentCompra._Moviment.Id);

                DateTime data1 = mov1.Data; // Deso la data per sumar-li segons.

                mov1.TipusMoviment = TipusMoviment.ContraSplit; // Modifico el tipus de moviment de la compra.
                mov1.Descripcio += descripcio;

                int partRestants = (int)movimentCompra._ParticipacionsDisponibles % factorConversor; // Calculo el número de participacions que sobren i s'hauran de vendre.
                int particContraSplit = (int)movimentCompra._ParticipacionsDisponibles - partRestants;
                int particSenseContraSplit = (int)mov1.Participacions - particContraSplit;

                double despesesSenseContraSplit = 0;

                if (particSenseContraSplit > 0)
                {
                    data1 = data1.AddSeconds(1);
                    despesesSenseContraSplit = Math.Round(mov1.Despeses.GetValueOrDefault() / mov1.Participacions * particSenseContraSplit, 4);

                    // Creo una nova compra amb la part de la compra original que no li afecta el ContraSplit
                    desaCompra(connexio, data1, particSenseContraSplit, mov1.PreuParticipacio, mov1.CanviAplicat, despesesSenseContraSplit, descripcio, null, false, false);
                }

                if (particContraSplit > 0)
                {
                    // Creo una compra amb el nou numero de participacions i nou preu.
                    data1 = data1.AddSeconds(1);
                    int participacions = particContraSplit / factorConversor;
                    var preuParticipacio = Math.Round(mov1.PreuParticipacio * factorConversor, 4); // Calculo el nou preu i les participacions del contraSplit
                    double despesesContraSplit = Math.Round(mov1.Despeses.GetValueOrDefault() - despesesSenseContraSplit, 4);
                    desaCompra(connexio, data1, participacions, preuParticipacio, mov1.CanviAplicat, despesesContraSplit, descripcio, null, false, false);
                }


                if (partRestants > 0)
                {
                    // Venc les participacions restants.
                    data1 = data1.AddSeconds(1);
                    var ven = desaVenda(connexio, data1, partRestants, preuOperacio, canviAplicat, 0, descripcio, false, false);
                    ven.PreuParticipacioOrigen = mov1.PreuParticipacioOrigen.GetValueOrDefault(); // Modifico el PreuParticipacioOrigen.
                }
            }

            // Modifico les valoracions a partir de la data del ContraSplit.
            var dataPrimeraCompra = compresAnt.First()._Moviment.Data;
            modificaValoracions(connexio, TipusMoviment.ContraSplit, dataPrimeraCompra.Date, factorConversor);

            //connexio.SaveChanges();
        }



        /// <summary>
        /// Afegeig un preu a la taula "Valoracions"
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="dataHora"></param>
        /// <param name="preuParticipacio"></param>
        private void afegeigPreuAValoracions(InversionsBDContext connexio, DateTime dataHora, double preuParticipacio)
        {
            // Crea una valoració amb el preu del moviment
            Valoracio val = ValoracionsProducte.SingleOrDefault(a => a.Data.Date == dataHora.Date);
            if (val == null)
            {
                try
                {
                    Valoracio.Nova(connexio, this, dataHora, preuParticipacio);
                }
                catch (SqlException ex)
                {
                    if (ex.Number != 2627) // Si Duplicate Key en Valoracions no fa cas
                        throw;
                }
            }
            else
                val.modifica(connexio, dataHora, preuParticipacio);
        }


        /// <summary>
        /// Modifica les valoracions al fer Split o ContraSplit
        /// </summary>
        /// <param name="connexio"></param>
        /// <param name="tipusMoviment"></param>
        /// <param name="dataPrimeraCompra"></param>
        /// <param name="factorConversor"></param>
        private void modificaValoracions(InversionsBDContext connexio, TipusMoviment tipusMoviment, DateTime dataPrimeraCompra, int factorConversor)
        {
            foreach (var valoracio in connexio.Valoracions.Where(w => w.ProdId == Id && w.Data >= dataPrimeraCompra.Date))
            {
                if (tipusMoviment == TipusMoviment.ContraSplit)
                    valoracio.PreuParticipacio = Math.Round(valoracio.PreuParticipacio * factorConversor, 4);
                else if (tipusMoviment == TipusMoviment.Split)
                    valoracio.PreuParticipacio = Math.Round(valoracio.PreuParticipacio / factorConversor, 4);
                else
                    throw new ArgumentException("Paràmetre incorrecte", "tipusMoviment");

                connexio.Valoracions.AddOrUpdate(valoracio);
            }
        }


        #endregion *** Mètodes que modifiquen la BD ***


        [ObsoleteAttribute("Obsolet. Utilitzar 'costOriginalEnCartera'", false)]
        public double costOriginalEnCarteraMetodeAntic(DateTime? dataFinal = null)
        {
            var dFinal = Utilitats.DataFinalDia(dataFinal);

            var participacions = numParticipacionsEnData(dFinal);

            var compresAnt = new Stack<Moviment>(Program.Sessio.MovimentsUsuari
                .Where(w => w.ProdId == Id && w.TipusMoviment == TipusMoviment.Compra && w.Data < dFinal)
                .OrderBy(o => o.Data));

            double costAntic = 0;
            while (compresAnt.Count > 0 && participacions > 0)
            {
                var desg = compresAnt.Pop();
                double partOrig = 0;

                if (participacions > desg.Participacions)
                {
                    partOrig = desg.Participacions;
                    participacions -= desg.Participacions;
                }
                else
                {
                    partOrig = participacions;
                    participacions = 0;
                }
                costAntic += (partOrig * desg.PreuParticipacioOrigen.GetValueOrDefault());
            }

            return costAntic;
        }


        /// <summary>
        /// Calcula el cost real de les participacions en cartera.
        /// </summary>
        /// <param name="data">Si null calcula les participacions avui, sinò les que hi havia a la data.</param>
        /// <returns></returns>
        public double costOriginalEnCartera(DateTime? data = null)
        {
            var dFinal = Utilitats.DataFinalDia(data);

            var participacions = numParticipacionsEnData(dFinal);

            var compresDesgAnt = new Stack<DesglosCompra>(Program.Sessio.DesglosCompras
                .Where(w => w.RefCompra.UsuariId == Usuari.Seleccionat.Id && w.RefCompra.ProdId == Id && w.RefCompra.Data < dFinal)
                .OrderBy(o => o.RefCompra.Data).ThenBy(o => o.RefCompraOrig.Data));

            double cost = 0;
            while (compresDesgAnt.Count > 0 && participacions > 0)
            {
                var desg = compresDesgAnt.Pop();
                double partOrig = 0;

                if (participacions > desg.Participacions)
                {
                    partOrig = desg.ParticipacionsOrig;
                    participacions -= desg.Participacions;
                }
                else
                {
                    partOrig = participacions / desg.Participacions * desg.ParticipacionsOrig;
                    participacions = 0;
                }
                cost += (partOrig * desg._PreuPartOrig);
            }

            return cost;
        }


        /// <summary>
        /// Calcula el cost de les participacions en cartera. Utilitza el preu de compra del mateix producte no l'original.
        /// </summary>
        /// <param name="data">Si null calcula les participacions avui, sinò les que hi havia a la data.</param>
        /// <returns></returns>
        public double costEnCartera(DateTime? data = null)
        {
            var dFinal = Utilitats.DataFinalDia(data);

            var participacions = numParticipacionsEnData(dFinal);

            var compresAnt = new Stack<Moviment>(Program.Sessio.Moviments
                .Where(w => w.UsuariId == Usuari.Seleccionat.Id && w.ProdId == Id && w.Data < dFinal)
                .OrderBy(o => o.Data));

            double cost = 0;
            while (compresAnt.Count > 0 && participacions > 0)
            {
                var compra = compresAnt.Pop();
                double parts = 0;

                if (participacions > compra.Participacions)
                {
                    parts = compra.Participacions;
                    participacions -= compra.Participacions;
                }
                else
                {
                    parts = participacions;
                    participacions = 0;
                }
                cost += (parts * compra.PreuParticipacio);
            }

            return cost;
        }


        /// <summary>
        /// Calcula la diferencia de compra/venda en el periode.
        /// </summary>
        /// <param name="dInici"></param>
        /// <param name="dFinal"></param>
        /// <returns></returns>
        [ObsoleteAttribute("Obsolet. Utilitzar 'importCompra'", false)]
        private double importCompraAntic(DateTime dInici, DateTime dFinal)
        {
            return MovimentsProducteUsuari.
                Where(w => w.Data >= dInici && w.Data <= dFinal && w._EsVendaReal).
                Sum(s => s.Participacions * s.PreuParticipacioOrigen.GetValueOrDefault());
        }

        
        /// <summary>
        /// Calcula la diferencia de compra/venda en el periode a partir de les vendes reals entre les dates. Substitueix "importCompraAntic".
        /// </summary>
        /// <param name="dInici"></param>
        /// <param name="dFinal"></param>
        /// <returns></returns>
        private double importCompra(DateTime dInici, DateTime dFinal)
        {
            // Troba les vendes reals entre les dates inici i fi.
            var vendesReals = MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w._EsVendaReal);
            
            double importCompresOrig = 0;
            foreach (Moviment vendaReal in vendesReals)
            {
                // Troba les compres de la venda.
                var desgloçCompres = vendaReal.compresDeLaVenda(Program.Sessio);

                foreach (var desgloçCompra in desgloçCompres)
                {
                    importCompresOrig += (desgloçCompra._ParticipacionsDelMovimentOrigen * desgloçCompra._PreuParticipacioOrig);
                }
            }

            return importCompresOrig;
        }



        /// <summary>
        /// Quant ha guanyat en un periode. (Vendes o vendesT dins el periode) + (participacions en cartera al final del periode).
        /// Preu compra --> Si s'ha comprat dins el periode, preu compra o compraT, sinò, valoració al inici del periode del les venudes i en cartera.
        /// Preu venda  --> Si s'ha venut dins el periode, preu venda o vendaT, sinò, valoració al final del periode.
        /// </summary>
        /// <param name="dataInici"></param>
        /// <param name="dataFinal"></param>
        /// <returns></returns>
        private double pig(DateTime dataInici, DateTime dataFinal)
        {
            var dInici = dataInici.Date; // Poso la d'inici hora a zero.
            var dFinal = Utilitats.DataFinalDia(dataFinal);

            var compres = MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w.TipusMoviment == TipusMoviment.Compra).ToList();
            var vendes = MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w.TipusMoviment == TipusMoviment.Venda).ToList();

            double totalDividends = 0;
            double totalDespeses = 0;
            if (this is ProdAccions)
            {
                foreach (var venda in vendes)
                {
                    totalDespeses += venda.Despeses.GetValueOrDefault();
                    var compresAnt = venda.compresAnteriors();
                    foreach (MovimentCompra movimentCompra in compresAnt)
                    {
                        totalDespeses += movimentCompra._Moviment.Despeses.GetValueOrDefault() * movimentCompra._ParticipacionsDisponibles / movimentCompra._Moviment.Participacions;
                    }
                }

                totalDividends = MovimentsProducteUsuari.Where(w => w.Data >= dInici && w.Data <= dFinal && w.TipusMoviment == TipusMoviment.Dividends).Sum(s => s.PreuParticipacio);
            }

            // Calcula total compres mes valor en cartera a l'inici.
            // Preu compra --> Si s'ha comprat dins el periode, preu compra o compraT, sinò, valoració al inici del periode del les venudes i en cartera.
            var particEnCarteraInicial = numParticipacionsEnData(dInici);
            double valorInicialParticEnCartera = 0;
            if (particEnCarteraInicial > 0)
            {
                var dataValoracio = dInici == DateTime.MinValue ? dInici : dInici.AddTicks(-1); // Necessito la valoració anterior a la data dinici.
                valorInicialParticEnCartera = valorParticipacio(dataValoracio) * particEnCarteraInicial;
            }

            var importCompres = compres.Sum(s => s.Participacions * s.PreuParticipacio) + valorInicialParticEnCartera;

            // Calcula total vendes mes valor en cartera al final.
            // Preu venda  --> Si s'ha venut dins el periode, preu venda o vendaT, sinò, valoració al final del periode.
            var particEnCarteraFinal = numParticipacionsEnData(dFinal);
            double valorFinalParticEnCartera = 0;
            if (particEnCarteraFinal > 0)
                valorFinalParticEnCartera = valorParticipacio(dFinal) * particEnCarteraFinal;
            var importVendes = vendes.Sum(s => s.Participacions * s.PreuParticipacio) + valorFinalParticEnCartera;

            return importVendes - importCompres + totalDividends - totalDespeses;
        }

    
    }
}
