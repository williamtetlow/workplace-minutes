namespace Domain.Types

open System
open Domain.Types

type AcceptedUploadFileType = 
  | AudioFileType

type UploadFileType = { FileName: string; Type: AcceptedUploadFileType; SourceSystemUser: SourceSystemUserType }

// EVENTS
type UploadFileReceivedEvent = { Timestamp: DateTime; UploadFile: UploadFileType }

type UploadFileEvents =
  | UploadFileReceivedEvent

module UploadFile =
  let create fileName fileType sourceSystemUser =
    { FileName = fileName; Type = fileType; SourceSystemUser = sourceSystemUser }
      