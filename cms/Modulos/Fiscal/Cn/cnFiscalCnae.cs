using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Data;
using cms.Modulos.Util;
using System.Data;

namespace cms.Modulos.Fiscal.Cn
{
    public class cnFiscalCnae
    {
        private cmsEntities dbEntities = new cmsEntities();

        public cnFiscalCnae()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<fiscal_cnae> FiscalCnaeProcurar(long? id_fiscal_cnae, string secao, string divisao, string grupo, string classe, string subclasse, string denominacao)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fiscal_cnae);
            IQueryable<fiscal_cnae> result = from f in dbEntities.fiscal_cnae
                                             where f.excluido == false
                                             orderby f.secao, f.divisao, f.grupo, f.classe, f.subclasse
                                             select f;

            if (id_fiscal_cnae != null)
                result = result.Where(e => e.id_fiscal_cnae == id_fiscal_cnae);

            if (!string.IsNullOrEmpty(secao))
                result = result.Where(e => e.secao == secao);

            if (!string.IsNullOrEmpty(divisao))
                result = result.Where(e => e.secao == secao);

            if (!string.IsNullOrEmpty(grupo))
                result = result.Where(e => e.grupo == grupo);

            if (!string.IsNullOrEmpty(classe))
                result = result.Where(e => e.classe == classe);

            if (!string.IsNullOrEmpty(subclasse))
                result = result.Where(e => e.subclasse == subclasse);

            if (!string.IsNullOrEmpty(denominacao))
                result = result.Where(e => e.denominacao.Contains(denominacao));

            return result;
        }

        public fiscal_cnae GetFiscalCnaeById(long id_fiscal_cnae)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fiscal_cnae);
            fiscal_cnae result = (from c in dbEntities.fiscal_cnae
                                  where c.excluido == false && c.id_fiscal_cnae == id_fiscal_cnae
                                  select c).SingleOrDefault();
            return result;
        }

        public bool FiscalCnaeCadastrar(ref fiscal_cnae cnae)
        {
            try
            {
                cnae.id_fiscal_cnae = cms.Modulos.Util.Util.sp_getcodigo(Referencia.fiscal_cnae);
                dbEntities.AddTofiscal_cnae(cnae);
                dbEntities.SaveChanges();
            }
            catch { }

            return true;
        }

        public bool FiscalCnaeEditar(ref fiscal_cnae cnae)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("fiscal_cnae", cnae);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, cnae);
                }
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

    }
}
