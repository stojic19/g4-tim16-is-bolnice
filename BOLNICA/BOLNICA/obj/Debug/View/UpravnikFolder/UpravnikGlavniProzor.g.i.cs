﻿#pragma checksum "..\..\..\..\View\UpravnikFolder\UpravnikGlavniProzor.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B5CA680F529F5BC28149CCE2749D7E1C84CFC6456EED26E8F321DF8CA1DA8F81"
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
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using Model;
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
    /// UpravnikGlavniProzor
    /// </summary>
    public partial class UpravnikGlavniProzor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\..\View\UpravnikFolder\UpravnikGlavniProzor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button strelica;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\..\View\UpravnikFolder\UpravnikGlavniProzor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button krevet;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\..\..\View\UpravnikFolder\UpravnikGlavniProzor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainPanel;
        
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
            System.Uri resourceLocater = new System.Uri("/Bolnica;component/view/upravnikfolder/upravnikglavniprozor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\UpravnikFolder\UpravnikGlavniProzor.xaml"
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
            
            #line 9 "..\..\..\..\View\UpravnikFolder\UpravnikGlavniProzor.xaml"
            ((Bolnica.UpravnikGlavniProzor)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.strelica = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\View\UpravnikFolder\UpravnikGlavniProzor.xaml"
            this.strelica.Click += new System.Windows.RoutedEventHandler(this.strelica_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.krevet = ((System.Windows.Controls.Button)(target));
            
            #line 50 "..\..\..\..\View\UpravnikFolder\UpravnikGlavniProzor.xaml"
            this.krevet.Click += new System.Windows.RoutedEventHandler(this.krevet_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 75 "..\..\..\..\View\UpravnikFolder\UpravnikGlavniProzor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Prostorije_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 78 "..\..\..\..\View\UpravnikFolder\UpravnikGlavniProzor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Oprema_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 81 "..\..\..\..\View\UpravnikFolder\UpravnikGlavniProzor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Lijekovi_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 84 "..\..\..\..\View\UpravnikFolder\UpravnikGlavniProzor.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Renoviranje_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MainPanel = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

