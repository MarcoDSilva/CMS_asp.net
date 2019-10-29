using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjW.MyUtil;
using ProjW.DAL;

namespace ProjW.Controllers
{
    public class ContaRegistosController : Controller
    {
        MarcoSilvaDbGesTarefas db = new MarcoSilvaDbGesTarefas();

        // GET: ContaRegistos
        public ActionResult Index()
        {
            StringConnection connection = new StringConnection();
            string query = "select count(*) from tarefas";

            ViewBag.registos = connection.ContaRegistos(connection.getSConnection(), query).Rows[0][0];


            return View();
        }
    }
}