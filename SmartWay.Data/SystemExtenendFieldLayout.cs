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
    
    public partial class SystemExtenendFieldLayout
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SystemExtenendFieldLayout()
        {
            this.SystemSectionExtendedFields = new HashSet<SystemSectionExtendedField>();
        }
    
        public int SystemExtenendFieldLayoutID { get; set; }
        public string SystemExtenendFieldLayoutDesc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SystemSectionExtendedField> SystemSectionExtendedFields { get; set; }
    }
}