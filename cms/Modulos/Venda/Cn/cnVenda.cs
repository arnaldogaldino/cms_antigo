using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Data;
using System.Data.EntityClient;
using System.Data;
using System.Data.SqlClient;
using System.Data.Objects;
using System.Data.Objects.SqlClient;
using cms.Modulos.Util;
using System.Data.Linq.SqlClient;

namespace cms.Modulos.Venda.Cn
{
    public class cnVenda
    {
        private cmsEntities dbEntities = new cmsEntities();

        public cnVenda()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<vw_venda> VendaProcurar(long? id_venda, long? id_cliente, string status, DateTime? data_cadastro_de, DateTime? data_cadastro_ate)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_venda);

            IQueryable<vw_venda> result = from v in dbEntities.vw_venda
                                          where v.excluido == false
                                          select v;

            if (id_venda != null)
                result = result.Where(v => v.id_venda == id_venda);

            if (id_cliente != null)
                result = result.Where(v => v.id_cliente == id_cliente);

            if (data_cadastro_de != null)
            {
                DateTime data_de = Convert.ToDateTime(data_cadastro_de.Value.ToString("dd/MM/yyyy"));
                result = result.Where(v => v.data_cadastro >= data_de);            
            }

            if (data_cadastro_ate != null)
            {
                DateTime data_ate = Convert.ToDateTime(data_cadastro_ate.Value.ToString("dd/MM/yyyy"));
                result = result.Where(v => v.data_cadastro <= data_ate);
            }

