//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartWay.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class PermissionsPage
    {
        public int id { get; set; }
        public int PermissionModelID { get; set; }
        public int PageID { get; set; }
        public string PageName { get; set; }
        public bool Write { get; set; }
        public bool Delete { get; set; }
        public bool Update { get; set; }
    
        public virtual PermissionsModule PermissionsModule { get; set; }
    }
}
