namespace Persistence.Types

module BucketStorage =
  type GoogleCloudStorage = { ProjectId : string }

  type T =
    | GCP of GoogleCloudStorage
