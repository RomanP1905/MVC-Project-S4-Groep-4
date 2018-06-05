using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAO_Wagenpark.Controllers
{
    public class ListController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Auto(int? id)
        { 
            return View("AutoView");
        }
        public ActionResult Dealer(int? id)
        {
            return View("Dealerview");
        }
    }
}