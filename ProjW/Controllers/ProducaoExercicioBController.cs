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
    public class ProducaoExercicioBController : Controller
    {
        private MarcoSilvaDbGesTarefas db = new MarcoSilvaDbGesTarefas();

        // GET: ProducaoExercicioB
        public ActionResult Index(int? idTipoTarefa, int? idTipoPrioridade)
        {
            //cria uma lista para as tarefas e as prioridades
            List <TipoTarefa> tarefas = db.TTiposTarefas.ToList();
            List<TipoPrioridade> prioridades = db.TTipoPrioridades.ToList();

            //filtrar as listas e passa os dados para uma select list, a qual vai ser passada para as drop down
            SelectList listTarefas = new SelectList(tarefas, "Id", "DesignacaoTipoTarefa");
            SelectList listPrioridades = new SelectList(prioridades, "Id", "DesignacaoPrioridade");

            //viewbags que vão passar a informação para as drop downs na view
            ViewBag.tarefas = listTarefas;
            ViewBag.prioridades = listPrioridades;

            //filtrar as tarefas consoante as combos
            int prioridadeID = 0;
            int tarefaID = 0;

            if(idTipoPrioridade.HasValue) {
                prioridadeID = (int)idTipoPrioridade;
            }

            if(idTipoTarefa.HasValue)  {
                tarefaID = (int)idTipoTarefa;
            }
            
            //pesquisa as tarefas com os ids já verificados e devolve a quantidade para a viewbag
            var filtraTarefas = db.TTarefas.Where(a => a.TipoTarefaID == tarefaID && a.TipoPrioridadeId == prioridadeID).Count();

            ViewBag.quantidade = filtraTarefas.ToString();

            return View();
        }
    }
}
