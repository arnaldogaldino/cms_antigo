using cms.Modulos.Fiscal.Cn;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using cms.NFe;
using System.Data;

namespace cms.unitTest
{
    
    
    /// <summary>
    ///This is a test class for cnFiscalNFeTest and is intended
    ///to contain all cnFiscalNFeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class cnFiscalNFeTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for DesserializarXML
        ///</summary>
        [TestMethod()]
        public void DesserializarXML()
        {
            cnFiscalNFe target = new cnFiscalNFe(); // TODO: Initialize to an appropriate value
            string path = string.Empty; // TODO: Initialize to an appropriate value
            target.DesserializarXML(@"D:\projetos\cms\cms.nfe\135100567990569_v1.10-procNFe.xml");
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SerializarXML
        ///</summary>
        [TestMethod()]
        public void SerializarXMLTest()
        {
            cnFiscalNFe target = new cnFiscalNFe(); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;
            actual = target.SerializarXML();
            
            NFe.AssinaturaArquivo a = new NFe.AssinaturaArquivo();
            a.GravarArquivo(@"D:\projetos\cms\cms.nfe\teste-procNFe.xml", actual);

            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SerializarXML
        ///</summary>
        [TestMethod()]
        public void InitializeTest()
        {
            cnFiscalNFe target = new cnFiscalNFe(); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;

            cms.Modulos.Venda.Cn.cnVenda venda = new Modulos.Venda.Cn.cnVenda();

            DataSet dsCep = new DataSet();

            dsCep.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=02816030&formato=xml");

            target.Venda = venda.GetVendaByID(11);
            target.Initialize();

            actual = null;
            
            
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

    }
}
