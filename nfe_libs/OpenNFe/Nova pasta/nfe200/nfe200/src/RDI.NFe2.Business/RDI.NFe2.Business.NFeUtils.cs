using System;
using System.IO;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using System.Xml.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Collections.Generic;
using System.Xml.Serialization;
using RDI.NFe2.SchemaXML;

namespace RDI.NFe2.Business
{
    public static class NFeUtils 
    {

        public static TCodUfIBGE DefineUF(String UF)
        {
            try
            {
                return (TCodUfIBGE)Enum.Parse(typeof(TCodUfIBGE), UF);
            }
            catch
            {
                throw new Exception("UF inválida");
            }
        }

        public static Enum DefineEnum(String value, Type EnumType)
        {
            foreach (FieldInfo field in EnumType.GetFields())
            {
                foreach (XmlEnumAttribute atr in field.GetCustomAttributes(typeof(XmlEnumAttribute), false))
                    if (atr.Name == value)
                        return (Enum)field.GetValue(atr);
            }
            throw new Exception("Item inexistente na listagem do tipo enumerado.");
        }


        //Função para cálculo de dígito verificador base 11 com resultado alfanumérico
        private static String DvBase11(String Numero)
        {
            try
            {

                Int32 Dv, Multiplicador;
                Multiplicador = 2;
                Dv = 0;
                for (Int32 I = Numero.Length - 1; I >= 0; I--)
                {
                    Dv += (Int32.Parse(Numero[I].ToString()) * Multiplicador);
                    Multiplicador++;
                    if (Multiplicador > 9)
                        Multiplicador = 2;
                }
                Dv = Dv % 11;
                if (Dv > 1)
                    return (11 - Dv).ToString();
                else
                    return "0";
            }
            catch (Exception ex)
            {
                throw new Exception("Erro na geração da chave de acesso." + ex.Message);
            }


        }

        public static int AssinaXML(String arqxml, String SUri, X509Certificate2 cert)
        {
            string _stringXml;
            string newArqXml;
            Type oType = null;

            if (SUri == "infNFe")
            {
                oType = typeof(SchemaXML.TNFe);
                newArqXml = arqxml.Substring(0, arqxml.Length - 51) + "ass" + arqxml.Substring(arqxml.Length - 51, 51);
            }
            else if (SUri == "infCanc")
            {
                oType = typeof(SchemaXML.TCancNFe);
                newArqXml = arqxml.Substring(0, arqxml.Length - 7) + "-ped-can.xml";
            }
            else if (SUri == "infInut")
            {
                oType = typeof(SchemaXML.TInutNFe);
                newArqXml = arqxml.Substring(0, arqxml.Length - 7) + "-ped-inu.xml";
            }
            else
            {
                return 4; //erro refURi
            }


            //Verifica se arquivo da nota Existe;
            if (File.Exists(arqxml))
            {
                #region carregar arquivo a ser assinado
                _stringXml = Servicos.GetXML(Servicos.CarregaXML_HD(arqxml, oType));
                
                #endregion

                // realiza assinatura
                AssinaturaDigital AD = new AssinaturaDigital();
                int resultado = AD.Assinar(_stringXml, SUri, cert);

                //limpar certificado
                cert.Reset();

                //assinatura bem sucedida
                if (resultado == 0)
                {
                    if (File.Exists(newArqXml))
                        File.Delete(newArqXml);

                    Servicos.SalvaXML(newArqXml, (Servicos.CarregaXML_STR(AD.XMLStringAssinado, oType)));

                    
                }

                return resultado; //Retorna o resultado da assinatura
            }
            else
                return 11;//Arquivo nao encontrado
        }

