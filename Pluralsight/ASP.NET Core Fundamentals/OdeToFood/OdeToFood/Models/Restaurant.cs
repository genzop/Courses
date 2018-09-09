using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        
        // Indica el texto a mostrar en la etiqueta
        [Display(Name = "Restaurant Name")]
        public string Name { get; set; }

        // Indica el texto a mostrar en la etiqueta
        [Display(Name = "Cuisine")]
        public CuisineType Cuisine { get; set; }
    }
}
