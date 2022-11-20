using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using BoletoNet;
using cms.Data;
using System.IO;

namespace cms.Modulos.Financeiro.Forms.Boletos
{
    public partial class frmBoletoList : cms.Modulos.Util.WindowBase
    {
        private DateTime data_atual = new DateTime();
        cms.Modulos.Financeiro.Cn.cnFinanceiroBoleto cFinanceiroBoleto = new cms.Modulos.Financeiro.Cn.cnFinanceiroBoleto();
        cms.Modulos.Financeiro.Cn.cnFinanceiroContaReceber cFinanceiroContaReceber = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaReceber();

        IQueryable<vw_financeiro_boleto> IQBoletos;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmBoletoList()
        {
            InitializeComponent();
        }

        #region Lookup
        private void btCliente_Click(object sender, EventArgs e)
        {
            cms.Modulos.Cliente.Forms.frmClienteLockup fClienteLockup = new cms.Modulos.Cliente.Forms.frmClienteLockup();

            if (fClienteLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var cliente = fClienteLockup.GetClienteSelecionado();

                txtCliente.Tag = cliente;
                txtCliente.Text = cliente.id_cliente + " - " + cliente.nome_fantasia;

                fClienteLockup.Close();
                fClienteLockup.Dispose();
            }
            else
            {
                txtCliente.Tag = null;
                txtCliente.Text = string.Empty;
            }
        }

        private void btContaCorrente_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.ContaCorrente.frmFinanceiroContaCorrenteLockup fContaCorrenteLockup = new cms.Modulos.Financeiro.Forms.ContaCorrente.frmFinanceiroContaCorrenteLockup();

            if (fContaCorrenteLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var conta_corrente = fContaCorrenteLockup.GetFormaPagamentoSelecionado();

                txtContaCorrente.Tag = conta_corrente;
                txtContaCorrente.Text = conta_corrente.financeiro_banco.nome;

                fContaCorrenteLockup.Close();
                fContaCorrenteLockup.Dispose();
            }
            else
            {
                txtContaCorrente.Tag = null;
                txtContaCorrente.Text = string.Empty;
            }
        }

