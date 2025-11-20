using System.ComponentModel.DataAnnotations;

namespace RazorPagesMovie.Pages
{
    public class Identity

    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$",
         ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
       
    }
}
