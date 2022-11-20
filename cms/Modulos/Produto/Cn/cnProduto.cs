using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;
using System.Data.EntityClient;
using System.Data;

namespace cms.Modulos.Produto.Cn
{
    public class cnProduto
    {
        private cmsEntities dbEntities = new cmsEntities();

        public cnProduto()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        #region # Produto #
        public produto GetProdutoByID(long id_produto)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto);
            produto result = (from p in dbEntities.produto
                              where p.excluido == false && p.id_produto == id_produto
                              select p).SingleOrDefault();

            return result;
        }
        public bool ProdutoCadastrar(ref produto pProduto)
        {
            try
            {
                pProduto.id_produto = cms.Modulos.Util.Util.sp_getcodigo(Referencia.produto);
                dbEntities.AddToproduto(pProduto);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true; 
        }
        public bool ProdutoEditar(ref produto pProduto)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("produto", pProduto);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, pProduto);
                }
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        public IQueryable<vw_produto> ProdutoProcurar(
            long? id_produto,
            long? id_produto_grupo,
            long? id_produto_subgrupo,
            long? id_produto_familia,
            long? id_produto_subfamilia,
            long? id_empresa,
            long? id_produto_preco_tabela,
            string descricao,
            string referencia,
            string codigo_barra,
            string codigo_barra_fornecedor)
        {
            IQueryable<vw_produto> result = from p in dbEntities.vw_produto
                                            select p;
            
            if(id_produto != null)
                result = result.Where(e => e.id_produto == id_produto);

            if (id_produto_grupo != null)
                result = result.Where(e => e.id_produto_grupo == id_produto_grupo);

            if (id_produto_subgrupo != null)
                result = result.Where(e => e.id_produto_subgrupo == id_produto_subgrupo);

            if (id_produto_familia != null)
                result = result.Where(e => e.id_produto_familia == id_produto_familia);

            if (id_produto_subfamilia != null)
                result = result.Where(e => e.id_produto_subfamilia == id_produto_subfamilia);

            if (id_empresa != null)
                result = result.Where(e => e.id_empresa == id_empresa);

            if (!string.IsNullOrEmpty(descricao))
                result = result.Where(e => e.descricao.Contains(descricao));

            if (!string.IsNullOrEmpty(codigo_barra))
                result = result.Where(e => e.codigo_barra.Contains(codigo_barra));

            if (!string.IsNullOrEmpty(codigo_barra_fornecedor))
                result = result.Where(e => e.codigo_barra_fornecedor.Contains(codigo_barra_fornecedor));

            if (!string.IsNullOrEmpty(referencia))
                result = result.Where(e => e.referencia_fabrica.Contains(referencia));

            if (id_produto_preco_tabela != null)
                result = result.Where(e => e.id_produto_preco_tabela == id_produto_preco_tabela);

            return result;
        }
        #endregion

        #region # Fiscal #
        public void ProdutoFiscalCadastrar(long id_produto, List<produto_ipi_icms> icms, List<produto_base_icms> base_icms)
        {
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto_ipi_icms);
                dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto_base_icms);

                var bases = from i in dbEntities.produto_base_icms
                           where i.id_produto == id_produto
                          select i;
                
                foreach(var i in bases)
                    dbEntities.produto_base_icms.DeleteObject(i);

                var icmss = from i in dbEntities.produto_ipi_icms
                            where i.id_produto == id_produto
                            select i;

                foreach (var i in icmss)
                    dbEntities.produto_ipi_icms.DeleteObject(i);

                dbEntities.SaveChanges();

                foreach(var i in icms)
                {
                    i.id_produto_icms = cms.Modulos.Util.Util.sp_getcodigo(Referencia.produto_base_icms);
                    dbEntities.AddToproduto_ipi_icms(i);
                }
                foreach(var i in base_icms)
                {
                    i.id_produto_base_icms = cms.Modulos.Util.Util.sp_getcodigo(Referencia.produto_base_icms);
                    dbEntities.AddToproduto_base_icms(i);
                }

                dbEntities.SaveChanges();
        }
        public IQueryable<produto_ipi_icms> GetProdutoIcmsByIdProduto(long id_produto)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto_ipi_icms);

            var result = from i in dbEntities.produto_ipi_icms
                         where i.id_produto == id_produto
                         orderby i.uf
                         select i;

            return result;
        }
        public IQueryable<produto_base_icms> GetProdutoBaseIcmsByIdProduto(long id_produto)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto_base_icms);

            var result = from i in dbEntities.produto_base_icms
                         where i.id_produto == id_produto
                         orderby i.uf
                         select i;

            return result;
        }
        #endregion

        #region # Estoque #
        public void ProdutoEstoqueCadastrar(long id_produto)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.empresa);
            
            var empresas = from e in dbEntities.empresa
                           select e;

            foreach (var e in empresas)
            {
                produto_estoque estoque = new produto_estoque();
                estoque.id_empresa = e.id_empresa;
                estoque.id_produto = id_produto;

                dbEntities.AddToproduto_estoque(estoque);
            }

            dbEntities.SaveChanges();
        }
        public void ProdutoEstoqueEditar(List<produto_estoque> estoques)
        {
            foreach (var e in estoques)
            {
                EntityKey key = dbEntities.CreateEntityKey("produto_estoque", e);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, e);
                }
            }
            dbEntities.SaveChanges();
        }

        public decimal IncrementaQuantidadeEstoque(long id_empresa, long id_produto, decimal quantidade)
        {
            decimal result = 0;

            var estoque = (from p in dbEntities.produto_estoque
                           where p.id_empresa == id_empresa && p.id_produto == id_produto
                           select p).SingleOrDefault();

            if (estoque == null)
                return result;

            estoque.quantidade_estoque += quantidade;

            EntityKey key = dbEntities.CreateEntityKey("produto_estoque", estoque);
            object originalItem;

            if (dbEntities.TryGetObjectByKey(key, out originalItem))
            {
                dbEntities.ApplyCurrentValues(key.EntitySetName, estoque);
            }

            dbEntities.SaveChanges();

            return result;
        }
        public decimal IncrementaQuantidadeReservada(long id_empresa, long id_produto, decimal quantidade)
        {
            decimal result = 0;

            var estoque = (from p in dbEntities.produto_estoque
                           where p.id_empresa == id_empresa && p.id_produto == id_produto
                           select p).SingleOrDefault();

            estoque.quantidade_reservada += quantidade;

            result = estoque.quantidade_reservada;

            EntityKey key = dbEntities.CreateEntityKey("produto_estoque", estoque);
            object originalItem;

            if (dbEntities.TryGetObjectByKey(key, out originalItem))
            {
                dbEntities.ApplyCurrentValues(key.EntitySetName, estoque);
            }

            dbEntities.SaveChanges();

            return result;
        }

        public decimal DescrementaQuantidadeEstoque(long id_empresa, long id_produto, decimal quantidade)
        {
            decimal result = 0;

            var estoque = (from p in dbEntities.produto_estoque
                           where p.id_empresa == id_empresa && p.id_produto == id_produto
                           select p).SingleOrDefault();

            estoque.quantidade_estoque -= quantidade;

            EntityKey key = dbEntities.CreateEntityKey("produto_estoque", estoque);
            object originalItem;

            if (dbEntities.TryGetObjectByKey(key, out originalItem))
            {
                dbEntities.ApplyCurrentValues(key.EntitySetName, estoque);
            }

            dbEntities.SaveChanges();

            return result;
        }
        public decimal DescrementaQuantidadeReservada(long id_empresa, long id_produto, decimal quantidade)
        {
            decimal result = 0;

            var estoque = (from p in dbEntities.produto_estoque
                           where p.id_empresa == id_empresa && p.id_produto == id_produto
                           select p).SingleOrDefault();

            estoque.quantidade_reservada -= quantidade;

            result = estoque.quantidade_reservada;

            EntityKey key = dbEntities.CreateEntityKey("produto_estoque", estoque);
            object originalItem;

            if (dbEntities.TryGetObjectByKey(key, out originalItem))
            {
                dbEntities.ApplyCurrentValues(key.EntitySetName, estoque);
            }

            dbEntities.SaveChanges();

            return result;
        }

        public void EstoqueHitorico(long id_empresa, long? id_compra, long? id_venda, long id_produto, decimal quantidade)
        {
            try
            {
                produto_estoque_historico historico = new produto_estoque_historico();

                historico.id_produto_estoque_historico = cms.Modulos.Util.Util.sp_getcodigo(Referencia.produto);
                historico.id_produto = id_produto;
                historico.id_empresa = id_empresa;

                if (id_venda != null)
                    historico.id_venda = id_venda.Value;
                if (id_compra != null)
                    historico.id_compra = id_compra.Value;
                
                historico.quantidade = quantidade;

                dbEntities.AddToproduto_estoque_historico(historico);
                dbEntities.SaveChanges();
            }
            catch { return; }
        }
        #endregion

        #region # Foto #
        public void ProdutoFotoCadastrar(produto_foto foto)
        {
            foto.id_produto_foto = cms.Modulos.Util.Util.sp_getcodigo(Referencia.produto_foto);
            foto.excluido = false;

            if (foto.principal)
            {
                var outras_fotos = GetProdutoFotoByIdProduto(foto.id_produto);
                foreach (var f in outras_fotos)
                {
                    f.principal = false;
                    EntityKey key = dbEntities.CreateEntityKey("produto_foto", f);
                    object originalItem;

                    if (dbEntities.TryGetObjectByKey(key, out originalItem))
                    {
                        dbEntities.ApplyCurrentValues(key.EntitySetName, f);
                    }
                }
            }
            dbEntities.SaveChanges();
            foto.data_cadastro = Util.Util.GetDataServidor();
            dbEntities.AddToproduto_foto(foto);
            dbEntities.SaveChanges();
        }
        public void ProdutoFotoEditar(produto_foto foto)
        {
            EntityKey key = dbEntities.CreateEntityKey("produto_foto", foto);
            object originalItem;

            if (dbEntities.TryGetObjectByKey(key, out originalItem))
            {
                dbEntities.ApplyCurrentValues(key.EntitySetName, foto);
            }

            if (foto.principal)
            {
                var outras_fotos = GetProdutoFotoByIdProduto(foto.id_produto);
                foreach (var f in outras_fotos)
                {
                    if (f.id_produto_foto != foto.id_produto_foto)
                    {
                        f.principal = false;
                        EntityKey key_ = dbEntities.CreateEntityKey("produto_foto", f);
                        object originalItem_;

                        if (dbEntities.TryGetObjectByKey(key_, out originalItem_))
                        {
                            dbEntities.ApplyCurrentValues(key_.EntitySetName, f);
                        }
                    }                
                }
            }

            dbEntities.SaveChanges();
        }
        public IQueryable<produto_foto> GetProdutoFotoByIdProduto(long id_produto)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto_foto);

            IQueryable<produto_foto> fotos = from i in dbEntities.produto_foto
                   where i.id_produto == id_produto &&
                         i.excluido == false
                 orderby i.ordem
                  select i;

            return fotos;
        }
        public produto_foto GetProdutoFotoByIdProdutoFoto(long id_produto_foto)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto_foto);

            produto_foto foto = (from i in dbEntities.produto_foto
                   where i.id_produto_foto == id_produto_foto &&
                         i.excluido == false
                  select i).SingleOrDefault();

            return foto;
        }
        #endregion

        #region # Preço Tabela #
        public void ProdutoPrecoTabelaCadastrar(long id_produto)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.empresa);
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto_preco_tabela);
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto);

            var empresas = from e in dbEntities.empresa
                        orderby e.apelido
                         select e;
            
            var preco_tabela = from e in dbEntities.produto_preco_tabela
                            orderby e.preco_tabela
                             select e;

            var produto = (from p in dbEntities.produto
                           where p.id_produto == id_produto
                           select p).SingleOrDefault();

            foreach (var e in empresas)
            {
                foreach (var p in preco_tabela)
                {
                    var exist = produto.produto_produto_preco_tabela.Where(o => o.id_empresa == e.id_empresa && o.id_produto_preco_tabela == p.id_produto_preco_tabela).SingleOrDefault();

                    if (exist == null)
                    {
                        produto_produto_preco_tabela preco = new produto_produto_preco_tabela();

                        preco.id_produto = id_produto;
                        preco.id_empresa = e.id_empresa;
                        preco.id_produto_preco_tabela = p.id_produto_preco_tabela;
                        preco.preco_venda = 0;
                        preco.preco_minimo = 0;

                        dbEntities.AddToproduto_produto_preco_tabela(preco);
                    }
                }
            }

            dbEntities.SaveChanges();
        }
        public void ProdutoPrecoTabelaEditar(produto_produto_preco_tabela preco)
        {
            EntityKey key = dbEntities.CreateEntityKey("produto_produto_preco_tabela", preco);
            object originalItem;

            if (dbEntities.TryGetObjectByKey(key, out originalItem))
            {
                dbEntities.ApplyCurrentValues(key.EntitySetName, preco);
            }
            dbEntities.SaveChanges();
        }
        public IQueryable<produto_produto_preco_tabela> GetProdutoPrecoTabelaByIdProduto(long id_produto)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto_produto_preco_tabela);

            IQueryable<produto_produto_preco_tabela> precos = from i in dbEntities.produto_produto_preco_tabela
                    where i.id_produto == id_produto &&
                          i.empresa.excluido == false
                    orderby i.id_empresa
                    select i;

            return precos;
        }
        #endregion

        #region # Embalagem #
        public void ProdutoEmbalagemCadastrar(produto_embalagem embalagem)
        {
            embalagem.id_produto_embalagem = cms.Modulos.Util.Util.sp_getcodigo(Referencia.produto_embalagem);
            dbEntities.AddToproduto_embalagem(embalagem);
            dbEntities.SaveChanges();
        }
        public void ProdutoEmbalagemEditar(produto_embalagem embalagem)
        {
            EntityKey key = dbEntities.CreateEntityKey("produto_embalagem", embalagem);
            object originalItem;

            if (dbEntities.TryGetObjectByKey(key, out originalItem))
            {
                dbEntities.ApplyCurrentValues(key.EntitySetName, embalagem);
            }
            dbEntities.SaveChanges();
        }
        public IQueryable<produto_embalagem> GetProdutoEmbalagemByIdProduto(long id_produto)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.produto_embalagem);
            IQueryable<produto_embalagem>  embalagem = from i in dbEntities.produto_embalagem
                     where i.id_produto == id_produto &&
                           i.excluido == false
                     orderby i.id_produto_embalagem
                     select i;

            return embalagem;
        }
        #endregion
        
    }
}


