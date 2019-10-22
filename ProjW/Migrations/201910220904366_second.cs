namespace ProjW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Tarefas", "TipoPrioridade_Id", "dbo.TipoPrioridades");
            DropIndex("dbo.Tarefas", new[] { "TipoPrioridade_Id" });
            DropColumn("dbo.Tarefas", "TipoPrioridadeId");
            RenameColumn(table: "dbo.Tarefas", name: "TipoPrioridade_Id", newName: "TipoPrioridadeId");
            AlterColumn("dbo.Tarefas", "TipoPrioridadeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Tarefas", "TipoPrioridadeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tarefas", "TipoPrioridadeId");
            AddForeignKey("dbo.Tarefas", "TipoPrioridadeId", "dbo.TipoPrioridades", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "TipoPrioridadeId", "dbo.TipoPrioridades");
            DropIndex("dbo.Tarefas", new[] { "TipoPrioridadeId" });
            AlterColumn("dbo.Tarefas", "TipoPrioridadeId", c => c.Int());
            AlterColumn("dbo.Tarefas", "TipoPrioridadeId", c => c.String());
            RenameColumn(table: "dbo.Tarefas", name: "TipoPrioridadeId", newName: "TipoPrioridade_Id");
            AddColumn("dbo.Tarefas", "TipoPrioridadeId", c => c.String());
            CreateIndex("dbo.Tarefas", "TipoPrioridade_Id");
            AddForeignKey("dbo.Tarefas", "TipoPrioridade_Id", "dbo.TipoPrioridades", "Id");
        }
    }
}
