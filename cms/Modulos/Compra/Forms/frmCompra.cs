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
using System.IO;
using cms.Modulos.Util;
using cms.Modulos.Compra.Cn;
using cms.Modulos.Produto.Cn;
using cms.Modulos.Fiscal.Cn;
using cms.Modulos.Financeiro.Cn;

namespace cms.Modulos.Compra.Forms
{
    public partial class frmCompra : cms.Modulos.Util.WindowBase
    {
        cnCompra cCompra = new cnCompra();
        private compra oCompra = new compra();
        private cnProduto cProduto = new cnProduto();

        public Util.Acao Acao { get; set; }
        public long id_compra { get; set; }

        public frmCompra()
        {
            InitializeComponent();
            cbStatus.DataSource = Util.Combos.StatusCompra();
            cbStatus.Refresh();
        }

        private void frmCompra_Load(object sender, EventArgs e)
        {
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
            this.oCompra = new compra();
            this.Text = "Compra - Cadastrar nova compra";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);

            gvCompraItens.Rows.Clear();
            gvStatus.Rows.Clear();
            gvCompraItens.Visible = false;

            dtaPrevisaoEntrega.Checked = false;
            dtaPrevisaoEntrega.Value = DateTime.Now;
            dtaRecebimento.Checked = false;
            dtaRecebimento.Value = DateTime.Now;

            txtCodigo.ReadOnly = true;
            txtCompraOrigem.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;
            cbStatus.Enabled = false;

            txtFornecedor.ReadOnly = true;
            btFornecedor.Enabled = true;

            dtaPrevisaoEntrega.Enabled = true;
            dtaRecebimento.Enabled = true;

            txtTotalItens.ReadOnly = true;
            txtValorTotal.ReadOnly = true;
            cbFilial.Enabled = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;
            btContasPagar.Enabled = false;
            btFinalizar.Enabled = false;

            btAdicionarItens.Enabled = false;
            btGravarXml.Enabled = false;
            btArquivoXml.Enabled = false;
            btCopiarItem.Enabled = false;
            btAprovar.Enabled = false;
            btCancelarCompra.Enabled = false;
            btConferir.Enabled = false;
            btEntrega.Enabled = false;

            gvCompraItens.Columns[0].ReadOnly = true; // id_compra_item
            gvCompraItens.Columns[1].ReadOnly = true; // id_produto
            gvCompraItens.Columns[2].ReadOnly = true; // Código
            gvCompraItens.Columns[3].ReadOnly = true; // Descrição
            gvCompraItens.Columns[4].ReadOnly = true; // Qtd. Solicitada
            gvCompraItens.Columns[5].ReadOnly = true; // Qtd. Recebida
            gvCompraItens.Columns[6].ReadOnly = true; // Valor Unit.
            gvCompraItens.Columns[7].ReadOnly = true; // Valor Desc.
            gvCompraItens.Columns[8].ReadOnly = true; // Total
            gvCompraItens.Columns[9].ReadOnly = true; // ICMS
            gvCompraItens.Columns[10].ReadOnly = true; // IPI
            gvCompraItens.Columns[11].ReadOnly = true; // Data Conferência
            gvCompraItens.Columns[12].ReadOnly = true; // Estq Atual
            gvCompraItens.Columns[13].ReadOnly = true; // Estq Min
            gvCompraItens.Columns[14].ReadOnly = true; // Estq Max
            gvCompraItens.Columns[15].ReadOnly = true; // Ultimo Preço

            PreencherGridStatus();
        }
        private void TelaModoEditar()
        {
            this.Text = "Compra - Editar cadastro de compra";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);

            txtCodigo.ReadOnly = true;
            txtCompraOrigem.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;
            cbStatus.Enabled = false;

            txtFornecedor.ReadOnly = true;
            btFornecedor.Enabled = false;

            dtaPrevisaoEntrega.Enabled = true;
            dtaRecebimento.Enabled = true;

            txtTotalItens.ReadOnly = true;
            txtValorTotal.ReadOnly = true;
            cbFilial.Enabled = false;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;
            AtualizarGridItens();
            
            gvCompraItens.Enabled = true;

