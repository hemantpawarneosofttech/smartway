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
    
    public partial class ProfileJobFunction
    {
        public int ProfileFunctionID { get; set; }
        public long ProfileID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int JobFunctionId { get; set; }
        public string USERGUID { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public string SmsNumber { get; set; }
    
        public virtual JobFunction JobFunction { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
