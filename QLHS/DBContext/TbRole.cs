using System;
using System.Collections.Generic;

#nullable disable

namespace QLHS.DBContext
{
    public partial class TbRole
    {
        public TbRole()
        {
            TbUsers = new HashSet<TbUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public byte? IsDeleted { get; set; }

        public virtual ICollection<TbUser> TbUsers { get; set; }
    }
}
