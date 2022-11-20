unit relatorioDANFE;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  Db, DBTables, Qrctrls, QuickRpt, ExtCtrls, xmldom, Provider, Xmlxform,
  DBClient, Barcode, Clipbrd, CJVBarCode, CJVQrDbBarCode, Grids, DBGrids, Utils;

type
  TDANFEREL = class(TForm)
    qrRelatorio: TQuickRep;
    qbDestinatario: TQRGroup;
    dsFatNsu: TDataSource;
    cdsNotaFiscal: TClientDataSet;
    XTPNFE: TXMLTransformProvider;
    QRLabel22: TQRLabel;
    QRShape9: TQRShape;
    QRLabel23: TQRLabel;
    qtdest_xNome: TQRDBText;
    QRShape10: TQRShape;
    QRLabel24: TQRLabel;
    qtdest_CNPJ: TQRDBText;
    QRShape11: TQRShape;
    QRLabel25: TQRLabel;
    qtide_dEmi: TQRDBText;
    QRLabel26: TQRLabel;
    QRShape13: TQRShape;
    QRLabel27: TQRLabel;
    qtenderDest_xBairro: TQRDBText;
    QRShape14: TQRShape;
    QRLabel28: TQRLabel;
    qtenderDest_CEP: TQRDBText;
    QRShape15: TQRShape;
    QRLabel29: TQRLabel;
    qtdSaiEnt: TQRDBText;
    QRShape16: TQRShape;
    QRLabel30: TQRLabel;
    QRDBText4: TQRDBText;
    QRShape17: TQRShape;
    QRLabel31: TQRLabel;
    qtFoneFax: TQRDBText;
    QRShape18: TQRShape;
    QRLabel32: TQRLabel;
    qtenderDestUF: TQRDBText;
    QRShape19: TQRShape;
    QRLabel33: TQRLabel;
    qtDestIE: TQRDBText;
    QRShape20: TQRShape;
    QRLabel34: TQRLabel;
    QRLabel35: TQRLabel;
    QRShape21: TQRShape;
    QRLabel36: TQRLabel;
    QRShape22: TQRShape;
    QRLabel37: TQRLabel;
    qtCalIcmBas: TQRDBText;
    QRShape23: TQRShape;
    QRLabel38: TQRLabel;
    qtvICMS: TQRDBText;
    QRShape24: TQRShape;
    QRLabel39: TQRLabel;
    qtICMSSUB: TQRDBText;
    QRShape25: TQRShape;
    QRLabel40: TQRLabel;
    qtvICMSSUB: TQRDBText;
    QRShape26: TQRShape;
    QRLabel41: TQRLabel;
    qtProdValTot: TQRDBText;
    QRShape27: TQRShape;
    QRLabel42: TQRLabel;
    qtValFrete: TQRDBText;
    QRShape28: TQRShape;
    QRLabel43: TQRLabel;
    qtvSeg: TQRDBText;
    QRShape29: TQRShape;
    QRLabel44: TQRLabel;
    qtvDesc: TQRDBText;
    QRShape30: TQRShape;
    QRLabel45: TQRLabel;
    qtvOutro: TQRDBText;
    QRShape31: TQRShape;
    QRLabel46: TQRLabel;
    qtvIPI: TQRDBText;
    QRShape32: TQRShape;
    lbNFValTot: TQRLabel;
    qtvNF: TQRDBText;
    QRLabel47: TQRLabel;
    QRShape33: TQRShape;
    QRLabel48: TQRLabel;
    qttransporta_xNome: TQRDBText;
    QRShape34: TQRShape;
    QRLabel49: TQRLabel;
    QRLabel50: TQRLabel;
    QRLabel51: TQRLabel;
    QRShape35: TQRShape;
    QRShape36: TQRShape;
    QRLabel52: TQRLabel;
    qtCodANTT: TQRDBText;
    QRShape37: TQRShape;
    QRLabel53: TQRLabel;
    qtPlaca: TQRDBText;
    QRShape38: TQRShape;
    QRLabel54: TQRLabel;
    qtTransUF: TQRDBText;
    QRLabel55: TQRLabel;
    qttransporta_CNPJ: TQRDBText;
    QRShape40: TQRShape;
    QRLabel56: TQRLabel;
    qtxEnder: TQRDBText;
    QRShape41: TQRShape;
    QRLabel57: TQRLabel;
    qrtransporta_xMun: TQRDBText;
    QRShape42: TQRShape;
    QRLabel58: TQRLabel;
    qttransporta_UF: TQRDBText;
    QRLabel59: TQRLabel;
    QRDBText1: TQRDBText;
    QRShape44: TQRShape;
    QRLabel60: TQRLabel;
    qtQuantidade: TQRDBText;
    QRShape45: TQRShape;
    QRLabel61: TQRLabel;
    qtEspecie: TQRDBText;
    QRShape46: TQRShape;
    QRLabel62: TQRLabel;
    qtMarca: TQRDBText;
    QRShape47: TQRShape;
    QRLabel63: TQRLabel;
    qtNumeracao: TQRDBText;
    QRShape48: TQRShape;
    QRLabel64: TQRLabel;
    qtPesoBruto: TQRDBText;
    QRShape49: TQRShape;
    QRLabel65: TQRLabel;
    qtPesoLiquido: TQRDBText;
    qbCanhotoDaNota: TQRBand;
    QRShape84: TQRShape;
    shNfeNum: TQRShape;
    QRShape85: TQRShape;
    QRShape86: TQRShape;
    QRLabel4: TQRLabel;
    QRLabel6: TQRLabel;
    QRLabel7: TQRLabel;
    QRLabel8: TQRLabel;
    qtSysEnt: TQRDBText;
    QRLabel11: TQRLabel;
    QRDBText6: TQRDBText;
    QRDBText7: TQRDBText;
    QRLabel90: TQRLabel;
    QRLabel92: TQRLabel;
    QRLabel93: TQRLabel;
    QRShape3: TQRShape;
    cbIdentificacaoDaOperacao: TQRChildBand;
    QRShape7: TQRShape;
    QRShape5: TQRShape;
    QRShape2: TQRShape;
    QRShape1: TQRShape;
    qtFatNsuNum: TQRDBText;
    qtSysCliRazSoc: TQRDBText;
    qtSysCidNom: TQRDBText;
    qtSysCliTel: TQRDBText;
    qtSysCliEndBai: TQRDBText;
    qtSysCliInsEst: TQRDBText;
    qtenderEmit_CEP: TQRDBText;
    qtSysCliCnp: TQRDBText;
    qtSysNopNom: TQRDBText;
    qiLogomarca: TQRImage;
    QRLabel1: TQRLabel;
    QRLabel2: TQRLabel;
    QRLabel12: TQRLabel;
    QRLabel13: TQRLabel;
    QRShape4: TQRShape;
    QRLabel15: TQRLabel;
    QRLabel16: TQRLabel;
    qtFatNsuSer: TQRDBText;
    QRLabel17: TQRLabel;
    QRLabel18: TQRLabel;
    QRShape6: TQRShape;
    QRLabel19: TQRLabel;
    qtIEST: TQRDBText;
    QRLabel21: TQRLabel;
    qtChaveAcesso: TQRDBText;
    codigoBarras: TCJVQrDbBarCode;
    qtEnderEmit_xLgr: TQRDBText;
    QRLabel14: TQRLabel;
    QRShape12: TQRShape;
    QRLabel20: TQRLabel;
    QRDBText2: TQRDBText;
    QRShape50: TQRShape;
    QRShape51: TQRShape;
    QRShape39: TQRShape;
    QRShape43: TQRShape;
    QRLabel66: TQRLabel;
    QRShape52: TQRShape;
    QRShape55: TQRShape;
    QRLabel67: TQRLabel;
    QRLabel68: TQRLabel;
    QRLabel69: TQRLabel;
    QRLabel70: TQRLabel;
    QRShape56: TQRShape;
    QRShape57: TQRShape;
    QRShape58: TQRShape;
    QRShape59: TQRShape;
    QRLabel71: TQRLabel;
    QRLabel72: TQRLabel;
    QRLabel73: TQRLabel;
    QRLabel74: TQRLabel;
    QRShape60: TQRShape;
    QRLabel75: TQRLabel;
    QRLabel76: TQRLabel;
    QRShape61: TQRShape;
    QRLabel77: TQRLabel;
    QRShape62: TQRShape;
    QRLabel78: TQRLabel;
    QRShape63: TQRShape;
    QRLabel79: TQRLabel;
    QRShape64: TQRShape;
    QRLabel80: TQRLabel;
    QRShape65: TQRShape;
    qbDetalhe: TQRBand;
    QRShape67: TQRShape;
    QRShape68: TQRShape;
    QRShape69: TQRShape;
    QRShape70: TQRShape;
    QRShape71: TQRShape;
    qtDescProd: TQRDBText;
    qtNCMSH: TQRDBText;
    qtCST: TQRLabel;
    qtCFOP: TQRDBText;
    qtUnidade: TQRDBText;
    qtQuanridade: TQRDBText;
    QRShape72: TQRShape;
    qtValUnit: TQRDBText;
    QRShape73: TQRShape;
    qtValTot: TQRDBText;
    QRShape74: TQRShape;
    qtBasIcms: TQRLabel;
    QRShape75: TQRShape;
    qtICMSVal: TQRLabel;
    QRShape76: TQRShape;
    qtIPIVal: TQRDBText;
    QRShape77: TQRShape;
    QRShape78: TQRShape;
    qtAliqIPI: TQRDBText;
    QRShape79: TQRShape;
    QRSysData1: TQRSysData;
    qbCalculoIssqn: TQRBand;
    QRLabel81: TQRLabel;
    QRShape66: TQRShape;
    QRLabel82: TQRLabel;
    QRDBText3: TQRDBText;
    QRShape80: TQRShape;
    QRLabel83: TQRLabel;
    QRDBText5: TQRDBText;
    QRShape81: TQRShape;
    QRLabel84: TQRLabel;
    qtvBC: TQRDBText;
    QRShape82: TQRShape;
    QRLabel85: TQRLabel;
    QRDBText8: TQRDBText;
    QRDBText9: TQRDBText;
    cbDadosAdicionais: TQRChildBand;
    QRLabel86: TQRLabel;
    QRLabel87: TQRLabel;
    QRDBText10: TQRDBText;
    QRShape83: TQRShape;
    QRLabel3: TQRLabel;
    QRLabel5: TQRLabel;
    QRLabel9: TQRLabel;
    cdsItensDaNota: TClientDataSet;
    cdsVolumesTransportados: TClientDataSet;
    cdsParcelasDaNota: TClientDataSet;
    cdsNotaFiscalversao: TStringField;
    cdsNotaFiscalinfNFe_Id: TStringField;
    cdsNotaFiscalcUF: TStringField;
    cdsNotaFiscalcNF: TStringField;
    cdsNotaFiscalnatOp: TStringField;
    cdsNotaFiscalindPag: TStringField;
    cdsNotaFiscalmod: TStringField;
    cdsNotaFiscalserie: TStringField;
    cdsNotaFiscalnNF: TStringField;
    cdsNotaFiscalide_dEmi: TDateField;
    cdsNotaFiscaldSaiEnt: TDateField;
    cdsNotaFiscaltpNF: TStringField;
    cdsNotaFiscalcMunFG1: TStringField;
    cdsNotaFiscaltpImp: TStringField;
    cdsNotaFiscaltpEmis: TStringField;
    cdsNotaFiscalcDV: TStringField;
    cdsNotaFiscaltpAmb: TStringField;
    cdsNotaFiscalfinNFe: TStringField;
    cdsNotaFiscalprocEmi: TStringField;
    cdsNotaFiscalverProc: TStringField;
    cdsNotaFiscalemit_CNPJ: TStringField;
    cdsNotaFiscalemit_CPF: TStringField;
    cdsNotaFiscalemit_xNome: TStringField;
    cdsNotaFiscalxFant: TStringField;
    cdsNotaFiscalenderEmit_xLgr: TStringField;
    cdsNotaFiscalenderEmit_nro: TStringField;
    cdsNotaFiscalenderEmit_xCpl: TStringField;
    cdsNotaFiscalenderEmit_xBairro: TStringField;
    cdsNotaFiscalenderEmit_cMun: TStringField;
    cdsNotaFiscalenderEmit_xMun: TStringField;
    cdsNotaFiscalenderEmit_UF: TStringField;
    cdsNotaFiscalenderEmit_CEP: TStringField;
    cdsNotaFiscalenderEmit_cPais: TStringField;
    cdsNotaFiscalenderEmit_xPais: TStringField;
    cdsNotaFiscalenderEmit_fone: TStringField;
    cdsNotaFiscalemit_IE: TStringField;
    cdsNotaFiscalIEST: TStringField;
    cdsNotaFiscalIM: TStringField;
    cdsNotaFiscalCNAE: TStringField;
    cdsNotaFiscalavulsa_CNPJ: TStringField;
    cdsNotaFiscalxOrgao: TStringField;
    cdsNotaFiscalmatr: TStringField;
    cdsNotaFiscalxAgente: TStringField;
    cdsNotaFiscalfone: TStringField;
    cdsNotaFiscalavulsa_UF: TStringField;
    cdsNotaFiscalnDAR: TStringField;
    cdsNotaFiscalavulsa_dEmi: TDateField;
    cdsNotaFiscalvDAR: TStringField;
    cdsNotaFiscalrepEmi: TStringField;
    cdsNotaFiscaldPag: TDateField;
    cdsNotaFiscaldest_CNPJ: TStringField;
    cdsNotaFiscaldest_CPF: TStringField;
    cdsNotaFiscaldest_xNome: TStringField;
    cdsNotaFiscalenderDest_xLgr: TStringField;
    cdsNotaFiscalenderDest_nro: TStringField;
    cdsNotaFiscalenderDest_xCpl: TStringField;
    cdsNotaFiscalenderDest_xBairro: TStringField;
    cdsNotaFiscalenderDest_cMun: TStringField;
    cdsNotaFiscalenderDest_xMun: TStringField;
    cdsNotaFiscalenderDest_UF: TStringField;
    cdsNotaFiscalenderDest_CEP: TStringField;
    cdsNotaFiscalenderDest_cPais: TStringField;
    cdsNotaFiscalenderDest_xPais: TStringField;
    cdsNotaFiscalenderDest_fone: TStringField;
    cdsNotaFiscaldest_IE: TStringField;
    cdsNotaFiscalISUF: TStringField;
    cdsNotaFiscalretirada_CNPJ: TStringField;
    cdsNotaFiscalretirada_xLgr: TStringField;
    cdsNotaFiscalretirada_nro: TStringField;
    cdsNotaFiscalretirada_xCpl: TStringField;
    cdsNotaFiscalretirada_xBairro: TStringField;
    cdsNotaFiscalretirada_cMun: TStringField;
    cdsNotaFiscalretirada_xMun: TStringField;
    cdsNotaFiscalretirada_UF: TStringField;
    cdsNotaFiscalentrega_CNPJ: TStringField;
    cdsNotaFiscalentrega_xLgr: TStringField;
    cdsNotaFiscalentrega_nro: TStringField;
    cdsNotaFiscalentrega_xCpl: TStringField;
    cdsNotaFiscalentrega_xBairro: TStringField;
    cdsNotaFiscalentrega_cMun: TStringField;
    cdsNotaFiscalentrega_xMun: TStringField;
    cdsNotaFiscalentrega_UF: TStringField;
    cdsNotaFiscalICMSTot_vBC: TStringField;
    cdsNotaFiscalvICMS: TStringField;
    cdsNotaFiscalvBCST: TStringField;
    cdsNotaFiscalvST: TStringField;
    cdsNotaFiscalvProd: TStringField;
    cdsNotaFiscalvFrete: TStringField;
    cdsNotaFiscalvSeg: TStringField;
    cdsNotaFiscalICMSTot_vDesc: TStringField;
    cdsNotaFiscalvII: TStringField;
    cdsNotaFiscalvIPI: TStringField;
    cdsNotaFiscalICMSTot_vPIS: TStringField;
    cdsNotaFiscalICMSTot_vCOFINS: TStringField;
    cdsNotaFiscalvOutro: TStringField;
    cdsNotaFiscalvNF: TStringField;
    cdsNotaFiscalISSQNtot_vServ: TStringField;
    cdsNotaFiscalISSQNtot_vBC: TStringField;
    cdsNotaFiscalvISS: TStringField;
    cdsNotaFiscalISSQNtot_vPIS: TStringField;
    cdsNotaFiscalISSQNtot_vCOFINS: TStringField;
    cdsNotaFiscalvRetPIS: TStringField;
    cdsNotaFiscalvRetCOFINS: TStringField;
    cdsNotaFiscalvRetCSLL: TStringField;
    cdsNotaFiscalvBCIRRF: TStringField;
    cdsNotaFiscalvIRRF: TStringField;
    cdsNotaFiscalvBCRetPrev: TStringField;
    cdsNotaFiscalvRetPrev: TStringField;
    cdsNotaFiscalmodFrete: TStringField;
    cdsNotaFiscalCNPJ: TStringField;
    cdsNotaFiscalCPF: TStringField;
    cdsNotaFiscalxNome: TStringField;
    cdsNotaFiscalIE: TStringField;
    cdsNotaFiscalxEnder: TStringField;
    cdsNotaFiscaltransporta_xMun: TStringField;
    cdsNotaFiscaltransporta_UF: TStringField;
    cdsNotaFiscalretTransp_vServ: TStringField;
    cdsNotaFiscalvBCRet: TStringField;
    cdsNotaFiscalpICMSRet: TStringField;
    cdsNotaFiscalvICMSRet: TStringField;
    cdsNotaFiscalCFOP: TStringField;
    cdsNotaFiscalcMunFG2: TStringField;
    cdsNotaFiscalveicTransp_placa: TStringField;
    cdsNotaFiscalveicTransp_UF: TStringField;
    cdsNotaFiscalveicTransp_RNTC: TStringField;
    cdsNotaFiscalreboque_placa: TStringField;
    cdsNotaFiscalreboque_UF: TStringField;
    cdsNotaFiscalreboque_RNTC: TStringField;
    cdsNotaFiscalnFat: TStringField;
    cdsNotaFiscalvOrig: TStringField;
    cdsNotaFiscalfat_vDesc: TStringField;
    cdsNotaFiscalvLiq: TStringField;
    cdsNotaFiscalinfAdFisco: TStringField;
    cdsNotaFiscalinfCpl: TStringField;
    cdsNotaFiscalobsCont_xCampo: TStringField;
    cdsNotaFiscalobsCont_xTexto: TStringField;
    cdsNotaFiscalobsFisco_xCampo: TStringField;
    cdsNotaFiscalobsFisco_xTexto: TStringField;
    cdsNotaFiscalUFEmbarq: TStringField;
    cdsNotaFiscalxLocEmbarq: TStringField;
    cdsNotaFiscalxNEmp: TStringField;
    cdsNotaFiscalxPed: TStringField;
    cdsNotaFiscalxCont: TStringField;
    cdsNotaFiscalSignature_Id: TStringField;
    cdsNotaFiscalSignedInfo_Id: TStringField;
    cdsNotaFiscalAlgorithm1: TStringField;
    cdsNotaFiscalSignatureMethod_Algorithm: TStringField;
    cdsNotaFiscalId: TStringField;
    cdsNotaFiscalURI: TStringField;
    cdsNotaFiscalType: TStringField;
    cdsNotaFiscalAlgorithm2: TStringField;
    cdsNotaFiscalXPath: TStringField;
    cdsNotaFiscalAlgorithm3: TStringField;
    cdsNotaFiscalDigestValue: TStringField;
    cdsNotaFiscalSignatureValue_Id: TStringField;
    cdsNotaFiscalKeyInfo_Id: TStringField;
    cdsNotaFiscalX509Certificate: TStringField;
    cdsNotaFiscalNFref: TDataSetField;
    cdsNotaFiscalvol: TDataSetField;
    cdsNotaFiscaldup: TDataSetField;
    cdsNotaFiscalprocRef: TDataSetField;
    cdsVolumesTransportadosqVol: TStringField;
    cdsVolumesTransportadosesp: TStringField;
    cdsVolumesTransportadosmarca: TStringField;
    cdsVolumesTransportadosnVol: TStringField;
    cdsVolumesTransportadospesoL: TStringField;
    cdsVolumesTransportadospesoB: TStringField;
    cdsVolumesTransportadoslacres: TDataSetField;
    QRShape87: TQRShape;
    cdsLotesDoProduto: TClientDataSet;
    dsFatIns: TDataSource;
    cdsLotesDoProdutonLote: TStringField;
    cdsLotesDoProdutoqLote: TStringField;
    cdsLotesDoProdutodFab: TDateField;
    cdsLotesDoProdutodVal: TDateField;
    cdsLotesDoProdutovPMC: TStringField;
    QRLabel10: TQRLabel;
    cdsParcelasDaNotanDup: TStringField;
    cdsParcelasDaNotadVenc: TDateField;
    cdsParcelasDaNotavDup: TStringField;
    cdsNotaFiscaldet: TDataSetField;
    cdsItensDaNotanItem: TStringField;
    cdsItensDaNotacProd: TStringField;
    cdsItensDaNotacEAN: TStringField;
    cdsItensDaNotaxProd: TStringField;
    cdsItensDaNotaNCM: TStringField;
    cdsItensDaNotaEXTIPI: TStringField;
    cdsItensDaNotagenero: TStringField;
    cdsItensDaNotaCFOP: TStringField;
    cdsItensDaNotauCom: TStringField;
    cdsItensDaNotaqCom: TStringField;
    cdsItensDaNotavUnCom: TStringField;
    cdsItensDaNotavProd: TStringField;
    cdsItensDaNotacEANTrib: TStringField;
    cdsItensDaNotauTrib: TStringField;
    cdsItensDaNotaqTrib: TStringField;
    cdsItensDaNotavUnTrib: TStringField;
    cdsItensDaNotavFrete: TStringField;
    cdsItensDaNotavSeg: TStringField;
    cdsItensDaNotavDesc: TStringField;
    cdsItensDaNotatpOp: TStringField;
    cdsItensDaNotachassi: TStringField;
    cdsItensDaNotacCor: TStringField;
    cdsItensDaNotaxCor: TStringField;
    cdsItensDaNotapot: TStringField;
    cdsItensDaNotaCM3: TStringField;
    cdsItensDaNotapesoL: TStringField;
    cdsItensDaNotapesoB: TStringField;
    cdsItensDaNotanSerie: TStringField;
    cdsItensDaNotatpComb: TStringField;
    cdsItensDaNotanMotor: TStringField;
    cdsItensDaNotaCMKG: TStringField;
    cdsItensDaNotadist: TStringField;
    cdsItensDaNotaRENAVAM: TStringField;
    cdsItensDaNotaanoMod: TStringField;
    cdsItensDaNotaanoFab: TStringField;
    cdsItensDaNotatpPint: TStringField;
    cdsItensDaNotatpVeic: TStringField;
    cdsItensDaNotaespVeic: TStringField;
    cdsItensDaNotaVIN: TStringField;
    cdsItensDaNotacondVeic: TStringField;
    cdsItensDaNotacMod: TStringField;
    cdsItensDaNotacProdANP: TStringField;
    cdsItensDaNotaCODIF: TStringField;
    cdsItensDaNotaqTemp: TStringField;
    cdsItensDaNotaCIDE_qBCProd: TStringField;
    cdsItensDaNotaCIDE_vAliqProd: TStringField;
    cdsItensDaNotavCIDE: TStringField;
    cdsItensDaNotavBCICMS: TStringField;
    cdsItensDaNotaICMSComb_vICMS: TStringField;
    cdsItensDaNotavBCICMSST: TStringField;
    cdsItensDaNotaICMSComb_vICMSST: TStringField;
    cdsItensDaNotavBCICMSSTDest: TStringField;
    cdsItensDaNotavICMSSTDest: TStringField;
    cdsItensDaNotavBCICMSSTCons: TStringField;
    cdsItensDaNotavICMSSTCons: TStringField;
    cdsItensDaNotaUFCons: TStringField;
    cdsItensDaNotaICMS00_orig: TStringField;
    cdsItensDaNotaICMS00_CST: TStringField;
    cdsItensDaNotaICMS00_modBC: TStringField;
    cdsItensDaNotaICMS00_vBC: TStringField;
    cdsItensDaNotaICMS00_pICMS: TStringField;
    cdsItensDaNotaICMS00_vICMS: TStringField;
    cdsItensDaNotaICMS10_orig: TStringField;
    cdsItensDaNotaICMS10_CST: TStringField;
    cdsItensDaNotaICMS10_modBC: TStringField;
    cdsItensDaNotaICMS10_vBC: TStringField;
    cdsItensDaNotaICMS10_pICMS: TStringField;
    cdsItensDaNotaICMS10_vICMS: TStringField;
    cdsItensDaNotaICMS10_modBCST: TStringField;
    cdsItensDaNotaICMS10_pMVAST: TStringField;
    cdsItensDaNotaICMS10_pRedBCST: TStringField;
    cdsItensDaNotaICMS10_vBCST: TStringField;
    cdsItensDaNotaICMS10_pICMSST: TStringField;
    cdsItensDaNotaICMS10_vICMSST: TStringField;
    cdsItensDaNotaICMS20_orig: TStringField;
    cdsItensDaNotaICMS20_CST: TStringField;
    cdsItensDaNotaICMS20_modBC: TStringField;
    cdsItensDaNotaICMS20_pRedBC: TStringField;
    cdsItensDaNotaICMS20_vBC: TStringField;
    cdsItensDaNotaICMS20_pICMS: TStringField;
    cdsItensDaNotaICMS20_vICMS: TStringField;
    cdsItensDaNotaICMS30_orig: TStringField;
    cdsItensDaNotaICMS30_CST: TStringField;
    cdsItensDaNotaICMS30_modBCST: TStringField;
    cdsItensDaNotaICMS30_pMVAST: TStringField;
    cdsItensDaNotaICMS30_pRedBCST: TStringField;
    cdsItensDaNotaICMS30_vBCST: TStringField;
    cdsItensDaNotaICMS30_pICMSST: TStringField;
    cdsItensDaNotaICMS30_vICMSST: TStringField;
    cdsItensDaNotaICMS40_orig: TStringField;
    cdsItensDaNotaICMS40_CST: TStringField;
    cdsItensDaNotaICMS51_orig: TStringField;
    cdsItensDaNotaICMS51_CST: TStringField;
    cdsItensDaNotaICMS51_modBC: TStringField;
    cdsItensDaNotaICMS51_pRedBC: TStringField;
    cdsItensDaNotaICMS51_vBC: TStringField;
    cdsItensDaNotaICMS51_pICMS: TStringField;
    cdsItensDaNotaICMS51_vICMS: TStringField;
    cdsItensDaNotaICMS60_orig: TStringField;
    cdsItensDaNotaICMS60_CST: TStringField;
    cdsItensDaNotaICMS60_vBCST: TStringField;
    cdsItensDaNotaICMS60_vICMSST: TStringField;
    cdsItensDaNotaICMS70_orig: TStringField;
    cdsItensDaNotaICMS70_CST: TStringField;
    cdsItensDaNotaICMS70_modBC: TStringField;
    cdsItensDaNotaICMS70_pRedBC: TStringField;
    cdsItensDaNotaICMS70_vBC: TStringField;
    cdsItensDaNotaICMS70_pICMS: TStringField;
    cdsItensDaNotaICMS70_vICMS: TStringField;
    cdsItensDaNotaICMS70_modBCST: TStringField;
    cdsItensDaNotaICMS70_pMVAST: TStringField;
    cdsItensDaNotaICMS70_pRedBCST: TStringField;
    cdsItensDaNotaICMS70_vBCST: TStringField;
    cdsItensDaNotaICMS70_pICMSST: TStringField;
    cdsItensDaNotaICMS70_vICMSST: TStringField;
    cdsItensDaNotaICMS90_orig: TStringField;
    cdsItensDaNotaICMS90_CST: TStringField;
    cdsItensDaNotaICMS90_modBC: TStringField;
    cdsItensDaNotaICMS90_vBC: TStringField;
    cdsItensDaNotaICMS90_pRedBC: TStringField;
    cdsItensDaNotaICMS90_pICMS: TStringField;
    cdsItensDaNotaICMS90_vICMS: TStringField;
    cdsItensDaNotaICMS90_modBCST: TStringField;
    cdsItensDaNotaICMS90_pMVAST: TStringField;
    cdsItensDaNotaICMS90_pRedBCST: TStringField;
    cdsItensDaNotaICMS90_vBCST: TStringField;
    cdsItensDaNotaICMS90_pICMSST: TStringField;
    cdsItensDaNotaICMS90_vICMSST: TStringField;
    cdsItensDaNotaclEnq: TStringField;
    cdsItensDaNotaCNPJProd: TStringField;
    cdsItensDaNotacSelo: TStringField;
    cdsItensDaNotaqSelo: TStringField;
    cdsItensDaNotacEnq: TStringField;
    cdsItensDaNotaIPITrib_CST: TStringField;
    cdsItensDaNotaIPITrib_vBC: TStringField;
    cdsItensDaNotapIPI: TStringField;
    cdsItensDaNotaqUnid: TStringField;
    cdsItensDaNotavUnid: TStringField;
    cdsItensDaNotavIPI: TStringField;
    cdsItensDaNotaIPINT_CST: TStringField;
    cdsItensDaNotaII_vBC: TStringField;
    cdsItensDaNotavDespAdu: TStringField;
    cdsItensDaNotavII: TStringField;
    cdsItensDaNotavIOF: TStringField;
    cdsItensDaNotaPISAliq_CST: TStringField;
    cdsItensDaNotaPISAliq_vBC: TStringField;
    cdsItensDaNotaPISAliq_pPIS: TStringField;
    cdsItensDaNotaPISAliq_vPIS: TStringField;
    cdsItensDaNotaPISQtde_CST: TStringField;
    cdsItensDaNotaPISQtde_qBCProd: TStringField;
    cdsItensDaNotaPISQtde_vAliqProd: TStringField;
    cdsItensDaNotaPISQtde_vPIS: TStringField;
    cdsItensDaNotaPISNT_CST: TStringField;
    cdsItensDaNotaPISOutr_CST: TStringField;
    cdsItensDaNotaPISOutr_vBC: TStringField;
    cdsItensDaNotaPISOutr_pPIS: TStringField;
    cdsItensDaNotaPISOutr_qBCProd: TStringField;
    cdsItensDaNotaPISOutr_vAliqProd: TStringField;
    cdsItensDaNotaPISOutr_vPIS: TStringField;
    cdsItensDaNotaPISST_vBC: TStringField;
    cdsItensDaNotapPIS: TStringField;
    cdsItensDaNotaPISST_qBCProd: TStringField;
    cdsItensDaNotaPISST_vAliqProd: TStringField;
    cdsItensDaNotavPIS: TStringField;
    cdsItensDaNotaCOFINSAliq_CST: TStringField;
    cdsItensDaNotaCOFINSAliq_vBC: TStringField;
    cdsItensDaNotaCOFINSAliq_pCOFINS: TStringField;
    cdsItensDaNotaCOFINSAliq_vCOFINS: TStringField;
    cdsItensDaNotaCOFINSQtde_CST: TStringField;
    cdsItensDaNotaCOFINSQtde_qBCProd: TStringField;
    cdsItensDaNotaCOFINSQtde_vAliqProd: TStringField;
    cdsItensDaNotaCOFINSQtde_vCOFINS: TStringField;
    cdsItensDaNotaCOFINSNT_CST: TStringField;
    cdsItensDaNotaCOFINSOutr_CST: TStringField;
    cdsItensDaNotaCOFINSOutr_vBC: TStringField;
    cdsItensDaNotaCOFINSOutr_pCOFINS: TStringField;
    cdsItensDaNotaCOFINSOutr_qBCProd: TStringField;
    cdsItensDaNotaCOFINSOutr_vAliqProd: TStringField;
    cdsItensDaNotaCOFINSOutr_vCOFINS: TStringField;
    cdsItensDaNotaCOFINSST_vBC: TStringField;
    cdsItensDaNotapCOFINS: TStringField;
    cdsItensDaNotaCOFINSST_qBCProd: TStringField;
    cdsItensDaNotaCOFINSST_vAliqProd: TStringField;
    cdsItensDaNotavCOFINS: TStringField;
    cdsItensDaNotaISSQN_vBC: TStringField;
    cdsItensDaNotavAliq: TStringField;
    cdsItensDaNotavISSQN: TStringField;
    cdsItensDaNotacMunFG: TStringField;
    cdsItensDaNotacListServ: TStringField;
    cdsItensDaNotainfAdProd: TStringField;
    cdsItensDaNotaDI: TDataSetField;
    cdsItensDaNotamed: TDataSetField;
    cdsItensDaNotaarma: TDataSetField;
    qbSubCabecalho: TQRBand;
    QRShape88: TQRShape;
    QRShape89: TQRShape;
    QRShape90: TQRShape;
    QRShape91: TQRShape;
    QRShape92: TQRShape;
    QRShape93: TQRShape;
    QRShape94: TQRShape;
    QRShape95: TQRShape;
    QRShape96: TQRShape;
    QRShape97: TQRShape;
    QRLabel88: TQRLabel;
    QRLabel89: TQRLabel;
    QRLabel91: TQRLabel;
    QRLabel94: TQRLabel;
    QRLabel95: TQRLabel;
    QRLabel96: TQRLabel;
    QRLabel97: TQRLabel;
    QRLabel98: TQRLabel;
    QRLabel99: TQRLabel;
    QRLabel100: TQRLabel;
    QRLabel101: TQRLabel;
    QRShape98: TQRShape;
    QRShape99: TQRShape;
    QRLabel102: TQRLabel;
    QRLabel103: TQRLabel;
    QRShape100: TQRShape;
    QRLabel104: TQRLabel;
    QRShape101: TQRShape;
    qiCodigoBarras: TQRImage;
    qtFatPnsNum002: TQRLabel;
    qlvLiq01: TQRLabel;
    qlvLiq02: TQRLabel;
    qlfat_vDesc02: TQRLabel;
    qlfat_vDesc01: TQRLabel;
    qtFatPnsNum001: TQRLabel;
    qtFatPnsNum003: TQRLabel;
    qlfat_vDesc03: TQRLabel;
    qlvLiq03: TQRLabel;
    QRShape102: TQRShape;
    QRShape103: TQRShape;
    QRShape104: TQRShape;
    QRShape105: TQRShape;
    QRShape106: TQRShape;
    QRShape107: TQRShape;
    QRShape54: TQRShape;
    QRAliqICMS: TQRLabel;
    QRLabel105: TQRLabel;
    QRLabel106: TQRLabel;
    QRShape108: TQRShape;
    QRShape109: TQRShape;
    QRnProt: TQRLabel;
    QRShape8: TQRShape;
    QRShape110: TQRShape;
    QRLabel107: TQRLabel;
    XTPPROT: TXMLTransformProvider;
    cdsProtNFe: TClientDataSet;
    dsProtNFe: TDataSource;
    cdsProtNFeversao: TStringField;
    cdsProtNFeId: TStringField;
    cdsProtNFetpAmb: TStringField;
    cdsProtNFeverAplic: TStringField;
    cdsProtNFechNFe: TStringField;
    cdsProtNFedhRecbto: TStringField;
    cdsProtNFenProt: TStringField;
    cdsProtNFedigVal: TStringField;
    cdsProtNFecStat: TStringField;
    cdsProtNFexMotivo: TStringField;
    QRShape111: TQRShape;
    QRShape112: TQRShape;
    QRShape53: TQRShape;
    QRShape113: TQRShape;
    QRShape114: TQRShape;
    procedure qrRelatorioBeforePrint(Sender: TCustomQuickRep;
      var PrintReport: Boolean);
    procedure QRDBText6Print(sender: TObject; var Value: String);
    procedure QRDBText7Print(sender: TObject; var Value: String);
    procedure qtEnderEmit_xLgrPrint(sender: TObject; var Value: String);
    procedure cdsNotaFiscalAfterOpen(DataSet: TDataSet);
    procedure qtSysCidNomPrint(sender: TObject; var Value: String);
    procedure qtSysCliTelPrint(sender: TObject; var Value: String);
    procedure qbCanhotoDaNotaBeforePrint(Sender: TQRCustomBand;
      var PrintBand: Boolean);
    procedure QRSysData1Print(sender: TObject; var Value: String);
    procedure qtFoneFaxPrint(sender: TObject; var Value: String);
    procedure QRDBText9Print(sender: TObject; var Value: String);
    procedure QRDBText10Print(sender: TObject; var Value: String);
    procedure QRLabel3Print(sender: TObject; var Value: String);
    procedure QRLabel5Print(sender: TObject; var Value: String);
    procedure qtCSTPrint(sender: TObject; var Value: String);
    procedure qtBasIcmsPrint(sender: TObject; var Value: String);
    procedure qtICMSValPrint(sender: TObject; var Value: String);

    procedure qbCalculoIssqnBeforePrint(Sender: TQRCustomBand;
      var PrintBand: Boolean);
    procedure cbDadosAdicionaisBeforePrint(Sender: TQRCustomBand;
      var PrintBand: Boolean);
    procedure qtChaveAcessoPrint(sender: TObject; var Value: String);
    procedure qtDescProdPrint(sender: TObject; var Value: String);
    procedure qtEstProCodPrint(sender: TObject; var Value: String);
    procedure qbSubCabecalhoBeforePrint(Sender: TQRCustomBand;
      var PrintBand: Boolean);
    procedure qbSubCabecalhoAfterPrint(Sender: TQRCustomBand;
      BandPrinted: Boolean);
    procedure QRDBText2Print(sender: TObject; var Value: String);
    procedure FormCreate(Sender: TObject);
    procedure qtdest_CNPJPrint(sender: TObject; var Value: String);

    procedure QRAliqICMSPrint(sender: TObject; var Value: String);

  private
    { Private declarations }
    _NFEUtils : NFEUtils;
    ImprimirSubCabecalho: boolean;
    function GetNFEUtils: NFEUtils;
  public
    { Public declarations }
    TotalDePaginas: integer;
    property Utils: NFEUtils read GetNFEUtils;
  end;

