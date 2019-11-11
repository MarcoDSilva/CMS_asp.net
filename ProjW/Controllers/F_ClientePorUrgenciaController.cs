using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjW.DAL;
using System.Web.Mvc;
using ProjW.ViewModel;

namespace ProjW.Controllers
{
    public class F_ClientePorUrgenciaController : Controller
    {
        //conexão à bd
        public MarcoSilvaDbGesTarefas db = new MarcoSilvaDbGesTarefas(); 

        // GET: F_ClientePorUrgencia
        public ActionResult Index(int? id)
        {
            //variavel que vai conectar a ViewModel
            var viewModel = new ClienteTarefas();

            if(id == null)
            {
                ViewBag.id = 0;
            } else
            {
                ViewBag.id = id;
            }
            
            //connecta a viewModel com as tabelas correspondentes
            viewModel.Tarefas = db.TTarefas.Where(a => a.TipoPrioridade.DesignacaoPrioridade == "Urgente" && a.ClienteId == id);
            viewModel.Clientes = db.TClientes;
            viewModel.Prioridades = db.TTipoPrioridades;

            return View(viewModel);
        }
    }
}