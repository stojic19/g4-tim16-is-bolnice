﻿#pragma checksum "..\..\..\..\LekarFolder\LekoviLekar\IzmenaLeka.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "4933FB98F5F0BE3823CC78AEBD7EE87FFE0AF78EEA5A8E28ABBE7E8206D19E53"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Bolnica.LekarFolder.LekoviLekar;
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


namespace Bolnica.LekarFolder.LekoviLekar {
    
    
    /// <summary>
    /// IzmenaLeka
    /// </summary>
    public partial class IzmenaLeka : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 42 "..\..\..\..\LekarFolder\LekoviLekar\IzmenaLeka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nazivLeka;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\LekarFolder\LekoviLekar\IzmenaLeka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox jacinaLeka;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\..\LekarFolder\LekoviLekar\IzmenaLeka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox kolicinaLeka;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\LekarFolder\LekoviLekar\IzmenaLeka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridSastojci;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\LekarFolder\LekoviLekar\IzmenaLeka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nazivSastojka;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\LekarFolder\LekoviLekar\IzmenaLeka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox kolicinaSastojka;
        
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
            System.Uri resourceLocater = new System.Uri("/Bolnica;component/lekarfolder/lekovilekar/izmenaleka.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\LekarFolder\LekoviLekar\IzmenaLeka.xaml"
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
            this.nazivLeka = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.jacinaLeka = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.kolicinaLeka = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.dataGridSastojci = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            
            #line 65 "..\..\..\..\LekarFolder\LekoviLekar\IzmenaLeka.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BrisanjeSastojka);
            
            #line default
            #line hidden
            return;
            case 6:
            this.nazivSastojka = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.kolicinaSastojka = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            
            #line 90 "..\..\..\..\LekarFolder\LekoviLekar\IzmenaLeka.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DodavanjeSastojka);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 96 "..\..\..\..\LekarFolder\LekoviLekar\IzmenaLeka.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Odustajanje);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 97 "..\..\..\..\LekarFolder\LekoviLekar\IzmenaLeka.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CuvanjeIzmena);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

