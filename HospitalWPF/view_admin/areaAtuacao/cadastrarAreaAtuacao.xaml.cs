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

namespace HospitalWPF.view_admin.areaAtuacao
{
    /// <summary>
    /// Lógica interna para cadastrarAreaAtuacao.xaml
    /// </summary>
    public partial class cadastrarAreaAtuacao : Window
    {
        AreaAtuacaoControler control = new AreaAtuacaoControler();

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }

        private AreaAtuacao _area = new AreaAtuacao();
        public AreaAtuacao AreaAtuacao
        {
            get { return _area; }
            set
            {
                this._area = value;
                this.NotifyPropertyChanged("AreaAtuacao");
            }
        }

        public cadastrarAreaAtuacao()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void btnSalvar_Click(object sender, RoutedEventArgs e)
        {
            control.SalvarObjeto(this.AreaAtuacao);

            this.DialogResult = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
