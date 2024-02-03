using System.ComponentModel.DataAnnotations;

namespace Z1.Models;

public class WelcomeModel
{
    [Required(ErrorMessage = "Musisz podać imię!")]
    [RegularExpression(pattern: "^[A-Z][a-z]+$", ErrorMessage = "W imieniu nie może być spacji ani znaków spejcalnych!")]
    [StringLength(maximumLength: 20, ErrorMessage = "Imię nie może być dłuższe niż 20 znaków!")]
    public string? Name { get; set; }
    [Range(minimum: 18, maximum: 100, ErrorMessage = "Wiek może być liczby między 18 a 100!")]
    public int? Age { get; set; }

    public string Format()
    {
        return $"Hello {Name}, age {Age}";
    }
}