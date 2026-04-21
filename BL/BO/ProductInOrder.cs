namespace BO;

public class ProductInOrder
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double BasePrice { get; set; }
    public int AmountInOrder { get; set; }
    public List<SaleInProduct>? Sales { get; set; }
    public double TotalPrice { get; set; }
    public override string ToString() => this.ToStringProperty();

}
