using System.Windows;

namespace SmartMarket.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            var addProduct = new AddProduct();
            addProduct.Show();
        }

        private void BuyProductButton_Click(object sender, RoutedEventArgs e)
        {
            var buyProduct = new BuyProduct();
            buyProduct.Show();
        }
    }
}
