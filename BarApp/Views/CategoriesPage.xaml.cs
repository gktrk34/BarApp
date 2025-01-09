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

            // Kategorileri mock veriden al�p CollectionView'e ba�layal�m
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
                    // Se�ilen kategori ismini BrandListPage'e parametre olarak g�nder
                    string route = $"BrandListPage?category={selectedCategory.Name}";
                    await Shell.Current.GoToAsync(route);
                }

                // Se�imi s�f�rlayal�m (ayn� kategoriyi bir daha se�ebilmek i�in)
                ((CollectionView)sender).SelectedItem = null;
            }
        }
    }
}
