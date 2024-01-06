namespace QLHS.ViewModel
{
    public class GetInfoStudentsOfClassRequest
    {
        public int ClassID { get; set; }
        public string StudentNameSearch { get; set; }
    }

    public class CheckQuantityStudentOfclassRequest
    {
        public int ClassID { get; set; }
        public int QuantityStudentsAddToClass { get; set; }
    }

    public class AddStudentIntoClassRequest
    {
        public int ClassID { get; set; }
        public int StudentID { get; set; }
    }

    public class UpdateInfoNameClassRequest
    {
        public int ClassID { get; set; }
        public string NewName { get; set; }
    }

    public class GradesVM
    {
        public int STT { get; set; }
        public int ID { get; set; }
        public int StudentID { get; set; }
        public string Name { get; set; }
        public int? SemesterID { get; set; }
        public string Semester { get; set; }
        public int? SubjectID { get; set; }
        public string SubjectName { get; set; }
        public double? Grade15 { get; set; }
        public double? Grade45 { get; set; }
        public double? GradeSemester { get; set; }
    }

    public class UpdateSubjectInfoRequest
    {
        public int SubjectID { get; set; }
        public string NewName { get; set; }
    }
    public class ReportVM
    {
        public int STT { get; set; }
        public int? ClassID { get; set; }
        public string ClassName { get; set; }
        public int? SiSo { get; set; }
        public int SoLuongDat { get; set; }
        public double TiLeDat { get; set; }
    }
}
