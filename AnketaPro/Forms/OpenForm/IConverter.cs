using System.Collections.Generic;

namespace AnketaPro.Forms.OpenForm
{
    public interface IConverter
    {
        List<FormInfo> ToFormInfoList(Dictionary<string, List<object>> assocArray);
    }
}