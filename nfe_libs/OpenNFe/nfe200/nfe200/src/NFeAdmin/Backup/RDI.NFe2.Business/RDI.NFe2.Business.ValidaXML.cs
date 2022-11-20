using System;
using System.IO;
using System.Xml;
using System.Xml.Schema;



namespace RDI.NFe2.Business
{
    public class ValidaXML
    {
        private String Resultado;

        public String Validar(string _xml, string _xsd)
        {
            Resultado = ""; 

            if (!File.Exists(_xml) || !File.Exists(_xsd))
            {
                return "NotFound";
            }

            // Cria um novo XMLValidatingReader
            XmlValidatingReader reader = new XmlValidatingReader(new XmlTextReader(new StreamReader(_xml)));
            // Cria um schemacollection
            XmlSchemaCollection schemaCollection = new XmlSchemaCollection();
            //Adiciona o XSD e o namespace
            schemaCollection.Add("http://www.portalfiscal.inf.br/nfe", _xsd);
            // Adiciona o schema ao ValidatingReader
            reader.Schemas.Add(schemaCollection);
            //Evento que retorna a mensagem de validacao
            reader.ValidationEventHandler += new ValidationEventHandler(reader_ValidationEventHandler);
            //Percorre o XML
            while (reader.Read()) {}
            reader.Close(); //Fecha o arquivo.
            //O Resultado é preenchido no reader_ValidationEventHandler
            return Resultado;
        }
        
        private void reader_ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            // Como sera exibida a mensagem de ERROS de validacao
            Resultado = Resultado + String.Format("\rLinha:{1}" + System.Environment.NewLine +
                                                  "\rColuna:{0}" + System.Environment.NewLine +
                                                  "\rErro:{2}" + System.Environment.NewLine , 
                                                  e.Exception.LinePosition, 
                                                  e.Exception.LineNumber, 
                                                  e.Exception.Message);
        }
    }
}
