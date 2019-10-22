using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjW.Models
{
    public class TipoPrioridade
    {
        public int Id { get; set; }

        [Display(Name = "Nível de Prioridade")]
        public string DesignacaoPrioridade { get; set; }  
        
        public ICollection<Tarefa> Tarefas { get; set; }
    }
}