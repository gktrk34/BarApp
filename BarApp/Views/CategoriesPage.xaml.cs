using BarApp.MockData;
using BarApp.Models;
using Microsoft.Maui.Controls;

namespace BarApp.Views
{
    public partial class CategoriesPage : ContentPage
    {
        public CategoriesPage()
        {
            InitializeComponent();

            // Kategorileri mock veriden alýp CollectionView'e baðlayalým
            var categories = MockCategories.GetCategories();
            CategoriesCollection.ItemsSource = categories;
        }

        private async void OnCategorySelected(object sender, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection != null && e.CurrentSelection.Count > 0)
            {
                var selectedCategory = e.CurrentSelection[0] as Category;
                if (selectedCategory != null)
                {
                    // Seçilen kategori ismini BrandListPage'e parametre olarak gönder
                    string route = $"BrandListPage?category={selectedCategory.Name}";
                    await Shell.Current.GoToAsync(route);
                }

                // Seçimi sýfýrlayalým (ayný kategoriyi bir daha seçebilmek için)
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
