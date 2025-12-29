using DO;
using DalApi;
namespace Dal
{
    internal class ProductImplementation : Iproduct
    {
        public int Create(Product product)
        {
            Product product1 = product with { id = DataSource.Config.Product_id };
            DataSource.products.Add(product1);
            return product1.id;

        }
        public Product? Read(int id)
        {
            if (DataSource.products != null)
            {
                foreach (Product product in DataSource.products)
                {
                    if (product != null && product.id == id)
                        return product;
                }
            }
            throw new DalIdNotFoundException("product not found");
        }
        public List<Product> ReadAll()
        {
            if (DataSource.products == null)
                return null;
            return new List<Product>(DataSource.products);
        }
        public void Update(Product product)
        {
            if (DataSource.products != null)
            {
                foreach (Product p in DataSource.products)
                {
                    if (product != null && product.id==p.id)
                    {
                        DataSource.products.Remove(p);
                        DataSource.products.Add(product);
                        return;
                    }
                       
                }
                throw new DalIdNotFoundException("product not found");
            }
        }
        public void Delete(int id)
        {
            if (DataSource.products != null)
            {
                foreach (Product p in DataSource.products)
                {
                    if (p != null && p.id == id) { 
                        DataSource.products.Remove(p);
                        return;
                    }
                }
                throw new DalIdNotFoundException("product not found");
            }

        }
    }
}
