namespace Persistence.Interfaces

open System
open Domain.Types
open Persistence.Types
open Persistence.Databases
open Persistence.Databases.GCPStorageContext

type IFileStorageDAO =
  abstract Insert : UploadFile -> Async<string>

type GCPFileStorageDAO(configuration : GCPStorageDAOConfiguration) =
  interface IFileStorageDAO with
    member this.Insert file = async {
      let db = GCPStorageContext.create configuration
      return! GCPStorageContext.uploadAsync db file
    }
      

module FileStorageDAO =
  let create (config : FileStorageDAOConfiguration) =
    let implementation =
      match config with
        | GCPStorageConfiguration c -> GCPFileStorageDAO(c)
    implementation :> IFileStorageDAO
     