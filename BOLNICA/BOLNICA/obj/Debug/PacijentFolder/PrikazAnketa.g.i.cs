﻿#pragma checksum "..\..\..\PacijentFolder\PrikazAnketa.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8824E12554BAECC32FA3C6AC8F2F3C4DB304B71F2E734D2437079B0F13B50187"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Bolnica.PacijentFolder;
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


namespace Bolnica.PacijentFolder {
    
    
    /// <summary>
    /// PrikazAnketa
    /// </summary>
    public partial class PrikazAnketa : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\PacijentFolder\PrikazAnketa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox AnketePacijenta;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\PacijentFolder\PrikazAnketa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button PopuniAnketu;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\PacijentFolder\PrikazAnketa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button OceniBolnicu;
        
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
            System.Uri resourceLocater = new System.Uri("/Bolnica;component/pacijentfolder/prikazanketa.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PacijentFolder\PrikazAnketa.xaml"
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
            this.AnketePacijenta = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.PopuniAnketu = ((System.Windows.Controls.Button)(target));
            
            #line 72 "..\..\..\PacijentFolder\PrikazAnketa.xaml"
            this.PopuniAnketu.Click += new System.Windows.RoutedEventHandler(this.PopuniAnketu_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.OceniBolnicu = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\PacijentFolder\PrikazAnketa.xaml"
            this.OceniBolnicu.Click += new System.Windows.RoutedEventHandler(this.OceniBolnicu_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

