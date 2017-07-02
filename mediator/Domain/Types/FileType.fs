namespace Domain.Types

type FileType = { ContentType: string; }

type AudioFileType = FileType

module FileType = 
  let create contentType =
    { ContentType = contentType }

  let getContentType fileType =
    fileType.ContentType

  module AudioFileType =
    let create : AudioFileType =
      { ContentType = "audio/mpeg"; }

  let isAudioFile fileType =
    AudioFileType.create = fileType