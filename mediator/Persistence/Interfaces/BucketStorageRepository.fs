namespace Persistence.Interfaces

open Persistence.Types
open Google.Cloud.Storage.V1

type IBucketStorageRepository =
  abstract member AddAsync : unit -> Async<int>

type GoogleCloudStorageRepository (config : BucketStorage.GoogleCloudStorage) =
  interface IBucketStorageRepository with 
    member this.AddAsync() = async {
      return 0
    }

module BucketStorageRepository =
  let private targetBucketStorageType (storage : BucketStorage.T) =
    let impl =
      match storage with
      | BucketStorage.GCP googleCloudStorageConfig -> GoogleCloudStorageRepository(googleCloudStorageConfig)
    impl :> IBucketStorageRepository
    
  let add db file = async {
    let repo = targetBucketStorageType db
    
    return! repo.AddAsync()
  }