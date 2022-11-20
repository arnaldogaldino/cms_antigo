using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RDI.NFe2.Business;
using System.IO;
using System.Collections;
using RDI.Lince;

namespace RDI.NFe.Visual
{
    /// <summary>
    ///  atualizar essa tela com os novos campos
    /// </summary>


    public partial class FrmEditNota : Form
    {
        public NotaFiscal oNFe;
        public FrmEditNota()
        {
            InitializeComponent();
        }

        private void FrmEditNota_Load(object sender, EventArgs e)
        {
            DoRefresh();    
        }

        private void btCancela_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btImprime_Click(object sender, EventArgs e)
        {
            if (oNFe.codigoSituacao == 13 || oNFe.codigoSituacao == 15)//aprovada ou impressa
                //|| Program.oParam.modoOperacao == ModoOperacao.Contigencia) 
                //nao pode ser impressa em contigencia, pq DANFE.exe nao atende 
                //espeficicacoes de contigencia//
            {
                ClientEnvironment manager = null;
                FuncaoAutomacao oFuncao = null;
                try
                {
                    manager = Program.CreateManager();
                    //oParam = Program.GetParametro(Program.empresa, manager);
                    oFuncao = new FuncaoAutomacao(Program.empresa, manager);
                    oFuncao.ImprimeDANFe(oNFe);
                    DoRefresh();
                }
                catch (Exception ex)
                {
                    if (oFuncao != null)
                    {
                        oFuncao.CriaLog(999, ex.Message);
                    }
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    oFuncao = null;
                    Program.DisposeManager(manager);
                }
            }
            else
            {
                MessageBox.Show("Nota não foi aprovada pela SEFAZ");
            }
        }

