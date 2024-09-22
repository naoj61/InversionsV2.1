using System;
using System.Collections.Generic;
using System.Linq;
using Comuns;


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

        public CompraExt(DesglosCompraExt desglosCompraExt)
            : this(desglosCompraExt._Compra)
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
            return Equals((CompraExt)obj);
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
            if ((object)left == null || (object)right == null)
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

        /// <summary>
        /// PiG de tots els productes en un any. Vendes reals dins el periode.
        /// Preu compra --> Preu origen.
        /// Preu venda  --> Preu venda.
        /// </summary>
        /// <param name="tipusProducte"></param>
        /// <param name="any"></param>
        /// <param name="inclouCartera"></param>
        /// <param name="inclouDividends">En la tributació a la renda els dividends tributen a part de les PiG de les accions. </param>
        /// <returns></returns>
        internal static decimal Pig4(TipusProducte tipusProducte, int any, bool inclouCartera, bool inclouDividends)
        {
            var dataInici = new DateTime(any, 1, 1);
            var dataFi = dataInici.AddYears(1).AddMilliseconds(-1);

            return Pig4(tipusProducte, null, dataInici, dataFi, true, inclouCartera, true, inclouDividends);
        }

        internal static decimal Pig4(TipusProducte tipusProducte, TipusFons? tipusFons,
          DateTime dataInici, DateTime dataFinal, bool pigOrig, bool inclouCartera, bool inclouDespeses, bool inclouDividends)
        {
            IEnumerable<Producte> prods = SeleccionaProds(tipusProducte, tipusFons).ToList();

            var div = inclouDividends ? prods.Sum(s=>s.dividends(dataInici, dataFinal)) : 0;
            
            var pig = prods.Sum(prod => prod.pigEntreDates4(dataInici, dataFinal, pigOrig, inclouDespeses, inclouCartera, true));

            return pig + div;
        }

        internal decimal pigEnAny4(int any, bool pigOrig, bool inclouDespeses, bool inclouCartera, bool utilitzarPiGVendaReal)
        {
            var dataIni = new DateTime(any, 1, 1).AddTicks(-1);
            var dataFi = dataIni.AddYears(1);

            return pigEntreDates4(dataIni, dataFi, pigOrig, inclouDespeses, inclouCartera, utilitzarPiGVendaReal);
        }


        internal decimal pigEntreDates4(DateTime dataInici, DateTime dataFi
            , bool pigOrig, bool inclouDespeses, bool inclouCartera, bool utilitzarPiGVendaReal)
        {
            var pigDataInici = pigEnData4(dataInici, pigOrig, inclouDespeses, inclouCartera, utilitzarPiGVendaReal);
            var pigDataFinal = pigEnData4(dataFi, pigOrig, inclouDespeses, inclouCartera, utilitzarPiGVendaReal);

            return pigDataFinal - pigDataInici;
        }



        /// <summary>
        /// Calcula el cost original de les participacions en cartera. Inclou despeses. 
        /// </summary>
        /// <param name="dataHoraFinal">Si null calcula les participacions avui, sinò les que hi havia a la data.</param>
        /// <param name="numPartsMax">Limita el cost a num de participacions</param>
        /// <returns></returns>
        internal decimal costOriginalEnCartera4(DateTime? dataHoraFinal = null, decimal? numPartsMax = null)
        {
            var dataH = dataHoraFinal.GetValueOrDefault(DateTime.Now);
            var numParts = numPartsMax.GetValueOrDefault(numParticipacionsEnData(dataH));

            decimal despesesCompres;

            return importCompra(dataH, numParts, true, out despesesCompres);
        }


        /// <summary>
        /// PiG de totes les vendes anteriors a 'dataHora' més el PiG de les participacions en cartera a 'dataHora'.
        /// </summary>
        /// <param name="dataHora"></param>
        /// <param name="pigOrig"></param>
        /// <param name="inclouDespeses"></param>
        /// <param name="inclouCartera"></param>
        /// <param name="utilitzarPiGVendaReal"></param>
        /// <returns></returns>
        internal decimal pigEnData4(DateTime dataHora
            , bool pigOrig, bool inclouDespeses, bool inclouCartera, bool utilitzarPiGVendaReal)
        {
            var vendes = MovimentsProducteUsuari.Where(mov => mov.Data < dataHora && mov._EsVenda).ToList();

            if (pigOrig)
                vendes = vendes.Where(venda => venda._EsVendaReal).ToList();

            var pigVendes = vendes.Sum(venda => venda.pigVenda4(pigOrig, inclouDespeses, utilitzarPiGVendaReal));
            var pigEnCartera = inclouCartera ? pigEnCartera4(pigOrig, inclouDespeses, dataHora) : 0;

            return pigVendes + pigEnCartera;
        }



        #region *** Criden a els mètodes bàsics ***

        /// <summary>
        /// Calcula el PiG de les participacions en cartera.
        /// </summary>
        /// <param name="pigOrig">Indica si s'han d'utilitzar els preus origen o no.</param>
        /// <param name="inclouDespeses">Torna les despeses de les compres.</param>
        /// <param name="dataHora">Data a partir d'on buscaran les compres anteriors. Si null, data hora actual.</param>
        /// <param name="preuParticipacio">Permet calcular la cartera amb un preu diferent a l'actual.</param>
        /// <returns></returns>
        internal decimal pigEnCartera4(bool pigOrig, bool inclouDespeses, DateTime? dataHora = null
            , decimal? preuParticipacio = null)
        {
            var data = dataHora.GetValueOrDefault(DateTime.Now);
            var parts = partsEnCartera(data);
            var preuPart = preuParticipacio.GetValueOrDefault(valorParticipacio(data));

            decimal despesesCompres;
            var pig = basicPigVendaOCartera4(data, parts, preuPart, pigOrig, out despesesCompres);

            if (inclouDespeses)
                pig -= despesesCompres;

            return pig;
        }

        /// <summary>
        /// Calcula el PiG de la venda.
        /// </summary>
        /// <param name="venda"></param>
        /// <param name="pigOrig">Indica si s'han d'utilitzar els preus origen o no.</param>
        /// <param name="utilitzarPiGVendaReal">Indica si s'ha de agafar el valor del PiG del camp: 'PiGVendaReal'.</param>
        /// <param name="despesesCompres">Torna les despeses de les compres.</param>
        /// <returns></returns>
        internal decimal pigVenda4(Moviment venda, bool pigOrig, bool utilitzarPiGVendaReal, out decimal despesesCompres)
        {
            if (!venda._EsVenda)
                throw new ArgumentException("El paràmetre no és una venda", "venda");

            if (pigOrig)
            {
                if (!venda._EsVendaReal)
                    // Si PigOrig, només tenen PiG les vendes reals.
                    throw new ArgumentException("Si 'pigOrig = true', el paràmetre ha de ser venda real", "venda");

                if (utilitzarPiGVendaReal && venda.PiGVendaReal.HasValue)
                {
                    despesesCompres = 0;
                    return venda.PiGVendaReal.Value;
                }
            }

            return basicPigVendaOCartera4(venda.Data, venda.Participacions, venda.PreuParticipacio, pigOrig, out despesesCompres);
        }

        /// <summary>
        /// Torna la llista de les vendes amb les participacions utilitzades de la compra i les participacions en cartera.
        /// Les vendes de les participacions no son les mateixes si agafem dedes Originals.
        /// </summary>
        /// <param name="compra"></param>
        /// <param name="pigOrig"></param>
        /// <param name="partsEnCartera"></param>
        /// <param name="desglosCompraTot"></param>
        /// <returns></returns>
        internal IEnumerable<VendaExt> vendesDeCompra4(Moviment compra, bool pigOrig, out decimal partsEnCartera
            , out List<DesglosCompraExt> desglosCompraTot)
        {
            return basicVendesDeCompra4(compra, pigOrig, out partsEnCartera, out desglosCompraTot).ToList();
        }

        #endregion *** Criden a els mètodes bàsics ***


        #region *** Mètodes bàsics ***

        /// <summary>
        /// Torna la llista de les compres de les partipacions del producte en una data.
        /// la venda pot ser que encara no existeixi en la taula moviments o que siguin les participacions en cartera.
        /// </summary>
        /// <param name="dataHora">Es buscaran compres anteriors a aquesta data.</param>
        /// <param name="numPartipacions">Son les partipacions de les que buscaré les seves compres. Si null les que estan en cartera a la data.</param>
        /// <param name="pigOrig">Indica si les compres s'han d'ordenar per Data o per DataOrig.</param>
        /// <returns></returns>
        internal IEnumerable<CompraExt> basicCompresDePartipacionsEnData4(DateTime dataHora, decimal numPartipacions, bool pigOrig = true)
        {
            List<CompraExt> compres = new List<CompraExt>();

            // Creo la llista de compres de les participacions numPartipacions.
            foreach (var desglosCompraExt in basicDesglosCompresDeParticipacionsEnData4(dataHora, numPartipacions, pigOrig))
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

        /// <summary>
        /// Torna la llista de les desgloç compres de les partipacions del producte en una data.
        /// la venda pot ser que encara no existeixi en la taula moviments o que siguin les participacions en cartera.
        /// </summary>
        /// <param name="dataHora">Es buscaran compres anteriors a aquesta data.</param>
        /// <param name="numPartipacions">Son les partipacions de les que buscaré les seves compres.</param>
        /// <param name="pigOrig">Indica si les compres s'han d'ordenar per Data o per DataOrig.</param>
        /// <returns></returns>
        internal IEnumerable<DesglosCompraExt> basicDesglosCompresDeParticipacionsEnData4(DateTime dataHora, decimal numPartipacions, bool pigOrig = true)
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
        /// Torna la llista de les vendes amb les participacions utilitzades de la compra i les participacions en cartera.
        /// Les vendes de les participacions no son les mateixes si agafem dedes Originals.
        /// </summary>
        /// <param name="compra"></param>
        /// <param name="pigOrig"></param>
        /// <param name="partsEnCartera"></param>
        /// <param name="desglosCompraTot"></param>
        /// <returns></returns>
        private IEnumerable<VendaExt> basicVendesDeCompra4(Moviment compra, bool pigOrig, out decimal partsEnCartera
            , out List<DesglosCompraExt> desglosCompraTot)
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
            foreach (var compraX in MovimentsProducteUsuari.Where(w => w._EsCompra))
            {
                desglosCompraTot.AddRange(compraX.DesglosCompres.Select(desglosCompra => new DesglosCompraExt(desglosCompra)));
            }
            desglosCompraTot = desglosCompraTot.ToList();

            if (pigOrig)
                desglosCompraTot = desglosCompraTot.OrderBy(o => o._DataOrig).ThenBy(o => o._Data).ToList();
            else
                desglosCompraTot = desglosCompraTot.OrderBy(o => o._Data).ToList();

            partsEnCartera = compra.Participacions;

            foreach (var vendaExt in vendesTotes)
            {
                var dataVenda = vendaExt._Data;
                var desglosCompraDisp = desglosCompraTot.Where(w => w._Compra.Data < dataVenda && w._PartsDisponibles > 0).ToList();
                foreach (var desglosCompraExt in desglosCompraDisp)
                {
                    /*
                     * Només compres anteriors a la venda. 
                     * Encara que la data orig sigui menor si en el moment de la venda encara no s'havia fet la compra...
                     */

                    decimal partsDisp = vendaExt._PartsDisponibles > desglosCompraExt._PartsDisponibles
                        ? desglosCompraExt._PartsDisponibles
                        : vendaExt._PartsDisponibles;

                    if (compra == desglosCompraExt._Compra)
                        partsEnCartera -= partsDisp;

                    if (compra == desglosCompraExt._Compra && (vendaExt._EsVendaReal || !pigOrig))
                    {
                        desglosCompraExt._PartsUtilitzades += partsDisp;
                        vendaExt._PartsUtilitzades += partsDisp;
                    }
                    else //if(desglosCompraExt._Compra.Data < compra.Data)
                    {
                        desglosCompraExt._PartsOcupades += partsDisp;
                        vendaExt._PartsOcupades += partsDisp;
                    }

                    if (vendaExt._PartsDisponibles == 0)
                        break;
                }
            }

            var vendes = vendesTotes.Where(venda => venda._PartsUtilitzades > 0).ToList();

            return vendes;
        }


        /// <summary>
        /// Calcula el PiG, o de les participacions en cartera o les d'una venda.
        /// </summary>
        /// <param name="dataHora">Data a partir d'on buscaran les compres anteriors</param>
        /// <param name="participacions">Participacions utilitzades.</param>
        /// <param name="preuPart">Preu per calcular l'import sobre el que es restarà el preu de compra.</param>
        /// <param name="pigOrig">Indica si s'han d'utilitzar els preus origen o no.</param>
        /// <param name="despesesCompres">Torna les despeses de les compres.</param>
        /// <returns></returns>
        private decimal basicPigVendaOCartera4(DateTime dataHora, decimal participacions, decimal preuPart, bool pigOrig
            , out decimal despesesCompres)
        {
            decimal impCompra = importCompra(dataHora, participacions, pigOrig, out despesesCompres);
            
            decimal importVenda = preuPart * participacions;

            return importVenda - impCompra;
        }

        /// <summary>
        /// Calcula el preu de cost de les compres anteriors a DataHora.
        /// </summary>
        /// <param name="dataHora"></param>
        /// <param name="participacions"></param>
        /// <param name="pigOrig">Calcula el cost original.</param>
        /// <param name="despesesCompres"></param>
        /// <returns></returns>
        private decimal importCompra(DateTime dataHora, decimal participacions, bool pigOrig, out decimal despesesCompres)
        {
            decimal impCompra;
            if (pigOrig && this is ProdFons)
            {
                var desgloçCompres = basicDesglosCompresDeParticipacionsEnData4(dataHora, participacions, pigOrig).ToList();

                impCompra = desgloçCompres.Sum(dcExt => dcExt._PartsUtilitzadesOrig * dcExt._PreuParticipacioOrig);

                // Algun fons pot tenir despeses, es poden produir en qualsevol dels traspassos i no tinc ganes de complicar-me la vida
                despesesCompres = 0;
            }
            else
            {
                var compres = basicCompresDePartipacionsEnData4(dataHora, participacions, false).ToList();

                impCompra = compres.Sum(compra => compra._PartsUtilitzades * compra._PreuParticipacio);

                despesesCompres = compres.Sum(compra => compra._Compra.Despeses.GetValueOrDefault() / compra._Participacions * compra._PartsUtilitzades);
            }

            return impCompra;
        }

        #endregion *** Mètodes bàsics ***


        #region *** Test ***

        public decimal pigHistoric4Test(bool pigOrig, bool inclouDespeses, DateTime data, bool utilitzarPiGVendaReal = true)
        {
            return pigEnData4(data, pigOrig, inclouDespeses, false, utilitzarPiGVendaReal);
        }

        public IEnumerable<DesglosCompraExt> desglosCompresDeParticipacionsEnData4Test(DateTime dataHora, decimal numPartipacions)
        {
            return basicDesglosCompresDeParticipacionsEnData4(dataHora, numPartipacions, true);
        }

        public IEnumerable<CompraExt> compresDePartipacionsEnData4Test(DateTime dataHora, decimal? numPartipacions = null)
        {
            return basicCompresDePartipacionsEnData4(dataHora, numPartipacions.GetValueOrDefault(_Participacions), true);
        }

        public decimal pigEnAny4Test(int any, bool pigOrig, bool inclouDespeses, bool inclouCartera = false, bool utilitzarPiGVendaReal = true)
        {
            return pigEnAny4(any, pigOrig, inclouDespeses, inclouCartera, utilitzarPiGVendaReal);
        }

        public decimal pigEnCartera4Test(bool pigOrig, bool inclouDespeses, DateTime? dataHora = null, decimal? preuParticipacio = null)
        {
            return pigEnCartera4(pigOrig, inclouDespeses, dataHora, preuParticipacio);
        }

        public IEnumerable<VendaExt> vendesDeCompra4Test(Moviment compra, bool pigOrig, out decimal partsEnCartera
            , out List<DesglosCompraExt> desglosCompraTot)
        {

            return vendesDeCompra4(compra, pigOrig, out partsEnCartera, out desglosCompraTot);
        }


        #endregion *** Test ***
    }
}