namespace Domain.Operations

type Message =
  // DOMAIN EVENTS
  | FileUploaded
  | FileUploadFail
  // ERRORS
  | NullProperty
  | FileUploadDTOIsNull
  | InvalidFileType