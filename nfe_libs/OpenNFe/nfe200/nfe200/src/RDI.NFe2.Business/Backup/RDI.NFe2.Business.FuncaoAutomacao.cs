using System;
using System.IO;
using System.Collections;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;
using RDI.Lince;
using System.Xml;


namespace RDI.NFe2.Business
{
    
    public class FuncaoAutomacao
    {
        Boolean connectionOk;
        DateTime dateOfLastConnection;
        Int32 tryNumber;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oGlobalManager">deverá receber uma conexao já aberta e quem o chamou deverá fecha-la</param>
        public FuncaoAutomacao(string empresa, ClientEnvironment oGlobalManager)
        {
           
            _empresa = empresa;
            manager = oGlobalManager;
            if (manager == null || manager.connection == null || manager.connection.State == System.Data.ConnectionState.Closed)
                throw new Exception("A conexão não esta aberta");

            connectionOk = ConsultaStatus();
            dateOfLastConnection = DateTime.Now;
            tryNumber = 0;
        }

        
        private string _empresa;
        private ClientEnvironment _globalManager;

        public ClientEnvironment manager
        {
            get { return _globalManager; }
            set { _globalManager = value; }
        }

        public Parametro oParam
        {
            get 
            { //todo : rever performance, isso fara como que os parametros sejam sempre atualizados
                ParametroQRY col = new ParametroQRY();
                col.empresa = _empresa;
                return (Parametro)ParametroDAL.Instance.GetInstances(col, manager)[0];
            }
            
        }

        private ArrayList ListaDeNotas;
        
             
        private void MontaListaNFeXml()
        {
            DirectoryInfo dir = null;
            ListaDeNotas = new ArrayList();
            if (!Directory.Exists(oParam.pastaEntrada))
            {
                dir = Directory.CreateDirectory(oParam.pastaEntrada);
            }
            else
            {
                dir = new DirectoryInfo(oParam.pastaEntrada);
            }

            if (dir != null)
            {
                foreach (FileInfo fileName in dir.GetFiles("NFe*.xml"))
                    ListaDeNotas.Add(fileName.Name);
            }
        }
        
      
       
        private long GetFileSize(string FileName)
        {
            FileInfo info = new FileInfo(FileName);

            if (!info.Exists)
                return -1;
            else
                return info.Length;
        }

        public void DoOnLoop(Boolean canLog, String FileName)
        {
            int delay = 180;

            if (connectionOk)
            {
                DoStep(canLog, FileName);
            }
            else
            {
                if (DateTime.Now.Subtract(dateOfLastConnection).TotalSeconds > delay)
                {
                    dateOfLastConnection = DateTime.Now;
                    connectionOk = ConsultaStatus(); 
                    tryNumber++;

                    //todo : aumentar o delay de acordo com o numero de tentativas

                    CriaLog(996, "Tentativa " + tryNumber.ToString() + ". A conexão com a SEFAZ esta indisponivel. Nova consulta em " + delay.ToString() + " segundos.");
                }
            }

        }

        private void DoStep(Boolean canLog, String FileName)
        {
            try
            {
                MontaListaNFeXml();

               
                //-------------------------------Monta lote------------------------------------//
                if ((((DateTime.Now.Minute * 60 + DateTime.Now.Second) % oParam.tempoParaLote == 0) ||
                       (ListaDeNotas.Count >= oParam.qtdeNotasPorLotes)) && (ListaDeNotas.Count != 0))
                {
                    if (ListaDeNotas.Count > oParam.qtdeNotasPorLotes)
                        CriaEnvelope(oParam.qtdeNotasPorLotes);
                    else
                        CriaEnvelope(ListaDeNotas.Count);

                }
                //-------------------------------Monta lote------------------------------------//

                //-------------------------------Envia lote------------------------------------//
                //if ((DateTime.Now.Minute * 60 + DateTime.Now.Second) % 12 == 0)
                {
                    //buscar os servicos pendentes
                    ServicoPendenteQry oSrvQry = new ServicoPendenteQry();
                    oSrvQry.codigoSituacao = ((sbyte)TipoSituacaoServico.Assinado).ToString();
                    oSrvQry.empresa = oParam.empresa;

                    ArrayList servicos = ServicoPendenteDAL.Instance.GetInstances(oSrvQry, manager);
                    foreach (ServicoPendente oServicoPendente in servicos)
                    {
                        EnviaEnvelope(oServicoPendente);
                    }
                    
                }//if envio de lotes
                //-------------------------------Envia lote------------------------------------//

                //-----------------------------ConsultaEnvelopes-------------------------------//
                //if ((DateTime.Now.Minute * 60 + DateTime.Now.Second) % 13 == 0)
                {
                    //buscar os servicos pendentes
                    ServicoPendenteQry oSrvQry = new ServicoPendenteQry();
                    oSrvQry.codigoSituacao = ((sbyte)TipoSituacaoServico.Enviado).ToString();
                    oSrvQry.empresa = oParam.empresa;

                    ArrayList servicos = ServicoPendenteDAL.Instance.GetInstances(oSrvQry, manager);
                    foreach (ServicoPendente oServicoPendente in servicos)
                    {
                        if (DateTime.Now.Subtract(oServicoPendente.dataSituacao).TotalSeconds > 15) //aguardar pelo menos 3 segundos
                        {
                            ConsultaEnvelope(oServicoPendente);
                        }
                    }
                    
                }//if consulta envelope
                //----------------------------ConsultaEnvelopes--------------------------------//

                //-------------------------------ImprimeDANFe----------------------------------//
                //if ((DateTime.Now.Minute * 60 + DateTime.Now.Second) % 15 == 0)
                {
                    ServicoPendenteQry oSrvQry = new ServicoPendenteQry();
                    oSrvQry.codigoSituacao = ((sbyte)TipoSituacaoServico.Processado).ToString();
                    oSrvQry.empresa = oParam.empresa;

                    ArrayList servicos = ServicoPendenteDAL.Instance.GetInstances(oSrvQry, manager);
                    foreach (ServicoPendente oServicoPendente in servicos)
                    {
                        FinalizaServicos(oServicoPendente);
                    }
                    
                    
                }//if imprime nota
                //-------------------------------ImprimeDANFe----------------------------------//


            }
            catch(Exception ex)
            {
                CriaLog(999, ex.Message);
            }
        }

