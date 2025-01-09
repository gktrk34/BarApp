using System.Collections.Generic;
using BarApp.Models;

namespace BarApp.MockData
{
    public static class MockCategories
    {
        public static List<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category { Name = "Gin",    ImageUrl = "gin.png" },
                new Category { Name = "Vodka",  ImageUrl = "vodka.png" },
                new Category { Name = "Whisky", ImageUrl = "whisky.png" },
                // vb. ekleyebilirsin
            };
        }
    }
}
