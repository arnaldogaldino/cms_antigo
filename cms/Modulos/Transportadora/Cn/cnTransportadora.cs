using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;

namespace cms.Modulos.Transportadora.Cn
{
    public class cnTransportadora
    {
        private cmsEntities dbEntities = new cmsEntities();

        #region Transportadora
        public cnTransportadora()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<transportadora> TransportadoraProcurar(long? id_transportadora, string razao_socail, string cnpj, string rg)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.transportadora);
            IQueryable<transportadora> result = from t in dbEntities.transportadora
                                                where t.excluido == false
                                                orderby t.nome_fantasia
                                                select t;

            if (id_transportadora != null)
                result = result.Where(e => e.id_transportadora == id_transportadora);

            if (!string.IsNullOrEmpty(razao_socail))
                result = result.Where(e => e.razao_social.Contains(razao_socail));

            if (!string.IsNullOrEmpty(cnpj))
                result = result.Where(e => e.cnpj.Contains(cnpj));

            if (!string.IsNullOrEmpty(rg))
                result = result.Where(e => e.i_estadual.Contains(rg));

            return result;
        }

        public transportadora GetTransportadoraByID(long id_transportadora)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.transportadora);

            var result = (from c in dbEntities.transportadora
                          where c.excluido == false && c.id_transportadora == id_transportadora
                          select c).SingleOrDefault();

            return result;
        }

        public bool TransportadoraCnpjIsExist(string cnpj)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.transportadora);

            IQueryable<transportadora> result = from c in dbEntities.transportadora
                                          where c.excluido == false && c.cnpj == cnpj
                                          select c;

            if (result.Count() == 0)
                return false;

            return true;
        }

        public bool TransportadoraCadastrar(ref transportadora transportadora)
        {
            try
            {
                transportadora.id_transportadora = cms.Modulos.Util.Util.sp_getcodigo(Referencia.transportadora);
                dbEntities.AddTotransportadora(transportadora);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool TransportadoraEditar(ref transportadora transportadora)
        {
            try
            {
                dbEntities.transportadora.ApplyCurrentValues(transportadora);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        #endregion

        #region Contato

        public IQueryable<transportadora_contato> TransportadoraContatoProcurar(long id_transportadora)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.transportadora_contato);
            IQueryable<transportadora_contato> result = from c in dbEntities.transportadora_contato
                                                        where c.excluido == false && c.id_transportadora == id_transportadora
                                                        orderby c.nome
                                                        select c;
            
            return result;
        }

        public void TransportadoraContatoCadastrar(transportadora_contato transportadora_contato)
        {
            try
            {
                transportadora_contato.id_transportadora_contato = cms.Modulos.Util.Util.sp_getcodigo(Referencia.transportadora_contato);
                dbEntities.AddTotransportadora_contato(transportadora_contato);
                dbEntities.SaveChanges();
            }
            catch { }
        }

        public bool TransportadoraContatoEditar(transportadora_contato transportadora_contato)
        {
            try
            {
                dbEntities.transportadora_contato.ApplyCurrentValues(transportadora_contato);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        #endregion

        #region Comentario

        public IQueryable<transportadora_comentario> TransportadoraComentarioProcurar(long? id_transportadora)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.transportadora_comentario);
            IQueryable<transportadora_comentario> result = from c in dbEntities.transportadora_comentario
                                                           where c.excluido == false && c.id_transportadora == id_transportadora
                                                           orderby c.data_cadastro
                                                           select c;
            return result;
        }

        public void TransportadoraComentarioCadastrar(transportadora_comentario transportadora_comentario)
        {
            try
            {
                transportadora_comentario.id_transportadora_comentario = cms.Modulos.Util.Util.sp_getcodigo(Referencia.transportadora_comentario);
                dbEntities.AddTotransportadora_comentario(transportadora_comentario);
                dbEntities.SaveChanges();
            }
            catch { }
        }

        public bool TransportadoraComentarioEditar(transportadora_comentario transportadora_comentario)
        {
            try
            {
                dbEntities.transportadora_comentario.ApplyCurrentValues(transportadora_comentario);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        #endregion


    }
}
