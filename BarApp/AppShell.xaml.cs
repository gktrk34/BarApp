using System;
using Microsoft.Maui.Controls;
using BarApp.Views;


namespace BarApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

           Routing.RegisterRoute("BrandListPage", typeof(Views.BrandListPage));
           Routing.RegisterRoute("BrandDetailPage", typeof(BrandDetailPage));
           Routing.RegisterRoute("ProductDetailPage", typeof(ProductDetailPage));



            // İleride markalar, ürün detayları vb. için ekstra Route tanımlayabiliriz
            // Örnek: Routing.RegisterRoute("BrandListPage", typeof(BrandListPage));
            // Routing.RegisterRoute("ProductDetailPage", typeof(ProductDetailPage));
        }
    }
}
