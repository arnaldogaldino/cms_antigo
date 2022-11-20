using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using RDI.Lince;


namespace RDI.NFe2.Business
{
    public class NotaFiscal : BusinessObject
    {
        private String _chaveNota;
        private Int32 _numeroLote;
        private Int32 _codigoSituacao;
        private String _descricaoSituacao;
        private DateTime _dataSituacao;
        
        private String _empresa;
        private String _cStat;
        private String _xMotivo;

        private String _xmlNota;
        private String _xmlProcesso;
        private String _nProt;

        private String _xmlPedidoCancelamento;
        private String _xmlProcessoCancelamento;
        private String _nProtCancelamento;


        public String cStat
        {
            get { return _cStat; }
            set { SetIfChanged(ref _cStat, value); }
        }
        public String xMotivo
        {
            get { return _xMotivo; }
            set { SetIfChanged(ref _xMotivo, value); }
        }
        

        public String empresa
        {
            get { return _empresa; }
            set { SetIfChanged(ref _empresa, value); }
        }
        
        public String chaveNota
        {
            get { return _chaveNota; }
            set { SetIfChanged(ref _chaveNota, value); }
        }
        public Int32 numeroLote
        {
            get { return _numeroLote; }
            set { SetIfChanged(ref _numeroLote, value); }
        }
        public Int32 codigoSituacao
        {
            get { return _codigoSituacao; }
            set { SetIfChanged(ref _codigoSituacao, value); }
        }
        public String descricaoSituacao
        {
            get { return _descricaoSituacao; }
            set { SetIfChanged(ref _descricaoSituacao, value); }
        }
        public DateTime dataSituacao
        {
            get { return _dataSituacao; }
            set { SetIfChanged(ref _dataSituacao, value); }
        }
        public String xmlNota
        {
            get { return _xmlNota; }
            set { SetIfChanged(ref _xmlNota, value); }
        }
        public String xmlProcesso
        {
            get { return _xmlProcesso; }
            set { SetIfChanged(ref _xmlProcesso, value); }
        }
        public String nProt
        {
            get { return _nProt; }
            set { SetIfChanged(ref _nProt, value); }
        }

        public String xmlPedidoCancelamento
        {
            get { return _xmlPedidoCancelamento; }
            set { SetIfChanged(ref _xmlPedidoCancelamento, value); }
        }
        public String xmlProcessoCancelamento
        {
            get { return _xmlProcessoCancelamento; }
            set { SetIfChanged(ref _xmlProcessoCancelamento, value); }
        }
        public String nProtCancelamento
        {
            get { return _nProtCancelamento; }
            set { SetIfChanged(ref _nProtCancelamento, value); }
        }

        public override DALObject GetDAL()
        {
            return NotaFiscalDAL.Instance;
        }

        public override string GetKeyString()
        {
            return String.Format("{0}|{1}|{2}", empresa, chaveNota, numeroLote);
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

    public class NotaFiscalDAL : DALObject
    {
        static private NotaFiscalDAL _instance;
        static public NotaFiscalDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new NotaFiscalDAL();
                return _instance;
            }
        }
        protected override void CreateInsertParameters(BusinessObject businessObject, System.Data.IDbCommand cmd)
        {
            NotaFiscal nota = (NotaFiscal)businessObject;

            CreateKeyParameters(businessObject, cmd);
            DALObject.CreateParameter(cmd, "@CodigoSituacao", System.Data.DbType.Int32, nota.codigoSituacao);
            DALObject.CreateParameter(cmd, "@DescricaoSituacao", System.Data.DbType.String, nota.descricaoSituacao);
            DALObject.CreateParameter(cmd, "@DataSituacao", System.Data.DbType.DateTime, nota.dataSituacao);
            DALObject.CreateParameter(cmd, "@XMLNotaFiscal", System.Data.DbType.String, nota.xmlNota);
            DALObject.CreateParameter(cmd, "@XMLProcesso", System.Data.DbType.String, nota.xmlProcesso);
            DALObject.CreateParameter(cmd, "@cStat", System.Data.DbType.String, nota.cStat);
            DALObject.CreateParameter(cmd, "@xMotivo", System.Data.DbType.String, nota.xMotivo);
            DALObject.CreateParameter(cmd, "@nProt", System.Data.DbType.String, nota.nProt);
            DALObject.CreateParameter(cmd, "@xmlPedidoCancelamento", System.Data.DbType.String, nota.xmlPedidoCancelamento);
            DALObject.CreateParameter(cmd, "@xmlProcessoCancelamento", System.Data.DbType.String, nota.xmlProcessoCancelamento);
            DALObject.CreateParameter(cmd, "@nProtCancelamento", System.Data.DbType.String, nota.nProtCancelamento);
        }

