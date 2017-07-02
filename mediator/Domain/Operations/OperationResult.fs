namespace Domain.Operations

type OperationResult<'TSuccess, 'TMessage> =
  | Success of 'TSuccess * 'TMessage list
  | Failure of 'TMessage list

module OperationResult =
  let success result =
    Success (result, [])

  let successWithMessage result msg =
    Success (result, [msg])

  let fail msg =
    Failure [msg]
  
  let either successFunc failureFunc =
    function
      | Success (s, msgs) -> successFunc (s, msgs)
      | Failure errors -> failureFunc errors

  let mergeMessages msgs result =
    let successFunc (x,msgs2) = 
        Success (x, msgs @ msgs2) 
    let failureFunc errs = 
        Failure (errs @ msgs) 
    either successFunc failureFunc result

  let bind switchFunc  =
    function
    | Success (s, msgs) -> switchFunc s |> mergeMessages msgs
    | Failure f -> Failure f

  let (>>=) input switchFunc = 
    bind switchFunc input

  
