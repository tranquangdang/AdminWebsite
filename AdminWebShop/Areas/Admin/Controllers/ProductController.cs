using AdminWebShop.Areas.Admin.Models;
using Models.DAO;
using Models.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdminWebShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        // GET: Admin/Product
        public ActionResult Index(int page = 1, int pagesize = 10)
        {
            Notification();
            var model = new ProductDAO().ListAll();
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpPost]
        public ActionResult Index(string keyword, int page = 1, int pagesize = 10)
        {
            var model = new ProductDAO().ListWhereAll(keyword, page, pagesize);
            ViewBag.SearchString = keyword;
            return View(model.ToPagedList(page, pagesize));
        }

        [HttpGet]
        public ActionResult Create(string str)
        {
            var model = new ProductDAO();
            var getCateList = model.getCate();
            if (str != null)
            {
                var ProductID = Convert.ToInt32(str);
                var result = model.Find(ProductID);
                ViewBag.CategoryNameList = new SelectList(getCateList, "CategoryID", "CategoryName", result.CategoryNo);
                return View(result);
            }
            else
            {
                ViewBag.Update = true;
                ViewBag.CategoryNameList = new SelectList(getCateList, "CategoryID", "CategoryName");
                return View();
            }

        }

        [HttpPost]
        public ActionResult Create(tblProduct model, HttpPostedFileBase postedFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    postedFile = Request.Files["ProductImage"];
                    if (postedFile.ContentLength <= 0 && model.ProductID == 0)
                    {
                        ViewBag.CategoryNameList = new SelectList(new ProductDAO().getCate(), "CategoryID", "CategoryName");
                        SetAlert("Vui lòng chọn ảnh!", "error");
                        return RedirectToAction("Create", "Product");
                    } 

                    if (postedFile.ContentLength > 0)
                    {
                        string filePath = "";
                        filePath = Server.MapPath("~/Images/");
                        var fileName = Path.GetFileName(postedFile.FileName);
                        filePath = filePath + fileName;
                        postedFile.SaveAs(filePath);
                        DeleteImg(model.ProductImg);
                        model.ProductImg = "~/Images/" + fileName;
                    }

                    string result = "";
                    result = new ProductDAO().Insert(model);
                    if (!string.IsNullOrEmpty(result))
                    {
                        SetAlert("Thành công!", "success");
                        return RedirectToAction("Index", "Product");
                    }
                    else
                    {
                        SetAlert("Lỗi", "error");
                    }
                }
                else
                {
                    ViewBag.CategoryNameList = new SelectList(new ProductDAO().getCate(), "CategoryID", "CategoryName");
                    SetAlert("Lỗi", "error");
                }
            }
            catch (Exception ex)
            {
                Common.Common.WriteLog("Product", "Create-Post", ex.ToString());
            }
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int ProductID)
        {
            var model = new ProductDAO();
            DeleteImg(model.Find(ProductID).ProductImg);
            model.Delete(ProductID);
            return RedirectToAction("Index");
        }

        public void DeleteImg(string pathName)
        {
            if(!string.IsNullOrEmpty(pathName))
            {
                if (pathName.Substring(0,4) != "http")
                {
                    string fullPath = Request.MapPath(pathName);
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                } 
            } 
        }
    }
}