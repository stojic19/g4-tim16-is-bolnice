﻿#pragma checksum "..\..\..\..\..\View\LekarFolder\LekoviLekar\VerifikacijaLekova.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "C4A7F33B1F1B99F601F256F242077466B14E519F11356B7E323B2A28DD1B5B33"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Bolnica.LekarFolder;
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


namespace Bolnica.LekarFolder {
    
    
    /// <summary>
    /// VerifikacijaLekova
    /// </summary>
    public partial class VerifikacijaLekova : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\..\View\LekarFolder\LekoviLekar\VerifikacijaLekova.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pretragaZahteva;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\..\..\View\LekarFolder\LekoviLekar\VerifikacijaLekova.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridZahtevi;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\View\LekarFolder\LekoviLekar\VerifikacijaLekova.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridSastojci;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\..\..\..\View\LekarFolder\LekoviLekar\VerifikacijaLekova.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label vecPostojiOdgovor;
        
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
            System.Uri resourceLocater = new System.Uri("/Bolnica;component/view/lekarfolder/lekovilekar/verifikacijalekova.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\LekarFolder\LekoviLekar\VerifikacijaLekova.xaml"
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
            this.pretragaZahteva = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\..\..\..\View\LekarFolder\LekoviLekar\VerifikacijaLekova.xaml"
            this.pretragaZahteva.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.pretragaZahteva_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 26 "..\..\..\..\..\View\LekarFolder\LekoviLekar\VerifikacijaLekova.xaml"
            this.pretragaZahteva.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.pretragaZahteva_TextChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 31 "..\..\..\..\..\View\LekarFolder\LekoviLekar\VerifikacijaLekova.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.PrikazBazeLekova);
            
            #line default
            #line hidden
            return;
            case 3:
            this.dataGridZahtevi = ((System.Windows.Controls.DataGrid)(target));
            
            #line 34 "..\..\..\..\..\View\LekarFolder\LekoviLekar\VerifikacijaLekova.xaml"
            this.dataGridZahtevi.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dataGridZahtevi_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.dataGridSastojci = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 5:
            this.vecPostojiOdgovor = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            
            #line 63 "..\..\..\..\..\View\LekarFolder\LekoviLekar\VerifikacijaLekova.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Odbijanje);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 64 "..\..\..\..\..\View\LekarFolder\LekoviLekar\VerifikacijaLekova.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Odobravanje);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

