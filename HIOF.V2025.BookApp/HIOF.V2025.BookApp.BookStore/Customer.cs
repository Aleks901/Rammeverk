namespace HIOF.V2025.BookApp.BookStore;

public sealed class Customer
{
    /// <summary>
    /// Kunde Id nødvendig for database. Immutable.
    /// <returns>Id: Int</returns>
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Kunde navn nødvendig for shipping. Immutable.
    /// <returns>Name: string</returns>
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Kunde Email nødvendig for tilsending av informasjon. Immutable.
    /// <returns>PersonalEmail: string</returns>
    /// </summary>
    public string PersonalEmail { get; }

    /// <summary>
    /// Kunde telefon nummer nødvendig for tilsending av informasjon. Immutable.
    /// <returns>PersonalPhone: string</returns>
    /// </summary>
    public string PersonalPhone { get; }

    /// <summary>
    /// Kunde adresse nødvendig for shipping. Immutable.
    /// <returns>HomeAddress: string</returns>
    /// </summary>
    public string HomeAddress { get; }

    /// <summary>
    /// Kunde postnummer nødvendig for shipping. Immutable.
    /// <returns>PostalCode: string</returns>
    /// </summary>
    public string PostalCode { get; }

    /// <summary>
    /// Konstruktør for customer. Alle egenskaper inkluderes for å få komplett kunde data.
    /// </summary>
    /// <param name="customerId">Id'en til en kunde</param>
    /// <param name="customerName">Navnet til en kunde</param>
    /// <param name="customerEmail">En kundes email adresse</param>
    /// <param name="customerPhone">En kundes telefon nummer</param>
    /// <param name="customerAddress">En kundes adresse</param>
    /// <param name="customerPostalCode">En kundes post kode</param>
    public Customer(int customerId, string customerName, string customerEmail, string customerPhone, string customerAddress, string customerPostalCode) 
    {
        Id = customerId;
        Name = customerName;
        PersonalEmail = customerEmail;
        PersonalPhone = customerPhone;
        HomeAddress = customerAddress;
        PostalCode = customerPostalCode;
    }



}