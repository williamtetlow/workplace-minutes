namespace Domain.Types

open Domain.Operations
open Domain.Operations.OperationResult

type SourceSystemUser = { Username: string; SourceSystemId: string }

module SourceSystemUser =
  let create username sourceSystemId =
   { Username = username; SourceSystemId = sourceSystemId }

  let newUsername (username : string) =
    match username with
      | null -> fail NullProperty
      | _ -> success username

  let newSourceSystemId (id : string) =
    match id with
      | null -> fail NullProperty
      | _ -> success id