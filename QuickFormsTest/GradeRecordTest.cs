using AnketaPro.Service;
using NUnit.Framework;

namespace QuickFormsTest
{
    public class GradeRecordTest : TestBase
    {
        protected override void Setup()
        {
        }

        [Test]
        public void LoadTest()
        {
            using (var service = new GradeRecordService())
            {
                var gradeRecord = service.Load("D:\\ved_ses.xls");
            }
        }
    }
}