        private static string GetAmbWebService(Parametro oParam)
        {
            String ambiente = "";

            //[HWS|PWS].
            if (oParam.tipoAmbiente == RDI.NFe2.SchemaXML.TAmb.Homologacao)
                ambiente = "HWS.";
            else if (oParam.tipoAmbiente == RDI.NFe2.SchemaXML.TAmb.Producao)
                ambiente = "PWS.";
            else
                throw new Exception("Tipo de Ambiente não definido.");

            if (oParam.tipoEmissao == RDI.NFe2.SchemaXML.TNFeInfNFeIdeTpEmis.ContigenciaSCAN)
            {
                ambiente += "SCAN";
            }
            else
            {
                //[AtendidoPor]oParam.UF.GetType().GetField(oParam.UF.ToString()).GetCustomAttributes(typeof(
                foreach (Atributo.AtendidoPor atr in oParam.UF.GetType().GetField(oParam.UF.ToString()).GetCustomAttributes(typeof(Atributo.AtendidoPor), false))
                {
                    if (String.IsNullOrEmpty(atr.value))
                        throw new Exception("UF não esta sendo atendida por nenhum WebService.");

                    ambiente += atr.value;
                }
            }
            return ambiente;

        }

        public static System.Web.Services.Protocols.SoapHttpClientProtocol SetWebService(
            Parametro oParam,
            String nomeTipoServico, 
            String nomeClasse)
        {

            //[HWS|PWS].[AtendidoPor].Status.NfeStatusServico2
            String ClassName = oParam.GetType().Namespace + "." + GetAmbWebService(oParam) + "." + nomeTipoServico + ".";
            String headerClassName = ClassName + "nfeCabecMsg";
            ClassName += nomeClasse;

            //todo : reavaliar o nome da dll
            //Assembly business = Assembly.LoadFile(AppDomain.CurrentDomain.BaseDirectory + "\\" + oParam.GetType().Namespace + ".dll");
            

            //Type classType = business.GetType(ClassName);
            Type classType = oParam.GetType().Assembly.GetType(ClassName);


            System.Web.Services.Protocols.SoapHttpClientProtocol oServico =
                (System.Web.Services.Protocols.SoapHttpClientProtocol)System.Activator.CreateInstance(classType);


            ////todo : temp precisa ser instalado a cadeia de certificados 
            //// do SVAN
            //if (ClassName.Contains("SVAN"))
            //{
            //    oServico = new statusSVAN();
            //}
            

            #region Instancia cabecalho

            //Type headerClassType = business.GetType(headerClassName);
            Type headerClassType = oParam.GetType().Assembly.GetType(headerClassName);

            System.Web.Services.Protocols.SoapHeader oCabecalho =
                (System.Web.Services.Protocols.SoapHeader)System.Activator.CreateInstance(headerClassType);


            oCabecalho.GetType().GetProperty("cUF").SetValue(oCabecalho,
                ((System.Xml.Serialization.XmlEnumAttribute)oParam.UF.GetType().GetField(
                    oParam.UF.ToString()).GetCustomAttributes(
                        typeof(System.Xml.Serialization.XmlEnumAttribute), false)[0]).Name,
                                                             null);

            oCabecalho.GetType().GetProperty("versaoDados").SetValue(oCabecalho, oParam.versaoDados, null);
            oServico.GetType().GetProperty("nfeCabecMsgValue").SetValue(oServico, oCabecalho, null);


            #endregion

            //business = null;

            return oServico;
        }
       
        public static string ValidacaoXML(String xml, String xsd)
        {
            ValidaXML oValidador = new ValidaXML();
            return oValidador.Validar(xml, xsd);
        }

        public static string RetiraAcentos(String retornoMsg)
        {
            retornoMsg = retornoMsg.Replace("ç", "c").Replace("Ç", "C").Replace("Ò", "O").Replace("ò", "o");
            retornoMsg = retornoMsg.Replace("ã", "a").Replace("Ã", "A").Replace("ö", "o").Replace("Ö", "O");
            retornoMsg = retornoMsg.Replace("é", "e").Replace("É", "E").Replace("à", "a").Replace("À", "A");
            retornoMsg = retornoMsg.Replace("í", "i").Replace("Í", "I").Replace("ì", "i").Replace("Ì", "i");
            retornoMsg = retornoMsg.Replace("õ", "o").Replace("Õ", "O").Replace("ó", "o").Replace("Ó", "O");
            retornoMsg = retornoMsg.Replace("ú", "u").Replace("Ú", "U").Replace("ù", "u").Replace("Ù", "U");
            retornoMsg = retornoMsg.Replace("ü", "u").Replace("Ü", "U").Replace("ä", "a").Replace("Ä", "A");
            retornoMsg = retornoMsg.Replace("á", "a").Replace("Á", "A").Replace("è", "e").Replace("È", "E");
            return retornoMsg;
        }

