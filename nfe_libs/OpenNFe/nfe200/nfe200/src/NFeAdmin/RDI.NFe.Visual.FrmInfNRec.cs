using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RDI.NFe2.Business;
using RDI.Lince;
using System.Collections;

namespace RDI.NFe.Visual
{
    public partial class FrmInfNRec : Form
    {
        public string keyString;
        public FrmInfNRec()
        {
            InitializeComponent();
        }

        private void btCancela_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            ClientEnvironment manager = null;
            try
            {
                if (String.IsNullOrEmpty(txtnRec.Text))
                    throw new Exception("Informe o número do Recibo.");

                manager = Program.CreateManager();

                ServicoPendente oServicoPendente = (ServicoPendente)ServicoPendenteDAL.Instance.Find(keyString, manager);
                Parametro oParam = Program.GetParametro(oServicoPendente.empresa, manager);

                //criar o recibo no disco
                RDI.NFe2.SchemaXML.TRetEnviNFe oRetEnviNFe = new RDI.NFe2.SchemaXML.TRetEnviNFe();
                oRetEnviNFe.tpAmb = oServicoPendente.tipoAmbiente;
                oRetEnviNFe.verAplic = "2.00";
                oRetEnviNFe.cUF = oServicoPendente.UF;
                oRetEnviNFe.cStat = "103";
                oRetEnviNFe.xMotivo = "Lote recebido com sucesso";
                oRetEnviNFe.dhRecbto = DateTime.Now;
                oRetEnviNFe.infRec = new RDI.NFe2.SchemaXML.TRetEnviNFeInfRec();
                oRetEnviNFe.infRec.nRec = txtnRec.Text;
                oRetEnviNFe.infRec.tMed = "1";
                Servicos.SalvaXML(oParam.pastaRecibo + oServicoPendente.numeroLote.ToString() + "-rec.xml", oRetEnviNFe);

                oServicoPendente.xmlRecibo = Servicos.GetXML(oRetEnviNFe);

                oServicoPendente.numeroRecibo = txtnRec.Text;

                oServicoPendente.dataSituacao = DateTime.Now;
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

                    Log oLog = new Log();
                    oLog.codigoSituacao = 13;
                    oLog.descricaoSituacao = "Nota Enviada";
                    oLog.nota = new NotaFiscal();
                    oLog.nota.chaveNota = oNFeProc.chaveNota;
                    oLog.data = DateTime.Now;
                    oLog.empresa = oServicoPendente.empresa;
                    oLog.Save(manager);
                }
                oServicoPendente.Save(manager);
                
                Log oLogSrv = new Log();
                oLogSrv.codigoSituacao = 998;
                oLogSrv.descricaoSituacao = "Recibo informado pelo usuario.";
                oLogSrv.nota = new NotaFiscal();
                oLogSrv.nota.chaveNota = String.Empty;
                oLogSrv.data = DateTime.Now;
                oLogSrv.empresa = oServicoPendente.empresa;
                oLogSrv.Save(manager);

                MessageBox.Show("Lote atualizado com sucesso.");
                this.Close();
                this.Dispose();
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

        
    }
}
