﻿#pragma checksum "..\..\..\..\UI\PrikazEntiteta\AkcijaWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "1F1A0D052F1EC9458CB1D1F24B0B2A84"
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
    /// AkcijaWindow
    /// </summary>
    public partial class AkcijaWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\..\UI\PrikazEntiteta\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgAkcija;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\..\UI\PrikazEntiteta\AkcijaWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Izlaz;
        
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
            System.Uri resourceLocater = new System.Uri("/pop-sf30-2016;component/ui/prikazentiteta/akcijawindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\UI\PrikazEntiteta\AkcijaWindow.xaml"
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
            this.dgAkcija = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 2:
            
            #line 15 "..\..\..\..\UI\PrikazEntiteta\AkcijaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Dodaj_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 16 "..\..\..\..\UI\PrikazEntiteta\AkcijaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Izmeni_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 17 "..\..\..\..\UI\PrikazEntiteta\AkcijaWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Obrisi_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Izlaz = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\..\UI\PrikazEntiteta\AkcijaWindow.xaml"
            this.Izlaz.Click += new System.Windows.RoutedEventHandler(this.Izlaz_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

