using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HIOF.V2025.BookApp.BookStore.Tests;

[TestClass]
public class BookStoreTest
{
    [TestMethod]
    public void Method_ValidFindBook_BookTitleExistsInInventory()
    {
        // Arrange
        var book = new Book("Not important", "Especially not important", "934-32-Not-important", 49, Genre.Biography);
        var randomBookStore = new BookStoreManager();
        // Act
        randomBookStore.AddBook(book);
        // Assert
        Assert.AreEqual(book, randomBookStore.FindBook(book.Title), "Book exists after being added i guess");

    }
}