var
  DANFEREL: TDANFEREL;

implementation

{$R *.DFM}




procedure TDANFEREL.FormCreate(Sender: TObject);
begin
  {Inicia variáveis.}
  TotalDePaginas := 1;
end;

procedure TDANFEREL.qrRelatorioBeforePrint(Sender: TCustomQuickRep;
  var PrintReport: Boolean);
var
  Msg: string;
  ArqNom, ArqBar: string;
  I: Integer;
  ratio : Extended;
  dhRecbto : string;
//  codigo : String;
begin
  {Fecha os datasets.}
  cdsNotaFiscal.Close;
  cdsItensDaNota.Close;
  cdsVolumesTransportados.Close;
  cdsParcelasDaNota.Close;
  cdsProtNFe.Close;
  {Imprime variáveis.}
  ImprimirSubCabecalho := false;
  {Carrega o schema xtr.}
  ArqNom := ExtractFilePath(Application.ExeName) + 'xsd\ToDp.xtr';
  XTPNFE.TransformRead.TransformationFile  := ArqNom;
  XTPNFE.TransformWrite.TransformationFile := ArqNom;

  ArqNom := ExtractFilePath(Application.ExeName) + 'xsd\ToDpProtNFe.xtr';
  XTPPROT.TransformRead.TransformationFile  := ArqNom;
  XTPPROT.TransformWrite.TransformationFile := ArqNom;
  {Carrega a logomarca.}
  if FileExists(ExtractFilePath(Application.ExeName) + 'Logomarca.bmp') then
  begin
    ArqNom := ExtractFilePath(Application.ExeName) + 'Logomarca.bmp';
    qiLogomarca.Picture.LoadFromFile(ArqNom);
    ratio := qiLogomarca.Picture.Bitmap.Height / qiLogomarca.Picture.Bitmap.Width;
    qiLogomarca.Picture.Bitmap.Height := Round(qiLogomarca.Width / ratio);
  end;
  {Carrega os dados do xml.}
  cdsNotaFiscal.Open;
  cdsItensDaNota.Open;
  cdsVolumesTransportados.Open;
  cdsParcelasDaNota.Open;
  cdsProtNFe.Open;
  {carrega a chave da nota no titulo do relatorio}
  qrRelatorio.ReportTitle := cdsNotaFiscalinfNFe_Id.Text;

  //converter dhRecbto para 12/03/2009 10:00:00
  dhRecbto := copy(cdsProtNFedhRecbto.Text, 9 , 2); //dia
  dhRecbto := dhRecbto + '/' + copy(cdsProtNFedhRecbto.Text, 6 , 2); //mes
  dhRecbto := dhRecbto + '/' + copy(cdsProtNFedhRecbto.Text, 0 , 4); //ano
  dhRecbto := dhRecbto + ' ' + copy(cdsProtNFedhRecbto.Text, 12 , 8); //horas

  QRnProt.Caption := cdsProtNFenProt.Text + ' ' + dhRecbto;
  //'11090123456789 12/03/2009 10:00:00'; //formatação do nProt

  {Carrega o código de barras.}
