﻿#pragma checksum "..\..\Login.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A00636FA56DA51A82D56E00AD69CAC29"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MemoryGameProject;
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


namespace MemoryGameProject {
    
    
    /// <summary>
    /// Login
    /// </summary>
    public partial class Login : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 78 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid connect;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelLogin;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelEmail;
        
        #line default
        #line hidden
        
        
        #line 96 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxEmail;
        
        #line default
        #line hidden
        
        
        #line 98 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelPassword;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox PasswordBox;
        
        #line default
        #line hidden
        
        
        #line 100 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock ErrorMsg;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSignIn;
        
        #line default
        #line hidden
        
        
        #line 122 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 123 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonSignInWithFacebook;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonMultiplayer;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonPlay;
        
        #line default
        #line hidden
        
        
        #line 155 "..\..\Login.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBox;
        
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
            System.Uri resourceLocater = new System.Uri("/MemoryGameProject;component/login.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Login.xaml"
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
            this.connect = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.LabelLogin = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.LabelEmail = ((System.Windows.Controls.Label)(target));
            
            #line 91 "..\..\Login.xaml"
            this.LabelEmail.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Email_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TextBoxEmail = ((System.Windows.Controls.TextBox)(target));
            
            #line 96 "..\..\Login.xaml"
            this.TextBoxEmail.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.TextBoxEmail_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LabelPassword = ((System.Windows.Controls.Label)(target));
            
            #line 98 "..\..\Login.xaml"
            this.LabelPassword.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.Password_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 6:
            this.PasswordBox = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 99 "..\..\Login.xaml"
            this.PasswordBox.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.PasswordBox_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.ErrorMsg = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.ButtonSignIn = ((System.Windows.Controls.Button)(target));
            
            #line 101 "..\..\Login.xaml"
            this.ButtonSignIn.Click += new System.Windows.RoutedEventHandler(this.ButtonSignIn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 113 "..\..\Login.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ButtonSignUp_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.ButtonSignInWithFacebook = ((System.Windows.Controls.Button)(target));
            
            #line 123 "..\..\Login.xaml"
            this.ButtonSignInWithFacebook.Click += new System.Windows.RoutedEventHandler(this.ButtonSignInWithFacebook_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ButtonMultiplayer = ((System.Windows.Controls.Button)(target));
            
            #line 132 "..\..\Login.xaml"
            this.ButtonMultiplayer.Click += new System.Windows.RoutedEventHandler(this.ButtonMultiplayer_Click);
            
            #line default
            #line hidden
            return;
            case 13:
            this.ButtonPlay = ((System.Windows.Controls.Button)(target));
            
            #line 144 "..\..\Login.xaml"
            this.ButtonPlay.Click += new System.Windows.RoutedEventHandler(this.ButtonPlay_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.checkBox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 155 "..\..\Login.xaml"
            this.checkBox.Checked += new System.Windows.RoutedEventHandler(this.checkBox_Checked);
            
            #line default
            #line hidden
            
            #line 155 "..\..\Login.xaml"
            this.checkBox.Unchecked += new System.Windows.RoutedEventHandler(this.checkBox_UnChecked);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

