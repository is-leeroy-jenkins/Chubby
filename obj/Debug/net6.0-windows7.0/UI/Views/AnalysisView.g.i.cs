﻿#pragma checksum "..\..\..\..\..\UI\Views\AnalysisView.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "386A8C1EC5D0E95367068F567030498DB39BF448"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Syncfusion;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.BulletGraph;
using Syncfusion.UI.Xaml.CellGrid;
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.UI.Xaml.Controls.DataPager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Layout;
using Syncfusion.UI.Xaml.Diagram.Panels;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using Syncfusion.UI.Xaml.Diagram.Theming;
using Syncfusion.UI.Xaml.DiagramRibbon;
using Syncfusion.UI.Xaml.Gauges;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.RowFilter;
using Syncfusion.UI.Xaml.HeatMap;
using Syncfusion.UI.Xaml.ImageEditor;
using Syncfusion.UI.Xaml.Maps;
using Syncfusion.UI.Xaml.NavigationDrawer;
using Syncfusion.UI.Xaml.ProgressBar;
using Syncfusion.UI.Xaml.Schedule;
using Syncfusion.UI.Xaml.Scheduler;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.UI.Xaml.TextInputLayout;
using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.UI.Xaml.TreeGrid.Filtering;
using Syncfusion.UI.Xaml.TreeMap;
using Syncfusion.UI.Xaml.TreeView;
using Syncfusion.UI.Xaml.TreeView.Engine;
using Syncfusion.Windows;
using Syncfusion.Windows.Collections;
using Syncfusion.Windows.ComponentModel;
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Gantt;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Input;
using Syncfusion.Windows.Controls.Layout;
using Syncfusion.Windows.Controls.Navigation;
using Syncfusion.Windows.Controls.Notification;
using Syncfusion.Windows.Controls.PivotGrid;
using Syncfusion.Windows.Controls.PivotSchemaDesigner;
using Syncfusion.Windows.Controls.RichTextBoxAdv;
using Syncfusion.Windows.Controls.Scroll;
using Syncfusion.Windows.Controls.VirtualTreeView;
using Syncfusion.Windows.Data;
using Syncfusion.Windows.Diagnostics;
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.PropertyGrid;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Styles;
using Syncfusion.Windows.Tools;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Chubby {
    
    
    /// <summary>
    /// AnalysisView
    /// </summary>
    public partial class AnalysisView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 45 "..\..\..\..\..\UI\Views\AnalysisView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ContextMenu MainWindowContextMenu;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Chubby;V1.0.0.0;component/ui/views/analysisview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\..\UI\Views\AnalysisView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.8.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainWindowContextMenu = ((System.Windows.Controls.ContextMenu)(target));
            return;
            case 2:
            
            #line 47 "..\..\..\..\..\UI\Views\AnalysisView.xaml"
            ((Syncfusion.Windows.Shared.MenuItemAdv)(target)).Click += new System.Windows.RoutedEventHandler(this.OnFileMenuOptionClick);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 56 "..\..\..\..\..\UI\Views\AnalysisView.xaml"
            ((Syncfusion.Windows.Shared.MenuItemAdv)(target)).Click += new System.Windows.RoutedEventHandler(this.OnFolderMenuOptionClick);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 67 "..\..\..\..\..\UI\Views\AnalysisView.xaml"
            ((Syncfusion.Windows.Shared.MenuItemAdv)(target)).Click += new System.Windows.RoutedEventHandler(this.OnChromeOptionClick);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 76 "..\..\..\..\..\UI\Views\AnalysisView.xaml"
            ((Syncfusion.Windows.Shared.MenuItemAdv)(target)).Click += new System.Windows.RoutedEventHandler(this.OnEdgeOptionClick);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 85 "..\..\..\..\..\UI\Views\AnalysisView.xaml"
            ((Syncfusion.Windows.Shared.MenuItemAdv)(target)).Click += new System.Windows.RoutedEventHandler(this.OnFirefoxOptionClick);
            
            #line default
            #line hidden
            return;
            case 7:
            
            #line 96 "..\..\..\..\..\UI\Views\AnalysisView.xaml"
            ((Syncfusion.Windows.Shared.MenuItemAdv)(target)).Click += new System.Windows.RoutedEventHandler(this.OnCalculatorMenuOptionClick);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 105 "..\..\..\..\..\UI\Views\AnalysisView.xaml"
            ((Syncfusion.Windows.Shared.MenuItemAdv)(target)).Click += new System.Windows.RoutedEventHandler(this.OnControlPanelOptionClick);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 114 "..\..\..\..\..\UI\Views\AnalysisView.xaml"
            ((Syncfusion.Windows.Shared.MenuItemAdv)(target)).Click += new System.Windows.RoutedEventHandler(this.OnTaskManagerOptionClick);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 125 "..\..\..\..\..\UI\Views\AnalysisView.xaml"
            ((Syncfusion.Windows.Shared.MenuItemAdv)(target)).Click += new System.Windows.RoutedEventHandler(this.OnCloseOptionClick);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

