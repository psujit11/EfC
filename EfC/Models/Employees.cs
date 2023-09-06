using System.ComponentModel.DataAnnotations;

namespace EfC.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Salary { get; set; }


    }
}
