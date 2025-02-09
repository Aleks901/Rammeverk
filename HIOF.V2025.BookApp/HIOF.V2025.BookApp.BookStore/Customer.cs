namespace HIOF.V2025.BookApp.BookStore;

public sealed class Customer
{
    /// <summary>
    /// Kunde Id nødvendig for database. Immutable.
    /// </summary>
    public int CustomerId { get; }

    /// <summary>
    /// Kunde navn nødvendig for shipping. Immutable.
    /// </summary>
    public string CustomerName { get; }

    /// <summary>
    /// Kunde Email nødvendig for tilsending av informasjon. Immutable.
    /// </summary>
    public string CustomerEmail { get; }

    /// <summary>
    /// Kunde telefon nummer nødvendig for tilsending av informasjon. Immutable.
    /// </summary>
    public string CustomerPhone { get; }

    /// <summary>
    /// Kunde adresse nødvendig for shipping. Immutable.
    /// </summary>
    public string CustomerAddress { get; }

    /// <summary>
    /// Kunde postnummer nødvendig for shipping. Immutable.
    /// </summary>
    public string CustomerPostalCode { get; }

    /// <summary>
    /// Konstruktør for customer.
    /// </summary>
    /// <param name="customerId"></param>
    /// <param name="customerName"></param>
    /// <param name="customerEmail"></param>
    /// <param name="customerPhone"></param>
    /// <param name="customerAddress"></param>
    /// <param name="customerPostalCode"></param>
    public Customer(int customerId, string customerName, string customerEmail, string customerPhone, string customerAddress, string customerPostalCode) 
    {
        CustomerId = customerId;
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        CustomerPhone = customerPhone;
        CustomerAddress = customerAddress;
        CustomerPostalCode = customerPostalCode;
    }



}