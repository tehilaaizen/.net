namespace BO;

public class SaleInProduct
{
    public int Id { get; set; }
    public int AmountToSale { get; set; }
    public double Price { get; set; }
    public bool ToAllCustomers { get; set; }
    public override string ToString() => this.ToStringProperty();
    public SaleInProduct(int id,int amountToSale,double price,bool toAllCustomers)
    {
        Id = id;
        AmountToSale = amountToSale;
        Price = price;
        ToAllCustomers = toAllCustomers;
    }
    public SaleInProduct() { }
}
