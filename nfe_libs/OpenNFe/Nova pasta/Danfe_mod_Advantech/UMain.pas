unit UMain;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  Menus, ComCtrls, ToolWin, ExtCtrls, Db, DbTables, DBITypes, ImgList,
  Buttons, StdCtrls, xmldom, XMLIntf, msxmldom, XMLDoc, ShellApi, Grids, DBGrids, Utils,
  IdBaseComponent, IdComponent, IdTCPConnection, IdTCPClient,
  IdMessageClient, IdSMTP, IdMessage;

const
 wm_IconMessage = wm_User;

type
  TFMain = class(TForm)
    tmBusca: TTimer;
    btMonitor: TButton;
    stBarra: TStatusBar;
    lvArquivos: TListBox;
    cbVias: TComboBox;
    Label1: TLabel;
    Label2: TLabel;
    Button1: TButton;
    smtpEnviaXML: TIdSMTP;
    msgEmail: TIdMessage;
    Button2: TButton;
    procedure doPrint(path, fileName : String; nVias : integer);
    procedure EnviaXMLEmail(path, fileName : String);
    procedure FormCreate(Sender: TObject);
    procedure FormCloseQuery(Sender: TObject; var CanClose: Boolean);
    procedure FormDestroy(Sender: TObject);
    procedure btMonitorClick(Sender: TObject);
    procedure tmBuscaTimer(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);

  private
    { Private declarations }
    _Utils: NFEUtils;
    Printing : Boolean;
    ClosedByButton : Boolean;
    IconData: TNotifyIconData;
    procedure CriaTrayIcon;
    procedure IncluiTrayIcon(Sender: TObject);
    procedure RestauraTrayIcon;
  public
    { Public declarations }
    procedure WndProc(var Msg : TMessage); override;
    function GetUtils: NFEUtils;
    property Utils: NFEUtils read GetUtils;
  end;

var
  FMain: TFMain;

implementation

{$R *.DFM}

uses
 DateUtils, Variants, relatorioDANFE, Math, UConfig;

procedure TFMain.FormCreate(Sender: TObject);
begin
  {Barra de tarefas.}
  CriaTrayIcon;
  IncluiTrayIcon(nil);
  Printing := false;
  ClosedByButton := false;
  TTConfig.LerConfig();
  cbVias.ItemIndex := UConfig.ConfigNumCopias - 1;
end;

procedure TFMain.WndProc(Var Msg : TMessage);
begin
  case Msg.Msg of
    WM_USER + 1:
      case Msg.lParam of
//                  WM_RBUTTONDOWN:;
        WM_LBUTTONDBLCLK: RestauraTrayIcon;
      end;
  end;
  inherited;
end;

procedure TFMain.CriaTrayIcon;
begin
  IconData.cbSize := sizeof(IconData);
  IconData.Wnd := Handle;
  IconData.uID := 100;
  IconData.uFlags := NIF_MESSAGE + NIF_ICON + NIF_TIP;
  IconData.uCallbackMessage := WM_USER + 1;
  IconData.hIcon := Application.Icon.Handle;
  StrPCopy(IconData.szTip, Application.Title);
end;

procedure TFMain.IncluiTrayIcon(Sender: TObject);
begin
  Shell_NotifyIcon(NIM_ADD, @IconData);
  Self.Hide;
  ShowWindow(Application.Handle, SW_HIDE);
  Application.ShowMainForm := false;
end;

procedure TFMain.RestauraTrayIcon;
begin
  ShowWindow(Application.Handle, SW_SHOW);
  Self.Show;
  Application.BringToFront;
end;

procedure TFMain.FormCloseQuery(Sender: TObject; var CanClose: Boolean);
begin
  CanClose := ClosedByButton;
  if(CanClose)then
    Shell_NotifyIcon(NIM_DELETE, @IconData)
  else
    IncluiTrayIcon(nil);
end;

procedure TFMain.FormDestroy(Sender: TObject);
begin
//  Shell_NotifyIcon(NIM_DELETE, @IconData);//Retira icon da tray
end;

