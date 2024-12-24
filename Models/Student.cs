using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyProject.Models
{
    public enum Department
    { 
        IT,
        CS,
        JS,
    }
    public enum Semseter
    {
        first,
        second,
    }
    [Table("asranTable")]

    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
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
