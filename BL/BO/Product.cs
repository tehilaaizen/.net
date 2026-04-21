namespace BO;

internal class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
    public List<SaleInProduct>? Sales { get; set; }
    public override string ToString() => this.ToStringProperty();

}
