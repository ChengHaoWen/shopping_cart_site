using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebEr.Controllers;
using WebEr.Models;
using System.Web.Security;

namespace WebEr.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        ErContext db = new ErContext();
        // GET: Home
        public ActionResult Index()
        {
            var products = db.TProduct.OrderByDescending(m => m.FId).ToList();

            return View(products);
        }
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(string Userid,string pwd)
        {

            var member = db.TMember.Where(m=>m.FUserId==Userid&& m.FPwd==pwd).FirstOrDefault();
            if (member == null)
            {
                ViewBag.Message = "帳號密碼錯誤，登入失敗";
                return View();
            }
            //使用session記錄歡迎詞
            Session["Welcome"] = member.FName + "歡迎光臨";
            FormsAuthentication.RedirectFromLoginPage(Userid, true);
            return RedirectToAction("Index", "Member");
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(TMember dt_member)
        {


            if (ModelState.IsValid == false)
            {
                return View();
            }
            var member = db.TMember.Where(m => m.FUserId==dt_member.FUserId).FirstOrDefault();
            if (member == null)
            {
                db.TMember.Add(dt_member);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            ViewBag.Message = "此帳號已有人使用，註冊失敗";
            return RedirectToAction("Index", "Home");
        }
        public ActionResult ProductCreate()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ProductCreate(HttpPostedFileBase photo, string FPid, string FName, int FPrice)
        {
            TProduct dtPro = new TProduct();
            var validTypes = new[] { "image/jpeg", "image/pjpeg", "image/png", "image/gif" };
            string type = photo.ContentType;//獲取圖片型別
            string name = photo.FileName;
            string[] types = type.Split('/');
            if (!validTypes.Contains(photo.ContentType))
            {
                ModelState.AddModelError("PhotoUpload", "Please upload either a JPG, GIF, or PNG image.");
            }
            if (photo != null && FPid != string.Empty && FName != string.Empty &&
                photo.ContentLength > 0)
            {
                dtPro.FPid = FPid;
                dtPro.FName = FName;
                dtPro.FPrice = FPrice;
                dtPro.FImg = name ;
                db.TProduct.Add(dtPro);
                string fileName = Path.GetFileName(photo.FileName);
                var path = Path.Combine(Server.MapPath("~/images"), fileName);
                photo.SaveAs(path);
                db.SaveChanges();
            }

            return RedirectToAction("member/index");
        }
    }
}