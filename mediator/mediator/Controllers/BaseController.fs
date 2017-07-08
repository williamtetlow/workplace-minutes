namespace mediator.Controllers

open System
open mediator.Functions
open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Http
open Microsoft.Extensions.Logging

type BaseController(controllerName: string, loggerFactory : ILoggerFactory) =
  inherit Controller()
  member this.LoggerForAction = Logging.newTypeLogger loggerFactory controllerName