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

namespace HospitalWPF.view_admin.convenio
{
    /// <summary>
    /// Lógica interna para cadastrarConvenio.xaml
    /// </summary>
    public partial class cadastrarConvenio : Window
    {
        ConvenioControler control = new ConvenioControler();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private Convenio _convenio = new Convenio();
        public Convenio Convenio
        {
            get { return _convenio; }
            set
            {
                this._convenio = value;
                this.NotifyPropertyChanged("Convenio");
            }
        }

        public cadastrarConvenio()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            control.SalvarObjeto(this.Convenio);

            this.DialogResult = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
