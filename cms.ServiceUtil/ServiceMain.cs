using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.IO;
using cms.nfe;

namespace cms.ServiceUtil
{
    partial class ServiceMain : ServiceBase
    {
        
        private const double stopped = 0.3d;

        private Queue<csTeste> queue = new Queue<csTeste>();
                
        private readonly string ip = "127.0.0.1";
        private readonly int port1 = 48888;
        
        private Socket socket;
        private Thread thread;

        private NetworkStream networkStream;
        private BinaryWriter binaryWriter;
        private BinaryReader binaryReader;

        public ServiceMain()
        {
            InitializeComponent();
        }

        #region # Events the Windows Services #
        protected override void OnStart(string[] args)
        {        
            DateTime dTimer = DateTime.Now;

            while (true)
            {
                if (DateTime.Now > dTimer.AddSeconds(15.0d))
                    break;
            }

            thread = new Thread(new ThreadStart(RunServer));
            thread.Start();
        }

        protected override void OnStop()
        {
            
        }

        protected override void OnPause()
        {
            
        }

        protected override void OnContinue()
        {
            
        }
        #endregion

        public void RunServer()
        {
            TcpListener tcpListener;
            try
            {
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(ip), port1);
                tcpListener = new TcpListener(ipEndPoint);
                tcpListener.Start();

                System.Diagnostics.Debug.WriteLine("Servidor habilitado e escutando porta...", "Server App");

                socket = tcpListener.AcceptSocket();

                networkStream = new NetworkStream(socket);
                binaryWriter = new BinaryWriter(networkStream);
                binaryReader = new BinaryReader(networkStream);
                
                System.Diagnostics.Debug.WriteLine("conexão recebida!", "Server App");
                binaryWriter.Write("\nconexão efetuada!");

                string messageReceived = "";
                do
                {
                    try
                    {
                        queue.Enqueue(Comunic.GetObjectByte(binaryReader.ReadBytes(170)));
                        binaryWriter.Write("\nObjeto recebido!");
                        messageReceived = binaryReader.ReadString();
                        //System.Diagnostics.Debug.WriteLine("Mensagem: " + messageReceived, "Server App");
                    }
                    catch 
                    {
                        binaryWriter.Write("\nErro ao receber o objeto!");
                    }

                } while (socket.Connected);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            finally
            {
                binaryReader.Close();
                binaryWriter.Close();
                networkStream.Close();
                socket.Close();

                System.Diagnostics.Debug.WriteLine("conexão finalizada", "Server App");
            }
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            try
            {
                binaryWriter.Write("Server respondendo: Houston, we have a problem!!!");
            }
            catch (SocketException socketEx)
            {
                System.Diagnostics.Debug.WriteLine(socketEx.Message, "Erro");
            }
        }
    
    }
}

