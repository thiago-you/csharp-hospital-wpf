namespace HospitalLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao2012 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agendamentoes", "Id", "dbo.Medicos");
            DropIndex("dbo.Agendamentoes", new[] { "Id" });
            AddColumn("dbo.Agendamentoes", "Medico_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Agendamentoes", "Medico_Id");
            AddForeignKey("dbo.Agendamentoes", "Medico_Id", "dbo.Medicos", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamentoes", "Medico_Id", "dbo.Medicos");
            DropIndex("dbo.Agendamentoes", new[] { "Medico_Id" });
            DropColumn("dbo.Agendamentoes", "Medico_Id");
            CreateIndex("dbo.Agendamentoes", "Id");
            AddForeignKey("dbo.Agendamentoes", "Id", "dbo.Medicos", "Id");
        }
    }
}
