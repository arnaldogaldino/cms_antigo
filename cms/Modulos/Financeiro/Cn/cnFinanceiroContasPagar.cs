using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;
using System.Data.Objects;
using System.Data;

namespace cms.Modulos.Financeiro.Cn
{
    public class cnFinanceiroContaPagar
    {
        private cmsEntities dbEntities = new cmsEntities();

        #region Financeiro Contas a Pagar

        public cnFinanceiroContaPagar()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<vw_financeiro_conta_pagar> FinanceiroContaPagarProcurar(long? id_conta_pagar, long? id_empresa, long? id_fornecedor, long? id_forma_pagamento, long? id_conta_corrente, string documento, DateTime? data_vencimento_de, DateTime? data_vencimento_ate, DateTime? data_pagamento_de, DateTime? data_pagamento_ate)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_financeiro_conta_pagar);
            var result = from c in dbEntities.vw_financeiro_conta_pagar
                         where c.excluido == false
                       select c;

            if (id_conta_pagar != null)
                result = result.Where(c => c.id_financeiro_conta_pagar == id_conta_pagar);

            if (id_empresa != null)
                result = result.Where(c => c.id_empresa == id_empresa);

            if (id_fornecedor != null)
                result = result.Where(c => c.id_fornecedor == id_fornecedor);

            if (id_forma_pagamento != null)
                result = result.Where(c => c.id_financeiro_forma_pagamento == id_forma_pagamento);

            if (id_conta_corrente != null)
                result = result.Where(c => c.id_financeiro_conta_corrente == id_conta_corrente);

            if (!string.IsNullOrEmpty(documento))
                result = result.Where(c => c.documento.Contains(documento));

            if (data_vencimento_de != null)
            {
                DateTime data_de = Convert.ToDateTime(data_vencimento_de.Value.ToString("dd/MM/yyyy"));
                result = result.Where(c => c.data_vencimento >= data_de);
            }

            if (data_vencimento_ate != null)
            {
                DateTime data_ate = Convert.ToDateTime(data_vencimento_ate.Value.ToString("dd/MM/yyyy"));
                result = result.Where(c => c.data_vencimento <= data_ate);
            }

            if (data_pagamento_de != null)
            {
                DateTime data_de = Convert.ToDateTime(data_pagamento_de.Value.ToString("dd/MM/yyyy"));
                result = result.Where(c => c.data_pagamento <= data_de);
            }

            if (data_pagamento_ate != null)
            {
                DateTime data_ate = Convert.ToDateTime(data_pagamento_ate.Value.ToString("dd/MM/yyyy"));
                result = result.Where(c => c.data_pagamento <= data_ate);
            }

            return result;
        }

        public financeiro_conta_pagar GetFinanceiroContaPagarByID(long id_conta_pagar)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_conta_pagar);

            financeiro_conta_pagar IResult;

            IResult = (from c in dbEntities.financeiro_conta_pagar
                       where c.excluido == false &&
                       c.id_financeiro_conta_pagar == id_conta_pagar
                       select c).SingleOrDefault();

            return IResult;
        }

        public bool FinanceiroContaPagarCadastrar(ref financeiro_conta_pagar financeiro_conta_pagar)
        {
            try
            {
                financeiro_conta_pagar.id_financeiro_conta_pagar = cms.Modulos.Util.Util.sp_getcodigo(Referencia.financeiro_conta_pagar);
                dbEntities.AddTofinanceiro_conta_pagar(financeiro_conta_pagar);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FinanceiroContaPagarEditar(ref financeiro_conta_pagar financeiro_conta_pagar)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("financeiro_conta_pagar", financeiro_conta_pagar);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, financeiro_conta_pagar);
                }
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FinanceiroContaPagarExcluir(financeiro_conta_pagar financeiro_conta_pagar)
        {
            try
            {
                financeiro_conta_pagar.excluido = true;

                EntityKey key = dbEntities.CreateEntityKey("financeiro_conta_pagar", financeiro_conta_pagar);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, financeiro_conta_pagar);
                }

                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        
        #endregion

    }
}
