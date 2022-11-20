using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;
using System.Data;

namespace cms.Modulos.Financeiro.Cn
{
    public class cnFinanceiroLancamento
    {
        private cmsEntities dbEntities = new cmsEntities();

        public cnFinanceiroLancamento()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<vw_financeiro_lancamento> FinanceiroLancamentoProcurar(long? id_lancamento, long? id_empresa, long? id_cliente, long? id_fornecedor, long? id_conta_corrente, long? id_financeiro_conta_pagar, long? id_financeiro_conta_receber, string documento, string descricao, DateTime? data_lancamento_de, DateTime? data_lancamento_ate, DateTime? data_conciliacao_de, DateTime? data_conciliacao_ate)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_financeiro_lancamento);
            IQueryable<vw_financeiro_lancamento> result = from l in dbEntities.vw_financeiro_lancamento
                                                          where l.excluido == false
                                                          orderby l.data_lancamento
                                                          select l;

            if (id_lancamento != null)
                result = result.Where(l => l.id_financeiro_lancamento == id_lancamento);

            if (id_empresa != null)
                result = result.Where(l => l.id_empresa == id_empresa);

            if (id_cliente != null)
                result = result.Where(l => l.id_cliente == id_cliente);

            if (id_fornecedor != null)
                result = result.Where(l => l.id_fornecedor == id_fornecedor);

            if (id_conta_corrente != null)
                result = result.Where(l => l.id_financeiro_conta_corrente == id_conta_corrente);

            if (!string.IsNullOrEmpty(documento))
                result = result.Where(l => l.documento == documento);

            if (!string.IsNullOrEmpty(descricao))
                result = result.Where(l => l.descricao == descricao);

            if (data_lancamento_de != null)
            {
                DateTime data_de = Convert.ToDateTime(data_lancamento_de.Value.ToString("dd/MM/yyyy"));
                result = result.Where(l => l.data_lancamento >= data_de);
            }
            if (data_lancamento_ate != null)
            {
                DateTime data_ate = Convert.ToDateTime(data_lancamento_ate.Value.ToString("dd/MM/yyyy"));
                result = result.Where(l => l.data_lancamento <= data_ate);
            }
            if (data_conciliacao_de != null)
            {
                DateTime data_de = Convert.ToDateTime(data_conciliacao_de.Value.ToString("dd/MM/yyyy"));
                result = result.Where(l => l.data_conciliado >= data_de);
            }
            if (data_conciliacao_ate != null)
            {
                DateTime data_ate = Convert.ToDateTime(data_conciliacao_ate.Value.ToString("dd/MM/yyyy"));
                result = result.Where(l => l.data_conciliado <= data_ate);
            }

            if (id_financeiro_conta_pagar != null)
                result = result.Where(l => l.id_financeiro_conta_pagar == id_financeiro_conta_pagar);

            if (id_financeiro_conta_receber != null)
                result = result.Where(l => l.id_financeiro_conta_receber == id_financeiro_conta_receber);

