using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Z2.Models;

public class Book
{
    [HiddenInput]
    public int Id { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(50)]
    public string Title { get; set; }
    [Required]
    [MinLength(5)]
    [MaxLength(50)]
    public string Author { get; set; }
    [Range(1,2000)]
    public int Pages { get; set; }
    [StringLength(13)]
    public string ISBN { get; set; }
    [DataType(DataType.Date)]
    public DateOnly Published { get; set; }
}