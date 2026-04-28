using BlApi;
//using BO.;

namespace BlImplementation;

internal class ProductImplementation : IProduct
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public int Create(BO.Product product)
    {
        return _dal.product.Create(product.ConversBoProductToDoProduct());
    }

    public void Delete(int id)
    {
        _dal.product.Delete(id);
    }

    public void GetSales(BO.ProductInOrder productInOrder, bool isMember)
    {

    }

    public BO.Product? Read(int id)
    {
        DO.Product product=_dal.product.Read(id);
        return product.ConversDoProductToBoProduct();
    }

    public BO.Product? Read(Func<BO.Product, bool> filter)
    {
        DO.Product product = _dal.product.Read((Func<DO.Product,bool>)filter);
        return product.ConversDoProductToBoProduct();

    }

    public List<BO.Product?> ReadAll(Func<BO.Product, bool>? filter)
    {
        
    }

    public void Update(BO.Product product)
    {
        _dal.product.Update(product.ConversBoProductToDoProduct());
    }
}
