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
using LioTech.Connections;

namespace LioTech.Windows
{
    public partial class WindowLogin
    {
        readonly Model_LioTech database = new Model_LioTech();

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
                return;
            }

            string loginHash = SHA256Hash(LoginTb.Text);
            string passwordHash = SHA256Hash(PwdBox.Password);

            foreach (Users user in database.Users)
            {
                if(user.Login == loginHash && user.Password == passwordHash)
                {
                    if(RememberBtn.IsChecked.Value == true)
                    {
                        string path = @"C:\Users\LioTechConfig.cfg";
                        try
                        {
                            using (FileStream stream = File.Create(path))
                            {
                                byte[] info = new UTF8Encoding(true).GetBytes($"{loginHash}{passwordHash}");
                                stream.Write(info, 0, info.Length);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        WindowLogist_Start();
                    }
                    else
                    {
                        WindowLogist_Start();
                    }
                }
                else
                {
                    MessageBox.Show("Неверный логин или пароль!");
                    return;
                }
            }
        }

        public static string SHA256Hash(string value)
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

        private void WindowLogist_Start()
        {
            WindowLogist window = new WindowLogist();
            window.Show();
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Hide();
            try
            {
                string path = @"C:\Users\LioTechConfig.cfg";

                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";

                    while ((s = sr.ReadLine()) != null)
                    {
                        foreach (Users user in database.Users)
                        {
                            if (user.Summary_Hash == SHA256Hash(s))
                            {
                                WindowLogist_Start();
                            }
                        }
                    }
                }
            }
            catch
            {
                this.Show();
                return;
            }
        }
    }
}
