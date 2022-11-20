using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;

namespace cms.Modulos.Produto.Cn
{
    public class cnGrupo
    {
        private cmsEntities dbEntities = new cmsEntities();

        public cnGrupo()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }
        
        #region Grupo

        public IQueryable<produto_grupo> GrupoProcurar(long? id_grupo, string grupo)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto_grupo);
            IQueryable<produto_grupo> result = from g in dbEntities.produto_grupo
                                               where g.excluido == false
                                               orderby g.grupo
                                               select g;

            if (id_grupo != null)
                result = result.Where(e => e.id_produto_grupo == id_grupo);

            if (!string.IsNullOrEmpty(grupo))
                result = result.Where(e => e.grupo.Contains(grupo));
            
            return result;
        }

        public produto_grupo GetGrupoByID(long id_grupo)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto_grupo);
            produto_grupo result = (from g in dbEntities.produto_grupo
                                    where g.excluido == false && g.id_produto_grupo == id_grupo
                                    select g).SingleOrDefault();
            return result;
        }

        public bool GrupoCadastrar(ref produto_grupo grupo)
        {
            try
            {
                grupo.id_produto_grupo = cms.Modulos.Util.Util.sp_getcodigo(Referencia.produto_grupo);
                dbEntities.AddToproduto_grupo(grupo);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool GrupoEditar(ref produto_grupo grupo)
        {
            try
            {
                dbEntities.produto_grupo.ApplyCurrentValues(grupo);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        #endregion

    }
}
