program DANFE;

uses
  Forms,
  UMain in 'UMain.pas' {FMain},
  utils in 'utils.pas',
  relatorioDANFE in 'relatorioDANFE.pas' {DANFEREL},
  Xmlxform in 'Xmlxform.pas',
  UConfig in 'UConfig.pas' {TConfig},
  Barcode in 'Barcode.pas',
  Barcode2 in 'Barcode2.pas',
  bcchksum in 'bcchksum.pas';

{$R *.res}

begin
  Application.Initialize;
  Application.Title := 'Servidor de impressão NFeAdmin - DANFe';
  Application.CreateForm(TFMain, FMain);
  Application.CreateForm(TTConfig, TConfig);
  Application.Run;
end.
