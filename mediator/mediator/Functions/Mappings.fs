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
      let username = fun dto -> dto.Username
      let sourceSystemId = fun dto -> dto.SourceSystemId
      SourceSystemUser.create sourceSystemUserModel.Username sourceSystemUserModel.SourceSystemId
    dto
    |> nullCheck
    >>= 
    //  

  let FileUploadDTOToUploadFile (fileUploadModel : FileUploadDTO) =
    let mapToDomain (dto : FileUploadDTO) =
      let filename = dto.File.FileName
      let fileType = { ContentType = dto.File.ContentType }
      let sourceSystemUser = SourceSystemUserDTOToSourceSystemUser dto.SourceSystemUser



    let canContinue dto =
      dto
      |> nullCheck
      >>= Validate.FileUploadDTO
    
    let { SourceSystemUser = sourceSystemUserDTO; File = file } = fileUploadModel
    let filename (file : IFormFile) = file.FileName
    let fileType (file: IFormFile) = AudioFile FileType.AudioFileType.create
    let sourceSystemUser sourceSystemUserDTO = 
       sourceSystemUserDTO
    use stream = file.OpenReadStream()

    UploadFile.create
      (file |> filename)
      (file |> fileType)
      (sourceSystemUserDTO |> sourceSystemUser)
      stream

