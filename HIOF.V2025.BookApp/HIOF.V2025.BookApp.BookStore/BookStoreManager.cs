namespace HIOF.V2025.BookApp.BookStore;


public sealed class BookStoreManager
{
    /// <summary>
    /// Liste over tilgjengelige bøker i bok butikken.
    /// </summary>
    public List<Book> inventory { get; } = new List<Book>();

    /// <summary>
    /// Liste over kunder som har fullført kjøp i bok butikken.
    /// </summary>
    public List<Customer> customers { get; } = new List<Customer>();

    /// <summary>
    /// Legger til en bok i inventory om detaljene er fullstendig.
    /// </summary>
    /// <param name="book">Boka som skal legges til</param>
    /// <exception cref="ArgumentNullException">Kastes hvis boka eller detaljene er null</exception>
    public void AddBook(Book book)
    {
        if (book == null) throw new ArgumentNullException(nameof(book));
        if (string.IsNullOrWhiteSpace(book.ISBN) || string.IsNullOrWhiteSpace(book.BookTitle) || string.IsNullOrWhiteSpace(book.AuthorName))
        {
            throw new ArgumentNullException(nameof(book), "Book details must be complete");
        }

        inventory.Add(book);
    }

    /// <summary>
    /// Finner en bok i inventory basert på tittel eller ISBN.
    /// Dersom boka eksisterer returneres den for videre bruk.
    /// </summary>
    /// <param name="titleOrIsbn">Boktittel eller ISBN</param>
    /// <returns>Boka hvis den finnes</returns>
    /// <exception cref="ArgumentNullException">Kastes hvis parameteren er null eller tom</exception>
    /// <exception cref="InvalidOperationException">Kastes hvis boken ikke finnes</exception>
    public Book FindBook(string titleOrIsbn)
    {
        if (string.IsNullOrWhiteSpace(titleOrIsbn)) throw new ArgumentNullException(nameof(titleOrIsbn));

        foreach (var book in inventory)
        {
            if (book.ISBN == titleOrIsbn || book.BookTitle == titleOrIsbn)
            {
                return book;
            }
        }

        throw new InvalidOperationException("Book does not exist in inventory");
    }

    /// <summary>
    /// Fullfører et kjøp av en bok dersom ISBN matcher en bok i inventory.
    /// Lagrer kunde informasjon for videre bruk (f.eks. shipping).
    /// </summary>
    /// <param name="isbn">ISBN til boken som skal kjøpes</param>
    /// <param name="customer">Kunden som kjøper boken</param>
    /// <exception cref="ArgumentNullException">Kastes hvis ISBN eller kunde er null</exception>
    /// <exception cref="InvalidOperationException">Kastes hvis boken ikke finnes</exception>
    public void PurchaseBook(string isbn, Customer customer)
    {
        if (string.IsNullOrWhiteSpace(isbn)) throw new ArgumentNullException(nameof(isbn));
        if (customer == null) throw new ArgumentNullException(nameof(customer));

        var book = inventory.FirstOrDefault(b => b.ISBN == isbn)
            ?? throw new InvalidOperationException("Book does not exist in inventory");

        customers.Add(customer);
    }
}
