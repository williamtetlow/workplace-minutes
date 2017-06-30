namespace mediator.Functions

open System
open mediator.Types
open Domain.Types

module Mappings =

  let SourceSystemUserModelToSourceSystemUser (sourceSystemUserModel : SourceSystemUserModel) =
    { Username = sourceSystemUserModel.Username; SourceSystemId = sourceSystemUserModel.SourceSystemId }

  let FileUploadModelToUploadFile (fileUploadModel : FileUploadModel) =
    let { SourceSystemUser = sourceSystemUserModel; File = file } = fileUploadModel
    let sourceSystemUser = SourceSystemUserModelToSourceSystemUser sourceSystemUserModel
    let fileName = file.FileName
    let contentType = AudioFile FileType.AudioFileType.create
    use stream = file.OpenReadStream()
    
    UploadFile.create fileName contentType sourceSystemUser stream
