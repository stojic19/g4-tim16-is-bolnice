﻿#pragma checksum "..\..\..\..\View\PacijentFolder\PrikazRasporedaPacijent.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "96381E09B6C054908A4441B9DC9DC15EF02A4976264ADA9ACD90A18E778F4AB0"
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
    /// PrikazRasporedaPacijent
    /// </summary>
    public partial class PrikazRasporedaPacijent : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\..\View\PacijentFolder\PrikazRasporedaPacijent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox SviTerminiPacijenta;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\..\View\PacijentFolder\PrikazRasporedaPacijent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button informacije;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\View\PacijentFolder\PrikazRasporedaPacijent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button pomeri;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\View\PacijentFolder\PrikazRasporedaPacijent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button otkazi;
        
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
            System.Uri resourceLocater = new System.Uri("/Bolnica;component/view/pacijentfolder/prikazrasporedapacijent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\PacijentFolder\PrikazRasporedaPacijent.xaml"
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
            this.SviTerminiPacijenta = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.informacije = ((System.Windows.Controls.Button)(target));
            
            #line 75 "..\..\..\..\View\PacijentFolder\PrikazRasporedaPacijent.xaml"
            this.informacije.Click += new System.Windows.RoutedEventHandler(this.informacije_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.pomeri = ((System.Windows.Controls.Button)(target));
            
            #line 78 "..\..\..\..\View\PacijentFolder\PrikazRasporedaPacijent.xaml"
            this.pomeri.Click += new System.Windows.RoutedEventHandler(this.pomeri_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.otkazi = ((System.Windows.Controls.Button)(target));
            
            #line 81 "..\..\..\..\View\PacijentFolder\PrikazRasporedaPacijent.xaml"
            this.otkazi.Click += new System.Windows.RoutedEventHandler(this.otkazi_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

