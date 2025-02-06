namespace HIOF.V2025.BookApp.BookStore;


/// <summary>
/// En representasjon av en bok med enkle properties.
/// Title: Immutable, kommer aldri til å endres.
/// AuthorName: Immutable, kommer aldri til å endres.
/// BookGenre: Immutable, kommer aldri til å endres. Enum class Genre.
/// Price: Mutable, kan endres ved behov. (F.eks discounts eller sales.)
/// </summary>
public class Book
{   
    
    public string Title { get; }
  
    public string AuthorName { get; }
 
    public Genre BookGenre { get; }

    public string ISBN {  get; }

    public decimal Price { get; private set; }
    
    public Book(string title, string authorName, string isbn, decimal price, Genre genre)
    {
        Title = title;
        AuthorName = authorName;
        ISBN = isbn;
        Price = price;
        BookGenre = genre;
    }

    public void PrintInfo() 
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Author: {AuthorName}");
        Console.WriteLine($"Genre: {BookGenre}");
        Console.WriteLine($"Price: {Price}");
    }
}
