namespace HospitalLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Medicos", "DataNasc", c => c.DateTime());
            AlterColumn("dbo.Pacientes", "DataNasc", c => c.DateTime());
            AlterColumn("dbo.Secretarias", "DataNasc", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Secretarias", "DataNasc", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pacientes", "DataNasc", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Medicos", "DataNasc", c => c.DateTime(nullable: false));
        }
    }
}