        /// <summary>
        /// versao 2.0 - ok
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="situacao"></param>
        /// <param name="chave"></param>
        private void CriaLog(int codigo, string situacao, string chave)
        {
            Log oLog = new Log();

            oLog.codigoSituacao = codigo;
            //depois de alterado o tamanho no banco.
            //será varchar max
            //if (situacao.Length < 255)
            oLog.descricaoSituacao = situacao;
            //else
            //    oLog.descricaoSituacao = situacao.Substring(0, 255);

            oLog.nota = new NotaFiscal();
            oLog.nota.chaveNota = chave;
            oLog.data = DateTime.Now;
            oLog.empresa = oParam.empresa;
            oLog.Save(manager);

        }

        /// <summary>
        /// versão 2.0 - ok
        /// </summary>
        /// <param name="codigo"></param>
        /// <param name="situacao"></param>
        public void CriaLog(int codigo, string situacao)
        {
            CriaLog(codigo, situacao, System.String.Empty);
        }

        /// <summary>
        /// versao 2.0 - ok
        /// </summary>
        /// <param name="NFeStr"></param>
        /// <param name="CodigoDoResultado"></param>
        /// <param name="DescricaoDoResultado"></param>
        private void AssinaNota(string NFeStr, ref int CodigoDoResultado, ref string DescricaoDoResultado)
        {
            string erros;

            try
            {
                X509Certificate2 cert = Certificado.BuscaNome(oParam.certificado, oParam.usaWService);

                CodigoDoResultado = NFeUtils.AssinaXML(oParam.pastaEntrada + NFeStr, "infNFe", cert);

                cert = null;

                //so validar nota assinada
                if (CodigoDoResultado == 0)
                {
                    erros = NFeUtils.ValidacaoXML(oParam.pastaEntrada + "ass" + NFeStr,
                                                  oParam.pastaXSD + "nfe_v" + oParam.versaoDados + ".xsd");

                    if (erros == "NotFound")
                    {
                        CodigoDoResultado = 10;
                        DescricaoDoResultado = "Arquivo não encontrado - Validação";
                        //TODO : criar e testar
                    }
                    else if (erros != System.String.Empty)      //problema : xml nao validado.
                    {
                        CodigoDoResultado = 8;
                        DescricaoDoResultado = erros;
                        //Renomear o arquivo para ERRO+NFE
                        if (File.Exists(oParam.pastaEntrada + "ERRO8_" + NFeStr))
                            File.Delete(oParam.pastaEntrada + "ERRO8_" + NFeStr);
                        File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO8_" + NFeStr);
                        File.Delete(oParam.pastaEntrada + "ass" + NFeStr);
                    }
                    else if (File.Exists(oParam.pastaEntrada + "ass" + NFeStr))//ESTA TUDO OK 
                    {
                        DescricaoDoResultado = "Nota Assinada";

                        File.Delete(oParam.pastaEntrada + NFeStr);
                    }
                }
                else if (CodigoDoResultado == 1)
                {
                    DescricaoDoResultado = "Problema ao acessar certificado";
                    //Avisar para o Usuario Avancado que existe um problema no certiificado
                    if (File.Exists(oParam.pastaEntrada + "ERRO1_" + NFeStr))
                        File.Delete(oParam.pastaEntrada + "ERRO1_" + NFeStr);
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO1_" + NFeStr);
                }
                else if (CodigoDoResultado == 2)
                {
                    DescricaoDoResultado = "Problemas no certificado";
                    //Avisar para o Usuario Avancado que existe um problema no certiificado
                    if (File.Exists(oParam.pastaEntrada + "ERRO2_" + NFeStr))
                        File.Delete(oParam.pastaEntrada + "ERRO2_" + NFeStr);
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO2_" + NFeStr);
                }
                else if (CodigoDoResultado == 3)
                {
                    DescricaoDoResultado = "XML mal formado";
                    //Renomear o arquivo para ERRO+NFE
                    if (File.Exists(oParam.pastaEntrada + "ERRO3_" + NFeStr))
                        File.Delete(oParam.pastaEntrada + "ERRO3_" + NFeStr);
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO3_" + NFeStr);
                }
                else if (CodigoDoResultado == 4)
                {
                    DescricaoDoResultado = "A TAG de assinatura é inexistente";
                    //Renomear o arquivo para ERRO+NFE
                    if (File.Exists(oParam.pastaEntrada + "ERRO4_" + NFeStr))
                        File.Delete(oParam.pastaEntrada + "ERRO4_" + NFeStr);
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO4_" + NFeStr);
                }
                else if (CodigoDoResultado == 5)
                {
                    DescricaoDoResultado = "A TAG de assinatura não é única";
                    //Renomear o arquivo para ERRO+NFE
                    if (File.Exists(oParam.pastaEntrada + "ERRO5_" + NFeStr))
                        File.Delete(oParam.pastaEntrada + "ERRO5_" + NFeStr);
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO5_" + NFeStr);
                }
                else if (CodigoDoResultado == 6)
                {
                    DescricaoDoResultado = "Erro ao assinar o documento";
                    //Renomear o arquivo para ERRO+NFE
                    if (File.Exists(oParam.pastaEntrada + "ERRO6_" + NFeStr))
                        File.Delete(oParam.pastaEntrada + "ERRO6_" + NFeStr);
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO6_" + NFeStr);
                }
                else if (CodigoDoResultado == 7)
                {
                    DescricaoDoResultado = "Erro ao assinar o documento";

                    if (File.Exists(oParam.pastaEntrada + "ERRO7_" + NFeStr))
                        File.Delete(oParam.pastaEntrada + "ERRO7_" + NFeStr);
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO7_" + NFeStr);
                }
                else if (CodigoDoResultado == 11)
                {
                    DescricaoDoResultado = "Arquivo não encontrado - Assinatura";
                }
            }
            catch (Exception ex)
            {
                CodigoDoResultado = 9;
                DescricaoDoResultado = "Exceção - " + ex.Message;
                if (File.Exists(oParam.pastaEntrada + "ERRO9_" + NFeStr))
                    File.Delete(oParam.pastaEntrada + "ERRO9_" + NFeStr);
                if (File.Exists(oParam.pastaEntrada + NFeStr))
                    File.Move(oParam.pastaEntrada + NFeStr, oParam.pastaEntrada + "ERRO9_" + NFeStr);
            }
        }

