using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;
using cms.Modulos.Compra.Cn;

namespace cms.Modulos.Compra.Forms
{
    public partial class frmCompraPagamento : Util.WindowBase
    {
        public long id_compra = 0;

        private compra oCompra = new compra();
        private cnCompra cCompra = new cnCompra();
        private vw_compra_item compra_item = null;

        public frmCompraPagamento()
        {
            InitializeComponent();
        }

        public void AtualizarCampos()
        {
            oCompra = cCompra.GetCompraByID(id_compra);

            txtCodigo.Text = oCompra.id_compra.ToString();
            txtDataCadastro.Text = oCompra.data_cadastro.ToString("dd/MM/yyyy");
            txtFornecedor.Text = oCompra.id_fornecedor + " - " + oCompra.fornecedor.nome_fantasia;
            txtObservacao.Text = oCompra.observacao;
            txtObservacaoComprador.Text = oCompra.observacao_comprador;
            txtTotal.Text = string.Format("{0:n}", oCompra.compra_item.Where(o => o.conferido == true).Sum(o => o.quantidade_recebida * o.valor_unitario - o.valor_desconto));

            if (oCompra.financeiro_condicao_pagamento != null)
            {
                txtCondicoesPagamento.Text = oCompra.financeiro_condicao_pagamento.id_financeiro_condicao_pagamento + " - " + oCompra.financeiro_condicao_pagamento.descricao;
                txtCondicoesPagamento.Tag = oCompra.financeiro_condicao_pagamento;
            }

            if (oCompra.status == "Finalizada")
            {
                gvPagamentos.Columns[5].ReadOnly = true;
                gvPagamentos.Columns[6].ReadOnly = true;
                gvPagamentos.Columns[7].ReadOnly = true;
                gvPagamentos.Columns[8].ReadOnly = true;
                
                btCondicoesPagamento.Enabled = false;
            }
        }

        private void frmCompraPagamento_Load(object sender, EventArgs e)
        {
            AtualizarCampos();
            AtualizarGrid();
        }

        private void btCondicoesPagamento_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.Tabelas.CondicaoPagamento.frmFinanceiroCondicaoPagamentoLockup fFinanceiroCondicaoPagamentoLockup = new cms.Modulos.Financeiro.Forms.Tabelas.CondicaoPagamento.frmFinanceiroCondicaoPagamentoLockup();

            if (fFinanceiroCondicaoPagamentoLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                cCompra.CompraPagamentoLimparByIdCompra(oCompra.id_compra);
                var condicao_pagamento = fFinanceiroCondicaoPagamentoLockup.GetCondicaoPagamentoSelecionado();

                txtCondicoesPagamento.Tag = condicao_pagamento;
                txtCondicoesPagamento.Text = condicao_pagamento.id_financeiro_condicao_pagamento + " - " + condicao_pagamento.descricao;

                fFinanceiroCondicaoPagamentoLockup.Close();
                fFinanceiroCondicaoPagamentoLockup.Dispose();

                decimal total = 0;

                decimal.TryParse(txtTotal.Text, out total);
                
                if(condicao_pagamento.acrecimo != null)
                    total = total + (total * (condicao_pagamento.acrecimo.Value / 100));
                
                DateTime data_vencimento = Util.Util.GetDataServidor();

                foreach (var p in condicao_pagamento.financeiro_condicao_pagamento_parcela)
                {
                    compra_pagamento pagamento = new compra_pagamento();

                    pagamento.id_compra = id_compra;
                    pagamento.numero_documento = "";
                    pagamento.valor = (total * (p.porcentagem / 100));

                    pagamento.data_vencimento = data_vencimento.AddDays(p.dias);

                    cCompra.CompraPagamentoCadastrar(pagamento);
                }
            }
            else
            {
                txtCondicoesPagamento.Tag = null;
                txtCondicoesPagamento.Text = string.Empty;
                cCompra.CompraPagamentoLimparByIdCompra(oCompra.id_compra);
            }

            AtualizarGrid();
        }

