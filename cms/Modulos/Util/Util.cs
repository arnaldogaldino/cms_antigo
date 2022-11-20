using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Data;
using System.Data.Objects;
using System.IO;
using System.Globalization;
using System.Text.RegularExpressions;

namespace cms.Modulos.Util
{
    public class Util
    {

        /// <summary>
        /// Retorna a data do servidor.
        /// </summary>
        public static DateTime GetDataServidor()
        {
            cmsEntities entities = new cmsEntities();
                return entities.ExecuteFunction<DateTime>("sp_getdatetime").SingleOrDefault();
        }

        /// <summary>
        /// Retorna o próximo código da tabela informada.
        /// </summary>
        /// <param name="p_id">Tabela para verificar o próximo código.</param>
        public static Int64 sp_getcodigo(Referencia p_id)
        {
            cmsEntities entities = new cmsEntities();

            ObjectParameter p_idParameter;
            p_idParameter = new ObjectParameter("p_id", (long)p_id);          

            return entities.ExecuteFunction<Nullable<System.Int64>>("sp_getcodigo", p_idParameter).SingleOrDefault().Value;
        }
        
        public static void sp_atualizar_referencia()
        {
            cmsEntities entities = new cmsEntities();
            entities.ExecuteFunction("sp_atualizar_referencia");
        }

        /// <summary>
        /// Re-Processa o Lancamento bancario.
        /// </summary>
        /// <param name="p_id_conta_corrente">Informe o id da conta corrente.</param>
        /// <param name="p_data_lancamento">Informe a data de Inicio para o processamento.</param>
        public static void sp_financeiro_lancamento_atualizar_saldo(long p_id_conta_corrente, DateTime p_data_lancamento)
        {
            cmsEntities entities = new cmsEntities();
            ObjectParameter p_id_conta_correnteParameter;
            p_id_conta_correnteParameter = new ObjectParameter("p_id_conta_corrente", p_id_conta_corrente);
          
            ObjectParameter p_data_lancamentoParameter;
            p_data_lancamentoParameter = new ObjectParameter("p_data_lancamento", p_data_lancamento);

            entities.ExecuteFunction("sp_financeiro_lancamento_atualizar_saldo", p_id_conta_correnteParameter, p_data_lancamentoParameter);
        }

        /// <summary>
        /// Retorna a data do servidor.
        /// </summary>
        public static DateTime sp_getdatetime()
        {
            cmsEntities entities = new cmsEntities();
            return entities.ExecuteFunction<System.DateTime>("sp_getdatetime").SingleOrDefault();
        }

        public static byte[] ReadFile(Stream file)
        {
            byte[] buffer;

            try
            {
                int length = (int)file.Length;  // get file length
                buffer = new byte[length];            // create buffer
                int count;                            // actual number of bytes read
                int sum = 0;                          // total number of bytes read

                // read until Read method returns 0 (end of the stream has been reached)
                while ((count = file.Read(buffer, sum, length - sum)) > 0)
                    sum += count;  // sum is a buffer offset for next reading
            }
            finally
            {
                file.Close();
            }
            return buffer;
        }

        public static string RemoveCaracteresEspeciais(string texto)
        {
            var normalizedString = texto;

            // Prepara a tabela de símbolos.
            var symbolTable = new Dictionary<char, char[]>();
            symbolTable.Add('a', new char[] { 'à', 'á', 'ä', 'â', 'ã' });
            symbolTable.Add('c', new char[] { 'ç' });
            symbolTable.Add('e', new char[] { 'è', 'é', 'ë', 'ê' });
            symbolTable.Add('i', new char[] { 'ì', 'í', 'ï', 'î' });
            symbolTable.Add('o', new char[] { 'ò', 'ó', 'ö', 'ô', 'õ' });
            symbolTable.Add('u', new char[] { 'ù', 'ú', 'ü', 'û' });

            // Substitui os símbolos.
            foreach (var key in symbolTable.Keys)
            {
                foreach (var symbol in symbolTable[key])
                {
                    normalizedString = normalizedString.Replace(symbol, key);
                }
            }

            // Remove os outros caracteres especiais.
            normalizedString = Regex.Replace(normalizedString, "[^0-9a-zA-Z._]+?", "");
            return normalizedString;

        }

    }
}
