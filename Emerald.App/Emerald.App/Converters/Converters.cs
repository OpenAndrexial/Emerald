﻿using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emerald.WinUI.Converters
{
    public class StringToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            // Reversed result
            if (parameter is string param)
            {
                if (param == "0")
                {
                    return (value is string val && val.Length > 0) ? Visibility.Collapsed : Visibility.Visible;
                }
            }

            return (value is string str && str.Length > 0) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new InvalidOperationException("Use the boolean to visibility converter in this situation. " +
                "A string is very likely unnecessary in this case.");
        }
    }

    public class BindlessStringToVisibility
    {
        public static Visibility BindlessConvert(object value)
        {
            return (value is string str && str.Length > 0) ? Visibility.Visible : Visibility.Collapsed;
        }

        public static void BindlessConvertBack(object value)
        {
            throw new InvalidOperationException("Use the boolean to visibility converter in this situation." +
                "A string is very likely unnecessary in this case. You tried to convert: " + value.ToString());
        }
    }
    public class BoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool b && b) ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (value is bool b && b) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
    public class NotBoolToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (value is bool b && b) ? Visibility.Collapsed : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return (value is bool b && b) ? Visibility.Collapsed : Visibility.Visible;
        }
    }
    public class InfobarServertyToBackground : IValueConverter
    {
        public Brush ErrorBrush { get; set; }
        public Brush WarningBrush { get; set; }
        public Brush SuccessBrush { get; set; }
        public Brush InformationalBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (Microsoft.UI.Xaml.Controls.InfoBarSeverity)value switch
            {
                Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error => ErrorBrush,
                Microsoft.UI.Xaml.Controls.InfoBarSeverity.Warning => WarningBrush,
                Microsoft.UI.Xaml.Controls.InfoBarSeverity.Success => SuccessBrush,
                Microsoft.UI.Xaml.Controls.InfoBarSeverity.Informational => InformationalBrush,
                _ => InformationalBrush,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new InvalidOperationException("Error lol.");
        }

    }
    public class InfobarServertyToIconGlyph: IValueConverter
    {
        public string ErrorString{ get; set; }
        public string WarningString { get; set; }
        public string SuccessString { get; set; }
        public string InformationalString { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            return (Microsoft.UI.Xaml.Controls.InfoBarSeverity)value switch
            {
                Microsoft.UI.Xaml.Controls.InfoBarSeverity.Error => ErrorString,
                Microsoft.UI.Xaml.Controls.InfoBarSeverity.Warning => WarningString,
                Microsoft.UI.Xaml.Controls.InfoBarSeverity.Success => SuccessString,
                Microsoft.UI.Xaml.Controls.InfoBarSeverity.Informational => InformationalString,
                _ => InformationalString,
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new InvalidOperationException("Error lol.");
        }

    }
}