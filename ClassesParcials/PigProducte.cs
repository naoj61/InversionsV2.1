using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Comuns;
using DevExpress.Utils.CodedUISupport;

namespace Inversions
{
    #region Classes Ext

    public class VendaExt
    {
        public VendaExt(Moviment venda, decimal partsOcupades, decimal partsUtilitzades)
        {
            if (!venda._EsVenda)
                throw new Exception("El paràmetre 'venda' no és una venda");

            vVenda = venda;
            _PartsOcupades = partsOcupades;
            _PartsUtilitzades = partsUtilitzades;
        }


        private readonly Moviment vVenda;
        public decimal _PartsUtilitzades { get; set; }
        public decimal _PartsOcupades { get; set; }


        /// <summary>
        /// Participacions lliures.
        /// </summary>
        public decimal _PartsDisponibles
        {
            get { return vVenda.Participacions - _PartsUtilitzades - _PartsOcupades; }
        }


        public Moviment _Venda
        {
            get { return vVenda; }
        }


        public int _Id
        {
            get { return vVenda.Id; }
        }

        public DateTime _Data
        {
            get { return vVenda.Data; }
        }

        public decimal _Participacions
        {
            get { return vVenda.Participacions; }
        }

        public decimal _PreuParticipacio
        {
            get { return vVenda.PreuParticipacio; }
        }

        public decimal _Despeses
        {
            get { return vVenda.Despeses.GetValueOrDefault(); }
        }

        public decimal _DespesesPartsUtilitzades
        {
            get { return vVenda.Despeses.GetValueOrDefault() / vVenda.Participacions * _PartsUtilitzades; }
        }

        public bool _EsVendaReal
        {
            get { return vVenda._EsVendaReal; }
        }
        

        #region Equals

        public override bool Equals(object obj)
        {
            return Equals((VendaExt)obj);
        }

        public bool Equals(VendaExt other)
        {
            return vVenda == other.vVenda;
        }

        public override int GetHashCode()
        {
            return vVenda.GetHashCode();
        }

        public static bool operator ==(VendaExt left, VendaExt right)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            // If one is null,return false.
            if ((object)left == null || (object)right == null)
            {
                return false;
            }

            return left.vVenda == right.vVenda;
        }

        public static bool operator !=(VendaExt left, VendaExt right)
        {
            return !(left == right);
        }

        #endregion Equals

