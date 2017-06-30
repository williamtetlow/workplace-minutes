namespace mediator.Types

open System
open System.IO
open Microsoft.AspNetCore.Http

type SourceSystemUserModel = { Username: string; SourceSystemId: string }
type FileUploadModel = { SourceSystemUser: SourceSystemUserModel; File: IFormFile }
