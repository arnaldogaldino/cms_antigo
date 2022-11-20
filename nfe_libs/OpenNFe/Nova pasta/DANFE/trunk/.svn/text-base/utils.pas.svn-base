unit utils;

interface

uses Classes, StdCtrls;

type
  NFeUtils = class
  public
    procedure AtualizaFilaImpressao(list : TListBox; folder, tag : String);
    function Se(test: boolean; returnIfTrue, returnIfFalse: variant): variant;
    function ValorPorExtenso(Valor: integer): string;
    function ValorExtensoDuasDecimais(rValor: real; UnMonet: array of string): string;
    function ReplaceChar(expression, oldChar:String; newChar :Char): String;
    function GetFileSize(const FileName: string): integer;
  end;


implementation


uses NB30, sysutils, Controls;



procedure NFeUtils.AtualizaFilaImpressao(list : TListBox; folder, tag : String);
var
  SR: TSearchRec;
  selected, isFound : integer;
begin
  selected := list.ItemIndex;
  list.Items.Clear;
  isFound := FindFirst(folder + tag, faAnyFile, SR);
  while IsFound = 0 do
  begin
    list.Items.Add(sr.Name);
    IsFound := FindNext(SR);
  end;
  FindClose(SR);
  list.ItemIndex := selected;
end;

function NFeUtils.Se(test: boolean; returnIfTrue, returnIfFalse: variant): variant;
begin
  if test then
     result := returnIfTrue
  else
     result := returnIfFalse;
end;


function NFeUtils.ValorPorExtenso(Valor: integer): string;
const
  Unidade : array[1..9] of String = ('um', 'dois', 'três', 'quatro', 'cinco', 'seis',
            'sete', 'oito', 'nove');
  DezenaA : array[1..9] of String = ('dez', 'vinte', 'trinta', 'quarenta', 'cinqüênta', 'sessenta',
            'setenta', 'oitenta', 'noventa');
  DezenaB : array[1..9] of String = ('onze', 'doze', 'treze', 'quatorze', 'quinze', 'dezesseis',
            'dezessete', 'dezoito', 'dezenove');
  Centena : array[0..9] of String = ('cem','cento','duzentos', 'trezentos', 'quatrocentos', 'quinhentos', 'seiscentos',
            'setecentos', 'oitocentos', 'novecentos');
var
  nValor,ExtInt : String;
begin
  nValor := IntToStr(Valor);
  while Length(nValor) < 3 do
    nValor := '0' + nValor;
  if (StrToInt(Copy(nValor,2,2)) <= 10) or (StrToInt(Copy(nValor,2,2)) >= 20) then
  begin
    if Copy(nValor, Length(nValor), Length(nValor)-1) <> '0' then
       ExtInt := ExtInt + Unidade[StrToInt(Copy(nValor,3,1))];
    if Copy(nValor,2,1) <> '0' then
    begin
      if Length(Trim(ExtInt)) > 0 then
         ExtInt := ' e ' + ExtInt;
      ExtInt := DezenaA[StrToInt(Copy(nValor,2,1))] + ExtInt;
    end;
  end
  else
    ExtInt := DezenaB[StrToInt(Copy(nValor,3,1))];
  if (Copy(nValor,1,1) <> ' ') and (Copy(nValor,1,1) <> '0') then
  begin
    if Length(Trim(ExtInt)) > 0 then
       ExtInt := ' e ' + ExtInt;
    if (Copy(nValor,1,1) = '1') and (Length(Trim(ExtInt))=0) then
       ExtInt := Centena[0]
    else
       ExtInt := Centena[StrToInt(Copy(nValor,1,1))] +  ExtInt;
  end;
  ValorPorExtenso := ExtInt;
end;


function NFeUtils.ValorExtensoDuasDecimais(rValor: real; UnMonet: array of string): string;
Const
  Milhares : array[1..4] of String = ('','mil','milhão','milhões');
var
  I: Integer;
  ExtensoFra,ExtensoInt,ExtensoAux,ValorAux,Milhar : String;
begin
  if (Length(UnMonet[0]) = 0) and (Length(UnMonet[1]) = 0) then
     raise exception.create('Parâmetros Incorretos.');
  if rValor >= 1000000000000 then
     raise exception.create('Valor muito extenso. Contate o responsável pelo sistema.');
  if rValor <= 0 then
     raise exception.create('Valor nulo ou negativo não pode ser convertido para extenso.');
  ValorAux := format('%*.*f',[9,2,rValor]);
  ValorAux := Copy(ValorAux,Pos(',',ValorAux)+1,Length(ValorAux));
  ExtensoFra := ValorPorExtenso(StrToInt(ValorAux));
  if StrToInt(ValorAux) > 1 then
     ExtensoFra := ExtensoFra + ' ' + UnMonet[3]
  else if StrToInt(ValorAux) > 0 then
          ExtensoFra := ExtensoFra + ' ' + UnMonet[1];
  ValorAux := format('%*.*f',[9,2,rValor]);
  ValorAux := Copy(ValorAux,1,Pos(',',ValorAux)-1);
  for I := 1 to 3 do
  begin
    Milhar := Copy(ValorAux, Length(ValorAux)-2, Length(ValorAux));
    ValorAux := Copy(ValorAux, 1, Length(ValorAux)-3);
    if (Trim(Milhar) <> '') and (StrToInt(Milhar) <> 0) then
    begin
      if (I > 1) and (Trim(ExtensoInt) <> '') then
         ExtensoInt := ', ' + ExtensoInt;
      ExtensoAux := ValorPorExtenso(StrToInt(Milhar));
      if (I=3) and (StrToInt(Milhar) > 1) then
         ExtensoAux := ExtensoAux + ' ' + Milhares[I+1]
      else
         ExtensoAux := ExtensoAux + ' ' + Milhares[I];
      ExtensoInt :=  Trim(ExtensoAux) + ExtensoInt;
    end;
  end;
  ValorAux := format('%*.*f',[9,2,rValor]);
  ValorAux := Copy(ValorAux, 1, Pos(',',ValorAux)-1);
  if ((StrToInt(ValorAux) mod 1000000) = 0) and (StrToInt(ValorAux)>0) then
     ExtensoInt := ExtensoInt + ' de';
  if StrToInt(ValorAux) > 1 then
     ExtensoInt := ExtensoInt + ' ' + UnMonet[2]
  else if StrToInt(ValorAux) > 0 then
          ExtensoInt := ExtensoInt + ' ' + UnMonet[0];
  if (Trim(ExtensoFra) = '') then
     result := Trim(ExtensoInt)
  else if (trim(ExtensoInt) = '') then
          result := Trim(ExtensoFra)
       else
          result := Trim(ExtensoInt) + ' e ' + Trim(ExtensoFra);
  result := UpperCase(copy(result,1,1)) + copy(result,2,length(result)) + '.';
end;


function NFeUtils.ReplaceChar(expression, oldChar:String; newChar :Char): String;
var
  S: String;
begin
  S := expression;
  while Pos(oldChar, S) > 0 do
    S[Pos(oldChar, S)] := newChar;
  result := S;
end;


function NFeUtils.GetFileSize(const FileName: string): integer;
var
  SR: TSearchRec;
  I: integer;
begin
  I := FindFirst(FileName, faArchive, SR);
  try
    if I = 0 then
      Result := SR.Size
    else
      Result := -1;
  finally
    FindClose(SR);
  end;
end;


end.
