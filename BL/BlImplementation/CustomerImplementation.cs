using BlApi;
using BO;

namespace BlImplementation;

internal class CustomerImplementation : ICustomer
{
    public int Create(Customer customer)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public bool IsExist(Customer customer)
    {
        throw new NotImplementedException();
    }

    public Customer? Read(int id)
    {
        throw new NotImplementedException();
    }

    public Customer? Read(Func<Customer, bool> filter)
    {
        throw new NotImplementedException();
    }

    public List<Customer?> ReadAll(Func<Customer, bool>? filter)
    {
        throw new NotImplementedException();
    }

    public void Update(Customer customer)
    {
        throw new NotImplementedException();
    }
}
