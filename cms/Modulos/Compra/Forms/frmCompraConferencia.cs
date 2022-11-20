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
using cms.Modulos.Produto.Cn;
using System.IO;

namespace cms.Modulos.Compra.Forms
{
    public partial class frmCompraConferencia : cms.Modulos.Util.WindowBase
    {
        public long id_compra = 0;

        private compra oCompra = new compra();
        private cnCompra cCompra = new cnCompra();
        private vw_compra_item compra_item = null;
        private cnProduto cProduto = new cnProduto();

        public frmCompraConferencia()
        {
            InitializeComponent();
        }

        private void frmCompraConferencia_Load(object sender, EventArgs e)
        {
            AtualizarCampos();
            AtualizarTotais();
            AtualizarGrid();
        }

        public void AtualizarCampos()
        {
            oCompra = cCompra.GetCompraByID(id_compra);

            txtCodigo.Text = oCompra.id_compra.ToString();
            txtDataCadastro.Text = oCompra.data_cadastro.ToString("dd/MM/yyyy");
            txtFornecedor.Text = oCompra.id_fornecedor + " - " + oCompra.fornecedor.nome_fantasia;
            txtObservacao.Text = oCompra.observacao;
            txtObservacaoComprador.Text = oCompra.observacao_comprador;
            txtObservacaoConferencia.Text = oCompra.observacao_conferencia;
        }

        private void txtObservacaoConferencia_Leave(object sender, EventArgs e)
        {
            oCompra.observacao_conferencia = txtObservacaoConferencia.Text;

            cCompra.CompraEditar(ref oCompra);
        }

        private void txtQtdRecebida_Leave(object sender, EventArgs e)
        {
            //txtCodigoBarras.Focus();
            //txtCodigoBarras.SelectAll();
        }

        private void txtCodigoBarras_Leave(object sender, EventArgs e)
        {
            //txtQtdRecebida.Focus();
            //txtQtdRecebida.SelectAll();
        }

        private void btConfirma_Click(object sender, EventArgs e)
        {
            string codigo_barra = txtCodigoBarras.Text;

            vw_compra_item item = new vw_compra_item();

            try
            {
                item = cCompra.GetCompraItemByCodigoBarras(id_compra, codigo_barra);

                if (item == null)
                    throw new Exception("Este item não existe na compra!");

                if (compra_item != null)
                {
                    var item_edit = cCompra.GetCompraItemByIdCompraItem(compra_item.id_compra_item);

                    item_edit.quantidade_recebida = decimal.Parse(txtQtdRecebida.Text);
                    item_edit.data_conferencia = Util.Util.GetDataServidor();
                    item_edit.conferido = true;

                    cCompra.CompraItemEditar(item_edit);
                }

                txtCodigoBarras.Focus();
                txtCodigoBarras.SelectAll();

                compra_item = item;

                txtDescricao.Text = item.descricao;
                txtQtdSolicitada.Text = string.Format("{0:n}", item.quantidade_solicitada);
                txtQtdRecebida.Text = string.Format("{0:n}", item.quantidade_solicitada);
                MemoryStream stImagem = new MemoryStream(cProduto.GetProdutoFotoByIdProdutoFoto(item.id_produto).imagem);
                imgProduto.Image = Image.FromStream(stImagem, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(null, ex.Message, "Conferencia de itens da Compra", MessageBoxButtons.OK, MessageBoxIcon.Information);
                compra_item = null;
            }

            AtualizarTotais();
            AtualizarGrid();
        }

        private void AtualizarTotais()
        {
            var items = cCompra.GetCompraItemByIdCompra(id_compra);

            txtTotalItens.Text = items.Count().ToString();
            txtTotalAtendidos.Text = items.Where(o => o.quantidade_recebida >= o.quantidade_solicitada && o.conferido == true).Count().ToString();
            txtTotalNaoAtendidos.Text = items.Where(o => o.quantidade_recebida < o.quantidade_solicitada && o.conferido == true).Count().ToString();
            txtTotalNaoConferido.Text = items.Where(o => o.conferido == false).Count().ToString();
        }

        private void AtualizarGrid()
        {
            gvItens.DataSource = from i in cCompra.GetCompraItemConferidoByIdCompra(oCompra.id_compra)
                                 select new { i.id_compra_item, i.id_produto, i.descricao, i.quantidade_recebida, i.quantidade_solicitada, diferenca = i.quantidade_recebida - i.quantidade_solicitada };
            gvItens.Refresh();
        }
    }
}
