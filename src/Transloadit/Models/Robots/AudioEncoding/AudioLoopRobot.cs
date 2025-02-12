﻿using System.Collections.Generic;
using Transloadit.Serialization;

namespace Transloadit.Models.Robots.AudioEncoding
{
    public class AudioLoopRobot : RobotBase
    {
        public AnyOf<string, List<string>, AdvancedUse> Use { get; set; }
        public AnyOf<bool, UploadOutputMeta> OutputMeta { get; set; }
        public string Preset { get; set; }
        public int? Bitrate { get; set; }
        public int? SampleRate { get; set; }
        public double? Duration { get; set; }
        public string FfmpegStack { get; set; }
        public Dictionary<string, object> Ffmpeg { get; set; }

        public AudioLoopRobot()
        {
            Robot = "/audio/loop";
        }
    }
}
