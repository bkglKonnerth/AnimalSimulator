﻿#pragma checksum "..\..\..\pages\MainMenuPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "07F0D8FE4765C1DDA77D09D55D7FF8C25DC4368E6D48235CD3E20956006FE12A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.42000
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using AnimalSimulator.pages;
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


namespace AnimalSimulator.pages {
    
    
    /// <summary>
    /// MainMenuPage
    /// </summary>
    public partial class MainMenuPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\..\pages\MainMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Animals;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\pages\MainMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Shops;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\pages\MainMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Storage;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\pages\MainMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_logout;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\pages\MainMenuPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_Editmenu;
        
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
            System.Uri resourceLocater = new System.Uri("/AnimalSimulator;component/pages/mainmenupage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\pages\MainMenuPage.xaml"
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
            this.Button_Animals = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\pages\MainMenuPage.xaml"
            this.Button_Animals.Click += new System.Windows.RoutedEventHandler(this.Button_Animals_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Button_Shops = ((System.Windows.Controls.Button)(target));
            
            #line 15 "..\..\..\pages\MainMenuPage.xaml"
            this.Button_Shops.Click += new System.Windows.RoutedEventHandler(this.Button_Shops_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Button_Storage = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.Button_logout = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\pages\MainMenuPage.xaml"
            this.Button_logout.Click += new System.Windows.RoutedEventHandler(this.Button_logout_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Button_Editmenu = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\pages\MainMenuPage.xaml"
            this.Button_Editmenu.Click += new System.Windows.RoutedEventHandler(this.Button_logout_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

