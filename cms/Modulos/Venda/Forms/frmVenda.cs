using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;
using cms.Modulos.Venda.Cn;
using cms.Modulos.Produto.Cn;
using cms.Modulos.Fiscal.Cn;

namespace cms.Modulos.Venda.Forms
{
    public partial class frmVenda : cms.Modulos.Util.WindowBase
    {
        cnVenda cVenda = new cnVenda();
        private venda oVenda = new venda();
        private cnProduto cProduto = new cnProduto();

        public Util.Acao Acao { get; set; }
        public long id_venda { get; set; }

        public frmVenda()
        {
            InitializeComponent();
        }

        private void frmVenda_Load(object sender, EventArgs e)
        {
            gvStatus.AutoGenerateColumns = false;
            gvCondicaoPagamento.AutoGenerateColumns = false;
            gvItens.AutoGenerateColumns = false;

            cbStatusVenda.DataSource = Util.Combos.StatusVendaNovo();
            cbStatusVenda.Refresh();

            cbPorConta.DataSource = Util.Combos.FretePorConta();
            cbPorConta.Refresh();

            DataGridViewComboBoxColumn cbFormaPagamento = (DataGridViewComboBoxColumn)gvCondicaoPagamento.Columns["colFormaPagamento"];
            cbFormaPagamento.DataSource = Util.Combos.FormaPagamento();
            cbFormaPagamento.ValueMember = "value";
            cbFormaPagamento.DisplayMember = "display";
            cbFormaPagamento.DataPropertyName = "id_financeiro_forma_pagamento";

            if (this.Acao == Util.Acao.Cadastrar)
                this.TelaModoCadastrarNovo();
            else if (this.Acao == Util.Acao.Editar)
                this.TelaModoEditar();
            else if (this.Acao == Util.Acao.Visualizar)
                this.TelaModoVisualizar();
        }

        #region # Modo de Tela #
        private void TelaModoCadastrarNovo()
        {
            this.oVenda = new venda();
            this.Text = "Venda - Cadastrar novo pedido";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);

            txtCodigo.ReadOnly = true;
            txtCliente.ReadOnly = true;
            txtPrecoTabela.ReadOnly = true;
            txtClienteContato.ReadOnly = true;
            txtCondicaoPagamento.ReadOnly = true;
            txtNaturezaOperacao.ReadOnly = true;
            txtTransportadora.ReadOnly = true;
            txtCondicaoPagamento.ReadOnly = true;
            txtValorFrete.Text = "0,00";

            btCliente.Enabled = true;
            btContato.Enabled = true;
            btPrecoTabela.Enabled = true;
            btCondicaoPagamento.Enabled = true;
            btNaturezaOperacao.Enabled = true;
            btTransportadora.Enabled = true;
            btCopiarItens.Enabled = false;

            txtItens.ReadOnly = true;
            txtValorTotal.ReadOnly = true;
            txtTotalIcms.ReadOnly = true;
            txtTotalIPI.ReadOnly = true;
            txtTotalICMSST.ReadOnly = true;
            txtDesconto.ReadOnly = true;
            txtTotalPedido.ReadOnly = true;
            txtTotalPagar.ReadOnly = true;

            gvItens.Visible = false;
            gbTotais.Visible = false;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            cbStatusVenda.SelectedValue = "Pendente";
        }
        private void TelaModoEditar()
        {
            this.Text = "Venda - Editar cadastro do pedido";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);

            txtCodigo.ReadOnly = true;
            txtCliente.ReadOnly = true;
            txtPrecoTabela.ReadOnly = true;
            txtClienteContato.ReadOnly = true;
            txtCondicaoPagamento.ReadOnly = true;
            txtNaturezaOperacao.ReadOnly = true;
            txtTransportadora.ReadOnly = true;
            txtCondicaoPagamento.ReadOnly = true;

            btCliente.Enabled = false;
            btPrecoTabela.Enabled = false;
            btContato.Enabled = true;
            btCondicaoPagamento.Enabled = true;
            btNaturezaOperacao.Enabled = true;
            btTransportadora.Enabled = true;
            btCopiarItens.Enabled = false;

            txtItens.ReadOnly = true;
            txtValorTotal.ReadOnly = true;
            txtTotalIcms.ReadOnly = true;
            txtTotalIPI.ReadOnly = true;
            txtTotalICMSST.ReadOnly = true;
            txtDesconto.ReadOnly = true;
            txtTotalPedido.ReadOnly = true;
            txtTotalPagar.ReadOnly = true;

            gvItens.Visible = true;
            gbTotais.Visible = true;

            DataGridViewComboBoxColumn cbFormaPagamento = (DataGridViewComboBoxColumn)gvCondicaoPagamento.Columns["colFormaPagamento"];
            cbFormaPagamento.ReadOnly = false;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;

            PreencherStatus();
            AtualizarGridItens();

            gvItens.Columns["colIdVendaItem"].ReadOnly = true;
            gvItens.Columns["colFoto"].ReadOnly = true;
            gvItens.Columns["colCodigo"].ReadOnly = true;
            gvItens.Columns["colDescricao"].ReadOnly = true;
            gvItens.Columns["colQuantidade"].ReadOnly = false;
            gvItens.Columns["colQuantidadeConfirmada"].ReadOnly = true;
            gvItens.Columns["colPrecoUnitario"].ReadOnly = true;
            gvItens.Columns["colDesconto"].ReadOnly = false;
            gvItens.Columns["colValorTotal"].ReadOnly = true;
            gvItens.Columns["colQuantidadeEstoque"].ReadOnly = true;
            gvItens.Columns["colQuantidadeReservada"].ReadOnly = true;
            gvItens.Columns["colEstoqueAtual"].ReadOnly = true;
            
