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

namespace cms.Modulos.Compra.Cn
{
    public class cnCompra
    {
        private cmsEntities dbEntities = new cmsEntities();
        
        public cnCompra()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable CompraProcurar(long? id_compra, long? id_fornecedor, string status, DateTime? data_cadastro_de, DateTime? data_cadastro_ate, DateTime? data_previsao_de, DateTime? data_previsao_ate, DateTime? data_recebimento_de, DateTime? data_recebimento_ate)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.compra);

            IQueryable<vw_compra> compras = from c in dbEntities.vw_compra
                                         where c.excluido == false
                                         select c;
            
            if (id_compra != null)
                compras = compras.Where(c => c.id_compra == id_compra);

            if (id_fornecedor != null)
                compras = compras.Where(c => c.id_fornecedor == id_fornecedor);

            if (!string.IsNullOrEmpty(status))
                compras = compras.Where(c => c.status == status);
    
            if (data_cadastro_de != null)
            {
                DateTime data_de = Convert.ToDateTime(data_cadastro_de.Value.ToString("dd/MM/yyyy"));
                compras = compras.Where(c => c.data_cadastro >= data_de);
            }

            if (data_cadastro_ate != null)
            {
                DateTime data_ate = Convert.ToDateTime(data_cadastro_ate.Value.ToString("dd/MM/yyyy"));
                compras = compras.Where(c => c.data_cadastro <= data_ate);
            }

            if (data_previsao_de != null)
            {
                DateTime data_de = Convert.ToDateTime(data_previsao_de.Value.ToString("dd/MM/yyyy"));
                compras = compras.Where(c => c.data_previsao >= data_de);
            }

            if (data_previsao_ate != null)
            {
                DateTime data_ate = Convert.ToDateTime(data_previsao_ate.Value.ToString("dd/MM/yyyy"));
                compras = compras.Where(c => c.data_previsao <= data_ate);
            }

            if (data_recebimento_de != null)
            {
                DateTime data_de = Convert.ToDateTime(data_recebimento_de.Value.ToString("dd/MM/yyyy"));
                compras = compras.Where(c => c.data_recebimento >= data_de);
            }

            if (data_recebimento_ate != null)
            {
                DateTime data_ate = Convert.ToDateTime(data_recebimento_ate.Value.ToString("dd/MM/yyyy"));
                compras = compras.Where(c => c.data_recebimento <= data_ate);
            }


            IQueryable result = (from e in compras
                    select new { e.id_compra, e.id_fornecedor, e.nome_fantasia, e.data_cadastro, e.data_previsao, e.data_recebimento, e.status, valor_total = (status=="Pendente" ? e.valor_total_recebido : e.valor_total_solicitado) }).AsQueryable();

