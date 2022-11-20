using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using RDI.NFe2.Business;
using RDI.Lince;

namespace RDI.NFe.Visual
{
    public partial class FrmCertificados : Form
    {
        Boolean isModified;

        public FrmCertificados()
        {
            InitializeComponent();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            if (isModified)
            {
                if (MessageBox.Show("Clique em Sim para salvar e em Não para sair sem salvar.", "Deseja salvar ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ClientEnvironment manager = null;
                    try
                    {
                        manager = Program.CreateManager();
                        Parametro oParam = Program.GetParametro(Program.empresa, manager);

                        oParam.certificado = cbCertificados.SelectedItem.ToString();

                        oParam.Save(manager);
                        oParam = null;
                        isModified = false;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        Program.DisposeManager(manager);

                        this.Close();
                        this.Dispose();
                    }
                }
                else
                {
                    this.Close();
                    this.Dispose();
                }
            }
            else
            {
                this.Close();
                this.Dispose();
            }
        }


        private void btCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FrmCertificados_Load(object sender, EventArgs e)
        {
        
            


        }

        private void FrmCertificados_Shown(object sender, EventArgs e)
        {

            
            ClientEnvironment manager = null;
            try
            {
                manager = Program.CreateManager();
                Parametro oParam = Program.GetParametro(Program.empresa, manager);

                Certificado.PopulaItems(cbCertificados.Items, oParam.usaWService);
                
                   
                    cbCertificados.SelectedItem = oParam.certificado;
                    isModified = false;

                    oParam = null;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Program.DisposeManager(manager);
            }


        }

        private void cbCertificados_SelectedIndexChanged(object sender, EventArgs e)
        {
            isModified = true;
        }
    }
}