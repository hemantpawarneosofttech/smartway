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
    
    public partial class ProfileLocation
    {
        public int Id { get; set; }
        public Nullable<long> ProfileId { get; set; }
        public Nullable<bool> IsDr { get; set; }
        public string Location { get; set; }
        public string Remark { get; set; }
    
        public virtual Profile Profile { get; set; }
    }
}
