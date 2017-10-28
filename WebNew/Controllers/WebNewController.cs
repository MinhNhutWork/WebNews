using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebNew.Models;

namespace WebNew.Controllers
{
    public class WebNewController : Controller
    {
        dbWEBTINTUCDataContext data = new dbWEBTINTUCDataContext();
        // GET: WebNew

        public ActionResult Index()
        {
            var baivietmoi = Laybaivietmoi(4);
            return View(baivietmoi);
        }
        private List<BaiViet> Laybaivietmoi(int n)
        {
            return data.BaiViets.OrderByDescending(a => a.NgayDang).Take(n).ToList();
        }
        public ActionResult LoaiBV()
        {
            var lbv = from lb in data.LoaiBaiViets select lb;
            return PartialView(lbv);
        }
        public ActionResult Baivietmoi()
        {
            var lbv = data.BaiViets.OrderByDescending(a => a.NgayDang).Take(10).ToList();
            return PartialView(lbv);
        }
        public ActionResult Baivietnoibat()
        {
            var lbv = data.BaiViets.OrderByDescending(a => a.NgayDang).Take(5).ToList();
            return PartialView(lbv);
        }
        public ActionResult BVTheoLoai(int id)
        {
            var bv = from lb in data.BaiViets where lb.MaLoaiBV==id select lb;
            return PartialView(bv);
        }
        public ActionResult Details(int id)
        {
            var bv = from lb in data.BaiViets where lb.MaBaiviet == id select lb;
            return View(bv.Single());
        }

        public ActionResult KinhTe()
        {
            var lbv = data.BaiViets.OrderByDescending(a => a.MaLoaiBV==1).Take(4).ToList();
            return PartialView(lbv);
        }        
        public ActionResult Congnghe()
        {
            var lbv = data.BaiViets.OrderByDescending(a => a.MaLoaiBV==2).Take(4).ToList();
            return PartialView(lbv);
        }
        public ActionResult Thoisu()
        {
            var lbv = data.BaiViets.OrderByDescending(a => a.MaLoaiBV == 3).Take(1).ToList();
            return PartialView(lbv);
        }
        public ActionResult Thethao()
        {
            var lbv = data.BaiViets.OrderByDescending(a => a.MaLoaiBV == 4).Take(1).ToList();
            return PartialView(lbv);
        }
    }
}