using RDI.Lince;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using RDI.NFe2.Business;
using System.IO;
using System.Threading;


namespace RDI.NFe.Visual
{
    public partial class FrmMonitor : Form
    {
        Boolean inExecution;
        String pastaEntrada;
        ThreadIdetificada oThreadIdentificada;

        public FrmMonitor()
        {
            InitializeComponent();
            inExecution = false;
            Parametro oParam;
            ClientEnvironment manager;
            try
            {
                manager = Program.CreateManager();
                oParam = Program.GetParametro(Program.empresa, manager);
                pastaEntrada = oParam.pastaEntrada;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                oParam = null;
                manager = null;
                Program.DisposeManager(manager);
            }

        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(pastaEntrada))
            {
                oLoop.Start();
                btStart.Enabled = !btStart.Enabled;
                btStop.Enabled = !btStop.Enabled;
                tssLStatus.Text = "Serviço iniciado";
                StartThread();
            }
            else
            {
                MessageBox.Show("Pasta de entrada não foi configurada.");
            }
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            StopThread();
            oLoop.Stop();
            btStart.Enabled = !btStart.Enabled;
            btStop.Enabled = !btStop.Enabled;
            tssLStatus.Text = "Serviço parado";
        }

        private void oLoop_Tick(object sender, EventArgs e)
        {
            if (!inExecution)
            {
                inExecution = true;

                //somente irá atualizar a tela
                DirectoryInfo dir = null;
                listadeNotas.Items.Clear();
                if (!Directory.Exists(pastaEntrada))
                {
                    dir = Directory.CreateDirectory(pastaEntrada);
                }
                else
                {
                    dir = new DirectoryInfo(pastaEntrada);
                }

                if (dir != null)
                {
                    foreach (FileInfo fileName in dir.GetFiles("NFe*.xml"))
                    {
                        listadeNotas.Items.Add(fileName.Name);
                    }
                }
                inExecution = false;
            }

        }

        public static void CreateThread(Object oThreadIdetificada)
        {
            ThreadIdetificada oTh = (ThreadIdetificada)oThreadIdetificada;
            ClientEnvironment manager = null;
            try
            {
                manager = Program.CreateManager();
                FuncaoAutomacao oFuncao = new FuncaoAutomacao(Program.empresa, manager);

                oFuncao.CriaLog(998, "Serviço de monitoramento inicializado com sucesso.");

                while (!oTh.finalizar)
                {
                    
                    oFuncao.DoOnLoop(false, "");

                }

                oFuncao.CriaLog(997, "Serviço de monitoramento paralizado com sucesso.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu uma chamada inválida. Feche o monitor e abra novamente. " + ex.Message);
            }
            finally
            {
                Program.DisposeManager(manager);
            }


            
        }

        private void StartThread()
        {   
             
            
            try
            {
                oThreadIdentificada = new ThreadIdetificada();
                //inicializa thread
                ParameterizedThreadStart operacao = new ParameterizedThreadStart(CreateThread);
                oThreadIdentificada.finalizar = false;
                oThreadIdentificada.minhaThread = new Thread(operacao);

                oThreadIdentificada.minhaThread.Start(oThreadIdentificada);
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                
            }
        }

        private void StopThread()
        {
            try
            {
                if (oThreadIdentificada != null)
                {
                    oThreadIdentificada.finalizar = true;
                }
                else
                {
                    MessageBox.Show("Thread não localizada.");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
        }

        private void FrmMonitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopThread();
        }
    }
}