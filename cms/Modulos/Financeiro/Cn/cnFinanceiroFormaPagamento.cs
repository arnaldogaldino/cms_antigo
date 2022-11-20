using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;

namespace cms.Modulos.Financeiro.Cn
{
    public class cnFinanceiroFormaPagamento
    {
        private cmsEntities dbEntities = new cmsEntities();

        #region Financeiro Forma de Pagamento

        public cnFinanceiroFormaPagamento()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<financeiro_forma_pagamento> FinanceiroFormaPagamentoProcurar()
        {
            IQueryable<financeiro_forma_pagamento> IResult;

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_forma_pagamento);

            IResult = from i in dbEntities.financeiro_forma_pagamento
                      orderby i.id_financeiro_plano_conta, i.nome ascending
                      select i;

            return IResult;
        }

        public financeiro_forma_pagamento GetFinanceiroFormaPagamentoByID(long id_forma_pagamento)
        {
            financeiro_forma_pagamento IResult;

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_forma_pagamento);

            IResult = (from i in dbEntities.financeiro_forma_pagamento
                       where i.id_financeiro_forma_pagamento == id_forma_pagamento
                      select i).SingleOrDefault();

            return IResult;
        }

        public bool FinanceiroFormaPagamentoCadastrar(ref financeiro_forma_pagamento financeiro_forma_pagamento)
        {
            try
            {
                financeiro_forma_pagamento.id_financeiro_forma_pagamento = cms.Modulos.Util.Util.sp_getcodigo(Referencia.financeiro_forma_pagamento);
                dbEntities.AddTofinanceiro_forma_pagamento(financeiro_forma_pagamento);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FinanceiroFormaPagamentoEditar(ref financeiro_forma_pagamento financeiro_forma_pagamento)
        {
            try
            {
                dbEntities.financeiro_forma_pagamento.ApplyCurrentValues(financeiro_forma_pagamento);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FinanceiroFormaPagamentoExcluir(financeiro_forma_pagamento financeiro_forma_pagamento)
        {
            try
            {
                dbEntities.financeiro_forma_pagamento.DeleteObject(financeiro_forma_pagamento);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        
        #endregion

    }
}
