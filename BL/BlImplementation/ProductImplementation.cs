using BlApi;
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
        List<DO.Sale> sales = _dal.sale.ReadAll(sale => sale.barcode == productInOrder.Id);
        List<BO.SaleInProduct> salesInProduct=new List<BO.SaleInProduct>();
        foreach(DO.Sale sale in sales)
        {
           salesInProduct.Add(sale.ConversDoSaleToBoSaleInProduct());
        }
        productInOrder.Sales = salesInProduct;
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
        List<DO.Product> list = _dal.product.ReadAll((Func<DO.Product, bool>)filter);
        List<BO.Product> products = new List<BO.Product>();
        foreach (DO.Product product in list)
        {
            products.Add(product.ConversDoProductToBoProduct());
        }
        return products;
    }

    public void Update(BO.Product product)
    {
        _dal.product.Update(product.ConversBoProductToDoProduct());
    }
}
