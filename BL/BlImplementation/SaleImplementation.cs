using BlApi;
using BO;

namespace BlImplementation;

internal class SaleImplementation : ISale
{
    public int Create(Sale sale)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public Sale? Read(int id)
    {
        throw new NotImplementedException();
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        throw new NotImplementedException();
    }

    public List<Sale?> ReadAll(Func<Sale, bool>? filter)
    {
        throw new NotImplementedException();
    }

    public void Update(Sale sale)
    {
        throw new NotImplementedException();
    }
}
