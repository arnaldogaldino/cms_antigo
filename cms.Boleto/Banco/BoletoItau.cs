using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cms.Boleto
{
    public class InfItau
    {
        public const int codigo = 341;
        public const string nome = "Itaú Unibanco S.A.";

        public List<_Carteira> Carteira { get; set; }
        public List<_Especie> Especie { get; set; }
        public List<_Instrucao> Instrucao { get; set; }
        public List<_OcorrenciaRemessa> OcorrenciaRemessa { get; set; }
        public List<_OcorrenciaRetorno> OcorrenciaRetorno { get; set; }
        
        public class _Carteira
        {
            public string carteira { get; set; }
            public string descricao { get; set; }
        }
        public class _Especie
        {
            public string especie { get; set; }
            public string descricao { get; set; }
        }
        public class _Instrucao
        {
            public string instrucao { get; set; }
            public string descricao { get; set; }
            public List<string> obj { get; set; }
        }
        public class _OcorrenciaRemessa
        {
            public string ocorrencia { get; set; }
            public string descricao { get; set; }
            public List<string> obs { get; set; }
        }
        public class _OcorrenciaRetorno
        {
            public string ocorrencia { get; set; }
            public string descricao { get; set; }
            public List<Erro> erros { get; set; }
            public class Erro
            {
                public string campo { get; set; }
                public string descricao { get; set; }
            }
        }

    }
}
