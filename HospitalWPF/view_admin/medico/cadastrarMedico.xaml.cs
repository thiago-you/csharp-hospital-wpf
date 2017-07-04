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

namespace HospitalWPF.view_admin.medico
{
    /// <summary>
    /// Lógica interna para cadastrarMedico.xaml
    /// </summary>
    public partial class cadastrarMedico : Window
    {
        MedicoControler control = new MedicoControler();
        BancoControler bancoControl = new BancoControler();
        AreaAtuacaoControler areaControl = new AreaAtuacaoControler();

        public IList<Banco> Bancos { get; set; } = new List<Banco>();
        public Banco BancoSelecionado { get; set; } = null;
        public IList<AreaAtuacao> Areas { get; set; } = new List<AreaAtuacao>();
        public AreaAtuacao AreaSelecionada { get; set; } = null;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private Medico _medico = new Medico();
        public Medico Medico
        {
            get { return _medico; }
            set
            {
                this._medico = value;
                this.NotifyPropertyChanged("Medico");
            }
        }

        public cadastrarMedico()
        {
            InitializeComponent();
            Bancos = bancoControl.ObterBancos();
            Areas = areaControl.ObterObjetos();
            this.DataContext = this;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            this.Medico.Turno = cbTurno.Text;
            this.Medico.Banco = BancoSelecionado;
            this.Medico.AreaAtuacao = AreaSelecionada;

            control.SalvarMedico(this.Medico);

            this.DialogResult = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