//Quando a chave ficar faltando os ultimos 3 digitos,
//verificar o toDp.xtr, length da infnfe_id.
//mudar de 44 para 47.
//se continuar dando problema, utilizar essa codificacao :
//  codigo := cdsNotaFiscalcUF.Text + copy(cdsNotaFiscalide_dEmi.Text,9,2);
//  codigo := codigo + copy(cdsNotaFiscalide_dEmi.Text,4,2);
//  codigo := codigo + cdsNotaFiscalemit_CNPJ.Text;
//  codigo := codigo + cdsNotaFiscalmod.Text + StringOfChar( '0', 3 - Length( Trim(cdsNotaFiscalserie.Text) ) ) + Trim(cdsNotaFiscalserie.Text);
//  codigo := codigo + StringOfChar( '0', 9 - Length( Trim(cdsNotaFiscalnNF.Text) ) ) + Trim(cdsNotaFiscalnNF.Text);
//  codigo := codigo + StringOfChar( '0', 9 - Length( Trim(cdsNotaFiscalcNF.Text) ) ) + Trim(cdsNotaFiscalcNF.Text);
//  codigo := codigo + cdsNotaFiscalcDV.Text;
//  CodigoBarras.Texto := codigo;
  CodigoBarras.Texto := copy(cdsNotaFiscal.FieldByName('infNFe_Id').AsString, 4, 44);
  // Retirado porque trabalhando em REDE poderá dar problema de
  // erro de gravação.

  //  ArqBar := ExtractFilePath(Application.ExeName) + cdsNotaFiscal.FieldByName('infNFe_Id').AsString + '.bmp';
  ArqBar := 'C:\' + cdsNotaFiscal.FieldByName('infNFe_Id').AsString + '.bmp';

  CodigoBarras.Picture.SaveToFile(ArqBar);
  if FileExists(ArqBar) then
  begin
    qiCodigoBarras.Picture.LoadFromFile(ArqBar);
    DeleteFile(ArqBar);
  end;
  qtFatPnsNum001.Caption := '';
  qtFatPnsNum002.Caption := '';
  qtFatPnsNum003.Caption := '';
  qlvLiq01.Caption := '';
  qlvLiq02.Caption := '';
  qlvLiq03.Caption := '';
  qlfat_vDesc01.caption := '';
  qlfat_vDesc02.Caption := '';
  qlfat_vDesc03.Caption := '';
  I := 1;

  while (Not cdsParcelasDaNota.Eof) and (I >= 1) and (I <= 5) do
  begin

    qtFatPnsNum001.Caption := qtFatPnsNum001.Caption +
             cdsParcelasDaNota.FieldByName('nDup').AsString + #13;

    qlfat_vDesc01.Caption := qlfat_vDesc01.Caption +
             cdsParcelasDaNota.FieldByName('dVenc').AsString + #13;

    qlvLiq01.Caption := qlvLiq01.Caption +
             cdsParcelasDaNota.FieldByName('vDup').AsString + #13;

    cdsParcelasDaNota.Next;
    Inc(I);
  end;

  while (Not cdsParcelasDaNota.Eof) and (I >= 6) and (I <= 10) do
  begin

    qtFatPnsNum002.Caption := qtFatPnsNum002.Caption +
             cdsParcelasDaNota.FieldByName('nDup').AsString + #13;

    qlfat_vDesc02.Caption := qlfat_vDesc02.Caption +
             cdsParcelasDaNota.FieldByName('dVenc').AsString + #13;

    qlvLiq02.Caption := qlvLiq02.Caption +
             cdsParcelasDaNota.FieldByName('vDup').AsString + #13;

    cdsParcelasDaNota.Next;
    Inc(I);
  end;

  while (Not cdsParcelasDaNota.Eof) and (I >= 11) and (I <= 15) do
  begin

    qtFatPnsNum003.Caption := qtFatPnsNum003.Caption +
             cdsParcelasDaNota.FieldByName('nDup').AsString + #13;

    qlfat_vDesc03.Caption := qlfat_vDesc03.Caption +
             cdsParcelasDaNota.FieldByName('dVenc').AsString + #13;

    qlvLiq03.Caption := qlvLiq03.Caption +
             cdsParcelasDaNota.FieldByName('vDup').AsString + #13;

    cdsParcelasDaNota.Next;
    Inc(I);
  end;

