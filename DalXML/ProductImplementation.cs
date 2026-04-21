using DalApi;
using DO;
using System.Xml.Serialization;

namespace Dal;
internal class ProductImplementation : IProduct
{
    private XmlSerializer xmlSerializer=new XmlSerializer(typeof(List<Product>));
    private const string filePath = @"products.xml";
    public int Create(Product product)
    {
        List<Product> products= new List<Product>();
        Product product1 = product with { id = Config.ProductNum };
        using (StreamReader sr = new StreamReader(filePath))
        {
            products=  xmlSerializer.Deserialize(sr) as List<Product>;
        }
        products.Add(product1);
        using(StreamWriter sw = new StreamWriter(filePath))
        {
            xmlSerializer.Serialize(sw, products);
        }
        return product1.id;
    }

    public void Delete(int id)
    {
        List<Product> products= new List<Product>();
        using(StreamReader sr = new StreamReader(filePath))
        {
            products=xmlSerializer.Deserialize(sr) as List<Product>;
        }
        foreach (Product p in products)
        {
            if (p != null && p.id == id)
            {
                products.Remove(p);
                using(StreamWriter sw = new StreamWriter(filePath))
                {
                    xmlSerializer.Serialize(sw,products);
                }
                return;
            }
        }
        throw new DalIdNotFoundException("product not found");
    }

    public Product? Read(int id)
    {
        List<Product> products = new List<Product>();
        using (StreamReader sr = new StreamReader(filePath))
        {
            products = xmlSerializer.Deserialize(sr) as List<Product>;
        }
        foreach (Product p in products)
            if (p != null && p.id == id)
                return p ;
        throw new DalIdNotFoundException("product not found");
    }

    public Product? Read(Func<Product, bool> filter)
    {
        List<Product>products = new List<Product>();
        using(StreamReader sr = new StreamReader(filePath))
        {
            products=xmlSerializer.Deserialize(sr) as List<Product>;
        }
        if (products==null||!products.Any())
            return null;
        return products.First(filter);
    }

    public List<Product?> ReadAll(Func<Product, bool>? filter)
    {
        List<Product> products = new List<Product>();
        using (StreamReader sr = new StreamReader(filePath))
        {
            products = xmlSerializer.Deserialize(sr) as List<Product>;
        }
        if (filter == null)
            return products;
        return products.Where(filter).ToList();
    }

    public void Update(Product product)
    {
        List<Product> products = new List<Product>();
        using (StreamReader sr = new StreamReader(filePath))
        {
            products = xmlSerializer.Deserialize(sr) as List<Product>;
        }
        Delete(product.id);
        products.Add(product);
        using(StreamWriter sr = new StreamWriter(filePath))
        {
            xmlSerializer.Serialize(sr, products);
        }
    }
}
