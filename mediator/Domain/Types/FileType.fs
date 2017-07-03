namespace Domain.Types

open Domain.Operations
open Domain.Operations.OperationResult

type FileType = { ContentType: string; }

type AudioFileType = FileType

type AcceptedFileType = 
  | AudioFile of AudioFileType

module FileType = 
  module AudioFileType =
    let private _type =
      { ContentType = "audio/mpeg"; }
    
    let create =
      AudioFile _type
    let isAudioFile (fileType : FileType) =
      _type = fileType

  let create (contentType : string) =
    match contentType with
      | null -> fail NullProperty
      | t when { ContentType = t } |> AudioFileType.isAudioFile ->
          AudioFileType.create |> success
      | _ -> fail InvalidFileType

  let getContentType fileType =
    fileType.ContentType