        /// <summary>
        /// versao 2.0 - ok
        /// </summary>
        /// <param name="QtdeNFLote"></param>
        private void CriaEnvelope(int QtdeNFLote)
        {

            try
            {
                int numeroNovoLote, i, CodigoDoResultado = 0;

                ServicoPendente oServicoPendente;
                string origem, DescricaoDoResultado = "";

                //inicia lote
                bool CriarServico = false;

                #region Pegar o ultimo lote criado.
                NotaFiscalQry oNFeQry = new NotaFiscalQry();
                oNFeQry.empresa = oParam.empresa;
                numeroNovoLote = NotaFiscalDAL.Instance.GetMax(oNFeQry, manager);
                SchemaXML.TEnviNFe oEnviNFe = new RDI.NFe2.SchemaXML.TEnviNFe();
                oEnviNFe.idLote = numeroNovoLote.ToString();
                oEnviNFe.versao = "2.00";

                #endregion

                #region assinar, validar e adicionar nota ao lote
                //corre a lista de nfe's disponiveis na pasta de entrada.
                for (i = 0; i < QtdeNFLote; i++)
                {
                    origem = ListaDeNotas[i].ToString();
                    SchemaXML.TNFe oNFe = new SchemaXML.TNFe();
                    string xmlNotaStr = "";

                    try
                    {
                        //todo
                        //if (origem.Length > 51)
                        //{
                        //    File.Move(origem, "tam_" + origem);
                        //}

                        #region verificar se é possível abrir o arquivo
                        if (!File.Exists(oParam.pastaEntrada + origem))
                        {
                            CodigoDoResultado = 11;
                            DescricaoDoResultado = "Arquivo não foi localizado. : " + oParam.pastaEntrada + origem;
                            throw new Exception(DescricaoDoResultado);
                        }
                        #endregion

                        using (StreamReader SR = File.OpenText(oParam.pastaEntrada + origem))
                        {
                            xmlNotaStr = SR.ReadToEnd();
                            SR.Close();
                        }
                        GC.Collect();


                        #region verificar serializacao antes de assinar jogar na classe de NFe
                        try
                        {
                            //oNFe = (SchemaXML.TNFe)Servicos.CarregaXML_HD(oParam.pastaEntrada + origem, typeof(SchemaXML.TNFe));
                            oNFe = (SchemaXML.TNFe)Servicos.CarregaXML_STR(xmlNotaStr, typeof(SchemaXML.TNFe));
                            Servicos.SalvaXML(oParam.pastaEntrada + origem, oNFe);
                            oNFe = null;
                        }
                        catch
                        {
                            CodigoDoResultado = 3;
                            DescricaoDoResultado = "Não foi possivel Deserializar a nota no Objeto TNFe.";
                            throw new Exception(DescricaoDoResultado);
                        }
                        #endregion

                        //todo : tratar se deu erro

                        AssinaNota(origem, ref CodigoDoResultado, ref DescricaoDoResultado);

                        if (CodigoDoResultado != 0)
                        {
                            throw new Exception(DescricaoDoResultado);
                        }
                        //nota assinada e validada

                        if (!File.Exists(oParam.pastaEntrada + "ass" + origem))
                        {
                            CodigoDoResultado = 11;
                            DescricaoDoResultado = "Nota não encontrada : " + origem;
                            throw new Exception(DescricaoDoResultado);
                        }

                        #region todo : validar a chave de acesso
                        oNFe = (SchemaXML.TNFe)Servicos.CarregaXML_HD(oParam.pastaEntrada + "ass" + origem, typeof(SchemaXML.TNFe));

                        
                        //todo
                        //if (oNFe.infNFe.ide.cUF.ToString() != origem.Substring(0, 2) ||
                        //    oNFe.infNFe.ide.dEmi.Substring(2, 2) != origem.Substring(2, 2) ||
                        //    oNFe.infNFe.ide.dEmi.Substring(5, 2) != origem.Substring(4, 2) ||
                        //    oNFe.infNFe.emit.Item != origem.Substring(6, 14) ||
                        //    oNFe.infNFe.ide.mod.ToString() != origem.Substring(20, 2) ||
                        //    oNFe.infNFe.ide.serie.PadLeft(3, '0') != origem.Substring(22, 3) ||
                        //    oNFe.infNFe.ide.nNF.PadLeft(9, '0') != origem.Substring(25, 9) ||
                        //    oNFe.infNFe.ide.tpEmis.ToString() != origem.Substring(34, 1) ||
                        //    oNFe.infNFe.ide.cNF != origem.Substring(35, 8) ||
                        //    oNFe.infNFe.ide.cDV != origem.Substring(44, 1))
                        //{
                        //    CodigoDoResultado = 3;
                        //    DescricaoDoResultado = "Chave de acesso não corresponde aos valores informados no XML";
                        //    throw new Exception(DescricaoDoResultado);
                        //}
                        #endregion

                        //adiciona nota assinada no envelope

                        //if (EnvelopaNFe("ass" + origem, numeroNovoLote.ToString()) == "NotFound")
                        //{
                        //    DescricaoDoResultado = "Nota não encontrada : " + origem;
                        //    throw new Exception(DescricaoDoResultado);
                        //}
                        //else
                        //{
                        //    DescricaoDoResultado = "Nota assinada e adicionada no lote : " + numeroNovoLote.ToString();
                        //    CriarServico = true;
                        //}

                        #region todo:  envelopar nota da nova maneira


                        if (oEnviNFe.NFe == null)
                            oEnviNFe.NFe = new RDI.NFe2.SchemaXML.TNFe[0];

                        int tamanhoEnvelope = oEnviNFe.NFe.Length;

                        SchemaXML.TNFe[] listaAux = new SchemaXML.TNFe[tamanhoEnvelope];

                        listaAux = oEnviNFe.NFe;

                        oEnviNFe.NFe = new SchemaXML.TNFe[tamanhoEnvelope + 1];

                        for (int pos = 0; pos < listaAux.Length; pos++)
                        {
                            SchemaXML.TNFe oNFe4List = (SchemaXML.TNFe)listaAux[pos];

                            oEnviNFe.NFe.SetValue(oNFe4List, pos);
                        }

                        oEnviNFe.NFe.SetValue(oNFe, listaAux.Length);

                        if (oEnviNFe.NFe.Length > 0)
                        {
                            CriarServico = true;

                            //salvar o lote
                            if (File.Exists(oParam.pastaSaida + oEnviNFe.idLote + "-env-lot.xml"))
                                File.Delete(oParam.pastaSaida + oEnviNFe.idLote + "-env-lot.xml");

                            Servicos.SalvaXML(oParam.pastaSaida + oEnviNFe.idLote + "-env-lot.xml", oEnviNFe);
                        }
                        

                        //#region testar tamanho do lote

                        ////salvar um lote temporario
                        //Servicos.SalvaXML(oParam.pastaRecibo + numeroNovoLote.ToString() + "temp.xml", oEnviNFe);

                        ////testa o tamanho do lote : se lote estourou o tamanho nao assina, nao adiciona.
                        ////salva a nota novamente na caixa de entrada. 
                        ////assim ela continua na caixa de entrada para o proximo lote
                        ////if (GetFileSize(oParam.pastaRecibo + numeroNovoLote.ToString() + "temp.xml") > oParam.tamMaximoLoteKB * 1024)
                        ////{
                        ////    oEnviNFe.NFe = new SchemaXML.TNFe[listaAux.Length];

                        ////    for (int pos = 0; pos < listaAux.Length; pos++)
                        ////    {
                        ////        SchemaXML.TNFe oNFe4List = (SchemaXML.TNFe)listaAux[pos];

                        ////        oEnviNFe.NFe.SetValue(oNFe4List, pos);
                        ////    }

                        ////    //deixa o arquivo sem assinatura na caixa de entrada
                        ////    oNFe.Signature = null;
                        ////    Servicos.SalvaXML(oParam.pastaEntrada + origem, oNFe);

                        ////}

                        //#endregion

                        ////apaga o lote temporario
                        //File.Delete(oParam.pastaRecibo + numeroNovoLote.ToString() + "temp.xml");

                        //#endregion
                        #endregion


                    }//fim do try principal
                    catch (Exception ex)
                    {
                        //todo 
                        if (File.Exists(oParam.pastaEntrada + "ERRO" + CodigoDoResultado.ToString() + "_" + origem))
                            File.Delete(oParam.pastaEntrada + "ERRO" + CodigoDoResultado.ToString() + "_" + origem);

                        if (File.Exists(oParam.pastaEntrada + origem))
                            File.Move(oParam.pastaEntrada + origem, oParam.pastaEntrada + "ERRO" + CodigoDoResultado.ToString() + "_" + origem);

                    }
                    finally
                    {

                        #region Salvar informações no banco de dados NFe
                        NotaFiscal oNotaProc = new NotaFiscal();
                        oNotaProc.chaveNota = origem.Substring(0, origem.Length - 4);//oNFe.infNFe.Id; //buscar no xml da nota.

                        //todo : buscar o cnpj da nota
                        oNotaProc.empresa = oParam.empresa;
                        oNotaProc.numeroLote = numeroNovoLote;
                        oNotaProc.codigoSituacao = CodigoDoResultado;
                        oNotaProc.xmlNota = xmlNotaStr;

                        if (CodigoDoResultado == 0)
                        {
                            oNotaProc.xmlProcesso = "";
                            oNotaProc.descricaoSituacao = DescricaoDoResultado;
                            oNotaProc.xmlNota = Servicos.GetXML(oNFe);
                        }
                        else if (CodigoDoResultado == 8)//os erros de validaçao estao dentro de DescricaoDoResultado. 
                        {
                            oNotaProc.xmlProcesso = "<erro>" + DescricaoDoResultado + "</erro>";
                            oNotaProc.descricaoSituacao = "XML inválido";
                            DescricaoDoResultado = "XML inválido";
                        }
                        else//DescricaoDoResultado contém a mensagem correta para o Log
                        {
                            oNotaProc.xmlProcesso = "<erro>" + DescricaoDoResultado + "</erro>"; 
                            oNotaProc.descricaoSituacao = "XML inválido";
                        }

                        oNotaProc.nProt = "";
                        oNotaProc.xMotivo = "";
                        oNotaProc.cStat = "";

                        oNotaProc.xmlPedidoCancelamento = "";
                        oNotaProc.xmlProcessoCancelamento = "";
                        oNotaProc.nProtCancelamento = "";

                        oNotaProc.dataSituacao = DateTime.Now;
                        oNotaProc.Save(manager);

                        //Criar operação de Log
                        CriaLog(CodigoDoResultado, DescricaoDoResultado, oNotaProc.chaveNota);
                        #endregion
                    }

                }//fim do for
                #endregion


                #region criar servico pendente referente as notas que estao no lote

                //Carrega lote se criado
                CriaLog(999, "Lote criado : " + numeroNovoLote.ToString());

                //adicionar o lote nos servicos pendentes
                oServicoPendente = new ServicoPendente();

                string msgLog = "Serviço criado com sucesso.";

                oServicoPendente.codigoSituacao = TipoSituacaoServico.Assinado;

                if (!CriarServico)
                {
                    oServicoPendente.codigoSituacao = TipoSituacaoServico.Invalido;
                    msgLog = "Serviço foi criado sem nenhuma nota válida.";
                }

                oServicoPendente.dataSituacao = DateTime.Now;

                //todo : pegar o cnpj do arquivo
                oServicoPendente.empresa = oParam.empresa;
                oServicoPendente.numeroLote = numeroNovoLote;
                oServicoPendente.UF = oParam.UF;
                oServicoPendente.tipoAmbiente = oParam.tipoAmbiente;
                oServicoPendente.tipoEmissao = oParam.tipoEmissao;

                oServicoPendente.numeroRecibo = "";
                oServicoPendente.xmlRecibo = "";
                oServicoPendente.xmlRetConsulta = "";
                oServicoPendente.erroEnvio = false;

                oServicoPendente.Save(manager);

                //LOG : Serviço criado.
                CriaLog(1, msgLog);


                #endregion

            }
            catch (Exception ex)
            {
                CriaLog(999, ex.Message);
            }
        }





