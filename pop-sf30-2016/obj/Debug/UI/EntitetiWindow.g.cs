﻿#pragma checksum "..\..\..\UI\EntitetiWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "45CA96E47537D6F6FD382B8329856B728B83A30B"
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
using pop_sf30_2016.UI;


namespace pop_sf30_2016.UI {
    
    
    /// <summary>
    /// EntitetiWindow
    /// </summary>
    public partial class EntitetiWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\UI\EntitetiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnTip;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UI\EntitetiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnKorisnici;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\UI\EntitetiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSalon;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\UI\EntitetiWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnKorisnici_Copy;
        
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
            System.Uri resourceLocater = new System.Uri("/pop-sf30-2016;component/ui/entitetiwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\EntitetiWindow.xaml"
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
            
            #line 12 "..\..\..\UI\EntitetiWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.NamestajWindow_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btnTip = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\UI\EntitetiWindow.xaml"
            this.btnTip.Click += new System.Windows.RoutedEventHandler(this.TipNamestaja_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 14 "..\..\..\UI\EntitetiWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ProdajaNamestaja_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 15 "..\..\..\UI\EntitetiWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DodatanaUsluga_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 16 "..\..\..\UI\EntitetiWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Akcija_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnKorisnici = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\UI\EntitetiWindow.xaml"
            this.btnKorisnici.Click += new System.Windows.RoutedEventHandler(this.Koirsnik_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnSalon = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\UI\EntitetiWindow.xaml"
            this.btnSalon.Click += new System.Windows.RoutedEventHandler(this.btnKorisnici_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnKorisnici_Copy = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\UI\EntitetiWindow.xaml"
            this.btnKorisnici_Copy.Click += new System.Windows.RoutedEventHandler(this.btnKorisnici_Copy_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

