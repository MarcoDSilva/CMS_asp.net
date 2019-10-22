namespace ProjW.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LinhaDeTarefas", "Descritivo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LinhaDeTarefas", "Descritivo");
        }
    }
}
