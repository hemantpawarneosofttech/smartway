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
    
    public partial class PublishQueue
    {
        public long ID { get; set; }
        public int RoomID { get; set; }
        public Nullable<System.DateTime> PublishedAt { get; set; }
        public byte PublishStatusID { get; set; }
        public System.DateTime RequestTime { get; set; }
        public Nullable<int> RowNumber { get; set; }
    
        public virtual PublishStatu PublishStatu { get; set; }
    }
}
