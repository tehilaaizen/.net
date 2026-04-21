namespace BO;

public class SaleInProduct
{
    public int Id { get; set; }
    public int AmountToSale { get; set; }
    public double Price { get; set; }
    public double ToAllCustomers { get; set; }
    public override string ToString() => this.ToStringProperty();

}
