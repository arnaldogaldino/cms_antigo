unit UConfig;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, INIFiles, UMain;

type
  TTConfig = class(TForm)
    GroupBox2: TGroupBox;
    Label2: TLabel;
    Label3: TLabel;
    Label4: TLabel;
    GroupBox3: TGroupBox;
    Label5: TLabel;
    Label6: TLabel;
    edtSmtpUsuario: TEdit;
    edtSmtpSenha: TEdit;
    edtSmtpHost: TEdit;
    edtRemetenteNome: TEdit;
    edtRemetenteEmail: TEdit;
    btnSalvar: TButton;
    GroupBox1: TGroupBox;
    Label1: TLabel;
    cbVias: TComboBox;
    Label7: TLabel;
    edtCopiaPara: TEdit;
    btnTestarEmail: TButton;
    Label8: TLabel;
    Button1: TButton;
    edtConfSenha: TEdit;
    GroupBox4: TGroupBox;
    chkEnvioEmail: TCheckBox;
    Label9: TLabel;
    edtSmtpPort: TEdit;
    chkSSL: TCheckBox;
    procedure btnSalvarClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
    procedure btnTestarEmailClick(Sender: TObject);
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    procedure GravarConfig(NumCopias, Usuario, Host, Port, Senha, TextoFrom, From, CopiaPara: String; EnvioAutomatico, SSL: Boolean);
    class procedure LerConfig();
  end;

var
  TConfig: TTConfig;
  ConfigNumCopias: Integer;
  ConfigUsuario, ConfigHost, ConfigPort, ConfigSenha, ConfigTextoFrom, ConfigFrom, ConfigCopiaPara: String;
  ConfigEnvioAutomatico, ConfigSSL: Boolean;

implementation

{$R *.dfm}

class procedure TTConfig.LerConfig();
  var ArqIni : TIniFile;
begin
  ArqIni := TIniFile.Create('./danfe.ini');
  Try
    Try
      ConfigNumCopias := StrToInt(ArqIni.ReadString('Email', 'NumCopias', ConfigUsuario));
    Except
      ConfigNumCopias := 1;
    end;

    ConfigUsuario := ArqIni.ReadString('Email', 'Usuario', ConfigUsuario);
    ConfigHost := ArqIni.ReadString('Email', 'Host', ConfigHost);
    ConfigPort := ArqIni.ReadString('Email', 'Port', ConfigPort);
    ConfigSenha := ArqIni.ReadString('Email', 'Senha', ConfigSenha);
    ConfigTextoFrom := ArqIni.ReadString('Email', 'TextoFrom', ConfigTextoFrom);
    ConfigFrom := ArqIni.ReadString('Email', 'From', ConfigFrom);
    ConfigCopiaPara := ArqIni.ReadString('Email', 'CopiaPara', ConfigCopiaPara);
    ConfigEnvioAutomatico := ArqIni.ReadBool('Email', 'Automatico', ConfigEnvioAutomatico);
    ConfigSSL := ArqIni.ReadBool('Email', 'SSL', ConfigSSL);

  Finally
    ArqIni.Free;
  end;
end;

procedure TTConfig.GravarConfig(NumCopias, Usuario, Host, Port, Senha, TextoFrom, From, CopiaPara: String; EnvioAutomatico, SSL: Boolean);
  var ArqIni : TIniFile;
begin
  ArqIni := TIniFile.Create('./danfe.ini');
  Try
    ArqIni.WriteString('Email', 'NumCopias', NumCopias);
    ArqIni.WriteString('Email', 'Usuario', Usuario);
    ArqIni.WriteString('Email', 'Host', Host);
        ArqIni.WriteString('Email', 'Port', Port);
    ArqIni.WriteString('Email', 'Senha', Senha);
    ArqIni.WriteString('Email', 'TextoFrom', TextoFrom);
    ArqIni.WriteString('Email', 'From', From);
    ArqIni.WriteString('Email', 'CopiaPara', CopiaPara);
    ArqIni.WriteBool('Email', 'Automatico', EnvioAutomatico);
    ArqIni.WriteBool('Email', 'SSL', SSL);

    ConfigNumCopias := StrToInt(NumCopias);
    ConfigUsuario := Usuario;
    ConfigHost := Host;
    ConfigSenha := Senha;
    ConfigTextoFrom := TextoFrom;
    ConfigFrom := From;
    ConfigCopiaPara := CopiaPara;
    ConfigEnvioAutomatico := EnvioAutomatico;
    ConfigSSL := chkSSL.Checked;
  Finally
    ArqIni.Free;
  end;