//  QLtpAmb.Enabled := (cdsNotaFiscaltpAmb.Text = '2');
end;

procedure TDANFEREL.cdsNotaFiscalAfterOpen(DataSet: TDataSet);
begin

  with cdsNotaFiscal do
  begin
    FieldByName('EnderEmit_CEP').EditMask  := '99\.999\-999;0;_';
    FieldByName('EnderEmit_Fone').EditMask := '\(cc99\)cc99\.9999;0;_';
    FieldByName('Emit_CNPJ').EditMask      := '99\.999\.999\/9999\-99;0;_';
    FieldByName('Dest_CNPJ').EditMask      := '99\.999\.999\/9999\-99;0;_';
    FieldByName('EnderDest_CEP').EditMask  := '99\.999\-999;0;_';
    FieldByName('CNPJ').EditMask           := '99\.999\.999\/9999\-99;0;_';

  end;
end;

procedure TDANFEREL.QRDBText6Print(sender: TObject; var Value: String);
begin
  Value := 'Nº ' + Value;
end;

procedure TDANFEREL.QRDBText7Print(sender: TObject; var Value: String);
begin
  Value := 'Série ' + Value;
end;

procedure TDANFEREL.qtEnderEmit_xLgrPrint(sender: TObject; var Value: String);
begin
  Value := Value + ' ' +
           cdsNotaFiscal.FieldByName('EnderEmit_Nro').AsString + ' ' +
           cdsNotaFiscal.FieldByName('EnderEmit_xCpl').AsString;
