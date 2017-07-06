using HospitalModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLib.Controler
{
    public class PacienteControler
    {
        public HospitalContext ctx = new HospitalContext();
        public ConvenioControler convenioControl = new ConvenioControler();

        // Popula a base com um registro padrao
        public void PopularBase()
        {
            this.SalvarObjeto(new Paciente()
            {
                Nome = "João",
                Convenio = convenioControl.getObjeto("1"),
                DataNasc = DateTime.Now,
                Cpf = "15744413375",
            });
            this.SalvarObjeto(new Paciente()
            {
                Nome = "Leonardo",
                Convenio = convenioControl.getObjeto("1"),
                DataNasc = DateTime.Now,
                Cpf = "87794774888",
            });
            this.SalvarObjeto(new Paciente()
            {
                Nome = "Victor",
                Convenio = convenioControl.getObjeto("1"),
                DataNasc = DateTime.Now,
                Cpf = "01183772130",
            });
            this.SalvarObjeto(new Paciente()
            {
                Nome = "Celestino",
                Convenio = convenioControl.getObjeto("1"),
                DataNasc = DateTime.Now,
                Cpf = "53575416125",
            });
            this.SalvarObjeto(new Paciente()
            {
                Nome = "Cleverson",
                Convenio = convenioControl.getObjeto("2"),
                DataNasc = DateTime.Now,
                Cpf = "15312771520",
            });
            this.SalvarObjeto(new Paciente()
            {
                Nome = "Dayana",
                Convenio = convenioControl.getObjeto("2"),
                DataNasc = DateTime.Now,
                Cpf = "83581331209",
            });
            this.SalvarObjeto(new Paciente()
            {
                Nome = "Jaqueline",
                Convenio = convenioControl.getObjeto("3"),
                DataNasc = DateTime.Now,
                Cpf = "27354493511",
            });
            this.SalvarObjeto(new Paciente()
            {
                Nome = "Hellen",
                Convenio = convenioControl.getObjeto("2"),
                DataNasc = DateTime.Now,
                Cpf = "51735632732",
            });
        }

        // Salva ou atualiza um objeto
        public void SalvarObjeto(Paciente objeto)
        {
            try
            {
                // marca os attributos que são objetos como já existentes evitando a duplicação
                ctx.Entry(objeto.Convenio).State = System.Data.Entity.EntityState.Unchanged;

                if (objeto.Id == 0)
                {
                    ctx.Pacientes.Add(objeto);
                }
                else
                {
                    var tempObjeto = ctx.Pacientes.SingleOrDefault(temp => temp.Id == objeto.Id);
                    tempObjeto.Id = objeto.Id;
                    tempObjeto.Nome = objeto.Nome;
                    tempObjeto.Cpf = objeto.Cpf;
                    tempObjeto.DataNasc = objeto.DataNasc;
                    tempObjeto.Telefone = objeto.Telefone;
                    tempObjeto.Convenio = objeto.Convenio;
                }

                ctx.SaveChanges();
            }
            catch (Exception ex)
            {
                Util.HandleSQLDBException(ex);
            }
        }

        // remove um objeto
        public void RemoverObjeto(Paciente objeto)
        {
            if (objeto.Id != 0)
            {
                ctx.Pacientes.Remove(ctx.Pacientes.Single(temp => temp.Id == objeto.Id));
                ctx.SaveChanges();
            }
        }

        // lista todos os registros
        public IList<Paciente> ObterObjetos()
        {
            var objetos = from objeto in ctx.Pacientes.Include("Convenio") select objeto;
            return objetos.ToList();
        }

        // busca um registro especifico
        public Paciente getObjeto(String StringId)
        {

            int id = int.Parse(StringId);
            var selectedObjeto = from objeto in ctx.Pacientes.Include("Convenio")
                                 where objeto.Id == id
                                 select objeto;

            return selectedObjeto.ToList().ElementAt(0);
        }

        // busca a quantidade de pacientes em determinado convenio
        public IList<Paciente> getPacientes(int Id)
        {
            var objetos = from objeto
                          in ctx.Pacientes.Include("Convenio")
                          where objeto.Convenio.Id == Id
                          select objeto;

            return objetos.ToList();
        }
    }
}
