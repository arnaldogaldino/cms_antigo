using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using FiscalPrinterBematech;

namespace ExemploFiscal
{
	/// <summary>
	/// Formulario principal do software
	/// </summary>
	public class FormPrincipal : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem10;	
		private System.Windows.Forms.MenuItem AbreCupom;
		private System.Windows.Forms.MenuItem menuVendeItem;
		private System.Windows.Forms.MenuItem menuFechaResumido;
		private System.Windows.Forms.MenuItem menuVendeItemDep;
		private System.Windows.Forms.MenuItem menuCancelItemAnt;
		private System.Windows.Forms.MenuItem menuCancelItemGen;
		private System.Windows.Forms.MenuItem menuCancelCupom;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem36;
		private System.Windows.Forms.MenuItem menuItem37;
		private System.Windows.Forms.MenuItem menuItem40;
		private System.Windows.Forms.MenuItem menuItem49;
		private System.Windows.Forms.MenuItem menuRelatGerencial;
		private System.Windows.Forms.MenuItem menuFechaRelatGerencial;
		private System.Windows.Forms.MenuItem menuAbreCompNaoFiscal;
		private System.Windows.Forms.MenuItem menuUsaCompNaoFiscal;
		private System.Windows.Forms.MenuItem menuFechaCompNaoFiscal;
		private System.Windows.Forms.MenuItem menuSuprimento;
		private System.Windows.Forms.MenuItem menuSangria;
		private System.Windows.Forms.MenuItem menuRecebNaoFiscal;
		private System.Windows.Forms.MenuItem menuLeituraX;
		private System.Windows.Forms.MenuItem menuLeituraXSerial;
		private System.Windows.Forms.MenuItem menuReducaoZ;
		private System.Windows.Forms.MenuItem menuMemFiscData;
		private System.Windows.Forms.MenuItem menuMemFiscReducao;
		private System.Windows.Forms.MenuItem menuSimboloMoeda;
		private System.Windows.Forms.MenuItem menuAliqTributaria;
		private System.Windows.Forms.MenuItem menuHorarioVerao;
		private System.Windows.Forms.MenuItem menuArredondamento;
		private System.Windows.Forms.MenuItem menuTruncamento;
		private System.Windows.Forms.MenuItem menuDepartamento;
		private System.Windows.Forms.MenuItem menuTotParcial;
		private System.Windows.Forms.MenuItem menuEspEntreLinha;
		private System.Windows.Forms.MenuItem menuLinhasEntreCupons;
		private System.Windows.Forms.MenuItem menuCaracGrafico;
		private System.Windows.Forms.MenuItem menuImpactoAgulhas;
		private System.Windows.Forms.MenuItem menuResetErro;
		private System.Windows.Forms.MenuItem menuAcionaGaveta;
		private System.Windows.Forms.MenuItem menuEstadoGaveta;
		private System.Windows.Forms.MenuItem menuImprimeCheque;
		private System.Windows.Forms.MenuItem menuCancelImpCheque;
		private System.Windows.Forms.MenuItem menuMoedaSingular;
		private System.Windows.Forms.MenuItem menuMoedaPlural;
		private System.Windows.Forms.MenuItem menuStatusCheque;
		private System.Windows.Forms.MenuItem menuCidadeFavorecido;
		private System.Windows.Forms.MenuItem menuCopiaDoCheque;
		private System.Windows.Forms.MenuItem menuAberturaDia;
		private System.Windows.Forms.MenuItem menuFechamentoDia;
		private System.Windows.Forms.MenuItem menuConfPrinter;
		private System.Windows.Forms.MenuItem menuImpDepartamentos;
		private System.Windows.Forms.MenuItem menuRelAnalitico;
		private System.Windows.Forms.MenuItem menuRelMestre;
		private System.Windows.Forms.MenuItem menuImpLigada;
		private System.Windows.Forms.MenuItem menuMapaResumo;
		private System.Windows.Forms.MenuItem menuIniFechamento;
		private System.Windows.Forms.MenuItem menuEfetuaPagamento;
		private System.Windows.Forms.MenuItem menuEfetuaPagmentoTexto;
		private System.Windows.Forms.MenuItem menuTerminaFechamento;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem44;
		private System.Windows.Forms.MenuItem menuCrescimos;
		private System.Windows.Forms.MenuItem menuCGCIE;
		private System.Windows.Forms.MenuItem menuClicheProprietario;
		private System.Windows.Forms.MenuItem menuContTotNaoFiscais;
		private System.Windows.Forms.MenuItem menuDataMovimento;
		private System.Windows.Forms.MenuItem menuDataHoraImpressora;
		private System.Windows.Forms.MenuItem menuDataHoraReducao;
		private System.Windows.Forms.MenuItem menuFlagsFiscais;
		private System.Windows.Forms.MenuItem menuGrandeTotal;
		private System.Windows.Forms.MenuItem menuDadosUltimaReducao;
		private System.Windows.Forms.MenuItem menuMinutosImprimindo;
		private System.Windows.Forms.MenuItem menuMinutosLigada;
		private System.Windows.Forms.MenuItem menuNumLoja;
		private System.Windows.Forms.MenuItem menuNumCuponsCancel;
		private System.Windows.Forms.MenuItem menuNumIntervencoes;
		private System.Windows.Forms.MenuItem menuNumOperacoes;
		private System.Windows.Forms.MenuItem menuNumReducoes;
		private System.Windows.Forms.MenuItem menuNumSerie;
		private System.Windows.Forms.MenuItem menuNumSubstProprietario;
		private System.Windows.Forms.MenuItem menuNumCaixa;
		private System.Windows.Forms.MenuItem menuNumUltimoItem;
		private System.Windows.Forms.MenuItem menuRetEstadoImpressora;
		private System.Windows.Forms.MenuItem menuRetFormaPagamento;
		private System.Windows.Forms.MenuItem menuRetAliquotas;
		private System.Windows.Forms.MenuItem menuNumCupom;
		private System.Windows.Forms.MenuItem menuRetSubTotal;
		private System.Windows.Forms.MenuItem menuRetCancelamentos;
		private System.Windows.Forms.MenuItem menuRetDepartamentos;
		private System.Windows.Forms.MenuItem menuRetDescontos;
		private System.Windows.Forms.MenuItem menuRetTotParciais;
		private System.Windows.Forms.MenuItem menuVerAliquotas;
		private System.Windows.Forms.MenuItem menuVerEPROM;
		private System.Windows.Forms.MenuItem menuVerIndiceAliquotas;
		private System.Windows.Forms.MenuItem menuVerModoOperacao;
		private System.Windows.Forms.MenuItem menuVerRecebNaoFiscais;
		private System.Windows.Forms.MenuItem menuVerTipoImpressora;
		private System.Windows.Forms.MenuItem menuVerTotalizadores;
		private System.Windows.Forms.MenuItem menuVerTruncamento;
		private System.Windows.Forms.MenuItem menuVerVersaoFirmware;
		private System.Windows.Forms.MenuItem menuSimboloMoeda1;
		private System.Windows.Forms.MenuItem menuFormaPgmento;
		private System.Windows.Forms.MenuItem menuTotNaoFiscal;
		private System.Windows.Forms.MenuItem menuRetEstadodaImpressora;
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.MenuItem menuItem3;
		private int IRetorno;

