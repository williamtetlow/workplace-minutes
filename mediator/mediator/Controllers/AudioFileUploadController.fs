namespace mediator.Controllers

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open System.IO
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Http
open Service.Helpers

[<Route("api/audio-file-upload")>]
type AudioFileUploadController() = 
  inherit Controller()

    // POST api/audio-file-upload
    [<HttpPost>]
    member this.Post([<FromBody>] file : IFormFile) =
      let fileType = { Mime = file.ContentType }
      
      0
