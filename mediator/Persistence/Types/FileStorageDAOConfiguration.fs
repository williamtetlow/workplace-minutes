namespace Persistence.Types

type GCPStorageDAOConfiguration = { ProjectId: string; BucketId: string; }

type FileStorageDAOConfiguration =
  | GCPStorage of GCPStorageDAOConfiguration

module FileStorageDAOConfiguration =
  let create projectId bucketId =
    { ProjectId = projectId; BucketId = bucketId }