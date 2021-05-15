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
using System.Linq;
using System.Windows.Shapes;
using LioTech.Connections;

namespace LioTech.Windows
{
    public partial class WindowTable : Window
    {

        public Model_LioTech database { get; set; }
        public string TableName;

        public WindowTable()
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
            WindowLogist.MainWindow.Show();
            this.Close();
        }

        private void MinBtn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            switch (TableName)
            {
                case "Deliveries":
                    windowHeader.Text = "Таблица: Поставки";
                    mainBindingSource.ItemsSource = database.Deliveries.ToList();
                    AddBtn.Visibility = Visibility.Visible;
                    ChangeBtn.Visibility = Visibility.Visible;
                    DeleteBtn.Visibility = Visibility.Visible;
                    break;

                case "LiIonBatteries":
                    windowHeader.Text = "Таблица: Литий-ионные аккумуляторы";
                    mainBindingSource.ItemsSource = database.LiIonBatteries.ToList();
                    break;

                case "TractionBatteries_EBus":
                    windowHeader.Text = "Таблица: Тяговые батареи для электробусов";
                    mainBindingSource.ItemsSource = database.TractionBatteries_EBus.ToList();
                    break;

                case "TractionBatteries_SpecialEq":
                    windowHeader.Text = "Таблица: Тяговые батареи для спецтехники";
                    mainBindingSource.ItemsSource = database.TractionBatteries_SpecialEq.ToList();
                    break;

                case "UninterruptiblePowerSupplies":
                    windowHeader.Text = "Таблица: Источники бесперебойного питания";
                    mainBindingSource.ItemsSource = database.UninterruptiblePowerSupplies.ToList();
                    break;

                case "NetworkedEnergyStorage":
                    windowHeader.Text = "Таблица: Сетевые накопители";
                    mainBindingSource.ItemsSource = database.NetworkedEnergyStorage.ToList();
                    break;

                default:
                    windowHeader.Text = "Таблица: Разное";
                    mainBindingSource.ItemsSource = database.Different.ToList();
                    break;
            }

        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowLogist.MainWindow.Show();
            this.Close();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowEditor window = new WindowEditor();
            window.database = database;
            window.deliver = null;
            this.Hide();
            if(window.ShowDialog() == true)
            {
                mainBindingSource.ItemsSource = null;
                mainBindingSource.ItemsSource = database.Deliveries.ToList();
                this.Show();
            }
            else
            {
                this.Show();
            }
        }

        private void ChangeBtn_Click(object sender, RoutedEventArgs e)
        {
            WindowEditor window = new WindowEditor();
            window.database = database;
            window.deliver = (Deliveries)mainBindingSource.SelectedItem;
            this.Hide();
            if (window.ShowDialog() == true)
            {
                mainBindingSource.ItemsSource = null;
                mainBindingSource.ItemsSource = database.Deliveries.ToList();
                this.Show();
            }
            else
            {
                this.Show();
            }
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            Deliveries deliver = (Deliveries)mainBindingSource.SelectedItem;

            MessageBoxResult result = MessageBox.Show("Удалить запись?", "Удаление записи",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            
            if (result == MessageBoxResult.Yes)
            {
                database.Deliveries.Remove(deliver);

                try
                {
                    database.SaveChanges();
                    mainBindingSource.ItemsSource = null;
                    mainBindingSource.ItemsSource = database.Deliveries.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
