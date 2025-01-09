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
            if (_currentProduct != null)
            {
                // _currentProduct'ýn referansýný kaybetmemek için bir kopyasýný oluþturuyoruz:
                var productToAdd = new Product
                {
                    Name = _currentProduct.Name,
                    ImageUrl = _currentProduct.ImageUrl,
                    BrandName = _currentProduct.BrandName,
                    Description = _currentProduct.Description
                    // Diðer özellikleri de kopyala...
                };

                _favoritesService.AddToFavorites(productToAdd);

                // Eklenen ürün favorilerde görünüyor mu kontrolü (Ýsim ve resim ile kontrol ediyoruz):
                var isAdded = _favoritesService.GetAllFavorites().Any(p => p.Name == productToAdd.Name && p.ImageUrl == productToAdd.ImageUrl);
                if (isAdded)
                {
                    DisplayAlert("Favori", $"{productToAdd.Name} favorilere eklendi!", "OK");
                }
                else
                {
                    DisplayAlert("Hata", $"{productToAdd.Name} favorilere eklenemedi!", "OK");
                }
            }
        }


        private void OnAddToBarClicked(object sender, EventArgs e)
        {
            // Henüz BarService eklemediysen mock ya da benzer þekilde yapabilirsin
            DisplayAlert("Bar", $"{_productName} barýna eklendi (Mock)", "OK");
        }
    }
}