            if (cbStatus.SelectedValue.ToString() == "Pendente")
            {
                btAdicionarItens.Enabled = true;

                if(cCompra.GetArquivoXML(oCompra.id_compra) != null)
                    btGravarXml.Enabled = true;

                btArquivoXml.Enabled = false;
                btCopiarItem.Enabled = true;
                btEntrega.Enabled = false;
                btAprovar.Enabled = false;
                btCancelarCompra.Enabled = false;
                btConferir.Enabled = false;
                btContasPagar.Enabled = true;
                btFinalizar.Enabled = false;

                dtaRecebimento.Enabled = false;

                gvCompraItens.Columns[0].ReadOnly = true; // id_compra_item
                gvCompraItens.Columns[1].ReadOnly = true; // id_produto
                gvCompraItens.Columns[2].ReadOnly = true; // Código
                gvCompraItens.Columns[3].ReadOnly = true; // Descrição
                gvCompraItens.Columns[4].ReadOnly = false; // Qtd. Solicitada
                gvCompraItens.Columns[5].ReadOnly = true; // Qtd. Recebida
                gvCompraItens.Columns[6].ReadOnly = false; // Valor Unit.
                gvCompraItens.Columns[7].ReadOnly = false; // Valor Desc.
                gvCompraItens.Columns[8].ReadOnly = true; // Total
                gvCompraItens.Columns[9].ReadOnly = true; // ICMS
                gvCompraItens.Columns[10].ReadOnly = true; // IPI
                gvCompraItens.Columns[11].ReadOnly = true; // Data Conferência
                gvCompraItens.Columns[12].ReadOnly = true; // Estq Atual
                gvCompraItens.Columns[13].ReadOnly = true; // Estq Min
                gvCompraItens.Columns[14].ReadOnly = true; // Estq Max
                gvCompraItens.Columns[15].ReadOnly = true; // Ultimo Preço
            }
            else if (cbStatus.SelectedValue.ToString() == "Aprovada")
            {
                btAdicionarItens.Enabled = false;

                if (cCompra.GetArquivoXML(oCompra.id_compra) != null)
                    btGravarXml.Enabled = true;

                btFornecedor.Enabled = false;
                dtaPrevisaoEntrega.Enabled = false;
                dtaRecebimento.Enabled = false;
                
                btArquivoXml.Enabled = true;
                btCopiarItem.Enabled = false;
                btEntrega.Enabled = false;
                btAprovar.Enabled = false;
                btCancelarCompra.Enabled = false;
                btConferir.Enabled = false;
                btContasPagar.Enabled = true;
                btFinalizar.Enabled = false;

                gvCompraItens.Columns[0].ReadOnly = true; // id_compra_item
                gvCompraItens.Columns[1].ReadOnly = true; // id_produto
                gvCompraItens.Columns[2].ReadOnly = true; // Código
                gvCompraItens.Columns[3].ReadOnly = true; // Descrição
                gvCompraItens.Columns[4].ReadOnly = true; // Qtd. Solicitada
                gvCompraItens.Columns[5].ReadOnly = true; // Qtd. Recebida
                gvCompraItens.Columns[6].ReadOnly = true; // Valor Unit.
                gvCompraItens.Columns[7].ReadOnly = true; // Valor Desc.
                gvCompraItens.Columns[8].ReadOnly = true; // Total
                gvCompraItens.Columns[9].ReadOnly = true; // ICMS
                gvCompraItens.Columns[10].ReadOnly = true; // IPI
                gvCompraItens.Columns[11].ReadOnly = true; // Data Conferência
                gvCompraItens.Columns[12].ReadOnly = true; // Estq Atual
                gvCompraItens.Columns[13].ReadOnly = true; // Estq Min
                gvCompraItens.Columns[14].ReadOnly = true; // Estq Max
                gvCompraItens.Columns[15].ReadOnly = true; // Ultimo Preço

            }
            else if (cbStatus.SelectedValue.ToString() == "Recebido")
            {
                btAdicionarItens.Enabled = false;

                if (cCompra.GetArquivoXML(oCompra.id_compra) != null)
                    btGravarXml.Enabled = true;

                btArquivoXml.Enabled = true;
                btCopiarItem.Enabled = false;
                btEntrega.Enabled = false;
                btAprovar.Enabled = false;
                btCancelarCompra.Enabled = false;
                btConferir.Enabled = false;
                btFinalizar.Enabled = false;

                dtaPrevisaoEntrega.Enabled = false;
                dtaRecebimento.Enabled = false;
                btFornecedor.Enabled = false;
                btContasPagar.Enabled = true;

                gvCompraItens.Columns[0].ReadOnly = true; // id_compra_item
                gvCompraItens.Columns[1].ReadOnly = true; // id_produto
                gvCompraItens.Columns[2].ReadOnly = true; // Código
                gvCompraItens.Columns[3].ReadOnly = true; // Descrição
                gvCompraItens.Columns[4].ReadOnly = true; // Qtd. Solicitada
                gvCompraItens.Columns[5].ReadOnly = false; // Qtd. Recebida
                gvCompraItens.Columns[6].ReadOnly = true; // Valor Unit.
                gvCompraItens.Columns[7].ReadOnly = true; // Valor Desc.
                gvCompraItens.Columns[8].ReadOnly = true; // Total
                gvCompraItens.Columns[9].ReadOnly = true; // ICMS
                gvCompraItens.Columns[10].ReadOnly = true; // IPI
                gvCompraItens.Columns[11].ReadOnly = true; // Data Conferência
                gvCompraItens.Columns[12].ReadOnly = true; // Estq Atual
                gvCompraItens.Columns[13].ReadOnly = true; // Estq Min
                gvCompraItens.Columns[14].ReadOnly = true; // Estq Max
                gvCompraItens.Columns[15].ReadOnly = true; // Ultimo Preço
            }
            else if (cbStatus.SelectedValue.ToString() == "Finalizada")
            {
                btAdicionarItens.Enabled = false;

                if (cCompra.GetArquivoXML(oCompra.id_compra) != null)
                    btGravarXml.Enabled = true;

                btArquivoXml.Enabled = true;
                btCopiarItem.Enabled = false;
                btEntrega.Enabled = false;
                btAprovar.Enabled = false;
                btCancelarCompra.Enabled = false;
                btConferir.Enabled = false;
                btContasPagar.Enabled = true;
                btFinalizar.Enabled = false;

                dtaPrevisaoEntrega.Enabled = false;
                dtaRecebimento.Enabled = false;
                btFornecedor.Enabled = false;

                txtObservacao.ReadOnly = true;
                txtObservacaoComprador.ReadOnly = true;
                
                gvCompraItens.Columns[0].ReadOnly = true; // id_compra_item
                gvCompraItens.Columns[1].ReadOnly = true; // id_produto
                gvCompraItens.Columns[2].ReadOnly = true; // Código
                gvCompraItens.Columns[3].ReadOnly = true; // Descrição
                gvCompraItens.Columns[4].ReadOnly = true; // Qtd. Solicitada
                gvCompraItens.Columns[5].ReadOnly = true; // Qtd. Recebida
                gvCompraItens.Columns[6].ReadOnly = true; // Valor Unit.
                gvCompraItens.Columns[7].ReadOnly = true; // Valor Desc.
                gvCompraItens.Columns[8].ReadOnly = true; // Total
                gvCompraItens.Columns[9].ReadOnly = true; // ICMS
                gvCompraItens.Columns[10].ReadOnly = true; // IPI
                gvCompraItens.Columns[11].ReadOnly = true; // Data Conferência
                gvCompraItens.Columns[12].ReadOnly = true; // Estq Atual
                gvCompraItens.Columns[13].ReadOnly = true; // Estq Min
                gvCompraItens.Columns[14].ReadOnly = true; // Estq Max
                gvCompraItens.Columns[15].ReadOnly = true; // Ultimo Preço

            }
            else if (cbStatus.SelectedValue.ToString() == "Cancelada")
            {
                btAdicionarItens.Enabled = false;

                if (cCompra.GetArquivoXML(oCompra.id_compra) != null)
                    btGravarXml.Enabled = true;

                btArquivoXml.Enabled = true;
                btCopiarItem.Enabled = false;
                btEntrega.Enabled = false;
                btAprovar.Enabled = false;
                btCancelarCompra.Enabled = false;
                btConferir.Enabled = false;
                btContasPagar.Enabled = false;
                btFinalizar.Enabled = false;

                btEditar.Enabled = false;
                btExcluir.Enabled = false;
                
                txtObservacao.ReadOnly = true;
                txtObservacaoComprador.ReadOnly = true;
                
                gvCompraItens.Columns[0].ReadOnly = true; // id_compra_item
                gvCompraItens.Columns[1].ReadOnly = true; // id_produto
                gvCompraItens.Columns[2].ReadOnly = true; // Código
                gvCompraItens.Columns[3].ReadOnly = true; // Descrição
                gvCompraItens.Columns[4].ReadOnly = true; // Qtd. Solicitada
                gvCompraItens.Columns[5].ReadOnly = true; // Qtd. Recebida
                gvCompraItens.Columns[6].ReadOnly = true; // Valor Unit.
                gvCompraItens.Columns[7].ReadOnly = true; // Valor Desc.
                gvCompraItens.Columns[8].ReadOnly = true; // Total
                gvCompraItens.Columns[9].ReadOnly = true; // ICMS
                gvCompraItens.Columns[10].ReadOnly = true; // IPI
                gvCompraItens.Columns[11].ReadOnly = true; // Data Conferência
                gvCompraItens.Columns[12].ReadOnly = true; // Estq Atual
                gvCompraItens.Columns[13].ReadOnly = true; // Estq Min
                gvCompraItens.Columns[14].ReadOnly = true; // Estq Max
                gvCompraItens.Columns[15].ReadOnly = true; // Ultimo Preço
            }

