using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Data;
using System.Data.EntityClient;
using System.Data;
using System.Data.Objects;
using cms.Modulos.Util;

namespace cms.Modulos.Empresa.Cn
{
    public class cnEmpresa
    {
        private cmsEntities dbEntities = new cmsEntities();

        #region Empresa
        public cnEmpresa()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<empresa> EmpresaProcurar(long? id_empresa, string razao_socail, string cpf, string rg, string cnpj, string ie, string tipo_pessoa, string tipo_empresa)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.empresa);
            IQueryable<empresa> result = from e in dbEntities.empresa
                                         where e.excluido == false
                                         orderby e.nome_fantasia
                                         select e;

            if (id_empresa != null)
                result = result.Where(e => e.id_empresa == id_empresa);

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

        public empresa GetEmpresaByID(long id_empresa)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.empresa);

            var result = (from e in dbEntities.empresa
                          where e.excluido == false && e.id_empresa == id_empresa
                          select e).SingleOrDefault();
           
            return result;
        }

        public bool EmpresaCnpjIsExist(string cnpj)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.empresa);

            IQueryable<empresa> result = from e in dbEntities.empresa
                                             where e.excluido == false && e.cnpj == cnpj
                                             select e;

            if (result.Count() == 0)
                return false;

            return true;
        }

        public bool EmpresaCadastrar(ref empresa pEmpresa)
        {
            try
            {
                pEmpresa.id_empresa = cms.Modulos.Util.Util.sp_getcodigo(Referencia.empresa);
                dbEntities.AddToempresa(pEmpresa);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool EmpresaEditar(ref empresa empresa)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("empresa", empresa);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, empresa);
                }
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        #endregion

        #region Contato

        public IQueryable<empresa_contato> EmpresaContatoProcurar(long? id_empresa)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.empresa_contato);

            var result = from e in dbEntities.empresa_contato
                         where e.excluido == false && e.id_empresa == id_empresa
                         orderby e.nome
                         select e;
            return result;
        }

        public void EmpresaContatoCadastrar(empresa_contato empresa_contato)
        {
            try
            {
                empresa_contato.id_empresa_contato = cms.Modulos.Util.Util.sp_getcodigo(Referencia.empresa_contato);
                dbEntities.AddToempresa_contato(empresa_contato);
                dbEntities.SaveChanges();
            }
            catch { }
        }

        public bool EmpresaContatoEditar(empresa_contato empresa_contato)
        {
            try
            {
                dbEntities.empresa_contato.ApplyCurrentValues(empresa_contato);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        #endregion

        #region Comentario

        public IQueryable<empresa_comentario> EmpresaComentarioProcurar(long? id_empresa)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.empresa_comentario);

            IQueryable<empresa_comentario> result = from e in dbEntities.empresa_comentario
                                                        where e.excluido == false && e.id_empresa == id_empresa
                                                        orderby e.data_cadastro
                                                        select e;

            return result;
        }

        public void EmpresaComentarioCadastrar(empresa_comentario empresa_comentario)
        {
            try
            {
                empresa_comentario.id_empresa_comentario = cms.Modulos.Util.Util.sp_getcodigo(Referencia.empresa_comentario);
                dbEntities.AddToempresa_comentario(empresa_comentario);
                dbEntities.SaveChanges();
            }
            catch { }
        }

        public bool EmpresaComentarioEditar(empresa_comentario empresa_comentario)
        {
            try
            {
                dbEntities.empresa_comentario.ApplyCurrentValues(empresa_comentario);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        #endregion

    }
}
