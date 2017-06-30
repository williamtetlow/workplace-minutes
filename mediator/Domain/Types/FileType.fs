namespace Domain.Types

type FileType = { ContentType: string }

type AudioFileType = FileType

module FileType = 

  let getContentType fileType =
    fileType.ContentType

  module AudioFileType =
    let create : AudioFileType =
      { ContentType = "audio/mp3" }

  let isAudioFile fileType =
    AudioFileType.create = fileType