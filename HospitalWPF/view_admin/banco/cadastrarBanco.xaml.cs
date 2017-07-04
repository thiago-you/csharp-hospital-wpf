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

namespace HospitalWPF.view_admin.banco
{
    /// <summary>
    /// Lógica interna para cadastrarBanco.xaml
    /// </summary>
    public partial class cadastrarBanco : Window
    {
        BancoControler control = new BancoControler();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private Banco _banco = new Banco();
        public Banco Banco
        {
            get { return _banco; }
            set
            {
                this._banco = value;
                this.NotifyPropertyChanged("Banco");
            }
        }

        public cadastrarBanco()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            control.SalvarBanco(this.Banco);

            this.DialogResult = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
