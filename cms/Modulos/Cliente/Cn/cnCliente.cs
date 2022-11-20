using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Data;
using System.Data.EntityClient;
using System.Data;
using System.Data.SqlClient;
using System.Data.Objects;
using cms.Modulos.Util;
using System.Collections.ObjectModel;

namespace cms.Modulos.Cliente.Cn
{
    public class cnCliente
    {
        private cmsEntities dbEntities = new cmsEntities();
        
        #region Cliente
        public cnCliente()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<cliente> ClienteProcurar(long? id_cliente, string razao_socail, string cpf, string rg, string cnpj, string ie, string tipo_pessoa, string tipo_cliente)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.cliente);
            
            IQueryable<cliente> result = from c in dbEntities.cliente
                                        where c.excluido == false
                                      orderby c.razao_social
                                       select c;

            if (id_cliente != null)
                result = result.Where(w => w.id_cliente == id_cliente);

            if (!string.IsNullOrEmpty(razao_socail))
                result = result.Where(c => c.razao_social == razao_socail);

            if (!string.IsNullOrEmpty(cnpj))
                result = result.Where(c => c.cnpj == cnpj);
            
            if (!string.IsNullOrEmpty(cpf))
                result = result.Where(c => c.cnpj == cpf);

            if (!string.IsNullOrEmpty(rg))
                result = result.Where(c => c.i_estadual == rg);

            if (!string.IsNullOrEmpty(ie))
                result = result.Where(c => c.i_estadual == ie);

            if (!string.IsNullOrEmpty(tipo_pessoa))
                result = result.Where(c => c.tipo_pessoa == tipo_pessoa);

            return result;
        }

        public cliente GetClienteByID(long id_cliente)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.cliente);

            var result = (from c in dbEntities.cliente
                           where c.excluido == false && c.id_cliente == id_cliente
                          select c).SingleOrDefault();

            return result;
        }

        public bool ClienteCnpjIsExist(string cnpj)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.cliente);

            IQueryable<cliente> result = from c in dbEntities.cliente
                                              where c.excluido == false && c.cnpj == cnpj
                                              select c;

            if (result.Count() == 0)
                return false;

            return true;
        }

        public bool ClienteCadastrar(ref cliente pCliente)
        {
            try
            {
                pCliente.id_cliente = cms.Modulos.Util.Util.sp_getcodigo(Referencia.cliente);
                dbEntities.AddTocliente(pCliente);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool ClienteEditar(ref cliente cliente)
        {
            try
            {
                EntityKey key = dbEntities.CreateEntityKey("cliente", cliente);
                object originalItem;

                if (dbEntities.TryGetObjectByKey(key, out originalItem))
                {
                    dbEntities.ApplyCurrentValues(key.EntitySetName, cliente);
                }
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        #endregion 

        #region Contato

        public IQueryable<cliente_contato> ClienteContatoProcurar(long? id_cliente)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.cliente_contato);

            IQueryable<cliente_contato> result = from c in dbEntities.cliente_contato
                                                 where c.excluido == false && c.id_cliente == id_cliente
                                                 orderby c.nome
                                                 select c;

            return result; 
        }

        public void ClienteContatoCadastrar(cliente_contato cliente_contato)
        {
            try
            {
                cliente_contato.id_cliente_contato = cms.Modulos.Util.Util.sp_getcodigo(Referencia.cliente_contato);
                dbEntities.AddTocliente_contato(cliente_contato);
                dbEntities.SaveChanges();
            }
            catch { }
        }

        public bool ClienteContatoEditar(cliente_contato cliente_contato)
        {
            try
            {
                dbEntities.cliente_contato.ApplyCurrentValues(cliente_contato);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public cliente_contato GetClienteContatoByIDClienteContato(long id_cliente_contato)
        {
            cliente_contato result = new cliente_contato();

            try
            {
                result = (from c in dbEntities.cliente_contato
                          where c.id_cliente_contato == id_cliente_contato
                          select c).SingleOrDefault();
            }
            catch { }

            return result;
        }
        #endregion

        #region Comentario

        public IQueryable<cliente_comentario> ClienteComentarioProcurar(long? id_cliente)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.cliente_comentario);

            IQueryable<cliente_comentario> result = from c in dbEntities.cliente_comentario
                                                        where c.excluido == false && c.id_cliente == id_cliente
                                                        orderby c.data_cadastro
                                                        select c;
            return result;
        }

        public void ClienteComentarioCadastrar(cliente_comentario cliente_comentario)
        {
            try
            {
                cliente_comentario.id_cliente_comentario = cms.Modulos.Util.Util.sp_getcodigo(Referencia.cliente_comentario);
                dbEntities.AddTocliente_comentario(cliente_comentario);
                dbEntities.SaveChanges();
            }
            catch { }
        }

        public bool ClienteComentarioEditar(cliente_comentario cliente_comentario)
        {
            try
            {
                dbEntities.cliente_comentario.ApplyCurrentValues(cliente_comentario);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        #endregion
                
    }
}
