using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Collections;
using RDI.NFe2.Business;
using RDI.Lince;
using System.IO;


namespace NFSe.Service
{
    public class Engine : System.ServiceProcess.ServiceBase
    {

        private FuncaoAutomacao oFuncao;
        private Parametro oParam;
        private ParametroQRY oParamQRY;
        private ClientEnvironment globalManager;
        private System.Data.SqlClient.SqlConnection globalConn;
        System.Timers.Timer oTmx;
        Boolean inExecution;
        Boolean isConnected;
        String connectionString;
        String CNPJ;
        String ConnectionFileName = "conexao";
        Boolean canLog = true;
        String LogFileName = "log.txt";
        

        public static void Main()
        {
            Run(new Engine());
        }

        public Engine()
        {
            //criar como em Program.cs
            oTmx = new System.Timers.Timer();
            oTmx.Elapsed += new System.Timers.ElapsedEventHandler(oTmx_Elapsed);
            oTmx.AutoReset = true;
            oTmx.Interval = 1000;
            inExecution = false;
            isConnected = false;
        }


        //precisamos criar um timer com loop
        protected override void OnStart(string[] args)
        {
            Boolean fileIsLoaded = true;
            Boolean fileIsFormated = true;
            String ErrorMSG = String.Empty;
            try
            {
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory+ ConnectionFileName))
                {
                    fileIsLoaded = false;
                    throw new Exception("Connection File is not found.");
                }

                try
                {
                    StreamReader SR = File.OpenText(AppDomain.CurrentDomain.BaseDirectory + ConnectionFileName);
                    connectionString = SR.ReadLine();
                    CNPJ = SR.ReadLine();
                    String LogLine = SR.ReadLine();
                    canLog = !(LogLine == "0");
                }
                catch
                {
                    fileIsFormated = false;
                }
                
            }
            catch (Exception ex)
            {
                ErrorMSG = ex.Message;
                if (!fileIsFormated)
                {
                    ErrorMSG = "Connection File is not formated."; //rever
                    fileIsLoaded = false;
                }
            }

            if (!fileIsLoaded)
            {
                NFeUtils.AddToFile("Error on start: " + ErrorMSG, canLog, LogFileName);
                isConnected = false;
            }
            else
            {
                Int32 numbersOfTents = 0;

                while (!isConnected && (numbersOfTents < 10))
                {
                    numbersOfTents++;

                    try
                    {
                        globalManager = new ClientEnvironment(DataBaseType.SQLSERVER);

                        oParam = new Parametro();//buscar do banco

                        globalManager = new RDI.Lince.ClientEnvironment(RDI.Lince.DataBaseType.SQLSERVER);
                        globalConn = new System.Data.SqlClient.SqlConnection();
                        globalConn.ConnectionString = connectionString;
                        globalConn.Open();
                        globalManager.connection = globalConn;

                        isConnected = true;

                        //carga dos parametros de sistema
                        oParam = new Parametro();
                        oParamQRY = new ParametroQRY();
                        oParamQRY.empresa = CNPJ;

                        //TODO: tratar mensagem de erro quando o CNPJ do conexao está incorreto.
                        try
                        {
                            oParam = (Parametro)ParametroDAL.Instance.GetInstances(oParamQRY, globalManager)[0];
                        }
                        catch (Exception ex)
                        {
                            NFeUtils.AddToFile(ex.Message, canLog, LogFileName);
                            isConnected = false;
                            numbersOfTents += 10;
                        }
                    }
                    catch (Exception ex)
                    {
                        NFeUtils.AddToFile(ex.Message, canLog, LogFileName);
                        isConnected = false;
                    }

                    Thread.Sleep(5000);

                }

                //iniciar loop
                if (isConnected)
                {
                    //salvar usaWService = true;
                    oParam.usaWService = true;
                    oParam.Save(globalManager);

                    //todo : salvar o nome da maquina que esta com o servico rodando;



                    oFuncao = new FuncaoAutomacao(oParam.empresa, globalManager);
                    inExecution = false;
                    NFeUtils.AddToFile("Started succesfully.", canLog, LogFileName);
                }
                else
                {
                    NFeUtils.AddToFile("Error on connect : number of tries overflow.", canLog, LogFileName);
                }
            }

