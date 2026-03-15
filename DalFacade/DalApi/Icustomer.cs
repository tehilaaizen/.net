namespace DalApi;
using DO;
public interface Icustomer : ICrud<Customer>
{
    int Create(Customer customer);
    Customer? Read(int id);
    Customer? Read(Func<Customer, bool> filter);
    List<Customer?> ReadAll(Func<Customer,bool>? filter);
    void Update(Customer customer);
    void Delete(int id);

}
