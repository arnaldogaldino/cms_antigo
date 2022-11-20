using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;

namespace cms.Modulos.Produto.Cn
{
    public class cnFamilia
    {
        private cmsEntities dbEntities = new cmsEntities();

        public cnFamilia()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }
        
        #region Familia

        public IQueryable<vw_produto_familia> FamiliaProcurar(long? id_familia, long? id_produto_grupo, long? id_produto_subgrupo, string familia)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto_familia);

            IQueryable<vw_produto_familia> result = from f in dbEntities.vw_produto_familia
                                                 where f.excluido == false
                                                 orderby f.familia
                                                 select f;

            if (id_familia != null)
                result = result.Where(e => e.id_produto_familia == id_familia);
            
            if (id_produto_grupo != null)
                result = result.Where(e => e.id_produto_grupo == id_produto_grupo);

            if (id_produto_subgrupo != null)
                result = result.Where(e => e.id_produto_subgrupo == id_produto_subgrupo);

            if (!string.IsNullOrEmpty(familia))
                result = result.Where(e => e.familia.Contains(familia));

            return result;
        }

        public produto_familia GetFamiliaByID(long id_familia)
        {
            produto_familia result = (from f in dbEntities.produto_familia
                                     where f.excluido == false && f.id_produto_familia == id_familia
                                     select f).SingleOrDefault();

            return result;
        }

        public bool FamiliaCadastrar(ref produto_familia familia)
        {
            try
            {
                familia.id_produto_familia = cms.Modulos.Util.Util.sp_getcodigo(Referencia.produto_familia);
                dbEntities.AddToproduto_familia(familia);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FamiliaEditar(ref produto_familia familia)
        {
            try
            {
                dbEntities.produto_familia.ApplyCurrentValues(familia);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        #endregion

    }
}
