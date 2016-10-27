using HomeWork1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeWork1.Controllers
{
    public class CustContactController : Controller
    {
        客戶資料Entities db = new 客戶資料Entities();

        // GET: CustContact
        public ActionResult Index(string search)
        {
            //var data = db.客戶聯絡人.ToList();

            var data = db.客戶聯絡人.Where(c => c.是否已刪除 == false).ToList();

            if (!string.IsNullOrEmpty(search))
            {
                data = data.Where(p => p.客戶資料.客戶名稱.Contains(search)).ToList();
            }

            return View(data);
        }

        public ActionResult Create()
        {
            var CustData = from A in db.客戶資料
                           select new
                           {
                               A.Id,
                               A.客戶名稱,
                           };
            
            List<SelectListItem> mySelectItemList = new List<SelectListItem>();

            foreach (var Custitem in CustData)
            {
                mySelectItemList.Add(new SelectListItem()
                {
                    Text = Custitem.客戶名稱,
                    Value = Custitem.Id.ToString(),
                    Selected = false
                });
            }

            ViewBag.客戶Id = mySelectItemList;

            return View();
        }

        [HttpPost]
        public ActionResult Create(客戶聯絡人 newData)
        {
            if (ModelState.IsValid)
            {
                db.客戶聯絡人.Add(newData);

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
            var Data = db.客戶聯絡人.Find(id);

            var CustData = from A in db.客戶資料
                           select new
                           {
                               A.Id,
                               A.客戶名稱,
                           };

            List<SelectListItem> mySelectItemList = new List<SelectListItem>();

            foreach (var Custitem in CustData)
            {
                mySelectItemList.Add(new SelectListItem()
                {
                    Text = Custitem.客戶名稱,
                    Value = Custitem.Id.ToString(),
                    Selected = Custitem.Id.Equals(Data.客戶Id)
                });
            }

            ViewBag.客戶Id = mySelectItemList;

            return View(Data);
        }

        [HttpPost]
        public ActionResult Edit(客戶聯絡人 Data)
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
            var Data = db.客戶聯絡人.Find(id);
            return View(Data);
        }

        public ActionResult Delete(int id)
        {
            var Data = db.客戶聯絡人.Find(id);

            //db.客戶聯絡人.Remove(Data);

            Data.是否已刪除 = true;

            db.Entry(Data).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}