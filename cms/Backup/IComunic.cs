using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using cms.nfe;

namespace cms.NFe.Comunic
{
    [ServiceContract]
    public interface IComunic
    {

        [OperationContract]
        void DoWork();

        [OperationContract]
        void EnQueue(csTeste value);

    }


}
