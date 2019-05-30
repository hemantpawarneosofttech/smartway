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

        public class ParentModel
        {
            public List<ApplicationViewModel> applicationList { get; set; }
        }
        public List<ApplicationViewModel> getAllParentApplications()
        {
            return Mapper.applicationViewModelMapper(DbContext.Applications.ToList());
        }

        public List<JsonModel> GetRelatedChildNodes(int applicationId)
        {
            List<JsonModel> list = new List<JsonModel>();

            try
            {
                string str = ConfigurationManager.ConnectionStrings["SmartWayNewDB"].ConnectionString;
                SqlConnection conString = new SqlConnection(str);
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
            }
            return list;
        }
        public List<JsonModel> GetItemsApplication(int itemId, int applicationId)
        {
            List<JsonModel> list = new List<JsonModel>();

            try
            {
                string str = ConfigurationManager.ConnectionStrings["SmartWayNewDB"].ConnectionString;
                SqlConnection conString = new SqlConnection(str);
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
                    jsonModel.IsApplication = Convert.ToBoolean(row.ItemArray.GetValue(7));
                    if (string.IsNullOrEmpty(jsonModel.parent) && jsonModel.shapeType != "Link")
                    {
                        jsonModel.IsBase = true;
                    }
                    list.Add(jsonModel);
                }
            }
            return list;
        }
    }
}
