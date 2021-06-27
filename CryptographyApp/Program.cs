using System;
using System.IO;
using System.Security.Cryptography;

namespace CryptographyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DESCryptoServiceProvider key = new DESCryptoServiceProvider();
            Console.WriteLine("Enter your message : ");
            string plainText = Console.ReadLine();
            string cipherText = "";
            Console.WriteLine("Cipher Text : " + Encrypt(plainText, key));
        }

        public static string Encrypt(string plainText, SymmetricAlgorithm key)
        {
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, key.CreateEncryptor(), CryptoStreamMode.Write);
            StreamWriter streamWriter = new StreamWriter(memoryStream);
            streamWriter.Write(plainText);
            streamWriter.Flush();
            cryptoStream.FlushFinalBlock();
            return (Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length));
        }
    }
}
