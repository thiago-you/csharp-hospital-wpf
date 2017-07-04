namespace HospitalLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao207 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pacientes", "Id", "dbo.Convenios");
            DropIndex("dbo.Pacientes", new[] { "Id" });
            AddColumn("dbo.Pacientes", "Convenio_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Pacientes", "Convenio_Id");
            AddForeignKey("dbo.Pacientes", "Convenio_Id", "dbo.Convenios", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pacientes", "Convenio_Id", "dbo.Convenios");
            DropIndex("dbo.Pacientes", new[] { "Convenio_Id" });
            DropColumn("dbo.Pacientes", "Convenio_Id");
            CreateIndex("dbo.Pacientes", "Id");
            AddForeignKey("dbo.Pacientes", "Id", "dbo.Convenios", "Id");
        }
    }
}
