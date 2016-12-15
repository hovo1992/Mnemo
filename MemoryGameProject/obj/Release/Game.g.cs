﻿#pragma checksum "..\..\Game.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "67C0D107EF8229F397F6147055D62311"
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
    /// Game
    /// </summary>
    public partial class Game : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 14 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid ContentElement;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelUser;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonLogOut;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelBestScore;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel wrapPanel;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextSize;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonPlay;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ButtonHint;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label LabelScore;
        
        #line default
        #line hidden
        
        
        #line 88 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Slider uiScaleSlider;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\Game.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MyGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/MemoryGameProject;component/game.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Game.xaml"
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
            this.ContentElement = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            
            #line 21 "..\..\Game.xaml"
            ((System.Windows.Controls.Border)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Game_Loaded);
            
            #line default
            #line hidden
            
            #line 21 "..\..\Game.xaml"
            ((System.Windows.Controls.Border)(target)).ContextMenuClosing += new System.Windows.Controls.ContextMenuEventHandler(this.Game_Closing);
            
            #line default
            #line hidden
            return;
            case 3:
            this.LabelUser = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.ButtonLogOut = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\Game.xaml"
            this.ButtonLogOut.Click += new System.Windows.RoutedEventHandler(this.ButtonLogOut_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.LabelBestScore = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.wrapPanel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 7:
            this.TextSize = ((System.Windows.Controls.TextBox)(target));
            
            #line 27 "..\..\Game.xaml"
            this.TextSize.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.NumericBox_PreviewKeyDown);
            
            #line default
            #line hidden
            return;
            case 8:
            this.ButtonPlay = ((System.Windows.Controls.Button)(target));
            
            #line 37 "..\..\Game.xaml"
            this.ButtonPlay.Click += new System.Windows.RoutedEventHandler(this.ButtonPlay_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.ButtonHint = ((System.Windows.Controls.Button)(target));
            
            #line 61 "..\..\Game.xaml"
            this.ButtonHint.Click += new System.Windows.RoutedEventHandler(this.ButtonHint_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.LabelScore = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.uiScaleSlider = ((System.Windows.Controls.Slider)(target));
            return;
            case 12:
            this.MyGrid = ((System.Windows.Controls.Grid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

