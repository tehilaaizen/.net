namespace BO;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Category Category { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }
    public List<SaleInProduct>? Sales { get; set; }
    public Product(int id, string name, Category category, double price, int amount, List<SaleInProduct>? sales)
    {
        Id = id;
        Name = name;
        Category = category;
        Price = price;
        Amount = amount;
        Sales = sales;
    }
    public override string ToString() => this.ToStringProperty();

}
