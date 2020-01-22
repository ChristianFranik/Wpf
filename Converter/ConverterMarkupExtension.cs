using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace Wpf.Converter
{
    public abstract class ConverterMarkupExtension<T> : MarkupExtension, IValueConverter where T : class, new()
    {
        //======================================================================
        // Properties
        //======================================================================
        private static T converter = null;

        //======================================================================
        // Public methods
        //======================================================================
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return converter ?? (converter = new T());
        }
        public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);
        public abstract object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
    }
}
