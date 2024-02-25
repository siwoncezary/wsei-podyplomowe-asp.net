using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Z2.Controllers;
using Z2.Models;

namespace Z4Test;

public class BookControllerTest
{
    [Fact]
    public void ActionIndexBookControllerTest()
    {
        // Arrange
        IBookService service = new ListBookService();
        BookController controller = new BookController(service);
        // Act
        ViewResult? result = controller.Index() as ViewResult;
        var model = result?.Model as List<Book>;
        // Assert
        Assert.Equal(service.FindAll().Count(), model?.Count);
    }

    [Theory]
    [InlineData(1, "C#")]
    [InlineData(2, "ASP.NET")]
    public void ActionDetailsBookControllerTest(int id, string title)
    {
        // Arrange
        IBookService service = new ListBookService();
        BookController controller = new BookController(service);
        // Act
        var view = controller.Details(id) as ViewResult;
        var model = view?.Model as Book;
        // Assert
        Assert.NotNull(model);
        Assert.Equal(title, model.Title);
    }
}