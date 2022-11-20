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
using cms.Modulos.Produto.Cn;
using cms.Modulos.Fiscal.Cn;
using System.IO;
using cms.Modulos.Util;

namespace cms.Modulos.Produto.Forms.Produto
{

    public partial class _frmProduto : cms.Modulos.Util.WindowBase
    {
        cnProduto cProduto = new cnProduto();
        cnFiscalNcm cNcm = new cnFiscalNcm();

        private produto oProduto = new produto();
        private produto_embalagem oEmbalagem = new produto_embalagem();
        private produto_preco oPreco = new produto_preco();
        private produto_foto oFoto = new produto_foto();

        private List<produto_embalagem> lEmbalagem = new List<produto_embalagem>();
        private List<produto_preco> lPreco = new List<produto_preco>();
        private List<produto_foto> lFoto = new List<produto_foto>();
        
        public Util.Acao Acao { get; set; }
        public long id_produto { get; set; }

        public _frmProduto()
        {
            InitializeComponent();
            PreencheCombos();
        }

        #region Modo de Tela

        private void TelaModoCadastrarNovo()
        {
            this.oProduto = new produto();
            this.Text = "Produto - Cadastrar novo produto";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            tsMenuEmbalagem.Enabled = false;
            tsMenuPrecos.Enabled = false;
            tsMenuFoto.Enabled = false;

            txtDataCadastro.Text = Util.Util.GetDataServidor().ToString("dd/MM/yyyy");
            txtDataCadastro.ReadOnly = true;

            TelaCamposReadOnly(true);

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;
        }

        private void TelaModoEditar()
        {
            this.Text = "Produto - Editar cadastro do produto";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            tsMenuEmbalagem.Enabled = false;
            tsMenuPrecos.Enabled = false;
            tsMenuFoto.Enabled = false;

            TelaCamposReadOnly(true);

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;
        }

