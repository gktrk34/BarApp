using BarApp.Models;
using System.Collections.ObjectModel;

namespace BarApp.ViewModels;

public class FavoritesPageViewModel
{
    public ObservableCollection<Product> Favorites { get; set; }

    public FavoritesPageViewModel()
    {
        Favorites = new ObservableCollection<Product>();
    }
}