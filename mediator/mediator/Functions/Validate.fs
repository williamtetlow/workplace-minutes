namespace mediator.Functions

open System.IO
open Microsoft.AspNetCore.Http
open mediator.Types
open Domain.Operations
open Domain.Operations.OperationResult
open Domain.Types
open Domain.Types.UploadFile

module Validate =
  let FileUploadDTO (dto : FileUploadDTO) =
    let acceptedFileType ( dto : FileUploadDTO) =
      let acceptedType =
        { ContentType = dto.File.ContentType }
        |> AcceptedUploadFiles.test
      match acceptedType with
        | true -> success dto
        | false -> fail InvalidFileType
    
    dto |> acceptedFileType