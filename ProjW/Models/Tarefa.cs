using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjW.Models
{
    public class Tarefa
    {
        public int ID { get; set; }

        [Display(Name = "Título")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição Tarefa")]
        public string DescritivoTarefa { get; set; }

        [Display(Name = "Tarefa")]
        public int TipoTarefaID { get; set; }
        public virtual TipoTarefa TipoTarefa { get; set; }

        public int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; } //connecta

        public int FuncionarioId { get; set; }
        public virtual Funcionario Funcionario { get; set; } //connecta

        [Display(Name = "Equipa")]
        public string Equipa { get; set; }

        [Display(Name = "Data Registo")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataRegisto { get; set; }

        [Display(Name = "Data Limite")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataLimite { get; set; }

        [Display(Name = "Coima")]
        public bool SujeitaCoima { get; set; }

        [Display(Name = "Prioridade")]
        public string TipoPrioridadeId { get; set; }
        public virtual TipoPrioridade TipoPrioridade { get; set; }

        public bool Estado { get; set; }

        public ICollection<LinhaDeTarefa> LinhaDeTarefas { get; set; }

  
    }
}