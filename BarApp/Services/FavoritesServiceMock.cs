using BarApp.Models;
using BarApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BarApp.Services
{
    public class FavoritesServiceMock : IFavoritesService
    {
        private readonly List<Product> _favorites = new();

        public void AddToFavorites(Product product)
        {
            // Aynı ürün varsa tekrar ekleme
            if (!_favorites.Any(p => p.Name == product.Name))
                _favorites.Add(product);
        }

        public void RemoveFromFavorites(Product product)
        {
            _favorites.RemoveAll(p => p.Name == product.Name);
        }

        public IReadOnlyList<Product> GetAllFavorites()
        {
            return _favorites;
        }
    }
}
