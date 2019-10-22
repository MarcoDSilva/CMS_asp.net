namespace ProjW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeCliente = c.String(),
                        CodigoInternoCliente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        DescritivoTarefa = c.String(),
                        TipoTarefaID = c.Int(nullable: false),
                        ClienteId = c.Int(nullable: false),
                        FuncionarioId = c.Int(nullable: false),
                        Equipa = c.String(),
                        DataRegisto = c.DateTime(nullable: false),
                        DataLimite = c.DateTime(nullable: false),
                        SujeitaCoima = c.Boolean(nullable: false),
                        TipoPrioridadeId = c.String(),
                        Estado = c.Boolean(nullable: false),
                        TipoPrioridade_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Funcionarios", t => t.FuncionarioId, cascadeDelete: true)
                .ForeignKey("dbo.TipoPrioridades", t => t.TipoPrioridade_Id)
                .ForeignKey("dbo.TipoTarefas", t => t.TipoTarefaID, cascadeDelete: true)
                .Index(t => t.TipoTarefaID)
                .Index(t => t.ClienteId)
                .Index(t => t.FuncionarioId)
                .Index(t => t.TipoPrioridade_Id);
            
            CreateTable(
                "dbo.Funcionarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomeFuncionario = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LinhaDeTarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataDaLinha = c.DateTime(nullable: false),
                        Tarefa_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tarefas", t => t.Tarefa_ID)
                .Index(t => t.Tarefa_ID);
            
            CreateTable(
                "dbo.TipoPrioridades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignacaoPrioridade = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoTarefas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DesignacaoTipoTarefa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "TipoTarefaID", "dbo.TipoTarefas");
            DropForeignKey("dbo.Tarefas", "TipoPrioridade_Id", "dbo.TipoPrioridades");
            DropForeignKey("dbo.LinhaDeTarefas", "Tarefa_ID", "dbo.Tarefas");
            DropForeignKey("dbo.Tarefas", "FuncionarioId", "dbo.Funcionarios");
            DropForeignKey("dbo.Tarefas", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.LinhaDeTarefas", new[] { "Tarefa_ID" });
            DropIndex("dbo.Tarefas", new[] { "TipoPrioridade_Id" });
            DropIndex("dbo.Tarefas", new[] { "FuncionarioId" });
            DropIndex("dbo.Tarefas", new[] { "ClienteId" });
            DropIndex("dbo.Tarefas", new[] { "TipoTarefaID" });
            DropTable("dbo.TipoTarefas");
            DropTable("dbo.TipoPrioridades");
            DropTable("dbo.LinhaDeTarefas");
            DropTable("dbo.Funcionarios");
            DropTable("dbo.Tarefas");
            DropTable("dbo.Clientes");
        }
    }
}
