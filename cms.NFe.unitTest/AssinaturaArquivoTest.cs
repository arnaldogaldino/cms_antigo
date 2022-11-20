using cms.NFe;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography.X509Certificates;

namespace cms.NFe.unitTest
{
    
    
    /// <summary>
    ///This is a test class for AssinaturaArquivoTest and is intended
    ///to contain all AssinaturaArquivoTest Unit Tests
    ///</summary>
    [TestClass()]
    public class AssinaturaArquivoTest
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
        ///A test for AssinaturaArquivo Constructor
        ///</summary>
        [TestMethod()]
        public void AssinaturaArquivoConstructorTest()
        {
            AssinaturaArquivo target = new AssinaturaArquivo();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for SelecionarCertificado
        ///</summary>
        [TestMethod()]
        public void SelecionarCertificado()
        {
            AssinaturaArquivo target = new AssinaturaArquivo(); // TODO: Initialize to an appropriate value
            X509Certificate2 expected = null; // TODO: Initialize to an appropriate value
            X509Certificate2 actual;

            actual = target.SelecionarCertificado();

            Assert.AreNotEqual(expected, actual);            
        }


        /// <summary>
        ///A test for GetArquivo
        ///</summary>
        [TestMethod()]
        public void GetArquivo()
        {
            AssinaturaArquivo target = new AssinaturaArquivo(); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual;

            actual = target.GetArquivo(@"C:\Setup.txt");

            Assert.AreNotEqual(expected, actual);
        }

        
        /// <summary>
        ///A test for VerificarArquivoAssinado
        ///</summary>
        [TestMethod()]
        public void VerificarArquivoAssinado()
        {
            AssinaturaArquivo target = new AssinaturaArquivo(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;

            actual = target.VerificarArquivoAssinado(target.GetArquivo(@"C:\Setup.txt"));

            Assert.AreEqual(expected, actual);
        }


        /// <summary>
        ///A test for AssinarArquivo
        ///</summary>
        [TestMethod()]
        public void AssinarArquivo()
        {
            AssinaturaArquivo target = new AssinaturaArquivo(); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual = target.GetArquivo(@"C:\Setup.log");

            expected = target.AssinarArquivo(target.SelecionarCertificado(), actual);

            Assert.AreNotEqual(expected, actual);
        }

        /// <summary>
        ///A test for GravarArquivo
        ///</summary>
        [TestMethod()]
        public void GravarArquivo()
        {
            AssinaturaArquivo target = new AssinaturaArquivo(); // TODO: Initialize to an appropriate value
            byte[] expected = null; // TODO: Initialize to an appropriate value
            byte[] actual = target.GetArquivo(@"C:\Setup.log");

            expected = target.AssinarArquivo(target.SelecionarCertificado(), actual);

            target.GravarArquivo(@"C:\Setup2.log", expected);

            Assert.AreNotEqual(expected, actual);
        }

        
    }
}
