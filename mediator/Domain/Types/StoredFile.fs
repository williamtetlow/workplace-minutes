namespace Domain.Types

open System
open Domain.Types

type StoredFile = { UploadFile: UploadFile; StorageLocation: StorageLocation }

// EVENTS
type FileStoredEvent = { Timestamp: DateTime; File: UploadFile; StorageLocation: StorageLocation }

type FileStoredEvents =
  | FileStoredEvent

module StoredFile =
  let create uploadFile storageLocation = 
    { UploadFile = uploadFile; StorageLocation = storageLocation }