using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using LioTech.Connections;

namespace LioTech.Windows
{
    public partial class WindowLogist : Window
    {
        readonly Model_LioTech database = new Model_LioTech();

        public static WindowLogist mainWindow { get; set; }

        public WindowLogist()
        {
            InitializeComponent();
        }

        private void DragMovement(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void СloseBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void DeliveriesBtn_Click(object sender, RoutedEventArgs e)
        {
            mainWindow = this;
            WindowDeliveries window = new WindowDeliveries
            {
                database = database
            };
            this.Hide();
            window.Show();
        }
    }
}
