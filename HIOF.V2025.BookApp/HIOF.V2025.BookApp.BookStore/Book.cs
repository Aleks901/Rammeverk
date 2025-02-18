namespace HIOF.V2025.BookApp.BookStore;


public sealed class Book
{
    /// <summary>
    /// Bok tittel. Immutable, kommer aldri til å endres.
    /// <returns>Book</returns>
    /// </summary>
    public string BookTitle { get; }

    /// <summary>
    /// Navnet til forfattereren, Immutable, kommer aldri til å endres.
    /// <returns>AuthorName: string</returns>
    /// </summary>
    public string AuthorName { get; }

    /// <summary>
    /// Bok sjanger. Immutable, kommer aldri til å endres. Enum class Genre.
    /// <returns>BookGenre: Enum Genre </returns>
    /// </summary>
    public Genre BookGenre { get; }

    /// <summary>
    /// Personlig identifikator for en spesifikk bok, immutable, kommer aldri til å endres.
    /// <returns>ISBN: string</returns>
    /// </summary>
    public string ISBN { get; }

    /// <summary>
    /// Prisen på boken, Mutable, kan endres ved behov. (F.eks discounts eller sales.)
    /// <returns>Price: decimal</returns>
    /// </summary>
    public decimal Price { get; private set; }
    
    /// <summary>
    /// Konstruktøren til Book klassen. Inkluderer alle egenskaper fra klassen for å lage en komplett bok.
    /// </summary>
    /// <param name="title">Tittelen til boken</param>
    /// <param name="authorName">Navnet til forfatteren</param>
    /// <param name="isbn">Personlig identifikator til en bok</param>
    /// <param name="price">Prisen til boken</param>
    /// <param name="genre">Sjangeren til boken</param>
    public Book(string title, string authorName, string isbn, decimal price, Genre genre)
    {
        BookTitle = title;
        AuthorName = authorName;
        ISBN = isbn;
        Price = price;
        BookGenre = genre;
    }
}
