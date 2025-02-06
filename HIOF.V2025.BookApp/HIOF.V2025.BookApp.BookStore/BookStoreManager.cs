namespace HIOF.V2025.BookApp.BookStore;

public class BookStoreManager
{
    private List<Book> inventory = new List<Book>();

    public void AddBook(Book book)
    {
        if (book.ISBN == null)
        {
            throw new ArgumentNullException("ISBN", "ISBN cannot be null");
        }

        inventory.Add(book);
    }

    public Book FindBook(string titleOrIsbn)
    {
        if (titleOrIsbn == null)
        {
            throw new InvalidOperationException("You have to add at least one of the following: ISBN or Title");
        }

        foreach (Book book in inventory) 
        {
            if(book.ISBN == titleOrIsbn || book.Title == titleOrIsbn) { return book; }
        }

        throw new InvalidOperationException("Book does not exist in inventory");
    }

    //public bool PurchaseBook(string isbn, Customer customer)
    

}
