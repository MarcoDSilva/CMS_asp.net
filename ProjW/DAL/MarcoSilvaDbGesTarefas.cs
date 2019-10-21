using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjW.Models;
using System.Data.Entity;

namespace ProjW.DAL
{
    public class MarcoSilvaDbGesTarefas : DbContext
    {
        public DbSet<Tarefa> TTarefas { get; set; }

        public DbSet<LinhaDeTarefa> TLinhasDeTarefa { get; set; }

        public DbSet<Cliente> TClientes { get; set; }

        public DbSet<Funcionario> TFuncionarios { get; set; }

        public DbSet<TipoTarefa> TTiposTarefas { get; set; }

        public DbSet<TipoPrioridade> TTipoPrioridades { get; set; }

    }
}