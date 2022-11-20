using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Services;

namespace cms.NFe
{
    /// <summary>
    /// WS de Homologação: http://hom.nfe.fazenda.gov.br/PORTAL/WebServices.aspx
    /// WS de Produção: http://www.nfe.fazenda.gov.br/portal/WebServices.aspx
    /// </summary>
    public class ServiceReferenceNFe
    {
        private string url_NfeRecepcao = "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/NfeRecepcao2.asmx?WSDL";
        private string url_NfeRetRecepcao = "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/NfeRetRecepcao2.asmx?WSDL";
        private string url_NfeCancelamento = "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/NfeCancelamento2.asmx?WSDL";
        private string url_NfeInutilizacao = "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/NfeInutilizacao2.asmx?WSDL";
        private string url_NfeConsultaProtocolo = "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/NfeConsulta2.asmx?WSDL";
        private string url_NfeStatusServico = "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/NfeStatusServico2.asmx?WSDL";
        private string url_NfeConsultaCadastro = "https://homologacao.nfe.fazenda.sp.gov.br/nfeweb/services/CadConsultaCadastro2.asmx?WSDL";
        private string url_RecepcaoEvento = "https://homologacao.nfe.fazenda.sp.gov.br/eventosWEB/services/RecepcaoEvento.asmx?WSDL";

        WebService NfeRecepcao;
        WebService NfeRetRecepcao;
        WebService NfeCancelamento;
        WebService NfeInutilizacao;
        WebService NfeConsultaProtocolo;
        WebService NfeStatusServico;
        WebService NfeConsultaCadastro;
        WebService RecepcaoEvento;

        public ServiceReferenceNFe()
        {
            Initialized();
        }

        public void Initialized()
        {

            cms.nfe.hmg.sp.Recepcao2.NfeRecepcao2 oservice = new nfe.hmg.sp.Recepcao2.NfeRecepcao2();
            cms.nfe.hmg.sp.StatusServico2.NfeStatusServico2 oStatus = new nfe.hmg.sp.StatusServico2.NfeStatusServico2();
            var teste = oStatus.nfeCabecMsgValue;

            
            //Uri uri = new Uri(url_NfeStatusServico);

            //NfeRecepcao = new WebService();
            //NfeRetRecepcao = new WebService();
            //NfeCancelamento = new WebService();
            //NfeInutilizacao = new WebService();
            //NfeConsultaProtocolo = new WebService();
            //NfeStatusServico = new WebService();
            //NfeConsultaCadastro = new WebService();
            //RecepcaoEvento = new WebService();

            
        }



    }
}
