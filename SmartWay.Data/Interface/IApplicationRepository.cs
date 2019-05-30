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
        List<JsonModel> GetRelatedChildNodes(int applicationId);

        List<JsonModel> GetItemsApplication(int itemId, int applicationId);
    }
}