            Totalizar();
        }
        private void TelaModoVisualizar()
        {
            this.oVenda = cVenda.GetVendaByID(id_venda);
            if (this.oVenda == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de venda.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Venda - Visualizar cadastro do pedido";
            this.Acao = Util.Acao.Visualizar;

            DataGridViewComboBoxColumn cbFormaPagamento = (DataGridViewComboBoxColumn)gvCondicaoPagamento.Columns["colFormaPagamento"];
            cbFormaPagamento.ReadOnly = true;

            PreencherCampos();

            txtCodigo.ReadOnly = true;
            txtCliente.ReadOnly = true;
            txtPrecoTabela.ReadOnly = true;
            txtClienteContato.ReadOnly = true;
            txtCondicaoPagamento.ReadOnly = true;
            txtNaturezaOperacao.ReadOnly = true;
            txtTransportadora.ReadOnly = true;
            txtCondicaoPagamento.ReadOnly = true;
            
            btCliente.Enabled = false;
            btPrecoTabela.Enabled = false;
            btContato.Enabled = false;
            btCondicaoPagamento.Enabled = false;
            btNaturezaOperacao.Enabled = false;
            btTransportadora.Enabled = false;
            btCopiarItens.Enabled = true;

            txtCondicaoPagamento.ReadOnly = true;
            txtItens.ReadOnly = true;
            txtValorTotal.ReadOnly = true;
            txtTotalIcms.ReadOnly = true;
            txtTotalIPI.ReadOnly = true;
            txtTotalICMSST.ReadOnly = true;
            txtDesconto.ReadOnly = true;
            txtTotalPedido.ReadOnly = true;
            txtTotalPagar.ReadOnly = true;

            gvItens.Visible = true;
            gbTotais.Visible = true;

            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            TravaFormControles(this.Controls);
            PreencherStatus();
            AtualizarGridItens();

            gvItens.Columns["colIdVendaItem"].ReadOnly = true;
            gvItens.Columns["colFoto"].ReadOnly = true;
            gvItens.Columns["colCodigo"].ReadOnly = true;
            gvItens.Columns["colDescricao"].ReadOnly = true;
            gvItens.Columns["colQuantidade"].ReadOnly = true;
            gvItens.Columns["colQuantidadeConfirmada"].ReadOnly = true;
            gvItens.Columns["colPrecoUnitario"].ReadOnly = true;
            gvItens.Columns["colDesconto"].ReadOnly = true;
            gvItens.Columns["colValorTotal"].ReadOnly = true;
            gvItens.Columns["colQuantidadeEstoque"].ReadOnly = true;
            gvItens.Columns["colQuantidadeReservada"].ReadOnly = true;
            gvItens.Columns["colEstoqueAtual"].ReadOnly = true;

            Totalizar();
        }
        #endregion

        #region # Menu Ação #
        private void btNovo_Click(object sender, EventArgs e)
        {
            gvCondicaoPagamento.Rows.Clear();
            gvStatus.Rows.Clear();
            gvItens.Rows.Clear();

            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtCodigo.ReadOnly = true;
            TelaModoCadastrarNovo();
        }
        private void btEditar_Click(object sender, EventArgs e)
        {
            DestravaFormControles(this.Controls);
            txtCodigo.ReadOnly = true;
            TelaModoEditar();
        }
        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o pedido: " + oVenda.id_venda + "!", "Cadastro de pedido.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                oVenda.excluido = true;
                if (cVenda.VendaEditar(ref oVenda))
                    TelaModoCadastrarNovo();
            }
        }
        private void btGravar_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (FormIsValid)
                PreencherVenda();

            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    oVenda.data_cadastro = Util.Util.GetDataServidor();
                    oVenda.id_usuario_cadastro = Util.AuthEntity.UsuarioOnLine.id_usuario;
                    oVenda.id_empresa = Util.AuthEntity.EmpresaPadrao.id_empresa;

                    if (cVenda.VendaCadastrar(ref oVenda))
                    {
                        this.id_venda = oVenda.id_venda;
                        txtCodigo.Text = oVenda.id_venda.ToString();
                        GravarCondicaoPagamento();
                        GravarVendaItem();
                        TelaModoVisualizar();
                    }
                    else
                        MessageBox.Show(null, "Não foi possivel cadastrar o pedido!", "Erro ao cadastrar pedido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cVenda.VendaEditar(ref oVenda))
                    {
                        GravarCondicaoPagamento();
                        GravarVendaItem();
                        TelaModoVisualizar();
                    }
                    else
                        MessageBox.Show(null, "Não foi possivel editar o pedido!", "Erro ao cadastrar pedido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btCancelar_Click(object sender, EventArgs e)
        {
            if (this.Acao == Util.Acao.Editar)
                this.TelaModoVisualizar();
        }
        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btAdicionarItens_Click(object sender, EventArgs e)
        {
            cms.Modulos.Venda.Forms.frmVendaItens fVendaItens = new cms.Modulos.Venda.Forms.frmVendaItens();
            fVendaItens.id_venda = oVenda.id_venda;
            fVendaItens.ShowDialog();

            AtualizarGridItens();
        }

        private void btCopiarItens_Click(object sender, EventArgs e)
        {
            frmVendaCopiarItens copia = new frmVendaCopiarItens();

            copia.ShowDialog();

            long id_venda_origem = copia.id_venda;
            if (cVenda.VendaItemCopiar(id_venda_origem, oVenda.id_venda))
            {
                AtualizarGridItens();
                MessageBox.Show(null, "Os itens do pedido: " + id_venda_origem + " foram copiados com sucesso.", "Copiar itens do pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(null, "Não foi possivel copiar itens do pedido: " + id_venda_origem + " foram copiados com sucesso.", "Copiar itens do pedido", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void PreencherVenda()
        {
            if (cbStatusVenda.SelectedValue != null)
                this.oVenda.status = cbStatusVenda.SelectedValue.ToString();

            if (cbPorConta.SelectedValue != null)
                this.oVenda.transporte_por_conta = cbPorConta.SelectedValue.ToString();

            if (txtCliente.Tag != null)
                this.oVenda.id_cliente = ((cliente)txtCliente.Tag).id_cliente;

            if (txtClienteContato.Tag != null)
                this.oVenda.id_cliente_contato = ((cliente_contato)txtClienteContato.Tag).id_cliente_contato;

            if (txtNaturezaOperacao.Tag != null)
                this.oVenda.id_fiscal_natureza_operacao = ((fiscal_natureza_operacao)txtNaturezaOperacao.Tag).id_fiscal_natureza_operacao;

            if (txtTransportadora.Tag != null)
                this.oVenda.id_transportadora = ((transportadora)txtTransportadora.Tag).id_transportadora;

            if (txtCondicaoPagamento.Tag != null)
                this.oVenda.id_financeiro_condicao_pagamento = ((financeiro_condicao_pagamento)txtCondicaoPagamento.Tag).id_financeiro_condicao_pagamento;

            if (txtPrecoTabela.Tag != null)
                this.oVenda.id_produto_preco_tabela = ((produto_preco_tabela)txtPrecoTabela.Tag).id_produto_preco_tabela;

            if (!string.IsNullOrEmpty(txtValorFrete.Text))
                this.oVenda.transporte_valor = decimal.Parse(txtValorFrete.Text);
            else
                this.oVenda.transporte_valor = 0;

            this.oVenda.observacao = txtObservacao.Text;
            this.oVenda.observacao_vendedor = txtObservacaoVendedor.Text;
        }
        private void PreencherCampos()
        {
            txtCodigo.Text = this.oVenda.id_venda.ToString();

            if (this.oVenda.status == "Cotacao" ||
                this.oVenda.status == "Pre-Venda" ||
                this.oVenda.status == "Pendente")
            {
                cbStatusVenda.DataSource = Util.Combos.StatusVendaNovo();
                cbStatusVenda.Refresh();
            }
            else
            {
                cbStatusVenda.DataSource = Util.Combos.StatusVenda();
                cbStatusVenda.Refresh();
            }

            cbStatusVenda.SelectedValue = this.oVenda.status;

            cbPorConta.SelectedValue = this.oVenda.transporte_por_conta;

            if (this.oVenda.cliente != null)
            {
                txtCliente.Text = this.oVenda.id_cliente + " - " + this.oVenda.cliente.nome_fantasia;
                txtCliente.Tag = this.oVenda.cliente;
            }
            else
            {
                txtCliente.Text = string.Empty;
                txtCliente.Tag = null;
            }

            if (this.oVenda.cliente_contato != null)
            {
                txtClienteContato.Text = this.oVenda.cliente_contato.nome + "(" + this.oVenda.cliente_contato.telefone + ")";
                txtClienteContato.Tag = this.oVenda.cliente_contato;
            }
            else
            {
                txtClienteContato.Text = string.Empty;
                txtClienteContato.Tag = null;
            }

            if (this.oVenda.id_produto_preco_tabela != null)
            {
                txtPrecoTabela.Text = this.oVenda.produto_preco_tabela.id_produto_preco_tabela + " - " + this.oVenda.produto_preco_tabela.preco_tabela;
                txtPrecoTabela.Tag = this.oVenda.produto_preco_tabela;
            }
            else
            {
                txtPrecoTabela.Text = string.Empty;
                txtPrecoTabela.Tag = null;
            }

            if (this.oVenda.fiscal_natureza_operacao != null)
            {
                txtNaturezaOperacao.Text = this.oVenda.fiscal_natureza_operacao.id_fiscal_natureza_operacao + " - " + this.oVenda.fiscal_natureza_operacao.descricao;
                txtNaturezaOperacao.Tag = this.oVenda.fiscal_natureza_operacao;
            }
            else
            {
                txtNaturezaOperacao.Text = string.Empty;
                txtNaturezaOperacao.Tag = null;
            }

            if (this.oVenda.transportadora != null)
            {
                txtTransportadora.Text = this.oVenda.transportadora.id_transportadora + " - " + this.oVenda.transportadora.nome_fantasia;
                txtTransportadora.Tag = this.oVenda.transportadora;
            }
            else
            {
                txtTransportadora.Text = string.Empty;
                txtTransportadora.Tag = null;
            }

            if (this.oVenda.financeiro_condicao_pagamento != null)
            {
                txtCondicaoPagamento.Text = this.oVenda.financeiro_condicao_pagamento.descricao;
                txtCondicaoPagamento.Tag = this.oVenda.financeiro_condicao_pagamento;
            }
            else
            {
                txtCondicaoPagamento.Text = string.Empty;
                txtCondicaoPagamento.Tag = null;
            }

            txtValorFrete.Text = string.Format("{0:n}", this.oVenda.transporte_valor);

            txtObservacao.Text = this.oVenda.observacao;
            txtObservacaoVendedor.Text = this.oVenda.observacao_vendedor;
            PreencherCondicaoPagamento();
        }
        #endregion

        #region # Validação de Formulario #
        private void ValidForm()
        {
            bool erro = false;

            if (string.IsNullOrEmpty(txtCliente.Text))
            {
                erro = true;
                txtCliente.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtCliente, "Campo cliente e obrigatório.");
            }
            else
                txtCliente.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(cbStatusVenda.SelectedValue.ToString()))
            {
                erro = true;
                cbStatusVenda.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtCliente, "Campo status e obrigatório.");

                MessageBox.Show("Preencha o campo status do pedido.", "Validação do formurario.");
            }
            else
                cbStatusVenda.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtPrecoTabela.Text.ToString()))
            {
                erro = true;
                txtPrecoTabela.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtPrecoTabela, "Campo preço tabela e obrigatório.");
            }
            else
                txtPrecoTabela.BackColor = DefaultBackColor;

            #region # Validar Pagamentos #
            
            gvCondicaoPagamento.EndEdit();
            string mensagem = string.Empty;

            for (int i = 0; i < gvCondicaoPagamento.Rows.Count; i++)
            {
                if (gvCondicaoPagamento.Rows[i].Cells["colFormaPagamento"].Value == null)
                {
                    gvCondicaoPagamento.Rows[i].Cells["colFormaPagamento"].ToolTipText = "Campo forma de pagamento é obrigatorio.";
                    gvCondicaoPagamento.Rows[i].Cells["colFormaPagamento"].Style.BackColor = CorCampoInvalido;
                    gvCondicaoPagamento.Rows[i].Cells["ColNumeroParcela"].Style.BackColor = CorCampoInvalido;
                    erro = true;
                    mensagem += "Parcela " + gvCondicaoPagamento.Rows[i].Cells["ColNumeroParcela"].Value.ToString() + " esta com a forma de pagamento inválida. \n";
                }
                else
                {
                    gvCondicaoPagamento.Rows[i].Cells["colFormaPagamento"].ToolTipText = string.Empty;
                    gvCondicaoPagamento.Rows[i].Cells["colFormaPagamento"].Style.BackColor = DefaultBackColor;
                    gvCondicaoPagamento.Rows[i].Cells["ColNumeroParcela"].Style.BackColor = DefaultBackColor;
                }
            }
            if (!string.IsNullOrEmpty(mensagem))
                MessageBox.Show(mensagem, "Cadastrar novo pedido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            #endregion

            if (erro)
                FormIsValid = false;
            else
                FormIsValid = true;
        }
        #endregion

        #region # Botões de Pesquisas #
        private void btCliente_Click(object sender, EventArgs e)
        {
            cms.Modulos.Cliente.Forms.frmClienteLockup fClienteLockup = new cms.Modulos.Cliente.Forms.frmClienteLockup();

            if (fClienteLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var cliente = fClienteLockup.GetClienteSelecionado();

                txtCliente.Tag = cliente;
                txtCliente.Text = cliente.id_cliente + " - " + cliente.nome_fantasia;

                txtClienteContato.Text = string.Empty;
                txtClienteContato.Tag = null;

                fClienteLockup.Close();
                fClienteLockup.Dispose();
            }
            else
            {
                txtCliente.Tag = null;
                txtCliente.Text = string.Empty;

                txtClienteContato.Text = string.Empty;
                txtClienteContato.Tag = null;
            }
        }
        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCliente_Click(sender, e);
            }
        }

        private void btClienteContato_Click(object sender, EventArgs e)
        {
            if (txtCliente.Tag == null)
            {
                MessageBox.Show("Informe primeiro o cliente.", "Pesquisar Contatos de Cliente.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cms.Modulos.Cliente.Forms.frmClienteContatoLockup fClienteContatoLockup = new cms.Modulos.Cliente.Forms.frmClienteContatoLockup((cliente)txtCliente.Tag);

            if (fClienteContatoLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var ClienteContato = fClienteContatoLockup.GetClienteContatoSelecionado();

                txtClienteContato.Tag = ClienteContato;
                txtClienteContato.Text = ClienteContato.nome + " (" + ClienteContato.telefone + ")";

                fClienteContatoLockup.Close();
                fClienteContatoLockup.Dispose();
            }
            else
            {
                txtClienteContato.Tag = null;
                txtClienteContato.Text = string.Empty;
            }
        }
        private void txtClienteContato_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btClienteContato_Click(sender, e);
            }
        }

        private void btTransportadora_Click(object sender, EventArgs e)
        {
            cms.Modulos.Transportadora.Forms.frmTransportadoraLockup fTransportadoraLockup = new cms.Modulos.Transportadora.Forms.frmTransportadoraLockup();

            if (fTransportadoraLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var transportadora = fTransportadoraLockup.GetTransportadoraSelecionado();

                txtTransportadora.Tag = transportadora;
                txtTransportadora.Text = transportadora.id_transportadora + " - " + transportadora.nome_fantasia;

                fTransportadoraLockup.Close();
                fTransportadoraLockup.Dispose();
            }
            else
            {
                txtTransportadora.Tag = null;
                txtTransportadora.Text = string.Empty;
            }
        }
        private void txtTransportadora_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btTransportadora_Click(sender, e);
            }
        }

        private void btTelefones_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txtCliente.Tag == null)
            {
                MessageBox.Show("Informe primeiro o cliente.", "Consultar Telefones.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cms.Modulos.Cliente.Forms.frmClienteTelefoneView fClienteTelefoneView = new cms.Modulos.Cliente.Forms.frmClienteTelefoneView((cliente)txtCliente.Tag);
            fClienteTelefoneView.ShowDialog();
        }

        private void btNaturezaOperacao_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.NaturezaOperacao.frmFiscalNaturesaOperacaoLockup fFiscalNaturesaOperacaoLockup = new cms.Modulos.Fiscal.Forms.NaturezaOperacao.frmFiscalNaturesaOperacaoLockup();

            if (fFiscalNaturesaOperacaoLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var natureza_operacao = fFiscalNaturesaOperacaoLockup.GetNaturezaOperacaoSelecionado();

                txtNaturezaOperacao.Tag = natureza_operacao;
                txtNaturezaOperacao.Text = natureza_operacao.id_fiscal_natureza_operacao + " - " + natureza_operacao.descricao;

                fFiscalNaturesaOperacaoLockup.Close();
                fFiscalNaturesaOperacaoLockup.Dispose();
            }
            else
            {
                txtNaturezaOperacao.Tag = null;
                txtNaturezaOperacao.Text = string.Empty;
            }
        }
        private void txtNaturezaOperacao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btNaturezaOperacao_Click(sender, e);
            }
        }
        
        private void btPrecoTabela_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.PrecoTabela.frmProdutoPrecoTabelaLockup fProdutoPrecoTabelaLockup = new cms.Modulos.Produto.Forms.PrecoTabela.frmProdutoPrecoTabelaLockup();

            if (fProdutoPrecoTabelaLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var preco_tabela = fProdutoPrecoTabelaLockup.GetPrecoTabelaSelecionado();

                txtPrecoTabela.Tag = preco_tabela;
                txtPrecoTabela.Text = preco_tabela.id_produto_preco_tabela + " - " + preco_tabela.preco_tabela;

                fProdutoPrecoTabelaLockup.Close();
                fProdutoPrecoTabelaLockup.Dispose();
            }
            else
            {
                txtPrecoTabela.Tag = null;
                txtPrecoTabela.Text = string.Empty;
            }
        }
        private void txtPrecoTabela_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btPrecoTabela_Click(sender, e);
            }
        }
        #endregion

        #region # Status #
        private void PreencherStatus()
        {
            gvStatus.Rows.Clear();

            if (oVenda.id_usuario_concluido != null && oVenda.id_usuario_concluido.Value > 0)
            {
                gvStatus.Rows.Add("Concluido", oVenda.data_concluido.Value.ToString("dd/MM/yyyy"), oVenda.usuario5.nome);
                btEditar.Enabled = false;
                btExcluir.Enabled = false;
                btAdicionarItens.Enabled = false;
                btAprovarVenda.Enabled = false;
                btCancelarVenda.Enabled = false;
                btCopiarItens.Enabled = false;
                btSeparaVenda.Enabled = false;
                btContaReceber.Enabled = false;
                btFinalizarVenda.Enabled = false;
                btInformacoes.Enabled = false;
                btEnviarEmail.Enabled = false;
                btNFe.Enabled = false;
                btImprimir.Enabled = false;
            }

            if (oVenda.id_usuario_cancelado != null && oVenda.id_usuario_cancelado.Value > 0)
            {
                gvStatus.Rows.Add("Cancelado", oVenda.data_cancelado.Value.ToString("dd/MM/yyyy"), oVenda.usuario6.nome);
                btEditar.Enabled = false;
                btExcluir.Enabled = false;
                btAdicionarItens.Enabled = false;
                btAprovarVenda.Enabled = false;
                btCancelarVenda.Enabled = false;
                btCopiarItens.Enabled = false;
                btSeparaVenda.Enabled = false;
                btContaReceber.Enabled = false;
                btFinalizarVenda.Enabled = false;
                btInformacoes.Enabled = false;
                btEnviarEmail.Enabled = false;
                btNFe.Enabled = false;
                btImprimir.Enabled = false;
            }

            if (oVenda.id_usuario_faturamento != null && oVenda.id_usuario_faturamento.Value > 0)
            {
                gvStatus.Rows.Add("Faturamento", oVenda.data_faturamento.Value.ToString("dd/MM/yyyy"), oVenda.usuario4.nome);

                if ((oVenda.id_usuario_faturamento == null || oVenda.id_usuario_faturamento.Value == 0) &&
                    (oVenda.id_usuario_cancelado == null || oVenda.id_usuario_cancelado.Value == 0) &&
                    (oVenda.id_usuario_concluido == null || oVenda.id_usuario_concluido.Value == 0))
                {
                    btEditar.Enabled = false;
                    btExcluir.Enabled = false;
                    btAdicionarItens.Enabled = false;
                    btAprovarVenda.Enabled = false;
                    btCancelarVenda.Enabled = true;
                    btCopiarItens.Enabled = false;
                    btSeparaVenda.Enabled = false;
                    btContaReceber.Enabled = true;
                    btFinalizarVenda.Enabled = true;
                    btInformacoes.Enabled = true;
                    btEnviarEmail.Enabled = true;
                    btNFe.Enabled = false;
                    btImprimir.Enabled = true;
                }
            }

            if (oVenda.id_usuario_conferencia != null && oVenda.id_usuario_conferencia.Value > 0)
            {
                gvStatus.Rows.Add("Conferencia", oVenda.data_conferencia.Value.ToString("dd/MM/yyyy"), oVenda.usuario3.nome);

                if ((oVenda.id_usuario_faturamento == null || oVenda.id_usuario_faturamento.Value == 0) &&
                    (oVenda.id_usuario_cancelado == null || oVenda.id_usuario_cancelado.Value == 0) &&
                    (oVenda.id_usuario_concluido == null || oVenda.id_usuario_concluido.Value == 0))
                {
                    btEditar.Enabled = false;
                    btExcluir.Enabled = false;
                    btAdicionarItens.Enabled = false;
                    btAprovarVenda.Enabled = false;
                    btCancelarVenda.Enabled = true;
                    btCopiarItens.Enabled = false;
                    btSeparaVenda.Enabled = true;
                    btContaReceber.Enabled = false;
                    btFinalizarVenda.Enabled = false;
                    btInformacoes.Enabled = true;
                    btEnviarEmail.Enabled = true;
                    btNFe.Enabled = false;
                    btImprimir.Enabled = true;
                }
            }

            if (oVenda.id_usuario_separacao != null && oVenda.id_usuario_separacao.Value > 0)
            {
                gvStatus.Rows.Add("Separação", oVenda.data_separacao.Value.ToString("dd/MM/yyyy"), oVenda.usuario2.nome);
               
                if ((oVenda.id_usuario_conferencia == null || oVenda.id_usuario_conferencia.Value == 0) &&
                    (oVenda.id_usuario_faturamento == null || oVenda.id_usuario_faturamento.Value == 0) &&
                    (oVenda.id_usuario_cancelado == null || oVenda.id_usuario_cancelado.Value == 0) &&
                    (oVenda.id_usuario_concluido == null || oVenda.id_usuario_concluido.Value == 0))
                {
                    btEditar.Enabled = false;
                    btExcluir.Enabled = false;
                    btAdicionarItens.Enabled = false;
                    btAprovarVenda.Enabled = false;
                    btCancelarVenda.Enabled = true;
                    btCopiarItens.Enabled = false;
                    btSeparaVenda.Enabled = true;
                    btContaReceber.Enabled = true;
                    btFinalizarVenda.Enabled = false;
                    btInformacoes.Enabled = true;
                    btEnviarEmail.Enabled = true;
                    btNFe.Enabled = true;
                    btImprimir.Enabled = true;
                }
            }

            if (oVenda.id_usuario_aprovacao != null && oVenda.id_usuario_aprovacao.Value > 0)
            {
                gvStatus.Rows.Add("Aprovado", oVenda.data_aprovacao.Value.ToString("dd/MM/yyyy"), oVenda.usuario1.nome);
                
                if ((oVenda.id_usuario_separacao == null || oVenda.id_usuario_separacao.Value == 0) &&
                    (oVenda.id_usuario_conferencia == null || oVenda.id_usuario_conferencia.Value == 0) &&
                    (oVenda.id_usuario_faturamento == null || oVenda.id_usuario_faturamento.Value == 0) &&
                    (oVenda.id_usuario_cancelado == null || oVenda.id_usuario_cancelado.Value == 0) &&
                    (oVenda.id_usuario_concluido == null || oVenda.id_usuario_concluido.Value == 0))
                {
                    btEditar.Enabled = false;
                    btExcluir.Enabled = false;
                    btAdicionarItens.Enabled = false;
                    btAprovarVenda.Enabled = false;
                    btCancelarVenda.Enabled = true;
                    btCopiarItens.Enabled = false;
                    btSeparaVenda.Enabled = true;
                    btContaReceber.Enabled = true;
                    btFinalizarVenda.Enabled = false;
                    btInformacoes.Enabled = true;
                    btEnviarEmail.Enabled = true;
                    btNFe.Enabled = false;
                    btImprimir.Enabled = true;
                }
            }

            if (oVenda.id_usuario_cadastro > 0)
            {
                gvStatus.Rows.Add("Cadastro", oVenda.data_cadastro.ToString("dd/MM/yyyy"), oVenda.usuario.nome);

                if ((oVenda.id_usuario_aprovacao == null || oVenda.id_usuario_aprovacao.Value == 0) &&
                    (oVenda.id_usuario_separacao == null || oVenda.id_usuario_separacao.Value == 0) &&
                    (oVenda.id_usuario_conferencia == null || oVenda.id_usuario_conferencia.Value == 0) &&
                    (oVenda.id_usuario_faturamento == null || oVenda.id_usuario_faturamento.Value == 0) &&
                    (oVenda.id_usuario_cancelado == null || oVenda.id_usuario_cancelado.Value == 0) &&
                    (oVenda.id_usuario_concluido == null || oVenda.id_usuario_concluido.Value == 0))
                {
                    btAdicionarItens.Enabled = true;
                    btAprovarVenda.Enabled = true;
                    btCancelarVenda.Enabled = true;
                    btCopiarItens.Enabled = true;
                    btSeparaVenda.Enabled = false;
                    btContaReceber.Enabled = false;
                    btFinalizarVenda.Enabled = false;
                    btInformacoes.Enabled = true;
                    btEnviarEmail.Enabled = true;
                    btNFe.Enabled = false;
                    btImprimir.Enabled = true;
                }
            }
        }
        #endregion

        #region # Condições de Pagamento #
        private void btCondicaoPagamento_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.Tabelas.CondicaoPagamento.frmFinanceiroCondicaoPagamentoLockup fFinanceiroCondicaoPagamentoLockup = new cms.Modulos.Financeiro.Forms.Tabelas.CondicaoPagamento.frmFinanceiroCondicaoPagamentoLockup();

            if (fFinanceiroCondicaoPagamentoLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var condicao_pagamento = fFinanceiroCondicaoPagamentoLockup.GetCondicaoPagamentoSelecionado();

                txtCondicaoPagamento.Tag = condicao_pagamento;
                txtCondicaoPagamento.Text = condicao_pagamento.id_financeiro_condicao_pagamento + " - " + condicao_pagamento.descricao;

                fFinanceiroCondicaoPagamentoLockup.Close();
                fFinanceiroCondicaoPagamentoLockup.Dispose();
            }
            else
            {
                txtCondicaoPagamento.Tag = null;
                txtCondicaoPagamento.Text = string.Empty;

                if (id_venda > 0)
                {
                    cVenda.VendaPagamentoLimparByIdVenda(id_venda);
                    gvCondicaoPagamento.Rows.Clear();
                }
                else
                    gvCondicaoPagamento.Rows.Clear();
            }

            MontarCondicoesPagamento();
        }
        private void txtCondicaoPagamento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btCondicaoPagamento_Click(sender, e);
            }
        }

        private void GravarCondicaoPagamento()
        {
            cVenda.VendaPagamentoLimparByIdVenda(this.id_venda);
            gvCondicaoPagamento.EndEdit();

            if (string.IsNullOrEmpty(txtTotalPedido.Text))
                txtTotalPedido.Text = "0,00";

            decimal frete = decimal.Parse(txtValorFrete.Text);
            decimal total = decimal.Parse(txtTotalPedido.Text);
            financeiro_condicao_pagamento condicao_pagamento = (financeiro_condicao_pagamento)txtCondicaoPagamento.Tag;

            for (int i = 0; i < gvCondicaoPagamento.Rows.Count; i++)
            {
                long id_venda_pagamento = 0;
                long? id_financeiro_conta_receber = null;
                int parcela = 0;
                long id_financeiro_forma_pagamento = 0;
                decimal valor = 0;
                string documento = string.Empty;
                DateTime data_vencimento = new DateTime();

                DataGridViewComboBoxColumn cbFormaPagamento = (DataGridViewComboBoxColumn)gvCondicaoPagamento.Columns["colFormaPagamento"];
                                
                if(gvCondicaoPagamento.Rows[i].Cells["colIdVendaPagamento"].Value != null)
                    id_venda_pagamento = long.Parse(gvCondicaoPagamento.Rows[i].Cells["colIdVendaPagamento"].Value.ToString());

                if(gvCondicaoPagamento.Rows[i].Cells["colIdContaReceber"].Value != null)
                    id_financeiro_conta_receber = long.Parse(gvCondicaoPagamento.Rows[i].Cells["colIdContaReceber"].Value.ToString());

                if(gvCondicaoPagamento.Rows[i].Cells["ColNumeroParcela"].Value != null)
                    parcela = int.Parse(gvCondicaoPagamento.Rows[i].Cells["ColNumeroParcela"].Value.ToString());

                if(gvCondicaoPagamento.Rows[i].Cells["colFormaPagamento"].Value != null)
                    id_financeiro_forma_pagamento = long.Parse(gvCondicaoPagamento.Rows[i].Cells["colFormaPagamento"].Value.ToString());

                if(gvCondicaoPagamento.Rows[i].Cells["colValor"].Value != null)
                    valor = decimal.Parse(gvCondicaoPagamento.Rows[i].Cells["colValor"].Value.ToString());

                if(gvCondicaoPagamento.Rows[i].Cells["colNumeroDocumento"].Value != null)
                    documento = gvCondicaoPagamento.Rows[i].Cells["colNumeroDocumento"].Value.ToString();

                if(gvCondicaoPagamento.Rows[i].Cells["colDataVencimento"].Value != null)
                    data_vencimento = DateTime.Parse(gvCondicaoPagamento.Rows[i].Cells["colDataVencimento"].Value.ToString());
                
                valor = 0;

                if (parcela == 1 && cbPorConta.SelectedValue.ToString() == "Entrega c/ Frete")
                    valor = frete;

                var pagamento_parcela = condicao_pagamento.financeiro_condicao_pagamento_parcela.Where(o => o.numero_parcela == parcela).SingleOrDefault();
                
                decimal acrecimo = 0;
                if (condicao_pagamento.acrecimo != null)
                    acrecimo = condicao_pagamento.acrecimo.Value;

                if (pagamento_parcela != null)
                {
                    if(acrecimo > 0)
                        valor += ((total + (total * (acrecimo / 100))) * (pagamento_parcela.porcentagem / 100));
                    else
                        valor += ((total) * (pagamento_parcela.porcentagem / 100));
                }

                venda_pagamento venda_pagamento = new venda_pagamento();

                venda_pagamento.id_venda_pagamento = id_venda_pagamento;
                venda_pagamento.id_venda = oVenda.id_venda;
                venda_pagamento.id_financeiro_conta_receber = id_financeiro_conta_receber;
                venda_pagamento.parcela = parcela;
                venda_pagamento.id_financeiro_forma_pagamento = id_financeiro_forma_pagamento;
                venda_pagamento.valor = valor;
                venda_pagamento.numero_documento = documento;
                venda_pagamento.data_vencimento = data_vencimento;

                cVenda.VendaPagamentoGravar(venda_pagamento);                
            }
        }
        private void PreencherCondicaoPagamento()
        {
            gvCondicaoPagamento.Rows.Clear();

            var pagamentos = cVenda.GetVendaPagamentoByIdVenda(id_venda);
            
            DataGridViewComboBoxColumn cbFormaPagamento = (DataGridViewComboBoxColumn)gvCondicaoPagamento.Columns["colFormaPagamento"];
            cbFormaPagamento.DataSource = Util.Combos.FormaPagamento();
            cbFormaPagamento.ValueMember = "value";
            cbFormaPagamento.DisplayMember = "display";
            cbFormaPagamento.DataPropertyName = "id_financeiro_forma_pagamento";
  
            foreach (var p in pagamentos)
            {
                    gvCondicaoPagamento.Rows.Add(p.id_venda_pagamento,
                                             p.id_financeiro_conta_receber,
                                             p.parcela,
                                             p.id_financeiro_forma_pagamento.ToString(),
                                             p.valor,
                                             p.numero_documento,
                                             p.data_vencimento);
            }
        }
        private void gvCondicaoPagamento_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal valor = 0;
            if (e.ColumnIndex == 4)
                if (decimal.TryParse(gvCondicaoPagamento.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out valor))
                {
                    gvCondicaoPagamento.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:n}", valor);
                }
        }

        private void MontarCondicoesPagamento()
        {
            #region Condições de Pagamento
            gvCondicaoPagamento.Rows.Clear();

            if (id_venda > 0)
            {
                cVenda.VendaPagamentoLimparByIdVenda(id_venda);
            }

            int parcela = 1;
            decimal valor_frete = decimal.Parse(txtValorFrete.Text);
            decimal valor = 0;
            decimal acrecimo = 0;
            decimal total_pedido = decimal.Parse(txtTotalPedido.Text);
            decimal total_pagar = 0;

            financeiro_condicao_pagamento condicao_pagamento = (financeiro_condicao_pagamento)txtCondicaoPagamento.Tag;

            if (condicao_pagamento.acrecimo != null)
                acrecimo = condicao_pagamento.acrecimo.Value;

            foreach (var p in condicao_pagamento.financeiro_condicao_pagamento_parcela)
            {
                if (parcela == 1 && cbPorConta.SelectedValue.ToString() == "Entrega c/ Frete")
                    valor = valor_frete;

                if (acrecimo > 0)
                    valor += ((total_pedido + (total_pedido * (acrecimo / 100))) * (p.porcentagem / 100));
                else
                    valor += ((total_pedido) * (p.porcentagem / 100));

                DateTime data_vencimento = Util.Util.GetDataServidor();
                data_vencimento = data_vencimento.AddDays(p.dias);

                if (data_vencimento.DayOfWeek == DayOfWeek.Sunday)
                    data_vencimento = data_vencimento.AddDays(2);

                if (data_vencimento.DayOfWeek == DayOfWeek.Tuesday)
                    data_vencimento = data_vencimento.AddDays(1);

                gvCondicaoPagamento.Rows.Add(null, null, parcela, null, string.Format("{0:n}", valor), "", data_vencimento.ToString("dd/MM/yyyy"));
                parcela++;

                total_pagar += valor;
                valor = 0;
            }
            
            txtTotalPagar.Text = string.Format("{0:n}", total_pagar);

            #endregion            
        }
        #endregion

        #region # Itens #
        private void AtualizarGridItens()
        {
            var itens = cVenda.GetVendaItemByIdVenda(oVenda.id_venda);

            gvItens.Rows.Clear();

            foreach (var i in itens)
            {
                gvItens.Rows.Add(i.id_venda_item, i.imagem, i.id_produto, i.descricao, i.quantidade, i.quantidade_confirmada, i.preco_venda, i.desconto, i.valor_total, i.valor_total_pagar_desconto, i.quantidade_estoque, i.quantidade_reservada, i.estoque_atual, i.preco_minimo);
            }
        }
        private void gvItens_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal valor = 0;

            if (e.ColumnIndex == 4 || e.ColumnIndex == 7)
                if (decimal.TryParse(gvItens.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out valor))
                    gvItens.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:n}", valor);

            decimal qtd_solicitada = 0;
            decimal qtd_confirmada = 0;
            decimal valor_unit = 0;
            decimal valor_total = 0;
            decimal valor_desc = 0;
            decimal total_pagar = 0;
            decimal valor_min = 0;

            if (gvItens.Rows[e.RowIndex].Cells[4].Value != null && !string.IsNullOrEmpty(gvItens.Rows[e.RowIndex].Cells[4].Value.ToString())) 
                qtd_solicitada = decimal.Parse(gvItens.Rows[e.RowIndex].Cells[4].Value.ToString());
            
            if (gvItens.Rows[e.RowIndex].Cells[5].Value != null && !string.IsNullOrEmpty(gvItens.Rows[e.RowIndex].Cells[5].Value.ToString()))
                qtd_confirmada = decimal.Parse(gvItens.Rows[e.RowIndex].Cells[5].Value.ToString());
            
            if (gvItens.Rows[e.RowIndex].Cells[6].Value != null && !string.IsNullOrEmpty(gvItens.Rows[e.RowIndex].Cells[6].Value.ToString()))
                valor_unit = decimal.Parse(gvItens.Rows[e.RowIndex].Cells[6].Value.ToString());
            
            if (gvItens.Rows[e.RowIndex].Cells[13].Value != null && !string.IsNullOrEmpty(gvItens.Rows[e.RowIndex].Cells[13].Value.ToString()))
                valor_min = decimal.Parse(gvItens.Rows[e.RowIndex].Cells[13].Value.ToString());

            if (gvItens.Rows[e.RowIndex].Cells[7].Value != null && !string.IsNullOrEmpty(gvItens.Rows[e.RowIndex].Cells[7].Value.ToString()))
            {
                valor_desc = decimal.Parse(gvItens.Rows[e.RowIndex].Cells[7].Value.ToString());
                if ((valor_unit - valor_desc) < valor_min)
                {
                    MessageBox.Show(null, "Este item não pode ter este conto!", "Cadastro de venda.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (cbStatusVenda.SelectedValue.ToString() == "Pendente" || cbStatusVenda.SelectedValue.ToString() == "Cotacao" || cbStatusVenda.SelectedValue.ToString() == "Pre-Venda")
            {
                valor_total = qtd_solicitada * valor_unit;
                total_pagar = qtd_solicitada * (valor_unit - valor_desc);
            }
            else
            {
                valor_total = qtd_confirmada * valor_unit;
                total_pagar = qtd_solicitada * (valor_unit - valor_desc);
            }

            gvItens.Rows[e.RowIndex].Cells[4].Value = string.Format("{0:n2}", qtd_solicitada);
            gvItens.Rows[e.RowIndex].Cells[7].Value = string.Format("{0:n2}", valor_desc);

            gvItens.Rows[e.RowIndex].Cells[8].Value = string.Format("{0:n2}", valor_total);
            gvItens.Rows[e.RowIndex].Cells[9].Value = string.Format("{0:n2}", total_pagar);
            Totalizar();
        }
        private void GravarVendaItem()
        {
            gvItens.EndEdit();

            List<venda_item> itens = new List<venda_item>();

            for (int i = 0; i < gvItens.Rows.Count; i++)
            {
                long? id_venda_item = null;
                decimal quantidade = 0;
                decimal valor = 0;
                decimal desconto = 0;

                venda_item item = new venda_item();

                if(gvItens.Rows[i].Cells["colIdVendaItem"].Value != null || !string.IsNullOrEmpty(gvItens.Rows[i].Cells["colIdVendaItem"].Value.ToString()))
                    id_venda_item = long.Parse(gvItens.Rows[i].Cells["colIdVendaItem"].Value.ToString());

                if (gvItens.Rows[i].Cells["colQuantidade"].Value != null || !string.IsNullOrEmpty(gvItens.Rows[i].Cells["colQuantidade"].Value.ToString()))
                    quantidade = decimal.Parse(gvItens.Rows[i].Cells["colQuantidade"].Value.ToString());

                if (gvItens.Rows[i].Cells["colPrecoUnitario"].Value != null || !string.IsNullOrEmpty(gvItens.Rows[i].Cells["colPrecoUnitario"].Value.ToString()))
                    valor = decimal.Parse(gvItens.Rows[i].Cells["colPrecoUnitario"].Value.ToString());

                if (gvItens.Rows[i].Cells["colDesconto"].Value != null || !string.IsNullOrEmpty(gvItens.Rows[i].Cells["colDesconto"].Value.ToString()))
                    desconto = decimal.Parse(gvItens.Rows[i].Cells["colDesconto"].Value.ToString());
                
                if(id_venda_item == null)
                {
                    MessageBox.Show("Erro ao gravar o item do pedido.", "Itens do pedido.");
                    return;
                }

                item = cVenda.GetVendaItemByIdVendaItem(id_venda_item.Value);
                item.desconto = desconto;
                item.quantidade = quantidade;
                item.valor_unitario = valor;

                itens.Add(item);
            }

            cVenda.VendaItemEditar(itens);
            Totalizar();
        }
        private void gvItens_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show(null, "Tem certeza que deseja excluir estes itens?", "Itens da venda.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    List<long> itens = new List<long>();

                    foreach (DataGridViewRow dr in gvItens.SelectedRows)
                    {
                        itens.Add(Convert.ToInt64(dr.Cells[0].Value));
                        gvItens.Rows.Remove(dr);
                    }

                    cVenda.VendaItensExcluir(itens);
                    AtualizarGridItens();
                }
            }
        }

        private void Totalizar()
        {
            string uf_origem = Util.AuthEntity.EmpresaPadrao.end_estado;
            string uf_destino = Util.AuthEntity.EmpresaPadrao.end_estado;
            string tipo_pessoa = string.Empty;
            string i_estadual = string.Empty;

            cnProduto cProduto = new cnProduto();
            cnFiscalIcms cFiscalIcms = new cnFiscalIcms();

            if (txtCliente.Tag == null)
                return;

            if (txtCliente.Tag != null)
            {
                tipo_pessoa = ((cliente)txtCliente.Tag).tipo_pessoa;
                i_estadual = ((cliente)txtCliente.Tag).i_estadual;
                uf_destino = ((cliente)txtCliente.Tag).end_estado;
            }

            txtItens.Text = "0,00";
            txtValorTotal.Text = "0,00";
            txtTotalIcms.Text = "0,00";
            txtTotalIPI.Text = "0,00";
            txtTotalICMSST.Text = "0,00";
            txtDesconto.Text = "0,00";
            txtTotalPedido.Text = "0,00";
            txtTotalPagar.Text = "0,00";

            decimal total_itens = 0;
            decimal valor_total = 0;
            decimal total_icms = 0;
            decimal total_ipi = 0;
            decimal total_icms_st = 0;
            decimal total_desconto = 0;
            decimal total_pedido = 0;
 
            total_itens = oVenda.venda_item.Count;

            for (int i = 0; i < gvItens.Rows.Count; i++)
            {
                decimal valor_unitario = 0;
                decimal quantidade = 0;
                decimal desconto = 0;
                produto Produto = new produto();

                if (gvItens.Rows[i].Cells[2].Value != null && gvItens.Rows[i].Cells[2].Value.ToString() != "")
                    Produto = cProduto.GetProdutoByID((long)gvItens.Rows[i].Cells[2].Value);

                if (cbStatusVenda.SelectedValue.ToString() == "Pendente" || cbStatusVenda.SelectedValue.ToString() == "Cotacao" || cbStatusVenda.SelectedValue.ToString() == "Pre-Venda")
                {
                    if (gvItens.Rows[i].Cells[4].Value != null && gvItens.Rows[i].Cells[4].Value.ToString() != "")
                        quantidade = Convert.ToDecimal(gvItens.Rows[i].Cells[4].Value);
                }
                else
                {
                    if (gvItens.Rows[i].Cells[5].Value != null && gvItens.Rows[i].Cells[5].Value.ToString() != "")
                        quantidade = Convert.ToDecimal(gvItens.Rows[i].Cells[5].Value);
                }

                if (gvItens.Rows[i].Cells[6].Value != null && gvItens.Rows[i].Cells[6].Value.ToString() != "")
                    valor_unitario = Convert.ToDecimal(gvItens.Rows[i].Cells[6].Value);

                if (gvItens.Rows[i].Cells[7].Value != null && gvItens.Rows[i].Cells[7].Value.ToString() != "")
                    desconto = Convert.ToDecimal(gvItens.Rows[i].Cells[7].Value);

                valor_total += valor_unitario * quantidade;
                total_icms += cFiscalIcms.CalcularICMS(Produto, valor_unitario, uf_origem, uf_destino) * quantidade;
                total_ipi += cFiscalIcms.CalcularIPI(Produto, valor_unitario, uf_destino) * quantidade;

                total_icms_st += cFiscalIcms.CalcularICMSST(Produto, valor_unitario, uf_origem, uf_destino, tipo_pessoa, i_estadual) * quantidade;

                total_desconto += desconto;
            }

            total_pedido = (valor_total + total_icms_st) - total_desconto;

            txtItens.Text = string.Format("{0:n}", total_itens);
            txtValorTotal.Text = string.Format("{0:n}", valor_total);
            txtTotalIcms.Text = string.Format("{0:n}", total_icms);
            txtTotalIPI.Text = string.Format("{0:n}", total_ipi);
            txtTotalICMSST.Text = string.Format("{0:n}", total_icms_st);
            txtDesconto.Text = string.Format("{0:n}", total_desconto);
            txtTotalPedido.Text = string.Format("{0:n}", total_pedido);

        }

        private void cbPorConta_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Totalizar();
        }
        private void txtValorFrete_Validating(object sender, CancelEventArgs e)
        {
            Totalizar();
        }
        #endregion

        #region # Pedido Ações #
        private void btInformacoes_Click(object sender, EventArgs e)
        {
            frmVendaInfo info = new frmVendaInfo();
            info.ShowDialog();
        }
        private void btAprovarVenda_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Deseja aprovar pedido?", "Aprovar pedido.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                if (cVenda.VendaAprovar(oVenda.id_venda, Util.AuthEntity.UsuarioOnLine.id_usuario))
                {
                    MessageBox.Show(null, "Pedido aprovado com sucesso!", "Aprovar pedido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(null, "Não foi possivel aprovar o pedido!", "Aprovar pedido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.TelaModoVisualizar();
        }
        private void btCancelarVenda_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Deseja cancelar pedido?", "Cancelar pedido.", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
            {
                if (cVenda.VendaCancelar(oVenda.id_venda, Util.AuthEntity.UsuarioOnLine.id_usuario))
                {
                    MessageBox.Show(null, "Pedido cancelado com sucesso!", "Cancelar pedido.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(null, "Não foi possivel cancelar o pedido!", "Cancelar pedido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.TelaModoVisualizar();
        }
        #endregion       
        
        #region # Separação #
        private void btSeparaVenda_Click(object sender, EventArgs e)
        {
            cms.Modulos.Venda.Forms.frmVendaSeparacao fVendaSeparacao = new cms.Modulos.Venda.Forms.frmVendaSeparacao();

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fVendaSeparacao.MdiParent = this;
                fVendaSeparacao.Show();
            }
            else
                fVendaSeparacao.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }
        #endregion

    }
}
