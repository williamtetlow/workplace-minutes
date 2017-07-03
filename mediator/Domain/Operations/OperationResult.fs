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

  /// given a function wrapped in a result
  /// and a value wrapped in a result
  /// apply the function to the value only if both are Success
  let apply func result =
    match func, result with
      | Success (f, msgs1), Success (x, msgs2) ->
        (f x, msgs1@msgs2) |> Success
      | Failure errs, Success (_, msgs)
      | Success (_, msgs), Failure errs ->
        errs@msgs |> Failure
      | Failure errs1, Failure errs2 ->
        errs1@errs2 |> Failure

  /// infix version of apply
  let (<*>) =
    apply

  /// given a function that transforms a value
  /// apply it only if the result is on the Success branch
  let lift func result =
    let f' =  func |> success
    apply f' result
  
  let (<!>) =
    lift

  let switch func result = 
    func result |> success

  let switchAwait func result =
     Async.RunSynchronously (func result) |> success