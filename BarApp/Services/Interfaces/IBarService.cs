using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarApp.Services.Interfaces
{
    public interface IBarService
    {
        void AddToBar(Product product);
        void RemoveFromBar(Product product);
        IReadOnlyList<Product> GetAllBarItems();
    }
}