﻿#pragma checksum "..\..\..\Pacijent\PrikazTerapijePacijent.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9F80AFD68BDDD23FEC0D30A1E0296C491EE6F534F3CAD6C3F0BB6B8B295BF4F7"
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
    /// PrikazTerapijePacijent
    /// </summary>
    public partial class PrikazTerapijePacijent : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Pacijent\PrikazTerapijePacijent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox LekoviLista;
        
        #line default
        #line hidden
        
        
        #line 79 "..\..\..\Pacijent\PrikazTerapijePacijent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ukljuci;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\Pacijent\PrikazTerapijePacijent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button iskljuci;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\Pacijent\PrikazTerapijePacijent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button izvestaj;
        
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
            System.Uri resourceLocater = new System.Uri("/Bolnica;component/pacijent/prikazterapijepacijent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pacijent\PrikazTerapijePacijent.xaml"
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
            this.LekoviLista = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.ukljuci = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\Pacijent\PrikazTerapijePacijent.xaml"
            this.ukljuci.Click += new System.Windows.RoutedEventHandler(this.ukljuci_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.iskljuci = ((System.Windows.Controls.Button)(target));
            
            #line 82 "..\..\..\Pacijent\PrikazTerapijePacijent.xaml"
            this.iskljuci.Click += new System.Windows.RoutedEventHandler(this.iskljuci_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.izvestaj = ((System.Windows.Controls.Button)(target));
            
            #line 85 "..\..\..\Pacijent\PrikazTerapijePacijent.xaml"
            this.izvestaj.Click += new System.Windows.RoutedEventHandler(this.izvestaj_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

