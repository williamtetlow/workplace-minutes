namespace mediator.Functions
open Domain.Operations.OperationResult
open Microsoft.Extensions.Logging

module Logging =

  let newTypeLogger (loggerFactory : ILoggerFactory) typeName funcName =
    let loggerName = typeName + "." + funcName
    loggerName |> loggerFactory.CreateLogger

  let logSuccess (logger : ILogger) format result =
    let log result = logger.LogInformation (format, [|result|])
    result
    |> callOnSuccess log

  let logFailure (logger : ILogger) result =
    let log result = logger.LogError ("Error: {0}", [| sprintf "%A" result|])
    result
    |> callOnFailure (Seq.iter log) 

