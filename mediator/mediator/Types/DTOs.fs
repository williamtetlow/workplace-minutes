namespace mediator.Types

open System
open System.IO
open Microsoft.AspNetCore.Http

[<AllowNullLiteralAttribute>]
type SourceSystemUserDTO() =
  member val Username : string = null with get, set
  member val SourceSystemId : string = null with get, set

[<AllowNullLiteralAttribute>]
type FileUploadDTO() =
  member val SourceSystemUser : SourceSystemUserDTO = null with get, set
  member val File : IFormFile = null with get, set
