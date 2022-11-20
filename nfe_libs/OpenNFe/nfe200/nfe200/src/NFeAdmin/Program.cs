using System;
using System.Collections.Generic;
using System.Windows.Forms;
using RDI.NFe.Visual;
using RDI.NFe2.Business;
using System.IO;
using RDI.Lince;

namespace RDI.NFe
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        //static System.Data.SqlClient.SqlConnection globalConn;
        //static private RDI.Lince.ClientEnvironment globalManager;
        //static private Parametro oParam;
        //static public ParametroQRY oParamQRY;
        //static private Boolean canRun = true;
        //static public FuncaoAutomacao oFuncao;

        static private String ConAux;
        static public String empresa;

        static public ClientEnvironment CreateManager()
        {
            //Conexao com banco de dados
            ClientEnvironment globalManager = new RDI.Lince.ClientEnvironment(RDI.Lince.DataBaseType.SQLSERVER);
            System.Data.SqlClient.SqlConnection globalConn = new System.Data.SqlClient.SqlConnection();
            globalConn.ConnectionString = ConAux;
            globalConn.Open();
            globalManager.connection = globalConn;

            return globalManager;
        }

        static public void DisposeManager(ClientEnvironment manager)
        {
            if (manager != null && manager.connection != null && manager.connection.State == System.Data.ConnectionState.Open)
            {
                manager.connection.Close();
            }
        }
        

        static public Parametro GetParametro(String empresa, ClientEnvironment manager)
        {
            ParametroQRY oParamQRY = new ParametroQRY();
            oParamQRY.empresa = empresa;

            return (Parametro)ParametroDAL.Instance.GetInstances(oParamQRY, manager)[0];
        }

        

        [STAThread]
        static void Main()
        {
            Boolean canRun = true;
            ClientEnvironment manager=null;
            try
            {
                if (!File.Exists(".\\conexao"))
                {
                    throw new Exception("Arquivo de conexão não existe ou esta corrompido.");
                }
                StreamReader SR = File.OpenText(".\\conexao");
                ConAux = SR.ReadLine();
                empresa = SR.ReadLine();

                manager = CreateManager();//nao é utilizado nesse ponto
                //todo : testar tabelas
                
                //essa carga nao sera feita aqui.(multiempresa)
                //carga dos parametros de sistema
                //Parametro oParam = new Parametro();
                //ParametroQRY oParamQRY = new ParametroQRY();
                //oParamQRY.empresa = SR.ReadLine();
                
                //oParam = (Parametro)ParametroDAL.Instance.GetInstances(oParamQRY, manager)[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERRO : " + ex.Message,"OpenNFe");
                MessageBox.Show("Este programa executou uma tarefa ilegal e será fechado. Contate o Administrador do Sistema.", "OpenNFe");
                canRun = false;
            }
            finally
            {
                DisposeManager(manager);
            }

            if (canRun)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmMaster());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}