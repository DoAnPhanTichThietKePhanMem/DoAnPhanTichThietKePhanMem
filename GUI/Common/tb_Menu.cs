//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GUI.Common
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> RoleID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
    
        public virtual tb_Roles tb_Roles { get; set; }
    }
}