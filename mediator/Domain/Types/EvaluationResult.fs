namespace Domain.Types

open Domain.Types

type EvaluationResult = { EvalutionProcess: EvaluationProcess }

module EvaluationResult =
  let create x =
    x + 1