using System;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;

namespace Transloadit.Utilities
{
    /// <summary>
    /// Specifies the hash algorithm used for calculating Transloadit API signatures.
    /// </summary>
    public enum SignatureAlgorithm
    {
        /// <summary>
        /// Deprecated but still supported. Not recommended to use.
        /// </summary>
        Sha1 = 1,

        /// <summary>
        /// Usually used for generating signatures for Smart CDN URLs. 
        /// This is due to restrictions from Amazon CloudFront which Transloadit use as a CDN.
        /// </summary>
        Sha256 = 2,

        /// <summary>
        /// Recommended algorithm to use. Used by default.
        /// </summary>
        Sha384 = 3,
    }

    /// <summary>
    /// Provides useful utilities for work with Transloadit API signatures.
    /// </summary>
    public static class SignatureUtilities
    {
        /// <summary>
        /// Calculates a signature for the specified string.
        /// </summary>
        /// <param name="input">The string to calculate signature for.</param>
        /// <param name="key">The secret key for encryption.</param>
        /// <param name="algorithm">The hashing algorithm to use.</param>
        /// <returns>The signature as <c>algorithm:hash</c>.</returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
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

        /// <summary>
        /// Validates the signature against the signature of the provided string.
        /// </summary>
        /// <param name="input">The string to calculate signature for.</param>
        /// <param name="key">The secret key for encryption.</param>
        /// <param name="signature">The signature to validate against.</param>
        /// <returns>A value indicating whether given <paramref name="signature"/> matches with the signature of <paramref name="input"/>.</returns>
        /// <exception cref="ArgumentException"></exception>
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
    }
}
