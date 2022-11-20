using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace RDI.NFe2.Business
{
    
    public class ThreadIdetificada
    {
        private Boolean _finalizar;

        private Thread _minhaThread;

        public Boolean finalizar
        {
            get { return _finalizar; }
            set { _finalizar = value; }
        }

        public Thread minhaThread
        {
            get { return _minhaThread; }
            set { _minhaThread = value; }
        }
    }
}
