using BlApi;
using DO;
//using BO;

namespace BlImplementation;

internal class CustomerImplementation : ICustomer
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public int Create(BO.Customer customer)
    {
        return _dal.customer.Create(customer.ConversBoProductToDoProduct());
    }

    public void Delete(int id)
    {
        _dal.product.Delete(id);
    }

    public bool IsExist(BO.Customer customer)
    {
        try
        {
            _dal.product.Read(customer.Id);
            return true;
        }catch (DalIdNotFoundException e)
        {
            return false;
        }
    }

    public BO.Customer? Read(int id)
    {
        DO.Customer customer=_dal.customer.Read(id);
        return customer.ConversDoProductToBoProduct();
    }

    public BO.Customer? Read(Func<BO.Customer, bool> filter)
    {
        DO.Customer customer = _dal.customer.Read((Func<DO.Customer, bool>)filter);
        return customer.ConversDoProductToBoProduct();
    }

    public List<BO.Customer?> ReadAll(Func<BO.Customer, bool>? filter)
    {
        List<DO.Customer> customers= _dal.customer.ReadAll((Func<DO.Customer?, bool>)filter);
        List<BO.Customer> boCustomers=new List<BO.Customer>();
        foreach (DO.Customer customer in customers)
        {
            boCustomers.Add(customer.ConversDoProductToBoProduct());
        }
        return boCustomers;
    }

    public void Update(BO.Customer customer)
    {
        _dal.customer.Update(customer.ConversBoProductToDoProduct());
    }
}
