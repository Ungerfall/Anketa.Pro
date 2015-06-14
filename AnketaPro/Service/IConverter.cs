using System.Collections.Generic;
using AnketaPro.Model;

namespace AnketaPro.Service
{
    public interface IConverter
    {
        List<FormInfo> ToFormInfoList(Dictionary<string, List<object>> assocArray);
    }
}