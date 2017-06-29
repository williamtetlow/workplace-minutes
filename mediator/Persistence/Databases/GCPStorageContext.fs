namespace Persistence.Databases

open Persistence.Types
open Domain.Types

type GCPStorageContext = { Configuration: GCPStorageDAOConfiguration }

module GCPStorageContext =
  let create configuration =
   { Configuration = configuration }

  let uploadAsync (context : GCPStorageContext) (file : UploadFile) =
    0