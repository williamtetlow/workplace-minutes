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
open mediator.Functions.Common
open Domain.Types
open Domain.Operations
open Domain.Operations.OperationResult
open Microsoft.Extensions.Logging

[<Route("api/file-upload")>]
type FileUploadController(fileStorageDAO : IFileStorageDAO, loggerFactory : ILoggerFactory) = 
  inherit BaseController("FileUploadController", loggerFactory)
    // POST api/audio-file-upload
  [<HttpPost>]
  member this.Post([<FromBody>] fileUpload : FileUploadDTO) =
    async {
      let logger = this.LoggerForAction "Post"

      return
        success fileUpload
        |> Logging.logSuccess logger "POST received {0}"
        >>= Mappings.FileUploadDTOToUploadFile
        >>= switchAwait fileStorageDAO.Insert
        |> Logging.logFailure logger
        |> OKOnSuccess
        |> MapToHttpResponse
    
    } |> Async.StartAsTask
