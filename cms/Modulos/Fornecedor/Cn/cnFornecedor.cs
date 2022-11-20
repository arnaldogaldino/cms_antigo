using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;

namespace cms.Modulos.Fornecedor.Cn
{
    public class cnFornecedor
    {
        private cmsEntities dbEntities = new cmsEntities();

        #region Fornecedor
        public cnFornecedor()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<fornecedor> FornecedorProcurar(long? id_fornecedor, string razao_socail, string cpf, string rg, string cnpj, string ie, string tipo_pessoa)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fornecedor);
            IQueryable<fornecedor> result = from f in dbEntities.fornecedor
                                            where f.excluido == false
                                            orderby f.nome_fantasia
                                            select f;

            if (id_fornecedor != null)
                result = result.Where(e => e.id_fornecedor == id_fornecedor);

            if (!string.IsNullOrEmpty(razao_socail))
                result = result.Where(e => e.razao_social.Contains(razao_socail));

            if (!string.IsNullOrEmpty(cnpj))
                result = result.Where(e => e.cnpj.Contains(cnpj));

            if (!string.IsNullOrEmpty(cpf))
                result = result.Where(e => e.cnpj == cpf);

            if (!string.IsNullOrEmpty(rg))
                result = result.Where(e => e.i_estadual.Contains(rg));

            if (!string.IsNullOrEmpty(ie))
                result = result.Where(e => e.cnpj == cpf);

            if (!string.IsNullOrEmpty(tipo_pessoa))
                result = result.Where(e => e.tipo_pessoa == tipo_pessoa);

            return result;
        }

        public fornecedor GetFornecedorByID(long id_fornecedor)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fornecedor);

            fornecedor result = (from f in dbEntities.fornecedor
                                 where f.excluido == false && f.id_fornecedor == id_fornecedor
                                 select f).SingleOrDefault();

            return result;
        }

        public bool FornecedorCnpjIsExist(string cnpj)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fornecedor);
            IQueryable<fornecedor> result = from f in dbEntities.fornecedor
                                                where f.excluido == false && f.cnpj == cnpj
                                                select f;
            if (result.Count() == 0)
                return false;

            return true;
        }

        public bool FornecedorCadastrar(ref fornecedor fornecedor)
        {
            try
            {
                fornecedor.id_fornecedor = cms.Modulos.Util.Util.sp_getcodigo(Referencia.fornecedor);
                dbEntities.AddTofornecedor(fornecedor);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FornecedorEditar(ref fornecedor fornecedor)
        {
            try
            {
                dbEntities.fornecedor.ApplyCurrentValues(fornecedor);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        #endregion 

        #region Contato

        public IQueryable<fornecedor_contato> FornecedorContatoProcurar(long? id_fornecedor)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fornecedor_contato);

            IQueryable<fornecedor_contato> result = from c in dbEntities.fornecedor_contato
                                                    where c.excluido == false && c.id_fornecedor == id_fornecedor
                                                    orderby c.nome
                                                    select c;

            return result;
        }
        
        public void FornecedorContatoCadastrar(fornecedor_contato fornecedor_contato)
        {
            try
            {
                fornecedor_contato.id_fornecedor_contato = cms.Modulos.Util.Util.sp_getcodigo(Referencia.fornecedor_contato);
                dbEntities.AddTofornecedor_contato(fornecedor_contato);
                dbEntities.SaveChanges();
            }
            catch { }
        }

        public bool FornecedorContatoEditar(fornecedor_contato fornecedor_contato)
        {
            try
            {
                dbEntities.fornecedor_contato.ApplyCurrentValues(fornecedor_contato);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
    
        #endregion

        #region Comentario

        public IQueryable<fornecedor_comentario> FornecedorComentarioProcurar(long? id_fornecedor)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fornecedor_contato);

            IQueryable<fornecedor_comentario> result = from c in dbEntities.fornecedor_comentario
                                                    where c.excluido == false && c.id_fornecedor == id_fornecedor
                                                    orderby c.data_cadastro
                                                    select c;

            return result;
        }

        public void FornecedorComentarioCadastrar(fornecedor_comentario fornecedor_comentario)
        {
            try
            {
                fornecedor_comentario.id_fornecedor_comentario = cms.Modulos.Util.Util.sp_getcodigo(Referencia.fornecedor_comentario);
                dbEntities.AddTofornecedor_comentario(fornecedor_comentario);
                dbEntities.SaveChanges();
            }
            catch { }
        }

        public bool FornecedorComentarioEditar(fornecedor_comentario fornecedor_comentario)
        {
            try
            {
                dbEntities.fornecedor_comentario.ApplyCurrentValues(fornecedor_comentario);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        #endregion


    }
}
