using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;

namespace cms.Modulos.Produto.Cn
{
    public class cnSubFamilia
    {

        private cmsEntities dbEntities = new cmsEntities();

        public cnSubFamilia()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }
        
        #region SubFamilia

        public IQueryable<vw_produto_subfamilia> SubFamiliaProcurar(long? id_subfamilia, long? id_familia, long? id_grupo,long? id_subgrupo, string subfamilia)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_produto_subfamilia);
            IQueryable<vw_produto_subfamilia> result = from f in dbEntities.vw_produto_subfamilia
                                                       where f.excluido == false
                                                       orderby f.familia, f.subfamilia
                                                       select f;

            if (id_subfamilia != null)
                result = result.Where(e => e.id_produto_subfamilia == id_subfamilia);

            if (id_familia != null)
                result = result.Where(e => e.id_produto_familia == id_familia);

            if (id_grupo != null)
                result = result.Where(e => e.id_produto_grupo == id_grupo);

            if (id_subgrupo != null)
                result = result.Where(e => e.id_produto_subgrupo == id_subgrupo);

            if (!string.IsNullOrEmpty(subfamilia))
                result = result.Where(e => e.subfamilia.Contains(subfamilia));

            return result;
        }

        public produto_subfamilia GetSubFamiliaByID(long id_subfamilia)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto_subfamilia);
            produto_subfamilia result = (from f in dbEntities.produto_subfamilia
                                        where f.excluido == false && f.id_produto_subfamilia == id_subfamilia
                                        select f).SingleOrDefault();
            return result;
        }

        public bool SubFamiliaCadastrar(ref produto_subfamilia subfamilia)
        {
            try
            {
                subfamilia.id_produto_subfamilia = cms.Modulos.Util.Util.sp_getcodigo(Referencia.produto_subfamilia);
                subfamilia.excluido = false;
                dbEntities.AddToproduto_subfamilia(subfamilia);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool SubFamiliaEditar(ref produto_subfamilia subfamilia)
        {
            try
            {
                dbEntities.produto_subfamilia.ApplyCurrentValues(subfamilia);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        #endregion

    }
}