		public FormPrincipal()
		{
			InitializeComponent();
		}

		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.AbreCupom = new System.Windows.Forms.MenuItem();
			this.menuVendeItem = new System.Windows.Forms.MenuItem();
			this.menuVendeItemDep = new System.Windows.Forms.MenuItem();
			this.menuCancelItemAnt = new System.Windows.Forms.MenuItem();
			this.menuCancelItemGen = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuFechaResumido = new System.Windows.Forms.MenuItem();
			this.menuIniFechamento = new System.Windows.Forms.MenuItem();
			this.menuEfetuaPagamento = new System.Windows.Forms.MenuItem();
			this.menuEfetuaPagmentoTexto = new System.Windows.Forms.MenuItem();
			this.menuTerminaFechamento = new System.Windows.Forms.MenuItem();
			this.menuCancelCupom = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuRelatGerencial = new System.Windows.Forms.MenuItem();
			this.menuFechaRelatGerencial = new System.Windows.Forms.MenuItem();
			this.menuAbreCompNaoFiscal = new System.Windows.Forms.MenuItem();
			this.menuUsaCompNaoFiscal = new System.Windows.Forms.MenuItem();
			this.menuFechaCompNaoFiscal = new System.Windows.Forms.MenuItem();
			this.menuSuprimento = new System.Windows.Forms.MenuItem();
			this.menuSangria = new System.Windows.Forms.MenuItem();
			this.menuRecebNaoFiscal = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuLeituraX = new System.Windows.Forms.MenuItem();
			this.menuLeituraXSerial = new System.Windows.Forms.MenuItem();
			this.menuReducaoZ = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuMemFiscData = new System.Windows.Forms.MenuItem();
			this.menuMemFiscReducao = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.menuSimboloMoeda = new System.Windows.Forms.MenuItem();
			this.menuAliqTributaria = new System.Windows.Forms.MenuItem();
			this.menuHorarioVerao = new System.Windows.Forms.MenuItem();
			this.menuArredondamento = new System.Windows.Forms.MenuItem();
			this.menuTruncamento = new System.Windows.Forms.MenuItem();
			this.menuDepartamento = new System.Windows.Forms.MenuItem();
			this.menuTotParcial = new System.Windows.Forms.MenuItem();
			this.menuEspEntreLinha = new System.Windows.Forms.MenuItem();
			this.menuLinhasEntreCupons = new System.Windows.Forms.MenuItem();
			this.menuCaracGrafico = new System.Windows.Forms.MenuItem();
			this.menuImpactoAgulhas = new System.Windows.Forms.MenuItem();
			this.menuResetErro = new System.Windows.Forms.MenuItem();
			this.menuItem36 = new System.Windows.Forms.MenuItem();
			this.menuCrescimos = new System.Windows.Forms.MenuItem();
			this.menuCGCIE = new System.Windows.Forms.MenuItem();
			this.menuClicheProprietario = new System.Windows.Forms.MenuItem();
			this.menuContTotNaoFiscais = new System.Windows.Forms.MenuItem();
			this.menuDataMovimento = new System.Windows.Forms.MenuItem();
			this.menuDataHoraImpressora = new System.Windows.Forms.MenuItem();
			this.menuDataHoraReducao = new System.Windows.Forms.MenuItem();
			this.menuFlagsFiscais = new System.Windows.Forms.MenuItem();
			this.menuGrandeTotal = new System.Windows.Forms.MenuItem();
			this.menuDadosUltimaReducao = new System.Windows.Forms.MenuItem();
			this.menuMinutosImprimindo = new System.Windows.Forms.MenuItem();
			this.menuMinutosLigada = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuNumLoja = new System.Windows.Forms.MenuItem();
			this.menuNumCupom = new System.Windows.Forms.MenuItem();
			this.menuNumCuponsCancel = new System.Windows.Forms.MenuItem();
			this.menuNumIntervencoes = new System.Windows.Forms.MenuItem();
			this.menuNumOperacoes = new System.Windows.Forms.MenuItem();
			this.menuNumReducoes = new System.Windows.Forms.MenuItem();
			this.menuNumSerie = new System.Windows.Forms.MenuItem();
			this.menuNumSubstProprietario = new System.Windows.Forms.MenuItem();
			this.menuNumCaixa = new System.Windows.Forms.MenuItem();
			this.menuNumUltimoItem = new System.Windows.Forms.MenuItem();
			this.menuRetEstadoImpressora = new System.Windows.Forms.MenuItem();
			this.menuRetEstadodaImpressora = new System.Windows.Forms.MenuItem();
			this.menuRetFormaPagamento = new System.Windows.Forms.MenuItem();
			this.menuRetAliquotas = new System.Windows.Forms.MenuItem();
			this.menuRetSubTotal = new System.Windows.Forms.MenuItem();
			this.menuRetCancelamentos = new System.Windows.Forms.MenuItem();
			this.menuRetDepartamentos = new System.Windows.Forms.MenuItem();
			this.menuRetDescontos = new System.Windows.Forms.MenuItem();
			this.menuRetTotParciais = new System.Windows.Forms.MenuItem();
			this.menuItem44 = new System.Windows.Forms.MenuItem();
			this.menuVerAliquotas = new System.Windows.Forms.MenuItem();
			this.menuVerEPROM = new System.Windows.Forms.MenuItem();
			this.menuVerIndiceAliquotas = new System.Windows.Forms.MenuItem();
			this.menuVerModoOperacao = new System.Windows.Forms.MenuItem();
			this.menuVerRecebNaoFiscais = new System.Windows.Forms.MenuItem();
			this.menuVerTipoImpressora = new System.Windows.Forms.MenuItem();
			this.menuVerTotalizadores = new System.Windows.Forms.MenuItem();
			this.menuVerTruncamento = new System.Windows.Forms.MenuItem();
			this.menuVerVersaoFirmware = new System.Windows.Forms.MenuItem();
			this.menuSimboloMoeda1 = new System.Windows.Forms.MenuItem();
			this.menuFormaPgmento = new System.Windows.Forms.MenuItem();
			this.menuTotNaoFiscal = new System.Windows.Forms.MenuItem();
			this.menuItem37 = new System.Windows.Forms.MenuItem();
			this.menuAcionaGaveta = new System.Windows.Forms.MenuItem();
			this.menuEstadoGaveta = new System.Windows.Forms.MenuItem();
			this.menuItem40 = new System.Windows.Forms.MenuItem();
			this.menuImprimeCheque = new System.Windows.Forms.MenuItem();
			this.menuCancelImpCheque = new System.Windows.Forms.MenuItem();
			this.menuMoedaSingular = new System.Windows.Forms.MenuItem();
			this.menuMoedaPlural = new System.Windows.Forms.MenuItem();
			this.menuStatusCheque = new System.Windows.Forms.MenuItem();
			this.menuCidadeFavorecido = new System.Windows.Forms.MenuItem();
			this.menuCopiaDoCheque = new System.Windows.Forms.MenuItem();
			this.menuItem49 = new System.Windows.Forms.MenuItem();
			this.menuAberturaDia = new System.Windows.Forms.MenuItem();
			this.menuFechamentoDia = new System.Windows.Forms.MenuItem();
			this.menuConfPrinter = new System.Windows.Forms.MenuItem();
			this.menuImpDepartamentos = new System.Windows.Forms.MenuItem();
			this.menuRelAnalitico = new System.Windows.Forms.MenuItem();
			this.menuRelMestre = new System.Windows.Forms.MenuItem();
			this.menuImpLigada = new System.Windows.Forms.MenuItem();
			this.menuMapaResumo = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.menuItem1,
																																							this.menuItem2,
																																							this.menuItem16,
																																							this.menuItem23,
																																							this.menuItem36,
																																							this.menuItem37,
																																							this.menuItem40,
																																							this.menuItem49});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.AbreCupom,
																																							this.menuVendeItem,
																																							this.menuVendeItemDep,
																																							this.menuCancelItemAnt,
																																							this.menuCancelItemGen,
																																							this.menuItem10,
																																							this.menuCancelCupom});
			this.menuItem1.Text = "&Cupom Fiscal";
			// 
			// AbreCupom
			// 
			this.AbreCupom.Index = 0;
			this.AbreCupom.Text = "Abre Cupom...";
			this.AbreCupom.Click += new System.EventHandler(this.AbreCupom_Click);
			// 
			// menuVendeItem
			// 
			this.menuVendeItem.Index = 1;
			this.menuVendeItem.Text = "Vende Item";
			this.menuVendeItem.Click += new System.EventHandler(this.menuVendeItem_Click);
			// 
			// menuVendeItemDep
			// 
			this.menuVendeItemDep.Index = 2;
			this.menuVendeItemDep.Text = "Venda de Item com Departamento";
			this.menuVendeItemDep.Click += new System.EventHandler(this.menuVendeItemDep_Click);
			// 
			// menuCancelItemAnt
			// 
			this.menuCancelItemAnt.Index = 3;
			this.menuCancelItemAnt.Text = "Cancela Item Anterior";
			this.menuCancelItemAnt.Click += new System.EventHandler(this.menuCancelItemAnt_Click);
			// 
			// menuCancelItemGen
			// 
			this.menuCancelItemGen.Index = 4;
			this.menuCancelItemGen.Text = "Cancela Item Genérico";
			this.menuCancelItemGen.Click += new System.EventHandler(this.menuCancelItemGen_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 5;
			this.menuItem10.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							 this.menuFechaResumido,
																																							 this.menuIniFechamento,
																																							 this.menuEfetuaPagamento,
																																							 this.menuEfetuaPagmentoTexto,
																																							 this.menuTerminaFechamento});
			this.menuItem10.Text = "Fechamento do Cupom";
			// 
			// menuFechaResumido
			// 
			this.menuFechaResumido.Index = 0;
			this.menuFechaResumido.Text = "Resumido";
			this.menuFechaResumido.Click += new System.EventHandler(this.menuFechaResumido_Click);
			// 
			// menuIniFechamento
			// 
			this.menuIniFechamento.Index = 1;
			this.menuIniFechamento.Text = "Incia fechamento";
			this.menuIniFechamento.Click += new System.EventHandler(this.menuIniFechamento_Click);
			// 
			// menuEfetuaPagamento
			// 
			this.menuEfetuaPagamento.Index = 2;
			this.menuEfetuaPagamento.Text = "Efetua forma de pagamento";
			this.menuEfetuaPagamento.Click += new System.EventHandler(this.menuEfetuaPagamento_Click);
			// 
			// menuEfetuaPagmentoTexto
			// 
			this.menuEfetuaPagmentoTexto.Index = 3;
			this.menuEfetuaPagmentoTexto.Text = "Efetua forma de pagamento com texto opcional";
			this.menuEfetuaPagmentoTexto.Click += new System.EventHandler(this.menuEfetuaPagmentoTexto_Click);
			// 
			// menuTerminaFechamento
			// 
			this.menuTerminaFechamento.Index = 4;
			this.menuTerminaFechamento.Text = "Termina fechamento";
			this.menuTerminaFechamento.Click += new System.EventHandler(this.menuTerminaFechamento_Click);
			// 
			// menuCancelCupom
			// 
			this.menuCancelCupom.Index = 6;
			this.menuCancelCupom.Text = "Cancela Cupom";
			this.menuCancelCupom.Click += new System.EventHandler(this.menuCancelCupom_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							this.menuRelatGerencial,
																																							this.menuItem3,
																																							this.menuFechaRelatGerencial,
																																							this.menuAbreCompNaoFiscal,
																																							this.menuUsaCompNaoFiscal,
																																							this.menuFechaCompNaoFiscal,
																																							this.menuSuprimento,
																																							this.menuSangria,
																																							this.menuRecebNaoFiscal});
			this.menuItem2.Text = "Operações não Fiscais";
			// 
			// menuRelatGerencial
			// 
			this.menuRelatGerencial.Index = 0;
			this.menuRelatGerencial.Text = "Relatório Gerencial";
			this.menuRelatGerencial.Click += new System.EventHandler(this.menuRelatGerencial_Click);
			// 
			// menuFechaRelatGerencial
			// 
			this.menuFechaRelatGerencial.Index = 2;
			this.menuFechaRelatGerencial.Text = "Fecha Relatório Gerencial";
			this.menuFechaRelatGerencial.Click += new System.EventHandler(this.menuFechaRelatGerencial_Click);
			// 
			// menuAbreCompNaoFiscal
			// 
			this.menuAbreCompNaoFiscal.Index = 3;
			this.menuAbreCompNaoFiscal.Text = "Abre Comprovante não Fiscal Vinculado";
			this.menuAbreCompNaoFiscal.Click += new System.EventHandler(this.menuAbreCompNaoFiscal_Click);
			// 
			// menuUsaCompNaoFiscal
			// 
			this.menuUsaCompNaoFiscal.Index = 4;
			this.menuUsaCompNaoFiscal.Text = "Usa Comprovante não Fiscal Vinculado";
			this.menuUsaCompNaoFiscal.Click += new System.EventHandler(this.menuUsaCompNaoFiscal_Click);
			// 
			// menuFechaCompNaoFiscal
			// 
			this.menuFechaCompNaoFiscal.Index = 5;
			this.menuFechaCompNaoFiscal.Text = "Fecha Comprovante não Fiscal Vinculado";
			this.menuFechaCompNaoFiscal.Click += new System.EventHandler(this.menuFechaCompNaoFiscal_Click);
			// 
			// menuSuprimento
			// 
			this.menuSuprimento.Index = 6;
			this.menuSuprimento.Text = "Suprimento";
			this.menuSuprimento.Click += new System.EventHandler(this.menuSuprimento_Click);
			// 
			// menuSangria
			// 
			this.menuSangria.Index = 7;
			this.menuSangria.Text = "Sangria";
			this.menuSangria.Click += new System.EventHandler(this.menuSangria_Click);
			// 
			// menuRecebNaoFiscal
			// 
			this.menuRecebNaoFiscal.Index = 8;
			this.menuRecebNaoFiscal.Text = "Recebimento não Fiscal...";
			this.menuRecebNaoFiscal.Click += new System.EventHandler(this.menuRecebNaoFiscal_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 2;
			this.menuItem16.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							 this.menuLeituraX,
																																							 this.menuLeituraXSerial,
																																							 this.menuReducaoZ,
																																							 this.menuItem20});
			this.menuItem16.Text = "Relatórios Fiscais";
			// 
			// menuLeituraX
			// 
			this.menuLeituraX.Index = 0;
			this.menuLeituraX.Text = "Leitura X";
			this.menuLeituraX.Click += new System.EventHandler(this.menuLeituraX_Click);
			// 
			// menuLeituraXSerial
			// 
			this.menuLeituraXSerial.Index = 1;
			this.menuLeituraXSerial.Text = "Leitura X pela Serial";
			this.menuLeituraXSerial.Click += new System.EventHandler(this.menuLeituraXSerial_Click);
			// 
			// menuReducaoZ
			// 
			this.menuReducaoZ.Index = 2;
			this.menuReducaoZ.Text = "Redução Z";
			this.menuReducaoZ.Click += new System.EventHandler(this.menuReducaoZ_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 3;
			this.menuItem20.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							 this.menuMemFiscData,
																																							 this.menuMemFiscReducao});
			this.menuItem20.Text = "Leitura da Memória Fiscal";
			// 
			// menuMemFiscData
			// 
			this.menuMemFiscData.Index = 0;
			this.menuMemFiscData.Text = "Por Data...";
			this.menuMemFiscData.Click += new System.EventHandler(this.menuMemFiscData_Click);
			// 
			// menuMemFiscReducao
			// 
			this.menuMemFiscReducao.Index = 1;
			this.menuMemFiscReducao.Text = "Por Redução...";
			this.menuMemFiscReducao.Click += new System.EventHandler(this.menuMemFiscReducao_Click);
			// 
			// menuItem23
			// 
			this.menuItem23.Index = 3;
			this.menuItem23.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							 this.menuSimboloMoeda,
																																							 this.menuAliqTributaria,
																																							 this.menuHorarioVerao,
																																							 this.menuArredondamento,
																																							 this.menuTruncamento,
																																							 this.menuDepartamento,
																																							 this.menuTotParcial,
																																							 this.menuEspEntreLinha,
																																							 this.menuLinhasEntreCupons,
																																							 this.menuCaracGrafico,
																																							 this.menuImpactoAgulhas,
																																							 this.menuResetErro});
			this.menuItem23.Text = "Inicialização";
			// 
			// menuSimboloMoeda
			// 
			this.menuSimboloMoeda.Index = 0;
			this.menuSimboloMoeda.Text = "Altera o Símbolo da Moeda";
			this.menuSimboloMoeda.Click += new System.EventHandler(this.menuSimboloMoeda_Click);
			// 
			// menuAliqTributaria
			// 
			this.menuAliqTributaria.Index = 1;
			this.menuAliqTributaria.Text = "Adição de Alíquota Tributária";
			this.menuAliqTributaria.Click += new System.EventHandler(this.menuAliqTributaria_Click);
			// 
			// menuHorarioVerao
			// 
			this.menuHorarioVerao.Index = 2;
			this.menuHorarioVerao.Text = "Ativa/Desativa o Horário de Verão";
			this.menuHorarioVerao.Click += new System.EventHandler(this.menuHorarioVerao_Click);
			// 
			// menuArredondamento
			// 
			this.menuArredondamento.Index = 3;
			this.menuArredondamento.Text = "Programa Arredondamento";
			this.menuArredondamento.Click += new System.EventHandler(this.menuArredondamento_Click);
			// 
			// menuTruncamento
			// 
			this.menuTruncamento.Index = 4;
			this.menuTruncamento.Text = "Programa Truncamento";
			this.menuTruncamento.Click += new System.EventHandler(this.menuTruncamento_Click);
			// 
			// menuDepartamento
			// 
			this.menuDepartamento.Index = 5;
			this.menuDepartamento.Text = "Nomeia Departamento";
			this.menuDepartamento.Click += new System.EventHandler(this.menuDepartamento_Click);
			// 
			// menuTotParcial
			// 
			this.menuTotParcial.Index = 6;
			this.menuTotParcial.Text = "Nomeia Totalizador Parcial";
			this.menuTotParcial.Click += new System.EventHandler(this.menuTotParcial_Click);
			// 
			// menuEspEntreLinha
			// 
			this.menuEspEntreLinha.Index = 7;
			this.menuEspEntreLinha.Text = "Programa Espaço entre Linhas";
			this.menuEspEntreLinha.Click += new System.EventHandler(this.menuEspEntreLinha_Click);
			// 
			// menuLinhasEntreCupons
			// 
			this.menuLinhasEntreCupons.Index = 8;
			this.menuLinhasEntreCupons.Text = "Programa Linhas entre Cupons";
			this.menuLinhasEntreCupons.Click += new System.EventHandler(this.menuLinhasEntreCupons_Click);
			// 
			// menuCaracGrafico
			// 
			this.menuCaracGrafico.Index = 9;
			this.menuCaracGrafico.Text = "Programa Caracter Gráfico para Autenticação";
			this.menuCaracGrafico.Click += new System.EventHandler(this.menuCaracGrafico_Click);
			// 
			// menuImpactoAgulhas
			// 
			this.menuImpactoAgulhas.Index = 10;
			this.menuImpactoAgulhas.Text = "Programa Força de Impacto das Agulhas";
			this.menuImpactoAgulhas.Click += new System.EventHandler(this.menuImpactoAgulhas_Click);
			// 
			// menuResetErro
			// 
			this.menuResetErro.Index = 11;
			this.menuResetErro.Text = "Reset em Caso de Erro";
			this.menuResetErro.Click += new System.EventHandler(this.menuResetErro_Click);
			// 
			// menuItem36
			// 
			this.menuItem36.Index = 4;
			this.menuItem36.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							 this.menuCrescimos,
																																							 this.menuCGCIE,
																																							 this.menuClicheProprietario,
																																							 this.menuContTotNaoFiscais,
																																							 this.menuDataMovimento,
																																							 this.menuDataHoraImpressora,
																																							 this.menuDataHoraReducao,
																																							 this.menuFlagsFiscais,
																																							 this.menuGrandeTotal,
																																							 this.menuDadosUltimaReducao,
																																							 this.menuMinutosImprimindo,
																																							 this.menuMinutosLigada,
																																							 this.menuItem17,
																																							 this.menuRetEstadoImpressora,
																																							 this.menuItem44,
																																							 this.menuSimboloMoeda1,
																																							 this.menuFormaPgmento,
																																							 this.menuTotNaoFiscal});
			this.menuItem36.Text = "Informações da Impressora";
			// 
			// menuCrescimos
			// 
			this.menuCrescimos.Index = 0;
			this.menuCrescimos.Text = "Acréscimos";
			this.menuCrescimos.Click += new System.EventHandler(this.menuCrescimos_Click);
			// 
			// menuCGCIE
			// 
			this.menuCGCIE.Index = 1;
			this.menuCGCIE.Text = "CGC/IE";
			this.menuCGCIE.Click += new System.EventHandler(this.menuCGCIE_Click);
			// 
			// menuClicheProprietario
			// 
			this.menuClicheProprietario.Index = 2;
			this.menuClicheProprietario.Text = "Clichê do Proprietário";
			this.menuClicheProprietario.Click += new System.EventHandler(this.menuClicheProprietario_Click);
			// 
			// menuContTotNaoFiscais
			// 
			this.menuContTotNaoFiscais.Index = 3;
			this.menuContTotNaoFiscais.Text = "Contador dos Totalizadores Não Fiscais";
			this.menuContTotNaoFiscais.Click += new System.EventHandler(this.menuContTotNaoFiscais_Click);
			// 
			// menuDataMovimento
			// 
			this.menuDataMovimento.Index = 4;
			this.menuDataMovimento.Text = "Data Movimento";
			this.menuDataMovimento.Click += new System.EventHandler(this.menuDataMovimento_Click);
			// 
			// menuDataHoraImpressora
			// 
			this.menuDataHoraImpressora.Index = 5;
			this.menuDataHoraImpressora.Text = "Data/Hora Impressora";
			this.menuDataHoraImpressora.Click += new System.EventHandler(this.menuDataHoraImpressora_Click);
			// 
			// menuDataHoraReducao
			// 
			this.menuDataHoraReducao.Index = 6;
			this.menuDataHoraReducao.Text = "Data/Hora Redução";
			this.menuDataHoraReducao.Click += new System.EventHandler(this.menuDataHoraReducao_Click);
			// 
			// menuFlagsFiscais
			// 
			this.menuFlagsFiscais.Index = 7;
			this.menuFlagsFiscais.Text = "Flags Fiscais";
			this.menuFlagsFiscais.Click += new System.EventHandler(this.menuFlagsFiscais_Click);
			// 
			// menuGrandeTotal
			// 
			this.menuGrandeTotal.Index = 8;
			this.menuGrandeTotal.Text = "Grande Total";
			this.menuGrandeTotal.Click += new System.EventHandler(this.menuGrandeTotal_Click);
			// 
			// menuDadosUltimaReducao
			// 
			this.menuDadosUltimaReducao.Index = 9;
			this.menuDadosUltimaReducao.Text = "Leitura dos Dados da Última Redução Z";
			this.menuDadosUltimaReducao.Click += new System.EventHandler(this.menuDadosUltimaReducao_Click);
			// 
			// menuMinutosImprimindo
			// 
			this.menuMinutosImprimindo.Index = 10;
			this.menuMinutosImprimindo.Text = "Minutos Imprimindo";
			this.menuMinutosImprimindo.Click += new System.EventHandler(this.menuMinutosImprimindo_Click);
			// 
			// menuMinutosLigada
			// 
			this.menuMinutosLigada.Index = 11;
			this.menuMinutosLigada.Text = "Minutos Ligada";
			this.menuMinutosLigada.Click += new System.EventHandler(this.menuMinutosLigada_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 12;
			this.menuItem17.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							 this.menuNumLoja,
																																							 this.menuNumCupom,
																																							 this.menuNumCuponsCancel,
																																							 this.menuNumIntervencoes,
																																							 this.menuNumOperacoes,
																																							 this.menuNumReducoes,
																																							 this.menuNumSerie,
																																							 this.menuNumSubstProprietario,
																																							 this.menuNumCaixa,
																																							 this.menuNumUltimoItem});
			this.menuItem17.Text = "Número";
			// 
			// menuNumLoja
			// 
			this.menuNumLoja.Index = 0;
			this.menuNumLoja.Text = "Loja";
			this.menuNumLoja.Click += new System.EventHandler(this.menuNumLoja_Click);
			// 
			// menuNumCupom
			// 
			this.menuNumCupom.Index = 1;
			this.menuNumCupom.Text = "Cupom";
			this.menuNumCupom.Click += new System.EventHandler(this.menuNumCupom_Click);
			// 
			// menuNumCuponsCancel
			// 
			this.menuNumCuponsCancel.Index = 2;
			this.menuNumCuponsCancel.Text = "Cupons Cancelados";
			this.menuNumCuponsCancel.Click += new System.EventHandler(this.menuNumCuponsCancel_Click);
			// 
			// menuNumIntervencoes
			// 
			this.menuNumIntervencoes.Index = 3;
			this.menuNumIntervencoes.Text = "Intervenções Técnicas";
			this.menuNumIntervencoes.Click += new System.EventHandler(this.menuNumIntervencoes_Click);
			// 
			// menuNumOperacoes
			// 
			this.menuNumOperacoes.Index = 4;
			this.menuNumOperacoes.Text = "Operações Não Fiscais";
			this.menuNumOperacoes.Click += new System.EventHandler(this.menuNumOperacoes_Click);
			// 
			// menuNumReducoes
			// 
			this.menuNumReducoes.Index = 5;
			this.menuNumReducoes.Text = "Reduções";
			this.menuNumReducoes.Click += new System.EventHandler(this.menuNumReducoes_Click);
			// 
			// menuNumSerie
			// 
			this.menuNumSerie.Index = 6;
			this.menuNumSerie.Text = "Série";
			this.menuNumSerie.Click += new System.EventHandler(this.menuNumSerie_Click);
			// 
			// menuNumSubstProprietario
			// 
			this.menuNumSubstProprietario.Index = 7;
			this.menuNumSubstProprietario.Text = "Substituições de Proprietário";
			this.menuNumSubstProprietario.Click += new System.EventHandler(this.menuNumSubstProprietario_Click);
			// 
			// menuNumCaixa
			// 
			this.menuNumCaixa.Index = 8;
			this.menuNumCaixa.Text = "Caixa";
			this.menuNumCaixa.Click += new System.EventHandler(this.menuNumCaixa_Click);
			// 
			// menuNumUltimoItem
			// 
			this.menuNumUltimoItem.Index = 9;
			this.menuNumUltimoItem.Text = "Último Item Vendido";
			this.menuNumUltimoItem.Click += new System.EventHandler(this.menuNumUltimoItem_Click);
			// 
			// menuRetEstadoImpressora
			// 
			this.menuRetEstadoImpressora.Index = 13;
			this.menuRetEstadoImpressora.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																														this.menuRetEstadodaImpressora,
																																														this.menuRetFormaPagamento,
																																														this.menuRetAliquotas,
																																														this.menuRetSubTotal,
																																														this.menuRetCancelamentos,
																																														this.menuRetDepartamentos,
																																														this.menuRetDescontos,
																																														this.menuRetTotParciais});
			this.menuRetEstadoImpressora.Text = "Retorno";
			// 
			// menuRetEstadodaImpressora
			// 
			this.menuRetEstadodaImpressora.Index = 0;
			this.menuRetEstadodaImpressora.Text = "Estado da Impressora";
			this.menuRetEstadodaImpressora.Click += new System.EventHandler(this.menuRetEstadodaImpressora_Click);
			// 
			// menuRetFormaPagamento
			// 
			this.menuRetFormaPagamento.Index = 1;
			this.menuRetFormaPagamento.Text = "Formas de Pagamento";
			this.menuRetFormaPagamento.Click += new System.EventHandler(this.menuRetFormaPagamento_Click);
			// 
			// menuRetAliquotas
			// 
			this.menuRetAliquotas.Index = 2;
			this.menuRetAliquotas.Text = "Alíquotas";
			this.menuRetAliquotas.Click += new System.EventHandler(this.menuRetAliquotas_Click);
			// 
			// menuRetSubTotal
			// 
			this.menuRetSubTotal.Index = 3;
			this.menuRetSubTotal.Text = "Sub Total";
			this.menuRetSubTotal.Click += new System.EventHandler(this.menuRetSubTotal_Click);
			// 
			// menuRetCancelamentos
			// 
			this.menuRetCancelamentos.Index = 4;
			this.menuRetCancelamentos.Text = "Cancelamentos";
			this.menuRetCancelamentos.Click += new System.EventHandler(this.menuRetCancelamentos_Click);
			// 
			// menuRetDepartamentos
			// 
			this.menuRetDepartamentos.Index = 5;
			this.menuRetDepartamentos.Text = "Departamentos";
			this.menuRetDepartamentos.Click += new System.EventHandler(this.menuRetDepartamentos_Click);
			// 
			// menuRetDescontos
			// 
			this.menuRetDescontos.Index = 6;
			this.menuRetDescontos.Text = "Descontos";
			this.menuRetDescontos.Click += new System.EventHandler(this.menuRetDescontos_Click);
			// 
			// menuRetTotParciais
			// 
			this.menuRetTotParciais.Index = 7;
			this.menuRetTotParciais.Text = "Totalizadores Parciais";
			this.menuRetTotParciais.Click += new System.EventHandler(this.menuRetTotParciais_Click);
			// 
			// menuItem44
			// 
			this.menuItem44.Index = 14;
			this.menuItem44.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							 this.menuVerAliquotas,
																																							 this.menuVerEPROM,
																																							 this.menuVerIndiceAliquotas,
																																							 this.menuVerModoOperacao,
																																							 this.menuVerRecebNaoFiscais,
																																							 this.menuVerTipoImpressora,
																																							 this.menuVerTotalizadores,
																																							 this.menuVerTruncamento,
																																							 this.menuVerVersaoFirmware});
			this.menuItem44.Text = "Verifica ";
			// 
			// menuVerAliquotas
			// 
			this.menuVerAliquotas.Index = 0;
			this.menuVerAliquotas.Text = "Alíquotas ISS";
			this.menuVerAliquotas.Click += new System.EventHandler(this.menuVerAliquotas_Click);
			// 
			// menuVerEPROM
			// 
			this.menuVerEPROM.Index = 1;
			this.menuVerEPROM.Text = "EPROM Conectado";
			this.menuVerEPROM.Click += new System.EventHandler(this.menuVerEPROM_Click);
			// 
			// menuVerIndiceAliquotas
			// 
			this.menuVerIndiceAliquotas.Index = 2;
			this.menuVerIndiceAliquotas.Text = "Índice Alíquota ISS";
			this.menuVerIndiceAliquotas.Click += new System.EventHandler(this.menuVerIndiceAliquotas_Click);
			// 
			// menuVerModoOperacao
			// 
			this.menuVerModoOperacao.Index = 3;
			this.menuVerModoOperacao.Text = "Modo Operação";
			this.menuVerModoOperacao.Click += new System.EventHandler(this.menuVerModoOperacao_Click);
			// 
			// menuVerRecebNaoFiscais
			// 
			this.menuVerRecebNaoFiscais.Index = 4;
			this.menuVerRecebNaoFiscais.Text = "Recebimentos Não Fiscais";
			this.menuVerRecebNaoFiscais.Click += new System.EventHandler(this.menuVerRecebNaoFiscais_Click);
			// 
			// menuVerTipoImpressora
			// 
			this.menuVerTipoImpressora.Index = 5;
			this.menuVerTipoImpressora.Text = "Tipo Impressora";
			this.menuVerTipoImpressora.Click += new System.EventHandler(this.menuVerTipoImpressora_Click);
			// 
			// menuVerTotalizadores
			// 
			this.menuVerTotalizadores.Index = 6;
			this.menuVerTotalizadores.Text = "Totalizadores Não Fiscais";
			this.menuVerTotalizadores.Click += new System.EventHandler(this.menuVerTotalizadores_Click);
			// 
			// menuVerTruncamento
			// 
			this.menuVerTruncamento.Index = 7;
			this.menuVerTruncamento.Text = "Truncamento";
			this.menuVerTruncamento.Click += new System.EventHandler(this.menuVerTruncamento_Click);
			// 
			// menuVerVersaoFirmware
			// 
			this.menuVerVersaoFirmware.Index = 8;
			this.menuVerVersaoFirmware.Text = "Versão do Firmware";
			this.menuVerVersaoFirmware.Click += new System.EventHandler(this.menuVerVersaoFirmware_Click);
			// 
			// menuSimboloMoeda1
			// 
			this.menuSimboloMoeda1.Index = 15;
			this.menuSimboloMoeda1.Text = "Símbolo da Moeda";
			this.menuSimboloMoeda1.Click += new System.EventHandler(this.menuSimboloMoeda1_Click);
			// 
			// menuFormaPgmento
			// 
			this.menuFormaPgmento.Index = 16;
			this.menuFormaPgmento.Text = "Valor da Forma de Pagamento";
			this.menuFormaPgmento.Click += new System.EventHandler(this.menuFormaPgmento_Click);
			// 
			// menuTotNaoFiscal
			// 
			this.menuTotNaoFiscal.Index = 17;
			this.menuTotNaoFiscal.Text = "Valor do Totalizador Não Fiscal";
			this.menuTotNaoFiscal.Click += new System.EventHandler(this.menuTotNaoFiscal_Click);
			// 
			// menuItem37
			// 
			this.menuItem37.Index = 5;
			this.menuItem37.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							 this.menuAcionaGaveta,
																																							 this.menuEstadoGaveta});
			this.menuItem37.Text = "Gaveta de Dinheiro";
			// 
			// menuAcionaGaveta
			// 
			this.menuAcionaGaveta.Index = 0;
			this.menuAcionaGaveta.Text = "Aciona Gaveta";
			this.menuAcionaGaveta.Click += new System.EventHandler(this.menuAcionaGaveta_Click);
			// 
			// menuEstadoGaveta
			// 
			this.menuEstadoGaveta.Index = 1;
			this.menuEstadoGaveta.Text = "Verifica Estado da Gaveta";
			this.menuEstadoGaveta.Click += new System.EventHandler(this.menuEstadoGaveta_Click);
			// 
			// menuItem40
			// 
			this.menuItem40.Index = 6;
			this.menuItem40.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							 this.menuImprimeCheque,
																																							 this.menuCancelImpCheque,
																																							 this.menuMoedaSingular,
																																							 this.menuMoedaPlural,
																																							 this.menuStatusCheque,
																																							 this.menuCidadeFavorecido,
																																							 this.menuCopiaDoCheque});
			this.menuItem40.Text = "Cheque";
			// 
			// menuImprimeCheque
			// 
			this.menuImprimeCheque.Index = 0;
			this.menuImprimeCheque.Text = "Imprime Cheque...";
			this.menuImprimeCheque.Click += new System.EventHandler(this.menuImprimeCheque_Click);
			// 
			// menuCancelImpCheque
			// 
			this.menuCancelImpCheque.Index = 1;
			this.menuCancelImpCheque.Text = "Cancela Impressão do Cheque";
			this.menuCancelImpCheque.Click += new System.EventHandler(this.menuCancelImpCheque_Click);
			// 
			// menuMoedaSingular
			// 
			this.menuMoedaSingular.Index = 2;
			this.menuMoedaSingular.Text = "Programa Moeda no Singular...";
			this.menuMoedaSingular.Click += new System.EventHandler(this.menuMoedaSingular_Click);
			// 
			// menuMoedaPlural
			// 
			this.menuMoedaPlural.Index = 3;
			this.menuMoedaPlural.Text = "Programa Moeda no Plural...";
			this.menuMoedaPlural.Click += new System.EventHandler(this.menuMoedaPlural_Click);
			// 
			// menuStatusCheque
			// 
			this.menuStatusCheque.Index = 4;
			this.menuStatusCheque.Text = "Verifica Status do Cheque";
			this.menuStatusCheque.Click += new System.EventHandler(this.menuStatusCheque_Click);
			// 
			// menuCidadeFavorecido
			// 
			this.menuCidadeFavorecido.Index = 5;
			this.menuCidadeFavorecido.Text = "Inclui Cidade e Favorecido no Arquivo BEMAFI32.INI...";
			this.menuCidadeFavorecido.Click += new System.EventHandler(this.menuCidadeFavorecido_Click);
			// 
			// menuCopiaDoCheque
			// 
			this.menuCopiaDoCheque.Index = 6;
			this.menuCopiaDoCheque.Text = "Imprime Cópia do Cheque";
			this.menuCopiaDoCheque.Click += new System.EventHandler(this.menuCopiaDoCheque_Click);
			// 
			// menuItem49
			// 
			this.menuItem49.Index = 7;
			this.menuItem49.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																							 this.menuAberturaDia,
																																							 this.menuFechamentoDia,
																																							 this.menuConfPrinter,
																																							 this.menuImpDepartamentos,
																																							 this.menuRelAnalitico,
																																							 this.menuRelMestre,
																																							 this.menuImpLigada,
																																							 this.menuMapaResumo});
			this.menuItem49.Text = "Outras";
			// 
			// menuAberturaDia
			// 
			this.menuAberturaDia.Index = 0;
			this.menuAberturaDia.Text = "Abertura do Dia";
			this.menuAberturaDia.Click += new System.EventHandler(this.menuAberturaDia_Click);
			// 
			// menuFechamentoDia
			// 
			this.menuFechamentoDia.Index = 1;
			this.menuFechamentoDia.Text = "Fechamento do Dia";
			this.menuFechamentoDia.Click += new System.EventHandler(this.menuFechamentoDia_Click);
			// 
			// menuConfPrinter
			// 
			this.menuConfPrinter.Index = 2;
			this.menuConfPrinter.Text = "Imprime Configurações da Impressora";
			this.menuConfPrinter.Click += new System.EventHandler(this.menuConfPrinter_Click);
			// 
			// menuImpDepartamentos
			// 
			this.menuImpDepartamentos.Index = 3;
			this.menuImpDepartamentos.Text = "Imprime Departamentos";
			this.menuImpDepartamentos.Click += new System.EventHandler(this.menuImpDepartamentos_Click);
			// 
			// menuRelAnalitico
			// 
			this.menuRelAnalitico.Index = 4;
			this.menuRelAnalitico.Text = "Relatório Tipo 60 - Analítico";
			this.menuRelAnalitico.Click += new System.EventHandler(this.menuRelAnalitico_Click);
			// 
			// menuRelMestre
			// 
			this.menuRelMestre.Index = 5;
			this.menuRelMestre.Text = "Relatório Tipo 60 - Mestre";
			this.menuRelMestre.Click += new System.EventHandler(this.menuRelMestre_Click);
			// 
			// menuImpLigada
			// 
			this.menuImpLigada.Index = 6;
			this.menuImpLigada.Text = "Verifica Impressora Ligada";
			this.menuImpLigada.Click += new System.EventHandler(this.menuImpLigada_Click);
			// 
			// menuMapaResumo
			// 
			this.menuMapaResumo.Index = 7;
			this.menuMapaResumo.Text = "Mapa Resumo";
			this.menuMapaResumo.Click += new System.EventHandler(this.menuMapaResumo_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Usa Relatório Gerencial";
			this.menuItem3.Click += new System.EventHandler(this.menuUsaCompNaoFiscal_Click);
			// 
			// FormPrincipal
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(624, 170);
			this.Menu = this.mainMenu1;
			this.Name = "FormPrincipal";
			this.Text = "Exemplo para Impressora Fiscal usando a BEMAFI32.DLL";

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new FormPrincipal());
		}
		

		private void AbreCupom_Click(object sender, System.EventArgs e)
		{
			if (MessageBox.Show("Deseja usar CGC/CPF do Consumidor?","Bematech",MessageBoxButtons.YesNo) == DialogResult.Yes)
			{
				FormDialog MyDLG = new FormDialog();
				MyDLG.LabelEditCaption.Text = "Digite o CPF/CGC do cliente.";
				MyDLG.Text = "BEMATECH CPF/CGC";
				if (MyDLG.ShowDialog(this) == DialogResult.OK)					
				{
					IRetorno = BemaFI32.Bematech_FI_AbreCupom(MyDLG.textBoxRetorno.Text);					
					BemaFI32.Analisa_iRetorno(IRetorno);					
				}
				MyDLG.Dispose();
			}
			else
			{
				IRetorno = BemaFI32.Bematech_FI_AbreCupom("");
				BemaFI32.Analisa_iRetorno(IRetorno);
			}							
		}


		private void menuVendeItem_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_VendeItem("001","coca-cola","FF","I","1",2,"1,00","%","0");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuFechaResumido_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_FechaCupomResumido("Dinheiro","Obrigado. Volte sempre!");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuVendeItemDep_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_VendeItemDepartamento("001","coca-cola","FF","1,00","1","0","0","Bebidas","Frs");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuCancelItemAnt_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_CancelaItemAnterior();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuCancelItemGen_Click(object sender, System.EventArgs e)
		{ 
			FormDialog MyDLG = new FormDialog();
			MyDLG.Text = "BEMATECH Cancela item genérico";
			MyDLG.LabelEditCaption.Text = "Código do Item"; 
			if ((MyDLG.ShowDialog(this) == DialogResult.OK) && (MyDLG.textBoxRetorno.Text != ""))
			{
				IRetorno = BemaFI32.Bematech_FI_CancelaItemGenerico(MyDLG.textBoxRetorno.Text);
				BemaFI32.Analisa_iRetorno(IRetorno);
			}
			MyDLG.Dispose();
		}

		private void menuCancelCupom_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_CancelaCupom();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuIniFechamento_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_IniciaFechamentoCupom("A","%","0");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuEfetuaPagamento_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_EfetuaFormaPagamento("Dinheiro","5,00");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuEfetuaPagmentoTexto_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_EfetuaFormaPagamentoDescricaoForma("Cartão","6,00","Master Card");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuTerminaFechamento_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_TerminaFechamentoCupom("Obrigado. Volte Sempre");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuRelatGerencial_Click(object sender, System.EventArgs e)
		{			
			IRetorno = BemaFI32.Bematech_FI_RelatorioGerencial("Bematech SA \nRelátorio Gerencial... \n" + DateTime.Now.ToString()); 
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuFechaRelatGerencial_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_FechaRelatorioGerencial();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuAbreCompNaoFiscal_Click(object sender, System.EventArgs e)
		{
			// Passando os dois ultimos parâmetros em branco, a DLL pega o ultimo cupom e o valor.
			IRetorno = BemaFI32.Bematech_FI_AbreComprovanteNaoFiscalVinculado("Cartão","","");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuUsaCompNaoFiscal_Click(object sender, System.EventArgs e)
		{
			FormDialog MyDLG = new FormDialog();
			MyDLG.Text = "BEMATECH Usa Comprovante Não Fiscal Vinculado";
			MyDLG.LabelEditCaption.Text = "Digite o texto a ser impresso"; 
			if ((MyDLG.ShowDialog(this) == DialogResult.OK) && (MyDLG.textBoxRetorno.Text != ""))
			{
				IRetorno = BemaFI32.Bematech_FI_UsaComprovanteNaoFiscalVinculado(MyDLG.textBoxRetorno.Text);
				BemaFI32.Analisa_iRetorno(IRetorno);
			}

			MyDLG.Dispose();
		}

		private void menuFechaCompNaoFiscal_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_FechaComprovanteNaoFiscalVinculado();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuSuprimento_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_Suprimento("5,00","Dinheiro");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuSangria_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_Sangria("2,00");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuRecebNaoFiscal_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_RecebimentoNaoFiscal("01","10,00","Dinheiro");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuLeituraX_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_LeituraX();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuLeituraXSerial_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_LeituraXSerial();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuReducaoZ_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_ReducaoZ("","");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuMemFiscData_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_LeituraMemoriaFiscalData("01/12/2003","15/01/2004");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuMemFiscReducao_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_LeituraMemoriaFiscalReducao("001","010");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuSimboloMoeda_Click(object sender, System.EventArgs e)
		{
			FormDialog MyDLG = new FormDialog();
			MyDLG.Text = "BEMATECH Altera Símbolo Moeda";
			MyDLG.LabelEditCaption.Text = "Símbolo Moeda"; 
			MyDLG.textBoxRetorno.MaxLength  = 2;
			if ((MyDLG.ShowDialog(this) == DialogResult.OK) && (MyDLG.textBoxRetorno.Text != ""))
			{
				IRetorno = BemaFI32.Bematech_FI_AlteraSimboloMoeda(MyDLG.textBoxRetorno.Text);
				BemaFI32.Analisa_iRetorno(IRetorno);
			}
			MyDLG.Dispose();		
		}

		private void menuAliqTributaria_Click(object sender, System.EventArgs e)
		{
			FormDialog MyDLG = new FormDialog();
			MyDLG.Text = "BEMATECH Programa Aliquota Tributaria";
			MyDLG.LabelEditCaption.Text = "Valor da Aliquota"; 			
			if ((MyDLG.ShowDialog(this) == DialogResult.OK) && (MyDLG.textBoxRetorno.Text != ""))
			{
				IRetorno = BemaFI32.Bematech_FI_ProgramaAliquota(MyDLG.textBoxRetorno.Text,0); // Para o segundo parâmetro "0 = ICMS" e "1 = ISS"
				BemaFI32.Analisa_iRetorno(IRetorno);
			}
			MyDLG.Dispose();		
		}

		private void menuHorarioVerao_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_ProgramaHorarioVerao();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuArredondamento_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_ProgramaArredondamento();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuTruncamento_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_ProgramaTruncamento();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuDepartamento_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_NomeiaDepartamento(1,"Bebidas");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuTotParcial_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_NomeiaTotalizadorNaoSujeitoIcms(01,"Conta de Luz");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuEspEntreLinha_Click(object sender, System.EventArgs e)
		{
			// Esta função é somente para a impressora MP-40 FI II.
			IRetorno = BemaFI32.Bematech_FI_EspacoEntreLinhas(2);
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuLinhasEntreCupons_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_LinhasEntreCupons(7);
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuCaracGrafico_Click(object sender, System.EventArgs e)
		{
			// Implementar depois..
		}

		private void menuImpactoAgulhas_Click(object sender, System.EventArgs e)
		{
			/*	Força
					1 --> Fraco
					2 --> Médio
					3 --> Forte
			 */
			IRetorno = BemaFI32.Bematech_FI_ForcaImpactoAgulhas(1);
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuResetErro_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_ResetaImpressora();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuAcionaGaveta_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_AcionaGaveta();			
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuEstadoGaveta_Click(object sender, System.EventArgs e)
		{
			int EstadoGaveta;
			IRetorno = BemaFI32.Bematech_FI_VerificaEstadoGaveta(out EstadoGaveta);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Estado da Gaveta:" + EstadoGaveta.ToString());
		}

		private void menuAberturaDia_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_AberturaDoDia("50,00","Dinheiro");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuFechamentoDia_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_FechamentoDoDia();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuConfPrinter_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_ImprimeConfiguracoes();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuImpDepartamentos_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_ImprimeDepartamentos();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuRelAnalitico_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_RelatorioTipo60Analitico();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuRelMestre_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_RelatorioTipo60Mestre();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuImpLigada_Click(object sender, System.EventArgs e)
		{// Implementar uma MESSAGEM
			IRetorno = BemaFI32.Bematech_FI_VerificaImpressoraLigada();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuMapaResumo_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_MapaResumo();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuImprimeCheque_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_ImprimeCheque("001","150,30","Bematech S/A","Curitiba","01/03/2004","");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuCancelImpCheque_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_CancelaImpressaoCheque();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuMoedaSingular_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_ProgramaMoedaSingular("Real");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuMoedaPlural_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_ProgramaMoedaPlural("Reais");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuStatusCheque_Click(object sender, System.EventArgs e)
		{
			//int StatusCheque;
			//	IRetorno = BemaFI32.Bematech_FI_VerificaStatusCheque(StatusCheque);
			//  BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuCidadeFavorecido_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_IncluiCidadeFavorecido("Curitiba","Bematech");
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuCopiaDoCheque_Click(object sender, System.EventArgs e)
		{
			IRetorno = BemaFI32.Bematech_FI_ImprimeCopiaCheque();
			BemaFI32.Analisa_iRetorno(IRetorno);
		}

		private void menuCrescimos_Click(object sender, System.EventArgs e)
		{
			string Acrescimos = new string('\x20',14);
			IRetorno = BemaFI32.Bematech_FI_Acrescimos(ref Acrescimos);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Total de Acrescioms\n" + Acrescimos,"Bematech",MessageBoxButtons.OK);
		}

		private void menuCGCIE_Click(object sender, System.EventArgs e)
		{
			string CGC = new string('\x20',18);
			string IE	 = new string('\x20',15);
			IRetorno = BemaFI32.Bematech_FI_CGC_IE(ref CGC,ref IE);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("CGC: " + CGC + " - IE: " + IE,"Bematech",MessageBoxButtons.OK);			
		}

		private void menuClicheProprietario_Click(object sender, System.EventArgs e)
		{
			string Cliche = new string('\x20',186);
			IRetorno = BemaFI32.Bematech_FI_ClicheProprietario(ref Cliche);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Cliche do Proprietário: " + Cliche,"Bematech",MessageBoxButtons.OK);
		}

		private void menuContTotNaoFiscais_Click(object sender, System.EventArgs e)
		{
			string Contador = new string('\x20',44);
			IRetorno = BemaFI32.Bematech_FI_ContadoresTotalizadoresNaoFiscais(ref Contador);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Contador: " + Contador,"Bematech",MessageBoxButtons.OK);			
		}

		private void menuDataMovimento_Click(object sender, System.EventArgs e)
		{
			string Data = new string('\x20',6);
			IRetorno = BemaFI32.Bematech_FI_DataMovimento(ref Data);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Data do Movimento: " + Data,"Bematech",MessageBoxButtons.OK);
		}

		private void menuDataHoraImpressora_Click(object sender, System.EventArgs e)
		{
			string Data = new string('\x20',6);
			string Hora = new string('\x20',6);
			IRetorno = BemaFI32.Bematech_FI_DataHoraImpressora(ref Data, ref Hora);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Data/Hora Impressora: " + Data + " - " + Hora,"Bematech",MessageBoxButtons.OK);
			
		}

		private void menuDataHoraReducao_Click(object sender, System.EventArgs e)
		{
			string Data = new string('\x20',6);
			string Hora = new string('\x20',6);	
			IRetorno = BemaFI32.Bematech_FI_DataHoraReducao(ref Data, ref Hora);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Data/Hora da redução: " + Data + " - " + Hora,"Bematech",MessageBoxButtons.OK);
		}

		private void menuFlagsFiscais_Click(object sender, System.EventArgs e)
		{
			int Flags=0;
			IRetorno = BemaFI32.Bematech_FI_FlagsFiscais(ref Flags);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Flags Fiscais: " + Flags.ToString(),"Bematech",MessageBoxButtons.OK);			
		}

		private void menuGrandeTotal_Click(object sender, System.EventArgs e)
		{
			string GT = new string('\x20',18);
			IRetorno = BemaFI32.Bematech_FI_GrandeTotal(ref GT);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Grande Total: " + GT,"Bematech",MessageBoxButtons.OK);
		}

		private void menuDadosUltimaReducao_Click(object sender, System.EventArgs e)
		{
			string Dados = new string('\x20',613);
			IRetorno = BemaFI32.Bematech_FI_DadosUltimaReducao(ref Dados);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Dados da Última Redução Z: \n\n" + Dados,"Bematech",MessageBoxButtons.OK);
		}

		private void menuMinutosImprimindo_Click(object sender, System.EventArgs e)
		{
			string Minutos = new string('\x20',6);
			IRetorno = BemaFI32.Bematech_FI_MinutosImprimindo(ref Minutos);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Minutos Imprimindo: " + Minutos,"Bematech",MessageBoxButtons.OK);
		}

		private void menuMinutosLigada_Click(object sender, System.EventArgs e)
		{
			string Minutos = new string('\x20',6);
			IRetorno = BemaFI32.Bematech_FI_MinutosLigada(ref Minutos);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Minutos Ligada" + Minutos,"Bematech",MessageBoxButtons.OK);
		}

		private void menuNumLoja_Click(object sender, System.EventArgs e)
		{
			string Loja = new string('\x20',4);
			IRetorno = BemaFI32.Bematech_FI_NumeroLoja(ref Loja);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Numero Loja: " + Loja,"Bematech",MessageBoxButtons.OK);
		}

		private void menuNumCupom_Click(object sender, System.EventArgs e)
		{
			string Cupom = new string('\x20',14);
			IRetorno = BemaFI32.Bematech_FI_NumeroCupom(ref Cupom);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Numero do Cupom: " + Cupom,"Bematech",MessageBoxButtons.OK);
		}

		private void menuNumCuponsCancel_Click(object sender, System.EventArgs e)
		{
			string NumCupons = new string('\x20',4);
			IRetorno = BemaFI32.Bematech_FI_NumeroCuponsCancelados(ref NumCupons);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Numero de cupons cancelado: " + NumCupons,"Bematech",MessageBoxButtons.OK);
		}

		private void menuNumIntervencoes_Click(object sender, System.EventArgs e)
		{
			string NumIntervencoes = new string('\x20',4);
			IRetorno = BemaFI32.Bematech_FI_NumeroIntervencoes(ref NumIntervencoes);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Numero de Intervenções: " + NumIntervencoes,"Bematech",MessageBoxButtons.OK);
		}

		private void menuNumOperacoes_Click(object sender, System.EventArgs e)
		{
			string NumOperacoes = new string('\x20',6);
			IRetorno = BemaFI32.Bematech_FI_NumeroOperacoesNaoFiscais(ref NumOperacoes);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Numero de Operações não fiscais: " + NumOperacoes,"Bematech",MessageBoxButtons.OK);
		}

		private void menuNumReducoes_Click(object sender, System.EventArgs e)
		{
			string NumReducoes = new string('\x20',4);
			IRetorno = BemaFI32.Bematech_FI_NumeroReducoes(ref NumReducoes);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Número de Reduções: " + NumReducoes,"Bematech",MessageBoxButtons.OK);
		}

		private void menuNumSerie_Click(object sender, System.EventArgs e)
		{
			string NumSerie = new string('\x20',15);
			IRetorno = BemaFI32.Bematech_FI_NumeroSerie(ref NumSerie);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Número de Serie: " + NumSerie,"Bematech",MessageBoxButtons.OK);
		}

		private void menuNumSubstProprietario_Click(object sender, System.EventArgs e)
		{
			string NumSubstituicoes = new string('\x20',4);
			IRetorno = BemaFI32.Bematech_FI_NumeroSubstituicoesProprietario(ref NumSubstituicoes);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Número de Substituições de Proprietário: " + NumSubstituicoes,"Bematech",MessageBoxButtons.OK);
		}

		private void menuNumCaixa_Click(object sender, System.EventArgs e)
		{
			string NumCaixa = new string('\x20',4);
			IRetorno = BemaFI32.Bematech_FI_NumeroCaixa(ref NumCaixa);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Número do caixa: " + NumCaixa,"Bematech",MessageBoxButtons.OK);
		}

		private void menuNumUltimoItem_Click(object sender, System.EventArgs e)
		{
			string NumItem = new string('\x20',4);
			IRetorno = BemaFI32.Bematech_FI_UltimoItemVendido(ref NumItem);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Número do ultimo item vendido: " + NumItem,"Bematech",MessageBoxButtons.OK);
		}

		private void menuRetEstadodaImpressora_Click(object sender, System.EventArgs e)
		{
			int ACK,ST1,ST2;
			ACK= ST1= ST2= 0;
			IRetorno = BemaFI32.Bematech_FI_VerificaEstadoImpressora(ref ACK,ref ST1,ref ST2);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Retorno da Impressora:" + "\nACK: " + ACK + "\nST1: " + ST1 + "\nST2: " + ST2,"Bematech",MessageBoxButtons.OK);
		}

		private void menuRetFormaPagamento_Click(object sender, System.EventArgs e)
		{
			string Formas = new string('\x20',3016);
			IRetorno = BemaFI32.Bematech_FI_VerificaFormasPagamento(ref Formas);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Formas de Pagamento : " + Formas,"Bematech",MessageBoxButtons.OK);
		}

		private void menuRetAliquotas_Click(object sender, System.EventArgs e)
		{
			string Aliquotas = new string('\x20',79);
			IRetorno = BemaFI32.Bematech_FI_RetornoAliquotas(ref Aliquotas);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Alíquotas Programadas : " + Aliquotas,"Bematech",MessageBoxButtons.OK);
		}

		private void menuRetSubTotal_Click(object sender, System.EventArgs e)
		{
			string SubTotal = new string('\x20',14);
			IRetorno = BemaFI32.Bematech_FI_SubTotal(ref SubTotal);	
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("SubTotal do Cupom : " + SubTotal,"Bematech",MessageBoxButtons.OK);
		}

		private void menuRetCancelamentos_Click(object sender, System.EventArgs e)
		{
			string ValorCancelamentos = new string('\x20',14);
			IRetorno = BemaFI32.Bematech_FI_Cancelamentos(ref ValorCancelamentos);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Valor dos Cancelamentos : " + ValorCancelamentos,"Bematech",MessageBoxButtons.OK);
		}

		private void menuRetDepartamentos_Click(object sender, System.EventArgs e)
		{
			string Departamentos = new string('\x20',1019);
			IRetorno = BemaFI32.Bematech_FI_VerificaDepartamentos(ref Departamentos);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Departamentos : " + Departamentos,"Bematech",MessageBoxButtons.OK);
		}

		private void menuRetDescontos_Click(object sender, System.EventArgs e)
		{
			string ValorDescontos = new string('\x20',14);
			IRetorno = BemaFI32.Bematech_FI_Descontos(ref ValorDescontos);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Valor dos Descontos : " + ValorDescontos,"Bematech",MessageBoxButtons.OK);
		}

		private void menuRetTotParciais_Click(object sender, System.EventArgs e)
		{
			string Totalizadores = new string('\x20',445);
			IRetorno = BemaFI32.Bematech_FI_VerificaTotalizadoresParciais(ref Totalizadores);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Totalizadores: \n" + Totalizadores,"Bematech",MessageBoxButtons.OK);
		}

		private void menuVerAliquotas_Click(object sender, System.EventArgs e)
		{
			string Aliquotas = new string('\x20',79);
			IRetorno = BemaFI32.Bematech_FI_VerificaAliquotasIss(ref Aliquotas);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Aliquotas de ISS : " + Aliquotas,"Bematech",MessageBoxButtons.OK);
		}

		private void menuVerEPROM_Click(object sender, System.EventArgs e)
		{
			string Flag = new string('\x20',2);;
			IRetorno = BemaFI32.Bematech_FI_VerificaEpromConectada(ref Flag);			
			BemaFI32.Analisa_iRetorno(IRetorno);
			if (Flag == "1")
				MessageBox.Show("EPROM Conectada!","Bematech",MessageBoxButtons.OK);
			else
				MessageBox.Show("EPROM Desconectada!","Bematech",MessageBoxButtons.OK);

		}

		private void menuVerIndiceAliquotas_Click(object sender, System.EventArgs e)
		{
			string Flag = new string('\x20',48);
			IRetorno = BemaFI32.Bematech_FI_VerificaIndiceAliquotasIss(ref Flag);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Indice Aliquotas ISS : " + Flag,"Bematech",MessageBoxButtons.OK);
		}

		private void menuVerModoOperacao_Click(object sender, System.EventArgs e)
		{
			string Modo  = new string('\x20',2);;
			IRetorno = BemaFI32.Bematech_FI_VerificaModoOperacao(ref Modo);
			BemaFI32.Analisa_iRetorno(IRetorno);
			if (Modo == "1")
				MessageBox.Show("Modo Normal !" ,"Bematech",MessageBoxButtons.OK);
			else
				MessageBox.Show("Modo Interveção Técnica !" ,"Bematech",MessageBoxButtons.OK);      		
		}

		private void menuVerRecebNaoFiscais_Click(object sender, System.EventArgs e)
		{
			string Recebimentos = new string('\x20',2200);
			IRetorno = BemaFI32.Bematech_FI_VerificaRecebimentoNaoFiscal(ref Recebimentos);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Recebimentos : " + Recebimentos,"Bematech",MessageBoxButtons.OK);
		}

		private void menuVerTipoImpressora_Click(object sender, System.EventArgs e)
		{
			int TipoImpressora=0;
			string MSG="";
			IRetorno = BemaFI32.Bematech_FI_VerificaTipoImpressora(ref TipoImpressora);
			BemaFI32.Analisa_iRetorno(IRetorno);
			switch (TipoImpressora)
			{
				case 1: MSG="Impressora fiscal, gaveta, autenticaçao.";
					break;
				case 2: MSG="Impressora fiscal, gaveta, cutter.";
					break;
				case 3: MSG="Impressora fiscal, presenter, autenticaçao.";
					break;
				case 4: MSG="Impressora fiscal, presenter, cutter.";
					break;
				case 5: MSG="Impressora bilhete de passagem, gaveta, autenticaçao.";
					break;
				case 6: MSG="Impressora bilhete de passagem, gaveta, cutter.";
					break;
				case 7: MSG="Impressora bilhete de passagem, presenter, autenticaçao.";
					break;
				case 8: MSG="Impressora bilhete de passagem, presenter, cutter.";
					break;
			}
			MessageBox.Show(MSG,"Bematech",MessageBoxButtons.OK);
		}

		private void menuVerTotalizadores_Click(object sender, System.EventArgs e)
		{
			string Totalizadores = new string('\x20',179);
			IRetorno = BemaFI32.Bematech_FI_VerificaTotalizadoresNaoFiscais(ref Totalizadores);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Totalizadores : " + Totalizadores,"Bematech",MessageBoxButtons.OK);
		}

		private void menuVerTruncamento_Click(object sender, System.EventArgs e)
		{
			string Flag = new string('\x20',2);
			IRetorno = BemaFI32.Bematech_FI_VerificaTruncamento(ref Flag);
			BemaFI32.Analisa_iRetorno(IRetorno);
			if (Flag == "1")
				MessageBox.Show("A Impressora está Truncando.","Bematech",MessageBoxButtons.OK);
			else
				MessageBox.Show("A Impressora está Arredondando.","Bematech",MessageBoxButtons.OK);			
		}

		private void menuVerVersaoFirmware_Click(object sender, System.EventArgs e)
		{
			string VersaoFirmware = new string('\x20',4);
			IRetorno = BemaFI32.Bematech_FI_VersaoFirmware(ref VersaoFirmware);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Versão do Firmware: " + VersaoFirmware ,"Bematech",MessageBoxButtons.OK);
		}

		private void menuSimboloMoeda1_Click(object sender, System.EventArgs e)
		{
			string SimboloMoeda = new string('\x20',2);
			IRetorno = BemaFI32.Bematech_FI_SimboloMoeda(ref SimboloMoeda);
			BemaFI32.Analisa_iRetorno(IRetorno);
			MessageBox.Show("Simbolo Moeda: " + SimboloMoeda,"Bematech",MessageBoxButtons.OK);
		}

		private void menuFormaPgmento_Click(object sender, System.EventArgs e)
		{
			string ValorForma = new string('\x20',15);;
			IRetorno = BemaFI32.Bematech_FI_ValorFormaPagamento("Dinheiro",ref ValorForma);			
			BemaFI32.Analisa_iRetorno(IRetorno);
			ValorForma = ValorForma.Insert(12,",");
			ValorForma = ValorForma.Trim('0');
			MessageBox.Show("Valor da forma de pagamento Dinheiro: " + ValorForma,"Bematech",MessageBoxButtons.OK);
		}

		private void menuTotNaoFiscal_Click(object sender, System.EventArgs e)
		{
			string ValorTotalizador = new string('\x20',15);;
			IRetorno = BemaFI32.Bematech_FI_ValorTotalizadorNaoFiscal("Conta de Luz",ref ValorTotalizador);
			BemaFI32.Analisa_iRetorno(IRetorno);
			ValorTotalizador = ValorTotalizador.Insert(12,",");
			ValorTotalizador = ValorTotalizador.Trim('0');
			MessageBox.Show("Valor do Totalizador Não Fiscal: " + ValorTotalizador,"Bematech",MessageBoxButtons.OK);
		}


	}
}
