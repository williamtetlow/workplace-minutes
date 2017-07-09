namespace mediator.Controllers

open System
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Logging
open mediator.Functions
open mediator.Functions.Common
open Domain.Operations
open Domain.Operations.OperationResult

type BaseController(controllerName: string, loggerFactory : ILoggerFactory) =
  inherit Controller()
  member this.LoggerForAction = Logging.newTypeLogger loggerFactory controllerName

  member this.PerformOperation logger operation result =
    result
    |> Logging.logSuccess logger "Received request {0}"
    |> operation
    |> Logging.logFailure logger
    |> OKOnSuccess
    |> MapMessagesToHttpResponse