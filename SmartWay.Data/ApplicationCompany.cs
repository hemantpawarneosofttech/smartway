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
    
    public partial class ApplicationCompany
    {
        public int ID { get; set; }
        public int SystemID { get; set; }
        public int CompanyID { get; set; }
    
        public virtual Company Company { get; set; }
        public virtual Application Application { get; set; }
    }
}