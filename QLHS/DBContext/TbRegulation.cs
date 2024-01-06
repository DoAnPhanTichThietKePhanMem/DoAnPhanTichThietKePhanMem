using System;
using System.Collections.Generic;

#nullable disable

namespace QLHS.DBContext
{
    public partial class TbRegulation
    {
        public int Id { get; set; }
        public int? MinAge { get; set; }
        public int? MaxAge { get; set; }
        public int? MaxQuantity { get; set; }
        public int? ClassQuantity { get; set; }
        public int? SubjectQuantity { get; set; }
        public double? PassingGrade { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
