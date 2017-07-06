using HospitalLib.Controler;
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
    /// Lógica interna para convenioRelatorio.xaml
    /// </summary>
    public partial class convenioRelatorio : Window
    {
        public convenioRelatorio()
        {
            InitializeComponent();
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            ConvenioControler controler = new ConvenioControler();
            var dataSource = new Microsoft.Reporting.WinForms.ReportDataSource("DataSetRelatorioConvenio", controler.ObterObjetos());
            ReportViewer.LocalReport.DataSources.Add(dataSource);
            ReportViewer.LocalReport.ReportEmbeddedResource = "HospitalWPF.ConvenioRelatorio.rdlc";

            ReportViewer.RefreshReport();
        }
    }
}
