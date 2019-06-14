using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
//using BusinessEntities;
using SmartWay.Data.Infrastructure;
using SmartWay.Data.Interface;
using SmartWay.Model.Models;

namespace SmartWay.Data.Repository
{
    public class ApplicationRepository : RepositoryBase<Application>, IApplicationRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["connectionstringName"].ToString()].ConnectionString;
        #region ParentModel
        public class ParentModel
        {
            public List<ApplicationViewModel> applicationList { get; set; }
        }
        #endregion ParentModel

        #region getAllParentApplications
        public List<ApplicationViewModel> getAllParentApplications()
        {
            var applications = DbContext.Applications.Where(x => !x.IsSubsystem.Value && x.StatusID != 5 && x.TypeID != 4).OrderBy(x=>x.Name).ToList();
            ///var applications = DbContext.Applications.ToList();
            return Mapper.applicationViewModelMapper(applications);
        }
        #endregion getAllParentApplications

        #region GetApplicationChild
        /// <summary>
        /// used to Get Application Child
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public List<JsonModel> GetApplicationChild(int applicationId)
        {
            List<JsonModel> list = new List<JsonModel>();

            try
            {
                SqlConnection conString = new SqlConnection(connectionString);
                conString.Open();
                SqlCommand cmdQuery = new SqlCommand("STP_GetApplicationChild", conString);
                cmdQuery.Parameters.AddWithValue("@ID", applicationId);
                cmdQuery.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmdQuery);
                DataSet dsData = new DataSet();
                sda.Fill(dsData);

                list = CreateListFromTable(dsData);
            }

            catch (Exception ex)
            {
                throw ex;
            }
            return list;
        }

        #endregion GetApplicationChild

        #region GetItemsApplication
        /// <summary>
        /// used for get item's application
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public List<JsonModel> GetItemsApplication(long itemId, int applicationId)
        {
            List<JsonModel> list = new List<JsonModel>();

            try
            {
                //string str = ConfigurationManager.ConnectionStrings["SmartWayNewDB"].ConnectionString;
                SqlConnection conString = new SqlConnection(connectionString);
                conString.Open();
                SqlCommand cmdQuery = new SqlCommand("STP_GetItemsApplication", conString);
                cmdQuery.Parameters.AddWithValue("@ID", applicationId);
                cmdQuery.Parameters.AddWithValue("@ItemId", itemId);
                cmdQuery.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmdQuery);
                DataSet dsData = new DataSet();
                sda.Fill(dsData);

                list = CreateListFromTable(dsData);

            }

            catch (Exception ex)
            {
            }

            return list;
        }

        #endregion

        #region GetSubsystemApplications

        /// <summary>
        ///uased to  Get Subsystem Applications
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        public List<JsonModel> GetSubsystemApplications(int applicationId)
        {
            List<JsonModel> list = new List<JsonModel>();

            try
            {
                SqlConnection conString = new SqlConnection(connectionString);
                conString.Open();
                SqlCommand cmdQuery = new SqlCommand("STP_GetSubsystemApplications", conString);
                cmdQuery.Parameters.AddWithValue("@ID", applicationId);
                cmdQuery.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter sda = new SqlDataAdapter(cmdQuery);
                DataSet dsData = new DataSet();
                sda.Fill(dsData);

                list = CreateListFromTable(dsData);
            }
            catch (Exception ex)
            {
            }
            return list;
        }

        #endregion GetSubsystemApplications

        #region GetItemIdFromName
        /// <summary>
        /// Get Id From Item or application Name
        /// </ summary>
        /// <param name="labelName"></param>
        /// <param name="isApplication"></param>
        /// <returns></returns>
        public long GetItemIdFromName(string labelName, bool isApplication)
        {
            long id = 0;
            if (isApplication)
            {
                var id1 = DbContext.Applications.Where(x => x.Name == labelName).FirstOrDefault()?.ID;
                if (id1.HasValue)
                    id = id1.Value;
            }
            else
            {
                var id1 = DbContext.Items.Where(x => x.Name == labelName).FirstOrDefault()?.ID;
                if (id1.HasValue)
                    id = id1.Value;
            }

            return id;
        }

        #endregion

        #region Private Methods
        private List<JsonModel> CreateListFromTable(DataSet dsData)
        {
            List<JsonModel> list = new List<JsonModel>();
            if (dsData != null)
            {
                foreach (DataRow row in dsData.Tables[0].Rows)
                {
                    JsonModel jsonModel = new JsonModel();
                    jsonModel.id = Convert.ToInt32(row.ItemArray.GetValue(0).ToString());
                    jsonModel.shapeType = row.ItemArray.GetValue(1).ToString();
                    jsonModel.shapeControlName = row.ItemArray.GetValue(2).ToString();
                    jsonModel.shapeLabel = row.ItemArray.GetValue(3).ToString();
                    jsonModel.linkSource = row.ItemArray.GetValue(4).ToString();
                    jsonModel.linkTarget = row.ItemArray.GetValue(5).ToString();
                    jsonModel.parent = row.ItemArray.GetValue(6).ToString();
                    jsonModel.IsApplication = Convert.ToBoolean(row.ItemArray.GetValue(8));
                    jsonModel.Level = Convert.ToInt32(row.ItemArray.GetValue(9).ToString());
                    if (string.IsNullOrEmpty(jsonModel.parent) && jsonModel.shapeType != "Link")
                    {
                        jsonModel.IsBase = true;
                    }
                    list.Add(jsonModel);
                }
            }
            return list;
        }

        #endregion


    }
}
