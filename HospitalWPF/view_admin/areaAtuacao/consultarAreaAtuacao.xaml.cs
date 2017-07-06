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

namespace HospitalWPF.view_admin.areaAtuacao
{
    /// <summary>
    /// Lógica interna para consultarAreaAtuacao.xaml
    /// </summary>
    public partial class consultarAreaAtuacao : Window
    {
        private AreaAtuacaoControler control = new AreaAtuacaoControler();
        public ICollection<AreaAtuacao> Objetos { get; set; }

        private AreaAtuacao _objeto = new AreaAtuacao();
        public AreaAtuacao Objeto
        {
            get { return _objeto; }
            set
            {
                this._objeto = value;
            }
        }

        public consultarAreaAtuacao()
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
            cadastrarAreaAtuacao win = new cadastrarAreaAtuacao();
            win.ShowDialog();
            if (win.DialogResult.HasValue && win.DialogResult.Value)
            {
                this.Binding();
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            cadastrarAreaAtuacao win = new cadastrarAreaAtuacao();
            win.AreaAtuacao = this.Objeto;

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
            AreaAtuacao objeto = this.Objeto;
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
