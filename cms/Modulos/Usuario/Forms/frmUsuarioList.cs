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
using cms.Modulos.Usuario.Cn;

namespace cms.Modulos.Usuario.Forms
{
    public partial class frmUsuarioList : cms.Modulos.Util.WindowBase
    {
        cnUsuario cUsuario = new cnUsuario();
        private IQueryable<usuario> usuarios;
        Thread threadPreencherGrid;
        cms.Modulos.Util.Carregando load = new cms.Modulos.Util.Carregando();
        
        public frmUsuarioList()
        {
            InitializeComponent();
        }

        void btCancelar_Click(object sender, EventArgs e)
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPesquisar_Click(object sender, EventArgs e)
        {
            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }

            load.btCancelar.Click += new EventHandler(btCancelar_Click);
            load.LoadShow(this);

            threadPreencherGrid = new Thread(AtualizarGvUsuario);
            threadPreencherGrid.IsBackground = true;
            threadPreencherGrid.Start();
        }
        
        private void btNovo_Click(object sender, EventArgs e)
        {
            cms.Modulos.Usuario.Forms.frmUsuario fUsuario = new cms.Modulos.Usuario.Forms.frmUsuario();

            fUsuario.Acao = Util.Acao.Cadastrar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fUsuario.MdiParent = this;
                fUsuario.Show();
            }
            else
                fUsuario.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void gvUsuario_DoubleClick(object sender, EventArgs e)
        {
            if (gvUsuario.CurrentRow == null)
                return;

            usuario oUsuario = (usuario)gvUsuario.CurrentRow.DataBoundItem;

            cms.Modulos.Usuario.Forms.frmUsuario fUsuario = new cms.Modulos.Usuario.Forms.frmUsuario();

            fUsuario.id_usuario = oUsuario.id_usuario;

            fUsuario.Acao = Util.Acao.Visualizar;

            if (((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag).DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fUsuario.MdiParent = this;
                fUsuario.Show();
            }
            else
                fUsuario.Show(((WeifenLuo.WinFormsUI.Docking.DockPanel)this.Tag));
        }

        private void AtualizarGvUsuario()
        {
            string usuario = string.Empty;
            string nome = string.Empty;

            long? id_usuario = null;
            if (txtCodigo.InvokeRequired)
                if (!string.IsNullOrEmpty(txtCodigo.Text))
                    id_usuario = long.Parse(txtCodigo.Text);

            if (txtUsuario.InvokeRequired)
                usuario = txtUsuario.Text;
            
            if (txtNome.InvokeRequired)
                nome = txtNome.Text;

            try
            {
                usuarios = cUsuario.UsuarioProcurar(id_usuario, nome, usuario);
            }
            catch
            {
                Thread.Sleep(200);
            }

            if (gvUsuario.InvokeRequired)
                gvUsuario.Invoke(new MethodInvoker(Preencher));
        }

        public void Preencher()
        {
            gvUsuario.AutoGenerateColumns = false;
            gvUsuario.DataSource = usuarios;
            gvUsuario.Refresh();

            if (threadPreencherGrid != null)
            {
                threadPreencherGrid.Abort();
                threadPreencherGrid = null;
                load.LoadHide(this);
            }
        }

        
       
    }
}
