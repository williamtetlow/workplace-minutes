namespace Domain.Types

open System
open Domain.Types

type StoredFile = { UploadFile: UploadFileType; StorageLocation: StorageLocationType }

// EVENTS
type FileStoredEvent = { Timestamp: DateTime; File: UploadFileType; StorageLocation: StorageLocationType }

type FileStoredEvents =
  | FileStoredEvent

module StoredFile =
  let create uploadFile storageLocation = 
    { UploadFile = uploadFile; StorageLocation = storageLocation }