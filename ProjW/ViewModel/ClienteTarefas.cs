﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjW.Models;

namespace ProjW.ViewModel
{
    public class ClienteTarefas
    {
        public IEnumerable<TipoPrioridade> Prioridades { get; set; }

        public IEnumerable<Cliente> Clientes { get; set; }
        public IEnumerable<Tarefa> Tarefas { get; set; }
        
    }
}