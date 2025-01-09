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

        // Favoriler servisini burada tutaca��z (mock veya ger�ek)
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

            // ServiceProvider arac�l���yla IFavoritesService elde ediyoruz
            _favoritesService = MauiProgram.ServiceProvider.GetService<IFavoritesService>();
        }

        private void LoadProduct()
        {
            // Mock data'dan gelen �r�n listesinden ismi e�le�en �r�n� �ek
            var product = MockProducts.GetProducts()
                .FirstOrDefault(p => p.Name == _productName);

            if (product != null)
            {
                // Sayfa �zerindeki g�rselleri doldur
                ProductImage.Source = product.ImageUrl;
                ProductNameLabel.Text = product.Name;
                ProductDescriptionLabel.Text = product.Description;

                // Bu �r�n� class d�zeyinde saklayal�m
                _currentProduct = product;
            }
        }

        private void OnFavoriteClicked(object sender, EventArgs e)
        {
            if (_currentProduct != null)
            {
                // _currentProduct'�n referans�n� kaybetmemek i�in bir kopyas�n� olu�turuyoruz:
                var productToAdd = new Product
                {
                    Name = _currentProduct.Name,
                    ImageUrl = _currentProduct.ImageUrl,
                    BrandName = _currentProduct.BrandName,
                    Description = _currentProduct.Description
                    // Di�er �zellikleri de kopyala...
                };

                _favoritesService.AddToFavorites(productToAdd);

                // Eklenen �r�n favorilerde g�r�n�yor mu kontrol� (�sim ve resim ile kontrol ediyoruz):
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
            // Hen�z BarService eklemediysen mock ya da benzer �ekilde yapabilirsin
            DisplayAlert("Bar", $"{_productName} bar�na eklendi (Mock)", "OK");
        }
    }
}
