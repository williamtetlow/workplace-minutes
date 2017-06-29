namespace Domain.Types

type SourceSystemUser = { Username: string; SourceSystemId: string }

module SourceSystemUser =
  let create userName sourceSystemId =
   { Username = userName; SourceSystemId = sourceSystemId }