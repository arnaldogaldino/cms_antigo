using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using cms.Data;

namespace cms.Modulos.Fiscal.Forms.Ncm
{
    public partial class bak_frmFiscalNcm : cms.Modulos.Util.WindowBase
    {
        cms.Modulos.Fiscal.Cn.cnFiscalNcm cFiscalNcm = new cms.Modulos.Fiscal.Cn.cnFiscalNcm();

        private fiscal_ncm fiscal_ncm = new fiscal_ncm();
        private fiscal_ncm_iva fiscal_ncm_iva = new fiscal_ncm_iva();
        
        public Util.Acao Acao { get; set; }
        public long id_fiscal_ncm { get; set; }

        public bak_frmFiscalNcm()
        {
            InitializeComponent();
        }

        private void frmFiscalNcm_Load(object sender, EventArgs e)
        {
            cbIvaEstado.DataSource = Util.Combos.Estado();
            cbIvaEstado.Refresh();

            gvIvaAliquota.AutoGenerateColumns = false;
            gvIvaAliquota.AutoGenerateColumns = false;

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
            this.fiscal_ncm = new fiscal_ncm();
            this.Text = "Ncm - Cadastrar novo ncm";

            this.Acao = Util.Acao.Cadastrar;
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            tsMenuIva.Enabled = true;

            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            tbAderecos.Visible = false;
        }
        private void TelaModoEditar()
        {
            this.Text = "Ncm - Editar cadastro de ncm";
            this.Acao = Util.Acao.Editar;

            DestravaFormControles(this.Controls);
            tsMenuIva.Enabled = true;
           
            btNovo.Enabled = false;
            btEditar.Enabled = false;
            btExcluir.Enabled = false;
            btGravar.Enabled = true;
            btCancelar.Enabled = true;
            btFechar.Enabled = true;

            tbAderecos.Visible = true;
        }
        private void TelaModoVisualizar()
        {
            this.fiscal_ncm = cFiscalNcm.GetFiscalNcmByID(id_fiscal_ncm);

            if (this.fiscal_ncm == null)
            {
                MessageBox.Show(null, "Este cadastro não existe!", "Cadastro de ncm.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TelaModoCadastrarNovo();
                return;
            }
            this.Text = "Ncm - Visualizar cadastro de ncm";
            this.Acao = Util.Acao.Visualizar;
            PreencherCampos();
 
            btNovo.Enabled = true;
            btEditar.Enabled = true;
            btExcluir.Enabled = true;
            btGravar.Enabled = false;
            btCancelar.Enabled = false;
            btFechar.Enabled = true;

            TravaFormControles(this.Controls);
            tbAderecos.Visible = true;
            tsMenuIva.Enabled = false;
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
                PreencherNCM();
            
            if (this.Acao == Util.Acao.Cadastrar)
            {
                if (FormIsValid)
                {
                    if (cFiscalNcm.FiscalNcmCadastrar(ref fiscal_ncm))
                    {
                        this.id_fiscal_ncm = fiscal_ncm.id_fiscal_ncm;
                        TelaModoVisualizar();
                    }
                    else
                    {
                        MessageBox.Show(null, "Não foi possivel cadastrar o ncm!", "Erro ao cadastrar ncm.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            if (this.Acao == Util.Acao.Editar)
            {
                if (FormIsValid)
                    if (cFiscalNcm.FiscalNcmEditar(ref fiscal_ncm))
                        TelaModoVisualizar();
                    else
                        MessageBox.Show(null, "Não foi possivel editar o ncm!", "Erro ao cadastrar ncm.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o Ncm: " + fiscal_ncm.ncm + "!", "Cadastro de Ncm.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                fiscal_ncm.excluido = true;
                if (cFiscalNcm.FiscalNcmEditar(ref fiscal_ncm))
                    TelaModoCadastrarNovo();
            }
        }

        private void btEditar_Click(object sender, EventArgs e)
        {
            DestravaFormControles(this.Controls);
            txtNcm.ReadOnly = true;
            TelaModoEditar();
        }

        private void btNovo_Click(object sender, EventArgs e)
        {
            LimparCampos(this.Controls);
            DestravaFormControles(this.Controls);
            txtNcm.ReadOnly = true;
            TelaModoCadastrarNovo();
        }

        private void PreencherNCM()
        {
            fiscal_ncm.ncm = txtNcm.Text;
            fiscal_ncm.descricao = txtDescricao.Text;
        }
        private void PreencherCampos()
        {
            txtNcm.Text = this.fiscal_ncm.ncm;
            txtDescricao.Text = this.fiscal_ncm.descricao;

            IvaAtualizaGrid();
        }
        #endregion

        #region Validação de Formulario
        private void ValidForm()
        {
            this.FormIsValid = true;
            bool erro = false;

            if (string.IsNullOrEmpty(txtNcm.Text))
            {
                erro = true;
                txtNcm.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtNcm, "Campo Ncm é obrigatório.");
            }
            else
                txtNcm.BackColor = DefaultBackColor;

            if (string.IsNullOrEmpty(txtDescricao.Text))
            {
                erro = true;
                txtDescricao.BackColor = CorCampoInvalido;
                this.ValidarForm.SetToolTip(this.txtDescricao, "Campo descrição é obrigatório.");
            }
            else
                txtDescricao.BackColor = DefaultBackColor;

            if (erro)
                this.FormIsValid = false;
        }
        #endregion
        
        #region Aliquotas Iva
        
        private void IvaNovo()
        {
            cbIvaEstado.ResetText();
            cbIvaEstado.SelectedValue = "";
            txtIvaAliquota.Text = "";

            cbIvaEstado.Focus();
            fiscal_ncm_iva = new fiscal_ncm_iva();
        }
        private void IvaAdd()
        {
            bool erro = false;

            if (cbIvaEstado.SelectedValue == null || cbIvaEstado.SelectedValue.ToString() == "")
            {
                this.ValidarForm.SetToolTip(this.cbIvaEstado, "Campo estado é obrigatório.");
                erro = true;
            }

            fiscal_ncm_iva.estado = cbIvaEstado.SelectedValue.ToString();
            try
            {
                //fiscal_ncm_iva.aliquota = decimal.Parse(txtIvaAliquota.Text);
            }
            catch 
            {
                this.ValidarForm.SetToolTip(this.txtIvaAliquota, "Campo aliquota é obrigatório.");    
                erro = true; 
            }

            if (erro)
                return;
            
            if (Acao == Util.Acao.Editar)
            {
                fiscal_ncm_iva.id_fiscal_ncm = id_fiscal_ncm;
                cFiscalNcm.FiscalNcmCadastrarIva(fiscal_ncm_iva);
            }
        }

        private void gvIvaAliquota_DoubleClick(object sender, EventArgs e)
        {
            if (gvIvaAliquota.CurrentRow == null)
                return;

            this.fiscal_ncm_iva = (fiscal_ncm_iva)gvIvaAliquota.CurrentRow.DataBoundItem;

            //txtIvaAliquota.Text = string.Format("{0:n}",fiscal_ncm_iva.aliquota);
            cbIvaEstado.SelectedValue = fiscal_ncm_iva.estado;
        }

        private void IvaAtualizaGrid()
        {
            gvIvaAliquota.DataSource = cFiscalNcm.FiscalNcmIvas(id_fiscal_ncm);
            gvIvaAliquota.Refresh();
        }

        private void btIvaNovo_Click(object sender, EventArgs e)
        {
            IvaNovo();
        }

        private void btIvaGravar_Click(object sender, EventArgs e)
        {
            IvaAdd();
            IvaAtualizaGrid();
            IvaNovo();
        }

        private void btIvaExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(null, "Tem certeza que deseja excluir \n o iva do estado: " + fiscal_ncm_iva.estado + "!", "Cadastro de iva.", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                cFiscalNcm.FiscalNcmExcluirIva(this.fiscal_ncm_iva);
                IvaAtualizaGrid();
                IvaNovo();
            }
        }

        #endregion
        
    }
}
