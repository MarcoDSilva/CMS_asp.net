using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjW.Models;
using ProjW.DAL;

namespace ProjW.Controllers
{
    public class ApagarRegistosComConfirmacaoController : Controller
    {
        private MarcoSilvaDbGesTarefas db = new MarcoSilvaDbGesTarefas();

        // GET: ApagarRegistosComConfirmacao
        public ActionResult Index(int? id_tarefa)
        {
            Tarefa testa = null;

            if (!id_tarefa.HasValue) {
                @ViewBag.teste = "Nenhum valor procurado, ou valor inválido.";
            }
            else  {
                testa = db.TTarefas.Find(id_tarefa);

                if (testa != null)  {
                    @ViewBag.verifica = 1;
                    @ViewBag.lista = testa;
                    //@ViewBag.teste = db.TTarefas.Find(id_tarefa).ID + " foi apagado";
                    //db.TTarefas.Remove(testa);
                    //db.SaveChanges();
                }
                else  {
                    @ViewBag.teste = "Registo não encontrado!";
                    @ViewBag.verifica = 0;
                }
            }
            return View();
        }
    }
}