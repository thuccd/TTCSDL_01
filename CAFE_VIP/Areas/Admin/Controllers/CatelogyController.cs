﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CAFE_VIP.Areas.Admin.Controllers
{
    public class CatelogyController : Controller
    {
        // GET: Admin/Catelogy
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