namespace Service.FileUpload

open System

module FileUploader =
  type FileUploadResult = { Success : bool; ErrorMessage : string option }
  let uploadFile (file : File) =
    let createErrorMessageForFile (file : File) =
      let wrongFormat = "File is not recognised audio format."
      let emptyFile = "File is empty."

      let msg = 
        match (file.IsAudioFile, file.IsNotEmpty) with
          | (false, false) -> Some(wrongFormat + emptyFile)
          | (false, true) -> Some(wrongFormat)
          | (true, false) -> Some(emptyFile)
          | _ -> None
      { Success = false; ErrorMessage = msg }

    let uploadResult =
      let uploadToStorage file =

        { Success = true; ErrorMessage = None }

      match file.AbleToUpload with
        | true -> uploadToStorage file
        | false -> createErrorMessageForFile file

    uploadResult

