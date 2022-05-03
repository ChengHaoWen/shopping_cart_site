using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebEr.Models;

namespace WebEr.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        ErContext db = new ErContext();
        public ActionResult Index()
        {
            var products = db.TProduct.OrderByDescending(m => m.FId).ToList();

            return View("../Member/Index","_LayoutMember",products);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Home");
        }
        public ActionResult ShoppingCar()
        {
            string userid = User.Identity.Name;
            var orderDetails = db.TOrderDetail.Where(m => m.FUserId == userid && m.FIsApproved == "否").ToList();


            return View(orderDetails);
        }
        public ActionResult AddCar(string FPid)
        {
            string userid = User.Identity.Name;
            var currentCar= db.TOrderDetail.Where(m => m.FUserId == userid && 
            m.FIsApproved == "否"&& m.FPid==FPid).FirstOrDefault();
            //若currentCar等於null表示會員選購的產品不是購物車狀態
            if (currentCar == null)
            {
                var product = db.TProduct.Where(m => m.FPid == FPid).FirstOrDefault();
                TOrderDetail orderdetail = new TOrderDetail();
                orderdetail.FUserId = userid.Trim();
                orderdetail.FPid = product.FPid.Trim();
                orderdetail.FName = product.FName.Trim();
                orderdetail.FPrice = product.FPrice;
                orderdetail.FQty = 1;
                orderdetail.FIsApproved = "否";
                db.TOrderDetail.Add(orderdetail);
            }
            else
            {
                currentCar.FQty += 1;
            }
            db.SaveChanges();
            return RedirectToAction("ShoppingCar");
        }
        public ActionResult DeletCar(int FId)
        {
            var orderDetail = db.TOrderDetail.Where(m => m.FId == FId).FirstOrDefault();
            db.TOrderDetail.Remove(orderDetail);
            db.SaveChanges();
            return RedirectToAction("ShoppingCar");
        }
        [HttpPost]
        public ActionResult ShoppingCar(string FReceive, string FEmail, string FAddress)
        {
            string userid = User.Identity.Name;
            //建立唯一的識別值給guid變數當訂單編號
            string guid = Guid.NewGuid().ToString();
            TOrder order = new TOrder();
            order.FOrderGuid = guid;
            order.FUserId = userid;
            order.FReceiver = FReceive;
            order.FEmail = FEmail;
            order.FAddress = FAddress;
            order.FDate = DateTime.Now;
            db.TOrder.Add(order);
            var carList = db.TOrderDetail.Where(m => m.FIsApproved == "否" && m.FUserId == userid).ToList();
            foreach (var item in carList)
            {
                item.FOrderGuid = guid;
                item.FIsApproved = "是";

            }
            db.SaveChanges();

            return RedirectToAction("OrderList");
        }
        public ActionResult OrderList()
        {
            string userid = User.Identity.Name;
            var orders = db.TOrder.Where(m => m.FUserId == userid).OrderByDescending(m => m.FDate).ToList();
            return View(orders);
        }
        public ActionResult OrderDetail(string FOrderGuid)
        {
            var orderDetails = db.TOrderDetail.Where(m => m.FOrderGuid == FOrderGuid).ToList();
            return View(orderDetails);
        }

    }
}