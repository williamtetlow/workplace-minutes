namespace Domain.Types

open System
open Domain.Types

type AcceptedUploadFiles = 
  | AudioFileType

type UploadFile = { FileName: string; Type: AcceptedUploadFiles; SourceSystemUser: SourceSystemUser }

// EVENTS
type UploadFileReceivedEvent = { Timestamp: DateTime; UploadFile: UploadFile }

type UploadFileEvents =
  | UploadFileReceivedEvent

module UploadFile =
  let create fileName fileType sourceSystemUser =
    { FileName = fileName; Type = fileType; SourceSystemUser = sourceSystemUser }
      