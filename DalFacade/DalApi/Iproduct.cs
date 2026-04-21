namespace DalApi;
using DO;
public interface IProduct : ICrud<Product>
{
    int Create(Product product);
    Product? Read(int id);
    Product? Read(Func<Product, bool> filter);
    List<Product?> ReadAll(Func<Product,bool>?filter);
    void Update(Product product);
    void Delete(int id);
}
