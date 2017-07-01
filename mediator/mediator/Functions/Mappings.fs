namespace mediator.Functions

open System
open Microsoft.AspNetCore.Http
open mediator.Types
open Domain.Types

module Mappings =

  let SourceSystemUserDTOToSourceSystemUser (sourceSystemUserModel : SourceSystemUserDTO) =
     SourceSystemUser.create sourceSystemUserModel.Username sourceSystemUserModel.SourceSystemId

  let FileUploadDTOToUploadFile (fileUploadModel : FileUploadDTO) =
    let { SourceSystemUser = sourceSystemUserDTO; File = file } = fileUploadModel
    let filename (file : IFormFile) = file.FileName
    let fileType (file: IFormFile) = AudioFile FileType.AudioFileType.create
    let sourceSystemUser sourceSystemUserDTO = 
      SourceSystemUserDTOToSourceSystemUser sourceSystemUserDTO
    use stream = file.OpenReadStream()

    UploadFile.create
      (file |> filename)
      (file |> fileType)
      (sourceSystemUserDTO |> sourceSystemUser)
      stream

