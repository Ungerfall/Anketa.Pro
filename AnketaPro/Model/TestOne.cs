using System.Collections.Generic;

namespace AnketaPro.Model
{
    public class TestOne : QuestionBase
    {
        public List<string> Variants { get; set; }

        public int AnswerIndex { get; set; }
    }
}