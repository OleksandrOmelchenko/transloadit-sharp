using System;
using System.ComponentModel;
using Transloadit.Services;
using Transloadit.Utilities;
using Xunit;

namespace Transloadit.Tests.Tests.Unit;

public class SignatureUtilitiesTests
{
    private const string Key = "ZAoE63deFCA915LupzPqTyOv4WCZmuOwJioIxwF3";
    private const string Input = "{\"auth\":{\"key\":\"some-secret-key\"}}";

    [Fact]
    public void CalculateSignature_Sha384_HasPrefix()
    {
        var signature = SignatureUtilities.CalculateSignature(Input, Key, SignatureAlgorithm.Sha384);
        Assert.StartsWith("sha384:", signature);
    }

    [Fact]
    public void CalculateSignature_Sha256_HasPrefix()
    {
        var signature = SignatureUtilities.CalculateSignature(Input, Key, SignatureAlgorithm.Sha256);
        Assert.StartsWith("sha256:", signature);
    }

    [Fact]
    public void CalculateSignature_Sha1_HasNoPrefix()
    {
        var signature = SignatureUtilities.CalculateSignature(Input, Key, SignatureAlgorithm.Sha1);
        Assert.DoesNotContain(":", signature);
    }

    [Fact]
    public void CalculateSignature_DefaultsToSha384()
    {
        var withDefault = SignatureUtilities.CalculateSignature(Input, Key);
        var explicitSha384 = SignatureUtilities.CalculateSignature(Input, Key, SignatureAlgorithm.Sha384);
        Assert.Equal(explicitSha384, withDefault);
    }

    [Fact]
    public void CalculateSignature_UnknownAlgorithm_Throws()
    {
        Assert.Throws<InvalidEnumArgumentException>(
            () => SignatureUtilities.CalculateSignature(Input, Key, (SignatureAlgorithm)999));
    }

    [Fact]
    public void ValidateSignature_MatchingSignature_ReturnsTrue()
    {
        var signature = SignatureUtilities.CalculateSignature(Input, Key, SignatureAlgorithm.Sha384);
        Assert.True(SignatureUtilities.ValidateSignature(Input, Key, signature));
    }

    [Fact]
    public void ValidateSignature_NonMatchingSignature_ReturnsFalse()
    {
        Assert.False(SignatureUtilities.ValidateSignature(Input, Key, "sha384:deadbeef"));
    }

    [Fact]
    public void ValidateSignature_LegacySha1_ReturnsTrue()
    {
        var sha1 = SignatureUtilities.CalculateSignature(Input, Key, SignatureAlgorithm.Sha1);
        Assert.True(SignatureUtilities.ValidateSignature(Input, Key, sha1));
    }

    [Fact]
    public void ValidateSignature_UnknownPrefix_Throws()
    {
        Assert.Throws<ArgumentException>(
            () => SignatureUtilities.ValidateSignature(Input, Key, "md5:abcdef"));
    }

    [Fact]
    public void SignatureService_DelegatesToUtilities()
    {
        var service = new SignatureService(Key);
        var fromService = service.CalculateSignature(Input, SignatureAlgorithm.Sha256);
        var fromUtilities = SignatureUtilities.CalculateSignature(Input, Key, SignatureAlgorithm.Sha256);

        Assert.Equal(fromUtilities, fromService);
        Assert.True(service.ValidateSignature(Input, fromService));
    }
}
