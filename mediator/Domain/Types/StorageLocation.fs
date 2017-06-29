namespace Domain.Types

open System

type GoogleCloudStorageLocation = { ProjectName: string; BucketId: string; }

type StorageLocation =
  | GoogleCloudStorageLocation of GoogleCloudStorageLocation

module StorageLocation =

  module GoogleCloudStorageLocation =
    let create projectName bucketId =
      { ProjectName = projectName; BucketId = bucketId }