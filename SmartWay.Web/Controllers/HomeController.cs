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
        public ActionResult Index()
        {
            var model = new ParentModel();

            model.applicationList = applicationRepository.getAllParentApplications();
            return View(model);
        }

        public JsonResult GetApplicationChild(int id)
        {
            var list = applicationRepository.GetRelatedChildNodes(id);

            //var result = applicationRepository.GetItemsApplication(list[1].id, list[0].id);
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetItemsApplication(int itemId, int appId)
        {
            var list = applicationRepository.GetItemsApplication(itemId, appId);
            foreach (var item in list)
            {
                item.Level = 3;
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }


        public JsonResult FilterChildData(string name)
        {
            var Data = JsonConvert.DeserializeObject("");

            return Json(Data, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Graph()
        {
            var model = new ParentModel();
            model.applicationList = applicationRepository.getAllParentApplications();
            return View(model);
        }
    }
}