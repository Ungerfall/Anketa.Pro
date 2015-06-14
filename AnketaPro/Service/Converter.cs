using System.Collections.Generic;
using AnketaPro.Model;

namespace AnketaPro.Service
{
    public class Converter : IConverter
    {
        public List<FormInfo> ToFormInfoList(Dictionary<string, List<object>> assocArray)
        {
            var formInfoList = new List<FormInfo>();
            return formInfoList;
        }
    }
}