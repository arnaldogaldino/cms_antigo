using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;

namespace cms.Modulos.Financeiro.Forms.ContasPagar
{
    public partial class frmFinanceiroContasPagarDuplicar : cms.Modulos.Util.WindowBase
    {
        private financeiro_conta_pagar conta_pagar = new financeiro_conta_pagar();
        cms.Modulos.Financeiro.Cn.cnFinanceiroContaPagar cFinanceiroContaPagar = new cms.Modulos.Financeiro.Cn.cnFinanceiroContaPagar();

        public void SetContaPagar(financeiro_conta_pagar conta)
        {
            conta_pagar = conta;
            txtValorParcela.Text = string.Format("{0:n}", conta_pagar.valor_vencimento.Value);
        }

        public frmFinanceiroContasPagarDuplicar()
        {
            InitializeComponent();
        }

        private void btPreview_Click(object sender, EventArgs e)
        {
            decimal valor_total = 0;
            decimal valor_parcela = 0;
            decimal qtd_parcela = 0;
            int intervalo = 0;

            valor_total = decimal.Parse(txtValorTotal.Text);
            valor_parcela = decimal.Parse(txtValorParcela.Text);
            qtd_parcela = int.Parse(txtQtdParcelas.Text);
            intervalo = int.Parse(txtIntervaloDias.Text);

            List<Parcelas> parcelamento = new List<Parcelas>();

            for (int i = 1; i <= qtd_parcela; i++)
            {
                DateTime data = conta_pagar.data_vencimento;

                data = data.AddDays(i * intervalo);
                Parcelas p = new Parcelas(i, data, valor_parcela);
                parcelamento.Add(p);
            }

            gvParcelas.DataSource = parcelamento;
            gvParcelas.Refresh();
        }

        private void txtValorParcela_Leave(object sender, EventArgs e)
        {
            decimal valor_total = 0;
            decimal valor_parcela = 0;
            decimal qtd_parcela = 0;

            valor_total = decimal.Parse(txtValorTotal.Text);
            valor_parcela = decimal.Parse(txtValorParcela.Text);
            qtd_parcela = int.Parse(txtQtdParcelas.Text);

            valor_total = valor_parcela * qtd_parcela;

            txtValorTotal.Text = string.Format("{0:n}", valor_total);
            txtValorParcela.Text = string.Format("{0:n}", valor_parcela);
            txtQtdParcelas.Text = qtd_parcela.ToString();
        }

        private void txtQtdParcelas_Leave(object sender, EventArgs e)
        {
            decimal valor_total = 0;
            decimal valor_parcela = 0;
            decimal qtd_parcela = 0;

            valor_total = decimal.Parse(txtValorTotal.Text);
            valor_parcela = decimal.Parse(txtValorParcela.Text);
            qtd_parcela = int.Parse(txtQtdParcelas.Text);

            valor_total = valor_parcela * qtd_parcela;

            txtValorTotal.Text = string.Format("{0:n}", valor_total);
            txtValorParcela.Text = string.Format("{0:n}", valor_parcela);
            txtQtdParcelas.Text = qtd_parcela.ToString();
        }

        private void processar_parcelas()
        {
            decimal valor_total = 0;
            decimal valor_parcela = 0;
            decimal qtd_parcela = 0;

            valor_total = decimal.Parse(txtValorTotal.Text);
            valor_parcela = decimal.Parse(txtValorParcela.Text);
            qtd_parcela = int.Parse(txtQtdParcelas.Text);
        }

        public class Parcelas
        {
            private int num_parcela = 0;

            public int Parcela
            {
                get { return num_parcela; }
                set { num_parcela = value; }
            }
            private DateTime data_parcela = new DateTime();

            public DateTime Data
            {
                get { return data_parcela; }
                set { data_parcela = value; }
            }
            private decimal valor_parcela = 0;

            public decimal Valor
            {
                get { return valor_parcela; }
                set { valor_parcela = value; }
            }

            public Parcelas()
            { }


            public Parcelas(int p, DateTime d, decimal v)
            {
                valor_parcela = v;
                data_parcela = d;
                num_parcela = p;
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gvParcelas.Rows.Count; i++)
            {
                financeiro_conta_pagar nova_conta_pagar = new financeiro_conta_pagar();
                Parcelas parc = (Parcelas)gvParcelas.Rows[i].DataBoundItem;

                nova_conta_pagar.data_cadastro = Util.Util.GetDataServidor();
                nova_conta_pagar.data_lancamento = null;
                nova_conta_pagar.data_pagamento = null;
                nova_conta_pagar.data_vencimento = parc.Data;
                nova_conta_pagar.id_empresa = conta_pagar.id_empresa;
                nova_conta_pagar.descricao = conta_pagar.descricao;
                nova_conta_pagar.documento = conta_pagar.documento;
                nova_conta_pagar.excluido = conta_pagar.excluido;
                nova_conta_pagar.id_compra = conta_pagar.id_compra;
                nova_conta_pagar.id_financeiro_conta_corrente = conta_pagar.id_financeiro_conta_corrente;
                nova_conta_pagar.id_financeiro_forma_pagamento = conta_pagar.id_financeiro_forma_pagamento;
                nova_conta_pagar.id_fornecedor = conta_pagar.id_fornecedor;
                nova_conta_pagar.id_financeiro_plano_conta = conta_pagar.id_financeiro_plano_conta;
                nova_conta_pagar.observacao = conta_pagar.observacao;
                nova_conta_pagar.valor_pagamento = null;
                nova_conta_pagar.valor_vencimento = parc.Valor;

                cFinanceiroContaPagar.FinanceiroContaPagarCadastrar(ref nova_conta_pagar);
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }
    }
}
