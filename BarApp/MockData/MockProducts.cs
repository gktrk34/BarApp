public static class MockProducts
{
    public static List<Product> GetProducts()
    {
        return new List<Product>
        {
            new Product { Name = "Gordon's London Dry", BrandName="Gordon's",
                          ImageUrl="dotnet_bot.png",
                          Description="Klasik London Dry Gin..." },
            new Product { Name = "Gordon's Premium Pink", BrandName="Gordon's",
                          ImageUrl="dotnet_bot.png",
                          Description="Meyvemsi aromalı pembe gin..." },
            new Product { Name = "Beefeater London Dry", BrandName="Beefeater",
                          ImageUrl="dotnet_bot.png",
                          Description="Londra'da üretilen klasik Dry Gin..." },
            // Vodka, Whisky vb. markalar için de ekle
        };
    }
}
