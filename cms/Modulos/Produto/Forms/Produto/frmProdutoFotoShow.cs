using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace cms.Modulos.Produto.Forms.Produto
{
    public partial class frmProdutoFotoShow : cms.Modulos.Util.WindowBase
    {
        public frmProdutoFotoShow(MemoryStream MemoryImage)
        {
            InitializeComponent();
            imgFoto.Image = Image.FromStream(MemoryImage);
        }
    }
}
