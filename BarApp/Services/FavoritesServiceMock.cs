using BarApp.Models;
using BarApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BarApp.Services { 
public class FavoritesServiceMock : IFavoritesService
{
    private readonly List<Product> _favorites = new List<Product>();

    public void AddToFavorites(Product product)
    {
        // Ürün zaten favorilerde yoksa ekle:
        if (!_favorites.Any(p => p.Name == product.Name && p.ImageUrl == product.ImageUrl))
        {
            _favorites.Add(product);
        }
    }

    public void RemoveFromFavorites(Product product)
    {
        // Ürünü listeden silerken referans kontrolü yerine Name ve ImageUrl özelliklerini kullan
        var itemToRemove = _favorites.FirstOrDefault(p => p.Name == product.Name && p.ImageUrl == product.ImageUrl);
        if (itemToRemove != null)
        {
            _favorites.Remove(itemToRemove);
        }
    }

    public List<Product> GetAllFavorites()
    {
        return _favorites;
    }
}
}