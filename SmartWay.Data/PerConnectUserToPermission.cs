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
    
    public partial class PerConnectUserToPermission
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public Nullable<int> PermissionId { get; set; }
        public Nullable<int> GroupId { get; set; }
        public bool Watching { get; set; }
        public bool Editing { get; set; }
    
        public virtual PerGroup PerGroup { get; set; }
        public virtual Permission Permission { get; set; }
        public virtual PerUser PerUser { get; set; }
    }
}