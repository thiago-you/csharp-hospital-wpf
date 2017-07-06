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

namespace HospitalWPF.view_relatorios
{
    /// <summary>
    /// Lógica interna para relatorios.xaml
    /// </summary>
    public partial class relatorios : Window
    {
        public relatorios()
        {
            InitializeComponent();
        }

        private void btnRelatorioMedicos_Click(object sender, RoutedEventArgs e)
        {
            medicoRelatorio win = new medicoRelatorio();
            win.Show();
        }

        private void btnRelatorioConvenios_Click(object sender, RoutedEventArgs e)
        {
            convenioRelatorio win = new convenioRelatorio();
            win.Show();
        }
    }
}
