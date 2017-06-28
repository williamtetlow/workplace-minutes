namespace Domain.Types

type SourceSystemUserType = { Username: string; SourceSystemId: string }

module SourceSystemUser =
  let create userName sourceSystemId =
   { Username = userName; SourceSystemId = sourceSystemId }