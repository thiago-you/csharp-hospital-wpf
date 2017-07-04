namespace HospitalLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao208 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Consultas", "Id", "dbo.Agendamentoes");
            DropIndex("dbo.Consultas", new[] { "Id" });
            AddColumn("dbo.Consultas", "Agendamento_Id", c => c.Int());
            CreateIndex("dbo.Consultas", "Agendamento_Id");
            AddForeignKey("dbo.Consultas", "Agendamento_Id", "dbo.Agendamentoes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consultas", "Agendamento_Id", "dbo.Agendamentoes");
            DropIndex("dbo.Consultas", new[] { "Agendamento_Id" });
            DropColumn("dbo.Consultas", "Agendamento_Id");
            CreateIndex("dbo.Consultas", "Id");
            AddForeignKey("dbo.Consultas", "Id", "dbo.Agendamentoes", "Id");
        }
    }
}
