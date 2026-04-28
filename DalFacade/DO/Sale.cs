namespace DO;

public record Sale(
    int id,
    int barcode,
    int min_amount,
    double price,
    bool to_members,
    DateTime begin_date,
    DateTime end_date)
{
    public Sale() : this(0, 0, 0, 0, true, DateTime.Now,DateTime.Now) { }
}
