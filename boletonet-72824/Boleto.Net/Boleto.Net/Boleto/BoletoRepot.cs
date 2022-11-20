using System;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    public class BoletoRepot
    {

        public BoletoRepot()
        {

        }

        #region Atributos

        private double? _Abatimento = null;
        private string _Aceite = string.Empty;
        private int _BancoCodigo = 0;
        private int _BancoDigito = 0;
        private string _BancoNome = string.Empty;
        private string _Carteira = string.Empty;
        private int _Categoria = 0;
        private int _CedenteCodigo = 0;
        private string _CedenteContaBancariaAgencia = string.Empty;
        private string _CedenteContaBancariaConta = string.Empty;
        private string _CedenteContaBancariaDigitoAgencia = string.Empty;
        private string _CedenteContaBancariaDigitoConta = string.Empty;
        private string _CedenteContaBancariaOperacaConta = string.Empty;
        private int _CedenteConvenio = 0;
        private string _CedenteCPFCNPJ = string.Empty;
        private int _CedenteDigitoCedente = 0;
        private string _CedenteNome = string.Empty;
        private string _CodigoBarra = string.Empty;
        private byte[] _CodigoBarraImg;
        private DateTime? _DataDesconto = null;
        private DateTime? _DataDocumento = null;
        private DateTime? _DataJurosMora = null;
        private DateTime? _DataMulta = null;
        private DateTime? _DataOutrosAcrescimos = null;
        private DateTime? _DataOutrosDescontos = null;
        private DateTime? _DataProcessamento = null;
        private DateTime? _DataVencimento = null;
        private string _Especie = string.Empty;
        private string _EspecieDocumento = string.Empty;
        private string _InstrucoesLinha1 = string.Empty;
        private string _InstrucoesLinha2 = string.Empty;
        private string _InstrucoesLinha3 = string.Empty;
        private string _InstrucoesLinha4 = string.Empty;
        private double? _IOF = null;
        private double? _JurosMora = null;
        private string _LocalPagamento = string.Empty;
        private int _Moeda = 0;
        private string _NossoNumero = string.Empty;
        private string _NumeroDocumento = string.Empty;
        private double? _OutrosAcrescimos = null;
        private double? _OutrosDescontos = null;
        private int _QuantidadeMoeda = 0;
        private string _SacadoCPFCNPJ = string.Empty;
        private string _SacadoEnderecoBairro = string.Empty;
        private string _SacadoEnderecoCEP = string.Empty;
        private string _SacadoEnderecoCidade = string.Empty;
        private string _SacadoEnderecoComplemento = string.Empty;
        private string _SacadoEnderecoEmail = string.Empty;
        private string _SacadoEnderecoEnd = string.Empty;
        private string _SacadoEnderecoLogradouro = string.Empty;
        private string _SacadoEnderecoNumero = string.Empty;
        private string _SacadoEnderecoUF = string.Empty;
        private string _SacadoNome = string.Empty;
        private string _TipoModalidade = string.Empty;
        private string _UsoBanco = string.Empty;
        private double? _ValorBoleto = null;
        private double? _ValorDesconto = null;
        private string _ValorMoeda = string.Empty;
        private double? _ValorMulta = null;
        private double? _ValorCobrado = null;
        #endregion
        
        #region Propriedade

        public double? Abatimento { get { return _Abatimento; } set { _Abatimento = value; } }
        public string Aceite { get { return _Aceite; } set { _Aceite = value; } }
        public int BancoCodigo { get { return _BancoCodigo; } set { _BancoCodigo = value; } }
        public int BancoDigito { get { return _BancoDigito; } set { _BancoDigito = value; } }
        public string BancoNome { get { return _BancoNome; } set { _BancoNome = value; } }
        public string Carteira { get { return _Carteira; } set { _Carteira = value; } }
        public int Categoria { get { return _Categoria; } set { _Categoria = value; } }
        public int CedenteCodigo { get { return _CedenteCodigo; } set { _CedenteCodigo = value; } }
        public string CedenteContaBancariaAgencia { get { return _CedenteContaBancariaAgencia; } set { _CedenteContaBancariaAgencia = value; } }
        public string CedenteContaBancariaConta { get { return _CedenteContaBancariaConta; } set { _CedenteContaBancariaConta = value; } }
        public string CedenteContaBancariaDigitoAgencia { get { return _CedenteContaBancariaDigitoAgencia; } set { _CedenteContaBancariaDigitoAgencia = value; } }
        public string CedenteContaBancariaDigitoConta { get { return _CedenteContaBancariaDigitoConta; } set { _CedenteContaBancariaDigitoConta = value; } }
        public string CedenteContaBancariaOperacaConta { get { return _CedenteContaBancariaOperacaConta; } set { _CedenteContaBancariaOperacaConta = value; } }
        public int CedenteConvenio { get { return _CedenteConvenio; } set { _CedenteConvenio = value; } }
        public string CedenteCPFCNPJ { get { return _CedenteCPFCNPJ; } set { _CedenteCPFCNPJ = value; } }
        public int CedenteDigitoCedente { get { return _CedenteDigitoCedente; } set { _CedenteDigitoCedente = value; } }
        public string CedenteNome { get { return _CedenteNome; } set { _CedenteNome = value; } }
        public string CodigoBarra { get { return _CodigoBarra; } set { _CodigoBarra = value; } }
        public byte[] CodigoBarraImg { get { return _CodigoBarraImg; } set { _CodigoBarraImg = value; } }
        public DateTime? DataDesconto { get { return _DataDesconto; } set { _DataDesconto = value; } }
        public DateTime? DataDocumento { get { return _DataDocumento; } set { _DataDocumento = value; } }
        public DateTime? DataJurosMora { get { return _DataJurosMora; } set { _DataJurosMora = value; } }
        public DateTime? DataMulta { get { return _DataMulta; } set { _DataMulta = value; } }
        public DateTime? DataOutrosAcrescimos { get { return _DataOutrosAcrescimos; } set { _DataOutrosAcrescimos = value; } }
        public DateTime? DataOutrosDescontos { get { return _DataOutrosDescontos; } set { _DataOutrosDescontos = value; } }
        public DateTime? DataProcessamento { get { return _DataProcessamento; } set { _DataProcessamento = value; } }
        public DateTime? DataVencimento { get { return _DataVencimento; } set { _DataVencimento = value; } }
        public string Especie { get { return _Especie; } set { _Especie = value; } }
        public string EspecieDocumento { get { return _EspecieDocumento; } set { _EspecieDocumento = value; } }
        public string InstrucoesLinha1 { get { return _InstrucoesLinha1; } set { _InstrucoesLinha1 = value; } }
        public string InstrucoesLinha2 { get { return _InstrucoesLinha2; } set { _InstrucoesLinha2 = value; } }
        public string InstrucoesLinha3 { get { return _InstrucoesLinha3; } set { _InstrucoesLinha3 = value; } }
        public string InstrucoesLinha4 { get { return _InstrucoesLinha4; } set { _InstrucoesLinha4 = value; } }
        public double? IOF { get { return _IOF; } set { _IOF = value; } }
        public double? JurosMora { get { return _JurosMora; } set { _JurosMora = value; } }
        public string LocalPagamento { get { return _LocalPagamento; } set { _LocalPagamento = value; } }
        public int Moeda { get { return _Moeda; } set { _Moeda = value; } }
        public string NossoNumero { get { return _NossoNumero; } set { _NossoNumero = value; } }
        public string NumeroDocumento { get { return _NumeroDocumento; } set { _NumeroDocumento = value; } }
        public double? OutrosAcrescimos { get { return _OutrosAcrescimos; } set { _OutrosAcrescimos = value; } }
        public double? OutrosDescontos { get { return _OutrosDescontos; } set { _OutrosDescontos = value; } }
        public int QuantidadeMoeda { get { return _QuantidadeMoeda; } set { _QuantidadeMoeda = value; } }
        public string SacadoCPFCNPJ { get { return _SacadoCPFCNPJ; } set { _SacadoCPFCNPJ = value; } }
        public string SacadoEnderecoBairro { get { return _SacadoEnderecoBairro; } set { _SacadoEnderecoBairro = value; } }
        public string SacadoEnderecoCEP { get { return _SacadoEnderecoCEP; } set { _SacadoEnderecoCEP = value; } }
        public string SacadoEnderecoCidade { get { return _SacadoEnderecoCidade; } set { _SacadoEnderecoCidade = value; } }
        public string SacadoEnderecoComplemento { get { return _SacadoEnderecoComplemento; } set { _SacadoEnderecoComplemento = value; } }
        public string SacadoEnderecoEmail { get { return _SacadoEnderecoEmail; } set { _SacadoEnderecoEmail = value; } }
        public string SacadoEnderecoEnd { get { return _SacadoEnderecoEnd; } set { _SacadoEnderecoEnd = value; } }
        public string SacadoEnderecoLogradouro { get { return _SacadoEnderecoLogradouro; } set { _SacadoEnderecoLogradouro = value; } }
        public string SacadoEnderecoNumero { get { return _SacadoEnderecoNumero; } set { _SacadoEnderecoNumero = value; } }
        public string SacadoEnderecoUF { get { return _SacadoEnderecoUF; } set { _SacadoEnderecoUF = value; } }
        public string SacadoNome { get { return _SacadoNome; } set { _SacadoNome = value; } }
        public string TipoModalidade { get { return _TipoModalidade; } set { _TipoModalidade = value; } }
        public string UsoBanco { get { return _UsoBanco; } set { _UsoBanco = value; } }
        public double? ValorBoleto { get { return _ValorBoleto; } set { _ValorBoleto = value; } }
        public double? ValorDesconto { get { return _ValorDesconto; } set { _ValorDesconto = value; } }
        public string ValorMoeda { get { return _ValorMoeda; } set { _ValorMoeda = value; } }
        public double? ValorMulta { get { return _ValorMulta; } set { _ValorMulta = value; } }
        public double? ValorCobrado { get { return _ValorCobrado; } set { _ValorCobrado = value; } }
        #endregion
        
        #region Metodos

        public List<BoletoRepot> ToList(List<BoletoBancario> pBoletos)
        {
            List<BoletoRepot> result = new List<BoletoRepot>();

            foreach (BoletoBancario b in pBoletos)
            {
               result.Add(ToBoletoRepot(b));
            }

            return result;
        }

        public List<BoletoRepot> ToList(List<Boleto> pBoletos)
        {
            List<BoletoRepot> result = new List<BoletoRepot>();

            foreach (Boleto b in pBoletos)
            {                
                result.Add(ToBoletoRepot(b));
            }

            return result;
        }

        public BoletoRepot ToBoletoRepot(BoletoBancario pBoleto)
        {
            BoletoRepot result = new BoletoRepot();
            result = ToBoletoRepot(pBoleto.Boleto);
            return result;
        }

        public BoletoRepot ToBoletoRepot(Boleto pBoleto)
        {
                BoletoRepot result = new BoletoRepot();

                result.Abatimento = pBoleto.Abatimento;
                result.Aceite = pBoleto.Aceite;
                result.BancoCodigo = pBoleto.Banco.Codigo;
                result.BancoDigito = pBoleto.Banco.Digito;
                result.BancoNome = pBoleto.Banco.Nome;
                result.Carteira = pBoleto.Carteira;
                result.Categoria = pBoleto.Categoria;
                result.CedenteCodigo = pBoleto.Cedente.Codigo;
                result.CedenteContaBancariaAgencia = pBoleto.Cedente.ContaBancaria.Agencia;
                result.CedenteContaBancariaConta = pBoleto.Cedente.ContaBancaria.Conta;
                result.CedenteContaBancariaDigitoAgencia = pBoleto.Cedente.ContaBancaria.DigitoAgencia;
                result.CedenteContaBancariaDigitoConta = pBoleto.Cedente.ContaBancaria.DigitoConta;
                result.CedenteContaBancariaOperacaConta = pBoleto.Cedente.ContaBancaria.OperacaConta;
                result.CedenteConvenio = pBoleto.Cedente.Convenio;
                result.CedenteCPFCNPJ = pBoleto.Cedente.CPFCNPJ;
                result.CedenteDigitoCedente = pBoleto.Cedente.DigitoCedente;
                result.CedenteNome = pBoleto.Cedente.Nome;
                result.CodigoBarra = pBoleto.CodigoBarra.LinhaDigitavel;
                result.CodigoBarraImg = pBoleto.CodigoBarra.ToArray; 
                result.DataDesconto = pBoleto.DataDesconto;
                result.DataDocumento = pBoleto.DataDocumento;
                result.DataJurosMora = pBoleto.DataJurosMora;
                result.DataMulta = pBoleto.DataMulta;
                result.DataOutrosAcrescimos = pBoleto.DataOutrosAcrescimos;
                result.DataOutrosDescontos = pBoleto.DataOutrosDescontos;
                result.DataProcessamento = pBoleto.DataProcessamento;
                result.DataVencimento = pBoleto.DataVencimento;
                result.Especie = pBoleto.Especie;
                result.EspecieDocumento = pBoleto.EspecieDocumento.Sigla;

                if (pBoleto.Instrucoes.Count >= 1)
                    result.InstrucoesLinha1 = pBoleto.Instrucoes[0].Descricao;
                if (pBoleto.Instrucoes.Count >= 2)
                    result.InstrucoesLinha2 = pBoleto.Instrucoes[1].Descricao;
                if (pBoleto.Instrucoes.Count >= 3)
                    result.InstrucoesLinha3 = pBoleto.Instrucoes[2].Descricao;                
                if (pBoleto.Instrucoes.Count >= 4)
                    result.InstrucoesLinha4 = pBoleto.Instrucoes[3].Descricao;

                result.IOF = pBoleto.IOF;
                result.JurosMora = pBoleto.JurosMora;
                result.LocalPagamento = pBoleto.LocalPagamento;
                result.Moeda = pBoleto.Moeda;
                result.NossoNumero = pBoleto.NossoNumero;
                result.NumeroDocumento = pBoleto.NumeroDocumento;
                result.OutrosAcrescimos = pBoleto.OutrosAcrescimos;
                result.OutrosDescontos = pBoleto.OutrosDescontos;
                result.QuantidadeMoeda = pBoleto.QuantidadeMoeda;
                result.SacadoCPFCNPJ = pBoleto.Sacado.CPFCNPJ;
                result.SacadoEnderecoBairro = pBoleto.Sacado.Endereco.Bairro;
                result.SacadoEnderecoCEP = pBoleto.Sacado.Endereco.CEP;
                result.SacadoEnderecoCidade = pBoleto.Sacado.Endereco.Cidade;
                result.SacadoEnderecoComplemento = pBoleto.Sacado.Endereco.Complemento;
                result.SacadoEnderecoEmail = pBoleto.Sacado.Endereco.Email;
                result.SacadoEnderecoEnd = pBoleto.Sacado.Endereco.End;
                result.SacadoEnderecoLogradouro = pBoleto.Sacado.Endereco.Logradouro;
                result.SacadoEnderecoNumero = pBoleto.Sacado.Endereco.Numero;
                result.SacadoEnderecoUF = pBoleto.Sacado.Endereco.UF;
                result.SacadoNome = pBoleto.Sacado.Nome;
                result.TipoModalidade = pBoleto.TipoModalidade;
                result.UsoBanco = pBoleto.UsoBanco;
                result.ValorBoleto = pBoleto.ValorBoleto;
                result.ValorDesconto = pBoleto.ValorDesconto;
                result.ValorMoeda = pBoleto.ValorMoeda;
                result.ValorMulta = pBoleto.ValorMulta;
                //result.ValorCobrado = pBoleto.Valorc;
            return result;
        }
        
        #endregion

    }
}
