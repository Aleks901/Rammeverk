namespace HIOF.V2025.BookApp.BookStore;

public sealed class Customer
{
    /// <summary>
    /// Kunde Id nødvendig for database. Immutable.
    /// <value>Id: Int</value>
    /// </summary>
    public int Id { get; }

    /// <summary>
    /// Kunde navn nødvendig for shipping. Immutable.
    /// <value>Name: string</value>
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Kunde Email nødvendig for tilsending av informasjon. Immutable.
    /// <value>PersonalEmail: string</value>
    /// </summary>
    public string PersonalEmail { get; }

    /// <summary>
    /// Kunde telefon nummer nødvendig for tilsending av informasjon. Immutable.
    /// <value>PersonalPhone: string</value>
    /// </summary>
    public string PersonalPhone { get; }

    /// <summary>
    /// Kunde adresse nødvendig for shipping. Immutable.
    /// <value>HomeAddress: string</value>
    /// </summary>
    public string HomeAddress { get; }

    /// <summary>
    /// Kunde postnummer nødvendig for shipping. Immutable.
    /// <value>PostalCode: string</value>
    /// </summary>
    public string PostalCode { get; }

    /// <summary>
    /// Kundens medlemskap status.
    /// <value>Membership: Enum</value>
    /// </summary>
    public Membership CurrentMembership { get; set; }

    /// <summary>
    /// Konstruktør for customer. Alle egenskaper inkluderes for å få komplett kunde data.
    /// </summary>
    /// <param name="customerId">Id'en til en kunde</param>
    /// <param name="customerName">Navnet til en kunde</param>
    /// <param name="customerEmail">En kundes email adresse</param>
    /// <param name="customerPhone">En kundes telefon nummer</param>
    /// <param name="customerAddress">En kundes adresse</param>
    /// <param name="customerPostalCode">En kundes post kode</param>
    public Customer(int customerId, string customerName, string customerEmail, string customerPhone, string customerAddress, string customerPostalCode, Membership currentMembership) 
    {
        Id = customerId;
        Name = customerName;
        PersonalEmail = customerEmail;
        PersonalPhone = customerPhone;
        HomeAddress = customerAddress;
        PostalCode = customerPostalCode;
        CurrentMembership = currentMembership;
    }

    /// <summary>
    /// Setter basis rabatter for produktet som medlemmer kan få.
    /// </summary>
    /// <param name="currentMembership">Medlemskapet til kunden</param>
    /// <returns>Discount: Enum</returns>
    /// <exception cref="ArgumentOutOfRangeException">Kastes dersom et ikke gyldig medlemskap legges til.</exception>
    public Discount GetDiscountForMembership(Membership currentMembership)
    {
        return currentMembership switch
        {
            Membership.None => new Discount(0),
            Membership.Bronze => new Discount(10),
            Membership.Silver => new Discount(15),
            Membership.Gold => new Discount(20),
            Membership.Diamond => new Discount(30),
            _ => throw new ArgumentOutOfRangeException(nameof(currentMembership))
        };
    }



}