using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyProject.Models
{
    [Table("asran")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Display(Name = "Name")]
       
        public string? Name { get; set; }

        [Display(Name = "Email")]
       
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Display(Name = "Password")]
       
        [DataType(DataType.Password)]
        public string? Password { get; set; }


        public bool isAdmin { get; set; }


        public bool isAdmin { get; set; }

    }
}
