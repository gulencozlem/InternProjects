using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WEB_SİTESİ.Models;

namespace WEB_SİTESİ.Controllers
{
    public class kayit_tableController : Controller
    {
        private KayitYapanlarEntities db = new KayitYapanlarEntities();

        // GET: kayit_table
        public ActionResult Index(string p)
        {
            if (!string.IsNullOrEmpty(p))
            {
                var filteredList = db.kayit_table.Where(x => x.TCKN.Contains(p)).ToList();
                return View(filteredList);
            }
            return View(db.kayit_table.ToList());
        }

        // GET: kayit_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kayit_table kayit_table = db.kayit_table.Find(id);
            if (kayit_table == null)
            {
                return HttpNotFound();
            }
            return View(kayit_table);
        }

        // GET: kayit_table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: kayit_table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "kayitID,adiniz,soyadiniz,TCKN,adres,hasar_bilgisi,beklentiniz_nedir")] kayit_table kayit_table)
        {
            if (ModelState.IsValid)
            {
                db.kayit_table.Add(kayit_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kayit_table);
        }

        // GET: kayit_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kayit_table kayit_table = db.kayit_table.Find(id);
            if (kayit_table == null)
            {
                return HttpNotFound();
            }
            return View(kayit_table);
        }

        // POST: kayit_table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kayitID,adiniz,soyadiniz,TCKN,adres,hasar_bilgisi,beklentiniz_nedir")] kayit_table kayit_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kayit_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kayit_table);
        }

        // GET: kayit_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kayit_table kayit_table = db.kayit_table.Find(id);
            if (kayit_table == null)
            {
                return HttpNotFound();
            }
            return View(kayit_table);
        }

        // POST: kayit_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kayit_table kayit_table = db.kayit_table.Find(id);
            db.kayit_table.Remove(kayit_table);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
