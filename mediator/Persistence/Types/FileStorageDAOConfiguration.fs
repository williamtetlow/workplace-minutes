namespace Persistence.Types

type GCPStorageDAOConfiguration = { ProjectId: string; BucketName: string; }

type FileStorageDAOConfiguration =
  | GCPStorageConfiguration of GCPStorageDAOConfiguration

module FileStorageDAOConfiguration =
  let createGCPStorageConfig projectId bucketName : FileStorageDAOConfiguration =
    GCPStorageConfiguration { ProjectId = projectId; BucketName = bucketName }
    
  module GCPStorageConfig =
    let getBucketName (config : GCPStorageDAOConfiguration) =
      config.BucketName