using System;
using System.Collections.Generic;

#nullable disable

namespace QLHS.DBContext
{
    public partial class TbStudent
    {
        public TbStudent()
        {
            TbTranScripts = new HashSet<TbTranScript>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int? ClassId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual TbClass Class { get; set; }
        public virtual ICollection<TbTranScript> TbTranScripts { get; set; }
    }
}
