using System;
using System.Collections.Generic;

#nullable disable

namespace QLHS.DBContext
{
    public partial class TbTranScript
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public int? SemesterId { get; set; }
        public int? SubjectId { get; set; }
        public double? Grade15 { get; set; }
        public double? Grade45 { get; set; }
        public double? GradeSemester { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TbSemester Semester { get; set; }
        public virtual TbStudent Student { get; set; }
        public virtual TbSubject Subject { get; set; }
    }
}
