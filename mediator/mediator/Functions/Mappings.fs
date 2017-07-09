namespace mediator.Functions

open System
open Microsoft.AspNetCore.Http
open mediator.Types
open Domain.Types
open Domain.Operations
open Domain.Operations.OperationResult

module Mappings =
  let private nullCheck dto =
    match dto with
      | null -> success dto
      | _ -> fail FileUploadDTOIsNull

  let SourceSystemUserDTOToSourceSystemUser (dto : SourceSystemUserDTO) =
    let mapToDomain (dto : SourceSystemUserDTO) =
      let username =
        SourceSystemUser.newUsername dto.Username
      let sourceSystemId =
        SourceSystemUser.newSourceSystemId dto.SourceSystemId
      
      SourceSystemUser.create
        <!> username
        <*> sourceSystemId

    dto
    |> nullCheck
    >>= mapToDomain 

  let FileUploadDTOToUploadFile (dto : FileUploadDTO) =
    let mapToDomain (dto : FileUploadDTO) =
      let filename =
        UploadFile.newFilename dto.File.FileName
      let fileType =
        FileType.create dto.File.ContentType
      let sourceSystemUser =
        SourceSystemUserDTOToSourceSystemUser dto.SourceSystemUser
      let fileStream =
        use stream = dto.File.OpenReadStream()
        success stream
      
      UploadFile.create
        <!> filename
        <*> fileType
        <*> sourceSystemUser
        <*> fileStream

    dto
    |> nullCheck
    >>= mapToDomain
