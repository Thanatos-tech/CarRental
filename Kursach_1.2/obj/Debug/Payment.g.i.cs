﻿#pragma checksum "..\..\Payment.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "D62A48EBB9AF30CBE29DB12E97A59E99B3AE785B5B0EB99DC61917A04FBB7149"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Kursach_1._2;
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


namespace Kursach_1._2 {
    
    
    /// <summary>
    /// Payment
    /// </summary>
    public partial class Payment : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 12 "..\..\Payment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox field1;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Payment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox field2;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\Payment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox field3;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\Payment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox field4;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\Payment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox field5;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\Payment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox field6;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Payment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label field7;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\Payment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label errorLabel;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Payment.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button payButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Kursach_1.2;component/payment.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Payment.xaml"
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
            this.field1 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.field2 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.field3 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.field4 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.field5 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.field6 = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.field7 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.errorLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.payButton = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\Payment.xaml"
            this.payButton.Click += new System.Windows.RoutedEventHandler(this.payButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