        public override string ToString()
        {
            return vVenda.ToString();
        }
    }

    public class CompraExt
    {
        public CompraExt(Moviment compra)
        {
            if (!compra._EsCompra)
                throw new Exception("El paràmetre 'compra' no és una compra");

            vCompra = compra;
        }

        public CompraExt(DesglosCompraExt desglosCompraExt) : this(desglosCompraExt._Compra)
        {
            vDesglosCompra.Add(desglosCompraExt);
        }

        private readonly Moviment vCompra;
        private readonly List<DesglosCompraExt> vDesglosCompra = new List<DesglosCompraExt>();

        public Moviment _Compra
        {
            get { return vCompra; }
        }

        public int _Id
        {
            get { return vCompra.Id; }
        }

        public DateTime _Data
        {
            get { return vCompra.Data; }
        }

        public decimal _Participacions
        {
            get { return vCompra.Participacions; }
        }

        public decimal _PreuParticipacio
        {
            get { return vCompra.PreuParticipacio; }
        }

        public decimal _Despeses
        {
            get { return vCompra.Despeses.GetValueOrDefault(); }
        }

        public decimal _PartsUtilitzades
        {
            get { return vDesglosCompra.Sum(s => s._PartsUtilitzades); }
        }

        public decimal _PartsOcupades
        {
            get { return vDesglosCompra.Sum(s => s._PartsOcupades); }
        }

        public decimal _DespesesPartsUtilitzades
        {
            get { return vCompra.Despeses.GetValueOrDefault() / vCompra.Participacions * _PartsUtilitzades; }
        }


        internal void addDesglos(DesglosCompraExt desglosCompra)
        {
            if (vDesglosCompra.Contains(desglosCompra))
            {
                var desg = vDesglosCompra.Single(w => w == desglosCompra);
                desg._PartsOcupades += desglosCompra._PartsOcupades;
                desg._PartsUtilitzades += desglosCompra._PartsUtilitzades;
            }
            else
                vDesglosCompra.Add(desglosCompra);
        }



        /// <summary>
        /// Calcula el preu total compra origen a partir del desgloç de les compres.
        /// </summary>
        /// <param name="calculaImportNet">Afegeig les despeses.</param>
        /// <returns></returns>
        public decimal calculaImportCompraOrigen3(bool calculaImportNet)
        {
            decimal desp = 0;
            if (calculaImportNet && vCompra.Despeses.HasValue)
            {
                if (vCompra.Participacions == _PartsUtilitzades)
                    //if (Utilitats.SonIguals(vCompra.Participacions, _PartsUtilitzades))
                    // Per evitar embolics amb els decimals, si Participacions i _ParticipacionsUtilitzades son iguals ja no cal dividirlos.
                    desp = vCompra.Despeses.Value;
                else
                    desp = vCompra.Despeses.Value / vCompra.Participacions * _PartsUtilitzades;
            }


            decimal import = 0;
            foreach (DesglosCompraExt desglosCompra in vDesglosCompra)
            {
                decimal partsOrig;
                if (Utilitats.SonIguals(desglosCompra._Participacions, desglosCompra._PartsUtilitzades))
                {
                    // Per evitar embolics amb els decimals, si Participacions i _ParticipacionsUtilitzades son iguals ja no cal dividirlos.
                    partsOrig = desglosCompra._ParticipacionsOrig;
                }
                else
                    // Pondero ParticipacionsOrig a partir de la diferència entre Participacions i _ParticipacionsUtilitzades.
                    partsOrig = desglosCompra._ParticipacionsOrig / desglosCompra._Participacions * desglosCompra._PartsUtilitzades;

                import += partsOrig * desglosCompra._PreuParticipacioOrig;
            }

            return import + desp;
        }


        #region Equals

        public override bool Equals(object obj)
        {
            return Equals((CompraExt) obj);
        }

        public bool Equals(CompraExt other)
        {
            return vCompra == other.vCompra;
        }

        public override int GetHashCode()
        {
            return vCompra.GetHashCode();
        }

        public static bool operator ==(CompraExt left, CompraExt right)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            // If one is null,return false.
            if ((object) left == null || (object) right == null)
            {
                return false;
            }

            return left.vCompra == right.vCompra;
        }

        public static bool operator !=(CompraExt left, CompraExt right)
        {
            return !(left == right);
        }

        #endregion Equals

        public override string ToString()
        {
            return vCompra.ToString();
        }
    }

    public class DesglosCompraExt
    {
        public DesglosCompraExt(DesglosCompra desgloçCompra)
        {
            vDesglosCompra = desgloçCompra;
        }

        private readonly DesglosCompra vDesglosCompra;

        public Moviment _CompraOrig
        {
            get { return vDesglosCompra.MovCompraOrig; }
        }

        public Moviment _Compra
        {
            get { return vDesglosCompra.MovCompra; }
        }

        public decimal _PreuParticipacioOrig
        {
            get { return vDesglosCompra._PreuParticipacioOrig; }
        }

        public decimal _Participacions
        {
            get { return vDesglosCompra.Participacions; }
        }

        /// <summary>
        /// Participacions que utilitza el procés actual.
        /// </summary>
        public decimal _PartsUtilitzades { get; set; }

        /// <summary>
        /// Participacions utilitzades per processos anteriors.
        /// </summary>
        public decimal _PartsOcupades { get; set; }

        /// <summary>
        /// Participacions lliures.
        /// </summary>
        public decimal _PartsDisponibles
        {
            get { return vDesglosCompra.Participacions - _PartsUtilitzades - _PartsOcupades; }
        }
        
        public decimal _ParticipacionsOrig
        {
            get { return vDesglosCompra.ParticipacionsOrig; }
        }
        
        /// <summary>
        /// Son les participacions originals utilitzades en aquest moviment.
        /// </summary>
        public decimal _PartsUtilitzadesOrig
        {
            get { return vDesglosCompra.ParticipacionsOrig / vDesglosCompra.Participacions * _PartsUtilitzades; }
        }

        public decimal _PartsOcupadesOrig
        {
            get { return vDesglosCompra.ParticipacionsOrig / vDesglosCompra.Participacions * _PartsOcupades; }
        }

        public decimal _PartsDisponiblesOrig
        {
            get { return vDesglosCompra.ParticipacionsOrig / vDesglosCompra.Participacions * _PartsDisponibles; }
        }

        public DateTime _Data
        {
            get { return _Compra.Data; }
        }

        public DateTime _DataOrig
        {
            get { return vDesglosCompra._DataOrig; }
        }

        public static IEnumerable<DesglosCompraExt> OmpleLlista(IEnumerable<Moviment> compres)
        {
            List<DesglosCompraExt> list = new List<DesglosCompraExt>();
            foreach (Moviment compra in compres)
            {
                if (!compra._EsCompra)
                    throw new ArgumentException(String.Format(" Id:{0}. No és una compra.", compra.Id));

                list.AddRange(compra.DesglosCompres.Select(compre => new DesglosCompraExt(compre)));
            }
            return list;
        }

        #region Equals

        public override bool Equals(object obj)
        {
            return Equals((DesglosCompraExt)obj);
        }

        public bool Equals(DesglosCompraExt other)
        {
            return this.vDesglosCompra == other.vDesglosCompra;
        }

        public override int GetHashCode()
        {
            return vDesglosCompra.GetHashCode();
        }

        public static bool operator ==(DesglosCompraExt left, DesglosCompraExt right)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(left, right))
            {
                return true;
            }

            // If one is null,return false.
            if ((object)left == null || (object)right == null)
            {
                return false;
            }

            return left.vDesglosCompra == right.vDesglosCompra;
        }

        public static bool operator !=(DesglosCompraExt left, DesglosCompraExt right)
        {
            return !(left == right);
        }

        #endregion Equals

        public override string ToString()
        {
            return vDesglosCompra.ToString();
        }

    }

    #endregion Classes Ext


    public partial class Moviment
    {
        internal decimal pigVenda4(bool pigOrig, bool inclouDespeses)
        {
            if (!_EsVenda)
                throw new Exception("El moviment no és una venda.");

            decimal pig = pigOrig && PiGVendaReal.HasValue 
                ? PiGVendaReal.Value 
                : Math.Round(Prod.pigEnData4(Data, pigOrig, inclouDespeses, Participacions, PreuParticipacio) - Despeses.GetValueOrDefault(), 3);
            
            return pig;
        }


        internal decimal pigCompra4(bool inclouDespeses, bool pigOrig, bool ambCartera, bool inclouDividends)
        {
            if (!_EsCompra)
                throw new Exception("El moviment no és una compra");
            
            decimal partsEnCartera;
            List<DesglosCompraExt> desglosCompraExt;
            var vendes = Prod.vendesDeCompra4(this, pigOrig, out partsEnCartera, out desglosCompraExt).ToList();
            desglosCompraExt = desglosCompraExt.Where(w => w._Compra == this).ToList();

            decimal importActualPartsEnCartera = 0;
            if (ambCartera)
            {
                // Si les parts venudes son inferiors a les comprades, és que encara hi ha parts en cartera. 
                //var partsEnCartera = Participacions - vendes.Sum(s => s._PartsUtilitzades);
                importActualPartsEnCartera = partsEnCartera * Prod._PreuParticipacioActual;
            }

            var importPartsVenudes = vendes.Sum(s => s._PartsUtilitzades * s._PreuParticipacio);

            decimal importCompra;
            if (pigOrig)
                if (ambCartera)
                {
                    importCompra = desglosCompraExt.Where(desgC => desgC._Compra == this)
                        .Sum(desgC => (desgC._PartsDisponiblesOrig + desgC._PartsUtilitzadesOrig) * desgC._PreuParticipacioOrig);
                }
                else
                    importCompra = desglosCompraExt.Sum(s => s._PartsUtilitzadesOrig * s._PreuParticipacioOrig);
            else
                if (ambCartera)
                    importCompra = _ImportBrut;
                else
                    importCompra = (Participacions - partsEnCartera) * PreuParticipacio;

            var pig = importActualPartsEnCartera + importPartsVenudes - importCompra;

            var despeses = inclouDespeses
                ? Math.Round(vendes.Sum(s => s._DespesesPartsUtilitzades) + Despeses.GetValueOrDefault(), 3)
                : 0;

            var dividends = inclouDividends ? dividendsCompra4() : 0;

            return Math.Round(pig + dividends - despeses, 3);
        }


        /// <summary>
        /// Torna l'import dels dividents cobrats que corresponen a la compra.
        /// </summary>
        /// <returns></returns>
        internal decimal dividendsCompra4()
        {
            if (!_EsCompra)
                throw new Exception("El moviment no és una compra");

            // Busco els dividents amb data superior a la compra.
            var divs = MovimentsUsuari.Where(mov => mov.ProdId == ProdId && mov.Data >= Data && mov._EsDividents).ToList();

            if (divs.Count == 0)
                return 0;

            // A partir de les participacions en cartera a la data de cada divident, miro quines compres li corresponen.
            decimal divCompra = 0;
            foreach (var dividend in divs)
            {
                var partsEnDataDivident = Prod.partsEnCartera(dividend.Data);
                var compraExt = Prod.desglosCompresDeParticipacionsEnData4(dividend.Data, partsEnDataDivident, false).SingleOrDefault(s => s._Compra == this);
                if (compraExt != null)
                {
                    // Si alguna compra coincideix amb la del paràmetre, reparteixo els dividents entre les participacions que li corresponguin
                    var div = dividend.PreuParticipacio / partsEnDataDivident * compraExt._PartsUtilitzades;
                    divCompra += div;
                }
            }

            return divCompra;
        }

        #region *** Test ***
        
        public decimal pigVenda4Test(bool pigOrig, bool inclouDespeses)
        {
            return pigVenda4(pigOrig, inclouDespeses);
        }

        public decimal pigCompra4Test(bool inclouDespeses, bool pigOrig, bool ambCartera, bool inclouDividends)
        {
            return pigCompra4(inclouDespeses, pigOrig, ambCartera, inclouDividends);
        }

        public decimal dividentsCompraTest()
        {
            return dividendsCompra4();
        }

        #endregion *** Test ***
    }


    public abstract partial class Producte
    {
        /*
         * -PiG Actual: Participacions en cartera, menys el preu de compra d'aquestes en el mateix producte.
         * 
         * -PiG Actual Orig: Participacions en cartera, menys el preu de compra original d'aquestes participacions.
         * 
         * -PiG Historic:  Participacions(Totes les vendes). 
         *  Preu actual més preu vendes, menys preu compra de totes les participacions en el mateix producte.
         * 
         * -PiG Historic Orig:  Participacions(Vendes reals). 
         *  Preu actual més preu vendes menys Preu compra original de les participacions.
         *  
         * -PiG entre dates. PiG Historic a data final, menys PiG historic a data inici.
         * 
         */

        internal decimal pigHistoric4(int any, bool pigOrig, bool inclouDespeses, bool inclouDividends)
        {
            var dataIni = new DateTime(any, 1, 1).AddTicks(-1);

            return pigHistoric4(dataIni, dataIni.AddYears(1), pigOrig, inclouDespeses, inclouDividends);
        }


        internal decimal pigHistoric4(DateTime dataInici, DateTime dataFi, bool pigOrig, bool inclouDespeses, bool inclouDividends)
        {
            decimal div = inclouDividends 
                ? Moviment.MovimentsUsuari.Where(mov => mov.Prod == this && mov._EsDividents && mov.Data > dataInici && mov.Data <= dataFi)
                .Sum(divid => divid._ImportBrut)
                : 0;

            return pigHistoric4(dataFi, pigOrig, inclouDespeses) - pigHistoric4(dataInici, pigOrig, inclouDespeses) + div;
        }


        internal decimal pigHistoric4(DateTime data, bool pigOrig, bool inclouDespeses)
        {
            var vendes = MovimentsProducteUsuari.Where(w => w._EsVenda && w.Data <= data).ToList();
            
            if (pigOrig)
                vendes = vendes.Where(w => w._EsVendaReal).ToList();

            decimal pigVendes = vendes.Sum(venda => venda.pigVenda4(pigOrig, inclouDespeses));

            return pigVendes;
        }


        internal decimal pigEnData4(int any, bool pigOrig, bool inclouDespeses)
        {
            var dataIni = new DateTime(any, 1, 1).AddTicks(-1);

            return pigEnData4(dataIni, dataIni.AddYears(1), pigOrig, inclouDespeses);
        }


        internal decimal pigEnData4(DateTime dataInici, DateTime dataFi, bool pigOrig, bool inclouDespeses)
        {
            return pigEnData4(dataFi, pigOrig, inclouDespeses) - pigEnData4(dataInici, pigOrig, inclouDespeses);
        }

        internal decimal pigEnData4(DateTime data, bool pigOrig, bool inclouDespeses, decimal? participacions = null, decimal? preuParticipacio = null)
        {
            decimal despesesCompres;

            var parts = participacions.GetValueOrDefault(partsEnCartera(data));
            var preuPart = preuParticipacio.GetValueOrDefault(valorParticipacio(data));

            var pig = pig4(data, parts, preuPart, pigOrig, out despesesCompres);

            return pig - (inclouDespeses ? despesesCompres : 0);
        }


        public decimal pigActual4Test(bool pigOrig, bool inclouDespeses)
        {
            return pigActual4(pigOrig, inclouDespeses);
        }

        internal decimal pigActual4(bool pigOrig, bool inclouDespeses, decimal? participacions = null, decimal? preuParticipacio = null)
        {
            return pigEnData4(DateTime.Now, pigOrig, inclouDespeses, participacions, preuParticipacio);
        }


        #region *** Mètodes bàsics ***

        /// <summary>
        /// Torna la llista de les desgloç compres de les partipacions del producte en una data.
        /// la venda pot ser que encara no existeixi en la taula moviments o que siguin les participacions en cartera.
        /// </summary>
        /// <param name="dataHora">Es buscaran compres anteriors a aquesta data.</param>
        /// <param name="numPartipacions">Son les partipacions de les que buscaré les seves compres.</param>
        /// <param name="pigOrig">Indica si les compres s'han d'ordenar per Data o per DataOrig.</param>
        /// <returns></returns>
        internal IEnumerable<DesglosCompraExt> desglosCompresDeParticipacionsEnData4(DateTime dataHora, decimal numPartipacions, bool pigOrig = true)
        {
            if (Utilitats.EsZero(numPartipacions))
                return new List<DesglosCompraExt>();

            var vendesAnt = MovimentsProducteUsuari.Where(w => w._EsVenda && w.Data < dataHora).OrderBy(o => o.Data).ToList();
            var desglosCompresAnt = DesglosCompraExt.OmpleLlista(MovimentsProducteUsuari.Where(w => w._EsCompra && w.Data < dataHora));

            // Ordena les compres anteriors.
            desglosCompresAnt = pigOrig ? desglosCompresAnt.OrderBy(o => o._DataOrig) : desglosCompresAnt.OrderBy(o => o._Data);
            desglosCompresAnt = desglosCompresAnt.ToList();

            // Marco les participacions ocupades per vendes anteriors.
            decimal partsVenudesResten;
            foreach (var venda in vendesAnt)
            {
                var dataVenda = venda.Data;
                partsVenudesResten = venda.Participacions;

                foreach (var desgCompra in desglosCompresAnt.Where(w => w._Data < dataVenda && w._PartsDisponibles > 0))
                {
                    if (partsVenudesResten > desgCompra._PartsDisponibles)
                    {
                        partsVenudesResten -= desgCompra._PartsDisponibles;
                        desgCompra._PartsOcupades += desgCompra._PartsDisponibles; // Al augmentar _PartsOcupades disminueixen _PartsDisponibles.
                    }
                    else
                    {
                        desgCompra._PartsOcupades += partsVenudesResten;
                        break;
                    }
                }
            }

            // Marco les participacions utilitzades en aquesta venda.
            partsVenudesResten = numPartipacions;
            foreach (var desgCompra in desglosCompresAnt.Where(w => w._PartsDisponibles > 0))
            {
                if (partsVenudesResten > desgCompra._PartsDisponibles)
                {
                    partsVenudesResten -= desgCompra._PartsDisponibles;
                    desgCompra._PartsUtilitzades += desgCompra._PartsDisponibles;
                }
                else
                {
                    desgCompra._PartsUtilitzades += partsVenudesResten;
                    break;
                }
            }

            return desglosCompresAnt.Where(w => w._PartsUtilitzades > 0);
        }

        /// <summary>
        /// Torna la llista de les compres de les partipacions del producte en una data.
        /// la venda pot ser que encara no existeixi en la taula moviments o que siguin les participacions en cartera.
        /// </summary>
        /// <param name="dataHora">Es buscaran compres anteriors a aquesta data.</param>
        /// <param name="numPartipacions">Son les partipacions de les que buscaré les seves compres. Si null les que estan en cartera a la data.</param>
        /// <param name="pigOrig">Indica si les compres s'han d'ordenar per Data o per DataOrig.</param>
        /// <returns></returns>
        internal IEnumerable<CompraExt> compresDePartipacionsEnData4(DateTime dataHora, decimal numPartipacions, bool pigOrig = true)
        {
            List<CompraExt> compres = new List<CompraExt>();

            // Creo la llista de compres de les participacions numPartipacions.
            foreach (var desglosCompraExt in desglosCompresDeParticipacionsEnData4(dataHora, numPartipacions, pigOrig))
            {
                // Busca la compra en la llista de compresExt que estic creant.
                var compra = compres.SingleOrDefault(w => w._Compra == desglosCompraExt._Compra);

                if (compra == null)
                {
                    // La compra encara no existeix en la llista
                    compres.Add(new CompraExt(desglosCompraExt));
                }
                else
                {
                    // La compra ja existeix en la llista
                    compra.addDesglos(desglosCompraExt);
                }
            }
            
            return compres;
        }

        public IEnumerable<VendaExt> vendesDeCompra4(Moviment compra, bool pigOrig)
        {
            decimal partsEnCartera;
            List<DesglosCompraExt> desglosCompraExt;
            
            return vendesDeCompra4(compra, pigOrig, out partsEnCartera, out desglosCompraExt).ToList();
        }

        /// <summary>
        /// Torna la llista de les vendes amb les participacions utilitzades de la compra i les participacions en cartera.
        /// Les vendes de les participacions no son les mateixes si agafem dedes Originals.
        /// </summary>
        /// <param name="compra"></param>
        /// <param name="pigOrig"></param>
        /// <param name="partsEncartera"></param>
        /// <param name="desglosCompraTot"></param>
        /// <returns></returns>
        public IEnumerable<VendaExt> vendesDeCompra4(Moviment compra, bool pigOrig, out decimal partsEncartera, out List<DesglosCompraExt> desglosCompraTot)
        {
        if (!compra._EsCompra)
                throw new Exception("No és una compra");

            if (compra.Usuari != Usuari.Seleccionat)
                throw new Exception("La compra no pertany al usuari seleccionat");

            if (compra.Prod != this)
                throw new Exception("La compra no pertany a  aquest producte");


            var vendesTotes = MovimentsProducteUsuari.Where(venda => venda._EsVenda)
                .Select(venda => new VendaExt(venda, 0, 0)).OrderBy(o => o._Data).ToList();

            desglosCompraTot = new List<DesglosCompraExt>();
            foreach (var compraX in MovimentsProducteUsuari.Where(w=>w._EsCompra))
            {
                desglosCompraTot.AddRange(compraX.DesglosCompres.Select(desglosCompra => new DesglosCompraExt(desglosCompra)));
            }
            desglosCompraTot = desglosCompraTot.ToList();

            if (pigOrig)
                desglosCompraTot = desglosCompraTot.OrderBy(o => o._DataOrig).ToList();
            else
                desglosCompraTot = desglosCompraTot.OrderBy(o => o._Data).ToList();

            foreach (var vendaExt in vendesTotes)
            {
                var dataVenda = vendaExt._Data;
                foreach (var desglosCompraExt in desglosCompraTot.Where(w => w._Compra.Data < dataVenda && w._PartsDisponibles > 0))
                {
                    /*
                     * Només compres anteriors a la venda. 
                     * Encara que la data orig sigui menor si en el moment de la venda encara no s'havia fet la compra...
                     */

                    decimal partsDisp = vendaExt._PartsDisponibles > desglosCompraExt._PartsDisponibles 
                        ? desglosCompraExt._PartsDisponibles 
                        : vendaExt._PartsDisponibles;

                    if (compra == desglosCompraExt._Compra)
                    {
                        desglosCompraExt._PartsUtilitzades += partsDisp;
                        vendaExt._PartsUtilitzades += partsDisp;
                    }
                    else //if(desglosCompraExt._Compra.Data < compra.Data)
                    {
                        desglosCompraExt._PartsOcupades += partsDisp;
                        vendaExt._PartsOcupades += partsDisp;
                    }

                    if(vendaExt._PartsDisponibles == 0)
                        break;
                }
            }

            var vendes = vendesTotes.Where(venda=>venda._PartsUtilitzades > 0).ToList();
            partsEncartera = compra.Participacions - vendes.Sum(venda => venda._PartsUtilitzades);
            var aaa = vendesTotes.Sum(venda => venda._PartsUtilitzades);

            return vendes;
        }


        /// <summary>
        /// Calcula el PiG, és indiferents si son participacions en cartera o corresponen a una venda.
        /// </summary>
        /// <param name="dataHora">Data a partir d'on buscaran les compres anteriors</param>
        /// <param name="partipacions">Participacions utilitzades.</param>
        /// <param name="preuPart">Preu per calcular l'import sobre el que es restarà el preu de compra.</param>
        /// <param name="pigOrig">Indica si s'han d'utilitzar els preus origen o no.</param>
        /// <param name="despesesCompres">Torna les despeses de les compres.</param>
        /// <returns></returns>
        private decimal pig4(DateTime dataHora, decimal partipacions, decimal preuPart, bool pigOrig, out decimal despesesCompres)
        {
            var desgloçCompres = desglosCompresDeParticipacionsEnData4(dataHora, partipacions, pigOrig).ToList();

            decimal importCompra = pigOrig 
                ? desgloçCompres.Sum(dcExt => dcExt._PartsUtilitzadesOrig * dcExt._PreuParticipacioOrig) 
                : desgloçCompres.Sum(dcExt => dcExt._PartsUtilitzades * dcExt._Compra.PreuParticipacio);

            if (!pigOrig)
            {
                importCompra = 0;
                decimal partsUt = 0;
                foreach (DesglosCompraExt dcExt in desgloçCompres)
                {
                    importCompra += dcExt._PartsUtilitzades * dcExt._Compra.PreuParticipacio;
                    partsUt += dcExt._PartsUtilitzades;
                }
            }


            decimal importVenda = preuPart * partipacions;

            // Algun fons pot tenir despeses, es poden produir en qualsevol dels traspassos i no tinc ganes de complicar-me la vida
            despesesCompres = this is ProdAccions 
                ? desgloçCompres.Sum(s => s._Compra.Despeses.GetValueOrDefault() / s._Compra.Participacions * s._PartsUtilitzades) 
                : 0;

            return importVenda - importCompra;
        }

        #endregion *** Mètodes bàsics ***


        #region *** Test ***


        public decimal pigHistoric4Test(bool pigOrig, bool inclouDespeses, DateTime data)
        {
            return pigHistoric4(data, pigOrig, inclouDespeses);
        }

        public IEnumerable<DesglosCompraExt> desglosCompresDeParticipacionsEnData4Test(DateTime dataHora, decimal numPartipacions)
        {
            return desglosCompresDeParticipacionsEnData4(dataHora, numPartipacions, true);
        }

        public IEnumerable<CompraExt> compresDePartipacionsEnData4Test(DateTime dataHora, decimal? numPartipacions = null)
        {
            return compresDePartipacionsEnData4(dataHora, numPartipacions.GetValueOrDefault(_Participacions), true);
        }

        public decimal pigHistoric4Test(int any, bool pigOrig, bool inclouDespeses, bool inclouDividends = true)
        {
            return pigHistoric4(any, pigOrig, inclouDespeses, inclouDividends);
        }

        public decimal pigEnData4Test(DateTime data, bool pigOrig, bool inclouDespeses, decimal? participacions = null, decimal? preuParticipacio = null)
        {
            return pigEnData4(data, pigOrig, inclouDespeses, participacions, preuParticipacio);
        }

        #endregion *** Test ***
    }
}