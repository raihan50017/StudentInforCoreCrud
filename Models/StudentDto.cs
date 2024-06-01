using System.ComponentModel.DataAnnotations;

namespace app.web.Models
{
    public class StudentDto
    {
        [Required]
        public String Name { get; set; } = "";
        [Required]
        public String Email { get; set; } = "";
        [Required]
        public String Phone { get; set; } = "";
    }
}
