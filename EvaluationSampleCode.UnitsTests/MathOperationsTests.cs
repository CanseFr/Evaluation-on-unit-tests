namespace EvaluationSampleCode.UnitsTests
{
    [TestFixture]
    public class MathOperationsTests
    {
        private MathOperations _mathOperations;

        [SetUp]
        public void SetUp()
        {
            _mathOperations = new MathOperations();
        }

        [Test]
        [TestCase(1,2,3)]
        [TestCase(0,0,0)]
        [TestCase(-1,1,0)]
        [TestCase(13435,98438729,98452164)]
        [TestCase(-13435,-98438729,-98452164)]
        public void Add_WhenCall_ReturnSum(int a, int b , int c)
        {
            var result = _mathOperations.Add(a, b);
            Assert.AreEqual(c, result);
        }

        [Test]
        [TestCase(10,2,5.00)]
        [TestCase(5,2,2.50)]
        public void Divid_WithNonZeroDivisor_ReturnQuotient(int a, int b , double c)
        {
            var result = _mathOperations.Divide(a, b);
            Assert.AreEqual(c, result);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(10, 0)]
        [TestCase(100, 0)]
        [TestCase(1000, 0)]
        public void Divid_DivisorIsZero_ThrowArgumentException(int a, int b)
        {
            Assert.Throws<ArgumentException>(() => _mathOperations.Divide(a, b));
        }

        [Test]
        [TestCase(1, 3, 5)]
        public void GetOddNumbers_LimitIsPositive_ReturnsOddNumbersUpToLimit(int a, int b, int c)
        {
            var result = _mathOperations.GetOddNumbers(c);
            var expected = new[] { a, b, c };
            Assert.AreEqual(expected, result);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(-100)]
        public void GetOddNumbers_LimitIsNegative_ThrowsArgumentException(int a)
        {
            Assert.Throws<ArgumentException>(() => _mathOperations.GetOddNumbers(a));
        }

        [Test]
        [TestCase(0)]
        public void GetOddNumbers_LimitIsZero_ReturnsNoOddNumbers(int a)
        {
            var result = _mathOperations.GetOddNumbers(a).ToArray();
            Assert.AreEqual(a, result.Length);
        }
    }
}