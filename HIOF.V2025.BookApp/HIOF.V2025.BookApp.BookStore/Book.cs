namespace HIOF.V2025.BookApp.BookStore;


/// <summary>
/// En representasjon av en bok med enkle properties.
/// Title: Immutable, kommer aldri til å endres.
/// AuthorName: Immutable, kommer aldri til å endres.
/// BookGenre: Immutable, kommer aldri til å endres. Enum class Genre.
/// Price: Mutable, kan endres ved behov. (F.eks discounts eller sales.)
/// </summary>
public sealed class Book
{   

    public string BookTitle { get; }
  
    public string AuthorName { get; }
 
    public Genre BookGenre { get; }

    public string ISBN { get; }

    public decimal Price { get; private set; }
    
    /// <summary>
    /// Konstruktøren til Book klassen.
    /// </summary>
    /// <param name="title"></param>
    /// <param name="authorName"></param>
    /// <param name="isbn"></param>
    /// <param name="price"></param>
    /// <param name="genre"></param>
    public Book(string title, string authorName, string isbn, decimal price, Genre genre)
    {
        BookTitle = title;
        AuthorName = authorName;
        ISBN = isbn;
        Price = price;
        BookGenre = genre;
    }
}
