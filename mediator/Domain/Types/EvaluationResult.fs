namespace Domain.Types

open Domain.Types

type EvaluationResultType = { EvalutionProcess: EvaluationProcessType }

module EvaluationResult =
  let create x =
    x + 1