end;

procedure TDANFEREL.qtSysCidNomPrint(sender: TObject; var Value: String);
begin
  Value := Value + ' ' +
           cdsNotaFiscal.FieldByName('enderEmit_UF').AsString;
end;

procedure TDANFEREL.qtSysCliTelPrint(sender: TObject; var Value: String);
begin
  if length(cdsNotaFiscal.FieldByName('EnderEmit_Fone').AsString) = 10 then
  begin
    Value := '(' + copy(cdsNotaFiscal.FieldByName('EnderEmit_Fone').AsString, 1, 2) + ') ' +
             copy(cdsNotaFiscal.FieldByName('EnderEmit_Fone').AsString, 3, 4) + '.' +
             copy(cdsNotaFiscal.FieldByName('EnderEmit_Fone').AsString, 7, 4);
  end
  else
    Value := Value;
end;

procedure TDANFEREL.qbCanhotoDaNotaBeforePrint(Sender: TQRCustomBand;
  var PrintBand: Boolean);
begin
  PrintBand := (qrRelatorio.QRPrinter.PageNumber = 1);
end;

procedure TDANFEREL.QRSysData1Print(sender: TObject; var Value: String);
begin
  Value := Value + '/' + IntToStr(TotalDePaginas);
end;

procedure TDANFEREL.qtFoneFaxPrint(sender: TObject; var Value: String);
begin
  if length(cdsNotaFiscal.FieldByName('EnderDest_fone').AsString) = 10 then
  begin
    Value := '(' + copy(cdsNotaFiscal.FieldByName('EnderDest_fone').AsString, 1, 2) + ') ' +
             copy(cdsNotaFiscal.FieldByName('EnderDest_fone').AsString, 3, 4) + '.' +
             copy(cdsNotaFiscal.FieldByName('EnderDest_fone').AsString, 7, 4);
  end
  else
    Value := Value;
