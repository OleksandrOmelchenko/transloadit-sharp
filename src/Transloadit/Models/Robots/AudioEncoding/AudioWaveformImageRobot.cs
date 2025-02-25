﻿using System.Collections.Generic;

namespace Transloadit.Models.Robots.AudioEncoding
{
    /// <summary>
    /// Represents <c>"/audio/waveform</c> Robot.
    /// </summary>
    public class AudioWaveformImageRobot : RobotBase
    {
        /// <summary>
        /// Specifies which Step(s) to use as input.
        /// </summary>
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }

        /// <summary>
        /// Allows to specify a set of metadata that is more expensive on CPU power to calculate, 
        /// and thus is disabled by default to keep your Assemblies processing fast.
        /// This can be set to <c>false</c> to skip metadata extraction and speed up transcoding.
        /// <para>Default: <c>{}</c>.</para>
        /// </summary>
        public AnyOf<bool, OutputMeta> OutputMeta { get; set; }
        public string Format { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int? Style { get; set; }
        public int? Antialiasing { get; set; }
        public string BackgroundColor { get; set; }
        public string CenterColor { get; set; }
        public string OuterColor { get; set; }

        /// <summary>
        /// Initializes <c>"/audio/waveform</c> Robot.
        /// </summary>
        public AudioWaveformImageRobot()
        {
            Robot = "/audio/waveform";
        }
    }
}
