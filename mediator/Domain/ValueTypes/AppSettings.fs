namespace Domain.ValueTypes

type DataSettings = 
  BucketStorageProjectId of string

type AppSettings = 
  Data of DataSettings
