namespace HospitalLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao2011 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agendamentoes", "Id", "dbo.Pacientes");
            DropForeignKey("dbo.Agendamentoes", "Id", "dbo.Secretarias");
            AddColumn("dbo.Agendamentoes", "Paciente_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Agendamentoes", "Secretaria_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Agendamentoes", "Paciente_Id");
            CreateIndex("dbo.Agendamentoes", "Secretaria_Id");
            AddForeignKey("dbo.Agendamentoes", "Paciente_Id", "dbo.Pacientes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Agendamentoes", "Secretaria_Id", "dbo.Secretarias", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agendamentoes", "Secretaria_Id", "dbo.Secretarias");
            DropForeignKey("dbo.Agendamentoes", "Paciente_Id", "dbo.Pacientes");
            DropIndex("dbo.Agendamentoes", new[] { "Secretaria_Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Paciente_Id" });
            DropColumn("dbo.Agendamentoes", "Secretaria_Id");
            DropColumn("dbo.Agendamentoes", "Paciente_Id");
            AddForeignKey("dbo.Agendamentoes", "Id", "dbo.Secretarias", "Id");
            AddForeignKey("dbo.Agendamentoes", "Id", "dbo.Pacientes", "Id");
        }
    }
}
