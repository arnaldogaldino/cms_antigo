using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;

namespace cms.Modulos.Produto.Cn
{
    public class cnSubGrupo
    {

        private cmsEntities dbEntities = new cmsEntities();

        public cnSubGrupo()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }
        
        #region SubGrupo

        public IQueryable<vw_produto_subgrupo> SubGrupoProcurar(long? id_subgrupo, long? id_grupo, string subgrupo)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_produto_subgrupo);
            IQueryable<vw_produto_subgrupo> result = from g in dbEntities.vw_produto_subgrupo
                                                     where g.excluido == false
                                                     orderby g.grupo, g.subgrupo
                                                     select g;

            if (id_subgrupo != null)
                result = result.Where(e => e.id_produto_subgrupo == id_subgrupo);

            if (id_grupo != null)
                result = result.Where(e => e.id_produto_grupo == id_grupo);

            if (!string.IsNullOrEmpty(subgrupo))
                result = result.Where(e => e.subgrupo.Contains(subgrupo));
            
            return result;
        }

        public produto_subgrupo GetSubGrupoByID(long id_subgrupo)
        {
            produto_subgrupo result = (from g in dbEntities.produto_subgrupo
                                       where g.excluido == false && g.id_produto_subgrupo == id_subgrupo
                                       select g).SingleOrDefault();


            return result;
        }

        public bool SubGrupoCadastrar(ref produto_subgrupo subgrupo)
        {
            try
            {
                subgrupo.id_produto_subgrupo = cms.Modulos.Util.Util.sp_getcodigo(Referencia.produto_subgrupo);
                dbEntities.AddToproduto_subgrupo(subgrupo);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool SubGrupoEditar(ref produto_subgrupo subgrupo)
        {
            try
            {
                dbEntities.produto_subgrupo.ApplyCurrentValues(subgrupo);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        #endregion

    }
}
