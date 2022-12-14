using System;
using System.Collections.Generic;
using System.Text;
using RDI.Lince;
using System.Net;

namespace RDI.NFe2.Business
{
    public class Parametro : BusinessObject
    {
        public string versaoDados = "2.00";

        RDI.NFe2.SchemaXML.TCodUfIBGE _UF;                      /* UF do WEBSERVICE (31,52) */
        RDI.NFe2.SchemaXML.TAmb _tipoAmbiente;                  /* Homologacao 1 Producao 2 */
        RDI.NFe2.SchemaXML.TNFeInfNFeIdeTpEmis _tipoEmissao;   /* normal 1 - contigencia 2 */


        String _pastaEntrada; /* Diretorio onde sao salvos as nfes a serem enviadas  */
        String _pastaSaida;   /* Diretorio onde sao salvos as nfes q foram enviadas  */
        String _pastaRecibo;  /* Diretorio onde sao salvos os recibos de comunicacao */
        String _pastaImpressao;  /* Diretorio onde sao salvas as notas para impressao */
        String _pastaXSD;      /* Diretorio onde ficam os arquivos .xsd para realizar validacao de xml */

        Int32 _qtdeNotasPorLotes; /* Quantidade m?xima de notas por lote   */
        Int32 _tempoParaLote;     /* Tempo de espera de fechamento de lote */
        Int32 _tamMaximoLoteKB;   /* Tamanho M?ximo em KyloBytes do Lote   */
        Delay _timeout;           /* Tempo de espera para resposta do WS   */

        String _prxUrl;         /* informa??es referentes ao proxy */
        String _prxUsr;
        String _prxPsw;
        String _prxDmn;
        Boolean _prx;  
        
        String _empresa;
        String _certificado;

        Boolean _usaWService;

        public String prxUrl
        {
            get { return _prxUrl; }
            set { SetIfChanged(ref _prxUrl, value); }
        }
        public String prxUsr
        {
            get { return _prxUsr; }
            set { SetIfChanged(ref _prxUsr, value); }
        }
        public String prxPsw
        {
            get { return _prxPsw; }
            set { SetIfChanged(ref _prxPsw, value); }
        }
        public String prxDmn
        {
            get { return _prxDmn; }
            set { SetIfChanged(ref _prxDmn, value); }
        }


        public RDI.NFe2.SchemaXML.TCodUfIBGE UF
        {
            get { return _UF; }
            set { if (_UF != value) { _UF = value; isModified = true; }; }
        }
        public RDI.NFe2.SchemaXML.TAmb tipoAmbiente
        {
            get { return _tipoAmbiente; }
            set { if (_tipoAmbiente != value) { _tipoAmbiente = value; isModified = true; }; }
        }
        public RDI.NFe2.SchemaXML.TNFeInfNFeIdeTpEmis tipoEmissao
        {
            get { return _tipoEmissao; }
            set { if (_tipoEmissao != value) { _tipoEmissao = value; isModified = true; }; }
        }
        public Boolean prx
        {
            get { return _prx; }
            set { SetIfChanged(ref _prx, value); }
        }
        public String pastaEntrada
        {
            get { return _pastaEntrada; }
            set { SetIfChanged(ref _pastaEntrada, value); }
        }
        public String pastaSaida
        {
            get { return _pastaSaida; }
            set { SetIfChanged(ref _pastaSaida, value); }
        }
        public String pastaRecibo
        {
            get { return _pastaRecibo; }
            set { SetIfChanged(ref _pastaRecibo, value); }
        }
        public String pastaImpressao
        {
            get { return _pastaImpressao; }
            set { SetIfChanged(ref _pastaImpressao, value); }
        }
        public String pastaXSD
        {
            get { return _pastaXSD; }
            set { SetIfChanged(ref _pastaXSD, value); }
        }
        public Int32 qtdeNotasPorLotes
        {
            get { return _qtdeNotasPorLotes; }
            set { SetIfChanged(ref _qtdeNotasPorLotes, value); }
        }
        public Int32 tempoParaLote
        {
            get { return _tempoParaLote; }
            set { SetIfChanged(ref _tempoParaLote, value); }
        }
        public Int32 tamMaximoLoteKB
        {
            get { return _tamMaximoLoteKB; }
            set { SetIfChanged(ref _tamMaximoLoteKB, value); }
        }
        public Delay timeout
        {
            get { return _timeout; }
            set { if (_timeout != value) { _timeout = value; isModified = true; }; }
        }
        public String empresa
        {
            get { return _empresa; }
            set { SetIfChanged( ref _empresa , value); }
        }

