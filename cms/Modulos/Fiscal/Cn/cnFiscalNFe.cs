using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cms.NFe;
using System.Xml.Serialization;
using System.IO;
using cms.Data;
using cms.Modulos.Util;

namespace cms.Modulos.Fiscal.Cn
{
    public class cnFiscalNFe
    {
        public compra Compra { get; set; }
        public venda Venda { get; set; }
        private empresa Empresa = new empresa();

        private cliente Cliente = null;
        private fornecedor Fornecedor = null;

        private TNFe NFe = new TNFe();

        public cnFiscalNFe()
        {
            NFe.infNFe = new TNFeInfNFe();
            NFe.Signature = new SignatureType();
        }

        public byte[] SerializarXML()
        {
            byte[] result = null;

            // Insert code to set properties and fields of the object.
            XmlSerializer mySerializer = new
            XmlSerializer(typeof(TNFe));
            // To write to a file, create a StreamWriter object.
            //StreamWriter myWriter = new StreamWriter("myFileName.xml");

            MemoryStream stream = new MemoryStream();
            mySerializer.Serialize(stream, NFe);
            //myWriter.Close();
            result = stream.GetBuffer();

            return result;
        }

        public void DesserializarXML(string path)
        {
            // Construct an instance of the XmlSerializer with the type
            // of object that is being deserialized.
            XmlSerializer mySerializer =
            new XmlSerializer(typeof(TNFe));
            // To read the file, create a FileStream.
            FileStream myFileStream =
            new FileStream(path, FileMode.Open);
            // Call the Deserialize method and cast to the object type.
            NFe = (TNFe)mySerializer.Deserialize(myFileStream);
        }

        public void Initialize()
        {
            if (Compra != null)
            {
                Empresa = Compra.empresa;
                Fornecedor = Compra.fornecedor;
            }
            
            if (Venda != null)
            {
                Empresa = Venda.empresa;
                Cliente = Venda.cliente;
            }

            PreencherInfNFeEmit();
            PreencherInfNFeDest();

            PreencherInfNFeCobr();

            PreencherInfNFeDet();

            PreencherInfNFeAvulsa();
            PreencherInfNFeCana();
            PreencherInfNFeEntrega();

            PreencherInfNFeCompra();
            PreencherInfNFeIde();
            
            PreencherInfNFeExporta();
            
            PreencherInfNFeInfAdic();
            PreencherInfNFeRetirada();
            PreencherInfNFeTotal();
            PreencherInfNFeTransp();
            PreencherSignature();
        }

        /// <summary>
        /// Preenche as Informações do Emitente.
        /// </summary>
        private void PreencherInfNFeEmit()
        {
            NFe.infNFe.emit = new TNFeInfNFeEmit();
                        
            NFe.infNFe.emit.CNAE = Util.Util.RemoveCaracteresEspeciais(Empresa.fiscal_cnae.subclasse);

            if (Empresa.crt == 1)
                NFe.infNFe.emit.CRT = TNFeInfNFeEmitCRT.Item1;
            if (Empresa.crt == 2)
                NFe.infNFe.emit.CRT = TNFeInfNFeEmitCRT.Item2;
            if (Empresa.crt == 3)
                NFe.infNFe.emit.CRT = TNFeInfNFeEmitCRT.Item3;

            NFe.infNFe.emit.IE = Empresa.i_estadual;
            
            NFe.infNFe.emit.IEST = Empresa.i_estadual;
            NFe.infNFe.emit.IM = Empresa.i_municipal;

            #region # enderEmit #
            NFe.infNFe.emit.enderEmit = new TEnderEmi();
            NFe.infNFe.emit.enderEmit.CEP = Empresa.end_cep;
            NFe.infNFe.emit.enderEmit.cMun = Empresa.end_municipio;

            NFe.infNFe.emit.enderEmit.cMun = Util.Combos.Municipios(Empresa.end_estado).Where(m => m.Value == Empresa.end_municipio).Single().Display;

            NFe.infNFe.emit.enderEmit.cPais = TEnderEmiCPais.Item1058;
            NFe.infNFe.emit.enderEmit.fone = Util.Util.RemoveCaracteresEspeciais(Empresa.telefone);
            NFe.infNFe.emit.enderEmit.nro = Empresa.end_numero;
            NFe.infNFe.emit.enderEmit.UF = (TUfEmi)Enum.Parse(typeof(TUfEmi), Empresa.end_estado);
            NFe.infNFe.emit.enderEmit.xBairro = Empresa.end_bairro;
            NFe.infNFe.emit.enderEmit.xLgr = Empresa.end_endereco;
            NFe.infNFe.emit.enderEmit.xCpl = Empresa.end_complemento;
            #endregion 
                        
            // esse campo não foi encontrado no XSD e nem no PDF
            //NFe.infNFe.emit.enderEmit.cPaisSpecified = true;
        }

