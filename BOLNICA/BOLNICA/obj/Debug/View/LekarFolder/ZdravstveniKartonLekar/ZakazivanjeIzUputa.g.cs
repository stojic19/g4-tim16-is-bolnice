﻿#pragma checksum "..\..\..\..\..\View\LekarFolder\ZdravstveniKartonLekar\ZakazivanjeIzUputa.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "45EF059374AF581B66518D20D0B4766C8FC8A8D90DA6B886CCA3F999EF306DBC"
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


namespace Bolnica.LekarFolder {
    
    
    /// <summary>
    /// ZakazivanjeIzUputa
    /// </summary>
    public partial class ZakazivanjeIzUputa : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\..\View\LekarFolder\ZdravstveniKartonLekar\ZakazivanjeIzUputa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox vrTermina;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\..\View\LekarFolder\ZdravstveniKartonLekar\ZakazivanjeIzUputa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox pacijent;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\..\View\LekarFolder\ZdravstveniKartonLekar\ZakazivanjeIzUputa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox lekar;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\..\View\LekarFolder\ZdravstveniKartonLekar\ZakazivanjeIzUputa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datum;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\..\View\LekarFolder\ZdravstveniKartonLekar\ZakazivanjeIzUputa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox pocVreme;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\..\View\LekarFolder\ZdravstveniKartonLekar\ZakazivanjeIzUputa.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox brojTermina;
        
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
            System.Uri resourceLocater = new System.Uri("/Bolnica;component/view/lekarfolder/zdravstvenikartonlekar/zakazivanjeizuputa.xam" +
                    "l", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\View\LekarFolder\ZdravstveniKartonLekar\ZakazivanjeIzUputa.xaml"
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
            this.vrTermina = ((System.Windows.Controls.ComboBox)(target));
            
            #line 38 "..\..\..\..\..\View\LekarFolder\ZdravstveniKartonLekar\ZakazivanjeIzUputa.xaml"
            this.vrTermina.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.vrTermina_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.pacijent = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.lekar = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.datum = ((System.Windows.Controls.DatePicker)(target));
            
            #line 67 "..\..\..\..\..\View\LekarFolder\ZdravstveniKartonLekar\ZakazivanjeIzUputa.xaml"
            this.datum.SelectedDateChanged += new System.EventHandler<System.Windows.Controls.SelectionChangedEventArgs>(this.datum_SelectedDateChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.pocVreme = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.brojTermina = ((System.Windows.Controls.ComboBox)(target));
            
            #line 85 "..\..\..\..\..\View\LekarFolder\ZdravstveniKartonLekar\ZakazivanjeIzUputa.xaml"
            this.brojTermina.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.brojTermina_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 99 "..\..\..\..\..\View\LekarFolder\ZdravstveniKartonLekar\ZakazivanjeIzUputa.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Povratak);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 102 "..\..\..\..\..\View\LekarFolder\ZdravstveniKartonLekar\ZakazivanjeIzUputa.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ZakaziTermin);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

