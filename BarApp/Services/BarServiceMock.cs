using BarApp.Models;
using BarApp.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BarApp.Services
{
    public class BarServiceMock : IBarService
    {
        private readonly List<Product> _barItems = new();

        public void AddToBar(Product product)
        {
            if (!_barItems.Any(p => p.Name == product.Name))
                _barItems.Add(product);
        }

        public void RemoveFromBar(Product product)
        {
            _barItems.RemoveAll(p => p.Name == product.Name);
        }

        public IReadOnlyList<Product> GetAllBarItems()
        {
            return _barItems;
        }
    }
}
