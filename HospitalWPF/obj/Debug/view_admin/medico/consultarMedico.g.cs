﻿#pragma checksum "..\..\..\..\view_admin\medico\consultarMedico.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "0A08CEFEA2F9DB535DD8095DD6E19B1D"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using HospitalWPF.view_admin.medico;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace HospitalWPF.view_admin.medico {
    
    
    /// <summary>
    /// consultarMedico
    /// </summary>
    public partial class consultarMedico : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\..\view_admin\medico\consultarMedico.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid gridMedico;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\..\view_admin\medico\consultarMedico.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCadastrar;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\..\view_admin\medico\consultarMedico.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAtualizar;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\..\view_admin\medico\consultarMedico.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeletar;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\..\view_admin\medico\consultarMedico.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCancelar;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/HospitalWPF;component/view_admin/medico/consultarmedico.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\view_admin\medico\consultarMedico.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.gridMedico = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            this.btnCadastrar = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\..\view_admin\medico\consultarMedico.xaml"
            this.btnCadastrar.Click += new System.Windows.RoutedEventHandler(this.btnCadastrar_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnAtualizar = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\..\view_admin\medico\consultarMedico.xaml"
            this.btnAtualizar.Click += new System.Windows.RoutedEventHandler(this.btnAtualizar_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnDeletar = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\..\view_admin\medico\consultarMedico.xaml"
            this.btnDeletar.Click += new System.Windows.RoutedEventHandler(this.btnDeletar_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnCancelar = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\..\view_admin\medico\consultarMedico.xaml"
            this.btnCancelar.Click += new System.Windows.RoutedEventHandler(this.btnCancelar_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

