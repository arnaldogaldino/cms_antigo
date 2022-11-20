using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Data;
using cms.Modulos.Util;
using System.Data;

namespace cms.Modulos.Fiscal.Cn
{
    public class cnFiscalCfop
    {
        private cmsEntities dbEntities = new cmsEntities();

        public cnFiscalCfop()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<fiscal_cfop> FiscalCfopProcurar(int? cfop, string tipo, string descricao)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fiscal_cfop);
            IQueryable<fiscal_cfop> result = from f in dbEntities.fiscal_cfop
                                             where f.excluido == false
                                             orderby f.cfop
                                             select f;

            if (cfop != null)
                result = result.Where(e => e.cfop == cfop);

            if (!string.IsNullOrEmpty(tipo))
                result = result.Where(e => e.tipo == tipo);

            if (!string.IsNullOrEmpty(descricao))
                result = result.Where(e => e.descricao.Contains(descricao));

            return result;
        }

        public fiscal_cfop GetFiscalCfopById(long id_fiscal_cfop)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fiscal_cfop);
            fiscal_cfop result = (from c in dbEntities.fiscal_cfop
                                  where c.excluido == false && c.id_fiscal_cfop == id_fiscal_cfop
                                  select c).SingleOrDefault();
            return result;
        }

        public bool FiscalCfopCadastrar(ref fiscal_cfop cfop)
        {
            try
            {
                cfop.id_fiscal_cfop = cms.Modulos.Util.Util.sp_getcodigo(Referencia.fiscal_cfop);
                dbEntities.AddTofiscal_cfop(cfop);
                dbEntities.SaveChanges();
            }
            catch { }

            return true;
        }

        public bool FiscalCfopEditar(ref fiscal_cfop cfop)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("fiscal_cfop", cfop);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, cfop);
                }
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
    
    }
}
