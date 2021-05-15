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
        Model_LioTech database = new Model_LioTech();

        public static WindowLogist MainWindow { get; set; }

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
            MainWindow = this;
            WindowTable window = new WindowTable
            {
                database = database,
                TableName = "Deliveries"
            };
            this.Hide();
            window.Show();
        }

        private void LiIonBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow = this;
            WindowTable window = new WindowTable
            {
                database = database,
                TableName = "LiIonBatteries"
            };
            this.Hide();
            window.Show();
        }

        private void EBusBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow = this;
            WindowTable window = new WindowTable
            {
                database = database,
                TableName = "TractionBatteries_EBus"
            };
            this.Hide();
            window.Show();
        }

        private void SpecialEqBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow = this;
            WindowTable window = new WindowTable
            {
                database = database,
                TableName = "TractionBatteries_SpecialEq"
            };
            this.Hide();
            window.Show();
        }

        private void UpsBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow = this;
            WindowTable window = new WindowTable
            {
                database = database,
                TableName = "UninterruptiblePowerSupplies"
            };
            this.Hide();
            window.Show();
        }

        private void NesBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow = this;
            WindowTable window = new WindowTable
            {
                database = database,
                TableName = "NetworkedEnergyStorage"
            };
            this.Hide();
            window.Show();
        }

        private void DifferentBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow = this;
            WindowTable window = new WindowTable
            {
                database = database,
                TableName = "Different"
            };
            this.Hide();
            window.Show();
        }

        private void Logo_MouseDown(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("http://liotech.ru");
        }
    }
}
