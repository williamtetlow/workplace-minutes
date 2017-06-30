namespace mediator.Functions

open System
open mediator.Types
open Domain.Types

module Mappings =
  let FileUploadModelToUploadFile (fileUploadModel : FileUploadModel) =
    let { SourceSystemUser = sourceSystemUser; File = file } = fileUploadModel
    
    let fileName = file.FileName
    let contentType = AudioFile FileType.AudioFileType.create
    use stream = file.OpenReadStream()
    UploadFile.create fileName contentType sourceSystemUser