            PreencherGridStatus();
        }
        private void TelaModoVisualizar()
        {
            this.oCompra = cCompra.GetCompraByID(id_compra);

            if (this.oCompra == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de compra.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }

            this.Text = "Compra - Visualizar cadastro de compra";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();

            txtCodigo.ReadOnly = true;
            txtCompraOrigem.ReadOnly = true;
            txtDataCadastro.ReadOnly = true;
            cbStatus.Enabled = false;

            txtFornecedor.ReadOnly = true;
            btFornecedor.Enabled = false;

            dtaPrevisaoEntrega.Enabled = false;
            dtaRecebimento.Enabled = false;

            txtTotalItens.ReadOnly = true;
            txtValorTotal.ReadOnly = true;
            cbFilial.Enabled = false;

            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            TravaFormControles(this.Controls);
            AtualizarGridItens();

            if (cbStatus.SelectedValue.ToString() == "Pendente")
            {
                btAdicionarItens.Enabled = true;

                if (cCompra.GetArquivoXML(oCompra.id_compra) != null)
                    btGravarXml.Enabled = true;

                btArquivoXml.Enabled = true;
                btCopiarItem.Enabled = true;
                btAprovar.Enabled = true;
                btEntrega.Enabled = false;
                btCancelarCompra.Enabled = true;
                btConferir.Enabled = false;
                btContasPagar.Enabled = true;
                btFinalizar.Enabled = false;

                gvCompraItens.Columns[0].ReadOnly = true; // id_compra_item
                gvCompraItens.Columns[1].ReadOnly = true; // id_produto
                gvCompraItens.Columns[2].ReadOnly = true; // Código
                gvCompraItens.Columns[3].ReadOnly = true; // Descrição
                gvCompraItens.Columns[4].ReadOnly = true; // Qtd. Solicitada
                gvCompraItens.Columns[5].ReadOnly = true; // Qtd. Recebida
                gvCompraItens.Columns[6].ReadOnly = true; // Valor Unit.
                gvCompraItens.Columns[7].ReadOnly = true; // Valor Desc.
                gvCompraItens.Columns[8].ReadOnly = true; // Total
                gvCompraItens.Columns[9].ReadOnly = true; // ICMS
                gvCompraItens.Columns[10].ReadOnly = true; // IPI
                gvCompraItens.Columns[11].ReadOnly = true; // Data Conferência
                gvCompraItens.Columns[12].ReadOnly = true; // Estq Atual
                gvCompraItens.Columns[13].ReadOnly = true; // Estq Min
                gvCompraItens.Columns[14].ReadOnly = true; // Estq Max
                gvCompraItens.Columns[15].ReadOnly = true; // Ultimo Preço

            }
            else if (cbStatus.SelectedValue.ToString() == "Aprovada")
            {
                btAdicionarItens.Enabled = false;

                if (cCompra.GetArquivoXML(oCompra.id_compra) != null)
                    btGravarXml.Enabled = true;

                btArquivoXml.Enabled = true;
                btCopiarItem.Enabled = false;
                btEntrega.Enabled = true;
                btAprovar.Enabled = false;
                btCancelarCompra.Enabled = true;
                btConferir.Enabled = false;
                btContasPagar.Enabled = true;
                btFinalizar.Enabled = false;

                btEditar.Enabled = true;
                btExcluir.Enabled = false;

                btFornecedor.Enabled = false;
                dtaPrevisaoEntrega.Enabled = false;
                dtaRecebimento.Enabled = false;
                txtObservacao.ReadOnly = true;
                txtObservacaoComprador.ReadOnly = true;
                
                gvCompraItens.Columns[0].ReadOnly = true; // id_compra_item
                gvCompraItens.Columns[1].ReadOnly = true; // id_produto
                gvCompraItens.Columns[2].ReadOnly = true; // Código
                gvCompraItens.Columns[3].ReadOnly = true; // Descrição
                gvCompraItens.Columns[4].ReadOnly = true; // Qtd. Solicitada
                gvCompraItens.Columns[5].ReadOnly = true; // Qtd. Recebida
                gvCompraItens.Columns[6].ReadOnly = true; // Valor Unit.
                gvCompraItens.Columns[7].ReadOnly = true; // Valor Desc.
                gvCompraItens.Columns[8].ReadOnly = true; // Total
                gvCompraItens.Columns[9].ReadOnly = true; // ICMS
                gvCompraItens.Columns[10].ReadOnly = true; // IPI
                gvCompraItens.Columns[11].ReadOnly = true; // Data Conferência
                gvCompraItens.Columns[12].ReadOnly = true; // Estq Atual
                gvCompraItens.Columns[13].ReadOnly = true; // Estq Min
                gvCompraItens.Columns[14].ReadOnly = true; // Estq Max
                gvCompraItens.Columns[15].ReadOnly = true; // Ultimo Preço

            }
            else if (cbStatus.SelectedValue.ToString() == "Recebido")
            {
                btAdicionarItens.Enabled = false;

                if (cCompra.GetArquivoXML(oCompra.id_compra) != null)
                    btGravarXml.Enabled = true;

                btArquivoXml.Enabled = true;
                btCopiarItem.Enabled = false;
                btEntrega.Enabled = false;
                btAprovar.Enabled = false;
                btCancelarCompra.Enabled = false;
                btConferir.Enabled = true;
                btContasPagar.Enabled = true;
                btFinalizar.Enabled = true;

                btEditar.Enabled = true;
                btExcluir.Enabled = false;
                
                gvCompraItens.Columns[0].ReadOnly = true; // id_compra_item
                gvCompraItens.Columns[1].ReadOnly = true; // id_produto
                gvCompraItens.Columns[2].ReadOnly = true; // Código
                gvCompraItens.Columns[3].ReadOnly = true; // Descrição
                gvCompraItens.Columns[4].ReadOnly = true; // Qtd. Solicitada
                gvCompraItens.Columns[5].ReadOnly = true; // Qtd. Recebida
                gvCompraItens.Columns[6].ReadOnly = true; // Valor Unit.
                gvCompraItens.Columns[7].ReadOnly = true; // Valor Desc.
                gvCompraItens.Columns[8].ReadOnly = true; // Total
                gvCompraItens.Columns[9].ReadOnly = true; // ICMS
                gvCompraItens.Columns[10].ReadOnly = true; // IPI
                gvCompraItens.Columns[11].ReadOnly = true; // Data Conferência
                gvCompraItens.Columns[12].ReadOnly = true; // Estq Atual
                gvCompraItens.Columns[13].ReadOnly = true; // Estq Min
                gvCompraItens.Columns[14].ReadOnly = true; // Estq Max
                gvCompraItens.Columns[15].ReadOnly = true; // Ultimo Preço

            }
            else if (cbStatus.SelectedValue.ToString() == "Finalizada")
            {
                btAdicionarItens.Enabled = false;

                if (cCompra.GetArquivoXML(oCompra.id_compra) != null)
                    btGravarXml.Enabled = true;

                btArquivoXml.Enabled = true;
                btCopiarItem.Enabled = false;
                btEntrega.Enabled = false;
                btAprovar.Enabled = false;
                btCancelarCompra.Enabled = false;
                btConferir.Enabled = false;
                btContasPagar.Enabled = true;
                btFinalizar.Enabled = false;

                btEditar.Enabled = false;
                btExcluir.Enabled = false;


                gvCompraItens.Columns[0].ReadOnly = true; // id_compra_item
                gvCompraItens.Columns[1].ReadOnly = true; // id_produto
                gvCompraItens.Columns[2].ReadOnly = true; // Código
                gvCompraItens.Columns[3].ReadOnly = true; // Descrição
                gvCompraItens.Columns[4].ReadOnly = true; // Qtd. Solicitada
                gvCompraItens.Columns[5].ReadOnly = true; // Qtd. Recebida
                gvCompraItens.Columns[6].ReadOnly = true; // Valor Unit.
                gvCompraItens.Columns[7].ReadOnly = true; // Valor Desc.
                gvCompraItens.Columns[8].ReadOnly = true; // Total
                gvCompraItens.Columns[9].ReadOnly = true; // ICMS
                gvCompraItens.Columns[10].ReadOnly = true; // IPI
                gvCompraItens.Columns[11].ReadOnly = true; // Data Conferência
                gvCompraItens.Columns[12].ReadOnly = true; // Estq Atual
                gvCompraItens.Columns[13].ReadOnly = true; // Estq Min
                gvCompraItens.Columns[14].ReadOnly = true; // Estq Max
                gvCompraItens.Columns[15].ReadOnly = true; // Ultimo Preço

            }
            else if (cbStatus.SelectedValue.ToString() == "Cancelada")
            {
                btAdicionarItens.Enabled = false;

                if (cCompra.GetArquivoXML(oCompra.id_compra) != null)
                    btGravarXml.Enabled = true;

                btArquivoXml.Enabled = true;
                btCopiarItem.Enabled = false;
                btEntrega.Enabled = false;
                btAprovar.Enabled = false;
                btCancelarCompra.Enabled = false;
                btConferir.Enabled = false;
                btContasPagar.Enabled = false;
                btFinalizar.Enabled = false;

                btEditar.Enabled = false;
                btExcluir.Enabled = false;

                gvCompraItens.Columns[0].ReadOnly = true; // id_compra_item
                gvCompraItens.Columns[1].ReadOnly = true; // id_produto
                gvCompraItens.Columns[2].ReadOnly = true; // Código
                gvCompraItens.Columns[3].ReadOnly = true; // Descrição
                gvCompraItens.Columns[4].ReadOnly = true; // Qtd. Solicitada
                gvCompraItens.Columns[5].ReadOnly = true; // Qtd. Recebida
                gvCompraItens.Columns[6].ReadOnly = true; // Valor Unit.
                gvCompraItens.Columns[7].ReadOnly = true; // Valor Desc.
                gvCompraItens.Columns[8].ReadOnly = true; // Total
                gvCompraItens.Columns[9].ReadOnly = true; // ICMS
                gvCompraItens.Columns[10].ReadOnly = true; // IPI
                gvCompraItens.Columns[11].ReadOnly = true; // Data Conferência
                gvCompraItens.Columns[12].ReadOnly = true; // Estq Atual
                gvCompraItens.Columns[13].ReadOnly = true; // Estq Min
                gvCompraItens.Columns[14].ReadOnly = true; // Estq Max
                gvCompraItens.Columns[15].ReadOnly = true; // Ultimo Preço

            }

            PreencherGridStatus();
        }
        #endregion

        #region # Menu Ação #
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
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o Compra: " + oCompra.id_compra + "!", "Cadastro de compra.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                oCompra.excluido = true;
                if (cCompra.CompraEditar(ref oCompra))
                    TelaModoCadastrarNovo();
            }
        }
        private void btGravar_Click(object sender, EventArgs e)
        {
            ValidForm();
            if (FormIsValid)
                PreencherCompra();

            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    if (!string.IsNullOrEmpty(cbFilial.GetSelectedValue()))
                        oCompra.id_empresa = long.Parse(cbFilial.GetSelectedValue());

                    oCompra.id_usuario_cadastro = Util.AuthEntity.UsuarioOnLine.id_usuario;
                    oCompra.data_cadastro = Util.Util.GetDataServidor();

                    if (cCompra.CompraCadastrar(ref oCompra))
                    {
                        this.id_compra = oCompra.id_compra;
                        TelaModoVisualizar();
                    }
                    else
                    {
                        MessageBox.Show(null, "Não foi possivel cadastrar a compra!", "Erro ao cadastrar compra.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cCompra.CompraEditar(ref oCompra))
                    {
                        GravarItens();
                        TelaModoVisualizar();                        
                    }
                    else
                        MessageBox.Show(null, "Não foi possivel editar compra!", "Erro ao cadastrar compra.", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void PreencherCompra()
        {
            if (txtFornecedor.Tag != null)
                oCompra.id_fornecedor = ((fornecedor)txtFornecedor.Tag).id_fornecedor;

            if (!string.IsNullOrEmpty(cbStatus.SelectedValue.ToString()))
                oCompra.status = cbStatus.SelectedValue.ToString();
            else
                oCompra.status = "Pendente";

            if (dtaPrevisaoEntrega.Checked)
                oCompra.data_previsao = dtaPrevisaoEntrega.Value;
            else
                oCompra.data_previsao = null;

            if (dtaRecebimento.Checked)
                oCompra.data_recebimento = dtaRecebimento.Value;
            else
                oCompra.data_recebimento = null;

            oCompra.observacao = txtObservacao.Text;
            oCompra.observacao_comprador = txtObservacaoComprador.Text;
        }
        private void PreencherCampos()
        {
            txtCodigo.Text = oCompra.id_compra.ToString();
            txtDataCadastro.Text = oCompra.data_cadastro.ToString("dd/MM/yyyy");
            txtCompraOrigem.Text = oCompra.id_compra_origem.ToString();

            cbFilial.SetSelectedValue(oCompra.empresa.id_empresa.ToString());

            txtFornecedor.Tag = oCompra.fornecedor;
            txtFornecedor.Text = oCompra.fornecedor.id_fornecedor + " - " + oCompra.fornecedor.nome_fantasia;

            try
            {
                txtValorTotal.Text = string.Format("{0:n}", oCompra.compra_item.Select(o => ((o.valor_unitario - o.valor_desconto) * o.quantidade_solicitada)).SingleOrDefault());
            }
            catch { }

            cbStatus.SelectedValue = oCompra.status;

            if (oCompra.data_previsao != null)
            {
                dtaPrevisaoEntrega.Value = oCompra.data_previsao.Value;
                dtaPrevisaoEntrega.Checked = true;
            }

            if (oCompra.data_recebimento != null)
            {
                dtaRecebimento.Value = oCompra.data_recebimento.Value;
                dtaRecebimento.Checked = true;
            }

            txtObservacao.Text = oCompra.observacao;
            txtObservacaoComprador.Text = oCompra.observacao_comprador;
            TotalizarCompra();
        }
        #endregion

        #region # Validação de Formulario #
        private void ValidForm()
        {
            this.FormIsValid = true;
            bool erro = false;

            if (txtFornecedor.Tag == null)
            {
                erro = true;
                txtFornecedor.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtFornecedor, "Campo fornecedor é obrigatório.");
            }
            else
                txtFornecedor.BackColor = DefaultBackColor;

            if (erro)
                this.FormIsValid = false;
        }
        #endregion

        #region # Lockups #
        private void btFornecedor_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fornecedor.Forms.frmFornecedorLockup fFornecedorLockup = new cms.Modulos.Fornecedor.Forms.frmFornecedorLockup();

            if (fFornecedorLockup.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fornecedor = fFornecedorLockup.GetFornecedorSelecionado();

                txtFornecedor.Tag = fornecedor;
                txtFornecedor.Text = fornecedor.id_fornecedor + " - " + fornecedor.nome_fantasia;

                fFornecedorLockup.Close();
                fFornecedorLockup.Dispose();
            }
            else
            {
                txtFornecedor.Tag = null;
                txtFornecedor.Text = string.Empty;
            }
        }
        private void txtFornecedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                btFornecedor_Click(sender, e);
            }
        }
        #endregion

        #region # Itens #
        private void btAdicionarItens_Click(object sender, EventArgs e)
        {
            cms.Modulos.Compra.Forms.frmCompraItens fCompraItens = new cms.Modulos.Compra.Forms.frmCompraItens();
            fCompraItens.id_compra = oCompra.id_compra;
            fCompraItens.ShowDialog();

            AtualizarGridItens();
        }

        private void AtualizarGridItens()
        {
            var itens = cCompra.GetCompraItemByIdCompra(oCompra.id_compra);
            gvCompraItens.Rows.Clear();
            
            fornecedor oFornecedor = (fornecedor)txtFornecedor.Tag;
            
            foreach (var i in itens)
            {
                int index = 0;
                empresa oEmpresa = cbFilial.GetEmpresa();
                produto oProduto = cProduto.GetProdutoByID(i.id_produto);
                produto_estoque oEstoque = oProduto.produto_estoque.Where(o => o.id_empresa == oEmpresa.id_empresa).SingleOrDefault();
                produto_ipi_icms oIcms = oProduto.produto_ipi_icms.Where(o => o.uf == oFornecedor.end_estado).SingleOrDefault();

                DataGridViewRow new_row = new DataGridViewRow();

                DataGridViewTextBoxCell dgvCell00 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell01 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell02 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell03 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell04 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell05 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell06 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell07 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell08 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell09 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell10 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell11 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell12 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell13 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell14 = new DataGridViewTextBoxCell();
                DataGridViewTextBoxCell dgvCell15 = new DataGridViewTextBoxCell();

                new_row.Cells.Add(dgvCell00);
                new_row.Cells.Add(dgvCell01);
                new_row.Cells.Add(dgvCell02);
                new_row.Cells.Add(dgvCell03);
                new_row.Cells.Add(dgvCell04);
                new_row.Cells.Add(dgvCell05);
                new_row.Cells.Add(dgvCell06);
                new_row.Cells.Add(dgvCell07);
                new_row.Cells.Add(dgvCell08);
                new_row.Cells.Add(dgvCell09);
                new_row.Cells.Add(dgvCell10);
                new_row.Cells.Add(dgvCell11);
                new_row.Cells.Add(dgvCell12);
                new_row.Cells.Add(dgvCell13);
                new_row.Cells.Add(dgvCell14);
                new_row.Cells.Add(dgvCell15);
                
                // # id_compra #
                new_row.Cells[0].Value = i.id_compra_item;

                // # id_produto #
                new_row.Cells[1].Value = i.id_produto;

                // # Código #
                new_row.Cells[2].Value = i.id_produto;

                // # Descrição #
                new_row.Cells[3].Value = i.descricao;

                // # Qtd. Solicitada #
                new_row.Cells[4].Value = i.quantidade_solicitada;

                // # Qtd. Recebida #
                new_row.Cells[5].Value = i.quantidade_recebida;

                // # Valor Unitario #
                new_row.Cells[6].Value = i.valor_unitario;

                // # Valor Desconto #
                new_row.Cells[7].Value = i.valor_desconto;

                // # Total #
                new_row.Cells[8].Value = i.valor_unitario * i.quantidade_solicitada;

                if (oIcms != null)
                {
                    // # ICMS #
                    new_row.Cells[9].Value = oIcms.aliquota_icms;

                    // # IPI #
                    new_row.Cells[10].Value = oIcms.aliquota_ipi;
                }
                else
                {
                    cnFiscalIcms cFiscalIcms = new cnFiscalIcms();
                    fiscal_icms icms = cFiscalIcms.GetIcmsByUf(oFornecedor.end_estado, oEmpresa.end_estado);
                    
                    // # ICMS #
                    new_row.Cells[9].Value = icms.aliquota_destino;

                    // # IPI #
                    new_row.Cells[10].Value = oProduto.ipi_aliquota;
                }

                if (i.data_conferencia != null)
                {
                    // # Data Conferencia #
                    new_row.Cells[11].Value = i.data_conferencia.Value.ToString("dd/MM/yyyy");
                }

                if (oEstoque != null)
                {
                    // # Estq Atual #
                    new_row.Cells[12].Value = (oEstoque.quantidade_estoque - oEstoque.quantidade_reservada);

                    // # Estq Min #
                    new_row.Cells[13].Value = oEstoque.estoque_minino;

                    // # Estq Max #
                    new_row.Cells[14].Value = oEstoque.estoque_maximo;
                }
                else
                {
                    // # Estq Atual #
                    new_row.Cells[12].Value = "0,00";

                    // # Estq Min #
                    new_row.Cells[13].Value = "0,00";

                    // # Estq Max #
                    new_row.Cells[14].Value = "0,00"; 
                }

                // # Ultimo Preço #
                new_row.Cells[15].Value = cCompra.GetUltimoPreco(i.id_compra, i.id_produto);
                
                if (cbStatus.SelectedValue.ToString() == "Pendente")
                {
                    // # Total #
                    new_row.Cells[8].Value = string.Format("{0:n}",
                        ((i.valor_unitario-i.valor_desconto) * i.quantidade_solicitada));
                }
                else
                {
                    // # Total #
                    new_row.Cells[8].Value = string.Format("{0:n}",
                        ((i.valor_unitario - i.valor_desconto) * i.quantidade_recebida));
                }

                index = gvCompraItens.Rows.Add(new_row);

                gvCompraItens.Rows[index].Selected = false;

                if (i.conferido)
                    gvCompraItens.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
            }

            if (cbStatus.SelectedValue.ToString() == "Pendente")
            {
                gvCompraItens.Columns[5].ReadOnly = true;
            }

            TotalizarCompra();
        }

        private void gvCompraItens_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal valor = 0;

            if (e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7 || e.ColumnIndex == 8 || e.ColumnIndex == 9)
                if (decimal.TryParse(gvCompraItens.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out valor))
                    gvCompraItens.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:n}", valor);

            decimal qtd_solicitada = 0;
            decimal qtd_recebida = 0;
            decimal valor_unit = 0;
            decimal valor_total = 0;
            decimal valor_desc = 0;
            decimal total_pagar = 0;

            qtd_solicitada = decimal.Parse(gvCompraItens.Rows[e.RowIndex].Cells[4].Value.ToString());
            qtd_recebida = decimal.Parse(gvCompraItens.Rows[e.RowIndex].Cells[5].Value.ToString());
            valor_unit = decimal.Parse(gvCompraItens.Rows[e.RowIndex].Cells[6].Value.ToString());
            valor_desc = decimal.Parse(gvCompraItens.Rows[e.RowIndex].Cells[7].Value.ToString());

            if (cbStatus.SelectedValue.ToString() == "Pendente")
                valor_total = qtd_solicitada * (valor_unit - valor_desc);
            else
                valor_total = qtd_recebida * (valor_unit - valor_desc);

            total_pagar = valor_total;

            gvCompraItens.Rows[e.RowIndex].Cells[8].Value = total_pagar;

            if (e.ColumnIndex == 5)
                gvCompraItens.Rows[e.RowIndex].Cells[11].Value = Util.Util.GetDataServidor();

            TotalizarCompra();
        }

        private void gvCompraItens_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            decimal valor = 0;

            if (e.ColumnIndex == 4 || e.ColumnIndex == 5 || e.ColumnIndex == 6 || e.ColumnIndex == 7)
                if (!decimal.TryParse(e.FormattedValue.ToString(), out valor))
                    e.Cancel = true;

            TotalizarCompra();
        }

        private void TotalizarCompra()
        {
            decimal total = 0;

            for(int i = 0; i < gvCompraItens.Rows.Count; i++)
            {
                try
                {
                    total += decimal.Parse(gvCompraItens.Rows[i].Cells[8].Value.ToString());
                }
                catch { }
            }
            
            txtTotalItens.Text = gvCompraItens.Rows.Count.ToString();
            txtValorTotal.Text = string.Format("{0:n}", total);
        }

        private void gvCompraItens_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (MessageBox.Show(null, "Tem certeza que deseja excluir estes itens?", "Itens da compra.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    List<long> itens = new List<long>();
                    
                    foreach (DataGridViewRow dr in gvCompraItens.SelectedRows)
                    {
                        itens.Add(Convert.ToInt64(dr.Cells[0].Value));
                        gvCompraItens.Rows.Remove(dr);
                    }

                    cCompra.CompraItensExcluir(itens);
                    AtualizarGridItens();
                }
            }
        }

        private void GravarItens()
        {
            List<compra_item> itens = new List<compra_item>();

            for (int i = 0; i < gvCompraItens.Rows.Count; i++)
            {
                long id_compra_item = 0;
                long id_produto = 0;
                decimal qtd_solicitada = 0;
                decimal qtd_recebida = 0;
                decimal valor_unit = 0;
                decimal valor_total = 0;
                decimal valor_desc = 0;
                decimal total_pagar = 0;
                DateTime data_conferencia = new DateTime();

                id_compra_item = long.Parse(gvCompraItens.Rows[i].Cells[0].Value.ToString());
                id_produto = long.Parse(gvCompraItens.Rows[i].Cells[1].Value.ToString());

                qtd_solicitada = decimal.Parse(gvCompraItens.Rows[i].Cells[4].Value.ToString());
                qtd_recebida = decimal.Parse(gvCompraItens.Rows[i].Cells[5].Value.ToString());
                valor_unit = decimal.Parse(gvCompraItens.Rows[i].Cells[6].Value.ToString());
                valor_total = decimal.Parse(gvCompraItens.Rows[i].Cells[8].Value.ToString());
                valor_desc = decimal.Parse(gvCompraItens.Rows[i].Cells[7].Value.ToString());
                total_pagar = decimal.Parse(gvCompraItens.Rows[i].Cells[9].Value.ToString());
                
                compra_item item = new compra_item();

                item.id_compra = oCompra.id_compra;
                item.id_compra_item = id_compra_item;
                item.id_produto = id_produto;
                item.quantidade_recebida = qtd_recebida;
                item.quantidade_solicitada = qtd_solicitada;
                item.valor_desconto = valor_desc;
                item.valor_unitario = valor_unit;

                if (gvCompraItens.Rows[i].Cells[11].Value != null && !string.IsNullOrEmpty(gvCompraItens.Rows[i].Cells[11].Value.ToString()))
                {
                    DateTime.TryParse(gvCompraItens.Rows[i].Cells[11].Value.ToString(), out data_conferencia);
                    item.data_conferencia = data_conferencia;
                    item.conferido = true;
                }

                itens.Add(item);
            }
            cCompra.CompraItemEditar(itens);
        }
        #endregion
         
        #region # XML #
        private void btArquivoXml_Click(object sender, EventArgs e)
        {
            if (OpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                compra_xml arquivo = new compra_xml();
                arquivo.id_compra = oCompra.id_compra;
                arquivo.nome = OpenFile.SafeFileName;

                Stream st = OpenFile.OpenFile();

                DataSet ds = new DataSet();
                ds.ReadXml(st);

                arquivo.arquivo = Util.Util.ReadFile(st);
                
                cCompra.ArquivoCadastrar(arquivo);
            }
        }
        private void btGravarXml_Click(object sender, EventArgs e)
        {
            compra_xml arquivo = cCompra.GetArquivoXML(oCompra.id_compra);
                        
            if (arquivo != null)
            {
                SaveFile.FileName = arquivo.nome;
                if (SaveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    string file = SaveFile.FileName;

                    File.WriteAllBytes(file, arquivo.arquivo);
                }
            }
            else
            {
                MessageBox.Show(null, "Não existe arquivo para ser gravado!", "Gravar arquivo xml da compra.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region # Copiar Itens #
        private void btCopiarItem_Click(object sender, EventArgs e)
        {
            frmCompraCopiarItens copia = new frmCompraCopiarItens();

            copia.ShowDialog();

            long id_compra_origem = copia.id_compra;
            if (cCompra.CompraItemCopiar(id_compra_origem, oCompra.id_compra))
            {
                AtualizarGridItens();
                MessageBox.Show(null, "Os itens da compra: " + id_compra_origem + " foram copiados com sucesso.", "Copiar itens de compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(null, "Não foi possivel copiar itens da compra: " + id_compra_origem + " foram copiados com sucesso.", "Copiar itens de compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region # Status #

        private void PreencherGridStatus()
        {
            gvStatus.Rows.Clear();
            
            if (oCompra.id_usuario_finalizado > 0 && oCompra.data_finalizado != null)
                gvStatus.Rows.Add("Finalizado", oCompra.data_finalizado.Value.ToString("dd/MM/yyyy"), oCompra.id_usuario_finalizado + " - " + oCompra.usuario4.nome);
            
            if (oCompra.id_usuario_cancelamento > 0 && oCompra.data_cancelamento != null)
                gvStatus.Rows.Add("Cancelado", oCompra.data_cancelamento.Value.ToString("dd/MM/yyyy"), oCompra.id_usuario_cancelamento + " - " + oCompra.usuario2.nome);

            if (oCompra.id_usuario_conferencia > 0 && oCompra.data_conferencia != null)
                gvStatus.Rows.Add("Conferencia", oCompra.data_conferencia.Value.ToString("dd/MM/yyyy"), oCompra.id_usuario_conferencia + " - " + oCompra.usuario3.nome);

            if (oCompra.id_usuario_recebimento > 0 && oCompra.data_recebimento != null)
                gvStatus.Rows.Add("Recebido", oCompra.data_recebimento.Value.ToString("dd/MM/yyyy"), oCompra.id_usuario_recebimento + " - " + oCompra.usuario5.nome);

            if (oCompra.id_usuario_aprovacao > 0 && oCompra.data_aprovacao != null)
                gvStatus.Rows.Add("Aprovado", oCompra.data_aprovacao.Value.ToString("dd/MM/yyyy"), oCompra.id_usuario_aprovacao + " - " + oCompra.usuario.nome);
            
            if (oCompra.id_usuario_cadastro > 0 && oCompra.data_cadastro != null)
                gvStatus.Rows.Add("Cadastro", oCompra.data_cadastro.ToString("dd/MM/yyyy"), oCompra.id_usuario_cadastro + " - " + oCompra.usuario1.nome);
            
        }

        private void btAprovar_Click(object sender, EventArgs e)
        {
            oCompra.id_usuario_aprovacao = Util.AuthEntity.UsuarioOnLine.id_usuario;
            oCompra.data_aprovacao = Util.Util.GetDataServidor();
            oCompra.status = "Aprovada";

            cCompra.CompraEditar(ref oCompra);
            TelaModoVisualizar();
        }

        private void btCancelarCompra_Click(object sender, EventArgs e)
        {
            oCompra.id_usuario_cancelamento = Util.AuthEntity.UsuarioOnLine.id_usuario;
            oCompra.data_cancelamento = Util.Util.GetDataServidor();
            oCompra.status = "Cancelada";

            cCompra.CompraEditar(ref oCompra);
            TelaModoVisualizar();
        }

        private void btEntrega_Click(object sender, EventArgs e)
        {
            oCompra.id_usuario_recebimento = Util.AuthEntity.UsuarioOnLine.id_usuario;
            oCompra.data_recebimento = Util.Util.GetDataServidor();
            oCompra.status = "Recebido";

            cCompra.CompraEditar(ref oCompra);
            TelaModoVisualizar();
        }

        #endregion

        #region # Conferencia #
        private void btConferir_Click(object sender, EventArgs e)
        {
            frmCompraConferencia fCompraConferencia = new frmCompraConferencia();
            fCompraConferencia.id_compra = oCompra.id_compra;
            fCompraConferencia.ShowDialog();

            AtualizarGridItens();
        }
        #endregion

        #region # Compra Pagamento #

        private void btContasPagar_Click(object sender, EventArgs e)
        {
            frmCompraPagamento fCompraPagamento = new frmCompraPagamento();
            fCompraPagamento.id_compra = oCompra.id_compra;
            fCompraPagamento.ShowDialog();
            TelaModoVisualizar();
        }

        #endregion

        #region # Finalizar Compra #
        private void btFinalizar_Click(object sender, EventArgs e)
        {
            if (oCompra.compra_pagamento.Count == 0)
            {
                MessageBox.Show("Não existe condições de pagamento para esta compra!", "Finalizando a compra.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            cnFinanceiroContaPagar cFinanceiroContaPagar = new cnFinanceiroContaPagar();
            cnProduto cProduto = new cnProduto();

            int count = 1;
            foreach (compra_pagamento pagamento in oCompra.compra_pagamento)
            {
                financeiro_conta_pagar pagar = new financeiro_conta_pagar();

                pagar.id_compra = oCompra.id_compra;
                pagar.id_financeiro_forma_pagamento = pagamento.id_financeiro_forma_pagamento.Value;
                pagar.data_cadastro = Util.Util.GetDataServidor();
                pagar.data_vencimento = pagamento.data_vencimento;
                pagar.valor_vencimento = pagamento.valor;
                pagar.descricao = "Compra: " + oCompra.id_compra + " - " + count.ToString().PadRight(0, '0') + "/" + oCompra.compra_pagamento.Count.ToString().PadRight(0, '0');
                pagar.id_empresa = oCompra.id_empresa;
                pagar.data_lancamento = Util.Util.GetDataServidor();
                
                count++;
                pagar.documento = pagamento.numero_documento;
                pagar.id_fornecedor = oCompra.id_fornecedor;

                cFinanceiroContaPagar.FinanceiroContaPagarCadastrar(ref pagar);

                pagamento.id_financeiro_conta_pagar = pagar.id_financeiro_conta_pagar;

                compra_pagamento p = pagamento;
                cCompra.CompraPagamentoEditar(ref p);
            }

            foreach (compra_item item in oCompra.compra_item)
            {
                if (!item.conferido)
                {
                    item.data_conferencia = Util.Util.GetDataServidor();
                    item.conferido = true;
                }
                else
                {
                    cProduto.IncrementaQuantidadeEstoque(oCompra.id_empresa, item.id_produto, item.quantidade_recebida);
                    cProduto.EstoqueHitorico(oCompra.id_empresa, oCompra.id_compra, null, item.id_produto, item.quantidade_recebida);
                }

                cCompra.CompraItemEditar(item);
            }

            oCompra.id_usuario_finalizado = Util.AuthEntity.UsuarioOnLine.id_usuario;
            oCompra.data_finalizado = Util.Util.GetDataServidor();
            oCompra.status = "Finalizada";
            
            cCompra.CompraEditar(ref oCompra);
            TelaModoVisualizar();
        }
        #endregion

        private void txtFornecedor_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
