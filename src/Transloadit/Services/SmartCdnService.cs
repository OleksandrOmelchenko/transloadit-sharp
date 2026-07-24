using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Transloadit.Utilities;
#if NET452
using Transloadit.Polyfills;
#endif

namespace Transloadit.Services;

/// <summary>
/// Represents tools for working with signatures.
/// </summary>
public class SmartCdnService
{
    private readonly string _key;
    private readonly string _secret;

    /// <summary>
    /// Initializes a new instance of the <see cref="SmartCdnService"/> class with Transloadit key and secret.
    /// </summary>
    /// <param name="key">Transloadit auth key.</param>
    /// <param name="secret">Transloadit auth secret.</param>
    public SmartCdnService(string key, string secret)
    {
        _secret = secret;
        _key = key;
    }

    /// <summary>
    /// Creates a Smart CDN url with signature.
    /// </summary>
    /// <param name="workspaceSlug">Workspace slug.</param>
    /// <param name="templateSlug">Template slug.</param>
    /// <param name="inputField">Input field.</param>
    /// <param name="signatureExpiration">CDN signature expiration date.</param>
    /// <param name="parameters">Additional parameters.</param>
    /// <returns>Smart CDN url with signature.</returns>
    public string GetSignedSmartCdnUrl(
        string workspaceSlug,
        string templateSlug,
        string inputField,
        DateTimeOffset signatureExpiration,
        Dictionary<string, string> parameters = null)
    {
        parameters ??= [];

        var encodedWorkspaceSlug = WebUtility.UrlEncode(workspaceSlug);
        var encodedTemplateSlug = WebUtility.UrlEncode(templateSlug);
        var encodedInputField = WebUtility.UrlEncode(inputField);

        parameters["auth_key"] = _key;
        parameters["exp"] = signatureExpiration.ToUnixTimeMilliseconds().ToString();

        // ordinal sort to match the server, which reconstructs the string-to-sign using URLSearchParams.sort()
        // (UTF-16 code-unit order). a culture-sensitive sort would order mixed-case keys differently and produce
        // a signature the CDN rejects. keys are encoded too, mirroring URLSearchParams.toString().
        var sortedParams = parameters.OrderBy(p => p.Key, StringComparer.Ordinal);
        var queryParams = string.Join("&", sortedParams.Select(p => $"{WebUtility.UrlEncode(p.Key)}={WebUtility.UrlEncode(p.Value)}"));

        var stringToSign = $"{encodedWorkspaceSlug}/{encodedTemplateSlug}/{encodedInputField}?{queryParams}";

        var signature = SignatureUtilities.CalculateSignature(stringToSign, _secret, SignatureAlgorithm.Sha256);
        var signedUrl = $"https://{encodedWorkspaceSlug}.tlcdn.com/{encodedTemplateSlug}/{encodedInputField}?{queryParams}&sig={signature}";
        return signedUrl;
    }
}