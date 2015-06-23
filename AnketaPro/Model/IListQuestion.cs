using System.Collections.Generic;

namespace AnketaPro.Model
{
    public interface IListQuestion
    {
        List<string> Variants { get; set; }
        List<string> Answers { get; set; } 
    }
}