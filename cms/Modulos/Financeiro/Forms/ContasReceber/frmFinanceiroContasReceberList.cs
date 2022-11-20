using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using cms.Data;

namespace cms.Modulos.Financeiro.Forms.ContasReceber
{
    public partial class frmFinanceiroContasReceberList : cms.Modulos.Util.WindowBase
    {
        private DateTime data_atual = new DateTime();
        cms.Modulos.Financeiro.Cn.cnFinanceiroContaReceber cFinanceiroContaReceber = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaReceber();

        IQueryable<vw_financeiro_conta_receber> conta_recebers;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();

        public frmFinanceiroContasReceberList()
        {
            InitializeComponent();
        }
        
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

        private void btFormaPagamento_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.Tabelas.FormaPagamento.frmFinanceiroFormaPagamentoLockup fFormaPagamentoLockup = new cms.Modulos.Financeiro.Forms.Tabelas.FormaPagamento.frmFinanceiroFormaPagamentoLockup();

            if (fFormaPagamentoLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var forma_pagamento = fFormaPagamentoLockup.GetFormaPagamentoSelecionado();

                txtFormaPagamento.Tag = forma_pagamento;
                txtFormaPagamento.Text = forma_pagamento.nome;

                fFormaPagamentoLockup.Close();
                fFormaPagamentoLockup.Dispose();
            }
            else
            {
                txtFormaPagamento.Tag = null;
                txtFormaPagamento.Text = string.Empty;
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

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.ContasReceber.frmFinanceiroContasReceber fContasReceber = new cms.Modulos.Financeiro.Forms.ContasReceber.frmFinanceiroContasReceber();

            fContasReceber.Acao = Util.Acao.Cadastrar;
            fContasReceber.Tag = this.Tag;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fContasReceber.MdiParent = this;
                fContasReceber.Show();
            }
            else
                fContasReceber.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void gvFinanceiroContasReceber_DoubleClick(object sender, EventArgs e)
        {
            if (gvFinanceiroContasReceber.CurrentRow == null)
                return;

            financeiro_conta_receber ContasReceber = new financeiro_conta_receber();

            try
            {
                ContasReceber = cFinanceiroContaReceber.GetFinanceiroContaReceberByID(long.Parse(gvFinanceiroContasReceber.CurrentRow.Cells[1].Value.ToString()));
            }
            catch { }

            cms.Modulos.Financeiro.Forms.ContasReceber.frmFinanceiroContasReceber fContaReceber = new cms.Modulos.Financeiro.Forms.ContasReceber.frmFinanceiroContasReceber();
            fContaReceber.Tag = this.Tag;

            fContaReceber.id_contas_receber = ContasReceber.id_financeiro_conta_receber;
            fContaReceber.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fContaReceber.MdiParent = this;
                fContaReceber.Show();
            }
            else
                fContaReceber.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }

            load.btCancelar.Click += new EventHandler(btCancelar_Click);
            load.LoadShow(this);

            threadPreencherGrid = new Thread(AtualizarGvContaReceber);
            threadPreencherGrid.IsBackground = true;
            threadPreencherGrid.Start();
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

        private void AtualizarGvContaReceber()
        {
            gvFinanceiroContasReceber.AutoGenerateColumns = false;

            long? id_conta_receber = null;
            long? id_conta_corrente = null;
            long? id_forma_pagamento = null;
            long? id_cliente = null;
            long? id_empresa = null;
           
            DateTime? data_vencimento_de = null;
            DateTime? data_vencimento_ate = null;
            DateTime? data_pagamento_de = null;
            DateTime? data_pagamento_ate = null;
            
            bool chk_data_vencimento_de = false;
            bool chk_data_vencimento_ate = false;
            bool chk_data_pagamento_de = false;
            bool chk_data_pagamento_ate = false;

            string documento = string.Empty;

            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_conta_receber = long.Parse(txtCodigo.Text);
            
            if (ctrlFilial.InvokeRequired)
                if (!string.IsNullOrEmpty(ctrlFilial.GetSelectedValue()))
                    id_empresa = long.Parse(ctrlFilial.GetSelectedValue());

            if (txtDocumento.InvokeRequired)
                if (!string.IsNullOrEmpty(txtDocumento.Text))
                    documento = txtDocumento.Text;

            if (txtContaCorrente.InvokeRequired)
                if (txtContaCorrente.Tag != null)
                    id_conta_corrente = ((financeiro_conta_corrente)txtContaCorrente.Tag).id_financeiro_conta_corrente;

            if (txtFormaPagamento.InvokeRequired)
                if (txtFormaPagamento.Tag != null)
                    id_forma_pagamento = ((financeiro_forma_pagamento)txtFormaPagamento.Tag).id_financeiro_forma_pagamento;

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
                conta_recebers = cFinanceiroContaReceber.FinanceiroContaReceberProcurar(id_conta_receber, id_empresa, id_cliente, id_forma_pagamento, id_conta_corrente, documento, data_vencimento_de, data_vencimento_ate, data_pagamento_de, data_pagamento_ate);
            }
            catch { }

