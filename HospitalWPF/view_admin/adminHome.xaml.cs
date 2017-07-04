using HospitalWPF.view_admin.admin;
using HospitalWPF.view_admin.agendamento;
using HospitalWPF.view_admin.areaAtuacao;
using HospitalWPF.view_admin.banco;
using HospitalWPF.view_admin.consulta;
using HospitalWPF.view_admin.convenio;
using HospitalWPF.view_admin.medico;
using HospitalWPF.view_admin.paciente;
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

namespace HospitalWPF.view_admin
{
    /// <summary>
    /// Lógica interna para adminHome.xaml
    /// </summary>
    public partial class adminHome : Window
    {
        public adminHome()
        {
            InitializeComponent();
        }

        private void btnMedico_Click(object sender, RoutedEventArgs e)
        {
            consultarMedico win = new consultarMedico();
            win.ShowDialog();
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            consultarAdmin win = new consultarAdmin();
            win.ShowDialog();
        }

        private void btnPaciente_Click(object sender, RoutedEventArgs e)
        {
            consultarPaciente win = new consultarPaciente();
            win.ShowDialog();
        }

        private void btnBanco_Click(object sender, RoutedEventArgs e)
        {
            consultarBanco win = new consultarBanco();
            win.ShowDialog();
        }

        private void btnAreaAtuacao_Click(object sender, RoutedEventArgs e)
        {
            consultarAreaAtuacao win = new consultarAreaAtuacao();
            win.ShowDialog();
        }

        private void btnConvenio_Click(object sender, RoutedEventArgs e)
        {
            consultarConvenio win = new consultarConvenio();
            win.ShowDialog();
        }

        private void btnAgendamento_Click(object sender, RoutedEventArgs e)
        {
            consultarAgendamentos win = new consultarAgendamentos();
            win.ShowDialog();
        }

        private void btnConsulta_Click(object sender, RoutedEventArgs e)
        {
            consultarConsulta win = new consultarConsulta();
            win.ShowDialog();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
