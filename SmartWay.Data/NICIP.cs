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
    
    public partial class NICIP
    {
        public long ID { get; set; }
        public long ItemNICID { get; set; }
        public string IPAddress { get; set; }
        public Nullable<int> VLANID { get; set; }
    
        public virtual ItemNIC ItemNIC { get; set; }
    }
}