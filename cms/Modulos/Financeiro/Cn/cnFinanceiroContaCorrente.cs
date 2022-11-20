using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;

namespace cms.Modulos.Financeiro.Cn
{
    public class cnFinanceiroContaCorrente
    {
        private cmsEntities dbEntities = new cmsEntities();

        #region Financeiro Conta Corrente

        public cnFinanceiroContaCorrente()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<vw_financeiro_conta_corrente> FinanceiroContaCorrenteProcurar(long id_empresa)
        {
            IQueryable<vw_financeiro_conta_corrente> IResult;

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_financeiro_conta_corrente);

            IResult = from c in dbEntities.vw_financeiro_conta_corrente
                      where c.id_empresa == id_empresa && c.excluido == false
                      orderby c.banco ascending
                      select c;           

            return IResult;
        }

        public IQueryable<financeiro_banco> GetBanco()
        {
            IQueryable<financeiro_banco> IResult;

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_banco);

            IResult = from c in dbEntities.financeiro_banco
                      orderby c.nome ascending
                      select c;

            return IResult;
        }

        public financeiro_conta_corrente GetFinanceiroContaCorrenteByID(long id_conta_corrente)
        {
            financeiro_conta_corrente IResult;

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_conta_corrente);

            IResult = (from i in dbEntities.financeiro_conta_corrente
                       where i.id_financeiro_conta_corrente == id_conta_corrente
                      select i).SingleOrDefault();

            return IResult;
        }
        public financeiro_banco GetFinanceiroBancoByID(long id_financeiro_banco)
        {
            financeiro_banco IResult;

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_banco);

            IResult = (from i in dbEntities.financeiro_banco
                       where i.id_financeiro_banco == id_financeiro_banco
                       select i).SingleOrDefault();

            return IResult;
        }

        public bool FinanceiroContaCorrenteCadastrar(ref financeiro_conta_corrente financeiro_conta_corrente)
        {
            try
            {
                financeiro_conta_corrente.id_financeiro_conta_corrente = cms.Modulos.Util.Util.sp_getcodigo(Referencia.financeiro_conta_corrente);
                dbEntities.AddTofinanceiro_conta_corrente(financeiro_conta_corrente);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FinanceiroContaCorrenteEditar(ref financeiro_conta_corrente financeiro_conta_corrente)
        {
            try
            {
                dbEntities.financeiro_conta_corrente.ApplyCurrentValues(financeiro_conta_corrente);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FinanceiroContaCorrenteExcluir(financeiro_conta_corrente financeiro_conta_corrente)
        {
            try
            {
                dbEntities.financeiro_conta_corrente.DeleteObject(financeiro_conta_corrente);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        #endregion

    }
}
