using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;

namespace cms.Modulos.Financeiro.Forms.Tabelas.CondicaoPagamento
{
    public partial class frmFinanceiroCondicaoPagamento : cms.Modulos.Util.WindowBase
    {
        private financeiro_condicao_pagamento financeiro_condicao_pagamento = new financeiro_condicao_pagamento();
        cms.Modulos.Financeiro.Cn.cnFinanceiroCondicaoPagamento cFinanceiroCondicaoPagamento = new cms.Modulos.Financeiro.Cn.cnFinanceiroCondicaoPagamento();

        public Util.Acao Acao { get; set; }
        public long id_financeiro_condicao_pagamento { get; set; }

        public frmFinanceiroCondicaoPagamento()
        {
            InitializeComponent();
        }
        
        private void frmFinanceiroCondicaoPagamento_Load(object sender, EventArgs e)
        {
            if (this.Acao == Util.Acao.Cadastrar)
                this.TelaModoCadastrarNovo();
            else if (this.Acao == Util.Acao.Editar)
                this.TelaModoEditar();
            else if (this.Acao == Util.Acao.Visualizar)
                this.TelaModoVisualizar();
        }

        #region Modo de Tela
        private void TelaModoCadastrarNovo()
        {
            this.financeiro_condicao_pagamento = new financeiro_condicao_pagamento();
            this.Text = "Condição de Pagamento - Cadastrar nova condição de pagamento";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);

            txtCodigo.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;
            txtDataCadastro.Text = Util.Util.GetDataServidor().ToString("dd/MM/yyyy");

            gvParcelas.Rows.Clear();
            txtQtdParcelas.Text = "1";
            gvParcelas.Rows.Add("1 º", "1", "100,00");
            txtAcrecimo.Text = "0,00";
            
            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            gvParcelas.Columns[0].ReadOnly = true;
            gvParcelas.Columns[1].ReadOnly = false;
            gvParcelas.Columns[2].ReadOnly = false;
        }
        private void TelaModoEditar()
        {
            this.Text = "Condição de Pagamento - Editar cadastro da condição de pagamento";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            
            txtCodigo.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;

            gvParcelas.Columns[0].ReadOnly = true;
            gvParcelas.Columns[1].ReadOnly = false;
            gvParcelas.Columns[2].ReadOnly = false;
        }
        private void TelaModoVisualizar()
        {
            this.financeiro_condicao_pagamento = cFinanceiroCondicaoPagamento.GetFinanceiroCondicaoPagamentoByID(id_financeiro_condicao_pagamento);

            if(financeiro_condicao_pagamento == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de condição de pagamento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }

            this.Text = "Condição de Pagamento - Visualizar cadastro de condição de pagamento";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();
            
            PreencherParcelas();

            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            TravaFormControles(this.Controls);

            txtCodigo.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;
            
            gvParcelas.Columns[0].ReadOnly = true;
            gvParcelas.Columns[1].ReadOnly = true;
            gvParcelas.Columns[2].ReadOnly = true;
        }
        #endregion

