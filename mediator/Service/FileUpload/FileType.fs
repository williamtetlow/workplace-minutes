namespace Service.FileUpload

open Microsoft.AspNetCore.Http


type File = { file : IFormFile } with
  member this.AbleToUpload =
      this.IsAudioFile && this.IsNotEmpty
  member this.IsAudioFile =
    let splitMime = this.file.ContentType.Split '/'
    splitMime.[0] = "audio"

  member this.IsNotEmpty =
    let fileLength = this.file.Length
    fileLength > int64 0