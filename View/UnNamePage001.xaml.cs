using PLCControl.PLC;
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

namespace PLCControl.View
{
    /// <summary>
    /// UnNamePage001.xaml 的交互逻辑
    /// </summary>
    public partial class UnNamePage001 : Page
    {
        public UnNamePage001()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            txtBox.Text = CPLC.Instance.ReadString("D10", 20);
        }
    }
}
