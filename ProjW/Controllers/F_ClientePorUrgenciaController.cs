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
        public ActionResult Index(int? id, string data_inicio, string data_final)
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

            DateTime inicio;
            DateTime final;                    
            
            try {
                inicio = DateTime.Parse(data_inicio);
                final = DateTime.Parse(data_final);
                ViewBag.datinha = inicio.Month;
                ViewBag.final = final.Month;
            } catch (Exception)
            {
                //valores teste para evitar datas nulas na pesquisa
                inicio = DateTime.Parse("01/01/1900");
                final = DateTime.Parse("31/12/2100");
            }

            //connecta a viewModel com as tabelas correspondentes
            viewModel.Tarefas = db.TTarefas.Where(a => a.TipoPrioridade.DesignacaoPrioridade == "Urgente" && a.ClienteId == id
                                 &&(a.DataLimite.Year >= inicio.Year && a.DataLimite.Year <= final.Year 
                                    && a.DataLimite.Month >= inicio.Month && a.DataLimite.Month <= final.Month));

            viewModel.Clientes = db.TClientes;
            viewModel.Prioridades = db.TTipoPrioridades;




            return View(viewModel);
        }
    }
}