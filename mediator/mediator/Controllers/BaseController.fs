namespace mediator.Controllers

open System
open Microsoft.Extensions.Logging

type BaseController(loggerFactory : ILoggerFactory) =
  let t = 1