end;

procedure TDANFEREL.QRDBText9Print(sender: TObject; var Value: String);
var
  FatNsuValTot: string;
begin
  FatNsuValTot := Utils.ReplaceChar(cdsNotaFiscal.FieldByName('vNF').AsString, '.', ',');
  if (StrToFloat(FatNsuValTot) > 0) then
     Value := Utils.ValorExtensoDuasDecimais(StrToFloat(FatNsuValTot), ['real','centavo','reais','centavos'])
  else
     Value := '';
end;

procedure TDANFEREL.QRDBText10Print(sender: TObject; var Value: String);
begin
  Value := Value + ' ' + cdsNotaFiscal.FieldByName('InfAdFisco').AsString;
end;

procedure TDANFEREL.QRLabel3Print(sender: TObject; var Value: String);
begin
  Value := Utils.Se(cdsNotaFiscal.FieldByName('TpNF').AsString = '0', '0', '1');
end;

procedure TDANFEREL.QRLabel5Print(sender: TObject; var Value: String);
begin
//RDI : na danfe informava que 1 - emitente ; 2 - destinatario
// modificado para novo padrao : 0 - emitente ; 1 - destinatario
  Value := Utils.Se(cdsNotaFiscal.FieldByName('ModFrete').AsString = '0', '0', '1');
