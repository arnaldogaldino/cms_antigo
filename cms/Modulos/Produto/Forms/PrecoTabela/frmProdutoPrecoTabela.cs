using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Threading;
using cms.Data;

namespace cms.Modulos.Produto.Forms.PrecoTabela
{

    public partial class frmProdutoPrecoTabela : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Produto.Cn.cnPrecoTabela cProdutoPrecoTabela = new cms.Modulos.Produto.Cn.cnPrecoTabela();

        private produto_preco_tabela produto_preco_tabela = new produto_preco_tabela();
        
        public Util.Acao Acao { get; set; }
        public long id_preco_tabela { get; set; }

        public frmProdutoPrecoTabela()
        {
            InitializeComponent();
        }

        private void frmProdutoPrecoTabela_Load(object sender, EventArgs e)
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
            this.produto_preco_tabela = new produto_preco_tabela();
            this.Text = "Tabela de Preço de Produto - Cadastrar nova tabela de preço de produto";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtCodigo.Enabled = false;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelarAcao.Enabled = false;
            btFechar.Enabled = true;
        }
        private void TelaModoEditar()
        {
            this.Text = "Tabela de Preço de Produto - Editar cadastro de tabela de preço de produto";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            txtCodigo.Enabled = false;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelarAcao.Enabled = true;
            btFechar.Enabled = true;
        }

        private void TelaModoVisualizar()
        {
            this.produto_preco_tabela = cProdutoPrecoTabela.GetPrecoTabelaByID(id_preco_tabela);

            if (this.produto_preco_tabela == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de tabela de preço de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Tabela de Preço de Produto - Visualizar cadastro de tabela de preço de produto";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();

            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelarAcao.Enabled = false;
            btFechar.Enabled = true;

            TravaFormControles(this.Controls);
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
                PreencherPrecoTabela();
            
            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    if (cProdutoPrecoTabela.PrecoTabelaCadastrar(ref produto_preco_tabela))
                    {
                        this.id_preco_tabela = produto_preco_tabela.id_produto_preco_tabela;
                        TelaModoVisualizar();
                    }
                    else
                    {
                        MessageBox.Show(null, "Não foi possivel cadastrar o tabela de preço de produto!", "Erro ao cadastrar tabela de preço de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cProdutoPrecoTabela.PrecoTabelaEditar(ref produto_preco_tabela))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o tabela de preço de produto!", "Erro ao cadastrar tabela de preço de produto.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o Tabela de Preço de Produto: " + produto_preco_tabela.preco_tabela + "!", "Cadastro de PrecoTabela de Produto.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                produto_preco_tabela.excluido = true;
                if (cProdutoPrecoTabela.PrecoTabelaEditar(ref produto_preco_tabela))
                    TelaModoCadastrarNovo();
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            DestravaFormControles(this.Controls);
            txtCodigo.ReadOnly = true;
            TelaModoEditar();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtCodigo.ReadOnly = true;
            TelaModoCadastrarNovo();
        }

        private void PreencherPrecoTabela()
        {
            produto_preco_tabela.preco_tabela = txtPrecoTabela.Text;
        }
        private void PreencherCampos()
        {
            txtCodigo.Text = this.produto_preco_tabela.id_produto_preco_tabela.ToString();
            txtPrecoTabela.Text = this.produto_preco_tabela.preco_tabela;
        }
        #endregion

        #region Validação de Formulario
        private void ValidForm()
        {
            this.FormIsValid = true;
            bool erro = false;

            if (string.IsNullOrEmpty(txtPrecoTabela.Text))
            {
                erro = true;
                txtPrecoTabela.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtPrecoTabela, "Campo Tabela de Preço de produto é obrigatório.");
            }
            else
                txtPrecoTabela.BackColor = DefaultBackColor;

            if (erro)
                this.FormIsValid = false;
        }
        #endregion

    }

}
