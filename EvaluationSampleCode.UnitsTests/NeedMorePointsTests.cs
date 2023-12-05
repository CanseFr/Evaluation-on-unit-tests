using Moq;
using NUnit.Framework;
using EvaluationSampleCode;

namespace EvaluationSampleCode.Tests
{
    [TestFixture]
    public class EvaluationProcessorTests
    {
        private Mock<NeedMorePoints.IEvaluationService> _evaluationServiceMock;
        private NeedMorePoints.EvaluationProcessor _evaluationProcessor;

        [SetUp]
        public void SetUp()
        {
            _evaluationServiceMock = new Mock<NeedMorePoints.IEvaluationService>();
            _evaluationProcessor = new NeedMorePoints.EvaluationProcessor(_evaluationServiceMock.Object);
        }

        [Test]
        public void ProcesEvaluation_WhenCall_ReturnUpdatScore()
        {
            var currentScore = 80;
            var bonusPoint = 2;
            var expectedScore = 82;
            _evaluationServiceMock.Setup(s => s.AddBonusPoints(currentScore, bonusPoint)).Returns(expectedScore);
            
            var result = _evaluationProcessor.ProcessEvaluation(currentScore, bonusPoint);

            Assert.AreEqual(expectedScore, result);
            _evaluationServiceMock.Verify(s => s.AddBonusPoints(currentScore, bonusPoint), Times.Once);
        }

        [Test]
        public void ProcesEvaluation_NegativBonusPoint_ThrowArgumentException()
        {
            var currentScore = 80;
            var bonusPoints = -2;
            _evaluationServiceMock.Setup(s => s.AddBonusPoints(It.IsAny<int>(), It.IsAny<int>()))
                                  .Throws<ArgumentException>();

            Assert.Throws<ArgumentException>(() => _evaluationProcessor.ProcessEvaluation(currentScore, bonusPoints));
        }

        [Test]
        public void ProcesEvaluation_VerifyCorrectParameterPasse()
        {
            var currentScore = 80;
            var bonusPoint = 5;
            _evaluationServiceMock.Setup(s => s.AddBonusPoints(It.IsAny<int>(), It.IsAny<int>())).Returns(85);

            _evaluationProcessor.ProcessEvaluation(currentScore, bonusPoint);

            _evaluationServiceMock.Verify(s => s.AddBonusPoints(currentScore, bonusPoint), Times.Once);
        }
    }
}
