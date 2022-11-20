using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using cms.Data;

namespace cms.Modulos.Util
{
    public class ExtensionMethods
    {
    }

    public class Validacoes
    {
        public static bool ValidaCPF(string vrCPF)
        {
            string valor = vrCPF.Replace(".", "");
            valor = valor.Replace("-", "");


            if (valor.Length != 11)
                return false;


            bool igual = true;
            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;


            if (igual || valor == "12345678909")
                return false;


            int[] numeros = new int[11];


            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(
                  valor[i].ToString());


            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];


            int resultado = soma % 11;


            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
                return false;


            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];


            resultado = soma % 11;


            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
                if (numeros[10] != 11 - resultado)
                    return false;


            return true;
        }

        public static bool ValidaCNPJ(string vrCNPJ)
        {
            string CNPJ = vrCNPJ.Replace(".", "");
            CNPJ = CNPJ.Replace("/", "");
            CNPJ = CNPJ.Replace("-", "");


            int[] digitos, soma, resultado;
            int nrDig;
            string ftmt;
            bool[] CNPJOk;


            ftmt = "6543298765432";
            digitos = new int[14];
            soma = new int[2];
            soma[0] = 0;
            soma[1] = 0;
            resultado = new int[2];
            resultado[0] = 0;
            resultado[1] = 0;
            CNPJOk = new bool[2];
            CNPJOk[0] = false;
            CNPJOk[1] = false;


            try
            {
                for (nrDig = 0; nrDig < 14; nrDig++)
                {
                    digitos[nrDig] = int.Parse(
                        CNPJ.Substring(nrDig, 1));
                    if (nrDig <= 11)
                        soma[0] += (digitos[nrDig] *
                          int.Parse(ftmt.Substring(
                          nrDig + 1, 1)));
                    if (nrDig <= 12)
                        soma[1] += (digitos[nrDig] *
                          int.Parse(ftmt.Substring(
                          nrDig, 1)));
                }


                for (nrDig = 0; nrDig < 2; nrDig++)
                {
                    resultado[nrDig] = (soma[nrDig] % 11);
                    if ((resultado[nrDig] == 0) || (
                         resultado[nrDig] == 1))
                        CNPJOk[nrDig] = (
                        digitos[12 + nrDig] == 0);
                    else
                        CNPJOk[nrDig] = (
                        digitos[12 + nrDig] == (
                        11 - resultado[nrDig]));
                }
                return (CNPJOk[0] && CNPJOk[1]);
            }
            catch
            {
                return false;
            }
        }
    }

    public static class Combos
    {
        public static List<Estados> Estado()
        {
            List<Estados> dResult = new List<Estados>();

            dResult.Add(new Estados("", "Selecione o estado"));
            dResult.Add(new Estados("AC", "Acre"));
            dResult.Add(new Estados("AL", "Alagoas"));
            dResult.Add(new Estados("AP", "Amapá"));
            dResult.Add(new Estados("AM", "Amazonas"));
            dResult.Add(new Estados("BA", "Bahia"));
            dResult.Add(new Estados("CE", "Ceará"));
            dResult.Add(new Estados("DF", "Distrito Federal"));
            dResult.Add(new Estados("ES", "Espirito Santo"));
            dResult.Add(new Estados("GO", "Goiás"));
            dResult.Add(new Estados("MA", "Maranhão"));
            dResult.Add(new Estados("MS", "Mato Grosso do Sul"));
            dResult.Add(new Estados("MT", "Mato Grosso"));
            dResult.Add(new Estados("MG", "Minas Gerais"));
            dResult.Add(new Estados("PA", "Pará"));
            dResult.Add(new Estados("PB", "Paraíba"));
            dResult.Add(new Estados("PR", "Paraná"));
            dResult.Add(new Estados("PE", "Pernambuco"));
            dResult.Add(new Estados("PI", "Piauí"));
            dResult.Add(new Estados("RJ", "Rio de Janeiro"));
            dResult.Add(new Estados("RN", "Rio Grande do Norte"));
            dResult.Add(new Estados("RS", "Rio Grande do Sul"));
            dResult.Add(new Estados("RO", "Rondônia"));
            dResult.Add(new Estados("RR", "Roraima"));
            dResult.Add(new Estados("SC", "Santa Catarina"));
            dResult.Add(new Estados("SP", "São Paulo"));
            dResult.Add(new Estados("SE", "Sergipe"));
            dResult.Add(new Estados("TO", "Tocantins"));

            return dResult;
        }

        public static List<ComboPropriedades> FormaPagamento()
        {
            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            cmsEntities dbEntities = new cmsEntities();

            dResult.Add(new ComboPropriedades("", "Selecione"));

            var forma_pagamentos = from i in dbEntities.financeiro_forma_pagamento
                                   where i.excluido == false
                                   select i;

            foreach (var i in forma_pagamentos)
            {
                dResult.Add(new ComboPropriedades(i.id_financeiro_forma_pagamento.ToString(), i.descricao));
            }

            return dResult;
        }

        public static List<ComboPropriedades> TipoCliente()
        {
            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            dResult.Add(new ComboPropriedades("", "Selecione"));
            dResult.Add(new ComboPropriedades("Atacado", "Atacado"));
            dResult.Add(new ComboPropriedades("Varejo", "Varejo"));
            dResult.Add(new ComboPropriedades("Web", "Web"));

            return dResult;
        }

        public static List<ComboPropriedades> ClasseABC()
        {
            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            dResult.Add(new ComboPropriedades("", "Selecione"));
            dResult.Add(new ComboPropriedades("A", "A - Grande qtde de itens, grande valor investido."));
            dResult.Add(new ComboPropriedades("B", "B - Média qtde de itens, médio valor investido."));
            dResult.Add(new ComboPropriedades("C", "C - Grande qtde de itens, pequeno valor investido."));

            return dResult;
        }

        public static List<ComboPropriedades> UnidadeMedida()
        {
            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            dResult.Add(new ComboPropriedades("", "Selecione"));
            dResult.Add(new ComboPropriedades("Unidade", "Unidade"));
            dResult.Add(new ComboPropriedades("Par", "Par"));
            dResult.Add(new ComboPropriedades("Caixa", "Caixa"));
            dResult.Add(new ComboPropriedades("Metro", "Metro"));
            dResult.Add(new ComboPropriedades("Kilo", "Kilo"));
            dResult.Add(new ComboPropriedades("Resma", "Resma"));
            dResult.Add(new ComboPropriedades("Saco", "Saco"));
            dResult.Add(new ComboPropriedades("Pacote", "Pacote"));
            dResult.Add(new ComboPropriedades("Peça", "Peça"));
            dResult.Add(new ComboPropriedades("Metro Cúbico", "Metro Cúbico"));
            dResult.Add(new ComboPropriedades("Metro Quadrado", "Metro Quadrado"));
            dResult.Add(new ComboPropriedades("Frasco", "Frasco"));
            dResult.Add(new ComboPropriedades("Milheiro", "Milheiro"));
            dResult.Add(new ComboPropriedades("Galão", "Galão"));
            dResult.Add(new ComboPropriedades("Lata", "Lata"));
            dResult.Add(new ComboPropriedades("Balde", "Balde"));
            dResult.Add(new ComboPropriedades("Folha", "Folha"));
            dResult.Add(new ComboPropriedades("Cartela", "Cartela"));
            dResult.Add(new ComboPropriedades("Barra", "Barra"));
            dResult.Add(new ComboPropriedades("Rolo", "Rolo"));
            dResult.Add(new ComboPropriedades("Tonelada", "Tonelada"));
            dResult.Add(new ComboPropriedades("Grama", "Grama"));
            dResult.Add(new ComboPropriedades("Tambor", "Tambor"));
            dResult.Add(new ComboPropriedades("Bombona", "Bombona"));
            dResult.Add(new ComboPropriedades("Fardo", "Fardo"));
            dResult.Add(new ComboPropriedades("Pote", "Pote"));
            dResult.Add(new ComboPropriedades("Refil", "Refil"));
            dResult.Add(new ComboPropriedades("Barril", "Barril"));
            dResult.Add(new ComboPropriedades("Disco", "Disco"));
            dResult.Add(new ComboPropriedades("Hora", "Hora"));
            dResult.Add(new ComboPropriedades("Dia", "Dia"));
            dResult.Add(new ComboPropriedades("Litros", "Litros"));
            dResult.Add(new ComboPropriedades("Cento", "Cento"));

            return dResult;
        }

        public static List<ComboPropriedades> CSTOrigem()
        {
            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            dResult.Add(new ComboPropriedades("", "Selecione"));
            dResult.Add(new ComboPropriedades("0", "0 - Nacional"));
            dResult.Add(new ComboPropriedades("1", "1 - Estrangeira importação direta"));
            dResult.Add(new ComboPropriedades("2", "2 - Estrangeira adquirida no mercado interno"));

            return dResult;
        }

        public static List<ComboPropriedades> CSTBase()
        {
            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            dResult.Add(new ComboPropriedades("", "Selecione"));
            dResult.Add(new ComboPropriedades("00", "00 - Tributada integralmente"));
            dResult.Add(new ComboPropriedades("10", "10 - Tributada e com cobrança do ICMS por substituição tributária"));
            dResult.Add(new ComboPropriedades("20", "20 - Com redução de base de cálculo"));
            dResult.Add(new ComboPropriedades("30", "30 - Isenta ou não tributada e com cobrança do ICMS por substituição tributária"));
            dResult.Add(new ComboPropriedades("40", "40 - Isenta"));
            dResult.Add(new ComboPropriedades("41", "41 - Não Tributada"));
            dResult.Add(new ComboPropriedades("50", "50 - Suspensão"));
            dResult.Add(new ComboPropriedades("51", "51 - Diferimento"));
            dResult.Add(new ComboPropriedades("60", "60 - ICMS cobrado anteriormente por substituição tributária"));
            dResult.Add(new ComboPropriedades("70", "70 - Com redução de base de cálculo e cobrança do ICMS por substituição tributária"));
            dResult.Add(new ComboPropriedades("90", "90 - Outras"));
            dResult.Add(new ComboPropriedades("101", "101 - Tributada com permissão de crédito"));
            dResult.Add(new ComboPropriedades("102", "102 - Tributada sem permissão de crédito"));
            dResult.Add(new ComboPropriedades("103", "103 - Isenção do ICMS para faixa de receita bruta"));
            dResult.Add(new ComboPropriedades("201", "201 - Tributada com permissão de crédito e com cobrança do ICMS por substituição tributária"));
            dResult.Add(new ComboPropriedades("202", "202 - Tributada sem permissão de crédito e com cobrança do ICMS por substituição tributária"));
            dResult.Add(new ComboPropriedades("203", "203 - Isenção do ICMS para faixa de receita bruta e com cobrança do ICMS por substituição tributária"));
            dResult.Add(new ComboPropriedades("300", "300 - Imune: Classificam-se neste código as operações praticadas por optantes contempladas com imunidade do ICMS."));
            dResult.Add(new ComboPropriedades("400", "400 - Não tributada"));
            dResult.Add(new ComboPropriedades("500", "500 - ICMS cobrado anteriormente por substituição tributária (substituído) ou por antecipação"));
            dResult.Add(new ComboPropriedades("900", "900 - Outros"));
            
            return dResult;
        }
        
        public static List<ComboPropriedades> CST()
        {
            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            dResult.Add(new ComboPropriedades("", "Selecione"));
            dResult.Add(new ComboPropriedades("00", "00 - Tributada integralmente"));
            dResult.Add(new ComboPropriedades("10", "10 - Tributada e com cobrança do ICMS por substituição tributária"));
            dResult.Add(new ComboPropriedades("20", "20 - Com redução de base de cálculo"));
            dResult.Add(new ComboPropriedades("30", "30 - Isenta ou não tributada e com cobrança do ICMS por substituição tributária"));
            dResult.Add(new ComboPropriedades("40", "40 - Isenta"));
            dResult.Add(new ComboPropriedades("41", "41 - Não Tributada"));
            dResult.Add(new ComboPropriedades("50", "50 - Suspensão"));
            dResult.Add(new ComboPropriedades("51", "51 - Diferimento"));
            dResult.Add(new ComboPropriedades("60", "60 - ICMS cobrado anteriormente por substituição tributária"));
            dResult.Add(new ComboPropriedades("70", "70 - Com redução de base de cálculo e cobrança do ICMS por substituição tributária"));
            dResult.Add(new ComboPropriedades("90", "90 - Outras"));

            return dResult;
        }

        public static List<ComboPropriedades> CSTIPI()
        {
            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            dResult.Add(new ComboPropriedades("", "Selecione"));
            dResult.Add(new ComboPropriedades("00", "00 – Entrada com recuperação de crédito"));
            dResult.Add(new ComboPropriedades("01", "01 – Entrada tributada com alíquota zero"));
            dResult.Add(new ComboPropriedades("02", "02 – Entrada isenta"));
            dResult.Add(new ComboPropriedades("03", "03 – Entrada não-tributada"));
            dResult.Add(new ComboPropriedades("04", "04 – Entrada imune"));
            dResult.Add(new ComboPropriedades("05", "05 – Entrada com suspensão"));
            dResult.Add(new ComboPropriedades("49", "49 – Outras Entradas"));
            dResult.Add(new ComboPropriedades("50", "50 – Saída tributada"));
            dResult.Add(new ComboPropriedades("51", "51 – Saída tributada com alíquota zero"));
            dResult.Add(new ComboPropriedades("52", "52 – Saída isenta"));
            dResult.Add(new ComboPropriedades("53", "53 – Saída não-tributada"));
            dResult.Add(new ComboPropriedades("54", "54 – Saída imune"));
            dResult.Add(new ComboPropriedades("55", "55 – Saída com suspensão"));
            dResult.Add(new ComboPropriedades("99", "99 – Outras saídas"));
    
            return dResult;
        }
        
        public static List<ComboPropriedades> CSTPIS()
        {
            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            dResult.Add(new ComboPropriedades("", "Selecione"));
            dResult.Add(new ComboPropriedades("01", "01 - Operação Tributável com Alíquota Básica"));
            dResult.Add(new ComboPropriedades("02", "02 - Operação Tributável com Alíquota Diferenciada"));
            dResult.Add(new ComboPropriedades("03", "03 - Operação Tributável com Alíquota por Unidade de Medida de Produto"));
            dResult.Add(new ComboPropriedades("04", "04 - Operação Tributável Monofásica - Revenda a Alíquota Zero"));
            dResult.Add(new ComboPropriedades("05", "05 - Operação Tributável por Substituição Tributária"));
            dResult.Add(new ComboPropriedades("06", "06 - Operação Tributável a Alíquota Zero"));
            dResult.Add(new ComboPropriedades("07", "07 - Operação Isenta da Contribuição"));
            dResult.Add(new ComboPropriedades("08", "08 - Operação sem Incidência da Contribuição"));
            dResult.Add(new ComboPropriedades("09", "09 - Operação com Suspensão da Contribuição"));
            dResult.Add(new ComboPropriedades("49", "49 - Outras Operações de Saída"));
            dResult.Add(new ComboPropriedades("50", "50 - Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno"));
            dResult.Add(new ComboPropriedades("51", "51 - Operação com Direito a Crédito - Vinculada Exclusivamente a  Receita Não-Tributada no Mercado Interno"));
            dResult.Add(new ComboPropriedades("52", "52 - Operação com Direito a Crédito - Vinculada Exclusivamente a Receita de Exportação"));
            dResult.Add(new ComboPropriedades("53", "53 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno"));
            dResult.Add(new ComboPropriedades("54", "54 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação"));
            dResult.Add(new ComboPropriedades("55", "55 - Operação com Direito a Crédito - Vinculada a Receitas Não Tributadas no Mercado Interno e de Exportação"));
            dResult.Add(new ComboPropriedades("56", "56 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno e de Exportação"));
            dResult.Add(new ComboPropriedades("60", "60 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno"));
            dResult.Add(new ComboPropriedades("61", "61 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno"));
            dResult.Add(new ComboPropriedades("62", "62 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação"));
            dResult.Add(new ComboPropriedades("63", "63 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno"));
            dResult.Add(new ComboPropriedades("64", "64 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação"));
            dResult.Add(new ComboPropriedades("65", "65 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação"));
            dResult.Add(new ComboPropriedades("66", "66 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno e de Exportação"));
            dResult.Add(new ComboPropriedades("67", "67 - Crédito Presumido - Outras Operações"));
            dResult.Add(new ComboPropriedades("70", "70 - Operação de Aquisição sem Direito a Crédito"));
            dResult.Add(new ComboPropriedades("71", "71 - Operação de Aquisição com Isenção"));
            dResult.Add(new ComboPropriedades("72", "72 - Operação de Aquisição com Suspensão"));
            dResult.Add(new ComboPropriedades("73", "73 - Operação de Aquisição a Alíquota Zero"));
            dResult.Add(new ComboPropriedades("74", "74 - Operação de Aquisição sem Incidência da Contribuição"));
            dResult.Add(new ComboPropriedades("75", "75 - Operação de Aquisição por Substituição Tributária"));
            dResult.Add(new ComboPropriedades("98", "98 - Outras Operações de Entrada"));
            dResult.Add(new ComboPropriedades("99", "99 - Outras Operações"));

            return dResult;
        }
                
        public static List<ComboPropriedades> CSTISS()
        {
            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            dResult.Add(new ComboPropriedades("", "Selecione"));
            dResult.Add(new ComboPropriedades("01", "01 - Operação Tributável com Alíquota Básica"));
            dResult.Add(new ComboPropriedades("02", "02 - Operação Tributável com Alíquota Diferenciada"));
            dResult.Add(new ComboPropriedades("03", "03 - Operação Tributável com Alíquota por Unidade de Medida de Produto"));
            dResult.Add(new ComboPropriedades("04", "04 - Operação Tributável Monofásica - Revenda a Alíquota Zero"));
            dResult.Add(new ComboPropriedades("05", "05 - Operação Tributável por Substituição Tributária"));
            dResult.Add(new ComboPropriedades("06", "06 - Operação Tributável a Alíquota Zero"));
            dResult.Add(new ComboPropriedades("07", "07 - Operação Isenta da Contribuição"));
            dResult.Add(new ComboPropriedades("08", "08 - Operação sem Incidência da Contribuição"));
            dResult.Add(new ComboPropriedades("08", "09 - Operação com Suspensão da Contribuição"));
            dResult.Add(new ComboPropriedades("49", "49 - Outras Operações de Saída"));
            dResult.Add(new ComboPropriedades("50", "50 - Operação com Direito a Crédito - Vinculada Exclusivamente a Receita Tributada no Mercado Interno"));
            dResult.Add(new ComboPropriedades("51", "51 - Operação com Direito a Crédito - Vinculada Exclusivamente a  Receita Não-Tributada no Mercado Interno"));
            dResult.Add(new ComboPropriedades("52", "52 - Operação com Direito a Crédito - Vinculada Exclusivamente a Receita de Exportação"));
            dResult.Add(new ComboPropriedades("53", "53 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno"));
            dResult.Add(new ComboPropriedades("54", "54 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas no Mercado Interno e de Exportação"));
            dResult.Add(new ComboPropriedades("55", "55 - Operação com Direito a Crédito - Vinculada a Receitas Não Tributadas no Mercado Interno e de Exportação"));
            dResult.Add(new ComboPropriedades("56", "56 - Operação com Direito a Crédito - Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno e de Exportação"));
            dResult.Add(new ComboPropriedades("60", "60 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Tributada no Mercado Interno"));
            dResult.Add(new ComboPropriedades("61", "61 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita Não-Tributada no Mercado Interno"));
            dResult.Add(new ComboPropriedades("62", "62 - Crédito Presumido - Operação de Aquisição Vinculada Exclusivamente a Receita de Exportação"));
            dResult.Add(new ComboPropriedades("63", "63 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno"));
            dResult.Add(new ComboPropriedades("64", "64 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas no Mercado Interno e de Exportação"));
            dResult.Add(new ComboPropriedades("65", "65 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Não-Tributadas no Mercado Interno e de Exportação"));
            dResult.Add(new ComboPropriedades("66", "66 - Crédito Presumido - Operação de Aquisição Vinculada a Receitas Tributadas e Não-Tributadas no Mercado Interno e de Exportação"));
            dResult.Add(new ComboPropriedades("67", "67 - Crédito Presumido - Outras Operações"));
            dResult.Add(new ComboPropriedades("70", "70 - Operação de Aquisição sem Direito a Crédito"));
            dResult.Add(new ComboPropriedades("71", "71 - Operação de Aquisição com Isenção"));
            dResult.Add(new ComboPropriedades("72", "72 - Operação de Aquisição com Suspensão"));
            dResult.Add(new ComboPropriedades("73", "73 - Operação de Aquisição a Alíquota Zero"));
            dResult.Add(new ComboPropriedades("74", "74 - Operação de Aquisição sem Incidência da Contribuição"));
            dResult.Add(new ComboPropriedades("75", "75 - Operação de Aquisição por Substituição Tributária"));
            dResult.Add(new ComboPropriedades("98", "98 - Outras Operações de Entrada"));
            dResult.Add(new ComboPropriedades("99", "99 - Outras Operações"));

            return dResult;
        }
        
        public static List<ComboPropriedades> StatusCompra()
        {
            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            dResult.Add(new ComboPropriedades("", "Selecione"));
            dResult.Add(new ComboPropriedades("Pendente", "Pendente"));
            dResult.Add(new ComboPropriedades("Aprovada", "Aprovada"));
            dResult.Add(new ComboPropriedades("Recebido", "Recebido"));
            dResult.Add(new ComboPropriedades("Finalizada", "Finalizada"));
            dResult.Add(new ComboPropriedades("Cancelada", "Cancelada"));

            return dResult;
        }

        public static List<ComboPropriedades> StatusVenda()
        {
            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            dResult.Add(new ComboPropriedades("", "Selecione"));
            dResult.Add(new ComboPropriedades("Cotacao", "Cotação"));
            dResult.Add(new ComboPropriedades("Pre-Venda", "Pré-Venda"));
            dResult.Add(new ComboPropriedades("Pendente", "Pendente"));
            dResult.Add(new ComboPropriedades("Aprovado", "Aprovado"));            
            dResult.Add(new ComboPropriedades("Em Processamento", "Em Processamento"));
            dResult.Add(new ComboPropriedades("Faturamento", "Faturamento"));
            dResult.Add(new ComboPropriedades("Transporte", "Transporte"));
            dResult.Add(new ComboPropriedades("Concluido", "Concluido"));
            dResult.Add(new ComboPropriedades("Cancelada", "Cancelada"));

            return dResult;
        }
        
        public static List<ComboPropriedades> StatusVendaNovo()
        {
            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            dResult.Add(new ComboPropriedades("", "Selecione"));
            dResult.Add(new ComboPropriedades("Cotacao", "Cotação"));
            dResult.Add(new ComboPropriedades("Pre-Venda", "Pré-Venda"));
            dResult.Add(new ComboPropriedades("Pendente", "Pendente"));

            return dResult;
        }

        public static List<ComboPropriedades> FretePorConta()
        {
            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            dResult.Add(new ComboPropriedades("", "Selecione"));
            dResult.Add(new ComboPropriedades("A retirar", "A retirar"));
            dResult.Add(new ComboPropriedades("Entrega s/ Acréscimo", "Entrega s/ Acréscimo"));
            dResult.Add(new ComboPropriedades("Entrega c/ Frete", "Entrega c/ Frete"));

            return dResult;
        }

        public static List<ComboPropriedades> Municipios(string uf)
        {
            cmsEntities entities = new cmsEntities();

            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            var municipios = (from m in entities.vw_municipio
                              select m).OrderBy(m => m.municipio);

            if (!string.IsNullOrEmpty(uf))
                municipios = municipios.Where(m => m.estado_sigla == uf).OrderBy(m => m.municipio);

            dResult.Add(new ComboPropriedades("", "Selecione"));

            foreach (var m in municipios)
            {
                dResult.Add(new ComboPropriedades(m.municipio_codigo.ToString(), m.municipio));
            }

            return dResult;
        }

        public static List<ComboPropriedades> IbgeUf()
        {
            cmsEntities entities = new cmsEntities();

            List<ComboPropriedades> dResult = new List<ComboPropriedades>();

            var estados = (from m in entities.cep_estado
                              select m).OrderBy(m => m.estado_sigla);

            dResult.Add(new ComboPropriedades("", "Selecione"));

            foreach (var e in estados)
            {
                dResult.Add(new ComboPropriedades(e.estado_codigo_federacao.ToString(), e.estado_sigla));
            }

            return dResult;
        }

        public class Estados
        {
            public Estados()
            { }

            public Estados(string value, string estado)
            {
                Value = value;
                Estado = estado;
            }

            public string Value { get; set; }
            public string Estado { get; set; }
        }

        public class ComboPropriedades
        {
            public ComboPropriedades()
            { }

            public ComboPropriedades(string value, string display)
            {
                Display = display;
                Value = value;
            }

            public string Display { get; set; }
            public string Value { get; set; }
        }

        public class ComboPropriedadesCST
        {
            public ComboPropriedadesCST()
            { }

            public ComboPropriedadesCST(string value, string display)
            {
                Display = display;
                Value = value;
                Tributavel = false;
            }

            public ComboPropriedadesCST(string value, string display, bool tributavel)
            {
                Display = display;
                Value = value;
                Tributavel = tributavel;
            }

            public string Display { get; set; }
            public string Value { get; set; }
            public bool Tributavel { get; set; }
        }
    }

    public static class Cep
    {
        public static cms.Data.cep_endereco GetCepLocal(string txtEndCep)
        {   
            cms.Data.cmsEntities cEntities = new Data.cmsEntities();

            var cep = from e in cEntities.cep_endereco
                      where e.endereco_cep == txtEndCep.Replace("-", "")
                      select e;

            if (cep.Count() > 1)
                return cep.First();

            return cep.SingleOrDefault();
        }

        //public static string GetCodigoIBGE(string cep)
        //{
        //    cms.Data.cmsEntities cEntities = new Data.cmsEntities();

        //    var result = (from e in cEntities.cep_endereco
        //              where e.endereco_cep == cep.Replace("-", "")
        //              select e).First();

        //    if (cep.Count() > 1)
        //        return result.

        //    return cep.SingleOrDefault();
        //}

        public static void BuscaCep(TextBox txtEndCep, TextBox txtEndEndereco, TextBox txtEndNumero, TextBox txtEndComplemento, TextBox txtEndBairro, TextBox txtEndCidade, ComboBox cbEndEstado)
        {
            DataSet dsCep = new DataSet();

            var oCep = GetCepLocal(txtEndCep.Text);

            System.Net.NetworkInformation.Ping ping = new System.Net.NetworkInformation.Ping();

            System.Net.NetworkInformation.PingReply resp = ping.Send("localhost", 1);
            
            try
            {
                resp = ping.Send("cep.republicavirtual.com.br", 10);
            }
            catch
            {   }

            if (oCep != null)
            {
                CrossThreadUI.SetText(txtEndEndereco, oCep.endereco_logradouro);
                CrossThreadUI.SetText(txtEndBairro, oCep.cep_bairro.bairro_descricao);
                CrossThreadUI.SetText(txtEndCidade, oCep.cep_bairro.cep_cidade.cidade_descricao);
                CrossThreadUI.SetPropertyValue(cbEndEstado, "SelectedValue", oCep.cep_bairro.cep_cidade.cep_estado.estado_sigla, null);
            }
            else
            {
                if (resp.Status == System.Net.NetworkInformation.IPStatus.Success)
                {
                    try
                    {
                        dsCep.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + txtEndCep.Text.Replace("-", "").Trim() + "&formato=xml");
                    }
                    catch { }
                }

                if (dsCep != null && dsCep.Tables.Count > 0 && dsCep.Tables[0].Rows.Count > 0)
                {
                    CrossThreadUI.SetText(txtEndEndereco, dsCep.Tables[0].Rows[0]["tipo_logradouro"].ToString() + " " +
                        dsCep.Tables[0].Rows[0]["logradouro"].ToString());
                    CrossThreadUI.SetText(txtEndBairro, dsCep.Tables[0].Rows[0]["bairro"].ToString());
                    CrossThreadUI.SetText(txtEndCidade, dsCep.Tables[0].Rows[0]["cidade"].ToString());                
                    CrossThreadUI.SetPropertyValue(cbEndEstado, "SelectedValue", dsCep.Tables[0].Rows[0]["uf"].ToString(), null);
                }
            }
        }
    }

    public enum Acao
    {
        Editar = 1,
        Cadastrar = 2,
        Visualizar = 3
    }
    
    public enum TipoValidacao
    {
        Obrigatorio = 0,
        CNPJ = 1,
        CPF = 2,
        Email = 3
    }

    public class ValidarCampos
    {
        public ValidarCampos()
        {
        }

        private bool validar = false;
        public bool Validar
        {
            get { return validar; }
            set { validar = value; }
        }

        private string titulo = string.Empty;
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }
                
        private string mensagem = string.Empty;
        public string Mensagem
        {
            get { return mensagem; }
            set { mensagem = value; }
        }

        private TipoValidacao tipo = 0;
        public TipoValidacao Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public  ValidarCampos(bool pValidar, string vTitulo, string vMensagem, TipoValidacao vTipo)
        {
            Validar = pValidar;
            Titulo = vTitulo;
            Mensagem = vMensagem;
            Tipo = vTipo;
        }
    }
    
    public class MyBindingList<T> : BindingList<T>
    {
        #region Searching Support
        protected override bool SupportsSearchingCore
        {
            get
            {
                return true;
            }
        }

        protected override int FindCore(PropertyDescriptor prop, object key)
        {
            // Get the property info for the specified property.
            PropertyInfo propInfo = typeof(T).GetProperty(prop.Name);
            T item;

            if (key != null)
            {
                // Loop through the items to see if the key
                // value matches the property value.
                for (int i = 0; i < Count; ++i)
                {
                    item = (T)Items[i];
                    if (propInfo.GetValue(item, null).Equals(key))
                        return i;
                }
            }
            return -1;
        }

        public int Find(string property, object key)
        {
            // Check the properties for a property with the specified name.
            PropertyDescriptorCollection properties =
                TypeDescriptor.GetProperties(typeof(T));
            PropertyDescriptor prop = properties.Find(property, true);

            // If there is not a match, return -1 otherwise pass search to
            // FindCore method.
            if (prop == null)
                return -1;
            else
                return FindCore(prop, key);
        } 
        #endregion

        #region Sorting support
        bool _isSorted = false;
        ListSortDirection _sortDirectionValue;
        PropertyDescriptor _sortPropertyValue;
        private ArrayList _sortedList;
        private ArrayList _unsortedItems;
        
        protected override bool IsSortedCore
        {
            get
            {
                return _isSorted;
            }
        }
        protected override bool SupportsSortingCore
        {
            get
            {
                return true;
            }
        }

        protected override void ApplySortCore(PropertyDescriptor prop,
            ListSortDirection direction)
        {
            _sortedList = new ArrayList();

            // Check to see if the property type we are sorting by implements
            // the IComparable interface.
            Type interfaceType = prop.PropertyType.GetInterface("IComparable");

            if (interfaceType != null)
            {
                // If so, set the SortPropertyValue and SortDirectionValue.
                _sortPropertyValue = prop;
                _sortDirectionValue = direction;

                _unsortedItems = new ArrayList(this.Count);

                // Loop through each item, adding it the the sortedItems ArrayList.
                foreach (Object item in this.Items)
                {
                    _sortedList.Add(prop.GetValue(item));
                    _unsortedItems.Add(item);
                }
                // Call Sort on the ArrayList.
                _sortedList.Sort();
                T temp;

                // Check the sort direction and then copy the sorted items
                // back into the list.
                if (direction == ListSortDirection.Descending)
                    _sortedList.Reverse();

                for (int i = 0; i < this.Count; i++)
                {
                    int position = Find(prop.Name, _sortedList[i]);
                    if (position != i)
                    {
                        temp = this[i];
                        this[i] = this[position];
                        this[position] = temp;
                    }
                }

                _isSorted = true;

                // Raise the ListChanged event so bound controls refresh their
                // values.
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
            else
                // If the property type does not implement IComparable, let the user
                // know.
                throw new NotSupportedException("Cannot sort by " + prop.Name +
                    ". This" + prop.PropertyType.ToString() +
                    " does not implement IComparable");
        } 
        #endregion

    }

}