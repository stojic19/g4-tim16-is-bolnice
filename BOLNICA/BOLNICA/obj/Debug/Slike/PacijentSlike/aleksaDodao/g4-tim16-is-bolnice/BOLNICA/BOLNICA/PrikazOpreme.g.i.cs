﻿#pragma checksum "..\..\..\..\..\..\..\..\Slike\PacijentSlike\aleksaDodao\g4-tim16-is-bolnice\BOLNICA\BOLNICA\PrikazOpreme.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "FAE470850A7A0FB3AA6C5F5EBE226ECA3F78449103A750E9566758DE39793358"
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
    /// PrikazOpreme
    /// </summary>
    public partial class PrikazOpreme : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 24 "..\..\..\..\..\..\..\..\Slike\PacijentSlike\aleksaDodao\g4-tim16-is-bolnice\BOLNICA\BOLNICA\PrikazOpreme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridOprema;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\..\..\..\..\Slike\PacijentSlike\aleksaDodao\g4-tim16-is-bolnice\BOLNICA\BOLNICA\PrikazOpreme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\..\..\..\..\..\Slike\PacijentSlike\aleksaDodao\g4-tim16-is-bolnice\BOLNICA\BOLNICA\PrikazOpreme.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image image;
        
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
            System.Uri resourceLocater = new System.Uri("/Bolnica;component/slike/pacijentslike/aleksadodao/g4-tim16-is-bolnice/bolnica/bo" +
                    "lnica/prikazopreme.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\..\..\..\Slike\PacijentSlike\aleksaDodao\g4-tim16-is-bolnice\BOLNICA\BOLNICA\PrikazOpreme.xaml"
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
            this.dataGridOprema = ((System.Windows.Controls.DataGrid)(target));
            
            #line 26 "..\..\..\..\..\..\..\..\Slike\PacijentSlike\aleksaDodao\g4-tim16-is-bolnice\BOLNICA\BOLNICA\PrikazOpreme.xaml"
            this.dataGridOprema.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGridOprema_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 39 "..\..\..\..\..\..\..\..\Slike\PacijentSlike\aleksaDodao\g4-tim16-is-bolnice\BOLNICA\BOLNICA\PrikazOpreme.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Dodavanje_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 41 "..\..\..\..\..\..\..\..\Slike\PacijentSlike\aleksaDodao\g4-tim16-is-bolnice\BOLNICA\BOLNICA\PrikazOpreme.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Izmjena_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 43 "..\..\..\..\..\..\..\..\Slike\PacijentSlike\aleksaDodao\g4-tim16-is-bolnice\BOLNICA\BOLNICA\PrikazOpreme.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Uklanjanje_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.image = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

