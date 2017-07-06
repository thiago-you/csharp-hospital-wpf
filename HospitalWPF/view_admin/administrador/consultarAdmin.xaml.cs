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

namespace HospitalWPF.view_admin.admin
{
    /// <summary>
    /// Lógica interna para consultarAdmin.xaml
    /// </summary>
    public partial class consultarAdmin : Window
    {
        private SecretariaControler control = new SecretariaControler();
        public ICollection<Secretaria> Objetos { get; set; }

        private Secretaria _objeto = new Secretaria();
        public Secretaria Objeto
        {
            get { return _objeto; }
            set
            {
                this._objeto = value;
            }
        }

        public consultarAdmin()
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
            cadastrarAdmin win = new cadastrarAdmin();
            win.ShowDialog();
            if (win.DialogResult.HasValue && win.DialogResult.Value)
            {
                this.Binding();
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            cadastrarAdmin win = new cadastrarAdmin();
            win.Admin = this.Objeto;

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
            Secretaria objeto = this.Objeto;
            if (objeto != null)
            {
                if(objeto.Id == 1) {
                    MessageBox.Show("Não é possível excluír esse registro padrão do sistema.");
                }
                else {
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
