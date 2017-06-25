namespace mediator.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open System.IO
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Http
open Service.FileUpload

[<Route("api/audio-file-upload")>]
type AudioFileUploadController() = 
  inherit Controller()

    // POST api/audio-file-upload
    [<HttpPost>]
    member this.Post([<FromBody>] file : IFormFile) =
      let uploadFileAsync (fileToUpload : IFormFile) path =
        fileToUpload.CopyToAsync(path)

      let fileType = { file = file }

      let shouldProceedWithUpload = 
        fileType.IsAudioFile && file.Length > int64 0

      let operation = 
        match shouldProceedWithUpload with
          | true -> Some(uploadFileAsync file)
          | false -> None
      0
