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
open Domain.Types

[<Route("api/file-upload")>]
type FileUploadController(fileStorageDAO : IFileStorageDAO) = 
  inherit Controller()

    // POST api/audio-file-upload
    [<HttpPost>]
    member this.Post([<FromBody>] fileUpload : FileUploadDTO) = async {
      let uploadFile = Mappings.FileUploadDTOToUploadFile fileUpload

      let! result = fileStorageDAO.Insert uploadFile

      return this.Ok(result) :> IActionResult
    }

    [<HttpGet>]
    member this.Get() = async {
      let user = SourceSystemUser.create "Willie" "1"
      use stream = File.OpenRead "/Users/william/Documents/Homework/workplace-minutes/mediator/mediator/TestFiles/Rick and Morty Season 3 Trai.textClipping"

      let uploadFile =
        UploadFile.create "test1" (AudioFile FileType.AudioFileType.create) user stream

      let! result = fileStorageDAO.Insert uploadFile
      
      return this.Ok(result) :> IActionResult
    }
