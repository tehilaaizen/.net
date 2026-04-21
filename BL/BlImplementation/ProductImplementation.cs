using BlApi;
using BO;

namespace BlImplementation;

internal class ProductImplementation : IProduct
{
    public int Create(Product product)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public void GetSales(ProductInOrder productInOrder, bool isMember)
    {
        throw new NotImplementedException();
    }

    public Product? Read(int id)
    {
        throw new NotImplementedException();
    }

    public Product? Read(Func<Product, bool> filter)
    {
        throw new NotImplementedException();
    }

    public List<Product?> ReadAll(Func<Product, bool>? filter)
    {
        throw new NotImplementedException();
    }

    public void Update(Product product)
    {
        throw new NotImplementedException();
    }
}
