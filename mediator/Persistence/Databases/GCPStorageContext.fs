namespace Persistence.Databases

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
    let bucketName = GCPStorageConfig.getBucketName config

    use fileStream = UploadFile.getFileStream file
    let filename = UploadFile.getFilename file
    let fileType = UploadFile.getFileType file
    
    return! Async.AwaitTask(client.UploadObjectAsync(bucketName, filename, fileType, fileStream))
  }

  let uploadAsync (context : GCPStorageContext) (file : UploadFile) = async {
      let! uploadResult =
        createClientAsync 
        |> Async.RunSynchronously
        |> uploadToStorageAsync context.Configuration file

      return 1

  }