            return result;
        }
        
        #region # Compra #
        public compra GetCompraByID(long id_compra)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.compra);

            compra result = (from c in dbEntities.compra
                            where c.excluido == false && c.id_compra == id_compra
                            select c).SingleOrDefault();

            return result;
        }
        public bool CompraCadastrar(ref compra oCompra)
        {
            try
            {
                oCompra.id_compra = cms.Modulos.Util.Util.sp_getcodigo(Referencia.compra);
                oCompra.data_cadastro = Util.Util.GetDataServidor();
                dbEntities.AddTocompra(oCompra);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        public bool CompraEditar(ref compra oCompra)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("compra", oCompra);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, oCompra);
                }
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        #endregion

        #region # Compra Itens #
        public void CompraItensCadastrar(long id_compra, List<long> lId_produto)
        {
            List<compra_item> itens = new List<compra_item>();

            foreach (var p in lId_produto)
            {
                var item = new compra_item();

                item.id_compra_item = cms.Modulos.Util.Util.sp_getcodigo(Referencia.compra_item);
                item.id_compra = id_compra;
                item.id_produto = p;

                item.quantidade_recebida = 0;
                item.quantidade_solicitada = 0;
                item.valor_desconto = 0;
                item.valor_unitario = 0;

                if (!ProdutoExistItem(id_compra, p))
                {
                    dbEntities.AddTocompra_item(item);
                    dbEntities.SaveChanges();
                }
            }            
        }
        public void CompraItensExcluir(List<long> itens)
        {
            foreach (var i in itens)
            {
                var item = (from c in dbEntities.compra_item
                           where c.id_compra_item == i
                           select c).SingleOrDefault();
                
                if(item != null)
                    dbEntities.compra_item.DeleteObject(item);
            }
            dbEntities.SaveChanges();
        }
        public IQueryable<vw_compra_item> GetCompraItemByIdCompra(long id_compra)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_compra_item);

            IQueryable<vw_compra_item> result;

            result = from c in dbEntities.vw_compra_item
                    where c.id_compra == id_compra
                    orderby c.conferido ascending, c.id_compra_item descending
                    select c;

            return result;
        }
        public bool ProdutoExistItem(long id_compra, long id_produto)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.compra_item);
            bool result = false;

            var item = (from i in dbEntities.compra_item
                       where i.id_compra == id_compra && i.id_produto == id_produto
                       select i).SingleOrDefault();

            if (item != null)
                result = true;

            return result;
        }
        public bool CompraItemEditar(List<compra_item> itens)
        {
            try
            {
                foreach (var item in itens)
                {
                    EntityKey key = dbEntities.CreateEntityKey("compra_item", item);
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
        
        public bool CompraItemEditar(compra_item item)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("compra_item", item);
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

        public bool CompraItemCopiar(long id_compra_old, long id_compra)
        {
            var itens = from i in dbEntities.compra_item
                        where i.id_compra == id_compra_old
                        select i;

            try
            {
                foreach (var i in itens)
                {
                    var item = new compra_item();

                    item.id_compra_item = cms.Modulos.Util.Util.sp_getcodigo(Referencia.compra_item);
                    item.id_compra = id_compra;
                    item.id_produto = i.id_produto;

                    item.quantidade_recebida = 0;
                    item.quantidade_solicitada = 0;
                    item.valor_desconto = 0;
                    item.valor_unitario = 0;

                    if (!ProdutoExistItem(id_compra, item.id_produto))
                        dbEntities.AddTocompra_item(item);
                }
            }
            catch { return false; }
            
            dbEntities.SaveChanges();
            
            return true;
        }

        public vw_compra_item GetCompraItemByCodigoBarras(long id_compra, string codigo_barras)
        {
            vw_compra_item result = new vw_compra_item();

            long id_produto = 0;

            long.TryParse(codigo_barras, out id_produto);
                        
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_compra_item);

            result = (from ci in dbEntities.vw_compra_item
                      where ci.id_compra == id_compra
                       join c in dbEntities.vw_compra on ci.id_compra equals c.id_compra into cj
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
        public compra_item GetCompraItemByIdCompraItem(long id_compra_item)
        {
            compra_item item = new compra_item();

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.compra_item);

            item = (from i in dbEntities.compra_item
                    where i.id_compra_item == id_compra_item
                    select i).SingleOrDefault();

            return item;
        }

        public IQueryable<vw_compra_item> GetCompraItemConferidoByIdCompra(long id_compra)
        {
            IQueryable<vw_compra_item> result;

            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.vw_compra_item);
            
            result = from i in dbEntities.vw_compra_item
                    where i.id_compra == id_compra &&
                          i.conferido == true
                  orderby i.data_conferencia ascending
                   select i;

            return result;
        }

        public decimal GetUltimoPreco(long id_compra, long id_produto)
        {
            decimal result = 0;

            try
            {
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.compra_item);
                
                var res = (from i in dbEntities.compra_item
                           join c in dbEntities.compra on i.compra equals c
                          where c.id_compra < id_compra &&
                                c.status == "Finalizada"
                        orderby i.id_compra_item ascending
                   select new { resultado = i.valor_unitario - i.valor_desconto }).Take(1).SingleOrDefault().resultado;

                result = res;
            }
            catch { result = 0; }

            return result;
        }
        #endregion

        #region # Compra Pagamentos #
        public bool CompraPagamentoCadastrar(compra_pagamento pagamento)
        {
            pagamento.id_compra_pagamento = cms.Modulos.Util.Util.sp_getcodigo(Referencia.compra_pagamento);
            try
            {
                pagamento.id_compra_pagamento = cms.Modulos.Util.Util.sp_getcodigo(Referencia.compra_pagamento);
                dbEntities.AddTocompra_pagamento(pagamento);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        public bool CompraPagamentoEditar(ref compra_pagamento pagamento)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("compra_pagamento", pagamento);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, pagamento);
                }
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        public bool CompraPagamentoExcluir(ref compra_pagamento pagamento)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("compra_pagamento", pagamento);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, pagamento);
                }

                dbEntities.compra_pagamento.DeleteObject(pagamento);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public IQueryable<compra_pagamento> GetCompraPagamentoIdCompra(long id_compra)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.compra_pagamento);

            IQueryable<compra_pagamento> pagamentos = from c in dbEntities.compra_pagamento
                                                      where c.id_compra == id_compra
                                                     select c;

            return pagamentos;
        }

        public void CompraPagamentoLimparByIdCompra(long id_compra)
        {
            var pagamentos = GetCompraPagamentoIdCompra(id_compra);

            foreach(var p in pagamentos)
            {
                dbEntities.compra_pagamento.DeleteObject(p);
            }

            dbEntities.SaveChanges();
        }
        #endregion

        #region # Arquivo XML #
        public void ArquivoCadastrar(compra_xml arquivo)
        {
            try
            {
                var arquivo_old = (from a in dbEntities.compra_xml
                                  where a.id_compra == arquivo.id_compra
                                   select a).SingleOrDefault();

                try
                {
                    dbEntities.compra_xml.DeleteObject(arquivo_old);
                    dbEntities.SaveChanges();
                }
                catch { }

                dbEntities.AddTocompra_xml(arquivo);
                dbEntities.SaveChanges();
            }
            catch { }
        }
        public compra_xml GetArquivoXML(long id_compra)
        {
            compra_xml result = (from i in dbEntities.compra_xml
                                 where i.id_compra == id_compra
                                 select i).SingleOrDefault();

            return result;
        }
        #endregion


    }
}
