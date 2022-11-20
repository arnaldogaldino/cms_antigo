unit UMain;

interface

uses
  Windows, Messages, SysUtils, Classes, Graphics, Controls, Forms, Dialogs,
  Menus, ComCtrls, ToolWin, ExtCtrls, Db, DbTables, DBITypes, ImgList,
  Buttons, StdCtrls, xmldom, XMLIntf, msxmldom, XMLDoc, ShellApi, Grids, DBGrids, Utils,
  IdBaseComponent, IdComponent, IdTCPConnection, IdTCPClient,
  IdMessageClient, IdSMTP, IdMessage, AppEvnts, IdSSLOpenSSL, IdIOHandler,
  IdIOHandlerSocket, QRPDFFilt, qrexport;


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

    msgEmail: TIdMessage;
    Button2: TButton;
    ApplicationEvents1: TApplicationEvents;
    
    smtpEnviaMailTeste: TIdSMTP;
    smtpEnviaXML: TIdSMTP;

    popmnuTrayIcon: TPopupMenu;
    Cd1: TMenuItem;
    Desabilitar1: TMenuItem;
    N1: TMenuItem;
    Encerrar1: TMenuItem;
    Envioautomticodeemail1: TMenuItem;
    sslSocket: TIdSSLIOHandlerSocket;
    procedure doPrint(path, fileName : String; nVias : integer);
    procedure FormCreate(Sender: TObject);
    procedure FormCloseQuery(Sender: TObject; var CanClose: Boolean);
    procedure FormDestroy(Sender: TObject);
    procedure btMonitorClick(Sender: TObject);
    procedure tmBuscaTimer(Sender: TObject);
    procedure Button1Click(Sender: TObject);
    procedure Button2Click(Sender: TObject);
    procedure ApplicationEvents1Exception(Sender: TObject; E: Exception);
    procedure smtpEnviaXMLWorkEnd(Sender: TObject; AWorkMode: TWorkMode);
    procedure Cd1Click(Sender: TObject);
    procedure Encerrar1Click(Sender: TObject);

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
    procedure EnviaXMLEmail(path, fileName : String; teste : Boolean);
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

//procedure TFMain.WndProc(Var Msg : TMessage);
//begin
//  case Msg.Msg of
//    WM_USER + 1:
//      case Msg.lParam of
//                  WM_RBUTTONDOWN:;
//        WM_LBUTTONDBLCLK: RestauraTrayIcon;
//      end;
//  end;
//  inherited;
//end;

procedure TFMain.WndProc(Var Msg : TMessage);
var
  p : TPoint;
begin
  case Msg.Msg of
    WM_USER + 1:
      case Msg.lParam of

        WM_LBUTTONDBLCLK: RestauraTrayIcon;

        WM_RBUTTONDOWN:
        begin
           SetForegroundWindow(Handle);
           GetCursorPos(p);
           popmnuTrayIcon.Popup(p.x, p.y);
           PostMessage(Handle, WM_NULL, 0, 0);
        end;

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
    //btMonitor.Caption := 'Desabilitar';
    Desabilitar1.Caption := 'Desabilitar';

   end
  else
  begin
    stBarra.SimpleText := 'Parado';
    //btMonitor.Caption := 'Habilitar';
    Desabilitar1.Caption := 'Habilitar';
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
  enviaEmail: Boolean;
//  pdffilter: TQRPDFDocumentFilter;
//  htmlfilter: TQRHTMLDocumentFilter;
begin
  DANFEREL := TDANFEREL.Create(Application);
  try
    DANFEREL.XTPNFE.XMLDataFile  := path + fileName;
    DANFEREL.XTPPROT.XMLDataFile  := path + fileName;

    DANFEREL.qrRelatorio.PrinterSettings.Copies := nVias;
    DANFEREL.qrRelatorio.Prepare;
    DANFEREL.TotalDePaginas := DANFEREL.qrRelatorio.QRPrinter.PageCount;

