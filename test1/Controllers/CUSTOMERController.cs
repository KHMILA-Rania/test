using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using test1.Models;
using test1.class1;

namespace test1.Controllers
{
    public class CUSTOMERController : Controller
    {
        Customer_Entities db = new Customer_Entities();

        // GET: CUSTOMER
        public ActionResult Index()
        {
            return View(db.CUSTOMERs.ToList());
        }


        public ActionResult Confirm( int id)
        {


        //        db.Entry(customer).State = EntityState.Modified;
        //        try
        //        {
        //            db.SaveChanges();
        //        }
        //        catch (DbEntityValidationException e)
        //        {
        //            foreach (var eve in e.EntityValidationErrors)
        //            {
        //                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
        //                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
        //                foreach (var ve in eve.ValidationErrors)
        //                {
        //                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
        //                        ve.PropertyName, ve.ErrorMessage);
        //                }
        //            }
        //            //throw;

            //        //dbc.SaveChanges();
            //        System.Threading.Thread.Sleep(200);
            //        return RedirectToAction("Index");
            //    }

            //    return RedirectToAction("Index");
            //}
       
            var model = new Customer_Entities();

            //TODO get person
            CUSTOMER Customer = new CUSTOMER();
            {
                //model.= id,
                // = "Sander",
                //Lastname = "Van Looveren"
            };

            return View("PersonForm", model);
        } 

        // GET: CUSTOMER/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMERs.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // GET: CUSTOMER/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CUSTOMER/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NAME,DESCRIPTION,STATUS")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMERs.Add(cUSTOMER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUSTOMER);
        }
       

        // GET: CUSTOMER/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id < 0 )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMERs.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // POST: CUSTOMER/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NAME,DESCRIPTION,STATUS")] CUSTOMER cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMER).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    //throw;
                }
                //dbc.SaveChanges();
                System.Threading.Thread.Sleep(200);
                return RedirectToAction("Index");
            }
            return View(cUSTOMER);
        }

        // GET: CUSTOMER/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMER cUSTOMER = db.CUSTOMERs.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // POST: CUSTOMER/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            CUSTOMER cUSTOMER = db.CUSTOMERs.Find(id);
            db.CUSTOMERs.Remove(cUSTOMER);
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
