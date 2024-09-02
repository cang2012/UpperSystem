using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UpperSystem.Utility
{
    public static class StringExtension
    {
        #region AES 加密/解密
        /// <summary>
        ///  AES 加密
        /// </summary>
        /// <param name="text">明文（待加密）</param>
        /// <param name="encryptionKey">密文</param>
        /// <returns></returns>
        public static string AesEncrypt(this string text, string encryptionKey = "")
        {
            if (string.IsNullOrWhiteSpace(encryptionKey))
            {
                encryptionKey = "AMAR2SPBNRAP390";
            }
            
            byte[] clearBytes = Encoding.Unicode.GetBytes(text);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[]
                  { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(),
                  CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    text = Convert.ToBase64String(ms.ToArray());
                }
            }

            return text;
        }

        /// <summary>
        ///  AES 解密
        /// </summary>
        /// <param name="cipherText">明文（待解密）</param>
        /// <param name="key">密文</param>
        /// <returns></returns>
        public static string AesDecrypt(this string cipherText, string encryptionKey = "")
        {
            if (string.IsNullOrWhiteSpace(encryptionKey))
            {
                encryptionKey = "AMAR2SPBNRAP390";
            }
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[]
                     { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(),
                                               CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }

            return cipherText;
        }
        #endregion
    }
}
