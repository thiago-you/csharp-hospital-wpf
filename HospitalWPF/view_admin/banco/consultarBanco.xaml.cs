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

namespace HospitalWPF.view_admin.banco
{
    /// <summary>
    /// Lógica interna para consultarBanco.xaml
    /// </summary>
    public partial class consultarBanco : Window
    {
        private BancoControler control = new BancoControler();
        public ICollection<Banco> Objetos { get; set; }

        private Banco _objeto = new Banco();
        public Banco Objeto
        {
            get { return _objeto; }
            set
            {
                this._objeto = value;
            }
        }

        public consultarBanco()
        {
            InitializeComponent();
            this.Objetos = control.ObterBancos();
            this.DataContext = this;
        }

        public void Binding()
        {
            gridObjetos.ItemsSource = null;
            gridObjetos.ItemsSource = control.ObterBancos();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            cadastrarBanco win = new cadastrarBanco();
            win.ShowDialog();
            if (win.DialogResult.HasValue && win.DialogResult.Value)
            {
                this.Binding();
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            cadastrarBanco win = new cadastrarBanco();
            win.Banco = this.Objeto;

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
            Banco objeto = this.Objeto;
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
                        this.control.RemoverBanco(objeto);
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
