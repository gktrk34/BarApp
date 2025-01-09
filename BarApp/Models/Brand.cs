namespace BarApp.Models
{
    public class Brand
    {
        public string Name { get; set; }
        public string CategoryName { get; set; } // Gin, Vodka, Whisky vb.
        public string ImageUrl { get; set; }      // Marka logosu
        public string Description { get; set; }   // Kısa tanıtım/tarihçe vb.
    }
}