        /// <summary>
        /// Versão 2.0 - ok
        /// 
        /// </summary>
        /// <param name="oServicoPendente">Servico ainda não enviado. situacao = 1</param>
        private void EnviaEnvelope(ServicoPendente oServicoPendente)
        {
            SchemaXML.TEnviNFe oEnviNFe;
            SchemaXML.TRetEnviNFe oRetEnviNFe = null;
            try
            {
                
                String nomeArquivo = oParam.pastaSaida + oServicoPendente.numeroLote.ToString() + "-env-lot.xml";
                //verificar se existe
                if (!File.Exists(nomeArquivo))
                    throw new Exception("Não foi possível localizar o arquivo : " + nomeArquivo);

                //carregar envelope
                oEnviNFe = (SchemaXML.TEnviNFe)Servicos.CarregaXML_HD(nomeArquivo, typeof(SchemaXML.TEnviNFe));


                //pronto para enviar
                System.Web.Services.Protocols.SoapHttpClientProtocol oServico = NFeUtils.SetWebService(oParam, "Recepcao", "NfeRecepcao2");

                try
                {
                    //chamar o servico
                    oRetEnviNFe = Servicos.EnviarEnvelope(oServico, oEnviNFe, oParam);

                }
                catch (Exception ex)
                {
                    oServicoPendente.erroEnvio = true;

                    connectionOk = ConsultaStatus();
                }

                if (oRetEnviNFe != null && oRetEnviNFe.infRec != null)
                {
                    //salvar o recibo do envio
                    Servicos.SalvaXML(oParam.pastaRecibo + oServicoPendente.numeroLote.ToString() + "-rec.xml", oRetEnviNFe);

                    #region atualizar Servico Pendente

                    //todo : iniciar transacao
                    if (oRetEnviNFe.cStat != "103")
                        throw new Exception(oRetEnviNFe.xMotivo);

                    oServicoPendente.numeroRecibo = oRetEnviNFe.infRec.nRec;

                    oServicoPendente.xmlRecibo = Servicos.GetXML(oRetEnviNFe);

                    oServicoPendente.dataSituacao = oRetEnviNFe.dhRecbto;

                    oServicoPendente.codigoSituacao = TipoSituacaoServico.Enviado;


                    //setar todas as notas desse servico como enviadas.

                    NotaFiscalQry oNFeQry = new NotaFiscalQry();
                    oNFeQry.empresa = oServicoPendente.empresa;
                    oNFeQry.numeroLote = oServicoPendente.numeroLote.ToString();

                    //somente as que foram assinadas e inseridas no lote.
                    oNFeQry.codigoSituacao = "0";

                    ArrayList notasProcessadas = NotaFiscalDAL.Instance.GetInstances(oNFeQry, manager);
                    foreach (NotaFiscal oNFeProc in notasProcessadas)
                    {
                        oNFeProc.codigoSituacao = 12; //Enviada
                        oNFeProc.descricaoSituacao = "Nota enviada";
                        oNFeProc.dataSituacao = oServicoPendente.dataSituacao;
                        oNFeProc.Save(manager);

                        CriaLog(13, "Nota enviada", oNFeProc.chaveNota);
                    }
                    #endregion
                }
                else
                {
                    if (!oServicoPendente.erroEnvio) // a comunicacao foi bem sucedida, mas nao foi possivel abrir o nRec
                    {
                        oServicoPendente.erroEnvio = true;
                        //todo : tratar
                    }
                    oServicoPendente.codigoSituacao = TipoSituacaoServico.ProblemaNoEnvio;
                }

                oServicoPendente.Save(manager);

                if(oRetEnviNFe != null)
                    CriaLog(Int32.Parse(oRetEnviNFe.cStat), oRetEnviNFe.xMotivo);
            }
            catch (Exception ex)
            {
                CriaLog(999, ex.Message);
            }
            finally
            {
                oEnviNFe = null;
                oRetEnviNFe = null;
            }
        }