        #region Menu Ação
        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            if (this.Acao == Util.Acao.Editar)
                this.TelaModoVisualizar();
        }

        private void btGravar_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (FormIsValid)
                PreencherCondicaoPagamento();

            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    financeiro_condicao_pagamento.data_cadastro = Util.Util.GetDataServidor();
                    if (cFinanceiroCondicaoPagamento.FinanceiroCondicaoPagamentoCadastrar(ref financeiro_condicao_pagamento))
                    {
                        this.id_financeiro_condicao_pagamento = financeiro_condicao_pagamento.id_financeiro_condicao_pagamento;

                        cFinanceiroCondicaoPagamento.FinanceiroCondicaoPagamentoParcelaExcluir(financeiro_condicao_pagamento);
                        gvParcelas.EndEdit();

                        for (int i = 0; i < gvParcelas.Rows.Count; i++)
                        {
                            financeiro_condicao_pagamento_parcela parcela = new financeiro_condicao_pagamento_parcela();
                            parcela.id_financeiro_condicao_pagamento = id_financeiro_condicao_pagamento;
                            parcela.numero_parcela = (i + 1);
                            parcela.porcentagem = Convert.ToDecimal(gvParcelas.Rows[i].Cells[2].Value);
                            parcela.dias = Convert.ToInt32(gvParcelas.Rows[i].Cells[1].Value);
                            
                            cFinanceiroCondicaoPagamento.FinanceiroCondicaoPagamentoParcelaCadastrar(ref parcela);
                        }

                        TelaModoVisualizar();
                    }
                    else
                    {
                        MessageBox.Show(null, "Não foi possivel cadastrar a condição de pagamento!", "Erro ao cadastrar condição de pagamento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cFinanceiroCondicaoPagamento.FinanceiroCondicaoPagamentoEditar(ref financeiro_condicao_pagamento))
                    {
                        cFinanceiroCondicaoPagamento.FinanceiroCondicaoPagamentoParcelaExcluir(financeiro_condicao_pagamento);
                        gvParcelas.EndEdit();

                        for (int i = 0; i < gvParcelas.Rows.Count; i++)
                        {
                            financeiro_condicao_pagamento_parcela parcela = new financeiro_condicao_pagamento_parcela();
                            parcela.id_financeiro_condicao_pagamento = id_financeiro_condicao_pagamento;
                            parcela.numero_parcela = (i + 1);
                            parcela.porcentagem = Convert.ToDecimal(gvParcelas.Rows[i].Cells[2].Value);
                            parcela.dias = Convert.ToInt32(gvParcelas.Rows[i].Cells[1].Value);

                            cFinanceiroCondicaoPagamento.FinanceiroCondicaoPagamentoParcelaCadastrar(ref parcela);
                        }

                        TelaModoVisualizar();
                    }
                    else
                        MessageBox.Show(null, "Não foi possivel editar o condição de pagamento!", "Erro ao cadastrar condição da pagmento.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o condição de pagamento: " + financeiro_condicao_pagamento.descricao + "!", "Cadastro de condição de pagamento.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                financeiro_condicao_pagamento.excluido = true;
                if (cFinanceiroCondicaoPagamento.FinanceiroCondicaoPagamentoEditar(ref financeiro_condicao_pagamento))
                    TelaModoCadastrarNovo();
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            DestravaFormControles(this.Controls);
            txtDataCadastro.ReadOnly = true;
            TelaModoEditar();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtDataCadastro.ReadOnly = true;
            TelaModoCadastrarNovo();
        }

        private void PreencherCondicaoPagamento()
        {
            this.financeiro_condicao_pagamento.descricao = txtDescricao.Text;
            this.financeiro_condicao_pagamento.acrecimo = Convert.ToDecimal(txtAcrecimo.Text);

            this.financeiro_condicao_pagamento.quantidade_parcelas = Convert.ToInt32(txtQtdParcelas.Text);
            this.financeiro_condicao_pagamento.pedido_compra = chkCompra.Checked;
            this.financeiro_condicao_pagamento.pedido_venda_orcamento = chkVendaOrcamento.Checked;
            this.financeiro_condicao_pagamento.pdv = chkPDV.Checked;
            this.financeiro_condicao_pagamento.web = chkWeb.Checked;
        }
        private void PreencherCampos()
        {
            txtCodigo.Text = this.financeiro_condicao_pagamento.id_financeiro_condicao_pagamento.ToString();
            txtDescricao.Text = this.financeiro_condicao_pagamento.descricao;
            txtDataCadastro.Text = this.financeiro_condicao_pagamento.data_cadastro.ToString("dd/MM/yyyy");
            txtAcrecimo.Text = string.Format("{0:n}", this.financeiro_condicao_pagamento.acrecimo);
            
            chkCompra.Checked = this.financeiro_condicao_pagamento.pedido_compra;
            chkVendaOrcamento.Checked = this.financeiro_condicao_pagamento.pedido_venda_orcamento;
            chkPDV.Checked = this.financeiro_condicao_pagamento.pdv;
            chkWeb.Checked = this.financeiro_condicao_pagamento.web;

            if (this.financeiro_condicao_pagamento.financeiro_condicao_pagamento_parcela.Count > 0)
                txtQtdParcelas.Text = this.financeiro_condicao_pagamento.financeiro_condicao_pagamento_parcela.Count.ToString();
            else
                txtQtdParcelas.Text = "1";
        }
        #endregion

        #region Validação de Formulario
        private void ValidForm()
        {
            this.FormIsValid = true;
            bool erro = false;

            if (txtDescricao.Text == "")
            {
                this.ValidarForm.SetToolTip(this.txtDescricao, "Campo descrição é obrigatório.");
                txtDescricao.BackColor = CorCampoInvalido;
                erro = true;
            }
            else
                txtDescricao.BackColor = DefaultBackColor;


            if (erro)
                this.FormIsValid = false;
        }
        #endregion

        #region # Parcelas #
        
        private void gvParcelas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int dias = 0;
            decimal rateio = 0;

            if (e.ColumnIndex == 1)
                if (int.TryParse(gvParcelas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out dias))
                    gvParcelas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dias;
            
            if (e.ColumnIndex == 2)
                if (decimal.TryParse(gvParcelas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out rateio))
                    gvParcelas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = rateio;
        }

        private void gvParcelas_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            int dias = 0;
            decimal rateio = 0;

            if (e.ColumnIndex == 1)
                if (!int.TryParse(gvParcelas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out dias))
                {
                    e.Cancel = true;
                }
                else
                {
                    if(dias == 0)
                        e.Cancel = true;
                }

            if (e.ColumnIndex == 2)
                if (!decimal.TryParse(gvParcelas.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out rateio))
                    e.Cancel = true;
        }

        private void PreencherParcelas()
        {
            gvParcelas.Rows.Clear();

            foreach (var i in financeiro_condicao_pagamento.financeiro_condicao_pagamento_parcela.OrderBy(o=>o.numero_parcela))
            {
                gvParcelas.Rows.Add(i.numero_parcela + " º", i.dias, string.Format("{0:n}", i.porcentagem));
            }
        }

        private void txtQtdParcelas_Validating(object sender, CancelEventArgs e)
        {
            if (int.Parse(txtQtdParcelas.Text) == 0)
                e.Cancel = true;

            gvParcelas.Rows.Clear();

            decimal porcentagem = 100;
            porcentagem = (porcentagem / int.Parse(txtQtdParcelas.Text));

            for (int i = 0; i < int.Parse(txtQtdParcelas.Text); i++)
            {
                gvParcelas.Rows.Add((i + 1) + " º", (30 * (i + 1)), string.Format("{0:n}", porcentagem));
            }
        }

        #endregion




    }
}
