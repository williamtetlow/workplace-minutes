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
open Domain.Operations
open Domain.Operations.OperationResult
open Microsoft.Extensions.Logging

[<Route("api/file-upload")>]
type FileUploadController(fileStorageDAO : IFileStorageDAO, loggerFactory : ILoggerFactory) = 
  inherit Controller()
  let loggerName funcName = "FileUploadController." + funcName
  let logger funcName = funcName |> loggerName |> loggerFactory.CreateLogger

    // POST api/audio-file-upload
  [<HttpPost>]
  member this.Post([<FromBody>] fileUpload : FileUploadDTO) =
    async {
      let result =
        success fileUpload
        >>= Mappings.FileUploadDTOToUploadFile
        >>= switchAwait fileStorageDAO.Insert

      return this.Ok(result) :> IActionResult
      
    } |> Async.StartAsTask

  [<HttpGet>]
  member this.Get() = 
    async {
      let logger = logger "Get"
      logger.LogDebug "In get method" |> ignore
      // let user = SourceSystemUser.create "Willie" "1"
      // use stream = File.OpenRead "/Users/william/Documents/Homework/workplace-minutes/mediator/mediator/TestFiles/Rick and Morty Season 3 Trai.textClipping"

      // let uploadFile =
      //   UploadFile.create "test1" (AudioFile FileType.AudioFileType.create) user stream

      // let! result = fileStorageDAO.Insert uploadFile
      
      return this.Ok("Yes") :> IActionResult
    } |> Async.StartAsTask
