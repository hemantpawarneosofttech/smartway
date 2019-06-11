using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using SmartWay.Data.Interface;
using SmartWay.Data.Repository;
using SmartWay.Model.Models;

namespace SmartWay.Web.Controllers
{
    public class HomeController : Controller
    {
        IApplicationRepository applicationRepository = new ApplicationRepository();
        #region Graph
        public ActionResult Graph()
        {
            var model = new ParentModel();
            model.applicationList = applicationRepository.getAllParentApplications();
            return View(model);
        }

        #endregion Graph

        #region GetCompletGraph
        /// <summary>
        /// GetCompletGraph
        /// </summary>
        /// <param name="shapeLabel"></param>
        /// <param name="itemid"></param>
        /// <param name="selectedParentId"></param>
        /// <param name="inputJsonModel"></param>
        /// <remarks>
        /// used to get graph data as per level
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        public JsonResult GetCompletGraph(GraphInputModel graphInput, List<JsonModel> inputJsonModel)
        {
            if (graphInput.itemid == null)
            {
                var list = applicationRepository.GetApplicationChild(Convert.ToInt32(graphInput.selectedParentId));
                //append list to inputjsonModel
                inputJsonModel.AddRange(list);

                //return list;
                return Json(inputJsonModel, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var isApplication = inputJsonModel.Where(x => x.shapeLabel == graphInput.shapeLabel).FirstOrDefault().IsApplication;


                long idFromLabel = applicationRepository.GetItemIdFromName(graphInput.shapeLabel, isApplication);//get id from label ie.currently passed item name's id

                if (idFromLabel <= 0)
                {
                    return Json(inputJsonModel);
                }
                //get level from label ie.currently passed itemid's level
                var currentLevel = 3;

                //check whether current itemid is IsAppication or not

                if (isApplication)
                {
                    currentLevel = 4;
                    //application child
                    var applicationChildList = applicationRepository.GetApplicationChild(Convert.ToInt32(idFromLabel));

                    applicationChildList.ForEach(x => x.Level = currentLevel);

                    //remove all child of current Level from inputJsonModel list
                    inputJsonModel.RemoveAll(x => x.Level >= currentLevel);

                    //applicationChildList

                    //applicationChildList.Where(f => !inputJsonModel.Contains(f));

                    //remove existing record from applicationChildlist
                    //for (var i = 0; i < inputJsonModel.Count; i++)//(var item in applicationChildList)
                    //{
                    //    for (var j = 0; j < applicationChildList.Count; j++)
                    //    {
                    //        if (inputJsonModel[i].shapeControlName == applicationChildList[j].shapeControlName)
                    //        {
                    //            applicationChildList.RemoveAll(x => x.shapeControlName == applicationChildList[j].shapeControlName );
                    //        }
                    //    }
                    //}
                    //&& applicationChildList[i].shapeType != "Link"
                    //append applicationChildList to inputjsonModel
                    var tempdata = new List<JsonModel>();
                    foreach (var item in applicationChildList)
                    {
                        if (!(inputJsonModel.Exists(x => x.shapeControlName == item.shapeControlName)))
                        {
                            tempdata.Add(item);
                        }
                    }

                    inputJsonModel = CombineList(inputJsonModel, tempdata);


                    //inputJsonModel.AddRange(applicationChildList);
                }
                else
                {
                    //application child
                    var applicationChildList = applicationRepository.GetItemsApplication(Convert.ToInt64(idFromLabel), Convert.ToInt32(graphInput.selectedParentId));

                    //remove all child of current Level from inputJsonModel list
                    inputJsonModel.RemoveAll(x => x.Level >= currentLevel);

                    //append applicationChildList to inputjsonModel
                    inputJsonModel = CombineList(inputJsonModel, applicationChildList);
                }

                inputJsonModel.Distinct();
                //return inputJsonmodel after appending data
                return Json(inputJsonModel, JsonRequestBehavior.AllowGet);
            }

        }

        #endregion GetCompletGraph

        #region GetSubsystemApplications

        /// <summary>
        /// Get Applications Subsystem 
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// Used for getting sub system data 
        /// </remarks>
        /// <returns></returns>
        //[HttpGet]
        //public JsonResult GetSubsystemApplications(int id)
        //{
        //    var subSystemList = applicationRepository.GetSubsystemApplications(id);

        //    return Json(subSystemList, JsonRequestBehavior.AllowGet);
        //}

        [HttpPost]
        public JsonResult GetSubsystemApplications(SubSystemInputModel model)
        {
            long idFromLabel = applicationRepository.GetItemIdFromName(model.shapeLabel, model.isApplication);//get id from label ie.currently passed item name's id

            if (idFromLabel <= 0)
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }

            var subSystemList = applicationRepository.GetSubsystemApplications(Convert.ToInt32(idFromLabel));         
            return Json(subSystemList, JsonRequestBehavior.AllowGet);
        }

        #endregion GetSubsystemApplications

