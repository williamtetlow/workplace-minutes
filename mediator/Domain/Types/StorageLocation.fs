namespace Domain.Types

open System

type GoogleCloudStorageLocationType = { ProjectName: string; BucketId: string; }

type StorageLocationType =
  | GoogleCloudStorageLocation of GoogleCloudStorageLocationType

module StorageLocation =

  module GoogleCloudStorageLocation =
    let create projectName bucketId =
      { ProjectName = projectName; BucketId = bucketId }