        /// <summary>
        /// Preenche as Informações do Destinatario.
        /// </summary>
        private void PreencherInfNFeDest()
        {
            NFe.infNFe.dest = new TNFeInfNFeDest();
            
            if(Cliente != null)
            {
                NFe.infNFe.dest.email = Cliente.email;
                NFe.infNFe.dest.IE = Cliente.i_estadual;
                
                /// ~Procurar Informações sobre este campo...
                //NFe.infNFe.dest.ISUF = Cliente.i_estadual;

                if (Cliente.tipo_pessoa == "Fisica")
                    NFe.infNFe.dest.ItemElementName = ItemChoiceType3.CPF;
                else if (Cliente.tipo_pessoa == "Juridica")
                    NFe.infNFe.dest.ItemElementName = ItemChoiceType3.CNPJ;

                NFe.infNFe.dest.Item = Cliente.cnpj;

                NFe.infNFe.dest.xNome = Cliente.razao_social;
                
                #region # enderDest #
                NFe.infNFe.dest.enderDest = new TEndereco();
                NFe.infNFe.dest.enderDest.CEP = Cliente.end_cep;
                NFe.infNFe.dest.enderDest.cMun = Cliente.end_municipio;

                NFe.infNFe.dest.enderDest.cMun = Util.Combos.Municipios(Cliente.end_estado).Where(m => m.Value == Cliente.end_municipio).Single().Display;

                NFe.infNFe.dest.enderDest.cPais = Tpais.Item1058;

                NFe.infNFe.dest.enderDest.fone = Util.Util.RemoveCaracteresEspeciais(Cliente.telefone);
                NFe.infNFe.dest.enderDest.nro = Cliente.end_numero;
                NFe.infNFe.dest.enderDest.UF = (TUf)Enum.Parse(typeof(TUf), Cliente.end_estado);
                NFe.infNFe.dest.enderDest.xBairro = Cliente.end_bairro;
                NFe.infNFe.dest.enderDest.xLgr = Cliente.end_endereco;
                NFe.infNFe.dest.enderDest.xCpl = Cliente.end_complemento;
                #endregion                         
            }

            if (Fornecedor != null)
            {
                NFe.infNFe.dest.email = Fornecedor.email;
                NFe.infNFe.dest.IE = Fornecedor.i_estadual;

                /// ~Procurar Informações sobre este campo...
                //NFe.infNFe.dest.ISUF = Cliente.i_estadual;

                if (Cliente.tipo_pessoa == "Fisica")
                    NFe.infNFe.dest.ItemElementName = ItemChoiceType3.CPF;
                else if (Cliente.tipo_pessoa == "Juridica")
                    NFe.infNFe.dest.ItemElementName = ItemChoiceType3.CNPJ;

                NFe.infNFe.dest.Item = Fornecedor.cnpj;

                NFe.infNFe.dest.xNome = Fornecedor.razao_social;

                #region # enderDest #
                NFe.infNFe.dest.enderDest = new TEndereco();
                NFe.infNFe.dest.enderDest.CEP = Fornecedor.end_cep;
                NFe.infNFe.dest.enderDest.cMun = Fornecedor.end_municipio;

                NFe.infNFe.dest.enderDest.xMun = Util.Combos.Municipios(Fornecedor.end_estado).Where(m => m.Value == Fornecedor.end_municipio).Single().Display;

                NFe.infNFe.dest.enderDest.cPais = Tpais.Item1058;

                NFe.infNFe.dest.enderDest.fone = Util.Util.RemoveCaracteresEspeciais(Fornecedor.telefone);
                NFe.infNFe.dest.enderDest.nro = Fornecedor.end_numero;
                NFe.infNFe.dest.enderDest.UF = (TUf)Enum.Parse(typeof(TUf), Fornecedor.end_estado);
                NFe.infNFe.dest.enderDest.xBairro = Fornecedor.end_bairro;
                NFe.infNFe.dest.enderDest.xLgr = Fornecedor.end_endereco;
                NFe.infNFe.dest.enderDest.xCpl = Fornecedor.end_complemento;
                #endregion   
            }
        }
        
        private void PreencherInfNFeAvulsa()
        {
            NFe.infNFe.avulsa = new TNFeInfNFeAvulsa();
        }

        private void PreencherInfNFeCana()
        {
            NFe.infNFe.cana = new TNFeInfNFeCana();
        }

        private void PreencherInfNFeCobr()
        {
            List<TNFeInfNFeCobrDup> dups = new List<TNFeInfNFeCobrDup>();

            NFe.infNFe.cobr = new TNFeInfNFeCobr();
            NFe.infNFe.cobr.fat = new TNFeInfNFeCobrFat();


            NFe.infNFe.cobr.dup = dups.ToArray();
        }

