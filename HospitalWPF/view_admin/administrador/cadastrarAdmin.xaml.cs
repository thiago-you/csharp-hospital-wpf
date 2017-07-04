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

namespace HospitalWPF.view_admin.admin
{
    /// <summary>
    /// Lógica interna para cadastrarAdmin.xaml
    /// </summary>
    public partial class cadastrarAdmin : Window
    {
        SecretariaControler control = new SecretariaControler();
        BancoControler bancoControl = new BancoControler();

        public IList<Banco> Bancos { get; set; } = new List<Banco>();
        public Banco BancoSelecionado { get; set; } = null;

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private Secretaria _admin = new Secretaria();
        public Secretaria Admin
        {
            get { return _admin; }
            set
            {
                this._admin = value;
                this.NotifyPropertyChanged("Secretaria");
            }
        }

        public cadastrarAdmin()
        {
            InitializeComponent();
            Bancos = bancoControl.ObterBancos();
            this.DataContext = this;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            this.Admin.Banco = BancoSelecionado;
            control.SalvarObjeto(this.Admin);

            this.DialogResult = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
