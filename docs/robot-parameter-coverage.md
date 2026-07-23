# Robot parameter coverage (follow-up backlog)

This library models a curated subset of each Robot's parameters. The universal generic params
(`result`, `force_accept`, `output_meta`, `interpolate`, `queue`, and `ignore_errors` for non-import
Robots; `credentials`, `path`, `force_name`, `import_on_errors` for imports) live on the base classes in
`src/Transloadit/Models/Robots/RobotBase.cs`. (`return_file_stubs` is documented by only 9 of 18 import
Robots, so it is modelled per-robot rather than on the base.)

The following **141 robot-specific parameters across 42 Robots** are documented by Transloadit but
not yet modelled. They are the tracked backlog for follow-up work (add via the `add-robot` skill's
per-parameter mapping). Source of truth is each Robot's docs page parameter table.

| Robot | Missing documented params | File |
|---|---|---|
| `/audio/waveform` | `amplitude_scale`, `axis_label_color`, `bar_gap`, `bar_style`, `bar_width`, `bits`, `border_color`, `color_map`, `colors`, `compression`, `end`, `ffmpeg`, `ffmpeg_stack`, `frequency_max`, `frequency_min`, `frequency_scale`, `gain`, `legend`, `no_axis_labels`, `orientation`, `pixels_per_second`, `split_channels`, `start`, `waveform_style`, `with_axis_labels`, `zoom` | `src/Transloadit/Models/Robots/AudioEncoding/AudioWaveformImageRobot.cs` |
| `/video/encode` | `segment`, `segment_duration`, `segment_name`, `segment_prefix`, `segment_time_delta`, `watermark_duration`, `watermark_opacity`, `watermark_position`, `watermark_resize_strategy`, `watermark_size`, `watermark_start_time`, `watermark_url`, `watermark_x_offset`, `watermark_y_offset` | `src/Transloadit/Models/Robots/VideoEncoding/VideoEncodeRobot.cs` |
| `/image/merge` | `cell_height`, `cell_width`, `columns`, `coverage`, `effect`, `height`, `rows`, `seed`, `shuffle`, `sort_by`, `width` | `src/Transloadit/Models/Robots/ImageManipulation/ImageMergeRobot.cs` |
| `/video/subtitle` | `bold`, `height`, `italic`, `keep_subtitles`, `language`, `name`, `outline_width`, `width` | `src/Transloadit/Models/Robots/VideoEncoding/VideoSubtitleRobot.cs` |
| `/image/resize` | `clut`, `contrast`, `monochrome`, `shave`, `watermark_opacity`, `watermark_repeat_x`, `watermark_repeat_y` | `src/Transloadit/Models/Robots/ImageManipulation/ImageResizeRobot.cs` |
| `/video/adaptive` | `audio_group`, `ffmpeg`, `ffmpeg_stack`, `height`, `hls_playlist_name`, `preset`, `width` | `src/Transloadit/Models/Robots/VideoEncoding/VideoAdaptiveRobot.cs` |
| `/video/concat` | `chapter_markers`, `height`, `sort_by`, `transition`, `transition_duration`, `width` | `src/Transloadit/Models/Robots/VideoEncoding/VideoConcatenateRobot.cs` |
| `/video/merge` | `image_url`, `loop`, `sort_by`, `transition`, `transition_duration` | `src/Transloadit/Models/Robots/VideoEncoding/VideoMergeRobot.cs` |
| `/image/bgremove` | `ignore_errors`, `model`, `provider`, `select` | `src/Transloadit/Models/Robots/ImageManipulation/ImageBackgroundRemove.cs` |
| `/video/thumbs` | `ffmpeg`, `input_codec`, `smart`, `smart_max_candidates` | `src/Transloadit/Models/Robots/VideoEncoding/VideoThumbnailsRobot.cs` |
| `/document/thumbs` | `page_range`, `stack`, `turbo` | `src/Transloadit/Models/Robots/Documents/DocumentThumbnailsRobot.cs` |
| `/file/preview` | `artwork_center_color`, `artwork_outer_color`, `zoom` | `src/Transloadit/Models/Robots/MediaCataloging/FilePreviewRobot.cs` |
| `/sftp/import` | `force_name`, `import_on_errors`, `recursive` | `src/Transloadit/Models/Robots/FileImporting/SftpImportRobot.cs` |
| `/speech/transcribe` | `max_speakers`, `speaker_labels`, `target_language` | `src/Transloadit/Models/Robots/AI/SpeechTranscribeRobot.cs` |
| `/audio/artwork` | `ffmpeg`, `preset` | `src/Transloadit/Models/Robots/AudioEncoding/AudioArtworkRobot.cs` |
| `/audio/concat` | `crossfade`, `sort_by` | `src/Transloadit/Models/Robots/AudioEncoding/AudioConcatenateRobot.cs` |
| `/dropbox/import` | `access_token`, `refresh_token` | `src/Transloadit/Models/Robots/FileImporting/DropboxImportRobot.cs` |
| `/file/compress` | `archive_name`, `path` | `src/Transloadit/Models/Robots/FileCompressing/FileCompressRobot.cs` |
| `/file/decompress` | `password`, `turbo` | `src/Transloadit/Models/Robots/FileCompressing/FileDecompressRobot.cs` |
| `/file/hash` | `partial`, `partial_size` | `src/Transloadit/Models/Robots/MediaCataloging/FileHashRobot.cs` |
| `/ftp/import` | `force_name`, `import_on_errors` | `src/Transloadit/Models/Robots/FileImporting/FtpImportRobot.cs` |
| `/http/import` | `max_file_size`, `range` | `src/Transloadit/Models/Robots/FileImporting/HttpImportRobot.cs` |
| `/image/generate` | `num_outputs`, `provider` | `src/Transloadit/Models/Robots/AI/ImageGenerateRobot.cs` |
| `/azure/import` | `recursive` | `src/Transloadit/Models/Robots/FileImporting/AzureImportRobot.cs` |
| `/azure/store` | `content_disposition` | `src/Transloadit/Models/Robots/FileExporting/AzureStoreRobot.cs` |
| `/cloudflare/store` | `url_prefix` | `src/Transloadit/Models/Robots/FileExporting/CloudFlareStoreRobot.cs` |
| `/document/merge` | `sort_by` | `src/Transloadit/Models/Robots/Documents/DocumentMergeRobot.cs` |
| `/file/serve` | `cache_duration` | `src/Transloadit/Models/Robots/SmartCdn/FileServeRobot.cs` |
| `/file/verify` | `repair_pdf` | `src/Transloadit/Models/Robots/FileFiltering/FileVerifyRobot.cs` |
| `/html/convert` | `wait_until` | `src/Transloadit/Models/Robots/Documents/HtmlConvertRobot.cs` |
| `/image/optimize` | `lossy` | `src/Transloadit/Models/Robots/ImageManipulation/ImageOptimizeRobot.cs` |
| `/meta/write` | `ffmpeg` | `src/Transloadit/Models/Robots/MediaCataloging/MetadataWriteRobot.cs` |
| `/s3/import` | `range` | `src/Transloadit/Models/Robots/FileImporting/S3ImportRobot.cs` |
| `/s3/store` | `session_token` | `src/Transloadit/Models/Robots/FileExporting/S3StoreRobot.cs` |
| `/swift/import` | `bucket_region` | `src/Transloadit/Models/Robots/FileImporting/SwiftImportRobot.cs` |
| `/swift/store` | `bucket_region` | `src/Transloadit/Models/Robots/FileExporting/SwiftStoreRobot.cs` |
| `/tigris/import` | `bucket_region` | `src/Transloadit/Models/Robots/FileImporting/TigrisImportRobot.cs` |
| `/tigris/store` | `bucket_region` | `src/Transloadit/Models/Robots/FileExporting/TigrisStoreRobot.cs` |
| `/tlcdn/deliver` | `enable_hipaa_compliance` | `src/Transloadit/Models/Robots/SmartCdn/TlcdnDeliverRobot.cs` |
| `/vimeo/store` | `folder_uri` | `src/Transloadit/Models/Robots/FileExporting/VimeoStoreRobot.cs` |
| `/wasabi/import` | `bucket_region` | `src/Transloadit/Models/Robots/FileImporting/WasabiImportRobot.cs` |
| `/wasabi/store` | `bucket_region` | `src/Transloadit/Models/Robots/FileExporting/WasabiStoreRobot.cs` |

> Generated from the rendered Transloadit docs parameter tables vs. the current models. Regenerate
> when robots or docs change (see the `docs-coverage-auditor` agent).
