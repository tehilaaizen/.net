namespace DO;

public record Customer(
    int id,
    string name,
    string address,
    string phone_number)
{
    public Customer() : this(0, "", "", "") { }
}
