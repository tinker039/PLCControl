﻿using PLCControl.ViewModel;
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
    /// ConnectionTestView.xaml 的交互逻辑
    /// </summary>
    public partial class ConnectionTestView : Page
    {

        public ConnectionTestView()
        {
            InitializeComponent();
            this.Focus();
        }


        private void changeAddressDT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox tb = sender as TextBox;
                BindingExpression binding = tb.GetBindingExpression(TextBox.TextProperty);
                binding.UpdateSource();
            }
        }



        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            ConnectionTestViewModel c = DataContext as ConnectionTestViewModel;
            c.Unloaded(sender, e);
        }
    }
}
