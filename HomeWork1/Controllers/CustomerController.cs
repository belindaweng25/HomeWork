using HomeWork1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork1.Controllers
{
    public class CustomerController : Controller
    {
        客戶資料Entities db = new 客戶資料Entities();

        // GET: Customer
        public ActionResult Index(string search)
        {
            //var data = db.客戶資料.ToList();

            var data = db.客戶資料.Where(c =>c.是否已刪除 == false).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(p => p.客戶名稱.Contains(search)).ToList();
            }

            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(客戶資料 newData)
        {

            if (ModelState.IsValid)
            {
                db.客戶資料.Add(newData);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(newData);
            }
        }

        public ActionResult Edit(int id)
        {
            var Data = db.客戶資料.Find(id);
            return View(Data);
        }

        [HttpPost]
        public ActionResult Edit(客戶資料 Data)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Data);
        }

        public ActionResult Details(int id)
        {
            var Data = db.客戶資料.Find(id);
            return View(Data);
        }

        public ActionResult Delete(int id)
        {
            var Data = db.客戶資料.Find(id);

            //var Contacts = Data.客戶聯絡人;
            //db.客戶聯絡人.RemoveRange(Contacts);

            //var BankInfo = Data.客戶銀行資訊;
            //db.客戶銀行資訊.RemoveRange(BankInfo);

            //db.客戶資料.Remove(Data);

            Data.是否已刪除 = true;

            db.Entry(Data).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ListPage()
        {
            var Data = db.vw_CustomerInfo.ToList();
            return View(Data);
        }
    }
}