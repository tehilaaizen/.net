using BO;
using BlApi;

namespace BlImplementation;

internal class OrderImplementation : IOrder
{
    private DalApi.IDal _dal = DalApi.Factory.Get;
    List<SaleInProduct> IOrder.AddProductToOrder(Order order, int productId, int amount)
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

    void IOrder.CalcTotalPrice(Order order)
    {
        foreach (ProductInOrder p in order.Products)
            order.TotalPrice += p.TotalPrice;
    }

    void IOrder.CalcTotalPriceForProduct(ProductInOrder productInOrder)
    {
        int amount=productInOrder.AmountInOrder;
        List<SaleInProduct> implementedSales = new List<SaleInProduct>();
        foreach(SaleInProduct sale in productInOrder.Sales)
        {
            if (amount < sale.AmountToSale)
               continue;
            productInOrder.TotalPrice-=(amount / sale.AmountToSale) *(productInOrder.BasePrice)- sale.Price;
            implementedSales.Add(sale);
            amount -= (amount / sale.AmountToSale);
            if(amount==0) 
                break;
        }
        productInOrder.Sales = implementedSales;
    }

    void IOrder.DoOrder(Order order)
    {
        foreach(ProductInOrder p in order.Products)
        {
            BO.Product product=new BO.Product(p.Id,null,);
            _dal.product.Update()
        }
    }
    void IOrder.SearchSaleForProduct(ProductInOrder productInOrder, bool isMember)
    {
        ProductImplementation productImplementation = new ProductImplementation();
        productImplementation.GetSales(productInOrder, isMember);
    }
}