        private void txtCondicoesPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCondicoesPagamento_Click(sender, e);
            }            
        }

        private void AtualizarGrid()
        {
            var pagamentos = cCompra.GetCompraPagamentoIdCompra(id_compra);
            gvPagamentos.Rows.Clear();

            DataGridViewComboBoxColumn cbFormaPagamento = (DataGridViewComboBoxColumn)gvPagamentos.Columns["colFormaPagamento"];
            cbFormaPagamento.DataSource = Util.Combos.FormaPagamento();
            cbFormaPagamento.ValueMember = "value";
            cbFormaPagamento.DisplayMember = "display";
            
            decimal total = 0;

            foreach (var p in pagamentos)
            {
                string forma_pagamento = "";

                if (p.id_financeiro_forma_pagamento != null)
                    forma_pagamento = p.id_financeiro_forma_pagamento.Value.ToString();

                                      //id_compra_pagamento //id_compra  //id_financeiro_conta_pagar //id_forma_pagamento               //Código                   //Forma de Pagamento //Num. Doc        //Valor
                gvPagamentos.Rows.Add(p.id_compra_pagamento, p.id_compra, p.id_financeiro_conta_pagar, p.id_financeiro_forma_pagamento, p.id_financeiro_conta_pagar, forma_pagamento, p.numero_documento, string.Format("{0:n}", p.valor), p.data_vencimento.ToString("dd/MM/yyyy"));
                total += p.valor;
            }

            txtTotalParcelas.Text = string.Format("{0:n}", total);
        }

        private void frmCompraPagamento_FormClosing(object sender, FormClosingEventArgs e)
        {
            gvPagamentos.EndEdit();
            decimal total = 0;

            for (int i = 0; i < gvPagamentos.Rows.Count; i++)
            {
                compra_pagamento pagamento = new compra_pagamento();
                
                //id_compra_pagamento //id_compra  //id_financeiro_conta_pagar //id_forma_pagamento               //Código                   //Forma de Pagamento //Num. Doc        //Valor

                pagamento.id_compra = oCompra.id_compra;
                pagamento.id_compra_pagamento = long.Parse(gvPagamentos.Rows[i].Cells[0].Value.ToString());

                if (gvPagamentos.Rows[i].Cells[5].Value != null && !string.IsNullOrEmpty(gvPagamentos.Rows[i].Cells[5].Value.ToString()))
                {
                    pagamento.id_financeiro_forma_pagamento = long.Parse(gvPagamentos.Rows[i].Cells[5].Value.ToString());
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("Forma de pagamento esta inválida!", "Condições de Pagamento de Compra.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                pagamento.numero_documento = gvPagamentos.Rows[i].Cells[6].Value.ToString();
                pagamento.valor = decimal.Parse(gvPagamentos.Rows[i].Cells[7].Value.ToString());

                if (gvPagamentos.Rows[i].Cells[8].Value != null && !string.IsNullOrEmpty(gvPagamentos.Rows[i].Cells[8].Value.ToString()))
                {
                    pagamento.data_vencimento = DateTime.Parse(gvPagamentos.Rows[i].Cells[8].Value.ToString());
                }

                cCompra.CompraPagamentoEditar(ref pagamento);

                total += pagamento.valor;
            }
            
            if(txtCondicoesPagamento.Tag != null)
            {
                oCompra.id_financeiro_condicao_pagamento = ((financeiro_condicao_pagamento)txtCondicoesPagamento.Tag).id_financeiro_condicao_pagamento;
            }

            cCompra.CompraEditar(ref oCompra);

            txtTotalParcelas.Text = string.Format("{0:n}", total);

            if (decimal.Parse(txtTotal.Text) > decimal.Parse(txtTotalParcelas.Text))
            {
                MessageBox.Show("O valor total das parcelas não esta correspondendo com o total da compra!", "Condições de Pagamento de Compra.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
            }
        }

        private void gvPagamentos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal valor = 0;
            if (e.ColumnIndex == 7)
                if (decimal.TryParse(gvPagamentos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out valor))
                {
                    gvPagamentos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:n}", valor);
                    TotalizarParcelas();
                }
        }

        private void gvPagamentos_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal valor = 0;
            if (e.ColumnIndex == 7)
                if(!decimal.TryParse(e.FormattedValue.ToString(), out valor))
                    e.Cancel = true;

            DateTime data;
            if (e.ColumnIndex == 8)
                if (!DateTime.TryParse(e.FormattedValue.ToString(), out data))
                    e.Cancel = true;
        }

        private void TotalizarParcelas()
        {
            gvPagamentos.EndEdit();
            decimal total = 0;

            for (int i = 0; i < gvPagamentos.Rows.Count; i++)
            {
                total += decimal.Parse(gvPagamentos.Rows[i].Cells[7].Value.ToString());
            }

            txtTotalParcelas.Text = string.Format("{0:n}", total);
        }

    }
}
