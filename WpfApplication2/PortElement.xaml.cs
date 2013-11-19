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
    /// Interaction logic for PortElement.xaml
    /// </summary>
    public partial class PortElement : UserControl
    {
        public PortElement()
        {
            InitializeComponent();
        }

        private void PopupClick(object sender, RoutedEventArgs e)
        {
            if (popup.IsOpen)
            {
                popup.IsOpen = false;
            }
            else
            {
                popup.IsOpen = true;
            }
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            popup.StaysOpen = true;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            popup.StaysOpen = false;
        }
    }
}
