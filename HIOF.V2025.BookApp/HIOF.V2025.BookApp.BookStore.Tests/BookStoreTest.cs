using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace HIOF.V2025.BookApp.BookStore.Tests;

[TestClass]
public class BookStoreTest
{
    [TestMethod]
    /// <summary>
    /// Metoden simulerer om en nylig lagt til bok eksisterer i listen etter å ha brukt AddBook metoden.
    /// Ettersom boken alltid vil ligge på første index i test butikk listen så vil testen alltid fungere-
    /// Så lenge metoden fungerer som den skal.
    /// </summary>
    public void AddBook_ValidBook_IncreasesInventory()
    {
        // Arrange
        var testBook = new Book("Not important", "Especially not important", "934-32-Not-important", 49, Genre.Biography, BookType.Digital);
        var testBookStore = new BookStoreManager();
        // Act
        testBookStore.AddBook(testBook);
        // Assert
        Assert.AreEqual(testBook, testBookStore.Inventory[0], "Book exists in list after being added");
    }

    /// <summary>
    /// Metoden simulerer ett tilfelle hvor AddBook metoden feiler.
    /// Metoden skal kaste en exception dersom ett eller flere av de påkrevde parameterene ikke eksisterer.
    /// </summary>
    [TestMethod]
    public void AddBook_BookParameteresNull_ThrowsException() 
    {
        // Arrange
        var testBook = new Book(null, null, null, 0, Genre.Mystery, BookType.Digital);
        var testBookStore = new BookStoreManager();

        // Act & Assert
        Assert.ThrowsException<ArgumentNullException>(() => 
        {
            testBookStore.AddBook(testBook);
        });
        
    }
    /// <summary>
    /// Metoden simulerer et tilfelle hvor en bok har blitt lagt til i inventory og skal da kunne returneres i søk ved
    /// bruk av FindBook metoden.
    /// I dette tilfellet sjekker vi både at Title og ISBN returnerer book objektet slik de skal.
    /// </summary>
    [TestMethod]
    public void FindBookByIsbnOrTitle_ExistingTitleorISBN_ReturnsBook() 
    {
        // Arrange
        var book3 = new Book("ABC", "Not important", "934-32-12-748", 50, Genre.Mystery, BookType.Digital);
        var testBookStore = new BookStoreManager();

        // Act
        testBookStore.AddBook(book3);

        // Assert
        Assert.IsTrue("ABC" == testBookStore.FindBook("ABC").BookTitle && "934-32-12-748" == testBookStore.FindBook("934-32-12-748").Isbn);
    }

    /// <summary>
    /// Metoden simulerer et tilfelle hvor boka man forsøker å finne ikke eksisterer.
    /// Skal alltid kaste exception.
    /// </summary>
    [TestMethod]
    public void FindBookByIsbnOrTitle_NonExistingTitle_ThrowsException() 
    {
        // Arrange
        var testBookStore = new BookStoreManager();

        // Act & Assert
        Assert.ThrowsException<InvalidOperationException>(() => 
        {
            testBookStore.FindBook("Book that doesn't exist");
        });
    }

    /// <summary>
    /// Metoden simulerer et tilfelle hvor en bok som er ønsket kjøpt matcher boka som eksisterer i
    /// inventory. Deretter etter fullført checkout prosess blir kunde informasjon lagret for bruk i
    /// shipping osv.
    /// </summary>
    [TestMethod]
    public void PurchaseBook_BookPurchased_CustomerDataStored() 
    {

        // Arrange
        var testCustomer = new Customer(1, "Aleks", "aleksj@hiof.no", "+4712345678", "B R A Veien 6c", "1793 Halden", Membership.None);
        var testBookStore = new BookStoreManager();
        var testBook = new Book("LOTR", "Tolkien", "1234-5678", 100, Genre.Fantasy, BookType.Digital);
       

        // Act
        testBookStore.AddBook(testBook);
        testBookStore.PurchaseBook("1234-5678", testCustomer);

        // Assert
        Assert.AreEqual(testCustomer, testBookStore.Customers[0]);
    }

