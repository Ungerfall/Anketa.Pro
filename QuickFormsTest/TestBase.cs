using NUnit.Framework;

namespace QuickFormsTest
{
    public abstract class TestBase
    {
        protected abstract void Setup();

        [SetUp]
        public void SetUp()
        {
            Setup();
        }
    }
}