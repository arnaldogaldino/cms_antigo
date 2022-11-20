using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Data;
using cms.Modulos.Util;
using System.Data;

namespace cms.Modulos.Financeiro.Cn
{
    public class cnFinanceiroCondicaoPagamento
    {

        private cmsEntities dbEntities = new cmsEntities();

        public cnFinanceiroCondicaoPagamento()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public bool FinanceiroCondicaoPagamentoCadastrar(ref financeiro_condicao_pagamento financeiro_condicao_pagamento)
        {
            try
            {
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_condicao_pagamento);

                financeiro_condicao_pagamento.id_financeiro_condicao_pagamento = cms.Modulos.Util.Util.sp_getcodigo(Referencia.financeiro_condicao_pagamento);
                dbEntities.AddTofinanceiro_condicao_pagamento(financeiro_condicao_pagamento);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FinanceiroCondicaoPagamentoEditar(ref financeiro_condicao_pagamento financeiro_condicao_pagamento)
        {
            try
            {
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_condicao_pagamento);

                EntityKey key = dbEntities.CreateEntityKey("financeiro_condicao_pagamento", financeiro_condicao_pagamento);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, financeiro_condicao_pagamento);
                }
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FinanceiroCondicaoPagamentoExcluir(financeiro_condicao_pagamento financeiro_condicao_pagamento)
        {
            try
            {
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_condicao_pagamento);

                financeiro_condicao_pagamento.excluido = false;

                EntityKey key = dbEntities.CreateEntityKey("financeiro_condicao_pagamento", financeiro_condicao_pagamento);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {                    
                    dbEntities.ApplyCurrentValues(key.EntitySetName, financeiro_condicao_pagamento);
                }
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        
        public bool FinanceiroCondicaoPagamentoParcelaCadastrar(ref financeiro_condicao_pagamento_parcela financeiro_condicao_pagamento_parcela)
        {
            try
            {
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_condicao_pagamento_parcela);

                financeiro_condicao_pagamento_parcela.id_financeiro_condicao_pagamento_parcela = cms.Modulos.Util.Util.sp_getcodigo(Referencia.financeiro_condicao_pagamento_parcela);
                dbEntities.AddTofinanceiro_condicao_pagamento_parcela(financeiro_condicao_pagamento_parcela);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public void FinanceiroCondicaoPagamentoParcelaExcluir(financeiro_condicao_pagamento financeiro_condicao_pagamento)
        {
            try
            {
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_condicao_pagamento_parcela);

                var parcelas = financeiro_condicao_pagamento.financeiro_condicao_pagamento_parcela.ToList();
                for (int i = 0; i < parcelas.Count; i++)
                {
                    dbEntities.financeiro_condicao_pagamento_parcela.DeleteObject(parcelas[i]);
                }

                dbEntities.SaveChanges();
            }
            catch { }
        }
        
        public IQueryable<financeiro_condicao_pagamento> FinanceiroCondicaoPagamentoProcurar()
        {
            IQueryable<financeiro_condicao_pagamento> IResult;

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_condicao_pagamento);

            IResult = from i in dbEntities.financeiro_condicao_pagamento
                      where i.excluido == false
                      orderby i.quantidade_parcelas, i.descricao ascending
                      select i;

            return IResult;
        }

        public financeiro_condicao_pagamento GetFinanceiroCondicaoPagamentoByID(long id_financeiro_condicao_pagamento)
        {
            financeiro_condicao_pagamento IResult;

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_condicao_pagamento);

            IResult = (from i in dbEntities.financeiro_condicao_pagamento
                       where i.id_financeiro_condicao_pagamento == id_financeiro_condicao_pagamento
                       select i).SingleOrDefault();

            return IResult;
        }

    }
}