        #region Private Methods
        private List<JsonModel> CombineList(List<JsonModel> firstList, List<JsonModel> secondList)
        {
            List<JsonModel> jsonModels = new List<JsonModel>();

            jsonModels.AddRange(firstList.Where(x => x.shapeType != "Link"));
            jsonModels.AddRange(secondList.Where(x => x.shapeType != "Link"));
            jsonModels.AddRange(firstList.Where(x => x.shapeType == "Link"));
            jsonModels.AddRange(secondList.Where(x => x.shapeType == "Link"));

            return jsonModels;
        }
        #endregion Private Methods
    }
}













//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Newtonsoft.Json;
//using SmartWay.Data.Interface;
//using SmartWay.Data.Repository;
//using SmartWay.Model.Models;

//namespace SmartWay.Web.Controllers
//{
//    public class HomeController : Controller
//    {
//        IApplicationRepository applicationRepository = new ApplicationRepository();
//        #region Graph
//        public ActionResult Graph()
//        {
//            var model = new ParentModel();
//            model.applicationList = applicationRepository.getAllParentApplications();
//            return View(model);
//        }

//        #endregion Graph

//        #region GetCompletGraph
//        /// <summary>
//        /// GetCompletGraph
//        /// </summary>
//        /// <param name="shapeLabel"></param>
//        /// <param name="itemid"></param>
//        /// <param name="selectedParentId"></param>
//        /// <param name="inputJsonModel"></param>
//        /// <remarks>
//        /// used to get graph data as per level
//        /// </remarks>
//        /// <returns></returns>
//        [HttpPost]
//        public JsonResult GetCompletGraph(string shapeLabel, int? itemid, int? selectedParentId, List<JsonModel> inputJsonModel)
//        {
//            if (itemid == null)
//            {
//                var list = applicationRepository.GetApplicationChild(Convert.ToInt32(selectedParentId));
//                //append list to inputjsonModel
//                inputJsonModel.AddRange(list);

//                //return list;
//                return Json(inputJsonModel, JsonRequestBehavior.AllowGet);
//            }
//            else
//            {
//                var isApplication = inputJsonModel.Where(x => x.shapeLabel == shapeLabel).FirstOrDefault().IsApplication;


//                long idFromLabel = applicationRepository.GetItemIdFromName(shapeLabel, isApplication);//get id from label ie.currently passed item name's id

//                if (idFromLabel <= 0)
//                {
//                    return Json(inputJsonModel);
//                }
//                //get level from label ie.currently passed itemid's level
//                var currentLevel = 3;

//                //check whether current itemid is IsAppication or not

//                if (isApplication)
//                {
//                    currentLevel = 4;
//                    //application child
//                    var applicationChildList = applicationRepository.GetApplicationChild(Convert.ToInt32(idFromLabel));

//                    applicationChildList.ForEach(x => x.Level = currentLevel);

//                    //remove all child of current Level from inputJsonModel list
//                    inputJsonModel.RemoveAll(x => x.Level >= currentLevel);

//                    //append applicationChildList to inputjsonModel
//                    inputJsonModel = CombineList(inputJsonModel, applicationChildList);
//                    //inputJsonModel.AddRange(applicationChildList);
//                }
//                else
//                {
//                    //application child
//                    var applicationChildList = applicationRepository.GetItemsApplication(Convert.ToInt64(idFromLabel), Convert.ToInt32(selectedParentId));

//                    //remove all child of current Level from inputJsonModel list
//                    inputJsonModel.RemoveAll(x => x.Level >= currentLevel);

//                    //append applicationChildList to inputjsonModel
//                    inputJsonModel = CombineList(inputJsonModel, applicationChildList);
//                }

//                //return inputJsonmodel after appending data
//                return Json(inputJsonModel, JsonRequestBehavior.AllowGet);
//            }

//        }

//        #endregion GetCompletGraph

//        #region GetSubsystemApplications

//        /// <summary>
//        /// Get Applications Subsystem 
//        /// </summary>
//        /// <param name="id"></param>
//        /// <remarks>
//        /// Used for getting sub system data 
//        /// </remarks>
//        /// <returns></returns>
//        [HttpGet]
//        public JsonResult GetSubsystemApplications(int id)
//        {
//            var subSystemList = applicationRepository.GetSubsystemApplications(id);

//            return Json(subSystemList, JsonRequestBehavior.AllowGet);
//        }

//        #endregion GetSubsystemApplications

//        #region Private Methods
//        private List<JsonModel> CombineList(List<JsonModel> firstList, List<JsonModel> secondList)
//        {
//            List<JsonModel> jsonModels = new List<JsonModel>();

//            jsonModels.AddRange(firstList.Where(x => x.shapeType != "Link"));
//            jsonModels.AddRange(secondList.Where(x => x.shapeType != "Link"));
//            jsonModels.AddRange(firstList.Where(x => x.shapeType == "Link"));
//            jsonModels.AddRange(secondList.Where(x => x.shapeType == "Link"));

//            return jsonModels;
//        }
//        #endregion Private Methods
//    }
//}