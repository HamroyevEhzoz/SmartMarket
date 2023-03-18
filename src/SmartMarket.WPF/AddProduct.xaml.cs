using SmartMarket.WPF.DomainLayer.Entities;
using SmartMarket.WPF.Infrastructure.Services;
using System;
using System.Windows;

namespace SmartMarket.WPF
{
    /// <summary>
    /// Interaction logic for AddProduct.xaml
    /// </summary>
    public partial class AddProduct : Window
    {
        private readonly ProductService _productService;
        public AddProduct()
        {
            InitializeComponent();
            _productService = new ProductService();

            //Vaqtinchalik test uchun yozilgan kod bu
            CategoriesLabel.FontWeight = FontWeights.Bold;
            CategoriesLabel.Content = "1.Oziq-Ovqat; 2.Meva; 3.Sut-Mahsulotlari;";
        }

        private async void AddProductButtom_Click(object sender, RoutedEventArgs e)
        {
            var name = ProductNameTextBox.Text;
            var productCode = ProductCodeTextBox.Text;

            var isCorrectCategoryId = int.TryParse(ProductCategoryTextBox.Text, out int productCategoryId);
            var isCorrectPrice = double.TryParse(ProductPriceTextBox.Text, out double price);
            var isCorrectAmount = int.TryParse(ProductAmountTextBox.Text, out int productAmount);

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(productCode) || string.IsNullOrEmpty(ProductAmountTextBox.Text)
                || string.IsNullOrEmpty(ProductPriceTextBox.Text) || string.IsNullOrEmpty(ProductCategoryTextBox.Text))
            {
                MessageBox.Show("Barcha satrlar to'ldirilishi shart!"
                                , "Ogohlantirish"
                                , MessageBoxButton.OKCancel
                                , MessageBoxImage.Warning);

                return;
            }

            if (isCorrectCategoryId == false)
            {
                MessageBox.Show("CategoryId ga notog'ri formatda qiymat kirtilindi!"
                                , "Ogohlantirish"
                                , MessageBoxButton.OKCancel
                                , MessageBoxImage.Warning);

                ProductCategoryTextBox.Clear();
                return;
            }

            if (isCorrectPrice == false)
            {
                MessageBox.Show("Mahsulot Narxi ga notog'ri formatda qiymat kirtilindi!"
                                , "Ogohlantirish"
                                , MessageBoxButton.OKCancel
                                , MessageBoxImage.Warning);

                ProductPriceTextBox.Clear();
                return;
            }

            if (isCorrectAmount == false)
            {
                MessageBox.Show("Mahsulot miqdori ga Notog'ri formatda qiymat kirtilindi!"
                                , "Ogohlantirish"
                                , MessageBoxButton.OKCancel
                                , MessageBoxImage.Warning);

                ProductAmountTextBox.Clear();
                return;
            }

            var product = new Product
            {
                Name = name,
                ProductCode = productCode,
                Price = price,
                TotalAmount = productAmount,
                CategoryId = productCategoryId
            };

            try
            {
                await _productService.AddProductAsync(product);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);
            }
            finally
            {
                MessageBox.Show("Mahsulot muvofaqiyatli qo'shildi!"
                               , "AweSome"
                               , MessageBoxButton.OKCancel
                               , MessageBoxImage.Information);

                ProductAmountTextBox.Clear();
                ProductNameTextBox.Clear();
                ProductPriceTextBox.Clear();
                ProductCategoryTextBox.Clear();
                ProductCodeTextBox.Clear();
            }
        }
    }
}
