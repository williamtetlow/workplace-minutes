namespace Domain.Operations

type Message =
  // DOMAIN EVENTS
  | FileUploaded
  | FileUploadFail
  // ERRORS
  | NullProperty
  | FileUploadDTOIsNull
  | InvalidFileType

module Message =
  let ToString =
    fun msg -> (sprintf "%A" msg)