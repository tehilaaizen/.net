

using BO;

namespace BlApi;

public interface IProduct
{
    int Create(Product product);
   Product ? Read(int id);
    Product? Read(Func<Product, bool> filter);
    List<Product?> ReadAll(Func<Product, bool>? filter);
    void Update(Product product);
    void Delete(int id);
    void GetSales(ProductInOrder productInOrder, bool isMember);
}
