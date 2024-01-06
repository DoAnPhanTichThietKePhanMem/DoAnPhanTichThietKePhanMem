using System;
using System.Collections.Generic;

#nullable disable

namespace QLHS.DBContext
{
    public partial class TbClass
    {
        public TbClass()
        {
            TbStudents = new HashSet<TbStudent>();
        }

        public int Id { get; set; }
        public int? GroupId { get; set; }
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TbGroup Group { get; set; }
        public virtual ICollection<TbStudent> TbStudents { get; set; }
    }
}
