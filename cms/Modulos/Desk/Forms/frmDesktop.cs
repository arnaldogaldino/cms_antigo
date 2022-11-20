using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Management;
using cms.Modulos.Usuario.Cn;
using cms.Data;

namespace cms.Modulos.Desk.Forms
{
    public partial class frmDesktop : cms.Modulos.Util.WindowBase
    {
        private cnUsuario cUsuario = new cnUsuario();

        public frmDesktop()
        {
            InitializeComponent();
            Thread thread = new Thread(CadastrarMenus);
            thread.Start();

            //CadastrarMenus();
            AtualizarFilial();
        }

        private void CadastrarMenus()
        {
            lerMenus(mnuDesktop.Items, 0);
        }

        private void AtualizarFilial()
        {
            var empresas = cms.Modulos.Util.AuthEntity.UsuarioOnLine.empresa;
            foreach (var emp in empresas)
            {
                ToolStripItem t = tssFilial.DropDownItems.Add(emp.apelido);
                t.Tag = emp;
                t.Click += tssFilial_ButtonClick;
            }
            tssFilial.Text = cms.Modulos.Util.AuthEntity.EmpresaPadrao.apelido;
            tssFilial.Tag = cms.Modulos.Util.AuthEntity.EmpresaPadrao;
        }

        private void lerMenus(ToolStripItemCollection items, long pai)
        {
            foreach (ToolStripMenuItem mnu in items)
            {
                var texto = mnu.Text;
                var nome = mnu.Name;

                long result = 0;
                if (pai != 0)
                    result = cms.Modulos.Util.AuthEntity.CadastrarMenu(pai, mnu.Name, mnu.Text, "");
                else
                    result = cms.Modulos.Util.AuthEntity.CadastrarMenu(null, mnu.Name, mnu.Text, "");

                if (!cUsuario.UsuarioPermissaoMenu(cms.Modulos.Util.AuthEntity.UsuarioOnLine.id_usuario, mnu.Name))
                    mnu.Visible = false;

                lerMenus(mnu.DropDownItems, result);
            }
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Cliente.Forms.frmClienteList fClienteList = new Cliente.Forms.frmClienteList();

            fClienteList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fClienteList.MdiParent = this;
                fClienteList.Show();
            }
            else
                fClienteList.Show(tabForms);
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Empresa.Forms.frmEmpresaList fEmpresaList = new cms.Modulos.Empresa.Forms.frmEmpresaList();
            fEmpresaList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fEmpresaList.MdiParent = this;
                fEmpresaList.Show();
            }
            else
                fEmpresaList.Show(tabForms);
        }

        private void fornecedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fornecedor.Forms.frmFornecedorList fFornecedorList = new Fornecedor.Forms.frmFornecedorList();
            fFornecedorList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFornecedorList.MdiParent = this;
                fFornecedorList.Show();
            }
            else
                fFornecedorList.Show(tabForms);
        }

        private void transportadoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Transportadora.Forms.frmTransportadoraList fTransportadoraList = new Transportadora.Forms.frmTransportadoraList();
            fTransportadoraList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fTransportadoraList.MdiParent = this;
                fTransportadoraList.Show();
            }
            else
                fTransportadoraList.Show(tabForms);
        }

        private void icmsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //cms.Modulos.Financeiro.Forms.Tabelas.Icms.frmFinanceiroIcmsList fFinanceiroIcmsList = new Financeiro.Forms.Tabelas.Icms.frmFinanceiroIcmsList();
            //fFinanceiroIcmsList.Tag = tabForms;

            //if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            //{
            //    fFinanceiroIcmsList.MdiParent = this;
            //    fFinanceiroIcmsList.Show();
            //}
            //else
            //    fFinanceiroIcmsList.Show(tabForms);
        }

        private void planoDeContasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.Tabelas.PlanoContas.frmFinanceiroPlanoContasList fFinanceiroPlanoContasList = new Financeiro.Forms.Tabelas.PlanoContas.frmFinanceiroPlanoContasList();
            fFinanceiroPlanoContasList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFinanceiroPlanoContasList.MdiParent = this;
                fFinanceiroPlanoContasList.Show();
            }
            else
                fFinanceiroPlanoContasList.Show(tabForms);
        }

        private void formaDePagamentoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.Tabelas.FormaPagamento.frmFinanceiroFormaPagamentoList fFinanceiroFormaPagamentoList = new Financeiro.Forms.Tabelas.FormaPagamento.frmFinanceiroFormaPagamentoList();
            fFinanceiroFormaPagamentoList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFinanceiroFormaPagamentoList.MdiParent = this;
                fFinanceiroFormaPagamentoList.Show();
            }
            else
                fFinanceiroFormaPagamentoList.Show(tabForms);
        }

        private void contaCorrenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.ContaCorrente.frmFinanceiroContaCorrenteList fFinanceiroContaCorrenteList = new Financeiro.Forms.ContaCorrente.frmFinanceiroContaCorrenteList();
            fFinanceiroContaCorrenteList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFinanceiroContaCorrenteList.MdiParent = this;
                fFinanceiroContaCorrenteList.Show();
            }
            else
                fFinanceiroContaCorrenteList.Show(tabForms);
        }

        private void contasAPagarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.ContasPagar.frmFinanceiroContasPagarList fFinanceiroContasPagarList = new Financeiro.Forms.ContasPagar.frmFinanceiroContasPagarList();
            fFinanceiroContasPagarList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFinanceiroContasPagarList.MdiParent = this;
                fFinanceiroContasPagarList.Show();
            }
            else
                fFinanceiroContasPagarList.Show(tabForms);
        }

        private void contasAReceberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.ContasReceber.frmFinanceiroContasReceberList fFinanceiroContasReceberList = new Financeiro.Forms.ContasReceber.frmFinanceiroContasReceberList();
            fFinanceiroContasReceberList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFinanceiroContasReceberList.MdiParent = this;
                fFinanceiroContasReceberList.Show();
            }
            else
                fFinanceiroContasReceberList.Show(tabForms);
        }

        private void lançamentoBancarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.LancamentoBancario.frmFinanceiroLancamentoList fFinanceiroLancamentoList = new Financeiro.Forms.LancamentoBancario.frmFinanceiroLancamentoList();
            fFinanceiroLancamentoList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFinanceiroLancamentoList.MdiParent = this;
                fFinanceiroLancamentoList.Show();
            }
            else
                fFinanceiroLancamentoList.Show(tabForms);
        }

        private void grupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.Grupo.frmProdutoGrupoList fProdutoGrupoList = new cms.Modulos.Produto.Forms.Grupo.frmProdutoGrupoList();
            fProdutoGrupoList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoGrupoList.MdiParent = this;
                fProdutoGrupoList.Show();
            }
            else
                fProdutoGrupoList.Show(tabForms);
        }

        private void boletosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.Boletos.frmBoletoList fBoletoList = new cms.Modulos.Financeiro.Forms.Boletos.frmBoletoList();
            fBoletoList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fBoletoList.MdiParent = this;
                fBoletoList.Show();
            }
            else
                fBoletoList.Show(tabForms);
        }

        private void subgrupoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.SubGrupo.frmProdutoSubGrupoList fProdutoSubGrupoList = new cms.Modulos.Produto.Forms.SubGrupo.frmProdutoSubGrupoList();
            fProdutoSubGrupoList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoSubGrupoList.MdiParent = this;
                fProdutoSubGrupoList.Show();
            }
            else
                fProdutoSubGrupoList.Show(tabForms);
        }
        
        private void familiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.Familia.frmProdutoFamiliaList fProdutoFamiliaList = new cms.Modulos.Produto.Forms.Familia.frmProdutoFamiliaList();
            fProdutoFamiliaList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoFamiliaList.MdiParent = this;
                fProdutoFamiliaList.Show();
            }
            else
                fProdutoFamiliaList.Show(tabForms);
        }

        private void subfamiliaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.SubFamilia.frmProdutoSubFamiliaList fProdutoSubFamiliaList = new cms.Modulos.Produto.Forms.SubFamilia.frmProdutoSubFamiliaList();
            fProdutoSubFamiliaList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoSubFamiliaList.MdiParent = this;
                fProdutoSubFamiliaList.Show();
            }
            else
                fProdutoSubFamiliaList.Show(tabForms);
        }	

        private void produtoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.Produto.frmProdutoList fProdutoList = new cms.Modulos.Produto.Forms.Produto.frmProdutoList();
            fProdutoList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoList.MdiParent = this;
                fProdutoList.Show();
            }
            else
                fProdutoList.Show(tabForms);
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Usuario.Forms.frmUsuarioList fUsuarioList = new cms.Modulos.Usuario.Forms.frmUsuarioList();
            fUsuarioList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fUsuarioList.MdiParent = this;
                fUsuarioList.Show();
            }
            else
                fUsuarioList.Show(tabForms);
        }

        private void mnuDesktop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Fiscal_ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void icmsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Icms.frmFiscalIcms fFiscalIcms = new cms.Modulos.Fiscal.Forms.Icms.frmFiscalIcms();
            fFiscalIcms.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFiscalIcms.MdiParent = this;
                fFiscalIcms.Show();
            }
            else
                fFiscalIcms.Show(tabForms);
        }

        private void Cfop_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopList fFiscalCfopList = new cms.Modulos.Fiscal.Forms.Cfop.frmFiscalCfopList();
            fFiscalCfopList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFiscalCfopList.MdiParent = this;
                fFiscalCfopList.Show();
            }
            else
                fFiscalCfopList.Show(tabForms);
        }

        private void nCMToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Ncm.frmFiscalNcmList fFiscalNcmList = new cms.Modulos.Fiscal.Forms.Ncm.frmFiscalNcmList();
            fFiscalNcmList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFiscalNcmList.MdiParent = this;
                fFiscalNcmList.Show();
            }
            else
                fFiscalNcmList.Show(tabForms);
        }

        private void NaturezaDaOperacao_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.NaturezaOperacao.frmNaturezaOperacaoList fNaturezaOperacaoList = new cms.Modulos.Fiscal.Forms.NaturezaOperacao.frmNaturezaOperacaoList();
            fNaturezaOperacaoList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fNaturezaOperacaoList.MdiParent = this;
                fNaturezaOperacaoList.Show();
            }
            else
                fNaturezaOperacaoList.Show(tabForms);
        }

        private void PrecoTabela_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.PrecoTabela.frmProdutoPrecoTabelaList fProdutoPrecoTabelaList = new cms.Modulos.Produto.Forms.PrecoTabela.frmProdutoPrecoTabelaList();
            fProdutoPrecoTabelaList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fProdutoPrecoTabelaList.MdiParent = this;
                fProdutoPrecoTabelaList.Show();
            }
            else
                fProdutoPrecoTabelaList.Show(tabForms);
        }

        private void tssFilial_ButtonClick(object sender, EventArgs e)
        {
            if (typeof(ToolStripMenuItem) == sender.GetType()) 
            {
                ToolStripMenuItem bt = (ToolStripMenuItem)sender;
                tssFilial.Text = bt.Text;
                tssFilial.Tag = bt.Tag;

                cms.Modulos.Util.AuthEntity.SetEmpresa((empresa)tssFilial.Tag);
            }
        }

        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Compra.Forms.frmCompraList fCompraList = new cms.Modulos.Compra.Forms.frmCompraList();
            fCompraList.Tag = tabForms;
            
            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fCompraList.MdiParent = this;
                fCompraList.Show();
            }
            else
                fCompraList.Show(tabForms);
        }

        private void CondicaoPagamento_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Financeiro.Forms.Tabelas.CondicaoPagamento.frmFinanceiroCondicaoPagamentoList fFinanceiroCondicaoPagamentoList = new cms.Modulos.Financeiro.Forms.Tabelas.CondicaoPagamento.frmFinanceiroCondicaoPagamentoList();
            fFinanceiroCondicaoPagamentoList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFinanceiroCondicaoPagamentoList.MdiParent = this;
                fFinanceiroCondicaoPagamentoList.Show();
            }
            else
                fFinanceiroCondicaoPagamentoList.Show(tabForms);
        }

        private void consultarProdutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Produto.Forms.Produto.frmProdutoEstoque frmProdutoEstoque = new cms.Modulos.Produto.Forms.Produto.frmProdutoEstoque();
            frmProdutoEstoque.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                frmProdutoEstoque.MdiParent = this;
                frmProdutoEstoque.Show();
            }
            else
                frmProdutoEstoque.Show(tabForms);
        }

        private void Pedido_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Venda.Forms.frmVendaList fVendaList = new cms.Modulos.Venda.Forms.frmVendaList();
            fVendaList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fVendaList.MdiParent = this;
                fVendaList.Show();
            }
            else
                fVendaList.Show(tabForms);
        }

        private void CNAE_ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cms.Modulos.Fiscal.Forms.Cnae.frmFiscalCnaeList fFiscalCnaeList = new cms.Modulos.Fiscal.Forms.Cnae.frmFiscalCnaeList();
            fFiscalCnaeList.Tag = tabForms;

            if (tabForms.DocumentStyle == WeifenLuo.WinFormsUI.Docking.DocumentStyle.SystemMdi)
            {
                fFiscalCnaeList.MdiParent = this;
                fFiscalCnaeList.Show();
            }
            else
                fFiscalCnaeList.Show(tabForms);
        }

    }
}
