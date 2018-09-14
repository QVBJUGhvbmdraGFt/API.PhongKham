using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Schedure.API.Models
{
    public static class Encoder
    {
        public static T Encode<T>(this object value, string key)
        {
            T res = (T)Activator.CreateInstance(typeof(T));
            var pros = value.GetType().GetProperties();
            foreach (var item in res.GetType().GetProperties())
            {
                var v = pros.FirstOrDefault(q => q.Name == item.Name);
                if (v != null)
                {
                    item.SetValue(res, Encrypt(v.GetValue(value) + "", key));
                }
            }
            return res;
        }

        public static string GetKey()
        {
            return string.Join("", Encoding.ASCII.GetBytes(DateTime.Now.ToString("hhmmssddMMyyyy")));
        }

        public static T Decode<T>(this object value, string key)
        {
            T res = (T)Activator.CreateInstance(typeof(T));
            var pros = value.GetType().GetProperties();

            foreach (var item in res.GetType().GetProperties())
            {
                var v = pros.FirstOrDefault(q => q.Name == item.Name);

                if (v != null)
                {
                    var gt = Decrypt(v.GetValue(value) + "", key);
                    if (item.PropertyType.IsGenericType
                        && item.PropertyType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
                    {
                        if (string.IsNullOrWhiteSpace(gt)) continue;
                        item.SetValue(res, ChangeType(gt, Nullable.GetUnderlyingType(item.PropertyType)));
                    }
                    else
                    {
                        item.SetValue(res, Convert.ChangeType(gt, item.PropertyType));
                    }
                }
            }
            return res;
        }

        public static object ChangeType(object value, Type conversion)
        {
            var t = conversion;

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return Convert.ChangeType(value, t);
        }



        public static T ChangeType<T>(object value)
        {
            var t = typeof(T);

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return default(T);
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return (T)Convert.ChangeType(value, t);
        }

        private const string initVector = "tu89geji340t89u2";
        private const int keysize = 256;

        public static string Encrypt(string Text, string Key)
        {
            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(Text);
            PasswordDeriveBytes password = new PasswordDeriveBytes(Key, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] Encrypted = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(Encrypted);
        }

        public static string Decrypt(string EncryptedText, string Key)
        {
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] DeEncryptedText = Convert.FromBase64String(EncryptedText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(Key, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(DeEncryptedText);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[DeEncryptedText.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}