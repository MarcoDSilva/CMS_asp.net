using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjW.DAL;
using ProjW.Models;

namespace ProjW.Controllers
{
    public class TipoTarefasController : Controller
    {
        private MarcoSilvaDbGesTarefas db = new MarcoSilvaDbGesTarefas();

        // GET: TipoTarefas
        public ActionResult Index()
        {
            return View(db.TTiposTarefas.ToList());
        }

        // GET: TipoTarefas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTarefa tipoTarefa = db.TTiposTarefas.Find(id);
            if (tipoTarefa == null)
            {
                return HttpNotFound();
            }
            return View(tipoTarefa);
        }

        // GET: TipoTarefas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoTarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DesignacaoTipoTarefa")] TipoTarefa tipoTarefa)
        {
            if (ModelState.IsValid)
            {
                db.TTiposTarefas.Add(tipoTarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoTarefa);
        }

        // GET: TipoTarefas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTarefa tipoTarefa = db.TTiposTarefas.Find(id);
            if (tipoTarefa == null)
            {
                return HttpNotFound();
            }
            return View(tipoTarefa);
        }

        // POST: TipoTarefas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DesignacaoTipoTarefa")] TipoTarefa tipoTarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoTarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoTarefa);
        }

        // GET: TipoTarefas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoTarefa tipoTarefa = db.TTiposTarefas.Find(id);
            if (tipoTarefa == null)
            {
                return HttpNotFound();
            }
            return View(tipoTarefa);
        }

        // POST: TipoTarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoTarefa tipoTarefa = db.TTiposTarefas.Find(id);
            db.TTiposTarefas.Remove(tipoTarefa);
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
