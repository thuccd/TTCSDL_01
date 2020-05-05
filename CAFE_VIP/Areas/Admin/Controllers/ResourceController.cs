using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAFE_VIP.Areas.Admin.Controllers
{
    public class ResourceController : Controller
    {
        // GET: Admin/Resource
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

    }
}