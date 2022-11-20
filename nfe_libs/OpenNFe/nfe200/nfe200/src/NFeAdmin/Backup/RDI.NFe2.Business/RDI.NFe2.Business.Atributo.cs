using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RDI.NFe2.Business.Atributo
{
    [AttributeUsage(AttributeTargets.Field)]
    public class AtendidoPor : Attribute
    {
        String _value;

        public String value
        {
            get { return _value; }
            set { _value = value; }
        }
    }
}

