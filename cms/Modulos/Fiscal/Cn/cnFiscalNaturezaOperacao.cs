using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Data;
using cms.Modulos.Util;
using System.Data;

namespace cms.Modulos.Fiscal.Cn
{
    public class cnFiscalNaturezaOperacao
    {
        private cmsEntities dbEntities = new cmsEntities();
        
        public cnFiscalNaturezaOperacao()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<fiscal_natureza_operacao> FiscalNaturezaOperacaoProcurar(string tipo, long? nat, string descricao)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fiscal_natureza_operacao);
            IQueryable<fiscal_natureza_operacao> result = from n in dbEntities.fiscal_natureza_operacao
                                                          where n.excluido == false
                                                          orderby n.id_fiscal_natureza_operacao
                                                          select n;
            
            if (nat != null)
                result = result.Where(e => e.id_fiscal_natureza_operacao == nat.Value);

            if (!string.IsNullOrEmpty(tipo))
                result = result.Where(e => e.tipo == tipo);

            if (!string.IsNullOrEmpty(descricao))
                result = result.Where(e => e.descricao.Contains(descricao));

            return result;
        }

        public fiscal_natureza_operacao GetFiscalNaturezaOperacaoById(long id_fiscal_natureza_operacao)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fiscal_natureza_operacao);
            fiscal_natureza_operacao result = (from n in dbEntities.fiscal_natureza_operacao
                                               where n.excluido == false && n.id_fiscal_natureza_operacao == id_fiscal_natureza_operacao
                                               select n).SingleOrDefault();
            return result;
        }

        public bool FiscalNaturezaOperacaoCadastrar(ref fiscal_natureza_operacao natureza)
        {
            try
            {
                natureza.id_fiscal_natureza_operacao = cms.Modulos.Util.Util.sp_getcodigo(Referencia.fiscal_natureza_operacao);
                dbEntities.AddTofiscal_natureza_operacao(natureza);
                dbEntities.SaveChanges();
            }
            catch { }

            return true;
        }

        public bool FiscalNaturezaOperacaoEditar(ref fiscal_natureza_operacao natureza)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("fiscal_natureza_operacao", natureza);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, natureza);
                }
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
    


    }
}
