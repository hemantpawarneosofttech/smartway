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
    
    public partial class ItemExtendedMetaField
    {
        public long ID { get; set; }
        public long ItemID { get; set; }
        public long FieldID { get; set; }
        public string FieldValue { get; set; }
    
        public virtual Item Item { get; set; }
        public virtual MetaItemField MetaItemField { get; set; }
    }
}
