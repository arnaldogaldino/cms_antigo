program DANFE;

uses
  Forms,
  UMain in 'UMain.pas' {FMain},
  utils in 'utils.pas',
  relatorioDANFE in 'relatorioDANFE.pas' {DANFEREL},
  Xmlxform in 'Xmlxform.pas',
  UConfig in 'UConfig.pas' {TConfig};

{$R *.res}

begin
  Application.Initialize;
  Application.Title := 'Servidor de impressão NFeAdmin - DANFe';
  Application.CreateForm(TFMain, FMain);
  Application.CreateForm(TTConfig, TConfig);
  Application.Run;
end.