        protected override void CreateKeyParameters(BusinessObject businessObject, System.Data.IDbCommand cmd)
        {
            NotaFiscal nota = (NotaFiscal)businessObject;
            DALObject.CreateParameter(cmd, "@CNPJ", System.Data.DbType.String, nota.empresa);
            DALObject.CreateParameter(cmd, "@ChaveNota", System.Data.DbType.String, nota.chaveNota);
            DALObject.CreateParameter(cmd, "@NumeroLote", System.Data.DbType.Int32, nota.numeroLote);

        }
        protected override void CreateUpdateParameters(BusinessObject businessObject, System.Data.IDbCommand cmd)
        {
            NotaFiscal nota = (NotaFiscal)businessObject;

            CreateKeyParameters(businessObject, cmd);
            DALObject.CreateParameter(cmd, "@CodigoSituacao", System.Data.DbType.Int32, nota.codigoSituacao);
            DALObject.CreateParameter(cmd, "@DescricaoSituacao", System.Data.DbType.String, nota.descricaoSituacao);
            DALObject.CreateParameter(cmd, "@DataSituacao", System.Data.DbType.DateTime, nota.dataSituacao);
            DALObject.CreateParameter(cmd, "@XMLNotaFiscal", System.Data.DbType.String, nota.xmlNota);
            DALObject.CreateParameter(cmd, "@XMLProcesso", System.Data.DbType.String, nota.xmlProcesso);
            DALObject.CreateParameter(cmd, "@cStat", System.Data.DbType.String, nota.cStat);
            DALObject.CreateParameter(cmd, "@xMotivo", System.Data.DbType.String, nota.xMotivo);
            DALObject.CreateParameter(cmd, "@nProt", System.Data.DbType.String, nota.nProt);
            DALObject.CreateParameter(cmd, "@xmlPedidoCancelamento", System.Data.DbType.String, nota.xmlPedidoCancelamento);
            DALObject.CreateParameter(cmd, "@xmlProcessoCancelamento", System.Data.DbType.String, nota.xmlProcessoCancelamento);
            DALObject.CreateParameter(cmd, "@nProtCancelamento", System.Data.DbType.String, nota.nProtCancelamento);
        }
        protected override void DataReaderToPersistentObject(System.Data.IDataReader dataReader, BusinessObject businessObject, string radical)
        {
            NotaFiscal nota = (NotaFiscal)businessObject;
            nota.BeginInit();
            try
            {
                nota.empresa = Utils.FieldAsString(dataReader, "CNPJ");
                nota.chaveNota = Utils.FieldAsString(dataReader, "ChaveNota");
                nota.numeroLote = Utils.FieldAsInt32(dataReader, "NumeroLote");
                nota.codigoSituacao = Utils.FieldAsInt32(dataReader, "CodigoSituacao");
                nota.descricaoSituacao = Utils.FieldAsString(dataReader, "DescricaoSituacao");
                nota.dataSituacao = Utils.FieldAsDateTime(dataReader, "DataSituacao");
                nota.xmlNota = Utils.FieldAsString(dataReader, "XMLNotaFiscal");
                nota.xmlProcesso = Utils.FieldAsString(dataReader, "XMLProcesso");
                nota.cStat = Utils.FieldAsString(dataReader, "cStat");
                nota.xMotivo = Utils.FieldAsString(dataReader, "xMotivo");
                nota.nProt = Utils.FieldAsString(dataReader, "nProt");

                nota.xmlPedidoCancelamento = Utils.FieldAsString(dataReader, "xmlPedidoCancelamento");
                nota.xmlProcessoCancelamento = Utils.FieldAsString(dataReader, "xmlProcessoCancelamento");
                nota.nProtCancelamento = Utils.FieldAsString(dataReader, "nProtCancelamento");

                nota.isRecorded = true;
                nota.isModified = false;
            }
            finally
            {
                nota.EndInit();
            }

        }
        protected override Type GetCollectorType()
        {
            return typeof(NotaFiscalQry);
        }
        protected override Type GetPersistentObjectType()
        {
            return typeof(NotaFiscal);
        }
        protected override string GetInsertStatement()
        {
            return @"INSERT INTO NotasFiscais(NumeroLote, ChaveNota, CodigoSituacao, DescricaoSituacao, DataSituacao, XMLNotaFiscal,
                                              XMLProcesso, CNPJ, cStat, xMotivo, nProt, xmlPedidoCancelamento, xmlProcessoCancelamento, nProtCancelamento)
                          VALUES(@NumeroLote, @ChaveNota, @CodigoSituacao, @DescricaoSituacao, @DataSituacao, @XMLNotaFiscal, 
                                 @XMLProcesso, @CNPJ, @cStat, @xMotivo, @nProt, @xmlPedidoCancelamento, @xmlProcessoCancelamento, @nProtCancelamento)";
        }
        protected override string GetUpdateStatement()
        {
            return @"UPDATE NotasFiscais
                        SET CodigoSituacao = @CodigoSituacao,
                            DescricaoSituacao = @DescricaoSituacao,
                            DataSituacao = @DataSituacao,
                            XMLNotaFiscal = @XMLNotaFiscal,
                            XMLProcesso = @XMLProcesso,
                            cStat = @cStat, 
                            xMotivo = @xMotivo, 
                            nProt = @nProt,
                            xmlPedidoCancelamento = @xmlPedidoCancelamento,
                            xmlProcessoCancelamento = @xmlProcessoCancelamento,
                            nProtCancelamento = @nProtCancelamento
                      WHERE NumeroLote = @NumeroLote
                        AND ChaveNota = @ChaveNota
                        AND CNPJ = @CNPJ";

        }
        protected override string GetDeleteStatement()
        {
            throw new Exception("Esse Registro não pode ser Excluído.");
        }
        protected override string GetSelectStatement()
        {
            return @"SELECT NumeroLote, ChaveNota, CodigoSituacao, DescricaoSituacao, DataSituacao, 
                            XMLNotaFiscal, XMLProcesso, CNPJ, cStat, xMotivo, nProt, xmlPedidoCancelamento, 
                            xmlProcessoCancelamento, nProtCancelamento
                       FROM NotasFiscais
                        --<where auto>--
                        --<orderby>--";
        }
        protected override string GetEntityName()
        {
            return "NotasFiscais";
        }

