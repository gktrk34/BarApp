using BarApp.Models;
using BarApp.Services.Interfaces;
using BarApp.ViewModels;
using System.Collections.ObjectModel;

namespace BarApp.Views;

public partial class FavoritesPage : ContentPage
{
    private readonly IFavoritesService _favoritesService;
    private FavoritesPageViewModel _viewModel; // ViewModel'ý burada tanýmlýyoruz

    public FavoritesPage()
    {
        InitializeComponent();
        _favoritesService = MauiProgram.ServiceProvider.GetService<IFavoritesService>();

        // ViewModel'ý sadece ilk seferde oluþtur:
        _viewModel = new FavoritesPageViewModel();
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // ViewModel'ýn Favorites koleksiyonunu güncelle:
        _viewModel.Favorites = new ObservableCollection<Product>(_favoritesService.GetAllFavorites());
        FavoritesCollection.ItemsSource = _viewModel.Favorites;

    }

    private void OnRemoveFavoriteSwiped(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipeItem && swipeItem.CommandParameter is Product product)
        {
            _favoritesService.RemoveFromFavorites(product);
            // ViewModel'ýn Favorites koleksiyonundan sil:
            _viewModel.Favorites.Remove(product);
        }
    }
}