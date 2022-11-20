using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cms.Modulos.Util
{
    public static class Globals
    {
        private static string titulo = "Lojas Maria da Penha";

        //private static string _ConnectionString = @"Data Source=arnaldooliveira.no-ip.biz;Initial Catalog=cms;Persist Security Info=True;User ID=sa;Password=Brasil@2003";
        //public static string ConnectionString
        //{
        //    get { return Globals._ConnectionString; }
        //}

        public static string Titulo(string t)
        {
            return titulo + " - " + t;
        }
        public static string Titulo()
        {
            return titulo;
        }
    
    }
}
