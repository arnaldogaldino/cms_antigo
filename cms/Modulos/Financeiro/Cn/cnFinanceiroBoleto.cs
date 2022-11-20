using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using BoletoNet;
using cms.Data;

namespace cms.Modulos.Financeiro.Cn
{
    public class cnFinanceiroBoleto
    {
        private cmsEntities dbEntities = new cmsEntities();
        private DateTime data_atual = new DateTime();

        public cnFinanceiroBoleto()
        {
            data_atual = Util.Util.GetDataServidor();
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public BoletoNet.Boleto ToBoleto(financeiro_conta_receber conta_receber)
        {
            var contaExist = GetBoletoByIdContaReceber(conta_receber.id_financeiro_conta_receber);
            if (contaExist != null)
                return ToBoleto(contaExist);

            int nossoNumero = Convert.ToInt32(cms.Modulos.Util.Util.sp_getcodigo(Referencia.financeiro_boleto));

            BoletoNet.Cedente cedente = new Cedente(conta_receber.financeiro_conta_corrente.boleto_cnpj, conta_receber.financeiro_conta_corrente.boleto_razao_social, conta_receber.financeiro_conta_corrente.agencia, conta_receber.financeiro_conta_corrente.agencia_digito, conta_receber.financeiro_conta_corrente.conta,conta_receber.financeiro_conta_corrente.conta_digito);

            BoletoNet.Boleto boleto = new BoletoNet.Boleto(conta_receber.data_vencimento, Convert.ToDouble(conta_receber.valor_vencimento), conta_receber.financeiro_conta_corrente.boleto_carteira, nossoNumero.ToString(), cedente, new EspecieDocumento(conta_receber.financeiro_conta_corrente.financeiro_banco.codigo));
            boleto.NumeroDocumento = conta_receber.id_financeiro_conta_receber.ToString();

            boleto.Sacado = new Sacado(conta_receber.cliente.cnpj, conta_receber.cliente.razao_social);
            if(string.IsNullOrEmpty(conta_receber.cliente.cob_cep))
            {
                boleto.Sacado.Endereco.End = conta_receber.cliente.end_endereco + " " + conta_receber.cliente.end_numero + " " + conta_receber.cliente.end_complemento;
                boleto.Sacado.Endereco.Bairro = conta_receber.cliente.end_bairro;
                boleto.Sacado.Endereco.Cidade = conta_receber.cliente.end_cidade;
                boleto.Sacado.Endereco.CEP = conta_receber.cliente.end_cep;
                boleto.Sacado.Endereco.UF = conta_receber.cliente.end_estado;
            }
            else
            {
                boleto.Sacado.Endereco.End = conta_receber.cliente.cob_endereco + " " + conta_receber.cliente.cob_numero + " " + conta_receber.cliente.cob_complemento;
                boleto.Sacado.Endereco.Bairro = conta_receber.cliente.cob_bairro;
                boleto.Sacado.Endereco.Cidade = conta_receber.cliente.cob_cidade;
                boleto.Sacado.Endereco.CEP = conta_receber.cliente.cob_cep;
                boleto.Sacado.Endereco.UF = conta_receber.cliente.cob_estado;
            }

            if (!string.IsNullOrEmpty(conta_receber.financeiro_conta_corrente.boleto_instrucao1))
            {
                Instrucao instrucao1 = new Instrucao(conta_receber.financeiro_conta_corrente.financeiro_banco.codigo);
                instrucao1.Descricao = conta_receber.financeiro_conta_corrente.boleto_instrucao1;
                boleto.Instrucoes.Add(instrucao1);
            }

            if (!string.IsNullOrEmpty(conta_receber.financeiro_conta_corrente.boleto_instrucao2))
            {
                Instrucao instrucao2 = new Instrucao(conta_receber.financeiro_conta_corrente.financeiro_banco.codigo);
                instrucao2.Descricao = conta_receber.financeiro_conta_corrente.boleto_instrucao2;
                boleto.Instrucoes.Add(instrucao2);
            }

            if (!string.IsNullOrEmpty(conta_receber.financeiro_conta_corrente.boleto_instrucao3))
            {
                Instrucao instrucao3 = new Instrucao(conta_receber.financeiro_conta_corrente.financeiro_banco.codigo);
                instrucao3.Descricao = conta_receber.financeiro_conta_corrente.boleto_instrucao3;
                boleto.Instrucoes.Add(instrucao3);
            }

            boleto.Banco = new Banco(conta_receber.financeiro_conta_corrente.financeiro_banco.codigo);
            
            try
            {
                boleto.Valida();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return boleto;
        }

        public BoletoNet.Boleto ToBoleto(financeiro_boleto conta_boleto)
        {
            string nossoNumero = conta_boleto.id_financeiro_conta_receber.ToString();

            BoletoNet.Cedente cedente = new Cedente(conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.boleto_cnpj, conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.boleto_razao_social, conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.agencia, conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.agencia_digito, conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.conta, conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.conta_digito);

            BoletoNet.Boleto boleto = new BoletoNet.Boleto(conta_boleto.financeiro_conta_receber.data_vencimento, Convert.ToDouble(conta_boleto.financeiro_conta_receber.valor_vencimento), conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.boleto_carteira, nossoNumero.ToString(), cedente, new EspecieDocumento(conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.financeiro_banco.codigo, 1));
            boleto.NumeroDocumento = conta_boleto.id_financeiro_conta_receber.ToString();

            boleto.Sacado = new Sacado(conta_boleto.financeiro_conta_receber.cliente.cnpj, conta_boleto.financeiro_conta_receber.cliente.razao_social);
            if (string.IsNullOrEmpty(conta_boleto.financeiro_conta_receber.cliente.cob_cep))
            {
                boleto.Sacado.Endereco.End = conta_boleto.financeiro_conta_receber.cliente.end_endereco + " " + conta_boleto.financeiro_conta_receber.cliente.end_numero + " " + conta_boleto.financeiro_conta_receber.cliente.end_complemento;
                boleto.Sacado.Endereco.Bairro = conta_boleto.financeiro_conta_receber.cliente.end_bairro;
                boleto.Sacado.Endereco.Cidade = conta_boleto.financeiro_conta_receber.cliente.end_cidade;
                boleto.Sacado.Endereco.CEP = conta_boleto.financeiro_conta_receber.cliente.end_cep;
                boleto.Sacado.Endereco.UF = conta_boleto.financeiro_conta_receber.cliente.end_estado;
            }
            else
            {
                boleto.Sacado.Endereco.End = conta_boleto.financeiro_conta_receber.cliente.cob_endereco + " " + conta_boleto.financeiro_conta_receber.cliente.cob_numero + " " + conta_boleto.financeiro_conta_receber.cliente.cob_complemento;
                boleto.Sacado.Endereco.Bairro = conta_boleto.financeiro_conta_receber.cliente.cob_bairro;
                boleto.Sacado.Endereco.Cidade = conta_boleto.financeiro_conta_receber.cliente.cob_cidade;
                boleto.Sacado.Endereco.CEP = conta_boleto.financeiro_conta_receber.cliente.cob_cep;
                boleto.Sacado.Endereco.UF = conta_boleto.financeiro_conta_receber.cliente.cob_estado;
            }

            if (!string.IsNullOrEmpty(conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.boleto_instrucao1))
            {
                Instrucao instrucao1 = new Instrucao(conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.financeiro_banco.codigo);
                instrucao1.Descricao = conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.boleto_instrucao1;
                boleto.Instrucoes.Add(instrucao1);
            }

            if (!string.IsNullOrEmpty(conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.boleto_instrucao2))
            {
                Instrucao instrucao2 = new Instrucao(conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.financeiro_banco.codigo);
                instrucao2.Descricao = conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.boleto_instrucao2;
                boleto.Instrucoes.Add(instrucao2);
            }

            if (!string.IsNullOrEmpty(conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.boleto_instrucao3))
            {
                Instrucao instrucao3 = new Instrucao(conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.financeiro_banco.codigo);
                instrucao3.Descricao = conta_boleto.financeiro_conta_receber.financeiro_conta_corrente.boleto_instrucao3;
                boleto.Instrucoes.Add(instrucao3);
            }

            boleto.Banco = boleto.Instrucoes[0].Banco;

            boleto.Valida();

            return boleto;
        }

        public financeiro_boleto GetBoletoByIdContaReceber(long id_conta_receber)
        {
            financeiro_boleto boleto = new financeiro_boleto();
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_boleto);

            boleto = (from b in dbEntities.financeiro_boleto
                      where b.id_financeiro_conta_receber == id_conta_receber
                      select b).SingleOrDefault();

            return boleto;
        }

        public void GravarBoleto(BoletoNet.Boleto boletoNet, financeiro_conta_receber conta_receber)
        {
            BoletoRepot br = new BoletoRepot();
            var b = br.ToBoletoRepot(boletoNet);
            bool update = false;

            financeiro_boleto boleto = new financeiro_boleto();

            boleto = GetBoletoByIdContaReceber(conta_receber.id_financeiro_conta_receber);

            if (boleto == null)
            {
                boleto = new financeiro_boleto();
                boleto.id_financeiro_boleto = Convert.ToInt32(b.NumeroDocumento);
                boleto.id_boleto = Convert.ToInt32(b.NumeroDocumento);
                boleto.nosso_numero = b.NossoNumero;
                boleto.numero_documento = b.NumeroDocumento;
                boleto.data_processamento = (b.DataProcessamento == DateTime.MinValue ? null : b.DataProcessamento);
                boleto.data_documento = (b.DataDocumento == DateTime.MinValue ? null : b.DataDocumento);
            }
            else update = true;

            boleto.id_cliente = conta_receber.id_cliente;
            boleto.id_financeiro_conta_corrente = Convert.ToInt64(conta_receber.id_financeiro_conta_corrente);
            boleto.id_financeiro_conta_receber = conta_receber.id_financeiro_conta_receber;

            boleto.abatimento = Convert.ToDecimal(b.Abatimento);
            boleto.aceite = b.Aceite;
            boleto.banco_codigo = b.BancoCodigo;
            boleto.banco_digito = b.BancoDigito;
            boleto.banco_nome = b.BancoNome;
            boleto.carteira = b.Carteira;
            boleto.categoria = b.Categoria;
            boleto.cedente_codigo = b.CedenteCodigo;
            boleto.cedente_conta_bancaria_agencia = b.CedenteContaBancariaAgencia;
            boleto.cedente_conta_bancaria_conta = b.CedenteContaBancariaConta;
            boleto.cedente_conta_bancaria_digito_agencia = b.CedenteContaBancariaDigitoAgencia;
            boleto.cedente_conta_bancaria_digito_conta = b.CedenteContaBancariaDigitoConta;
            boleto.cedente_conta_bancaria_operaca_conta = b.CedenteContaBancariaOperacaConta;
            boleto.cedente_convenio = b.CedenteConvenio;
            boleto.cedente_cpf_cnpj = b.CedenteCPFCNPJ;
            boleto.cedente_digito_cedente = b.CedenteDigitoCedente;
            boleto.cedente_nome = b.CedenteNome;
            boleto.codigo_barra = b.CodigoBarra;
            boleto.codigo_barra_img = b.CodigoBarraImg;

            boleto.data_desconto = (b.DataDesconto == DateTime.MinValue ? null : b.DataDesconto);
            boleto.data_juros_mora = (b.DataJurosMora == DateTime.MinValue ? null : b.DataJurosMora);
            boleto.data_multa = (b.DataMulta == DateTime.MinValue ? null : b.DataMulta);
            boleto.data_outros_acrescimos = (b.DataOutrosAcrescimos == DateTime.MinValue ? null : b.DataOutrosAcrescimos);
            boleto.data_outros_descontos = (b.DataOutrosDescontos == DateTime.MinValue ? null : b.DataOutrosDescontos);
            boleto.data_vencimento = (b.DataVencimento == DateTime.MinValue ? null : b.DataVencimento);

            boleto.especie = b.Especie;
            boleto.especie_documento = b.EspecieDocumento;

            boleto.instrucoes_linha1 = b.InstrucoesLinha1;
            boleto.instrucoes_linha2 = b.InstrucoesLinha2;
            boleto.instrucoes_linha3 = b.InstrucoesLinha3;
            boleto.instrucoes_linha4 = b.InstrucoesLinha4;

            boleto.iof = Convert.ToDecimal(b.IOF);
            boleto.juros_mora = Convert.ToDecimal(b.JurosMora);
            boleto.local_pagamento = b.LocalPagamento;
            boleto.moeda = b.Moeda;

            boleto.outros_acrescimos = Convert.ToDecimal(b.OutrosAcrescimos);
            boleto.outros_descontos = Convert.ToDecimal(b.OutrosDescontos);
            boleto.quantidade_moeda = Convert.ToString(b.QuantidadeMoeda);
            boleto.sacado_cpfcnpj = b.SacadoCPFCNPJ;
            boleto.sacado_endereco_bairro = b.SacadoEnderecoBairro;
            boleto.sacado_endereco_cep = b.SacadoEnderecoCEP;
            boleto.sacado_endereco_cidade = b.SacadoEnderecoCidade;
            boleto.sacado_endereco_complemento = b.SacadoEnderecoComplemento;
            boleto.sacado_endereco_email = b.SacadoEnderecoEmail;

            boleto.sacado_endereco_end = b.SacadoEnderecoEnd;
            boleto.sacado_endereco_logradouro = b.SacadoEnderecoLogradouro;
            boleto.sacado_endereco_numero = b.SacadoEnderecoNumero;
            boleto.sacado_endereco_uf = b.SacadoEnderecoUF;
            boleto.sacado_nome = b.SacadoNome;
            boleto.tipo_modalidade = b.TipoModalidade;

            boleto.uso_banco = b.UsoBanco;
            boleto.valor_boleto = Convert.ToDecimal(b.ValorBoleto);
            boleto.valor_cobrado = Convert.ToDecimal(b.ValorCobrado);
            boleto.valor_desconto = Convert.ToDecimal(b.ValorDesconto);
            boleto.valor_moeda = b.ValorMoeda;
            boleto.valor_multa = Convert.ToDecimal(b.ValorMulta);
            boleto.id_empresa = conta_receber.id_empresa;

            if (!update)
                dbEntities.AddTofinanceiro_boleto(boleto);
            else
                dbEntities.financeiro_boleto.ApplyCurrentValues(boleto);

            dbEntities.SaveChanges();
        }

        public IQueryable<vw_financeiro_boleto> FinanceiroBoletoProcurar(string nosso_numero, long? id_empresa, long? id_cliente, long? id_conta_corrente, string documento, DateTime? data_vencimento_de, DateTime? data_vencimento_ate, DateTime? data_pagamento_de, DateTime? data_pagamento_ate)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_financeiro_boleto);
            IQueryable<vw_financeiro_boleto> result = from b in dbEntities.vw_financeiro_boleto
                                                      select b;

