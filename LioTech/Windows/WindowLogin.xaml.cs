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
using System.IO;
using System.Security.Cryptography;

namespace LioTech.Windows
{
    public partial class WindowLogin
    {
        public WindowLogin()
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

        private void PwdInputHandler(object sender, RoutedEventArgs e)
        {
            if (PwdBox.Password.Length > 0)
                wmark_pwd.Visibility = Visibility.Collapsed;

            else
                wmark_pwd.Visibility = Visibility.Visible;
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTb.Text == "" || PwdBox.Password == "")
            {
                MessageBox.Show("Пожалуйста, заполните все поля");
            }
            else
            {

            }
        }

        public static String sha256_hash(String value)
        {
            StringBuilder Sb = new StringBuilder();

            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                Byte[] result = hash.ComputeHash(enc.GetBytes(value));

                foreach (Byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }
    }
}
