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

namespace HospitalWPF.view_admin.paciente
{
    /// <summary>
    /// Lógica interna para cadastrarPaciente.xaml
    /// </summary>
    public partial class cadastrarPaciente : Window
    {
        PacienteControler control = new PacienteControler();
        ConvenioControler convenioControl = new ConvenioControler();

        public IList<Convenio> Convenios { get; set; } = new List<Convenio>();
        public Convenio ConvenioSelecionado { get; set; } = null;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private Paciente _paciente = new Paciente();
        public Paciente Paciente
        {
            get { return _paciente; }
            set
            {
                this._paciente = value;
                this.NotifyPropertyChanged("Paciente");
            }
        }

        public cadastrarPaciente()
        {
            InitializeComponent();
            Convenios = convenioControl.ObterObjetos();
            this.DataContext = this;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            this.Paciente.Convenio = ConvenioSelecionado;
            control.SalvarObjeto(this.Paciente);

            this.DialogResult = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
