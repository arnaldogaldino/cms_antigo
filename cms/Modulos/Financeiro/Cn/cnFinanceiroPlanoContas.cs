using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;

namespace cms.Modulos.Financeiro.Cn
{
    public class cnFinanceiroPlanoConta
    {
        private cmsEntities dbEntities = new cmsEntities();

        #region Plano de Contas
        public cnFinanceiroPlanoConta()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<vw_financeiro_plano_conta> FinanceiroPlanoContasProcurar(string descricao, cms.Modulos.Util.TipoPlanoConta tipo)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_financeiro_plano_conta);
            IQueryable<vw_financeiro_plano_conta> result = from p in dbEntities.vw_financeiro_plano_conta
                                                           where p.excluido == false
                                                           orderby p.plano_conta
                                                           select p;

            if (!string.IsNullOrEmpty(descricao))
                result = result.Where(e => e.descricao.Contains(descricao));

            if(tipo == TipoPlanoConta.Entrada)
                result = result.Where(e => e.plano_conta.StartsWith("1."));

            if (tipo == TipoPlanoConta.Saida)
                result = result.Where(e => e.plano_conta.StartsWith("2."));

            return result;
        }

        public IQueryable<financeiro_plano_conta> FinanceiroPlanoContasProcurar(string descricao)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_plano_conta);

            IQueryable<financeiro_plano_conta> result = from p in dbEntities.financeiro_plano_conta
                                                        where p.excluido == false
                                                        orderby p.plano_conta
                                                        select p;

            if (!string.IsNullOrEmpty(descricao))
                result = result.Where(p => p.descricao.Contains(descricao));

            return result;
        }

        public vw_financeiro_plano_conta GetVWFinanceiroPlanoContasByID(long id_financeiro_plano_conta)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_financeiro_plano_conta);
            var result = (from p in dbEntities.vw_financeiro_plano_conta
                          where p.excluido == false && p.id_financeiro_plano_conta == id_financeiro_plano_conta
                          select p).SingleOrDefault();

            return result;
        }

        public financeiro_plano_conta GetFinanceiroPlanoContasByID(long id_financeiro_plano_conta)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_plano_conta);
            var result = (from p in dbEntities.financeiro_plano_conta
                         where p.excluido == false && p.id_financeiro_plano_conta == id_financeiro_plano_conta
                         select p).SingleOrDefault();

            return result;
        }

        public bool FinanceiroPlanoContasCadastrar(ref financeiro_plano_conta financeiro_plano_conta)
        {
            try
            {
                financeiro_plano_conta.id_financeiro_plano_conta = cms.Modulos.Util.Util.sp_getcodigo(Referencia.financeiro_plano_conta);
                dbEntities.AddTofinanceiro_plano_conta(financeiro_plano_conta);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FinanceiroPlanoContasEditar(ref financeiro_plano_conta financeiro_plano_conta)
        {
            try
            {
                dbEntities.financeiro_plano_conta.ApplyCurrentValues(financeiro_plano_conta);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        
        #endregion

    }
}
