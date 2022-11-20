using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RDI.NFe2.Business;
using RDI.Lince;

namespace RDI.NFe.Visual
{
    public partial class FrmEditServico : Form
    {
        public ServicoPendente oSrv;
        public FrmEditServico()
        {
            InitializeComponent();
        }

        private void btGrava_Click(object sender, EventArgs e)
        {

        }

        private void FrmEditServico_Load(object sender, EventArgs e)
        {
            DoRefresh();
        }

        private void DoRefresh()
        {
            if (oSrv != null)
            {
                 ClientEnvironment manager = null;
                 try
                 {
                     manager = Program.CreateManager();
                     oSrv = (ServicoPendente)ServicoPendenteDAL.Instance.Find(oSrv.keyString, manager);

                 }
                 catch (Exception ex)
                 {

                     MessageBox.Show(ex.Message);
                 }
                 finally
                 {
                     Program.DisposeManager(manager);
                 }

                txLote.Text = oSrv.numeroLote.ToString();
                txCodSit.Text = oSrv.codigoSituacao.ToString();
                txDatSit.Text = oSrv.dataSituacao.ToString();
                txRecNum.Text = oSrv.numeroRecibo;

                if (oSrv.xmlRecibo != String.Empty)
                {
                    
                    System.Xml.XmlDocument xmlRec = new System.Xml.XmlDocument();
                    xmlRec.LoadXml(oSrv.xmlRecibo);
                    NFeUtils.PopulaTreeView(xmlRec, tvSPeRec, true);
                }
                else
                {
                    tvSPeRec.Nodes.Clear();
                    tvSPeRec.Nodes.Add("Problema ao carregar o arquivo.");
                }

                if (oSrv.xmlRetConsulta != String.Empty)
                {

                    System.Xml.XmlDocument xmlRec = new System.Xml.XmlDocument();
                    xmlRec.LoadXml(oSrv.xmlRetConsulta);
                    NFeUtils.PopulaTreeView(xmlRec, tvSPeCons, true);
                }
                else
                {
                    tvSPeRec.Nodes.Clear();
                    tvSPeRec.Nodes.Add("Problema ao carregar o arquivo.");
                }
                btAtualizarLote.Enabled = (oSrv.codigoSituacao == TipoSituacaoServico.ProblemaNoEnvio);

            }
        }

        private void btCancela_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btAtualizarLote_Click(object sender, EventArgs e)
        {
            FrmInfNRec oFrm = new FrmInfNRec();
            oFrm.keyString = oSrv.keyString;
            oFrm.ShowDialog();

            DoRefresh();
        }

        private void btEnvScan_Click(object sender, EventArgs e)
        {

        }

        


        /* **********************Como funciona Contigencia************************************************
        * http://www.nfe.fazenda.gov.br/portal/docs/Manual_de_Contingencia_da_NF_e%20_Contribuinte_v602.pdf
        * http://www.nfe.fazenda.gov.br/portal/docs/Manual_DPEC_v1.00.pdf <- conferir esse site
        * 
        * 
        * sao 2 op��es :
        * 1) enviando para o SCAN 
        *      Quando utilizar ?
        *      R. Se o problema de comunica��o for no SEFAZ-Origem, o sistema
        *          poder� enviar a nota para o SCAN, que � outro WS.
        * 
        *      O que deve ser feito?
        *      R.  -   Alterar a s�rie da nota para uma s�rie v�lida para o SCAN(900 a 999);
        *          -   AVALIAR: Gerar novamente a chave da nota.
        *          -   AVALIAR: Assinar a nota novamente. necessidade do sistema.
        *          -   AVALIAR: Envelopar novamente.
        *          
        *          -   Enviar a nota para o WS Scan;
        *          -   Consultar sua aprova��o;
        *          -   Imprimir normalmente em papel comum, conforme aprova��o de uso;
        *          -   Monitorar a disponibilidade do SEFAZ-Origem, determinando o momento 
        *              de retornar o envio para o mesmo.
        *
        * 
        * 2) enviando para Sefaz-Origem p�s restaura��o do servi�o
        *      Quando utilizar ?
        *      R. Se o problema de comunica��o for no sistema interno da contribuinte, 
        *          falha na internet ou problema de rede.
        * 
        *      O que deve ser feito?
        *      R.  -   Alterar o campo tpEmis para 2(emitida em contigencia);
        *          -   Imprimir DANFE em formul�rio de contig�ncia estampando a informa��o 
        *                  �DANFE em conting�ncia, impresso em decorr�ncia de problemas t�cnicos� 
        *                  em 2 vias, sendo uma para o destino e outra arquivada na empresa emitente
        *                  para posterior consulta do FISCO;
        *          -   AVALIAR: Assinar a nota novamente. necessidade do sistema.
        *          -   AVALIAR: Envelopar novamente.
        *          -   Enviar as notas que foram emitidas em contigencia para a SEFAZ-Origem
        * 
        *      IMPORTANTE : Nesse caso, n�o devem ser utilizadas as s�ries reservadas para o SCAN(900 a 999)
        *          
        *          -   Se a nota for rejeitada para uso, a nota deve ser corrigida e novamente enviada para 
        *                  a SEFAZ-Origem
        *          -   Quando corrigida e autorizada, a nova DANFE deve ser enviada para a empresa destino.
        * 
        *          "O contribuinte emissor dever� lavrar termo no Livro de Registro de Utiliza��o de Documentos
        *          Fiscais e Termos de Ocorr�ncias, informando o motivo da entrada em conting�ncia, n�mero dos
        *          formul�rios de seguran�a utilizados, data e hora do in�cio e t�rmino, bem como a numera��o e
        *          s�rie das NF-e geradas neste per�odo."
        * 
        *          -   Esssas notas n�o passaram por verifica��es de Denega��o de Uso
        * 
        *************************************************************************************************************/
    }
}