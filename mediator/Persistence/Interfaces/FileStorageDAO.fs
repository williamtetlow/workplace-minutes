namespace Persistence.Interfaces

open Domain.Types
open Persistence.Types
open Persistence.Databases

type IFileStorageDAO =
  abstract Insert : UploadFile -> int

type GCPFileStorageDAO(configuration : GCPStorageDAOConfiguration) =
  interface IFileStorageDAO with
    member this.Insert file =
      let db = GCPStorageContext.create configuration
      GCPStorageContext.upload db file
      

module FileStorageDAO =
  let create (configuration : FileStorageDAOConfiguration) =
    match configuration with
     | GCPStorage config -> GCPFileStorageDAO(config) :> IFileStorageDAO
  
     