end;

procedure TDANFEREL.qtCSTPrint(sender: TObject; var Value: String);
begin
  if (cdsItensDaNota.FieldByName('ICMS00_CST').AsString <> '') then
     Value := cdsItensDaNotaICMS00_orig.Text + '00'
  else  if (cdsItensDaNota.FieldByName('ICMS10_CST').AsString <> '') then
     Value := cdsItensDaNotaICMS10_orig.Text + '10'
  else if (cdsItensDaNota.FieldByName('ICMS20_CST').AsString <> '') then
     Value := cdsItensDaNotaICMS20_orig.Text + '20'
  else   if (cdsItensDaNota.FieldByName('ICMS30_CST').AsString <> '') then
     Value := cdsItensDaNotaICMS30_orig.Text + '30'
  else   if (cdsItensDaNota.FieldByName('ICMS40_CST').AsString <> '') then
     Value := cdsItensDaNotaICMS40_orig.Text + '40'
  else   if (cdsItensDaNota.FieldByName('ICMS51_CST').AsString <> '') then
     Value := cdsItensDaNotaICMS51_orig.Text + '51'
  else   if (cdsItensDaNota.FieldByName('ICMS60_CST').AsString <> '') then
     Value := cdsItensDaNotaICMS60_orig.Text + '60'
  else   if (cdsItensDaNota.FieldByName('ICMS70_CST').AsString <> '') then
     Value := cdsItensDaNotaICMS70_orig.Text + '70'
  else   if (cdsItensDaNota.FieldByName('ICMS90_CST').AsString <> '') then
     Value := cdsItensDaNotaICMS90_orig.Text + '90';
end;

