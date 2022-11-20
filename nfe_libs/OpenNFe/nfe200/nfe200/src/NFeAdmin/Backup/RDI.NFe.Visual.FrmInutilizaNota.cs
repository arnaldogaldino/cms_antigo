using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RDI.NFe2.Business;
using System.IO;
using RDI.Lince;

namespace RDI.NFe.Visual
{
    public partial class FrmInutilizaNota : Form
    {
        public FrmInutilizaNota()
        {
            InitializeComponent();
            cbUF.DataSource = NFeUtils.Listar(typeof(NFe2.SchemaXML.TCodUfIBGE));
            cbUF.DisplayMember = "Value";
            cbUF.ValueMember = "Key";

            cbTipoAmbiente.DataSource = NFeUtils.Listar(typeof(NFe2.SchemaXML.TAmb));
            cbTipoAmbiente.DisplayMember = "Value";
            cbTipoAmbiente.ValueMember = "Key";

            ClientEnvironment manager = null;

            try
            {
                manager = Program.CreateManager();
                Parametro oParam = Program.GetParametro(Program.empresa, manager);

                cbTipoAmbiente.SelectedValue = Convert.ToInt32(oParam.tipoAmbiente);
                cbUF.SelectedValue = Convert.ToInt32(oParam.UF);
                tbCNPJ.Text = Program.empresa;

                oParam = null;
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

        private void btCancela_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }


        private void btInutiliza_Click(object sender, EventArgs e)
        {
            ClientEnvironment manager = null;
            Parametro oParam= null;
            FuncaoAutomacao oFuncao = null;
            try
            {
                manager = Program.CreateManager();
                oParam = Program.GetParametro(Program.empresa, manager);
                oFuncao = new FuncaoAutomacao(Program.empresa, manager);

                if (Int32.Parse(tbNotaInicial.Text) > Int32.Parse(tbNotaFinal.Text))
                    throw new Exception("Nota Inicial deve ser menor que Nota Final.");


                //Código da UF + CNPJ + modelo + série + nro inicial e nro final precedida do literal “ID”
                RDI.NFe2.SchemaXML.TInutNFe oInutilizacao = new RDI.NFe2.SchemaXML.TInutNFe();

                oInutilizacao.versao = oParam.versaoDados;
                oInutilizacao.infInut = new RDI.NFe2.SchemaXML.TInutNFeInfInut();
                oInutilizacao.infInut.ano = tbAno.Text;
                oInutilizacao.infInut.CNPJ = tbCNPJ.Text;

                oInutilizacao.infInut.cUF = NFeUtils.DefineUF(cbUF.SelectedValue.ToString());

                oInutilizacao.infInut.Id = "ID" + cbUF.SelectedValue.ToString() + tbAno.Text.PadLeft(2,'0') + tbCNPJ.Text + tbMod.Text +
                                                  tbSerie.Text.PadLeft(3, '0') + tbNotaInicial.Text.PadLeft(9, '0') + tbNotaFinal.Text.PadLeft(9, '0');

                oInutilizacao.infInut.mod = RDI.NFe2.SchemaXML.TMod.Item55;
                oInutilizacao.infInut.nNFIni = tbNotaInicial.Text;
                oInutilizacao.infInut.nNFFin = tbNotaFinal.Text;
                oInutilizacao.infInut.serie = tbSerie.Text;

                oInutilizacao.infInut.tpAmb = (RDI.NFe2.SchemaXML.TAmb)NFeUtils.DefineEnum(cbTipoAmbiente.SelectedValue.ToString(),
                                                                                         typeof(RDI.NFe2.SchemaXML.TAmb));
                oInutilizacao.infInut.xJust = tbJust.Text;
                oInutilizacao.infInut.xServ = "INUTILIZAR";

                String cStat = String.Empty;
                String xMotivo = String.Empty;

                oFuncao.InutilizaNumeracao(oInutilizacao, ref cStat, ref xMotivo);


                if (cStat == String.Empty && xMotivo == String.Empty) //recebeu resposta da sefaz
                    throw new Exception("Não foi possível executar Inutilização. Consulte o LOG do sistema.");

                if (cStat != "102")
                    throw new Exception(xMotivo);

                Int32 notaInicial = Int32.Parse(tbNotaInicial.Text);
                Int32 notaFinal = Int32.Parse(tbNotaFinal.Text);

                while (notaInicial <= notaFinal)
                {
                    NotaInutilizada oNota = new NotaInutilizada();
                    oNota.numeroNota = notaInicial.ToString();
                    
                    //setar a serie da nota
                    oNota.serieNota = tbSerie.Text;

                    oNota.data = DateTime.Today;
                    oNota.empresa = oParam.empresa;
                    System.Xml.XmlDocument oDoc = new System.Xml.XmlDocument();
                    oDoc.Load(oParam.pastaRecibo + oInutilizacao.infInut.Id + "-inu.xml");
                    oNota.XMLResposta = oDoc.OuterXml;
                    oDoc.Load(oParam.pastaRecibo + oInutilizacao.infInut.Id + "-ped-inu.xml");
                    oNota.XMLPedido = oDoc.OuterXml;
                    oNota.Save(manager);

                    notaInicial++;
                }

                MessageBox.Show(xMotivo);

            }
            catch (Exception ex)
            {
                if (oFuncao != null)
                {
                    oFuncao.CriaLog(999, "Inutilização de Notas : " + ex.Message);
                }
                MessageBox.Show(ex.Message);
            }
            finally
            {
                oParam = null;
                oFuncao = null;
                Program.DisposeManager(manager);
            }
        }


        

        private void tbAno_TextChanged(object sender, EventArgs e)
        {

        }
    }
}