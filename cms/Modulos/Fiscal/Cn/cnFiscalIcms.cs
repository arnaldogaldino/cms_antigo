using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.Modulos.Util;
using cms.Data;

namespace cms.Modulos.Fiscal.Cn
{

    public class cnFiscalIcms
    {
        private cmsEntities dbEntities = new cmsEntities();

        public cnFiscalIcms()
        {
            dbEntities.SavingChanges += new EventHandler(AuthEntity.LogEntities_SavingChanges);
        }

        public DataTable GetIcms()
        {
            DataTable dtResult = new DataTable();

            var ICols = (from ufs in dbEntities.fiscal_icms
                         select ufs.uf_destino).Distinct();

            foreach (var cols in ICols)
            {
                dtResult.Columns.Add(cols);
            }

            foreach (var col in ICols)
            {
                DataRow dr = dtResult.NewRow();

                var IVals = (from ufs in dbEntities.fiscal_icms
                             where ufs.uf_origem == col
                             select ufs);

                foreach (var vals in IVals)
                {
                    try
                    {
                        dr[vals.uf_destino] = string.Format("{0:n}", vals.aliquota_destino);
                    }
                    catch { dr[vals.uf_destino] = "0,00"; }
                }

                dtResult.Rows.Add(dr);
            }

            return dtResult;
        }

        public void AtualizarICMS(string uf_origem, string uf_destino, decimal aliquota_destino)
        {
            if (uf_origem != uf_destino)
            {
                var icm = (from i in dbEntities.fiscal_icms
                           where i.uf_destino == uf_destino && i.uf_origem == uf_origem
                           select i).SingleOrDefault();

                icm.aliquota_destino = aliquota_destino;
                dbEntities.fiscal_icms.ApplyCurrentValues(icm);
                dbEntities.SaveChanges();
            }
            else
            {
                var icms = (from i in dbEntities.fiscal_icms
                            where i.uf_origem == uf_origem
                            select i);

                foreach (var icm in icms)
                {
                    icm.aliquota_origem = aliquota_destino;

                    if (icm.uf_destino == icm.uf_origem)
                        icm.aliquota_destino = aliquota_destino;

                    dbEntities.fiscal_icms.ApplyCurrentValues(icm);
                }

                dbEntities.SaveChanges();
            }
        }
        public fiscal_icms GetIcmsByUf(string uf_origem, string uf_destino)
        {
            var result = (from i in dbEntities.fiscal_icms
                          where i.uf_origem == uf_origem && i.uf_destino == uf_destino
                          select i).SingleOrDefault();

            return result;

        }

        public decimal CalcularICMS(produto Produto, decimal valor_produto, string uf_origem, string uf_destino)
        {
            decimal result = 0;
            decimal aliquota_icms = 0;

            var produto_icms = Produto.produto_ipi_icms.Where(o => o.uf == uf_destino).SingleOrDefault();

            if (produto_icms != null)
            {
                aliquota_icms = produto_icms.aliquota_icms;
            }
            else
            {
                var icms = GetIcmsByUf(uf_origem, uf_destino);
                aliquota_icms = icms.aliquota_destino;
            }

            result = valor_produto * (aliquota_icms / 100);

            return result;
        }
        public decimal CalcularBaseICMS(produto Produto, decimal valor_produto, string uf_destino, string tipo_pessoa)
        {
            decimal result = 0;
            decimal aliquota_base_icms = 0;

            string cst = Produto.origem_cst + Produto.cst;

            var produto_icms = Produto.produto_base_icms.Where(o => o.uf == uf_destino && o.cst == cst && o.tipo_pessoa == tipo_pessoa).SingleOrDefault();

            if (produto_icms != null)
            {
                aliquota_base_icms = produto_icms.aliquota;
            }
            else
            {
                if(Produto.base_icms != null)
                    aliquota_base_icms = Produto.base_icms.Value;
            }

            result = valor_produto * (aliquota_base_icms / 100);

            return result;
        }
        public decimal CalcularICMSST(produto Produto, decimal valor_produto, string uf_origem, string uf_destino, string tipo_pessoa, string i_estadual)
        {
            decimal result = 0;
            try
            {
                decimal aliquota_icms_base = CalcularBaseICMS(Produto, valor_produto, uf_destino, tipo_pessoa);

                if ((uf_destino == uf_origem) || (tipo_pessoa == "Fisica" && i_estadual == "Isento"))
                    return result;

                if (Produto.fiscal_ncm == null)
                    throw new Exception("NCM não informado para este produto.");

                var produto_ncm = Produto.fiscal_ncm.fiscal_ncm_iva.Where(o => o.estado == uf_destino).SingleOrDefault();

                if (aliquota_icms_base > 0 && produto_ncm != null)
                    result = aliquota_icms_base * (produto_ncm.iva / 100);
            }
            catch (Exception e)
            {
                throw new Exception("Não existe IVA para o NCM cadastrado ou \n o produto não tem NCM Cadastrado.", e.InnerException);
            }
            return result;
        }
        public decimal CalcularIPI(produto Produto, decimal valor_produto, string uf_destino)
        {
            decimal result = 0;
            decimal aliquota_ipi = 0;

            var produto_icms = Produto.produto_ipi_icms.Where(o => o.uf == uf_destino).SingleOrDefault();

            if (produto_icms != null)
                aliquota_ipi = produto_icms.aliquota_ipi;
            else
                if (Produto.ipi_aliquota != null)
                    aliquota_ipi = Produto.ipi_aliquota.Value;

            result = valor_produto * (aliquota_ipi / 100);

            return result;
        }

    }

}