end;

procedure TTConfig.btnSalvarClick(Sender: TObject);
begin
if(edtSmtpSenha.Text <> edtConfSenha.Text) then
begin
  ShowMessage('Senha não confere.');
end
else
begin
  TConfig.GravarConfig(cbVias.Text, edtSmtpUsuario.Text, edtSmtpHost.Text, edtSmtpPort.Text, edtSmtpSenha.Text, edtRemetenteNome.Text, edtRemetenteEmail.Text, edtCopiaPara.Text, chkEnvioEmail.Checked, chkSSL.Checked);
  Self.Close();
  end;
end;

procedure TTConfig.FormCreate(Sender: TObject);
begin
  LerConfig();
  cbVias.ItemIndex := ConfigNumCopias - 1;
  edtSmtpUsuario.Text := ConfigUsuario;
  edtSmtpSenha.Text := ConfigSenha;
  edtConfSenha.Text := ConfigSenha;
  edtSmtpHost.Text := ConfigHost;
  edtRemetenteNome.Text := ConfigTextoFrom;
  edtRemetenteEmail.Text := ConfigFrom;
  edtCopiaPara.Text := ConfigCopiaPara;
  edtSmtpPort.Text := ConfigPort;
  chkEnvioEmail.Checked := ConfigEnvioAutomatico;
  chkSSL.Checked := ConfigSSL;
end;

procedure TTConfig.btnTestarEmailClick(Sender: TObject);
var
  TempConfigNumCopias: Integer;
  TempConfigUsuario, TempConfigHost, TempConfigPort, TempConfigSenha, TempConfigTextoFrom, TempConfigFrom, TempConfigCopiaPara: String;
  TempSSL : Boolean;
begin
  TempConfigNumCopias := ConfigNumCopias;
  TempConfigUsuario := ConfigUsuario;
  TempConfigSenha := ConfigSenha;
  TempConfigHost := ConfigHost;
  TempConfigPort := ConfigPort;
  TempConfigTextoFrom := ConfigTextoFrom;
  TempConfigFrom := ConfigFrom;
  TempConfigCopiaPara := ConfigCopiaPara;
  TempSSL := ConfigSSL;

  ConfigNumCopias := cbVias.ItemIndex + 1;
  ConfigUsuario := edtSmtpUsuario.Text;
  ConfigSenha := edtSmtpSenha.Text;
  ConfigHost := edtSmtpHost.Text;
  ConfigPort := edtSmtpPort.Text;
  ConfigTextoFrom := edtRemetenteNome.Text;
  ConfigFrom := edtRemetenteEmail.Text;
  ConfigCopiaPara := edtCopiaPara.Text;
  ConfigSSL := chkSSL.Checked;

  try
    FMain.EnviaXMLEmail('', '', true);
    MessageDlg('Envio de e-mail realizado para ' + ConfigCopiaPara + '.', mtInformation, mbOKCancel, 0);
  except
    on e: Exception do
      ShowMessage('Erro ao testar o enviode e-mail.'#13 + e.Message);
  end;

  ConfigNumCopias := TempConfigNumCopias;
  ConfigUsuario := TempConfigUsuario;
  ConfigSenha := TempConfigSenha;
  ConfigHost := TempConfigHost;
  ConfigPort := TempConfigPort;
  ConfigTextoFrom := TempConfigTextoFrom;
  ConfigFrom := TempConfigFrom;
  ConfigCopiaPara := TempConfigCopiaPara;
  ConfigSSL := TempSSL;
end;

procedure TTConfig.Button1Click(Sender: TObject);
begin
    Self.Close();
end;

end.
