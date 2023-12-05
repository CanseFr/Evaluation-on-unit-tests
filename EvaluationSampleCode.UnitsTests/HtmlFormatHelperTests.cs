namespace EvaluationSampleCode.UnitsTests
{
    [TestFixture]
    public class HtmlFormatHelperTests
    {
        private HtmlFormatHelper _htmlFormatHelper;

        [SetUp]
        public void SetUp()
        {
            _htmlFormatHelper = new HtmlFormatHelper();
        }

        [Test]
        [TestCase("test")]
        [TestCase("@@@")]
        [TestCase("111")]
        [TestCase("/:çEeè6")]
        public void GetBoldFormat_WhenCalled_WrapsContentInBoldTags(string a)
        {
            var result = _htmlFormatHelper.GetBoldFormat(a);
            Assert.AreEqual("<b>" +a+"</b>", result);
        }

        [Test]
        [TestCase("test")]
        [TestCase("@@@")]
        [TestCase("111")]
        [TestCase("/:çEeè6")]
        public void GetItalicFormat_WhenCalled_WrapsContentInItalicTags(string a)
        {
            var result = _htmlFormatHelper.GetItalicFormat(a);
            Assert.AreEqual("<i>"+a+"</i>", result);
        }

        [Test]
        public void GetFormattedListElements_WithNonEmptyList_ReturnsListInHtmlFormat()
        {
            var list = new List<string> { "item1", "item2" };
            var result = _htmlFormatHelper.GetFormattedListElements(list);
            var expectedHtml = "<ul><li>item1</li><li>item2</li></ul>";
            Assert.AreEqual(expectedHtml, result);
        }

        [Test]
        [TestCase("<ul></ul>")]
        public void GetFormattedListElements_WithEmptyList_ReturnsEmptyListInHtmlFormat(string a)
        {
            var list = new List<string>();
            var result = _htmlFormatHelper.GetFormattedListElements(list);
            var expectedHtml = "<ul></ul>";
            Assert.AreEqual(a, result);
        }

        [Test]
        public void GetFormattedListElement_WithNullList_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _htmlFormatHelper.GetFormattedListElements(null));
        }
    }
}
