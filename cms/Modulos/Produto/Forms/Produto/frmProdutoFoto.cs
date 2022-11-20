using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using cms.Data;
using cms.Modulos.Produto.Cn;

namespace cms.Modulos.Produto.Forms.Produto
{
    public partial class frmProdutoFoto : Form
    {
        cnProduto cProduto = new cnProduto();

        private long id_produto = 0;
        public long Id_produto
        {
            get { return id_produto; }
            set { id_produto = value; }
        }
             
        public frmProdutoFoto()
        {
            InitializeComponent();
            openFileDialog.Filter = "Foto (*.jpg)|*.jpg|All files (*.*)|*.*";
        }

        private void btCarregarFoto_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                decimal tamanho = 0;

                imgFoto.Image = Image.FromStream(openFileDialog.OpenFile());
                
                txtAltura.Text = imgFoto.Image.Width.ToString();
                txtLargura.Text = imgFoto.Image.Height.ToString();

                tamanho = openFileDialog.OpenFile().Length;

                if ((tamanho / 1024) <= 1024)
                    txtTamanho.Text = Math.Round((tamanho / 1024), 2).ToString() + " KB";
                else
                    txtTamanho.Text = Math.Round((tamanho / (1024 * 1024)), 2).ToString() + " MB";
            }
        }

        private void btConcluir_Click(object sender, EventArgs e)
        {
            produto_foto foto = new produto_foto();

            foto.id_produto = id_produto;
            foto.ordem = int.Parse(txtOrdem.Text);
            foto.principal = chkPrincipal.Checked;

            MemoryStream ms = new MemoryStream();
            imgFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            foto.imagem = ms.ToArray();

            cProduto.ProdutoFotoCadastrar(foto);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Hide();
        }

        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.Hide();
            this.Close();
        }
    }
}
