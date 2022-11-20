using System;
using System.IO;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Collections;
using System.ComponentModel;
using RDI.NFe2.SchemaXML;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using System.Web.Services.Protocols;

using System.Net;

using System.Net.Cache;
using System.Runtime.Serialization;
using System.Text;


namespace RDI.NFe2.Business
{
    public static class Servicos
    {

        /// <summary>
        /// carrega o xml do HD
        /// </summary>
        /// <param name="filename">Origem do arquivo xml</param>
        /// <param name="tipoObj">Tipo do objeto que irá receber o xml</param>
        /// <returns></returns>
        public static Object CarregaXML_HD(string filename, Type tipoObj)
        {
            StreamReader SR;
            SR = File.OpenText(filename);
            String _xml = SR.ReadToEnd();
            SR.Close();
            SR.Dispose();
             
            return CarregaXML_STR(_xml, tipoObj);

           
        }

        private static Byte[] StringToUTF8ByteArray(string pXmlString)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] byteArray = encoding.GetBytes(pXmlString);
            return byteArray;
        }

        /// <summary>
        /// carrega o xml de uma string
        /// </summary>
        /// <param name="filename">Origem do arquivo xml</param>
        /// <param name="tipoObj">Tipo do objeto que irá receber o xml</param>
        /// <returns></returns>
        public static Object CarregaXML_STR(string XML, Type tipoObj)
        {
            XmlSerializer xs = new XmlSerializer(tipoObj);
            MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(XML));
            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
            return xs.Deserialize(memoryStream);



           
        }

      
        /// <summary>
        /// salva o xml no HD
        /// </summary>
        /// <param name="filename">Destino do arquivo</param>
        /// <param name="obj">instancia da classe que será salva</param>
        /// <returns></returns>
        public static void SalvaXML(string filename, Object objSomeObject)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("", "http://www.portalfiscal.inf.br/nfe");

            XmlSerializer xs = new XmlSerializer(objSomeObject.GetType());

            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, new System.Text.UTF8Encoding(false));

            xs.Serialize(xmlTextWriter, objSomeObject, xsn);

            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;

            Byte[] characters = memoryStream.ToArray();

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

            StreamWriter oSW = File.CreateText(filename);
            oSW.Write(encoding.GetString(characters));
            oSW.Close();

        }

        /// <summary>
        /// retorna o xml de uma classe em uma string
        /// </summary>
        /// <param name="obj">instancia da classe com o XML</param>
        /// <returns></returns>
        public static String GetXML(Object obj)
        {
            MemoryStream memoryStream = new MemoryStream();
            XmlSerializerNamespaces xsn = new XmlSerializerNamespaces();
            xsn.Add("", "http://www.portalfiscal.inf.br/nfe");

            System.Xml.Serialization.XmlSerializer xs = new System.Xml.Serialization.XmlSerializer(obj.GetType());

            XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, new System.Text.UTF8Encoding(false));

            xs.Serialize(xmlTextWriter, obj, xsn);

            memoryStream = (MemoryStream)xmlTextWriter.BaseStream;

            Byte[] characters = memoryStream.ToArray();

            System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();

            return encoding.GetString(characters);

        }



      



        public static TRetEnviNFe EnviarEnvelope(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico,
            TEnviNFe oEnviNFe, Parametro oParam)
        {
            return (TRetEnviNFe)CarregaXML_STR(ExecutaServico(oServico, oEnviNFe, oParam),
                typeof(TRetEnviNFe));
        }


        public static TRetConsReciNFe ConsultarProcessamentoEnvelope(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico,
            TConsReciNFe oConsReciNFe, Parametro oParam)
        {
            return (TRetConsReciNFe)CarregaXML_STR(ExecutaServico(oServico, oConsReciNFe, oParam),
                typeof(TRetConsReciNFe));
        }


        public static TRetConsStatServ ConsultarStatusServidor(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico,
            TConsStatServ oConsStatServ, Parametro oParam)
        {
            return (TRetConsStatServ)CarregaXML_STR(ExecutaServico(oServico, oConsStatServ, oParam),
                typeof(TRetConsStatServ));
        }


        public static TRetCancNFe CancelarNFe(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico,
            TCancNFe oCancNFe, Parametro oParam)
        {
            return (TRetCancNFe)CarregaXML_STR(ExecutaServico(oServico, oCancNFe, oParam),
                typeof(TRetCancNFe));
        }

        public static TRetInutNFe InutilizarNFe(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico,
            TInutNFe oInutNFe, Parametro oParam)
        {
            return (TRetInutNFe)CarregaXML_STR(ExecutaServico(oServico, oInutNFe, oParam),
                typeof(TRetInutNFe));
        }


        public static TRetConsSitNFe ConsultarProtocoloNFe(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico,
            TConsSitNFe oConsSitNFe, Parametro oParam)
        {
            return (TRetConsSitNFe)CarregaXML_STR(ExecutaServico(oServico, oConsSitNFe, oParam),
                typeof(TRetConsSitNFe));
        }






        private static void InicializaServico(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico, 
            Parametro oParam)
        {

            X509Certificate2 certificadox509 = Certificado.BuscaNome(oParam.certificado, oParam.usaWService);

            oServico.ClientCertificates.Clear();
            oServico.ClientCertificates.Add(certificadox509);
            if (oParam.prx)
            {
                oServico.Proxy = new WebProxy(oParam.prxUrl, true);
                oServico.Proxy.Credentials = new NetworkCredential(oParam.prxUsr, oParam.prxPsw, oParam.prxDmn);
            }
            else
            {
                oServico.Credentials = System.Net.CredentialCache.DefaultCredentials;
            }
            oServico.Timeout =  (int)oParam.timeout;
            oServico.InitializeLifetimeService();

        }


        private static String ExecutaServico(
            System.Web.Services.Protocols.SoapHttpClientProtocol oServico, 
            Object DADOS, Parametro oParam)
        {

            try
            {


                string dados = GetXML(DADOS);
                XmlNode node = null;

                XmlDocument doc = new XmlDocument();
                XmlReader reader = XmlReader.Create(new StringReader(dados));
                reader.MoveToContent();

                node = doc.ReadNode(reader);


                InicializaServico(oServico, oParam);


                if (DADOS.GetType() == typeof(TEnviNFe))
                {
                    XmlNode ret = (XmlNode)oServico.GetType().InvokeMember("nfeRecepcaoLote2",
                                                        System.Reflection.BindingFlags.InvokeMethod,
                                                        null, oServico, new object[] { node });

                    return GetXML(ret);
                }
                else if (DADOS.GetType() == typeof(TConsReciNFe))
                {
                    XmlNode ret = (XmlNode)oServico.GetType().InvokeMember("nfeRetRecepcao2",
                                    System.Reflection.BindingFlags.InvokeMethod,
                                    null, oServico, new object[] { node });

                    return GetXML(ret);
                }
                else if (DADOS.GetType() == typeof(TConsStatServ))
                {
                    XmlNode ret = (XmlNode)oServico.GetType().InvokeMember("nfeStatusServicoNF2",
                                    System.Reflection.BindingFlags.InvokeMethod,
                                    null, oServico, new object[] { node });

                    return GetXML(ret);

                }
                else if (DADOS.GetType() == typeof(TCancNFe))
                {
                    XmlNode ret = (XmlNode)oServico.GetType().InvokeMember("nfeCancelamentoNF2",
                                    System.Reflection.BindingFlags.InvokeMethod,
                                    null, oServico, new object[] { node });

                    return GetXML(ret);
                }
                else if (DADOS.GetType() == typeof(TInutNFe))
                {
                    XmlNode ret = (XmlNode)oServico.GetType().InvokeMember("nfeInutilizacaoNF2",
                                    System.Reflection.BindingFlags.InvokeMethod,
                                    null, oServico, new object[] { node });

                    return GetXML(ret);
                }
                else if (DADOS.GetType() == typeof(TConsSitNFe))
                {
                    XmlNode ret = (XmlNode)oServico.GetType().InvokeMember("nfeConsultaNF2",
                                                        System.Reflection.BindingFlags.InvokeMethod,
                                                        null, oServico, new object[] { node });
                    return GetXML(ret);
                }
                else
                {
                    throw new Exception("Tipo de objeto de envio não mapeado. Consulte o administrador do Sistema.");
                }
            }
            catch (Exception ex)
            {
                String msg = ex.Message;
                if (ex.InnerException != null)
                    msg = ex.InnerException.Message;

                throw new Exception("Erro ao executar Serviço : " + msg);
            }

        }
    }

   

}
