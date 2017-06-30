namespace mediator.Types

open System
open System.IO
open Microsoft.AspNetCore.Http

type FileUploadModel = { SourceSystemUser: string; File: IFormFile }
