using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CookingBlogFront.Data
{
    public class LoginModel
    {
        [Required]
        [JsonPropertyName("Login")]
        public string Login { get; set; }
        [Required]
        [JsonPropertyName("Email")]
        public string Email { get; set; }
        [Required]
        [JsonPropertyName("Password")]
        public string Password { get; set; }
    }
}
