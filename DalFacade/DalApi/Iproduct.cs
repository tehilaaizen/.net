namespace DalApi;
using DO;
public interface Iproduct
{
    int Create(Product product);
    Product? Read(int id);
    List<Product> ReadAll();
    void Update(Product product);
    void Delete(int id);
}
