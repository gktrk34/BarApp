using System.Collections.Generic;
using BarApp.Models;

namespace BarApp.MockData
{
    public static class MockBrands
    {
        public static List<Brand> GetBrands()
        {
            return new List<Brand>
            {
                new Brand
                {
                    Name = "Gordon's",
                    CategoryName = "Gin",
                    ImageUrl = "dotnet_bot.png",
                    Description = "1769'da kurulmuş ünlü bir Gin markası..."
                },
                new Brand
                {
                    Name = "Beefeater",
                    CategoryName = "Gin",
                    ImageUrl = "dotnet_bot.png",
                    Description = "Londra'nın klasik dry gin markası..."
                },
                new Brand
                {
                    Name = "Absolut",
                    CategoryName = "Vodka",
                    ImageUrl = "dotnet_bot.png",
                    Description = "İsveç'in ünlü buğday vodkası..."
                },
                new Brand
                {
                    Name = "Grey Goose",
                    CategoryName = "Vodka",
                    ImageUrl = "dotnet_bot.png",
                    Description = "Fransız premium votka..."
                },
                new Brand
                {
                    Name = "Jack Daniel's",
                    CategoryName = "Whisky",
                    ImageUrl = "dotnet_bot.png",
                    Description = "Tennessee viskisi..."
                },
                new Brand
                {
                    Name = "Johnnie Walker",
                    CategoryName = "Whisky",
                    ImageUrl = "dotnet_bot.png",
                    Description = "İskoç harman viskisi..."
                },
            };
        }
    }
}
