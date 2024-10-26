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
using System.Net.Http;
using System.Net.Http.Json;
using Lab3.Models;
using Lab4.Services;
using sun.security.util;

namespace Lab4
{
    public partial class MainWindow : Window
    {
        private readonly ApiClient _apiClient;

        public MainWindow()
        {
            InitializeComponent();
            _apiClient = new ApiClient(new HttpClient { BaseAddress = new Uri("http://localhost:5000/") });
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var user = new User { Email = Login.Text, Password = Password.Password };
            var response = await _apiClient.LoginAsync(user);

            if (response?.access_token != null)
            {
                MessageBox.Show($"Welcome {response.username}!");
            }
            else
            {
                MessageBox.Show("Invalid credentials!");
            }
        }
    }
}