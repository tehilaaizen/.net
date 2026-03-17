using DalApi;
using DO;
using System.Xml.Serialization;

namespace Dal;
internal class SaleImplementation : Isale
{
    private XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Sale>));
    private const string filePath = @"sales.xml";
    public int Create(Sale sale)
    {
        List<Sale> sales = new List<Sale>();
        sale = sale with { id = Config.SaleNum };
        using (StreamReader sr = new StreamReader(filePath))
        {
            sales = xmlSerializer.Deserialize(sr) as List<Sale>;
        }
        sales.Add(sale);
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            xmlSerializer.Serialize(sw, sales);
        }
        return sale.id;
    }

    public void Delete(int id)
    {
        List<Sale> sales = new List<Sale>();
        using (StreamReader sr = new StreamReader(filePath))
        {
            sales = xmlSerializer.Deserialize(sr) as List<Sale>;
        }
        foreach (Sale p in sales)
        {
            if (p != null && p.id == id)
            {
                sales.Remove(p);
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    xmlSerializer.Serialize(sw, sales);
                }
                return;
            }
        }
        throw new DalIdNotFoundException("sale not found");
    }

    public Sale? Read(int id)
    {
        List<Sale> sales = new List<Sale>();
        using (StreamReader sr = new StreamReader(filePath))
        {
            sales = xmlSerializer.Deserialize(sr) as List<Sale>;
        }
        foreach (Sale p in sales)
            if (p != null && p.id == id)
                return p;
        throw new DalIdNotFoundException("sale not found");
    }

    public Sale? Read(Func<Sale, bool> filter)
    {
        List<Sale> sales = new List<Sale>();
        using (StreamReader sr = new StreamReader(filePath))
        {
            sales = xmlSerializer.Deserialize(sr) as List<Sale>;
        }
        if (sales == null || !sales.Any())
            return null;
        return sales.First(filter);
    }

    public List<Sale?> ReadAll(Func<Sale, bool>? filter)
    {
        List<Sale> sales = new List<Sale>();
        using (StreamReader sr = new StreamReader(filePath))
        {
            sales = xmlSerializer.Deserialize(sr) as List<Sale>;
        }
        if (filter == null)
            return sales;
        return sales.Where(filter).ToList();
    }

    public void Update(Sale sale)
    {
        List<Sale> sales = new List<Sale>();
        using (StreamReader sr = new StreamReader(filePath))
        {
            sales = xmlSerializer.Deserialize(sr) as List<Sale>;
        }
        Delete(sale.id);
        sales.Add(sale);
        using (StreamWriter sr = new StreamWriter(filePath))
        {
            xmlSerializer.Serialize(sr, sales);
        }
    }
}
