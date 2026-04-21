namespace BlApi;

public interface IBl
{
    public ICustomer customer { get; }
    public ISale sale { get;  }
    public IProduct product { get; }
    public IOrder order { get; }
}