        /// <summary>
        /// Versão 2.0 - ok
        /// </summary>
        /// <param name="oServicoPendente">situacao = 2 : enviado</param>
        public void ConsultaEnvelope(ServicoPendente oServicoPendente)
        {
            SchemaXML.TRetEnviNFe oRetEnviNFe;
            SchemaXML.TConsReciNFe oConsReciNFe;
            SchemaXML.TRetConsReciNFe oRetConsReciNFe = null;

            try
            {
                oRetEnviNFe = (SchemaXML.TRetEnviNFe)Servicos.CarregaXML_STR(oServicoPendente.xmlRecibo, typeof(SchemaXML.TRetEnviNFe));

                if (oRetEnviNFe.infRec.nRec != oServicoPendente.numeroRecibo)
                {
                    oServicoPendente.codigoSituacao = TipoSituacaoServico.ProblemaNoEnvio;
                }
                else
                {                 
                    //cria o objeto de consulta de recibo
                    oConsReciNFe = new SchemaXML.TConsReciNFe();
                    oConsReciNFe.versao = oParam.versaoDados;
                    oConsReciNFe.tpAmb = oRetEnviNFe.tpAmb;
                    
                    oConsReciNFe.nRec = oRetEnviNFe.infRec.nRec;

                    //executar o servico
                    System.Web.Services.Protocols.SoapHttpClientProtocol oServico = NFeUtils.SetWebService(oParam, "RetRecepcao", "NfeRetRecepcao2");

                    try
                    {
                        oRetConsReciNFe = Servicos.ConsultarProcessamentoEnvelope(oServico, oConsReciNFe, oParam);

                        
                    }
                    catch(Exception ex)
                    {
                        connectionOk = ConsultaStatus();

                        throw ex;
                    }

                    //salvar o arquivo de retorno da consulta
                    Servicos.SalvaXML(oParam.pastaRecibo + oServicoPendente.numeroRecibo + "-pro-rec.xml", oRetConsReciNFe);

                    //testar retorno
                    #region trata Retorno do processamento

                    //atualiza a tabela de notas
                    NotaFiscalQry oNFQry = new NotaFiscalQry();
                    oNFQry.empresa = oServicoPendente.empresa;
                    oNFQry.numeroLote = oServicoPendente.numeroLote.ToString();

                    //buscar somente as notas que pertencem ao lote como enviada
                    oNFQry.codigoSituacao = "12";//enviada

                    ArrayList notasProcessadas = NotaFiscalDAL.Instance.GetInstances(oNFQry, manager);

                    //testa Codigo de Mensagem de resultado

                    if (oRetConsReciNFe.cStat == "105")
                    {
                        CriaLog(105, "Lote em processamento");
                    }
                    else if (oRetConsReciNFe.cStat == "225" || oRetConsReciNFe.cStat == "223" ||
                        oRetConsReciNFe.cStat == "280" || oRetConsReciNFe.cStat == "281" ||
                        oRetConsReciNFe.cStat == "283" || oRetConsReciNFe.cStat == "286" ||
                        oRetConsReciNFe.cStat == "284" || oRetConsReciNFe.cStat == "285" ||
                        oRetConsReciNFe.cStat == "282" || oRetConsReciNFe.cStat == "214" ||
                        oRetConsReciNFe.cStat == "243" || oRetConsReciNFe.cStat == "242" ||
                        oRetConsReciNFe.cStat == "299" || oRetConsReciNFe.cStat == "408" ||
                        oRetConsReciNFe.cStat == "238" || oRetConsReciNFe.cStat == "239" ||
                        oRetConsReciNFe.cStat == "215" || oRetConsReciNFe.cStat == "404" ||
                        oRetConsReciNFe.cStat == "402" || oRetConsReciNFe.cStat == "252" ||
                        oRetConsReciNFe.cStat == "248" || oRetConsReciNFe.cStat == "106" ||
                        (oRetConsReciNFe.cStat == "104" && oRetConsReciNFe.protNFe[0].infProt.cStat == "999"))
                    {
                        //aplicativo deverá rejeitar o servico todo
                        CriaLog(Int32.Parse(oRetConsReciNFe.cStat), "Lote " + oServicoPendente.numeroLote.ToString() + " : " + oRetConsReciNFe.xMotivo);

                        
                        foreach (NotaFiscal oNFeProc in notasProcessadas)
                        {
                            oNFeProc.codigoSituacao = 14; //nota rejeitada
                            oNFeProc.descricaoSituacao = "Nota Rejeitada";
                            oNFeProc.dataSituacao = DateTime.Now;

                            oNFeProc.xmlProcesso = Servicos.GetXML(oRetConsReciNFe);
                            oNFeProc.cStat = oRetConsReciNFe.cStat;
                            oNFeProc.xMotivo = oRetConsReciNFe.xMotivo;

                            oNFeProc.Save(manager);
                            CriaLog(14, "Nota rejeitada pelo processamento do lote", oNFeProc.chaveNota);
                        }

                        //atualiza a tabela de serviços pendentes daquele lote.
                        oServicoPendente.codigoSituacao = TipoSituacaoServico.Rejeitado;
                    }
                    else if (oRetConsReciNFe.cStat == "104")//lote ja foi processado
                    {
                        //aplicativo deverá atualiza o servico 
                        CriaLog(Int32.Parse(oRetConsReciNFe.cStat), "Lote " + oServicoPendente.numeroRecibo.ToString() + " : " + oRetConsReciNFe.xMotivo);

                        //todo : criar uma transacao

                        #region percorre as notas
                        foreach (NotaFiscal oNotaProc in notasProcessadas)
                        {
                            foreach (SchemaXML.TProtNFe protocolo in oRetConsReciNFe.protNFe)
                            {
                                if (protocolo.infProt.chNFe == oNotaProc.chaveNota.Replace("NFe", ""))
                                {
                                    //achou protocolo da nota

                                    oNotaProc.dataSituacao = DateTime.Now;

                                    oNotaProc.xmlProcesso = Servicos.GetXML(protocolo);
                                    oNotaProc.cStat = protocolo.infProt.cStat;
                                    oNotaProc.xMotivo = protocolo.infProt.xMotivo;

                                    if (protocolo.infProt.cStat == "100")
                                    {
                                        //autorizacao por nota
                                        oNotaProc.codigoSituacao = 13;//nota Aprovada
                                        oNotaProc.descricaoSituacao = "Nota Aprovada";
                                        if (protocolo.infProt.nProt != null)
                                        {
                                            oNotaProc.nProt = protocolo.infProt.nProt;
                                        }
                                        else
                                        {
                                            oNotaProc.nProt = ""; //todo : tratar 
                                            CriaLog(999, "Não foi possivel obter nProt do retorno da consulta. ", oNotaProc.chaveNota.ToString());
                                        }
                                    }
                                    else
                                    {
                                        //rejeicao por nota
                                        oNotaProc.codigoSituacao = 14;//nota rejeitada
                                        oNotaProc.descricaoSituacao = "Nota Rejeitada";
                                    }
                                    oNotaProc.Save(manager);

                                    //Atualiza LOG
                                    CriaLog(Convert.ToInt32(protocolo.infProt.cStat),
                                                            protocolo.infProt.xMotivo,
                                                    "NFe" + protocolo.infProt.chNFe);
                                    break;
                                }//fim do if
                            }//fim do foreach protocolo
                        }//fim do foreach nota
                        #endregion

                        //atualiza a tabela de serviços pendentes daquele lote.
                        oServicoPendente.codigoSituacao = TipoSituacaoServico.Processado;
                    }
                    #endregion
                }

                oServicoPendente.dataSituacao = DateTime.Now;
                oServicoPendente.xmlRetConsulta = Servicos.GetXML(oRetConsReciNFe);
                oServicoPendente.Save(manager);

               
            }
            catch (Exception ex)
            {
                CriaLog(999, ex.Message);
            }
            finally
            {
                oRetConsReciNFe = null;
                oConsReciNFe = null;
            }
        }
                
