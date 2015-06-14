using System;
using System.Collections.Generic;

namespace AnketaPro.Model
{
    public class GradeRecord
    {
        public int? GradeRecordNumber { get; set; }

        public string Subject { get; set; }

        public string Group { get; set; }

        public string Examiner { get; set; }

        public DateTime? DateTime { get; set; }

        public List<GradeRecordStudent> Students { get; set; } 
    }
}