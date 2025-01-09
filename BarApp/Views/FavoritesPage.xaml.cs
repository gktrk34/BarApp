using BarApp.Models;
using BarApp.Services.Interfaces; // IFavoritesService'i buradan al�yoruz
using Microsoft.Maui.Controls;

namespace BarApp.Views
{
    public partial class FavoritesPage : ContentPage
    {
        private readonly IFavoritesService _favoritesService;

        public FavoritesPage()
        {
            InitializeComponent();

            // Service locator veya DI: 
            // A�a��daki sat�r�n �al��mas� i�in MauiProgram.ServiceProvider tan�mlanm�� olmal�
            _favoritesService = MauiProgram.ServiceProvider.GetService<IFavoritesService>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Favori �r�nleri y�kleyip CollectionView'e ba�layal�m
            FavoritesCollection.ItemsSource = _favoritesService.GetAllFavorites();
        }

        private void OnRemoveFavoriteSwiped(object sender, EventArgs e)
        {
            // '��kar' butonuna bas�ld�
            if (sender is SwipeItem swipeItem && swipeItem.CommandParameter is Product product)
            {
                _favoritesService.RemoveFromFavorites(product);

                // Listeyi yenile
                FavoritesCollection.ItemsSource = null;
                FavoritesCollection.ItemsSource = _favoritesService.GetAllFavorites();
            }
        }
    }
}
