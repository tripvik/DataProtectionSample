using System;
using System.Security.Cryptography;
using System.Text;

namespace DPAPIExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter text to encrypt:");
            string plainText = Console.ReadLine();

            try
            {
                // Encrypt the text
                byte[] encryptedData = ProtectData(Encoding.UTF8.GetBytes(plainText));

                Console.WriteLine("\nEncrypted Text:");
                Console.WriteLine(Convert.ToBase64String(encryptedData));

                // Decrypt the text
                byte[] decryptedData = UnprotectData(encryptedData);

                Console.WriteLine("\nDecrypted Text:");
                Console.WriteLine(Encoding.UTF8.GetString(decryptedData));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            Console.ReadLine();
        }

        static byte[] ProtectData(byte[] data)
        {
            // Protect the data using DPAPI
            return ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
        }

        static byte[] UnprotectData(byte[] data)
        {
            // Unprotect the data using DPAPI
            return ProtectedData.Unprotect(data, null, DataProtectionScope.CurrentUser);
        }
    }
}