        private void PreencherInfNFeCompra()
        {
            NFe.infNFe.compra = new TNFeInfNFeCompra();            
        }
        
        private void PreencherInfNFeDet()
        { 
            List<TNFeInfNFeDet> dets = new List<TNFeInfNFeDet>();
            TNFeInfNFeDet det = new TNFeInfNFeDet();
            
            NFe.infNFe.det = dets.ToArray();
        }
        
        private void PreencherInfNFeEntrega()
        {
            NFe.infNFe.entrega = new TLocal();
            
            if(Venda != null)
            {
                NFe.infNFe.entrega.cMun = Venda.end_ent_municipio;
                NFe.infNFe.entrega.xMun = Util.Combos.Municipios(Venda.end_ent_estado).Where(m => m.Value == Venda.end_ent_municipio).Single().Display;
                NFe.infNFe.entrega.xLgr = Venda.end_ent_endereco;
                NFe.infNFe.entrega.xCpl = Venda.end_ent_complemento;
                NFe.infNFe.entrega.xBairro = Venda.end_ent_bairro;
                NFe.infNFe.entrega.nro = Venda.end_ent_numero;
                NFe.infNFe.entrega.UF = (TUf)Enum.Parse(typeof(TUf), Util.Combos.Municipios(Venda.end_ent_estado).Where(m => m.Value == Venda.end_ent_municipio).Single().Display );                
            }
        }
        
        private void PreencherInfNFeExporta()
        {
            NFe.infNFe.exporta = new TNFeInfNFeExporta();
        }
        
        private void PreencherInfNFeIde()
        {
            NFe.infNFe.ide = new TNFeInfNFeIde();
            NFe.infNFe.ide.mod = TMod.Item55;
            NFe.infNFe.ide.cUF = (TCodUfIBGE)Enum.Parse(typeof(TUf), Util.Combos.IbgeUf().Where(m => m.Value == Empresa.end_estado).Single().Value);
            

            if(Venda.venda_pagamento.Count == 1)
                NFe.infNFe.ide.indPag = TNFeInfNFeIdeIndPag.Item0;
            if(Venda.venda_pagamento.Count > 1)
                NFe.infNFe.ide.indPag = TNFeInfNFeIdeIndPag.Item1;
        }
        
        private void PreencherInfNFeInfAdic()
        {
            NFe.infNFe.infAdic = new TNFeInfNFeInfAdic();            
        }
        
        private void PreencherInfNFeRetirada()
        {
            NFe.infNFe.retirada = new TLocal();
        }

        private void PreencherInfNFeTotal()
        {
            NFe.infNFe.total = new TNFeInfNFeTotal();
        }

        private void PreencherInfNFeTransp()
        {
            NFe.infNFe.transp = new TNFeInfNFeTransp();

            if (Venda != null)
            {
                if (Venda.transporte_por_conta == "")
                    NFe.infNFe.transp.modFrete = TNFeInfNFeTranspModFrete.Item9;

                if (Venda.transporte_por_conta == "Entrega s/ Acréscimo")
                    NFe.infNFe.transp.modFrete = TNFeInfNFeTranspModFrete.Item0;

                if (Venda.transporte_por_conta == "Entrega c/ Frete")
                    NFe.infNFe.transp.modFrete = TNFeInfNFeTranspModFrete.Item1;
            }
            
            List<ItemsChoiceType5> Items = new List<ItemsChoiceType5>();

            Items.Add(ItemsChoiceType5.veicTransp);

            NFe.infNFe.transp.ItemsElementName = Items.ToArray();

            // Informar o valor do ICMS do
            // serviço de transporte retido.
            #region # retTransp #
            NFe.infNFe.transp.retTransp = new TNFeInfNFeTranspRetTransp();
            #endregion

            #region # transporta #
            NFe.infNFe.transp.transporta.IE = Venda.transportadora.i_estadual;
            NFe.infNFe.transp.transporta.UF = (TUf)Enum.Parse(typeof(TUf), Venda.transportadora.end_estado);
            NFe.infNFe.transp.transporta.xMun = Util.Combos.Municipios(Fornecedor.end_estado).Where(m => m.Value == Fornecedor.end_municipio).Single().Display;
            NFe.infNFe.transp.transporta.xNome = Venda.transportadora.razao_social;
            NFe.infNFe.transp.transporta.xEnder = (Venda.transportadora.end_cep + " - N." + Venda.transportadora.end_numero + " - " + Venda.transportadora.end_endereco).PadRight(60, ' ').Substring(0, 60);
            #endregion

        }

        private void PreencherSignature()
        {
        
        }

    }
}
