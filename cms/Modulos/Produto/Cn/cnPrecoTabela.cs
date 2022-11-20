using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;

namespace cms.Modulos.Produto.Cn
{
    public class cnPrecoTabela
    {
        private cmsEntities dbEntities = new cmsEntities();

        public cnPrecoTabela()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }
        
        #region PrecoTabela

        public IQueryable<produto_preco_tabela> PrecoTabelaProcurar(long? id_preco_tabela, string preco_tabela)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto_preco_tabela);
            IQueryable<produto_preco_tabela> result = from p in dbEntities.produto_preco_tabela
                                                      where p.excluido == false
                                                      orderby p.preco_tabela
                                                      select p;
            if (id_preco_tabela != null)
                result = result.Where(e => e.id_produto_preco_tabela == id_preco_tabela);

            if (!string.IsNullOrEmpty(preco_tabela))
                result = result.Where(e => e.preco_tabela.Contains(preco_tabela));

            return result;
        }

        public produto_preco_tabela GetPrecoTabelaByID(long id_preco_tabela)
        {
            produto_preco_tabela result = (from p in dbEntities.produto_preco_tabela
                                           where p.excluido == false && p.id_produto_preco_tabela == id_preco_tabela
                                           select p).SingleOrDefault();

            return result;
        }

        public bool PrecoTabelaCadastrar(ref produto_preco_tabela preco_tabela)
        {
            try
            {
                preco_tabela.id_produto_preco_tabela = cms.Modulos.Util.Util.sp_getcodigo(Referencia.produto_preco_tabela);
                preco_tabela.data_cadastro = cms.Modulos.Util.Util.sp_getdatetime();
                preco_tabela.excluido = false;
                dbEntities.AddToproduto_preco_tabela(preco_tabela);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool PrecoTabelaEditar(ref produto_preco_tabela preco_tabela)
        {
            try
            {
                dbEntities.produto_preco_tabela.ApplyCurrentValues(preco_tabela);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        #endregion

    }
}
