using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace BlockMapTinkering
{
    public static class Sha256Hasher
    {
        public static string GetSha256Hash(byte[] input)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] hashData = sha256Hash.ComputeHash(input);
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < hashData.Length; i++)
                {
                    stringBuilder.Append(hashData[i].ToString("x2"));
                }

                return stringBuilder.ToString();
            }
        }

        public static bool CompareByteStreamHashToSha256Hash(byte[] input, string knownSha256Hash)
        {
            string computedSha256Hash = GetSha256Hash(input);
            return (computedSha256Hash == knownSha256Hash);
        }
    }
}
