using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace Transloadit.Utilities
{
    public enum SignatureAlgorithm
    {
        Sha1 = 1,
        Sha256 = 2,
        Sha384 = 3,
    }

    public static class SignatureUtilities
    {
        private static string ToLowerHex(byte[] bytes)
        {
            var builder = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        private static string CalculateHash(string input, string key, SignatureAlgorithm algorithm = SignatureAlgorithm.Sha384)
        {
            using HMAC crypto = algorithm switch
            {
                SignatureAlgorithm.Sha384 => new HMACSHA384(Encoding.UTF8.GetBytes(key)),
                SignatureAlgorithm.Sha256 => new HMACSHA256(Encoding.UTF8.GetBytes(key)),
                SignatureAlgorithm.Sha1 => new HMACSHA1(Encoding.UTF8.GetBytes(key)),
                _ => throw new InvalidEnumArgumentException($"Unexpected SignatureAlgorithm: {algorithm}"),
            };

            var hashBytes = crypto.ComputeHash(Encoding.UTF8.GetBytes(input));
            var hash = ToLowerHex(hashBytes);

            return hash;
        }

        public static string CalculateSignature(string input, string key, SignatureAlgorithm algorithm = SignatureAlgorithm.Sha384)
        {
            var prefix = algorithm switch
            {
                SignatureAlgorithm.Sha384 => "sha384:",
                SignatureAlgorithm.Sha256 => "sha256:",
                SignatureAlgorithm.Sha1 => "",
                _ => throw new InvalidEnumArgumentException($"Unexpected SignatureAlgorithm: {algorithm}"),
            };

            var hash = CalculateHash(input, key, algorithm);
            return $"{prefix}{hash}";
        }

        public static bool ValidateSignature(string input, string key, string signature)
        {
            var parts = signature.Split(':');
            SignatureAlgorithm algorithm;
            if (parts.Length == 2)
            {
                algorithm = parts[0] switch
                {
                    "sha384" => SignatureAlgorithm.Sha384,
                    "sha256" => SignatureAlgorithm.Sha256,
                    _ => throw new ArgumentException($"Unexpected hashing algorithm prefix: {parts[0]}"),
                };

                return parts[1] == CalculateHash(input, key, algorithm);
            }
            else
            {
                algorithm = SignatureAlgorithm.Sha1;
                return signature == CalculateHash(input, key, algorithm);
            }
        }
    }
}
