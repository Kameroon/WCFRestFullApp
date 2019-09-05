namespace MMAWcfService.Models
{
    public interface ICustomer
    {
        string Address { get; set; }
        int CustomerID { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}