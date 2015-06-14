using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using AnketaPro.Model;
using Microsoft.Office.Interop.Excel;

namespace AnketaPro.Service
{
    public class GradeRecordService : IGradeRecordService, IDisposable
    {
        private Application excel = new Application();
        private Workbook excellGradeRecord;
        private Worksheet worksheet;

        public GradeRecord Load(string filepath)
        {
            int number;
            DateTime date;
            var gradeRecord = new GradeRecord {Students = new List<GradeRecordStudent>()};
            excel.Visible = false;
            excellGradeRecord = excel.Workbooks.Open(filepath);
            worksheet = (Worksheet)excellGradeRecord.Sheets[1];
            var cell = GetCellValue(4, 2);

            if (Int32.TryParse(cell.Substring(cell.LastIndexOf('№') + 1), out number))
                gradeRecord.GradeRecordNumber = number;

            gradeRecord.Group = GetCellValue(5, 6).Substring(7);
            gradeRecord.Subject = GetCellValue(6, 2);
            cell = GetCellValue(7, 2);
            var dateLocation = cell.LastIndexOf("Дата:", StringComparison.Ordinal);
            gradeRecord.Examiner = cell.Substring(13, 50).Trim();
            if (DateTime.TryParseExact(cell.Substring(dateLocation + 5).Trim(), "dd.MM.yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                gradeRecord.DateTime = date;
            var rowIndex = 10;
            while (GetCellValue(rowIndex, 2) != string.Empty)
            {
                var row =
                    (Array) worksheet.Range[string.Format("B{0}", rowIndex), string.Format("D{0}", rowIndex)].Value;
                gradeRecord.Students.Add(new GradeRecordStudent
                {
                    Serial = int.Parse(row.GetValue(1, 1).ToString(), NumberStyles.Float),
                    Student = row.GetValue(1, 2).ToString(),
                    RecordBookNumber = int.Parse(row.GetValue(1, 3).ToString())
                });
                ++rowIndex;
            }
            
            return gradeRecord;
        }

        public bool Save(GradeRecord gradeRecord, string filename)
        {
            throw new NotImplementedException();
        }

        private string GetCellValue(int row, int column)
        {
            var cell = ((Range) worksheet.Cells[row, column]).Value;
            return cell == null ? string.Empty : cell.ToString().Trim();
        }

        public void Dispose()
        {
            excellGradeRecord.Close(0);
            excel.Quit();
            Marshal.ReleaseComObject(worksheet);
            Marshal.ReleaseComObject(excellGradeRecord);
            Marshal.ReleaseComObject(excel);
        }
    }
}