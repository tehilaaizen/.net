namespace DalApi;
using DO;
public interface Isale
{
    int Create(Sale sale);
    Sale? Read(int id);
    List<Sale> ReadAll();
    void Update(Sale sale);
    void Delete(int id);
}
