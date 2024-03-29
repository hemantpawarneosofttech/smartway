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
    
    public partial class ItemLog
    {
        public long ID { get; set; }
        public long ItemID { get; set; }
        public long MetaItemID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public bool Active { get; set; }
        public Nullable<long> Parent { get; set; }
        public int RelativeLocation { get; set; }
        public string Name { get; set; }
        public string IPAddress { get; set; }
        public string Description { get; set; }
        public string BiosName { get; set; }
        public bool Publish { get; set; }
        public string Owner { get; set; }
        public Nullable<long> RackID { get; set; }
        public Nullable<int> RoomID { get; set; }
        public int StatusID { get; set; }
        public Nullable<System.DateTime> LogTimeStamp { get; set; }
        public string Action { get; set; }
        public Nullable<System.DateTime> InsertTimeStamp { get; set; }
        public Nullable<System.DateTime> InstallTimeStamp { get; set; }
        public Nullable<System.DateTime> WarrentyStartDate { get; set; }
        public Nullable<System.DateTime> WarrentyEndDate { get; set; }
        public Nullable<System.DateTime> ContractStartDate { get; set; }
        public Nullable<System.DateTime> ContractEndDate { get; set; }
        public string AssertNumber { get; set; }
        public string UserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserGUID { get; set; }
        public Nullable<int> EnvironmentId { get; set; }
        public string Instruction { get; set; }
        public Nullable<int> ClusterID { get; set; }
        public Nullable<int> MemberID { get; set; }
        public Nullable<bool> Manual { get; set; }
        public Nullable<bool> Monitoring { get; set; }
        public Nullable<bool> Billable { get; set; }
        public Nullable<int> TotalPowerWallt { get; set; }
        public Nullable<int> TotalPowerVA { get; set; }
        public Nullable<int> DomainID { get; set; }
        public string SysUserId { get; set; }
        public string SerailNumber { get; set; }
        public Nullable<System.DateTime> InformationsecurityLastUpdate { get; set; }
        public string WorkflowID { get; set; }
        public string PurchaseOrderNumber { get; set; }
        public Nullable<bool> IsExistInDR { get; set; }
        public Nullable<bool> RequiredInDR { get; set; }
        public string DownTimeConflictReason { get; set; }
        public Nullable<int> DownTimeID { get; set; }
        public Nullable<int> FileLevelBackup { get; set; }
        public string TDPBackup { get; set; }
        public string SystemName { get; set; }
        public Nullable<bool> RearLocation { get; set; }
        public string SystemUserName { get; set; }
        public Nullable<bool> Siem { get; set; }
        public Nullable<bool> Pci { get; set; }
        public Nullable<bool> Sox { get; set; }
        public Nullable<bool> Sensitive { get; set; }
        public Nullable<bool> DataPrivilege { get; set; }
        public Nullable<int> RoundId { get; set; }
        public Nullable<int> DowntimeGroupID { get; set; }
        public Nullable<bool> IsApprovedSecurity { get; set; }
    }
}
