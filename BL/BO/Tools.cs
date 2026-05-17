using System.Reflection;

internal static class Tools
{
    public static string ToStringProperty<T>(this T t)
    {
        return "";
    }
 
    public static BO.Customer ConversDoProductToBoProduct(this DO.Customer customer)
    {
        return new BO.Customer(customer.id, customer.name,  customer.address,customer.phone_number);
    }
    public static BO.Sale ConversDoSaleToBoSale(this DO.Sale sale)
    {
        return new BO.Sale(sale.id,sale.barcode,sale.min_amount,sale.price,sale.to_members,sale.begin_date,sale.end_date);
    }
    public static BO.Product ConversDoProductToBoProduct(this DO.Product product)
    {
        return new BO.Product(product.id, product.name, (BO.Category)product.category, product.price, product.amount,null);
    }
    public static DO.Customer ConversBoProductToDoProduct(this BO.Customer customer)
    {
        return new DO.Customer(customer.Id, customer.Name, customer.Address, customer.PhoneNumber);
    }
    public static DO.Sale ConversBoSaleToDoSale(this BO.Sale sale)
    {
        return new DO.Sale(sale.Id,sale.Barcode,sale.MinAmount,sale.Price,sale.ToMembers,sale.BeginDate,sale.EndDate);
    }
    public static DO.Product ConversBoProductToDoProduct(this BO.Product product)
    {
        return new DO.Product(product.Id, product.Name, (DO.Category)product.Category, product.Price, product.Amount);
    }
    public static BO.SaleInProduct ConversDoSaleToBoSaleInProduct(this DO.Sale sale)
    {
        return new BO.SaleInProduct(sale.id, sale.min_amount, sale.price, sale.to_members);
    }
}
