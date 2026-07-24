using Transloadit.Serialization.Attributes;

namespace Transloadit.Models.Credentials;

/// <summary>
/// Represents Supabase credentials request.
/// </summary>
public class SupabaseCredentialsRequest : CredentialsRequestBase
{
    /// <summary>
    /// Initializes Supabase credentials request.
    /// </summary>
    public SupabaseCredentialsRequest()
    {
        Type = "supabase";
    }

    /// <summary>
    /// Supabase credentials content.
    /// </summary>
    [TransloaditJsonName("content")]
    public SupabaseCredentialsContent Content { get; set; }
}

/// <summary>
/// Represents Supabase credentials.
/// </summary>
public class SupabaseCredentialsContent
{
    /// <summary>
    /// Supabase bucket.
    /// </summary>
    [TransloaditJsonName("bucket")]
    public string Bucket { get; set; }

    /// <summary>
    /// Supabase host.
    /// </summary>
    [TransloaditJsonName("host")]
    public string Host { get; set; }

    /// <summary>
    /// Supabase bucket region.
    /// </summary>
    [TransloaditJsonName("bucket_region")]
    public string BucketRegion { get; set; }

    /// <summary>
    /// Supabase key.
    /// </summary>
    [TransloaditJsonName("key")]
    public string Key { get; set; }

    /// <summary>
    /// Supabase secret.
    /// </summary>
    [TransloaditJsonName("secret")]
    public string Secret { get; set; }
}
