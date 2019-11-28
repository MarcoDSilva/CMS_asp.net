using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjW.DAL;
using ProjW.Models;

namespace ProjW.Controllers
{
    public class ProducaoExercicioCController : Controller
    {
        private MarcoSilvaDbGesTarefas db = new MarcoSilvaDbGesTarefas();

        // GET: ProducaoExercicioC
        public ActionResult Index(int? idDropCliente, int? idDropFuncionario, string ordena)
        {
            //a tabela clientes é passada para uma lista
            List<Cliente> clientes = db.TClientes.ToList();
            List<Funcionario> funcionarios = db.TFuncionarios.ToList();

            //essa lista é filtrada para uma SelectList , que recebe como argumento o Id e o Nome do cliente dessa mesma tabela
            SelectList listItemsClientes = new SelectList(clientes, "Id", "NomeCliente");
            SelectList listItemsFuncionarios = new SelectList(funcionarios, "Id", "NomeFuncionario");

            //a viewbag recebe a selectedlist, a qual recebe typecast razor da dropdownlist
            ViewBag.Clientes = listItemsClientes;
            ViewBag.Funcionarios = listItemsFuncionarios;

            int clienteID = 0;
            int funcionarioID = 0;

            //verifica se os IDs tem valor, caso contrário ficam a 0
            if (idDropCliente.HasValue)
            {
                clienteID = (int)idDropCliente;
            }

            if(idDropFuncionario.HasValue)
            {
                funcionarioID = (int)idDropFuncionario;
            }

            //filtra a lista de tarefas  consoante o id do cliente e o id que vem da droplist
            var tTarefas = db.TTarefas.Where(element => element.Cliente.Id == clienteID
                                            && element.Funcionario.Id == funcionarioID);

            //verifica os radio buttons, e se tiverem sido selecionados, filtra a lista segundo a escolha
            if (!string.IsNullOrEmpty(ordena))
            {
                if(ordena.Equals("crescente")) {
                    tTarefas = db.TTarefas.OrderBy(a => a.ID);
                }
                else if (ordena.Equals("decrescente")) {
                    tTarefas = db.TTarefas.OrderByDescending(a => a.ID);
                }
            }
            return View(tTarefas.ToList());
        }
    }
}