            return result;
        }
        
        public bool LancarContasPagar(ref financeiro_conta_pagar daoContasPagar)
        {
            try
            {
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_lancamento);
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_conta_pagar);

                financeiro_lancamento daoLancamento = new financeiro_lancamento();
                
                daoLancamento.id_empresa = daoContasPagar.id_empresa;
                daoLancamento.data_lancamento = Util.Util.GetDataServidor();
                daoLancamento.data_conciliado = daoContasPagar.data_pagamento.Value;
                daoLancamento.descricao = daoContasPagar.descricao;
                daoLancamento.documento = daoContasPagar.documento;
                daoLancamento.valor_credito = 0;
                daoLancamento.valor_debito = daoContasPagar.valor_pagamento.Value;

                if (daoContasPagar.id_financeiro_conta_corrente != null)
                    daoLancamento.id_financeiro_conta_corrente = daoContasPagar.id_financeiro_conta_corrente.Value;

                daoLancamento.id_financeiro_conta_pagar = daoContasPagar.id_financeiro_conta_pagar;

                daoLancamento.id_financeiro_lancamento = cms.Modulos.Util.Util.sp_getcodigo(Referencia.financeiro_lancamento);

                dbEntities.AddTofinanceiro_lancamento(daoLancamento);
                dbEntities.SaveChanges();
                cms.Modulos.Util.Util.sp_financeiro_lancamento_atualizar_saldo(daoLancamento.id_financeiro_conta_corrente, daoLancamento.data_lancamento);
            }
            catch { throw; }

            return true;
        }
        public bool LancarContasReceber(ref financeiro_conta_receber daoContasReceber)
        {
            try
            {
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_lancamento);
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_conta_receber);

                financeiro_lancamento daoLancamento = new financeiro_lancamento();
                
                daoLancamento.id_empresa = daoContasReceber.id_empresa;
                daoLancamento.data_lancamento = Util.Util.GetDataServidor();
                daoLancamento.data_conciliado = daoContasReceber.data_pagamento.Value;
                daoLancamento.descricao = daoContasReceber.descricao;
                daoLancamento.documento = daoContasReceber.documento;
                daoLancamento.valor_credito = daoContasReceber.valor_pagamento.Value;
                daoLancamento.valor_debito = 0;
                daoLancamento.id_financeiro_conta_corrente = daoContasReceber.id_financeiro_conta_corrente.Value;
                daoLancamento.id_financeiro_conta_receber = daoContasReceber.id_financeiro_conta_receber;

                daoLancamento.id_financeiro_lancamento = cms.Modulos.Util.Util.sp_getcodigo(Referencia.financeiro_lancamento);

                dbEntities.AddTofinanceiro_lancamento(daoLancamento);
                dbEntities.SaveChanges();
                cms.Modulos.Util.Util.sp_financeiro_lancamento_atualizar_saldo(daoLancamento.id_financeiro_conta_corrente, daoLancamento.data_lancamento);
            }
            catch { throw; }

            return true;
        }

        public bool EstornarContasPagar(ref financeiro_conta_pagar daoContasPagar)
        {
            try
            {
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_lancamento);
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_conta_pagar);

                financeiro_lancamento lancamento = GetLancamentoById_contas_pagar(daoContasPagar.id_financeiro_conta_pagar).SingleOrDefault();
                
                daoContasPagar.data_lancamento = null;
                dbEntities.financeiro_conta_pagar.ApplyCurrentValues(daoContasPagar);
                
                long id_conta_corrente = lancamento.id_financeiro_conta_corrente;
                DateTime data_lancamento = lancamento.data_lancamento;




                EntityKey key = dbEntities.CreateEntityKey("financeiro_lancamento", lancamento);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, lancamento);
                }


                daoContasPagar.data_lancamento = null;

                EntityKey key1 = dbEntities.CreateEntityKey("financeiro_conta_pagar", daoContasPagar);
                object originalItem1;

                if (dbEntities.TryGetObjectByKey(key1, out originalItem1))
                {
                    dbEntities.ApplyCurrentValues(key1.EntitySetName, daoContasPagar);
                }

                

                dbEntities.ExecuteStoreCommand("DELETE FROM [dbo].[financeiro_lancamento] WHERE ([id_financeiro_lancamento] = {0})", lancamento.id_financeiro_lancamento);
                dbEntities.SaveChanges();
                cms.Modulos.Util.Util.sp_financeiro_lancamento_atualizar_saldo(id_conta_corrente, data_lancamento);
            }
            catch { }
            
            return true;
        }
        public bool EstornarContasReceber(ref financeiro_conta_receber daoContasReceber)
        {
            try
            {
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_lancamento);
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_conta_receber);
                
                daoContasReceber.data_lancamento = null;
                financeiro_lancamento lancamento = GetLancamentoById_contas_receber(daoContasReceber.id_financeiro_conta_receber).Single();


                long id_conta_corrente = lancamento.id_financeiro_conta_corrente;
                DateTime data_lancamento = lancamento.data_lancamento;

                
                EntityKey key = dbEntities.CreateEntityKey("financeiro_lancamento", lancamento);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, lancamento);
                }


                daoContasReceber.data_lancamento = null;

                EntityKey key1 = dbEntities.CreateEntityKey("financeiro_conta_receber", daoContasReceber);
                object originalItem1;

                if (dbEntities.TryGetObjectByKey(key1, out originalItem1))
                {
                    dbEntities.ApplyCurrentValues(key1.EntitySetName, daoContasReceber);
                }
                

                dbEntities.ExecuteStoreCommand("DELETE FROM [dbo].[financeiro_lancamento] WHERE ([id_financeiro_lancamento] = {0})", lancamento.id_financeiro_lancamento);
                dbEntities.SaveChanges();
                cms.Modulos.Util.Util.sp_financeiro_lancamento_atualizar_saldo(id_conta_corrente, data_lancamento);
            }
            catch { }
            
            return true;
        }

        public financeiro_lancamento GetLancamentoById_lancamento(long id_lancamento)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_lancamento);
            var result = (from l in dbEntities.financeiro_lancamento
                         where l.id_financeiro_lancamento == id_lancamento
                         select l).SingleOrDefault();

            return result;
        }
        public IQueryable<financeiro_lancamento> GetLancamentoById_contas_pagar(long id_contas_pagar)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_lancamento);
            var result = from c in dbEntities.financeiro_lancamento
                        where c.excluido == false && c.id_financeiro_conta_pagar == id_contas_pagar
                        select c;

            return result;
        }
        public IQueryable<financeiro_lancamento> GetLancamentoById_contas_receber(long id_contas_receber)
        {            
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_lancamento);
            var result = from l in dbEntities.financeiro_lancamento
                         where l.excluido == false && l.id_financeiro_conta_receber == id_contas_receber
                         select l;

            return result;
        }
        
        public financeiro_lancamento GetFinanceiroLancamentoByID(long id_lancamento)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.financeiro_lancamento);
            financeiro_lancamento result = (from i in dbEntities.financeiro_lancamento
                       where i.id_financeiro_lancamento == id_lancamento
                       select i).SingleOrDefault();

            return result;
        }

        public bool FinanceiroLancamentoCadastrar(ref financeiro_lancamento financeiro_financeiro_lancamento)
        {
            try
            {
                financeiro_financeiro_lancamento.id_financeiro_lancamento = cms.Modulos.Util.Util.sp_getcodigo(Referencia.financeiro_lancamento);
                dbEntities.AddTofinanceiro_lancamento(financeiro_financeiro_lancamento);
                dbEntities.SaveChanges();
                cms.Modulos.Util.Util.sp_financeiro_lancamento_atualizar_saldo(financeiro_financeiro_lancamento.id_financeiro_conta_corrente, financeiro_financeiro_lancamento.data_lancamento);
            }
            catch { return false; }

            return true;
        }

        public bool FinanceiroLancamentoEditar(ref financeiro_lancamento financeiro_financeiro_lancamento)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("financeiro_financeiro_lancamento", financeiro_financeiro_lancamento);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, financeiro_financeiro_lancamento);
                }
                dbEntities.SaveChanges();
                cms.Modulos.Util.Util.sp_financeiro_lancamento_atualizar_saldo(financeiro_financeiro_lancamento.id_financeiro_conta_corrente, financeiro_financeiro_lancamento.data_lancamento);
            }
            catch { return false; }

            return true;
        }

        public bool FinanceiroLancamentoExcluir(financeiro_lancamento financeiro_financeiro_lancamento)
        {
            try
            {
                financeiro_financeiro_lancamento.excluido = true;

                EntityKey key = dbEntities.CreateEntityKey("financeiro_financeiro_lancamento", financeiro_financeiro_lancamento);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, financeiro_financeiro_lancamento);
                }
                dbEntities.SaveChanges();
                cms.Modulos.Util.Util.sp_financeiro_lancamento_atualizar_saldo(financeiro_financeiro_lancamento.id_financeiro_conta_corrente, financeiro_financeiro_lancamento.data_lancamento);
            }
            catch { return false; }

            return true;
        }
        
    }
}
