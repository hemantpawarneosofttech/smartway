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
    
    public partial class SoftwareInstalled
    {
        public int Id { get; set; }
        public Nullable<long> EquipmentId { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
        public string Manufacturar { get; set; }
        public Nullable<System.DateTime> DateOfInstal { get; set; }
        public string description { get; set; }
    }
}
