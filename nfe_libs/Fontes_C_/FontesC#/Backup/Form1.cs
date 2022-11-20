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

            MessageBox.Show("A vers�o em uso � : " + util.Versao());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // declara as vari�veis que ser�o utilizadas na chamada
            //
            // nome do titular do certificado,
            // caso o conte�do seja omitido, ser� aberto uma caixa
            // de dialoga para escolha do certificado existente no
            // reposit�rio de certificados do usu�rio corrente do windows
            // 
            // este nome � utilizado para passar o certificado selecionado nas
            // chamadas dos WS que exigem a indica��o de um certificado digital

            string nome = "";
            //
            //  vari�vel utilizada para a devolu��o da literal do retorno do processamento
            //
            string msgResultado = "";
            //
            // inst�ncia classe
            //
            NFe_Util_PL005a.Util util = new NFe_Util_PL005a.Util();
            //
            // chama o m�todo PegaNomeCertificado
            //
            int resultado = util.PegaNomeCertificado(ref nome, out msgResultado);
            MessageBox.Show("Resultado da chamada: \r\r" + resultado.ToString() + " - " + msgResultado + "\r\rNome do titular do certificado selecionado:\r\r" + nome);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //            ConsultaStatusSCAN: Consulta Situa��o do Web Service de Recep��o de NF-e

            //Entradas:

            //          siglaWS: Sigla da WS chamado, informar:
            //                   . sigla da UF para UF com WS pr�prio (AM, BA, CE, DF, GO, MS, MT, MG, PE, PR, RS, RO e SP)
            //                   . SCAN � Sistema de Conting�ncia do Ambiente Nacional
            //                   . SVRS � SEFAZ Virtual do Rio Grande do Sul (AC, AL, AP, MS*, PB, RJ, RR, SC, SE e TO)
            //                   . SVAN � SEFAZ Virutal do Ambiente Nacional (CE*, ES*, MA, PA, PI, PR* e RN)                     
            //          siglaUF: Sigla da UF consultada
            //     tipoAmbiente: C�digo do tipo de ambiente = 1-Produ��o / 2-Homologa��o
            //nomeCertificado: Nome do titular do certificado a ser utlizado na conex�o SSL
            //Ex.: "CN=NFe - Associacao NF-e:99999090910270, C=BR, L=PORTO ALEGRE, O=Teste Projeto NFe RS, OU=Teste Projeto NFe RS, S=RS"

            //proxy ,usuario e senha: deve ser informado nos casos em que � necess�rio o uso de proxy

            //'https://proxyserver:port';    // verificar com o cliente qual � o endere�o do servidor proxy e a porta https, a porta padr�o do https � 443, assim ter�amos algo do tipo 'http://192.168.15.1:443'

            //Retornos:

            //ConsultaStatusSCAN: c�digo do resultado da chamada do WS
            //                0 - OK
            //                1 - codigo do ambiente inv�lido
            //                2 - sigla da UF inv�lida
            //                3 - a UF n�o oferece o servi�o
            //                4 - Arquivo com a URL do WS n�o localizados
            //                5 - Erro n�o tratado de abertura/tratamento Arquivo ws.xml
            //                6 - Erro de valida��o de Schema
            //                7 - Nenhum Certificado Selecionado
            //                8 - Nenhum certificado v�lido foi encontrado com o nome informado
            //                9 - Erro Inesperado no acesso ao certificado digital: "+ex.Message
            //               10 - Erro: Time-out ao chamar o WS
            //               11 - Erro: exce��o do biblioteca criptogr�fica
            //               12 - Erro: conectividade
            //      msgCabec: XML do cabe�alho enviado ao WS (�til para depura��o)
            //      msgDados: XML do pedido de consulta Status enviado ao WS
            //      msgRetWS: XML de resposta do WS
            //msgResultado: literal do resultado da chamada do WS Consulta Status SCAN

            string _siglaWS = "SVAN";
            string _siglaUF = "MA";
            int _tipoAmbiente = 2;
            string _nomeCertificado = ""; // se o valor for omitido,  a aplica��o abre uma janela para escolha
            // do certificado existente na reposit�rio de certificados do usu�rio corrente.
            string _msgCabec = "";
            string _msgDados = "";
            string _retWS = "";
            string _msgResultado = "";
            string _proxy = "";
            string _usuario = "";
            string _senha = "";
            //
            // inst�ncia classe
            //
            NFe_Util_PL005a.Util util = new NFe_Util_PL005a.Util();
            //
            // chama o m�todo de Consulta Status
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
                MessageBox.Show("Informe o n�mero da Chave!");
            }
            else
            {
                string _siglaWS = "SVAN";
                string _siglaUF = "RS";
                int _tipoAmbiente = 2;
                string _nomeCertificado = null; // se o valor for omitido,  a aplica��o abre uma janela para escolha
                // do certificado existente na reposit�rio de certificados do usu�rio corrente.
                string _chaveNF = tbChave.Text.Trim();
                string _msgCabec = "";
                string _msgDados = "";
                string _retWS = "";
                string _msgResultado = "";
                string _proxy = "";
                string _usuario = "";
                string _senha = "";
                //
                // inst�ncia classe
                //
                NFe_Util_PL005a.Util util = new NFe_Util_PL005a.Util();
                //
                // chama o m�todo de Consulta Status
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