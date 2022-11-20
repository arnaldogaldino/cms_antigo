using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cms.nfe.Legacy
{
    public class ClasseB : IFactory
    {
        public ClasseB()
        {}

        public string ValorX()
        {
            return "Valor da Classe B";
        }
    }
}
