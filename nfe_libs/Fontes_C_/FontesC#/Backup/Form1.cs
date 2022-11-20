using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using NFe_Util_PL005a;

namespace DemoNFeUtil
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NFe_Util_PL005a.Util util = new NFe_Util_PL005a.Util();

            MessageBox.Show("A versão em uso é : " + util.Versao());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // declara as variáveis que serão utilizadas na chamada
            //
            // nome do titular do certificado,
            // caso o conteúdo seja omitido, será aberto uma caixa
            // de dialoga para escolha do certificado existente no
            // repositório de certificados do usuário corrente do windows
            // 
            // este nome é utilizado para passar o certificado selecionado nas
            // chamadas dos WS que exigem a indicação de um certificado digital

            string nome = "";
            //
            //  variável utilizada para a devolução da literal do retorno do processamento
            //
            string msgResultado = "";
            //
            // instância classe
            //
            NFe_Util_PL005a.Util util = new NFe_Util_PL005a.Util();
            //
            // chama o método PegaNomeCertificado
            //
            int resultado = util.PegaNomeCertificado(ref nome, out msgResultado);
            MessageBox.Show("Resultado da chamada: \r\r" + resultado.ToString() + " - " + msgResultado + "\r\rNome do titular do certificado selecionado:\r\r" + nome);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //            ConsultaStatusSCAN: Consulta Situação do Web Service de Recepção de NF-e

            //Entradas:

            //          siglaWS: Sigla da WS chamado, informar:
            //                   . sigla da UF para UF com WS próprio (AM, BA, CE, DF, GO, MS, MT, MG, PE, PR, RS, RO e SP)
            //                   . SCAN – Sistema de Contingência do Ambiente Nacional
            //                   . SVRS – SEFAZ Virtual do Rio Grande do Sul (AC, AL, AP, MS*, PB, RJ, RR, SC, SE e TO)
            //                   . SVAN – SEFAZ Virutal do Ambiente Nacional (CE*, ES*, MA, PA, PI, PR* e RN)                     
            //          siglaUF: Sigla da UF consultada
            //     tipoAmbiente: Código do tipo de ambiente = 1-Produção / 2-Homologação
            //nomeCertificado: Nome do titular do certificado a ser utlizado na conexão SSL
            //Ex.: "CN=NFe - Associacao NF-e:99999090910270, C=BR, L=PORTO ALEGRE, O=Teste Projeto NFe RS, OU=Teste Projeto NFe RS, S=RS"

            //proxy ,usuario e senha: deve ser informado nos casos em que é necessário o uso de proxy

            //'https://proxyserver:port';    // verificar com o cliente qual é o endereço do servidor proxy e a porta https, a porta padrão do https é 443, assim teríamos algo do tipo 'http://192.168.15.1:443'

            //Retornos:

            //ConsultaStatusSCAN: código do resultado da chamada do WS
            //                0 - OK
            //                1 - codigo do ambiente inválido
            //                2 - sigla da UF inválida
            //                3 - a UF não oferece o serviço
            //                4 - Arquivo com a URL do WS não localizados
            //                5 - Erro não tratado de abertura/tratamento Arquivo ws.xml
            //                6 - Erro de validação de Schema
            //                7 - Nenhum Certificado Selecionado
            //                8 - Nenhum certificado válido foi encontrado com o nome informado
            //                9 - Erro Inesperado no acesso ao certificado digital: "+ex.Message
            //               10 - Erro: Time-out ao chamar o WS
            //               11 - Erro: exceção do biblioteca criptográfica
            //               12 - Erro: conectividade
            //      msgCabec: XML do cabeçalho enviado ao WS (útil para depuração)
            //      msgDados: XML do pedido de consulta Status enviado ao WS
            //      msgRetWS: XML de resposta do WS
            //msgResultado: literal do resultado da chamada do WS Consulta Status SCAN

            string _siglaWS = "SVAN";
            string _siglaUF = "MA";
            int _tipoAmbiente = 2;
            string _nomeCertificado = ""; // se o valor for omitido,  a aplicação abre uma janela para escolha
            // do certificado existente na repositório de certificados do usuário corrente.
            string _msgCabec = "";
            string _msgDados = "";
            string _retWS = "";
            string _msgResultado = "";
            string _proxy = "";
            string _usuario = "";
            string _senha = "";
            //
            // instância classe
            //
            NFe_Util_PL005a.Util util = new NFe_Util_PL005a.Util();
            //
            // chama o método de Consulta Status
            //
            int resultado = util.ConsultaStatusSCAN(_siglaWS,
                                                     _siglaUF,
                                                     _tipoAmbiente,
                                                     _nomeCertificado,
                                                     out _msgCabec,
                                                     out _msgDados,
                                                     out _retWS,
                                                     out _msgResultado,
                                                     _proxy, _usuario, _senha);
            MessageBox.Show("Resultado da chamada: \r\r" + resultado.ToString() + " - " + _msgResultado + "\r\rXML da resposta do WS:\r\r" + _retWS);
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            if (tbChave.Text == string.Empty)
            {
                MessageBox.Show("Informe o número da Chave!");
            }
            else
            {
                string _siglaWS = "SVAN";
                string _siglaUF = "RS";
                int _tipoAmbiente = 2;
                string _nomeCertificado = null; // se o valor for omitido,  a aplicação abre uma janela para escolha
                // do certificado existente na repositório de certificados do usuário corrente.
                string _chaveNF = tbChave.Text.Trim();
                string _msgCabec = "";
                string _msgDados = "";
                string _retWS = "";
                string _msgResultado = "";
                string _proxy = "";
                string _usuario = "";
                string _senha = "";
                //
                // instância classe
                //
                NFe_Util_PL005a.Util util = new NFe_Util_PL005a.Util();
                //
                // chama o método de Consulta Status
                //

                int resultado = util.ConsultaNFSCAN(_siglaUF,
                                            _tipoAmbiente,
                                            _nomeCertificado,
                                            out _msgCabec,
                                            out _msgDados,
                                            out _retWS,
                                            out _msgResultado,
                                            _chaveNF, _proxy, _usuario, _senha);
                MessageBox.Show("Resultado da chamada: \r\r" + resultado.ToString() + " - " + _msgResultado + "\r\rXML da resposta do WS:\r\r" + _retWS);


            }
        }
    }
}