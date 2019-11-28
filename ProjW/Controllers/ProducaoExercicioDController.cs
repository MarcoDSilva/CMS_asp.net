using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjW.ViewModel;
using ProjW.DAL;

namespace ProjW.Controllers
{
    public class ProducaoExercicioDController : Controller
    {
        private MarcoSilvaDbGesTarefas db = new MarcoSilvaDbGesTarefas();

        // GET: ProducaoExercicioD
        public ActionResult Index(int? id)
        {
            //view model com tabela cliente e tarefas
            var viewModel = new ClientesTarefas();

            //verifica se o id é nulo, ou recebeu valor, para condicional na view
            if (id == null) {
                ViewBag.id = 0;
            }
            else {
                ViewBag.id = id;
            }

            //passa as tabelas correspondentes à viewmodel
            viewModel.Clientes = db.TClientes;
            viewModel.Tarefas = db.TTarefas.Where(a => a.ClienteId == id );

            return View(viewModel);
        }
    }
}