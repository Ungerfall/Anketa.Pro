using AnketaPro.Model;

namespace AnketaPro.Service
{
    public interface IGradeRecordService
    {
        GradeRecord Load(string filepath);

        bool Save(GradeRecord gradeRecord, string filename);
    }
}