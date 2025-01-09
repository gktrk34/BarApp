using BarApp.Models;
using BarApp.Services.Interfaces; // IFavoritesService'i buradan alýyoruz
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
            // Aþaðýdaki satýrýn çalýþmasý için MauiProgram.ServiceProvider tanýmlanmýþ olmalý
            _favoritesService = MauiProgram.ServiceProvider.GetService<IFavoritesService>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Favori ürünleri yükleyip CollectionView'e baðlayalým
            FavoritesCollection.ItemsSource = _favoritesService.GetAllFavorites();
        }

        private void OnRemoveFavoriteSwiped(object sender, EventArgs e)
        {
            // 'Çýkar' butonuna basýldý
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
