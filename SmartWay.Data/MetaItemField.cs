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
    
    public partial class MetaItemField
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MetaItemField()
        {
            this.ItemExtendedMetaFields = new HashSet<ItemExtendedMetaField>();
        }
    
        public long ID { get; set; }
        public long MetaItemID { get; set; }
        public string FieldName { get; set; }
        public int FieldType { get; set; }
        public Nullable<int> ListID { get; set; }
        public bool Mandatory { get; set; }
        public string DefaultValue { get; set; }
    
        public virtual FieldDataType FieldDataType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemExtendedMetaField> ItemExtendedMetaFields { get; set; }
        public virtual List List { get; set; }
    }
}