            if (gvFinanceiroContasReceber.InvokeRequired)
                gvFinanceiroContasReceber.Invoke(new MethodInvoker(Preencher));
        }

        public void Preencher()
        {
            data_atual = Util.Util.GetDataServidor();
            gvFinanceiroContasReceber.AutoGenerateColumns = false;
            gvFinanceiroContasReceber.DataSource = conta_recebers;
            gvFinanceiroContasReceber.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        private void txtContaCorrente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btContaCorrente_Click(sender, e);
            }
        }

        private void txtFormaPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btFormaPagamento_Click(sender, e);
            }
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCliente_Click(sender, e);
            }
        }

        private void gvFinanceiroContasReceber_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewRow row = gvFinanceiroContasReceber.Rows[e.RowIndex];
            
            // Traja linha de contas em atrazo que ainda não quitadas.
            if (e.ColumnIndex == 6 && (DateTime)e.Value < data_atual && row.Cells[8].Value == null && row.Cells[10].Value == null)
            {
                row.DefaultCellStyle.ForeColor = Color.White;
                row.DefaultCellStyle.BackColor = Color.Crimson;
            }

            // Traja linha de contas quitadas.
            if (row.Cells[8].Value != null && row.Cells[10].Value == null)
            {
                row.DefaultCellStyle.ForeColor = Color.White;
                row.DefaultCellStyle.BackColor = Color.SteelBlue;
            }

            // Traja linha de contas não quitadas com vencimento hoje.
            if (e.ColumnIndex == 6 && ((DateTime)e.Value).ToString("dd/MM/yyyy") == data_atual.ToString("dd/MM/yyyy") && row.Cells[8].Value == null && row.Cells[10].Value == null)
            {
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.BackColor = Color.Gold;
            }

            // Traja linha de contas lançadas.
            if (row.Cells[10].Value != null)
            {
                row.DefaultCellStyle.ForeColor = Color.White;
                row.DefaultCellStyle.BackColor = Color.Navy;
            }

            foreach (DataGridViewCell cell in row.Cells)
            {
                if (e.ColumnIndex == 6 && (DateTime)e.Value < data_atual && row.Cells[8].Value == null && row.Cells[10].Value == null)
                    cell.ToolTipText = "Conta com vencimento em atrazo há " + ((((DateTime)e.Value).Day - data_atual.Day) * -1) + " dias.";
                if (row.Cells[8].Value != null && row.Cells[10].Value == null)
                    cell.ToolTipText = "Conta quitada.";
                if (row.Cells[10].Value != null)
                    cell.ToolTipText = "Conta lançada em " + ((DateTime)row.Cells[10].Value).ToString("dd/MM/yyyy") + ".";
            }

        }

        CheckBox chkTodos;
        void chkTodos_CheckedChanged(object sender, EventArgs e)
        {
            for (int j = 0; j < this.gvFinanceiroContasReceber.RowCount; j++)
            {
                this.gvFinanceiroContasReceber[0, j].Value = this.chkTodos.Checked;
            }
            this.gvFinanceiroContasReceber.EndEdit();
        }

        private void frmFinanceiroContasReceberList_Load(object sender, EventArgs e)
        {
            chkTodos = new CheckBox();
            //Get the column header cell bounds
            Rectangle rect =
                this.gvFinanceiroContasReceber.GetCellDisplayRectangle(-1, -1, true);

            chkTodos.Size = new Size(14, 14);
            //Change the location of the CheckBox to make it stay on the header
            chkTodos.Location = new Point(rect.Location.X + 3, rect.Location.Y + 3);

            chkTodos.CheckedChanged += new EventHandler(chkTodos_CheckedChanged);
            //Add the CheckBox into the DataGridView
            this.gvFinanceiroContasReceber.Controls.Add(chkTodos);
        }

        private void btGerarBoleto_Click(object sender, EventArgs e)
        {
            List<long> ids = new List<long>();

            for (int j = 0; j < this.gvFinanceiroContasReceber.RowCount; j++)
            {
                if (Convert.ToBoolean(this.gvFinanceiroContasReceber[0, j].Value.ToString()) == true)
                {
                    if(this.gvFinanceiroContasReceber[1, j].Value != null)
                        if (this.gvFinanceiroContasReceber[4, j].Value.ToString() == "Boleto")
                            ids.Add(Convert.ToInt64(this.gvFinanceiroContasReceber[1, j].Value.ToString()));
                }
            }

            cms.Modulos.Financeiro.Forms.Boletos.frmBoletoVisualizar fBoletoVisualizar = new Boletos.frmBoletoVisualizar(ids.ToArray());

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
