using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Product name is required.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(1, double.MaxValue, ErrorMessage = "Price must be a positive number.")]
        public decimal Price { get; set; }
        public string? Description {  get; set; }
        public string? ImageUrl {  get; set; }
        [Range(0,1000,ErrorMessage = "Discount must be between 0 and 1000")]
        public int Discount {  get; set; }
        [Required(ErrorMessage ="Product must be specified")]
        public string? IsNew { get; set ; }
        //public int SubCategoryId { get; set; }
        //public int Category { get; set; }

    }
}
