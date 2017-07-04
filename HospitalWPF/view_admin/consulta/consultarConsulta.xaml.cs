using HospitalLib.Controler;
using HospitalModel;
using System;
using System.Collections.Generic;
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
    /// Lógica interna para consultarConsulta.xaml
    /// </summary>
    public partial class consultarConsulta : Window
    {
        private ConsultaControler control = new ConsultaControler();
        public ICollection<Consulta> Objetos { get; set; }

        private Consulta _objeto = new Consulta();
        public Consulta Objeto
        {
            get { return _objeto; }
            set
            {
                this._objeto = value;
            }
        }

        public consultarConsulta()
        {
            InitializeComponent();
            this.Objetos = control.ObterObjetos();
            this.DataContext = this;
        }

        public void Binding()
        {
            gridObjetos.ItemsSource = null;
            gridObjetos.ItemsSource = control.ObterObjetos();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            cadastrarConsulta win = new cadastrarConsulta();
            win.ShowDialog();
            if (win.DialogResult.HasValue && win.DialogResult.Value)
            {
                this.Binding();
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            cadastrarConsulta win = new cadastrarConsulta();
            win.Consulta = this.Objeto;

            win.ShowDialog();
            if (win.DialogResult.HasValue && win.DialogResult.Value)
            {
                this.Binding();
            }
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
