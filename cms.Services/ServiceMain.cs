using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace cms.Services
{
    partial class ServiceMain : ServiceBase
    {

        private System.Timers.Timer timer;
        private const double stopped = 0.3d;

        private readonly int port1 = 48888;
        private readonly IPAddress ip = IPAddress.Parse("127.0.0.1");
        private Thread ThreadListenerPort1;

        private TcpListener listenerPorta1;
        
        public ServiceMain()
        {
            InitializeComponent();
        }

        void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ThreadListenerPort1.Start();
        }

        #region # Events the Windows Services #
        protected override void OnStart(string[] args)
        {
            //ThreadListenerPort1 = new Thread(ListenerPort1);

            //listenerPorta1 = new TcpListener(port1);
            //ThreadListenerPort1.Start();
            MessageBox.Show("Started?");
        }

        protected override void OnStop()
        {
            //ThreadListenerPort1.Abort();
            MessageBox.Show("Stop?");
        }

        protected override void OnPause()
        {
            //ThreadListenerPort1.Suspend();
            MessageBox.Show("Paused?");
        }

        protected override void OnContinue()
        {
            //ThreadListenerPort1.Resume();
            MessageBox.Show("Continue?");
        }
        #endregion

        private void ListenerPort1()
        {
            Thread.Sleep(10000);
            Socket s;
            Byte[] incomingBuffer;
            Byte[] time;
            int bytesRead;

            while (true)
            {
                s = this.listenerPorta1.AcceptSocket();

                incomingBuffer = new Byte[100];
                bytesRead = s.Receive(incomingBuffer);

                time = Encoding.ASCII.GetBytes(System.DateTime.Now.ToString().ToCharArray());

                s.Send(time);
            }
        }

    }
}
