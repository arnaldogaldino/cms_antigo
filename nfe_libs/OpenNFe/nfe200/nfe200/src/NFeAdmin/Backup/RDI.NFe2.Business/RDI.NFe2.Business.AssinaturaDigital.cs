using System;
using System.IO;
using System.Data;
using System.Configuration;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;


namespace RDI.NFe2.Business
{
    //Classe que realiza a assinatura Digital
    public class AssinaturaDigital
    {
        
        public int Assinar(string XMLString, string RefUri, X509Certificate2 _X509Cert)
        /*
        * Entradas:
        * XMLString: string XML a ser assinada
        * RefUri : Referência da URI a ser assinada ( infNFe, Cancelamento e inutilzacao)
        * X509Cert : certificado digital a ser utilizado na assinatura digital
        *
        * Retornos:
        * Assinar : 0 - Assinatura realizada com sucesso
        * 1 - Erro: Problema ao acessar o certificado digital - %exceção%
        extinto* 2 - Problemas no certificado digital
        * 3 - XML mal formado + exceção
        * 4 - A tag de assinatura %RefUri% inexiste
        * 5 - A tag de assinatura %RefUri% não é unica
        * 6 - Erro Ao assinar o documento - ID deve ser string %RefUri(Atributo)%
        * 7 - Erro: Ao assinar o documento - %exceção%
        *
        * XMLStringAssinado : string XML assinada
        *
        * XMLDocAssinado : XMLDocument do XML assinado
        */
        {
            int resultado = 0;
            msgResultado = "Assinatura realizada com sucesso";
            try
            {
                
                
               
                    // certificado ok
                    //_X509Cert = collection1[0];
                    
                    // Cria um novo XML.
                    XmlDocument doc = new XmlDocument();
                    //XmlDocument doc2 = new XmlDocument();
                    //doc.PreserveWhitespace = false;
                    // carrega o conteudo XML passado
                    try
                    {
                        doc.LoadXml(XMLString);
                        // Verifica se a tag a ser assinada existe é única
                        int qtdeRefUri = doc.GetElementsByTagName(RefUri).Count;
                        if (qtdeRefUri == 0)
                        {
                            // a URI indicada não existe
                            resultado = 4;
                            msgResultado = "A tag de assinatura " + RefUri.Trim() + " inexiste";
                        }
                        // Exsiste mais de uma tag a ser assinada
                        else
                        {
                            if (qtdeRefUri > 1)
                            {
                                // existe mais de uma URI indicada
                                resultado = 5;
                                msgResultado = "A tag de assinatura " + RefUri.Trim() + " não é unica";
                            }
                            //else if (_listaNum.IndexOf(doc.GetElementsByTagName(RefUri).Item(0).Attributes.ToString().Substring(1,1))>0)
                            //{
                            // resultado = 6;
                            // msgResultado = "Erro: Ao assinar o documento - ID deve ser string (" + doc.GetElementsByTagName(RefUri).Item(0).Attributes + ")";
                            //}
                            else
                            {
                                try
                                {
                                    // cria um objeto xml assinado
                                    SignedXml signedXml = new SignedXml(doc);
                                    // adiciona a chave do certificado
                                    signedXml.SigningKey = _X509Cert.PrivateKey;
                                    // Cria a referencia para assinatura
                                    Reference reference = new Reference();
                                    // pega o uri que deve ser assinada
                                    XmlAttributeCollection _Uri = doc.GetElementsByTagName(RefUri).Item(0).Attributes;
                                    foreach (XmlAttribute _atributo in _Uri)
                                    {
                                        if (_atributo.Name == "Id")
                                        {
                                            reference.Uri = "#" + _atributo.InnerText;
                                        }
                                    }
                                    // adiciona um XmlDsigEnvelopedSignatureTransform para a assinatura
                                    XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                                    reference.AddTransform(env);
                                    XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                                    reference.AddTransform(c14);
                                    // adiciona a referencia no xml assinado
                                    signedXml.AddReference(reference);
                                    // Cria a chave
                                    KeyInfo keyInfo = new KeyInfo();
                                    // carrega o certificado em um keyinfox509
                                    // e adiciona ao keyinfo
                                    keyInfo.AddClause(new KeyInfoX509Data(_X509Cert));
                                    // adiciona o keyinfo ao xml assinado
                                    signedXml.KeyInfo = keyInfo;
                                    signedXml.ComputeSignature();
                                    // busca a representacao XML da assinatura e salva no XML
                                    XmlElement xmlDigitalSignature = signedXml.GetXml();
                                    // adiciona a assinatura no documento
                                    doc.DocumentElement.AppendChild(doc.ImportNode(xmlDigitalSignature, true));
                                    //salva o documento assinado
                                    XMLDoc = new XmlDocument();
                                    //XMLDoc.PreserveWhitespace = false;
                                    XMLDoc = doc;
                                }
                                catch (Exception caught)
                                {
                                    resultado = 7;
                                    msgResultado = "Erro: Ao assinar o documento - " + caught.Message;
                                }
                            }
                        }
                    }
                    catch (Exception caught)
                    {
                        resultado = 3;
                        msgResultado = "Erro: XML mal formado - " + caught.Message;
                    }
                
            }
            catch (Exception caught)
            {
                resultado = 1;
                msgResultado = "Erro: Problema ao acessar o certificado digital" + caught.Message;
            }
            return resultado;
        }
        //
        // mensagem de Retorno
        //
        private string msgResultado;
        private XmlDocument XMLDoc;

        public XmlDocument XMLDocAssinado
        {
            get { return XMLDoc; }
        }

        public string XMLStringAssinado
        {
            get { return XMLDoc.OuterXml; }
        }

        public string mensagemResultado
        {
            get { return msgResultado; }
        }
    }
}