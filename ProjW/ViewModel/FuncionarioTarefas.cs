using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjW.Models;

namespace ProjW.ViewModel
{
    public class FuncionarioTarefas
    {
        public IEnumerable<Funcionario> Funcionarios { get; set; }
        public IEnumerable<Tarefa> Tarefas { get; set; }
    }
}