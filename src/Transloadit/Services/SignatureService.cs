using System;
using System.ComponentModel;
using Transloadit.Utilities;

namespace Transloadit.Services
{
    /// <summary>
    /// Represents tools for working with signatures.
    /// </summary>
    public class SignatureService
    {
        private readonly string _secret;

        /// <summary>
        /// Initializes a new instance of the <see cref="SignatureService"/> class with Transloadit secret.
        /// </summary>
        /// <param name="secret">Transloadit auth secret.</param>
        public SignatureService(string secret)
        {
            _secret = secret;
        }

        /// <summary>
        /// Calculates a signature for the specified string.
        /// </summary>
        /// <param name="input">The string to calculate signature for.</param>
        /// <param name="algorithm">The hashing algorithm to use.</param>
        /// <returns>The signature as <c>algorithm:hash</c>.</returns>
        /// <exception cref="InvalidEnumArgumentException"></exception>
        public string CalculateSignature(string input, SignatureAlgorithm algorithm = SignatureAlgorithm.Sha384)
            => SignatureUtilities.CalculateSignature(input, _secret, algorithm);

        /// <summary>
        /// Validates the signature against the signature of the provided string.
        /// </summary>
        /// <param name="input">The string to calculate signature for.</param>
        /// <param name="signature">The signature to validate against.</param>
        /// <returns>A value indicating whether given <paramref name="signature"/> matches with the signature of <paramref name="input"/>.</returns>
        /// <exception cref="ArgumentException"></exception>
        public bool ValidateSignature(string input, string signature)
            => SignatureUtilities.ValidateSignature(input, _secret, signature);
    }
}