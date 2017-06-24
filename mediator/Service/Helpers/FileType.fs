namespace Service.Helpers

type FileType = { Mime : string } with
  member this.IsAudioFile =
    let splitMime = this.Mime.Split '/'
    splitMime.[0] = "audio"