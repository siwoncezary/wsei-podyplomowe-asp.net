using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace Z2.Models;
// Dodaj klasę encji Author opisującej autora :
// FirstName
// LastName
// Email

// Dodaj w klasu AppDbContext zbiór authorów o nazwie Authors
public class Author
{
    public int Id { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }
    
    public string Email { get; set; }
}


[Table("books")]
public class Book
{
    [HiddenInput]
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    [Display(Name = "Tytuł książki")]
    public string Title { get; set; }
    public int? AuthorId { get; set; }   // związek opcjonalny
    public Author? Author { get; set; }  // właściwość nawigacyjna tworzy związek jeden-do-wielu
    [Display(Name = "Liczba stron")]
    [Range(1,2000)]
    public int Pages { get; set; }
    [StringLength(13)]
    public string ISBN { get; set; }
    [DataType(DataType.Date)]
    [Display(Name = "Data wydania")]
    [Column("data_wydania")]
    public DateOnly Published { get; set; }
}