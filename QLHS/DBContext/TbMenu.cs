using System;
using System.Collections.Generic;

#nullable disable

namespace QLHS.DBContext
{
    public partial class TbMenu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? RoleId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public byte? IsDeleted { get; set; }
    }
}
