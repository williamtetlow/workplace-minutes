namespace mediator.Types

open System
open System.IO
open Microsoft.AspNetCore.Http

type SourceSystemUserDTO = { Username: string; SourceSystemId: string }
type FileUploadDTO = { SourceSystemUser: SourceSystemUserDTO; File: IFormFile }
