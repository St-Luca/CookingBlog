using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CookingBlog.Models.Requests;

public class CreateUserRequest : IValidatableObject
{
    public string Name { get; set; } = null!;
    public string? Picture { get; set; } 
    public string Email { get; set; } = null!;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Email) || !Regex.IsMatch(Email, @"^[^\s@]+@[a-zA-Z]+\.[a-zA-Z]+$") || Email.Length > 50)
        {
            yield return new ValidationResult("Invalid Email", new[] { nameof(Email) });
        }

        if (string.IsNullOrWhiteSpace(Name))
        {
            yield return new ValidationResult("Name is required", new[] { nameof(Name) });
        }
    }
}
