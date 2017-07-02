namespace Service.FileUpload

open System
open Persistence.Interfaces
open Domain.Types

type FileUploader = { Context: IFileStorageDAO }

module FileUploader =

  let SaveFileToStorage (uploader : FileUploader) file = async {
    let context = fun uploader -> uploader.Context



    return! (uploader |> context).Insert file
  }
