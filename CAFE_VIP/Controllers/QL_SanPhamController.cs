using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CAFE_VIP.Models;
using Models.EF;
using CAFE_VIP.Common;
using System.IO;

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
        [HttpGet]
        public ActionResult TaoMoi()
        {
            //load  dropdow list mã loại món
            ViewBag.CategoryID = new SelectList(db.CATEGORies.OrderBy(n => n.CategoryID), "CategoryID","CategoryName");
            return View() ;
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult TaoMoi(PRODUCT sp, HttpPostedFileBase ShowImage)
        {
            //load  dropdow list mã loại món
            ViewBag.CategoryID = new SelectList(db.CATEGORies.OrderBy(n => n.CategoryID), "CategoryID", "CategoryName");
            
            // kiểm tra hình ảnh đã tồn tại hay chưa 
            if(ShowImage.ContentLength>0)
            {
                //lấy tên hình ảnh 
                var filename = Path.GetFileName(ShowImage.FileName);
                //lấy hình ảnh chuyển đến thư mục hình ảnh 
                var path = Path.Combine(Server.MapPath("~/Content/HinhAnhSP"),filename);
                //nếu thư mục đã có hình ảnh thì xuất ra thông báo 
                if (System.IO.File.Exists(path))
                {
                    ViewBag.upload = "Hình Đã Tồn Tại ";
                    return View();
                }    
                else
                {
                    //lấy  hình ảnh đưa ra thư mục Hình Ảnh Sản Phẩm 
                    ShowImage.SaveAs(path);
                    Session["TenHinh"] = ShowImage.FileName;
                    ViewBag.TenHinh = "";
                    sp.ShowImage = filename;

                }
                
            }
            db.PRODUCTs.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }
        [HttpGet]
        public ActionResult ChinhSua(int ? id)
        {
            //lấy sản phẩm chỉnh sửa dựa vào id 
                if (id==null)
            {
                Response.StatusCode = 404;
                return null;
            }               
                PRODUCT sp =db.PRODUCTs.SingleOrDefault(n=>n.CategoryID==id) ;

            
            //load  dropdow list mã loại món 
            ViewBag.CategoryID = new SelectList(db.CATEGORies.OrderBy(n => n.CategoryID), "CategoryID", "CategoryName");
            return View();
        }
    }

}