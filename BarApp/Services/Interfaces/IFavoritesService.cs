using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarApp.Services.Interfaces
{
    public interface IFavoritesService
    {
        // Uygulamada favorilere ekleyip çıkaracağın tip. 
        // Örnek: Product
        void AddToFavorites(Product product);
        void RemoveFromFavorites(Product product);
        IReadOnlyList<Product> GetAllFavorites();
    }
}
