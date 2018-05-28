using System.ComponentModel.DataAnnotations;
namespace MVC.AX.Models {

    public class Person {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Phonenumber { get; set; }
        [Required]
        public string City { get; set; }
    }
}