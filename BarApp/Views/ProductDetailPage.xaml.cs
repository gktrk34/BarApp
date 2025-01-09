using BarApp.Models;
using BarApp.MockData;
using BarApp.Services.Interfaces;
using Microsoft.Maui.Controls;
using System;
using System.Linq;

namespace BarApp.Views
{
    [QueryProperty(nameof(ProductName), "productName")]
    public partial class ProductDetailPage : ContentPage
    {
        private string _productName;
        private Product _currentProduct;

        // Favoriler servisini burada tutacaðýz (mock veya gerçek)
        private IFavoritesService _favoritesService;

        public string ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged();
                LoadProduct();
            }
        }

        public ProductDetailPage()
        {
            InitializeComponent();

            // ServiceProvider aracýlýðýyla IFavoritesService elde ediyoruz
            _favoritesService = MauiProgram.ServiceProvider.GetService<IFavoritesService>();
        }

        private void LoadProduct()
        {
            // Mock data'dan gelen ürün listesinden ismi eþleþen ürünü çek
            var product = MockProducts.GetProducts()
                .FirstOrDefault(p => p.Name == _productName);

            if (product != null)
            {
                // Sayfa üzerindeki görselleri doldur
                ProductImage.Source = product.ImageUrl;
                ProductNameLabel.Text = product.Name;
                ProductDescriptionLabel.Text = product.Description;

                // Bu ürünü class düzeyinde saklayalým
                _currentProduct = product;
            }
        }

        private void OnFavoriteClicked(object sender, EventArgs e)
        {
            // Eðer _currentProduct varsa, favorilere ekleyelim
            if (_currentProduct != null)
            {
                _favoritesService.AddToFavorites(_currentProduct);

                DisplayAlert("Favori", $"{_currentProduct.Name} favorilere eklendi!", "OK");
            }
            else
            {
                DisplayAlert("Hata", "Ürün bilgisi yüklenemedi!", "OK");
            }
        }

        private void OnAddToBarClicked(object sender, EventArgs e)
        {
            // Henüz BarService eklemediysen mock ya da benzer þekilde yapabilirsin
            DisplayAlert("Bar", $"{_productName} barýna eklendi (Mock)", "OK");
        }
    }
}
