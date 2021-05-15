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
using System.Windows.Shapes;
using LioTech.Connections;

namespace LioTech.Windows
{
    public partial class WindowEditor : Window
    {
        public Model_LioTech database { get; set; }
        public Deliveries deliver { get; set; }

        public WindowEditor()
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (deliver == null)
            {
                this.windowHeader.Text = "Добавление поставки";
            }
            else
            {
                this.windowHeader.Text = "Изменение поставки";
                CompanyNameTb.Text = deliver.CompanyName;
                ProductTb.Text = deliver.Product;
                DeparturDateTb.SelectedDate = deliver.DepartureDate;
                ReceivingDateTb.SelectedDate = deliver.ReceivingDate;
                StatusCb.Text = deliver.Status;
            }
        }

        private void DeparturDateTb_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            DeparturDateTb.Foreground = Brushes.Black;
        }

        private void ReceivingDateTb_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            ReceivingDateTb.Foreground = Brushes.Black;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (deliver == null)
            {
                deliver = new Deliveries();

                if (CompanyNameTb.Text == "" || ProductTb.Text == "" || DeparturDateTb.Text == "" || ReceivingDateTb.Text == "" || StatusCb.Text == "")
                {
                    MessageBox.Show("Все поля должны быть заполненны!");
                    return;
                }

                deliver.CompanyName = CompanyNameTb.Text;
                deliver.Product = ProductTb.Text;
                deliver.DepartureDate = DeparturDateTb.SelectedDate.Value;
                deliver.ReceivingDate = ReceivingDateTb.SelectedDate.Value;
                deliver.Status = StatusCb.Text;

                database.Deliveries.Add(deliver);
                try
                {
                    database.SaveChanges();
                    this.DialogResult = true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                if (CompanyNameTb.Text == "" || ProductTb.Text == "" || DeparturDateTb.Text == "" || ReceivingDateTb.Text == "" || StatusCb.Text == "")
                {
                    MessageBox.Show("Все поля должны быть заполненны!");
                    return;
                }

                deliver.CompanyName = CompanyNameTb.Text;
                deliver.Product = ProductTb.Text;
                deliver.DepartureDate = DeparturDateTb.SelectedDate.Value;
                deliver.ReceivingDate = ReceivingDateTb.SelectedDate.Value;
                deliver.Status = StatusCb.Text;

                try
                {
                    database.SaveChanges();
                    this.DialogResult = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
