using HospitalLib.Controler;
using HospitalModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HospitalWPF.view_admin.consulta
{
    /// <summary>
    /// Lógica interna para cadastrarConsulta.xaml
    /// </summary>
    public partial class cadastrarConsulta : Window
    {
        ConsultaControler control = new ConsultaControler();
        PacienteControler pacienteControl = new PacienteControler();
        MedicoControler medicoControl = new MedicoControler();
        AgendamentoControler agendamentoControl = new AgendamentoControler();

        public IList<Paciente> Pacientes { get; set; } = new List<Paciente>();
        public Paciente PacienteSelecionado { get; set; } = null;
        public IList<Medico> Medicos { get; set; } = new List<Medico>();
        public Medico MedicoSelecionado { get; set; } = null;
        public IList<Agendamento> Agendamentos { get; set; } = new List<Agendamento>();
        public Agendamento AgendamentoSelecionado { get; set; } = null;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private Consulta _consulta = new Consulta();
        public Consulta Consulta
        {
            get { return _consulta; }
            set
            {
                this._consulta = value;
                this.NotifyPropertyChanged("Consulta");
            }
        }

        public cadastrarConsulta()
        {
            InitializeComponent();
            Pacientes = pacienteControl.ObterObjetos();
            Medicos = medicoControl.ObterMedicos();
            Agendamentos = agendamentoControl.ObterObjetos();
            this.DataContext = this;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            this.Consulta.Data = DateTime.Now;
            this.Consulta.Paciente = PacienteSelecionado;
            this.Consulta.Medico = MedicoSelecionado;
            this.Consulta.Agendamento = AgendamentoSelecionado;
            control.SalvarObjeto(this.Consulta);

            this.DialogResult = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
