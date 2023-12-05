namespace EvaluationSampleCode.UnitsTests
{
    [TestFixture]
    public class CustomStackTests
    {
        private CustomStack _customStack;

        [SetUp]
        public void SetUp()
        {
            _customStack = new CustomStack();
        }

        [Test]
        [TestCase(1)]
        public void Push_WhenCalled_AddsValueToStack(int value)
        {
            _customStack.Push(value);
            Assert.AreEqual(value, _customStack.Count());
        }

        [Test]
        public void Count_WhenStackIsEmpty_ReturnsZero()
        {
            Assert.AreEqual(0, _customStack.Count());
        }

        [Test]
        public void Pop_WhenStackIsNotEmpty_ReturnLastValueAndRemoveIt()
        {
            _customStack.Push(1);
            _customStack.Push(2);
            
            var result = _customStack.Pop();

            Assert.AreEqual(2, result);
            Assert.AreEqual(1, _customStack.Count());
        }

        [Test]
        public void Pop_WhenStackEmpty_ThrowStackCantBeEmptyException()
        {
            Assert.Throws<CustomStack.StackCantBeEmptyException>(() => _customStack.Pop());
        }
    }
}