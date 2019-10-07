using AirBench.Data;
using AirBench.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AirBench.Controllers
{
    public class HomeController : Controller
    {
        private IBenchRepository repository;

        public HomeController(IBenchRepository repository)
        {
            this.repository = repository;
        }

        public async Task<ActionResult> Index()
        {
            var benches = await repository.GetList();
            return View(benches);
        }
    }
}