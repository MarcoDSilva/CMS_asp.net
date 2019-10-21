using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjW.Models
{
    public class TipoTarefa
    {
        public int Id { get; set; }

        [Display(Name = "Tipo de tarefa")]
        public string DesignacaoTipoTarefa { get; set; }

        public ICollection<Tarefa> Tarefas { get; set; }
    }
}