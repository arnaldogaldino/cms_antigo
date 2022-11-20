using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using RDI.NFe2.Business;
using RDI.Lince;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;



namespace RDI.NFe.Visual
{
    public partial class FrmMaster : Form
    {
        private List<ItemWithObject> Janelas;

        public FrmMaster()
        {
            InitializeComponent();
            Janelas = new List<ItemWithObject>();
        }

        private void CheckCanCreate(Type TypeFrm)
        {
            Boolean Create = true;
            Form oNewForm = null;

            foreach (Form oForm in this.MdiChildren)
            {
                if (oForm.Name == TypeFrm.Name)
                {
                    Create = false;
                    oNewForm = oForm;
                    break;
                }
            }

            if (Create)
            {
                oNewForm = (Form)Activator.CreateInstance(TypeFrm);
                oNewForm.MdiParent = this;
                oNewForm.Disposed += new EventHandler(oNewForm_Disposed);

                ItemWithObject item = new ItemWithObject();
                item.Frm = oNewForm;


                item.Item = janelasToolStripMenuItem.DropDownItems.Add(oNewForm.Text, null,
                    delegate
                    {
                        CheckCanCreate(oNewForm.GetType());
                    }
                    );


                Janelas.Add(item);


                oNewForm.Show();
            }

            oNewForm.BringToFront();

        }

        void oNewForm_Disposed(object sender, EventArgs e)
        {
            foreach (ItemWithObject item in Janelas)
            {
                if (item.Frm == ((Form)sender))
                {
                    janelasToolStripMenuItem.DropDownItems.Remove(item.Item);
                    Janelas.Remove(item);
                    break;
                }
            }
        }


        private void FrmMaster_Load(object sender, EventArgs e)
        {
            this.Hide();
            FrmSplash fSp = new FrmSplash();
            fSp.Show();
            fSp.Update();
            Thread.Sleep(3000);
            fSp.Close();
            this.Visible = true;
            this.Text = Program.empresa + " - RDI - Open NFe 2.00";
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.Dispose();
        }

        private void automaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmMonitor));
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmMonitor));
        }

        private void certificadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmCertificados));
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmCertificados));
        }


        private void webServicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmWebService));
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmSobre));
            

        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmSobre));
            

        }

        private void pastasDeArquivosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmDiretorios));
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmDiretorios));
            
        }

        private void proxyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmProxy));
            
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmProxy));
            
        }

        private void lotesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmLotes));
            
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmLotes));
            
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmWebService));
            
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmServicos));
            
        }

        private void serviçosPendenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmServicos));
            
        }

        private void notasFiscaisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmNotaFiscal));
            
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmNotaFiscal));
            
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            //consulta status do servidor
            ClientEnvironment manager = null;
            try
            {
                manager = Program.CreateManager();
                FuncaoAutomacao oFuncao = new FuncaoAutomacao(Program.empresa, manager);
                tsbStatusWebsrv.Checked = oFuncao.ConsultaStatus();
                oFuncao = null;
            }
            catch (Exception ex)
            {
            }
            finally
            {
                Program.DisposeManager(manager);
            }
        }

        

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmLog));
           
        }

        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
        private void FrmMaster_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair ?", "Sair do RDI - Open NFe 2.00", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;

        }

        private void toolStripButton1_Click_2(object sender, EventArgs e)
        {
        }

        private void logToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmLog));
        }

        private void toolStripButton1_Click_3(object sender, EventArgs e)
        {

        }

        private void notasInutilizadasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckCanCreate(typeof(FrmNotaInutilizada));
            
        }
    }
}
