﻿#pragma checksum "..\..\foodMenuWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "E36B5FAAEBF907AA287F32DC0E8C2C2DF4308D20C58DAD1455716E27945DB570"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using HotelManegmantWpfApp;
using MahApps.Metro;
using MahApps.Metro.Accessibility;
using MahApps.Metro.Actions;
using MahApps.Metro.Automation.Peers;
using MahApps.Metro.Behaviors;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Converters;
using MahApps.Metro.Markup;
using MahApps.Metro.Theming;
using MahApps.Metro.ValueBoxes;
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


namespace HotelManegmantWpfApp {
    
    
    /// <summary>
    /// foodMenuWindow
    /// </summary>
    public partial class foodMenuWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\foodMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox breakfastCheckbox;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\foodMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown breakfastQTY;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\foodMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox lunchCheckbox;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\foodMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown lunchQTY;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\foodMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox dinnerCheckbox;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\foodMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.Controls.NumericUpDown dinnerQTY;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\foodMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cleaningCheckbox;
        
        #line default
        #line hidden
        
        
        #line 61 "..\..\foodMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox towelsCheckbox;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\foodMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox surpriseCheckbox;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\foodMenuWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button nextBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/HotelManegmantWpfApp;component/foodmenuwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\foodMenuWindow.xaml"
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
            this.breakfastCheckbox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 41 "..\..\foodMenuWindow.xaml"
            this.breakfastCheckbox.Unchecked += new System.Windows.RoutedEventHandler(this.breakfastCheckbox_Unchecked);
            
            #line default
            #line hidden
            
            #line 41 "..\..\foodMenuWindow.xaml"
            this.breakfastCheckbox.Checked += new System.Windows.RoutedEventHandler(this.breakfastCheckbox_Checked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.breakfastQTY = ((MahApps.Metro.Controls.NumericUpDown)(target));
            return;
            case 3:
            this.lunchCheckbox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 47 "..\..\foodMenuWindow.xaml"
            this.lunchCheckbox.Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 47 "..\..\foodMenuWindow.xaml"
            this.lunchCheckbox.Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.lunchQTY = ((MahApps.Metro.Controls.NumericUpDown)(target));
            return;
            case 5:
            this.dinnerCheckbox = ((System.Windows.Controls.CheckBox)(target));
            
            #line 53 "..\..\foodMenuWindow.xaml"
            this.dinnerCheckbox.Checked += new System.Windows.RoutedEventHandler(this.dinnerCheckbox_Checked);
            
            #line default
            #line hidden
            
            #line 53 "..\..\foodMenuWindow.xaml"
            this.dinnerCheckbox.Unchecked += new System.Windows.RoutedEventHandler(this.dinnerCheckbox_Unchecked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.dinnerQTY = ((MahApps.Metro.Controls.NumericUpDown)(target));
            return;
            case 7:
            this.cleaningCheckbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 8:
            this.towelsCheckbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 9:
            this.surpriseCheckbox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 10:
            this.nextBtn = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\foodMenuWindow.xaml"
            this.nextBtn.Click += new System.Windows.RoutedEventHandler(this.nextBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

