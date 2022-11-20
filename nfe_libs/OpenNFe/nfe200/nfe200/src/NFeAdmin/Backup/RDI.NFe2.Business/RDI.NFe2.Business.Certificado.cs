using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Security;
using System.Xml;
using System.Xml.Schema;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;


namespace RDI.NFe2.Business
{
    public static class Certificado
    {
        //Classe para buscar o certificado no repositorio do WINDOWS
        public static X509Certificate2 BuscaNome(string Nome, Boolean usaWService)
        {
            //X509Certificate2 oCert = new X509Certificate2("", "senha");
            //testar para certificados a3

            X509Certificate2 _X509Cert = new X509Certificate2();
            try
            {
                X509Certificate2Collection collection2 = CollectCertificates(usaWService);


                if (Nome == "")
                {
                    X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection(collection2, "Certificado(s) Digital(is) disponível(is)", "Selecione o Certificado Digital para uso no aplicativo", X509SelectionFlag.SingleSelection);
                    if (scollection.Count == 0)
                    {
                        _X509Cert.Reset();
                    }
                    else
                    {
                        _X509Cert = scollection[0];
                    }
                }
                else
                {
                    X509Certificate2Collection scollection = (X509Certificate2Collection)collection2.Find(X509FindType.FindBySubjectDistinguishedName, Nome, false);
                    if (scollection.Count == 0)
                    {
                        _X509Cert.Reset();
                    }
                    else
                    {
                        _X509Cert = scollection[0];
                    }
                }


                return _X509Cert;
            }
            catch //(System.Exception ex)
            {
                return _X509Cert;
            }
        }

        public static int PopulaItems(ComboBox.ObjectCollection items, Boolean usaWService)
        {
            int i = 0;
            items.Clear();

            X509Certificate2Collection collection2 = CollectCertificates(usaWService);

            while (i < collection2.Count)
            {
                items.Add(collection2[i].Subject.ToString());
                i++;
            }

            return items.Count;
        }

        public static X509Certificate2Collection CollectCertificates(Boolean usaWService)
        {
            StoreLocation StLocation = StoreLocation.CurrentUser;

            if (usaWService)
                StLocation = StoreLocation.LocalMachine;

            X509Store store = new X509Store("MY", StLocation);
            store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
            X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find(X509FindType.FindByTimeValid, DateTime.Now, true);
            X509Certificate2Collection collection2 = (X509Certificate2Collection)collection1.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, true);

            store.Close();

            return collection2;
        }
    }
}