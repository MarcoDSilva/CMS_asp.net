namespace ProjW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fourth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LinhaDeTarefas", "Tarefa_ID", "dbo.Tarefas");
            DropIndex("dbo.LinhaDeTarefas", new[] { "Tarefa_ID" });
            RenameColumn(table: "dbo.LinhaDeTarefas", name: "Tarefa_ID", newName: "TarefaId");
            AlterColumn("dbo.LinhaDeTarefas", "TarefaId", c => c.Int(nullable: false));
            CreateIndex("dbo.LinhaDeTarefas", "TarefaId");
            AddForeignKey("dbo.LinhaDeTarefas", "TarefaId", "dbo.Tarefas", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LinhaDeTarefas", "TarefaId", "dbo.Tarefas");
            DropIndex("dbo.LinhaDeTarefas", new[] { "TarefaId" });
            AlterColumn("dbo.LinhaDeTarefas", "TarefaId", c => c.Int());
            RenameColumn(table: "dbo.LinhaDeTarefas", name: "TarefaId", newName: "Tarefa_ID");
            CreateIndex("dbo.LinhaDeTarefas", "Tarefa_ID");
            AddForeignKey("dbo.LinhaDeTarefas", "Tarefa_ID", "dbo.Tarefas", "ID");
        }
    }
}
