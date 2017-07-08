namespace mediator.Functions

open System
open System.Collections.Generic
open System.Linq
open System.Threading.Tasks
open System.IO
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Http
open Domain.Operations
open Domain.Operations.OperationResult

module Common =
  let OK content =
    if content = box () then
      OkResult() :> IActionResult
    else
      ObjectResult(content) :> IActionResult
  
  let OKOnSuccess content =
    lift OK content

  type ResponseMessage = 
    | BadRequest of string 
    | InternalServerError of string 
    | DomainEvent of Message 
  
  let private classifyMsg msg  =
    match msg with
      | NullProperty
      | FileUploadDTOIsNull
      | InvalidFileType
        -> BadRequest (msg |> Message.ToString)
      | FileUploaded
        -> DomainEvent msg
      | FileUploadFail
        -> InternalServerError (msg |> Message.ToString)
  
  let private primaryResponse msgs =
    msgs
    |> List.map classifyMsg
    |> List.min

  let private mapToHttpResponse msgs : IActionResult =
    match (msgs |> primaryResponse) with
      | BadRequest msg 
      | InternalServerError msg
        -> upcast BadRequestObjectResult(msg)
      | DomainEvent msg
        -> upcast ObjectResult(msg)

  let MapToHttpResponse result =
    result |> valueOrDefault mapToHttpResponse