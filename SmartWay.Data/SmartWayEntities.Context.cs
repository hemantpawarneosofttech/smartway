﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class SmartWayEntities : DbContext
    {
        public SmartWayEntities()
            : base("name=SmartWayEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccessDetail> AccessDetails { get; set; }
        public virtual DbSet<ActionPaneCategoriesLink> ActionPaneCategoriesLinks { get; set; }
        public virtual DbSet<AppDocindex> AppDocindexes { get; set; }
        public virtual DbSet<AppErrorCode> AppErrorCodes { get; set; }
        public virtual DbSet<ApplicationAuditStatu> ApplicationAuditStatus { get; set; }
        public virtual DbSet<ApplicationCompany> ApplicationCompanies { get; set; }
        public virtual DbSet<ApplicationConnection> ApplicationConnections { get; set; }
        public virtual DbSet<ApplicationConnectionsTransmitType> ApplicationConnectionsTransmitTypes { get; set; }
        public virtual DbSet<ApplicationContactPerson> ApplicationContactPersons { get; set; }
        public virtual DbSet<ApplicationDocument> ApplicationDocuments { get; set; }
        public virtual DbSet<ApplicationInformation> ApplicationInformations { get; set; }
        public virtual DbSet<ApplicationInformationType> ApplicationInformationTypes { get; set; }
        public virtual DbSet<ApplicationInstraction> ApplicationInstractions { get; set; }
        public virtual DbSet<ApplicationJobFunction> ApplicationJobFunctions { get; set; }
        public virtual DbSet<ApplicationMaintenance> ApplicationMaintenances { get; set; }
        public virtual DbSet<ApplicationModule> ApplicationModules { get; set; }
        public virtual DbSet<ApplicationOperation> ApplicationOperations { get; set; }
        public virtual DbSet<ApplicationParamValue> ApplicationParamValues { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<ApplicationSection> ApplicationSections { get; set; }
        public virtual DbSet<ApplicationsSecurityStatu> ApplicationsSecurityStatus { get; set; }
        public virtual DbSet<ApplicationType> ApplicationTypes { get; set; }
        public virtual DbSet<ApplicationVetsionControl> ApplicationVetsionControls { get; set; }
        public virtual DbSet<AppVersion> AppVersions { get; set; }
        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<AthorMethod> AthorMethods { get; set; }
        public virtual DbSet<AthorMethorRight> AthorMethorRights { get; set; }
        public virtual DbSet<AthorPage> AthorPages { get; set; }
        public virtual DbSet<AthorPagesRight> AthorPagesRights { get; set; }
        public virtual DbSet<AutoTestMail> AutoTestMails { get; set; }
        public virtual DbSet<AutoTest> AutoTests { get; set; }
        public virtual DbSet<AutoTestServer> AutoTestServers { get; set; }
        public virtual DbSet<AutoTestSubSystem> AutoTestSubSystems { get; set; }
        public virtual DbSet<AutoTestTag> AutoTestTags { get; set; }
        public virtual DbSet<BackupAgent> BackupAgents { get; set; }
        public virtual DbSet<BackupType> BackupTypes { get; set; }
        public virtual DbSet<BdStatu> BdStatus { get; set; }
        public virtual DbSet<BigFix> BigFixes { get; set; }
        public virtual DbSet<BIkva> BIkvas { get; set; }
        public virtual DbSet<BizProcess> BizProcesses { get; set; }
        public virtual DbSet<BizProcessApplication> BizProcessApplications { get; set; }
        public virtual DbSet<BizProcessType> BizProcessTypes { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<CableColor> CableColors { get; set; }
        public virtual DbSet<CableItem> CableItems { get; set; }
        public virtual DbSet<CableLength> CableLengths { get; set; }
        public virtual DbSet<CableType> CableTypes { get; set; }
        public virtual DbSet<Captcha> Captchas { get; set; }
        public virtual DbSet<ChangesInfrastructure> ChangesInfrastructures { get; set; }
        public virtual DbSet<ChangesReport> ChangesReports { get; set; }
        public virtual DbSet<CheckListToItem> CheckListToItems { get; set; }
        public virtual DbSet<CheckListToSystem> CheckListToSystems { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<CloudHostingLocationForSystem> CloudHostingLocationForSystems { get; set; }
        public virtual DbSet<CloudInfoForSystem> CloudInfoForSystems { get; set; }
        public virtual DbSet<CloudProviderForSystem> CloudProviderForSystems { get; set; }
        public virtual DbSet<CloudRedundancyLevelForSystem> CloudRedundancyLevelForSystems { get; set; }
        public virtual DbSet<ClusterDBMember> ClusterDBMembers { get; set; }
        public virtual DbSet<ClusterItemMember> ClusterItemMembers { get; set; }
        public virtual DbSet<ClusterMethod> ClusterMethods { get; set; }
        public virtual DbSet<ClusterProtocol> ClusterProtocols { get; set; }
        public virtual DbSet<Cluster> Clusters { get; set; }
        public virtual DbSet<ClustersStatu> ClustersStatus { get; set; }
        public virtual DbSet<ClusterSystemMember> ClusterSystemMembers { get; set; }
        public virtual DbSet<ClusterType> ClusterTypes { get; set; }
        public virtual DbSet<ComboCatalog> ComboCatalogs { get; set; }
        public virtual DbSet<CommunicationLine> CommunicationLines { get; set; }
        public virtual DbSet<CommunicationLineAttachedEquipment> CommunicationLineAttachedEquipments { get; set; }
        public virtual DbSet<CommunicationLineBandwidth> CommunicationLineBandwidths { get; set; }
        public virtual DbSet<CommunicationLineCluster> CommunicationLineClusters { get; set; }
        public virtual DbSet<CommunicationLineContact> CommunicationLineContacts { get; set; }
        public virtual DbSet<CommunicationLineHop> CommunicationLineHops { get; set; }
        public virtual DbSet<CommunicationLineInfrastructureProvider> CommunicationLineInfrastructureProviders { get; set; }
        public virtual DbSet<CommunicationLineISP> CommunicationLineISPs { get; set; }
        public virtual DbSet<CommunicationLineKind> CommunicationLineKinds { get; set; }
        public virtual DbSet<CommunicationLineLink> CommunicationLineLinks { get; set; }
        public virtual DbSet<CommunicationLineNote> CommunicationLineNotes { get; set; }
        public virtual DbSet<CommunicationLineRealatedItem> CommunicationLineRealatedItems { get; set; }
        public virtual DbSet<CommunicationLineRealatedSystem> CommunicationLineRealatedSystems { get; set; }
        public virtual DbSet<CommunicationLinesupplier> CommunicationLinesuppliers { get; set; }
        public virtual DbSet<CommunicationLineType> CommunicationLineTypes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<ContactPerson> ContactPersons { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CriticalLevel> CriticalLevels { get; set; }
        public virtual DbSet<DatabaseInstance> DatabaseInstances { get; set; }
        public virtual DbSet<DatabaseJobFunction> DatabaseJobFunctions { get; set; }
        public virtual DbSet<DatabaseVersion> DatabaseVersions { get; set; }
        public virtual DbSet<DataType> DataTypes { get; set; }
        public virtual DbSet<DbClassification> DbClassifications { get; set; }
        public virtual DbSet<DBInstanceConnectedToSystem> DBInstanceConnectedToSystems { get; set; }
        public virtual DbSet<DBLocation> DBLocations { get; set; }
        public virtual DbSet<DBRemoteControl> DBRemoteControls { get; set; }
        public virtual DbSet<DbStatu> DbStatus { get; set; }
        public virtual DbSet<DbType> DbTypes { get; set; }
        public virtual DbSet<DCM2statistic> DCM2statistic { get; set; }
        public virtual DbSet<DEMO> DEMOes { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DiminutionRea> DiminutionReas { get; set; }
        public virtual DbSet<DocRepository> DocRepositories { get; set; }
        public virtual DbSet<DocType> DocTypes { get; set; }
        public virtual DbSet<Domain> Domains { get; set; }
        public virtual DbSet<DownTime> DownTimes { get; set; }
        public virtual DbSet<DownTimeConflictReason> DownTimeConflictReasons { get; set; }
        public virtual DbSet<DownTimeDay> DownTimeDays { get; set; }
        public virtual DbSet<DownTimeDuration> DownTimeDurations { get; set; }
        public virtual DbSet<DowntimeGroup> DowntimeGroups { get; set; }
        public virtual DbSet<DownTimeLog> DownTimeLogs { get; set; }
        public virtual DbSet<DownTimeMounth> DownTimeMounths { get; set; }
        public virtual DbSet<DownTimeMsgBox> DownTimeMsgBoxes { get; set; }
        public virtual DbSet<DownTimeWeek> DownTimeWeeks { get; set; }
        public virtual DbSet<DpItem> DpItems { get; set; }
        public virtual DbSet<DpItemHardware> DpItemHardwares { get; set; }
        public virtual DbSet<DR_EnumNoteSubject> DR_EnumNoteSubject { get; set; }
        public virtual DbSet<DR_EnumStatus> DR_EnumStatus { get; set; }
        public virtual DbSet<DRPChecker> DRPCheckers { get; set; }
        public virtual DbSet<DRPDocument> DRPDocuments { get; set; }
        public virtual DbSet<DRPEvent> DRPEvents { get; set; }
        public virtual DbSet<DRPLoadOrder> DRPLoadOrders { get; set; }
        public virtual DbSet<DRPPreparation> DRPPreparations { get; set; }
        public virtual DbSet<DRPPreparationType> DRPPreparationTypes { get; set; }
        public virtual DbSet<DRPRequiredSoftware> DRPRequiredSoftwares { get; set; }
        public virtual DbSet<ElectricalCircuite> ElectricalCircuites { get; set; }
        public virtual DbSet<ELMAH_Error> ELMAH_Error { get; set; }
        public virtual DbSet<Environment> Environments { get; set; }
        public virtual DbSet<EqiupmentServerRole> EqiupmentServerRoles { get; set; }
        public virtual DbSet<EquipmentJobFunction> EquipmentJobFunctions { get; set; }
        public virtual DbSet<EquipmentsNote> EquipmentsNotes { get; set; }
        public virtual DbSet<EtcToRackID> EtcToRackIDs { get; set; }
        public virtual DbSet<EtcToRoom> EtcToRooms { get; set; }
        public virtual DbSet<FieldDataType> FieldDataTypes { get; set; }
        public virtual DbSet<Floor> Floors { get; set; }
        public virtual DbSet<Frequency> Frequencies { get; set; }
        public virtual DbSet<From_TADDM_to_LANSWEEPER> From_TADDM_to_LANSWEEPER { get; set; }
        public virtual DbSet<ImporterLog> ImporterLogs { get; set; }
        public virtual DbSet<ImporterLogAction> ImporterLogActions { get; set; }
        public virtual DbSet<infoWebService> infoWebServices { get; set; }
        public virtual DbSet<IntelDcmConverter> IntelDcmConverters { get; set; }
        public virtual DbSet<IP> IPs { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemApplicationConnection> ItemApplicationConnections { get; set; }
        public virtual DbSet<ItemApplication> ItemApplications { get; set; }
        public virtual DbSet<ItemBackupDocument> ItemBackupDocuments { get; set; }
        public virtual DbSet<ItemCheckList> ItemCheckLists { get; set; }
        public virtual DbSet<ItemContactPerson> ItemContactPersons { get; set; }
        public virtual DbSet<ItemData> ItemDatas { get; set; }
        public virtual DbSet<ItemDeleteReason> ItemDeleteReasons { get; set; }
        public virtual DbSet<ItemDiminution> ItemDiminutions { get; set; }
        public virtual DbSet<ItemEnergy> ItemEnergies { get; set; }
        public virtual DbSet<ItemExtendedItemTypeField> ItemExtendedItemTypeFields { get; set; }
        public virtual DbSet<ItemExtendedMetaField> ItemExtendedMetaFields { get; set; }
        public virtual DbSet<ItemFileLink> ItemFileLinks { get; set; }
        public virtual DbSet<ItemInstraction> ItemInstractions { get; set; }
        public virtual DbSet<ItemLog> ItemLogs { get; set; }
        public virtual DbSet<ItemMetaData> ItemMetaDatas { get; set; }
        public virtual DbSet<ItemNIC> ItemNICs { get; set; }
        public virtual DbSet<ItemRole> ItemRoles { get; set; }
        public virtual DbSet<ItemRoleType> ItemRoleTypes { get; set; }
        public virtual DbSet<ItemServerRole> ItemServerRoles { get; set; }
        public virtual DbSet<ItemStatu> ItemStatus { get; set; }
        public virtual DbSet<ItemType> ItemTypes { get; set; }
        public virtual DbSet<ItemTypeField> ItemTypeFields { get; set; }
        public virtual DbSet<JobFunction> JobFunctions { get; set; }
        public virtual DbSet<JobFunctionToFix> JobFunctionToFixes { get; set; }
        public virtual DbSet<JobOrder> JobOrders { get; set; }
        public virtual DbSet<JobType> JobTypes { get; set; }
        public virtual DbSet<LastUserUpdate> LastUserUpdates { get; set; }
        public virtual DbSet<List> Lists { get; set; }
        public virtual DbSet<ListItem> ListItems { get; set; }
        public virtual DbSet<LOBALERT> LOBALERTS { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LogDcm2> LogDcm2 { get; set; }
        public virtual DbSet<LogDcmPlu> LogDcmPlus { get; set; }
        public virtual DbSet<LoginType> LoginTypes { get; set; }
        public virtual DbSet<MaintenanceCompany> MaintenanceCompanies { get; set; }
        public virtual DbSet<ManageTable> ManageTables { get; set; }
        public virtual DbSet<Manufacturer> Manufacturers { get; set; }
        public virtual DbSet<MeasureUnit> MeasureUnits { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuDcm2> MenuDcm2 { get; set; }
        public virtual DbSet<MenuForScript> MenuForScripts { get; set; }
        public virtual DbSet<MetaItem> MetaItems { get; set; }
        public virtual DbSet<MetaItemCrossReference> MetaItemCrossReferences { get; set; }
        public virtual DbSet<MetaItemExtendedField> MetaItemExtendedFields { get; set; }
        public virtual DbSet<MetaItemField> MetaItemFields { get; set; }
        public virtual DbSet<MND_SystemMovement> MND_SystemMovement { get; set; }
        public virtual DbSet<MNDCompny> MNDCompnies { get; set; }
        public virtual DbSet<MNDContactPerson> MNDContactPersons { get; set; }
        public virtual DbSet<MNDEvent> MNDEvents { get; set; }
        public virtual DbSet<MNDEventType> MNDEventTypes { get; set; }
        public virtual DbSet<MNDGroup> MNDGroups { get; set; }
        public virtual DbSet<MNDJobOwner> MNDJobOwners { get; set; }
        public virtual DbSet<MNDMovement> MNDMovements { get; set; }
        public virtual DbSet<MNDProgressStatu> MNDProgressStatus { get; set; }
        public virtual DbSet<MNDRiskBank> MNDRiskBanks { get; set; }
        public virtual DbSet<MNDShipment> MNDShipments { get; set; }
        public virtual DbSet<MNDShipmentsLog> MNDShipmentsLogs { get; set; }
        public virtual DbSet<MNDStatu> MNDStatus { get; set; }
        public virtual DbSet<MNDToDoList> MNDToDoLists { get; set; }
        public virtual DbSet<ModuleSystem> ModuleSystems { get; set; }
        public virtual DbSet<NCHeader> NCHeaders { get; set; }
        public virtual DbSet<NCItemSaveData> NCItemSaveDatas { get; set; }
        public virtual DbSet<NCMain> NCMains { get; set; }
        public virtual DbSet<NewLocation> NewLocations { get; set; }
        public virtual DbSet<NICIP> NICIPs { get; set; }
        public virtual DbSet<NICType> NICTypes { get; set; }
        public virtual DbSet<OrgTree> OrgTrees { get; set; }
        public virtual DbSet<PageHeader> PageHeaders { get; set; }
        public virtual DbSet<PerConnectUserToPermission> PerConnectUserToPermissions { get; set; }
        public virtual DbSet<PerGroup> PerGroups { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<PermissionsModule> PermissionsModules { get; set; }
        public virtual DbSet<PermissionsPage> PermissionsPages { get; set; }
        public virtual DbSet<PersonalizationDisplay> PersonalizationDisplays { get; set; }
        public virtual DbSet<PerUser> PerUsers { get; set; }
        public virtual DbSet<PhysicalInterface> PhysicalInterfaces { get; set; }
        public virtual DbSet<portalReport> portalReports { get; set; }
        public virtual DbSet<PortalSection> PortalSections { get; set; }
        public virtual DbSet<PortalWebPart> PortalWebParts { get; set; }
        public virtual DbSet<PortalZoneLayout> PortalZoneLayouts { get; set; }
        public virtual DbSet<ProfileDocument> ProfileDocuments { get; set; }
        public virtual DbSet<ProfileJobFunction> ProfileJobFunctions { get; set; }
        public virtual DbSet<ProfileLocation> ProfileLocations { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<Profiles_From_As400> Profiles_From_As400 { get; set; }
        public virtual DbSet<profilesApplicationConnection> profilesApplicationConnections { get; set; }
        public virtual DbSet<Protocol> Protocols { get; set; }
        public virtual DbSet<PublishQueue> PublishQueues { get; set; }
        public virtual DbSet<PublishStatu> PublishStatus { get; set; }
        public virtual DbSet<Rack> Racks { get; set; }
        public virtual DbSet<RelatveLocation> RelatveLocations { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<RoomMetaItem> RoomMetaItems { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Scenario> Scenarios { get; set; }
        public virtual DbSet<ScenDomain> ScenDomains { get; set; }
        public virtual DbSet<ScenTag> ScenTags { get; set; }
        public virtual DbSet<SensitivityData> SensitivityDatas { get; set; }
        public virtual DbSet<ServerMonitoringData> ServerMonitoringDatas { get; set; }
        public virtual DbSet<ServerProperty> ServerProperties { get; set; }
        public virtual DbSet<ServerPropertiesLog> ServerPropertiesLogs { get; set; }
        public virtual DbSet<ServerRole> ServerRoles { get; set; }
        public virtual DbSet<SNMP_Code> SNMP_Code { get; set; }
        public virtual DbSet<SoftwareInstalled> SoftwareInstalleds { get; set; }
        public virtual DbSet<Station> Stations { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<SysDocNew> SysDocNews { get; set; }
        public virtual DbSet<SystemExtendedSystemField> SystemExtendedSystemFields { get; set; }
        public virtual DbSet<SystemExtenendFieldLayout> SystemExtenendFieldLayouts { get; set; }
        public virtual DbSet<SystemExtenendFieldWebPart> SystemExtenendFieldWebParts { get; set; }
        public virtual DbSet<SystemFieldDataType> SystemFieldDataTypes { get; set; }
        public virtual DbSet<SystemFileLink> SystemFileLinks { get; set; }
        public virtual DbSet<SystemMaintenanceCompany> SystemMaintenanceCompanies { get; set; }
        public virtual DbSet<SystemSectionExtendedField> SystemSectionExtendedFields { get; set; }
        public virtual DbSet<SystemsNote> SystemsNotes { get; set; }
        public virtual DbSet<SystemsRequiresDR> SystemsRequiresDRs { get; set; }
        public virtual DbSet<SystemStatu> SystemStatus { get; set; }
        public virtual DbSet<SystemTypeField> SystemTypeFields { get; set; }
        public virtual DbSet<TaddmImpoterLog> TaddmImpoterLogs { get; set; }
        public virtual DbSet<Technology> Technologies { get; set; }
        public virtual DbSet<Tier> Tiers { get; set; }
        public virtual DbSet<TSTRackDemo> TSTRackDemoes { get; set; }
        public virtual DbSet<UploadedStencil> UploadedStencils { get; set; }
        public virtual DbSet<UserDisplayDefualtView> UserDisplayDefualtViews { get; set; }
        public virtual DbSet<UserFavorite> UserFavorites { get; set; }
        public virtual DbSet<UserManagentLOG> UserManagentLOGs { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VersionsDetailed> VersionsDetaileds { get; set; }
        public virtual DbSet<VisioMaster> VisioMasters { get; set; }
        public virtual DbSet<VisualizationContact> VisualizationContacts { get; set; }
        public virtual DbSet<VisualizationNote> VisualizationNotes { get; set; }
        public virtual DbSet<VLAN> VLANs { get; set; }
        public virtual DbSet<VPXImpData> VPXImpDatas { get; set; }
        public virtual DbSet<warehouse> warehouses { get; set; }
        public virtual DbSet<WeightType> WeightTypes { get; set; }
        public virtual DbSet<Wiki> Wikis { get; set; }
        public virtual DbSet<WikiSection> WikiSections { get; set; }
        public virtual DbSet<WikiTag> WikiTags { get; set; }
        public virtual DbSet<WMILog> WMILogs { get; set; }
        public virtual DbSet<WSFileLauncherCatalog> WSFileLauncherCatalogs { get; set; }
        public virtual DbSet<WSFileLauncherMethod> WSFileLauncherMethods { get; set; }
        public virtual DbSet<WSIncomingData> WSIncomingDatas { get; set; }
        public virtual DbSet<WSQueryCatalog> WSQueryCatalogs { get; set; }
        public virtual DbSet<WSTimeIntervalUnit> WSTimeIntervalUnits { get; set; }
        public virtual DbSet<WSV2_Methods> WSV2_Methods { get; set; }
        public virtual DbSet<WSV2_Parameters> WSV2_Parameters { get; set; }
        public virtual DbSet<WSV2_Services> WSV2_Services { get; set; }
        public virtual DbSet<WSXmlLibrary> WSXmlLibraries { get; set; }
        public virtual DbSet<ApplicationsLog> ApplicationsLogs { get; set; }
        public virtual DbSet<AppMoveStatu> AppMoveStatus { get; set; }
        public virtual DbSet<ASD> ASDs { get; set; }
        public virtual DbSet<AuditWSQueryCatalog> AuditWSQueryCatalogs { get; set; }
        public virtual DbSet<CommunicationLineContactPerson> CommunicationLineContactPersons { get; set; }
        public virtual DbSet<DocIndex> DocIndexes { get; set; }
        public virtual DbSet<EnvironmentToDowntimeGroup> EnvironmentToDowntimeGroups { get; set; }
        public virtual DbSet<EquipmentLog> EquipmentLogs { get; set; }
        public virtual DbSet<Essence> Essences { get; set; }
        public virtual DbSet<HP_Servers> HP_Servers { get; set; }
        public virtual DbSet<Item_BackUp> Item_BackUp { get; set; }
        public virtual DbSet<ItemApplicationConnectionDB> ItemApplicationConnectionDBs { get; set; }
        public virtual DbSet<ItemTypeOfUse> ItemTypeOfUses { get; set; }
        public virtual DbSet<LansweeperImport_Temp01> LansweeperImport_Temp01 { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<MNDJobOwnersGroup> MNDJobOwnersGroups { get; set; }
        public virtual DbSet<MNDMovementItemMember> MNDMovementItemMembers { get; set; }
        public virtual DbSet<MNDMovementSystemMember> MNDMovementSystemMembers { get; set; }
        public virtual DbSet<MNDRiskType> MNDRiskTypes { get; set; }
        public virtual DbSet<MNDSystemProgressStatu> MNDSystemProgressStatus { get; set; }
        public virtual DbSet<MNDToDoBank> MNDToDoBanks { get; set; }
        public virtual DbSet<MNDToDoType> MNDToDoTypes { get; set; }
        public virtual DbSet<RiskAssessmentType> RiskAssessmentTypes { get; set; }
        public virtual DbSet<Round> Rounds { get; set; }
        public virtual DbSet<slaTier> slaTiers { get; set; }
        public virtual DbSet<StationSeat> StationSeats { get; set; }
        public virtual DbSet<TempTbl> TempTbls { get; set; }
        public virtual DbSet<testTbl1> testTbl1 { get; set; }
        public virtual DbSet<Version> Versions { get; set; }
        public virtual DbSet<VM_HOST_IMPORT_FROM_IMPORT_PROD> VM_HOST_IMPORT_FROM_IMPORT_PROD { get; set; }
        public virtual DbSet<VM_HOST_IMPORT_FROM_IMPORT_TEST> VM_HOST_IMPORT_FROM_IMPORT_TEST { get; set; }
        public virtual DbSet<VM_HOST_IMPORT_PROD> VM_HOST_IMPORT_PROD { get; set; }
        public virtual DbSet<VM_HOST_IMPORT_TEMP04> VM_HOST_IMPORT_TEMP04 { get; set; }
        public virtual DbSet<VM_HOST_IMPORT_TEST> VM_HOST_IMPORT_TEST { get; set; }
        public virtual DbSet<VM_IMPORT_FROM_IMPORT_PROD> VM_IMPORT_FROM_IMPORT_PROD { get; set; }
        public virtual DbSet<VM_IMPORT_FROM_IMPORT_TEST> VM_IMPORT_FROM_IMPORT_TEST { get; set; }
        public virtual DbSet<VM_IMPORT_PROD> VM_IMPORT_PROD { get; set; }
        public virtual DbSet<VM_IMPORT_TEMP> VM_IMPORT_TEMP { get; set; }
        public virtual DbSet<VM_IMPORT_TEMP03> VM_IMPORT_TEMP03 { get; set; }
        public virtual DbSet<VM_IMPORT_TEST> VM_IMPORT_TEST { get; set; }
    
        public virtual int GetApplicationData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetApplicationData");
        }
    
        public virtual int GetData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetData");
        }
    
        public virtual int GetDataApplication()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetDataApplication");
        }
    
        public virtual int GetItemData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("GetItemData");
        }
    }
}