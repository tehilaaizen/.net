namespace BO;

public class Order
{
    public bool IsMemberCustomer { get; set; }
    public List<ProductInOrder> Products { get; set; }
    public double TotalPrice { get; set; }
    public override string ToString() => this.ToStringProperty();

}