        public static String ObterDescricao(Enum valor)
        {
            FieldInfo fieldInfo = valor.GetType().GetField(valor.ToString());

            DescriptionAttribute[] atributos = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return atributos.Length > 0 ? atributos[0].Description ?? "Nulo" : valor.ToString();
        }

        public static IList Listar(Type tipo)
        {
            ArrayList lista = new ArrayList();
            if (tipo != null)
            {
                Array enumValores = Enum.GetValues(tipo);
                foreach (Enum valor in enumValores)
                {
                    lista.Add(new KeyValuePair<int, String>(Convert.ToInt32(valor), ObterDescricao(valor)));
                }
            }

            return lista;
        }

        private static void AddNode(System.Xml.XmlNode inXmlNode, System.Windows.Forms.TreeNode inTreeNode)
        {
            System.Xml.XmlNode xNode;
            System.Windows.Forms.TreeNode tNode;
            System.Xml.XmlNodeList nodeList;
            int i;

            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    inTreeNode.Nodes.Add(new System.Windows.Forms.TreeNode(xNode.Name));
                    tNode = inTreeNode.Nodes[i];
                    AddNode(xNode, tNode);
                }
            }
            else
            {
                // Here you need to pull the data from the XmlNode based on the
                // type of node, whether attribute values are required, and so forth.
                inTreeNode.Text = (inXmlNode.OuterXml).Trim();
            }
        }

        public static void PopulaTreeView(System.Xml.XmlDocument xmlDoc, System.Windows.Forms.TreeView TreeXML)
        {
            PopulaTreeView(xmlDoc, TreeXML, false);
        }

        public static void PopulaTreeView(System.Xml.XmlDocument xmlDoc, System.Windows.Forms.TreeView TreeXML, bool Expande)
        {
            try
            {

                // SECTION 2. Initialize the TreeView control.
                TreeXML.Nodes.Clear();
                TreeXML.Nodes.Add(new System.Windows.Forms.TreeNode(xmlDoc.DocumentElement.Name));
                System.Windows.Forms.TreeNode tNode = new System.Windows.Forms.TreeNode();
                tNode = TreeXML.Nodes[0];

                // SECTION 3. Populate the TreeView with the DOM nodes.
                AddNode(xmlDoc.DocumentElement, tNode);
                if(Expande)
                    TreeXML.ExpandAll();
            }
            catch (System.Xml.XmlException xmlEx)
            {
                System.Windows.Forms.MessageBox.Show(xmlEx.Message);
            }
        }

        public static void AddToFile(string contents, Boolean canLog, String FileName)
        {
            if (canLog)
            {
                String pathPFileName = AppDomain.CurrentDomain.BaseDirectory + FileName;

                while (IsFileOpen(pathPFileName))
                { }

                FileStream fs = null;

                if (File.Exists(FileName))
                {
                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + FileName, FileMode.Open, FileAccess.Write);
                }
                else
                {
                    fs = new FileStream(AppDomain.CurrentDomain.BaseDirectory + FileName, FileMode.Open, FileAccess.Write);
                }

                StreamWriter sw = new StreamWriter(fs);
                sw.BaseStream.Seek(0, SeekOrigin.End);
                sw.WriteLine(DateTime.Now + " : " + contents);
                sw.Flush();
                sw.Close();
            }
        }

        private static bool IsFileOpen(string filePath)
        {
            bool fileOpened = false;
            try
            {
                System.IO.FileStream fs = System.IO.File.OpenWrite(filePath);
                fs.Close();
            }
            catch
            {
                fileOpened = true;
            }

            return fileOpened;
        }


    }   
}
