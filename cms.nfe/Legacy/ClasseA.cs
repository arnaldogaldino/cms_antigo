using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cms.nfe.Legacy
{
    public class ClasseA : IFactory
    {

        public ClasseA()
        {}

        public string ValorX()
        {
            return "Valor da Classe A";
        }

    }
}
