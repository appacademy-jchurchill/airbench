using AirBench.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AirBench.Controllers
{
    public class BenchesController : Controller
    {
        public ActionResult Create()
        {
            var formModel = new CreateBench();
            return View(formModel);
        }
    }
}