        private void txtContaCorrente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btContaCorrente_Click(sender, e);
            }
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCliente_Click(sender, e);
            }
        }
        #endregion

        #region Pesquisa
        private void btPesquisar_Click(object sender, EventArgs e)
        {
            data_atual = Util.Util.GetDataServidor();
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }

            load.btCancelar.Click += new EventHandler(btCancelar_Click);
            load.LoadShow(this);

            threadPreencherGrid = new Thread(AtualizarGvContaPagar);
            threadPreencherGrid.IsBackground = true;
            threadPreencherGrid.Start();
        }

        private void AtualizarGvContaPagar()
        {
            gvFinanceiroBoleto.AutoGenerateColumns = false;

            long? id_conta_corrente = null;
            long? id_cliente = null;
            long? id_empresa = null;
            string nosso_numero = string.Empty;

            DateTime? data_vencimento_de = null;
            DateTime? data_vencimento_ate = null;
            DateTime? data_pagamento_de = null;
            DateTime? data_pagamento_ate = null;

            bool chk_data_vencimento_de = false;
            bool chk_data_vencimento_ate = false;
            bool chk_data_pagamento_de = false;
            bool chk_data_pagamento_ate = false;

            string documento = string.Empty;

            if (ctrlFilial.InvokeRequired)
                if (!string.IsNullOrEmpty(ctrlFilial.GetSelectedValue()))
                    id_empresa = long.Parse(ctrlFilial.GetSelectedValue());

            if (txtNossoNumero.InvokeRequired)
                if (!string.IsNullOrEmpty(txtNossoNumero.Text))
                    nosso_numero = txtNossoNumero.Text;

            if (txtDocumento.InvokeRequired)
                if (!string.IsNullOrEmpty(txtDocumento.Text))
                    documento = txtDocumento.Text;

            if (txtContaCorrente.InvokeRequired)
                if (txtContaCorrente.Tag != null)
                    id_conta_corrente = ((financeiro_conta_corrente)txtContaCorrente.Tag).id_financeiro_conta_corrente;

            if (txtCliente.InvokeRequired)
                if (txtCliente.Tag != null)
                    id_cliente = ((cliente)txtCliente.Tag).id_cliente;


            if (dtaVencimentoDataDe.InvokeRequired)
            {
                dtaVencimentoDataDe.Invoke(new MethodInvoker(delegate { chk_data_vencimento_de = dtaVencimentoDataDe.Checked; }));
                if (chk_data_vencimento_de)
                    dtaVencimentoDataDe.Invoke(new MethodInvoker(delegate { data_vencimento_de = dtaVencimentoDataDe.Value; }));
            }

            if (dtaVencimentoDataAte.InvokeRequired)
            {
                dtaVencimentoDataAte.Invoke(new MethodInvoker(delegate { chk_data_vencimento_ate = dtaVencimentoDataAte.Checked; }));
                if (chk_data_vencimento_ate)
                    dtaVencimentoDataAte.Invoke(new MethodInvoker(delegate { data_vencimento_ate = dtaVencimentoDataAte.Value; }));
            }

            if (dtaPagamentoDataDe.InvokeRequired)
            {
                dtaPagamentoDataDe.Invoke(new MethodInvoker(delegate { chk_data_pagamento_de = dtaPagamentoDataDe.Checked; }));
                if (chk_data_pagamento_de)
                    dtaPagamentoDataDe.Invoke(new MethodInvoker(delegate { data_pagamento_de = dtaPagamentoDataDe.Value; }));
            }

            if (dtaPagamentoDataAte.InvokeRequired)
            {
                dtaPagamentoDataDe.Invoke(new MethodInvoker(delegate { chk_data_pagamento_ate = dtaPagamentoDataAte.Checked; }));
                if (chk_data_pagamento_ate)
                    dtaPagamentoDataDe.Invoke(new MethodInvoker(delegate { data_pagamento_ate = dtaPagamentoDataAte.Value; }));
            }

            try
            {
                IQBoletos = cFinanceiroBoleto.FinanceiroBoletoProcurar(nosso_numero, id_empresa, id_cliente, id_conta_corrente, documento, data_vencimento_de, data_vencimento_ate, data_pagamento_de, data_pagamento_ate);
            }
            catch { }

            if (gvFinanceiroBoleto.InvokeRequired)
                gvFinanceiroBoleto.Invoke(new MethodInvoker(Preencher));
        }
        
        public void Preencher()
        {
            gvFinanceiroBoleto.AutoGenerateColumns = false;
            gvFinanceiroBoleto.DataSource = IQBoletos;
            gvFinanceiroBoleto.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }
        
        void btCancelar_Click(object sender, EventArgs e)
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }
        
        private void gvFinanceiroBoleto_DoubleClick(object sender, EventArgs e)
        {
            if (gvFinanceiroBoleto.CurrentRow == null)
                return;

            long id_conta_receber = 0;
            try
            {
                id_conta_receber = long.Parse(gvFinanceiroBoleto.CurrentRow.Cells[1].Value.ToString());
            }
            catch { }

            cms.Modulos.Financeiro.Forms.Boletos.frmBoletoVisualizar fBoletoVisualiza = new cms.Modulos.Financeiro.Forms.Boletos.frmBoletoVisualizar(id_conta_receber);

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fBoletoVisualiza.MdiParent = this;
                fBoletoVisualiza.Show();
            }
            else
                fBoletoVisualiza.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        #endregion

        private void gvFinanceiroBoleto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                if(Convert.ToBoolean(gvFinanceiroBoleto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value) == false)
                    gvFinanceiroBoleto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                else
                    gvFinanceiroBoleto.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
            }
        }

        private void btGerarArquivoRemessa_Click(object sender, EventArgs e)
        {            
            List<financeiro_boleto> boletosFinanceiro = new List<financeiro_boleto>();

            for (int i = 0; i < gvFinanceiroBoleto.Rows.Count; i++)
            {
                bool chk = Convert.ToBoolean(gvFinanceiroBoleto.Rows[i].Cells[0].Value);
                long id_conta_receber = Convert.ToInt64(gvFinanceiroBoleto.Rows[i].Cells[1].Value);
                
                if (chk)
                    boletosFinanceiro.Add(cFinanceiroBoleto.GetBoletoByIdContaReceber(id_conta_receber));
            }

            IEnumerable<long> ids_conta_corrente = boletosFinanceiro.Select(o => o.id_financeiro_conta_corrente).Distinct();

            foreach(var id_conta in ids_conta_corrente)
            {
                var grupoBoletos = boletosFinanceiro.Where(o => o.id_financeiro_conta_corrente == id_conta);
                TipoArquivo tipo = new TipoArquivo();

                BoletoNet.Boletos boletosNet = new BoletoNet.Boletos();
                
                int count = 0;
                foreach (var b in grupoBoletos)
                {
                    if (b.financeiro_conta_corrente.boleto_cnab != null)
                    {
                        if (b.financeiro_conta_corrente.boleto_cnab == 240)
                            tipo = TipoArquivo.CNAB240;
                        if (b.financeiro_conta_corrente.boleto_cnab == 400)
                            tipo = TipoArquivo.CNAB400;
                    }

                    boletosNet.Add(cFinanceiroBoleto.ToBoleto(b));
                    count++;
                    if (count > 100)
                    {
                        GerarArquivoRemessa(boletosNet[0].Banco, boletosNet[0].Cedente, boletosNet, tipo);
                        boletosNet = new BoletoNet.Boletos();
                        count = 0;
                    }
                }
                GerarArquivoRemessa(boletosNet[0].Banco, boletosNet[0].Cedente, boletosNet, tipo); 
            }
        }

        private void btProcessarArquivoRetorno_Click(object sender, EventArgs e)
        {
            if (txtContaCorrente.Tag == null)
            {
                txtContaCorrente.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtContaCorrente, "Campo fornecedor é obrigatório.");
                return;
            }
            else
                txtContaCorrente.BackColor = DefaultBackColor;
            
            ofdRetorno.FileName = "";
            ofdRetorno.Title = "Selecione um arquivo de retorno";
            ofdRetorno.Filter = "Arquivos de Retorno (*.ret)|*.ret|Todos Arquivos (*.*)|*.*";
            if (ofdRetorno.ShowDialog() == DialogResult.OK)
            {
                financeiro_conta_corrente cc = (financeiro_conta_corrente)txtContaCorrente.Tag;

                Banco bco = new Banco(cc.financeiro_banco.codigo);
                Stream stArq = ofdRetorno.OpenFile();

                if (cc.boleto_cnab == 400)
                    LerCNAB400(bco, stArq);
                if (cc.boleto_cnab == 240)
                    LerCNAB240(bco, stArq);
            }

        }

        private void LerCNAB400(Banco bco, Stream stArq)
        {
            ArquivoRetornoCNAB400 cnab400 = new ArquivoRetornoCNAB400();
            cnab400.LinhaDeArquivoLida += new EventHandler<LinhaDeArquivoLidaArgs>(cnab_LinhaDeArquivoLida);
            cnab400.LerArquivoRetorno(bco, stArq);
        }

        void cnab_LinhaDeArquivoLida(object sender, LinhaDeArquivoLidaArgs e)
        {
            if (e.TipoLinha == EnumTipodeLinhaLida.HeaderDeLote)
            {
                var detalhe = e.Detalhe;
            }

            // NumeroDocumento é o codigo da venda / parcela
            //long numero_documento = Convert.ToInt64(detalhe.NumeroDocumento.Trim());

            //var conta_receber = cFinanceiroContaReceber.GetFinanceiroContaReceberByID(numero_documento);
            //var boleto = cFinanceiroBoleto.GetBoletoByIdContaReceber(numero_documento);

            //if (string.IsNullOrEmpty(detalhe.Erros.Trim()))
            //{
            //    conta_receber.valor_pagamento = Convert.ToDecimal(detalhe.ValorPago);
            //    conta_receber.data_pagamento = detalhe.DataLiquidacao;
            //}
            //Console.WriteLine("Nº Documento: " + detalhe.NumeroDocumento);
            //Console.WriteLine("Codigo Ocorrencia: " + detalhe.CodigoOcorrencia);
            //Console.WriteLine("Erros: " + detalhe.Erros);
            //Console.WriteLine("Motivo Codigo Ocorrencia: " + detalhe.MotivoCodigoOcorrencia);
            //Console.WriteLine("Motivos Rejeicao: " + detalhe.MotivosRejeicao);

            //Console.WriteLine("___________________________________________");
        }

        private void LerCNAB240(Banco bco, Stream stArq)
        {
            ArquivoRetornoCNAB240 cnab240 = new ArquivoRetornoCNAB240();
            cnab240.LinhaDeArquivoLida += new EventHandler<LinhaDeArquivoLidaArgs>(cnab_LinhaDeArquivoLida);
            cnab240.LerArquivoRetorno(bco, stArq);
        }
        
        private void GerarArquivoRemessa(IBanco banco, Cedente cedente, BoletoNet.Boletos boletosNet, TipoArquivo tipo)
        {
            string arquivo_nome = string.Empty;
            arquivo_nome = Util.Util.GetDataServidor().ToString("ddMMyyyyHHmmss") + "_" + boletosNet.Count;
            
            sfdRemessa.FileName = arquivo_nome + ".rem";
            sfdRemessa.Filter = "Arquivos de Remessa (*.rem)|*.rem|Todos Arquivos (*.*)|*.*";
            
            if (sfdRemessa.ShowDialog() == DialogResult.OK)
            {
                ArquivoRemessa arquivo = new ArquivoRemessa(tipo);
                arquivo.GerarArquivoRemessa("0", banco, cedente, boletosNet, sfdRemessa.OpenFile(), 1);

                MessageBox.Show("Arquivo gerado com sucesso!", "Arquivo Remessa",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
        
        CheckBox chkTodos;
        void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < this.gvFinanceiroBoleto.RowCount; j++)
            {
                this.gvFinanceiroBoleto[0, j].Value = this.chkTodos.Checked;
            }
            this.gvFinanceiroBoleto.EndEdit();

         }

        private void frmBoletoList_Load(object sender, EventArgs e)
        {
            chkTodos = new CheckBox();
            //Get the column header cell bounds
            Rectangle rect =
                this.gvFinanceiroBoleto.GetCellDisplayRectangle(-1, -1, true);

            chkTodos.Size = new Size(14, 14);
            //Change the location of the CheckBox to make it stay on the header
            chkTodos.Location = new Point(rect.Location.X + 3, rect.Location.Y + 3);

            chkTodos.CheckedChanged += new EventHandler(chkTodos_CheckedChanged);
            //Add the CheckBox into the DataGridView
            this.gvFinanceiroBoleto.Controls.Add(chkTodos);
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btImprimir_Click(object sender, EventArgs e)
        {
            List<long> boletosFinanceiro = new List<long>();

            for (int i = 0; i < gvFinanceiroBoleto.Rows.Count; i++)
            {
                bool chk = Convert.ToBoolean(gvFinanceiroBoleto.Rows[i].Cells[0].Value);
                long id_conta_receber = Convert.ToInt64(gvFinanceiroBoleto.Rows[i].Cells[1].Value);

                if (chk)
                    boletosFinanceiro.Add(id_conta_receber);
            }

            cms.Modulos.Financeiro.Forms.Boletos.frmBoletoVisualizar fBoletoVisualizar = new Boletos.frmBoletoVisualizar(boletosFinanceiro.ToArray());

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fBoletoVisualizar.MdiParent = this;
                fBoletoVisualizar.Show();
            }
            else
                fBoletoVisualizar.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

    }
}