        /// <summary>
        /// Versao 2.0 - ok
        /// </summary>
        /// <returns>true - Sefaz respondeu ou false - falha na conexao</returns>
        public Boolean ConsultaStatus()
        {
            RDI.NFe2.SchemaXML.TRetConsStatServ oRetConsStatServ;
            RDI.NFe2.SchemaXML.TConsStatServ oConsStatServ;

            bool retorno;

            try
            {
                #region Cria objeto de consulta
                oConsStatServ = new RDI.NFe2.SchemaXML.TConsStatServ();
                oConsStatServ.versao = oParam.versaoDados;
                oConsStatServ.tpAmb = oParam.tipoAmbiente;
                oConsStatServ.cUF = oParam.UF;
                #endregion

                System.Web.Services.Protocols.SoapHttpClientProtocol oServico =
                    NFeUtils.SetWebService(oParam, "Status", "NfeStatusServico2");

                Servicos.SalvaXML(oParam.pastaRecibo + oParam.UF.ToString() + "consulta-ped-sta.xml",
                        oConsStatServ);

                oRetConsStatServ = Servicos.ConsultarStatusServidor(oServico, oConsStatServ, oParam);

                Servicos.SalvaXML(oParam.pastaRecibo + oParam.UF.ToString() + "consulta-sta.xml",
                    oRetConsStatServ);


                //teste de operação
                retorno = (oRetConsStatServ.cStat == "107");
                CriaLog(Int32.Parse(oRetConsStatServ.cStat), "SEFAZ-" +
                    NFeUtils.ObterDescricao(oParam.UF) + " " + oRetConsStatServ.xMotivo);

            }
            catch (Exception ex)
            {
                //mapear codigos do log
                CriaLog(999, "SEFAZ-" + NFeUtils.ObterDescricao(oParam.UF) +
                    " não respondeu no timeout configurado. " + ex.Message);
                retorno = false;
            }
            finally
            {
                //Limpa os objetos
                oConsStatServ = null;
                oRetConsStatServ = null;
            }
            return retorno;
        }

