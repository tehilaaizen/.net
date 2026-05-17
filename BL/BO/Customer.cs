namespace BO;

public class Customer
{
    public Customer(int id, string name, string address,string phoneNumber)
    {
        Id = id;
        Name = name;
        Address = address;
        PhoneNumber = phoneNumber;
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string PhoneNumber { get; set; }
    public override string ToString() => this.ToStringProperty();
}
