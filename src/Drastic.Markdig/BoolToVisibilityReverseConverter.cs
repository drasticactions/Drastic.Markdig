﻿using System;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml;

namespace Utilities.Common
{
    public class BoolToVisibilityReverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
            => !(bool)value ? Visibility.Visible : Visibility.Collapsed;

        public object ConvertBack(object value, Type targetType, object parameter, string language)
            => (Visibility)value != Visibility.Visible;
    }
}
