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
    public class LinhaDeTarefasController : Controller
    {
        private MarcoSilvaDbGesTarefas db = new MarcoSilvaDbGesTarefas();

        // GET: LinhaDeTarefas
        public ActionResult Index()
        {
            var tLinhasDeTarefa = db.TLinhasDeTarefa.Include(l => l.Tarefa);
            return View(tLinhasDeTarefa.ToList());
        }

        // GET: LinhaDeTarefas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaDeTarefa linhaDeTarefa = db.TLinhasDeTarefa.Find(id);
            if (linhaDeTarefa == null)
            {
                return HttpNotFound();
            }
            return View(linhaDeTarefa);
        }

        // GET: LinhaDeTarefas/Create
        public ActionResult Create()
        {
            ViewBag.TarefaId = new SelectList(db.TTarefas, "ID", "Titulo");
            return View();
        }

        // POST: LinhaDeTarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataDaLinha,Descritivo,TarefaId")] LinhaDeTarefa linhaDeTarefa)
        {
            if (ModelState.IsValid)
            {
                db.TLinhasDeTarefa.Add(linhaDeTarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TarefaId = new SelectList(db.TTarefas, "ID", "Titulo", linhaDeTarefa.TarefaId);
            return View(linhaDeTarefa);
        }

        // GET: LinhaDeTarefas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaDeTarefa linhaDeTarefa = db.TLinhasDeTarefa.Find(id);
            if (linhaDeTarefa == null)
            {
                return HttpNotFound();
            }
            ViewBag.TarefaId = new SelectList(db.TTarefas, "ID", "Titulo", linhaDeTarefa.TarefaId);
            return View(linhaDeTarefa);
        }

        // POST: LinhaDeTarefas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataDaLinha,Descritivo,TarefaId")] LinhaDeTarefa linhaDeTarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linhaDeTarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TarefaId = new SelectList(db.TTarefas, "ID", "Titulo", linhaDeTarefa.TarefaId);
            return View(linhaDeTarefa);
        }

        // GET: LinhaDeTarefas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LinhaDeTarefa linhaDeTarefa = db.TLinhasDeTarefa.Find(id);
            if (linhaDeTarefa == null)
            {
                return HttpNotFound();
            }
            return View(linhaDeTarefa);
        }

        // POST: LinhaDeTarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LinhaDeTarefa linhaDeTarefa = db.TLinhasDeTarefa.Find(id);
            db.TLinhasDeTarefa.Remove(linhaDeTarefa);
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
