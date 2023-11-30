using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem1.EF;
using InventoryManagementSystem1.Models;

namespace InventoryManagementSystem1.Controllers
{
    public class InvoiceSummariesController : Controller
    {
        private InventoryContext db = new InventoryContext();

        // GET: InvoiceSummaries
        public ActionResult Index()
        {
            var finalList = from inv in db.InvoiceSummarys.ToList()
                            join sup in db.Suppliers.ToList() on inv.SupplierId equals sup.SupplierID
                            select new InvoiceSummaryVM()
                            {
                                EntryDate = inv.EntryDate.ToString("D"),
                                EntryId = inv.EntryID,
                                InvoiceAmount = inv.AmountInGST.ToString("C"),
                                InvoiceDate = inv.InvoiceDate.ToString("D"),
                                InvoiceNumber = inv.InvoiceNumber,
                                OrderNumber = inv.PurchaseOrderNumber,
                                SupplierName = sup.SupplierName
                            };



            //var list = db.InvoiceSummarys.ToList();
            //var newList = list.Select(x =>new InvoiceSummaryVM() {
            //EntryDate=x.EntryDate.ToString("D"),
            //EntryId=x.EntryID,
            //InvoiceAmount=x.AmountInGST.ToString("C"),
            //InvoiceDate=x.InvoiceDate.ToString("D"),
            //InvoiceNumber=x.InvoiceNumber,
            //OrderNumber=x.PurchaseOrderNumber,
            //SupplierName=sup.SupplierName
            //});
            return View(finalList);
        }

        // GET: InvoiceSummaries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceSummary invoiceSummary = db.InvoiceSummarys.Find(id);
            if (invoiceSummary == null)
            {
                return HttpNotFound();
            }
            return View(invoiceSummary);
        }

        // GET: InvoiceSummaries/Create
        public ActionResult Create()
        {
            ViewBag.SuplierList = db.Suppliers;

            return View();
        }

        // POST: InvoiceSummaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EntryID,SupplierId,PurchaseOrderNumber,EntryDate,InvoiceNumber,InvoiceDate,AmountInGST,Email,Notes")] InvoiceSummary invoiceSummary)
        {
            if (ModelState.IsValid)
            {
                db.InvoiceSummarys.Add(invoiceSummary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(invoiceSummary);
        }

        // GET: InvoiceSummaries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceSummary invoiceSummary = db.InvoiceSummarys.Find(id);
            if (invoiceSummary == null)
            {
                return HttpNotFound();
            }
            ViewBag.SuplierList = db.Suppliers;
            ViewBag.POList= db.Orders.Where(x => x.Supplier_ID == invoiceSummary.SupplierId).Select(x => x.OrderNumber);
            return View(invoiceSummary);
        }

        // POST: InvoiceSummaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EntryID,SupplierId,PurchaseOrderNumber,EntryDate,InvoiceNumber,InvoiceDate,AmountInGST,Email,Notes")] InvoiceSummary invoiceSummary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invoiceSummary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(invoiceSummary);
        }

        // GET: InvoiceSummaries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InvoiceSummary invoiceSummary = db.InvoiceSummarys.Find(id);
            if (invoiceSummary == null)
            {
                return HttpNotFound();
            }
            return View(invoiceSummary);
        }

        // POST: InvoiceSummaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InvoiceSummary invoiceSummary = db.InvoiceSummarys.Find(id);
            db.InvoiceSummarys.Remove(invoiceSummary);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult GetPOs (int id)
        {
            var data= db.Orders.Where(x=>x.Supplier_ID==id).Select(x => x.OrderNumber);
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public PartialViewResult GetPOsPV(int id)
        {
            var data = db.Orders.Where(x => x.Supplier_ID == id).Select(x => x.OrderNumber);
            return PartialView("_PODropdownData", data);

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
