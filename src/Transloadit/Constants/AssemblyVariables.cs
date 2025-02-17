namespace Transloadit.Constants
{
    /// <summary>
    /// Contains available assembly variables.
    /// </summary>
    public static class AssemblyVariables
    {
        /// <summary>
        /// The ID of the Assembly representing the current upload, which is a UUIDv4 without dashes.
        /// </summary>
        public const string AssemblyId = "${assembly.id}";

        /// <summary>
        /// The AWS region where the Assembly is being processed. You could use this to import files from a bucket in the same region, to reduce data transfer costs and latencies.
        /// </summary>
        public const string AssemblyRegion = "${assembly.region}";

        /// <summary>
        /// The ID of the parent Assembly when replaying that parent Assembly.
        /// </summary>
        public const string AssemblyParentId = "${assembly.parent_id}";

        /// <summary>
        /// A unique 33-character prefix used to avoid file name collisions, such as <c>"f2/d3eeeb67479f11f8b091b04f6181ad"</c>.
        /// </summary>
        public const string UniquePrefix = "${unique_prefix}";

        /// <summary>
        /// This is similar to <c>${unique_prefix}</c>, with the exception that two different encoding results of the same uploaded file (the original file) will have the same prefix value here.
        /// </summary>
        public const string UniqueOriginalPrefix = "${unique_original_prefix}";

        /// <summary>
        /// The name of the previous Step that produced the current file.
        /// </summary>
        public const string PreviousStepName = "${previous_step.name}";

        /// <summary>
        /// The ID of the file being processed, which is a UUIDv4 without dashes.
        /// </summary>
        public const string FileId = "${file.id}";

        /// <summary>
        /// The ID of the original file that a certain file derives from. For example, if you use an import Robot to import files and then encode them somehow, the encoding result files will have a <c>${file.original_id}</c> that matches the <c>${file.id}</c> of the imported file.
        /// </summary>
        public const string FileOriginalId = "${file.original_id}";

        /// <summary>
        /// The name of the original file (including file extension) that a certain file derives from. For example, if you use an import Robot to import files and then encode them somehow, the encoding result files will have a <c>${file.original_name}</c> that matches the <c>${file.name}</c> of the imported file.
        /// </summary>
        public const string FileOriginalName = "${file.original_name}";

        /// <summary>
        /// The basename of the original file that a certain file derives from. For example, if you use an import Robot to import files and then encode them somehow, the encoding result files will have a <c>${file.original_basename}</c> that matches the <c>${file.basename}</c> of the imported file.
        /// </summary>
        public const string FileOriginalBasename = "${file.original_basename}";

        /// <summary>
        /// The import path of the original file that a certain file derives from. All of our import Robots set <c>${file.original_path}</c> accordingly.
        /// </summary>
        public const string FileOriginalPath = "${file.original_path}";

        /// <summary>
        /// The name of the file being processed, including the file extension.
        /// </summary>
        public const string FileName = "${file.name}";

        /// <summary>
        /// The slugged name of the file.
        /// </summary>
        public const string FileUrlName = "${file.url_name}";

        /// <summary>
        /// The name of the file being processed, without the file extension.
        /// </summary>
        public const string FileBasename = "${file.basename}";

        /// <summary>
        /// Tus uploads, which you use to upload to Transloadit, can carry meta data values. All the extra values sent along will end up in <c>user_meta</c>. This allows you to do things dynamically per file instead of per assembly with fields.
        /// </summary>
        public const string FileUserMeta = "${file.user_meta}";

        /// <summary>
        /// The slugged basename of the file (the file name without the file extension).
        /// </summary>
        public const string FileUrlBasename = "${file.url_basename}";

        /// <summary>
        /// The file extension.
        /// </summary>
        public const string FileExt = "${file.ext}";

        /// <summary>
        /// The file size in bytes.
        /// </summary>
        public const string FileSize = "${file.size}";

        /// <summary>
        /// The file's MIME type.
        /// </summary>
        public const string FileMime = "${file.mime}";

        /// <summary>
        /// The file's MD5 hash. This is a hash over the file's contents, not only over the file's name.
        /// </summary>
        public const string FileMd5Hash = "${file.md5hash}";

        /// <summary>
        /// The current date and time represented as the number of milliseconds elapsed since the UNIX epoch.
        /// </summary>
        public const string DateNow = "${Date.now()}";
    }
}
