using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class AesEncryption
{
    // AES-256 requires a 256-bit key (32 bytes)
    private static readonly byte[] AesKey = new byte[] {
        0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
        0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F, 0x10,
        0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18,
        0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F, 0x20
    };

    // Fixed IV size for AES (16 bytes)
    private static readonly byte[] AesIV = new byte[] {
        0x10, 0x20, 0x30, 0x40, 0x50, 0x60, 0x70, 0x80,
        0x90, 0xA0, 0xB0, 0xC0, 0xD0, 0xE0, 0xF0, 0x00
    };

    public static byte[] Encrypt(string plainText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = AesKey;
            aesAlg.IV = AesIV;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }
                return msEncrypt.ToArray();
            }
        }
    }

    public static string Decrypt(byte[] cipherText)
    {
        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = AesKey;
            aesAlg.IV = AesIV;
            aesAlg.Mode = CipherMode.CBC;
            aesAlg.Padding = PaddingMode.PKCS7;

            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
            using (var msDecrypt = new MemoryStream(cipherText))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(csDecrypt))
                {
                    return srDecrypt.ReadToEnd();
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        string original = "Hello, world!";
        byte[] encrypted = AesEncryption.Encrypt(original);
        string decrypted = AesEncryption.Decrypt(encrypted);

        Console.WriteLine($"Original: {original}");
        Console.WriteLine($"Encrypted: {Convert.ToBase64String(encrypted)}");
        Console.WriteLine($"Decrypted: {decrypted}");
    }
}




//using System.Security.Cryptography;
//using System.Text;

//namespace AesEncryption
//{
//    public class AesEncryption
//    {
//        private static readonly byte[] fixedIV = new byte[16] { 15, 23, 75, 34, 2, 13, 56, 28, 29, 10, 11, 12, 13, 14, 15, 16 };
//        private const int KeySize = 256;
//        private const int SaltSize = 16; // Size in bytes
//        private const int Iterations = 10000; // Number of iterations

//        public static byte[] Encrypt(string plainText, string password)
//        {
//            byte[] salt = GenerateRandomSalt();
//            byte[] key = GenerateKeyFromPassword(password, salt, KeySize / 8, Iterations);

//            using (Aes aesAlg = Aes.Create())
//            {
//                aesAlg.Key = key;
//                aesAlg.IV = fixedIV;
//                aesAlg.Mode = CipherMode.CBC;

//                using (var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV))
//                using (var msEncrypt = new MemoryStream())
//                {
//                    // Prepend salt to output
//                    msEncrypt.Write(salt, 0, salt.Length);

//                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
//                    using (var swEncrypt = new StreamWriter(csEncrypt))
//                    {
//                        swEncrypt.Write(plainText);
//                    }

//                    return msEncrypt.ToArray();
//                }
//            }
//        }

//        public static string Decrypt(byte[] cipherText, string password)
//        {
//            // Extract salt from the beginning of the cipherText
//            byte[] salt = new byte[SaltSize];
//            Array.Copy(cipherText, 0, salt, 0, salt.Length);
//            byte[] key = GenerateKeyFromPassword(password, salt, KeySize / 8, Iterations);

//            using (Aes aesAlg = Aes.Create())
//            {
//                aesAlg.Key = key;
//                aesAlg.IV = fixedIV;
//                aesAlg.Mode = CipherMode.CBC;

//                using (var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV))
//                using (var msDecrypt = new MemoryStream(cipherText, salt.Length, cipherText.Length - salt.Length))
//                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
//                using (var srDecrypt = new StreamReader(csDecrypt))
//                {
//                    return srDecrypt.ReadToEnd();
//                }
//            }
//        }

//        public static byte[] GenerateRandomSalt()
//        {
//            using (var rng = new RNGCryptoServiceProvider())
//            {
//                byte[] salt = new byte[SaltSize];
//                rng.GetBytes(salt);
//                return salt;
//            }
//        }

//        // Derive a key from a password using PBKDF2
//        public static byte[] GenerateKeyFromPassword(string password, byte[] salt, int keyBytes, int iterations)
//        {
//            using (var keyDerivationFunction = new Rfc2898DeriveBytes(password, salt, iterations))
//            {
//                return keyDerivationFunction.GetBytes(keyBytes);
//            }
//        }
//    }

//    class Program
//    {
//        static void Main()
//        {
//            string original = "Hello, world!";
//            string password = "p@ssw0rd";

//            byte[] encrypted = AesEncryption.Encrypt(original, password);
//            string decrypted = AesEncryption.Decrypt(encrypted, password);

//            Console.WriteLine($"Original: {original}");
//            Console.WriteLine($"Encrypted: {Convert.ToBase64String(encrypted)}");
//            Console.WriteLine($"Decrypted: {decrypted}");


//            string generatedkeyfrompass = Convert.ToBase64String(AesEncryption.GenerateKeyFromPassword(password, AesEncryption.GenerateRandomSalt(), 32, 10000));
//            Console.WriteLine($"Generated key from password: {generatedkeyfrompass}");
//        }
//    }

//}

