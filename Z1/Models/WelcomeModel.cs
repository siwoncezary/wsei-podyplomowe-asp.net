using System.ComponentModel.DataAnnotations;

namespace Z1.Models;

public class WelcomeModel
{
    [Required]
    [RegularExpression(pattern: "^[A-Z][a-z]+$")]
    [StringLength(maximumLength: 20)]
    public string? Name { get; set; }
    [Range(minimum: 18, maximum: 100)]
    public int? Age { get; set; }

    public string Format()
    {
        return $"Hello {Name}, age {Age}";
    }
}