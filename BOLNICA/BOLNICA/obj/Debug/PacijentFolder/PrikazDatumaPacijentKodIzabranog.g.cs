﻿#pragma checksum "..\..\..\PacijentFolder\PrikazDatumaPacijentKodIzabranog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "00426CADFEA5C8C1B27A7C33C240F1D045889E581E62B65DD71024933DE1765C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Bolnica;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
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


namespace Bolnica {
    
    
    /// <summary>
    /// PrikazDatumaPacijentKodIzabranog
    /// </summary>
    public partial class PrikazDatumaPacijentKodIzabranog : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\PacijentFolder\PrikazDatumaPacijentKodIzabranog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label NaslovTabele;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\PacijentFolder\PrikazDatumaPacijentKodIzabranog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox slobodniDatumiKodIzabranog;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\PacijentFolder\PrikazDatumaPacijentKodIzabranog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button izaberiDatum;
        
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
            System.Uri resourceLocater = new System.Uri("/Bolnica;component/pacijentfolder/prikazdatumapacijentkodizabranog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PacijentFolder\PrikazDatumaPacijentKodIzabranog.xaml"
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
            this.NaslovTabele = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.slobodniDatumiKodIzabranog = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.izaberiDatum = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\PacijentFolder\PrikazDatumaPacijentKodIzabranog.xaml"
            this.izaberiDatum.Click += new System.Windows.RoutedEventHandler(this.izaberiDatum_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

