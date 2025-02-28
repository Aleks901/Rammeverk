namespace HIOF.V2025.BookApp.BookStore;

/// <summary>
/// Et bok produkt.
/// </summary>
public sealed class Book : IDiscountable
{
    /// <summary>
    /// Bok tittel. Immutable, kommer aldri til å endres.
    /// <value>Book</value>
    /// </summary>
    public string BookTitle { get; }

    /// <summary>
    /// Navnet til forfattereren, Immutable, kommer aldri til å endres.
    /// <value>AuthorName: string</value>
    /// </summary>
    public string AuthorName { get; }

    /// <summary>
    /// Personlig identifikator for en spesifikk bok, immutable, kommer aldri til å endres.
    /// <value>Isbn: string</value>
    /// </summary>
    public string Isbn { get; }

    /// <summary>
    /// Prisen på boken, Mutable, kan endres ved behov. (F.eks discounts eller sales.)
    /// <value>Price: decimal</value>
    /// </summary>
    public decimal Price { get; private set; }

    /// <summary>
    /// Bok sjanger. Immutable, kommer aldri til å endres.
    /// <value>BookGenre: Enum Genre</value>
    /// </summary>
    public Genre BookGenre { get; }

    /// <summary>
    /// Bok type. (Digital / Hardcover) Immutable.
    /// <value>BookType: Enum</value>
    /// </summary>
    public BookType BookType { get; }

    /// <summary>
    /// Konstruktøren til Book klassen. Inkluderer alle egenskaper fra klassen for å lage en komplett bok.
    /// </summary>
    /// <param name="title">Tittelen til boken</param>
    /// <param name="authorName">Navnet til forfatteren</param>
    /// <param name="isbn">Personlig identifikator til en bok</param>
    /// <param name="price">Prisen til boken</param>
    /// <param name="genre">Sjangeren til boken</param>
    public Book(string title, string authorName, string isbn, decimal price, Genre genre, BookType bookType)
    {
        BookTitle = title;
        AuthorName = authorName;
        Isbn = isbn;
        Price = price;
        BookGenre = genre;
        BookType = bookType;
    }

    /// <summary>
    /// Bruker en discount på boka og oppdaterer prisen.
    /// </summary>
    /// <param name="discount">Rabatten som skal trekkes fra prisen.</param>
    public void ApplyDiscount(Discount discount)
    {
        Price = discount.ApplyDiscount(Price);
    }
}
