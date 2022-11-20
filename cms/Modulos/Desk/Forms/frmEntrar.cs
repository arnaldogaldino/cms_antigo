using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;
using cms.Modulos.Util;
using cms.Data;
using cms.Modulos.Usuario.Cn;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace cms.Modulos.Desk.Forms
{
    public partial class frmEntrar : cms.Modulos.Util.WindowBase
    {
        bool entrar = false;

        public frmEntrar()
        {
            InitializeComponent();
            cbFilial.LabelSelecione = false;
        }

        private void btSair_Click(object sender, EventArgs e)
        {
            if (cbFilial.Visible == false)
            {
                Application.Exit();
            }
            else
            {
                cbFilial.Visible = false;
                
                txtSenha.Enabled = true;
                txtUsuario.Enabled = true;

                txtSenha.Text = string.Empty;
                txtUsuario.Text = string.Empty;

                cms.Modulos.Util.AuthEntity.UsuarioOnlineClear();
            }
        }

        private void btEntrar_Click(object sender, EventArgs e)
        {
            cnUsuario cUsuario = new cnUsuario();

            usuario userOnline = cUsuario.GetUsuarioByLogin(txtUsuario.Text, txtSenha.Text);

            if (userOnline != null)
            {
                cms.Modulos.Util.AuthEntity.SetUsuario(userOnline);
                if (!entrar)
                {
                    cbFilial.Atualizar();
                }

                if (cbFilial.ItemsCount() > 1)
                {
                    cbFilial.Visible = true;

                    txtSenha.Enabled = false;
                    txtUsuario.Enabled = false;

                    if (!entrar)
                    {
                        entrar = true;
                        return;
                    }
                    else
                    {
                        cms.Modulos.Util.AuthEntity.SetEmpresa((empresa)cbFilial.GetEmpresa());
                    }
                }
                else if (cbFilial.ItemsCount() == 1)
                {
                    cms.Modulos.Util.AuthEntity.SetEmpresa((empresa)cbFilial.GetEmpresa());
                }
                else if (cbFilial.ItemsCount() == 0)
                {
                    MessageBox.Show(null, "Este usuário não tem filial cadastrada!", "Login.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtSenha.Text = string.Empty;
                    txtUsuario.Text = string.Empty;
                    return;
                }

                cms.Modulos.Desk.Forms.frmDesktop fDesktop = new cms.Modulos.Desk.Forms.frmDesktop();
                fDesktop.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show(null, "Este usuário ou senha esta incorreto!", "Login.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSenha.Text = string.Empty;
                txtUsuario.Text = string.Empty;
            }
        }

        private void frmEntrar_Load(object sender, EventArgs e)
        {

        }


    }
}
