﻿#pragma checksum "..\..\..\..\..\View\LekarView\LekoviLekar\OdbijanjeLeka.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F6BA36EA71582592B2ED3ACADA66A05D81699FB54F855D1A6E2DCA025E509C9A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Bolnica.Lokalizacija;
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
    /// OdbijanjeLeka
    /// </summary>
    public partial class OdbijanjeLeka : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\..\..\View\LekarView\LekoviLekar\OdbijanjeLeka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nazivLeka;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\..\View\LekarView\LekoviLekar\OdbijanjeLeka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox jacinaLeka;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\..\View\LekarView\LekoviLekar\OdbijanjeLeka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dataGridSastojci;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\..\View\LekarView\LekoviLekar\OdbijanjeLeka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox razlogOdbijanja;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\View\LekarView\LekoviLekar\OdbijanjeLeka.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label validacijaOdbijanja;
        
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
            System.Uri resourceLocater = new System.Uri("/Bolnica;component/view/lekarview/lekovilekar/odbijanjeleka.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\LekarView\LekoviLekar\OdbijanjeLeka.xaml"
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
            this.dataGridSastojci = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 4:
            this.razlogOdbijanja = ((System.Windows.Controls.TextBox)(target));
            
            #line 66 "..\..\..\..\..\View\LekarView\LekoviLekar\OdbijanjeLeka.xaml"
            this.razlogOdbijanja.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.razlogOdbijanja_PreviewMouseDown);
            
            #line default
            #line hidden
            
            #line 66 "..\..\..\..\..\View\LekarView\LekoviLekar\OdbijanjeLeka.xaml"
            this.razlogOdbijanja.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.razlogOdbijanja_TextChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.validacijaOdbijanja = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            
            #line 73 "..\..\..\..\..\View\LekarView\LekoviLekar\OdbijanjeLeka.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Odustajanje);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 74 "..\..\..\..\..\View\LekarView\LekoviLekar\OdbijanjeLeka.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Potvrda);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