        public String certificado
        {
            get { return _certificado; }
            set { SetIfChanged( ref _certificado , value); }
        }

        public Boolean usaWService
        {
            get { return _usaWService; }
            set { SetIfChanged(ref _usaWService, value); }
        }

        public override DALObject GetDAL()
        {
            return ParametroDAL.Instance;
        }
        public override string GetKeyString()
        {
            return String.Format("{0}", empresa);
        }
        public override void SetKey(string keyString)
        {
            throw new Exception("The method or operation is not implemented.");
        }
        public override string GetObjectDescription()
        {
            throw new Exception("The method or operation is not implemented.");
        }


    }

    public class ParametroDAL : DALObject
    {
        static private ParametroDAL _instance;
        static public ParametroDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ParametroDAL();
                return _instance;
            }
        }
        protected override void CreateInsertParameters(BusinessObject businessObject, System.Data.IDbCommand cmd)
        {
            Parametro param = (Parametro)businessObject;

            CreateKeyParameters(businessObject, cmd);
            DALObject.CreateParameter(cmd, "@TipoOperacao", System.Data.DbType.Int32, param.tipoAmbiente);
            DALObject.CreateParameter(cmd, "@ModoOperacao", System.Data.DbType.Int32, param.tipoEmissao);
            
            DALObject.CreateParameter(cmd, "@UnidadeFederativa", System.Data.DbType.Int32, param.UF);

            DALObject.CreateParameter(cmd, "@QtdeNFLote", System.Data.DbType.Int32, param.qtdeNotasPorLotes);
            DALObject.CreateParameter(cmd, "@TempoFechaLote", System.Data.DbType.Int32, param.tempoParaLote);
            DALObject.CreateParameter(cmd, "@TamanhoLote", System.Data.DbType.Int32, param.tamMaximoLoteKB);

            DALObject.CreateParameter(cmd, "@DiretorioRecibo", System.Data.DbType.String, param.pastaRecibo);
            DALObject.CreateParameter(cmd, "@DiretorioEntrada", System.Data.DbType.String, param.pastaEntrada);
            DALObject.CreateParameter(cmd, "@DiretorioSaida", System.Data.DbType.String, param.pastaSaida);
            DALObject.CreateParameter(cmd, "@DiretorioImpressao", System.Data.DbType.String, param.pastaImpressao);
            DALObject.CreateParameter(cmd, "@DiretorioXSD", System.Data.DbType.String, param.pastaXSD);

            DALObject.CreateParameter(cmd, "@UsaProxy",    System.Data.DbType.Boolean, param.prx);
            DALObject.CreateParameter(cmd, "@DominioProxy", System.Data.DbType.String, param.prxDmn);
            DALObject.CreateParameter(cmd, "@SenhaProxy", System.Data.DbType.String, param.prxPsw);
            DALObject.CreateParameter(cmd, "@UrlProxy", System.Data.DbType.String, param.prxUrl);
            DALObject.CreateParameter(cmd, "@UsuarioProxy", System.Data.DbType.String, param.prxUsr);

            DALObject.CreateParameter(cmd, "@TimeOut", System.Data.DbType.String, param.timeout);
            DALObject.CreateParameter(cmd, "@NomeCertificado", System.Data.DbType.String, param.certificado);
            DALObject.CreateParameter(cmd, "@WService", System.Data.DbType.Boolean, param.usaWService);

        }
        protected override void CreateKeyParameters(BusinessObject businessObject, System.Data.IDbCommand cmd)
        {
            Parametro param = (Parametro)businessObject;
            DALObject.CreateParameter(cmd, "@CNPJ", System.Data.DbType.String, param.empresa);
        }
        protected override void CreateUpdateParameters(BusinessObject businessObject, System.Data.IDbCommand cmd)
        {
            Parametro param = (Parametro)businessObject;

            CreateKeyParameters(businessObject, cmd);
            DALObject.CreateParameter(cmd, "@TipoOperacao", System.Data.DbType.Int32, param.tipoAmbiente);
            DALObject.CreateParameter(cmd, "@ModoOperacao", System.Data.DbType.Int32, param.tipoEmissao);
            DALObject.CreateParameter(cmd, "@UnidadeFederativa", System.Data.DbType.Int32, param.UF);

            DALObject.CreateParameter(cmd, "@QtdeNFLote", System.Data.DbType.Int32, param.qtdeNotasPorLotes);
            DALObject.CreateParameter(cmd, "@TempoFechaLote", System.Data.DbType.Int32, param.tempoParaLote);
            DALObject.CreateParameter(cmd, "@TamanhoLote", System.Data.DbType.Int32, param.tamMaximoLoteKB);

            DALObject.CreateParameter(cmd, "@DiretorioRecibo", System.Data.DbType.String, param.pastaRecibo);
            DALObject.CreateParameter(cmd, "@DiretorioEntrada", System.Data.DbType.String, param.pastaEntrada);
            DALObject.CreateParameter(cmd, "@DiretorioSaida", System.Data.DbType.String, param.pastaSaida);
            DALObject.CreateParameter(cmd, "@DiretorioImpressao", System.Data.DbType.String, param.pastaImpressao);
            DALObject.CreateParameter(cmd, "@DiretorioXSD", System.Data.DbType.String, param.pastaXSD);

            DALObject.CreateParameter(cmd, "@UsaProxy", System.Data.DbType.Boolean, param.prx);
            DALObject.CreateParameter(cmd, "@DominioProxy", System.Data.DbType.String, param.prxDmn);
            DALObject.CreateParameter(cmd, "@SenhaProxy", System.Data.DbType.String, param.prxPsw);
            DALObject.CreateParameter(cmd, "@UrlProxy", System.Data.DbType.String, param.prxUrl);
            DALObject.CreateParameter(cmd, "@UsuarioProxy", System.Data.DbType.String, param.prxUsr);

            DALObject.CreateParameter(cmd, "@TimeOut", System.Data.DbType.Int32, param.timeout);
            DALObject.CreateParameter(cmd, "@NomeCertificado", System.Data.DbType.String, param.certificado);
            DALObject.CreateParameter(cmd, "@WService", System.Data.DbType.Boolean, param.usaWService);
        }
        protected override void DataReaderToPersistentObject(System.Data.IDataReader dataReader, BusinessObject businessObject, string radical)
        {
            Parametro param = (Parametro)businessObject;
            param.BeginInit();
            try
            {
                param.tipoAmbiente = (NFe2.SchemaXML.TAmb)Utils.FieldAsInt32(dataReader, "TipoOperacao");
                param.tipoEmissao = (NFe2.SchemaXML.TNFeInfNFeIdeTpEmis)Utils.FieldAsInt32(dataReader, "ModoOperacao");
                param.UF = (NFe2.SchemaXML.TCodUfIBGE)Utils.FieldAsInt32(dataReader, "UnidadeFederativa");
                param.timeout = (Delay)Utils.FieldAsInt32(dataReader, "TimeOut");

                param.empresa = Utils.FieldAsString(dataReader, "CNPJ");

                param.qtdeNotasPorLotes = Utils.FieldAsInt32(dataReader, "QtdeNFLote");
                param.tempoParaLote     = Utils.FieldAsInt32(dataReader, "TempoFechaLote");
                param.tamMaximoLoteKB   = Utils.FieldAsInt32(dataReader, "TamanhoLote");

                param.pastaRecibo  = Utils.FieldAsString(dataReader, "DiretorioRecibo");
                param.pastaEntrada = Utils.FieldAsString(dataReader, "DiretorioEntrada");
                param.pastaSaida   = Utils.FieldAsString(dataReader, "DiretorioSaida");
                param.pastaImpressao = Utils.FieldAsString(dataReader, "DiretorioImpressao");
                param.pastaXSD = Utils.FieldAsString(dataReader, "DiretorioXSD");

                param.prx = Utils.FieldAsBoolean(dataReader, "UsaProxy");
                param.prxDmn = Utils.FieldAsString(dataReader, "DominioProxy");
                param.prxPsw = Utils.FieldAsString(dataReader, "SenhaProxy");
                param.prxUrl = Utils.FieldAsString(dataReader, "UrlProxy");
                param.prxUsr = Utils.FieldAsString(dataReader, "UsuarioProxy");
                param.certificado = Utils.FieldAsString(dataReader, "NomeCertificado");
                param.usaWService = Utils.FieldAsBoolean(dataReader, "WService");

                param.isRecorded = true;
                param.isModified = false;
            }
            finally
            {
                param.EndInit();
            }

        }
        protected override Type GetCollectorType()
        {
            return typeof(ParametroQRY);
        }
        protected override Type GetPersistentObjectType()
        {
            return typeof(Parametro);
        }
        protected override string GetInsertStatement()
        {
            /*return @"INSERT INTO Parametros 
                               (ModoOperacao, TipoOperacao, UnidadeFederativa, QtdeNFLote, TempoFechaLote, 
                                UsaProxy, DominioProxy, SenhaProxy, UrlProxy, UsuarioProxy, TimeOut, CNPJ, 
                                TamanhoLote, DiretorioRecibo, DiretorioEntrada, DiretorioSaida, DiretorioImpressao, DiretorioXSD,                                            NomeCertificado)
                     VALUES
                               (@ModoOperacao, @TipoOperacao, @UnidadeFederativa, @QtdeNFLote, @TempoFechaLote, 
                                @UsaProxy, @DominioProxy, @SenhaProxy, @UrlProxy, @UsuarioProxy, @TimeOut, @CNPJ,
                                @TamanhoLote, @DiretorioRecibo, @DiretorioEntrada, @DiretorioSaida, @DiretorioImpressao, @DiretorioXSD,                                      @NomeCertificado)";  */
            throw new Exception("Esse Registro n?o pode ser Inclu?do.");

        }
        protected override string GetUpdateStatement()
        {
            return @"UPDATE Parametros
                        SET ModoOperacao = @ModoOperacao, 
                            TipoOperacao = @TipoOperacao, 
                            UnidadeFederativa     = @UnidadeFederativa, 
                            QtdeNFLote = @QtdeNFLote, 
                            TempoFechaLote = @TempoFechaLote,                              
                            TamanhoLote = @TamanhoLote, 
                            DiretorioRecibo = @DiretorioRecibo, 
                            DiretorioEntrada = @DiretorioEntrada, 
                            DiretorioSaida = @DiretorioSaida,
                            DiretorioImpressao = @DiretorioImpressao,
                            DiretorioXSD = @DiretorioXSD,
                            UsaProxy    = @UsaProxy, 
                            DominioProxy = @DominioProxy, 
                            SenhaProxy = @SenhaProxy, 
                            UrlProxy = @UrlProxy, 
                            UsuarioProxy = @UsuarioProxy, 
                            TimeOut = @TimeOut, 
                            NomeCertificado = @NomeCertificado,
                            WService = @WService
                        WHERE CNPJ = @CNPJ
                      --<where i>--";

        }
        protected override string GetDeleteStatement()
        {
            throw new Exception("Esse Registro n?o pode ser Exclu?do.");
        }
        protected override string GetSelectStatement()
        {
            return @"SELECT ModoOperacao, TipoOperacao, UnidadeFederativa, QtdeNFLote, TempoFechaLote, 
                            TamanhoLote, DiretorioRecibo, DiretorioEntrada, DiretorioSaida, DiretorioImpressao, DiretorioXSD,
                            UsaProxy, DominioProxy, SenhaProxy, UrlProxy, UsuarioProxy,
                            TimeOut, CNPJ, NomeCertificado, WService
                       FROM Parametros
                      --<where auto>--";
        }
        protected override string GetEntityName()
        {
            return "Parametros";
        }
    }

    public class ParametroQRY : QueryObject
    {
        public ParametroQRY() : base(System.String.Empty) { }
        private String _empresa; //implementar multi empresa
        public String empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }

        public override void CreateParameters(System.Data.IDbCommand cmd)
        {
            if (empresa != null)
                DALObject.CreateParameter(cmd, "@CNPJ", System.Data.DbType.String, empresa);

        }
        public override void ModifySQL(SQLUtils handler)
        {
            if (empresa != null)
                handler.handleSQLAppendWhere(prefix + "CNPJ = @CNPJ");
        }
        public override void SetKey(BusinessObject businessObject)
        {
            Parametro param = (Parametro)businessObject;
            empresa = param.empresa; 
        }
        public override void SetKey(string keyString)
        {
            empresa = keyString.Split('|')[0];
        }
    }
}
