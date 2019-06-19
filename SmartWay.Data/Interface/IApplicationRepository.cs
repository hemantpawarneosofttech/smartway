using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using BusinessEntities;

using SmartWay.Data.Infrastructure;
using SmartWay.Model.Models;

namespace SmartWay.Data.Interface
{
    public interface IApplicationRepository : IRepository<Application>
    {
        List<ApplicationViewModel> getAllParentApplications();
        List<JsonModel> GetApplicationChild(int applicationId);

        List<JsonModel> GetItemsApplication(long itemId, int applicationId);

        long GetItemIdFromName(string labelName, bool isApplication);

        List<JsonModel> GetSubsystemApplications(int applicationId);

        List<JsonModel> GetApplicationDatabases(int applicationId);
    }
}
