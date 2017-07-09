namespace Persistence.Databases

open System.IO
open Persistence.Types
open Persistence.Types.FileStorageDAOConfiguration
open Domain.Types
open Google.Cloud.Storage.V1
open Google.Apis.Storage.v1
open Google.Apis.Storage.v1.Data


type GCPStorageContext = { Configuration: GCPStorageDAOConfiguration }

module GCPStorageContext =
  let create configuration =
   { Configuration = configuration }

  let private createClientAsync = async {
    return! Async.AwaitTask (StorageClient.CreateAsync())
  }
  let private uploadToStorageAsync  config file (client: StorageClient) = async {
    let liftUploadParams =
      fun file config -> (UploadFile.getFilename file, UploadFile.getFileType file, GCPStorageConfig.getBucketName config)

    let liftFileStream =
      fun file -> (UploadFile.getFileStream file)
    
    use fileStream = liftFileStream file
    let filename, fileType, bucketName = liftUploadParams file config
      
    return! Async.AwaitTask (client.UploadObjectAsync(bucketName, filename, fileType, fileStream))
  }

  let uploadAsync (context : GCPStorageContext) (file : UploadFile) = async {
      let! uploadResult =
        createClientAsync 
        |> Async.RunSynchronously
        |> uploadToStorageAsync context.Configuration file

      return uploadResult.Id
  }