﻿#pragma checksum "..\..\..\PacijentFolder\PotvrdiPomeranjePacijent.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E85CCFE6EDE006ED979FC61E718899C1838796092DC55CD654E8BBFBD2B6A4AC"
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
    /// PotvrdiPomeranjePacijent
    /// </summary>
    public partial class PotvrdiPomeranjePacijent : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\PacijentFolder\PotvrdiPomeranjePacijent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextLekar;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\PacijentFolder\PotvrdiPomeranjePacijent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextDatum;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\PacijentFolder\PotvrdiPomeranjePacijent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextVreme;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\PacijentFolder\PotvrdiPomeranjePacijent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button potvrdi;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\PacijentFolder\PotvrdiPomeranjePacijent.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button odustani;
        
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
            System.Uri resourceLocater = new System.Uri("/Bolnica;component/pacijentfolder/potvrdipomeranjepacijent.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PacijentFolder\PotvrdiPomeranjePacijent.xaml"
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
            this.TextLekar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TextDatum = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextVreme = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.potvrdi = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\PacijentFolder\PotvrdiPomeranjePacijent.xaml"
            this.potvrdi.Click += new System.Windows.RoutedEventHandler(this.potvrdi_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.odustani = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\PacijentFolder\PotvrdiPomeranjePacijent.xaml"
            this.odustani.Click += new System.Windows.RoutedEventHandler(this.odustani_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

