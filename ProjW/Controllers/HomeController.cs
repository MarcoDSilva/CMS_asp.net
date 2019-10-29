using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjW.MyUtil;

namespace ProjW.Controllers
{
    public class HomeController : Controller
    {
        TarefasFuncs Funcs = new TarefasFuncs();

        // GET: Home
        public ActionResult Index()
        {
            ViewBag.horas = DateTime.Now.ToString("hh:mm");

            ViewBag.saudacao = Funcs.Saudacao();
            return View();
        }
    }
}