        private void btDoCancel_Click(object sender, EventArgs e)
        {
            ClientEnvironment manager = null;
            Parametro oParam = null;
            FuncaoAutomacao oFuncao = null;
            try
            {
                if (MessageBox.Show("Deseja realmente cancelar essa nota ?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) != DialogResult.Yes)
                {
                    throw new Exception("Pedido de cancelamento não executado.");
                }
                
                if (oNFe.codigoSituacao != 13 && oNFe.codigoSituacao != 15) //aprovada ou impressa
                {
                    if (oNFe.codigoSituacao == 16)
                    {
                        throw new Exception("Nota já cancelada.");
                    }
                    else
                    {
                        throw new Exception("Nota não foi aprovada pela SEFAZ.");
                    }
                }

                manager = Program.CreateManager();
                oParam = Program.GetParametro(Program.empresa, manager);
                oFuncao = new FuncaoAutomacao(Program.empresa, manager);
                RDI.NFe2.SchemaXML.TCancNFe oCancelamento = new RDI.NFe2.SchemaXML.TCancNFe();
                RDI.NFe2.SchemaXML.TProtNFe oProtNFe = (RDI.NFe2.SchemaXML.TProtNFe)
                    Servicos.CarregaXML_STR(oNFe.xmlProcesso, typeof(RDI.NFe2.SchemaXML.TProtNFe));
                oCancelamento.versao = oProtNFe.versao;
                oCancelamento.infCanc = new RDI.NFe2.SchemaXML.TCancNFeInfCanc();
                oCancelamento.infCanc.chNFe = oProtNFe.infProt.chNFe;
                oCancelamento.infCanc.Id = "ID" + oProtNFe.infProt.chNFe;
                oCancelamento.infCanc.nProt = oProtNFe.infProt.nProt;
                oCancelamento.infCanc.tpAmb = oProtNFe.infProt.tpAmb;
                oProtNFe = null;

                //todo : colocar mensagem para o usuario digitar
                oCancelamento.infCanc.xJust = "NOTA CANCELADA NO SISTEMA";//todo : permitir ao usuario digitar a justificativa
                oCancelamento.infCanc.xServ = "CANCELAR";

                String cStat = String.Empty;
                String xMotivo = String.Empty;

                oFuncao.CancelaNFe(oCancelamento, ref cStat, ref xMotivo);

                if (cStat == String.Empty && xMotivo == String.Empty) //recebeu resposta da sefaz
                {
                    throw new Exception("Não foi possível executar o Cancelamento. Consulte o log do sistema.");
                }

                


                if (cStat != "101")
                    throw new Exception(xMotivo);

                oNFe.codigoSituacao = 16;//todo : nota cancelada
                oNFe.dataSituacao = DateTime.Now;
                oNFe.descricaoSituacao = "Nota Cancelada";

                RDI.NFe2.SchemaXML.TRetCancNFe oRetCancelamento = (RDI.NFe2.SchemaXML.TRetCancNFe)
                    RDI.NFe2.Business.Servicos.CarregaXML_HD(oParam.pastaRecibo + oCancelamento.infCanc.chNFe + "-can.xml",
                                                                typeof(RDI.NFe2.SchemaXML.TRetCancNFe));

                //carregar o pedido assinado
                oCancelamento = (RDI.NFe2.SchemaXML.TCancNFe)Servicos.CarregaXML_HD(oParam.pastaRecibo + oCancelamento.infCanc.chNFe + "-ped-can.xml",
                                                                typeof(RDI.NFe2.SchemaXML.TCancNFe));


                //atualizar registro
                oNFe.xmlPedidoCancelamento = Servicos.GetXML(oCancelamento);
                oNFe.xmlProcessoCancelamento = Servicos.GetXML(oRetCancelamento);
                oNFe.cStat = cStat;
                oNFe.xMotivo = xMotivo;
                oNFe.nProtCancelamento = oRetCancelamento.infCanc.nProt;
                oNFe.Save(manager);

                oFuncao.CriaLog(999, "Cancelamento de Nota : " + xMotivo );
                MessageBox.Show(xMotivo);
                DoRefresh();



            }
            catch (Exception ex)
            {
               if (oFuncao != null)
                {
                   oFuncao.CriaLog(999, "Cancelamento de Nota : " + ex.Message);
                }
                MessageBox.Show(ex.Message);
            }
            finally
            {
                oFuncao = null;
                oParam = null;
                Program.DisposeManager(manager);
            }
        }

        

        
        private void DoRefresh()
        {
            ClientEnvironment manager = null;

            try
            {
                manager = Program.CreateManager();

                oNFe = (NotaFiscal)NotaFiscalDAL.Instance.Find(oNFe.GetKeyString(), manager);


                txChaveNota.Text = oNFe.chaveNota;
                txLote.Text = oNFe.numeroLote.ToString();
                txCodSit.Text = oNFe.codigoSituacao.ToString();
                txDatSit.Text = oNFe.dataSituacao.ToString();
                txDesSit.Text = oNFe.descricaoSituacao;

                if (!String.IsNullOrEmpty(oNFe.cStat))
                    txcStat.Text = oNFe.cStat;
                if (!String.IsNullOrEmpty(oNFe.xMotivo))
                    txxMotivo.Text = oNFe.xMotivo;
                if (!String.IsNullOrEmpty(oNFe.nProt))
                    txnProt.Text = oNFe.nProt;
                if (!String.IsNullOrEmpty(oNFe.nProtCancelamento))
                    txnProtCanc.Text = oNFe.nProtCancelamento;



                System.Xml.XmlDocument xmlNota = new System.Xml.XmlDocument();
                xmlNota.LoadXml(oNFe.xmlNota);
                NFeUtils.PopulaTreeView(xmlNota, tvXmlNota);
                if (oNFe.codigoSituacao == 8) //xml invalido
                {
                    tvProcFinal.Visible = false;
                    tbProcFinal.Visible = true;
                    tbProcFinal.Text = oNFe.xmlProcesso;
                }
                else if (!String.IsNullOrEmpty(oNFe.xmlProcesso))
                {
                    xmlNota.LoadXml(oNFe.xmlProcesso);
                    NFeUtils.PopulaTreeView(xmlNota, tvProcFinal);
                }

                if (oNFe.cStat == "101")
                {
                    System.Xml.XmlDocument xmlCancelamento = new System.Xml.XmlDocument();

                    xmlCancelamento.LoadXml(oNFe.xmlPedidoCancelamento);
                    NFeUtils.PopulaTreeView(xmlCancelamento, tvXmlCancelamento);

                    xmlCancelamento.LoadXml(oNFe.xmlProcessoCancelamento);
                    NFeUtils.PopulaTreeView(xmlCancelamento, tvProcCancelamento);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Program.DisposeManager(manager);
            }
        }

        private void btGeraProcNFe_Click(object sender, EventArgs e)
        {
            ClientEnvironment manager = null;
            Parametro oParam = null;
            FuncaoAutomacao oFuncao = null;

            try
            {
                manager = Program.CreateManager();
                oParam = Program.GetParametro(Program.empresa, manager);
                oFuncao = new FuncaoAutomacao(Program.empresa, manager);

                if (oNFe.codigoSituacao != 13 && oNFe.codigoSituacao != 15 && oNFe.codigoSituacao != 16) // aprovada ou impressa ou cancelada
                {
                    throw new Exception("Somente para notas Aprovadas ou Canceladas!");
                }

                if (oNFe.codigoSituacao == 13 && oNFe.codigoSituacao == 15)
                {
                    oFuncao.GeraArquivoProcNFe(oNFe, oParam.pastaSaida + oNFe.nProt + "_v2.00-procNFe.xml");
                    MessageBox.Show("Arquivo gerado com sucesso em : " + oParam.pastaSaida + oNFe.nProt + "_v2.00-procNFe.xml");
                }
                else
                {
                    oFuncao.GeraArquivoProcNFe(oNFe, oParam.pastaSaida + oNFe.nProt + "_v2.00-procCancNFe.xml");
                    MessageBox.Show("Arquivo gerado com sucesso em : " + oParam.pastaSaida + oNFe.nProt + "_v2.00-procCancNFe.xml");
                }

                
            }
            catch (Exception ex)
            {
                if (oFuncao != null)
                {
                    oFuncao.CriaLog(999, "Gerar Arquivo Processo : " + ex.Message);
                }

                MessageBox.Show(ex.Message);
            }
            finally
            {
                //oParam = null;
                oFuncao = null;
                Program.DisposeManager(manager);
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void txnProtCanc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btRefreshId_Click(object sender, EventArgs e)
        {

           

            ClientEnvironment manager = null;
            Parametro oParam = null;
            FuncaoAutomacao oFuncao = null;

            try
            {
                manager = Program.CreateManager();
                oParam = Program.GetParametro(Program.empresa, manager);
                oFuncao = new FuncaoAutomacao(Program.empresa, manager);

                ServicoPendenteQry col = new ServicoPendenteQry();
                col.numeroLote = oNFe.numeroLote.ToString();
                ArrayList servicos = ServicoPendenteDAL.Instance.GetInstances(col, manager);
                if (servicos.Count > 0)
                {
                    ServicoPendente oSrv = (ServicoPendente)servicos[0];

                   if(oSrv.codigoSituacao != TipoSituacaoServico.ProblemaNoEnvio)
                       throw new Exception("Lote não teve problemas no envio.");

                    //todo : atualizar nfe pela chave de acesso.
                   
                }

                


            }
            catch (Exception ex)
            {
                if (oFuncao != null)
                {
                    oFuncao.CriaLog(999, "Atualizar situação pela chave : " + ex.Message);
                }

                MessageBox.Show(ex.Message);
            }
            finally
            {
                //oParam = null;
                oFuncao = null;
                Program.DisposeManager(manager);
            }


        }

    }
}