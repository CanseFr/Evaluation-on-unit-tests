namespace EvaluationSampleCode;

public class NeedMorePoints
{
    public interface IEvaluationService
    {
        int AddBonusPoints(int currentScore, int bonusPoints);
    }

    public class EvaluationProcessor
    {
        private readonly IEvaluationService _evaluationService;

        public EvaluationProcessor(IEvaluationService evaluationService)
        {
            _evaluationService = evaluationService;
        }

        public int ProcessEvaluation(int currentScore, int bonusPoints)
        {
            return _evaluationService.AddBonusPoints(currentScore, bonusPoints);
        }
    }
}