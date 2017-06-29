namespace Persistence.Types

type GCPStorageDAOConfiguration = { ProjectId: string; BucketId: string; }

type FileStorageDAOConfiguration =
  | GCPStorageConfiguration of GCPStorageDAOConfiguration

module FileStorageDAOConfiguration =
  let createGCPStorageConfig projectId bucketId =
    { ProjectId = projectId; BucketId = bucketId }