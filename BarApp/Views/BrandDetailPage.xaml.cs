using Microsoft.Maui.Controls;
using BarApp.Models;
using BarApp.MockData;
using System.Linq;
using System.Collections.Generic;
using BarApp.Views;

namespace BarApp.Views
{
    [QueryProperty(nameof(BrandName), "brandName")]
    public partial class BrandDetailPage : ContentPage
    {
        private string _brandName;
        public string BrandName
        {
            get => _brandName;
            set
            {
                _brandName = value;
                OnPropertyChanged();
                LoadBrandDetails();
            }
        }

        public BrandDetailPage()
        {
            InitializeComponent();
        }

        private void LoadBrandDetails()
        {
            // Markalar içinde bul
            var brand = MockBrands.GetBrands()
                                  .FirstOrDefault(b => b.Name == _brandName);

            if (brand != null)
            {
                // Marka bilgilerini göster
                BrandLogo.Source = brand.ImageUrl;
                BrandNameLabel.Text = brand.Name;
                BrandDescriptionLabel.Text = brand.Description;

                // Markaya ait ürünleri filtrele
                var allProducts = MockProducts.GetProducts();
                var brandProducts = allProducts
                    .Where(p => p.BrandName == brand.Name)
                    .ToList();

                ProductsCollection.ItemsSource = brandProducts;
            }
        }

        private async void OnProductSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                var selectedProduct = e.CurrentSelection[0] as Product;
                if (selectedProduct != null)
                {
                    // ProductDetailPage'e navigasyon yapalým
                    string route = $"ProductDetailPage?productName={selectedProduct.Name}";
                    await Shell.Current.GoToAsync(route);
                }

                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
