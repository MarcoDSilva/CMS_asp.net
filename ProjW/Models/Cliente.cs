using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjW.Models
{
    public class Cliente
    {
        public int Id { get; set; } 
        public string NomeCliente { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }
}