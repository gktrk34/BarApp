using BarApp.Models;
using System.Collections.ObjectModel;

namespace BarApp.ViewModels;

public class FavoritesPageViewModel : BaseViewModel
{
    private ObservableCollection<Product> _favorites;
    public ObservableCollection<Product> Favorites
    {
        get => _favorites;
        set => SetProperty(ref _favorites, value);
    }

    public FavoritesPageViewModel()
    {
        _favorites = new ObservableCollection<Product>();
    }
}