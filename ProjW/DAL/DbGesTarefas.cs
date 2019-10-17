using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjW.Models;
using System.Data.Entity;

namespace ProjW.DAL
{
    public class DbGesTarefas : DbContext
    {
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}