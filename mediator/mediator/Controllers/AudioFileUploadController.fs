namespace mediator.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open System.IO
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Http
open Service.FileUpload
open Persistence.Interfaces
open mediator.Types
open mediator.Functions

[<Route("api/audio-file-upload")>]
type AudioFileUploadController(fileStorageDAO : IFileStorageDAO) = 
  inherit Controller()

    // POST api/audio-file-upload
    [<HttpPost>]
    member this.Post([<FromBody>] fileUpload : FileUploadModel) = async {
      let uploadFile = Mappings.FileUploadModelToUploadFile fileUpload

      let! result = fileStorageDAO.Insert uploadFile

      return this.Ok(result) :> IActionResult
    }
