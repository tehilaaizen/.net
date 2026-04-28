namespace BO;

public class ProductInOrder
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double BasePrice { get; set; }
    public int AmountInOrder { get; set; }
    public List<SaleInProduct>? Sales { get; set; }
    public double TotalPrice { get; set; }
    public ProductInOrder(int id, string name, double basePrice, int amountInOrder, List<SaleInProduct>? sales, double totalPrice)
    {
        Id = id;
        Name = name;
        BasePrice = basePrice;
        AmountInOrder = amountInOrder;
        Sales = sales;
        TotalPrice = totalPrice;
    }
    public override string ToString() => this.ToStringProperty();

}
