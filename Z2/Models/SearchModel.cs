using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Z2.Models;

public class SearchModel
{
    public string? TitleQuery { get; set; }
    public string? AuthorQuery { get; set; }
    
    [ValidateNever]
    public List<Book> Result { get; set; }
}