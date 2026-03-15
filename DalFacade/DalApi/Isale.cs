namespace DalApi;
using DO;
public interface Isale:ICrud<Sale>
{
    int Create(Sale sale);
    Sale? Read(int id);
    Sale? Read(Func<Sale, bool> filter);
    List<Sale?> ReadAll(Func<Sale,bool>?filter);
    void Update(Sale sale);
    void Delete(int id);
}
