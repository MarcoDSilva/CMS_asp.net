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
    public class FiltrarTarefasController : Controller
    {
        private MarcoSilvaDbGesTarefas db = new MarcoSilvaDbGesTarefas();

        // GET: FiltrarTarefas
        public ActionResult Index(int? idDropList)
        {
            //a tabela clientes é passada para uma lista
            List<Cliente> clientes = db.TClientes.ToList();

            //essa lista é filtrada para uma SelectList , que recebe como argumento o Id e o Nome do cliente dessa mesma tabela
            SelectList listItems = new SelectList(clientes, "Id", "NomeCliente");

            //a viewbag recebe a selectedlist, a qual recebe typecast razor da dropdownlist
            ViewBag.Clientes = listItems;

            if(!idDropList.HasValue) {
                ViewBag.Id = "none";
            } else  {
                  ViewBag.Id = idDropList;
            }

            //filtra a lista de tarefas  consoante o id do cliente e o id que vem da droplist
            var tTarefas = db.TTarefas.Where(element => element.Cliente.Id == idDropList);

            ViewBag.LINHAS = tTarefas.Count();

            return View(tTarefas.ToList());
        }

        // GET: FiltrarTarefas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.TTarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // GET: FiltrarTarefas/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.TClientes, "Id", "NomeCliente");
            ViewBag.FuncionarioId = new SelectList(db.TFuncionarios, "Id", "NomeFuncionario");
            ViewBag.TipoPrioridadeId = new SelectList(db.TTipoPrioridades, "Id", "DesignacaoPrioridade");
            ViewBag.TipoTarefaID = new SelectList(db.TTiposTarefas, "Id", "DesignacaoTipoTarefa");
            return View();
        }

        // POST: FiltrarTarefas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Titulo,DescritivoTarefa,TipoTarefaID,ClienteId,FuncionarioId,Equipa,DataRegisto,DataLimite,SujeitaCoima,TipoPrioridadeId,Estado")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.TTarefas.Add(tarefa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.TClientes, "Id", "NomeCliente", tarefa.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.TFuncionarios, "Id", "NomeFuncionario", tarefa.FuncionarioId);
            ViewBag.TipoPrioridadeId = new SelectList(db.TTipoPrioridades, "Id", "DesignacaoPrioridade", tarefa.TipoPrioridadeId);
            ViewBag.TipoTarefaID = new SelectList(db.TTiposTarefas, "Id", "DesignacaoTipoTarefa", tarefa.TipoTarefaID);
            return View(tarefa);
        }

        // GET: FiltrarTarefas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.TTarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.TClientes, "Id", "NomeCliente", tarefa.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.TFuncionarios, "Id", "NomeFuncionario", tarefa.FuncionarioId);
            ViewBag.TipoPrioridadeId = new SelectList(db.TTipoPrioridades, "Id", "DesignacaoPrioridade", tarefa.TipoPrioridadeId);
            ViewBag.TipoTarefaID = new SelectList(db.TTiposTarefas, "Id", "DesignacaoTipoTarefa", tarefa.TipoTarefaID);
            return View(tarefa);
        }

        // POST: FiltrarTarefas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Titulo,DescritivoTarefa,TipoTarefaID,ClienteId,FuncionarioId,Equipa,DataRegisto,DataLimite,SujeitaCoima,TipoPrioridadeId,Estado")] Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tarefa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.TClientes, "Id", "NomeCliente", tarefa.ClienteId);
            ViewBag.FuncionarioId = new SelectList(db.TFuncionarios, "Id", "NomeFuncionario", tarefa.FuncionarioId);
            ViewBag.TipoPrioridadeId = new SelectList(db.TTipoPrioridades, "Id", "DesignacaoPrioridade", tarefa.TipoPrioridadeId);
            ViewBag.TipoTarefaID = new SelectList(db.TTiposTarefas, "Id", "DesignacaoTipoTarefa", tarefa.TipoTarefaID);
            return View(tarefa);
        }

        // GET: FiltrarTarefas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tarefa tarefa = db.TTarefas.Find(id);
            if (tarefa == null)
            {
                return HttpNotFound();
            }
            return View(tarefa);
        }

        // POST: FiltrarTarefas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tarefa tarefa = db.TTarefas.Find(id);
            db.TTarefas.Remove(tarefa);
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
