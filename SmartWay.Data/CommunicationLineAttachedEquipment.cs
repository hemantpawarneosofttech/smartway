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
    
    public partial class CommunicationLineAttachedEquipment
    {
        public int AttachedEquipmentID { get; set; }
        public string AttachedEquipmentDesc { get; set; }
        public Nullable<int> AttachedEquipmentSupplyerID { get; set; }
        public Nullable<int> CommunicationLineID { get; set; }
        public string AttachedEquipmentPort { get; set; }
    
        public virtual CommunicationLinesupplier CommunicationLinesupplier { get; set; }
    }
}