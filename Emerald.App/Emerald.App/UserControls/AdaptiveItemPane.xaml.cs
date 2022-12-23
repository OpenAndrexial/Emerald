// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Emerald.WinUI.UserControls
{

    /// <summary>
    /// A nice control from the RiseMP
    /// </summary>
    public sealed partial class AdaptiveItemPane : UserControl
    {
        public static DependencyProperty LeftPaneProperty =
            DependencyProperty.Register("LeftPane", typeof(object),
                typeof(AdaptiveItemPane), new PropertyMetadata(null));

        public object LeftPane
        {
            get => GetValue(LeftPaneProperty);
            set => SetValue(LeftPaneProperty, value);
        }

        public static DependencyProperty RightPaneProperty =
            DependencyProperty.Register("RightPane", typeof(object),
                typeof(AdaptiveItemPane), new PropertyMetadata(null));

        public object RightPane
        {
            get => GetValue(RightPaneProperty);
            set => SetValue(RightPaneProperty, value);
        }

        public static DependencyProperty BreakpointProperty =
            DependencyProperty.Register("Breakpoint", typeof(double),
                typeof(AdaptiveItemPane), new PropertyMetadata(double.NaN));

        public double Breakpoint
        {
            get => (double)GetValue(BreakpointProperty);
            set => SetValue(BreakpointProperty, value);
        }

        private long _leftToken;
        private long _rightToken;

        public AdaptiveItemPane()
        {
            InitializeComponent();
        }

        private void OnControlLoaded(object sender, RoutedEventArgs e)
        {
            UpdateBreakpoint(this);
            PerformResize(ActualWidth);

            _leftToken = RegisterPropertyChangedCallback(LeftPaneProperty, OnPanesUpdated);
            _rightToken = RegisterPropertyChangedCallback(RightPaneProperty, OnPanesUpdated);
        }

        private void OnControlUnloaded(object sender, RoutedEventArgs e)
        {
            UnregisterPropertyChangedCallback(LeftPaneProperty, _leftToken);
            UnregisterPropertyChangedCallback(RightPaneProperty, _rightToken);
        }
    }

    // Event handlers
    public sealed partial class AdaptiveItemPane
    {
        private static void OnPanesUpdated(DependencyObject d, DependencyProperty dp)
        {
            if (d is AdaptiveItemPane pane)
                UpdateBreakpoint(pane);
        }

        private static void UpdateBreakpoint(AdaptiveItemPane pane)
        {
            pane.Breakpoint = pane.Left.DesiredSize.Width + pane.Right.DesiredSize.Width;
        }

        private void Pane_SizeChanged(object sender, SizeChangedEventArgs e)
            => PerformResize(e.NewSize.Width);

        private void PerformResize(double width)
        {
            if (width - 12 < Breakpoint)
                VisualStateManager.GoToState(this, "Stacked", false);
            else
                VisualStateManager.GoToState(this, "SideBySide", false);
        }
    }
}
