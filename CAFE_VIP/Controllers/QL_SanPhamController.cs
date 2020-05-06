using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAFE_VIP.Models;
using Models.EF;
using CAFE_VIP.Common;

namespace CAFE_VIP.Controllers
{
    public class QL_SanPhamController : Controller
    {
        // GET: QL_SanPham
        CafeDbContext db = new CafeDbContext();
        public ActionResult Index()
        {
            return View(db.PRODUCTs.Where(n=>n.ProductStatus==false));
        }
    }
}