        /// <summary>
        /// versao 2.0 - ok
        /// </summary>
        /// <param name="oServicoPendente">processado  = 3</param>
        public void FinalizaServicos(ServicoPendente oServicoPendente)
        {
            try
            {
                //todo : criar transacao

                //buscar no banco as notas aprovadas desse ServicoPendente
                NotaFiscalQry oNFeQry = new NotaFiscalQry();
                oNFeQry.empresa = oServicoPendente.empresa;
                oNFeQry.numeroLote = oServicoPendente.numeroLote.ToString();
                oNFeQry.codigoSituacao = "13";//aprovada

                ArrayList notasProcessadas = NotaFiscalDAL.Instance.GetInstances(oNFeQry, manager);

                foreach (NotaFiscal oNotaProc in notasProcessadas)
                {
                    ImprimeDANFe(oNotaProc);
                    CriaLog(4, "Arquivo enviado para Pasta de Impressão com sucesso!", oNotaProc.chaveNota);
                }
                oServicoPendente.codigoSituacao = TipoSituacaoServico.Finalizado;
                oServicoPendente.dataSituacao = DateTime.Now;
                oServicoPendente.Save(manager);
            }
            catch (Exception ex)
            {
                CriaLog(999, ex.Message);
            }
            finally
            {

            }
        }

        public void ImprimeDANFe(NotaFiscal oNotaProc)
        {
            try
            {
                String nomeArquivo = oNotaProc.nProt + "_v2.00-procNFe.xml";
                GeraArquivoProcNFe(oNotaProc, oParam.pastaSaida + nomeArquivo);
                
                if (!File.Exists(oParam.pastaSaida + nomeArquivo))
                    throw new Exception("Não foi possivel localizar arquivo de processo : " + oParam.pastaSaida + nomeArquivo);

                File.Copy(oParam.pastaSaida + nomeArquivo, oParam.pastaImpressao + nomeArquivo, true);

                if (!File.Exists(oParam.pastaImpressao + nomeArquivo))
                    throw new Exception("Não foi possivel salvar o arquivo de processo : " + oParam.pastaImpressao + nomeArquivo);

                oNotaProc.codigoSituacao = 15;//impressa
                oNotaProc.descricaoSituacao = "Nota Impressa";
                oNotaProc.dataSituacao = DateTime.Now;

                oNotaProc.Save(manager);
                
            }
            catch (Exception ex)
            {
                CriaLog(999, ex.Message, oNotaProc.chaveNota);
            }

        }

                
            
        


        /// <summary>
        /// Executa servico do webservice de consulta protocolo, testando antes se webservice esta funcionando.
        /// </summary>
        /// <param name="ChaveNFe">chave da nfe a ser consultada sem o NFe.</param>
        /// <returns>ok - true(oParam.pastaRecibo + ChaveNFe + "-sit.xml") | erro - false </returns>
        private Boolean ConsultaProcNFe(String ChaveNFe)
        {
            //string retorno = "";
            //StreamWriter SW;
            //Antes de enviar testar se o WS da Receita esta Disponivel

            RDI.NFe2.SchemaXML.TConsSitNFe oConsSitNFe;
            RDI.NFe2.SchemaXML.TRetConsSitNFe oRetConsSitNFe;

            //if (ConsultaStatus())
            //retirado para atender as regras de boas praticas da SEFAZ
            //{
                //Comunicação OK
                try
                {

                    oConsSitNFe = new RDI.NFe2.SchemaXML.TConsSitNFe();
                    oConsSitNFe.chNFe = ChaveNFe;
                    oConsSitNFe.tpAmb = oParam.tipoAmbiente;
                    oConsSitNFe.versao = oParam.versaoDados;


                    RDI.NFe2.Business.Servicos.SalvaXML(oParam.pastaRecibo + ChaveNFe + "-ped-sit.xml", oConsSitNFe);

                    System.Web.Services.Protocols.SoapHttpClientProtocol oServico = NFeUtils.SetWebService(oParam, "Consulta", "NfeConsulta2");

                    try
                    {
                        // Executa servico
                        oRetConsSitNFe = Servicos.ConsultarProtocoloNFe(oServico, oConsSitNFe, oParam);
                        
                        Servicos.SalvaXML(oParam.pastaRecibo + ChaveNFe + "-sit.xml", oRetConsSitNFe);

                        return true;
                    }
                    catch (Exception ex)
                    {
                        connectionOk = ConsultaStatus();
                        throw ex;
                    }

                }
                catch
                {
                    CriaLog(999, "Erro ao executar ConsultaProcNFe()", ChaveNFe);
                    return false;
                }
                finally
                {
                    oRetConsSitNFe = null;
                    oConsSitNFe = null;
                }
            //}
            //else
            //{
            //    return false;
            //}

        }


        public void GeraArquivoProcNFe(NotaFiscal oNotaProc, string nomeArquivo)
        {
            

            if (oNotaProc.cStat == "100") // notas aprovadas
            {
                SchemaXML.TNfeProc oNFeProc = new RDI.NFe2.SchemaXML.TNfeProc();
                oNFeProc.versao = oParam.versaoDados; // todo
                oNFeProc.NFe = (SchemaXML.TNFe)Servicos.CarregaXML_STR(oNotaProc.xmlNota, typeof(SchemaXML.TNFe));
                oNFeProc.protNFe = (SchemaXML.TProtNFe)Servicos.CarregaXML_STR(oNotaProc.xmlProcesso, typeof(SchemaXML.TProtNFe));

                if (File.Exists(nomeArquivo))
                    File.Delete(nomeArquivo);

                Servicos.SalvaXML(nomeArquivo, oNFeProc);
            }
            else if (oNotaProc.cStat == "101") //notas canceladas
            {
                SchemaXML.TProcCancNFe oCancProc = new RDI.NFe2.SchemaXML.TProcCancNFe();
                oCancProc.versao = oParam.versaoDados;//todo
                oCancProc.cancNFe = (SchemaXML.TCancNFe)Servicos.CarregaXML_STR(oNotaProc.xmlPedidoCancelamento, typeof(SchemaXML.TCancNFe));
                oCancProc.retCancNFe = (SchemaXML.TRetCancNFe)Servicos.CarregaXML_STR(oNotaProc.xmlProcessoCancelamento, typeof(SchemaXML.TRetCancNFe));

                if (File.Exists(nomeArquivo))
                    File.Delete(nomeArquivo);

                Servicos.SalvaXML(nomeArquivo, oCancProc);
            }
            
        }

              

