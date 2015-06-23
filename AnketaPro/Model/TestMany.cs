using System.Collections.Generic;

namespace AnketaPro.Model
{
    public class TestMany : QuestionBase
    {
        public List<string> Variants { get; set; }

        public List<int> AnswerIndexes { get; set; }
    }
}