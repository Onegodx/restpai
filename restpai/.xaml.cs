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
using Lab4.Services;
using System.Security.Cryptography;
using Lab4.Models;
using Azure;
using static Azure.Core.HttpHeader;
using Lab4.Models;

namespace Lab4
{
    public partial class AddEditSale : Window
    {
        private readonly ApiClient _apiClient;

        public AddEditSale()
        {
            InitializeComponent();
            _apiClient = new ApiClient(new HttpClient { BaseAddress = new Uri("http://localhost:5000/") });
            LoadPriceLists();
        }

        private async void LoadPriceLists()
        {
            var priceLists = await _apiClient.GetPriceListsAsync();
            cbMarka.ItemsSource = priceLists;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var sale = new Sales
            {
                DateSale = DatePicker.SelectedDate.Value,
                FIO = FIO.Text,
                PriceList_Id = ((PriceList)cbMarka.SelectedItem).Id,
                Complect = lbComplect.Content.ToString(),
                Discount = int.Parse(tbDiscounr.Text),
                TotalPrice = CalculateTotalPrice()
            };

            await _apiClient.CreateSaleAsync(sale);
            MessageBox.Show("Sale added successfully!");
            Close();
        }

        private decimal CalculateTotalPrice()
        {
            // Ваш алгоритм для расчета итоговой цены с учетом скидки
            return 0; // заменить на реальную логику
        }
    }
}