        public void InutilizaNumeracao(SchemaXML.TInutNFe oInutNFe, ref String cStat, ref String xMotivo)
        {
            SchemaXML.TRetInutNFe oRetInutNFe;

            try
            {

                String nomeArquivoPedido = oParam.pastaRecibo + oInutNFe.infInut.Id + "-pi.xml";
                String nomeArquivoPedidoAss = oParam.pastaRecibo + oInutNFe.infInut.Id + "-ped-inu.xml";

                if (File.Exists(nomeArquivoPedido))
                    File.Delete(nomeArquivoPedido);

                //salvar o arquivo
                NFe2.Business.Servicos.SalvaXML(nomeArquivoPedido, oInutNFe);

                //assinar pedido
                X509Certificate2 cert = Certificado.BuscaNome(oParam.certificado, oParam.usaWService);
                Int32 CodigoDoResultado = NFeUtils.AssinaXML(nomeArquivoPedido, "infInut", cert);
                cert = null;

                //apaga arquivo sem assinatura : -pi.xml
                if (File.Exists(nomeArquivoPedido))
                    File.Delete(nomeArquivoPedido);

                //avaliar retorno da assinatura
                if (CodigoDoResultado == 0)
                {
                    String erros = NFeUtils.ValidacaoXML(nomeArquivoPedidoAss,
                                                  oParam.pastaXSD + "inutNFe_v" + oParam.versaoDados + ".xsd");

                    if (erros != System.String.Empty)      //todo : problema : xml nao validado.
                    {
                        throw new Exception("Não foi possível validar o arquivo de Pedido de Inutilização.");
                    }
                    else if (erros == "NotFound")//TODO : implementar teste em validacaoXML.
                    {
                        throw new Exception("Não foi possível encontrar o arquivo de Pedido de Inutilização.");
                    }
                    else //ESTA TUDO OK 
                    {
                        
                        //carrega o pedido assinado
                        oInutNFe = (SchemaXML.TInutNFe)Servicos.CarregaXML_HD(nomeArquivoPedidoAss, typeof(SchemaXML.TInutNFe));
                        //cria servico
                        System.Web.Services.Protocols.SoapHttpClientProtocol oServico = NFeUtils.SetWebService(oParam, "Inutilizacao", "NfeInutilizacao2");
                        try
                        {
                            //executa servico
                            oRetInutNFe = Servicos.InutilizarNFe(oServico, oInutNFe, oParam);
                            //setar variaveis de retorno
                            cStat = oRetInutNFe.infInut.cStat;
                            xMotivo = oRetInutNFe.infInut.xMotivo;
                            //salva resultado no HD
                            Servicos.SalvaXML(nomeArquivoPedidoAss.Replace("-ped", ""), oRetInutNFe);
                        }
                        catch(Exception ex)
                        {
                            connectionOk = ConsultaStatus();

                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CriaLog(999, ex.Message);
            }
            finally
            {
                oRetInutNFe = null;
            }
        }

        public void CancelaNFe(SchemaXML.TCancNFe oCancNFe, ref String cStat, ref String xMotivo)
        {
            SchemaXML.TRetCancNFe oRetCancNFe;

            try
            {

                String nomeArquivoPedido = oParam.pastaRecibo + oCancNFe.infCanc.chNFe + "-pc.xml";
                String nomeArquivoPedidoAss = oParam.pastaRecibo + oCancNFe.infCanc.chNFe + "-ped-can.xml";

                //apagar de um antigo pedido
                if (File.Exists(nomeArquivoPedido))
                    File.Delete(nomeArquivoPedido);

                //salvar o arquivo
                NFe2.Business.Servicos.SalvaXML(nomeArquivoPedido, oCancNFe);

                //assinar pedido
                X509Certificate2 cert = Certificado.BuscaNome(oParam.certificado, oParam.usaWService);
                Int32 CodigoDoResultado = NFeUtils.AssinaXML(nomeArquivoPedido, "infCanc", cert);
                cert = null;

                //apaga arquivo sem assinatura : -pc.xml
                if (File.Exists(nomeArquivoPedido))
                    File.Delete(nomeArquivoPedido);

                //avaliar retorno da assinatura
                if (CodigoDoResultado == 0)
                {
                    String erros = NFeUtils.ValidacaoXML(nomeArquivoPedido.Replace("-pc", "-ped-can"),
                                                  oParam.pastaXSD + "cancNFe_v" + oParam.versaoDados + ".xsd");

                    if (erros != System.String.Empty)      //todo : problema : xml nao validado.
                    {
                        throw new Exception("Não foi possível validar o arquivo de Pedido de Cancelamento.");
                    }
                    else if (erros == "NotFound")//TODO : implementar teste em validacaoXML.
                    {
                        throw new Exception("Não foi possível encontrar o arquivo de Pedido de Cancelamento.");
                    }
                    else //ESTA TUDO OK 
                    {

                        //carrega o pedido assinado
                        oCancNFe = (SchemaXML.TCancNFe)Servicos.CarregaXML_HD(nomeArquivoPedidoAss, typeof(SchemaXML.TCancNFe));
                        //cria servico
                        System.Web.Services.Protocols.SoapHttpClientProtocol oServico = NFeUtils.SetWebService(oParam, "Cancelamento", "NfeCancelamento2");
                        try
                        {
                            //executa servico
                            oRetCancNFe = Servicos.CancelarNFe(oServico, oCancNFe, oParam);
                            //setar variaveis de retorno
                            cStat = oRetCancNFe.infCanc.cStat;
                            xMotivo = oRetCancNFe.infCanc.xMotivo;
                            //salva resultado no HD
                            Servicos.SalvaXML(nomeArquivoPedidoAss.Replace("-ped", ""), oRetCancNFe);
                        }
                        catch (Exception ex)
                        {
                            connectionOk = ConsultaStatus();

                            throw ex;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CriaLog(999, ex.Message);
            }
            finally
            {
                oRetCancNFe = null;
            }
        }



       

        

        

       
    }
}