        protected string GetMaxSelect()
        {
            return @"SELECT isnull (max(NumeroLote),0) as NumeroLote
                       FROM NotasFiscais
                        --<where auto>--";
        }
        public Int32 GetMax(QueryObject queryobject, ClientEnvironment clientEnvironment)
        {
            System.Data.IDbCommand cmd = clientEnvironment.connection.CreateCommand();

            cmd.Parameters.Clear();
            cmd.CommandText = GetMaxSelect();

            if (clientEnvironment.transaction != null) cmd.Transaction = clientEnvironment.transaction;

            return (Int32)cmd.ExecuteScalar() + 1;
        }
 
 
    }

    public class NotaFiscalQry : QueryObject
    {
        public NotaFiscalQry() : base(System.String.Empty) { }
        private String _chaveNota;
        private String _numeroLote;
        private String _codigoSituacao;
        private DateTime _dataInicial;
        private DateTime _dataFinal;
        public Boolean FilterByDate = false;

        private String _empresa;

        public String chaveNota
        {
            get { return _chaveNota; }
            set { _chaveNota = value; }
        }
        public String numeroLote
        {
            get { return _numeroLote; }
            set { _numeroLote = value; }
        }
        public String codigoSituacao
        {
            get { return _codigoSituacao; }
            set { _codigoSituacao = value; }
        }
        public DateTime dataInicial
        {
            get { return _dataInicial; }
            set { _dataInicial = value; }
        }
        public DateTime dataFinal
        {
            get { return _dataFinal; }
            set { _dataFinal = value; }
        }

        public String empresa
        {
            get { return _empresa; }
            set { _empresa = value; }
        }
        public override void CreateParameters(System.Data.IDbCommand cmd)
        {
            if (chaveNota != null)
                DALObject.CreateParameter(cmd, "@ChaveNota", System.Data.DbType.String, "%"+chaveNota+"%");
            if (numeroLote != null)
                DALObject.CreateParameter(cmd, "@NumeroLote", System.Data.DbType.Int32, numeroLote);
            if (codigoSituacao != null)
                DALObject.CreateParameter(cmd, "@CodigoSituacao", System.Data.DbType.Int32, codigoSituacao);
            if (FilterByDate)
            {
                if (dataInicial.ToShortDateString() != "01/01/0001")
                    DALObject.CreateParameter(cmd, "@dataInicial", System.Data.DbType.DateTime, dataInicial);
                if (dataFinal.ToShortDateString() != "01/01/0001")
                    DALObject.CreateParameter(cmd, "@dataFinal", System.Data.DbType.DateTime,
                        dataFinal.AddHours(23).AddMinutes(59).AddSeconds(59).AddMilliseconds(999));
            }
            if (empresa != null)
                DALObject.CreateParameter(cmd, "@CNPJ", System.Data.DbType.String, empresa);
        }
        public override void ModifySQL(SQLUtils handler)
        {
            if (chaveNota != null)
                handler.handleSQLAppendWhere(prefix + "ChaveNota like @ChaveNota");
            if (numeroLote != null)
                handler.handleSQLAppendWhere(prefix + "NumeroLote = @NumeroLote");
            if (codigoSituacao != null)
                handler.handleSQLAppendWhere(prefix + "CodigoSituacao = @CodigoSituacao");
            if (empresa != null)
                handler.handleSQLAppendWhere(prefix + "CNPJ = @CNPJ");

            if (FilterByDate)
            {
                if (dataInicial.ToShortDateString() != "01/01/0001")
                    handler.handleSQLAppendWhere(prefix + "DataSituacao >= @dataInicial");
                if (dataFinal.ToShortDateString() != "01/01/0001")
                    handler.handleSQLAppendWhere(prefix + "DataSituacao <= @dataFinal");
                handler.handleSQLAppendOrderBy("order by DataSituacao");
            }
        }
        public override void SetKey(BusinessObject businessObject)
        {
            NotaFiscal nota = (NotaFiscal)businessObject;
            chaveNota = nota.chaveNota;
            numeroLote = nota.numeroLote.ToString();
            empresa = nota.empresa;
        }
        public override void SetKey(string keyString)
        {
            empresa = keyString.Split('|')[0];
            chaveNota = keyString.Split('|')[1];
            numeroLote = keyString.Split('|')[2];
        }
    }
}
