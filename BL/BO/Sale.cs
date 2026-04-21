namespace BO;

public class Sale
{
    public int Id { get; set; }
    public int Barcode { get; set; }
    public int MinAmount { get; set; }
    public double Price { get; set; }
    public bool ToMembers { get; set; }
    public DateTime BeginDate { get; set; }
    public DateTime EndDate { get; set; }
    public override string ToString() => this.ToStringProperty();

}
