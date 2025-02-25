using System.Collections.Generic;

namespace Transloadit.Models.Robots.FileCompressing
{
    /// <summary>
    /// Represents <c>/file/compress</c> Robot.
    /// </summary>
    public class FileCompressRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// The format of the archive to be created. Supported values are <c>tar</c> and <c>zip</c>.
        /// Setting <c>tar</c> without setting <c>gzip</c> to <c>true</c> results in an archive that's not compressed in any way.
        /// <para>Default: <c>tar</c>.</para>
        /// </summary>
        public string Format { get; set; }

        /// <summary>
        /// Determines if the result archive should also be gzipped. Gzip compression is only applied if the <c>tar</c> format is used.
        /// <para>Default: <c>false</c>.</para>
        /// </summary>
        public bool? Gzip { get; set; }

        /// <summary>
        /// This allows to encrypt all archive contents with a password and thereby protect it against unauthorized use. 
        /// To unzip the archive, the user will need to provide the password in a text input field prompt.
        /// <para>This parameter has no effect if the <c>format</c> parameter is anything other than <c>zip</c>.</para>
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Determines how fiercely to try to compress the archive. <c>-0</c> is compressionless, which is suitable for media that is already compressed. 
        /// <c>-1</c> is fastest with lowest compression. <c>-9</c> is slowest with the highest compression.
        /// <para>Default: <c>-6</c>.</para>
        /// </summary>
        public int? CompressionLevel { get; set; }

        /// <summary>
        /// Determines if the result archive should contain all files in one directory (value for this is <c>simple</c>) 
        /// or in subfolders according to the explanation below (value for this is <c>advanced</c>).
        /// <para>Default: <c>advanced</c>.</para>
        /// </summary>
        public string FileLayout { get; set; }

        /// <summary>
        /// Initializes <c>/file/compress</c> Robot.
        /// </summary>
        public FileCompressRobot()
        {
            Robot = "/file/compress";
        }
    }
}
