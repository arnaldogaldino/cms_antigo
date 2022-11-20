using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using cms.nfe;

namespace cms.NFe.Comunic
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Comunic" in code, svc and config file together.
    public class Comunic : IComunic
    {
        private Queue<csTeste> enqueue = new Queue<csTeste>();

        public void DoWork()
        {
        }

        public void EnQueue(csTeste value)
        {
            enqueue.Enqueue(value);

            
        }



    }
}
