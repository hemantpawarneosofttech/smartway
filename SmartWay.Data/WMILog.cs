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
    
    public partial class WMILog
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> timeStamp { get; set; }
        public Nullable<System.TimeSpan> MessageTime { get; set; }
        public string MessageDescription { get; set; }
        public string MessageType { get; set; }
        public string MessageCause { get; set; }
    }
}
