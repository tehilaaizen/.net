using BlApi;
namespace BlImplementation;

internal class SaleImplementation : ISale
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    public int Create(BO.Sale sale)
    {
       return _dal.sale.Create(sale.ConversBoSaleToDoSale());
    }

    public void Delete(int id)
    {
        _dal.sale.Delete(id);
    }

    public BO.Sale? Read(int id)
    {
        DO.Sale sale=_dal.sale.Read(id);
        return sale.ConversDoSaleToBoSale();
    }

    public BO.Sale? Read(Func<BO.Sale, bool> filter)
    {
        DO.Sale sale = _dal.sale.Read((Func<DO.Sale,bool>)filter);
        return sale.ConversDoSaleToBoSale();
    }

    public List<BO.Sale?> ReadAll(Func<BO.Sale, bool>? filter)
    {
        List<DO.Sale> list = _dal.sale.ReadAll((Func<DO.Sale, bool>)filter);
        List<BO.Sale> sales = new List<BO.Sale>();
        foreach(DO.Sale sale in list)
        {
            sales.Add(sale.ConversDoSaleToBoSale());
        }
        return sales;
    }

    public void Update(BO.Sale sale)
    {
        _dal.sale.Update(sale.ConversBoSaleToDoSale());
    }
}
