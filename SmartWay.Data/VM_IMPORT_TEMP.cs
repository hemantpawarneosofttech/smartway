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
    
    public partial class VM_IMPORT_TEMP
    {
        public int ID { get; set; }
        public int DATACENTER_ID { get; set; }
        public string FILE_NAME { get; set; }
        public string LOCAL_FILE_NAME { get; set; }
        public int POWER_STATE { get; set; }
        public int DISABLED_SNAPSHOT { get; set; }
        public decimal FAILED_DMOTION { get; set; }
        public string UUID_BIOS { get; set; }
        public Nullable<int> RESOURCE_GROUP_ID { get; set; }
        public string GUEST_OS { get; set; }
        public string GUEST_FAMILY { get; set; }
        public string GUEST_STATE { get; set; }
        public Nullable<int> MEM_SIZE_MB { get; set; }
        public Nullable<int> MEMORY_RESERVATION { get; set; }
        public Nullable<int> CPU_RESERVATION { get; set; }
        public Nullable<int> NUM_VCPU { get; set; }
        public Nullable<int> NUM_NIC { get; set; }
        public Nullable<int> NUM_DISK { get; set; }
        public string DNS_NAME { get; set; }
        public int IS_TEMPLATE { get; set; }
        public int HOST_ID { get; set; }
        public string IP_ADDRESS { get; set; }
        public Nullable<int> TOOLS_STATUS { get; set; }
        public string TOOLS_VERSION_STATUS { get; set; }
        public string TOOLS_RUNNING_STATUS { get; set; }
        public string TOOLS_VERSION { get; set; }
        public Nullable<decimal> GUEST_OPS_READY { get; set; }
        public Nullable<decimal> INT_GUEST_OPS_READY { get; set; }
        public Nullable<int> SCREEN_WIDTH { get; set; }
        public Nullable<int> SCREEN_HEIGHT { get; set; }
        public int AGENT_ID { get; set; }
        public int AGENT_CNX_STATE { get; set; }
        public string CONFIG { get; set; }
        public string CAPABILITY { get; set; }
        public Nullable<System.DateTime> SUSPEND_TIME { get; set; }
        public Nullable<System.DateTime> BOOT_TIME { get; set; }
        public string SUSPEND_INTERVAL { get; set; }
        public string QUESTION_INFO { get; set; }
        public string MEMORY_OVERHEAD { get; set; }
        public Nullable<int> TOOLS_MOUNTED { get; set; }
        public Nullable<int> MKS_CONNECTIONS { get; set; }
        public decimal ONLINE_STANDBY { get; set; }
        public string DESCRIPTION { get; set; }
        public string ANNOTATION { get; set; }
        public string PENDING_NAME { get; set; }
        public string PENDING_ANNOTATION { get; set; }
        public decimal PENDING_ANNOT_SET_FLG { get; set; }
        public string FILE_LAYOUT { get; set; }
        public string FILE_LAYOUT_X { get; set; }
        public string UUID_INSTANCE { get; set; }
        public string VAPP_CONFIG { get; set; }
        public Nullable<decimal> AGGR_COMMITED_STORAGE_SPACE { get; set; }
        public Nullable<decimal> AGGR_UNCOMMITED_STORAGE_SPACE { get; set; }
        public Nullable<decimal> AGGR_UNSHARED_STORAGE_SPACE { get; set; }
        public Nullable<System.DateTime> STORAGE_SPACE_UPDATED_TIME { get; set; }
        public Nullable<int> FAULT_TOLERANCE_STATE { get; set; }
        public Nullable<int> RECORD_REPLAY_STATE { get; set; }
        public string DEV_RUNTIME { get; set; }
        public string GUEST_IP_STACK { get; set; }
        public string MANAGED_BY_EXT_KEY { get; set; }
        public string MANAGED_BY_TYPE { get; set; }
        public Nullable<int> ESX_AGENT_VM_STATE { get; set; }
        public Nullable<int> DAS_PROTECTED_DESIRED { get; set; }
        public Nullable<int> DAS_PROTECTED_ACTUAL { get; set; }
        public decimal IS_CONSOLIDATE_NEEDED { get; set; }
    }
}
