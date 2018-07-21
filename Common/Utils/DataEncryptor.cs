using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.Security.Cryptography;
using System.Configuration;
public static class Crypt
{
    private static byte[] key = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
    private static byte[] iv = new byte[8] { 1, 2, 3, 4, 5, 6, 7, 8 };
    private static string EncryptionKey = ConfigurationManager.AppSettings["EncryptionKey"].ToString();

    public static string CryptStr(this string text)
    {
        if (!EncryptionKey.Trim().Equals(""))
        {
            SymmetricAlgorithm algorithm = DES.Create();
            ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            byte[] inputbuffer = Encoding.Unicode.GetBytes(text + "|" + EncryptionKey);
            byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            return Convert.ToBase64String(outputBuffer);
        }
        else
            throw new Exception("Encryption Key Not Defined");
    }

    public static string Decrypt(this string text)
    {
        SymmetricAlgorithm algorithm = DES.Create();
        ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
        byte[] inputbuffer = Convert.FromBase64String(text);
        byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);

        string decryptedValue =  Encoding.Unicode.GetString(outputBuffer).ToString();
        string[] decryptedArray = decryptedValue.Split('|');

        if (decryptedArray.Length > 0)
        {
            if (decryptedArray[1].Trim().Equals(EncryptionKey))
            {
                return decryptedArray[0];
            }
            else
            {
                throw new Exception("Not a valid Call");
            }
        }
        else
        {
            throw new Exception("Not a valid Call");
        }
    }
}