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
    public partial class frmProduto : cms.Modulos.Util.WindowBase
    {
        cnProduto cProduto = new cnProduto();

        private produto oProduto = new produto();

        public Util.Acao Acao { get; set; }
        public long id_produto { get; set; }

        public frmProduto()
        {
            InitializeComponent();
            PreencheCombos();
        }

        private void frmProduto_Load(object sender, EventArgs e)
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
            this.oProduto = new produto();
            this.Text = "Produto - Cadastrar novo produto";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);

            txtCodigo.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;

            txtDataCadastro.Text = Util.Util.GetDataServidor().ToString("dd/MM/yyyy");
            txtDataCadastro.ReadOnly = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            btGrupo.Enabled = true;
            btSubGrupo.Enabled = true;
            btFamilia.Enabled = true;
            btSubFamilia.Enabled = true;

            txtGrupo.ReadOnly = true;
            txtSubGrupo.ReadOnly = true;
            txtFamilia.ReadOnly = true;
            txtSubFamilia.ReadOnly = true;

            tbAderecos.Visible = false;
            gbFoto.Visible = false;

            #region # Fiscal #
            btNCM.Enabled = true;
            txtNCM.ReadOnly = true;
            gvBaseICMS.Enabled = true;
            gvICMS.Enabled = true;
            #endregion

            #region # Estoque #
            gvEstoque.Enabled = true;
            #endregion

            #region # Foto #
            gvFoto.Enabled = true;
            tsMenuFotos.Enabled = true;
            #endregion

            #region # Preço Tabela #
            gvPrecoTabela.Enabled = true;
            #endregion
            
            #region # Embalagem #
            gvEmbalagem.Enabled = true;
            #endregion
            
        }
        private void TelaModoEditar()
        {
            this.Text = "Produto - Editar cadastro do produto";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);

            txtCodigo.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;

            btGrupo.Enabled = true;
            btSubGrupo.Enabled = true;
            btFamilia.Enabled = true;
            btSubFamilia.Enabled = true;

            txtGrupo.ReadOnly = true;
            txtSubGrupo.ReadOnly = true;
            txtFamilia.ReadOnly = true;
            txtSubFamilia.ReadOnly = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;

            tbAderecos.Visible = true;
            gbFoto.Visible = true;

            #region # Fiscal #
            btNCM.Enabled = true;
            txtNCM.ReadOnly = true;
            gvBaseICMS.Enabled = true;
            gvICMS.Enabled = true;
            #endregion

            #region # Estoque #
            gvEstoque.Enabled = true;
            #endregion

            #region # Foto #
            gvFoto.Enabled = true;
            tsMenuFotos.Enabled = true;
            #endregion

            #region # Preço Tabela #
            gvPrecoTabela.Enabled = true;
            #endregion
            
            #region # Embalagem #
            gvEmbalagem.Enabled = true;
            #endregion

            #region # Foto #
            ShowFoto();
            #endregion
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

            btGrupo.Enabled = false;
            btSubGrupo.Enabled = false;
            btFamilia.Enabled = false;
            btSubFamilia.Enabled = false;

            txtGrupo.ReadOnly = true;
            txtSubGrupo.ReadOnly = true;
            txtFamilia.ReadOnly = true;

            txtSubFamilia.ReadOnly = true;
            TravaFormControles(this.Controls);

            txtCodigo.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;

            tbAderecos.Visible = true;
            gbFoto.Visible = true;

            #region # Fiscal #
            btNCM.Enabled = false;
            txtNCM.ReadOnly = true;
            gvBaseICMS.Enabled = false;
            gvICMS.Enabled = false;
            #endregion

            #region # Estoque #
            gvEstoque.Enabled = false;
            #endregion
            
            #region # Foto #
            gvFoto.Enabled = false;
            tsMenuFotos.Enabled = false;
            #endregion

            #region # Preço Tabela #
            gvPrecoTabela.Enabled = false;
            #endregion
            
            #region # Embalagem #
            gvEmbalagem.Enabled = false;
            #endregion

            #region # Foto #
            ShowFoto();
            #endregion
        }
        private void PreencheCombos()
        {
            cbClasseABC.DataSource = Util.Combos.ClasseABC();
            cbClasseABC.Refresh();

            #region # Fiscal #
            cbOrigemCST.DataSource = Util.Combos.CSTOrigem();
            cbOrigemCST.Refresh();

            cbCstIcms.DataSource = Util.Combos.CST();
            cbCstIcms.Refresh();

            cbPisCst.DataSource = Util.Combos.CSTPIS();
            cbPisCst.Refresh();

            cbCofinsCst.DataSource = Util.Combos.CSTPIS();
            cbCofinsCst.Refresh();

            cbIpiCst.DataSource = Util.Combos.CSTIPI();
            cbIpiCst.Refresh();

            DataGridViewComboBoxColumn cbBase = (DataGridViewComboBoxColumn)gvBaseICMS.Columns["ColBaseIcmsCst"];
            cbBase.DataSource = Util.Combos.CSTBase();
            cbBase.ValueMember = "value";
            cbBase.DisplayMember = "display";

            DataGridViewComboBoxColumn cbPessoa = (DataGridViewComboBoxColumn)gvBaseICMS.Columns["ColBaseIcmsPessoa"];
            cbPessoa.Items.Add("Fisica");
            cbPessoa.Items.Add("Juridica");

            DataGridViewComboBoxColumn cbBaseUF = (DataGridViewComboBoxColumn)gvBaseICMS.Columns["ColBaseIcmsUF"];
            cbBaseUF.DataSource = Util.Combos.Estado();
            cbBaseUF.ValueMember = "value";
            cbBaseUF.DisplayMember = "value";

            DataGridViewComboBoxColumn cbIcmsUF = (DataGridViewComboBoxColumn)gvICMS.Columns["ColIcmsUF"];
            cbIcmsUF.DataSource = Util.Combos.Estado();
            cbIcmsUF.ValueMember = "value";
            cbIcmsUF.DisplayMember = "value";

            #endregion

        }
        #endregion

        #region Menu Ação
        private void btNovo_Click(object sender, EventArgs e)
        {
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            TelaModoCadastrarNovo();
        }
        private void btEditar_Click(object sender, EventArgs e)
        {
            DestravaFormControles(this.Controls);
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
                        GravarICMS();
                        cProduto.ProdutoEstoqueCadastrar(oProduto.id_produto);
                        cProduto.ProdutoPrecoTabelaCadastrar(oProduto.id_produto);
                            
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
                    {
                        GravarICMS();
                        GravarEstoque();
                        GravarFoto();
                        GravarProdutoPreco();
                        GravarProdutoEmbalagem();
                        TelaModoVisualizar();
                    }
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
            oProduto.descricao = txtDescricao.Text;
            oProduto.descricao_abreviada = txtDescricaoAbreviada.Text;
            oProduto.codigo_barra = txtCodigoBarras.Text;
            oProduto.codigo_barra_fornecedor = txtCodigoBarraFornecedor.Text;
            oProduto.referencia_fabrica = txtReferenciaFabrica.Text;

            oProduto.tipo = "PD";

            //if (rbProduto.Checked)
            //    oProduto.tipo = "PD";
            //if (rbMaoObra.Checked)
            //    oProduto.tipo = "MO";
            //if (rbMateriaPrima.Checked)
            //    oProduto.tipo = "MT";
            //if (rbMaterialConsumo.Checked)
            //    oProduto.tipo = "MC";
            //if (rbProdutoIntermediario.Checked)
            //    oProduto.tipo = "PI";

            oProduto.classe_abc = cbClasseABC.SelectedValue.ToString();

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

            #region # Fiscal #
            if (txtNCM.Tag != null)
                oProduto.id_fiscal_ncm = ((fiscal_ncm)txtNCM.Tag).id_fiscal_ncm;

            if (!string.IsNullOrEmpty(cbOrigemCST.SelectedValue.ToString()))
                oProduto.origem_cst = cbOrigemCST.SelectedValue.ToString();

            if (!string.IsNullOrEmpty(cbCstIcms.SelectedValue.ToString()))
                oProduto.cst = cbCstIcms.SelectedValue.ToString();

            if (!string.IsNullOrEmpty(txtAliquotaIcmsSaida.Text))
                oProduto.icms_saida = decimal.Parse(txtAliquotaIcmsSaida.Text);

            if (!string.IsNullOrEmpty(txtAliquotaBaseIcmsSaida.Text))
                oProduto.base_icms = decimal.Parse(txtAliquotaBaseIcmsSaida.Text);

            if (!string.IsNullOrEmpty(txtAliquotaImp.Text))
                oProduto.imp_importacao = decimal.Parse(txtAliquotaImp.Text);

            if (!string.IsNullOrEmpty(txtPisAliquota.Text))
                oProduto.pis_aliquota = decimal.Parse(txtPisAliquota.Text);

            if (!string.IsNullOrEmpty(txtPisBaseCalculo.Text))
                oProduto.pis_base_calculo = decimal.Parse(txtPisBaseCalculo.Text);

            if (!string.IsNullOrEmpty(cbPisCst.SelectedValue.ToString()))
                oProduto.pis_cst = cbPisCst.SelectedValue.ToString();

            if (!string.IsNullOrEmpty(txtCofinsAliquota.Text))
                oProduto.cofins_aliquota = decimal.Parse(txtCofinsAliquota.Text);

            if (!string.IsNullOrEmpty(txtCofinsBaseCalculo.Text))
                oProduto.cofins_base_calculo = decimal.Parse(txtCofinsBaseCalculo.Text);

            if (!string.IsNullOrEmpty(cbCofinsCst.SelectedValue.ToString()))
                oProduto.cofins_cst = cbCofinsCst.SelectedValue.ToString();

            if (!string.IsNullOrEmpty(txtIpiAliquota.Text))
                oProduto.ipi_aliquota = decimal.Parse(txtIpiAliquota.Text);

            if (!string.IsNullOrEmpty(txtIpiBaseCalculo.Text))
                oProduto.ipi_base_calculo = decimal.Parse(txtIpiBaseCalculo.Text);

            if (!string.IsNullOrEmpty(cbIpiCst.SelectedValue.ToString()))
                oProduto.ipi_cst = cbIpiCst.SelectedValue.ToString();

            #endregion

            #region # Descritivo #
            oProduto.observacoes_internas = txtObservacaoInternas.Text;
            oProduto.outras_informacoes = txtOutrasInformacoesProduto.Text;
            #endregion

            #region # Loja Virtual #
            oProduto.web_descricao = txtWebDescricao.Text;
            oProduto.web_descricao_complementar = txtWebDescricaoComplementar.Text;
            oProduto.web_espeficicacao_tecnica = txtWebEspecificacaoTecnica.Text;
            #endregion

        }
        private void PreencherCampos()
        {
            txtCodigo.Text = oProduto.id_produto.ToString();
            txtDataCadastro.Text = oProduto.data_cadastro.ToString("dd/MM/yyyy");
            txtDescricao.Text = oProduto.descricao;
            txtDescricaoAbreviada.Text = oProduto.descricao_abreviada;
            txtCodigoBarras.Text = oProduto.codigo_barra;
            txtCodigoBarraFornecedor.Text = oProduto.codigo_barra_fornecedor;
            txtReferenciaFabrica.Text = oProduto.referencia_fabrica;

            if (oProduto.tipo == "PD")
                rbProduto.Checked = true;

            if (oProduto.tipo == "MO")
                rbMaoObra.Checked = true;

            if (oProduto.tipo == "MT")
                rbMateriaPrima.Checked = true;

            if (oProduto.tipo == "MC")
                rbMaterialConsumo.Checked = true;

            if (oProduto.tipo == "PI")
                rbProdutoIntermediario.Checked = true;

            cbClasseABC.SelectedValue = oProduto.classe_abc;

            chkInativo.Checked = oProduto.inativo;
            chkPalm.Checked = oProduto.palm;
            chkVendaWeb.Checked = oProduto.web;
            chkSazonal.Checked = oProduto.sazonal;

            if (oProduto.produto_grupo != null)
            {
                txtGrupo.Tag = oProduto.produto_grupo;
                txtGrupo.Text = oProduto.produto_grupo.id_produto_grupo + " - " + oProduto.produto_grupo.grupo;
            }

            if (oProduto.produto_subgrupo != null)
            {
                txtSubGrupo.Tag = oProduto.produto_subgrupo;
                txtSubGrupo.Text = oProduto.produto_subgrupo.id_produto_subgrupo + " - " + oProduto.produto_subgrupo.subgrupo;
            }

            if (oProduto.produto_familia != null)
            {
                txtFamilia.Tag = oProduto.produto_familia;
                txtFamilia.Text = oProduto.produto_familia.id_produto_familia + " - " + oProduto.produto_familia.familia;
            }

            if (oProduto.produto_subfamilia != null)
            {
                txtSubFamilia.Tag = oProduto.produto_subfamilia;
                txtSubFamilia.Text = oProduto.produto_subfamilia.id_produto_subfamilia + " - " + oProduto.produto_subfamilia.subfamilia;
            }

            #region # Fiscal #
            if (oProduto.fiscal_ncm != null)
            {
                txtNCM.Text = oProduto.fiscal_ncm.id_fiscal_ncm + " - " + oProduto.fiscal_ncm.ncm;
                txtNCM.Tag = oProduto.fiscal_ncm;
            }

            if (!string.IsNullOrEmpty(oProduto.origem_cst))
                cbOrigemCST.SelectedValue = oProduto.origem_cst;

            if (!string.IsNullOrEmpty(oProduto.cst))
                cbCstIcms.SelectedValue = oProduto.cst;

            if (oProduto.icms_saida != null)
                txtAliquotaIcmsSaida.Text = string.Format("{0:n2}", oProduto.icms_saida);

            if (oProduto.base_icms != null)
                txtAliquotaBaseIcmsSaida.Text = string.Format("{0:n2}", oProduto.base_icms);

            if (oProduto.imp_importacao != null)
                txtAliquotaImp.Text = string.Format("{0:n2}", oProduto.imp_importacao);


            if (oProduto.pis_aliquota != null)
                txtPisAliquota.Text = string.Format("{0:n2}", oProduto.pis_aliquota);

            if (oProduto.pis_base_calculo != null)
                txtPisBaseCalculo.Text = string.Format("{0:n2}", oProduto.pis_base_calculo);

            if (!string.IsNullOrEmpty(oProduto.pis_cst))
                cbPisCst.SelectedValue = oProduto.pis_cst;

            if (oProduto.cofins_aliquota != null)
                txtCofinsAliquota.Text = string.Format("{0:n2}", oProduto.cofins_aliquota);

            if (oProduto.cofins_base_calculo != null)
                txtCofinsBaseCalculo.Text = string.Format("{0:n2}", oProduto.cofins_base_calculo);

            if (!string.IsNullOrEmpty(oProduto.cofins_cst))
                cbCofinsCst.SelectedValue = oProduto.cofins_cst;

            if (oProduto.ipi_aliquota != null)
                txtIpiAliquota.Text = string.Format("{0:n2}", oProduto.ipi_aliquota);

            if (oProduto.ipi_base_calculo != null)
                txtIpiBaseCalculo.Text = string.Format("{0:n2}", oProduto.ipi_base_calculo);

            if (!string.IsNullOrEmpty(oProduto.ipi_cst))
                cbIpiCst.SelectedValue = oProduto.ipi_cst;

            gvBaseICMS.AutoGenerateColumns = false;
            gvICMS.AutoGenerateColumns = false;

            gvBaseICMS.Rows.Clear();
            gvICMS.Rows.Clear();

            var base_icms = cProduto.GetProdutoBaseIcmsByIdProduto(oProduto.id_produto).ToList();
            var icms = cProduto.GetProdutoIcmsByIdProduto(oProduto.id_produto).ToList();

            foreach (var i in base_icms)
                gvBaseICMS.Rows.Add(i.uf, i.aliquota, i.cst, i.tipo_pessoa);

            foreach (var i in icms)
                gvICMS.Rows.Add(i.uf, i.aliquota_icms, i.aliquota_ipi);

            gvBaseICMS.Refresh();
            gvICMS.Refresh();
            #endregion

            #region # Descritivo #
            txtObservacaoInternas.Text = oProduto.observacoes_internas;
            txtOutrasInformacoesProduto.Text = oProduto.outras_informacoes;
            #endregion

            #region # Estoque #
            gvEstoque.Rows.Clear();

            foreach (var emp in oProduto.produto_estoque)
            {
                var empresa = (from e in Util.AuthEntity.UsuarioOnLine.empresa
                               where e.id_empresa == emp.id_empresa
                               select e).SingleOrDefault();

                if (empresa != null)
                    gvEstoque.Rows.Add(emp.id_empresa, emp.id_empresa + " - " + emp.empresa.apelido, emp.quantidade_estoque, emp.quantidade_reservada, emp.quantidade_estoque - emp.quantidade_reservada, emp.estoque_minino, emp.estoque_maximo, emp.localizacao_rua, emp.localizacao_local, emp.localizacao_andar, emp.alerta_valores);
            }
            #endregion

            #region # Loja Virtual #
            txtWebDescricao.Text = oProduto.web_descricao;
            txtWebDescricaoComplementar.Text = oProduto.web_descricao_complementar;
            txtWebEspecificacaoTecnica.Text = oProduto.web_espeficicacao_tecnica;
            #endregion

            #region # Fotos #
            gvFotoAtualizar();
            #endregion

            #region # Preço Tabela #
            gvPrecoTabelaAtualizar();            
            #endregion

            #region # Embalagem #
            gvEmbalagemAtualizar();
            #endregion

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
            if (txtSubGrupo.Tag == null)
            {
                MessageBox.Show(null, "Sub-Grupo não foi selecionado!", "Cadastro de sub-grupo de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cms.Modulos.Produto.Forms.Familia.frmProdutoFamiliaLockup fProdutoFamiliaLockup = new cms.Modulos.Produto.Forms.Familia.frmProdutoFamiliaLockup((produto_subgrupo)txtSubGrupo.Tag);
            
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

            if (string.IsNullOrEmpty(txtGrupo.Text))
            {
                erro = true;
                txtGrupo.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtGrupo, "Campo grupo de produto e obrigatório.");
            }
            else
                txtGrupo.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtSubGrupo.Text))
            {
                erro = true;
                txtSubGrupo.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtGrupo, "Campo sub-grupo de produto e obrigatório.");
            }
            else
                txtSubGrupo.BackColor = DefaultBackColor;
 
            if (erro)
                FormIsValid = false;
            else
                FormIsValid = true;
        }
        #endregion

        #region Fiscal

        private void GravarICMS()
        {
            List<produto_ipi_icms> lIcms = new List<produto_ipi_icms>();
            List<produto_base_icms> lBase = new List<produto_base_icms>();
            
            gvICMS.CommitEdit(DataGridViewDataErrorContexts.Commit);
            gvBaseICMS.CommitEdit(DataGridViewDataErrorContexts.Commit);

            for (int i = 0; i < gvICMS.Rows.Count - 1; i++)
            {
                produto_ipi_icms icms = new produto_ipi_icms();
                icms.id_produto = oProduto.id_produto;
                icms.uf = gvICMS.Rows[i].Cells[0].Value.ToString();
                icms.aliquota_icms = decimal.Parse(gvICMS.Rows[i].Cells[1].Value.ToString());

                lIcms.Add(icms);
            }

            for (int i = 0; i < gvBaseICMS.Rows.Count - 1; i++)
            {
                produto_base_icms base_icms = new produto_base_icms();
                base_icms.id_produto = oProduto.id_produto;
                base_icms.uf = gvBaseICMS.Rows[i].Cells[0].Value.ToString();
                base_icms.aliquota = decimal.Parse(gvBaseICMS.Rows[i].Cells[1].Value.ToString());
                base_icms.cst = gvBaseICMS.Rows[i].Cells[2].Value.ToString();
                base_icms.tipo_pessoa = gvBaseICMS.Rows[i].Cells[3].Value.ToString();

                lBase.Add(base_icms);
            }

            cProduto.ProdutoFiscalCadastrar(oProduto.id_produto, lIcms, lBase);
        }

        private void gvICMS_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            string uf = string.Empty;
            decimal icms = 0;
            decimal ipi = 0;

            if (gvICMS.Rows[e.RowIndex].Cells[0].Value != null)
                uf = gvICMS.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (gvICMS.Rows[e.RowIndex].Cells[1].Value != null)
                icms = decimal.Parse(gvICMS.Rows[e.RowIndex].Cells[1].Value.ToString());

            if (gvICMS.Rows[e.RowIndex].Cells[2].Value != null)
                ipi = decimal.Parse(gvICMS.Rows[e.RowIndex].Cells[2].Value.ToString());

            if (string.IsNullOrEmpty(uf) && (icms > 0 || ipi > 0))
                e.Cancel = true;
        }
        private void gvICMS_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal valor = 0;
            
            if (e.ColumnIndex == 1)
                if (gvICMS.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && decimal.TryParse(gvICMS.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out valor))
                    gvICMS.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:n}", valor);

            if (e.ColumnIndex == 2)
                if (gvICMS.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && decimal.TryParse(gvICMS.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out valor))
                    gvICMS.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:n}", valor);
        }
        private void gvICMS_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal valor = 0;

            if (e.ColumnIndex == 1)
                if (!decimal.TryParse(e.FormattedValue.ToString(), out valor))
                    e.Cancel = true;

            if (e.ColumnIndex == 2)
                if (!decimal.TryParse(e.FormattedValue.ToString(), out valor))
                    e.Cancel = true;
        }

        private void gvBaseICMS_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            string uf = string.Empty;
            decimal icms = 0;
            string cst = string.Empty;
            string pessoa = string.Empty;

            if (gvBaseICMS.Rows[e.RowIndex].Cells[0].Value != null)
                uf = gvBaseICMS.Rows[e.RowIndex].Cells[0].Value.ToString();

            if (gvBaseICMS.Rows[e.RowIndex].Cells[1].Value != null)
                icms = decimal.Parse(gvBaseICMS.Rows[e.RowIndex].Cells[1].Value.ToString());

            if (gvBaseICMS.Rows[e.RowIndex].Cells[2].Value != null)
                cst = gvBaseICMS.Rows[e.RowIndex].Cells[2].Value.ToString();
            
            if (gvBaseICMS.Rows[e.RowIndex].Cells[3].Value != null)
                pessoa = gvBaseICMS.Rows[e.RowIndex].Cells[3].Value.ToString();

            if (!string.IsNullOrEmpty(uf) || !string.IsNullOrEmpty(cst) || !string.IsNullOrEmpty(pessoa))
            {
                if (string.IsNullOrEmpty(uf))
                    e.Cancel = true;

                if (string.IsNullOrEmpty(cst))
                    e.Cancel = true;

                if(string.IsNullOrEmpty(pessoa))
                    e.Cancel = true;
            }
        }
        private void gvBaseICMS_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal valor = 0;

            if (e.ColumnIndex == 1)
                if (gvBaseICMS.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null && decimal.TryParse(gvBaseICMS.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out valor))
                    gvBaseICMS.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:n}", valor);
        }
        private void gvBaseICMS_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal valor = 0;
            
            if (e.ColumnIndex == 1)
                if (!decimal.TryParse(e.FormattedValue.ToString(), out valor))
                    e.Cancel = true;
        }

        #endregion

        #region Estoque
        private void gvEstoque_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal valor = 0;
            if (e.ColumnIndex == 5 || e.ColumnIndex == 6)
            {
                if (decimal.TryParse(gvEstoque.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString(), out valor))
                    gvEstoque.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:n}", valor);
                else
                    e.Cancel = true;
            }
        }
        private void gvEstoque_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal valor = 0;
            if (e.ColumnIndex == 5 || e.ColumnIndex == 6)
            {
                if (decimal.TryParse(gvEstoque.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString(), out valor))
                    gvEstoque.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:n}", valor);
            }
        }
        private void GravarEstoque()
        {
            List<produto_estoque> estoques = new List<produto_estoque>();
            gvEstoque.CommitEdit(DataGridViewDataErrorContexts.Commit);

            for (int i = 0; i < gvEstoque.Rows.Count; i++)
            {
                produto_estoque e = new produto_estoque();

                e.id_empresa = long.Parse(gvEstoque.Rows[i].Cells[0].Value.ToString());
                e.id_produto = oProduto.id_produto;

                if (gvEstoque.Rows[i].Cells[5].Value != null)
                    e.estoque_minino = decimal.Parse(gvEstoque.Rows[i].Cells[5].Value.ToString());
                if (gvEstoque.Rows[i].Cells[6].Value != null)
                    e.estoque_maximo = decimal.Parse(gvEstoque.Rows[i].Cells[6].Value.ToString());

                if (gvEstoque.Rows[i].Cells[7].Value != null)
                    e.localizacao_rua = gvEstoque.Rows[i].Cells[7].Value.ToString();
                if (gvEstoque.Rows[i].Cells[8].Value != null)
                    e.localizacao_local = gvEstoque.Rows[i].Cells[8].Value.ToString();
                if (gvEstoque.Rows[i].Cells[9].Value != null)
                    e.localizacao_andar = gvEstoque.Rows[i].Cells[9].Value.ToString();
                if (gvEstoque.Rows[i].Cells[10].Value != null)
                    e.alerta_valores = bool.Parse(gvEstoque.Rows[i].Cells[10].Value.ToString());

                estoques.Add(e);
            }
            cProduto.ProdutoEstoqueEditar(estoques);
        }
        #endregion

        #region Foto
        private void btNovaFoto_Click(object sender, EventArgs e)
        {
            frmProdutoFoto carregar_foto = new frmProdutoFoto();
            carregar_foto.Id_produto = oProduto.id_produto;
            if (carregar_foto.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                carregar_foto.Close();
                gvFotoAtualizar();
            }
        }
        private void btExcluirFoto_Click(object sender, EventArgs e)
        {
            long id_produto_foto = 0;
            if (gvFoto.CurrentRow != null)
            {
                id_produto_foto = long.Parse(gvFoto.CurrentRow.Cells[0].Value.ToString());
                produto_foto foto = cProduto.GetProdutoFotoByIdProdutoFoto(id_produto_foto);
                foto.excluido = true;
                cProduto.ProdutoFotoEditar(foto);
            }
            gvFotoAtualizar();
        }
        private void gvFotoAtualizar()
        {
            gvFoto.Rows.Clear();

            var fotos = cProduto.GetProdutoFotoByIdProduto(oProduto.id_produto);
            foreach (var f in fotos)
            {
                decimal tamanho = 0;
                string tam = "";

                tamanho = f.imagem.Length;
                Image img = Image.FromStream(new MemoryStream(f.imagem));

                if ((tamanho / 1024) <= 1024)
                    tam += Math.Round((tamanho / 1024), 2).ToString() + " KB";
                else
                    tam += Math.Round((tamanho / (1024 * 1024)), 2).ToString() + " MB";

                gvFoto.Rows.Add(f.id_produto_foto, f.principal, f.ordem, img.Width + "x" + img.Height, tam, "", img);
            }
            gvFoto.Refresh();
        }
        private void GravarFoto()
        {
            List<produto_foto> fotos = new List<produto_foto>();
            gvFoto.CommitEdit(DataGridViewDataErrorContexts.Commit);

            for (int i = 0; i < gvFoto.Rows.Count; i++)
            {
                long id_produto_foto = long.Parse(gvFoto.Rows[i].Cells[0].Value.ToString());
                produto_foto foto = new produto_foto();
                foto = cProduto.GetProdutoFotoByIdProdutoFoto(id_produto_foto);
                foto.principal = bool.Parse(gvFoto.Rows[i].Cells[1].Value.ToString());
                foto.ordem = int.Parse(gvFoto.Rows[i].Cells[2].Value.ToString());
                cProduto.ProdutoFotoEditar(foto);
            }
        }        
        private void gvFoto_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                bool valor = (bool)gvFoto.Rows[e.RowIndex].Cells[1].EditedFormattedValue;
                if (valor)
                {
                    for (int i = 0; i < gvFoto.Rows.Count; i++)
                    {
                        if (i != e.RowIndex)
                        {
                            gvFoto.Rows[i].Cells[e.ColumnIndex].Value = false;
                        }
                    }
                }
            }

            if (e.ColumnIndex == 2)
            {
                int valor = 0;
                if (gvFoto.Rows[e.RowIndex].Cells[2].EditedFormattedValue != null)
                    if (!int.TryParse(gvFoto.Rows[e.RowIndex].Cells[2].EditedFormattedValue.ToString(), out valor))
                        e.Cancel = false;
            }
        }
        #endregion

        #region Preço Tabela
        private void gvPrecoTabelaAtualizar()
        {
            gvPrecoTabela.Rows.Clear();
            
            var precos = cProduto.GetProdutoPrecoTabelaByIdProduto(oProduto.id_produto);
            foreach (var p in precos)
            {
                var empresa = (from e in Util.AuthEntity.UsuarioOnLine.empresa
                               where e.id_empresa == p.id_empresa
                             select e).SingleOrDefault();

                if(empresa != null)
                    gvPrecoTabela.Rows.Add(p.id_empresa, p.empresa.id_empresa + " - " + p.empresa.apelido, p.produto_preco_tabela.id_produto_preco_tabela, p.produto_preco_tabela.id_produto_preco_tabela + " - " + p.produto_preco_tabela.preco_tabela, string.Format("{0:n}", p.preco_venda), string.Format("{0:n}", p.preco_minimo));
            }
            gvPrecoTabela.Refresh();
        }
        private void GravarProdutoPreco()
        {
            cProduto.ProdutoPrecoTabelaCadastrar(oProduto.id_produto);

            List<produto_produto_preco_tabela> precos = new List<produto_produto_preco_tabela>();
            gvPrecoTabela.CommitEdit(DataGridViewDataErrorContexts.Commit);

            for (int i = 0; i < gvPrecoTabela.Rows.Count; i++)
            {
                produto_produto_preco_tabela preco = new produto_produto_preco_tabela();
                
                preco.id_produto = oProduto.id_produto;

                if (gvPrecoTabela.Rows[i].Cells[0].Value != null)
                    preco.id_empresa = long.Parse(gvPrecoTabela.Rows[i].Cells[0].Value.ToString());
                if (gvPrecoTabela.Rows[i].Cells[2].Value != null)
                    preco.id_produto_preco_tabela = long.Parse(gvPrecoTabela.Rows[i].Cells[2].Value.ToString());

                if (gvPrecoTabela.Rows[i].Cells[4].Value != null)
                    preco.preco_venda = decimal.Parse(gvPrecoTabela.Rows[i].Cells[4].Value.ToString());

                if (gvPrecoTabela.Rows[i].Cells[5].Value != null)
                    preco.preco_minimo = decimal.Parse(gvPrecoTabela.Rows[i].Cells[5].Value.ToString());

                cProduto.ProdutoPrecoTabelaEditar(preco);
            }
        }
        private void gvPrecoTabela_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal valor = 0;
            if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                if (decimal.TryParse(gvPrecoTabela.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString(), out valor))
                    gvPrecoTabela.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:n}", valor);
                else
                    e.Cancel = true;
            }
        }
        private void gvPrecoTabela_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal valor = 0;
            if (e.ColumnIndex == 4 || e.ColumnIndex == 5)
            {
                if (decimal.TryParse(gvPrecoTabela.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString(), out valor))
                    gvPrecoTabela.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:n}", valor);
            }
        }
        #endregion

        #region Embalagem
        private void gvEmbalagemAtualizar()
        {
            gvEmbalagem.Rows.Clear();

            var embalagem = cProduto.GetProdutoEmbalagemByIdProduto(oProduto.id_produto);
            foreach (var emb in embalagem)
            {
                gvEmbalagem.Rows.Add(emb.id_produto_embalagem, emb.codigo_barra, emb.codigo_barra_fornecedor, emb.referencia_fabrica, emb.descricao, string.Format("{0:n}", emb.peso_liquido), string.Format("{0:n}", emb.peso_bruto), string.Format("{0:n}", emb.falor_conversao), string.Format("{0:n}", emb.altura), string.Format("{0:n}", emb.largura), string.Format("{0:n}", emb.comprimento));
            }
            gvEmbalagem.Refresh();
        }
        private void GravarProdutoEmbalagem()
        {
            gvEmbalagem.CommitEdit(DataGridViewDataErrorContexts.Commit);

            for (int i = 0; i < gvEmbalagem.Rows.Count-1; i++)
            {
                produto_embalagem embalagem = new produto_embalagem();

                if (gvEmbalagem.Rows[i].Cells[0].Value != null)
                    embalagem.id_produto_embalagem = long.Parse(gvEmbalagem.Rows[i].Cells[0].Value.ToString());

                embalagem.id_produto = oProduto.id_produto;

                if (gvEmbalagem.Rows[i].Cells[1].Value != null)
                    embalagem.codigo_barra = gvEmbalagem.Rows[i].Cells[1].Value.ToString();

                if (gvEmbalagem.Rows[i].Cells[2].Value != null)
                    embalagem.codigo_barra_fornecedor = gvEmbalagem.Rows[i].Cells[2].Value.ToString();

                if (gvEmbalagem.Rows[i].Cells[3].Value != null)
                    embalagem.referencia_fabrica = gvEmbalagem.Rows[i].Cells[3].Value.ToString();

                if (gvEmbalagem.Rows[i].Cells[4].Value != null)
                    embalagem.descricao = gvEmbalagem.Rows[i].Cells[4].Value.ToString();

                if (gvEmbalagem.Rows[i].Cells[5].Value != null)
                    embalagem.peso_liquido = decimal.Parse(gvEmbalagem.Rows[i].Cells[5].Value.ToString());

                if (gvEmbalagem.Rows[i].Cells[6].Value != null)
                    embalagem.peso_bruto = decimal.Parse(gvEmbalagem.Rows[i].Cells[6].Value.ToString());

                if (gvEmbalagem.Rows[i].Cells[7].Value != null)
                    embalagem.falor_conversao = decimal.Parse(gvEmbalagem.Rows[i].Cells[7].Value.ToString());

                if (gvEmbalagem.Rows[i].Cells[8].Value != null)
                    embalagem.altura = decimal.Parse(gvEmbalagem.Rows[i].Cells[8].Value.ToString());

                if (gvEmbalagem.Rows[i].Cells[9].Value != null)
                    embalagem.largura = decimal.Parse(gvEmbalagem.Rows[i].Cells[9].Value.ToString());

                if (gvEmbalagem.Rows[i].Cells[10].Value != null)
                    embalagem.comprimento = decimal.Parse(gvEmbalagem.Rows[i].Cells[10].Value.ToString());
                
                if (embalagem.id_produto_embalagem > 0)
                    cProduto.ProdutoEmbalagemEditar(embalagem);
                else
                    cProduto.ProdutoEmbalagemCadastrar(embalagem);
            }
        }
        private void gvEmbalagem_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal valor = 0;
            if (e.ColumnIndex > 4)
            {
                if (decimal.TryParse(gvEmbalagem.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString(), out valor))
                    gvEmbalagem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:n}", valor);
                else
                    e.Cancel = true;
            }
        }
        private void gvEmbalagem_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal valor = 0;
            if (e.ColumnIndex > 4)
            {
                if (decimal.TryParse(gvEmbalagem.Rows[e.RowIndex].Cells[e.ColumnIndex].EditedFormattedValue.ToString(), out valor))
                    gvEmbalagem.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:n}", valor);
            }
        }
        #endregion

        #region Foto
        int index = 0;
        List<produto_foto> lFotos = new List<produto_foto>();
        
        private void btFotoAnterior_Click(object sender, EventArgs e)
        {
            if (index > 0)
                index--;
            else if (index == 0)
                index = oProduto.produto_foto.ToList().Count - 1;

            ShowFoto();
        }
        private void btFotoProxima_Click(object sender, EventArgs e)
        {
            if (index < oProduto.produto_foto.ToList().Count-1)
                index++;
            else if (index == oProduto.produto_foto.ToList().Count - 1)
                index = 0;

            ShowFoto();
        }

        public void ShowFoto()
        {
            try
            {
                if (oProduto.produto_foto.ToList().Count >= index)
                    imgFoto.Image = Image.FromStream(new MemoryStream(oProduto.produto_foto.ToList()[index].imagem));
            }
            catch { }
        }

        private void btFotoPreview_Click(object sender, EventArgs e)
        {
            MemoryStream ms = new MemoryStream(oProduto.produto_foto.ToList()[index].imagem);
            frmProdutoFotoShow fProdutoFotoShow = new frmProdutoFotoShow(ms);
            fProdutoFotoShow.ShowDialog();
        }
        #endregion
  
    }
}
