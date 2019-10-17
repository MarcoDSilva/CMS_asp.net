﻿using System;
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
        public string TipoImportancia { get; set; }

        public string Descritivo { get; set; }

        public bool Estado { get; set; }

        public int ClienteID { get; set; }
        public virtual Cliente Cliente { get; set; }
    }
}