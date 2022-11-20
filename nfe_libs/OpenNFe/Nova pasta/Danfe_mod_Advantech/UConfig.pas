unit UConfig;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls, INIFiles;

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
    procedure btnSalvarClick(Sender: TObject);
    procedure FormCreate(Sender: TObject);
  private
    { Private declarations }
  public
    procedure GravarConfig(NumCopias, Usuario, Host, Senha, TextoFrom, From: String);
    class procedure LerConfig();
  end;

var
  TConfig: TTConfig;
  ConfigNumCopias: Integer;
  ConfigUsuario, ConfigHost, ConfigSenha, ConfigTextoFrom, ConfigFrom: String;

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
    ConfigSenha := ArqIni.ReadString('Email', 'Senha', ConfigSenha);
    ConfigTextoFrom := ArqIni.ReadString('Email', 'TextoFrom', ConfigTextoFrom);
    ConfigFrom := ArqIni.ReadString('Email', 'From', ConfigFrom);
  Finally
    ArqIni.Free;
  end;
end;

procedure TTConfig.GravarConfig(NumCopias, Usuario, Host, Senha, TextoFrom, From: String);
  var ArqIni : TIniFile;
begin
  ArqIni := TIniFile.Create('./danfe.ini');
  Try
    ArqIni.WriteString('Email', 'NumCopias', NumCopias);
    ArqIni.WriteString('Email', 'Usuario', Usuario);
    ArqIni.WriteString('Email', 'Host', Host);
    ArqIni.WriteString('Email', 'Senha', Senha);
    ArqIni.WriteString('Email', 'TextoFrom', TextoFrom);
    ArqIni.WriteString('Email', 'From', From);

    ConfigNumCopias := StrToInt(NumCopias);
    ConfigUsuario := Usuario;
    ConfigHost := Host;
    ConfigSenha := Senha;
    ConfigTextoFrom := TextoFrom;
    ConfigFrom := From;
  Finally
    ArqIni.Free;
  end;
end;

procedure TTConfig.btnSalvarClick(Sender: TObject);
begin
  TConfig.GravarConfig(cbVias.Text, edtSmtpUsuario.Text, edtSmtpHost.Text, edtSmtpSenha.Text, edtRemetenteNome.Text, edtRemetenteEmail.Text);
  Self.Close();
end;

procedure TTConfig.FormCreate(Sender: TObject);
begin
  LerConfig();
  cbVias.ItemIndex := ConfigNumCopias - 1;
  edtSmtpUsuario.Text := ConfigUsuario;
  edtSmtpSenha.Text := ConfigSenha;
  edtSmtpHost.Text := ConfigHost;
  edtRemetenteNome.Text := ConfigTextoFrom;
  edtRemetenteEmail.Text := ConfigFrom;
end;

end.
