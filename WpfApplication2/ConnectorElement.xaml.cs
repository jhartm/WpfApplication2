using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for ConnectorElement.xaml
    /// </summary>
    public partial class ConnectorElement : UserControl
    {
        public ConnectorElement()
        {
            InitializeComponent();
        }

        #region Properties
        public int X1
        {
            get { return (int)GetValue(X1Property); }
            set { SetValue(X1Property, value); }
        }

        public int Y1
        {
            get { return (int)GetValue(Y1Property); }
            set { SetValue(Y1Property, value); }
        }

        public int X2
        {
            get { return (int)GetValue(X2Property); }
            set { SetValue(X2Property, value); }
        }

        public int Y2
        {
            get { return (int)GetValue(Y2Property); }
            set { SetValue(Y2Property, value); }
        }
        #endregion

        #region Dependency Properties
        public static readonly DependencyProperty X1Property =
            DependencyProperty.Register("X1", typeof(int), typeof(ConnectorElement),
            new PropertyMetadata(20));

        public static readonly DependencyProperty Y1Property =
            DependencyProperty.Register("Y1", typeof(int), typeof(ConnectorElement),
            new PropertyMetadata(20));

        public static readonly DependencyProperty X2Property =
            DependencyProperty.Register("X2", typeof(int), typeof(ConnectorElement),
            new PropertyMetadata(100));

        public static readonly DependencyProperty Y2Property =
            DependencyProperty.Register("Y2", typeof(int), typeof(ConnectorElement),
            new PropertyMetadata(20));
        #endregion


    }
}