    /// <summary>
    /// Tester at PurchaseBook-metoden kaster en exception dersom man prøver å kjøpe en bok som ikke eksisterer i inventory.
    /// </summary>
    [TestMethod]
    public void PurchaseBook_NonExistingBook_ThrowsException()
    {
        // Arrange
        var testCustomer = new Customer(2, "Ola Nordmann", "ola@hiof.no", "+4798765432", "Testveien 1", "1793 Halden", Membership.None);
        var testBookStore = new BookStoreManager();

        // Act & Assert
        Assert.ThrowsException<InvalidOperationException>(() =>
        {
            testBookStore.PurchaseBook("9999-8888", testCustomer);
        });
    }

    /// <summary>
    /// Tester om rabbatert pris returneres etter bruk av ApplyDiscount metode.
    /// </summary>
    [TestMethod]
    public void ApplyDiscount_DiscountApplied_ReturnsNewPriceOfProduct() 
    {
        // Arrange
        var testKupong = new Discount(100);
        var testBook = new Book("SomeBook", "SomeAuthor", "SomeIsbn", 100, Genre.Biography, BookType.Digital);

        // Act
        testBook.ApplyDiscount(testKupong);

        // Assert
        Assert.IsTrue(testBook.Price == 0);

        
    }

    /// <summary>
    /// Denne metoden tester 2 ting, først at dersom kupongen ble produsert med en verdi <= 0 så skulle den kaste en exception. 
    /// Deretter sjekker den at den negative prisen også IKKE ble lagt til produktet. Dette er bare et ekstra steg for sikkerhetsskyld.
    /// </summary>
    [TestMethod]
    public void ApplyDiscount_DiscountNotApplied_ThrowsOutOfRangeException() 
    {
        // Arrange
        var testBook = new Book("SomeBook", "SomeAuthor", "SomeIsbn", 100, Genre.Biography, BookType.Digital);

        // Act & Assert
        Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
        {
            var testKupong = new Discount(-100);
            testBook.ApplyDiscount(testKupong);
        });

        // Assert #2
        Assert.IsTrue(testBook.Price == 100);
    }

    /// <summary>
    /// Tester om medlemskap rabatt blir puttet på kjøpt produkt.
    /// </summary>
    [TestMethod]
    public void GetDiscountForMembership_ValidMembershipDiscount_MembershipDiscountApplied() 
    {
        // Arrange
        var testCustomer = new Customer(2, "Ola Nordmann", "ola@hiof.no", "+4798765432", "Testveien 1", "1793 Halden", Membership.Diamond);
        var testBook = new Book("SomeBook", "SomeAuthor", "SomeIsbn", 100, Genre.Biography, BookType.Digital);
        var testBookStore = new BookStoreManager();
        testBookStore.AddBook(testBook);

        // Act & Assert
        Assert.IsTrue((testBookStore.PurchaseBook("SomeIsbn", testCustomer)).Price == 70);
    }

    /// <summary>
    /// Tester et tilfelle hvor kunden ikke er medlem, og dermed at rabatt ikke blir puttet på det returnerte produktet.
    /// </summary>
    [TestMethod]
    public void GetDiscountForMembership_InvalidMembershipDiscount_MembershipDiscountNotApplied() 
    {
        // Arrange
        var testCustomer = new Customer(2, "Ola Nordmann", "ola@hiof.no", "+4798765432", "Testveien 1", "1793 Halden", Membership.None);
        var testBook = new Book("SomeBook", "SomeAuthor", "SomeIsbn", 100, Genre.Biography, BookType.Digital);
        var testBookStore = new BookStoreManager();
        testBookStore.AddBook(testBook);

        // Act & Assert
        Assert.IsTrue((testBookStore.PurchaseBook("SomeIsbn", testCustomer)).Price == 100);

    }

}
