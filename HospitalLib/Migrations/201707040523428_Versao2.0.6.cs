namespace HospitalLib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Versao206 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agendamentoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DataAgendada = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicos", t => t.Id)
                .ForeignKey("dbo.Pacientes", t => t.Id)
                .ForeignKey("dbo.Secretarias", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Consultas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        PrecoTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Medico_Id = c.Int(nullable: false),
                        Paciente_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicos", t => t.Medico_Id, cascadeDelete: true)
                .ForeignKey("dbo.Pacientes", t => t.Paciente_Id, cascadeDelete: true)
                .ForeignKey("dbo.Agendamentoes", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Medico_Id)
                .Index(t => t.Paciente_Id);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Crm = c.String(nullable: false, maxLength: 15),
                        Turno = c.String(nullable: false),
                        Nome = c.String(nullable: false),
                        Cpf = c.String(),
                        DataNasc = c.DateTime(),
                        Telefone = c.String(),
                        AreaAtuacao_Id = c.Int(nullable: false),
                        Banco_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AreaAtuacaos", t => t.AreaAtuacao_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bancoes", t => t.Banco_Id)
                .Index(t => t.AreaAtuacao_Id)
                .Index(t => t.Banco_Id);
            
            CreateTable(
                "dbo.AreaAtuacaos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Area = c.String(nullable: false, maxLength: 100),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bancoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Conta = c.String(nullable: false, maxLength: 10),
                        Agencia = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cpf = c.String(),
                        DataNasc = c.DateTime(),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Convenios", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Convenios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NomePlano = c.String(nullable: false, maxLength: 100),
                        NomeEmpresa = c.String(nullable: false, maxLength: 100),
                        Telefone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Secretarias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Cpf = c.String(),
                        DataNasc = c.DateTime(),
                        Telefone = c.String(),
                        Banco_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bancoes", t => t.Banco_Id)
                .Index(t => t.Banco_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Secretarias", "Banco_Id", "dbo.Bancoes");
            DropForeignKey("dbo.Agendamentoes", "Id", "dbo.Secretarias");
            DropForeignKey("dbo.Consultas", "Id", "dbo.Agendamentoes");
            DropForeignKey("dbo.Consultas", "Paciente_Id", "dbo.Pacientes");
            DropForeignKey("dbo.Pacientes", "Id", "dbo.Convenios");
            DropForeignKey("dbo.Agendamentoes", "Id", "dbo.Pacientes");
            DropForeignKey("dbo.Consultas", "Medico_Id", "dbo.Medicos");
            DropForeignKey("dbo.Medicos", "Banco_Id", "dbo.Bancoes");
            DropForeignKey("dbo.Medicos", "AreaAtuacao_Id", "dbo.AreaAtuacaos");
            DropForeignKey("dbo.Agendamentoes", "Id", "dbo.Medicos");
            DropIndex("dbo.Secretarias", new[] { "Banco_Id" });
            DropIndex("dbo.Pacientes", new[] { "Id" });
            DropIndex("dbo.Medicos", new[] { "Banco_Id" });
            DropIndex("dbo.Medicos", new[] { "AreaAtuacao_Id" });
            DropIndex("dbo.Consultas", new[] { "Paciente_Id" });
            DropIndex("dbo.Consultas", new[] { "Medico_Id" });
            DropIndex("dbo.Consultas", new[] { "Id" });
            DropIndex("dbo.Agendamentoes", new[] { "Id" });
            DropTable("dbo.Secretarias");
            DropTable("dbo.Convenios");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Bancoes");
            DropTable("dbo.AreaAtuacaos");
            DropTable("dbo.Medicos");
            DropTable("dbo.Consultas");
            DropTable("dbo.Agendamentoes");
        }
    }
}
