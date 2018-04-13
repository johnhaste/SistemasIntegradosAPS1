using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.DAO;

namespace Web.Controllers
{
    public class EnderecosController : Controller
    {
        private Entities db = new Entities();

        // GET: Enderecos
        public ActionResult Index()
        {
            var enderecos = db.Enderecos.Include(e => e.Clientes);
            return View(enderecos.ToList());
        }

        // GET: Enderecos/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enderecos enderecos = db.Enderecos.Find(id);
            if (enderecos == null)
            {
                return HttpNotFound();
            }
            return View(enderecos);
        }

        // GET: Enderecos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome");
            return View();
        }

        // POST: Enderecos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteID,EnderecoID,Rua,Cidade,Estado")] Enderecos enderecos)
        {
            if (ModelState.IsValid)
            {
                enderecos.ClienteID = Guid.NewGuid();
                db.Enderecos.Add(enderecos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", enderecos.ClienteID);
            return View(enderecos);
        }

        // GET: Enderecos/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enderecos enderecos = db.Enderecos.Find(id);
            if (enderecos == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", enderecos.ClienteID);
            return View(enderecos);
        }

        // POST: Enderecos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteID,EnderecoID,Rua,Cidade,Estado")] Enderecos enderecos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(enderecos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", enderecos.ClienteID);
            return View(enderecos);
        }

        // GET: Enderecos/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Enderecos enderecos = db.Enderecos.Find(id);
            if (enderecos == null)
            {
                return HttpNotFound();
            }
            return View(enderecos);
        }

        // POST: Enderecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Enderecos enderecos = db.Enderecos.Find(id);
            db.Enderecos.Remove(enderecos);
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
