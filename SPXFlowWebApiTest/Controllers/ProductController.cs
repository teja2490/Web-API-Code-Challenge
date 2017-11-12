using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace SPXFlowWebApiTest.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult list()
        {
            return View();
        }
    }
}
