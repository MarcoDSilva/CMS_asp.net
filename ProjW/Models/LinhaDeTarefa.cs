using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjW.Models
{
    public class LinhaDeTarefa
    {
        public int Id { get; set; }

        [Display(Name = "Data da linha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime DataDaLinha { get; set; }

        public string Descritivo;        
        public virtual Tarefa Tarefa { get; set; }
    }
}