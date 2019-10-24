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
    public class FiltrarLinhasDeTarefaController : Controller
    {
        private MarcoSilvaDbGesTarefas db = new MarcoSilvaDbGesTarefas();

        // GET: FiltrarLinhasDeTarefa
        public ActionResult Index(int? busca)
        {
            if(busca.HasValue)  {
                ViewBag.pesquisa = busca;
            } else            {
                ViewBag.pesquisa = "null";
            }


            var tLinhasDeTarefa = db.TLinhasDeTarefa.Where(inc => inc.TarefaId == busca);
            //var tLinhasDeTarefa = db.TLinhasDeTarefa.Include(l => l.Tarefa);
            return View(tLinhasDeTarefa.ToList());
        }

        // GET: FiltrarLinhasDeTarefa/Details/5
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

        // GET: FiltrarLinhasDeTarefa/Create
        public ActionResult Create()
        {
            ViewBag.TarefaId = new SelectList(db.TTarefas, "ID", "Titulo");
            return View();
        }

        // POST: FiltrarLinhasDeTarefa/Create
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

        // GET: FiltrarLinhasDeTarefa/Edit/5
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

        // POST: FiltrarLinhasDeTarefa/Edit/5
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

        // GET: FiltrarLinhasDeTarefa/Delete/5
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

        // POST: FiltrarLinhasDeTarefa/Delete/5
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
