using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CookingBlogFront.Data
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
