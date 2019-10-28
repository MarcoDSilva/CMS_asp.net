using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjW.DAL;
using ProjW.Models;

namespace ProjW.Controllers
{
    public class ApagaRegistosController : Controller
    {

        private MarcoSilvaDbGesTarefas db = new MarcoSilvaDbGesTarefas();
        
        // GET: ApagaRegistos
        public ActionResult Index(int? id_tarefa)
        {
            if(!id_tarefa.HasValue) {
                @ViewBag.teste = "Nenhum valor procurado, ou valor inválido.";
            } else {
                Tarefa testa = db.TTarefas.Find(id_tarefa);
               
                    if (testa != null) {
                        @ViewBag.teste = testa.ID + " foi apagado";
                        db.TTarefas.Remove(testa);
                        db.SaveChanges();
                    } else  {
                        @ViewBag.teste = "Registo não encontrado!";
                    }                
            }
            return View();
        }
    }
}