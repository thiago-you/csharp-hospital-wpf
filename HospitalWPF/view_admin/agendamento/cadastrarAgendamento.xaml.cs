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

namespace HospitalWPF.view_admin.agendamento
{
    /// <summary>
    /// Lógica interna para cadastrarAgendamento.xaml
    /// </summary>
    public partial class cadastrarAgendamento : Window
    {
        AgendamentoControler control = new AgendamentoControler();
        PacienteControler pacienteControl = new PacienteControler();
        MedicoControler medicoControl = new MedicoControler();
        SecretariaControler adminControl = new SecretariaControler();

        // variaveis para fazer as validações de data
        public DateTime dateNow = DateTime.Now;
        public DateTime turno_inicio;
        public DateTime turno_fim;

        public IList<Paciente> Pacientes { get; set; } = new List<Paciente>();
        public Paciente PacienteSelecionado { get; set; } = null;
        public IList<Medico> Medicos { get; set; } = new List<Medico>();
        public Medico MedicoSelecionado { get; set; } = null;
        public IList<Secretaria> Admins { get; set; } = new List<Secretaria>();
        public Secretaria AdminSelecionado { get; set; } = null;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private Agendamento _agendamento = new Agendamento();
        public Agendamento Agendamento
        {
            get { return _agendamento; }
            set
            {
                this._agendamento = value;
                this.NotifyPropertyChanged("Agendamento");
            }
        }

        public cadastrarAgendamento()
        {
            InitializeComponent();
            Pacientes = pacienteControl.ObterObjetos();
            Medicos = medicoControl.ObterMedicos();
            Admins = adminControl.ObterObjetos();
            this.DataContext = this;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.Agendamento.Paciente = PacienteSelecionado;
                this.Agendamento.Medico = MedicoSelecionado;
                this.Agendamento.Secretaria = AdminSelecionado;

                control.SalvarObjeto(this.Agendamento);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Erro Interno");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possível salvar. Tente novamente.", "Erro Interno");
            }

            this.DialogResult = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
