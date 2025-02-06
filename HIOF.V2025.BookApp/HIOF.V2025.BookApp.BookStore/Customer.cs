namespace HIOF.V2025.BookApp.BookStore;

public class Customer
{
    public string CustomerId { get; set; }

    public string CustomerName { get; set; }

    public string CustomerEmail { get; set; }

    public string CustomerPhone { get; set; }

    public string CustomerAddress { get; set; }

    public string CustomerPostalCode { get; set; }

    public Customer(string customerId, string customerName, string customerEmail, string customerPhone, string customerAddress, string customerPostalCode) 
    {
        CustomerId = customerId;
        CustomerName = customerName;
        CustomerEmail = customerEmail;
        CustomerPhone = customerPhone;
        CustomerAddress = customerAddress;
        CustomerPostalCode = customerPostalCode;
    }



}