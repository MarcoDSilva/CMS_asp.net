using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjW.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string NomeFuncionario { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }
}