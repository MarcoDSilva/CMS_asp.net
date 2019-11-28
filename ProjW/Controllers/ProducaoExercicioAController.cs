using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjW.DAL;
using ProjW.Models;

namespace ProjW.Controllers
{
    public class ProducaoExercicioAController : Controller
    {
        private MarcoSilvaDbGesTarefas database = new MarcoSilvaDbGesTarefas();

        // GET: ProducaoExercicioA
        public ActionResult Index(int? id_tarefa)
        {
            /*
             * se o id_tarefa tiver valor
             * procuramos:  a linha que corresponde ao id enviado
             *              o ID da tarefa que contém essa linha
             *              e contamos as linhas que existem nessa tarefa
             * Se existir mais que 1 linha, procedemos ao apagamento dessa linha
             * As viewbags são actualizadas para passar informação para a view
             */

            if (id_tarefa.HasValue) {
                try {
                    var linhasID = database.TLinhasDeTarefa.Where(l => l.Id == id_tarefa);
                    var tarefa = linhasID.First().TarefaId;
                    var contaLinhas = database.TLinhasDeTarefa.Where(t => t.TarefaId == tarefa).Count();
                    ViewBag.linhas = contaLinhas;
                    ViewBag.tarefa = tarefa;
                    ViewBag.idLinha = id_tarefa;

                    if (contaLinhas > 1) {       
                        ViewBag.linhasNovas = contaLinhas - 1;

                        LinhaDeTarefa linha = database.TLinhasDeTarefa.Find(id_tarefa);
                        database.TLinhasDeTarefa.Remove(linha);
                        database.SaveChanges();
                    }
                }
                catch (Exception) {
                    ViewBag.aviso = "Não encontrado";
                }
            } else  {
                ViewBag.aviso = "Valor não introduzido";
            }
           
            return View();
        }
    }
}