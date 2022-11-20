using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;

namespace cms.Modulos.Fiscal.Cn
{
    public class cnFiscalNcm
    {
        private cmsEntities dbEntities = new cmsEntities();

        #region Fiscal Ncm

        public cnFiscalNcm()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public IQueryable<fiscal_ncm> FiscalNcmProcurar(string ncm, string descricao)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fiscal_ncm);

            IQueryable<fiscal_ncm> result = from n in dbEntities.fiscal_ncm
                                            where n.excluido == false
                                            orderby n.ncm
                                            select n;

            if (!string.IsNullOrEmpty(ncm))
                result = result.Where(e => e.ncm == ncm);

            if (!string.IsNullOrEmpty(descricao))
                result = result.Where(e => e.descricao.Contains(descricao));

            return result;
        }
        
        public IQueryable<fiscal_ncm_iva> FiscalNcmIvas(long id_fiscal_ncm)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fiscal_ncm_iva);
            IQueryable<fiscal_ncm_iva> result = from i in dbEntities.fiscal_ncm_iva
                                                where i.id_fiscal_ncm == id_fiscal_ncm
                                                orderby i.estado
                                                select i;
            return result;
        }

        public fiscal_ncm GetFiscalNcmByID(long id_fiscal_ncm)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fiscal_ncm);

            fiscal_ncm result = (from n in dbEntities.fiscal_ncm
                                 where n.excluido == false && n.id_fiscal_ncm == id_fiscal_ncm
                                 select n).SingleOrDefault();

            return result;
        }

        public bool NcmIsExist(string ncm)
        {
            dbEntities.Refresh(System.Data.Objects.RefreshMode.ClientWins, dbEntities.fiscal_ncm);

            IQueryable<fiscal_ncm> result = from n in dbEntities.fiscal_ncm
                                            where n.excluido == false && n.ncm == ncm
                                            select n;

            if (result.Count() == 0)
                return false;

            return true;
        }

        public bool FiscalNcmCadastrar(ref fiscal_ncm fiscaNcm)
        {
            try
            {
                fiscaNcm.id_fiscal_ncm = cms.Modulos.Util.Util.sp_getcodigo(Referencia.fiscal_ncm);
                fiscaNcm.excluido = false;

                var estados = from e in dbEntities.cep_estado
                              select e;

                foreach (var e in estados)
                {
                    fiscal_ncm_iva iva = new fiscal_ncm_iva();

                    iva.id_fiscal_ncm_iva = cms.Modulos.Util.Util.sp_getcodigo(Referencia.fiscal_ncm_iva);
                    iva.id_fiscal_ncm = fiscaNcm.id_fiscal_ncm;
                    iva.estado = e.estado_sigla;

                    iva.imposto_st = 0;
                    iva.iva = 0;
                    iva.reducao_bc = 0;
                    iva.aliquota_interna = 0;
                    fiscaNcm.fiscal_ncm_iva.Add(iva);
                }

                dbEntities.AddTofiscal_ncm(fiscaNcm);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public void AtualizarIva(ref fiscal_ncm fiscaNcm)
        {
            var estados = from e in dbEntities.cep_estado
                          select e;

            foreach (var e in estados)
            {
                var exist = (from i in fiscaNcm.fiscal_ncm_iva
                            where i.estado == e.estado_sigla
                            select i).SingleOrDefault();

                if (exist == null)
                {
                    fiscal_ncm_iva iva = new fiscal_ncm_iva();

                    iva.id_fiscal_ncm_iva = cms.Modulos.Util.Util.sp_getcodigo(Referencia.fiscal_ncm_iva);
                    iva.id_fiscal_ncm = fiscaNcm.id_fiscal_ncm;
                    iva.estado = e.estado_sigla;

                    iva.imposto_st = 0;
                    iva.iva = 0;
                    iva.reducao_bc = 0;
                    iva.aliquota_interna = 0;
                    fiscaNcm.fiscal_ncm_iva.Add(iva);
                }
            }

            dbEntities.fiscal_ncm.ApplyCurrentValues(fiscaNcm);
            dbEntities.SaveChanges();
        }

        public bool FiscalNcmEditar(ref fiscal_ncm ncm)
        {
            try
            {
                dbEntities.fiscal_ncm.ApplyCurrentValues(ncm);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        
        public bool FiscalNcmCadastrarIva(fiscal_ncm_iva iva)
        {
            try
            {
                iva.id_fiscal_ncm_iva = cms.Modulos.Util.Util.sp_getcodigo(Referencia.fiscal_ncm_iva);
                dbEntities.AddTofiscal_ncm_iva(iva);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FiscalNcmEditarIva(fiscal_ncm_iva iva)
        {
            try
            {
                dbEntities.fiscal_ncm_iva.ApplyCurrentValues(iva);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }

        public bool FiscalNcmExcluirIva(fiscal_ncm_iva iva)
        {
            try
            {
                dbEntities.fiscal_ncm_iva.DeleteObject(iva);
                dbEntities.SaveChanges();
            }
            catch { return false; }

            return true;
        }
        
        #endregion 

    }

}
