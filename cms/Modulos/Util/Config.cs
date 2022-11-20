using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Security.Cryptography;
using System.Configuration;

namespace cms.Modulos.Util
{
    public class Config
    {
        static string nome_arquivo_xml = "config.xml";
        static string diretorio_xml = Directory.GetCurrentDirectory();
        static DataTable dtConfig = new DataTable();

        public Config()
        {
            VerificaArquivo();
        }

        public static string GetValue(string key)
        {
            string result = string.Empty;
            bool key_exist = false;

            VerificaArquivo();

            foreach (DataRow dr in dtConfig.Rows)
            {
                if (dr["key"].ToString().Equals(key, StringComparison.CurrentCultureIgnoreCase))
                {
                    result = dr["value"].ToString();
                    key_exist = true;
                }
            }

            if (!key_exist)
            {
                throw new Exception("Key não existe!");
            }

            return result;
        }

        public static void SetValue(string key, string value)
        {
            bool key_exist = false;

            VerificaArquivo();

            foreach (DataRow dr in dtConfig.Rows)
            {
                if (dr["key"].ToString().Equals(key, StringComparison.CurrentCultureIgnoreCase))
                {
                    dr["value"] = Encrypt(value,true);
                    key_exist = true;
                }
            }

            if (!key_exist)
            {
                throw new Exception("Key não existe!");
            }

            GravaArquivo();
        }

        public static void NewKey(string key, string value)
        {
            VerificaArquivo();
            
            if (!ExitsKey(key))
                dtConfig.Rows.Add(key, value);
            else
                throw new Exception("Esse key já existe!");

            GravaArquivo();
        }

        public static bool ExitsKey(string key)
        {
            bool result = false;
            
            VerificaArquivo();

            foreach (DataRow dr in dtConfig.Rows)
            {
                if (dr["key"].ToString().Equals(key, StringComparison.CurrentCultureIgnoreCase))
                {
                    result = true;
                }
            }

            return result;
        }

        private static void VerificaArquivo()
        {
            if (!File.Exists(diretorio_xml + "\\" + nome_arquivo_xml))
                CriaArquivo();
            else
                LerArquivo();
        }

        private static void LerArquivo()
        {
            dtConfig.ReadXml(diretorio_xml + "\\" + nome_arquivo_xml);
        }

        private static void CriaArquivo()
        {
            dtConfig.TableName = "configuracao";
            dtConfig.Columns.Add("key", Type.GetType("System.String"));
            dtConfig.Columns.Add("value", Type.GetType("System.String"));
            dtConfig.WriteXml(diretorio_xml + "\\" + nome_arquivo_xml);
        }

        private static void GravaArquivo()
        {
            dtConfig.WriteXml(diretorio_xml + "\\" + nome_arquivo_xml);
        }

        public static string Encrypt(string toEncrypt, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            // Get the key from config file

            string key = (string)settingsReader.GetValue("SecurityKey",
                                                             typeof(String));
            //System.Windows.Forms.MessageBox.Show(key);
            //If hashing use get hashcode regards to your key
            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //Always release the resources and flush data
                // of the Cryptographic service provide. Best Practice

                hashmd5.Clear();
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string cipherString, bool useHashing)
        {
            byte[] keyArray;
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
            //Get your key from config file to open the lock!
            string key = (string)settingsReader.GetValue("SecurityKey",
                                                         typeof(String));

            if (useHashing)
            {
                //if hashing was used get the hash code with regards to your key
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                //release any resource held by the MD5CryptoServiceProvider

                hashmd5.Clear();
            }
            else
            {
                //if hashing was not implemented get the byte code of the key
                keyArray = UTF8Encoding.UTF8.GetBytes(key);
            }

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            //set the secret key for the tripleDES algorithm
            tdes.Key = keyArray;
            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static void UnitTeste()
        {
            File.Delete(diretorio_xml + "\\" + nome_arquivo_xml);
            
            #region # Testa se o key existe #
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Testa se o key existe!");
            try
            {
                Console.WriteLine(@"Config.ExitsKey(""porta_impressora"")");
                if (!Config.ExitsKey("porta_impressora"))
                {
                    Console.WriteLine("Teste Ok: " + Config.ExitsKey("porta_impressora").ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no teste: " + ex.Message);
            }
            #endregion

            #region # Testa se o GetKey da erro #
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Testa se o GetKey da erro!");
            try
            {
                Console.WriteLine(@"string value = Config.GetValue(""porta_impressora"")");
                string value = Config.GetValue("porta_impressora");
                Console.WriteLine("Erro no teste: o key porta_impressora não existe!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Teste Ok: " + ex.Message);
            }
            #endregion

            #region # Testa se o SetValue da erro #
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Testa se o SetValue da erro!");
            try
            {
                Console.WriteLine(@"Config.SetValue(""porta_impressora"", ""USB001"")");
                Config.SetValue("porta_impressora", "USB001");
                Console.WriteLine("Erro no teste: o key porta_impressora não existe!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Teste Ok: " + ex.Message);
            }
            #endregion

            #region # Testa se o NewKey Grava #
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Testa se o NewKey Grava!");
            try
            {
                Console.WriteLine(@"Config.NewKey(""impressora_tamanho_folha"", ""A4"");");
                Config.NewKey("impressora_tamanho_folha", "A4");
                Config.NewKey("max_usuarios", "10");
                Console.WriteLine("Teste Ok: " + Config.ExitsKey("impressora_tamanho_folha").ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no teste: " + ex.Message);
            }
            #endregion

            #region # Testa se o NewKey da erro Key Exist #
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Testa se o NewKey da erro Key Exist!");
            try
            {
                Console.WriteLine(@"Config.NewKey(""impressora_tamanho_folha"", ""A4"");");
                Config.NewKey("impressora_tamanho_folha", "A4");
                Console.WriteLine("Erro no teste: era pra dar erro por que o key já existe!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Teste Ok: " + ex.Message);
            }
            #endregion

            #region # Testa se o GetValue funciona #
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Testa se o GetValue funciona!");
            try
            {
                Console.WriteLine(@"Config.GetValue(""max_usuarios"");");
                string result = Config.GetValue("max_usuarios");
                Console.WriteLine("Teste Ok: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no Teste: esse key existe! " + ex.Message);
            }
            #endregion

            #region # Testa se o SetValue funciona #
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Testa se o SetValue funciona!");
            try
            {
                Console.WriteLine(@"Config.SetValue(""max_usuarios"", ""25"")");
                Config.SetValue("max_usuarios", "25");
                string result = Config.GetValue("max_usuarios");
                Console.WriteLine("Teste Ok: " + result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro no Teste: esse key existe! " + ex.Message);
            }
            #endregion

        }

    }
}
