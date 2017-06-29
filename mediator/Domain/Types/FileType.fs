namespace Domain.Types

type FileType = { ContentType: string }

type AudioFileType = FileType

module FileType = 

  module AudioFileType =
    let create : AudioFileType =
      { ContentType = "audio" }

  let isAudioFile fileType =
    AudioFileType.create = fileType