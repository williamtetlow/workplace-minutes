namespace Domain.Types

open Domain.Operations.OperationResult

type SourceSystemUser = { Username: string; SourceSystemId: string }

module SourceSystemUser =
  let create username sourceSystemId =
   { Username = username; SourceSystemId = sourceSystemId }

  let createUsername (username : string) =
    success username