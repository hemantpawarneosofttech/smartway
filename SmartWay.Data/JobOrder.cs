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
    
    public partial class JobOrder
    {
        public int Id { get; set; }
        public Nullable<long> ItemId { get; set; }
        public int JobType { get; set; }
        public System.DateTime Date { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public Nullable<int> RoomId { get; set; }
        public Nullable<int> RackId { get; set; }
        public Nullable<int> UnitId { get; set; }
        public int MetaItemId { get; set; }
        public Nullable<bool> IsOpen { get; set; }
    
        public virtual Item Item { get; set; }
    }
}