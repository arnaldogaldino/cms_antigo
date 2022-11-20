using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;

namespace cms.Modulos.Financeiro.Cn
{
    public class cnFinanceiroContaReceber
    {
        private cmsEntities dbEntities = new cmsEntities();

        #region Financeiro Contas a Receber

        public cnFinanceiroContaReceber()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<vw_financeiro_conta_receber> FinanceiroContaReceberProcurar(long? id_conta_receber, long? id_empresa, long? id_cliente, long? id_forma_pagamento, long? id_conta_corrente, string documento, DateTime? data_vencimento_de, DateTime? data_vencimento_ate, DateTime? data_pagamento_de, DateTime? data_pagamento_ate)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_financeiro_conta_pagar);
            var result = from c in dbEntities.vw_financeiro_conta_receber
                         select c;

            if (id_conta_receber != null)
                result = result.Where(c => c.id_financeiro_conta_receber == id_conta_receber);
            
            if (id_empresa != null)
                result = result.Where(c => c.id_empresa == id_empresa);
            
            if (id_cliente != null)
                result = result.Where(c => c.id_cliente == id_cliente);

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

        public financeiro_conta_receber GetFinanceiroContaReceberByID(long id_conta_receber)
        {
            financeiro_conta_receber IResult;

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_conta_receber);

            IResult = (from c in dbEntities.financeiro_conta_receber
                       where c.excluido == false &&
                       c.id_financeiro_conta_receber == id_conta_receber
                       select c).SingleOrDefault();

            return IResult;
        }

        public IQueryable<financeiro_conta_receber> GetFinanceiroContaReceberByIDs(long[] id_conta_receber)
        {
            IQueryable<financeiro_conta_receber> IResult;

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_conta_receber);

            IResult = from c in dbEntities.financeiro_conta_receber
                       where c.excluido == false && id_conta_receber.Contains(c.id_financeiro_conta_receber)
                       select c;

            return IResult;
        }
        
        public bool FinanceiroContaReceberCadastrar(ref financeiro_conta_receber financeiro_conta_receber)
        {
            try
            {
                financeiro_conta_receber.id_financeiro_conta_receber = cms.Modulos.Util.Util.sp_getcodigo(Referencia.financeiro_conta_receber);
                dbEntities.AddTofinanceiro_conta_receber(financeiro_conta_receber);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FinanceiroContaReceberEditar(ref financeiro_conta_receber financeiro_conta_receber)
        {
            try
            {
                dbEntities.financeiro_conta_receber.ApplyCurrentValues(financeiro_conta_receber);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FinanceiroContaReceberExcluir(financeiro_conta_receber financeiro_conta_receber)
        {
            try
            {
                dbEntities.financeiro_conta_receber.DeleteObject(financeiro_conta_receber);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        #endregion

    }
}
