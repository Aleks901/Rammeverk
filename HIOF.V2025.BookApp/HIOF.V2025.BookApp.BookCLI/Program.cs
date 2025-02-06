using HIOF.V2025.BookApp.BookStore;

namespace HIOF.V2025.BookApp.BookCLI;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Book book1 = new Book("Lord of the Rings", "J.R.R Tolkien", "934-423-233-123-Idk", 49, Genre.Fantasy);
        book1.PrintInfo();
        Console.ReadLine();
    }
}