procedure TDANFEREL.qtBasIcmsPrint(sender: TObject; var Value: String);
begin
  if (cdsItensDaNota.FieldByName('ICMS00_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS00_vBc').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS00_vBc').AsString
    else
       Value := '0.00';
  end;

  if (cdsItensDaNota.FieldByName('ICMS10_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS10_vBc').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS10_vBc').AsString
    else
       Value := '0.00';
  end;


  if (cdsItensDaNota.FieldByName('ICMS20_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS20_vBc').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS20_vBc').AsString
    else
       Value := '0.00';
  end;


  if (cdsItensDaNota.FieldByName('ICMS30_CST').AsString <> '') then
     Value := '0.00';

  if (cdsItensDaNota.FieldByName('ICMS40_CST').AsString <> '') then
     Value := '0.00';

  if (cdsItensDaNota.FieldByName('ICMS51_CST').AsString <> '') then
       begin
    if(cdsItensDaNota.FieldByName('ICMS51_vBc').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS51_vBc').AsString
    else
       Value := '0.00';
  end;


  if (cdsItensDaNota.FieldByName('ICMS60_CST').AsString <> '') then
     Value := '0.00';

  if (cdsItensDaNota.FieldByName('ICMS70_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS70_vBc').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS70_vBc').AsString
    else
       Value := '0.00';
  end;


  if (cdsItensDaNota.FieldByName('ICMS90_CST').AsString <> '') then
       begin
    if(cdsItensDaNota.FieldByName('ICMS90_vBc').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS90_vBc').AsString
    else
       Value := '0.00';
  end;

end;

procedure TDANFEREL.qtICMSValPrint(sender: TObject; var Value: String);
begin
  if (cdsItensDaNota.FieldByName('ICMS00_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS00_vICMS').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS00_vICMS').AsString
    else
       Value := '0.00';
  end;

  if (cdsItensDaNota.FieldByName('ICMS10_CST').AsString <> '') then
    begin
    if(cdsItensDaNota.FieldByName('ICMS10_vICMS').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS10_vICMS').AsString
    else
       Value := '0.00';
  end;

  if (cdsItensDaNota.FieldByName('ICMS20_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS20_vICMS').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS20_vICMS').AsString
    else
       Value := '0.00';
  end;

  if (cdsItensDaNota.FieldByName('ICMS30_CST').AsString <> '') then
  begin
     Value := '0.00';
  end;

  if (cdsItensDaNota.FieldByName('ICMS40_CST').AsString <> '') then
  begin
     Value := '0.00';
  end;

  if (cdsItensDaNota.FieldByName('ICMS51_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS51_vICMS').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS51_vICMS').AsString
    else
       Value := '0.00';
  end;

  if (cdsItensDaNota.FieldByName('ICMS60_CST').AsString <> '') then
  begin
     Value := '0.00';
  end;

  if (cdsItensDaNota.FieldByName('ICMS70_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS70_vICMS').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS70_vICMS').AsString
    else
       Value := '0.00';
  end;

  if (cdsItensDaNota.FieldByName('ICMS90_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS90_vICMS').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS90_vICMS').AsString
    else
       Value := '0.00';
  end;

end;


procedure TDANFEREL.QRAliqICMSPrint(sender: TObject; var Value: String);
begin
  if (cdsItensDaNota.FieldByName('ICMS00_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS00_pICMS').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS00_pICMS').AsString
    else
       Value := '0.00';
  end;


  if (cdsItensDaNota.FieldByName('ICMS10_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS10_pICMS').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS10_pICMS').AsString
    else
       Value := '0.00';
  end;


  if (cdsItensDaNota.FieldByName('ICMS20_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS20_pICMS').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS20_pICMS').AsString
    else
       Value := '0.00';
  end;


  if (cdsItensDaNota.FieldByName('ICMS30_CST').AsString <> '') then
     Value := '0.00';

  if (cdsItensDaNota.FieldByName('ICMS40_CST').AsString <> '') then
     Value := '0.00';

  if (cdsItensDaNota.FieldByName('ICMS51_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS51_pICMS').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS51_pICMS').AsString
    else
       Value := '0.00';
  end;


  if (cdsItensDaNota.FieldByName('ICMS60_CST').AsString <> '') then
     Value := '0.00';

  if (cdsItensDaNota.FieldByName('ICMS70_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS70_pICMS').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS70_pICMS').AsString
    else
       Value := '0.00';
  end;


  if (cdsItensDaNota.FieldByName('ICMS90_CST').AsString <> '') then
  begin
    if(cdsItensDaNota.FieldByName('ICMS90_pICMS').AsString <> '') then
       Value := cdsItensDaNota.FieldByName('ICMS90_pICMS').AsString
    else
       Value := '0.00';
  end;


end;



procedure TDANFEREL.qbCalculoIssqnBeforePrint(Sender: TQRCustomBand;
  var PrintBand: Boolean);
begin
  PrintBand := (qrRelatorio.QRPrinter.PageNumber = 1);
//  if(not PrintBand)then
//    qbCalculoIssqn.Height := 0
//  else
//    qbCalculoIssqn.Height := 63;
end;

procedure TDANFEREL.cbDadosAdicionaisBeforePrint(Sender: TQRCustomBand;
  var PrintBand: Boolean);
begin
  PrintBand := (qrRelatorio.QRPrinter.PageNumber = 1);
//  if(not PrintBand)then
//    cbDadosAdicionais.Height := 0
//  else
//    cbDadosAdicionais.Height := 144;
end;

procedure TDANFEREL.qtChaveAcessoPrint(sender: TObject; var Value: String);
//var
// codigo : String;
begin
  Value := Value;
  if UpperCase(copy(Value, 1, 3)) = 'NFE' then
     value := copy(Value, 4, 47);
//Quando a chave ficar faltando os ultimos 3 digitos,
//verificar o toDp.xtr, length da infnfe_id.
//mudar de 44 para 47.
//se continuar dando problema, utilizar essa codificacao :
//  codigo := cdsNotaFiscalcUF.Text + copy(cdsNotaFiscalide_dEmi.Text,9,2);
//  codigo := codigo + copy(cdsNotaFiscalide_dEmi.Text,4,2);
//  codigo := codigo + cdsNotaFiscalemit_CNPJ.Text;
//  codigo := codigo + cdsNotaFiscalmod.Text + StringOfChar( '0', 3 - Length( Trim(cdsNotaFiscalserie.Text) ) ) + Trim(cdsNotaFiscalserie.Text);
//  codigo := codigo + StringOfChar( '0', 9 - Length( Trim(cdsNotaFiscalnNF.Text) ) ) + Trim(cdsNotaFiscalnNF.Text);
//  codigo := codigo + StringOfChar( '0', 9 - Length( Trim(cdsNotaFiscalcNF.Text) ) ) + Trim(cdsNotaFiscalcNF.Text);
//  codigo := codigo + cdsNotaFiscalcDV.Text;
//  Value := codigo;
end;

procedure TDANFEREL.qtDescProdPrint(sender: TObject; var Value: String);
begin
  Value := Value;
  Value := Value +
              Utils.Se(cdsLotesDoProduto.FieldByName('nLote').AsString <> '',
                 ' Lote: ' + cdsLotesDoProduto.FieldByName('nLote').AsString,
                 '') +
              Utils.Se(cdsLotesDoProduto.FieldByName('dVal').AsString <> '',
                 ' Venc: ' + cdsLotesDoProduto.FieldByName('dVal').AsString,
                 '');
end;

procedure TDANFEREL.qtEstProCodPrint(sender: TObject; var Value: String);
begin
  Value := cdsItensDaNota.FieldByName('cProd').AsString;
end;

procedure TDANFEREL.qbSubCabecalhoBeforePrint(Sender: TQRCustomBand;
  var PrintBand: Boolean);
begin
  PrintBand := ImprimirSubCabecalho;
end;

procedure TDANFEREL.qbSubCabecalhoAfterPrint(Sender: TQRCustomBand;
  BandPrinted: Boolean);
begin
  ImprimirSubCabecalho := true;
end;

procedure TDANFEREL.QRDBText2Print(sender: TObject; var Value: String);
begin
  Value := Value +
           ', ' + cdsNotaFiscal.FieldByName('enderDest_nro').AsString +
           '  ' + cdsNotaFiscal.fieldByName('enderDest_xCpl').AsString;
end;

function TDANFEREL.GetNFEUtils: NFEUtils;
begin
  if (not Assigned(_NFEUtils)) then
      _NFEUtils := NFEUtils.Create();
  result := _NFEUtils;
end;

procedure TDANFEREL.qtdest_CNPJPrint(sender: TObject; var Value: String);
begin
  if(Value = '  .   .   /    -  ')then
  begin
      Value :=  Copy(cdsNotaFiscaldest_CPF.Text, 1, 3) + '.' +
                Copy(cdsNotaFiscaldest_CPF.Text, 4, 3) + '.' +
                Copy(cdsNotaFiscaldest_CPF.Text, 7, 3) + '-' +
                Copy(cdsNotaFiscaldest_CPF.Text, 10, 2);
  end;

end;





end.