            //always start the timer.
            //if any problem, the service will be stopped in elapsed code.
            oTmx.Enabled = true;
            NFeUtils.AddToFile("Timer is started.", canLog, LogFileName);
        }

        protected override void OnShutdown()
        {
            if(this.CanStop)
                Stop();
        }

        protected override void OnStop()
        {
            //parar o loop
            if (isConnected)
            {
                globalConn.Close();
                NFeUtils.AddToFile("Connection is closed.", canLog, LogFileName);
            }

            oTmx.Enabled = false;

            NFeUtils.AddToFile("The Service is stopped.", canLog, LogFileName);

            inExecution = false;
        }

        


        void oTmx_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (isConnected && oParam.usaWService)
            {
                NFeUtils.AddToFile("Elapsed", canLog, LogFileName);

                if (!inExecution)
                {
                    NFeUtils.AddToFile("Before - doonloop", canLog, LogFileName);
                    DoOnLoop();
                    NFeUtils.AddToFile("After - doonloop", canLog, LogFileName);
                }
            }
            else
            {
                Thread.Sleep(1000);
                NFeUtils.AddToFile("Stopping the Service.", canLog, LogFileName);
                Stop();
            }
        }

        private void DoOnLoop()
        {
            
            //try
            //{
                inExecution = true;

            //todo : criar no banco um campo para converter TXT->XML

                oFuncao.DoOnLoop(canLog, LogFileName);

                inExecution = false;

                #region antigo

                //    //const int qtdServicos = 5; // Variavel utilizada apenas para espacar o gatilho de cada servico automatico.
            //    TipoModoComunicacao modoComunicacao;

            //    oFuncao.MontaListaRPSXml();
            //    //servia para manter a lista do formulario com o nome dos arquivos
            //    //listadeNotas.Items.Clear();
            //    int i = 0;
            //    while (i < oFuncao.ListaDeNotasVisualizar.Count)
            //    {
            //        AddToFile(oFuncao.ListaDeNotasVisualizar[i].ToString());
            //        i++;
            //    }

            //    //-------------------------------Monta lote------------------------------------//
            //    if
            //    (
            //        oFuncao.ListaDeNotasProcessar.Count != 0 &&
            //        (
            //            ((DateTime.Now.Minute * 60 + DateTime.Now.Second) % oParam.tempoParaLote == 0) ||
            //            oFuncao.ListaDeNotasProcessar.Count >= oParam.qtdeRPSPorLotesAssinc
            //        )
            //    )
            //    {
            //        // Monta lote
            //        if (oFuncao.ListaDeNotasProcessar.Count <= oParam.qtdeRPSPorLotesSinc)
            //        {
            //            modoComunicacao = TipoModoComunicacao.Sinc;
            //            oFuncao.CriaEnvelope(oFuncao.ListaDeNotasProcessar.Count, modoComunicacao);

            //            AddToFile("Envia Sinc");
            //        }
            //        else
            //        {
            //            modoComunicacao = TipoModoComunicacao.Assinc;

            //            if (oFuncao.ListaDeNotasProcessar.Count > oParam.qtdeRPSPorLotesAssinc)
            //                oFuncao.CriaEnvelope(oParam.qtdeRPSPorLotesAssinc, modoComunicacao);
            //            else
            //                oFuncao.CriaEnvelope(oFuncao.ListaDeNotasProcessar.Count, modoComunicacao);

            //            AddToFile("Envia assinc");
            //        }

            //    }
            //    //-------------------------------Monta lote------------------------------------//

            //    //-------------------------------Envia lote------------------------------------//
            //    // Verifica lotes não enviados e envia
            //    //if (DateTime.Now.Second + 1 == 60 / qtdServicos)
            //    {
            //        LoteQry queryLote = new LoteQry();
            //        queryLote.empresa = oParam.empresa;
            //        queryLote.codigoSituacao = "0";

            //        ArrayList lista = LoteDAL.Instance.GetInstances(queryLote, globalManager);

            //        foreach (Lote tbLote in lista)
            //        {
            //            oFuncao.EnviaEnvelope(tbLote);
            //        }
            //        AddToFile("Envia Nota");
            //    }
            //    //-------------------------------Envia lote------------------------------------//

            //    //---------------------------Imprime NFSe recebida-----------------------------//
            //    if ((oParam.impressaoAutomatica))// && (DateTime.Now.Second + 1 == 60 / qtdServicos * 2))
            //    {
            //        oFuncao.ImprimirNFSeRecebidas();
            //        oFuncao.ReimprimirNFSe();
            //        AddToFile("Imprime NFSe");
            //    }
            //    //---------------------------Imprime NFSe recebida-----------------------------//

            //    //------------------------ Processa lotes pendentes----------------------------//
            //    //if (DateTime.Now.Second + 1 == 60 / qtdServicos * 3)
            //    {
            //        oFuncao.ProcessaLotesPendentes();
            //        AddToFile("Processa Lotes Pendentes");
            //    }
            //    //------------------------ Processa lotes pendentes----------------------------//

            //    //---------------------------Cancela NFSe-----------------------------//
            //    //if (DateTime.Now.Second + 1 == 60 / qtdServicos * 4)
            //    {
            //        oFuncao.BuscaArquivosCancelamentoNFSe();
            //        AddToFile("Busca Cancelamento");
            //    }
            //    //---------------------------Cancela NFSe-----------------------------//

            //    //----------------Atualiza XML de NFSe Substituida--------------------//
            //    //if (DateTime.Now.Second + 1 == 60 / qtdServicos * 5)
            //    {
            //        LoteQry queryLote = new LoteQry();
            //        queryLote.empresa = oParam.empresa;
            //        queryLote.codigoSituacao = "5";
            //        ArrayList lista = LoteDAL.Instance.GetInstances(queryLote, globalManager);

            //        foreach (Lote tbLote in lista)
            //        {
            //            if (tbLote.codigoSituacao == TipoCodigoSituacaoLote.NaoEnviado)
            //            {
            //                oFuncao.AbortarEnvio(tbLote);
            //            }
            //            else
            //            {
            //                throw new Exception("Situação do lote deve ser Não enviado.");
            //            }
            //        }
                    
                    
            //        oFuncao.AtualizaXMLNotasSubstituidas();
            //        AddToFile("Atualiza Nota");
            //    }
            //    //----------------Atualiza XML de NFSe Substituida--------------------//
            //}
            //catch (Exception ex)
            //{
            //    oFuncao.GravaLog(ex.Message);
            //    AddToFile(ex.Message);
                //}

                #endregion

                
        }

        private void InitializeComponent()
        {
            this.ServiceName = "EngineNFe2";
        }



    }
}
