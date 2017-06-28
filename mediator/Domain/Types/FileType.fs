namespace Domain.Types

type FileTypeType = { ContentType: string }

type AudioFileType = FileTypeType

module FileType = 

  module AudioFileType =
    let create : AudioFileType =
      { ContentType = "audio" }

  let isAudioFile fileType =
    AudioFileType.create = fileType