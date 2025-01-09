using BarApp.Models;
using BarApp.MockData;
using Microsoft.Maui.Controls;
using System.Linq;

namespace BarApp.Views
{
    [QueryProperty(nameof(CategoryName), "category")]
    public partial class BrandListPage : ContentPage
    {
        private string _categoryName;
        public string CategoryName
        {
            get => _categoryName;
            set
            {
                _categoryName = value;
                OnPropertyChanged();
                LoadBrands();  // Kategori parametresi set edilince markalarý yükle
            }
        }

        public BrandListPage()
        {
            InitializeComponent();
        }

        private void LoadBrands()
        {
            // Tüm markalarý mock veriden çek
            var allBrands = MockBrands.GetBrands();

            // Kategori ismi geldiyse filtre uygula
            if (!string.IsNullOrWhiteSpace(_categoryName))
            {
                var filtered = allBrands
                    .Where(b => b.CategoryName == _categoryName)
                    .ToList();

                BrandsCollection.ItemsSource = filtered;
            }
            else
            {
                // Kategori parametresi yoksa tüm markalarý gösterebilirsin
                BrandsCollection.ItemsSource = allBrands;
            }
        }

        private async void OnBrandSelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                var selectedBrand = e.CurrentSelection[0] as Brand;
                if (selectedBrand != null)
                {
                    // Örnek: Marka detay sayfasýna git
                    string route = $"BrandDetailPage?brandName={selectedBrand.Name}";
                    await Shell.Current.GoToAsync(route);
                }

                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
