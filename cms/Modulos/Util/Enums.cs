using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cms.Modulos.Util
{

    /// <summary>
    /// select tabela + ' = ' + CONVERT(varchar, id_referencia) + ', '  from referencia
    /// </summary>
    public enum Referencia : long
    {
        auditoria_log = 735341684,
        auditoria_log_detalhe = 959342482,
        cep_bairro = 728389664,
        cep_cidade = 584389151,
        cep_distrito = 360388353,
        cep_endereco = 536388980,
        cep_estado = 680389493,
        cep_municipio = 808389949,
        cep_paises = 648389379,
        cep_subdistrito = 488388809,
        cliente = 116195464,
        cliente_comentario = 388196433,
        cliente_contato = 308196148,
        compra = 765961805,
        compra_item = 621961292,
        compra_pagamento = 1514488474,
        compra_xml = 1325963800,
        empresa = 1108915022,
        empresa_comentario = 1631344876,
        empresa_contato = 1679345047,
        financeiro_banco = 36195179,
        financeiro_boleto = 1247343508,
        financeiro_boleto_log = 323532236,
        financeiro_boleto_ocorrencia = 371532407,
        financeiro_condicao_pagamento = 1370487961,
        financeiro_condicao_pagamento_parcela = 1338487847,
        financeiro_conta_corrente = 235147883,
        financeiro_conta_pagar = 1255675521,
        financeiro_conta_receber = 1447676205,
        financeiro_forma_pagamento = 1012198656,
        financeiro_lancamento = 1639676889,
        financeiro_plano_conta = 1796201449,
        fiscal_cfop = 1035866757,
        fiscal_cnae = 1795537480,
        fiscal_icms = 641437359,
        fiscal_iss = 545437017,
        fiscal_natureza_operacao = 2008394224,
        fiscal_ncm = 1307867726,
        fiscal_ncm_iva = 593437188,
        fornecedor = 500196832,
        fornecedor_comentario = 651149365,
        fornecedor_contato = 699149536,
        menu = 1215343394,
        menu_detalhe = 1839345617,
        menu_detalhe_permissao = 2031346301,
        menu_permissao = 1935345959,
        nfe = 1603536796,
        nfe_arquivo = 1715537195,
        produto = 1585440722,
        produto_base_icms = 449436675,
        produto_embalagem = 29959183,
        produto_estoque = 1089438955,
        produto_estoque_historico = 535008987,
        produto_familia = 96719397,
        produto_foto = 1037246750,
        produto_grupo = 112719454,
        produto_icms = 497436846,
        produto_ipi_icms = 1786489443,
        produto_preco_tabela = 957246465,
        produto_produto_preco_tabela = 1937441976,
        produto_subfamilia = 320720195,
        produto_subgrupo = 192719739,
        transportadora = 581577110,
        transportadora_comentario = 597577167,
        transportadora_contato = 613577224,
        usuario = 155863622,
        usuario_empresa = 1220915421,
        venda = 131531552,
        venda_item = 2039014345,
        venda_pagamento = 739533718, 
    }

    /// <summary>
    /// select nome + ' = ' + CONVERT(varchar, id_menu_detalhe) + ', ' from menu_detalhe
    /// </summary>
    public enum PermissaoDetalhe : long
    {
        cadastrar_cliente = 123,
        cadastrar_produto = 124,
        alterar_preco = 125
    }

    public enum TipoPlanoConta : long
    {
        Entrada = 1,
        Saida = 2
    }

}