(*    pdffilter := TQRPDFDocumentFilter.Create(path + 'PDF\' + filename + '.PDF');

    try
      DANFEREL.qrRelatorio.ExportToFilter(pdffilter);
    finally
      pdffilter.Free();
    end;


    htmlfilter := TQRHTMLDocumentFilter.Create(path + 'HTML\' + filename + '.HTML');

    try
      DANFEREL.qrRelatorio.ExportToFilter(htmlfilter);
    finally
      htmlfilter.Free();
    end; *)


    DANFEREL.qrRelatorio.Print;


    // TODO: um REGEX aqui cai bem melhor do que um POS.
(*    enviaEmail := (assigned(DANFEREL)) and
                  (assigned(DANFEREL.cdsNotaFiscalobsCont_xTexto)) and
                  (Pos('@', DANFEREL.cdsNotaFiscalobsCont_xTexto.Value) > 0); *)

  enviaEmail := true;

    if enviaEmail and ConfigEnvioAutomatico then
      EnviaXMLEmail(path, fileName, false);


  finally
    DANFEREL.Free;
    if not (enviaEmail and ConfigEnvioAutomatico) then
    begin
      DeleteFile(path+fileName);

//    Delete(newFileName,1,5);//Apaga o print da string que contem o nome do arquivo origem
//    if(FileExists(path+'printed'+newFileName)) then //Se o arquivo ja existir,
//       DeleteFile(path+'printed'+newFileName);  // apague.
//    RenameFile(path+fileName, path+'printed'+newFileName); //Sempre renomeie de print para printed

      Printing := false;
    end;
  end;
end;

procedure TFMain.EnviaXMLEmail(path, fileName : String; teste : Boolean);
var
  a, posicaoSeparador, posicaoArroba: integer;
  enderecoCopias, email: string;
  smtp: TIdSMTP;

begin


  if teste then
    smtp := smtpEnviaMailTeste
  else
    smtp := smtpEnviaXML;



  smtp.Username := ConfigUsuario;
  smtp.Host := ConfigHost;
  smtp.Password := ConfigSenha;
//  smtp.Port := StrToInt(ConfigPort);

  if(ConfigSSL) then
  begin
    smtp.IOHandler := sslSocket;
    smtp.AuthenticationType := atLogin;
  end;


  try

    if not smtp.Connected then
    smtp.Connect();

    if smtp.AuthSchemesSupported.IndexOf('LOGIN')>-1 then
    begin
      smtp.AuthenticationType := atLogin;
    end;


    smtp.Authenticate;

    if (not teste) and (assigned(DANFEREL)) and (DANFEREL.GetFieldValue(DANFEREL.cdsNotaFiscal, 'obsCont_xTexto') <> '') then
      posicaoArroba := Pos('@', DANFEREL.GetFieldValue(DANFEREL.cdsNotaFiscal, 'obsCont_xTexto'))
    else
      posicaoArroba := 0;

    if (not teste) then
    begin
//      msgEmail.Recipients.EMailAddresses := DANFEREL.cdsNotaFiscalobsCont_xTexto.Value;
//      msgEmail.CCList.EMailAddresses := ConfigCopiaPara;
     msgEmail.Recipients.EMailAddresses := ConfigCopiaPara;
    end
    else
    begin
     msgEmail.Recipients.EMailAddresses := ConfigCopiaPara;
    end;

    msgEmail.From.Text := ConfigTextoFrom;
    msgEmail.From.Address := ConfigFrom;
    if teste then
      msgEmail.Subject := 'Teste de envio de e-mail do Open NFe'
    else
      msgEmail.Subject := 'Envio autom�tico de XML do Open NFe';

    msgEmail.Body.Clear;

    if teste then
      msgEmail.Body.Add('Envio de e-mail de teste do Open NFe. Favor n�o responder.')
    else
      msgEmail.Body.Add('Envio autom�tico de XML do Open NFe. Favor n�o responder este e-mail.');

    msgEmail.MessageParts.Clear;

    if Trim(filename) <> '' then
    begin
      TIdAttachment.Create(msgEmail.MessageParts , Tfilename(path + filename));
//      TIdAttachment.Create(msgEmail.MessageParts , Tfilename(path + 'PDF\' + filename + '.PDF'));
//      TIdAttachment.Create(msgEmail.MessageParts , Tfilename(path + 'HTML\' + filename + '.HTML'));
    end;

//    if teste or (posicaoArroba > 0) then

    begin
      smtp.Send(msgEmail);
    end;

  finally
    if smtp.Connected then
      smtp.Disconnect;
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

procedure TFMain.ApplicationEvents1Exception(Sender: TObject;
  E: Exception);
var
    NomeDoLog: string;
    Arquivo: TextFile;
  begin
    NomeDoLog := ChangeFileExt(Application.Exename, '.erro.log');
    AssignFile(Arquivo, NomeDoLog);

    if FileExists(NomeDoLog) then
      Append(arquivo) { se existir, apenas adiciona linhas }
    else
      ReWrite(arquivo); { cria um novo se n�o existir }

    try
      WriteLn(arquivo, DateTimeToStr(Now) + ': ' + E.Message);
      WriteLn(arquivo,'----------------------------------------------------------------------');
//      Application.ShowException(E);
    finally
      CloseFile(arquivo);

      if Printing then
      begin

        if lvArquivos.Count > 0 then
          DeleteFile(ExtractFilePath(Application.ExeName)+'PrintBox\'+ lvArquivos.Items[0]);

        Printing := false;

      end;

    end;

end;

procedure TFMain.smtpEnviaXMLWorkEnd(Sender: TObject;
  AWorkMode: TWorkMode);
begin
  DeleteFile(ExtractFilePath(Application.ExeName)+'PrintBox\'+ lvArquivos.Items[0]);
  Printing := false;
end;

procedure TFMain.Cd1Click(Sender: TObject);
begin
  TConfig.ShowModal;
end;

procedure TFMain.Encerrar1Click(Sender: TObject);
begin
ClosedByButton := true;
  Close;
end;

end.
