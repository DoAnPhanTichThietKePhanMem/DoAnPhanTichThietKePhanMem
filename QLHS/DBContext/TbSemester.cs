using System;
using System.Collections.Generic;

#nullable disable

namespace QLHS.DBContext
{
    public partial class TbSemester
    {
        public TbSemester()
        {
            TbTranScripts = new HashSet<TbTranScript>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ICollection<TbTranScript> TbTranScripts { get; set; }
    }
}
