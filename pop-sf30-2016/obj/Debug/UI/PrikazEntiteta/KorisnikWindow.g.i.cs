﻿#pragma checksum "..\..\..\..\UI\PrikazEntiteta\KorisnikWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F7B2A20BFCB93487494FB70032A6A12DA50F6706"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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
using pop_sf30_2016.UI.PrikazEntiteta;


namespace pop_sf30_2016.UI.PrikazEntiteta {
    
    
    /// <summary>
    /// KorisnikWindow
    /// </summary>
    public partial class KorisnikWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\UI\PrikazEntiteta\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgKorisnik;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\..\UI\PrikazEntiteta\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbSortiraj;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\..\UI\PrikazEntiteta\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Izlaz;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\..\UI\PrikazEntiteta\KorisnikWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbObrisani;
        
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
            System.Uri resourceLocater = new System.Uri("/pop-sf30-2016;component/ui/prikazentiteta/korisnikwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\PrikazEntiteta\KorisnikWindow.xaml"
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
            this.dgKorisnik = ((System.Windows.Controls.DataGrid)(target));
            
            #line 14 "..\..\..\..\UI\PrikazEntiteta\KorisnikWindow.xaml"
            this.dgKorisnik.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgKorisnik_AutoGeneratingColumn);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 16 "..\..\..\..\UI\PrikazEntiteta\KorisnikWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Dodaj_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 17 "..\..\..\..\UI\PrikazEntiteta\KorisnikWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Izmeni_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 18 "..\..\..\..\UI\PrikazEntiteta\KorisnikWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Obrisi_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cbSortiraj = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\..\..\UI\PrikazEntiteta\KorisnikWindow.xaml"
            this.cbSortiraj.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbSortiraj_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Izlaz = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\..\UI\PrikazEntiteta\KorisnikWindow.xaml"
            this.Izlaz.Click += new System.Windows.RoutedEventHandler(this.Izlaz_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.cbObrisani = ((System.Windows.Controls.ComboBox)(target));
            
            #line 23 "..\..\..\..\UI\PrikazEntiteta\KorisnikWindow.xaml"
            this.cbObrisani.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cbObrisani_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