            return result;
        }

        public venda GetVendaByID(long id_venda)
        {
            venda result = new venda();

            try
            {
                result = (from v in dbEntities.venda
                         where v.excluido == false && v.id_venda==id_venda
                         select v).SingleOrDefault();
            }
            catch { }

            return result;
        }

        public bool VendaCadastrar(ref venda oVenda)
        {
            try
            {
                oVenda.id_venda = cms.Modulos.Util.Util.sp_getcodigo(Referencia.venda);
                dbEntities.AddTovenda(oVenda);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool VendaEditar(ref venda oVenda)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("venda", oVenda);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, oVenda);
                }
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        #region # Venda Pagamentos #
        public IQueryable<venda_pagamento> GetVendaPagamentoByIdVenda(long id_venda)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.venda_pagamento);

            IQueryable<venda_pagamento> result;

            result = from p in dbEntities.venda_pagamento
                    where p.id_venda == id_venda
                   select p;

            return result;
        }

        public void VendaPagamentoLimparByIdVenda(long id_venda)
        {
            var pagamentos = GetVendaPagamentoByIdVenda(id_venda);

            foreach (var p in pagamentos)
            {
                dbEntities.venda_pagamento.DeleteObject(p);
            }

            try
            {
                dbEntities.SaveChanges();
            }
            catch 
            {
                
            }
        }

        public void VendaPagamentoGravar(venda_pagamento oVendaPagamento)
        {
            try
            {
                oVendaPagamento.id_venda_pagamento = cms.Modulos.Util.Util.sp_getcodigo(Referencia.venda_pagamento);
                dbEntities.AddTovenda_pagamento(oVendaPagamento);
                dbEntities.SaveChanges();
            }
            catch { }
        }

        public void VendaPagmanetoEditar(venda_pagamento oVendaPagamento)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("venda_pagamento", oVendaPagamento);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, oVendaPagamento);
                }
                dbEntities.SaveChanges();
            }
            catch { }
        }
        #endregion
        
        #region # Venda Itens #
        public void VendaItensCadastrar(long id_venda, List<long> lId_produto)
        {
            foreach (var p in lId_produto)
            {
                var item = new venda_item();

                item.id_venda_item = cms.Modulos.Util.Util.sp_getcodigo(Referencia.venda_item);
                item.id_venda = id_venda;
                item.id_produto = p;

                item.quantidade_confirmada = 0;
                item.quantidade = 0;
                item.desconto = 0;
                item.valor_unitario = 0;

                if (!ProdutoExistItem(id_venda, p))
                    dbEntities.AddTovenda_item(item);
            }

            dbEntities.SaveChanges();
        }
        public void VendaItensExcluir(List<long> itens)
        {
            foreach (var i in itens)
            {
                var item = (from c in dbEntities.venda_item
                            where c.id_venda_item == i
                            select c).SingleOrDefault();

                if (item != null)
                    dbEntities.venda_item.DeleteObject(item);
            }
            dbEntities.SaveChanges();
        }
        public IQueryable<vw_venda_item> GetVendaItemByIdVenda(long id_venda)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_venda_item);

            IQueryable<vw_venda_item> result;

            result = from c in dbEntities.vw_venda_item
                     where c.id_venda == id_venda
                     orderby c.conferido ascending, c.id_venda_item descending
                     select c;

            return result;
        }
 
        public bool ProdutoExistItem(long id_venda, long id_produto)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.venda_item);
            bool result = false;

            var item = (from i in dbEntities.venda_item
                        where i.id_venda == id_venda && i.id_produto == id_produto
                        select i).SingleOrDefault();

            if (item != null)
                result = true;

            return result;
        }

        public bool VendaItemEditar(List<venda_item> itens)
        {
            try
            {
                foreach (var item in itens)
                {
                    EntityKey key = dbEntities.CreateEntityKey("venda_item", item);
                    object originalItem;

                    if (dbEntities.TryGetObjectByKey(key, out originalItem))
                    {
                        dbEntities.ApplyCurrentValues(key.EntitySetName, item);
                    }
                }

                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool VendaItemEditar(venda_item item)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("venda_item", item);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, item);
                }
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool VendaItemCopiar(long id_venda_old, long id_venda)
        {
            var itens = from i in dbEntities.venda_item
                        where i.id_venda == id_venda_old
                        select i;

            try
            {
                foreach (var i in itens)
                {
                    var item = new venda_item();

                    item.id_venda_item = cms.Modulos.Util.Util.sp_getcodigo(Referencia.venda_item);
                    item.id_venda = id_venda;
                    item.id_produto = i.id_produto;

                    item.quantidade_confirmada = 0;
                    item.quantidade = 0;
                    item.desconto = 0;
                    item.valor_unitario = 0;

                    if (!ProdutoExistItem(id_venda, item.id_produto))
                        dbEntities.AddTovenda_item(item);
                }
            }
            catch { return false; }

            dbEntities.SaveChanges();

            return true;
        }

        public vw_venda_item GetvendaItemByCodigoBarras(long id_venda, string codigo_barras)
        {
            vw_venda_item result = new vw_venda_item();

            long id_produto = 0;

            long.TryParse(codigo_barras, out id_produto);

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_venda_item);

            result = (from ci in dbEntities.vw_venda_item
                      where ci.id_venda == id_venda
                      join c in dbEntities.vw_venda on ci.id_venda equals c.id_venda into cj
                      from cf in cj.DefaultIfEmpty()
                      join p in dbEntities.produto on ci.id_produto equals p.id_produto into pj
                      from pf in pj.DefaultIfEmpty()
                      join e in dbEntities.produto_embalagem on ci.id_produto equals e.id_produto into ej
                      from ef in ej.DefaultIfEmpty()
                      where (pf.codigo_barra == codigo_barras || pf.codigo_barra_fornecedor == codigo_barras ||
                             pf.referencia_fabrica == codigo_barras || ef.codigo_barra == codigo_barras ||
                             ef.codigo_barra_fornecedor == codigo_barras || ef.referencia_fabrica == codigo_barras ||
                             pf.id_produto == id_produto)
                      select ci).Distinct().SingleOrDefault();

            return result;
        }
        public venda_item GetVendaItemByIdVendaItem(long id_venda_item)
        {
            venda_item item = new venda_item();

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.venda_item);

            item = (from i in dbEntities.venda_item
                    where i.id_venda_item == id_venda_item
                    select i).SingleOrDefault();

            return item;
        }

        public IQueryable<vw_venda_item> GetVendaItemConferidoByIdCompra(long id_venda)
        {
            IQueryable<vw_venda_item> result;

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_venda_item);

            result = from i in dbEntities.vw_venda_item
                     where i.id_venda == id_venda &&
                           i.conferido == true
                     orderby i.id_venda_item ascending
                     select i;

            return result;
        }

        public decimal GetUltimoPreco(long id_venda, long id_produto)
        {
            decimal result = 0;

            try
            {
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.venda_item);

                var res = (from i in dbEntities.venda_item
                           join c in dbEntities.venda on i.venda equals c
                           where c.id_venda < id_venda &&
                                 c.status == "Finalizada"
                           orderby i.id_venda_item ascending
                           select new { resultado = i.valor_unitario - i.desconto }).Take(1).SingleOrDefault().resultado;

                result = res;
            }
            catch { result = 0; }

            return result;
        }
        #endregion

        #region # Venda Aprovar Pedido #

        public bool VendaAprovar(long id_venda, long id_usuario)
        {
            venda venda_aprovar = GetVendaByID(id_venda);
            venda_aprovar.status = "Em Processamento";
            venda_aprovar.id_usuario_aprovacao = id_usuario;
            venda_aprovar.data_aprovacao = Util.Util.GetDataServidor();

            try
            {
                VendaEditar(ref venda_aprovar);
            }
            catch
            {
                return true;
            }
            
            return true;
        }

        public bool VendaCancelar(long id_venda, long id_usuario)
        {
            venda venda_cancelar = GetVendaByID(id_venda);
            venda_cancelar.status = "Cancelada";
            venda_cancelar.id_usuario_cancelado = id_usuario;
            venda_cancelar.data_cancelado = Util.Util.GetDataServidor();

            try
            {
                VendaEditar(ref venda_cancelar);
            }
            catch
            {
                return true;
            }

            return true;
        }
        #endregion

    }
}
