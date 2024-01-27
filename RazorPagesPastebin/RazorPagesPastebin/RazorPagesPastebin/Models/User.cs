using System.ComponentModel.DataAnnotations;

namespace RazorPagesPastebin.Models
{
    public class User
    {
        public int Id { get; set; }
        [Display(Name = "Username:")]
        public string Name { get; set; }
        [Display(Name = "Email Address:")]
        public string Email { get; set; }
        [Display(Name = "Password:")]
        public string Password { get; set; }
    }
}
