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
      GCPStorageContext.uploadAsync db file
      

module FileStorageDAO =
  let create (config : FileStorageDAOConfiguration) =
    let implementation =
      match config with
        | GCPStorageConfiguration c -> GCPFileStorageDAO(c)
    implementation :> IFileStorageDAO
     