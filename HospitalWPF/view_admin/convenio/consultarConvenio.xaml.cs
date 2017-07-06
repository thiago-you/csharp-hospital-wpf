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

namespace HospitalWPF.view_admin.convenio
{
    /// <summary>
    /// Lógica interna para consultarConvenio.xaml
    /// </summary>
    public partial class consultarConvenio : Window
    {
        private ConvenioControler control = new ConvenioControler();
        public ICollection<Convenio> Objetos { get; set; }

        private Convenio _objeto = new Convenio();
        public Convenio Objeto
        {
            get { return _objeto; }
            set
            {
                this._objeto = value;
            }
        }

        public consultarConvenio()
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
            cadastrarConvenio win = new cadastrarConvenio();
            win.ShowDialog();
            if (win.DialogResult.HasValue && win.DialogResult.Value)
            {
                this.Binding();
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            cadastrarConvenio win = new cadastrarConvenio();
            win.Convenio = this.Objeto;

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

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            Convenio objeto = this.Objeto;
            if (objeto != null)
            {
                if (objeto.Id == 1)
                {
                    MessageBox.Show("Não é possível excluír esse registro padrão do sistema.");
                }
                else
                {
                    try
                    {
                        this.control.RemoverObjeto(objeto);
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Não foi possível excluír essse registro.");
                    }
                }
            }
            this.Binding();
        }
    }
}
