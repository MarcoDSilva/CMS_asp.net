using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjW.ViewModel;
using ProjW.DAL;

namespace ProjW.Controllers
{
    public class F_TarefasFuncs_MesController : Controller
    {
        private MarcoSilvaDbGesTarefas db = new MarcoSilvaDbGesTarefas();

        // GET: F_TarefasFuncs_Mes
        public ActionResult Index(int? id)
        {
            var viewModel = new FuncionarioTarefas();

            viewModel.Funcionarios = db.TFuncionarios;
            viewModel.Tarefas = db.TTarefas;

            if(id == null)  {
                ViewBag.id = 0;
            } else  {
                ViewBag.id = id;
            }

            return View(viewModel);
        }
    }
}