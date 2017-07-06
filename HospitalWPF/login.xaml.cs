using HospitalLib.Controler;
using HospitalWPF.view_admin;
using HospitalWPF.view_relatorios;
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

namespace HospitalWPF
{
    /// <summary>
    /// Lógica interna para login.xaml
    /// </summary>
    public partial class login : Window
    {
        public login()
        {
            InitializeComponent();

            // variaveis de controle
            BancoControler bancoControl = new BancoControler();
            ConvenioControler convenioControl = new ConvenioControler();
            AreaAtuacaoControler areaAtuacaoControl = new AreaAtuacaoControler();
            PacienteControler pacienteControl = new PacienteControler();
            MedicoControler medicoControl = new MedicoControler();
            SecretariaControler secretariaControl = new SecretariaControler();
            AgendamentoControler agendamentoControl = new AgendamentoControler();
            ConsultaControler consultaControl = new ConsultaControler();

            // Popula a Base caso esteja vazia 
            try {

                if (bancoControl.ObterBancos().Count == 0) { bancoControl.PopularBase(); }
                if (convenioControl.ObterObjetos().Count == 0) { convenioControl.PopularBase(); }
                if (areaAtuacaoControl.ObterObjetos().Count == 0) { areaAtuacaoControl.PopularBase(); }
                if (pacienteControl.ObterObjetos().Count == 0) { pacienteControl.PopularBase(); }
                if (medicoControl.ObterMedicos().Count == 0) { medicoControl.PopularBase(); }
                if (secretariaControl.ObterObjetos().Count == 0) { secretariaControl.PopularBase(); }
                if (agendamentoControl.ObterObjetos().Count == 0) { agendamentoControl.PopularBase(); }
                if (consultaControl.ObterObjetos().Count == 0) { consultaControl.PopularBase(); }

            } catch (Exception) {
                MessageBox.Show("Erro ao inicar programa.");
            }

        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            adminHome win = new adminHome();
            win.ShowDialog();
        }

        private void btnRelatorio_Click(object sender, RoutedEventArgs e)
        {
            relatorios win = new relatorios();
            win.Show();
        }
    }
}
