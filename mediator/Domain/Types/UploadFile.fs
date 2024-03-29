namespace Domain.Types

open System
open System.IO
open Domain.Types
open Domain.Operations
open Domain.Operations.OperationResult

type UploadFile = { 
  FileName: string;
  Type: AcceptedFileType;
  SourceSystemUser: SourceSystemUser;
  Stream: Stream
}

// EVENTS
type UploadFileReceivedEvent = { Timestamp: DateTime; UploadFile: UploadFile }

type UploadFileEvents =
  | UploadFileReceivedEvent

module UploadFile =
  let create fileName fileType sourceSystemUser stream =
    { FileName = fileName; Type = fileType; SourceSystemUser = sourceSystemUser; Stream = stream }

  let newFilename filename =
    match filename with
      | null -> fail NullProperty
      | _ -> success filename

  let getFileStream uploadFile =
    uploadFile.Stream

  let getFilename uploadFile =
    uploadFile.FileName

  let getFileType uploadFile =
    match uploadFile.Type with
      | AudioFile audioFile -> FileType.getContentType audioFile