namespace Domain.Types

open System
open System.IO
open Domain.Types

type AcceptedUploadFiles = 
  | AudioFile of AudioFileType

type UploadFile = { 
  FileName: string;
  Type: AcceptedUploadFiles;
  SourceSystemUser:SourceSystemUser;
  Stream: Stream
}

// EVENTS
type UploadFileReceivedEvent = { Timestamp: DateTime; UploadFile: UploadFile }

type UploadFileEvents =
  | UploadFileReceivedEvent

module UploadFile =
  let create fileName fileType sourceSystemUser stream =
    { FileName = fileName; Type = fileType; SourceSystemUser = sourceSystemUser; Stream = stream }

  let getFileStream uploadFile =
    uploadFile.Stream

  let getFilename uploadFile =
    uploadFile.FileName

  let getFileType uploadFile =
    match uploadFile.Type with
      | AudioFile audioFile -> FileType.getContentType audioFile
      