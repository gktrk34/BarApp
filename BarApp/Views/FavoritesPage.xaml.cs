using BarApp.Models;
using BarApp.Services.Interfaces;
using BarApp.ViewModels;
using System.Collections.ObjectModel;

namespace BarApp.Views;

public partial class FavoritesPage : ContentPage
{
    private readonly IFavoritesService _favoritesService;
    public ObservableCollection<Product> Favorites { get; set; }

    public FavoritesPage()
    {
        InitializeComponent();
        _favoritesService = MauiProgram.ServiceProvider.GetService<IFavoritesService>();
        // BindingContext'i ayarla ve Favorites'i doldur:
        BindingContext = new FavoritesPageViewModel { Favorites = new ObservableCollection<Product>(_favoritesService.GetAllFavorites()) };
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        // Sayfa her göründüðünde listeyi güncelle:
        Favorites = new ObservableCollection<Product>(_favoritesService.GetAllFavorites());
        FavoritesCollection.ItemsSource = Favorites;

    }

    private void OnRemoveFavoriteSwiped(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipeItem && swipeItem.CommandParameter is Product product)
        {
            _favoritesService.RemoveFromFavorites(product);
            // Doðrudan Favorites koleksiyonundan ürünü sil:
            Favorites.Remove(product);
        }
    }
}