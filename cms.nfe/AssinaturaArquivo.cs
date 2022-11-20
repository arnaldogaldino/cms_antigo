﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Security.Cryptography.Xml;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Pkcs;

namespace cms.NFe
{

    public class AssinaturaArquivo
    {

        public X509Certificate2 SelecionarCertificado()
        {
            X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
            X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, DateTime.Now, true);
            X509Certificate2Collection collection2 = (X509Certificate2Collection)collection1.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, true);

            X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(collection, "Certificado(s) Digital(is) disponível(is)", "Selecione o Certificado Digital para uso no aplicativo", X509SelectionFlag.SingleSelection);

            if (scollection.Count < 1)
                throw new Exception("Nenhum certificado foi selecionado.");

            return scollection[0];
        }

        public X509Certificate2Collection SelecionarCertificados()
        {
            X509Store store = new X509Store("MY", StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);

            X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
            X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, DateTime.Now, true);
            X509Certificate2Collection collection2 = (X509Certificate2Collection)collection1.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, true);

            X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(collection, "Certificado(s) Digital(is) disponível(is)", "Selecione o Certificado Digital para uso no aplicativo", X509SelectionFlag.SingleSelection);

            if (scollection.Count < 1)
                throw new Exception("Nenhum certificado foi selecionado.");

            return scollection;
        }


        public byte[] AssinarArquivo(X509Certificate2 cert, byte[] data)
        {
            try
            {
                ContentInfo content = new ContentInfo(data);
                SignedCms signedCms = new SignedCms(content, false);
                if (VerificarArquivoAssinado(data))
                {
                    signedCms.Decode(data);
                }

                CmsSigner signer = new CmsSigner(cert);
                signer.IncludeOption = X509IncludeOption.WholeChain;
                signedCms.ComputeSignature(signer);

                return signedCms.Encode();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao assinar arquivo. A mensagem retornada foi: " + ex.Message);
            }
        }

        public bool VerificarArquivoAssinado(byte[] data)
        {
            try
            {
                SignedCms signed = new SignedCms();
                signed.Decode(data);
            }
            catch
            {
                return false; // Arquivo não assinado
            }
            return true;
        }

        public byte[] GetArquivo(string path)
        {
            byte[] result = null;

            result = File.ReadAllBytes(path);

            return result;
        }

        public void GravarArquivo(string path, byte[] data)
        {
            File.WriteAllBytes(path, data);
        }

        private String Resultado;

        public String ValidarXML(string _xml, string _xsd)
        {
            Resultado = "";

            if (!File.Exists(_xml) || !File.Exists(_xsd))
            {
                return "NotFound";
            }

            XmlValidatingReader reader = new XmlValidatingReader(new XmlTextReader(new StreamReader(_xml)));
            XmlSchemaCollection schemaCollection = new XmlSchemaCollection();
            schemaCollection.Add("http://www.portalfiscal.inf.br/nfe", _xsd);
            reader.Schemas.Add(schemaCollection);
            reader.ValidationEventHandler += new ValidationEventHandler(reader_ValidationEventHandler);
            
            while (reader.Read()) { }
            reader.Close();

            return Resultado;
        }

        private void reader_ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            Resultado = Resultado + String.Format("\rLinha:{1}" + System.Environment.NewLine +
                                                  "\rColuna:{0}" + System.Environment.NewLine +
                                                  "\rErro:{2}" + System.Environment.NewLine,
                                                  e.Exception.LinePosition,
                                                  e.Exception.LineNumber,
                                                  e.Exception.Message);
        }

    }

}