            if(!string.IsNullOrEmpty(nosso_numero))
                result = result.Where(e => e.nosso_numero == nosso_numero);

            if (id_cliente != null)
                result = result.Where(e => e.id_cliente == id_cliente);

            if (id_empresa != null)
                result = result.Where(e => e.id_empresa == id_empresa);

            if (id_conta_corrente != null)
                result = result.Where(e => e.id_financeiro_conta_corrente == id_conta_corrente);

            if(!string.IsNullOrEmpty(documento))
                result = result.Where(e => e.numero_documento == documento);

            if (data_vencimento_de != null)
            {
                DateTime data_de = Convert.ToDateTime(data_vencimento_de.Value.ToString("dd/MM/yyyy"));
                result = result.Where(c => c.data_vencimento >= data_de);
            }
            if (data_vencimento_ate != null)
            {
                DateTime data_ate = Convert.ToDateTime(data_vencimento_ate.Value.ToString("dd/MM/yyyy"));
                result = result.Where(c => c.data_vencimento <= data_ate);
            }

            if (data_pagamento_de != null)
            {
                DateTime data_de = Convert.ToDateTime(data_pagamento_de.Value.ToString("dd/MM/yyyy"));
                result = result.Where(c => c.data_pagamento >= data_de);
            }
            if (data_pagamento_ate != null)
            {
                DateTime data_ate = Convert.ToDateTime(data_vencimento_ate.Value.ToString("dd/MM/yyyy"));
                result = result.Where(c => c.data_pagamento <= data_ate);
            }

            return result;
        }
    }
}
