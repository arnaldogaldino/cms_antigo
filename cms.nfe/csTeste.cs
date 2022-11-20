using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cms.nfe
{

    [Serializable]
    public class csTeste
    {
        private int id = 0;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string nome = string.Empty;
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        public csTeste()
        { }
    }
}
