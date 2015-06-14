using AnketaPro.Service;

namespace AnketaPro.Model
{
    public class Student
    {
        [DbColumn("StudentFirstName")]
        public string FirstName { get; set; }

        [DbColumn("StudentMiddleName")]
        public string MiddleName { get; set; }

        [DbColumn("StudentSecondName")]
        public string SecondName { get; set; }

        [DbColumn("StudentRecordBook")]
        public int RecordBookNumber { get; set; }
    }
}