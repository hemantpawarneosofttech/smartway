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
    
    public partial class ApplicationVetsionControl
    {
        public long ID { get; set; }
        public int AppID { get; set; }
        public string Enviroment { get; set; }
        public string MajorVer { get; set; }
        public string MinorVer { get; set; }
        public Nullable<System.DateTime> LastApproved { get; set; }
        public string LastKnownVer { get; set; }
    }
}