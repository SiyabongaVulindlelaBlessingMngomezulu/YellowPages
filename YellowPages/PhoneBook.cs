using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace YellowPages
{
    public class PhoneBook : Archive
    {
        public PhoneBook()
        {
            Store = new Dictionary<string, string>();
        }

        public void writeToFile()
        {
          
            string[] phoneNumbers = Store.Keys.ToArray();
             string[] names = Store.Values.ToArray();
            //File.WriteAllLines(Properties.Settings.Default.url, phoneNumbers)

            string[] entries = new string[Store.Count];

            for (int i = 0; i < entries.Length; i++)
            {
                entries[i] = phoneNumbers[i] + "," + names[i];     
            }
            File.AppendAllLines(Properties.Settings.Default.url, entries);
            Store = new Dictionary<string, string>();
            EncryptFile(Properties.Settings.Default.url, Properties.Settings.Default.key);
            
        }

        public void readFromFile()
        {
            DecryptFile(Properties.Settings.Default.url, Properties.Settings.Default.key);
        }

        
            public void UnScramble()
        {
            DecryptFile(Properties.Settings.Default.url, Properties.Settings.Default.key);
        }

        public void Scramble() {
            EncryptFile(Properties.Settings.Default.url, Properties.Settings.Default.key);
        }


        private  void EncryptFile(string url, string key)
        #region
        {
            byte[] plainText = File.ReadAllBytes(url);
            var DES = new DESCryptoServiceProvider();
            using (DES)
            {
                DES.IV = Encoding.UTF8.GetBytes(key);
                DES.Key = Encoding.UTF8.GetBytes(key);
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;

                using (var stream = new System.IO.MemoryStream())
                {
                    CryptoStream cryptStream = new CryptoStream(stream, DES.CreateEncryptor(), CryptoStreamMode.Write);
                    cryptStream.Write(plainText, 0, plainText.Length);
                    cryptStream.FlushFinalBlock();

                    File.WriteAllBytes(url, stream.ToArray());

                    MessageBox.Show("Your file has \nsuccessfully been encrypted.");
                }
            }

        }
        #endregion


        private void DecryptFile(string url, string key)
        #region
        {
            
            byte[] plainText = File.ReadAllBytes(url);
            var DES = new DESCryptoServiceProvider();
            using (DES)
            #region
            {
                DES.IV = Encoding.UTF8.GetBytes(key);
                DES.Key = Encoding.UTF8.GetBytes(key);
                DES.Mode = CipherMode.CBC;
                DES.Padding = PaddingMode.PKCS7;

                using (var stream = new System.IO.MemoryStream())
                #region
                {
                    try {
                        CryptoStream cryptStream = new CryptoStream(stream, DES.CreateDecryptor(), CryptoStreamMode.Write);
                        cryptStream.Write(plainText, 0, plainText.Length);
                        cryptStream.FlushFinalBlock();


                        File.WriteAllBytes(url, stream.ToArray());
                        MessageBox.Show("Your file has \nsuccessfully been decrypted.");

                    } catch (System.Security.Cryptography.CryptographicException sse) {
                        return;
                    }
                       
                }
                #endregion
            }
            #endregion
        }
        #endregion
    } 
}


