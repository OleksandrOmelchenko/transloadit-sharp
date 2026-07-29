using CsCheck;
using Transloadit.Utilities;
using Xunit;

namespace Transloadit.Tests.Tests.Unit;

// property-based tests over the security-critical signature path, exercising arbitrary inputs/keys where
// SignatureTests only pins a few hardcoded hashes. these run on every target framework, so they also cover the
// signature path under both serializer engines' TFMs.
public class SignaturePropertyTests
{
    private static readonly Gen<SignatureAlgorithm> Algorithms =
        Gen.OneOfConst(SignatureAlgorithm.Sha1, SignatureAlgorithm.Sha256, SignatureAlgorithm.Sha384);

    [Fact]
    public void Signature_RoundTrips_ForAnyInputAndKey()
        => Gen.Select(Gen.String, Gen.String, Algorithms)
            .Sample((input, key, algorithm) =>
                SignatureUtilities.ValidateSignature(input, key, SignatureUtilities.CalculateSignature(input, key, algorithm)));

    [Fact]
    public void Signature_IsDeterministic()
        => Gen.Select(Gen.String, Gen.String, Algorithms)
            .Sample((input, key, algorithm) =>
                SignatureUtilities.CalculateSignature(input, key, algorithm) == SignatureUtilities.CalculateSignature(input, key, algorithm));

    [Fact]
    public void Signature_WithADifferentKey_DoesNotValidate()
        => Gen.Select(Gen.String, Gen.String, Gen.String, Algorithms)
            .Sample((input, key, otherKey, algorithm) =>
                key == otherKey
                || !SignatureUtilities.ValidateSignature(input, otherKey, SignatureUtilities.CalculateSignature(input, key, algorithm)));

    [Fact]
    public void Signature_OverTamperedInput_DoesNotValidate()
        => Gen.Select(Gen.String, Gen.String, Algorithms)
            .Sample((input, key, algorithm) =>
                !SignatureUtilities.ValidateSignature(input + "x", key, SignatureUtilities.CalculateSignature(input, key, algorithm)));
}