        private void TelaModoVisualizar()
        {
            this.oProduto = cProduto.GetProdutoByID(id_produto);
            if (this.oProduto == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Produto - Visualizar cadastro do produto";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();

            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            TravaFormControles(this.Controls);
            tsMenuEmbalagem.Enabled = false;
            tsMenuPrecos.Enabled = false;
            tsMenuFoto.Enabled = false;
        }

        private void TelaCamposReadOnly(bool b)
        {
            txtCodigo.ReadOnly = b;
            txtDataCadastro.ReadOnly = b;
            txtGrupo.ReadOnly = b;
            txtSubGrupo.ReadOnly = b;
            txtFamilia.ReadOnly = b;
            txtSubFamilia.ReadOnly = b;
            txtEstoqueFisico.ReadOnly = b;
            txtQtdEstoqueReservado.ReadOnly = b;
            txtPedidoCompra.ReadOnly = b;
            txtPedidoVenda.ReadOnly = b;
            txtSaldoInicial.ReadOnly = b;
            txtUltimoAcerto.ReadOnly = b;
            txtNcmUnidade.ReadOnly = b;
            txtNCM.ReadOnly = b;
            txtAliquotaIcms.ReadOnly = b;
            txtAliquotaIcmsUF.ReadOnly = b;
            txtNcmIpiUnidade.ReadOnly = b;
        }
        #endregion
        
        #region Menu Ação

        private void btNovo_Click(object sender, EventArgs e)
        {
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            TelaCamposReadOnly(true);
            TelaModoCadastrarNovo();
        }
        private void btEditar_Click(object sender, EventArgs e)
        {
            DestravaFormControles(this.Controls);
            TelaCamposReadOnly(true);
            TelaModoEditar();
        }
        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o Produto: " + oProduto.descricao + "!", "Cadastro de produto.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                oProduto.excluido = true;
                if (cProduto.ProdutoEditar(ref oProduto))
                    TelaModoCadastrarNovo();
            }
        }
        private void btGravar_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (FormIsValid)
                PreencherProduto();

            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    oProduto.data_cadastro = Util.Util.GetDataServidor();
                    if (cProduto.ProdutoCadastrar(ref oProduto))
                    {
                        this.id_produto = oProduto.id_produto;
                        txtCodigo.Text = oProduto.id_produto.ToString();
                        TelaModoVisualizar();
                    }
                    else
                        MessageBox.Show(null, "Não foi possivel cadastrar o produto!", "Erro ao cadastrar produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cProduto.ProdutoEditar(ref oProduto))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o Produto!", "Erro ao cadastrar produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void PreencherProduto()
        {
            oProduto.data_cadastro = DateTime.Parse(txtDataCadastro.Text);
            
            if(rbProduto.Checked)
                oProduto.tipificacao = "PD";
            if(rbMaoObra.Checked)
                oProduto.tipificacao = "MO";
            if (rbMateriaPrima.Checked)
                oProduto.tipificacao = "MT";
            if (rbMaterialConsumo.Checked)
                oProduto.tipificacao = "MC";
            if (rbProdutoIntermediario.Checked)
                oProduto.tipificacao = "PI";

            oProduto.classe_abc = cbClasseABC.SelectedText;

            oProduto.inativo = chkInativo.Checked;
            oProduto.palm = chkPalm.Checked;
            oProduto.web = chkVendaWeb.Checked;
            oProduto.sazonal = chkSazonal.Checked;

            if (txtGrupo.Tag != null)
                oProduto.id_produto_grupo = ((produto_grupo)txtGrupo.Tag).id_produto_grupo;

            if (txtSubGrupo.Tag != null)
                oProduto.id_produto_subgrupo = ((produto_subgrupo)txtSubGrupo.Tag).id_produto_subgrupo;

            if (txtFamilia.Tag != null)
                oProduto.id_produto_familia = ((produto_familia)txtFamilia.Tag).id_produto_familia;

            if (txtSubFamilia.Tag != null)
                oProduto.id_produto_subfamilia = ((produto_subfamilia)txtSubFamilia.Tag).id_produto_subfamilia;

            oProduto.observacoes_internas = txtObservacaoInternas.Text;
            oProduto.outras_informacoes = txtOutrasInformacoesProduto.Text;

            oProduto.multiplo_atacado = Convert.ToDecimal(txtMultiploAtacado.Text);
            oProduto.multiplo_distribuidor = Convert.ToDecimal(txtMultiploDistribuidor.Text);

            if (dtaUltimaDataCompra.Checked)
                oProduto.ultima_data_compra = dtaUltimaDataCompra.Value;

            if (dtaUltimaDataVenda.Checked)
                oProduto.ultima_data_venda = dtaUltimaDataVenda.Value;

            oProduto.qtd_seguranca = Convert.ToDecimal(txtQtdSeguranca.Text);
            oProduto.estoque_min = Convert.ToDecimal(txtEstoqueMinimo.Text);
            oProduto.estoque_max = Convert.ToDecimal(txtEstoqueMaximo.Text);
            oProduto.demanda_med = Convert.ToDecimal(txtDemandaMed.Text);
            oProduto.alerta_estoque = chkAlertaEstoque.Checked;
            oProduto.estoque = Convert.ToDecimal(txtEstoqueFisico.Text);
            oProduto.estoque_reservado = Convert.ToDecimal(txtQtdEstoqueReservado.Text);

            if (!string.IsNullOrEmpty(txtPedidoCompra.Text))
                oProduto.pedido_compra = Convert.ToDecimal(txtPedidoCompra.Text);
            
            if (!string.IsNullOrEmpty(txtPedidoVenda.Text))
                oProduto.pedido_compra = Convert.ToDecimal(txtPedidoVenda.Text);

            oProduto.saldo_inicial = Convert.ToDecimal(txtSaldoInicial.Text);

            if (dtaDataSaldoInicial.Checked)
                oProduto.data_saldo_inicial = dtaDataSaldoInicial.Value;

            oProduto.ultimo_acerto = Convert.ToDecimal(txtUltimoAcerto.Text);

            if (dtaDataUltimoAcerto.Checked)
                oProduto.data_ultimo_acerto = dtaDataUltimoAcerto.Value;

            oProduto.galpao_armazem = txtGalpaoArmazem.Text;
            oProduto.rua = txtRua.Text;
            oProduto.localizacao = txtLocalizacao.Text;
            oProduto.andar_nivel = txtAndarArmazem.Text;
            oProduto.camada = txtNCamada.Text;
            oProduto.altura_max = txtAlturaMax.Text;

            if (!string.IsNullOrEmpty(txtValorLastro.Text))
                oProduto.valor_lastro = Convert.ToDecimal(txtValorLastro.Text);

            if (!string.IsNullOrEmpty(txtPrazoEntrega.Text))
                oProduto.prazo_entrega = Convert.ToInt32(txtPrazoEntrega.Text);

            oProduto.reposicao = txtReposicao.Text;
            oProduto.qtd_lote = txtQtdLote.Text;
            oProduto.consumo_diario = txtConsumoDiario.Text;
            oProduto.desvio_padrao = txtDesvioPadrao.Text;
            oProduto.sugestao_proporcional = chkSugestaoProporcional.Checked;

            oProduto.observacao_estoque = txtObservacaoEstoque.Text;

            //if (txtNCM.Tag != null)
            //    oProduto.id_financeiro_ncm_unidade = ((financeiro_ncm)txtNCM.Tag).id_financeiro_ncm;

            if(!string.IsNullOrEmpty(cbOrigemCST.SelectedValue.ToString()))
                oProduto.origem_cst = cbOrigemCST.SelectedValue.ToString();

            if(!string.IsNullOrEmpty(cbCstIcms.SelectedValue.ToString()))
                oProduto.cst_icms = cbCstIcms.SelectedValue.ToString();

            //if(cbCstIpi.SelectedValue != string.Empty)
                //oProduto.c

            if (!string.IsNullOrEmpty(cbCodigoISS.SelectedValue.ToString()))
                oProduto.codigo_iss = cbCodigoISS.SelectedValue.ToString();

            oProduto.aliquota = Convert.ToDecimal(txtAliquota.Text);
            oProduto.base_calculo = Convert.ToDecimal(txtBaseCalculo.Text);
            oProduto.pauta_cat = Convert.ToDecimal(txtPautaCat.Text);
            oProduto.reg_cumulativo_pis = Convert.ToDecimal(txtRegCumulativoPis.Text);
            oProduto.reg_cumulativo_cofins = Convert.ToDecimal(txtRegCumulativoCofins.Text);
            oProduto.reg_nao_cumulativo_pis = Convert.ToDecimal(txtRegNaoCumulativoPis.Text);
            oProduto.reg_nao_cumulativo_cofins = Convert.ToDecimal(txtRegNaoCumulativoCofins.Text);
        }

        private void PreencherCampos()
        {
            txtCodigo.Text = oProduto.id_produto.ToString();
        }
        
        #endregion

        #region Validação de Formulario
        private void ValidForm()
        {
            bool erro = false;

            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                erro = true;
                txtDescricao.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtDescricao, "Campo descrição e obrigatório.");
            }
            else
                txtDescricao.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtDescricaoAbreviada.Text))
            {
                erro = true;
                txtDescricaoAbreviada.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtDescricaoAbreviada, "Campo descrição abreviada e obrigatório.");
            }
            else
                txtDescricaoAbreviada.BackColor = DefaultBackColor;

            if (erro)
                FormIsValid = false;
            else
                FormIsValid = true;

        }
        #endregion
        
        #region Lookups

        private void btGrupo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.Grupo.frmProdutoGrupoLockup fProdutoGrupoLockup = new cms.Modulos.Produto.Forms.Grupo.frmProdutoGrupoLockup();

            if (fProdutoGrupoLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var grupo = fProdutoGrupoLockup.GetGrupoSelecionado();

                txtGrupo.Tag = grupo;
                txtGrupo.Text = grupo.id_produto_grupo + " - " + grupo.grupo;

                fProdutoGrupoLockup.Close();
                fProdutoGrupoLockup.Dispose();
            }
            else
            {
                txtGrupo.Tag = null;
                txtGrupo.Text = string.Empty;
            }
        }
        private void txtGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btGrupo_Click(sender, e);
            }
        }

        private void btSubGrupo_Click(object sender, EventArgs e)
        {
            if (txtGrupo.Tag == null)
            {
                MessageBox.Show(null, "Grupo não foi selecionado!", "Cadastro de sub-grupo de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cms.Modulos.Produto.Forms.SubGrupo.frmProdutoSubGrupoLockup fProdutoSubGrupoLockup = new cms.Modulos.Produto.Forms.SubGrupo.frmProdutoSubGrupoLockup((produto_grupo)txtGrupo.Tag);

            if (fProdutoSubGrupoLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var subgrupo = fProdutoSubGrupoLockup.GetSubGrupoSelecionado();

                txtSubGrupo.Tag = subgrupo;
                txtSubGrupo.Text = subgrupo.id_produto_subgrupo + " - " + subgrupo.subgrupo;

                fProdutoSubGrupoLockup.Close();
                fProdutoSubGrupoLockup.Dispose();
            }
            else
            {
                txtSubGrupo.Tag = null;
                txtSubGrupo.Text = string.Empty;
            }
        }
        private void txtSubGrupo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btSubGrupo_Click(sender, e);
            }
        }
        
        private void btFamilia_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.Familia.frmProdutoFamiliaLockup fProdutoFamiliaLockup = new cms.Modulos.Produto.Forms.Familia.frmProdutoFamiliaLockup();

            if (fProdutoFamiliaLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var familia = fProdutoFamiliaLockup.GetFamiliaSelecionado();

                txtFamilia.Tag = familia;
                txtFamilia.Text = familia.id_produto_familia + " - " + familia.familia;

                fProdutoFamiliaLockup.Close();
                fProdutoFamiliaLockup.Dispose();
            }
            else
            {
                txtFamilia.Tag = null;
                txtFamilia.Text = string.Empty;
            }
        }
        private void txtFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btFamilia_Click(sender, e);
            }
        }

        private void btSubFamilia_Click(object sender, EventArgs e)
        {
            if (txtFamilia.Tag == null)
            {
                MessageBox.Show(null, "Familia não foi selecionada!", "Cadastro de sub-familia de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cms.Modulos.Produto.Forms.SubFamilia.frmProdutoSubFamiliaLockup fProdutoSubFamiliaLockup = new cms.Modulos.Produto.Forms.SubFamilia.frmProdutoSubFamiliaLockup((produto_familia)txtFamilia.Tag);

            if (fProdutoSubFamiliaLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var subfamilia = fProdutoSubFamiliaLockup.GetSubFamiliaSelecionado();

                txtSubFamilia.Tag = subfamilia;
                txtSubFamilia.Text = subfamilia.id_produto_subfamilia + " - " + subfamilia.subfamilia;

                fProdutoSubFamiliaLockup.Close();
                fProdutoSubFamiliaLockup.Dispose();
            }
            else
            {
                txtSubFamilia.Tag = null;
                txtSubFamilia.Text = string.Empty;
            }
        }
        private void txtSubFamilia_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btSubFamilia_Click(sender, e);
            }
        }

        private void btNcmUnidade_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Ncm.frmFiscalNcmLockup fFiscalNcmLockup = new cms.Modulos.Fiscal.Forms.Ncm.frmFiscalNcmLockup();

            if (fFiscalNcmLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var ncm = fFiscalNcmLockup.GetNcmSelecionado();

                txtNcmUnidade.Tag = ncm;
                txtNcmUnidade.Text = ncm.ncm + " - " + ncm.descricao;

                fFiscalNcmLockup.Close();
                fFiscalNcmLockup.Dispose();
            }
            else
            {
                txtNcmUnidade.Tag = null;
                txtNcmUnidade.Text = string.Empty;
            }
        }
        private void txtNcmUnidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btNcmUnidade_Click(sender, e);
            }
        }

        private void btNCM_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Ncm.frmFiscalNcmLockup fFiscalNcmLockup = new cms.Modulos.Fiscal.Forms.Ncm.frmFiscalNcmLockup();

            if (fFiscalNcmLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var ncm = fFiscalNcmLockup.GetNcmSelecionado();

                txtNCM.Tag = ncm;
                txtNCM.Text = ncm.ncm + " - " + ncm.descricao;

                fFiscalNcmLockup.Close();
                fFiscalNcmLockup.Dispose();
            }
            else
            {
                txtNCM.Tag = null;
                txtNCM.Text = string.Empty;
            }
        }
        private void txtNCM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btNCM_Click(sender, e);
            }
        }

        private void btNcmIpiUnidade_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Ncm.frmFiscalNcmLockup fFiscalNcmLockup = new cms.Modulos.Fiscal.Forms.Ncm.frmFiscalNcmLockup();

            if (fFiscalNcmLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var ncm = fFiscalNcmLockup.GetNcmSelecionado();

                txtNcmIpiUnidade.Tag = ncm;
                txtNcmIpiUnidade.Text = ncm.ncm + " - " + ncm.descricao;

                fFiscalNcmLockup.Close();
                fFiscalNcmLockup.Dispose();
            }
            else
            {
                txtNcmIpiUnidade.Tag = null;
                txtNcmIpiUnidade.Text = string.Empty;
            }
        }
        private void txtNcmIpiUnidade_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btNcmIpiUnidade_Click(sender, e);
            }
        }

        private void btTabela_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.PrecoTabela.frmProdutoPrecoTabelaLockup fProdutoPrecoTabelaLockup = new cms.Modulos.Produto.Forms.PrecoTabela.frmProdutoPrecoTabelaLockup();

            if (fProdutoPrecoTabelaLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var tabela_preco = fProdutoPrecoTabelaLockup.GetPrecoTabelaSelecionado();

                txtTabela.Tag = tabela_preco;
                txtTabela.Text = tabela_preco.id_produto_preco_tabela + " - " + tabela_preco.preco_tabela;

                fProdutoPrecoTabelaLockup.Close();
                fProdutoPrecoTabelaLockup.Dispose();
            }
            else
            {
                txtTabela.Tag = null;
                txtTabela.Text = string.Empty;
            }
        }
        private void txtTabela_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btTabela_Click(sender, e);
            }
        }
        
        private void PreencheCombos()
        {
            cbClasseABC.DataSource = Util.Combos.ClasseABC();
            cbCodigoISS.DataSource = Util.Combos.CSTISS();
            cbCstIcms.DataSource = Util.Combos.CSTIPI();
            cbCstIpi.DataSource = Util.Combos.CSTIPI();
            cbCstPisCofins.DataSource = Util.Combos.CSTIPI();
            cbOrigemCST.DataSource = Util.Combos.CST();
            cbUnidade.DataSource = Util.Combos.UnidadeMedida();

            cbClasseABC.Refresh();
            cbCodigoISS.Refresh();
            cbCstIcms.Refresh();
            cbCstIpi.Refresh();
            cbCstPisCofins.Refresh();
            cbOrigemCST.Refresh();
            cbUnidade.Refresh();
        }

        #endregion
        
        #region Embalagem

        private void btEmbalagemNovo_Click(object sender, EventArgs e)
        {
            oEmbalagem = new produto_embalagem();
            PreencherCamposEmbalagem();
            PreencherGvEmbalagem();
        }

        private void btEmbalagemGravar_Click(object sender, EventArgs e)
        {
            PreencherEmbalagem();

            if (lEmbalagem.Contains(oEmbalagem))
                lEmbalagem[lEmbalagem.LastIndexOf(oEmbalagem)] = oEmbalagem;
            else
                lEmbalagem.Add(oEmbalagem);

            oEmbalagem = new produto_embalagem();
            PreencherCamposEmbalagem();
            PreencherGvEmbalagem();
        }

        private void btEmbalagemExcluir_Click(object sender, EventArgs e)
        {   
            oEmbalagem.excluido = true;
            lEmbalagem[lEmbalagem.LastIndexOf(oEmbalagem)] = oEmbalagem;

            oEmbalagem = new produto_embalagem();
            PreencherCamposEmbalagem();
            PreencherGvEmbalagem();
        }

        private void gvEmbalagem_DoubleClick(object sender, EventArgs e)
        {
            if (gvEmbalagem.CurrentRow == null)
                return;

            this.oEmbalagem = (produto_embalagem)gvEmbalagem.CurrentRow.DataBoundItem;

            PreencherCamposEmbalagem();
            PreencherGvEmbalagem();
        }

        private void PreencherCamposEmbalagem()
        {
            txtEmbalagemCodigoBarras.Text = oEmbalagem.codigo_barra;
            txtEmbalagemCodigoFornecedor.Text = oEmbalagem.codigo_fornecedor;
            txtEmbalagemDescricao.Text = oEmbalagem.descricao_embalagem;
            txtConteudo.Text = oEmbalagem.conteudo;

            if (!string.IsNullOrEmpty(oEmbalagem.unidade))
                cbUnidade.SelectedValue = oEmbalagem.unidade;
            else
                cbUnidade.SelectedValue = string.Empty;

            if(oEmbalagem.peso_liquido != null)
                txtPesoLiquido.Text = string.Format("{0:n}", oEmbalagem.peso_liquido);
            else
                txtPesoLiquido.Text = "0,00";

            if (oEmbalagem.peso_bruto != null)
                txtPesoBruto.Text = string.Format("{0:n}", oEmbalagem.peso_bruto);
            else
                txtPesoBruto.Text = "0,00";

            if (oEmbalagem.peso_bruto != null)
                txtAltura.Text = string.Format("{0:n}", oEmbalagem.peso_bruto);
            else
                txtAltura.Text = "0,00";

            if (oEmbalagem.largura != null)
                txtLargura.Text = string.Format("{0:n}", oEmbalagem.largura);
            else
                txtLargura.Text = "0,00";

            if (oEmbalagem.comprimento != null) 
                txtComprimento.Text = string.Format("{0:n}", oEmbalagem.comprimento);
            else
                txtComprimento.Text = "0,00";

            if (oEmbalagem.fator_conversao != null)
                txtFatorConversao.Text = string.Format("{0:n}", oEmbalagem.fator_conversao);
            else
                txtFatorConversao.Text = "0,00";

            if (oEmbalagem.id_financeiro_ncm != null)
            {
                var ncm = cNcm.GetFiscalNcmByID((long)oEmbalagem.id_financeiro_ncm);

                txtNcmUnidade.Tag = ncm;
                txtNcmUnidade.Text = ncm.ncm + " - " + ncm.descricao;
            }
            else
            {
                txtNcmUnidade.Tag = null;
                txtNcmUnidade.Text = string.Empty;
            }

            chkDispRelatorio.Checked = oEmbalagem.disp_relatorio;
            chkUnidadeCompra.Checked = oEmbalagem.unidade_compra;
            chkUnidadeEstoque.Checked = oEmbalagem.unidade_estoque;
            chkUnidadeVenda.Checked = oEmbalagem.unidade_venda;
        }
        private void PreencherEmbalagem()
        {
            oEmbalagem.codigo_barra = txtEmbalagemCodigoBarras.Text;
            oEmbalagem.codigo_fornecedor = txtEmbalagemCodigoFornecedor.Text;
            oEmbalagem.descricao_embalagem = txtEmbalagemDescricao.Text;
            oEmbalagem.conteudo = txtConteudo.Text;
            oEmbalagem.unidade = cbUnidade.SelectedValue.ToString();

            oEmbalagem.peso_liquido = decimal.Parse(txtPesoLiquido.Text);
            oEmbalagem.peso_bruto = decimal.Parse(txtPesoBruto.Text);
            oEmbalagem.altura = decimal.Parse(txtAltura.Text);
            oEmbalagem.largura = decimal.Parse(txtLargura.Text);
            oEmbalagem.comprimento = decimal.Parse(txtComprimento.Text);
            oEmbalagem.fator_conversao = decimal.Parse(txtFatorConversao.Text);

            //if (txtNcmUnidade.Tag != null)
            //{
            //    oEmbalagem.id_financeiro_ncm = ((financeiro_ncm)txtNcmUnidade.Tag).id_financeiro_ncm;
            //    try
            //    {
            //        oEmbalagem.financeiro_ncm = ((financeiro_ncm)txtNcmUnidade.Tag);
            //    }
            //    catch { }
            //}
   
            oEmbalagem.disp_relatorio = chkDispRelatorio.Checked;
            oEmbalagem.unidade_compra = chkUnidadeCompra.Checked;
            oEmbalagem.unidade_estoque = chkUnidadeEstoque.Checked;
            oEmbalagem.unidade_venda = chkUnidadeVenda.Checked;
            oEmbalagem.data_cadastro = Util.Util.sp_getdatetime();
            oEmbalagem.excluido = false;

        }

        private void gvEmbalagem_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                var val = (produto_embalagem)gvEmbalagem.Rows[e.RowIndex].DataBoundItem;

                //if(val.financeiro_ncm != null)
                //    e.Value = val.financeiro_ncm.ncm + " - " + val.financeiro_ncm.descricao;
            }
        }

        private void PreencherGvEmbalagem()
        {
            gvEmbalagem.AutoGenerateColumns = false;
            gvEmbalagem.DataSource = lEmbalagem.Where(o => o.excluido == false).ToList();
            gvEmbalagem.Refresh();
        }
        #endregion

        #region Preco

        private void btPrecoNovo_Click(object sender, EventArgs e)
        {

        }

        private void btPrecoGravar_Click(object sender, EventArgs e)
        {

        }

        private void btPrecoExcluir_Click(object sender, EventArgs e)
        {

        }

        private void gvTabelaPreco_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion
        
        #region Foto

        private void PreencherCamposFoto()
        {
            if (oFoto.imagem != null)
            {
                MemoryStream st = new MemoryStream(oFoto.imagem);
                imgFotoCarregada.Image = Image.FromStream(st);
            }
            else
            {
                imgFotoCarregada.Image = null;
            }

            txtFotoOrdem.Text = oFoto.ordem.ToString();
            chkFotoPrincipal.Checked = oFoto.principal;   
        }

        private void PreencherFoto()
        {
            oFoto.data_cadastro = Util.Util.sp_getdatetime();
            oFoto.excluido = false;

            MemoryStream st = new MemoryStream();

            imgFotoCarregada.Image.Save(st , System.Drawing.Imaging.ImageFormat.Jpeg);

            oFoto.imagem = st.ToArray();

            oFoto.ordem = int.Parse(txtFotoOrdem.Text);
            oFoto.principal = chkFotoPrincipal.Checked;            
        }

        private void PreencherGvFoto()
        {
            gvFoto.AutoGenerateColumns = false;
            gvFoto.DataSource = lFoto.Where(o => o.excluido == false).ToList();
            gvFoto.Refresh();
        }
        
        private void gvFoto_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (gvFoto.Rows[e.RowIndex].DataBoundItem != null)
            {
                var img = (produto_foto)gvFoto.Rows[e.RowIndex].DataBoundItem;

                if (e.ColumnIndex == 4 && img != null)
                {
                    e.Value = Util.Imagem.redimensionarImagem(img.imagem, new Size(110, 45));
                }
            }
        }
        
        private void btFotoNovo_Click(object sender, EventArgs e)
        {
            oFoto = new produto_foto();
            PreencherCamposFoto();
            PreencherGvFoto();
        }

        private void btFotoGravar_Click(object sender, EventArgs e)
        {
            PreencherFoto();

            if (lFoto.Contains(oFoto))
                lFoto[lFoto.LastIndexOf(oFoto)] = oFoto;
            else
                lFoto.Add(oFoto);

            oFoto = new produto_foto();
            PreencherCamposFoto();
            PreencherGvFoto();
        }

        private void btFotoExcluir_Click(object sender, EventArgs e)
        {
            oFoto.excluido = true;
            lFoto[lFoto.LastIndexOf(oFoto)] = oFoto;

            oFoto = new produto_foto();
            PreencherCamposFoto();
            PreencherGvFoto();
        }

        private void gvFoto_DoubleClick(object sender, EventArgs e)
        {

        }
        
        private void btCarregaFoto_Click(object sender, EventArgs e)
        {
            ofFoto.Filter = "Foto (*.jpg)|*.jpg|All files (*.*)|*.*";

            if(ofFoto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                imgFotoCarregada.Image = Image.FromStream(ofFoto.OpenFile());
            }
        }

        private void gvFoto_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && gvFoto.Rows[e.RowIndex].DataBoundItem != null)
            {
                var img = (produto_foto)gvFoto.Rows[e.RowIndex].DataBoundItem;

                pictureBox1.Image = null;
                pictureBox1.Visible = false;

                if (e.ColumnIndex == 4 && img != null)
                {
                    //PictureBox pic = new PictureBox();
                    //pic.Image = Util.Imagem.redimensionarImagem(img.imagem, new Size(300, 300));
                    //pic.Top = gvFoto.Top + 100;
                    //pic.Left = gvFoto.Left + 250;

                    //this.Controls.Add(pic);

                    pictureBox1.Image = Util.Imagem.redimensionarImagem(img.imagem, new Size(300, 300));
                    pictureBox1.Visible = true;

                }
            }
            else
            {
                pictureBox1.Image = null;
                pictureBox1.Visible = false;
            }
        }

        #endregion

    }
}