procedure TFMain.btMonitorClick(Sender: TObject);
begin
  tmBusca.Enabled := not tmBusca.Enabled;
  if(tmBusca.Enabled) then
  begin
    stBarra.SimpleText := 'Monitorando';
    btMonitor.Caption := 'Desabilitar';
   end
  else
  begin
    stBarra.SimpleText := 'Parado';
    btMonitor.Caption := 'Habilitar';
  end;
end;

procedure TFMain.tmBuscaTimer(Sender: TObject);
begin
  Utils.AtualizaFilaImpressao(lvArquivos, ExtractFilePath(Application.ExeName)+'PrintBox\', '*.xml');
  if((not Printing) and (lvArquivos.Count > 0))then
  begin
    Printing := true;
    doPrint(ExtractFilePath(Application.ExeName)+'PrintBox\', lvArquivos.Items[0] ,cbVias.ItemIndex + 1);
  end;
end;

procedure TFMain.doPrint(path, fileName : String; nVias : integer);
var
  i : Integer;
//  newFileName : String;
begin
  DANFEREL := TDANFEREL.Create(Application);
  try
    DANFEREL.XTPNFE.XMLDataFile  := path + fileName;
    DANFEREL.XTPPROT.XMLDataFile  := path + fileName;

    DANFEREL.qrRelatorio.PrinterSettings.Copies := nVias;
    DANFEREL.qrRelatorio.Prepare;
    DANFEREL.TotalDePaginas := DANFEREL.qrRelatorio.QRPrinter.PageCount;

    DANFEREL.qrRelatorio.Print;

    EnviaXMLEmail(path, fileName);
  finally
    DANFEREL.Free;
    DeleteFile(path+fileName);
//    Delete(newFileName,1,5);//Apaga o print da string que contem o nome do arquivo origem
//    if(FileExists(path+'printed'+newFileName)) then //Se o arquivo ja existir,
//       DeleteFile(path+'printed'+newFileName);  // apague.
//    RenameFile(path+fileName, path+'printed'+newFileName); //Sempre renomeie de print para printed
    Printing := false;
  end;
end;

procedure TFMain.EnviaXMLEmail(path, fileName : String);
var
a: integer;
begin
  smtpEnviaXML.AuthenticationType := atLogin;
  smtpEnviaXML.Username := ConfigUsuario;
  smtpEnviaXML.Host := ConfigHost;
  smtpEnviaXML.Password := ConfigSenha;
  smtpEnviaXML.AuthenticationType := atNone;
  if not smtpEnviaXML.Connected then
    smtpEnviaXML.Connect;

  try
    if smtpEnviaXML.AuthSchemesSupported.IndexOf('LOGIN')>-1 then
    begin
      smtpEnviaXML.AuthenticationType := atLogin;
      smtpEnviaXML.Authenticate;
    end;

    smtpEnviaXML.Port := 25;

    msgEmail.Recipients.EMailAddresses := DANFEREL.cdsNotaFiscalobsCont_xTexto.Value;
    msgEmail.From.Text := ConfigTextoFrom;
    msgEmail.From.Address := ConfigFrom;
    msgEmail.Subject := 'Envio automático de XML do OpenNFe';
    msgEmail.Body.Add('Envio automático de XML do OpenNFe. Favor não responder este e-mail.');
    TIdAttachment.Create(msgEmail.MessageParts , Tfilename(path + filename));
    smtpEnviaXML.Send(msgEmail);
  finally
    smtpEnviaXML.Disconnect;
  end;

end;

procedure TFMain.Button1Click(Sender: TObject);
begin
  ClosedByButton := true;
  Close;
end;

function TFMain.GetUtils: NFEUtils;
begin
  if (not assigned(_Utils)) then
    _Utils := NFEUtils.Create();
  result := _Utils;
end;

procedure TFMain.Button2Click(Sender: TObject);
begin
   TConfig.ShowModal;
end;

end.
