using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace WpfApplication2
{
    public class BoolToBrushConverter : DependencyObject, IValueConverter
    {

        public SolidColorBrush TrueBrush
        {
            get { return (SolidColorBrush)GetValue(TrueBrushProperty); }
            set { SetValue(TrueBrushProperty, value); }
        }

        public SolidColorBrush FalseBrush
        {
            get { return (SolidColorBrush)GetValue(FalseBrushProperty); }
            set { SetValue(FalseBrushProperty, value); }
        }

        public static readonly DependencyProperty TrueBrushProperty =
            DependencyProperty.Register("TrueBrush", typeof(SolidColorBrush), typeof(BoolToBrushConverter));

        public static readonly DependencyProperty FalseBrushProperty =
            DependencyProperty.Register("FalseBrush", typeof(SolidColorBrush), typeof(BoolToBrushConverter));


        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((bool)value)
            {
                return TrueBrush;
            }

            return FalseBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
