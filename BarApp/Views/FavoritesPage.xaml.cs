using BarApp.Models;
using BarApp.Services.Interfaces;
using BarApp.ViewModels;
using System.Collections.ObjectModel;

namespace BarApp.Views;

public partial class FavoritesPage : ContentPage
{
    private readonly IFavoritesService _favoritesService;
    private FavoritesPageViewModel _viewModel;

    public FavoritesPage()
    {
        InitializeComponent();
        _favoritesService = MauiProgram.ServiceProvider.GetService<IFavoritesService>();

        // ViewModel'ý oluþtur ve favorileri yükle:
        _viewModel = new FavoritesPageViewModel
        {
            Favorites = new ObservableCollection<Product>(_favoritesService.GetAllFavorites())
        };
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Koleksiyonu güncelle ve arayüze bildir:
        _viewModel.Favorites.Clear();
        foreach (var product in _favoritesService.GetAllFavorites())
        {
            _viewModel.Favorites.Add(product);
        }
    }

    private void OnRemoveFavoriteSwiped(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipeItem && swipeItem.CommandParameter is Product product)
        {
            _favoritesService.RemoveFromFavorites(product);
            _viewModel.Favorites.Remove(product);
        }
    }
}