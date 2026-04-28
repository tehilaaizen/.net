using BO;
using BlApi;

namespace BlImplementation;

internal class OrderImplementation : IOrder
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    List<SaleInProduct> AddProductToOrder(Order order, int productId, int amount)
    {
        DO.Product product = _dal.product.Read(productId);
        bool isExist = false;
        ProductInOrder currentProduct = null;
        foreach (ProductInOrder p in order.Products)
        {
            if (p.Id == productId)
            {
                isExist = true;
                currentProduct = p;
                if (p.AmountInOrder + amount > product.amount)
                    throw new BlNotEnoughInStockException("the amount is too big");
                else
                    p.AmountInOrder += amount;
            }
        }
        if (!isExist)
        {
            if (amount > product.amount)
                throw new BlNotEnoughInStockException("the amount is too big");
            else
            {
                currentProduct = new ProductInOrder(productId, product.name, product.price, amount, null, product.price * amount);
            }
        }
        SearchSaleForProduct(currentProduct, order.IsMemberCustomer);
        CalcTotalPriceForProduct(currentProduct);
        CalcTotalPrice(order);
        return currentProduct.Sales;
    }

    void CalcTotalPrice(Order order)
    {
        foreach (ProductInOrder p in order.Products)
            order.TotalPrice += p.TotalPrice;
    }

    void CalcTotalPriceForProduct(ProductInOrder productInOrder)
    {
        
    }

    void DoOrder(Order order)
    {
        throw new NotImplementedException();
    }

    void SearchSaleForProduct(ProductInOrder productInOrder, bool isMember)
    {
    }
}
