﻿#pragma checksum "..\..\..\..\View\MappingView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "E49CB88EEBD125CD348E878AC03224E62D4B19A9"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.42000
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using test.Common;
using test.Resources;
using test.View;


namespace test.View {
    
    
    /// <summary>
    /// MappingView
    /// </summary>
    public partial class MappingView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 201 "..\..\..\..\View\MappingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox ExampleCheckBox;
        
        #line default
        #line hidden
        
        
        #line 202 "..\..\..\..\View\MappingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal test.Common.PopupEx pop1;
        
        #line default
        #line hidden
        
        
        #line 244 "..\..\..\..\View\MappingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ScrollViewer scrollView;
        
        #line default
        #line hidden
        
        
        #line 245 "..\..\..\..\View\MappingView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas CanvasInPath;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/test;V1.0.0.0;component/view/mappingview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\View\MappingView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 11 "..\..\..\..\View\MappingView.xaml"
            ((test.View.MappingView)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_Keydown);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\..\View\MappingView.xaml"
            ((test.View.MappingView)(target)).KeyUp += new System.Windows.Input.KeyEventHandler(this.Window_KeyUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.ExampleCheckBox = ((System.Windows.Controls.CheckBox)(target));
            return;
            case 5:
            this.pop1 = ((test.Common.PopupEx)(target));
            return;
            case 6:
            this.scrollView = ((System.Windows.Controls.ScrollViewer)(target));
            return;
            case 7:
            this.CanvasInPath = ((System.Windows.Controls.Canvas)(target));
            
            #line 245 "..\..\..\..\View\MappingView.xaml"
            this.CanvasInPath.MouseMove += new System.Windows.Input.MouseEventHandler(this.CanvasInPath_MouseMove);
            
            #line default
            #line hidden
            
            #line 245 "..\..\..\..\View\MappingView.xaml"
            this.CanvasInPath.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CanvasInPath_MouseLeftButtonDown);
            
            #line default
            #line hidden
            
            #line 245 "..\..\..\..\View\MappingView.xaml"
            this.CanvasInPath.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.CanvasInPath_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.17.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 42 "..\..\..\..\View\MappingView.xaml"
            ((System.Windows.Controls.Primitives.RepeatButton)(target)).Click += new System.Windows.RoutedEventHandler(this.HorizontalScrollBarRepeatButon_Click);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 61 "..\..\..\..\View\MappingView.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Restore_Click);
            
            #line default
            #line hidden
            
            #line 61 "..\..\..\..\View\MappingView.xaml"
            ((System.Windows.Controls.Button)(target)).MouseRightButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CanvasInPath_MouseRightButtonDown);
            
            #line default
            #line hidden
            
            #line 61 "..\..\..\..\View\MappingView.xaml"
            ((System.Windows.Controls.Button)(target)).KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_Keydown);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

