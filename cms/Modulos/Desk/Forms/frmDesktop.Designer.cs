using System.Windows.Forms;
using System.Threading;

namespace cms.Modulos.Desk.Forms
{
    partial class frmDesktop
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
            Application.Exit();
            Thread.EndThreadAffinity();

        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDesktop));
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin1 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient1 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient2 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient2 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient3 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient1 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient4 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient5 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient3 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient6 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient7 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            this.mnuDesktop = new System.Windows.Forms.MenuStrip();
            this.Cadastro_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cliente_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Fornecedor_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Produto_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Produto_ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.Grupo_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubGrupo_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Familia_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SubFamilia_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PrecoTabela_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Transportadora_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Funcionario_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Estoque_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.separaçãoDePedidosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarProdutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Venda_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Pedido_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Financeiro_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContasAPagar_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContasAReceber_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LançamentoBancario_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContaCorrente_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Boletos_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tabelas_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PlanoDeContas_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormaDePagamento_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CondicaoPagamento_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Fiscal_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CNAE_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cfop_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NaturezaDaOperacao_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nCMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.icmsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ISQN_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Relatorios_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Configurações_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Usuarios_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Empresas_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Sair_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textMask1 = new ToolMasked.TextMask(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFilial = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssFilial = new System.Windows.Forms.ToolStripSplitButton();
            this.tabForms = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.mnuDesktop.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuDesktop
            // 
            this.mnuDesktop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cadastro_ToolStripMenuItem,
            this.Estoque_ToolStripMenuItem,
            this.Venda_ToolStripMenuItem,
            this.Financeiro_ToolStripMenuItem,
            this.Fiscal_ToolStripMenuItem,
            this.Relatorios_ToolStripMenuItem,
            this.Configurações_ToolStripMenuItem,
            this.Sair_ToolStripMenuItem});
            this.mnuDesktop.Location = new System.Drawing.Point(0, 0);
            this.mnuDesktop.Name = "mnuDesktop";
            this.mnuDesktop.Size = new System.Drawing.Size(650, 24);
            this.mnuDesktop.TabIndex = 1;
            this.mnuDesktop.Text = "menuStrip1";
            this.mnuDesktop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuDesktop_ItemClicked);
            // 
            // Cadastro_ToolStripMenuItem
            // 
            this.Cadastro_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cliente_ToolStripMenuItem,
            this.Fornecedor_ToolStripMenuItem,
            this.Produto_ToolStripMenuItem,
            this.Transportadora_ToolStripMenuItem,
            this.Funcionario_ToolStripMenuItem});
            this.Cadastro_ToolStripMenuItem.Name = "Cadastro_ToolStripMenuItem";
            this.Cadastro_ToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.Cadastro_ToolStripMenuItem.Text = "Cadastro";
            // 
            // Cliente_ToolStripMenuItem
            // 
            this.Cliente_ToolStripMenuItem.Name = "Cliente_ToolStripMenuItem";
            this.Cliente_ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.Cliente_ToolStripMenuItem.Text = "Cliente";
            this.Cliente_ToolStripMenuItem.Click += new System.EventHandler(this.clienteToolStripMenuItem_Click);
            // 
            // Fornecedor_ToolStripMenuItem
            // 
            this.Fornecedor_ToolStripMenuItem.Name = "Fornecedor_ToolStripMenuItem";
            this.Fornecedor_ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.Fornecedor_ToolStripMenuItem.Text = "Fornecedor";
            this.Fornecedor_ToolStripMenuItem.Click += new System.EventHandler(this.fornecedorToolStripMenuItem_Click);
            // 
            // Produto_ToolStripMenuItem
            // 
            this.Produto_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Produto_ToolStripMenuItem1,
            this.Grupo_ToolStripMenuItem,
            this.SubGrupo_ToolStripMenuItem,
            this.Familia_ToolStripMenuItem,
            this.SubFamilia_ToolStripMenuItem,
            this.PrecoTabela_ToolStripMenuItem});
            this.Produto_ToolStripMenuItem.Name = "Produto_ToolStripMenuItem";
            this.Produto_ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.Produto_ToolStripMenuItem.Text = "Produto";
            // 
            // Produto_ToolStripMenuItem1
            // 
            this.Produto_ToolStripMenuItem1.Name = "Produto_ToolStripMenuItem1";
            this.Produto_ToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.Produto_ToolStripMenuItem1.Text = "Produto";
            this.Produto_ToolStripMenuItem1.Click += new System.EventHandler(this.produtoToolStripMenuItem1_Click);
            // 
            // Grupo_ToolStripMenuItem
            // 
            this.Grupo_ToolStripMenuItem.Name = "Grupo_ToolStripMenuItem";
            this.Grupo_ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.Grupo_ToolStripMenuItem.Text = "Grupo";
            this.Grupo_ToolStripMenuItem.Click += new System.EventHandler(this.grupoToolStripMenuItem_Click);
            // 
            // SubGrupo_ToolStripMenuItem
            // 
            this.SubGrupo_ToolStripMenuItem.Name = "SubGrupo_ToolStripMenuItem";
            this.SubGrupo_ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.SubGrupo_ToolStripMenuItem.Text = "Sub-Grupo";
            this.SubGrupo_ToolStripMenuItem.Click += new System.EventHandler(this.subgrupoToolStripMenuItem_Click);
            // 
            // Familia_ToolStripMenuItem
            // 
            this.Familia_ToolStripMenuItem.Name = "Familia_ToolStripMenuItem";
            this.Familia_ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.Familia_ToolStripMenuItem.Text = "Familia";
            this.Familia_ToolStripMenuItem.Click += new System.EventHandler(this.familiaToolStripMenuItem_Click);
            // 
            // SubFamilia_ToolStripMenuItem
            // 
            this.SubFamilia_ToolStripMenuItem.Name = "SubFamilia_ToolStripMenuItem";
            this.SubFamilia_ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.SubFamilia_ToolStripMenuItem.Text = "Sub-Familia";
            this.SubFamilia_ToolStripMenuItem.Click += new System.EventHandler(this.subfamiliaToolStripMenuItem_Click);
            // 
            // PrecoTabela_ToolStripMenuItem
            // 
            this.PrecoTabela_ToolStripMenuItem.Name = "PrecoTabela_ToolStripMenuItem";
            this.PrecoTabela_ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.PrecoTabela_ToolStripMenuItem.Text = "Preço Tabela";
            this.PrecoTabela_ToolStripMenuItem.Click += new System.EventHandler(this.PrecoTabela_ToolStripMenuItem_Click);
            // 
            // Transportadora_ToolStripMenuItem
            // 
            this.Transportadora_ToolStripMenuItem.Name = "Transportadora_ToolStripMenuItem";
            this.Transportadora_ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.Transportadora_ToolStripMenuItem.Text = "Transportadora";
            this.Transportadora_ToolStripMenuItem.Click += new System.EventHandler(this.transportadoraToolStripMenuItem_Click);
            // 
            // Funcionario_ToolStripMenuItem
            // 
            this.Funcionario_ToolStripMenuItem.Name = "Funcionario_ToolStripMenuItem";
            this.Funcionario_ToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.Funcionario_ToolStripMenuItem.Text = "Funcionario";
            // 
            // Estoque_ToolStripMenuItem
            // 
            this.Estoque_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.compraToolStripMenuItem,
            this.separaçãoDePedidosToolStripMenuItem,
            this.consultarProdutoToolStripMenuItem});
            this.Estoque_ToolStripMenuItem.Name = "Estoque_ToolStripMenuItem";
            this.Estoque_ToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.Estoque_ToolStripMenuItem.Text = "Estoque";
            // 
            // compraToolStripMenuItem
            // 
            this.compraToolStripMenuItem.Name = "compraToolStripMenuItem";
            this.compraToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.compraToolStripMenuItem.Text = "Compra";
            this.compraToolStripMenuItem.Click += new System.EventHandler(this.compraToolStripMenuItem_Click);
            // 
            // separaçãoDePedidosToolStripMenuItem
            // 
            this.separaçãoDePedidosToolStripMenuItem.Name = "separaçãoDePedidosToolStripMenuItem";
            this.separaçãoDePedidosToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.separaçãoDePedidosToolStripMenuItem.Text = "Separação de Pedidos";
            // 
            // consultarProdutoToolStripMenuItem
            // 
            this.consultarProdutoToolStripMenuItem.Name = "consultarProdutoToolStripMenuItem";
            this.consultarProdutoToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.consultarProdutoToolStripMenuItem.Text = "Consultar Produto";
            this.consultarProdutoToolStripMenuItem.Click += new System.EventHandler(this.consultarProdutoToolStripMenuItem_Click);
            // 
            // Venda_ToolStripMenuItem
            // 
            this.Venda_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Pedido_ToolStripMenuItem});
            this.Venda_ToolStripMenuItem.Name = "Venda_ToolStripMenuItem";
            this.Venda_ToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.Venda_ToolStripMenuItem.Text = "Venda";
            // 
            // Pedido_ToolStripMenuItem
            // 
            this.Pedido_ToolStripMenuItem.Name = "Pedido_ToolStripMenuItem";
            this.Pedido_ToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.Pedido_ToolStripMenuItem.Text = "Pedido";
            this.Pedido_ToolStripMenuItem.Click += new System.EventHandler(this.Pedido_ToolStripMenuItem_Click);
            // 
            // Financeiro_ToolStripMenuItem
            // 
            this.Financeiro_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContasAPagar_ToolStripMenuItem,
            this.ContasAReceber_ToolStripMenuItem,
            this.LançamentoBancario_ToolStripMenuItem,
            this.ContaCorrente_ToolStripMenuItem,
            this.Boletos_ToolStripMenuItem,
            this.Tabelas_ToolStripMenuItem});
            this.Financeiro_ToolStripMenuItem.Name = "Financeiro_ToolStripMenuItem";
            this.Financeiro_ToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.Financeiro_ToolStripMenuItem.Text = "Financeiro";
            // 
            // ContasAPagar_ToolStripMenuItem
            // 
            this.ContasAPagar_ToolStripMenuItem.Name = "ContasAPagar_ToolStripMenuItem";
            this.ContasAPagar_ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.ContasAPagar_ToolStripMenuItem.Text = "Contas a Pagar";
            this.ContasAPagar_ToolStripMenuItem.Click += new System.EventHandler(this.contasAPagarToolStripMenuItem_Click);
            // 
            // ContasAReceber_ToolStripMenuItem
            // 
            this.ContasAReceber_ToolStripMenuItem.Name = "ContasAReceber_ToolStripMenuItem";
            this.ContasAReceber_ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.ContasAReceber_ToolStripMenuItem.Text = "Contas a Receber";
            this.ContasAReceber_ToolStripMenuItem.Click += new System.EventHandler(this.contasAReceberToolStripMenuItem_Click);
            // 
            // LançamentoBancario_ToolStripMenuItem
            // 
            this.LançamentoBancario_ToolStripMenuItem.Name = "LançamentoBancario_ToolStripMenuItem";
            this.LançamentoBancario_ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.LançamentoBancario_ToolStripMenuItem.Text = "Lançamento Bancário";
            this.LançamentoBancario_ToolStripMenuItem.Click += new System.EventHandler(this.lançamentoBancarioToolStripMenuItem_Click);
            // 
            // ContaCorrente_ToolStripMenuItem
            // 
            this.ContaCorrente_ToolStripMenuItem.Name = "ContaCorrente_ToolStripMenuItem";
            this.ContaCorrente_ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.ContaCorrente_ToolStripMenuItem.Text = "Conta Corrente";
            this.ContaCorrente_ToolStripMenuItem.Click += new System.EventHandler(this.contaCorrenteToolStripMenuItem_Click);
            // 
            // Boletos_ToolStripMenuItem
            // 
            this.Boletos_ToolStripMenuItem.Name = "Boletos_ToolStripMenuItem";
            this.Boletos_ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.Boletos_ToolStripMenuItem.Text = "Boletos";
            this.Boletos_ToolStripMenuItem.Click += new System.EventHandler(this.boletosToolStripMenuItem_Click);
            // 
            // Tabelas_ToolStripMenuItem
            // 
            this.Tabelas_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlanoDeContas_ToolStripMenuItem,
            this.FormaDePagamento_ToolStripMenuItem,
            this.CondicaoPagamento_ToolStripMenuItem});
            this.Tabelas_ToolStripMenuItem.Name = "Tabelas_ToolStripMenuItem";
            this.Tabelas_ToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.Tabelas_ToolStripMenuItem.Text = "Tabelas";
            // 
            // PlanoDeContas_ToolStripMenuItem
            // 
            this.PlanoDeContas_ToolStripMenuItem.Name = "PlanoDeContas_ToolStripMenuItem";
            this.PlanoDeContas_ToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.PlanoDeContas_ToolStripMenuItem.Text = "Plano de Contas";
            this.PlanoDeContas_ToolStripMenuItem.Click += new System.EventHandler(this.planoDeContasToolStripMenuItem_Click);
            // 
            // FormaDePagamento_ToolStripMenuItem
            // 
            this.FormaDePagamento_ToolStripMenuItem.Name = "FormaDePagamento_ToolStripMenuItem";
            this.FormaDePagamento_ToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.FormaDePagamento_ToolStripMenuItem.Text = "Forma de Pagamento";
            this.FormaDePagamento_ToolStripMenuItem.Click += new System.EventHandler(this.formaDePagamentoToolStripMenuItem_Click);
            // 
            // CondicaoPagamento_ToolStripMenuItem
            // 
            this.CondicaoPagamento_ToolStripMenuItem.Name = "CondicaoPagamento_ToolStripMenuItem";
            this.CondicaoPagamento_ToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.CondicaoPagamento_ToolStripMenuItem.Text = "Condição de Pagamento";
            this.CondicaoPagamento_ToolStripMenuItem.Click += new System.EventHandler(this.CondicaoPagamento_ToolStripMenuItem_Click);
            // 
            // Fiscal_ToolStripMenuItem
            // 
            this.Fiscal_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CNAE_ToolStripMenuItem,
            this.Cfop_ToolStripMenuItem,
            this.NaturezaDaOperacao_ToolStripMenuItem,
            this.nCMToolStripMenuItem,
            this.icmsToolStripMenuItem,
            this.ISQN_ToolStripMenuItem});
            this.Fiscal_ToolStripMenuItem.Name = "Fiscal_ToolStripMenuItem";
            this.Fiscal_ToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.Fiscal_ToolStripMenuItem.Text = "Fiscal";
            this.Fiscal_ToolStripMenuItem.Click += new System.EventHandler(this.Fiscal_ToolStripMenuItem_Click);
            // 
            // CNAE_ToolStripMenuItem
            // 
            this.CNAE_ToolStripMenuItem.Name = "CNAE_ToolStripMenuItem";
            this.CNAE_ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.CNAE_ToolStripMenuItem.Text = "CNAE";
            this.CNAE_ToolStripMenuItem.Click += new System.EventHandler(this.CNAE_ToolStripMenuItem_Click);
            // 
            // Cfop_ToolStripMenuItem
            // 
            this.Cfop_ToolStripMenuItem.Name = "Cfop_ToolStripMenuItem";
            this.Cfop_ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.Cfop_ToolStripMenuItem.Text = "CFOP";
            this.Cfop_ToolStripMenuItem.Click += new System.EventHandler(this.Cfop_ToolStripMenuItem_Click);
            // 
            // NaturezaDaOperacao_ToolStripMenuItem
            // 
            this.NaturezaDaOperacao_ToolStripMenuItem.Name = "NaturezaDaOperacao_ToolStripMenuItem";
            this.NaturezaDaOperacao_ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.NaturezaDaOperacao_ToolStripMenuItem.Text = "Natureza da Operação";
            this.NaturezaDaOperacao_ToolStripMenuItem.Click += new System.EventHandler(this.NaturezaDaOperacao_ToolStripMenuItem_Click);
            // 
            // nCMToolStripMenuItem
            // 
            this.nCMToolStripMenuItem.Name = "nCMToolStripMenuItem";
            this.nCMToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.nCMToolStripMenuItem.Text = "NCM";
            this.nCMToolStripMenuItem.Click += new System.EventHandler(this.nCMToolStripMenuItem_Click_1);
            // 
            // icmsToolStripMenuItem
            // 
            this.icmsToolStripMenuItem.Name = "icmsToolStripMenuItem";
            this.icmsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.icmsToolStripMenuItem.Text = "Icms";
            this.icmsToolStripMenuItem.Click += new System.EventHandler(this.icmsToolStripMenuItem_Click_1);
            // 
            // ISQN_ToolStripMenuItem
            // 
            this.ISQN_ToolStripMenuItem.Name = "ISQN_ToolStripMenuItem";
            this.ISQN_ToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.ISQN_ToolStripMenuItem.Text = "ISQN";
            // 
            // Relatorios_ToolStripMenuItem
            // 
            this.Relatorios_ToolStripMenuItem.Name = "Relatorios_ToolStripMenuItem";
            this.Relatorios_ToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.Relatorios_ToolStripMenuItem.Text = "Relatórios";
            // 
            // Configurações_ToolStripMenuItem
            // 
            this.Configurações_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Usuarios_ToolStripMenuItem,
            this.Empresas_ToolStripMenuItem,
            this.testeToolStripMenuItem});
            this.Configurações_ToolStripMenuItem.Name = "Configurações_ToolStripMenuItem";
            this.Configurações_ToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.Configurações_ToolStripMenuItem.Text = "Configurações";
            // 
            // Usuarios_ToolStripMenuItem
            // 
            this.Usuarios_ToolStripMenuItem.Name = "Usuarios_ToolStripMenuItem";
            this.Usuarios_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.Usuarios_ToolStripMenuItem.Text = "Usuários";
            this.Usuarios_ToolStripMenuItem.Click += new System.EventHandler(this.usuariosToolStripMenuItem_Click);
            // 
            // Empresas_ToolStripMenuItem
            // 
            this.Empresas_ToolStripMenuItem.Name = "Empresas_ToolStripMenuItem";
            this.Empresas_ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.Empresas_ToolStripMenuItem.Text = "Empresas";
            this.Empresas_ToolStripMenuItem.Click += new System.EventHandler(this.empresasToolStripMenuItem_Click);
            // 
            // testeToolStripMenuItem
            // 
            this.testeToolStripMenuItem.Name = "testeToolStripMenuItem";
            this.testeToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.testeToolStripMenuItem.Text = "Teste";
            // 
            // Sair_ToolStripMenuItem
            // 
            this.Sair_ToolStripMenuItem.Name = "Sair_ToolStripMenuItem";
            this.Sair_ToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.Sair_ToolStripMenuItem.Text = "Sair";
            this.Sair_ToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // textMask1
            // 
            this.textMask1.Text = null;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lblFilial,
            this.tssFilial});
            this.statusStrip1.Location = new System.Drawing.Point(0, 385);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(650, 22);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            this.toolStripStatusLabel1.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(554, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // lblFilial
            // 
            this.lblFilial.BackColor = System.Drawing.Color.Transparent;
            this.lblFilial.Name = "lblFilial";
            this.lblFilial.Size = new System.Drawing.Size(34, 17);
            this.lblFilial.Text = "Filial:";
            // 
            // tssFilial
            // 
            this.tssFilial.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tssFilial.Image = ((System.Drawing.Image)(resources.GetObject("tssFilial.Image")));
            this.tssFilial.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tssFilial.Name = "tssFilial";
            this.tssFilial.Size = new System.Drawing.Size(47, 20);
            this.tssFilial.Text = "Filial";
            this.tssFilial.ButtonClick += new System.EventHandler(this.tssFilial_ButtonClick);
            // 
            // tabForms
            // 
            this.tabForms.ActiveAutoHideContent = null;
            this.tabForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabForms.DockBackColor = System.Drawing.Color.White;
            this.tabForms.Location = new System.Drawing.Point(0, 24);
            this.tabForms.Name = "tabForms";
            this.tabForms.Size = new System.Drawing.Size(650, 361);
            dockPanelGradient1.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient1.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin1.DockStripGradient = dockPanelGradient1;
            tabGradient1.EndColor = System.Drawing.SystemColors.Control;
            tabGradient1.StartColor = System.Drawing.SystemColors.Control;
            tabGradient1.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin1.TabGradient = tabGradient1;
            dockPanelSkin1.AutoHideStripSkin = autoHideStripSkin1;
            tabGradient2.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient2.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.ActiveTabGradient = tabGradient2;
            dockPanelGradient2.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient2.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient1.DockStripGradient = dockPanelGradient2;
            tabGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient3.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient1.InactiveTabGradient = tabGradient3;
            dockPaneStripSkin1.DocumentGradient = dockPaneStripGradient1;
            tabGradient4.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient4.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient4.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient4.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient1.ActiveCaptionGradient = tabGradient4;
            tabGradient5.EndColor = System.Drawing.SystemColors.Control;
            tabGradient5.StartColor = System.Drawing.SystemColors.Control;
            tabGradient5.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.ActiveTabGradient = tabGradient5;
            dockPanelGradient3.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient3.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient1.DockStripGradient = dockPanelGradient3;
            tabGradient6.EndColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient6.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient6.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient1.InactiveCaptionGradient = tabGradient6;
            tabGradient7.EndColor = System.Drawing.Color.Transparent;
            tabGradient7.StartColor = System.Drawing.Color.Transparent;
            tabGradient7.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient1.InactiveTabGradient = tabGradient7;
            dockPaneStripSkin1.ToolWindowGradient = dockPaneStripToolWindowGradient1;
            dockPanelSkin1.DockPaneStripSkin = dockPaneStripSkin1;
            this.tabForms.Skin = dockPanelSkin1;
            this.tabForms.TabIndex = 14;
            // 
            // frmDesktop
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(650, 407);
            this.Controls.Add(this.tabForms);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.mnuDesktop);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuDesktop;
            this.Name = "frmDesktop";
            this.Text = "Sistema";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuDesktop.ResumeLayout(false);
            this.mnuDesktop.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuDesktop;
        private System.Windows.Forms.ToolStripMenuItem Cadastro_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Cliente_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Fornecedor_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Produto_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Produto_ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Grupo_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SubGrupo_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Transportadora_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Funcionario_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Financeiro_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContasAPagar_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContasAReceber_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LançamentoBancario_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContaCorrente_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Boletos_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Tabelas_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PlanoDeContas_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FormaDePagamento_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Configurações_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Usuarios_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Sair_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Relatorios_ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Empresas_ToolStripMenuItem;
        private ToolMasked.TextMask textMask1;
        private StatusStrip statusStrip1;
        private ToolStripMenuItem Familia_ToolStripMenuItem;
        private ToolStripMenuItem SubFamilia_ToolStripMenuItem;
        private ToolStripMenuItem PrecoTabela_ToolStripMenuItem;
        private ToolStripMenuItem Fiscal_ToolStripMenuItem;
        private ToolStripMenuItem Cfop_ToolStripMenuItem;
        private ToolStripMenuItem NaturezaDaOperacao_ToolStripMenuItem;
        private ToolStripMenuItem nCMToolStripMenuItem;
        private ToolStripMenuItem icmsToolStripMenuItem;
        private ToolStripMenuItem ISQN_ToolStripMenuItem;
        private ToolStripMenuItem Estoque_ToolStripMenuItem;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripSplitButton tssFilial;
        private ToolStripStatusLabel lblFilial;
        private WeifenLuo.WinFormsUI.Docking.DockPanel tabForms;
        private ToolStripMenuItem compraToolStripMenuItem;
        private ToolStripMenuItem separaçãoDePedidosToolStripMenuItem;
        private ToolStripMenuItem CondicaoPagamento_ToolStripMenuItem;
        private ToolStripMenuItem consultarProdutoToolStripMenuItem;
        private ToolStripMenuItem Venda_ToolStripMenuItem;
        private ToolStripMenuItem Pedido_ToolStripMenuItem;
        private ToolStripMenuItem CNAE_ToolStripMenuItem;
        private ToolStripMenuItem testeToolStripMenuItem;

    }
}