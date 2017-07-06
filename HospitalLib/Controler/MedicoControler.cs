using HospitalModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLib.Controler
{
    public class MedicoControler
    {

        public HospitalContext ctx = new HospitalContext();
        public BancoControler bancoControl = new BancoControler();
        public AreaAtuacaoControler areaControl = new AreaAtuacaoControler();

        // Popula a base com um registro padrao
        public void PopularBase()
        {
            this.SalvarMedico(new Medico()
            {
                Nome = "Jonathan",
                Crm = "0000/PR",
                Cpf = "66422587708",
                Banco = bancoControl.getBanco("1"),
                AreaAtuacao = areaControl.getObjeto("1"),
                Turno = "Diurno",
                DataNasc = DateTime.Now,
            });
            this.SalvarMedico(new Medico()
            {
                Nome = "Rafael",
                Crm = "1234/PR",
                Cpf = "39415774924",
                Banco = bancoControl.getBanco("1"),
                AreaAtuacao = areaControl.getObjeto("2"),
                Turno = "Diurno",
                DataNasc = DateTime.Now,
            });
            this.SalvarMedico(new Medico()
            {
                Nome = "Alex",
                Crm = "5678/PR",
                Cpf = "64756648800",
                Banco = bancoControl.getBanco("1"),
                AreaAtuacao = areaControl.getObjeto("3"),
                Turno = "Noturno",
                DataNasc = DateTime.Now,
            });
            this.SalvarMedico(new Medico()
            {
                Nome = "Felipe",
                Crm = "0012/PR",
                Cpf = "86157455870",
                Banco = bancoControl.getBanco("1"),
                AreaAtuacao = areaControl.getObjeto("1"),
                Turno = "Noturno",
                DataNasc = DateTime.Now,
            });
            this.SalvarMedico(new Medico()
            {
                Nome = "R. Macedo",
                Crm = "1902/PR",
                Cpf = "47832433361",
                Banco = bancoControl.getBanco("1"),
                AreaAtuacao = areaControl.getObjeto("2"),
                Turno = "Diurno",
                DataNasc = DateTime.Now,
            });
            this.SalvarMedico(new Medico()
            {
                Nome = "Paulo",
                Crm = "0230/PR",
                Cpf = "31138544825",
                Banco = bancoControl.getBanco("1"),
                AreaAtuacao = areaControl.getObjeto("2"),
                Turno = "Madrugada",
                DataNasc = DateTime.Now,
            });
        }

        // Salva ou atualiza um objeto
        public void SalvarMedico(Medico medico)
        {
            try
            {
                // marca os attributos que são objetos como já existentes evitando a duplicação
                ctx.Entry(medico.Banco).State = System.Data.Entity.EntityState.Unchanged;
                ctx.Entry(medico.AreaAtuacao).State = System.Data.Entity.EntityState.Unchanged;

                if (medico.Id == 0)
                {
                    ctx.Medicos.Add(medico);
                }
                else
                {
                    var tempMedico = ctx.Medicos.SingleOrDefault(m => m.Id == medico.Id);
                    tempMedico.Id = medico.Id;
                    tempMedico.Crm = medico.Crm;
                    tempMedico.Nome = medico.Nome;
                    tempMedico.Cpf = medico.Cpf;
                    tempMedico.Telefone = medico.Telefone;
                    tempMedico.DataNasc = medico.DataNasc;
                    tempMedico.Turno = medico.Turno;
                    tempMedico.Banco = medico.Banco;
                    tempMedico.AreaAtuacao = medico.AreaAtuacao;
                }

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Util.HandleSQLDBException(ex);
            }
        }

        // remove um objeto
        public void RemoverMedico(Medico medico)
        {
            if (medico.Id != 0)
            {
                ctx.Medicos.Remove(ctx.Medicos.Single(m => m.Id == medico.Id));
                ctx.SaveChanges();
            }
        }

        // lista todos os registros
        public IList<Medico> ObterMedicos()
        {
            var medicos = from medico 
                          in ctx.Medicos.Include("Banco").Include("AreaAtuacao")
                          select medico;
            return medicos.ToList();
        }

        // busca um registro especifico
        public Medico getMedico(String StringID)
        {
            int id = int.Parse(StringID);
            var medicos = from medico
                          in ctx.Medicos.Include("Banco").Include("AreaAtuacao")
                          where medico.Id == id
                          select medico;

            return medicos.ToList().ElementAt(0);
        }
    }
}
