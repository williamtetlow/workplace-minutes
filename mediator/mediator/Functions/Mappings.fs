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
    let filename = fun (file : IFormFile) -> file.FileName
    let fileType = fun (file: IFormFile) -> AudioFile FileType.AudioFileType.create
    use stream = file.OpenReadStream()

    UploadFile.create
      (file |> filename)
      (file |> fileType)
      (sourceSystemUserDTO |> SourceSystemUserDTOToSourceSystemUser)
      stream

