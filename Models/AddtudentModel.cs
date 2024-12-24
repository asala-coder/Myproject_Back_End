using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    public class AddtudentModel
    {
        public string? Name { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public Department department { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public Semseter semester { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public int Fees { get; set; }
    }
}
